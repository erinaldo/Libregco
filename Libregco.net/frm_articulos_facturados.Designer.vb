<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_articulos_facturados
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_articulos_facturados))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Imagen = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Cantidad = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Medida = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Generales = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.IDArticulo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.Referencia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDPrecio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Descripcion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.PrecioUnitario = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Importe = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDMedida = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RutaFoto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDCategoria = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemLookUpEdit1Cat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.IDSubCategoria = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemLookUpEdit2SubCat = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1Cat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2SubCat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 1)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemPictureEdit1, Me.RepositoryItemMemoEdit1, Me.RepositoryItemLookUpEdit1Cat, Me.RepositoryItemLookUpEdit2SubCat})
        Me.GridControl1.Size = New System.Drawing.Size(833, 622)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Appearance.Empty.BackColor = System.Drawing.SystemColors.Control
        Me.AdvBandedGridView1.Appearance.Empty.Options.UseBackColor = True
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand4, Me.gridBand2, Me.Generales, Me.gridBand1})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.IDArticulo, Me.IDPrecio, Me.Descripcion, Me.Referencia, Me.IDMedida, Me.Medida, Me.RutaFoto, Me.Cantidad, Me.PrecioUnitario, Me.Importe, Me.Imagen, Me.IDCategoria, Me.IDSubCategoria})
        Me.AdvBandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(807, 509, 216, 201)
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.GroupCount = 2
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.AdvBandedGridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.AdvBandedGridView1.OptionsPrint.AutoWidth = False
        Me.AdvBandedGridView1.OptionsPrint.ExpandAllDetails = True
        Me.AdvBandedGridView1.OptionsSelection.MultiSelect = True
        Me.AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView1.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.AdvBandedGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.AdvBandedGridView1.RowSeparatorHeight = 2
        Me.AdvBandedGridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll
        Me.AdvBandedGridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.IDCategoria, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.IDSubCategoria, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand4
        '
        Me.gridBand4.Caption = " Picture"
        Me.gridBand4.Columns.Add(Me.Imagen)
        Me.gridBand4.ImageOptions.Image = CType(resources.GetObject("gridBand4.ImageOptions.Image"), System.Drawing.Image)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 0
        Me.gridBand4.Width = 89
        '
        'Imagen
        '
        Me.Imagen.AppearanceCell.Options.UseImage = True
        Me.Imagen.AutoFillDown = True
        Me.Imagen.Caption = "Imagen"
        Me.Imagen.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.Imagen.FieldName = "Imagen"
        Me.Imagen.Name = "Imagen"
        Me.Imagen.OptionsColumn.AllowEdit = False
        Me.Imagen.OptionsColumn.AllowFocus = False
        Me.Imagen.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Imagen.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Imagen.OptionsColumn.AllowMove = False
        Me.Imagen.OptionsColumn.AllowSize = False
        Me.Imagen.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Imagen.OptionsColumn.ReadOnly = True
        Me.Imagen.OptionsFilter.AllowAutoFilter = False
        Me.Imagen.OptionsFilter.AllowFilter = False
        Me.Imagen.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell
        Me.Imagen.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.Imagen.Visible = True
        Me.Imagen.Width = 89
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Cantidad"
        Me.gridBand2.Columns.Add(Me.Cantidad)
        Me.gridBand2.Columns.Add(Me.Medida)
        Me.gridBand2.ImageOptions.Image = CType(resources.GetObject("gridBand2.ImageOptions.Image"), System.Drawing.Image)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 140
        '
        'Cantidad
        '
        Me.Cantidad.AutoFillDown = True
        Me.Cantidad.Caption = " "
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        Me.Cantidad.OptionsColumn.AllowFocus = False
        Me.Cantidad.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Cantidad.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Cantidad.OptionsColumn.AllowMove = False
        Me.Cantidad.OptionsColumn.AllowShowHide = False
        Me.Cantidad.OptionsColumn.AllowSize = False
        Me.Cantidad.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Cantidad.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.Cantidad.OptionsColumn.ReadOnly = True
        Me.Cantidad.OptionsColumn.ShowInCustomizationForm = False
        Me.Cantidad.OptionsColumn.ShowInExpressionEditor = False
        Me.Cantidad.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Cantidad.Visible = True
        Me.Cantidad.Width = 52
        '
        'Medida
        '
        Me.Medida.AppearanceCell.ForeColor = System.Drawing.Color.Gray
        Me.Medida.AppearanceCell.Options.UseForeColor = True
        Me.Medida.AppearanceCell.Options.UseTextOptions = True
        Me.Medida.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Medida.AppearanceHeader.Options.UseTextOptions = True
        Me.Medida.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Medida.AutoFillDown = True
        Me.Medida.Caption = "Medida  "
        Me.Medida.FieldName = "Medida"
        Me.Medida.Name = "Medida"
        Me.Medida.OptionsColumn.AllowEdit = False
        Me.Medida.OptionsColumn.AllowFocus = False
        Me.Medida.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Medida.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Medida.OptionsColumn.AllowMove = False
        Me.Medida.OptionsColumn.AllowSize = False
        Me.Medida.OptionsColumn.ReadOnly = True
        Me.Medida.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Medida.Visible = True
        Me.Medida.Width = 88
        '
        'Generales
        '
        Me.Generales.Caption = "Generales"
        Me.Generales.Columns.Add(Me.IDArticulo)
        Me.Generales.Columns.Add(Me.Referencia)
        Me.Generales.Columns.Add(Me.IDPrecio)
        Me.Generales.Columns.Add(Me.Descripcion)
        Me.Generales.ImageOptions.Image = CType(resources.GetObject("Generales.ImageOptions.Image"), System.Drawing.Image)
        Me.Generales.Name = "Generales"
        Me.Generales.VisibleIndex = 2
        Me.Generales.Width = 378
        '
        'IDArticulo
        '
        Me.IDArticulo.AppearanceCell.Options.UseTextOptions = True
        Me.IDArticulo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IDArticulo.AppearanceHeader.Options.UseTextOptions = True
        Me.IDArticulo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IDArticulo.Caption = "ID"
        Me.IDArticulo.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.IDArticulo.FieldName = "IDArticulo"
        Me.IDArticulo.Name = "IDArticulo"
        Me.IDArticulo.OptionsColumn.AllowEdit = False
        Me.IDArticulo.OptionsColumn.AllowFocus = False
        Me.IDArticulo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDArticulo.OptionsColumn.AllowMove = False
        Me.IDArticulo.OptionsColumn.AllowShowHide = False
        Me.IDArticulo.OptionsColumn.ReadOnly = True
        Me.IDArticulo.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDArticulo.Visible = True
        Me.IDArticulo.Width = 128
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'Referencia
        '
        Me.Referencia.AppearanceCell.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Referencia.AppearanceCell.Options.UseForeColor = True
        Me.Referencia.AppearanceCell.Options.UseTextOptions = True
        Me.Referencia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Referencia.AppearanceHeader.Options.UseTextOptions = True
        Me.Referencia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.Referencia.AutoFillDown = True
        Me.Referencia.Caption = "Referencia"
        Me.Referencia.FieldName = "Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.OptionsColumn.AllowEdit = False
        Me.Referencia.OptionsColumn.AllowFocus = False
        Me.Referencia.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Referencia.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Referencia.OptionsColumn.AllowMove = False
        Me.Referencia.OptionsColumn.AllowSize = False
        Me.Referencia.OptionsColumn.ReadOnly = True
        Me.Referencia.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Referencia.Visible = True
        Me.Referencia.Width = 250
        '
        'IDPrecio
        '
        Me.IDPrecio.AppearanceCell.Options.UseTextOptions = True
        Me.IDPrecio.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IDPrecio.AppearanceHeader.Options.UseTextOptions = True
        Me.IDPrecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IDPrecio.Caption = "IDPrecio"
        Me.IDPrecio.FieldName = "IDPrecio"
        Me.IDPrecio.Name = "IDPrecio"
        Me.IDPrecio.OptionsColumn.AllowEdit = False
        Me.IDPrecio.OptionsColumn.AllowFocus = False
        Me.IDPrecio.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDPrecio.OptionsColumn.AllowMove = False
        Me.IDPrecio.OptionsColumn.AllowShowHide = False
        Me.IDPrecio.OptionsColumn.ReadOnly = True
        Me.IDPrecio.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'Descripcion
        '
        Me.Descripcion.AutoFillDown = True
        Me.Descripcion.Caption = "Descripción"
        Me.Descripcion.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.Descripcion.FieldName = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.OptionsColumn.AllowEdit = False
        Me.Descripcion.OptionsColumn.AllowFocus = False
        Me.Descripcion.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.Descripcion.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.Descripcion.OptionsColumn.AllowMove = False
        Me.Descripcion.OptionsColumn.AllowSize = False
        Me.Descripcion.OptionsColumn.ReadOnly = True
        Me.Descripcion.RowIndex = 1
        Me.Descripcion.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Descripcion.Visible = True
        Me.Descripcion.Width = 378
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "Valores"
        Me.gridBand1.Columns.Add(Me.PrecioUnitario)
        Me.gridBand1.Columns.Add(Me.Importe)
        Me.gridBand1.ImageOptions.Image = CType(resources.GetObject("gridBand1.ImageOptions.Image"), System.Drawing.Image)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 3
        Me.gridBand1.Width = 208
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.AutoFillDown = True
        Me.PrecioUnitario.Caption = "Valor"
        Me.PrecioUnitario.DisplayFormat.FormatString = "c"
        Me.PrecioUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PrecioUnitario.FieldName = "PrecioUnitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.OptionsColumn.AllowEdit = False
        Me.PrecioUnitario.OptionsColumn.AllowFocus = False
        Me.PrecioUnitario.OptionsColumn.ReadOnly = True
        Me.PrecioUnitario.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.PrecioUnitario.Visible = True
        Me.PrecioUnitario.Width = 99
        '
        'Importe
        '
        Me.Importe.AutoFillDown = True
        Me.Importe.Caption = "Importe"
        Me.Importe.DisplayFormat.FormatString = "c"
        Me.Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Importe.FieldName = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.OptionsColumn.AllowEdit = False
        Me.Importe.OptionsColumn.AllowFocus = False
        Me.Importe.OptionsColumn.ReadOnly = True
        Me.Importe.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Importe.Visible = True
        Me.Importe.Width = 109
        '
        'IDMedida
        '
        Me.IDMedida.Caption = "IDMedida"
        Me.IDMedida.FieldName = "IDMedida"
        Me.IDMedida.Name = "IDMedida"
        Me.IDMedida.OptionsColumn.AllowEdit = False
        Me.IDMedida.OptionsColumn.AllowFocus = False
        Me.IDMedida.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDMedida.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDMedida.OptionsColumn.AllowMove = False
        Me.IDMedida.OptionsColumn.AllowShowHide = False
        Me.IDMedida.OptionsColumn.AllowSize = False
        Me.IDMedida.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDMedida.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDMedida.OptionsColumn.ReadOnly = True
        Me.IDMedida.OptionsColumn.ShowInCustomizationForm = False
        Me.IDMedida.OptionsColumn.ShowInExpressionEditor = False
        Me.IDMedida.OptionsColumn.TabStop = False
        Me.IDMedida.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'RutaFoto
        '
        Me.RutaFoto.AutoFillDown = True
        Me.RutaFoto.Caption = "RutaFoto"
        Me.RutaFoto.FieldName = "RutaFoto"
        Me.RutaFoto.Name = "RutaFoto"
        Me.RutaFoto.OptionsColumn.AllowEdit = False
        Me.RutaFoto.OptionsColumn.AllowFocus = False
        Me.RutaFoto.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.RutaFoto.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.RutaFoto.OptionsColumn.AllowMove = False
        Me.RutaFoto.OptionsColumn.AllowShowHide = False
        Me.RutaFoto.OptionsColumn.AllowSize = False
        Me.RutaFoto.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.RutaFoto.OptionsColumn.ReadOnly = True
        Me.RutaFoto.OptionsColumn.ShowCaption = False
        Me.RutaFoto.OptionsColumn.ShowInCustomizationForm = False
        Me.RutaFoto.OptionsColumn.ShowInExpressionEditor = False
        Me.RutaFoto.OptionsFilter.AllowAutoFilter = False
        Me.RutaFoto.OptionsFilter.AllowFilter = False
        Me.RutaFoto.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.RutaFoto.Visible = True
        Me.RutaFoto.Width = 235
        '
        'IDCategoria
        '
        Me.IDCategoria.Caption = "Categoría"
        Me.IDCategoria.ColumnEdit = Me.RepositoryItemLookUpEdit1Cat
        Me.IDCategoria.FieldName = "IDCategoria"
        Me.IDCategoria.Name = "IDCategoria"
        Me.IDCategoria.OptionsColumn.ReadOnly = True
        Me.IDCategoria.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDCategoria.Visible = True
        '
        'RepositoryItemLookUpEdit1Cat
        '
        Me.RepositoryItemLookUpEdit1Cat.AutoHeight = False
        Me.RepositoryItemLookUpEdit1Cat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1Cat.Name = "RepositoryItemLookUpEdit1Cat"
        Me.RepositoryItemLookUpEdit1Cat.ReadOnly = True
        '
        'IDSubCategoria
        '
        Me.IDSubCategoria.Caption = "SubCategoría"
        Me.IDSubCategoria.ColumnEdit = Me.RepositoryItemLookUpEdit2SubCat
        Me.IDSubCategoria.FieldName = "IDSubCategoria"
        Me.IDSubCategoria.Name = "IDSubCategoria"
        Me.IDSubCategoria.OptionsColumn.ReadOnly = True
        Me.IDSubCategoria.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDSubCategoria.Visible = True
        '
        'RepositoryItemLookUpEdit2SubCat
        '
        Me.RepositoryItemLookUpEdit2SubCat.AutoHeight = False
        Me.RepositoryItemLookUpEdit2SubCat.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2SubCat.Name = "RepositoryItemLookUpEdit2SubCat"
        Me.RepositoryItemLookUpEdit2SubCat.ReadOnly = True
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 626)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(833, 25)
        Me.BarraEstado.TabIndex = 413
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = Global.Libregco.My.Resources.Resources.Loading
        Me.PicLoading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLoading.Name = "PicLoading"
        Me.PicLoading.Size = New System.Drawing.Size(23, 22)
        Me.PicLoading.Text = "ToolStripButton1"
        Me.PicLoading.Visible = False
        '
        'ToolSeparator
        '
        Me.ToolSeparator.Name = "ToolSeparator"
        Me.ToolSeparator.Size = New System.Drawing.Size(6, 25)
        Me.ToolSeparator.Visible = False
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 22)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 22)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'frm_articulos_facturados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 651)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GridControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_articulos_facturados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Artículos asociados"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1Cat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2SubCat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView1 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents Imagen As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemPictureEdit1 As XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents IDArticulo As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents Referencia As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Medida As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDPrecio As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Descripcion As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents Cantidad As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RutaFoto As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDMedida As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrecioUnitario As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Importe As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents IDCategoria As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDSubCategoria As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Generales As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents RepositoryItemLookUpEdit1Cat As XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit2SubCat As XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
