Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_vacaciones
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Private Sub frm_buscar_vacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IdVacaciones,Empleados_vacaciones.SecondID,Fecha,Empleados.Nombre,ConceptoVacaciones FROM" & SysName.Text & "empleados_vacaciones INNER JOIN" & SysName.Text & "Empleados on Empleados_vacaciones.IDEmpleado=Empleados.IDEmpleado Where IDVacaciones like '%" + txtBuscar.Text + "%' ORDER BY IDVacaciones ASC", Con)
            ElseIf rdbNomina.Checked = True Then
                cmd = New MySqlCommand("SELECT IdVacaciones,Empleados_vacaciones.SecondID,Fecha,Empleados.Nombre,ConceptoVacaciones FROM" & SysName.Text & "empleados_vacaciones INNER JOIN" & SysName.Text & "Empleados on Empleados_vacaciones.IDEmpleado=Empleados.IDEmpleado Where ConceptoVacaciones like '%" + txtBuscar.Text + "%' ORDER BY ConceptoVacaciones ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Vacaciones")

            Bs.DataMember = "Vacaciones"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvVacaciones.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Sub LimpiartxtBuscar()

        rdbNomina.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvVacaciones
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "ID"
            .Columns(1).Width = 90
            .Columns(2).Width = 140
            .Columns(3).Width = 200
            .Columns(4).Width = 300
            .Columns(4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbNomina_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvVacaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvVacaciones.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvVacaciones.Focus()
    End Sub

    Private Sub DgvNominas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvVacaciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvVacaciones.Focus()
        End If
    End Sub

    Private Sub DgvVacaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvVacaciones.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvVacaciones.ColumnCount
                Dim NumRows As Integer = DgvVacaciones.RowCount
                Dim CurCell As DataGridViewCell = DgvVacaciones.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvVacaciones.CurrentCell = DgvVacaciones.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvVacaciones.CurrentCell = DgvVacaciones.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Dim IDVacaciones As New Label
        Dim DsTemp As New DataSet

        IDVacaciones.Text = DgvVacaciones.CurrentRow.Cells(0).Value

        DsTemp.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT idvacaciones,empleados_vacaciones.secondid,fecha,empleados_vacaciones.idempleado,empleados.nombre,fechasalida,fechaentrada,diaspagados,conceptovacaciones,montovacaciones,empleados_vacaciones.Nulo,RutaFoto,Empleados.Nombre,Salario,sumaletra,adjunto,fechaingreso FROM" & SysName.Text & "empleados_vacaciones inner join" & SysName.Text & "empleados on empleados_vacaciones.idempleado=empleados.idempleado Where empleados_vacaciones.idvacaciones='" + IDVacaciones.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Vacaciones")
        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("Vacaciones")

        If Me.Owner.Name = frm_empleados_vacaciones.Name Then
            frm_empleados_vacaciones.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
            frm_empleados_vacaciones.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_empleados_vacaciones.lblFechaIngreso.Text = CDate(Convert.ToString(Tabla.Rows(0).Item("FechaIngreso")))
            frm_empleados_vacaciones.lblSalario.Text = CDbl(Tabla.Rows(0).Item("Salario")).ToString("C")
            frm_empleados_vacaciones.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
            frm_empleados_vacaciones.txtIDVacaciones.Text = Tabla.Rows(0).Item("IDVacaciones")
            frm_empleados_vacaciones.txtFecha.Text = CDate(Convert.ToString(Tabla.Rows(0).Item("Fecha"))).ToString("yyyy-MM-dd HH:mm:ss")
            frm_empleados_vacaciones.txtDiasVacaciones.Text = Tabla.Rows(0).Item("diaspagados")
            frm_empleados_vacaciones.txtTotalVacaciones.Text = CDbl(Tabla.Rows(0).Item("montovacaciones")).ToString("C")
            frm_empleados_vacaciones.txtConcepto.Text = Tabla.Rows(0).Item("Conceptovacaciones")
            frm_empleados_vacaciones.dtpVacacionInicia.Value = CDate(Convert.ToString(Tabla.Rows(0).Item("FechaSalida")))
            frm_empleados_vacaciones.dtpVacacionTermina.Value = CDate(Convert.ToString(Tabla.Rows(0).Item("FechaEntrada")))
            frm_empleados_vacaciones.lblMontoLetras.Text = Tabla.Rows(0).Item("SumaLetra")
            frm_empleados_vacaciones.RutaDocumento = Tabla.Rows(0).Item("adjunto")

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("RutaFoto")) Then
                    MakeRoundedImageToPanel(My.Resources.no_photo, frm_empleados_vacaciones.PicCliente)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        MakeRoundedImageToPanel(System.Drawing.Image.FromStream(wFile), frm_empleados_vacaciones.PicCliente)
                        wFile.Close()
                    Else

                        MakeRoundedImageToPanel(My.Resources.no_photo, frm_empleados_vacaciones.PicCliente)
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("RutaFoto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If
            frm_empleados_vacaciones.FillVacaciones()
        End If

        Me.Close()

    End Sub


End Class