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

Public Class frm_reporte_etiquetas_productos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDMedida, IDPrecios, IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim ObjRpt As New ReportDocument
    Dim Permisos As New ArrayList

    Private Sub frm_reporte_etiquetas_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarTodo()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub LimpiarTodo()
        txtIDArticulo.Clear()
        txtArticulo.Clear()
        txtEvento.Clear()
    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        CbxTipoBarra.Text = "C39 ASCII"
        cbxTipoPrecio.SelectedIndex = 0
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from Articulos Where IDArticulo='" + txtIDArticulo.Text + "'", ConLibregco)
        txtArticulo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtArticulo.Text = "" Then txtIDArticulo.Clear()

        FillMedida()
    End Sub

    Friend Sub FillMedida()
        Try
            If txtIDArticulo.Text <> "" Then
                Ds.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Medida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + txtIDArticulo.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "PrecioArticulo")
                CbxMedida.Items.Clear()
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")

                For Each Fila As DataRow In Tabla.Rows
                    CbxMedida.Items.Add(Fila.Item("Medida"))
                Next

                If Tabla.Rows.Count > 0 Then
                    CbxMedida.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Etiquetas' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
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

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        frm_buscar_mant_articulos.ShowDialog(Me)

        FillMedida()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))

            If txtArticulo.Text = "" Then
                MessageBox.Show("Seleccione el artículo para la impresión de las etiquetas.", "Seleccionar artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CbxMedida.Text = "" Then
                MessageBox.Show("Seleccione la medida del artículo que desea elegir.", "Seleccionar la medida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            'Para facturas a credito
            'Lleando EtiquetaData
            AdaptadorSP = New MySqlDataAdapter("Select Articulos.IDArticulo,Articulos.Descripcion,Referencia,IDTipoProducto,TipoArticulo,Articulos.IDSuplidor,Suplidor,Articulos.IDDepartamento,Departamento,Articulos.IDItbis,Tipo,Articulos.IDCategoria,Categoria,Articulos.IDSubCategoria,SubCategoria,Articulos.IDMarca,Marca,IDGarantia,TiempoGarantia,GarantiaArticulos.Dias,Articulos.IDParentesco,ParentescoProducto.Descripcion as Parentesco,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,ExistenciaTotal,ExistenciaMin,ExistenciaMax,Existencia,Articulos.RutaFoto,Articulos.PreAlertar,Articulos.Revisado,Articulos.BloqueoCredito,Articulos.Desactivar,IDExistencia,Almacen.IDSucursal,Sucursal.Sucursal,Existencia.IDAlmacen,Almacen,Color.IDColor,Color.Color,BigColorPath,QRCode,Medida.IDMedida,Medida,Existencia.Existencia as ExistenciaAlmacen,IDPrecios,Contenido,Costo,CostoFinal,CostoClave,PrecioContado,PrecioCredito,Precio3,Precio4,PrecioBlackFriday,(Select count(IDEspecificacion) from Libregco.Articulos_Especificaciones Where Articulos.IDArticulo=Articulos_Especificaciones.IDArticulo) as CantEspecificaciones from Libregco.Articulos INNER JOIN Libregco.TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.Garantiaarticulos ON Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos LEFT JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida LEFT JOIN Libregco.Existencia on PrecioArticulo.IDPrecios=Existencia.IDPrecioArticulo LEFT JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen LEFT JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.ParentescoProducto on Articulos.IDParentesco=ParentescoProducto.IDParentesco INNER JOIN Libregco.Color on Articulos.IDColor=Color.IDColor Where PrecioArticulo.IDPrecios='" + IDPrecios.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "EtiquetasData")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("listadoproductosview1").SetDataSource(DsSP.Tables("EtiquetasData"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

            '@SelectPrecio
            If cbxTipoPrecio.Text = "No mostrar precios" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxTipoPrecio.Text = "Costo" Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxTipoPrecio.Text = "Costo final" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxTipoPrecio.Text = "Precio B" Then
                crParameterDiscreteValue.Value = 3
            ElseIf cbxTipoPrecio.Text = "Precio A" Then
                crParameterDiscreteValue.Value = 4
            ElseIf cbxTipoPrecio.Text = "Precio C" Then
                crParameterDiscreteValue.Value = 5
            ElseIf cbxTipoPrecio.Text = "Precio D" Then
                crParameterDiscreteValue.Value = 6
            ElseIf cbxTipoPrecio.Text = "Clave de costo" Then
                crParameterDiscreteValue.Value = 7
            ElseIf cbxTipoPrecio.Text = "Black Friday" Then
                crParameterDiscreteValue.Value = 8
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SelectPrecio")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@TextoPresenta
            If txtEvento.Text = "" Then
                crParameterDiscreteValue.Value = ""
            Else
                crParameterDiscreteValue.Value = txtEvento.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TextoPresenta")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Me.CrystalViewer.ReportSource = ObjRpt
                Me.CrystalViewer.Refresh()
                Me.CrystalViewer.Zoom(2)

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog

                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                    .PrinterSettings.Copies = Convert.ToInt16(txtCantidad.Value)
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim PrinterSettings1 As New Printing.PrinterSettings
                    Dim PageSettings1 As New Printing.PageSettings

                    PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                    PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                    PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                    PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
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

            txtCantidad.Value = 1
            DsSP.Dispose()
            CrystalViewer.Cursor = Cursors.Default
            lblStatusBar.Text = "Listo"

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIDArticulo.Clear()
        txtArticulo.Clear()
        CbxMedida.Items.Clear()
        IDMedida.Text = ""
        txtCantidad.Value = 1
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub SetIDMedida()
        If ConLibregco.State = ConnectionState.Open Then
            ConLibregco.Close()
        End If

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMedida FROM Medida Where Medida='" + CbxMedida.SelectedItem + "'", ConLibregco)
        IDMedida.Text = Convert.ToString(cmd.ExecuteScalar())


        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + IDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        IDPrecios.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub
End Class