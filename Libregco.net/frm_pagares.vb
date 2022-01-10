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
Public Class frm_pagares

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Friend lblIDFactura As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_pagares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarTodo()
        txtFactura.Clear()
        lblIDFactura.Text = ""
        Me.VisorDocumento.ReportSource = Nothing
        Me.VisorDocumento.Refresh()
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Pagares' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")

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

    Private Sub ActualizarTodo()
        FillReportes()
        cbxTipoOrden.SelectedIndex = 0
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))

        FillOrdenamiento()
    End Sub

    Private Sub cbxTipoOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoOrden.SelectedIndexChanged
        If CbxOrden.Text = "Ascendente" Then
            OrdenFormula.Text = "crAscendingOrder"
        ElseIf CbxOrden.Text = "Descendiente" Then
            OrdenFormula.Text = "crDescendingOrder"
        End If
    End Sub

    Private Sub CbxOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOrden.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("Select Campo from ReportesOrden where IDReporte='" + IDReport.Text + "' and Descripcion='" + CbxOrden.Text + "'", Con)
        OrdenCampo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillOrdenamiento()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM ReportesOrden where IDReporte='" + IDReport.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OrdenReportes")
            CbxOrden.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("OrdenReportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxOrden.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxOrden.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron orden de reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FillOrdenamiento()")
        End Try

    End Sub

    Private Sub ChangePictureRdb()
        If rdbPresentacion.Checked = True Then
            PicSalida.Image = My.Resources.Preview_x72
        ElseIf rdbImpresora.Checked = True Then
            PicSalida.Image = My.Resources.Printer_x72
        ElseIf rdbPDF.Checked = True Then
            PicSalida.Image = My.Resources.AdobeReader_x72
        ElseIf rdbExcel.Checked = True Then
            PicSalida.Image = My.Resources.Ms_Excel_x72
        End If
    End Sub

    Private Sub rdbImpresora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbImpresora.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExcel.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarTodo()
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

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Try
        Dim DsSP As New DataSet

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument

        If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el No. de factura para buscar los pagarés correspondientes.", "Escribe o selecciona el No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim cmdSP As New MySqlCommand
        Dim AdaptadorSP As MySqlDataAdapter

        crParameterValues.Clear()
        VisorDocumento.Cursor = Cursors.AppStarting
        LoadAnimation()

        'Llenado EmpresaView
        AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
        AdaptadorSP.Fill(DsSP, "EmpresaView")

        'Lleando pagaresView
        AdaptadorSP = New MySqlDataAdapter("SELECT IDPagare,Pagares.IDFactura,FacturaDatos.SecondID,FacturaDatos.IDCondicion,FacturaDatos.Fecha as FechaFactura,FacturaDatos.FechaVencimiento as FechaVencimientoFactura,FacturaDatos.Balance AS BalanceFactura,FacturaDatos.IDCliente,Clientes.Nombre as NombreCliente,NombreFactura,Clientes.Apodo,Clientes.IDTipoIdentificacion,IdentificacionFactura,DireccionFactura,TelefonosFactura,NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento as VencimientoPagares,Pagares.DiasVencidos as DiasVencidosPagares,Concepto,Pagares.Monto,Pagares.Balance as BalancePagares,IDListaPagare,FacturaDatos.IDVendedor,Pagares.IDEmpleado as IDCobradorPagare,Cobrador.Nombre as NombreCobrador,FacturaDatos.IDUsuario,FacturaDatos.IDSucursal,FacturaDatos.IDAlmacen,Nota,Pagares.IDStatusPagare,FacturaDatos.Nulo,Clientes.BalanceGeneral,Clientes.GenerarCargo,Clientes.CuentaIncobrable,GROUP_CONCAT(FacturaArticulos.Descripcion,'') AS DescripcionArticulos FROM" & SysName.Text & "pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Empleados as Cobrador on Pagares.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura Where Pagares.IDFactura='" + lblIDFactura.Text + "' GROUP BY Pagares.IDPagare", ConMixta)
        AdaptadorSP.Fill(DsSP, "PagaresView")

        cmdSP.Dispose()
        AdaptadorSP.Dispose()

        ObjRpt.Database.Tables("pagaressimplificadoview1").SetDataSource(DsSP.Tables("PagaresView"))
        ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

        ''@Factura
        'If txtFactura.Text = "" Then
        '    crParameterDiscreteValue.Value = 0
        'Else
        '    crParameterDiscreteValue.Value = lblIDFactura.Text
        'End If
        'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Factura")
        'crParameterValues.Add(crParameterDiscreteValue)
        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        LoadAnimation()

        If rdbPresentacion.Checked = True Then
            lblStatusBar.Text = "Visualizando el reporte..."
            Me.VisorDocumento.ReportSource = ObjRpt
            Me.VisorDocumento.Refresh()
            Me.VisorDocumento.Cursor = Cursors.Default
            Me.VisorDocumento.Tag = ObjRpt.PrintOptions.PrinterName.ToString

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

                Dim PrinterSettings1 As New Printing.PrinterSettings
                Dim PageSettings1 As New Printing.PageSettings

                PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

                Me.Cursor = Cursors.Default
            End If

        ElseIf rdbPDF.Checked = True Then
            lblStatusBar.Text = "Convirtiendo en PDF..."
            Dim GetFileName As New SaveFileDialog
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

            With GetFileName
                .RestoreDirectory = True
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

        lblStatusBar.Text = "Listo"

    End Sub

    Private Sub btnBuscarFactura_Click(sender As Object, e As EventArgs) Handles btnBuscarFactura.Click
        If frm_consulta_ventas.Visible = True Then
            frm_consulta_ventas.Close()
            frm_consulta_ventas.ShowDialog(Me)
        Else
            frm_consulta_ventas.ShowDialog(Me)
        End If
    End Sub

    Private Sub frm_pagares_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If Me.Owner.Name = frm_facturacion.Name Then
        '    If frm_facturacion.Owner.Name = frm_cierre_facturas.Name Then
        '        frm_facturacion.Close()
        '    End If
        'End If
    End Sub
End Class