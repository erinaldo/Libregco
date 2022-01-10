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

Public Class frm_consulta_solicitud_cheques

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, IDReport, NameReport, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim SelectCommand As String = "SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.Fecha,SolicitudCheques.IDCuenta,CuentasBancarias.NoCuenta,Bancos.Identidad,Neto,SolicitudCheques.Nulo FROM solicitudcheques INNER JOIN CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta INNER JOIN Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco"
    Dim FullCommand, FechaValue, IDCuentaBancariaValue, IDBancoValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_solicitud_cheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.Fecha,SolicitudCheques.IDCuenta,CuentasBancarias.NoCuenta,Bancos.Identidad,Neto,SolicitudCheques.Nulo FROM solicitudcheques INNER JOIN CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta INNER JOIN Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where SolicitudCheques.Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and SolicitudCheques.Nulo=0", Con)
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
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='SolicitudCheques' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ListadoSolicitudCheques' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDBanco.Clear()
        txtBanco.Clear()
        txtIDCuentaBancaria.Clear()
        txtCuentaBancaria.Clear()
        chkNulos.Checked = False
        lblNulo.Text = 0
        txtIDCuentaBancaria.Focus()
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
            Adaptador.Fill(Ds, "Solicitud")
            DgvSolicitudes.DataSource = Ds
            DgvSolicitudes.DataMember = "Solicitud"
            Con.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvSolicitudes.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvSolicitudes.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvSolicitudes
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Solicitud"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"

            .Columns(3).HeaderText = "ID"
            .Columns(3).Width = 60


            .Columns(4).HeaderText = "No. de cuenta"
            .Columns(4).Width = 160

            .Columns(5).HeaderText = "Identidad"
            .Columns(5).Width = 220

            .Columns(6).Width = 125
            .Columns(6).HeaderText = "Neto"
            .Columns(6).DefaultCellStyle.Format = ("C")

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim Counter As Integer = DgvSolicitudes.Rows.Count
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = Counter Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvSolicitudes.Rows(x).Cells(6).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & Counter
    End Sub

    Private Sub SelectCuentaBancaria()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias Where IDCuenta='" + txtIDCuentaBancaria.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "CuentasBancarias")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")
            txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))

        Catch ex As Exception
            txtIDCuentaBancaria.Clear()
            txtCuentaBancaria.Clear()
        End Try
    End Sub

    Private Sub SelectBanco()
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Identidad FROM Bancos Where IDBanco='" + txtIDBanco.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Bancos")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Bancos")
            txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

        Catch ex As Exception
            txtIDBanco.Clear()
            txtBanco.Clear()
        End Try
    End Sub


    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDCuentaBancaria_Leave(sender As Object, e As EventArgs) Handles txtIDCuentaBancaria.Leave
        SelectCuentaBancaria()
        VerificarCondicionCuentaBancaria()
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

    Private Sub txtIDBanco_Leave(sender As Object, e As EventArgs) Handles txtIDBanco.Leave
        SelectBanco()
        VerificarCondicionBanco()
    End Sub

    Sub VerificarCondicionCuentaBancaria()
        If txtIDCuentaBancaria.Text = "" Then
            IDCuentaBancariaValue = ""
        Else
            IDCuentaBancariaValue = " SolicitudCheques.IDCuenta=" & txtIDCuentaBancaria.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionBanco()
        If txtIDBanco.Text = "" Then
            IDBancoValue = ""
        Else
            IDBancoValue = " CuentasBancarias.IDBanco=" & txtIDBanco.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " SolicitudCheques.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " SolicitudCheques.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionCuentaBancaria()
        VerificarCondicionBanco()
        VerificarCondicionFecha()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDCuentaBancariaValue <> "" Or IDBancoValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDCuentaBancariaValue & IDBancoValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDCuentaBancariaValue <> "" And IDBancoValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDBancoValue <> "" And NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If


        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDCuentaBancariaValue & A2 & IDBancoValue & A3 & NuloValue
    End Sub

    Private Sub btnBuscarBanco_Click(sender As Object, e As EventArgs) Handles btnBuscarBanco.Click
        frm_buscar_bancos.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnBuscarCuentaBancaria.Click
        frm_buscar_cuenta_bancaria.ShowDialog(Me)
    End Sub


    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvSolicitudes.Rows.Count = 0 Then
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
                    .StartValue = txtFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = txtFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDCuentaBancaria
                If txtIDCuentaBancaria.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCuentaBancaria.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCuentaBancaria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDAlmacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Beneficiario
                crParameterDiscreteValue.Value = ""
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Beneficiario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Valor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Valor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '@Estado
                If chkNulos.Text = "Todos" Then
                    crParameterDiscreteValue.Value = 2
                ElseIf chkNulos.Text = "Sólo Activos" Then
                    crParameterDiscreteValue.Value = 0
                ElseIf chkNulos.Text = "Nulos" Then
                    crParameterDiscreteValue.Value = 1
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                '' ''Setting Info
                '' ''Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                '' ''Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "No. de Solicitud")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. de Solicitud")
                'RangoFechas()
                If txtFechaInicial.Value = txtFechaFinal.Value Then
                    ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                Else
                    ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                End If

                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvSolicitudes.SelectedRows.Count > 0 Then
                    Dim IDSolicitud As New Label
                    IDSolicitud.Text = DgvSolicitudes.SelectedRows(0).Cells(0).Value

                    If DgvSolicitudes.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El documento de registro de solicitud de cheque " & DgvSolicitudes.SelectedRows(0).Cells(1).Value & " de fecha " & DgvSolicitudes.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDSolicitud.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
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

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsTemp As New DataSet
            If DgvSolicitudes.SelectedRows.Count > 0 Then
                Dim IDSolicitud As New Label
                IDSolicitud.Text = DgvSolicitudes.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.IDTipoDocumento,TipoDocumento.Documento,SolicitudCheques.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,SolicitudCheques.Fecha,SolicitudCheques.Hora,SolicitudCheques.IDUsuario,Usuarios.Nombre as NombreUsuario,SolicitudCheques.IDCuenta,CuentasBancarias.NoCuenta,CuentasBancarias.Titular,CuentasBancarias.Balance as BceCuenta,CuentasBancarias.IDBanco,Bancos.Identidad,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,SolicitudCheques.Observacion,Tipo,SolicitudCheques.Nulo FROM solicitudcheques INNER JOIN TipoDocumento on SolicitudCheques.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN AreaImpresion on SolicitudCheques.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Empleados as Usuarios on SolicitudCheques.IDUsuario=Usuarios.IDEmpleado INNER JOIN CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta INNER JOIN Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where IDSolicitudCheque= '" + IDSolicitud.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "SolicitudCheque")
                Con.Close()

                Dim Tabla As DataTable = DsTemp.Tables("SolicitudCheque")

                If frm_solicitud_cheques.Visible = True Then
                    frm_solicitud_cheques.Close()
                End If

                frm_solicitud_cheques.Show(Me)

                If (Tabla.Rows(0).Item("Tipo")) = 0 Then
                    frm_solicitud_cheques.rdbCuentasporPagar.Checked = True
                    frm_solicitud_cheques.Tipo.Text = (Tabla.Rows(0).Item("Tipo"))
                    frm_solicitud_cheques.TabControl1.SelectedIndex = 0
                    frm_solicitud_cheques.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDSolicitudCheque"))
                    frm_solicitud_cheques.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                    frm_solicitud_cheques.lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
                    frm_solicitud_cheques.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
                    frm_solicitud_cheques.cbxCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))
                    frm_solicitud_cheques.SetIDCuenta()
                    frm_solicitud_cheques.txtNoChequeC.Text = (Tabla.Rows(0).Item("NoCheque"))
                    frm_solicitud_cheques.txtConcepto.Text = (Tabla.Rows(0).Item("Observacion"))
                    frm_solicitud_cheques.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                    frm_solicitud_cheques.txtDescRet.Text = CDbl(Tabla.Rows(0).Item("Retencion")).ToString("C")
                    frm_solicitud_cheques.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                    frm_solicitud_cheques.dtpFechaPagoR.Text = (Tabla.Rows(0).Item("FechaPago"))
                    frm_solicitud_cheques.dtpFechaPagoR.Value = (Tabla.Rows(0).Item("FechaPago"))
                    frm_solicitud_cheques.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                    frm_solicitud_cheques.txtBalance.Text = CDbl(Tabla.Rows(0).Item("BceCuenta")).ToString("C")
                    frm_solicitud_cheques.Hora.Enabled = False

                    Dim DsLlenarFormulario As New DataSet
                    Dim IDSuplidor As New Label
                    IDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))

                    DsLlenarFormulario.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select IDSuplidor,Suplidor,TipoIdentificacion.Descripcion,TipoIdentificacion.IDTipoIdentificacion,RNC,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero from Suplidor INNER JOIN tipoidentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Condicion on Suplidor.IDCondicion=Condicion.IDCondicion INNER JOIN ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto Where IDSuplidor= '" + IDSuplidor.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsLlenarFormulario, "Suplidor")
                    Con.Close()

                    Dim Tablas As DataTable = DsLlenarFormulario.Tables("Suplidor")

                    frm_solicitud_cheques.txtIDSuplidor.Text = (Tablas.Rows(0).Item("IDSuplidor"))
                    frm_solicitud_cheques.txtNombreSuplidor.Text = (Tablas.Rows(0).Item("Suplidor"))
                    frm_solicitud_cheques.txtBalanceSup.Text = CDbl((Tablas.Rows(0).Item("Balance"))).ToString("C")
                    frm_solicitud_cheques.txtUltimoPago.Text = (Tablas.Rows(0).Item("UltimoPago"))
                    If IsNumeric(Tablas.Rows(0).Item("UltimoMonto")) Then
                        frm_solicitud_cheques.txtUltimoMonto.Text = CDbl(Tablas.Rows(0).Item("UltimoMonto")).ToString("C")
                    Else
                        frm_solicitud_cheques.txtUltimoMonto.Text = (Tablas.Rows(0).Item("UltimoMonto"))
                    End If

                    frm_solicitud_cheques.WriteNumberToText()
                    frm_solicitud_cheques.RefrescarSolicitudesDetalle()
                Else
                    frm_solicitud_cheques.rdbEgresos.Checked = True
                    frm_solicitud_cheques.Tipo.Text = (Tabla.Rows(0).Item("Tipo"))
                    frm_solicitud_cheques.TabControl1.SelectedIndex = 1
                    frm_solicitud_cheques.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDSolicitudCheque"))
                    frm_solicitud_cheques.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                    frm_solicitud_cheques.lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
                    frm_solicitud_cheques.txtBancoE.Text = (Tabla.Rows(0).Item("Identidad")) & " --> " & (Tabla.Rows(0).Item("Titular"))
                    frm_solicitud_cheques.cbxCuentaE.Text = (Tabla.Rows(0).Item("NoCuenta"))
                    frm_solicitud_cheques.SetIDCuenta()
                    frm_solicitud_cheques.txtNoChequeE.Text = (Tabla.Rows(0).Item("NoCheque"))
                    frm_solicitud_cheques.txtConceptoE.Text = (Tabla.Rows(0).Item("Observacion"))
                    frm_solicitud_cheques.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                    frm_solicitud_cheques.dtpFechaPagoE.Text = (Tabla.Rows(0).Item("FechaPago"))
                    frm_solicitud_cheques.dtpFechaPagoE.Value = (Tabla.Rows(0).Item("FechaPago"))
                    frm_solicitud_cheques.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
                    frm_solicitud_cheques.WriteNumberToText()
                    frm_solicitud_cheques.txtBalanceE.Text = CDbl(Tabla.Rows(0).Item("BceCuenta")).ToString("C")
                    frm_solicitud_cheques.Hora.Enabled = False
                End If


            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class