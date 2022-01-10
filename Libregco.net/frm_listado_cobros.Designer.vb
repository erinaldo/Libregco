<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_listado_cobros
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_listado_cobros))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.Generales = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.NombreFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDCliente = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.Nombre = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BalanceGeneral = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DireccionFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.TelefonosFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.IDFacturaDatos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Balance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Cargos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SecondIDFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.EstadoFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Fecha = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.VencFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.UltimoPago = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.UltimoMonto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDCalificacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Guardar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.IDEstadoFactura = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDProvincia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Provincia = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDMunicipio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Municipio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDEmpleadoSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SubCobradorNombre = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.btnCobrador = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(4, 59)
        Me.GridControl1.LookAndFeel.UseWindowsXPTheme = True
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemButtonEdit1, Me.RepositoryItemHyperLinkEdit1, Me.RepositoryItemMemoEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1085, 738)
        Me.GridControl1.TabIndex = 361
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.Generales, Me.gridBand2, Me.gridBand3, Me.gridBand1})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.IDFacturaDatos, Me.SecondIDFactura, Me.Fecha, Me.VencFactura, Me.IDCliente, Me.NombreFactura, Me.Nombre, Me.BalanceGeneral, Me.Balance, Me.Cargos, Me.IDEstadoFactura, Me.EstadoFactura, Me.UltimoPago, Me.UltimoMonto, Me.DireccionFactura, Me.TelefonosFactura, Me.IDProvincia, Me.Provincia, Me.IDMunicipio, Me.Municipio, Me.IDEmpleadoSub, Me.SubCobradorNombre, Me.IDCalificacion, Me.BandedGridColumn2, Me.Guardar})
        Me.AdvBandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(1167, 768, 216, 208)
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.GroupCount = 1
        Me.AdvBandedGridView1.GroupFormat = "{1} {2}"
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.AdvBandedGridView1.OptionsCustomization.AllowColumnMoving = False
        Me.AdvBandedGridView1.OptionsDetail.AllowExpandEmptyDetails = True
        Me.AdvBandedGridView1.OptionsPrint.ExpandAllDetails = True
        Me.AdvBandedGridView1.OptionsView.ShowAutoFilterRow = True
        Me.AdvBandedGridView1.OptionsView.ShowFooter = True
        Me.AdvBandedGridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Nombre, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'Generales
        '
        Me.Generales.Caption = "Generales"
        Me.Generales.Columns.Add(Me.NombreFactura)
        Me.Generales.Columns.Add(Me.IDCliente)
        Me.Generales.Columns.Add(Me.Nombre)
        Me.Generales.Columns.Add(Me.BalanceGeneral)
        Me.Generales.Columns.Add(Me.DireccionFactura)
        Me.Generales.Columns.Add(Me.TelefonosFactura)
        Me.Generales.Name = "Generales"
        Me.Generales.VisibleIndex = 0
        Me.Generales.Width = 528
        '
        'NombreFactura
        '
        Me.NombreFactura.Caption = "Nombre factura"
        Me.NombreFactura.FieldName = "NombreFactura"
        Me.NombreFactura.Name = "NombreFactura"
        Me.NombreFactura.OptionsColumn.AllowEdit = False
        Me.NombreFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.NombreFactura.Visible = True
        Me.NombreFactura.Width = 373
        '
        'IDCliente
        '
        Me.IDCliente.AppearanceCell.Options.UseFont = True
        Me.IDCliente.AppearanceCell.Options.UseTextOptions = True
        Me.IDCliente.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.IDCliente.AppearanceHeader.Options.UseTextOptions = True
        Me.IDCliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.IDCliente.Caption = "ID"
        Me.IDCliente.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.IDCliente.FieldName = "IDCliente"
        Me.IDCliente.Name = "IDCliente"
        Me.IDCliente.OptionsColumn.AllowEdit = False
        Me.IDCliente.RowIndex = 1
        Me.IDCliente.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDCliente.Width = 76
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.LinkColor = System.Drawing.SystemColors.MenuHighlight
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'Nombre
        '
        Me.Nombre.AppearanceCell.Options.UseFont = True
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.AllowEdit = False
        Me.Nombre.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.Nombre.RowIndex = 1
        Me.Nombre.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Nombre.Width = 188
        '
        'BalanceGeneral
        '
        Me.BalanceGeneral.AppearanceCell.Options.UseFont = True
        Me.BalanceGeneral.Caption = "Balance Gral."
        Me.BalanceGeneral.DisplayFormat.FormatString = "c"
        Me.BalanceGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BalanceGeneral.FieldName = "BalanceGeneral"
        Me.BalanceGeneral.Name = "BalanceGeneral"
        Me.BalanceGeneral.OptionsColumn.AllowEdit = False
        Me.BalanceGeneral.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BalanceGeneral.Visible = True
        Me.BalanceGeneral.Width = 155
        '
        'DireccionFactura
        '
        Me.DireccionFactura.AppearanceCell.ForeColor = System.Drawing.Color.Gray
        Me.DireccionFactura.AppearanceCell.Options.UseFont = True
        Me.DireccionFactura.AppearanceCell.Options.UseForeColor = True
        Me.DireccionFactura.Caption = "Dirección"
        Me.DireccionFactura.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.DireccionFactura.FieldName = "DireccionFactura"
        Me.DireccionFactura.Name = "DireccionFactura"
        Me.DireccionFactura.OptionsColumn.AllowEdit = False
        Me.DireccionFactura.RowIndex = 1
        Me.DireccionFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.DireccionFactura.Visible = True
        Me.DireccionFactura.Width = 340
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        Me.RepositoryItemMemoEdit1.ReadOnly = True
        '
        'TelefonosFactura
        '
        Me.TelefonosFactura.AppearanceCell.ForeColor = System.Drawing.Color.Gray
        Me.TelefonosFactura.AppearanceCell.Options.UseFont = True
        Me.TelefonosFactura.AppearanceCell.Options.UseForeColor = True
        Me.TelefonosFactura.Caption = "Teléfonos"
        Me.TelefonosFactura.FieldName = "TelefonosFactura"
        Me.TelefonosFactura.Name = "TelefonosFactura"
        Me.TelefonosFactura.OptionsColumn.AllowEdit = False
        Me.TelefonosFactura.RowIndex = 2
        Me.TelefonosFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.TelefonosFactura.Visible = True
        Me.TelefonosFactura.Width = 528
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Informaciónes de factura"
        Me.gridBand2.Columns.Add(Me.IDFacturaDatos)
        Me.gridBand2.Columns.Add(Me.Balance)
        Me.gridBand2.Columns.Add(Me.Cargos)
        Me.gridBand2.Columns.Add(Me.SecondIDFactura)
        Me.gridBand2.Columns.Add(Me.EstadoFactura)
        Me.gridBand2.Columns.Add(Me.Fecha)
        Me.gridBand2.Columns.Add(Me.VencFactura)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 237
        '
        'IDFacturaDatos
        '
        Me.IDFacturaDatos.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IDFacturaDatos.AppearanceCell.Options.UseForeColor = True
        Me.IDFacturaDatos.AppearanceCell.Options.UseTextOptions = True
        Me.IDFacturaDatos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IDFacturaDatos.Caption = "# Transacción"
        Me.IDFacturaDatos.FieldName = "IDFacturaDatos"
        Me.IDFacturaDatos.Name = "IDFacturaDatos"
        Me.IDFacturaDatos.OptionsColumn.AllowEdit = False
        Me.IDFacturaDatos.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDFacturaDatos.Width = 90
        '
        'Balance
        '
        Me.Balance.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Balance.AppearanceCell.Options.UseBackColor = True
        Me.Balance.Caption = "Balance"
        Me.Balance.DisplayFormat.FormatString = "c"
        Me.Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.OptionsColumn.AllowEdit = False
        Me.Balance.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Balance.Visible = True
        Me.Balance.Width = 128
        '
        'Cargos
        '
        Me.Cargos.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Cargos.AppearanceCell.Options.UseBackColor = True
        Me.Cargos.Caption = "Cargos"
        Me.Cargos.DisplayFormat.FormatString = "c"
        Me.Cargos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Cargos.FieldName = "Cargos"
        Me.Cargos.Name = "Cargos"
        Me.Cargos.OptionsColumn.AllowEdit = False
        Me.Cargos.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Cargos.Visible = True
        Me.Cargos.Width = 109
        '
        'SecondIDFactura
        '
        Me.SecondIDFactura.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SecondIDFactura.AppearanceCell.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.SecondIDFactura.AppearanceCell.Options.UseBackColor = True
        Me.SecondIDFactura.AppearanceCell.Options.UseForeColor = True
        Me.SecondIDFactura.Caption = "# Factura"
        Me.SecondIDFactura.FieldName = "SecondIDFactura"
        Me.SecondIDFactura.Name = "SecondIDFactura"
        Me.SecondIDFactura.OptionsColumn.AllowEdit = False
        Me.SecondIDFactura.RowIndex = 1
        Me.SecondIDFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.SecondIDFactura.Visible = True
        Me.SecondIDFactura.Width = 237
        '
        'EstadoFactura
        '
        Me.EstadoFactura.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.EstadoFactura.AppearanceCell.Options.UseBackColor = True
        Me.EstadoFactura.Caption = "Situación"
        Me.EstadoFactura.FieldName = "EstadoFactura"
        Me.EstadoFactura.Name = "EstadoFactura"
        Me.EstadoFactura.OptionsColumn.AllowEdit = False
        Me.EstadoFactura.RowIndex = 2
        Me.EstadoFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.EstadoFactura.Visible = True
        Me.EstadoFactura.Width = 78
        '
        'Fecha
        '
        Me.Fecha.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Fecha.AppearanceCell.Options.UseBackColor = True
        Me.Fecha.Caption = "Fecha"
        Me.Fecha.FieldName = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.OptionsColumn.AllowEdit = False
        Me.Fecha.RowIndex = 2
        Me.Fecha.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Fecha.Visible = True
        Me.Fecha.Width = 78
        '
        'VencFactura
        '
        Me.VencFactura.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.VencFactura.AppearanceCell.Options.UseBackColor = True
        Me.VencFactura.Caption = "Vencimiento"
        Me.VencFactura.FieldName = "VencFactura"
        Me.VencFactura.Name = "VencFactura"
        Me.VencFactura.OptionsColumn.AllowEdit = False
        Me.VencFactura.RowIndex = 2
        Me.VencFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.VencFactura.Visible = True
        Me.VencFactura.Width = 81
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Observaciones"
        Me.gridBand3.Columns.Add(Me.UltimoPago)
        Me.gridBand3.Columns.Add(Me.UltimoMonto)
        Me.gridBand3.Columns.Add(Me.IDCalificacion)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 205
        '
        'UltimoPago
        '
        Me.UltimoPago.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UltimoPago.AppearanceCell.Options.UseBackColor = True
        Me.UltimoPago.Caption = "Último Pago"
        Me.UltimoPago.FieldName = "UltimoPago"
        Me.UltimoPago.Name = "UltimoPago"
        Me.UltimoPago.OptionsColumn.AllowEdit = False
        Me.UltimoPago.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.UltimoPago.Visible = True
        Me.UltimoPago.Width = 92
        '
        'UltimoMonto
        '
        Me.UltimoMonto.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UltimoMonto.AppearanceCell.Options.UseBackColor = True
        Me.UltimoMonto.Caption = "Último Monto"
        Me.UltimoMonto.DisplayFormat.FormatString = "C"
        Me.UltimoMonto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UltimoMonto.FieldName = "UltimoMonto"
        Me.UltimoMonto.Name = "UltimoMonto"
        Me.UltimoMonto.OptionsColumn.AllowEdit = False
        Me.UltimoMonto.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.UltimoMonto.Visible = True
        Me.UltimoMonto.Width = 113
        '
        'IDCalificacion
        '
        Me.IDCalificacion.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.IDCalificacion.AppearanceCell.Options.UseBackColor = True
        Me.IDCalificacion.AutoFillDown = True
        Me.IDCalificacion.Caption = "Calificación"
        Me.IDCalificacion.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.IDCalificacion.FieldName = "IDCalificacion"
        Me.IDCalificacion.Name = "IDCalificacion"
        Me.IDCalificacion.RowIndex = 1
        Me.IDCalificacion.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDCalificacion.Visible = True
        Me.IDCalificacion.Width = 154
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.BandedGridColumn2.AppearanceCell.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.BandedGridColumn2.AppearanceCell.Options.UseBackColor = True
        Me.BandedGridColumn2.AutoFillDown = True
        Me.BandedGridColumn2.Caption = "Credito"
        Me.BandedGridColumn2.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.BandedGridColumn2.FieldName = "CerrarCredito"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.RowIndex = 1
        Me.BandedGridColumn2.ShowUnboundExpressionMenu = True
        Me.BandedGridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 51
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.Appearance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.Appearance.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.Appearance.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceFocused.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.Options.UseBackColor = True
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Caption = "Cerrar Crédito"
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "True"
        Me.RepositoryItemCheckEdit1.DisplayValueGrayed = "-1"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "False"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.RepositoryItemCheckEdit1.ValueChecked = CType(1, Short)
        Me.RepositoryItemCheckEdit1.ValueGrayed = "0"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = CType(0, Short)
        '
        'gridBand1
        '
        Me.gridBand1.Caption = "Acciones"
        Me.gridBand1.Columns.Add(Me.Guardar)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.VisibleIndex = 3
        Me.gridBand1.Width = 75
        '
        'Guardar
        '
        Me.Guardar.AutoFillDown = True
        Me.Guardar.Caption = "Guardar"
        Me.Guardar.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.Guardar.FieldName = "Guardar"
        Me.Guardar.Name = "Guardar"
        Me.Guardar.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        Me.Guardar.Visible = True
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Guardar", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'IDEstadoFactura
        '
        Me.IDEstadoFactura.AppearanceCell.BackColor = System.Drawing.SystemColors.ControlLight
        Me.IDEstadoFactura.AppearanceCell.Options.UseBackColor = True
        Me.IDEstadoFactura.Caption = "IDEstadoFactura"
        Me.IDEstadoFactura.FieldName = "IDEstadoFactura"
        Me.IDEstadoFactura.Name = "IDEstadoFactura"
        Me.IDEstadoFactura.OptionsColumn.AllowEdit = False
        Me.IDEstadoFactura.OptionsColumn.AllowFocus = False
        Me.IDEstadoFactura.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDEstadoFactura.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDEstadoFactura.OptionsColumn.AllowMove = False
        Me.IDEstadoFactura.OptionsColumn.AllowShowHide = False
        Me.IDEstadoFactura.OptionsColumn.AllowSize = False
        Me.IDEstadoFactura.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDEstadoFactura.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.IDEstadoFactura.OptionsColumn.ShowCaption = False
        Me.IDEstadoFactura.OptionsColumn.ShowInCustomizationForm = False
        Me.IDEstadoFactura.OptionsColumn.ShowInExpressionEditor = False
        Me.IDEstadoFactura.OptionsColumn.TabStop = False
        Me.IDEstadoFactura.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'IDProvincia
        '
        Me.IDProvincia.Caption = "IDProvincia"
        Me.IDProvincia.FieldName = "IDProvincia"
        Me.IDProvincia.Name = "IDProvincia"
        Me.IDProvincia.OptionsColumn.AllowEdit = False
        Me.IDProvincia.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDProvincia.Visible = True
        '
        'Provincia
        '
        Me.Provincia.Caption = "Provincia"
        Me.Provincia.FieldName = "Provincia"
        Me.Provincia.Name = "Provincia"
        Me.Provincia.OptionsColumn.AllowEdit = False
        Me.Provincia.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Provincia.Visible = True
        '
        'IDMunicipio
        '
        Me.IDMunicipio.Caption = "IDMunicipio"
        Me.IDMunicipio.FieldName = "IDMunicipio"
        Me.IDMunicipio.Name = "IDMunicipio"
        Me.IDMunicipio.OptionsColumn.AllowEdit = False
        Me.IDMunicipio.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDMunicipio.Visible = True
        '
        'Municipio
        '
        Me.Municipio.Caption = "Municipio"
        Me.Municipio.FieldName = "Municipio"
        Me.Municipio.Name = "Municipio"
        Me.Municipio.OptionsColumn.AllowEdit = False
        Me.Municipio.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Municipio.Visible = True
        '
        'IDEmpleadoSub
        '
        Me.IDEmpleadoSub.Caption = "IDEmpleadoSub"
        Me.IDEmpleadoSub.FieldName = "IDEmpleadoSub"
        Me.IDEmpleadoSub.Name = "IDEmpleadoSub"
        Me.IDEmpleadoSub.OptionsColumn.AllowEdit = False
        Me.IDEmpleadoSub.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDEmpleadoSub.Visible = True
        '
        'SubCobradorNombre
        '
        Me.SubCobradorNombre.Caption = "SubCobradorNombre"
        Me.SubCobradorNombre.FieldName = "SubCobradorNombre"
        Me.SubCobradorNombre.Name = "SubCobradorNombre"
        Me.SubCobradorNombre.OptionsColumn.AllowEdit = False
        Me.SubCobradorNombre.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.SubCobradorNombre.Visible = True
        '
        'btnCobrador
        '
        Me.btnCobrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCobrador.Image = CType(resources.GetObject("btnCobrador.Image"), System.Drawing.Image)
        Me.btnCobrador.Location = New System.Drawing.Point(147, 12)
        Me.btnCobrador.Name = "btnCobrador"
        Me.btnCobrador.Size = New System.Drawing.Size(23, 23)
        Me.btnCobrador.TabIndex = 358
        Me.btnCobrador.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(5, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 359
        Me.Label7.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(169, 12)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(304, 23)
        Me.txtCobrador.TabIndex = 360
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(72, 12)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.Size = New System.Drawing.Size(76, 23)
        Me.txtIDCobrador.TabIndex = 357
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BandedGridColumn1.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn1.Caption = "BalanceGeneral"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "c"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "Balance General"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 85
        '
        'frm_listado_cobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 800)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnCobrador)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_listado_cobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "216"
        Me.Text = "Mantenimiento de listado de cobros"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCobrador As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCobrador As TextBox
    Friend WithEvents txtIDCobrador As TextBox
    Friend WithEvents BandedGridColumn1 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AdvBandedGridView1 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents Nombre As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDCliente As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BalanceGeneral As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DireccionFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents TelefonosFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDFacturaDatos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Balance As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Cargos As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SecondIDFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents EstadoFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Fecha As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents VencFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UltimoPago As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UltimoMonto As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDCalificacion As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDEstadoFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDProvincia As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Provincia As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDMunicipio As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Municipio As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDEmpleadoSub As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SubCobradorNombre As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridControl1 As XtraGrid.GridControl
    Friend WithEvents RepositoryItemLookUpEdit1 As XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemCheckEdit1 As XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Guardar As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BandedGridColumn2 As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents Generales As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand1 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents RepositoryItemMemoEdit1 As XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents NombreFactura As XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
