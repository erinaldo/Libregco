Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.Win32
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports DevExpress.XtraGrid.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils

Public Class frm_cierre_facturas
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Private ConMixPrefactura As New MySqlConnection(CnGeneral) 'Conexion mixta
    Private ConMixPrefacturaArticulos As New MySqlConnection(CnGeneral) 'Conexion mixta
    Private ConMixPrefacturaArticulosMultiple As New MySqlConnection(CnGeneral) 'Conexion mixta

    Private LastLastIdletime As Integer = 0
    Dim CounterIdleTime, idletime As Integer
    Friend cantidadFilas As Integer = 0
    Dim lastInputInf As New LASTINPUTINFO()

    Dim VidaUtilPrefacturaenHoras As Integer = 0
    Friend sqlQ As String
    Friend TablaPrefacturas As DataTable
    Dim RepositoryIncluir As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .Caption = "Incluír", .ReadOnly = False, .AllowGrayed = False, .NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive}
    Dim ReposityImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False, .ReadOnly = True}
    Dim RepositoryDescripMultiple As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False, .ReadOnly = True}
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor, .SmallImages = imgFlags, .ReadOnly = True, .Name = "RepCurrency"}

    Friend TablaArticulos As DataTable


    Friend TablaMultipleArticulos As DataTable
    Dim ReposityImagenMultiple As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}
    Dim RepositorySecondIDMultiple As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}

    Friend SelectedIDPrefacturaMultiple As String = ""
    <StructLayout(LayoutKind.Sequential)>
    Structure LASTINPUTINFO
        <MarshalAs(UnmanagedType.U4)>
        Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)>
        Public dwTime As Integer
    End Structure

    <DllImport("user32.dll")>
    Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function


    Private Sub frm_cierre_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        FillReportes()
        FillInstaledPrinters()
        CargarLibregco()
        Permisos = PasarPermisos(73)
        CargarConfiguracion()
        SetVentasTable()
        SetTablaMultipleArticulos()
        RefrescarTabla()
        AddHandler RepositoryIncluir.EditValueChanged, AddressOf OnEditValueChanged
    End Sub

    Private Sub SetTablaMultipleArticulos()
        'Tabla articulos
        TablaMultipleArticulos = New DataTable("ArticulosMultiple")
        TablaMultipleArticulos.Columns.Add("IDPrefactura", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("SecondIDPrefactura", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("IDPrefactArt", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("Cantidad", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("PrecioUnitario", System.Type.GetType("System.Double"))
        TablaMultipleArticulos.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TablaMultipleArticulos.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TablaMultipleArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))
        TablaMultipleArticulos.Columns.Add("RutaImagen", System.Type.GetType("System.String"))
        TablaMultipleArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaMultipleArticulos.Columns.Add("Nivel", System.Type.GetType("System.String"))
        GridViewMultiplePrefacturas.DataSource = TablaMultipleArticulos

        GridView3.Columns("SecondIDPrefactura").ColumnEdit = RepositorySecondIDMultiple
        GridView3.Columns("Imagen").ColumnEdit = ReposityImagenMultiple
        GridView3.Columns("Descripcion").ColumnEdit = RepositoryDescripMultiple



        GridView3.Columns("IDPrefactura").Visible = False
        GridView3.Columns("SecondIDPrefactura").Caption = "Prefactura"
        GridView3.Columns("IDPrefactArt").Visible = False
        GridView3.Columns("RutaImagen").Visible = False
        GridView3.Columns("Descripcion").OptionsColumn.FixedWidth = 300
        GridView3.Columns("Descripcion").Width = 300
        GridView3.Columns("PrecioUnitario").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("PrecioUnitario").DisplayFormat.FormatString = "C2"
        GridView3.Columns("Descuento").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("Descuento").DisplayFormat.FormatString = "C2"
        GridView3.Columns("Itbis").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("Itbis").DisplayFormat.FormatString = "C2"
        GridView3.Columns("Itbis").Visible = False
        GridView3.Columns("Importe").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("Importe").DisplayFormat.FormatString = "C2"

        If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
            GridView3.Columns("Imagen").Visible = True
        Else
            GridView3.Columns("Imagen").Visible = False
        End If

        GridView3.Columns("IDArticulo").Caption = "Código"
        GridView3.Columns("PrecioUnitario").Caption = "Precio"
        GridView3.Columns("Descripcion").Caption = "Descripción"

        GridView3.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")

        For i = 0 To GridView3.Columns.Count - 1
            GridView3.Columns(i).OptionsColumn.ReadOnly = True
            GridView3.Columns(i).OptionsColumn.AllowEdit = False
        Next

    End Sub

    Private Sub SumarRowsGridArticulos()
        Dim DescuentoGridArticulos As Double = 0

        For Each rw As DataRow In TablaArticulos.Rows
            DescuentoGridArticulos = DescuentoGridArticulos + CDbl(rw.Item("Descuento"))
        Next

        If DescuentoGridArticulos = 0 Then
            GridView2.Columns("Descuento").Visible = False
        Else
            GridView2.Columns("Descuento").Visible = False
        End If
    End Sub

    Private Sub SUmarRowsGridMultiple()
        Dim DescuentoArticulosMultiple As Double = 0

        For Each rw As DataRow In TablaMultipleArticulos.Rows
            DescuentoArticulosMultiple = DescuentoArticulosMultiple + CDbl(rw.Item("Descuento"))
        Next

        If DescuentoArticulosMultiple = 0 Then
            GridView3.Columns("Descuento").Visible = False
        Else
            GridView3.Columns("Descuento").Visible = False
        End If
    End Sub


    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PostEditor()

        'Aqui va el evento de refrescar tabla multiples
        Dim dstemp As New DataSet

        If ConMixPrefacturaArticulosMultiple.State = ConnectionState.Open Then
            ConMixPrefacturaArticulosMultiple.Close()
        End If

        ConMixPrefacturaArticulosMultiple.Open()

        Dim iterateIndex As Integer = 0
        Dim newDataTable As DataTable = TablaMultipleArticulos.Copy
        For Each RT As DataRow In newDataTable.Rows
            cmd = New MySqlCommand("Select Cierre from" & SysName.Text & "Prefactura where IDPrefactura='" + RT.Item("IDPrefactura").ToString + "'", ConMixPrefacturaArticulosMultiple)
            If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                TablaMultipleArticulos.Rows.RemoveAt(iterateIndex)
            Else
                iterateIndex += 1
            End If
        Next
        newDataTable.Dispose()

        If GridView1.GetFocusedRowCellValue("Incluir").ToString = 1 Then
            cmd = New MySqlCommand("Select Prefactura.IDPrefactura,Prefactura.SecondID,IDPrefactArt,Cantidad,Medida,prefacturaarticulos.IDArticulo,prefacturaarticulos.Descripcion,(Importe/Cantidad) as PrecioUnitario,Descuento,Itbis,Importe,Articulos.RutaFoto,NivelPrecioArticulo from" & SysName.Text & "prefacturaarticulos INNER JOIN" & SysName.Text & "Prefactura on PrefacturaArticulos.IDPrefactura=Prefactura.IDPrefactura INNER JOIN Libregco.Articulos on PrefacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE PrefacturaArticulos.IDPreFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixPrefacturaArticulosMultiple)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "PrefacturaArticulos")

            Dim TablaArticulo As DataTable = dstemp.Tables("PrefacturaArticulos")

            For Each rw As DataRow In TablaArticulo.Rows
                Dim ArticuloEncontrado As Boolean = False

                For Each RowsinTablaArticulos As DataRow In TablaMultipleArticulos.Rows
                    If rw.Item("IDPrefactArt") = RowsinTablaArticulos.Item("IDPrefactArt") Then
                        ArticuloEncontrado = True
                        Dim myRow() As DataRow = TablaMultipleArticulos.Select("IDPrefactArt = '" + RowsinTablaArticulos.Item("IDPrefactArt") + "'")
                        myRow(0)("Cantidad") = rw.Item("Cantidad")
                        myRow(0)("PrecioUnitario") = rw.Item("PrecioUnitario")
                        myRow(0)("Descuento") = rw.Item("Descuento")
                        myRow(0)("Itbis") = rw.Item("Itbis")
                        myRow(0)("Importe") = rw.Item("Importe")
                        Exit For
                    End If
                Next

                If ArticuloEncontrado = False Then
                    If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
                        Dim img As Image
                        If rw.Item("RutaFoto") <> "" Then
                            If System.IO.File.Exists(rw.Item("RutaFoto")) = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(rw.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                img = ResizeImage(System.Drawing.Image.FromStream(wFile), 35)
                                wFile.Close()
                            Else
                                img = ResizeImage(My.Resources.No_Image, 35)
                            End If
                        Else
                            img = ResizeImage(My.Resources.No_Image, 35)
                        End If


                        TablaMultipleArticulos.Rows.Add(rw.Item("IDPrefactura"), rw.Item("SecondID"), rw.Item("IDPrefactArt"), rw.Item("Cantidad"), rw.Item("Medida"), rw.Item("IDArticulo"), rw.Item("Descripcion"), rw.Item("PrecioUnitario"), rw.Item("Descuento"), rw.Item("Itbis"), rw.Item("Importe"), rw.Item("RutaFoto"), ResizeImage(img, 35), rw.Item("NivelPrecioArticulo"))

                    Else
                        TablaMultipleArticulos.Rows.Add(rw.Item("IDPrefactura"), rw.Item("SecondID"), rw.Item("IDPrefactArt"), rw.Item("Cantidad"), rw.Item("Medida"), rw.Item("IDArticulo"), rw.Item("Descripcion"), rw.Item("PrecioUnitario"), rw.Item("Descuento"), rw.Item("Itbis"), rw.Item("Importe"), rw.Item("RutaFoto"), ResizeImage(My.Resources.No_Image, 15), rw.Item("NivelPrecioArticulo"))
                    End If

                End If
            Next

        Else

            Dim iterateIndex1 As Integer = 0
            Dim newDataTable1 As DataTable = TablaMultipleArticulos.Copy
            For Each itm As DataRow In newDataTable1.Rows
                If itm.Item("IDPrefactura") = GridView1.GetFocusedRowCellValue("ID").ToString Then
                    TablaMultipleArticulos.Rows.RemoveAt(iterateIndex1)
                Else
                    iterateIndex1 += 1
                End If
            Next
            newDataTable1.Dispose()
        End If

        ConMixPrefacturaArticulosMultiple.Close()

        SUmarRowsGridMultiple()
        GridView3.BestFitColumns()

        ContarCheckeds()


    End Sub


    Sub ContarCheckeds()
        cantidadFilas = 0

        For Each rt As DataRow In TablaPrefacturas.Rows
            If rt.Item("Incluir") = True Then
                cantidadFilas += 1
            End If
        Next

        If cantidadFilas >= 2 Then
            GroupControl1.Visible = True
            GridArticulos.Visible = False
        Else
            GroupControl1.Visible = False
            GridArticulos.Visible = True
        End If

    End Sub


    Private Sub SetVentasTable()
        TablaPrefacturas = New DataTable("Prefacturas")

        TablaPrefacturas.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Hora", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("FechaHora", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("IDEquipo", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Equipo", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Almacen", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("IDSucursal", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Sucursal", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Vendedor", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("NombreFactura", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Condicion", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))
        TablaPrefacturas.Columns.Add("FormaPago", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Usando", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Vencimiento", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("VidaUtil", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Cierre", System.Type.GetType("System.String"))
        TablaPrefacturas.Columns.Add("Moneda", System.Type.GetType("System.Object"))
        TablaPrefacturas.Columns.Add("Incluir", System.Type.GetType("System.String"))

        GvPrefacturas.DataSource = TablaPrefacturas
        GridView1.Columns("Incluir").ColumnEdit = RepositoryIncluir
        GridView1.Columns("SecondID").ColumnEdit = RepositorySecondID
        GridView1.Columns("Moneda").ColumnEdit = RepositoryCurrency

        'Propiedades
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("ID").Caption = "Código clave de la prefactura"
        GridView1.Columns("SecondID").Caption = "Código de prefactura"
        GridView1.Columns("SecondID").Caption = "Documento"
        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Hora").Visible = False
        GridView1.Columns("FechaHora").Caption = "Fecha de registro"
        GridView1.Columns("IDEquipo").Visible = False
        GridView1.Columns("Equipo").Visible = False
        GridView1.Columns("IDAlmacen").Visible = False
        GridView1.Columns("Almacen").Visible = False
        GridView1.Columns("IDSucursal").Visible = False
        GridView1.Columns("Sucursal").Visible = False
        GridView1.Columns("IDVendedor").Caption = "ID del vendedor"
        GridView1.Columns("IDVendedor").Visible = False
        GridView1.Columns("Vendedor").Visible = False
        GridView1.Columns("IDCliente").Caption = "ID"
        GridView1.Columns("NombreFactura").Caption = "Nombre del cliente"
        GridView1.Columns("Condicion").Caption = "Condición"
        GridView1.Columns("TotalNeto").Caption = "Total Neto"
        GridView1.Columns("FormaPago").Caption = "T/ Pago"
        GridView1.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("TotalNeto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Moneda").Caption = "$"

        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            GridView1.Columns("FormaPago").Visible = True
        Else
            GridView1.Columns("FormaPago").Visible = False
        End If
        GridView1.Columns("Usando").Visible = False
        GridView1.Columns("Cierre").Visible = False

        If CInt(DTConfiguracion.Rows(136 - 1).Item("Value2Int")) = 1 Then
            GridView1.Columns("VidaUtil").Visible = True
        Else
            GridView1.Columns("VidaUtil").Visible = False
        End If

        GridView1.Columns("Vencimiento").Visible = False
        GridView1.Columns("Vencimiento").OptionsColumn.ReadOnly = True
        GridView1.Columns("Vencimiento").OptionsColumn.AllowEdit = False
        GridView1.Columns("VidaUtil").OptionsColumn.ReadOnly = True
        GridView1.Columns("VidaUtil").OptionsColumn.AllowEdit = False
        GridView1.Columns("VidaUtil").Caption = "Vida útil"
        GridView1.Columns("Incluir").Caption = "Incluír"
        GridView1.Columns("TotalNeto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalNeto", "{0:c2}")

        For i = 0 To GridView1.Columns.Count - 2
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        'Tabla articulos
        TablaArticulos = New DataTable("Articulos")
        TablaArticulos.Columns.Add("IDPrefactArt", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Cantidad", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("PrecioUnitario", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("RutaImagen", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaArticulos.Columns.Add("Nivel", System.Type.GetType("System.String"))

        GridArticulos.DataSource = TablaArticulos
        GridView2.Columns("Descripcion").ColumnEdit = RepositoryDescrip
        GridView2.Columns("Descripcion").OptionsColumn.FixedWidth = 300
        GridView2.Columns("Descripcion").Width = 300
        GridView2.Columns("PrecioUnitario").DisplayFormat.FormatType = FormatType.Numeric
        GridView2.Columns("PrecioUnitario").DisplayFormat.FormatString = "C2"
        GridView2.Columns("Descuento").DisplayFormat.FormatType = FormatType.Numeric
        GridView2.Columns("Descuento").DisplayFormat.FormatString = "C2"
        GridView2.Columns("Itbis").DisplayFormat.FormatType = FormatType.Numeric
        GridView2.Columns("Itbis").DisplayFormat.FormatString = "C2"
        GridView2.Columns("Itbis").Visible = False
        GridView2.Columns("Importe").DisplayFormat.FormatType = FormatType.Numeric
        GridView2.Columns("Importe").DisplayFormat.FormatString = "C2"
        GridView2.Columns("Imagen").AppearanceCell.BackColor = Color.White
        GridView2.Columns("Imagen").ColumnEdit = ReposityImagen
        ReposityImagen.Appearance.BackColor = Color.White
        ReposityImagen.Appearance.BackColor2 = Color.White
        ReposityImagen.AppearanceFocused.BackColor = Color.White

        GridView2.Columns("IDPrefactArt").Visible = False
        GridView2.Columns("RutaImagen").Visible = False

        If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
            GridView2.Columns("Imagen").Visible = True
        Else
            GridView2.Columns("Imagen").Visible = False
        End If

        GridView2.Columns("IDArticulo").Caption = "Código"
        GridView2.Columns("PrecioUnitario").Caption = "Precio"
        GridView2.Columns("Descripcion").Caption = "Descripción"

        GridView2.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")

        For i = 0 To GridView2.Columns.Count - 1
            GridView2.Columns(i).OptionsColumn.ReadOnly = True
            GridView2.Columns(i).OptionsColumn.AllowEdit = False
        Next
    End Sub

    Public Function GetLastInputTime() As Integer
        idletime = 0
        lastInputInf.cbSize = Marshal.SizeOf(lastInputInf)
        lastInputInf.dwTime = 0

        If GetLastInputInfo(lastInputInf) Then
            idletime = Environment.TickCount - lastInputInf.dwTime
        End If

        If idletime > 0 Then
            Return idletime / 1000
        Else : Return 0
        End If

    End Function
    Private Sub CargarConfiguracion()
        Try
            'Bloqueo de impresiones rápidas en cierre de prefacturas
            If CInt(DTConfiguracion.Rows(126 - 1).Item("Value2Int")) = 1 Then
                chkImpresionDirecta.Checked = False
                chkImpresionDirecta.Visible = False
                GroupBox3.Visible = False
            Else
                chkImpresionDirecta.Checked = True
                chkImpresionDirecta.Visible = True
                GroupBox3.Visible = True
            End If

            'Control de tipo de pago en prefacturacion
            'ControlTipoPago = CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int"))

            'Verificar si la vida es limitada
            'LimitarVidaUtil = CInt(DTConfiguracion.Rows(136 - 1).Item("Value2Int"))

            If CInt(DTConfiguracion.Rows(136 - 1).Item("Value2Int")) = 1 Then
                Timer2.Enabled = True
                lblValidez.Visible = True

                'Verificar vida especificada
                VidaUtilPrefacturaenHoras = CInt(DTConfiguracion.Rows(137 - 1).Item("Value2Int"))

                If VidaUtilPrefacturaenHoras = 0 Then
                    lblValidez.Text = "Validez de prefacturas: Siempre"
                    VidaUtilPrefacturaenHoras = 99999
                ElseIf VidaUtilPrefacturaenHoras = 1 Then
                    VidaUtilPrefacturaenHoras = 12
                    lblValidez.Text = "Validez de prefacturas: 12 horas / 1/2 día"
                ElseIf VidaUtilPrefacturaenHoras = 2 Then
                    VidaUtilPrefacturaenHoras = 24
                    lblValidez.Text = "Validez de prefacturas: 24 horas / 1 día"
                ElseIf VidaUtilPrefacturaenHoras = 3 Then
                    VidaUtilPrefacturaenHoras = 48
                    lblValidez.Text = "Validez de prefacturas: 48 horas / 2 días"
                ElseIf VidaUtilPrefacturaenHoras = 4 Then
                    VidaUtilPrefacturaenHoras = 96
                    lblValidez.Text = "Validez de prefacturas: 96 horas / 4 días"
                ElseIf VidaUtilPrefacturaenHoras = 5 Then
                    VidaUtilPrefacturaenHoras = 192
                    lblValidez.Text = "Validez de prefacturas: 192 horas / 8 días"
                ElseIf VidaUtilPrefacturaenHoras = 6 Then
                    VidaUtilPrefacturaenHoras = 360
                    lblValidez.Text = "Validez de prefacturas: 360 horas / 15 días"
                ElseIf VidaUtilPrefacturaenHoras = 7 Then
                    VidaUtilPrefacturaenHoras = 720
                    lblValidez.Text = "Validez de prefacturas: 720 horas / 30 días"
                ElseIf VidaUtilPrefacturaenHoras = 8 Then
                    VidaUtilPrefacturaenHoras = 1440
                    lblValidez.Text = "Validez de prefacturas: 1,440 horas / 60 días"
                End If

            Else
                VidaUtilPrefacturaenHoras = 99999
                Timer2.Enabled = False
                lblValidez.Visible = False
            End If

            'Altura de las imágenes de facturación
            'PictureHeightFacturacion = CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))

            'Altura de las imágenes de prefacturación
            'PictureHeightPrefacturacion = CInt(DTConfiguracion.Rows(179 - 1).Item("Value2Int"))

            'Utilizar reportes predefinidos en facturación
            'ReportesPredefinidos = CInt(DTConfiguracion.Rows(188 - 1).Item("Value2Int"))

            'Reporte de facturación para facturas al contado
            'ReporteContado = CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int"))

            'Reporte de facturación para facturas a crédito
            'ReporteCredito = CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int"))

            'Fill tipo moneda
            RepositoryCurrency.SmallImages = imgFlags
            ''RepositoryCurrency.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
            RepositoryCurrency.GlyphAlignment = HorzAlignment.Center
            RepositoryCurrency.Name = "RepCurrency"

            Dim dstemp As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM Libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "tipomoneda")
            ConLibregco.Close()

            Dim Tabla As DataTable = dstemp.Tables("tipomoneda")

            For Each Fila As DataRow In Tabla.Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                'nvmoneda.Description = Fila.Item("Texto")
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                RepositoryCurrency.Properties.Items.Add(nvmoneda)
            Next
            'Con.Close()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
    Private Sub FillInstaledPrinters()
        For Each pkInstalledPrinters As String In PrinterSettings.InstalledPrinters

            If pkInstalledPrinters.Contains("OneNote") = False Then
                If pkInstalledPrinters.Contains("XPS") = False Then
                    If pkInstalledPrinters.Contains("Fax") = False Then
                        CbxInstalledPrinters.Items.Add(pkInstalledPrinters)
                    End If
                End If
            End If


        Next

        If CbxInstalledPrinters.Items.Count > 0 Then
            If GetDefaultPrinter.Contains("OneNote") = True Then
                CbxInstalledPrinters.SelectedIndex = 0
            ElseIf GetDefaultPrinter.Contains("XPS") = True Then
                CbxInstalledPrinters.SelectedIndex = 0
            ElseIf GetDefaultPrinter.Contains("Fax") = True Then
                CbxInstalledPrinters.SelectedIndex = 0
            Else
                CbxInstalledPrinters.Text = GetDefaultPrinter()
            End If
        End If

    End Sub

    Public Function GetDefaultPrinter() As String
        Dim settings As PrinterSettings = New PrinterSettings()
        Return settings.PrinterName
    End Function

    Friend Sub RefrescarTabla()
        Try
            Dim dstemp As New DataSet

            If ConMixPrefactura.State = ConnectionState.Open Then
                ConMixPrefactura.Close()
            End If

            ConMixPrefactura.Open()

            Timer1.Enabled = False

            Dim iterateIndex As Integer = 0
            Dim newDataTable As DataTable = TablaPrefacturas.Copy
            For Each RT As DataRow In newDataTable.Rows
                cmd = New MySqlCommand("Select Cierre from" & SysName.Text & "Prefactura where IDPrefactura='" + RT.Item("ID").ToString + "'", ConMixPrefactura)
                If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                    TablaPrefacturas.Rows.RemoveAt(iterateIndex)
                Else
                    iterateIndex += 1
                End If
            Next
            newDataTable.Dispose()

            cmd = New MySqlCommand("SELECT IDPreFactura,Prefactura.SecondID,Prefactura.Fecha,Prefactura.Hora,TIMESTAMP(Prefactura.Fecha,Prefactura.Hora) as FechaHora,Prefactura.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,IDVendedor,Vendedor.Nombre as NombreVendedor,IDCliente,NombreFactura,Condicion.Condicion,TotalNeto,(if(Prefactura.TipoPago=1,'Sólo Efectivo',if(Prefactura.TipoPago=2,'Tarjeta',if(Prefactura.TipoPago=3,'Pago Mixto','N/A')))) as TipoPago,Usando,Cierre,Prefactura.IDMoneda FROM" & SysName.Text & "prefactura INNER JOIN Libregco.Condicion on Prefactura.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Prefactura.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "AreaImpresion on Prefactura.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal where Cierre=0 and Prefactura.Nulo=0 order by IDPrefactura ASC", ConMixPrefactura)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "PreFactura")
            ConMixPrefactura.Close()

            Dim Tabla As DataTable = dstemp.Tables("PreFactura")

            For Each dt As DataRow In Tabla.Rows
                Dim PrefacturaEncontrada As Boolean = False

                For Each RowsinTablePrefacturas As DataRow In TablaPrefacturas.Rows
                    If dt.Item("IDPrefactura") = RowsinTablePrefacturas.Item("ID") Then
                        PrefacturaEncontrada = True
                        Dim myRow() As DataRow = TablaPrefacturas.Select("ID = '" + dt.Item("IDPrefactura").ToString + "'")
                        myRow(0)("IDCliente") = dt.Item("IDCliente")
                        myRow(0)("NombreFactura") = dt.Item("NombreFactura")
                        myRow(0)("Condicion") = dt.Item("Condicion")
                        myRow(0)("TotalNeto") = dt.Item("TotalNeto")
                        myRow(0)("Usando") = dt.Item("Usando")
                        myRow(0)("FormaPago") = dt.Item("TipoPago")
                        myRow(0)("Moneda") = dt.Item("IDMoneda")
                        Exit For
                    End If
                Next

                If PrefacturaEncontrada = False Then
                    Dim Datex As DateTime = CDate(dt.Item("Fecha")).ToString("dd/MM/yyyy") & " " & CDate(Convert.ToString(dt.Item("Hora"))).ToString("hh:mm:ss tt")
                    Dim Datez As DateTime = CDate(CDate(dt.Item("Fecha")).ToString("dd/MM/yyyy") & " " & CDate(Convert.ToString(dt.Item("Hora"))).ToString("hh:mm:ss tt")).AddHours(VidaUtilPrefacturaenHoras)
                    Dim SpanDt As TimeSpan = Datez - Now

                    TablaPrefacturas.Rows.Add(dt.Item("IDPrefactura"), dt.Item("SecondID"), dt.Item("Fecha"), dt.Item("Hora"), dt.Item("FechaHora"), dt.Item("IDEquipo"), dt.Item("ComputerName"), dt.Item("IDAlmacen"), dt.Item("Almacen"), dt.Item("IDSucursal"), dt.Item("Sucursal"), dt.Item("IDVendedor"), dt.Item("NombreVendedor"), dt.Item("IDCliente"), dt.Item("NombreFactura"), dt.Item("Condicion"), dt.Item("TotalNeto"), dt.Item("TipoPago"), dt.Item("Usando"), Datez.ToString("dd/MM/yyyy") & " " & Datez.ToString("hh:mm:ss tt"), String.Format("{0} días, {1} horas, {2} minutos, {3} segundos", SpanDt.Days, SpanDt.Hours, SpanDt.Minutes, SpanDt.Seconds), dt.Item("Cierre"), CInt(dt.Item("IDMoneda")), 0)
                End If
            Next


            GridView1.BestFitColumns()
            LStatus()

            BuscarArticulosPrefactura()

            Timer1.Enabled = True

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        BuscarArticulosPrefactura()
        VerificacionRepPredefinido()
    End Sub

    Private Sub BuscarArticulosPrefactura()
        If TablaPrefacturas.Rows.Count = 0 Then
            TablaArticulos.Rows.Clear()
        Else
            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.SelectedRowsCount > 0 Then
                    TablaArticulos.Rows.Clear()

                    Dim DsTemp1 As New DataSet

                    If ConMixPrefacturaArticulos.State = ConnectionState.Open Then
                        ConMixPrefacturaArticulos.Close()
                    End If

                    ConMixPrefacturaArticulos.Open()
                    cmd = New MySqlCommand("Select IDPrefactArt,Cantidad,Medida,prefacturaarticulos.IDArticulo,prefacturaarticulos.Descripcion,(Importe/Cantidad) as PrecioUnitario,Descuento,Itbis,Importe,Articulos.RutaFoto,NivelPrecioArticulo from" & SysName.Text & "prefacturaarticulos INNER JOIN Libregco.Articulos on PrefacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE IDPreFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixPrefacturaArticulos)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp1, "PrefacturaArticulos")
                    ConMixPrefacturaArticulos.Close()
                    Dim TablaArticulo As DataTable = DsTemp1.Tables("PrefacturaArticulos")


                    For Each rw As DataRow In TablaArticulo.Rows
                        Dim ArticuloEncontrado As Boolean = False

                        For Each RowsinTablaArticulos As DataRow In TablaArticulos.Rows
                            If rw.Item("IDPrefactArt") = RowsinTablaArticulos.Item("IDPrefactArt") Then
                                ArticuloEncontrado = True
                                Dim myRow() As DataRow = TablaArticulos.Select("IDPrefactArt = '" + RowsinTablaArticulos.Item("IDPrefactArt").ToString + "'")
                                myRow(0)("Cantidad") = rw.Item("Cantidad")
                                myRow(0)("PrecioUnitario") = rw.Item("PrecioUnitario")
                                myRow(0)("Descuento") = rw.Item("Descuento")
                                myRow(0)("Itbis") = rw.Item("Itbis")
                                myRow(0)("Importe") = rw.Item("Importe")
                                Exit For
                            End If
                        Next

                        If ArticuloEncontrado = False Then
                            If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
                                Dim img As Image

                                If rw.Item("RutaFoto") <> "" Then
                                    If System.IO.File.Exists(rw.Item("RutaFoto")) = True Then
                                        Dim wFile As System.IO.FileStream
                                        wFile = New FileStream(rw.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                        img = System.Drawing.Image.FromStream(wFile)
                                        wFile.Close()
                                    Else
                                        img = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(179 - 1).Item("Value2Int")))
                                    End If
                                Else
                                    img = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(179 - 1).Item("Value2Int")))
                                End If


                                TablaArticulos.Rows.Add(rw.Item("IDPrefactArt"), rw.Item("Cantidad"), rw.Item("Medida"), rw.Item("IDArticulo"), rw.Item("Descripcion"), rw.Item("PrecioUnitario"), rw.Item("Descuento"), rw.Item("Itbis"), rw.Item("Importe"), rw.Item("RutaFoto"), ResizeImage(img, CInt(DTConfiguracion.Rows(179 - 1).Item("Value2Int"))), rw.Item("NivelPrecioArticulo"))

                            Else
                                TablaArticulos.Rows.Add(rw.Item("IDPrefactArt"), rw.Item("Cantidad"), rw.Item("Medida"), rw.Item("IDArticulo"), rw.Item("Descripcion"), rw.Item("PrecioUnitario"), rw.Item("Descuento"), rw.Item("Itbis"), rw.Item("Importe"), rw.Item("RutaFoto"), ResizeImage(My.Resources.No_Image, 25), rw.Item("NivelPrecioArticulo"))
                            End If

                        End If
                    Next

                End If
            End If


            SumarRowsGridArticulos()
            GridView2.BestFitColumns()

        End If



    End Sub

    Private Sub LStatus()
        If GridView1.RowCount = 0 Then
            lblStatusBar.Text = "No se encontraron registros."
        ElseIf GridView1.RowCount = 1 Then
            lblStatusBar.Text = "Se encontró un registro."
        ElseIf GridView1.RowCount > 1 Then
            lblStatusBar.Text = "Se encontraron: " & GridView1.RowCount & " registros."
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
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

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        RefrescarTabla()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Try

        If GridView1.RowCount = 0 Then
            MessageBox.Show("No hay ningún registro para realizar el cierre de prefacturas.", "No hay facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        ElseIf cantidadFilas > 1 Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            SelectedIDPrefacturaMultiple = ""
            If frm_eleccion_prefactura_multiple.Visible = True Then
                frm_eleccion_prefactura_multiple.Close()
            Else
                frm_eleccion_prefactura_multiple.ShowDialog(Me)
            End If


            If SelectedIDPrefacturaMultiple = "" Then
                MessageBox.Show("No se estableció el registro maestro de las informaciones generales de la prefactura a generar, por lo que el proceso ha sido cancelado.", "No origen de datos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else

                Dim DsTemp As New DataSet
                Dim ProductImage As Image

                ConMixPrefactura.Open()
                cmd = New MySqlCommand("SELECT IDPreFactura,Prefactura.SecondID,IDEquipo,Prefactura.IDTipoDocumento,Prefactura.IDCliente,NombreFactura,BalanceGeneral,IdentificacionFactura,DireccionFactura,TelefonosFactura,Prefactura.IDCondicion,Condicion.Condicion,Prefactura.IDSucursal,Prefactura.IDAlmacen,Prefactura.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,IDVendedor,Vendedor.Nombre,IDUsuario,Prefactura.Fecha,Prefactura.Hora,TotalNeto,Observacion,Cierre,Prefactura.NoOrden,Prefactura.Nulo,PreFactura.Usando,Prefactura.TipoPago,ifnull((Select Abonos.Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDCalificacion,Calificacion,Calificacion.ColorCalificacion,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.IDGrupoCXC,Clientes.LiberarControles,Prefactura.IDMoneda,TipoMoneda.Moneda,TipoMoneda.Texto FROM" & SysName.Text & "prefactura INNER JOIN Libregco.Condicion on Prefactura.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Prefactura.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.CLientes on Prefactura.IDCliente=Clientes.IDCLiente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.TipoMoneda on Prefactura.IDMoneda=TipoMoneda.IDTipoMoneda Where IDPrefactura= '" + SelectedIDPrefacturaMultiple + "'", ConMixPrefactura)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "PreFactura")
                ConMixPrefactura.Close()

                Dim Tabla As DataTable = DsTemp.Tables("PreFactura")

                If (Tabla.Rows(0).Item("Usando")) = 1 Then
                    MessageBox.Show("La prefactura " & Tabla.Rows(0).Item("SecondID") & " está siendo utilizada y/o procesada en este momento.", "Prefactura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If frm_facturacion.Visible = True Then
                    If frm_facturacion.Owner.Name = Me.Name Then
                        ConMixPrefactura.Open()
                        For Each itm As String In frm_facturacion.IDPrefactura
                            cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET Usando=0 WHERE IDPrefactura= (" + itm + ")", ConMixPrefactura)
                            cmd.ExecuteNonQuery()
                        Next
                        ConMixPrefactura.Close()
                        frm_facturacion.IDPrefactura.Clear()
                    End If
                    frm_facturacion.Close()
                End If

                ''''''''''''''''''''''''
                ConMixta.Open()
                For Each rt As DataRow In TablaPrefacturas.Rows
                    If rt.Item("Incluir") = True Then
                        cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET Usando=1 WHERE IDPreFactura='" + rt.Item("ID").ToString + "'", ConMixta)
                        cmd.ExecuteNonQuery()
                        frm_facturacion.IDPrefactura.Add(rt.Item("ID"))
                    End If
                Next
                ConMixta.Close()
                RefrescarTabla()
                '''''''''''''''''''''''''''''''''''''''''''''''''''

                frm_facturacion.Show(Me)
                frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
                frm_facturacion.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                frm_facturacion.txtNombre.Text = Tabla.Rows(0).Item("NombreFactura")
                frm_facturacion.txtRNC.Text = Tabla.Rows(0).Item("IdentificacionFactura")
                frm_facturacion.txtDireccion.Text = Tabla.Rows(0).Item("DireccionFactura")
                frm_facturacion.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonosFactura")
                frm_facturacion.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_facturacion.IDGrupoCXC = Tabla.Rows(0).Item("IDGrupoCxc")

                If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                    frm_facturacion.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."
                End If

                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                End If
                If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                    frm_facturacion.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                Else
                    frm_facturacion.txtUltimoMonto.Text = Tabla.Rows(0).Item("UltimoMontoPago")
                End If


                frm_facturacion.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")
                frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))

                If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                    frm_facturacion.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                    frm_facturacion.lblMensajeCalificacion.Visible = True
                Else
                    frm_facturacion.lblMensajeCalificacion.Visible = False
                End If

                frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                frm_facturacion.cbxCondicion.Text = Tabla.Rows(0).Item("Condicion")
                frm_facturacion.CbxTipoComprobante.Text = Tabla.Rows(0).Item("TipoComprobante")
                frm_facturacion.txtVendedor.Tag = Tabla.Rows(0).Item("IDVendedor")
                frm_facturacion.txtVendedor.Text = Tabla.Rows(0).Item("Nombre")
                frm_facturacion.txtCobrador.Text = Tabla.Rows(0).Item("Cobrador")
                frm_facturacion.txtCobrador.Tag = Tabla.Rows(0).Item("IDCobrador")
                frm_facturacion.txtObservacion.Text = Tabla.Rows(0).Item("Observacion")
                frm_facturacion.txtOrden.Text = Tabla.Rows(0).Item("NoOrden")
                frm_facturacion.IDTipopago = Tabla.Rows(0).Item("TipoPago")
                frm_facturacion.RefrescarBalances()
                frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
                frm_facturacion.NombreMoneda = Tabla.Rows(0).Item("Moneda")
                frm_facturacion.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")

                If TypeConnection.Text = 1 Then
                    If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                        frm_facturacion.PicImagen.Image = My.Resources.no_photo
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                            frm_facturacion.PicImagen.Image = Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

                'Liberando controles
                If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                    If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                        frm_facturacion.LiberarControles.Text = 1
                    End If
                End If


                frm_facturacion.dgvArticulosFactura.Rows.Clear()

                ConMixPrefactura.Open()

                For Each row As DataRow In TablaMultipleArticulos.Rows
                    DsTemp.Clear()
                    cmd = New MySqlCommand("Select IDPrefactArt,IDPrefactura,PrefacturaArticulos.IDPrecio,PrefacturaArticulos.IDMedida,Medida.Abreviatura,IDAlmacen,PrefacturaArticulos.Cantidad,PrefacturaArticulos.IDArticulo,PrefacturaArticulos.Descripcion,PrefacturaArticulos.PrecioUnitario,PrefacturaArticulos.Descuento,PrefacturaArticulos.Itbis,PrefacturaArticulos.Importe,NivelPrecioArticulo,Articulos.RutaFoto,Medida.Fraccionamiento FROM" & SysName.Text & "prefacturaarticulos INNER JOIN Libregco.PrecioArticulo on PrefacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where prefacturaarticulos.IDPrefactArt= '" + row.Item("IDPrefactArt").ToString + "'", ConMixPrefactura)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "prefacturaarticulos")

                    Dim TablaArticulos As DataTable = DsTemp.Tables("prefacturaarticulos")

                    If TypeConnection.Text = 1 Then
                        If TablaArticulos.Rows(0).Item("RutaFoto") = "" Then
                            ProductImage = My.Resources.No_Image
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(TablaArticulos.Rows(0).Item("RutaFoto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(TablaArticulos.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                ProductImage = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                ProductImage = My.Resources.No_Image
                            End If
                        End If
                    Else
                        ProductImage = My.Resources.No_Image
                    End If


                    frm_facturacion.dgvArticulosFactura.Rows.Add("", "", TablaArticulos.Rows(0).Item("IDPrecio"), TablaArticulos.Rows(0).Item("IDMedida"), TablaArticulos.Rows(0).Item("Cantidad"), TablaArticulos.Rows(0).Item("Abreviatura"), TablaArticulos.Rows(0).Item("IDArticulo"), row.Item("Descripcion"), CDbl(TablaArticulos.Rows(0).Item("PrecioUnitario")).ToString("C4"), CDbl(TablaArticulos.Rows(0).Item("Descuento")).ToString("C4"), CDbl(TablaArticulos.Rows(0).Item("Itbis")).ToString("C4"), CDbl(CDbl(CDbl(TablaArticulos.Rows(0).Item("PrecioUnitario")) + CDbl(TablaArticulos.Rows(0).Item("Itbis"))) * CDbl(TablaArticulos.Rows(0).Item("Cantidad"))).ToString("C4"), TablaArticulos.Rows(0).Item("IDAlmacen"), TablaArticulos.Rows(0).Item("NivelPrecioArticulo"), 0, TablaArticulos.Rows(0).Item("Fraccionamiento"), ResizeImage(ProductImage, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))))

                Next
                ConMixPrefactura.Close()

                frm_facturacion.SumTotales()
                frm_facturacion.CreatePagares()
                frm_facturacion.HabilitarEscCredito()
                frm_facturacion.BloquearModificacionPrefactura()
                frm_facturacion.Activate()
                frm_facturacion.Focus()



                Tabla.Dispose()
                DsTemp.Dispose()
            End If


        ElseIf GridView1.SelectedRowsCount > 0 Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsTemp, Dstemp1 As New DataSet
            Dim ProductImage As Image
            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPreFactura,Prefactura.SecondID,IDEquipo,Prefactura.IDTipoDocumento,Prefactura.IDCliente,NombreFactura,BalanceGeneral,IdentificacionFactura,DireccionFactura,TelefonosFactura,Prefactura.IDCondicion,Condicion.Condicion,Prefactura.IDSucursal,Prefactura.IDAlmacen,Prefactura.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,IDVendedor,Vendedor.Nombre,IDUsuario,Prefactura.Fecha,Prefactura.Hora,TotalNeto,Prefactura.Observacion,Prefactura.NoOrden,Cierre,Prefactura.Nulo,PreFactura.Usando,Prefactura.TipoPago,ifnull((Select Abonos.Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Abonos.Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDCalificacion,Calificacion,Calificacion.ColorCalificacion,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.IDGrupoCXC,Clientes.IDComprobanteFiscal as IDNCFClientes,ComprobanteFiscalCliente.TipoComprobante as TipoComprobanteCliente,Prefactura.IDMoneda,TipoMoneda.Moneda,TipoMoneda.Texto,Clientes.LiberarControles FROM" & SysName.Text & "prefactura INNER JOIN Libregco.Condicion on Prefactura.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Prefactura.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.CLientes on Prefactura.IDCliente=Clientes.IDCLiente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal AS ComprobanteFiscalCliente on Clientes.IDComprobanteFiscal=ComprobanteFiscalCliente.IDComprobanteFiscal INNER JOIN Libregco.TipoMoneda on Prefactura.IDMoneda=TipoMoneda.IDTipoMoneda Where IDPrefactura= '" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "PreFactura")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("PreFactura")

            If (Tabla.Rows(0).Item("Usando")) = 1 Then
                MessageBox.Show("La prefactura " & Tabla.Rows(0).Item("SecondID") & " está siendo utilizada y/o procesada en este momento.", "Prefactura en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If frm_facturacion.Visible = True Then
                If frm_facturacion.Owner.Name = Me.Name Then
                    ConMixPrefactura.Open()
                    For Each itm As String In frm_facturacion.IDPrefactura
                        cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET Usando=0 WHERE IDPrefactura= (" + itm + ")", ConMixPrefactura)
                        cmd.ExecuteNonQuery()
                    Next
                    ConMixPrefactura.Close()
                End If
                frm_facturacion.Close()
            End If

            frm_facturacion.IDPrefactura.Add(GridView1.GetFocusedRowCellValue("ID").ToString)

            ConMixta.Open()
            sqlQ = "UPDATE" & SysName.Text & "PreFactura SET Usando=1 WHERE IDPreFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

            frm_facturacion.Show(Me)
            frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
            frm_facturacion.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
            frm_facturacion.txtNombre.Text = Tabla.Rows(0).Item("NombreFactura")
            frm_facturacion.txtRNC.Text = Tabla.Rows(0).Item("IdentificacionFactura")
            frm_facturacion.txtDireccion.Text = Tabla.Rows(0).Item("DireccionFactura")
            frm_facturacion.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonosFactura")
            frm_facturacion.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_facturacion.IDGrupoCXC = Tabla.Rows(0).Item("IDGrupoCxc")


            If CInt(Tabla.Rows(0).Item("IDGrupocxc")) = 3 Then
                frm_facturacion.lblStatusBar.Text = "El cliente está excento de los ajustes y controles de facturación de grupos personales."
            End If

            If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
            Else
                frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            End If
            If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                frm_facturacion.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
            Else
                frm_facturacion.txtUltimoMonto.Text = Tabla.Rows(0).Item("UltimoMontoPago")
            End If
            frm_facturacion.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")
            frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
            frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            frm_facturacion.cbxCondicion.Text = Tabla.Rows(0).Item("Condicion")
            frm_facturacion.CbxTipoComprobante.Text = Tabla.Rows(0).Item("TipoComprobante")
            frm_facturacion.txtVendedor.Tag = Tabla.Rows(0).Item("IDVendedor")
            frm_facturacion.txtVendedor.Text = Tabla.Rows(0).Item("Nombre")
            frm_facturacion.txtCobrador.Tag = Tabla.Rows(0).Item("IDCobrador")
            frm_facturacion.txtCobrador.Text = Tabla.Rows(0).Item("Cobrador")
            frm_facturacion.IDTipopago = Tabla.Rows(0).Item("TipoPago")
            frm_facturacion.txtObservacion.Text = Tabla.Rows(0).Item("Observacion")
            frm_facturacion.txtOrden.Text = Tabla.Rows(0).Item("NoOrden")
            frm_facturacion.RefrescarBalances()
            frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
            frm_facturacion.NombreMoneda = Tabla.Rows(0).Item("Moneda")
            frm_facturacion.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")

            If TypeConnection.Text = 1 Then
                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    frm_facturacion.PicImagen.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        frm_facturacion.PicImagen.Image = Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            End If

            'Liberando controles
            If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                    frm_facturacion.LiberarControles.Text = 1
                End If
            End If


            Dstemp1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPrefactArt,IDPrefactura,PrefacturaArticulos.IDPrecio,PrefacturaArticulos.IDMedida,Medida.Abreviatura,IDAlmacen,PrefacturaArticulos.Cantidad,PrefacturaArticulos.IDArticulo,PrefacturaArticulos.Descripcion,PrefacturaArticulos.PrecioUnitario,PrefacturaArticulos.Descuento,PrefacturaArticulos.Itbis,PrefacturaArticulos.Importe,NivelPrecioArticulo,Articulos.RutaFoto,Medida.Fraccionamiento  FROM" & SysName.Text & "prefacturaarticulos  INNER JOIN Libregco.PrecioArticulo on PrefacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where prefacturaarticulos.IDPrefactura= '" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp1, "prefacturaarticulos")
            ConMixta.Close()

            Dim TablaArticulos As DataTable = Dstemp1.Tables("prefacturaarticulos")

            frm_facturacion.dgvArticulosFactura.Rows.Clear()

            For Each row As DataRow In TablaArticulos.Rows
                If TypeConnection.Text = 1 Then
                    If row.Item("RutaFoto") = "" Then
                        ProductImage = My.Resources.No_Image
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(row.Item("RutaFoto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(row.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            ProductImage = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            ProductImage = My.Resources.No_Image
                        End If
                    End If
                Else
                    ProductImage = My.Resources.No_Image
                End If


                frm_facturacion.dgvArticulosFactura.Rows.Add("", "", row.Item("IDPrecio"), row.Item("IDMedida"), row.Item("Cantidad"), row.Item("Abreviatura"), row.Item("IDArticulo"), row.Item("Descripcion"), CDbl(row.Item("PrecioUnitario")).ToString("C4"), CDbl(row.Item("Descuento")).ToString("C4"), CDbl(row.Item("Itbis")).ToString("C4"), CDbl(CDbl(CDbl(row.Item("PrecioUnitario")) + CDbl(row.Item("Itbis"))) * CDbl(row.Item("Cantidad"))).ToString("C4"), row.Item("IDAlmacen"), row.Item("NivelPrecioArticulo"), 0, row.Item("Fraccionamiento"), ResizeImage(ProductImage, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))))
            Next

            frm_facturacion.SumTotales()
            frm_facturacion.CreatePagares()
            frm_facturacion.HabilitarEscCredito()
            frm_facturacion.BloquearModificacionPrefactura()
            frm_facturacion.Activate()
            frm_facturacion.Focus()

            If Tabla.Rows(0).Item("IDCliente") <> 1 Then
                    If Tabla.Rows(0).Item("IDComprobanteFiscal") <> Tabla.Rows(0).Item("IDNCFClientes") Then
                        frm_alerta_tipocomprobante.lblComprobanteRecomendado.Tag = Tabla.Rows(0).Item("IDNCFClientes")
                        frm_alerta_tipocomprobante.lblComprobanteRecomendado.Text = Tabla.Rows(0).Item("TipoComprobanteCliente")
                        frm_alerta_tipocomprobante.lblComprobanteElegido.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
                        frm_alerta_tipocomprobante.lblComprobanteElegido.Text = Tabla.Rows(0).Item("TipoComprobante")
                        frm_alerta_tipocomprobante.ShowDialog(Me)
                    End If

                If Replace(Tabla.Rows(0).Item("IdentificacionFactura"), "-", "") <> "" Then
                    If Tabla.Rows(0).Item("IDComprobanteFiscal") = 2 Then
                        frm_alerta_tipocomprobante.lblComprobanteRecomendado.Tag = 1
                        frm_alerta_tipocomprobante.lblComprobanteRecomendado.Text = "Crédito Fiscal"
                        frm_alerta_tipocomprobante.lblComprobanteElegido.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
                        frm_alerta_tipocomprobante.lblComprobanteElegido.Text = Tabla.Rows(0).Item("TipoComprobante")
                        frm_alerta_tipocomprobante.ShowDialog(Me)
                    End If
                End If
            End If

                If CInt(Tabla.Rows(0).Item("IDComprobanteFiscal")) = 8 Then
                    frm_facturacion.DeterminarCambiadoItbis()
                End If


            If chkImpresionDirecta.Checked = True Then
                'Aqui va el procedimiento para la revision de los reportes seleccionados
                If CInt(DTConfiguracion.Rows(188 - 1).Item("Value2Int")) = 1 Then
                    ConTemporal.Open()
                    If GridView1.GetFocusedRowCellValue(GridView1.Columns("Condicion")).ToString.ToUpper.Contains("CONTADO") And LUEReportes.EditValue <> CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int")) Then
                        frm_alerta_reporte_cierre.lblReporteRecomendado.Tag = CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int"))
                        cmd = New MySqlCommand("Select Descripcion FROM" & SysName.Text & "Reportes where IDReportes= '" + CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int")) + "'", ConTemporal)
                        frm_alerta_reporte_cierre.lblReporteRecomendado.Text = Convert.ToString(cmd.ExecuteScalar())

                        cmd = New MySqlCommand("SELECT IDPaperName FROM" & SysName.Text & "Reportes where IDReportes= '" + CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int")) + "'", ConTemporal)
                        Dim PaperID As Int16 = Convert.ToString(cmd.ExecuteScalar())

                        If PaperID = 1 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.Letter
                        ElseIf PaperID = 2 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.HalfPage
                        ElseIf PaperID = 3 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.SalePoint
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        frm_alerta_reporte_cierre.lblReporteElegido.Tag = LUEReportes.GetColumnValue("IDReportes")
                        frm_alerta_reporte_cierre.lblReporteElegido.Text = LUEReportes.GetColumnValue("Descripcion")

                        If LUEReportes.GetColumnValue("idPaperSize") = 1 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.Letter
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 2 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.HalfPage
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 3 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.SalePoint
                        End If

                        frm_alerta_reporte_cierre.ShowDialog(Me)

                    ElseIf GridView1.GetFocusedRowCellValue(GridView1.Columns("Condicion")).ToString.ToUpper.Contains("CREDITO") Or GridView1.GetFocusedRowCellValue(GridView1.Columns("Condicion")).ToString.ToUpper.Contains("CRÉDITO") And LUEReportes.EditValue <> CInt(CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int"))) Then

                        frm_alerta_reporte_cierre.lblReporteRecomendado.Tag = CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int"))
                        cmd = New MySqlCommand("SELECT Descripcion FROM" & SysName.Text & "Reportes where IDReportes= '" + CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int")).ToString + "'", ConTemporal)
                        MessageBox.Show(cmd.CommandText)
                        frm_alerta_reporte_cierre.lblReporteRecomendado.Text = Convert.ToString(cmd.ExecuteScalar())

                        cmd = New MySqlCommand("SELECT IDPaperName FROM" & SysName.Text & "Reportes where IDReportes= '" + CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int")).ToString + "'", ConTemporal)
                        Dim PaperID As Int16 = Convert.ToString(cmd.ExecuteScalar())

                        If PaperID = 1 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.Letter
                        ElseIf PaperID = 2 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.HalfPage
                        ElseIf PaperID = 3 Then
                            frm_alerta_reporte_cierre.SimpleButton1.ImageOptions.Image = My.Resources.SalePoint
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        frm_alerta_reporte_cierre.lblReporteElegido.Tag = LUEReportes.GetColumnValue("IDReportes")
                        frm_alerta_reporte_cierre.lblReporteElegido.Text = LUEReportes.GetColumnValue("Descripcion")

                        If LUEReportes.GetColumnValue("idPaperSize") = 1 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.Letter
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 2 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.HalfPage
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 3 Then
                            frm_alerta_reporte_cierre.SimpleButton2.ImageOptions.Image = My.Resources.SalePoint
                        End If

                        frm_alerta_reporte_cierre.ShowDialog(Me)
                    End If

                    ConTemporal.Close()

                    If Not CbxInstalledPrinters.Text.Contains(LUEReportes.GetColumnValue("PrinterKey")) Then
                        frm_alerta_impresion.lblImpresoraRecomendado.Tag = LUEReportes.GetColumnValue("PrinterKey")
                        For Each itm As String In CbxInstalledPrinters.Items
                            If itm.Contains(LUEReportes.GetColumnValue("PrinterKey")) Then
                                frm_alerta_impresion.lblImpresoraRecomendado.Text = itm
                                Exit For
                            End If
                        Next

                        If LUEReportes.GetColumnValue("idPaperSize") = 1 Then
                            frm_alerta_impresion.SimpleButton1.ImageOptions.Image = My.Resources.Letter
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 2 Then
                            frm_alerta_impresion.SimpleButton1.ImageOptions.Image = My.Resources.HalfPage
                        ElseIf LUEReportes.GetColumnValue("idPaperSize") = 3 Then
                            frm_alerta_impresion.SimpleButton1.ImageOptions.Image = My.Resources.SalePoint
                        End If

                        frm_alerta_impresion.lblImpresoraElegida.Text = CbxInstalledPrinters.Text

                        frm_alerta_impresion.ShowDialog(Me)
                    End If
                End If
            End If

            Tabla.Dispose()
            TablaArticulos.Dispose()
            DsTemp.Dispose()
            Dstemp1.Dispose()
        End If

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub


    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Try

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If GridView1.RowCount = 0 Then
                MessageBox.Show("No hay una fila seleccionada para realizar la liberación de la prefactura.", "No hay prefacturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else

                If GridView1.SelectedRowsCount > 0 Then

                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la prefactura " & GridView1.GetFocusedRowCellValue("SecondID") & "?", "Anular prefactura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ControlSuperClave = 1
                        frm_facturacion_anulacion.ShowDialog(Me)
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If

                        sqlQ = "UPDATE PreFactura SET ClasificacionAnulacion='" + frm_facturacion_anulacion.cbxClasificacion.Text + "',MotivoAnulacion='" + frm_facturacion_anulacion.txtMotivos.Text + "',IDUsuarioAnulador='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',FechaAnulacion='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',Nulo=1 WHERE IDPrefactura= (" + GridView1.GetFocusedRowCellValue("ID") + ")"
                        GuardarDatos()
                        GridView1.DeleteRow(GridView1.FocusedRowHandle)
                        MessageBox.Show("Se ha anulado la prefactura satisfactoriamente.", "Prefactura anulada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        GridView1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub DgvFacturas_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGuardar.PerformClick()

        End If
    End Sub

    Private Sub frm_cierre_facturas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            If GridView1.RowCount > 0 Then
                If GridView1.SelectedRowsCount > 0 Then
                    btnGuardar.PerformClick()
                End If
            End If

        ElseIf e.KeyCode = Keys.F5 Then
            e.Handled = True
            btnActualizar.PerformClick()

        ElseIf e.KeyCode = Keys.F12 Then
            e.Handled = True
            Dim find As FindControl = TryCast(GridView1.GridControl.Controls.Find("FindControl", True)(0), FindControl)
            find.FindEdit.Focus()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.FocusedRowHandle >= 0 Then
            btnGuardar.PerformClick()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim it As Integer = GetLastInputTime()

        If LastLastIdletime > it Then
            CounterIdleTime = 0
        Else
            CounterIdleTime = GetLastInputTime()

            If CounterIdleTime > 1 Then
                RefrescarTabla()
            End If
        End If

        LastLastIdletime = it
    End Sub


    Private Sub chkImpresionDirecta_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpresionDirecta.CheckedChanged
        If chkImpresionDirecta.Checked = True Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub LiberarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiberarToolStripMenuItem.Click
        Try
            If TablaPrefacturas.Rows.Count > 0 Then
                Dim DsTemp As New DataSet

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Prefactura.SecondID,PreFactura.Usando FROM" & SysName.Text & "prefactura Where IDPrefactura= '" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "PreFactura")
                ConMixta.Close()
                Dim Tabla As DataTable = DsTemp.Tables("PreFactura")

                If (Tabla.Rows(0).Item("Usando")) = 1 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("La prefactura " & Tabla.Rows(0).Item("SecondID") & " está siendo utilizada y/o procesada en este momento." & vbNewLine & vbNewLine & "Está seguro que desea liberar la factura?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        sqlQ = "UPDATE PreFactura SET Usando=0  WHERE IDPrefactura= (" + GridView1.GetFocusedRowCellValue("ID").ToString + ")"
                        GuardarDatos()
                        Dim myRow() As DataRow = TablaPrefacturas.Select("ID = '" + GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                        myRow(0)("Usando") = 0
                    End If
                End If

                Tabla.Dispose()
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Try
        Dim iterateIndex As Integer = 0
        Dim newDataTable As DataTable = TablaPrefacturas.Copy
        lblStatusBar.Text = newDataTable.Rows.Count

        For Each row As DataRow In newDataTable.Rows
            Dim Datez As DateTime = row.Item("Vencimiento")
            Dim SpanDt As TimeSpan = Datez - Now


            If Datez < Now Then
                Dim myRow() As DataRow = TablaPrefacturas.Select("ID = '" + row.Item("ID").ToString + "'")
                myRow(0)("VidaUtil") = "Vencido"
                sqlQ = "UPDATE PreFactura SET Nulo=1 WHERE IDPrefactura= (" + row.Item("ID").ToString + ")"
                GuardarDatos()
                TablaPrefacturas.Rows.RemoveAt(iterateIndex)
            Else
                iterateIndex += 1
                Dim myRow() As DataRow = TablaPrefacturas.Select("ID = '" + row.Item("ID").ToString + "'")
                myRow(0)("VidaUtil") = String.Format("{0} días, {1} horas, {2} minutos, {3} segundos", SpanDt.Days, SpanDt.Hours, SpanDt.Minutes, SpanDt.Seconds)
            End If

        Next

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.SelectedRowsCount > 0 Then
                If e.KeyCode = Keys.Enter Then
                    btnGuardar.PerformClick()
                End If
            End If
        End If
    End Sub


    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle
        e.Appearance.BackColor = SystemColors.Info
        e.Appearance.BackColor2 = Color.PaleGoldenrod
        e.HighPriority = True
    End Sub


    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
            Dim currentView As GridView = TryCast(sender, GridView)
            If e.Column.FieldName = "FormaPago" Then
                If currentView.GetRowCellValue(e.RowHandle, "FormaPago") = "Sólo Efectivo" Then
                    e.Appearance.BackColor = Color.ForestGreen
                    e.Appearance.ForeColor = Color.White
                ElseIf currentView.GetRowCellValue(e.RowHandle, "FormaPago") = "Tarjeta" Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.ForeColor = Color.Black
                ElseIf currentView.GetRowCellValue(e.RowHandle, "FormaPago") = "Pago Mixto" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.ForeColor = Color.White
                End If
            End If

        End If
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                If Me.Owner.Name = frm_inicio.Name Then

                    If GridView1.FocusedColumn.FieldName = "SecondID" Then
                        btnGuardar.PerformClick()
                    End If
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillReportes()
        'Try
        'Dim DsTemp As New DataSet

        'Con.Open()
        'cmd = New MySqlCommand("SELECT IDReportes,Descripcion,PrinterKey FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Facturación' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
        'Adaptador = New MySqlDataAdapter(cmd)
        'Adaptador.Fill(DsTemp, "Reportes")
        'CbxFormato.Items.Clear()
        'Con.Close()

        'CbxFormato.DisplayMember = "Descripcion"
        'CbxFormato.ValueMember = "IDReportes"
        'CbxFormato.DataSource = DsTemp.Tables("Reportes")

        'If DsTemp.Tables("Reportes").Rows.Count > 0 Then
        '    CbxFormato.SelectedIndex = 0
        'Else
        '    MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
        'End If

        Dim DsTemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT IDReportes,Descripcion,PrinterKey,Reporte,Path,ModoDuplicado,idPaperSize FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Facturación' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Reportes")
        LUEReportes.Properties.DataSource = Nothing
        Con.Close()

        LUEReportes.Properties.DataSource = DsTemp.Tables("Reportes")
        LUEReportes.Properties.DisplayMember = "Descripcion"
        LUEReportes.Properties.ValueMember = "IDReportes"
        LUEReportes.Properties.PopulateColumns()
        LUEReportes.Properties.Columns(LUEReportes.Properties.ValueMember).Visible = False
        LUEReportes.Properties.Columns(LUEReportes.Properties.DisplayMember).Caption = "Reportes disponibles"
        LUEReportes.Properties.Columns(2).Visible = False
        LUEReportes.Properties.Columns(3).Visible = False
        LUEReportes.Properties.Columns(4).Visible = False
        LUEReportes.Properties.Columns(5).Visible = False
        LUEReportes.Properties.Columns(6).Visible = False

        If DsTemp.Tables("Reportes").Rows.Count > 0 Then
            LUEReportes.ItemIndex = 0
        Else
            MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    'Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
    '    Dim DsTemp As New DataSet

    '    DsTemp.Clear()
    '    Con.Open()
    '    cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
    '    Adaptador = New MySqlDataAdapter(cmd)
    '    Adaptador.Fill(DsTemp, "Reportes")
    '    Con.Close()

    '    Dim Tabla As DataTable = DsTemp.Tables("Reportes")

    '    IDReport = (Tabla.Rows(0).Item("IDReportes"))
    '    NameReport = (Tabla.Rows(0).Item("Reporte"))
    '    FilePathReport = (Tabla.Rows(0).Item("Path"))
    '    ModoDuplicado = Tabla.Rows(0).Item("ModoDuplicado")


    '    Tabla.Dispose()
    '    DsTemp.Dispose()

    'End Sub

    Private Sub frm_cierre_facturas_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        GridView1.Focus()
        VerificacionRepPredefinido()
        BuscarArticulosPrefactura()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("Usando")) = "1" Then
                e.Appearance.BackColor = Color.LightGreen
                e.Appearance.BackColor2 = Color.MediumPurple
                e.HighPriority = True

            Else
                If View.GetRowCellValue(e.RowHandle, View.Columns("Incluir")) = True Then
                    e.Appearance.BackColor = SystemColors.Info
                    e.Appearance.BackColor2 = Color.PaleGoldenrod
                    e.HighPriority = True
                End If
            End If
        End If

    End Sub

    Private Sub VerificacionRepPredefinido()
        Try

            If GridView1.FocusedRowHandle >= 0 Then
                If CInt(DTConfiguracion.Rows(188 - 1).Item("Value2Int")) = 1 Then
                    If GridView1.GetFocusedRowCellValue(GridView1.Columns("Condicion")).ToString = "Contado" Or GridView1.GetFocusedRowCellValue(GridView1.Columns("Condicion")).ToString = "CONTADO" Then
                        LUEReportes.EditValue = CInt(DTConfiguracion.Rows(189 - 1).Item("Value2Int"))
                    Else
                        LUEReportes.EditValue = CInt(DTConfiguracion.Rows(190 - 1).Item("Value2Int"))
                    End If

                    For Each itm As String In CbxInstalledPrinters.Items
                        If itm.Contains(LUEReportes.GetColumnValue("PrinterKey")) Then
                            CbxInstalledPrinters.Text = itm
                            Exit For
                        End If
                    Next
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Se ha intentado seleccionar un reporte predefinido desde la configuración. Sin embargo, el reporte predefinido no se encuentra entre las opciones de los reportes disponibles. Por favor visite los ajustes de la empresa, en la configuración de [Facturación] y verifique el apartado de reportes predefinidos." & vbNewLine & ex.Message.ToString)
        End Try
    End Sub


End Class