Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_aumento_precios_dinamico

    Dim cmd As MySqlCommand
    Dim sqlQ As String
    Dim Adaptador As MySqlDataAdapter
    Dim IDCompra As String
    Dim TablaPrecios As DataTable
    Dim PermisosArticulos As New ArrayList
    Dim PermisosEtiquetas As New ArrayList
    Dim PathReport As String
    Dim SelectedPrinter As String = ""

    Private Sub frm_aumento_precios_dinamico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PermisosArticulos = PasarPermisos(3)
        PermisosEtiquetas = PasarPermisos(29)

        Con.Open()
        cmd = New MySqlCommand("SELECT Path FROM reportes where menustring='Etiquetas' and Activo=1 ORDER BY NoOrden ASC LIMIT 1", Con)
        PathReport = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        TablaPrecios = New DataTable("Precios")

        If Me.Owner.Name = frm_registro_compras.Name Then
            IDCompra = frm_registro_compras.txtIDCompra.Text
            frm_registro_compras.PreciosDinámicosToolStripMenuItem.Visible = True
        End If

        TablaPrecios.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("IDPrecios", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Variacion", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("VariacionTexto", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("CDC", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Costo", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("MCosto", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("PorcientoCosto", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("A", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("PrecioA", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("MPrecioA", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("PorcientoA", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("B", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("PrecioB", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("MPrecioB", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("PorcientoB", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("C", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("PrecioC", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("MPrecioC", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("PorcientoC", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("D", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("PrecioD", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("MPrecioD", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("PorcientoD", System.Type.GetType("System.Double"))
        TablaPrecios.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaPrecios.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Guardar", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Imprimir", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("IDMedida", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("IDColectivo", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        GridControl1.DataSource = TablaPrecios
        FillArticulos()


    End Sub

    Private Sub FillArticulos()
        Try
            TablaPrecios.Clear()

            Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
                Using myCommand As MySqlCommand = New MySqlCommand("SELECT DetalleCompra.IDDetalleCompra,PrecioArticulo.IDArticulo,PrecioArticulo.IDPrecios AS IDPrecios,Articulos.Descripcion,Articulos.Referencia,Medida.Medida,((PrecioArticulo.Costo/IFNULL((SELECT ViejoCosto FROM libregco.precioarticulo_historial where precioarticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios ORDER BY idPrecioArticulo_historial DESC LIMIT 1),PrecioArticulo.Costo))-1) as Variacion,IFNULL((SELECT ViejoCosto FROM libregco.precioarticulo_historial where precioarticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios ORDER BY idPrecioArticulo_historial DESC LIMIT 1),PrecioArticulo.Costo) AS Costo,DetalleCompra.Importe as MCosto,PrecioArticulo.PrecioCredito as PrecioA,0 as MPrecioA,PrecioContado as PrecioB,0 as MPrecioB,Precio3 AS PrecioC,0 as MPrecioC,Precio4 AS PrecioD,0 as MPrecioD,'' AS Imagen,Articulos.RutaFoto,'CDC' AS CDC,'A' AS A,'B' AS B,'C' AS C,'D' AS D,PrecioArticulo.IDMedida,Articulos.IDColectivo,DetalleCompra.Cantidad FROM" & SysName.Text & "DetalleCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where DetalleCompra.IDCompra='" + IDCompra + "' ORDER BY DetalleCompra.Orden ASC", ConMixta)
                    ConMixta.Open()
                    Using myReader As MySqlDataReader = myCommand.ExecuteReader
                        TablaPrecios.Load(myReader, LoadOption.Upsert)
                        ConMixta.Close()
                        ConMixta.Dispose()
                    End Using
                End Using
            End Using
            TablaPrecios.EndLoadData()

            For Each dt As DataRow In TablaPrecios.Rows
                Dim wFile As System.IO.FileStream
                Dim ImgFile As Image
                dt.Item("Guardar") = 0
                dt.Item("Imprimir") = 0

                dt.Item("MPrecioA") = Math.Round(CDbl(dt.Item("PrecioA")) * (1 + (CDbl(dt.Item("Variacion")))), 3)
                dt.Item("MPrecioB") = Math.Round(CDbl(dt.Item("PrecioB")) * (1 + (CDbl(dt.Item("Variacion")))), 3)
                dt.Item("MPrecioC") = Math.Round(CDbl(dt.Item("PrecioC")) * (1 + (CDbl(dt.Item("Variacion")))), 3)
                dt.Item("MPrecioD") = Math.Round(CDbl(dt.Item("PrecioD")) * (1 + (CDbl(dt.Item("Variacion")))), 3)

                dt.Item("PorcientoCosto") = CDbl(dt.Item("MCosto")) / CDbl(dt.Item("Costo")) - 1
                dt.Item("PorcientoA") = CDbl(dt.Item("MPrecioA")) / CDbl(dt.Item("MCosto")) - 1
                dt.Item("PorcientoB") = CDbl(dt.Item("MPrecioB")) / CDbl(dt.Item("MCosto")) - 1
                dt.Item("PorcientoC") = CDbl(dt.Item("MPrecioC")) / CDbl(dt.Item("MCosto")) - 1
                dt.Item("PorcientoD") = CDbl(dt.Item("MPrecioD")) / CDbl(dt.Item("MCosto")) - 1

                If CDbl(dt.Item("Variacion")) > 0 Then
                    dt.Item("VariacionTexto") = "el costo aumentó un + " & CDbl(dt.Item("Variacion")).ToString("P2")
                ElseIf CDbl(dt.Item("Variacion")) < 0 Then
                    dt.Item("VariacionTexto") = "el costo redujo un " & CDbl(dt.Item("Variacion")).ToString("P2")
                ElseIf CDbl(dt.Item("Variacion")) = 0 Then
                    dt.Item("VariacionTexto") = "no hubo variación del costo"
                End If

                If dt.Item("RutaFoto") = "" Then
                    ImgFile = ResizeImage(My.Resources.No_Image, 64)
                Else
                    If System.IO.File.Exists(dt.Item("RutaFoto")) Then
                        wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 64)
                        wFile.Close()
                    Else
                        ImgFile = ResizeImage(My.Resources.No_Image, 64)
                    End If
                End If

                dt.Item("Imagen") = ImgFile


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanging(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanging
        Dim view As GridView = sender
        If view Is Nothing Then
            Return
        End If

        If e.Column.FieldName = "MCosto" Then
            If IsNumeric(e.Value) Then
                Dim cellValue As Double = (CDbl(e.Value) / CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Costo"))) - 1
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoCosto", cellValue)

                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoA", ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA"))) / CDbl(e.Value)) - 1)
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoB", ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB"))) / CDbl(e.Value)) - 1)
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoC", ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC"))) / CDbl(e.Value)) - 1)
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoD", ((CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD"))) / CDbl(e.Value)) - 1)

            End If

        ElseIf e.Column.FieldName = "MPrecioA" Then
            If IsNumeric(e.Value) Then
                Dim cellValue As Double = (CDbl(e.Value) / CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto"))) - 1
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoA", cellValue)
            End If

        ElseIf e.Column.FieldName = "MPrecioB" Then
            If IsNumeric(e.Value) Then
                Dim cellValue As Double = (CDbl(e.Value) / CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto"))) - 1
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoB", cellValue)
            End If

        ElseIf e.Column.FieldName = "MPrecioC" Then
            If IsNumeric(e.Value) Then
                Dim cellValue As Double = (CDbl(e.Value) / CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto"))) - 1
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoC", cellValue)
            End If

        ElseIf e.Column.FieldName = "MPrecioD" Then
            If IsNumeric(e.Value) Then
                Dim cellValue As Double = (CDbl(e.Value) / CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto"))) - 1
                AdvBandedGridView1.SetFocusedRowCellValue("PorcientoD", cellValue)
            End If

        End If

    End Sub

    Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "IDArticulo" Then
                If PermisosArticulos(0) = 1 Then
                    If frm_mant_articulos.Visible = True Then
                        If frm_mant_articulos.WindowState = FormWindowState.Minimized Then
                            frm_mant_articulos.WindowState = FormWindowState.Normal
                        Else
                            frm_mant_articulos.Activate()
                        End If
                    Else
                        frm_mant_articulos.Show(Me)
                    End If

                    frm_mant_articulos.txtIDProducto.Text = AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo")
                    frm_mant_articulos.FillAllDatafromID()
                End If
            ElseIf e.Column.FieldName = "Guardar" Then

                If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")) = 0 Then
                    MessageBox.Show("Defina el costo del artículo.", "Costo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")) = 0 Then
                    MessageBox.Show("Especifique el precio A del artículo.", "Precio de A", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")) Then
                    MessageBox.Show("El precio A es menor que el costo. Verifique los cálculos aplicados.", "Precio A menor que costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")) = 0 Then
                    MessageBox.Show("Especifique el precio B del artículo.", "Precio de B", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")) Then
                    MessageBox.Show("El precio B es menor que el costo. Verifique los cálculos aplicados.", "Precio B menor que costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")) Then
                    MessageBox.Show("El precio A es menor que el precio B. Verifique los cálculos aplicados.", "Precio A menor que B", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")) = 0 Then
                    MessageBox.Show("Escriba y/o establezca el precio C del artículo..", "Precio de C", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")) Then
                    MessageBox.Show("El precio C es menor que el costo. Verifique los cálculos aplicados.", "Precio C menor que costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")) Then
                    MessageBox.Show("El precio B es menor que el precio C. Verifique los cálculos aplicados.", "Precio B menor que C", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")) = 0 Then
                    MessageBox.Show("Escriba y/o establezca el precio D del artículo.", "Precio de D", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")) Then
                    MessageBox.Show("El precio C es menor que el precio D. Verifique los cálculos aplicados.", "Precio C menor que D", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                ElseIf CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")) Then
                    MessageBox.Show("El precio D es menor que el costo. Verifique los cálculos aplicados.", "Precio D menor que costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If

                Con.Open()
                CheckedUptadesinPrinces(AdvBandedGridView1.GetFocusedRowCellValue("IDPrecios"), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")))
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")).ToString + "',CostoFinal='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")).ToString + "',PrecioContado='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")).ToString + "',PrecioCredito='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")).ToString + "',Precio3='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")).ToString + "',Precio4='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA"))).ToString + "' WHERE IDPrecios=(" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecios") + ")", Con)
                cmd.ExecuteNonQuery()
                UpdateLastUpdatePrices(AdvBandedGridView1.GetFocusedRowCellValue("IDPrecios"))
                Con.Close()

                AdvBandedGridView1.SetFocusedRowCellValue("Guardar", "1")
                AdvBandedGridView1.ClearSelection()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))


            ElseIf e.Column.FieldName = "Etiqueta" Then
                Dim DsSP As New DataSet
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim crParameterFiledDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterRangeValue As ParameterRangeValue
                Dim ObjRpt As New ReportDocument

                If TypeConnection.Text = 1 Then
                    ObjRpt.Load("\\" & PathServidor.Text & PathReport)
                Else
                    ObjRpt.Load("C:" & PathReport.Replace("\Libregco\Libregco.net", ""))
                End If

                Dim cmdSP As New MySqlCommand
                Dim AdaptadorSP As MySqlDataAdapter

                'Llenado EmpresaView
                AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                AdaptadorSP.Fill(DsSP, "EmpresaView")

                'Para facturas a credito
                'Lleando EtiquetaData
                AdaptadorSP = New MySqlDataAdapter("Select Articulos.IDArticulo,Articulos.Descripcion,Referencia,IDTipoProducto,TipoArticulo,Articulos.IDSuplidor,Suplidor,Articulos.IDDepartamento,Departamento,Articulos.IDItbis,Tipo,Articulos.IDCategoria,Categoria,Articulos.IDSubCategoria,SubCategoria,Articulos.IDMarca,Marca,IDGarantia,TiempoGarantia,GarantiaArticulos.Dias,Articulos.IDParentesco,ParentescoProducto.Descripcion as Parentesco,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,ExistenciaTotal,ExistenciaMin,ExistenciaMax,Existencia,Articulos.RutaFoto,Articulos.PreAlertar,Articulos.Revisado,Articulos.BloqueoCredito,Articulos.Desactivar,IDExistencia,Almacen.IDSucursal,Sucursal.Sucursal,Existencia.IDAlmacen,Almacen,Color.IDColor,Color.Color,BigColorPath,QRCode,Medida.IDMedida,Medida,Existencia.Existencia as ExistenciaAlmacen,IDPrecios,Contenido,Costo,CostoFinal,CostoClave,PrecioContado,PrecioCredito,Precio3,Precio4,PrecioBlackFriday from Libregco.Articulos INNER JOIN Libregco.TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.Garantiaarticulos ON Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos LEFT JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida LEFT JOIN Libregco.Existencia on PrecioArticulo.IDPrecios=Existencia.IDPrecioArticulo LEFT JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen LEFT JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.ParentescoProducto on Articulos.IDParentesco=ParentescoProducto.IDParentesco INNER JOIN Libregco.Color on Articulos.IDColor=Color.IDColor Where PrecioArticulo.IDPrecios='" + AdvBandedGridView1.GetFocusedRowCellValue("IDPrecios").ToString + "'", ConMixta)
                AdaptadorSP.Fill(DsSP, "EtiquetasData")

                cmdSP.Dispose()
                AdaptadorSP.Dispose()

                ObjRpt.Database.Tables("listadoproductosview1").SetDataSource(DsSP.Tables("EtiquetasData"))
                ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

                '@SelectPrecio
                crParameterDiscreteValue.Value = 4
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SelectPrecio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TextoPresenta
                crParameterDiscreteValue.Value = ""
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TextoPresenta")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                Dim PrintDialog As New PrintDialog

                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                    .PrinterSettings.Copies = Convert.ToInt16(AdvBandedGridView1.GetFocusedRowCellValue("Cantidad"))
                    If SelectedPrinter <> "" Then
                        .PrinterSettings.PrinterName = SelectedPrinter
                    End If

                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Dim PrinterSettings1 As New Printing.PrinterSettings
                    Dim PageSettings1 As New Printing.PageSettings

                    PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                    PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                    PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                    PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                    ObjRpt.SummaryInfo.ReportTitle = Me.Text
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

                    SelectedPrinter = PrinterSettings1.PrinterName

                    ObjRpt.Dispose()
                    DsSP.Dispose()
                End If
            End If
        End If
    End Sub

    Public Sub UpdateLastUpdatePrices(ByVal IDPrecio As String)
        Dim Dstemp As New DataSet

        cmd = New MySqlCommand("SELECT IFNULL((Select FechaFactura from Libregco.Compras inner join Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraZ,IFNULL((Select DetalleCompra.Importe from Libregco.Compras INNER JOIN Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraZ,IFNULL((Select FechaFactura from Libregco_Main.Compras inner join Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraA,IFNULL((Select DetalleCompra.Importe from Libregco_Main.Compras INNER JOIN Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraA,IFNULL((Select DATE(Fecha) from Libregco.PrecioArticulo_historial where PrecioArticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios ORDER BY PrecioArticulo_historial.FechA DESC LIMIT 1),'1990-01-01') as UltimoCambioPrecios from Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo where PrecioArticulo.IDPrecios='" + IDPrecio.ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "precioarticulo")

        If Dstemp.Tables("precioarticulo").Rows.Count > 0 Then
            Dim ArrDates As New List(Of Date)

            If CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ")) > CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraA")) Then
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraZ").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            Else
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraA").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraA").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

        End If

        Dstemp.Dispose()

    End Sub

    Private Sub ActualizarPreciosGrupales()
        Dim dstemp As New DataSet
        cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioCredito,PrecioContado,Precio3,Precio4 FROM libregco.articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Articulos_Grupos on Articulos.IDColectivo=Articulos_Grupos.idArticulos_grupos where Articulos.IDColectivo='" + AdvBandedGridView1.GetFocusedRowCellValue("IDColectivo").ToString + "' and PrecioArticulo.IDMedida='" + AdvBandedGridView1.GetFocusedRowCellValue("IDMedida").ToString + "' and Articulos_Grupos.VincularPrecio=1 and Articulos.IDArticulo<>'" + AdvBandedGridView1.GetFocusedRowCellValue("IDArticulo").ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "PrecioArticulo")

        Dim Tabla As DataTable = dstemp.Tables("PrecioArticulo")

        For Each rw As DataRow In Tabla.Rows
            CheckedUptadesinPrinces(rw.Item("IDPrecios").ToString, CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")), CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")))
            cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")).ToString + "',CostoFinal='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MCosto")).ToString + "',PrecioContado='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioB")).ToString + "',PrecioCredito='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA")).ToString + "',Precio3='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioC")).ToString + "',Precio4='" + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioD")).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(AdvBandedGridView1.GetFocusedRowCellValue("MPrecioA"))).ToString + "' WHERE IDPrecios=(" + rw.Item("IDPrecios").ToString + ")", Con)
            cmd.ExecuteNonQuery()
            UpdateLastUpdatePrices(rw.Item("IDPrecios").ToString)
        Next

        Tabla.Dispose()
        dstemp.Dispose()

    End Sub

    Private Sub AdvBandedGridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AdvBandedGridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                If View.GetRowCellValue(e.RowHandle, View.Columns("Guardar")) = "1" Then
                    e.Appearance.BackColor = Color.White
                    e.Appearance.BackColor2 = Color.LightGreen
                    e.HighPriority = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class