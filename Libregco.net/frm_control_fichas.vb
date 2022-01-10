Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_control_fichas

    Dim sqlQ As String=""
    Dim Ds, Ds1 As New DataSet
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim ChkHabilitar As New DataGridViewCheckBoxColumn
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim IDReport, NameReport, PathReport As New Label

    Private Sub frm_control_fichas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTxtBuscar()
        CreateColumns()
        cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.IDCliente,Clientes.Nombre,TotalNeto,HabilitarFicha FROM facturadatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where FacturaDatos.Nulo=0 ORDER BY HabilitarFicha DESC, Fecha ASC", Con)
        RefrescarTabla()
        FillReportes()
    End Sub

    Private Sub LimpiarTxtBuscar()
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub CreateColumns()
        DgvFacturas.Columns.Clear()

        With DgvFacturas
            .Columns.Clear()
            .Columns.Add("IDFacturaDatos", "Código") '0
            .Columns.Add("NoFactura", "No. Factura") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("IDCliente", "ID") '3
            .Columns.Add("Nombre", "Nombre") '4
            .Columns.Add("Neto", "Total Neto") '5
            .Columns.Add(ChkHabilitar) '6
        End With

        PropiedadColumnsDvg()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvFacturas
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(1).ReadOnly = True
            .Columns(1).HeaderText = "No. Factura"

            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True
            .Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(3).ReadOnly = True

            .Columns(4).Width = 250
            .Columns(4).ReadOnly = True

            .Columns(5).Width = 110
            .Columns(5).ReadOnly = True
            .Columns(5).DefaultCellStyle.Format = "C"
        End With

        With ChkHabilitar
            .HeaderText = "Ficha"
            .Name = "ChkHabilitar"
            .Width = 80
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .FlatStyle = FlatStyle.Standard
            .DataPropertyName = "ChkHabilitar"
        End With

    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvFacturas.Focus()
    End Sub

    Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If DgvFacturas.Columns.Count = 0 Then
                CreateColumns()
            End If

            DgvFacturas.Rows.Clear()

            Con.Open()

            If rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,TotalNeto,HabilitarFicha FROM facturadatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where FacturaDatos.NombreFactura like '%" + txtBuscar.Text + "%' and FacturaDatos.Nulo=0 ORDER BY HabilitarFicha DESC, Fecha ASC LIMIT 50", Con)
            Else
                cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,TotalNeto,HabilitarFicha FROM facturadatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where FacturaDatos.SecondID like '%" + txtBuscar.Text + "%' and FacturaDatos.Nulo=0 ORDER BY HabilitarFicha DESC, Fecha ASC LIMIT 50", Con)
            End If

            Dim LectorFacturas As MySqlDataReader = cmd.ExecuteReader
            While LectorFacturas.Read
                DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), CDbl(LectorFacturas.GetValue(5)).ToString("C"), CBool(LectorFacturas.GetValue(6)))
            End While

            LectorFacturas.Close()
            Con.Close()

            PropiedadColumnsDvg()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub DgvFacturas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellValueChanged
        'Try
        If DgvFacturas.Rows.Count > 0 Then
            If e.ColumnIndex = 6 Then
                Dim IDCodigo As New Label
                Dim IsTicked As Boolean = CBool(DgvFacturas.CurrentRow.Cells(6).Value)
                IDCodigo.Text = DgvFacturas.CurrentRow.Cells(0).Value

                If IsTicked Then
                    sqlQ = "UPDATE FacturaDatos SET HabilitarFicha=1 WHERE IDFacturaDatos= (" + IDCodigo.Text + ")"
                    GuardarDatos()
                Else
                    sqlQ = "UPDATE FacturaDatos SET HabilitarFicha=0 WHERE IDFacturaDatos= (" + IDCodigo.Text + ")"
                    GuardarDatos()
                End If

                txtBuscar.Focus()
                txtBuscar.SelectAll()

            End If
        End If
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvRecibos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellEndEdit
        DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvRecibos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvFacturas.CurrentCellDirtyStateChanged
        If DgvFacturas.IsCurrentCellDirty Then
            DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
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

    Private Sub ImprimirDocumento()
        Try
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Con.Open()
            cmd = New MySqlCommand("Select count(FacturaDatos.IDFacturaDatos) from FacturaDatos where FacturaDatos.HabilitarFicha=1", Con)
            Dim HabilitarFicha As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CDbl(HabilitarFicha) = 0 Then
                MessageBox.Show("No existen registros de facturas hábiles para la impresión de las fichas de cobros.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else

                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim ObjRpt As New ReportDocument

                If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))

                crParameterValues.Clear()
                frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
                LoadAnimation()

                Dim cmdSP As New MySqlCommand
                Dim AdaptadorSP As MySqlDataAdapter

                'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                AdaptadorSP = New MySqlDataAdapter("Select FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID AS SecondIDFact,FacturaDatos.IDTransaccion,TipoDocumento.Documento,FacturaDatos.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Apodo,Clientes.Identificacion,Clientes.Direccion,Clientes.IDProvincia,Clientes.IDMunicipio,Clientes.Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,Clientes.IDEmpleado,Clientes.BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,FacturaDatos.IDCondicion,Condicion.Condicion,Condicion.Dias,FacturaDatos.IDSucursal,FacturaDatos.IDAlmacen,FacturaDatos.IDComprobanteFiscal,Comprobantefiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.NIF,FacturaDatos.IDChofer,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,FacturaDatos.IDUsuario,Usuarios.Nombre as NombreUsuario,Usuarios.Login,FacturaDatos.Fecha as FechaFactura,FacturaDatos.Hora as HoraFactura,FacturaDatos.Inicial,FacturaDatos.Balance,FacturaDatos.Cargos,FacturaDatos.NetoFactura,FacturaDatos.CantidadPagos,FacturaDatos.MontoPagos,FacturaDatos.Pagoadicional,FacturaDatos.FechaAdicional,FacturaDatos.FechaVencimiento,FacturaDatos.NotaContado,FacturaDatos.CondicionContado,FacturaDatos.HabilitarFicha,FacturaDatos.SubTotal,FacturaDatos.Descuento,FacturaDatos.Itbis,FacturaDatos.Flete,FacturaDatos.TotalNeto,FacturaDatos.EntregarPorConduce,FacturaDatos.Observacion,FacturaDatos.Impreso,FacturaDatos.Nulo,Efectivo,Cheque,Deposito,Informacion,Credito,IDCredito,ClaseTarjeta,Transaccion.Tarjeta,NoTarjeta,TipoTarjeta,Recibido,MontoCobrar,Devuelta,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,(SELECT (Select Group_Concat(Descripcion) from " & SysName.Text & "FacturaArticulos Where FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos)) as Articulos FROM " & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes ON FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN " & SysName.Text & "Comprobantefiscal ON FacturaDatos.IDComprobanteFiscal=Comprobantefiscal.IDComprobanteFiscal INNER JOIN " & SysName.Text & "Empleados as Vendedor ON FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN " & SysName.Text & "Empleados as Usuarios ON FacturaDatos.IDUsuario=Usuarios.IDEmpleado INNER JOIN " & SysName.Text & "Empleados as Cobrador ON Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Condicion ON FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN " & SysName.Text & "Transaccion ON FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN " & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where FacturaDatos.HabilitarFicha=1", Con)
                AdaptadorSP.Fill(DsSP, "Ficha_DATA")

                cmdSP.Dispose()
                AdaptadorSP.Dispose()

                ObjRpt.Database.Tables("Ficha_DATA").SetDataSource(DsSP.Tables("Ficha_DATA"))

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

                        Dim PrinterSettings1 As New Printing.PrinterSettings
                        Dim PageSettings1 As New Printing.PageSettings

                        PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                        PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                        PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                        PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                        PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                        PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                        frm_reportView.ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                        frm_reportView.ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                        frm_reportView.ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

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
                DsSP.Dispose()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnImprimri_Click(sender As Object, e As EventArgs) Handles btnImprimri.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            Dim IDFactura As New Label

            Con.Open()

            For Each row As DataGridViewRow In DgvFacturas.Rows
                If Convert.ToInt16(row.Cells(6).Value) = 1 Then
                    IDFactura.Text = row.Cells(0).Value

                    sqlQ = "UPDATE FacturaDatos SET HabilitarFicha='0' WHERE IDFacturaDatos='" + IDFactura.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            Con.Close()

            MessageBox.Show("Se han deshabilitado " & DataGridViewExtensions.CheckBoxCount(DgvFacturas, 6, True) & "/" & DgvFacturas.Rows.Count & " fichas visibles de la tabla.", "Fichas deseleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            RefrescarTabla()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Reportes")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Reportes")
            IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
            NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
            PathReport.Text = (Tabla.Rows(0).Item("Path"))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='FichaCobro' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

End Class