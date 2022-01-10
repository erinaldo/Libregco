Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Bitmap
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.Utils.DragDrop

Public Class frm_registro_compras

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    'Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblDiasCondicion, lblIDPrecio, lblIDAlmacenArticulo, lblItbisArticulo, lblMarca, lblCheckDuplicates, lblDescuento2, lblDetalleCompra, Fraccionamiento, RutaDocumento, IDOrdenCompra, lblTipoItbis, lblRNC As New Label
    Friend DefaultCondicion, ImponerEscrituradeNCF As String
    Dim Permisos, PermisosAjustes, PermisosArticulos, PermisosEtiquetas As New ArrayList
    Friend AccionesModulosAutorizadas As New ArrayList
    Friend ProductImage As Image
    Private MailRegex As New Regex("^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$", RegexOptions.Compiled)

    Friend TablaCompras As DataTable
    Dim RepositoryImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}
    Dim RepositoryIDArticulo As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescripcion As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryChkFraccionamiento As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkActualizarCosto As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0", .CheckStyle = XtraEditors.Controls.CheckStyles.Standard, .DisplayValueChecked = True, .DisplayValueUnchecked = False}
    Dim RepositoryAlmacen As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryCantidad As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "1", .MaxValue = "1000000"}

    Dim RepositoryPrecioUnitario As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryDescuento1 As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryDescuento2 As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbis As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryImporte As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryCostoFinalUnitario As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryImporteTotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryItbisTotal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

    Private Sub frm_registro_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        SetComprasTable()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub SetComprasTable()
        TablaCompras = New DataTable("Compras")
        FillRepAlmacen()

        TablaCompras.Columns.Add("IDDetalleCompra", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDCompra", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaCompras.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("IDMedida", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("PrecioUnitario", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("Descuento2", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("Importe", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("CostoFinalUnitario", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("ImporteTotal", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("IDAlmacen", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Fraccionamiento", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("ActualizarCostos", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("ItbisTotal", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("Subtotal", System.Type.GetType("System.Double"))
        TablaCompras.Columns.Add("E/C", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("E/V", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaCompras.Columns.Add("Marca", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaCompras
        SetUpGrid(GridControl1, TablaCompras)

        RepositoryPrecioUnitario.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPrecioUnitario.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryPrecioUnitario.Mask.UseMaskAsDisplayFormat = True
        RepositoryPrecioUnitario.NullText = CDbl(0).ToString("C")
        RepositoryPrecioUnitario.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryDescuento1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryDescuento1.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryDescuento1.Mask.UseMaskAsDisplayFormat = True
        RepositoryDescuento1.NullText = CDbl(0).ToString("C")
        RepositoryDescuento1.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryDescuento2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryDescuento2.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryDescuento2.Mask.UseMaskAsDisplayFormat = True
        RepositoryDescuento2.NullText = CDbl(0).ToString("C")
        RepositoryDescuento2.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbis.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbis.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryItbis.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbis.NullText = CDbl(0).ToString("C")
        RepositoryItbis.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryImporte.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryImporte.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryImporte.Mask.UseMaskAsDisplayFormat = True
        RepositoryImporte.NullText = CDbl(0).ToString("C")
        RepositoryImporte.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryCostoFinalUnitario.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCostoFinalUnitario.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryCostoFinalUnitario.Mask.UseMaskAsDisplayFormat = True
        RepositoryCostoFinalUnitario.NullText = CDbl(0).ToString("C")
        RepositoryCostoFinalUnitario.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryImporteTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryImporteTotal.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryImporteTotal.Mask.UseMaskAsDisplayFormat = True
        RepositoryImporteTotal.NullText = CDbl(0).ToString("C")
        RepositoryImporteTotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryItbisTotal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryItbisTotal.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryItbisTotal.Mask.UseMaskAsDisplayFormat = True
        RepositoryItbisTotal.NullText = CDbl(0).ToString("C")
        RepositoryItbisTotal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryCantidad.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
        RepositoryCantidad.Properties.Mask.MaskType = XtraEditors.Mask.MaskType.Numeric
        RepositoryCantidad.Properties.NullText = 1
        RepositoryCantidad.Properties.AllowNullInput = DefaultBoolean.False
        RepositoryCantidad.Properties.NullValuePromptShowForEmptyValue = 1


        With GridView1
            .Columns("Imagen").ColumnEdit = RepositoryImagen
            .Columns("IDArticulo").ColumnEdit = RepositoryIDArticulo
            .Columns("Cantidad").ColumnEdit = RepositoryCantidad
            .Columns("Cantidad").OptionsColumn.AllowEdit = True
            .Columns("Cantidad").OptionsColumn.ReadOnly = False
            .Columns("Descripcion").ColumnEdit = RepositoryDescripcion
            .Columns("PrecioUnitario").ColumnEdit = RepositoryPrecioUnitario
            .Columns("Descuento").ColumnEdit = RepositoryDescuento1
            .Columns("Descuento2").ColumnEdit = RepositoryDescuento2
            .Columns("Itbis").ColumnEdit = RepositoryItbis
            .Columns("Importe").ColumnEdit = RepositoryImporte
            .Columns("CostoFinalUnitario").ColumnEdit = RepositoryCostoFinalUnitario
            .Columns("ImporteTotal").ColumnEdit = RepositoryImporteTotal
            .Columns("ItbisTotal").ColumnEdit = RepositoryItbisTotal
            .Columns("Fraccionamiento").ColumnEdit = RepositoryChkFraccionamiento
            .Columns("ActualizarCostos").ColumnEdit = RepositoryChkActualizarCosto
            .Columns("IDAlmacen").ColumnEdit = RepositoryAlmacen
            .Columns("IDDetalleCompra").Visible = False
            .Columns("IDCompra").Visible = False

            If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
                If chkPreviewImages.Checked = True Then
                    .Columns("Imagen").Width = 100
                    .Columns("Imagen").Visible = True
                    .Columns("Descripcion").Width = 350
                Else
                    .Columns("Imagen").Width = 100
                    .Columns("Imagen").Visible = False
                    .Columns("Descripcion").Width = 450
                End If
            Else
                .Columns("Imagen").Width = 100
                .Columns("Imagen").Visible = False
                .Columns("Descripcion").Width = 450
            End If

            .Columns("Imagen").Width = 60
            .Columns("IDArticulo").Caption = "Código"
            .Columns("IDArticulo").Width = 80
            .Columns("IDArticulo").Summary.Add(DevExpress.Data.SummaryItemType.Count, "IDArticulo", "Items: {0}")
            .Columns("Descripcion").Caption = "Descripción"
            .Columns("Descripcion").Width = 390
            .Columns("Descripcion").OptionsColumn.AllowEdit = False
            .Columns("Descripcion").OptionsColumn.ReadOnly = True
            .Columns("Cantidad").OptionsColumn.AllowEdit = True
            .Columns("Cantidad").OptionsColumn.ReadOnly = False
            .Columns("Cantidad").Width = 75
            .Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0}")
            .Columns("Medida").Width = 85
            .Columns("Medida").OptionsColumn.AllowEdit = False
            .Columns("Medida").OptionsColumn.ReadOnly = True
            .Columns("IDPrecio").Visible = False
            .Columns("IDMedida").Visible = False
            .Columns("PrecioUnitario").Width = 85
            .Columns("PrecioUnitario").OptionsColumn.AllowEdit = False
            .Columns("PrecioUnitario").OptionsColumn.ReadOnly = True
            .Columns("PrecioUnitario").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("PrecioUnitario").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("PrecioUnitario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PrecioUnitario", "{0:c2}")
            .Columns("Descuento").Visible = False
            .Columns("Descuento").Width = 85
            .Columns("Descuento").OptionsColumn.AllowEdit = False
            .Columns("Descuento").OptionsColumn.ReadOnly = True
            .Columns("Descuento").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("Descuento").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("Descuento").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Descuento", "{0:c2}")
            .Columns("Descuento2").Width = 85
            .Columns("Descuento2").OptionsColumn.AllowEdit = False
            .Columns("Descuento2").OptionsColumn.ReadOnly = True
            .Columns("Descuento2").Visible = False
            .Columns("Descuento2").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("Descuento2").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("Descuento2").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Descuento2", "{0:c2}")
            .Columns("Itbis").Width = 80
            .Columns("Itbis").OptionsColumn.AllowEdit = False
            .Columns("Itbis").OptionsColumn.ReadOnly = True
            .Columns("Itbis").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("Itbis").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("Itbis").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Itbis", "{0:c2}")
            .Columns("Importe").Width = 90
            .Columns("Importe").Caption = "Importe Unit."
            .Columns("Importe").OptionsColumn.AllowEdit = False
            .Columns("Importe").OptionsColumn.ReadOnly = True
            .Columns("Importe").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("Importe").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")
            .Columns("CostoFinalUnitario").Width = 100
            .Columns("CostoFinalUnitario").Caption = "Costo final unit."
            .Columns("CostoFinalUnitario").Visible = False
            .Columns("CostoFinalUnitario").OptionsColumn.AllowEdit = False
            .Columns("CostoFinalUnitario").OptionsColumn.ReadOnly = True
            .Columns("CostoFinalUnitario").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("CostoFinalUnitario").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("CostoFinalUnitario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CostoFinalUnitario", "{0:c2}")
            .Columns("ImporteTotal").Width = 100
            .Columns("ImporteTotal").OptionsColumn.AllowEdit = False
            .Columns("ImporteTotal").OptionsColumn.ReadOnly = True
            .Columns("ImporteTotal").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("ImporteTotal").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("ImporteTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ImporteTotal", "{0:c2}")
            .Columns("ItbisTotal").Width = 100
            .Columns("ItbisTotal").Visible = False
            .Columns("ItbisTotal").OptionsColumn.AllowEdit = False
            .Columns("ItbisTotal").OptionsColumn.ReadOnly = True
            .Columns("ItbisTotal").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("ItbisTotal").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("ItbisTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ItbisTotal", "{0:c2}")
            .Columns("Subtotal").Visible = False
            .Columns("Subtotal").Width = 100
            .Columns("Subtotal").OptionsColumn.AllowEdit = False
            .Columns("Subtotal").OptionsColumn.ReadOnly = True
            .Columns("Subtotal").DisplayFormat.FormatType = FormatType.Numeric
            .Columns("Subtotal").DisplayFormat.FormatString = "C" & txtCantDecimales.Value
            .Columns("Subtotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Subtotal", "{0:c2}")
            .Columns("Fraccionamiento").Visible = False
            .Columns("ActualizarCostos").Visible = True
            .Columns("ActualizarCostos").Caption = "Act. Costos"
            .Columns("ActualizarCostos").Width = 80
            .Columns("ActualizarCostos").OptionsColumn.AllowEdit = True
            .Columns("ActualizarCostos").OptionsColumn.ReadOnly = False
            .Columns("IDAlmacen").Width = 100
            .Columns("IDAlmacen").Caption = "Almacén"
            .Columns("E/C").Width = 200
            .Columns("E/V").Width = 200
            .Columns("E/C").OptionsColumn.AllowEdit = False
            .Columns("E/C").OptionsColumn.ReadOnly = True
            .Columns("E/V").OptionsColumn.AllowEdit = False
            .Columns("E/V").OptionsColumn.ReadOnly = True
            .Columns("Referencia").OptionsColumn.AllowEdit = False
            .Columns("Referencia").OptionsColumn.ReadOnly = True
            .Columns("Marca").OptionsColumn.AllowEdit = False
            .Columns("Marca").OptionsColumn.ReadOnly = True
            .Columns("Referencia").Visible = False
            .Columns("Referencia").OptionsColumn.ReadOnly = True
            .Columns("Marca").Visible = False
            .Columns("Marca").OptionsColumn.ReadOnly = True
        End With


    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub


    Private Sub FillRepAlmacen()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen,Almacen from Libregco.Almacen", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Almacen")
        ConLibregco.Close()

        Dim TablaAlmacen As DataTable = dstemp.Tables("Almacen")
        RepositoryAlmacen.DataSource = TablaAlmacen
        RepositoryAlmacen.ValueMember = "IDAlmacen"
        RepositoryAlmacen.DisplayMember = "Almacen"
        RepositoryAlmacen.PopulateColumns()
        RepositoryAlmacen.Columns(0).Visible = False
    End Sub

    Private Sub SetConfiguracion()
        Try
            ConMixta.Open()

            'Condicion Predeterminada
            cmd = New MySqlCommand("Select Condicion from" & SysName.Text & "Configuracion INNER JOIN Libregco.Condicion on Configuracion.Value2Int=Condicion.IDCondicion Where IDConfiguracion=59", ConMixta)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            ''TipoComprobante
            'TypeOfMetod = DTConfiguracion.Rows(75 - 1).Item("Value2Int")

            'Hacer revisión de subtotales durante el registro de compras
            'VerificarSubtotales = DTConfiguracion.Rows(164 - 1).Item("Value2Int")

            'Cantidad de decimales
            txtCantDecimales.Value = DTConfiguracion.Rows(168 - 1).Item("Value2Int")

            'Permitir duplicados
            'PermitirDuplicados = DTConfiguracion.Rows(169 - 1).Item("Value2Int")

            'Altura de las imágenes de compras
            'PictureHeight = DTConfiguracion.Rows(180 - 1).Item("Value2Int")

            'Cargar monedas
            Dim ds As New DataSet
            LueMoneda.Properties.Items.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "tipomoneda")
            ConLibregco.Close()

            For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                nvmoneda.Description = Fila.Item("Texto")
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                LueMoneda.Properties.Items.Add(nvmoneda)
            Next
            ds.Dispose()

            'Moneda predeterminada
            'DefaultCurrency.Text = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
            ConMixta.Close()

            PermisosArticulos = PasarPermisos(3)
            If PermisosArticulos(0) = 0 Then
                IrAArtículosToolStripMenuItem.Enabled = False
                btnActualizarDescripcion.Visible = False
                AnexarImagenToolStripMenuItem.Enabled = False
                MantenimientoDeArtículosToolStripMenuItem.Enabled = False
                ToolStripButton1.Enabled = False
            Else
                IrAArtículosToolStripMenuItem.Enabled = True
                AnexarImagenToolStripMenuItem.Enabled = True
                MantenimientoDeArtículosToolStripMenuItem.Enabled = True
                ToolStripButton1.Enabled = True
            End If


            PermisosEtiquetas = PasarPermisos(29)
            If PermisosEtiquetas(0) = 0 Then
                ImpresiónDeEtiquetasToolStripMenuItem.Enabled = False
            Else
                ImpresiónDeEtiquetasToolStripMenuItem.Enabled = True
            End If


            PermisosAjustes = PasarPermisos(17)
            If PermisosAjustes(0) = 0 Then
                GenerarAjusteDeInventarioToolStripMenuItem.Enabled = False
            Else
                GenerarAjusteDeInventarioToolStripMenuItem.Enabled = True
            End If

            chkPreviewImages.Checked = frm_inicio.chkPreviewMode.CheckState

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkPreviewImages_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreviewImages.CheckedChanged
        If chkPreviewImages.Checked = True Then
            GridView1.Columns("Imagen").Width = 100
            GridView1.Columns("Imagen").Visible = True
            GridView1.Columns("Imagen").VisibleIndex = 0
            GridView1.Columns("Descripcion").Width = 350
        Else
            GridView1.Columns("Imagen").Width = 100
            GridView1.Columns("Imagen").Visible = False
            GridView1.Columns("Descripcion").Width = 450
        End If
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        XtraTabControl1.SelectedTabPageIndex = 0
        XtraTabControl2.SelectedTabPageIndex = 0
        lblDetalleCompra.Text = ""
        ControlSuperClave = 0
        txtPrecio.Properties.Precision = txtCantDecimales.Value
        lblCheckDuplicates.Text = 0
        ChkNulo.Checked = False
        btnActualizarDescripcion.Visible = False
        chkpreciosdiferidos.Checked = False
        chkcreditospendientes.Checked = False
        chkArtfuerapedido.Checked = False
        chkrenegociarflete.Checked = False
        chkAveriados.Checked = False
        chkDescuentoPago.Checked = False
        chkActualizarCosto.Checked = True
        btnModificar.Enabled = True
        txtTasa.Text = 1
        txtSubTotal.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtFlete.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtNeto.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtDescuento.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtPorDescuento2.Text = CDbl(0).ToString("P")
        txtDescuento2.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtItbis.Text = CDbl(0.0).ToString("C" & txtCantDecimales.Value)
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkEnviarReporte.Checked = False
        chkEnviarCopiaDigital.Checked = False
        btnActualizarDescripcion.Text = "Actualizar"
        lblStatusBar.Text = "Listo"
        lblStatusBar.ForeColor = Color.Black
        txtDescripcionArticulo.Enabled = False
        VerificarSubtotalesToolStripMenuItem.Visible = False
        MostrarControlSubTotales()
        rdbNoItbis.Visible = True
        PreciosDinámicosToolStripMenuItem.Visible = False
        LueMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        DtpFechaFact.Value = Today
        DtpVencimiento.Value = Today
        DtpDiaRecibido.Value = Today
        DtpDiaRecibido.Value = Today
        FillComprobanteFiscal()
        FillAlmacen()
        FillCondicion()
        FillGastos()
        HabilitarEnvioDatos()
        FillCorreos()
    End Sub

    Private Sub FillCorreos()
        Try

            edtTo.Properties.Tokens.Clear()
            edtTo.EditValue = Nothing

            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("Select CorreoElectronico FROM empleados where correoelectronico<>'' and Nulo=0 group by correoelectronico", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Correo")
            Con.Close()

            For Each Fila As DataRow In ds.Tables("Correo").Rows
                edtTo.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken(Fila.Item("CorreoElectronico")))
            Next

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillAlmacen()
        Try
            Dim dstemp As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT IDAlmacen,Almacen FROM Almacen Where IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "' and Desactivar=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Almacen")
            LUEAlmacen.Properties.DataSource = Nothing
            Con.Close()

            Dim Tabla As DataTable = dstemp.Tables("Almacen")
            LUEAlmacen.Properties.DataSource = Tabla
            LUEAlmacen.Properties.ValueMember = "IDAlmacen"
            LUEAlmacen.Properties.DisplayMember = "Almacen"

            LUEAlmacen.Properties.PopulateColumns()
            LUEAlmacen.Properties.Columns(LUEAlmacen.Properties.ValueMember).Visible = False

            If Tabla.Rows.Count > 0 Then
                LUEAlmacen.ItemIndex = 0
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillGastos()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGasto,TipoGasto FROM libregco.tipogasto where Nulo=0 ORDER BY IDGASTO ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "TipoGasto")
        LUEGasto.Properties.DataSource = Nothing
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("TipoGasto")
        LUEGasto.Properties.DataSource = Tabla
        LUEGasto.Properties.ValueMember = "IDGasto"
        LUEGasto.Properties.DisplayMember = "TipoGasto"

        LUEGasto.Properties.PopulateColumns()
        LUEGasto.Properties.Columns(LUEGasto.Properties.ValueMember).Visible = False
        LUEGasto.Properties.Columns(LUEGasto.Properties.DisplayMember).Caption = "Gasto"

        If Tabla.Rows.Count > 0 Then
            LUEGasto.ItemIndex = 0
        End If
    End Sub

    Private Sub FillComprobanteFiscal()
        Try
            Dim ds As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM comprobantefiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "ComprobanteFiscal")
            CbxTipoComprobante.Items.Clear()
            Con.Close()


            For Each Fila As DataRow In ds.Tables("ComprobanteFiscal").Rows
                CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillCondicion()
        Try
            Dim ds As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Libregco.Condicion Where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            For Each Fila As DataRow In ds.Tables("Condicion").Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next
            If ds.Tables("Condicion").Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        SetIDCondicion()

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Dias FROM Libregco.Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If lblDiasCondicion.Text = 0 Then
            DtpVencimiento.Value = DtpFechaFact.Value
            DtpVencimiento.Enabled = False
        Else

            DtpVencimiento.Enabled = True

            If CDbl(lblDiasCondicion.Text) > 998 Then
                DtpVencimiento.Value = DtpFechaFact.Value.AddDays(30)
            Else
                DtpVencimiento.Value = DtpFechaFact.Value.AddDays(lblDiasCondicion.Text)
            End If

        End If
    End Sub

    Private Sub SetIDCondicion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Libregco.Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        SetIDComprobante()
    End Sub

    Private Sub SetIDComprobante()
        Dim ds As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * from" & SysName.Text & "ComprobanteFiscal Where TipoComprobante='" + CbxTipoComprobante.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Comprobantes")
        ConMixta.Close()

        CbxTipoComprobante.Tag = ds.Tables("Comprobantes").Rows(0).Item("IDComprobanteFiscal")
        ImponerEscrituradeNCF = ds.Tables("Comprobantes").Rows(0).Item("ImposicionCompra")

        'If txtIDCompra.Text = "" Then
        If ImponerEscrituradeNCF = 1 Then
            If DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 1 Then
                txtNCF.Mask = ds.Tables("Comprobantes").Rows(0).Item("Serie") & "000000000000000000"
                txtNCF.Text = ds.Tables("Comprobantes").Rows(0).Item("Serie") & ds.Tables("Comprobantes").Rows(0).Item("NoTCF")
            ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 2 Then
                txtNCF.Mask = ds.Tables("Comprobantes").Rows(0).Item("Serie") & "000000000000000000"
                txtNCF.Text = ds.Tables("Comprobantes").Rows(0).Item("Serie") & ds.Tables("Comprobantes").Rows(0).Item("NoTCF")
            ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 3 Then
                txtNCF.Mask = ds.Tables("Comprobantes").Rows(0).Item("Serie") & ds.Tables("Comprobantes").Rows(0).Item("NoTCF") & CDbl(0).ToString.PadLeft(ds.Tables("Comprobantes").Rows(0).Item("Longitud"), "0")
                txtNCF.Text = ds.Tables("Comprobantes").Rows(0).Item("Serie") & ds.Tables("Comprobantes").Rows(0).Item("NoTCF")
            End If
        Else
            If DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 1 Then
                txtNCF.Mask = ""
                txtNCF.Text = ""
            ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 2 Then
                txtNCF.Mask = ""
                txtNCF.Text = ""
            ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 3 Then
                txtNCF.Mask = ""
                txtNCF.Text = ""
            End If
        End If

        'Else
        '    txtNCF.Mask = ""
        'End If

        ds.Dispose()

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("hh:mm:ss tt")
    End Sub

    Private Sub SelectUsuario()
        Try

            GbxUserInfo.Text = "User Info --> " & frm_inicio.Button3.Text & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString() & "]"

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDCompra.Clear()
        txtSecondID.Clear()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        lblRNC.Text = ""
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        txtNoFact.Clear()
        txtReferencia.Clear()
        txtRecepcion.Tag = ""
        txtRecepcion.Text = ""
        txtNCF.Clear()
        txtNotaCompra.Clear()
        cbxCondicion.Items.Clear()
        CbxTipoComprobante.Items.Clear()
        LimpiarTextInsert()
        chkpreciosdiferidos.Tag = 0
        chkcreditospendientes.Tag = 0
        chkArtfuerapedido.Tag = 0
        chkrenegociarflete.Tag = 0
        chkAveriados.Tag = 0
        chkDescuentoPago.Tag = 0
        lblIDPrecio.Text = ""
        lblTipoItbis.Text = ""
        RutaDocumento.Text = ""
        IDOrdenCompra.Text = ""
        AccionesModulosAutorizadas.Clear()
        TablaCompras.Rows.Clear()
        ChkNulo.Checked = False
        rdbIncluido.Checked = True
        ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
        btnBuscarSup.Focus()
    End Sub

    Private Sub ImporteTotalUnitario()
        Try
            If CDbl(txtCantidadArticulo.Text) > 0 And CDbl(txtPrecio.Text) > 0 Then
                If rdbIncluido.Checked = True Then
                    Dim PrecioUnitarioSinItbis As Double = (CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text)))
                    Dim DescuentoAplicado As Double = ((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                    Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * (CDbl(Replace(txtPorDescuento2.Text, "%", "")) / 100)
                    Dim ItbisCalculado As Double = (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2) * (CDbl(lblItbisArticulo.Text))


                    txtImporteTotal.Text = CDbl(CDbl(PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * CDbl(txtCantidadArticulo.Text)).ToString("C")

                ElseIf rdbNoIncluido.Checked = True Then
                    Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                    Dim DescuentoAplicado As Double = (CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                    Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * (CDbl(Replace(txtPorDescuento2.Text, "%", "")) / 100)
                    Dim ItbisCalculado As Double = (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2) * (CDbl(lblItbisArticulo.Text))

                    txtImporteTotal.Text = CDbl(CDbl(PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * CDbl(txtCantidadArticulo.Text)).ToString("C")

                ElseIf rdbNoItbis.Checked = True Then
                    Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                    Dim DescuentoAplicado As Double = (CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                    Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * (CDbl(Replace(txtPorDescuento2.Text, "%", "")) / 100)
                    Dim ItbisCalculado As Double = 0

                    txtImporteTotal.Text = CDbl(CDbl(PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * CDbl(txtCantidadArticulo.Text)).ToString("C")
                End If
            End If


        Catch ex As Exception

            txtImporteTotal.Text = CDbl(0).ToString("C")
        End Try
    End Sub
    Private Sub LimpiarTextInsert()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtPrecio.EditValue = 0
        txtDescuentoAplicado.Clear()
        txtIDArticulo.Clear()
        lblIDPrecio.Text = ""
        CbxMedida.Tag = ""
        lblIDAlmacenArticulo.Text = ""
        IDArticulo.Text = ""
        txtImporteTotal.Clear()
        lblDetalleCompra.Text = ""
        txtDescripcionArticulo.Tag = ""
        chkActualizarCosto.Checked = True
        btnActualizarDescripcion.Text = "Actualizar"
        txtDescripcionArticulo.Enabled = False
        XtraTabControl1.TabPages(1).PageVisible = False
        XtraTabControl1.TabPages(2).PageVisible = False
        XtraTabControl1.TabPages(3).PageVisible = False
        btnActualizarDescripcion.Visible = False
        btnModificar.Enabled = True
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Sub SetInformacionArticulo()
        Dim Dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia,ExistenciaTotal,Articulos.RutaFoto,Descontinuar,Marca FROM Articulos INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca WHERE IDArticulo='" + txtIDArticulo.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "Articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = Dstemp.Tables("Articulos")

        If Tabla.Rows.Count = 0 Then
            ConLibregco.Open()
            Dstemp.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia,ExistenciaTotal,Articulos.RutaFoto,Descontinuar,Marca FROM Articulos  INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca WHERE Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Articulos")
            ConLibregco.Close()

            Tabla = Dstemp.Tables("Articulos")

            If Tabla.Rows.Count = 0 Then
                ConLibregco.Open()
                Dstemp.Clear()
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia,ExistenciaTotal,Articulos.RutaFoto,Descontinuar,Marca FROM Articulos INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca WHERE CodigoBarra='" + txtIDArticulo.Text + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp, "Articulos")
                ConLibregco.Close()

                Tabla = Dstemp.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    txtIDArticulo.Focus()
                    XtraTabControl1.TabPages(1).PageVisible = False
                    XtraTabControl1.TabPages(2).PageVisible = False
                    XtraTabControl1.TabPages(3).PageVisible = False
                    btnActualizarDescripcion.Visible = False
                    ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                Else

                    If (Tabla.Rows(0).Item("Descontinuar")) = 1 Then
                        MessageBox.Show("El artíulo está marcado como descontinuado, por favor verifique el status del producto en el código No. [" & (Tabla.Rows(0).Item("IDArticulo")) & "] " & (Tabla.Rows(0).Item("Descripcion")) & ".", "Artículo descontinuado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        LimpiarDatosArticulos()
                        Exit Sub
                    End If

                    txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                    txtDescripcionArticulo.Tag = Tabla.Rows(0).Item("Referencia")
                    Label34.Text = "[" & (Tabla.Rows(0).Item("IDArticulo")) & "]"
                    Label33.Text = (Tabla.Rows(0).Item("Descripcion"))
                    lblMarca.Text = Tabla.Rows(0).Item("Marca")
                    txtDescuentoAplicado.Text = CDbl(0).ToString("P2")
                    txtCantidadArticulo.Text = 1
                    FillMedida()
                    ImporteTotalUnitario()

                    If TypeConnection.Text = 1 Then
                        If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                            ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        Else
                            If chkPreviewImages.Checked Then
                                Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                                If ExistFile = True Then
                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                    ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                                    wFile.Close()
                                Else
                                    ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                                End If

                            Else
                                ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            End If


                        End If
                    Else
                        ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    End If

                    If PermisosArticulos(0) = 1 Then
                        btnActualizarDescripcion.Visible = True
                        XtraTabControl1.TabPages(1).PageVisible = True
                        XtraTabControl1.TabPages(2).PageVisible = True
                        XtraTabControl1.TabPages(3).PageVisible = True
                    End If
                End If
            Else
                If (Tabla.Rows(0).Item("Descontinuar")) = 1 Then
                    MessageBox.Show("El artíulo está marcado como descontinuado, por favor verifique el status del producto en el código No. [" & (Tabla.Rows(0).Item("IDArticulo")) & "] " & (Tabla.Rows(0).Item("Descripcion")) & ".", "Artículo descontinuado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    LimpiarDatosArticulos()
                    Exit Sub
                End If

                txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                txtDescripcionArticulo.Tag = Tabla.Rows(0).Item("Referencia")
                Label34.Text = "[" & (Tabla.Rows(0).Item("IDArticulo")) & "]"
                Label33.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblMarca.Text = Tabla.Rows(0).Item("Marca")
                txtCantidadArticulo.Text = 1
                txtDescuentoAplicado.Text = CDbl(0).ToString("P2")
                FillMedida()
                ImporteTotalUnitario()

                If TypeConnection.Text = 1 Then
                    If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                        ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    Else
                        If chkPreviewImages.Checked Then
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                                wFile.Close()
                            Else
                                ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            End If

                        Else
                            ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        End If
                    End If
                Else
                    ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                End If

                If PermisosArticulos(0) = 1 Then
                    btnActualizarDescripcion.Visible = True
                    XtraTabControl1.TabPages(1).PageVisible = True
                    XtraTabControl1.TabPages(2).PageVisible = True
                    XtraTabControl1.TabPages(3).PageVisible = True
                End If
            End If
        Else

            If (Tabla.Rows(0).Item("Descontinuar")) = 1 Then
                MessageBox.Show("El artíulo está marcado como descontinuado, por favor verifique el status del producto en el código No. [" & (Tabla.Rows(0).Item("IDArticulo")) & "] " & (Tabla.Rows(0).Item("Descripcion")) & ".", "Artículo descontinuado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                LimpiarDatosArticulos()
                Exit Sub
            End If

            txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
            txtDescripcionArticulo.Tag = Tabla.Rows(0).Item("Referencia")
            Label34.Text = "[" & (Tabla.Rows(0).Item("IDArticulo")) & "]"
            Label33.Text = (Tabla.Rows(0).Item("Descripcion"))
            lblMarca.Text = Tabla.Rows(0).Item("Marca")
            txtCantidadArticulo.Text = 1
            txtDescuentoAplicado.Text = CDbl(0).ToString("P2")
            FillMedida()
            ImporteTotalUnitario()

            If TypeConnection.Text = 1 Then
                If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                    ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                Else
                    If chkPreviewImages.Checked Then
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            wFile.Close()
                        Else
                            ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        End If

                    Else
                        ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    End If
                End If
            Else
                ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
            End If

            If PermisosArticulos(0) = 1 Then
                btnActualizarDescripcion.Visible = True
                XtraTabControl1.TabPages(1).PageVisible = True
                XtraTabControl1.TabPages(2).PageVisible = True
                XtraTabControl1.TabPages(3).PageVisible = True
            End If

            Dstemp.Dispose()
        End If
    End Sub

    Sub LimpiarDatosArticulos()
        IDArticulo.Text = ""
        lblMarca.Text = ""
        txtIDArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtDescripcionArticulo.Enabled = False
        txtCantidadArticulo.Clear()
        txtPrecio.EditValue = 0
        txtImporteTotal.Clear()
        CbxMedida.Items.Clear()
        txtDescuentoAplicado.Clear()
        XtraTabControl1.TabPages(1).PageVisible = False
        XtraTabControl1.TabPages(2).PageVisible = False
        XtraTabControl1.TabPages(3).PageVisible = False
        btnActualizarDescripcion.Visible = False
        ProductImage = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
    End Sub

    Private Sub FillMedida()
        Try
            Dim ds As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "PrecioArticulo")
            CbxMedida.Items.Clear()
            ConLibregco.Close()


            For Each Fila As DataRow In ds.Tables("PrecioArticulo").Rows
                CbxMedida.Items.Add(Fila.Item("Abreviatura"))
            Next

            If ds.Tables("PrecioArticulo").Rows.Count > 0 Then
                CbxMedida.SelectedIndex = 0
            End If

            BuscarItebis()

            ds.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtIDArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtIDArticulo.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        'Try
        If txtIDArticulo.Text = "" Then
            LimpiarDatosArticulos()
        Else
            If txtIDArticulo.Text.Substring(0, 1) = "-" Then
                Dim Index As Integer = txtIDArticulo.Text.Remove(0, 1)
                If Index > 0 Then
                    If TablaCompras.Rows.Count >= Index - 1 Then
                        GridView1.DeleteRow(Index - 1)
                        LimpiarDatosArticulos()
                        SumTotales()
                    Else
                        LimpiarDatosArticulos()
                    End If
                Else
                    LimpiarDatosArticulos()
                End If

            ElseIf txtIDArticulo.Text.Substring(0, 1) = "*" Then
                Dim Index As Integer = txtIDArticulo.Text.Remove(0, 1)
                If Index > 0 Then
                    If TablaCompras.Rows.Count >= Index - 1 Then
                        LimpiarDatosArticulos()
                        GridView1.Focus()
                        GridView1.SelectRow(Index - 1)
                    Else
                        LimpiarDatosArticulos()
                    End If
                    LimpiarDatosArticulos()
                Else
                    LimpiarDatosArticulos()
                End If

                LimpiarDatosArticulos()

            Else
                lblIDAlmacenArticulo.Text = LUEAlmacen.EditValue.ToString
                SetInformacionArticulo()
            End If

        End If

        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        SetCosto()

        lblUnidad.Text = CbxMedida.Text.ToString.ToUpper
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM Libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        CbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()
    End Sub

    Sub SetCosto()
        Try
            Dim ds As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioCredito,PrecioContado,Precio3,Precio4 FROM Libregco.PrecioArticulo WHERE IDArticulo= '" + txtIDArticulo.Text + "' AND IDMedida='" + CbxMedida.Tag.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "PrecioArticulo")
            ConLibregco.Close()

            Label39.Tag = 0
            txtPrecio.EditValue = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Costo"))
            lblIDPrecio.Text = (ds.Tables("PrecioArticulo").Rows(0).Item("IDPrecios"))

            Label39.Text = "[Costos no actualizados]"
            Label39.ForeColor = Color.OrangeRed

            txtUltimoCosto.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Costo")).ToString("C" & txtCantDecimales.Value)
            txtUltimoCostoFInal.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("CostoFinal")).ToString("C" & txtCantDecimales.Value)
            txtUltimoPrecioA.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("PrecioCredito")).ToString("C" & txtCantDecimales.Value)
            txtUltimoPrecioB.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("PrecioContado")).ToString("C" & txtCantDecimales.Value)
            txtUltimoPrecioC.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Precio3")).ToString("C" & txtCantDecimales.Value)
            txtUltimoPrecioD.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Precio4")).ToString("C" & txtCantDecimales.Value)

            txtCosto.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Costo")).ToString("C" & txtCantDecimales.Value)
            txtCostoFinal.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("CostoFinal")).ToString("C" & txtCantDecimales.Value)
            txtPrecioA.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("PrecioCredito")).ToString("C" & txtCantDecimales.Value)
            txtPrecioB.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("PrecioContado")).ToString("C" & txtCantDecimales.Value)
            txtPrecioC.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Precio3")).ToString("C" & txtCantDecimales.Value)
            txtPrecioD.Text = CDbl(ds.Tables("PrecioArticulo").Rows(0).Item("Precio4")).ToString("C" & txtCantDecimales.Value)

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            LimpiarDatosArticulos()
        End Try
    End Sub

    Private Sub txtDescuentoAplicado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoAplicado.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDescuentoAplicado_Leave(sender As Object, e As EventArgs) Handles txtDescuentoAplicado.Leave
        Try
            If txtDescuentoAplicado.Text = "" Then
                txtDescuentoAplicado.Text = CDbl(0.0).ToString("P2")
            Else
                If CDbl(txtDescuentoAplicado.Text) > 100 Then
                    txtDescuentoAplicado.Text = 100
                End If

                txtDescuentoAplicado.Text = CDbl((txtDescuentoAplicado.Text) / 100).ToString("P2")
            End If


        Catch ex As Exception
            txtDescuentoAplicado.Text = CDbl(0.0).ToString("P2")
        End Try
    End Sub

    Private Sub VerificarDuplicados()
        If TablaCompras.Rows.Count = 0 Then
            lblCheckDuplicates.Text = 0
        Else
            For Each itm As DataRow In TablaCompras.Rows
                If CDbl(itm.Item("IDPrecio")) = CDbl(lblIDPrecio.Text) Then
                    MessageBox.Show("Este artículo ya se encuentra introducido en la compra." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    txtIDArticulo.Focus()
                    lblCheckDuplicates.Text = 1
                    Exit Sub
                End If
            Next
            lblCheckDuplicates.Text = 0
        End If

    End Sub

    Private Sub BuscarItebis()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Itbis from Libregco.Articulos INNER JOIN Libregco.TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
        lblItbisArticulo.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub btnAplicarMonto_Click(sender As Object, e As EventArgs) Handles btnAplicarMonto.Click
        'Try

        If txtIDArticulo.Text = "" Then
            MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()

        ElseIf CbxMedida.Items.Count = 0 Then
            MessageBox.Show("No se encontraron medidas válidas para el artículo seleccionado. Por favor inserte el renglón de costos y precios al artículo", "No se encontraron precios.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()

        Else

            If CbxMedida.Items.Count = 0 Then
                MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                CbxMedida.Focus()
                Exit Sub
            End If

            If DTConfiguracion.Rows(169 - 1).Item("Value2Int") = 0 Then
                VerificarDuplicados()
                If lblCheckDuplicates.Text = 1 Then
                    Exit Sub
                End If
            End If

            'Busqueda de Itbis
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
            Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()

            If rdbIncluido.Checked = True Then
                Dim PrecioUnitarioSinItbis As Double = (CDbl(txtPrecio.Text) / (CDbl(1) + ItbisC))
                Dim DescuentoAplicado As Double = ((CDbl(txtPrecio.Text) / (CDbl(1) + ItbisC)) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                Dim ItbisCalculado As Double = (((CDbl(txtPrecio.Text) / (CDbl(1) + ItbisC)) - ((CDbl(txtPrecio.Text) / (CDbl(1) + ItbisC)) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))) * ItbisC)

                TablaCompras.Rows.Add(lblDetalleCompra.Text, txtIDCompra.Text, ProductImage, lblIDPrecio.Text, IDArticulo.Text, txtDescripcionArticulo.Text, txtCantidadArticulo.Text, CbxMedida.Tag.ToString, CbxMedida.Text, PrecioUnitarioSinItbis, DescuentoAplicado, DescuentoAplicado2, ItbisCalculado, (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), ((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * txtCantidadArticulo.Text), lblIDAlmacenArticulo.Text, Convert.ToInt16(Fraccionamiento.Text), Convert.ToInt16(chkActualizarCosto.Checked), CDbl(ItbisCalculado * CDbl(txtCantidadArticulo.Text)), CDbl(CDbl(PrecioUnitarioSinItbis * CDbl(txtCantidadArticulo.Text))), VerificarEntidadCosto((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), VerificarEntidadPrecio((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), txtDescripcionArticulo.Tag, lblMarca.Text)

            ElseIf rdbNoIncluido.Checked = True Then
                Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                Dim DescuentoAplicado As Double = (CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                Dim ItbisCalculado As Double = (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2) * (ItbisC)
                TablaCompras.Rows.Add(lblDetalleCompra.Text, txtIDCompra.Text, ProductImage, lblIDPrecio.Text, IDArticulo.Text, txtDescripcionArticulo.Text, txtCantidadArticulo.Text, CbxMedida.Tag.ToString, CbxMedida.Text, CDbl(txtPrecio.Text), DescuentoAplicado, DescuentoAplicado2, ItbisCalculado, (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), ((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * txtCantidadArticulo.Text), lblIDAlmacenArticulo.Text, Convert.ToInt16(Fraccionamiento.Text), Convert.ToInt16(chkActualizarCosto.Checked), CDbl(ItbisCalculado * CDbl(txtCantidadArticulo.Text)), CDbl(CDbl(PrecioUnitarioSinItbis * CDbl(txtCantidadArticulo.Text))), VerificarEntidadCosto((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), VerificarEntidadPrecio((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), txtDescripcionArticulo.Tag, lblMarca.Text)

            ElseIf rdbNoItbis.Checked = True Then
                Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                Dim DescuentoAplicado As Double = (CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuentoAplicado.Text, "%", "") / 100))
                Dim DescuentoAplicado2 As Double = (PrecioUnitarioSinItbis - DescuentoAplicado) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                Dim ItbisCalculado As Double = 0

                TablaCompras.Rows.Add(lblDetalleCompra.Text, txtIDCompra.Text, ProductImage, lblIDPrecio.Text, IDArticulo.Text, txtDescripcionArticulo.Text, txtCantidadArticulo.Text, CbxMedida.Tag.ToString, CbxMedida.Text, CDbl(txtPrecio.Text), DescuentoAplicado, DescuentoAplicado2, ItbisCalculado, (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), (PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), ((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado) * txtCantidadArticulo.Text), lblIDAlmacenArticulo.Text, Convert.ToInt16(Fraccionamiento.Text), Convert.ToInt16(chkActualizarCosto.Checked), CDbl(ItbisCalculado * CDbl(txtCantidadArticulo.Text)), CDbl(CDbl(PrecioUnitarioSinItbis * CDbl(txtCantidadArticulo.Text))), VerificarEntidadCosto((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), VerificarEntidadPrecio((PrecioUnitarioSinItbis - DescuentoAplicado - DescuentoAplicado2 + ItbisCalculado), lblIDPrecio.Text), txtDescripcionArticulo.Tag, lblMarca.Text)
            End If

            btnActualizarDescripcion.Visible = False
            LimpiarTextInsert()
            HabilitarPanelItibis()
            GridView1.ClearSelection()
            SumTotales()
            GridView1.MoveLast()
            txtIDArticulo.Focus()

        End If
        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub Gridview1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.FocusedColumn.FieldName = "IDArticulo" Then
                    If frm_mant_articulos.Visible = True Then
                        frm_mant_articulos.Close()
                    End If

                    frm_mant_articulos.Show(Me)
                    frm_mant_articulos.txtIDProducto.Text = GridView1.GetFocusedRowCellValue("IDArticulo").ToString
                    frm_mant_articulos.FillAllDatafromID()

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFactSuplidor(txtIDSuplidor.Text)
        FunctCalcBceSuplidor(txtIDSuplidor.Text)
    End Sub

    Private Sub ActualizarCambios()
        If txtIDCompra.Text = "" Then
        Else
            sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='" + lblTipoItbis.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + LUEAlmacen.EditValue.ToString + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(txtDescuento.Text).ToString + "',ITBIS='" + CDbl(txtItbis.Text).ToString + "',Descuento2='" + CDbl(txtDescuento2.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDEmpleadoRec='" + txtRecepcion.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='" + chkpreciosdiferidos.Tag.ToString + "',CreditoPendiente='" + chkcreditospendientes.Tag.ToString + "',ArticuloFuera='" + chkArtfuerapedido.Tag.ToString + "',NegociarFlete='" + chkrenegociarflete.Tag.ToString + "',Averiados='" + chkAveriados.Tag.ToString + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
            GuardarDatos()
            CalcularBalances()
        End If
    End Sub

    Private Sub EliminarArticulo()
        Dim IDDetalleCompra As New Label
        IDDetalleCompra.Text = GridView1.GetFocusedRowCellValue("IDDetalleCompra")

        If IDDetalleCompra.Text = "" Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)

        Else
            sqlQ = "Delete from DetalleCompra Where IDDetalleCompra = (" + IDDetalleCompra.Text + ")"
            GuardarDatos()
            CalcExistencia()
            CalcExistenciaAlm()
            Dim iterateIndex1 As Integer = 0
            Dim newDataTable1 As DataTable = TablaCompras.Copy
            For Each itm As DataRow In newDataTable1.Rows
                If itm.Item("IDDetalleCompra") = GridView1.GetFocusedRowCellValue("IDDetalleCompra").ToString Then
                    TablaCompras.Rows.RemoveAt(iterateIndex1)
                    Exit For
                Else
                    iterateIndex1 += 1
                End If
            Next
            newDataTable1.Dispose()

            MessageBox.Show("Artículo eliminado satisfactoriamente de la factura.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub txtFlete_Leave(sender As Object, e As EventArgs) Handles txtFlete.Leave
        Try
            If txtFlete.Text = "" Then
                txtFlete.Text = CDbl(0).ToString("C" & txtCantDecimales.Value)
            Else

                txtFlete.Text = CDbl(txtFlete.Text).ToString("C" & txtCantDecimales.Value)
            End If
            SumTotales()

        Catch ex As Exception
            txtFlete.Text = CDbl(0).ToString("C" & txtCantDecimales.Value)
        End Try
    End Sub

    Private Sub txtFlete_Enter(sender As Object, e As EventArgs) Handles txtFlete.Enter
        If txtFlete.Text = "" Then
        Else
            txtFlete.Text = CDbl(txtFlete.Text)
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        'Try
        If txtUltimoCosto.Text = "" Then
        Else
            If CDbl(txtPrecio.EditValue) <> CDbl(txtUltimoCosto.Text) Then
                Label39.Text = "[Costo Actualizado]"
                Label39.ForeColor = SystemColors.Highlight

                txtCosto.Text = txtPrecio.EditValue
                txtCostoFinal.Text = txtPrecio.EditValue
                lblDifCosto.Text = GetPorcentajeDif(CDbl(txtPrecio.EditValue), CDbl(txtUltimoCosto.Text), lblDifCosto)
            End If
        End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        '    txtPrecio.EditValue = CDbl(0).ToString("C" & CantDecimales)
        'End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub

    Private Sub UltCompra()
        Try

            If txtIDCompra.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDCompra from Compras where IDCompra= (Select Max(IDCompra) from Compras)", Con)
                txtIDCompra.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

            MostrarControlSubTotales()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CreateFolder()
        Try
            If TypeConnection.Text = 1 Then
                Dim Exists As Boolean
                Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)

                If Exists = True Then
                Else
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
                End If

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub MoverFichero()
        Try
            If TypeConnection.Text = 1 Then
                CreateFolder()   'Verificamos si existe el folder del suplidor

                If RutaDocumento.Text = "" Then
                Else
                    'Verifico si existe la carpeta del suplidor
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
                    End If


                    'Verifico si existe el archivo de por anexar
                    Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                    If ExistsFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text & "\" & txtSecondID.Text & "-" & txtNoFact.Text & ".png"

                        If RutaDestino <> RutaDocumento.Text Then
                            My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                        sqlQ = "UPDATE Compras SET RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDCompra= '" + txtIDCompra.Text + "'"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                        RutaDocumento.Text = RutaDestino
                        wFile.Close()
                    End If

                End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub HabilitarEnvioDatos()
        If txtIDCompra.Text <> "" Then

            XtraTabControl2.TabPages(3).PageVisible = True

            If RutaDocumento.Text = "" Then
                chkEnviarCopiaDigital.Checked = False
                chkEnviarCopiaDigital.Enabled = False
                chkEnviarReporte.Enabled = True

            Else
                chkEnviarCopiaDigital.Checked = False
                chkEnviarReporte.Checked = False
                chkEnviarCopiaDigital.Enabled = True
                chkEnviarReporte.Enabled = True
            End If
        Else
            XtraTabControl2.TabPages(3).PageVisible = False
        End If

    End Sub

    Private Sub CerrarOrden()
        Try
            If IDOrdenCompra.Text = "" Then
            Else
                sqlQ = "UPDATE OrdenCompra SET IDTipoOrden=2 WHERE IDOrdenCompra= (" + IDOrdenCompra.Text + ")"
                GuardarDatos()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarCostos()
        Try

            'Dim UpdateCostos As Double = DTConfiguracion.Rows(27 - 1).Item("Value2Int")
            If DTConfiguracion.Rows(27 - 1).Item("Value2Int") = 1 Then
                Dim lblIDPrecio, Costo, CostoFinal As New Label
                Dim DsTemp As New DataSet
                ConMixta.Open()

                For Each Rws As DataRow In TablaCompras.Rows
                    lblIDPrecio.Text = Rws.Item("IDPrecio")

                    'Llenamos dataset con datos de la ultima factura para actualizar los costos
                    DsTemp.Clear()
                    cmd = New MySqlCommand("SELECT DetalleCompra.IDCompra,Compras.SecondID,Compras.Fecha,IDArticulo,IDPrecio,Descripcion,Importe,CostoFinal FROM" & SysName.Text & "detallecompra INNER JOIN" & SysName.Text & "Compras on DetalleCompra.IDCompra=Compras.IDCompra Where IDPrecio='" + lblIDPrecio.Text + "' and Actualizable=1 ORDER BY Compras.IDCompra DESC,Importe DESC  LIMIT 1", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Compras")

                    Dim Tabla As DataTable = DsTemp.Tables("Compras")

                    Costo.Text = (Tabla.Rows(0).Item("Importe"))
                    CostoFinal.Text = (Tabla.Rows(0).Item("CostoFinal"))

                    sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + Costo.Text + "',CostoFinal='" + CostoFinal.Text + "' WHERE IDPrecios= '" + lblIDPrecio.Text + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CalcExistenciaAlm()
        For Each Row As DataRow In TablaCompras.Rows
            FunctCalcInvAlmacenes(Row.Item("IDArticulo").ToString, Row.Item("IDPrecio").ToString)
        Next
    End Sub

    Private Sub CalcExistencia()
        For Each Row As DataRow In TablaCompras.Rows
            FunctCalcInventarioGral(Row.Item("IDArticulo").ToString)
        Next
    End Sub

    Private Sub InsertArticulos()
        Con.Open()

        For Each Row As DataRow In TablaCompras.Rows

            If CStr(Row.Item("IDDetalleCompra")).ToString = "" Then
                sqlQ = "INSERT INTO DetalleCompra (IDCompra,IDArticulo,IDPrecio,Descripcion,IDMedida,Medida,Cantidad,PrecioUnitario,Descuento,Descuento2,Itbis,Importe,IDAlmacen,CostoFinal,Orden,Actualizable) VALUES ('" + txtIDCompra.Text + "','" + Row.Item("IDArticulo").ToString + "','" + Row.Item("IDPrecio").ToString + "','" + Row.Item("Descripcion").ToString + "','" + Row.Item("IDMedida").ToString + "','" + Row.Item("Medida").ToString + "','" + Row.Item("Cantidad").ToString + "','" + CDbl(Row.Item("PrecioUnitario")).ToString + "','" + CDbl(Row.Item("Descuento")).ToString + "','" + CDbl(Row.Item("Descuento2")).ToString + "','" + CDbl(Row.Item("Itbis")).ToString + "','" + CDbl(Row.Item("Importe")).ToString + "','" + Row.Item("IDAlmacen").ToString + "','" + CDbl(Row.Item(14)).ToString + "','" + TablaCompras.Rows.IndexOf(Row).ToString + "','" + Convert.ToInt16(Row.Item("ActualizarCostos")).ToString + "')"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                'Estos eventos requieren una conexion abierta
                CheckedUptadesinPrinces(Row.Item("IDPrecio").ToString, CDbl(Row.Item("Importe")))
                CheckProductListStatus(Row.Item("IDArticulo").ToString, 1)
                UpdateLastUpdatePrices(Row.Item("IDPrecio").ToString)

            Else
                sqlQ = "UPDATE DetalleCompra SET IDCompra='" + Row.Item("IDCompra").ToString + "',IDArticulo='" + Row.Item("IDArticulo").ToString + "',IDPrecio='" + Row.Item("IDPrecio").ToString + "',Descripcion='" + Row.Item("Descripcion").ToString + "',IDMedida='" + Row.Item("IDMedida").ToString + "',Medida='" + Row.Item("Medida").ToString + "',Cantidad='" + Row.Item("Cantidad").ToString + "',PrecioUnitario='" + CDbl(Row.Item("PrecioUnitario")).ToString + "',Descuento='" + CDbl(Row.Item("Descuento")).ToString + "',Descuento2='" + CDbl(Row.Item("Descuento2")).ToString + "',Itbis='" + CDbl(Row.Item("Itbis")).ToString + "',Importe='" + CDbl(Row.Item("Importe")).ToString + "',IDAlmacen='" + Row.Item("IDAlmacen").ToString + "',CostoFinal='" + CDbl(Row.Item("CostoFinalUnitario")).ToString + "',Orden='" + TablaCompras.Rows.IndexOf(Row).ToString + "',Actualizable='" + Convert.ToInt16(CBool(Row.Item("ActualizarCostos"))).ToString + "' Where IDDetalleCompra='" + Row.Item("IDDetalleCompra").ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

        Next

        Con.Close()

        RefrescarTablaArticulos()
    End Sub

    Private Sub chkAnular_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Sub DeshabilitarControles()
        DtpFechaFact.Enabled = False
        cbxCondicion.Enabled = False
        DtpVencimiento.Enabled = False
        txtNoFact.Enabled = False
        txtReferencia.Enabled = False
        GbComprobante.Enabled = False
        XtraTabControl1.Enabled = False
        XtraTabControl2.Enabled = False
        LUEAlmacen.Enabled = False
        txtFlete.Enabled = False
        btnGuardarC.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        DtpFechaFact.Enabled = True
        cbxCondicion.Enabled = True
        DtpVencimiento.Enabled = True
        txtNoFact.Enabled = True
        txtReferencia.Enabled = True
        GbComprobante.Enabled = True
        XtraTabControl1.Enabled = True
        XtraTabControl2.Enabled = True
        LUEAlmacen.Enabled = True
        txtFlete.Enabled = True
        btnGuardarC.Enabled = True
    End Sub

    Sub RefrescarTablaArticulos()
        Dim ImgFile As Image

        If txtIDCompra.Text = "" Then
        Else
            TablaCompras.Rows.Clear()

            ConMixta.Open()
            Dim Consulta As New MySqlCommand("Select IDDetalleCompra,IDCompra,DetalleCompra.IDPrecio,DetalleCompra.IDArticulo,DetalleCompra.Descripcion,DetalleCompra.IDMedida,Medida.Abreviatura,Cantidad,PrecioUnitario,Descuento,Descuento2,Itbis,Importe,IDAlmacen,DetalleCompra.CostoFinal,Fraccionamiento,Actualizable,Articulos.RutaFoto,Articulos.Referencia,Marca.Marca FROM" & SysName.Text & "DetalleCompra INNER JOIN Libregco.PrecioArticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on DetalleCompra.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca Where IDCompra='" + txtIDCompra.Text + "' Order by Orden ASC", ConMixta)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read

                If TypeConnection.Text = 1 Then
                    If (LectorArticulos.GetValue(17)) = "" Then
                        ImgFile = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(LectorArticulos.GetValue(17))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(LectorArticulos.GetValue(17), FileMode.Open, FileAccess.Read)
                            ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                            wFile.Close()
                        Else
                            ImgFile = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                        End If
                    End If
                Else
                    ImgFile = ResizeImage(My.Resources.No_Image, DTConfiguracion.Rows(180 - 1).Item("Value2Int"))
                End If

                TablaCompras.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), ImgFile, LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(7), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(14), CDbl(LectorArticulos.GetValue(7)) * CDbl(LectorArticulos.GetValue(12)), LectorArticulos.GetValue(13), LectorArticulos.GetValue(15), LectorArticulos.GetValue(16), CDbl(LectorArticulos.GetValue(7) * CDbl(LectorArticulos.GetValue(11))), CDbl(CDbl(LectorArticulos.GetValue(8) * CDbl(LectorArticulos.GetValue(7)))), VerificarEntidadCosto(CDbl(LectorArticulos.GetValue(12)), LectorArticulos.GetValue(2)), VerificarEntidadPrecio(CDbl(LectorArticulos.GetValue(12)), LectorArticulos.GetValue(2)), LectorArticulos.GetValue(18), LectorArticulos.GetValue(19))
            End While

            LectorArticulos.Close()
            ConMixta.Close()

        End If

        SumTotales()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDCompra.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub txtDescuentoAplicado_Enter(sender As Object, e As EventArgs) Handles txtDescuentoAplicado.Enter
        Try
            If txtDescuentoAplicado.Text = "" Then
            Else
                txtDescuentoAplicado.Text = CDbl(Replace(txtDescuentoAplicado.Text, "%", ""))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DtpDiaRecibido_ValueChanged(sender As Object, e As EventArgs) Handles DtpDiaRecibido.ValueChanged
        If DtpDiaRecibido.Value < DtpFechaFact.Value Then
            MessageBox.Show("La fecha de recepción de compras no puede ser menor a la fecha de facturacíon. Verifique los datos para continuar.", "Error en fecha de recepción", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            DtpDiaRecibido.Value = DtpFechaFact.Value
        Else
        End If
    End Sub

    Private Sub DtpVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles DtpVencimiento.ValueChanged
        If DtpVencimiento.Value < DtpFechaFact.Value Then
            MessageBox.Show("La fecha de vencimiento de compras no puede ser menor a la fecha de facturacíon. Verifique los datos para continuar.", "Error en fecha de vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            DtpVencimiento.Value = DtpFechaFact.Value
        Else
        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Try
            If Fraccionamiento.Text = 1 Then
                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select

                If (txtCantidadArticulo.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
                    e.Handled = True
                End If
            Else

                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    'Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select
            End If


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
        btnBuscarSup.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPrecio.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlete.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtFlete.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBlanquearr_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If TablaCompras.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDCompra.Text = "" And TablaCompras.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    TablaCompras.Rows.Clear()
                    HabilitarPanelItibis()
                    SumTotales()
                    Exit Sub
                End If
            End If

            If txtIDCompra.Text <> "" And TablaCompras.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya insertados a través de esta función." & vbNewLine & "Para proceder a la eliminación de artículos utilice la función F2-Quitar Artículos.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If TablaCompras.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & GridView1.GetFocusedRowCellValue("Descripcion").ToString & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    EliminarArticulo()
                    HabilitarPanelItibis()
                    SumTotales()
                    ActualizarCambios()

                    Con.Open()
                    CheckProductListStatus(GridView1.GetFocusedRowCellValue("IDArticulo"), 0)
                    Con.Close()

                End If
            Else
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        'Try
        If TablaCompras.Rows.Count > 0 Then
            btnModificar.Enabled = False
            lblDetalleCompra.Text = GridView1.GetFocusedRowCellValue("IDDetalleCompra")
            txtIDArticulo.Text = GridView1.GetFocusedRowCellValue("IDArticulo")
            IDArticulo.Text = GridView1.GetFocusedRowCellValue("IDArticulo")
            FillMedida()
            CbxMedida.Text = GridView1.GetFocusedRowCellValue("Medida")
            CbxMedida.Tag = GridView1.GetFocusedRowCellValue("IDMedida")
            txtCantidadArticulo.Text = GridView1.GetFocusedRowCellValue("Cantidad")
            txtDescripcionArticulo.Text = GridView1.GetFocusedRowCellValue("Descripcion")
            txtDescripcionArticulo.Tag = GridView1.GetFocusedRowCellValue("Referencia")
            lblIDAlmacenArticulo.Text = GridView1.GetFocusedRowCellValue("IDAlmacen")
            chkActualizarCosto.Checked = GridView1.GetFocusedRowCellValue("ActualizarCostos")
            ProductImage = GridView1.GetFocusedRowCellValue("Imagen")

            If rdbNoIncluido.Checked = True Or rdbNoItbis.Checked = True Then
                txtPrecio.EditValue = CDbl(GridView1.GetFocusedRowCellValue("PrecioUnitario"))
            Else
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Itbis FROM articulos INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + GridView1.GetFocusedRowCellValue("IDArticulo") + "'", ConLibregco)
                Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()
                txtPrecio.EditValue = CDbl((GridView1.GetFocusedRowCellValue("PrecioUnitario")) * (CDbl(1) + ItbisC))
            End If

            If CDbl(GridView1.GetFocusedRowCellValue("PrecioUnitario")) > 0 Then
                txtDescuentoAplicado.Text = (CDbl(GridView1.GetFocusedRowCellValue("Descuento")) / CDbl(GridView1.GetFocusedRowCellValue("PrecioUnitario"))).ToString("P")
            Else
                txtDescuentoAplicado.Text = CDbl(0).ToString("P")
            End If

            lblDescuento2.Text = CDbl(GridView1.GetFocusedRowCellValue("Descuento2"))
            txtPrecio.Focus()

            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            '''''''''''''''''''''''''''''''''''''''

            HabilitarPanelItibis()
            SumTotales()

            If PermisosArticulos(0) = 1 Then
                btnActualizarDescripcion.Visible = True
                XtraTabControl1.TabPages(1).PageVisible = True
                XtraTabControl1.TabPages(2).PageVisible = True
                XtraTabControl1.TabPages(3).PageVisible = True
            End If
        Else
            MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub SubirFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubirFacturaToolStripMenuItem.Click
        btnSubirFactura.PerformClick()
    End Sub

    Private Sub btnSubirFactura_Click(sender As Object, e As EventArgs) Handles btnSubirFactura.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = RutaDocumento.Text

            If RutaDocumento.Text <> "" Then
                If System.IO.File.Exists(RutaDocumento.Text) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDocumento.Text, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If
        End If
    End Sub

    Private Sub ConsultaDeNotasDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeNotasDePedidoToolStripMenuItem.Click
        If frm_consulta_orden_compra.Visible = True Then
            frm_consulta_orden_compra.Close()
        End If

        frm_consulta_orden_compra.Show(Me)
    End Sub


    Private Sub txtPorDescuento2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorDescuento2.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPorDescuento2.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPorDescuento2_Leave(sender As Object, e As EventArgs) Handles txtPorDescuento2.Leave
        Try
            If txtPorDescuento2.Text = "" Then
                txtPorDescuento2.Text = CDbl(0.0).ToString("P2")
            Else

                If CDbl(txtPorDescuento2.Text) > 100 Then
                    txtPorDescuento2.Text = 100
                End If

                txtPorDescuento2.Text = CDbl((txtPorDescuento2.Text) / 100).ToString("P2")
            End If

            CalcularDescuento2()
            SumTotales()

        Catch ex As Exception
            txtPorDescuento2.Text = CDbl(0.0).ToString("P")
        End Try
    End Sub

    Private Sub CalcularDescuento2()
        'Try
        Dim Desc As String = CDbl(Replace(txtPorDescuento2.Text, "%", ""))

        If IsNumeric(Desc) Then
            For Each rw As DataRow In TablaCompras.Rows
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + rw("IDArticulo").ToString + "'", ConLibregco)
                Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                rw.Item("Descuento2") = CDbl(CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")))) - CDbl(CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento"))) - ((CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento"))) * (CDbl(Desc) / 100)))
                rw.Item("Itbis") = CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")) - CDbl(rw("Descuento2"))) * ItbisC
                rw.Item("Importe") = CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")) - CDbl(rw("Descuento2")) + CDbl(rw("Itbis")))
                rw.Item("CostoFinalUnitario") = CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")) - CDbl(rw("Descuento2")) + CDbl(rw("Itbis")))
                rw.Item("ImporteTotal") = CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")) - CDbl(rw("Descuento2")) + CDbl(rw("Itbis"))) * CDbl(rw("Cantidad"))
                rw.Item("ItbisTotal") = CDbl(rw("Itbis")) * CDbl(rw("Cantidad"))
                rw.Item("Subtotal") = CDbl(CDbl(rw("PrecioUnitario")) - CDbl(rw("Descuento")) - CDbl(rw("Descuento2"))) * CDbl(rw("Cantidad"))
                rw.Item("E/C") = VerificarEntidadCosto(CDbl(rw("Importe")), rw("IDPrecio"))
                rw.Item("E/V") = VerificarEntidadPrecio(CDbl(rw("Importe")), rw("IDPrecio"))
            Next
        End If



        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub txtPorDescuento2_Enter(sender As Object, e As EventArgs) Handles txtPorDescuento2.Enter
        Try
            If txtPorDescuento2.Text = "" Then
            Else
                txtPorDescuento2.Text = CDbl(Replace(txtPorDescuento2.Text, "%", ""))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub HabilitarPanelItibis()
        'If DgvArticulos.Rows.Count = 0 Then
        '    PnItbis.Enabled = True
        'Else
        '    PnItbis.Enabled = False
        'End If
    End Sub

    Private Sub SetTipoItbis()
        If rdbIncluido.Checked = True Then
            lblTipoItbis.Text = 1
        ElseIf rdbNoIncluido.Checked = True Then
            lblTipoItbis.Text = 2
        ElseIf rdbNoItbis.Checked = True Then
            lblTipoItbis.Text = 3
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDCompra.Text = "" Then
            If TablaCompras.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de registro de compras?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor de la factura a procesar.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtNoFact.Text = "" Then
            MessageBox.Show("Escriba el No. de la Factura de compra.", "No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoFact.Focus()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante de la factura de compra.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf TablaCompras.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar la compra.", "Insertar los artículos de la compra", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            Exit Sub
        ElseIf LUEAlmacen.EditValue.ToString = "" Then
            MessageBox.Show("Seleccione un almacén para generar el registro de compra", "Seleccione un almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            LUEAlmacen.Focus()
            Exit Sub
        ElseIf txtRecepcion.Text = "" Then
            MessageBox.Show("Seleccione el empleado que recibió la factura.", "Empleado en Recepción y/o Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRecepcion.Focus()
            Exit Sub
        ElseIf ImponerEscrituradeNCF = 1 And txtNCF.MaskFull = False Then
            MessageBox.Show("El tipo de comprobante fiscal seleccionado obliga a la escritura del NCF completamente. Por favor ingrese el número de comprobante fiscal.", "NCF incompleto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNCF.Focus()
            Exit Sub
        End If


        If txtIDCompra.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura de compras del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nueva Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Dim AvisoInconsistencia = DTConfiguracion.Rows(9 - 1).Item("Value2Int")

                If DTConfiguracion.Rows(9 - 1).Item("Value2Int") = 1 Then
                    If ImponerEscrituradeNCF = 1 Then
                        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                        Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                        Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                        If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                            If Not AccionesModulosAutorizadas.Contains("99") Then
                                ControlSuperClave = 1
                                MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_superclave.IDAccion.Text = 99
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                VerificarStocksEnInventario()
                SetTipoItbis()
                sqlQ = "INSERT INTO Compras (IDTipoDocumento,IDSuplidor,IDUsuario,Fecha,Hora,IDCondicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,IDComprobanteFiscal,NCF,NCFModificado,TipoItbis,IDSucursal,IDAlmacen,SubTotal,Descuento,Descuento2,ITBIS,Flete,TotalNeto,IDEmpleadoRec,DiaRecepcion,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoAlPago,IDTipoGasto,IDMoneda,Tasa,Balance,RutaDocumento,Nulo,Impreso,SubtotalLlenado,SubtotalBienes,SubtotalServicios,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,ISRPercibido,ISRMontoRetencion,ISCTotal,PropinaLegal,OtrosImpuestos,IDTipoPago,CantDecimales) VALUES (6,'" + txtIDSuplidor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURTIME(),'" + cbxCondicion.Tag.ToString + "','" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "','" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "','" + txtNoFact.Text + "','" + txtReferencia.Text + "','" + CbxTipoComprobante.Tag.ToString + "','" + txtNCF.Text + "','','" + lblTipoItbis.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + LUEAlmacen.EditValue.ToString + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(txtDescuento.Text).ToString + "','" + CDbl(txtDescuento2.Text).ToString + "','" + CDbl(txtItbis.Text).ToString + "','" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + txtRecepcion.Tag.ToString + "','" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "','" + txtNotaCompra.Text + "','" + chkpreciosdiferidos.Tag.ToString + "','" + chkcreditospendientes.Tag.ToString + "','" + chkArtfuerapedido.Tag.ToString + "','" + chkrenegociarflete.Tag.ToString + "','" + chkAveriados.Tag.ToString + "','" + chkDescuentoPago.Tag.ToString + "','" + LUEGasto.EditValue.ToString + "','" + LueMoneda.EditValue.ToString + "','" + txtTasa.Text + "','" + CDbl(txtNeto.Text).ToString + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0,0,'" + CDbl(CDbl(txtSubTotal.Text) - CDbl(txtDescuento.Text) - CDbl(txtDescuento2.Text)).ToString + "',0,'" + CDbl(txtItbis.Text).ToString + "',0,0,0,0,0,1,0,0,0,0,0,1,'" + txtCantDecimales.Value.ToString + "')"
                GuardarDatos()
                UltCompra()
                SetSecondID()
                InsertArticulos()
                CalcularBalances()
                ActualizarCostos()
                CalcularInventarios()
                ActualizarUltimoSuplidor()
                MoverFichero()
                HabilitarEnvioDatos()
                frm_aumento_precios_dinamico.ShowDialog(Me)
                CerrarOrden()

                ToastNotificationsManager1.Notifications(0).Body = "La compra " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                GridView1.ClearSelection()

                If DTConfiguracion.Rows(164 - 1).Item("Value2Int") = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then


                FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Dim AvisoInconsistencia = DTConfiguracion.Rows(27 - 1).Item("Value2Int")

                If DTConfiguracion.Rows(9 - 1).Item("Value2Int") = 1 Then
                    If ImponerEscrituradeNCF = 1 Then
                        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                        Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                        Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                        If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                            If Not AccionesModulosAutorizadas.Contains("99") Then
                                ControlSuperClave = 1
                                MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_superclave.IDAccion.Text = 99
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                SetTipoItbis()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='" + lblTipoItbis.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + LUEAlmacen.EditValue.ToString + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(txtDescuento.Text).ToString + "',ITBIS='" + CDbl(txtItbis.Text).ToString + "',Descuento2='" + CDbl(txtDescuento2.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDEmpleadoRec='" + txtRecepcion.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='" + chkpreciosdiferidos.Tag.ToString + "',CreditoPendiente='" + chkcreditospendientes.Tag.ToString + "',ArticuloFuera='" + chkArtfuerapedido.Tag.ToString + "',NegociarFlete='" + chkrenegociarflete.Tag.ToString + "',Averiados='" + chkAveriados.Tag.ToString + "',DescuentoAlPago='" + chkDescuentoPago.Tag.ToString + "',IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDMoneda='" + LueMoneda.EditValue.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                InsertArticulos()
                CalcularBalances()
                ActualizarCostos()
                CalcularInventarios()
                MoverFichero()
                HabilitarEnvioDatos()

                ToastNotificationsManager1.Notifications(1).Body = "La compra " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
                GridView1.ClearSelection()

                If DTConfiguracion.Rows(164 - 1).Item("Value2Int") = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub ActualizarUltimoSuplidor()
        Try
            'Dim ActualizarSuplidor As Double = DTConfiguracion.Rows(26 - 1).Item("Value2Int")

            If DTConfiguracion.Rows(26 - 1).Item("Value2Int") = 1 Then
                ConLibregco.Open()

                For Each Row As DataRow In TablaCompras.Rows
                    sqlQ = "UPDATE Libregco.Articulos SET IDSuplidor='" + txtIDSuplidor.Text + "' WHERE IDArticulo='" + Row.Item("IDArticulo").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                Next
                ConLibregco.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=6", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Compras SET SecondID='" + lblSecondID.Text + "' WHERE IDCompra='" + txtIDCompra.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=6"
            GuardarDatos()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub VerificarStocksEnInventario()
        If PermisosAjustes(0) = 1 Then

            Dim DsTemp As New DataSet

            frm_registro_compras_ajustesentrada.DgvArticulos.Rows.Clear()

            ConMixta.Open()

            For Each rw As DataRow In TablaCompras.Rows
                DsTemp.Clear()
                cmd = New MySqlCommand("SELECT Articulos.IDArticulo,IDPrecios,Medida.IDMedida,Descripcion,Referencia,Abreviatura,CostoFinal,ExistenciaTotal,Contenido FROM libregco.articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where Articulos.IDArticulo='" + rw.Item("IDArticulo").ToString + "' and Contenido=1", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "articulos")

                Dim Tabla As DataTable = DsTemp.Tables("articulos")

                If Tabla.Rows.Count > 0 Then

                    If CDbl(Tabla.Rows(0).Item("ExistenciaTotal")) < 0 Then

                        Dim Founded As Boolean = False

                        For Each rws As DataGridViewRow In frm_registro_compras_ajustesentrada.DgvArticulos.Rows
                            If rws.Cells(0).Value = Tabla.Rows(0).Item(0) Then
                                Founded = True
                                Exit For
                            Else
                                Founded = False
                            End If
                        Next

                        If Founded = False Then
                            frm_registro_compras_ajustesentrada.DgvArticulos.Rows.Add(Tabla.Rows(0).Item(0), Tabla.Rows(0).Item(1), Tabla.Rows(0).Item(2), Tabla.Rows(0).Item(3), Tabla.Rows(0).Item(4), Tabla.Rows(0).Item(5), Tabla.Rows(0).Item(6), Tabla.Rows(0).Item(7), True)
                        End If

                    End If
                End If
            Next

            ConMixta.Close()


            If frm_registro_compras_ajustesentrada.DgvArticulos.Rows.Count > 0 Then
                frm_registro_compras_ajustesentrada.ShowDialog(Me)
            End If

        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor de la factura a procesar.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtNoFact.Text = "" Then
            MessageBox.Show("Escriba el No. de la Factura de compra.", "No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoFact.Focus()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante de la factura de compra.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf LUEAlmacen.EditValue.ToString = "" Then
            MessageBox.Show("Seleccione un almacén para generar el registro de compra", "Seleccione un almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            LUEAlmacen.Focus()
            Exit Sub
        ElseIf TablaCompras.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar la compra.", "Insertar los artículos de la compra", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            Exit Sub
        ElseIf txtRecepcion.Text = "" Then
            MessageBox.Show("Seleccione el empleado que recibió la factura.", "Empleado en Recepción y/o Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRecepcion.Focus()
            Exit Sub
        End If


        If txtIDCompra.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura de compras del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nueva Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Dim AvisoInconsistencia =DTConfiguracion.Rows(9 - 1).Item("Value2Int")

                If DTConfiguracion.Rows(9 - 1).Item("Value2Int") = 1 Then
                    If ImponerEscrituradeNCF = 1 Then
                        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                        Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                        Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                        If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                            If Not AccionesModulosAutorizadas.Contains("99") Then
                                ControlSuperClave = 1
                                MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_superclave.IDAccion.Text = 99
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                VerificarStocksEnInventario()
                SetTipoItbis()
                sqlQ = "INSERT INTO Compras (IDTipoDocumento,IDSuplidor,IDUsuario,Fecha,Hora,IDCondicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,IDComprobanteFiscal,NCF,NCFModificado,TipoItbis,IDSucursal,IDAlmacen,SubTotal,Descuento,Descuento2,ITBIS,Flete,TotalNeto,IDEmpleadoRec,DiaRecepcion,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoAlPago,IDTipoGasto,IDMoneda,Tasa,Balance,RutaDocumento,Nulo,Impreso,SubtotalLlenado,SubtotalBienes,SubtotalServicios,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,ISRPercibido,ISRMontoRetencion,ISCTotal,PropinaLegal,OtrosImpuestos,IDTipoPago,CantDecimales) VALUES (6,'" + txtIDSuplidor.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',CURDATE(),CURTIME(),'" + cbxCondicion.Tag.ToString + "','" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "','" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "','" + txtNoFact.Text + "','" + txtReferencia.Text + "','" + CbxTipoComprobante.Tag.ToString + "','" + txtNCF.Text + "','','" + lblTipoItbis.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + LUEAlmacen.EditValue.ToString + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(txtDescuento.Text).ToString + "','" + CDbl(txtDescuento2.Text).ToString + "','" + CDbl(txtItbis.Text).ToString + "','" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + txtRecepcion.Tag.ToString + "','" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "','" + txtNotaCompra.Text + "','" + chkpreciosdiferidos.Tag.ToString + "','" + chkcreditospendientes.Tag.ToString + "','" + chkArtfuerapedido.Tag.ToString + "','" + chkrenegociarflete.Tag.ToString + "','" + chkAveriados.Tag.ToString + "','" + chkDescuentoPago.Tag.ToString + "','" + LUEGasto.EditValue.ToString + "','" + LueMoneda.EditValue.ToString + "','" + txtTasa.Text + "','" + CDbl(txtNeto.Text).ToString + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0,0,'" + CDbl(CDbl(txtSubTotal.Text) - CDbl(txtDescuento.Text) - CDbl(txtDescuento2.Text)).ToString + "',0,'" + CDbl(txtItbis.Text).ToString + "',0,0,0,0,0,1,0,0,0,0,0,1,'" + txtCantDecimales.Value.ToString + "')"
                GuardarDatos()
                UltCompra()
                SetSecondID()
                InsertArticulos()
                CalcularBalances()
                ActualizarCostos()
                CalcularInventarios()
                ActualizarUltimoSuplidor()
                MoverFichero()
                frm_aumento_precios_dinamico.ShowDialog(Me)
                CerrarOrden()

                ToastNotificationsManager1.Notifications(0).Body = "La compra " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                If DTConfiguracion.Rows(164 - 1).Item("Value2Int") = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Dim AvisoInconsistencia = DTConfiguracion.Rows(9 - 1).Item("Value2Int")

                If DTConfiguracion.Rows(9 - 1).Item("Value2Int") = 1 Then
                    If ImponerEscrituradeNCF = 1 Then
                        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                        Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                        Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                        If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                            If Not AccionesModulosAutorizadas.Contains("99") Then
                                ControlSuperClave = 1
                                MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_superclave.IDAccion.Text = 99
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                SetTipoItbis()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='" + lblTipoItbis.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + LUEAlmacen.EditValue.ToString + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(txtDescuento.Text).ToString + "',ITBIS='" + CDbl(txtItbis.Text).ToString + "',Descuento2='" + CDbl(txtDescuento2.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDEmpleadoRec='" + txtRecepcion.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='" + chkpreciosdiferidos.Tag.ToString + "',CreditoPendiente='" + chkcreditospendientes.Tag.ToString + "',ArticuloFuera='" + chkArtfuerapedido.Tag.ToString + "',NegociarFlete='" + chkrenegociarflete.Tag.ToString + "',Averiados='" + chkAveriados.Tag.ToString + "',DescuentoAlPago='" + chkDescuentoPago.Tag.ToString + "',IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDMoneda='" + LueMoneda.EditValue.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                InsertArticulos()
                CalcularBalances()
                ActualizarCostos()
                CalcularInventarios()
                MoverFichero()

                ToastNotificationsManager1.Notifications(1).Body = "La compra " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                If DTConfiguracion.Rows(164 - 1).Item("Value2Int") = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione un suplidor para visualizar el historial de las facturas.", "Seleccione un Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_suplidor.ShowDialog(Me)

            If txtIDSuplidor.Text = "" Then
            Else
                frm_historial_suplidor.ShowDialog(Me)
            End If

        Else
            frm_historial_suplidor.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor de la factura a procesar.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtNoFact.Text = "" Then
            MessageBox.Show("Escriba el No. de la Factura de compra.", "No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoFact.Focus()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante de la factura de compra.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf TablaCompras.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar la compra.", "Insertar los artículos de la compra", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            Exit Sub
        ElseIf txtRecepcion.Text = "" Then
            frm_contraseña_empleado.Show(Me)
            If txtRecepcion.Text = "" Then
                MessageBox.Show("Seleccione el empleado que recibió la factura.", "Empleado en Recepción y/o Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtRecepcion.Focus()
                Exit Sub
            End If
        End If


        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de compra No. " & txtIDCompra.Text & " del suplidor " & txtNombreSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 100
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = False
                SetTipoItbis()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='" + lblTipoItbis.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + LUEAlmacen.EditValue.ToString + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(txtDescuento.Text).ToString + "',ITBIS='" + CDbl(txtItbis.Text).ToString + "',Descuento2='" + CDbl(txtDescuento2.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDEmpleadoRec='" + txtRecepcion.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='" + chkpreciosdiferidos.Tag.ToString + "',CreditoPendiente='" + chkcreditospendientes.Tag.ToString + "',ArticuloFuera='" + chkArtfuerapedido.Tag.ToString + "',NegociarFlete='" + chkrenegociarflete.Tag.ToString + "',Averiados='" + chkAveriados.Tag.ToString + "',DescuentoAlPago='" + chkDescuentoPago.Tag.ToString + "',IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDMoneda='" + LueMoneda.EditValue.ToString + "',Tasa='" + CDbl(txtTasa.Text).ToString + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                CalcularBalances()
                CalcularInventarios()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCompra.Text = "" Then
            MessageBox.Show("No hay un registro de factura de compra abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la factura de compra No. " & txtIDCompra.Text & " del suplidor " & txtNombreSuplidor.Text & " del sistema?", "Anular Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 101
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = True
                SetTipoItbis()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='" + lblTipoItbis.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + LUEAlmacen.EditValue.ToString + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(txtDescuento.Text).ToString + "',ITBIS='" + CDbl(txtItbis.Text).ToString + "',Descuento2='" + CDbl(txtDescuento2.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',IDEmpleadoRec='" + txtRecepcion.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='" + chkpreciosdiferidos.Tag.ToString + "',CreditoPendiente='" + chkcreditospendientes.Tag.ToString + "',ArticuloFuera='" + chkArtfuerapedido.Tag.ToString + "',NegociarFlete='" + chkrenegociarflete.Tag.ToString + "',Averiados='" + chkAveriados.Tag.ToString + "',DescuentoAlPago='" + chkDescuentoPago.Tag.ToString + "',IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDMoneda='" + LueMoneda.EditValue.ToString + "',Tasa='" + CDbl(txtTasa.Text).ToString + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                CalcularBalances()
                CalcularInventarios()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub CalcularInventarios()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        If txtIDArticulo.Focused = False Then
            txtIDArticulo.Focus()
        Else
            txtIDArticulo.Focus()
            frm_buscar_mant_articulos.ShowDialog(Me)
        End If
    End Sub


    Private Sub txtNCF_Leave(sender As Object, e As EventArgs) Handles txtNCF.Leave
        If CbxTipoComprobante.Text <> "" Then

            If txtNCF.MaskFull = False And ImponerEscrituradeNCF = 1 Then
                MessageBox.Show("No se ha completado la numeración del comprobante fiscal de la factura de compra. Por favor complete el registro.", "Numeración no completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                txtNCF.Text = txtNCF.Text.ToUpper
            End If
        End If

    End Sub

    Private Sub IrAArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
        frm_mant_articulos.txtIDProducto.Text = GridView1.GetFocusedRowCellValue("IDArticulo").ToString
        frm_mant_articulos.FillAllDatafromID()

    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub chkDescuentoPago_CheckedChanged(sender As Object, e As EventArgs) Handles chkDescuentoPago.CheckedChanged
        If chkDescuentoPago.Checked = True Then
            chkDescuentoPago.Tag = 1
        Else
            chkDescuentoPago.Tag = 0
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub chkpreciosdiferidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkpreciosdiferidos.CheckedChanged
        If chkpreciosdiferidos.Checked = True Then
            chkpreciosdiferidos.Tag = 1
        Else
            chkpreciosdiferidos.Tag = 0
        End If
    End Sub

    Private Sub chkcreditospendientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkcreditospendientes.CheckedChanged
        If chkcreditospendientes.Checked = True Then
            chkcreditospendientes.Tag = 1
        Else
            chkcreditospendientes.Tag = 0
        End If
    End Sub

    Private Sub chkArtfuerapedido_CheckedChanged(sender As Object, e As EventArgs) Handles chkArtfuerapedido.CheckedChanged
        If chkArtfuerapedido.Checked = True Then
            chkArtfuerapedido.Tag = 1
        Else
            chkArtfuerapedido.Tag = 0
        End If
    End Sub

    Private Sub edtTo_ValidateToken(sender As Object, e As DevExpress.XtraEditors.TokenEditValidateTokenEventArgs) Handles edtTo.ValidateToken
        e.IsValid = MailRegex.IsMatch(e.Description)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        If My.Computer.Network.IsAvailable = True Then

            If edtTo.GetTokenList.Count = 0 Then
                MessageBox.Show("Escriba al menos una dirección de correo electrónico de destinatario(s) para enviar los datos de este registro.", "No hay destinatarios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Dim Envios As New SmtpClient
            Dim Correos As New MailMessage
            Dim ReportPath As String

            Correos.To.Clear()
            Correos.Subject = "Registro de compras"
            Correos.IsBodyHtml = True
            Correos.Body = "<ul> <li>Raz&oacute;n Social: " & frm_inicio.lblRazon.Text & "</li> <li>Teminal: " & frm_inicio.Button4.Text & "</li> </ul><p>Notificamos el registro de la factura de compra No. <strong>" + txtNoFact.Text + "&nbsp;</strong>de fecha " + DtpFechaFact.Value.ToString("dd/MM/yyyy") + " del suplidor " + txtNombreSuplidor.Text + ", por un valor de " + txtNeto.Text + ".</p> <p>Este registro se encuentra guardado con el ID # <strong>" + txtSecondID.Text + "</strong>.</p><p>&nbsp;Este correo ha remitido por <strong>" + frm_inicio.lblNombre.Text + "</strong>.</p> <hr /> <p>Este mensaje ha sido enviado desde @<em><strong>Libregco</strong></em>.</p>"
            Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
            Correos.Priority = System.Net.Mail.MailPriority.Normal

            For Each st As String In edtTo.EditValue
                Correos.To.Add(Trim(String.Format(st)))
            Next

            If chkEnviarCopiaDigital.Checked = True Then
                Dim Attach As New System.Net.Mail.Attachment(RutaDocumento.Text)
                Correos.Attachments.Add(Attach)
            End If

            If chkEnviarReporte.Checked = True Then
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim crParameterFiledDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterRangeValue As ParameterRangeValue
                Dim ObjRpt As New ReportDocument

                'Buscar ubicacion del reporte
                Dim CompraReportPath As String
                Con.Open()
                cmd = New MySqlCommand("Select Path FROM" & SysName.Text & "reportes where IDReportes=72", Con)
                CompraReportPath = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                'Selecciono el tipo de conexion
                If TypeConnection.Text = 1 Then
                    ObjRpt.Load("\\" & PathServidor.Text & CompraReportPath)
                Else
                    ObjRpt.Load("C:" & CompraReportPath.Replace("\Libregco\Libregco.net", ""))
                End If

                'Limpio los antiguos parametros
                crParameterValues.Clear()

                crParameterDiscreteValue.Value = txtIDCompra.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Despues de cargados los datos, las opciones del PDF por DEfault
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                CrDiskFileDestinationOptions.DiskFileName = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
                ReportPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
                CrExportOptions = ObjRpt.ExportOptions

                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .ExportDestinationOptions = CrDiskFileDestinationOptions
                    .ExportFormatOptions = CrFormatTypeOtions
                End With

                ObjRpt.Export()

                Dim Attach As New System.Net.Mail.Attachment(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf")
                Correos.Attachments.Add(Attach)
            End If

            'Envio del correo
            Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
            Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

            Envios.Host = "smtp.gmail.com"
            Envios.Port = 587
            Envios.EnableSsl = True
            Envios.Send(Correos)


            Envios.Dispose()
            Correos.Dispose()

            If System.IO.File.Exists(ReportPath) = True Then
                System.IO.File.Delete(ReportPath)
            End If

            Dim NotificacionMessage As New NotifyIcon
            NotificacionMessage.Icon = SystemIcons.Application
            NotificacionMessage.BalloonTipIcon = ToolTipIcon.Info
            NotificacionMessage.Visible = True


            With NotificacionMessage
                .Text = "El correo ha sido enviado exitosamente."
                .BalloonTipTitle = "Correo enviado"
                .BalloonTipText = "El correo ha sido enviado exitosamente."
                .ShowBalloonTip(2000)
            End With

            NotificacionMessage.Dispose()


            'MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Else
            MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub txtIDRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNCF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCF.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "AB0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkrenegociarflete_CheckedChanged(sender As Object, e As EventArgs) Handles chkrenegociarflete.CheckedChanged
        If chkrenegociarflete.Checked = True Then
            chkrenegociarflete.Tag = 1
        Else
            chkrenegociarflete.Tag = 0
        End If
    End Sub

    Private Sub chkAveriados_CheckedChanged(sender As Object, e As EventArgs) Handles chkAveriados.CheckedChanged
        If chkAveriados.Checked = True Then
            chkAveriados.Tag = 1
        Else
            chkAveriados.Tag = 0
        End If
    End Sub

    Private Sub txtIDArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIDArticulo.Text <> "" Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtIDArticulo.Text <> "" Then
                If txtIDArticulo.SelectionStart = txtIDArticulo.TextLength Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub CbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtCantidadArticulo.Focus()
            txtCantidadArticulo.SelectAll()

        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then

            If txtCantidadArticulo.SelectionStart = 0 Then
                e.Handled = True
                If txtDescripcionArticulo.Enabled = True Then
                    txtDescripcionArticulo.Focus()
                    txtDescripcionArticulo.SelectAll()
                Else
                    e.Handled = True
                    txtIDArticulo.Focus()
                    txtIDArticulo.SelectAll()
                End If
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            End If

        ElseIf e.KeyCode = Keys.Up Then
            txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) + 1
            txtCantidadArticulo.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            If CDbl(txtCantidadArticulo.Text) > 1 Then
                txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) - 1
                txtCantidadArticulo.SelectAll()
            End If

        End If
    End Sub

    Private Sub txtDescripcionArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcionArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtDescripcionArticulo.SelectionStart = 0 Then
                txtIDArticulo.Focus()
                txtIDArticulo.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtDescripcionArticulo.SelectionStart = txtDescripcionArticulo.TextLength Then
                e.Handled = True
                txtCantidadArticulo.Focus()
                txtCantidadArticulo.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtDescuentoAplicado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuentoAplicado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtDescuentoAplicado.SelectionStart = 0 Then
                txtPrecio.Focus()
                txtPrecio.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtDescuentoAplicado.SelectionStart = txtDescuentoAplicado.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub frm_registro_compras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.End Then
            e.Handled = True
            btnGuardaryLimpiar.PerformClick()

        ElseIf e.KeyCode = Keys.Escape Then
            If txtIDCompra.Text = "" Then
                If TablaCompras.Rows.Count > 0 Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario de registro de compras?", "Cerrar formulario de compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result1 = MsgBoxResult.Yes Then
                        Me.Close()
                    End If
                End If
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cerrar el formulario de registro de compras?", "Cierre de registros de compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Me.Close()
                End If

            End If
        End If
    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnActualizarDescripcion.Click
        If btnActualizarDescripcion.Text = "Actualizar" Then
            btnActualizarDescripcion.Text = "Guardar"

            txtDescripcionArticulo.Enabled = True
            txtDescripcionArticulo.Focus()
            txtDescripcionArticulo.SelectAll()

        Else
            ConLibregco.Open()
            sqlQ = "UPDATE Articulos SET Descripcion='" + txtDescripcionArticulo.Text + "' WHERE IDArticulo= (" + txtIDArticulo.Text + ")"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))
            btnActualizarDescripcion.Text = "Actualizar"

            txtDescripcionArticulo.Enabled = False

            txtPrecio.Focus()
        End If
    End Sub

    Private Sub txtPrecio3_Leave(sender As Object, e As EventArgs) Handles txtPrecioC.Leave
        If txtPrecioC.Text = "" Then
            txtPrecioC.Text = (0).ToString("C" & txtCantDecimales.Value)
        Else
            txtPrecioC.Text = CDbl(txtPrecioC.Text).ToString("C" & txtCantDecimales.Value)

            CalcDifs()
        End If
    End Sub

    Private Sub txtPrecioContado_Leave(sender As Object, e As EventArgs) Handles txtPrecioB.Leave
        Try
            If txtPrecioB.Text = "" Then
                txtPrecioB.Text = (0).ToString("C" & txtCantDecimales.Value)
            Else
                txtPrecioB.Text = CDbl(txtPrecioB.Text).ToString("C" & txtCantDecimales.Value)

                CalcDifs()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtDescripcionArticulo.Text = "" Then
            MessageBox.Show("Seleccione un artículo para actualizar los precios y costos.", "Seleccionar artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            XtraTabControl1.SelectedTabPageIndex = 0
            txtIDArticulo.Focus()
            Exit Sub
        ElseIf txtCosto.Text = "" Then
            MessageBox.Show("Defina el costo del artículo.", "Costo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCosto.Focus()
            Exit Sub
        ElseIf txtCostoFinal.Text = "" Then
            MessageBox.Show("Defina el costo final del artículo.", "Costo Final", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCostoFinal.Focus()
            Exit Sub
        ElseIf txtPrecioB.Text = "" Or txtPrecioB.Text = CDbl(0).ToString("C" & txtCantDecimales.Value) Then
            MessageBox.Show("Especifique el precio de contado del artículo.", "Precio de Contado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioB.Focus()
            Exit Sub
        ElseIf txtPrecioA.Text = "" Or txtPrecioA.Text = CDbl(0).ToString("C" & txtCantDecimales.Value) Then
            MessageBox.Show("Especifique el precio de crédito del artículo.", "Precio de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioA.Focus()
            Exit Sub
        ElseIf CDbl(txtPrecioA.Text) < CDbl(txtPrecioB.Text) Then
            MessageBox.Show("El precio de contado es menor que el precio de crédito. Verifique los cálculos aplicados.", "Precio Contado menor que Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrecioB.Focus()
            Exit Sub
        ElseIf txtPrecioC.Text = "" Or txtPrecioC.Text = CDbl(0).ToString("C" & txtCantDecimales.Value) Then
            MessageBox.Show("Escriba y/o establezca el precio especial de nivel 3.", "Precio de nivel 3", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioC.Focus()
            Exit Sub
        ElseIf txtPrecioD.Text = "" Or txtPrecioD.Text = CDbl(0).ToString("C" & txtCantDecimales.Value) Then
            MessageBox.Show("Escriba y/o establezca el precio especial de nivel 4.", "Precio de nivel 4", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioD.Focus()
            Exit Sub
        End If

        ConLibregco.Open()
        sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(txtCosto.Text).ToString + "',CostoFinal='" + CDbl(txtCostoFinal.Text).ToString + "',PrecioContado='" + CDbl(txtPrecioB.Text).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.Text).ToString + "',Precio3='" + CDbl(txtPrecioC.Text).ToString + "',Precio4='" + CDbl(txtPrecioD.Text).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.Text)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio.Text + ")"
        cmd = New MySqlCommand(sqlQ, ConLibregco)
        cmd.ExecuteNonQuery()
        ConLibregco.Close()

        ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))

        XtraTabControl1.SelectedTabPageIndex = 0
    End Sub

    Private Sub txtPrecioA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioA.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecioB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioB.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecioC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioC.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecioD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioD.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCosto_TextChanged(sender As Object, e As EventArgs) Handles txtCosto.TextChanged
        If Len(txtCosto.Text) = 0 Then
            txtCosto.Text = 0
            txtCosto.SelectAll()
        End If
    End Sub

    Private Sub txtCostoFinal_TextChanged(sender As Object, e As EventArgs) Handles txtCostoFinal.TextChanged
        If Len(txtCostoFinal.Text) = 0 Then
            txtCostoFinal.Text = 0
            txtCostoFinal.SelectAll()
        End If
    End Sub

    Private Sub txtPrecioA_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioA.TextChanged
        If Len(txtPrecioA.Text) = 0 Then
            txtPrecioA.Text = 0
            txtPrecioA.SelectAll()
        End If
    End Sub

    Private Sub txtPrecioB_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioB.TextChanged
        If Len(txtPrecioB.Text) = 0 Then
            txtPrecioB.Text = 0
            txtPrecioB.SelectAll()
        End If
    End Sub

    Private Sub txtPrecioC_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioC.TextChanged
        If Len(txtPrecioC.Text) = 0 Then
            txtPrecioC.Text = 0
            txtPrecioC.SelectAll()
        End If
    End Sub

    Private Sub txtPrecioD_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioD.TextChanged
        If Len(txtPrecioD.Text) = 0 Then
            txtPrecioD.Text = 0
            txtPrecioD.SelectAll()
        End If
    End Sub


    Private Sub TabPane1_SelectedPageIndexChanged(sender As Object, e As EventArgs) Handles XtraTabControl1.SelectedPageChanged
        Try

            If XtraTabControl1.SelectedTabPage.TabIndex = 2 Then

                'Limite de Consulta
                Dim LimitValue As New Label

                LimitValue.Text = DTConfiguracion.Rows(28 - 1).Item("Value2Int")

                DgvHistorialArt.Rows.Clear()

                If ConMixta.State = ConnectionState.Open Then
                    ConMixta.Close()
                End If

                ConMixta.Open()

                '''''''''Z
                '''''Anexo de Compras
                Dim AnexoCompraDetalle As New MySqlCommand("Select Compras.SecondID,FechaFactura,Hora,Suplidor,(Cantidad * Contenido) as Resultado,Importe from Libregco.detallecompra INNER JOIN Libregco.compras on detallecompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios WHERE DetalleCompra.IDArticulo='" + txtIDArticulo.Text + "' and Compras.Nulo=0", ConMixta)
                Dim Lector As MySqlDataReader = AnexoCompraDetalle.ExecuteReader

                While Lector.Read
                    DgvHistorialArt.Rows.Add(Lector.GetValue(0), CDate(Lector.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(2)), "Compra", Lector.GetValue(3).ToString.ToUpper, Lector.GetValue(4), "", "", Lector.GetValue(5))
                End While
                Lector.Close()



                ''''''Anexo de Ventas
                Dim AnexoVentasDetalle As New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,FacturaDatos.NombreFactura,(Cantidad * Contenido) as Resultado,Importe from Libregco.facturaarticulos INNER JOIN Libregco.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDArticulo.Text + "' and FacturaDatos.Nulo=0", ConMixta)
                Dim Lector1 As MySqlDataReader = AnexoVentasDetalle.ExecuteReader

                While Lector1.Read
                    DgvHistorialArt.Rows.Add(Lector1.GetValue(0), CDate(Lector1.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector1.GetValue(2)), "Venta", Lector1.GetValue(3).ToString.ToUpper, "", Lector1.GetValue(4), "", Lector1.GetValue(5))
                End While
                Lector1.Close()



                ''''''Ajuste de Entrada
                Dim AnexoAjusteEntrada As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE Movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and Movimientoinventario.IDTipodeAjuste=1 and Movimientoinventario.Nulo=0", ConMixta)
                Dim Lector2 As MySqlDataReader = AnexoAjusteEntrada.ExecuteReader

                While Lector2.Read
                    DgvHistorialArt.Rows.Add(Lector2.GetValue(0), CDate(Lector2.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector2.GetValue(2)), "Ajuste", "AJUSTE DE ENTRADA", Lector2.GetValue(3), "", "", Lector2.GetValue(4))
                End While
                Lector2.Close()


                ''''''Ajuste de Salida
                Dim AnexoAjusteSalida As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios where movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and movimientoinventario.IDTipodeAjuste=2 and movimientoinventario.Nulo=0", ConMixta)
                Dim Lector3 As MySqlDataReader = AnexoAjusteSalida.ExecuteReader

                While Lector3.Read
                    DgvHistorialArt.Rows.Add(Lector3.GetValue(0), CDate(Lector3.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector3.GetValue(2)), "Ajuste", "AJUSTE DE SALIDA", "", Lector3.GetValue(3), "", Lector3.GetValue(4))
                End While
                Lector3.Close()


                ''''''Devoluciones de Venta
                Dim AnexoDevolucionesVenta As New MySqlCommand("Select DevolucionVenta.SecondID,DevolucionVenta.Fecha,DevolucionVenta.Hora,Clientes.Nombre,(CantDevuelta * Contenido) as Resultado,PrecioDevuelto from Libregco.Devolucionventadetalle INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + txtIDArticulo.Text + "' and CantDevuelta>0 and DevolucionVenta.Nulo=0", ConMixta)
                Dim Lector4 As MySqlDataReader = AnexoDevolucionesVenta.ExecuteReader

                While Lector4.Read
                    DgvHistorialArt.Rows.Add(Lector4.GetValue(0), CDate(Lector4.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector4.GetValue(2)), "Dev. Venta", Lector4.GetValue(3).ToString.ToUpper, Lector4.GetValue(4), "", "", Lector4.GetValue(5))
                End While
                Lector4.Close()

                ''''''Inventario Inicial
                Dim AnexoInventarioInicial As New MySqlCommand("Select MovimientoInventario.SecondID,Movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.PrecioArticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios where movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and movimientoinventario.IDTipodeAjuste=3 and movimientoinventario.Nulo=0", ConMixta)
                Dim Lector5 As MySqlDataReader = AnexoInventarioInicial.ExecuteReader

                While Lector5.Read
                    DgvHistorialArt.Rows.Add(Lector5.GetValue(0), CDate(Lector5.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector5.GetValue(2)), "Ajuste", "INVENTARIO INICIAL", Lector5.GetValue(3), "", "", Lector5.GetValue(4))
                End While
                Lector5.Close()


                ''''''Devoluciones de Compras
                Dim AnexoDevolucionesCompra As New MySqlCommand("Select DevolucionCompra.SecondID,DevolucionCompra.Fecha,DevolucionCompra.Hora,Suplidor.Suplidor,(CantDevuelta * Contenido) as Resultado,PrecioDevuelto from Libregco.DevolucionCompraDetalle INNER JOIN Libregco.DevolucionCompra on DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE DevolucionCompraDetalle.IDArticulo='" + txtIDArticulo.Text + "' and DevolucionCompra.Nulo=0", ConMixta)
                Dim Lector6 As MySqlDataReader = AnexoDevolucionesCompra.ExecuteReader

                While Lector6.Read
                    DgvHistorialArt.Rows.Add(Lector6.GetValue(0), CDate(Lector6.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector6.GetValue(2)), "Dev. Compra", Lector6.GetValue(3).ToString.ToUpper, "", Lector6.GetValue(4), "", Lector6.GetValue(5))
                End While
                Lector6.Close()

                ''''''Reparaciones no procesadas
                Dim AnexoReparaciones As New MySqlCommand("Select Reparacion.SecondID,Reparacion.Fecha,Reparacion.Hora,Suplidor.Suplidor,(Cantidad*Contenido) as Resultado,0 from Libregco. ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.PrecioArticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios Where ReparacionDetalle.IDArticulo='" + txtIDArticulo.Text + "' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0", ConMixta)
                Dim Lector7 As MySqlDataReader = AnexoReparaciones.ExecuteReader

                While Lector7.Read
                    DgvHistorialArt.Rows.Add(Lector7.GetValue(0), CDate(Lector7.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector7.GetValue(2)), "Cond. Emitido", Lector7.GetValue(3).ToString.ToUpper, "", Lector7.GetValue(4), "", "N/A")
                End While
                Lector7.Close()

                ''''''Entradas de reparaciones
                Dim AnexoEntradaReparaciones As New MySqlCommand("Select EntradaReparacion.SecondID,EntradaReparacion.Fecha,EntradaReparacion.Hora,Suplidor.Suplidor,0,(CantidadRecibida * Contenido) as Resultado from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + txtIDArticulo.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConMixta)
                Dim Lector71 As MySqlDataReader = AnexoEntradaReparaciones.ExecuteReader

                While Lector71.Read
                    DgvHistorialArt.Rows.Add(Lector71.GetValue(0), CDate(Lector71.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector71.GetValue(2)), "Cond. Recibido", Lector71.GetValue(3).ToString.ToUpper, Lector71.GetValue(5), "", "", "N/A")
                End While
                Lector71.Close()



                ''''''''''''''''''''''''''''''A
                '''''Anexo de Compras
                Dim AnexoCompraDetalle1 As New MySqlCommand("Select Compras.SecondID,FechaFactura,Hora,Suplidor,(Cantidad * Contenido) as Resultado,Importe from Libregco_Main.detallecompra INNER JOIN Libregco_Main.compras on detallecompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios WHERE DetalleCompra.IDArticulo='" + txtIDArticulo.Text + "' and Compras.Nulo=0", ConMixta)
                Dim Lector8 As MySqlDataReader = AnexoCompraDetalle1.ExecuteReader

                While Lector8.Read
                    DgvHistorialArt.Rows.Add(Lector8.GetValue(0), CDate(Lector8.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector8.GetValue(2)), "Compra", Lector8.GetValue(3).ToString.ToUpper, Lector8.GetValue(4), "", "", Lector8.GetValue(5))
                End While
                Lector8.Close()

                ''''''Anexo de Ventas
                Dim AnexoVentasDetalle1 As New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,FacturaDatos.NombreFactura,(Cantidad * Contenido) as Resultado,Importe from Libregco_Main.facturaarticulos INNER JOIN Libregco_Main.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDArticulo.Text + "' and FacturaDatos.Nulo=0", ConMixta)
                Dim Lector9 As MySqlDataReader = AnexoVentasDetalle1.ExecuteReader

                While Lector9.Read
                    DgvHistorialArt.Rows.Add(Lector9.GetValue(0), CDate(Lector9.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector9.GetValue(2)), "Venta", Lector9.GetValue(3).ToString.ToUpper, "", Lector9.GetValue(4), "", Lector9.GetValue(5))
                End While
                Lector9.Close()

                ''''''Ajuste de Entrada
                Dim AnexoAjusteEntrada1 As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE Movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and Movimientoinventario.IDTipodeAjuste=1 and Movimientoinventario.Nulo=0", ConMixta)
                Dim Lector10 As MySqlDataReader = AnexoAjusteEntrada1.ExecuteReader

                While Lector10.Read
                    DgvHistorialArt.Rows.Add(Lector10.GetValue(0), CDate(Lector10.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector10.GetValue(2)), "Ajuste", "AJUSTE DE ENTRADA", Lector10.GetValue(3), "", "", Lector10.GetValue(4))
                End While
                Lector10.Close()

                ''''''Ajuste de Salida
                Dim AnexoAjusteSalida1 As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios where movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and movimientoinventario.IDTipodeAjuste=2 and movimientoinventario.Nulo=0", ConMixta)
                Dim Lector11 As MySqlDataReader = AnexoAjusteSalida1.ExecuteReader

                While Lector11.Read
                    DgvHistorialArt.Rows.Add(Lector11.GetValue(0), CDate(Lector11.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector11.GetValue(2)), "Ajuste", "AJUSTE DE SALIDA", "", Lector11.GetValue(3), "", Lector11.GetValue(4))
                End While
                Lector11.Close()

                ''''''Devoluciones de Venta
                Dim AnexoDevolucionesVenta1 As New MySqlCommand("Select DevolucionVenta.SecondID,DevolucionVenta.Fecha,DevolucionVenta.Hora,Clientes.Nombre,(CantDevuelta * Contenido) as Resultado,PrecioDevuelto from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco_Main. FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + txtIDArticulo.Text + "' and CantDevuelta>0 and DevolucionVenta.Nulo=0", ConMixta)
                Dim Lector12 As MySqlDataReader = AnexoDevolucionesVenta1.ExecuteReader

                While Lector12.Read
                    DgvHistorialArt.Rows.Add(Lector12.GetValue(0), CDate(Lector12.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector12.GetValue(2)), "Dev. Venta", Lector12.GetValue(3).ToString.ToUpper, Lector12.GetValue(4), "", "", Lector12.GetValue(5))
                End While
                Lector12.Close()

                ''''''Inventario Inicial
                Dim AnexoInventarioInicial1 As New MySqlCommand("Select MovimientoInventario.SecondID,Movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.PrecioArticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios where movimientoinvdetalle.IDArticulo='" + txtIDArticulo.Text + "' and movimientoinventario.IDTipodeAjuste=3 and movimientoinventario.Nulo=0", ConMixta)
                Dim Lector13 As MySqlDataReader = AnexoInventarioInicial1.ExecuteReader

                While Lector13.Read
                    DgvHistorialArt.Rows.Add(Lector13.GetValue(0), CDate(Lector13.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector13.GetValue(2)), "Ajuste", "INVENTARIO INICIAL", Lector13.GetValue(3), "", "", Lector13.GetValue(4))
                End While
                Lector13.Close()

                ''''''Devoluciones de Compras
                Dim AnexoDevolucionesCompra1 As New MySqlCommand("Select DevolucionCompra.SecondID,DevolucionCompra.Fecha,DevolucionCompra.Hora,Suplidor.Suplidor,(CantDevuelta * Contenido) as Resultado,PrecioDevuelto from Libregco_Main.DevolucionCompraDetalle INNER JOIN Libregco_Main.DevolucionCompra on DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco_Main.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE DevolucionCompraDetalle.IDArticulo='" + txtIDArticulo.Text + "' and DevolucionCompra.Nulo=0", ConMixta)
                Dim Lector14 As MySqlDataReader = AnexoDevolucionesCompra1.ExecuteReader

                While Lector14.Read
                    DgvHistorialArt.Rows.Add(Lector14.GetValue(0), CDate(Lector14.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector14.GetValue(2)), "Dev. Compra", Lector14.GetValue(3).ToString.ToUpper, "", Lector14.GetValue(4), "", Lector14.GetValue(5))
                End While
                Lector14.Close()

                ''''''Reparaciones no procesadas
                Dim AnexoReparaciones1 As New MySqlCommand("Select Reparacion.SecondID,Reparacion.Fecha,Reparacion.Hora,Suplidor.Suplidor,(Cantidad*Contenido) as Resultado,0 from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.PrecioArticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios Where ReparacionDetalle.IDArticulo='" + txtIDArticulo.Text + "' and Reparacion.IDStatusReparacion=1 and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0", ConMixta)
                Dim Lector15 As MySqlDataReader = AnexoReparaciones1.ExecuteReader

                While Lector15.Read
                    DgvHistorialArt.Rows.Add(Lector15.GetValue(0), CDate(Lector15.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector15.GetValue(2)), "Cond. Emitido", Lector15.GetValue(3).ToString.ToUpper, "", Lector15.GetValue(5), "", "N/A")
                End While
                Lector15.Close()

                ''''''Entradas de reparaciones
                Dim AnexoEntradaReparaciones1 As New MySqlCommand("Select EntradaReparacion.SecondID,EntradaReparacion.Fecha,EntradaReparacion.Hora,Suplidor.Suplidor,0,(CantidadRecibida * Contenido) as Resultado from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + txtIDArticulo.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConMixta)
                Dim Lector712 As MySqlDataReader = AnexoEntradaReparaciones1.ExecuteReader

                While Lector712.Read
                    DgvHistorialArt.Rows.Add(Lector712.GetValue(0), CDate(Lector712.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector712.GetValue(2)), "Cond. Recibido", Lector712.GetValue(3).ToString.ToUpper, Lector712.GetValue(5), "", "", "N/A")
                End While
                Lector712.Close()

                ConMixta.Close()

                If DgvHistorialArt.Rows.Count > 0 Then
                    DgvHistorialArt.Sort(DgvHistorialArt.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                End If

                ConMixta.Close()
                CalcAcumulado()
                DgvHistorialArt.ClearSelection()


            End If

        Catch ex As Exception
            If ConMixta.State = ConnectionState.Open Then
                ConMixta.Close()
            End If

            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CalcAcumulado()
        Dim Suma, Resta, Total As New Label
        Dim x As Integer

        Total.Text = CDbl(0)

Inicio:
        If x = DgvHistorialArt.Rows.Count Then
            GoTo Fin
        End If

        Suma.Text = DgvHistorialArt.Rows(x).Cells(4).Value
        Resta.Text = DgvHistorialArt.Rows(x).Cells(5).Value

        If Suma.Text = "" Then
            Suma.Text = CDbl(0)
        Else
            Suma.Text = CDbl(Suma.Text)
        End If

        If Resta.Text = "" Then
            Resta.Text = CDbl(0)
        Else
            Resta.Text = CDbl(Resta.Text)
        End If

        Total.Text = CDbl(Total.Text) + CDbl(Suma.Text) - CDbl(Resta.Text)
        DgvHistorialArt.Rows(x).Cells(6).Value = CDbl(Total.Text)

        x = x + 1
        GoTo Inicio
Fin:
    End Sub

    Private Sub CalcDifs()
        lblDifCosto.Text = GetPorcentajeDif(CDbl(txtCosto.Text), CDbl(txtUltimoCosto.Text), lblDifCosto)
        lblDifCostoFinal.Text = GetPorcentajeDif(CDbl(txtCostoFinal.Text), CDbl(txtUltimoCostoFInal.Text), lblDifCostoFinal)

        lblDifPrecioA.Text = GetPorcentajeDif(CDbl(txtPrecioA.Text), CDbl(txtUltimoPrecioA.Text), lblDifPrecioA)
        lblBeneficioA.Text = GetPorcentajeDif(CDbl(txtPrecioA.Text), CDbl(txtCosto.Text), lblBeneficioA)


        lblDifPrecioB.Text = GetPorcentajeDif(CDbl(txtPrecioB.Text), CDbl(txtUltimoPrecioB.Text), lblDifPrecioB)
        lblBeneficioB.Text = GetPorcentajeDif(CDbl(txtPrecioB.Text), CDbl(txtCosto.Text), lblBeneficioB)

        lblDifPrecioC.Text = GetPorcentajeDif(CDbl(txtPrecioC.Text), CDbl(txtUltimoPrecioC.Text), lblDifPrecioC)
        lblBeneficioC.Text = GetPorcentajeDif(CDbl(txtPrecioC.Text), CDbl(txtCosto.Text), lblBeneficioC)

        lblDifPrecioD.Text = GetPorcentajeDif(CDbl(txtPrecioD.Text), CDbl(txtUltimoPrecioD.Text), lblDifPrecioD)
        lblBeneficioD.Text = GetPorcentajeDif(CDbl(txtPrecioD.Text), CDbl(txtCosto.Text), lblBeneficioD)
    End Sub

    Private Sub AnexarImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnexarImagenToolStripMenuItem.Click
        If TypeConnection.Text = 1 Then
            Dim OfdImagen As New OpenFileDialog
            Dim Exists As Boolean
            Dim RutaDestino As String
            Dim UltNum As Double

            With OfdImagen
                .RestoreDirectory = True
                .Title = "Buscar imagen de artículo"
                .Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
                .FileName = ""
                .Multiselect = True
            End With

            If OfdImagen.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                OfdImagen.Multiselect = False

                For Each itm In OfdImagen.FileNames
                    Exists = File.Exists(itm)

                    If Exists = True Then
                        ConLibregco.Open()
                        cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco' AND table_name='Articulos_fotos'", ConLibregco)
                        UltNum = Convert.ToDouble(cmd.ExecuteScalar())
                        ConLibregco.Close()

                        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\" & "ART-" & GridView1.GetFocusedRowCellValue("IDArticulo").ToString & " R#" & UltNum & ".png"

                        If RutaDestino <> itm Then
                            My.Computer.FileSystem.MoveFile(itm, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            itm = RutaDestino


                            sqlQ = "INSERT INTO Libregco.Articulos_fotos (IDArticulo,Descripcion,Orden,RutaImagen) VALUES ('" + GridView1.GetFocusedRowCellValue("IDArticulo").ToString + "','','0','" + Replace(RutaDestino, "\", "\\") + "')"
                            ConLibregco.Open()
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                            ConLibregco.Close()

                            SetDefaultPhoto(GridView1.GetFocusedRowCellValue("IDArticulo"))

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            GridView1.SetFocusedRowCellValue("Imagen", ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int")))
                            wFile.Close()
                        End If
                    End If
                Next


            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ImpresiónDeEtiquetasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónDeEtiquetasToolStripMenuItem.Click
        If frm_reporte_etiquetas_productos.Visible = True Then
            frm_reporte_etiquetas_productos.Close()
        End If

        frm_reporte_etiquetas_productos.Show(Me)
        frm_reporte_etiquetas_productos.txtIDArticulo.Text = GridView1.GetFocusedRowCellValue("IDArticulo").ToString
        frm_reporte_etiquetas_productos.txtArticulo.Text = GridView1.GetFocusedRowCellValue("Descripcion").ToString
        frm_reporte_etiquetas_productos.FillMedida()
        frm_reporte_etiquetas_productos.cbxTipoPrecio.Text = "Precio A"
        frm_reporte_etiquetas_productos.btnBuscar.PerformClick()
        frm_reporte_etiquetas_productos.txtCantidad.Value = GridView1.GetFocusedRowCellValue("Cantidad").ToString

    End Sub

    Private Sub ChangeTypeofPrice()
        If IsNothing(TablaCompras) Then
        Else
            If TablaCompras.Rows.Count > 0 Then
                For Each rw As DataRow In TablaCompras.Rows
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + rw("IDArticulo").ToString + "'", ConLibregco)
                    Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    Dim Descuento1 As Double

                    If CDbl(rw.Item("PrecioUnitario")) > 0 Then


                        If rdbIncluido.Checked Then
                            Descuento1 = CDbl(rw.Item("Descuento")) / CDbl(rw.Item("PrecioUnitario"))
                            rw.Item("PrecioUnitario") = (CDbl(rw.Item("PrecioUnitario")) / (1 + ItbisC))
                            rw.Item("Descuento") = rw.Item("PrecioUnitario") * Descuento1
                            rw.Item("Descuento2") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento"))) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                            rw.Item("Itbis") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2"))) * ItbisC
                            rw.Item("Importe") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("CostoFinalUnitario") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("ImporteTotal") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis"))) * CDbl(rw.Item("Cantidad"))
                            rw.Item("ItbisTotal") = CDbl(CDbl(rw.Item("Itbis")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("Subtotal") = CDbl(CDbl(rw.Item("PrecioUnitario")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("E/C") = VerificarEntidadCosto(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                            rw.Item("E/V") = VerificarEntidadPrecio(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                            rdbNoItbis.Visible = False

                        ElseIf rdbNoIncluido.Checked Then
                            Descuento1 = CDbl(rw.Item("Descuento")) / CDbl(rw.Item("PrecioUnitario"))
                            rw.Item("PrecioUnitario") = (CDbl(rw.Item("PrecioUnitario")) * (1 + ItbisC))
                            rw.Item("Descuento") = rw.Item("PrecioUnitario") * Descuento1
                            rw.Item("Descuento2") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento"))) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                            rw.Item("Itbis") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2"))) * ItbisC
                            rw.Item("Importe") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("CostoFinalUnitario") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("ImporteTotal") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis"))) * CDbl(rw.Item("Cantidad"))
                            rw.Item("ItbisTotal") = CDbl(CDbl(rw.Item("Itbis")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("Subtotal") = CDbl(CDbl(rw.Item("PrecioUnitario")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("E/C") = VerificarEntidadCosto(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                            rw.Item("E/V") = VerificarEntidadPrecio(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                            rdbNoItbis.Visible = False

                        ElseIf rdbNoItbis.Checked Then
                            Descuento1 = CDbl(rw.Item("Descuento")) / CDbl(rw.Item("PrecioUnitario"))
                            rw.Item("PrecioUnitario") = CDbl(rw.Item("PrecioUnitario"))
                            rw.Item("Descuento") = rw.Item("PrecioUnitario") * Descuento1
                            rw.Item("Descuento2") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento"))) * CDbl(Replace(txtPorDescuento2.Text, "%", "") / 100)
                            rw.Item("Itbis") = 0
                            rw.Item("Importe") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("CostoFinalUnitario") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis")))
                            rw.Item("ImporteTotal") = (CDbl(rw.Item("PrecioUnitario")) - CDbl(rw.Item("Descuento")) - CDbl(rw.Item("Descuento2")) + CDbl(rw.Item("Itbis"))) * CDbl(rw.Item("Cantidad"))
                            rw.Item("ItbisTotal") = CDbl(CDbl(rw.Item("Itbis")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("Subtotal") = CDbl(CDbl(rw.Item("PrecioUnitario")) * CDbl(rw.Item("Cantidad")))
                            rw.Item("E/C") = VerificarEntidadCosto(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                            rw.Item("E/V") = VerificarEntidadPrecio(CDbl(rw.Item("Importe")), rw.Item("IDPrecio"))
                        End If
                    End If

                Next

            End If
            SumTotales()
            ImporteTotalUnitario()
        End If
    End Sub
    Private Sub rdbIncluido_CheckedChanged(sender As Object, e As EventArgs) Handles rdbIncluido.CheckedChanged
        If rdbIncluido.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub

    Private Sub VerificarSubtotalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarSubtotalesToolStripMenuItem.Click
        frm_subtotales_compras.ShowDialog(Me)
    End Sub

    Sub MostrarControlSubTotales()
        If txtSecondID.Text = "" Then
            VerificarSubtotalesToolStripMenuItem.Visible = False
        Else
            VerificarSubtotalesToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub rdbNoIncluido_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoIncluido.CheckedChanged
        If rdbNoIncluido.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub

    Private Sub Gridview1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub txtCantidadArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadArticulo.TextChanged
        If Len(txtCantidadArticulo.Text) = 0 Then
            txtCantidadArticulo.Text = 1
            txtCantidadArticulo.SelectAll()
        End If

        ImporteTotalUnitario()
    End Sub

    Private Sub txtDescuentoAplicado_TextChanged(sender As Object, e As EventArgs) Handles txtDescuentoAplicado.TextChanged
        If Len(txtDescuentoAplicado.Text) = 0 Then
            txtDescuentoAplicado.Text = 0
            txtDescuentoAplicado.SelectAll()
        End If

        ImporteTotalUnitario()
    End Sub

    Private Sub txtPorDescuento2_TextChanged(sender As Object, e As EventArgs) Handles txtPorDescuento2.TextChanged
        If Len(txtPorDescuento2.Text) = 0 Then
            txtPorDescuento2.Text = 0
            txtPorDescuento2.SelectAll()
        End If

        ImporteTotalUnitario()
    End Sub

    Private Sub txtFlete_TextChanged(sender As Object, e As EventArgs) Handles txtFlete.TextChanged
        If Len(txtFlete.Text) = 0 Then
            txtFlete.Text = 0
            txtFlete.SelectAll()
        End If
        SumTotales()
    End Sub

    Private Sub LUEMoneda_EditValueChanged(sender As Object, e As EventArgs) Handles LueMoneda.EditValueChanged
        If IsNothing(LueMoneda.EditValue) Then
        Else
            If txtIDCompra.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT TasaCompra FROM TipoMoneda WHERE IDTipoMoneda= '" + LueMoneda.EditValue.ToString + "'", ConLibregco)
                txtTasa.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If
        End If

    End Sub

    Private Sub XtraTabControl1_SizeChanged(sender As Object, e As EventArgs) Handles XtraTabControl1.SizeChanged
        If GridControl1.Size.Height > 203 Then
            GridView1.OptionsView.ShowFooter = True
        Else
            GridView1.OptionsView.ShowFooter = False
        End If
    End Sub

    Private Sub Gridview1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Cantidad" Then
                If e.Value.ToString = "" Then
                    GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Cantidad"), 1)
                End If

                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Subtotal"), CDbl(CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Cantidad"))) * CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("PrecioUnitario")))))
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ItbisTotal"), CDbl(CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Cantidad"))) * CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Itbis")))))
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("ImporteTotal"), CDbl(CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Cantidad"))) * CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Importe")))))

            End If
            SumTotales()
        End If
    End Sub

    Sub SumTotales()
        If IsNothing(TablaCompras) Then
        Else
            If TablaCompras.Rows.Count > 0 Then
                Dim SubTotal As Double = 0
                Dim Descuentos As Double = 0
                Dim Descuentos2 As Double = 0
                Dim Itbis As Double = 0

                For Each Rw As DataRow In TablaCompras.Rows
                    SubTotal = SubTotal + (CDbl(Rw.Item("PrecioUnitario")) * (CDbl(Rw.Item("Cantidad"))))
                    Descuentos = Descuentos + (CDbl(Rw.Item("Descuento")) * (CDbl(Rw.Item("Cantidad"))))
                    Descuentos2 = Descuentos2 + (CDbl(Rw.Item("Descuento2")) * (CDbl(Rw.Item("Cantidad"))))
                    Itbis = Itbis + (CDbl(Rw.Item("Itbis")) * (CDbl(Rw.Item("Cantidad"))))
                Next

                txtSubTotal.Text = SubTotal.ToString("C" & txtCantDecimales.Value)
                txtDescuento.Text = Descuentos.ToString("C" & txtCantDecimales.Value)
                txtDescuento2.Text = Descuentos2.ToString("C" & txtCantDecimales.Value)
                txtItbis.Text = Itbis.ToString("C" & txtCantDecimales.Value)
                txtNeto.Text = CDbl(SubTotal - Descuentos - Descuentos2 + Itbis + CDbl(txtFlete.Text)).ToString("C" & txtCantDecimales.Value)

            ElseIf TablaCompras.Rows.Count = 0 Then

                Dim SubTotal As Double = 0
                Dim Descuentos As Double = 0
                Dim Descuentos2 As Double = 0
                Dim SumDes2 As Double = 0
                Dim SumItbis As Double = 0

                txtSubTotal.Text = SubTotal.ToString("C" & txtCantDecimales.Value)
                txtDescuento.Text = Descuentos.ToString("C" & txtCantDecimales.Value)
                txtDescuento2.Text = SumDes2.ToString("C" & txtCantDecimales.Value)
                txtItbis.Text = SumItbis.ToString("C" & txtCantDecimales.Value)
                txtNeto.Text = CDbl(SubTotal - Descuentos - SumDes2 + SumItbis + CDbl(txtFlete.Text)).ToString("C" & txtCantDecimales.Value)
            End If
        End If
    End Sub

    Private Sub Gridview1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim EC As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("E/C"))
            If EC = "El costo no posee variaciones" Then
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
                'e.HighPriority = True

            ElseIf EC.Contains("aumentado") Then
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.Salmon
                'e.HighPriority = True

            ElseIf EC.Contains("disminuido") Then
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.LightGreen
                'e.HighPriority = True
            End If
        End If
    End Sub

    Private Sub Gridview1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If e.Column.FieldName = "PrecioUnitario" Or e.Column.FieldName = "Descuento" Or e.Column.FieldName = "Descuento2" Or e.Column.FieldName = "Itbis" Or e.Column.FieldName = "Importe" Or e.Column.FieldName = "CostoFinalUnitario" Or e.Column.FieldName = "ImporteTotal" Then

                Dim EV As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "E/V"))

                If EV.Contains("Beneficio") Then
                    e.Appearance.ForeColor = Color.Black

                ElseIf EV.Contains("El costo es mayor") Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrecio.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecio.Text <> "" Then
                If txtPrecio.SelectionStart = CStr(txtPrecio.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecio.SelectionStart = 0 Then
                e.Handled = True
                CbxMedida.Focus()
                CbxMedida.DroppedDown = True

            End If
        End If
    End Sub


    Private Sub CalcEdit1_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        If IsNumeric(txtPrecio.EditValue) Then
            If Len(txtPrecio.Text) = 0 Then
                txtPrecio.Text = 0
                txtPrecio.SelectAll()
            End If

            ImporteTotalUnitario()
        End If
    End Sub

    Private Sub txtRecepcion_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtRecepcion.ButtonClick
        frm_contraseña_empleado.txtUsuario.Tag = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
        frm_contraseña_empleado.ShowDialog(Me)
    End Sub

    Private Sub rdbNoItbis_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoItbis.CheckedChanged
        If rdbNoItbis.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub

    Private Sub txtCantDecimales_ValueChanged(sender As Object, e As EventArgs) Handles txtCantDecimales.ValueChanged
        txtPrecio.Properties.Precision = txtCantDecimales.Value
        txtPrecio.Properties.EditMask = "c" & txtCantDecimales.Value
        RepositoryPrecioUnitario.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryDescuento1.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryDescuento2.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryItbis.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryImporte.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryCostoFinalUnitario.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryImporteTotal.Mask.EditMask = "c" & txtCantDecimales.Value
        RepositoryItbisTotal.Mask.EditMask = "c" & txtCantDecimales.Value

        GridView1.RefreshData()
        GridView1.PostEditor()

        SumTotales()

    End Sub

    Private Sub MantenimientoDeArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        MantenimientoDeArtículosToolStripMenuItem.PerformClick()
    End Sub

    Private Sub txtPrecioCredito_Leave(sender As Object, e As EventArgs) Handles txtPrecioA.Leave
        Try
            If txtPrecioA.Text = "" Then
                txtPrecioA.Text = (0).ToString("C" & txtCantDecimales.Value)
            Else
                txtPrecioA.Text = CDbl(txtPrecioA.Text).ToString("C" & txtCantDecimales.Value)

                CalcDifs()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPrecio4_Leave(sender As Object, e As EventArgs) Handles txtPrecioD.Leave
        If txtPrecioD.Text = "" Then
            txtPrecioD.Text = (0).ToString("C" & txtCantDecimales.Value)
        Else
            txtPrecioD.Text = CDbl(txtPrecioD.Text).ToString("C" & txtCantDecimales.Value)

            CalcDifs()
        End If
    End Sub

    Private Sub txtPrecio3_Enter(sender As Object, e As EventArgs) Handles txtPrecioC.Enter
        If txtPrecioC.Text = "" Then
        Else
            txtPrecioC.Text = CDbl(txtPrecioC.Text)
            txtPrecioC.SelectAll()
        End If
    End Sub

    Private Sub txtPrecio4_Enter(sender As Object, e As EventArgs) Handles txtPrecioD.Enter
        If txtPrecioD.Text = "" Then
        Else
            txtPrecioD.Text = CDbl(txtPrecioD.Text)
            txtPrecioD.SelectAll()
        End If
    End Sub

    Private Sub txtPrecioContado_Enter(sender As Object, e As EventArgs) Handles txtPrecioB.Enter
        If txtPrecioB.Text = "" Then
        Else
            txtPrecioB.Text = CDbl(txtPrecioB.Text)
        End If
    End Sub

    Private Sub txtPrecioCredito_Enter(sender As Object, e As EventArgs) Handles txtPrecioA.Enter
        If txtPrecioA.Text = "" Then
        Else
            txtPrecioA.Text = CDbl(txtPrecioA.Text)
            txtPrecioA.SelectAll()
        End If
    End Sub

    Private Sub txtPrecio3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioC.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPrecioC.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioD.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPrecioD.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioB.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPrecioB.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioA.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPrecioA.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCostoFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCostoFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtCostoFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoFinal.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtCostoFinal.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub PreciosDinámicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreciosDinámicosToolStripMenuItem.Click
        frm_aumento_precios_dinamico.ShowDialog(Me)
    End Sub

    Private Sub frm_registro_compras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtIDCompra.Text = "" Then
            If GridView1.RowCount > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario de registro de compras?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If Result = MsgBoxResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtCostoFinal_Leave(sender As Object, e As EventArgs) Handles txtCostoFinal.Leave
        If txtCostoFinal.Text = "" Then
            txtCostoFinal.Text = (0).ToString("C" & txtCantDecimales.Value)
        Else
            txtCostoFinal.Text = CDbl(txtCostoFinal.Text).ToString("C" & txtCantDecimales.Value)

            CalcDifs()
        End If
    End Sub

    Private Sub txtCosto_Leave(sender As Object, e As EventArgs) Handles txtCosto.Leave
        If txtCosto.Text = "" Then
            txtCosto.Text = (0).ToString("C" & txtCantDecimales.Value)
        Else
            txtCosto.Text = CDbl(txtCosto.Text).ToString("C" & txtCantDecimales.Value)

            If CDbl(txtCosto.Text) <> CDbl(txtUltimoCosto.Text) Then
                txtPrecio.Text = txtCosto.Text
                Label39.Text = "[Costo Actualizado]"
                Label39.ForeColor = SystemColors.Highlight

                CalcDifs()
            End If
        End If
    End Sub

    Private Function GetPorcentajeDif(ByVal NewValue As Double, ByVal OldValue As Double, ByVal Ctl As Control) As String
        Dim StSymbol As String

        If IsNumeric(NewValue) And IsNumeric(OldValue) Then
            If NewValue > OldValue Then
                Ctl.ForeColor = Color.OrangeRed
                StSymbol = "↑ "
            ElseIf NewValue < OldValue Then
                Ctl.ForeColor = SystemColors.Highlight
                StSymbol = "↓ "
            Else
                Ctl.ForeColor = Color.Black
                StSymbol = "= "
            End If

            Return StSymbol & CDbl(((NewValue / OldValue) - 1)).ToString("P2")

        Else
            Return ""
        End If
    End Function


    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtCosto.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCosto_Enter(sender As Object, e As EventArgs) Handles txtCosto.Enter
        If txtCosto.Text = "" Then
        Else
            txtCosto.Text = CDbl(txtCosto.Text)
            txtCosto.SelectAll()
        End If
    End Sub

    Private Sub txtCostoFinal_Enter(sender As Object, e As EventArgs) Handles txtCostoFinal.Enter
        If txtCostoFinal.Text = "" Then

            If txtCosto.Text <> "" Then
                If IsNumeric(CDbl(txtCosto.Text)) Then
                    txtCostoFinal.Text = CDbl(txtCosto.Text)
                    txtCostoFinal.SelectAll()
                End If
            End If

        Else
            txtCostoFinal.Text = CDbl(txtCostoFinal.Text)
            txtCostoFinal.SelectAll()
        End If
    End Sub

    Public Sub SetUpGrid(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal table As DataTable)
        Dim view As GridView = TryCast(grid.MainView, GridView)
        grid.DataSource = table
        'view.OptionsBehavior.Editable = False

        HandleBehaviorDragDropEvents()
    End Sub

    Public Sub HandleBehaviorDragDropEvents()
        Dim gridControlBehavior As DragDropBehavior = BehaviorManager1.GetBehavior(Of DragDropBehavior)(Me.GridView1)
        AddHandler gridControlBehavior.DragDrop, AddressOf Behavior_DragDrop
        AddHandler gridControlBehavior.DragOver, AddressOf Behavior_DragOver
    End Sub
    Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
    End Sub
    Private Sub Behavior_DragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
        Dim targetGrid As GridView = TryCast(e.Target, GridView)
        Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If
        Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = targetGrid.CalcHitInfo(hitPoint)

        Dim sourceHandles() As Integer = e.GetData(Of Integer())()

        Dim targetRowHandle As Integer = hitInfo.RowHandle
        Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        Dim draggedRows As New List(Of DataRow)()
        For Each sourceHandle As Integer In sourceHandles
            Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
            Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
            draggedRows.Add(oldRow)
        Next sourceHandle

        Dim newRowIndex As Integer

        Select Case e.InsertType
            Case InsertType.Before
                newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
                For i As Integer = draggedRows.Count - 1 To 0 Step -1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case InsertType.After
                newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
                For i As Integer = 0 To draggedRows.Count - 1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case Else
                newRowIndex = -1
        End Select
        Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        targetGrid.FocusedRowHandle = insertedIndex
        targetGrid.SelectRow(targetGrid.FocusedRowHandle)
    End Sub

    Private Sub PrevisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevisualizarToolStripMenuItem.Click
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GridView1.ShowPrintPreview()
        End If
    End Sub

    Private Sub ImpresiónDirectaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónDirectaToolStripMenuItem.Click
        Try
            ' Check whether the GridControl can be printed. 
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Else
                GridView1.Print()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ExportarAPDFToolStripMenuItem.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Portable Documento Format (*.pdf)|*.pdf"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToPdf(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CopiarCeldaToolStripMenuItem.Click
        Clipboard.SetText(GridView1.GetFocusedDisplayText())
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CopiarFilaToolStripMenuItem.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.Columns.Count - 1
            If GridView1.Columns(i).Visible = True Then
                str = str & " ׀ " & GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, GridView1.Columns(i))
            End If
        Next

        Clipboard.SetText(str)

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CopiarColumnaToolStripMenuItem.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Archivos de Excel (*.xls)|*.xls"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToXls(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub
End Class
