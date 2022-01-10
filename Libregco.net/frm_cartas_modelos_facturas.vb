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

Public Class frm_cartas_modelos_facturas
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub txtIDFactura_Leave(sender As Object, e As EventArgs) Handles txtIDFactura.Leave
        Con.Open()
        cmd = New MySqlCommand("Select SecondID from FacturaDatos Where IDFacturaDatos='" + txtIDFactura.Text + "'", Con)
        txtFactura.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtFactura.Text = "" Then txtIDFactura.Clear()
        FillInfoFactura()
    End Sub

    Private Sub frm_cartas_modelos_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        ChangePictureRdb()
        FillReportes()
        Actualizar()
        Permisos = PasarPermisos(Me.Tag)
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

    Private Sub FillReportes()
        DgvReportes.Rows.Clear()
        Con.Open()
        Dim Consulta As New MySqlCommand("SELECT IDReportes,Descripcion,Path FROM reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='CorrespondenciaFactura' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
        Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

        While LectorArticulos.Read
            DgvReportes.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2))
        End While
        LectorArticulos.Close()
        Con.Close()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub btnFactura_Click(sender As Object, e As EventArgs) Handles btnFactura.Click
        If frm_consulta_ventas.Visible = True Then
            frm_consulta_ventas.Close()
        End If

        frm_consulta_ventas.ShowDialog(Me)
        FillInfoFactura()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIDFactura.Clear()
        txtFactura.Clear()
        Actualizar()
        txtIDFactura.Focus()
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

    Private Sub Actualizar()
        lblNombre.Text = ""
        lblIdentificacion.Text = ""
        lblCondicion.Text = ""
        lblFecha.Text = ""
        lblTotalNeto.Text = " "
        lblBalance.Text = ""
    End Sub

    Friend Sub FillInfoFactura()
        Try

            Dim Ds1 As New DataSet

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,IdentificacionFactura,Clientes.Nombre,IDFacturaDatos,FacturaDatos.SecondID,IDTipoDocumento,IDTransaccion,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.Nulo from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos='" + txtIDFactura.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")

            If Tabla.Rows.Count = 0 Then
                Actualizar()
            Else
                lblNombre.Text = "[" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("NombreFactura")
                lblIdentificacion.Text = Tabla.Rows(0).Item("IdentificacionFactura")
                lblCondicion.Text = Tabla.Rows(0).Item("Condicion")
                lblFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & " " & CDate(Convert.ToString(Tabla.Rows(0).Item("Hora"))).ToString("hh:mm:ss tt")
                lblTotalNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                lblBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Try

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument

        If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & DgvReportes.CurrentRow.Cells(2).Value) Else ObjRpt.Load("C:" & DgvReportes.CurrentRow.Cells(2).Value.Replace("\Libregco\Libregco.net", ""))


        If txtIDFactura.Text = "" Then
            MessageBox.Show("Seleccione la factura para generar los reportes de correspondencia.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnFactura.PerformClick()
            Exit Sub
        End If

        If DgvReportes.SelectedRows.Count > 0 Then
            MessageBox.Show("Por favor seleccione el reporte de correspondencia que desea generar.", "Seleccionar reporte de correspondencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        crParameterValues.Clear()
        frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
        LoadAnimation()

        '@IDFactura
        crParameterDiscreteValue.Value = txtIDFactura.Text
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDFactura")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        '@IDEmpleado
        crParameterDiscreteValue.Value = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        LoadAnimation()

        If rdbPresentacion.Checked = True Then
            lblStatusBar.Text = "Visualizando el reporte..."
            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default

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
                ObjRpt.SummaryInfo.ReportTitle = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy")
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
                .FileName = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
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
                .FileName = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
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
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub
End Class