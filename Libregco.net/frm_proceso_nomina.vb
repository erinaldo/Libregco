Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_proceso_nomina

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Friend lblIDUsuario, IDEmpleado As New Label
    Dim ModificacionNomina As Boolean = False
    Dim DgvModificables As New DataGridView
    Dim Permisos As New ArrayList
    Dim NormalSizeNotes As Integer


    Private Sub frm_proceso_nomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToParent()
            'Me.WindowState = CheckWindowState()
            CargarEmpresa()
            CargarLibregco()
            Permisos = PasarPermisos(Me.Tag)
            SelectUsuario()
            LimpiarDatos()
            ActualizarTodo()
            ColumnsDgvEmpleados()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()

        If Now.Month = 12 Then
            SalarioDeNavidadToolStripMenuItem.Visible = True
        Else
            SalarioDeNavidadToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub LimpiarDatos()
        DgvEmpleados.Rows.Clear()
        txtSecondID.Clear()
        DtpFechaInicial.Value = Today
        DtpFechaFinal.Value = Today
        txtIDTipoNomina.Clear()
        txtTipoNomina.Clear()
        txtIDNomina.Clear()
        txtCantidadEmpleados.Clear()
        txtTotalBruto.Clear()
        txtTotalDeducciones.Clear()
        txtTotalNeto.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        CheckBox1.Checked = False
        chkDiario.Checked = False
        chkSemanal.Checked = False
        chkQuincenal.Checked = False
        chkMensual.Checked = False
        chkNulo.Checked = False
        ModificacionNomina = False
        ControlSuperClave = 1
        LabelStatus.Text = "Listo"
        CreateModificables()
        HabilitarControles()
    End Sub

    Private Sub CreateModificables()
        With DgvModificables
            .Columns.Clear()
            .Columns.Add("Codigo", "Codigo")
        End With
    End Sub

    Private Sub ColumnsDgvEmpleados()
        DgvEmpleados.Columns.Clear()
        With DgvEmpleados
            .Columns.Add("IDNominaDetalle", "IDNomDetalle") '0
            .Columns.Add("IDEmpleado", "Código") '1
            .Columns.Add("Nombre", "Nombre") '2
            .Columns.Add("Cargo", "Cargo") '3
            .Columns.Add("Sueldo", "Sueldo") '4
            .Columns.Add("Prestamo", "Préstamos") '5
            .Columns.Add("CXC", "CXC") '6
            .Columns.Add("Flota", "Flota") '7
            .Columns.Add("TSS", "TSS") '8
            .Columns.Add("ISR", "ISR") '9
            .Columns.Add("Deducciones", "Ded./Ing.") '10
            .Columns.Add("Neto", "Neto") '11
            .Columns.Add("Nota", "Nota")     '12
        End With
        PropiedadDgvEmpleados()
    End Sub

    Private Sub PropiedadDgvEmpleados()
        Try
            Dim DatagridWidth As Double = (DgvEmpleados.Width - DgvEmpleados.RowHeadersWidth) / 100

            With DgvEmpleados
                .Columns(0).Visible = False
                .Columns(0).ReadOnly = True

                .Columns(1).Visible = True
                .Columns(1).Width = DatagridWidth * 6
                .Columns(1).ReadOnly = True

                .Columns(2).Width = DatagridWidth * 22
                .Columns(2).ReadOnly = True

                .Columns(3).Width = DatagridWidth * 14
                .Columns(3).ReadOnly = True

                .Columns(4).Width = DatagridWidth * 7
                .Columns(4).DefaultCellStyle.Format = ("C")
                .Columns(4).DefaultCellStyle.ForeColor = Color.Blue
                .Columns(4).ReadOnly = True

                .Columns(5).Width = DatagridWidth * 7
                .Columns(5).DefaultCellStyle.Format = ("C")
                .Columns(5).DefaultCellStyle.ForeColor = Color.Red

                .Columns(6).Width = DatagridWidth * 7
                .Columns(6).DefaultCellStyle.Format = ("C")
                .Columns(6).DefaultCellStyle.ForeColor = Color.Red

                .Columns(7).Width = DatagridWidth * 7
                .Columns(7).DefaultCellStyle.Format = ("C")
                .Columns(7).DefaultCellStyle.ForeColor = Color.Red

                .Columns(8).Width = DatagridWidth * 7
                .Columns(8).DefaultCellStyle.ForeColor = Color.Red
                .Columns(8).DefaultCellStyle.Format = ("C")

                .Columns(9).Width = DatagridWidth * 7
                .Columns(9).DefaultCellStyle.ForeColor = Color.Red
                .Columns(9).DefaultCellStyle.Format = ("C")

                .Columns(10).Width = DatagridWidth * 7
                .Columns(10).DefaultCellStyle.ForeColor = Color.Black
                .Columns(10).DefaultCellStyle.Format = ("C")
                .Columns(10).ReadOnly = True

                .Columns(11).Width = DatagridWidth * 8
                .Columns(11).DefaultCellStyle.Format = ("C")
                .Columns(11).ReadOnly = True

                NormalSizeNotes = DatagridWidth * 25

                .Columns(12).Width = NormalSizeNotes
                .Columns(12).ReadOnly = False
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvEmpleados.CurrentCell.ColumnIndex

        If Columna = 4 Or Columna = 5 Or Columna = 6 Or Columna = 7 Or Columna = 8 Or Columna = 9 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvFacturas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvEmpleados.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub DgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEmpleados.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Or e.ColumnIndex = 12 Then
                DgvEmpleados.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If

    End Sub

    Private Sub DgvFacturas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvEmpleados.CurrentCellDirtyStateChanged
        If DgvEmpleados.IsCurrentCellDirty Then
            DgvEmpleados.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvFacturas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEmpleados.CellEndEdit
        DgvEmpleados.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Sub BuscarEmpleados()
        Try
            DgvEmpleados.Rows.Clear()
            ConMixta.Open()

            If txtIDNomina.Text = "" Then
                If chkDiario.Checked = True Then
                    Dim AnexarDiarios As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=1 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                    Dim LectorDiarios As MySqlDataReader = AnexarDiarios.ExecuteReader
                    While LectorDiarios.Read
                        DgvEmpleados.Rows.Add("", LectorDiarios.GetValue(0), LectorDiarios.GetValue(1), LectorDiarios.GetValue(2), (CDbl(LectorDiarios.GetValue(3) / 30)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), "")
                    End While
                    LectorDiarios.Close()
                End If

                If chkSemanal.Checked = True Then
                    Dim AnexarSemanal As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=2 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                    Dim LectorSemanal As MySqlDataReader = AnexarSemanal.ExecuteReader
                    While LectorSemanal.Read
                        DgvEmpleados.Rows.Add("", LectorSemanal.GetValue(0), LectorSemanal.GetValue(1), LectorSemanal.GetValue(2), (CDbl(LectorSemanal.GetValue(3) / 4)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), "")
                    End While
                    LectorSemanal.Close()
                End If

                If chkQuincenal.Checked = True Then
                    Dim AnexarQuincenal As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=3 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                    Dim LectorQuincenal As MySqlDataReader = AnexarQuincenal.ExecuteReader
                    While LectorQuincenal.Read
                        DgvEmpleados.Rows.Add("", LectorQuincenal.GetValue(0), LectorQuincenal.GetValue(1), LectorQuincenal.GetValue(2), (CDbl(LectorQuincenal.GetValue(3)) / 2).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), "")
                    End While
                    LectorQuincenal.Close()
                End If

                If chkMensual.Checked = True Then
                    Dim AnexarMensual As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=4 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                    Dim LectorMensual As MySqlDataReader = AnexarMensual.ExecuteReader
                    While LectorMensual.Read
                        DgvEmpleados.Rows.Add("", LectorMensual.GetValue(0), LectorMensual.GetValue(1), LectorMensual.GetValue(2), CDbl(LectorMensual.GetValue(3)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), "")
                    End While
                    LectorMensual.Close()
                End If

            Else
                If ModificacionNomina = False Then
                    Dim AnexarModificados As New MySqlCommand("SELECT IDNominaDetalle,NominaDetalle.IDEmpleado,Nombre,Cargo,Bruto,Prestamos,CXC,Flota,TSS,ISR,Deducciones,Neto FROM" & SysName.Text & "nominadetalle INNER JOIN" & SysName.Text & "Empleados on NominaDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where IDNomina='" + txtIDNomina.Text + "' ORDER BY NominaDetalle.IDEmpleado DESC", ConMixta)
                    Dim LectorMod As MySqlDataReader = AnexarModificados.ExecuteReader
                    While LectorMod.Read
                        DgvEmpleados.Rows.Add(LectorMod.GetValue(0), LectorMod.GetValue(1), LectorMod.GetValue(2), LectorMod.GetValue(3), CDbl(LectorMod.GetValue(4)).ToString("C"), CDbl(LectorMod.GetValue(5)).ToString("C"), CDbl(LectorMod.GetValue(6)).ToString("C"), CDbl(LectorMod.GetValue(7)).ToString("C"), CDbl(LectorMod.GetValue(8)).ToString("C"), CDbl(LectorMod.GetValue(9)).ToString("C"), CDbl(LectorMod.GetValue(10)).ToString("C"), CDbl(LectorMod.GetValue(11)).ToString("C"))
                    End While
                    LectorMod.Close()

                Else
                    If chkDiario.Checked = True Then
                        Dim AnexarDiarios As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=1 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                        Dim LectorDiarios As MySqlDataReader = AnexarDiarios.ExecuteReader
                        While LectorDiarios.Read
                            DgvEmpleados.Rows.Add("", LectorDiarios.GetValue(0), LectorDiarios.GetValue(1), LectorDiarios.GetValue(2), (CDbl(LectorDiarios.GetValue(3) / 30)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"))
                        End While
                        LectorDiarios.Close()
                    End If

                    If chkSemanal.Checked = True Then
                        Dim AnexarSemanal As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=2 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                        Dim LectorSemanal As MySqlDataReader = AnexarSemanal.ExecuteReader
                        While LectorSemanal.Read
                            DgvEmpleados.Rows.Add("", LectorSemanal.GetValue(0), LectorSemanal.GetValue(1), LectorSemanal.GetValue(2), (CDbl(LectorSemanal.GetValue(3) / 4)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"))
                        End While
                        LectorSemanal.Close()
                    End If

                    If chkQuincenal.Checked = True Then
                        Dim AnexarQuincenal As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=3 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                        Dim LectorQuincenal As MySqlDataReader = AnexarQuincenal.ExecuteReader
                        While LectorQuincenal.Read
                            DgvEmpleados.Rows.Add("", LectorQuincenal.GetValue(0), LectorQuincenal.GetValue(1), LectorQuincenal.GetValue(2), (CDbl(LectorQuincenal.GetValue(3)) / 2).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"))
                        End While
                        LectorQuincenal.Close()
                    End If

                    If chkMensual.Checked = True Then
                        Dim AnexarMensual As New MySqlCommand("Select IDEmpleado,Nombre,Cargo,Salario from" & SysName.Text & "empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.IDTipoNomina='" + txtIDTipoNomina.Text + "' AND IDPeriodoPago=4 AND HabilitarNomina=1 AND Empleados.Nulo=0", ConMixta)
                        Dim LectorMensual As MySqlDataReader = AnexarMensual.ExecuteReader
                        While LectorMensual.Read
                            DgvEmpleados.Rows.Add("", LectorMensual.GetValue(0), LectorMensual.GetValue(1), LectorMensual.GetValue(2), CDbl(LectorMensual.GetValue(3)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"))
                        End While
                        LectorMensual.Close()
                    End If

                End If

            End If

            ConMixta.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " BuscarEmpleado")
        End Try

    End Sub

    Private Sub CalcularNavidad()
        Try
            Dim Salario, IDEmpleado, FechaInicio As New Label
            Dim arrTiempoCalculo(2) As Integer
            Dim DgvMensualidades As New DataGridView


            DgvEmpleados.Columns(4).ReadOnly = False
            DgvEmpleados.Columns(5).Visible = False
            DgvEmpleados.Columns(6).Visible = False
            DgvEmpleados.Columns(7).Visible = False
            DgvEmpleados.Columns(8).Visible = False
            DgvEmpleados.Columns(9).Visible = False
            DgvEmpleados.Columns(10).Visible = False
            DgvEmpleados.Columns(11).Visible = False
            DgvEmpleados.Columns(12).Width = 600

            With DgvMensualidades
                .Columns.Add("No", "No.")
                .Columns.Add("Mes", "Mes")
                .Columns.Add("Salario", "Salario")
                .Columns.Add("Comisiones", "Comisiones")
                .Columns.Add("Totales", "Totales")
            End With

            DgvMensualidades.Rows.Clear()

            Con.Open()

            For Each row As DataGridViewRow In DgvEmpleados.Rows
                IDEmpleado.Text = row.Cells(1).Value

                cmd = New MySqlCommand("SELECT Salario FROM Empleados where IDEmpleado='" + IDEmpleado.Text + "'", Con)
                Salario.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT FechaIngreso FROM Empleados where IDEmpleado='" + IDEmpleado.Text + "'", Con)
                FechaInicio.Text = Convert.ToString(cmd.ExecuteScalar())


                Dim TiempoLaborado(2) As Integer

                DgvMensualidades.Rows.Clear()


                calcDifFechas(CDate(FechaInicio.Text), Today, arrTiempoCalculo)
                calcDifFechas(CDate(FechaInicio.Text), Today, TiempoLaborado)

                Dim MesesdeNomina As Integer = 1

                If arrTiempoCalculo(0) = 0 Then
                    MesesdeNomina = arrTiempoCalculo(1)
                Else
                    MesesdeNomina = 12
                End If

                Dim StartDate, FinalDate As Date
                Dim DsTemp As New DataSet

                ConLibregco.Open()

                For i As Integer = MesesdeNomina To 1 Step -1
                    DsTemp.Clear()

                    StartDate = DateSerial(Today.Year, Today.Month, 1).AddMonths(-i)
                    FinalDate = StartDate.AddMonths(1).AddDays(-1)


                    cmd = New MySqlCommand("SELECT Fecha,coalesce(sum(NominaDetalle.Bruto),0) as Bruto,coalesce(sum(if(NominaDetalle.Deducciones>0,NominaDetalle.Deducciones,0)),0) as Comisiones,coalesce(sum((nominaDetalle.Bruto+if(NominaDetalle.Deducciones>0,NominaDetalle.Deducciones,0))),0) as Total  FROM" & SysName.Text & "nominadetalle inner join" & SysName.Text & "nomina on nominadetalle.idnomina=nomina.idnomina where IDempleado='" + IDEmpleado.Text + "' and Fecha Between '" + StartDate.ToString("yyyy-MM-dd") + "' and '" + FinalDate.ToString("yyyy-MM-dd") + "' and Nomina.Nulo=0", ConLibregco)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Nomina")
                    Dim Tabla As DataTable = DsTemp.Tables("Nomina")

                    If Tabla.Rows.Count > 0 Then
                        If CDbl(Tabla.Rows(0).Item("Total")) > 0 Then
                            DgvMensualidades.Rows.Add(DgvMensualidades.Rows.Count + 1, MonthName(CDate(Convert.ToString(Tabla.Rows(0).Item("Fecha"))).Month, True) & " - " & CDate(Convert.ToString(Tabla.Rows(0).Item("Fecha"))).Year, CDbl(Tabla.Rows(0).Item("Bruto")).ToString("C"), CDbl(Tabla.Rows(0).Item("Comisiones")).ToString("C"), CDbl(Tabla.Rows(0).Item("Total")).ToString("C"))
                        End If
                    End If

                Next

                ConLibregco.Close()

                'If arrTiempoCalculo(0) = 0 Then
                '    If arrTiempoCalculo(1) <> DgvMensualidades.Rows.Count Then
                '        MessageBox.Show("No es posible establecer los derechos adquiridos a través de este método ya que la antiguedad del empleado excede la antiguedad de los registros de nómina." & vbNewLine & vbNewLine & "Utilice la herramienta en el módulo Nómina->Procesos->Préstaciones Laborales", "No es posible verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '        Exit Sub
                '    End If
                'End If

                Dim Mensaje As String = ""

                If TiempoLaborado(0) > 0 Then
                    Mensaje += TiempoLaborado(0) & If(TiempoLaborado(0) > 1, " años", " año")

                    If TiempoLaborado(1) > 0 Then

                        If TiempoLaborado(2) > 0 Then
                            Mensaje += ", " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                            Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                        Else

                            Mensaje += " y " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")

                        End If


                    ElseIf TiempoLaborado(2) > 0 Then
                        Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                    End If

                ElseIf TiempoLaborado(1) > 0 Then
                    If TiempoLaborado(2) > 0 Then
                        Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                        Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")

                    Else

                        Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                    End If

                ElseIf TiempoLaborado(2) > 0 Then
                    Mensaje += TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                End If


                '''''''''''''''''''''''''''''''''''''''

                If DgvMensualidades.Rows.Count > 0 Then
                    Dim SueldoAcumulado As Double = 0
                    Dim promediodiario As Double = 0

                    For Each rw As DataGridViewRow In DgvMensualidades.Rows
                        SueldoAcumulado += CDbl(rw.Cells(4).Value)
                    Next

                    Dim Coeficiente As Double = 1

                    Dim promedioMensual As Double = 0
                    If arrTiempoCalculo(0) > 0 Then
                        promedioMensual = (SueldoAcumulado / 12) * Coeficiente

                    ElseIf arrTiempoCalculo(1) > 0 Then
                        promedioMensual = (SueldoAcumulado / arrTiempoCalculo(1)) * Coeficiente

                    Else
                        promedioMensual = SueldoAcumulado * Coeficiente
                    End If

                    promediodiario = (promedioMensual / 23.83)

                    ' Calcular Preaviso
                    Dim mesesPreaviso As Integer = ((arrTiempoCalculo(0) * 12) + arrTiempoCalculo(1))
                    Dim diaspreaviso As Integer = 0
                    Dim totalpreaviso As Double = 0

                    Select Case (True)
                        Case (mesesPreaviso >= 12)
                            diaspreaviso = 28
                        Case (mesesPreaviso >= 6)
                            diaspreaviso = 14
                        Case (mesesPreaviso >= 3)
                            diaspreaviso = 7
                    End Select

                    totalpreaviso = (CDbl(promedioMensual / 23.83)) * diaspreaviso

                    ' Cesantia
                    Dim fechaingreso(2) As Integer
                    fechaingreso(0) = CDate(FechaInicio.Text).Day
                    fechaingreso(1) = CDate(FechaInicio.Text).Month
                    fechaingreso(2) = CDate(FechaInicio.Text).Year

                    Dim fechasalida(2) As Integer
                    fechasalida(0) = 31
                    fechasalida(1) = 12
                    fechasalida(2) = Now.Year

                    Dim fecha1 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))
                    Dim fecha2 As Date = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                    Dim d1 As Date = New Date(1992, 5, 17)
                    Dim d2 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))

                    Dim TiempoAntesCodigo(3) As Integer
                    Dim TiempoDespuesCodigo(3) As Integer
                    Dim iDiasCensantiaAnterior = 0

                    If d1 > d2 Then
                        calcDifFechas(d2, d1, TiempoAntesCodigo)
                        d2 = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                        calcDifFechas(d1, d2, TiempoDespuesCodigo)

                        If (TiempoAntesCodigo(0) > 0) Then
                            iDiasCensantiaAnterior = TiempoAntesCodigo(0) * 15
                        End If

                        ''Ajuste en los meses despues del codigo con la suma de los dias antes y despues
                        If ((TiempoAntesCodigo(2) + TiempoDespuesCodigo(2)) >= 30) Then
                            TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + 1
                        End If

                        'Ajuste en los anos despues del codigo con la suma de los anos antes y despues

                        If ((TiempoDespuesCodigo(1) + TiempoAntesCodigo(1)) >= 12) Then
                            TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + TiempoAntesCodigo(1) - 12
                            TiempoDespuesCodigo(0) = TiempoDespuesCodigo(0) + 1
                        End If

                    Else

                        TiempoDespuesCodigo(0) = arrTiempoCalculo(0)
                        TiempoDespuesCodigo(1) = arrTiempoCalculo(1)
                        TiempoDespuesCodigo(2) = arrTiempoCalculo(2)
                    End If

                    Dim iDiasCesantiaNueva As Integer = 0

                    If (TiempoDespuesCodigo(0) >= 5) Then
                        iDiasCesantiaNueva = iDiasCesantiaNueva + (23 * TiempoDespuesCodigo(0))
                    ElseIf (TiempoDespuesCodigo(0) >= 1) Then
                        iDiasCesantiaNueva = iDiasCesantiaNueva + (21 * TiempoDespuesCodigo(0))
                    End If

                    If (TiempoDespuesCodigo(1) >= 6) Then
                        iDiasCesantiaNueva = (iDiasCesantiaNueva + 13)
                    ElseIf (TiempoDespuesCodigo(1) >= 3) Then
                        iDiasCesantiaNueva = (iDiasCesantiaNueva + 6)
                    End If

                    Dim cCesantiaAnterior As Double = (iDiasCensantiaAnterior * promediodiario * 100) / 100
                    Dim cCesantiaNueva As Double = (iDiasCesantiaNueva * promediodiario * 100) / 100

                    'Salario de navidad
                    Dim SalarioNavidad As Double = 0

                    Dim arrTiempoNavidad(2) As Integer
                    Dim dd1 As New Date
                    If CDate(FechaInicio.Text) > DateSerial(Today.Year, 1, 1) Then
                        dd1 = CDate(FechaInicio.Text)
                    Else
                        dd1 = DateSerial(Today.Year, 1, 1)
                    End If

                    Dim dd2 As New Date
                    dd2 = DateSerial(Now.Year, 12, 31)

                    calcDifFechas(dd1, dd2, arrTiempoNavidad)

                    Dim totaldiasmes As Integer = diasMes(fechasalida(1), fechasalida(2))

                    If (arrTiempoNavidad(0) > 0) Then
                        SalarioNavidad = promedioMensual

                    Else
                        SalarioNavidad = ((arrTiempoNavidad(1) * promedioMensual) + (((arrTiempoNavidad(2) * 23.83) / totaldiasmes) * promediodiario)) / 12
                    End If


                    'Mostrar el tiempo de navidad
                    Dim tiempoNavidad As String = ""

                    If (arrTiempoNavidad(0) > 0) Then
                        tiempoNavidad = " (1 Año)"

                    ElseIf (arrTiempoNavidad(1) > 0) Then
                        tiempoNavidad = " ("
                        tiempoNavidad += arrTiempoNavidad(1) & If(arrTiempoNavidad(1) > 1, " meses", " mes")

                        If (arrTiempoNavidad(2) > 0) Then
                            tiempoNavidad += " y " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                        End If

                        tiempoNavidad += ")"

                    Else

                        tiempoNavidad = " " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                    End If

                    row.Cells(4).Value = CDbl(SalarioNavidad).ToString("C")
                    row.Cells(12).Value = tiempoNavidad

                End If


            Next

            Con.Close()

            DgvMensualidades.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Function diasMes(ByVal mes As Integer, ByVal anno As Integer) As Integer
        Select Case (mes)
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31

            Case 2
                If Date.IsLeapYear(anno) Then
                    Return 29
                Else
                    Return 28
                End If

            Case Else
                Return 30
        End Select

    End Function

    Private Sub BuscarDeducciones()
        Try
            Dim TssValue, IDEmpleado, BalanceEmpleado, Salario, SalarioTotal, ValorPeriodo, CuotaPrestamo, CuotaCXC, ConsumoFlota, CobrarTss, SeguroComplementario, ISR As New Label

            Con.Open()
            ConMixta.Open()

            'Conseguir tasa de TSS
            cmd = New MySqlCommand("SELECT Value3Double FROM configuracion where IDConfiguracion=77", Con)
            TssValue.Text = Convert.ToDouble(cmd.ExecuteScalar())

            For Each row As DataGridViewRow In DgvEmpleados.Rows
                IDEmpleado.Text = row.Cells(1).Value
                Salario.Text = row.Cells(4).Value

                'Conseguir salario bruto mensual
                cmd = New MySqlCommand("SELECT Cotizable FROM Empleados where IDEmpleado='" + IDEmpleado.Text + "'", Con)
                SalarioTotal.Text = Convert.ToDouble(cmd.ExecuteScalar())

                'Buscar valor de periodo pago
                cmd = New MySqlCommand("SELECT PeriodoPago FROM Libregco.periodopago INNER JOIN" & SysName.Text & "Empleados on PeriodoPago.IDPeriodoPago=Empleados.IDPeriodoPago Where Empleados.IDEmpleado='" + IDEmpleado.Text + "'", Con)
                ValorPeriodo.Text = Convert.ToDouble(cmd.ExecuteScalar())

                'Buscando préstamos
                cmd = New MySqlCommand("Select Balance from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                BalanceEmpleado.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If CDbl(BalanceEmpleado.Text) > 0 Then
                    cmd = New MySqlCommand("Select CuotaPrestamo from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                    CuotaPrestamo.Text = Convert.ToDouble(cmd.ExecuteScalar())
                    If CDbl(CuotaPrestamo.Text) < CDbl(BalanceEmpleado.Text) Then
                        row.Cells(5).Value = CDbl(CuotaPrestamo.Text).ToString("C")
                    Else
                        row.Cells(5).Value = CDbl(BalanceEmpleado.Text).ToString("C")
                    End If
                Else
                    row.Cells(5).Value = CDbl(0).ToString("C")
                End If

                'Buscando cxc
                cmd = New MySqlCommand("Select CuotaCuenta from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                CuotaCXC.Text = Convert.ToDouble(cmd.ExecuteScalar())
                row.Cells(6).Value = CDbl(CuotaCXC.Text).ToString("C")

                'Buscando consumo flota base
                cmd = New MySqlCommand("Select ConsumoFlota from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                ConsumoFlota.Text = Convert.ToDouble(cmd.ExecuteScalar())
                row.Cells(7).Value = CDbl(ConsumoFlota.Text).ToString("C")

                'Buscando Tss
                cmd = New MySqlCommand("Select CobrarTss from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                CobrarTss.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SeguroComplementario from Empleados Where IDEmpleado = '" + IDEmpleado.Text + "'", Con)
                SeguroComplementario.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If CobrarTss.Text = 1 Then
                    row.Cells(8).Value = (((CDbl(SalarioTotal.Text) * CDbl(TssValue.Text)) / CDbl(ValorPeriodo.Text)) + (CDbl(SeguroComplementario.Text) / CDbl(ValorPeriodo.Text))).ToString("C")
                Else
                    row.Cells(8).Value = CDbl(0).ToString("C")
                End If

                'Buscar ISR
                cmd = New MySqlCommand("SELECT Tasa FROM Libregco.retisr Where Desde<='" + SalarioTotal.Text + "' and Hasta>='" + SalarioTotal.Text + "' and Nulo=0", ConMixta)
                ISR.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If ISR.Text > 0 Then
                    Dim SalarioDep As Double = CDbl(SalarioTotal.Text) / CDbl(Salario.Text)
                    row.Cells(9).Value = ((CDbl(SalarioTotal.Text) * CDbl(ISR.Text)) / SalarioDep).ToString("C")
                Else
                    row.Cells(9).Value = CDbl(0).ToString("C")
                End If

                'Buscar resultado de deducciones e ingresos
                'Nuevos ingresos
                cmd = New MySqlCommand("SELECT Coalesce(Sum(if(Funcion='-',-Monto,Monto)),0) as Resultado FROM" & SysName.Text & "deduccionesprocdetalle INNER JOIN Libregco.Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN Libregco.TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion INNER JOIN" & SysName.Text & "DeduccionesProcesadas on DeduccionesProcDetalle.IDDeduccionProcesada=DeduccionesProcesadas.IDeduccionesProcesadas Where IDEmpleado='" + IDEmpleado.Text + "' and deduccionesprocdetalle.Fecha Between '" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "' and deduccionesprocdetalle.IDNominaEmpleados IS NULL and DeduccionesProcesadas.Nulo=0", ConMixta)
                Dim NuevosIng As Double = Convert.ToDouble(cmd.ExecuteScalar())

                'Ingresos ya procesados
                cmd = New MySqlCommand("SELECT Coalesce(Sum(if(Funcion='-',-Monto,Monto)),0) as Resultado FROM" & SysName.Text & "deduccionesprocdetalle INNER JOIN Libregco.Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN Libregco.TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion INNER JOIN" & SysName.Text & "DeduccionesProcesadas on DeduccionesProcDetalle.IDDeduccionProcesada=DeduccionesProcesadas.IDeduccionesProcesadas INNER JOIN" & SysName.Text & "Nominadetalle on deduccionesprocdetalle.IDNominaEmpleados=nominadetalle.IDNominaDetalle Where NominaDetalle.IDEmpleado='" + row.Cells(1).Value.ToString + "' and NominaDetalle.IDNomina='" + txtIDNomina.Text + "' and  DeduccionesProcesadas.Nulo=0", ConMixta)
                Dim YaProcesados As Double = Convert.ToDouble(cmd.ExecuteScalar())

                row.Cells(10).Value = CDbl(NuevosIng + YaProcesados).ToString("C")

                If CDbl(row.Cells(10).Value) > 0 Then
                    row.Cells(10).Style.ForeColor = Color.Blue
                ElseIf CDbl(row.Cells(10).Value) < 0 Then
                    row.Cells(10).Style.ForeColor = Color.Red
                ElseIf CDbl(row.Cells(10).Value) = 0 Then
                    row.Cells(10).Style.ForeColor = Color.Black
                End If

                row.Cells(11).Value = (CDbl(row.Cells(4).Value) - CDbl(row.Cells(5).Value) - CDbl(row.Cells(6).Value) - CDbl(row.Cells(7).Value) - CDbl(row.Cells(8).Value) - CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value)).ToString("C")
            Next

            Con.Close()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SumarRows()
        Dim SueldoBruto, Corrientes, Ingresos, TotalNeto As New Label
        SueldoBruto.Text = 0
        Ingresos.Text = 0
        TotalNeto.Text = 0
        Corrientes.Text = 0

        For Each row As DataGridViewRow In DgvEmpleados.Rows
            SueldoBruto.Text = SueldoBruto.Text + CDbl(row.Cells(4).Value)
            Ingresos.Text = Ingresos.Text + CDbl(row.Cells(10).Value)
            TotalNeto.Text = TotalNeto.Text + CDbl(row.Cells(11).Value)
            Corrientes.Text = Corrientes.Text + CDbl(row.Cells(5).Value) + CDbl(row.Cells(6).Value) + CDbl(row.Cells(7).Value) + CDbl(row.Cells(8).Value) + CDbl(row.Cells(9).Value)
        Next

        txtTotalBruto.Text = CDbl(SueldoBruto.Text).ToString("C")
        txtDeduccionesCorrientes.Text = CDbl(Corrientes.Text).ToString("C")
        txtTotalDeducciones.Text = CDbl(Ingresos.Text).ToString("C")
        txtTotalNeto.Text = CDbl(TotalNeto.Text).ToString("C")
        txtCantidadEmpleados.Text = DgvEmpleados.Rows.Count
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltNomina()

        If txtIDNomina.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDNomina from Nomina where IDNomina= (Select Max(IDNomina) from Nomina)", Con)
            txtIDNomina.Text = Convert.ToDouble(cmd.ExecuteScalar)
            Con.Close()
        End If
    End Sub

    Private Sub HabilitarControles()
        GbDatos.Enabled = True
        Gb2.Enabled = True
        DgvEmpleados.Enabled = True
        btnBuscar.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GbDatos.Enabled = False
        Gb2.Enabled = False
        DgvEmpleados.Enabled = False
        btnBuscar.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If txtIDNomina.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la nómina procesada?", "Imprimir Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub InsertDetalle()
        Con.Open()

        For Each rw As DataGridViewRow In DgvEmpleados.Rows
            If Convert.ToString(rw.Cells(0).Value).ToString = "" Then
                sqlQ = "INSERT INTO NominaDetalle (IDNomina,IDEmpleado,Bruto,Prestamos,CXC,Flota,TSS,ISR,Deducciones,Neto,Nota) VALUES ('" + txtIDNomina.Text + "','" + rw.Cells(1).Value.ToString + "','" + CDbl(rw.Cells(4).Value).ToString + "','" + CDbl(rw.Cells(5).Value).ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + CDbl(rw.Cells(7).Value).ToString + "','" + CDbl(rw.Cells(8).Value).ToString + "','" + CDbl(rw.Cells(9).Value).ToString + "','" + CDbl(rw.Cells(10).Value).ToString + "','" + CDbl(rw.Cells(11).Value).ToString + "','" + CStr(Convert.ToString(rw.Cells(12).Value)).ToString + "') "
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDNominaDetalle from nominadetalle where IDNominaDetalle= (Select Max(IDNominaDetalle) from nominadetalle)", Con)
                rw.Cells(0).Value = Convert.ToDouble(cmd.ExecuteScalar)

            Else
                sqlQ = "UPDATE NominaDetalle SET IDNomina='" + txtIDNomina.Text + "',IDEmpleado='" + rw.Cells(1).Value.ToString + "',Bruto='" + CDbl(rw.Cells(4).Value).ToString + "',Prestamos='" + CDbl(rw.Cells(5).Value).ToString + "',CXC='" + CDbl(rw.Cells(6).Value).ToString + "',Flota='" + CDbl(rw.Cells(7).Value).ToString + "',TSS='" + CDbl(rw.Cells(8).Value).ToString + "',ISR='" + CDbl(rw.Cells(9).Value).ToString + "',Deducciones='" + CDbl(rw.Cells(10).Value).ToString + "',Neto='" + CDbl(rw.Cells(11).Value).ToString + "',Nota='" + CStr(Convert.ToString(rw.Cells(12).Value)).ToString + "' WHERE IDNominaDetalle= (" + rw.Cells(0).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

            AnexarDeducciones(CDbl(rw.Cells(0).Value), CDbl(rw.Cells(1).Value))

        Next

        Con.Close()

    End Sub

    Private Sub btnBuscarNomina_Click(sender As Object, e As EventArgs) Handles btnBuscarNomina.Click
        frm_buscar_tipo_nomina.ShowDialog(Me)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_historial_nominas.ShowDialog(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()

        DgvEmpleados.Columns(4).ReadOnly = True
        DgvEmpleados.Columns(5).Visible = True
        DgvEmpleados.Columns(6).Visible = True
        DgvEmpleados.Columns(7).Visible = True
        DgvEmpleados.Columns(8).Visible = True
        DgvEmpleados.Columns(9).Visible = True
        DgvEmpleados.Columns(10).Visible = True
        DgvEmpleados.Columns(11).Visible = True
        DgvEmpleados.Columns(12).Width = NormalSizeNotes
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Nómina No. " & txtSecondID.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 94
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                sqlQ = "UPDATE Nomina SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',FechaInicial='" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',Diario='" + Convert.ToInt16(chkDiario.Checked).ToString + "',Semanal='" + Convert.ToInt16(chkSemanal.Checked).ToString + "',Quincenal='" + Convert.ToInt16(chkQuincenal.Checked).ToString + "',Mensual='" + Convert.ToInt16(chkMensual.Checked).ToString + "',TotalBruto='" + CDbl(txtTotalBruto.Text).ToString + "',Corrientes='" + CDbl(txtDeduccionesCorrientes.Text).ToString + "',Deducciones='" + CDbl(txtTotalDeducciones.Text).ToString + "',Neto='" + CDbl(txtTotalNeto.Text).ToString + "',CantEmp='" + txtCantidadEmpleados.Text + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDNomina= (" + txtIDNomina.Text + ")"
                GuardarDatos()
                EliminarModificados()
                InsertDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDNomina.Text = "" Then
            MessageBox.Show("No hay un registro de nómina abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la nómina No. " & txtSecondID.Text & " del sistema?", "Anular Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 93
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                sqlQ = "UPDATE Nomina SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',FechaInicial='" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',Diario='" + Convert.ToInt16(chkDiario.Checked).ToString + "',Semanal='" + Convert.ToInt16(chkSemanal.Checked).ToString + "',Quincenal='" + Convert.ToInt16(chkQuincenal.Checked).ToString + "',Mensual='" + Convert.ToInt16(chkMensual.Checked).ToString + "',TotalBruto='" + CDbl(txtTotalBruto.Text).ToString + "',Corrientes='" + CDbl(txtDeduccionesCorrientes.Text).ToString + "',Deducciones='" + CDbl(txtTotalDeducciones.Text).ToString + "',Neto='" + CDbl(txtTotalNeto.Text).ToString + "',CantEmp='" + txtCantidadEmpleados.Text + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDNomina= (" + txtIDNomina.Text + ")"
                GuardarDatos()
                EliminarModificados()
                InsertDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If CDate(DtpFechaFinal.Value.ToString("yyyy-MM-dd")) < CDate(DtpFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            MessageBox.Show("La fecha inicial es mayor a la fecha inicial." & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar la nómina.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtIDTipoNomina.Text = "" Then
            MessageBox.Show("Seleccione el tipo de nómina a procesar.", "Seleccionar Nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarNomina.PerformClick()
            Exit Sub
        ElseIf chkDiario.Checked = False And chkSemanal.Checked = False And chkQuincenal.Checked = False And chkMensual.Checked = False Then
            MessageBox.Show("Seleccione al menos una frecuencia de pago para buscar los clientes bajo esa condición.", "Marque la(s) frecuencia(s) de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf DgvEmpleados.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado empleados hábiles para procesar la nómina. Por favor modifique las condiciones o haga click 'Buscar'.", "No se encontraron empleados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDNomina.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la nueva nómina con fecha del " & DtpFechaInicial.Text & " al " & DtpFechaFinal.Text & "?", "Guardar Nueva Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Nomina (IDSucursal,IDAlmacen,IDEquipo,IDTipoDocumento,Fecha,Hora,IDUsuario,IDTipoNomina,FechaInicial,FechaFinal,Diario,Semanal,Quincenal,Mensual,TotalBruto,Corrientes,Deducciones,Neto,CantEmp,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',36,'" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtIDTipoNomina.Text + "','" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "','" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(chkDiario.Checked).ToString + "','" + Convert.ToInt16(chkSemanal.Checked).ToString + "','" + Convert.ToInt16(chkQuincenal.Checked).ToString + "','" + Convert.ToInt16(chkMensual.Checked).ToString + "','" + CDbl(txtTotalBruto.Text).ToString + "','" + CDbl(txtDeduccionesCorrientes.Text).ToString + "','" + CDbl(txtTotalDeducciones.Text).ToString + "','" + CDbl(txtTotalNeto.Text).ToString + "','" + txtCantidadEmpleados.Text + "',0,'" + Convert.ToInt16(chkNulo.Checked).ToString + "' )"
                GuardarDatos()
                UltNomina()
                SetSecondID()
                InsertDetalle()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nómina?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Nomina SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',FechaInicial='" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',Diario='" + Convert.ToInt16(chkDiario.Checked).ToString + "',Semanal='" + Convert.ToInt16(chkSemanal.Checked).ToString + "',Quincenal='" + Convert.ToInt16(chkQuincenal.Checked).ToString + "',Mensual='" + Convert.ToInt16(chkMensual.Checked).ToString + "',TotalBruto='" + CDbl(txtTotalBruto.Text).ToString + "',Corrientes='" + CDbl(txtDeduccionesCorrientes.Text).ToString + "',Deducciones='" + CDbl(txtTotalDeducciones.Text).ToString + "',Neto='" + CDbl(txtTotalNeto.Text).ToString + "',CantEmp='" + txtCantidadEmpleados.Text + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDNomina= (" + txtIDNomina.Text + ")"
                GuardarDatos()
                EliminarModificados()
                InsertDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Function AnexarDeducciones(ByVal IDNominaEmpleado As Double, ByVal IDEmpleado As Double)
        Dim dstemp As New DataSet

        cmd = New MySqlCommand("SELECT IDDeduccionesProcDetalle,Monto FROM" & SysName.Text & "deduccionesprocdetalle INNER JOIN Libregco.Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN Libregco.TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion INNER JOIN" & SysName.Text & "DeduccionesProcesadas on DeduccionesProcDetalle.IDDeduccionProcesada=DeduccionesProcesadas.IDeduccionesProcesadas Where IDEmpleado='" + IDEmpleado.ToString + "' and deduccionesprocdetalle.Fecha Between '" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "' and DeduccionesProcesadas.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "deduccionesprocdetalle")

        For Each dt As DataRow In dstemp.Tables("deduccionesprocdetalle").Rows
            sqlQ = "UPDATE" & SysName.Text & "deduccionesprocdetalle SET IDNominaEmpleados='" + IDNominaEmpleado.ToString + "' where IDDeduccionesProcDetalle='" + dt.Item(0).ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Next

    End Function


    Private Sub EliminarModificados()
        Try
            If ModificacionNomina = True Then
                Con.Open()

                For Each row As DataGridViewRow In DgvModificables.Rows
                    If IsNumeric(row.Cells(0).Value) Then

                        sqlQ = "UPDATE Deduccionesprocdetalle SET IDNominaEmpleados=NULL Where IDNominaEmpleados='" + row.Cells(0).Value.ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        sqlQ = "Delete from NominaDetalle Where IDNominaDetalle= (" + row.Cells(0).Value.ToString + ")"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()


                    End If
                Next

                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error desde eliminar modificados")
        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=36", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Nomina SET SecondID='" + lblSecondID.Text + "' WHERE IDNomina='" + txtIDNomina.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=36"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarEmpleados.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        frm_historial_nominas.ShowDialog(Me)
    End Sub

    Private Sub SalarioDeNavidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalarioDeNavidadToolStripMenuItem.Click
        Try
            If txtIDTipoNomina.Text = "" Then
                MessageBox.Show("Seleccione el tipo de nómina a buscar.", "Seleccionar nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarNomina.Focus()
            ElseIf chkDiario.Checked = False And chkSemanal.Checked = False And chkQuincenal.Checked = False And chkMensual.Checked = False Then
                MessageBox.Show("Seleccione las especificaciones de la nómina seleccionada.", "Seleccionar especificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                If txtIDNomina.Text = "" Then
                    ModificacionNomina = False
                    BuscarEmpleados()
                    CalcularNavidad
                    SumarRows()
                    DgvEmpleados.ClearSelection()
                Else
                    If ModificacionNomina = False Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Ya se han generado(s) ingresos de detalle en la actual nómina." & vbNewLine & vbNewLine & "Está seguro que desea realizar modificaciones en la actual nómina.", "Modificaciones en nómina procesada", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            ModificacionNomina = True
                            For Each Row As DataGridViewRow In DgvEmpleados.Rows
                                DgvModificables.Rows.Add(Row.Cells(0).Value)
                            Next
                            MessageBox.Show("Haga click nuevamente en el botón buscar para registrar las modificaciones de empleados a la nómina.", "Buscar empleados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    Else

                        BuscarEmpleados()
                        CalcularNavidad
                        SumarRows()
                        DgvEmpleados.ClearSelection()
                    End If

                End If
            End If

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleados.Click
        Try
            If txtIDTipoNomina.Text = "" Then
                MessageBox.Show("Seleccione el tipo de nómina a buscar.", "Seleccionar nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarNomina.Focus()
            ElseIf chkDiario.Checked = False And chkSemanal.Checked = False And chkQuincenal.Checked = False And chkMensual.Checked = False Then
                MessageBox.Show("Seleccione las especificaciones de la nómina seleccionada.", "Seleccionar especificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                If txtIDNomina.Text = "" Then
                    ModificacionNomina = False
                    BuscarEmpleados()
                    BuscarDeducciones()
                    SumarRows()
                    DgvEmpleados.ClearSelection()
                Else
                    If ModificacionNomina = False Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Ya se han generado(s) ingresos de detalle en la actual nómina." & vbNewLine & vbNewLine & "Está seguro que desea realizar modificaciones en la actual nómina.", "Modificaciones en nómina procesada", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            ModificacionNomina = True
                            For Each Row As DataGridViewRow In DgvEmpleados.Rows
                                DgvModificables.Rows.Add(Row.Cells(0).Value)
                            Next
                            MessageBox.Show("Haga click nuevamente en el botón buscar para registrar las modificaciones de empleados a la nómina.", "Buscar empleados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        BuscarEmpleados()
                        BuscarDeducciones()
                        SumarRows()
                        DgvEmpleados.ClearSelection()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub BuscarTipoNominaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarTipoNominaToolStripMenuItem.Click
        btnBuscarNomina.PerformClick()
    End Sub

    Private Sub btnBuscarNomina_Enter(sender As Object, e As EventArgs)
        LabelStatus.Text = "Se pueden manejar diversas especificaciones de nóminas al mismo tiempo. Seleccione la nómina para el procesamiento de la operación."
    End Sub

    Private Sub btnBuscarNomina_Leave(sender As Object, e As EventArgs)
        LabelStatus.Text = "Listo"
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If CDate(DtpFechaFinal.Value.ToString("yyyy-MM-dd")) < CDate(DtpFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            MessageBox.Show("La fecha inicial es mayor a la fecha inicial." & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar la nómina.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtIDTipoNomina.Text = "" Then
            MessageBox.Show("Seleccione el tipo de nómina a procesar.", "Seleccionar Nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarNomina.PerformClick()
            Exit Sub
        ElseIf chkDiario.Checked = False And chkSemanal.Checked = False And chkQuincenal.Checked = False And chkMensual.Checked = False Then
            MessageBox.Show("Seleccione al menos una frecuencia de pago para buscar los clientes bajo esa condición.", "Marque la(s) frecuencia(s) de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf DgvEmpleados.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado empleados hábiles para procesar la nómina. Por favor modifique las condiciones o haga click 'Buscar'.", "No se encontraron empleados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDNomina.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la nueva nómina con fecha del " & DtpFechaInicial.Text & " al " & DtpFechaFinal.Text & "?", "Guardar Nueva Nómina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Nomina (IDSucursal,IDAlmacen,IDEquipo,IDTipoDocumento,Fecha,Hora,IDUsuario,IDTipoNomina,FechaInicial,FechaFinal,Diario,Semanal,Quincenal,Mensual,TotalBruto,Corrientes,Deducciones,Neto,CantEmp,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',36,'" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtIDTipoNomina.Text + "','" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "','" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(chkDiario.Checked).ToString + "','" + Convert.ToInt16(chkSemanal.Checked).ToString + "','" + Convert.ToInt16(chkQuincenal.Checked).ToString + "','" + Convert.ToInt16(chkMensual.Checked).ToString + "','" + CDbl(txtTotalBruto.Text).ToString + "','" + CDbl(txtDeduccionesCorrientes.Text).ToString + "','" + CDbl(txtTotalDeducciones.Text).ToString + "','" + CDbl(txtTotalNeto.Text).ToString + "','" + txtCantidadEmpleados.Text + "',0,'" + Convert.ToInt16(chkNulo.Checked).ToString + "' )"
                GuardarDatos()
                UltNomina()
                SetSecondID()
                InsertDetalle()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nómina?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Nomina SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',FechaInicial='" + DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',Diario='" + Convert.ToInt16(chkDiario.Checked).ToString + "',Semanal='" + Convert.ToInt16(chkSemanal.Checked).ToString + "',Quincenal='" + Convert.ToInt16(chkQuincenal.Checked).ToString + "',Mensual='" + Convert.ToInt16(chkMensual.Checked).ToString + "',TotalBruto='" + CDbl(txtTotalBruto.Text).ToString + "',Corrientes='" + CDbl(txtDeduccionesCorrientes.Text).ToString + "',Deducciones='" + CDbl(txtTotalDeducciones.Text).ToString + "',Neto='" + CDbl(txtTotalNeto.Text).ToString + "',CantEmp='" + txtCantidadEmpleados.Text + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDNomina= (" + txtIDNomina.Text + ")"
                GuardarDatos()
                EliminarModificados()
                InsertDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            chkDiario.Checked = True
            chkSemanal.Checked = True
            chkQuincenal.Checked = True
            chkMensual.Checked = True
        Else
            chkDiario.Checked = False
            chkSemanal.Checked = False
            chkQuincenal.Checked = False
            chkMensual.Checked = False

        End If
    End Sub

    Private Sub frm_proceso_nomina_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadDgvEmpleados()
    End Sub

    Private Sub DgvEmpleados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEmpleados.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 10 Then
                Dim Deduccion As New Label
                IDEmpleado.Text = DgvEmpleados.CurrentRow.Cells(1).Value
                Deduccion.Text = CDbl(DgvEmpleados.CurrentRow.Cells(10).Value)

                If Deduccion.Text <> 0 Then
                    frm_deducciones_nomina.ShowDialog(Me)
                End If
            End If
        End If
    End Sub

    Private Sub DgvEmpleados_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEmpleados.CellValueChanged
        Try
            If e.ColumnIndex = 4 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(4).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(4).Value = CDbl(DgvEmpleados.CurrentRow.Cells(4).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(4).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(4).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 5 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(5).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(5).Value = CDbl(DgvEmpleados.CurrentRow.Cells(5).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(5).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(5).Value = CDbl(0).ToString("C")
        End Try
        Try
            If e.ColumnIndex = 6 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(6).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(6).Value = CDbl(DgvEmpleados.CurrentRow.Cells(6).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(6).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(6).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 7 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(7).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(7).Value = CDbl(DgvEmpleados.CurrentRow.Cells(7).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(7).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(7).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 8 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(8).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(8).Value = CDbl(DgvEmpleados.CurrentRow.Cells(8).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 9 Then
                If IsNumeric(CDbl(DgvEmpleados.CurrentRow.Cells(9).Value)) Then
                    DgvEmpleados.CurrentRow.Cells(9).Value = CDbl(DgvEmpleados.CurrentRow.Cells(9).Value).ToString("C")
                Else
                    DgvEmpleados.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
                End If


            End If
        Catch ex As Exception
            DgvEmpleados.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
        End Try


        For Each row As DataGridViewRow In DgvEmpleados.Rows
            row.Cells(11).Value = (CDbl(row.Cells(4).Value) - CDbl(row.Cells(5).Value) - CDbl(row.Cells(6).Value) - CDbl(row.Cells(7).Value) - CDbl(row.Cells(8).Value) - CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value)).ToString("C")
        Next

        SumarRows()
    End Sub
End Class