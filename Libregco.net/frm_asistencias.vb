Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraScheduler

Public Class frm_asistencias
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_asistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        CreateHeaders()
        LimpiarDatos()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
        LeerAsistencias()
    End Sub

    Private Sub CreateHeaders()
        Dim headers As New List(Of DGVMultiHeader)
        headers.Add(New DGVMultiHeader("Tandas", DiaHabil.Index, Empleado.Index))

        headers.Add(New DGVMultiHeader("Control", Validado.Index, Observacion.Index))

        Dim headerManager = New DGVMultiHeaderManager(DgvAsistencias, headers)

    End Sub
    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatos()
        DgvAsistencias.Rows.Clear()
    End Sub

    Private Sub ActualizarTodo()
        DgvBitacora.Rows.Clear()
        dtpFechaInicial.Value = Today
        dtpFechaFinal.Value = Today
        chkEspecificar.Checked = True
        XtraTabControl1.SelectedTabPageIndex = 0
        XtraTabControl1.TabPages(2).PageVisible = False
        SchedulerControl2.GoToToday()
        FillClasificaciones()
    End Sub

    Private Sub FillClasificaciones()
        Dim DsTemp As New DataSet

        Tipo.DataSource = Nothing
        Tipo.Items.Clear()

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDClasificacionPresencial,ClasificacionPresencial FROM libregco.clasificacionpresencial ORDER BY IDClasificacionPresencial ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "clasificacion")
        Tipo.ValueMember = "IDClasificacionPresencial"
        Tipo.DisplayMember = "ClasificacionPresencial"
        Tipo.DataSource = DsTemp.Tables("Clasificacion")
        ConLibregco.Close()

    End Sub
    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LeerAsistencias()

        DgvAsistencias.Rows.Clear()

        Dim EmployeePhoto As Image

        ConMixta.Open()
        Dim Consulta As New MySqlCommand

        If chkEspecificar.Checked = True Then
            Consulta.CommandText = "Select IDAsistencia,DiaHabil,Asistencias.IDEmpleado,Empleados.RutaFoto,Empleados.Nombre,IDTipoPresencia,DiaEfectivo,Observacion from" & SysName.Text & "Asistencias INNER JOIN" & SysName.Text & "Empleados on Asistencias.IDEmpleado=Empleados.IDEmpleado where DiaHabil=CurDate() ORDER BY IDAsistencia LIMIT 100"
        Else
            Consulta.CommandText = "Select IDAsistencia,DiaHabil,Asistencias.IDEmpleado,Empleados.RutaFoto,Empleados.Nombre,IDTipoPresencia,DiaEfectivo,Observacion from" & SysName.Text & "Asistencias INNER JOIN" & SysName.Text & "Empleados on Asistencias.IDEmpleado=Empleados.IDEmpleado Where DiaHabil Between  '" + dtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "'"
        End If

        Consulta.Connection = ConMixta

        Dim LectorUsuarios As MySqlDataReader = Consulta.ExecuteReader

        While LectorUsuarios.Read
            If TypeConnection.Text = 1 Then
                If LectorUsuarios.GetValue(3) = "" Then
                    EmployeePhoto = My.Resources.No_Image
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(LectorUsuarios.GetValue(3))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(LectorUsuarios.GetValue(3), FileMode.Open, FileAccess.Read)
                        EmployeePhoto = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        EmployeePhoto = My.Resources.No_Image
                    End If
                End If
            Else
                EmployeePhoto = My.Resources.No_Image
            End If


            DgvAsistencias.Rows.Add(LectorUsuarios.GetValue(0), CDate(LectorUsuarios.GetValue(1)).ToString("dd/MM/yyyy"), LectorUsuarios.GetValue(2), EmployeePhoto, LectorUsuarios.GetValue(4), LectorUsuarios.GetValue(5), Convert.ToBoolean(LectorUsuarios.GetValue(6)), LectorUsuarios.GetValue(7))

        End While

        LectorUsuarios.Close()
        ConMixta.Close()
        DgvAsistencias.ClearSelection()

    End Sub

    Private Sub dtpFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged
        LeerAsistencias()
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        LeerAsistencias()
    End Sub

    Private Sub chkEspecificar_CheckedChanged(sender As Object, e As EventArgs) Handles chkEspecificar.CheckedChanged
        If chkEspecificar.Checked = True Then
            dtpFechaFinal.Enabled = False
            dtpFechaInicial.Enabled = False
        Else
            dtpFechaInicial.Enabled = True
            dtpFechaFinal.Enabled = True
        End If
        LeerAsistencias()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        LeerAsistencias()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        Try

            If DgvAsistencias.Rows.Count > 0 Then
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                ConMixta.Open()

                For Each rw As DataGridViewRow In DgvAsistencias.Rows
                    sqlQ = "UPDATE Libregco.Asistencias SET DiaEfectivo='" + Convert.ToInt16(rw.Cells(6).Value).ToString + "',IDTipoPresencia='" + rw.Cells(5).Value.ToString + "',Observacion='" + rw.Cells(7).Value.ToString + "' Where IDAsistencia='" + rw.Cells(0).Value.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

                MessageBox.Show("Los registros de asistencias se han guardado satisfactoriamente.", "Asistencias actualizadas")

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvAsistencias_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvAsistencias.CurrentCellDirtyStateChanged
        If DgvAsistencias.IsCurrentCellDirty Then
            DgvAsistencias.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvAsistencias_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAsistencias.CellEndEdit
        DgvAsistencias.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If DgvAsistencias.Rows.Count > 0 Then
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvAsistencias.SelectedRows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea borrar los registros de asistencias de " & DgvAsistencias.CurrentRow.Cells(4).Value & " al día " & DgvAsistencias.CurrentRow.Cells(1).Value & "?", "Borrar registro de asistencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConMixta.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Asistencias SET DiaEfectivo=0,Observacion='',IDTipoPresencia=1 Where IDAsistencia='" + DgvAsistencias.CurrentRow.Cells(0).Value.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                    ConMixta.Close()

                    MessageBox.Show("Registro de asistencias reseteado satisfactoriamente.", "Registro modificado")
                End If
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub DgvAsistencias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAsistencias.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                DgvBitacora.Rows.Clear()
                ConMixta.Open()
                Dim Consulta As New MySqlCommand("SELECT IDAsistencias_detalles,FechaRegistro,if(Tipo=1,'Entrada','Salida') as Tipo,Tiempo FROM libregco.asistencias_detalles inner join Libregco.Asistencias on Asistencias_detalles.IDAsistencia=Asistencias.IDAsistencia where asistencias_detalles.IDAsistencia='" + DgvAsistencias.CurrentRow.Cells(0).Value.ToString + "'", ConMixta)
                Dim LectorBitacora As MySqlDataReader = Consulta.ExecuteReader

                While LectorBitacora.Read
                    DgvBitacora.Rows.Add(LectorBitacora.GetValue(0), LectorBitacora.GetValue(1), LectorBitacora.GetValue(2), LectorBitacora.GetValue(3), ConvertTimeSpantoLetter(LectorBitacora.GetValue(3)))
                End While
                LectorBitacora.Close()
                ConMixta.Close()

                Dim spanHorasLaboradas As New TimeSpan
                Dim spanHoraSalidas As New TimeSpan
                Dim CantSalidas As Integer = 0
                For Each row As DataGridViewRow In DgvBitacora.Rows
                    If row.Cells(2).Value = "Salida" Then
                        spanHorasLaboradas = spanHorasLaboradas + TimeSpan.Parse(row.Cells(3).Value.ToString)
                        CantSalidas = CantSalidas + 1
                        row.Cells(4).Value = row.Cells(4).Value & " en labores"
                    End If
                    If row.Cells(2).Value = "Entrada" Then
                        spanHoraSalidas = spanHoraSalidas + TimeSpan.Parse(row.Cells(3).Value.ToString)
                        row.Cells(4).Value = row.Cells(4).Value & " en ausencia de labor"
                    End If
                Next
                lblCantidadHoras.Text = spanHorasLaboradas.ToString
                lblTiempoSalidas.Text = spanHoraSalidas.ToString
                lblCantidadSalidas.Text = CantSalidas

                DgvBitacora.ClearSelection()
                XtraTabControl1.SelectedTabPageIndex = 1
                XtraTabControl1.TabPages(2).PageVisible = True

                LlenarGraficosxEmpleado(DgvAsistencias.Rows(e.RowIndex).Cells(2).Value)
            End If
        End If
    End Sub

    Private Sub DgvBitacora_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvBitacora.RowsAdded
        If DgvBitacora.Rows(e.RowIndex).Cells(2).Value = "Entrada" Then
            DgvBitacora.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Green
        Else
            DgvBitacora.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Red
        End If
    End Sub

    Private Function LlenarGraficosxEmpleado(ByVal IDEmpleado As String)
        Try
            Dim BStart As Boolean = False
            Dim BEnd As Boolean = False
            Dim StartDate As DateTime
            Dim EndDate As DateTime

            SchedulerControl2.DataStorage.Appointments.Clear()

            ConMixta.Open()
            Dim Consulta As New MySqlCommand("SELECT IDAsistencias_detalles,FechaRegistro,if(Tipo=1,'Entrada','Salida') as Tipo,Tiempo FROM libregco.asistencias_detalles inner join Libregco.Asistencias on Asistencias_detalles.IDAsistencia=Asistencias.IDAsistencia where Asistencias.IDEmpleado='" + IDEmpleado + "' and Asistencias.DiaHabil between '" + If(chkEspecificar.Checked = True, Today.AddYears(-50).ToString("yyyy-MM-dd"), dtpFechaInicial.Value.ToString("yyyy-MM-dd")) + "' and '" + If(chkEspecificar.Checked = True, Today.AddYears(+50).ToString("yyyy-MM-dd"), dtpFechaFinal.Value.ToString("yyyy-MM-dd")) + "'", ConMixta)
            Dim LectorBitacora As MySqlDataReader = Consulta.ExecuteReader

            While LectorBitacora.Read
                'Dim Tiempo As TimeSpan = TimeSpan.Parse(Convert.ToString(LectorBitacora.GetValue(3)))
                'Dim FechaChequeo As DateTime = LectorBitacora.GetValue(1)
                'Dim FechaResultado As DateTime = FechaChequeo.Add(Tiempo)
                If LectorBitacora.GetValue(2) = "Entrada" Then
                    StartDate = LectorBitacora.GetValue(1)
                    BStart = True
                ElseIf LectorBitacora.GetValue(2) = "Salida" Then
                    EndDate = LectorBitacora.GetValue(1)
                    BEnd = True
                End If

                If BStart = True And BEnd = True Then
                    Dim apt As Appointment = SchedulerControl2.DataStorage.CreateAppointment(AppointmentType.Normal)
                    apt.Start = StartDate
                    apt.End = EndDate

                    apt.Description = ConvertTimeSpantoLetter(LectorBitacora.GetValue(3))

                    If LectorBitacora.GetValue(2) = "Salida" Then
                        apt.Subject = "Activo"
                    Else
                        apt.Subject = "Ausencia"
                    End If

                    SchedulerControl2.GroupType = SchedulerGroupType.Resource
                    apt.ResourceId = SchedulerControl2.SelectedResource.Id
                    SchedulerControl2.DataStorage.Appointments.Add(apt)

                    BStart = False
                    BEnd = False
                End If
            End While

            LectorBitacora.Close()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Function

    Private Sub DgvBitacora_Resize(sender As Object, e As EventArgs) Handles DgvBitacora.Resize
        DgvBitacora.Columns(1).Width = CInt(DgvBitacora.Width * 0.15)
        DgvBitacora.Columns(2).Width = CInt(DgvBitacora.Width * 0.22)
        DgvBitacora.Columns(3).Width = CInt(DgvBitacora.Width * 0.23)
        DgvBitacora.Columns(4).Width = CInt(DgvBitacora.Width * 0.4)
    End Sub

    Private Sub DgvAsistencias_Resize(sender As Object, e As EventArgs) Handles DgvAsistencias.Resize
        Dim VScrollBarWidht As Integer = 0

        If VScrollBarVisible() = True Then
            VScrollBarWidht = 17
        Else
            VScrollBarWidht = 0
        End If

        Dim DatagridWith As Double = (DgvAsistencias.Width - DgvAsistencias.Columns(3).Width - DgvAsistencias.RowHeadersWidth - VScrollBarWidht - 20) / 100


        DgvAsistencias.Columns(1).Width = DatagridWith * 10
        DgvAsistencias.Columns(4).Width = DatagridWith * 30
        DgvAsistencias.Columns(5).Width = DatagridWith * 20
        DgvAsistencias.Columns(6).Width = DatagridWith * 10
        DgvAsistencias.Columns(5).Width = DatagridWith * 30
    End Sub

    Private Function VScrollBarVisible() As Boolean
        Dim ctrl As New Control
        For Each ctrl In DgvAsistencias.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing
    End Function
End Class