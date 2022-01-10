<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_catalogo_cuentas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_catalogo_cuentas))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.NoCuenta = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.IDCtaCont = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NombreCuenta = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Comentario = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Nulo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryChkNulo = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.IDParent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryCuentas = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.NoParent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Numero = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Orden = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Balance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryChkNulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 2)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1026, 803)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.SimpleButton1)
        Me.XtraTabPage1.Controls.Add(Me.GridControl1)
        Me.XtraTabPage1.Controls.Add(Me.TreeView1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1020, 775)
        Me.XtraTabPage1.Text = "Cuentas Contables"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(642, 6)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 423
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(3, 6)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryCuentas, Me.RepositoryChkNulo, Me.RepositoryItemMemoEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(633, 766)
        Me.GridControl1.TabIndex = 422
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.BehaviorManager1.SetBehaviors(Me.AdvBandedGridView1, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.Utils.DragDrop.DragDropBehavior.Create(GetType(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), True, True, True), DevExpress.Utils.Behaviors.Behavior)})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.IDCtaCont, Me.NombreCuenta, Me.Orden, Me.Numero, Me.NoCuenta, Me.IDParent, Me.NoParent, Me.Comentario, Me.Nulo, Me.Balance})
        Me.AdvBandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(928, 719, 216, 222)
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsFind.AlwaysVisible = True
        Me.AdvBandedGridView1.OptionsFind.FindNullPrompt = ""
        Me.AdvBandedGridView1.OptionsFind.ShowFindButton = False
        Me.AdvBandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.AdvBandedGridView1.RowSeparatorHeight = 3
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Catálogo de cuentas"
        Me.GridBand1.Columns.Add(Me.NoCuenta)
        Me.GridBand1.Columns.Add(Me.IDCtaCont)
        Me.GridBand1.Columns.Add(Me.NombreCuenta)
        Me.GridBand1.Columns.Add(Me.Comentario)
        Me.GridBand1.Columns.Add(Me.Nulo)
        Me.GridBand1.Columns.Add(Me.IDParent)
        Me.GridBand1.Columns.Add(Me.NoParent)
        Me.GridBand1.Columns.Add(Me.Numero)
        Me.GridBand1.Columns.Add(Me.Orden)
        Me.GridBand1.ImageOptions.Image = CType(resources.GetObject("GridBand1.ImageOptions.Image"), System.Drawing.Image)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 589
        '
        'NoCuenta
        '
        Me.NoCuenta.Caption = "# Número de cuenta"
        Me.NoCuenta.FieldName = "NoCuenta"
        Me.NoCuenta.Name = "NoCuenta"
        Me.NoCuenta.OptionsColumn.FixedWidth = True
        Me.NoCuenta.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.NoCuenta.Visible = True
        Me.NoCuenta.Width = 126
        '
        'IDCtaCont
        '
        Me.IDCtaCont.Caption = "ID"
        Me.IDCtaCont.FieldName = "IDCtaCont"
        Me.IDCtaCont.Name = "IDCtaCont"
        Me.IDCtaCont.RowIndex = 1
        Me.IDCtaCont.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'NombreCuenta
        '
        Me.NombreCuenta.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreCuenta.AppearanceCell.Options.UseFont = True
        Me.NombreCuenta.Caption = "Cuenta"
        Me.NombreCuenta.FieldName = "NombreCuenta"
        Me.NombreCuenta.Name = "NombreCuenta"
        Me.NombreCuenta.OptionsColumn.FixedWidth = True
        Me.NombreCuenta.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.NombreCuenta.Visible = True
        Me.NombreCuenta.Width = 225
        '
        'Comentario
        '
        Me.Comentario.Caption = "Observaciones"
        Me.Comentario.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.Comentario.FieldName = "Comentario"
        Me.Comentario.Name = "Comentario"
        Me.Comentario.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Comentario.Visible = True
        Me.Comentario.Width = 202
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.AcceptsReturn = False
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        Me.RepositoryItemMemoEdit1.ValidateOnEnterKey = True
        '
        'Nulo
        '
        Me.Nulo.Caption = "Nulo"
        Me.Nulo.ColumnEdit = Me.RepositoryChkNulo
        Me.Nulo.FieldName = "Nulo"
        Me.Nulo.Name = "Nulo"
        Me.Nulo.OptionsColumn.FixedWidth = True
        Me.Nulo.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Nulo.Visible = True
        Me.Nulo.Width = 36
        '
        'RepositoryChkNulo
        '
        Me.RepositoryChkNulo.AutoHeight = False
        Me.RepositoryChkNulo.DisplayValueChecked = "0"
        Me.RepositoryChkNulo.DisplayValueGrayed = "1"
        Me.RepositoryChkNulo.Name = "RepositoryChkNulo"
        Me.RepositoryChkNulo.ValueChecked = "1"
        Me.RepositoryChkNulo.ValueGrayed = ""
        Me.RepositoryChkNulo.ValueUnchecked = "0"
        '
        'IDParent
        '
        Me.IDParent.AppearanceCell.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDParent.AppearanceCell.Options.UseFont = True
        Me.IDParent.Caption = "Padre"
        Me.IDParent.ColumnEdit = Me.RepositoryCuentas
        Me.IDParent.FieldName = "IDParent"
        Me.IDParent.Name = "IDParent"
        Me.IDParent.RowIndex = 1
        Me.IDParent.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.IDParent.Visible = True
        Me.IDParent.Width = 286
        '
        'RepositoryCuentas
        '
        Me.RepositoryCuentas.AutoHeight = False
        Me.RepositoryCuentas.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.RepositoryCuentas.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCuentas.Name = "RepositoryCuentas"
        Me.RepositoryCuentas.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        Me.RepositoryCuentas.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth
        Me.RepositoryCuentas.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        '
        'NoParent
        '
        Me.NoParent.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NoParent.AppearanceCell.Options.UseBackColor = True
        Me.NoParent.Caption = "# Padre"
        Me.NoParent.FieldName = "NoParent"
        Me.NoParent.Name = "NoParent"
        Me.NoParent.OptionsColumn.FixedWidth = True
        Me.NoParent.OptionsColumn.ReadOnly = True
        Me.NoParent.RowIndex = 1
        Me.NoParent.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.NoParent.Visible = True
        Me.NoParent.Width = 144
        '
        'Numero
        '
        Me.Numero.Caption = "Numero"
        Me.Numero.FieldName = "Numero"
        Me.Numero.Name = "Numero"
        Me.Numero.RowIndex = 1
        Me.Numero.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Numero.Visible = True
        Me.Numero.Width = 55
        '
        'Orden
        '
        Me.Orden.Caption = "Orden"
        Me.Orden.FieldName = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.RowIndex = 1
        Me.Orden.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.Orden.Visible = True
        Me.Orden.Width = 104
        '
        'Balance
        '
        Me.Balance.Caption = "Balance"
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Balance.Visible = True
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.Indent = 22
        Me.TreeView1.ItemHeight = 20
        Me.TreeView1.Location = New System.Drawing.Point(642, 31)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(373, 737)
        Me.TreeView1.TabIndex = 0
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 808)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1029, 25)
        Me.BarraEstado.TabIndex = 416
        Me.BarraEstado.Text = "ToolStrip1"
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
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 22)
        Me.LabelStatus.Text = "Listo"
        '
        'frm_catalogo_cuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 833)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_catalogo_cuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de cuentas"
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryChkNulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XtraTabControl1 As XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As XtraGrid.GridControl
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents LabelStatus As ToolStripLabel
    Friend WithEvents AdvBandedGridView1 As XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents IDCtaCont As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NombreCuenta As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NoCuenta As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents IDParent As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Comentario As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Nulo As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryCuentas As XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryChkNulo As XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridBand1 As XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents RepositoryItemMemoEdit1 As XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents NoParent As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Balance As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BehaviorManager1 As Utils.Behaviors.BehaviorManager
    Friend WithEvents Numero As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Orden As XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SimpleButton1 As XtraEditors.SimpleButton
End Class
