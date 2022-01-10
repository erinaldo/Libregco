<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_colores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_buscar_colores))
        Me.DgvColor = New System.Windows.Forms.DataGridView()
        Me.IDColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageColorGroup = New System.Windows.Forms.DataGridViewImageColumn()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbCodigo = New System.Windows.Forms.RadioButton()
        Me.rdbColor = New System.Windows.Forms.RadioButton()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.DgvColoresDetallados = New System.Windows.Forms.DataGridView()
        Me.IDColorDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDetailColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArgbDetailColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.DgvColoresDetallados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvColor
        '
        Me.DgvColor.AllowUserToAddRows = False
        Me.DgvColor.AllowUserToDeleteRows = False
        Me.DgvColor.AllowUserToResizeColumns = False
        Me.DgvColor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvColor.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvColor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvColor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColor, Me.Grupo, Me.FilePath, Me.ImageColorGroup})
        Me.DgvColor.Location = New System.Drawing.Point(4, 48)
        Me.DgvColor.MultiSelect = False
        Me.DgvColor.Name = "DgvColor"
        Me.DgvColor.ReadOnly = True
        Me.DgvColor.RowTemplate.Height = 46
        Me.DgvColor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvColor.Size = New System.Drawing.Size(452, 330)
        Me.DgvColor.StandardTab = True
        Me.DgvColor.TabIndex = 225
        Me.DgvColor.TabStop = False
        '
        'IDColor
        '
        Me.IDColor.HeaderText = "ID"
        Me.IDColor.Name = "IDColor"
        Me.IDColor.ReadOnly = True
        Me.IDColor.Width = 50
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 260
        '
        'FilePath
        '
        Me.FilePath.HeaderText = ""
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Visible = False
        '
        'ImageColorGroup
        '
        Me.ImageColorGroup.HeaderText = ""
        Me.ImageColorGroup.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ImageColorGroup.Name = "ImageColorGroup"
        Me.ImageColorGroup.ReadOnly = True
        Me.ImageColorGroup.Width = 85
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rdbCodigo)
        Me.groupBox1.Controls.Add(Me.rdbColor)
        Me.groupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.groupBox1.Location = New System.Drawing.Point(4, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(143, 38)
        Me.groupBox1.TabIndex = 227
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Criterios de Búsqueda"
        '
        'rdbCodigo
        '
        Me.rdbCodigo.AutoSize = True
        Me.rdbCodigo.Location = New System.Drawing.Point(6, 15)
        Me.rdbCodigo.Name = "rdbCodigo"
        Me.rdbCodigo.Size = New System.Drawing.Size(58, 17)
        Me.rdbCodigo.TabIndex = 6
        Me.rdbCodigo.TabStop = True
        Me.rdbCodigo.Text = "Código"
        Me.rdbCodigo.UseVisualStyleBackColor = True
        '
        'rdbColor
        '
        Me.rdbColor.AutoSize = True
        Me.rdbColor.Checked = True
        Me.rdbColor.Location = New System.Drawing.Point(76, 15)
        Me.rdbColor.Name = "rdbColor"
        Me.rdbColor.Size = New System.Drawing.Size(50, 17)
        Me.rdbColor.TabIndex = 3
        Me.rdbColor.TabStop = True
        Me.rdbColor.Text = "Color"
        Me.rdbColor.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(169, 18)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(45, 15)
        Me.label7.TabIndex = 226
        Me.label7.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(220, 15)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(227, 23)
        Me.txtBuscar.TabIndex = 224
        '
        'DgvColoresDetallados
        '
        Me.DgvColoresDetallados.AllowUserToAddRows = False
        Me.DgvColoresDetallados.AllowUserToDeleteRows = False
        Me.DgvColoresDetallados.AllowUserToResizeColumns = False
        Me.DgvColoresDetallados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvColoresDetallados.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DgvColoresDetallados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvColoresDetallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvColoresDetallados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColorDetalle, Me.NameDetailColor, Me.ArgbDetailColor, Me.ColorDetail})
        Me.DgvColoresDetallados.Location = New System.Drawing.Point(4, 385)
        Me.DgvColoresDetallados.MultiSelect = False
        Me.DgvColoresDetallados.Name = "DgvColoresDetallados"
        Me.DgvColoresDetallados.ReadOnly = True
        Me.DgvColoresDetallados.RowTemplate.Height = 42
        Me.DgvColoresDetallados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvColoresDetallados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvColoresDetallados.Size = New System.Drawing.Size(452, 198)
        Me.DgvColoresDetallados.StandardTab = True
        Me.DgvColoresDetallados.TabIndex = 230
        Me.DgvColoresDetallados.TabStop = False
        '
        'IDColorDetalle
        '
        Me.IDColorDetalle.HeaderText = "ID-Sub"
        Me.IDColorDetalle.Name = "IDColorDetalle"
        Me.IDColorDetalle.ReadOnly = True
        Me.IDColorDetalle.Visible = False
        '
        'NameDetailColor
        '
        Me.NameDetailColor.HeaderText = "Descripción"
        Me.NameDetailColor.Name = "NameDetailColor"
        Me.NameDetailColor.ReadOnly = True
        Me.NameDetailColor.Width = 280
        '
        'ArgbDetailColor
        '
        Me.ArgbDetailColor.HeaderText = ""
        Me.ArgbDetailColor.Name = "ArgbDetailColor"
        Me.ArgbDetailColor.ReadOnly = True
        Me.ArgbDetailColor.Visible = False
        '
        'ColorDetail
        '
        Me.ColorDetail.HeaderText = ""
        Me.ColorDetail.Name = "ColorDetail"
        Me.ColorDetail.ReadOnly = True
        Me.ColorDetail.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColorDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColorDetail.Width = 130
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 586)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(459, 25)
        Me.BarraEstado.TabIndex = 414
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
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 22)
        Me.LabelStatus.Text = "Listo"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID-Sub"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 280
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = ""
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 130
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 280
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = ""
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 130
        '
        'frm_buscar_colores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 611)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.DgvColoresDetallados)
        Me.Controls.Add(Me.DgvColor)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtBuscar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_buscar_colores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Colores"
        CType(Me.DgvColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.DgvColoresDetallados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvColor As DataGridView
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents rdbCodigo As RadioButton
    Friend WithEvents rdbColor As RadioButton
    Private WithEvents label7 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents DgvColoresDetallados As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents IDColorDetalle As DataGridViewTextBoxColumn
    Friend WithEvents NameDetailColor As DataGridViewTextBoxColumn
    Friend WithEvents ArgbDetailColor As DataGridViewTextBoxColumn
    Friend WithEvents ColorDetail As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents LabelStatus As ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents IDColor As DataGridViewTextBoxColumn
    Friend WithEvents Grupo As DataGridViewTextBoxColumn
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents ImageColorGroup As DataGridViewImageColumn
End Class
