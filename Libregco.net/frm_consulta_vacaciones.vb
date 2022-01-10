Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_consulta_vacaciones
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT idvacaciones,empleados_vacaciones.secondid,fecha,empleados.nombre as nombreempleado,montovacaciones,fechasalida,fechaentrada,empleados_vacaciones.nulo FROM" & SysName.Text & "empleados_vacaciones inner join" & SysName.Text & "empleados on empleados_vacaciones.idempleado=empleados.idempleado inner join" & SysName.Text & "empleados as usuarios on empleados_vacaciones.idusuario=usuarios.idempleado"
    Dim FullCommand, FechaValue, IDSucursalValue, IDEmpleadoValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Private Sub frm_consulta_vacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT idvacaciones,empleados_vacaciones.secondid,fecha,empleados.nombre as nombreempleado,montovacaciones,fechasalida,fechaentrada,empleados_vacaciones.nulo FROM" & SysName.Text & "empleados_vacaciones inner join" & SysName.Text & "empleados on empleados_vacaciones.idempleado=empleados.idempleado inner join" & SysName.Text & "empleados as usuarios on empleados_vacaciones.idusuario=usuarios.idempleado Where Empleados_vacaciones.Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd 00:00:00") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd 23:59:59") + "' and Empleados_vacaciones.Nulo=0", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Vacaciones' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='VacacionesListado' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDSucursal.Clear()
        txtSucursal.Clear()
        txtIDEmpleado.Clear()
        txtEmpleado.Clear()
        cbxEstado.Text = "Todos"
        lblNulo.Text = 0
        txtIDEmpleado.Focus()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Value = Today
        txtFechaInicial.Value = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            Con.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Vacaciones")
            DgvVacaciones.DataSource = Ds
            DgvVacaciones.DataMember = "Vacaciones"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvVacaciones.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvVacaciones.Rows
                If CInt(Row.Cells(5).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvVacaciones
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Vacaciones"
            .Columns(1).Width = 120
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 100
            .Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns(3).Width = 230
            .Columns(3).HeaderText = "Empleado"

            .Columns(4).HeaderText = "Monto"
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Format = "C"

            .Columns(5).HeaderText = "Salida"
            .Columns(5).Width = 100

            .Columns(6).HeaderText = "Entrada"
            .Columns(6).Width = 100

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvVacaciones.Rows.Count
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = Counter Then
            GoTo Fin
        End If

        Monto = Monto + CDbl(DgvVacaciones.Rows(x).Cells(4).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectSucursal()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Sucursal")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Sucursal")
            txtSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))

        Catch ex As Exception
            txtSucursal.Text = ""
        End Try
    End Sub

    Private Sub SelectEmpleado()
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre from Empleados Where IDEmpleado='" + txtIDEmpleado.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Empleados")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Empleados")
            txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))

        Catch ex As Exception
            txtEmpleado.Text = ""
        End Try
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        SelectSucursal()
        VerificarCondicionSucursal()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog(Me)
    End Sub

    Private Sub txtIDEmpleado_Leave(sender As Object, e As EventArgs) Handles txtIDEmpleado.Leave
        SelectEmpleado()
        VerificarEmpleado()
    End Sub

    Sub VerificarEmpleado()
        If txtIDEmpleado.Text = "" Then
            IDEmpleadoValue = ""
        Else
            IDEmpleadoValue = " Empleados_vacaciones.IDEmpleado=" & txtIDEmpleado.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionSucursal()
        If txtIDSucursal.Text = "" Then
            IDSucursalValue = ""
        Else
            IDSucursalValue = " Sucursal.IDSucursal=" & txtIDSucursal.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " Empleados_vacaciones.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd 00:00:00") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd 23:59:59") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If cbxEstado.Text = "Todos" Then
            NuloValue = ""

        ElseIf cbxEstado.Text = "Sólo Activos" Then
            NuloValue = " Empleados_vacaciones.Nulo=0 "

        ElseIf cbxEstado.Text = "Nulos" Then
            NuloValue = " Empleados_vacaciones.Nulo=1 "

        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionSucursal()
        VerificarEmpleado()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDSucursalValue <> "" Or IDEmpleadoValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDSucursalValue & IDEmpleadoValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDSucursalValue <> "" And IDEmpleadoValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDEmpleadoValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDSucursalValue & A2 & IDEmpleadoValue & A3 & NuloValue
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        'Try
        Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvVacaciones.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@Fecha
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = txtFechaInicial.Value
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = txtFechaFinal.Value
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDEmpleado
                If txtIDEmpleado.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDEmpleado.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@IDAlmacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                If txtIDSucursal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSucursal.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If cbxEstado.Text = "Todos" Then
                    crParameterDiscreteValue.Value = 2
                ElseIf cbxEstado.Text = "Sólo Activos" Then
                    crParameterDiscreteValue.Value = 0
                ElseIf cbxEstado.Text = "Nulos" Then
                    crParameterDiscreteValue.Value = 1
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

            ElseIf rdbEspecifico.Checked = True Then

                If DgvVacaciones.SelectedRows.Count > 0 Then
                    Dim IDVacaciones As New Label
                    IDVacaciones.Text = DgvVacaciones.SelectedRows(0).Cells(0).Value

                If DgvVacaciones.SelectedRows(0).Cells(7).Value = "1" Then
                    MessageBox.Show("El documento de registro de vacaciones " & DgvVacaciones.SelectedRows(0).Cells(1).Value & " de fecha " & DgvVacaciones.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar el registro de vacaciones", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                '@IDDocumento
                crParameterDiscreteValue.Value = IDVacaciones.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")

                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                End If

            End If

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default
                lblStatusBar.Text = "Listo"

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog
                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
                    Me.Cursor = Cursors.Default
                End If

            ElseIf rdbPDF.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en PDF..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Portable Documento Format (*.pdf)|*.pdf"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            ElseIf rdbExcel.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en archivo de Excel..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New ExcelFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Excel (*.xls)|*.xls"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If
            End If
            LoadAnimation()
            lblStatusBar.Text = "Listo"

        '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub

    Private Sub cbxEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstado.SelectedIndexChanged
        VerificarCondicionNulo()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If DgvVacaciones.SelectedRows.Count > 0 Then
                Dim IDVacaciones As New Label
                Dim DsTemp As New DataSet

                IDVacaciones.Text = DgvVacaciones.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idvacaciones,empleados_vacaciones.secondid,fecha,empleados_vacaciones.idempleado,empleados.nombre,fechasalida,fechaentrada,diaspagados,conceptovacaciones,montovacaciones,empleados_vacaciones.Nulo,RutaFoto,Empleados.Nombre,Salario,sumaletra,adjunto,fechaingreso FROM" & SysName.Text & "empleados_vacaciones inner join" & SysName.Text & "empleados on empleados_vacaciones.idempleado=empleados.idempleado Where empleados_vacaciones.idvacaciones='" + IDVacaciones.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Vacaciones")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Vacaciones")

                If frm_empleados_vacaciones.Visible = True Then
                    frm_empleados_vacaciones.Close()
                End If

                frm_empleados_vacaciones.Show(Me)

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

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class