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

Public Class frm_movimiento_facturas_cxp
    Friend IDReport, NameReport, PathReport As New Label

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim lblIDCompra As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_movimiento_facturas_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        FillReportes()
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtDireccion.Clear()
        txtRNC.Clear()
        txtTelefono.Clear()
        txtComentarios.Clear()
        DgvMovimientos.Rows.Clear()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub


    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where IDReportes=167 and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
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

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtNoFactura.Text = "" Then
            MessageBox.Show("Escriba un número de factura válido o el número de registro de la compra para procesar la solicitud de movimientos.", "Escriba el No. de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            BuscarFactura()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub BuscarFactura()
        Dim DsTemp As New DataSet
        LimpiarDatos()

        ConMixta.Open()
        DsTemp.Clear()
        cmd = New MySqlCommand("SELECT IDCompra,Compras.IDTipoDocumento,TipoDocumento.Documento,Compras.SecondID,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.Direccion,Suplidor.RNC,Suplidor.Telefono,Suplidor.Fax,Compras.IDUsuario,Usuarios.Nombre as NombreUsuario,Compras.IDSucursal,Sucursal.Sucursal,Compras.IDAlmacen,Almacen.Almacen,Compras.Fecha,Compras.Hora,Compras.IDCondicion,Condicion.Condicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.Nota,Compras.SubTotal,Compras.Descuento,Compras.Descuento2,Compras.Itbis,Compras.Flete,Compras.TotalNeto,Compras.IDEmpleadoRec,Recepcion.Nombre as NombreRecepcion,DiaRecepcion,Compras.Balance,RutaDocumento,Compras.Nota,Compras.Impreso,Compras.Nulo FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Empleados as Usuarios on Compras.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Sucursal on Compras.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Empleados as Recepcion on Compras.IDEmpleadoRec=Recepcion.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on COmpras.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where Compras.IDCompra='" + txtNoFactura.Text + "' or Compras.SecondID='" + txtNoFactura.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Compras")


        Dim Tabla As DataTable = DsTemp.Tables("Compras")

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontró factura(s) identicadas con " & txtNoFactura.Text & " en la base de datos. Por favor revise los datos suministrados e intentelo de nuevo.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConMixta.Close()
            Exit Sub
        End If

        txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
        txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
        txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
        txtRNC.Text = (Tabla.Rows(0).Item("RNC"))
        txtTelefono.Text = (Tabla.Rows(0).Item("Telefono")) & " " & (Tabla.Rows(0).Item("Fax"))
        txtComentarios.Text = (Tabla.Rows(0).Item("Nota"))
        lblIDCompra.Text = (Tabla.Rows(0).Item("IDCompra"))

        'Buscar movimientos de la factura
        If chkNoEspecificar.Checked = True Then
            Dim Consulta As New MySqlCommand("Select SecondID,Fecha,Hora,Documento,Credito,Debito,Balance from" & SysName.Text & "Movimientosfacturaview Where Movimientosfacturaview.IDCompra='" + lblIDCompra.Text + "'", ConMixta)
            Dim LectorPagos As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagos.Read
                DgvMovimientos.Rows.Add(LectorPagos.GetValue(0), CDate(LectorPagos.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(LectorPagos.GetValue(2))).ToString("HH:mm:ss"), LectorPagos.GetValue(3), CDbl(LectorPagos.GetValue(4)).ToString("C"), CDbl(LectorPagos.GetValue(5)).ToString("C"), CDbl(LectorPagos.GetValue(6)).ToString("C"))
            End While

            LectorPagos.Close()
        Else
            Dim Consulta As New MySqlCommand("Select SecondID,Fecha,Hora,Documento,Credito,Debito,Balance from" & SysName.Text & "Movimientosfacturaview Where Movimientosfacturaview.IDCompra='" + lblIDCompra.Text + "' and Movimientosfacturaview.Fecha Between '" + dtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "'", ConMixta)
            Dim LectorPagos As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagos.Read
                DgvMovimientos.Rows.Add(LectorPagos.GetValue(0), CDate(LectorPagos.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(LectorPagos.GetValue(2))).ToString("HH:mm:ss"), LectorPagos.GetValue(3), CDbl(LectorPagos.GetValue(4)).ToString("C"), CDbl(LectorPagos.GetValue(5)).ToString("C"), CDbl(LectorPagos.GetValue(6)).ToString("C"))
            End While

            LectorPagos.Close()
        End If

        ConMixta.Close()

        DgvMovimientos.Sort(DgvMovimientos.Columns("Fecha"), System.ComponentModel.ListSortDirection.Ascending)

        SumarAcumulados()
    End Sub
    Private Sub txtNoFactura_Leave(sender As Object, e As EventArgs) Handles txtNoFactura.Leave
        Try
            If txtNoFactura.Text = "" Then
                MessageBox.Show("Escriba un número de factura válido o el número de registro de la compra para procesar la solicitud de movimientos.", "Escriba el No. de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNoFactura.Focus()
            Else
                BuscarFactura()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SumarAcumulados()
        Try
            Dim Acumulado As Double
            For Each row As DataGridViewRow In DgvMovimientos.Rows
                Acumulado = Acumulado + CDbl(row.Cells(3).Value) - CDbl(row.Cells(4).Value)
                row.Cells(6).Value = Acumulado.ToString("C")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        btnActualizar.PerformClick()
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If chkNoEspecificar.Checked = False Then
                If CDate(dtpFechaFinal.Text) < CDate(dtpFechaInicial.Text) Then
                    MessageBox.Show("La fecha inicial es mayor a la fecha inicial" & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar el reporte.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If txtNoFactura.Text = "" Then
                MessageBox.Show("Escriba el No. de factura o el código de registro de la factura de compra a buscar.", "Escribir No. de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNoFactura.Focus()
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@Fecha
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            If chkNoEspecificar.Checked = False Then
                With crParameterRangeValue
                    .StartValue = dtpFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
            Else
                With crParameterRangeValue
                    .StartValue = dtpFechaInicial.MinDate.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaFinal.MaxDate.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive

                End With
            End If
            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDCompra
            If txtNoFactura.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = lblIDCompra.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCompra")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Setting Info 
            'Resumir Reporte
            If chkResumir.Checked = True Then
                ObjRpt.SetParameterValue("@Resumir", 1)
            Else
                ObjRpt.SetParameterValue("@Resumir", 0)
            End If
            'Ordenamiento de Reporte
            ObjRpt.SetParameterValue("@SortedField", "No. de Suplidor")
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. de Suplidor")
            'RangoFechas()
            If dtpFechaInicial.Value = dtpFechaFinal.Value Then
                ObjRpt.SetParameterValue("@RangoFechas", "Del " & dtpFechaFinal.Value.ToString("dd/MM/yyyy"))
            Else
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & dtpFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & dtpFechaFinal.Value.ToString("dd/MM/yyyy"))
            End If
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            lblStatusBar.Text = "Listo"
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkNoEspecificar_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoEspecificar.CheckedChanged
        If chkNoEspecificar.Checked = True Then
            GroupBox4.Enabled = False
        Else
            GroupBox4.Enabled = True
        End If
    End Sub
End Class