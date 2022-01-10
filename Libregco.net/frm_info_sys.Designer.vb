<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_info_sys
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_info_sys))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.row = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row3 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row4 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row5 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row6 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row7 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row8 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row10 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row9 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.LibregcoxMini
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(490, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 483)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(488, 25)
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
        'VGridControl1
        '
        Me.VGridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.VGridControl1.Location = New System.Drawing.Point(12, 76)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.RecordWidth = 128
        Me.VGridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.VGridControl1.RowHeaderWidth = 72
        Me.VGridControl1.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row, Me.row1, Me.row2, Me.row3, Me.row4, Me.row5, Me.row6, Me.category, Me.row7, Me.row8, Me.row10, Me.row9})
        Me.VGridControl1.Size = New System.Drawing.Size(464, 390)
        Me.VGridControl1.TabIndex = 417
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.RepositoryItemCheckEdit1.ValueChecked = "1"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "0"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.RepositoryItemCheckEdit2.ValueChecked = "1"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "0"
        '
        'row
        '
        Me.row.Name = "row"
        Me.row.Properties.Caption = "Versión"
        Me.row.Properties.Value = "1.6.7.12"
        '
        'row1
        '
        Me.row1.Name = "row1"
        Me.row1.Properties.Caption = "Fecha de versión"
        Me.row1.Properties.Value = "12/12/2021"
        '
        'row2
        '
        Me.row2.Name = "row2"
        Me.row2.Properties.Caption = "Licencia"
        Me.row2.Properties.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.row2.Properties.Value = "Inactiva"
        '
        'row3
        '
        Me.row3.Name = "row3"
        Me.row3.Properties.Caption = "Tipo"
        Me.row3.Properties.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.row3.Properties.Value = "Único pago"
        '
        'row4
        '
        Me.row4.Name = "row4"
        Me.row4.Properties.Caption = "Iguala"
        Me.row4.Properties.RowEdit = Me.RepositoryItemCheckEdit1
        '
        'row5
        '
        Me.row5.Height = 17
        Me.row5.Name = "row5"
        Me.row5.Properties.Caption = "Servicios"
        Me.row5.Properties.RowEdit = Me.RepositoryItemCheckEdit2
        '
        'row6
        '
        Me.row6.Name = "row6"
        Me.row6.Properties.Caption = "Inicio de operaciones"
        Me.row6.Properties.Value = "12/12/2021"
        '
        'category
        '
        Me.category.Name = "category"
        Me.category.Properties.Caption = "Operaciones"
        '
        'row7
        '
        Me.row7.Name = "row7"
        Me.row7.Properties.Caption = "Ventas"
        '
        'row8
        '
        Me.row8.Name = "row8"
        Me.row8.Properties.Caption = "Compras"
        '
        'row10
        '
        Me.row10.Name = "row10"
        Me.row10.Properties.Caption = "Clientes"
        '
        'row9
        '
        Me.row9.Name = "row9"
        Me.row9.Properties.Caption = "Suplidores"
        '
        'frm_info_sys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 508)
        Me.Controls.Add(Me.VGridControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_info_sys"
        Me.Text = "Información del sistema"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents LabelStatus As ToolStripLabel
    Friend WithEvents VGridControl1 As XtraVerticalGrid.VGridControl
    Friend WithEvents row As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row1 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row2 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row3 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row4 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row5 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row6 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents RepositoryItemCheckEdit1 As XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents category As XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents row7 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row8 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row10 As XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row9 As XtraVerticalGrid.Rows.EditorRow
End Class
