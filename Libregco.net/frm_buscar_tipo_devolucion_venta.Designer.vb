<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_tipo_devolucion_venta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_buscar_tipo_devolucion_venta))
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DgvTipoDevolucion = New System.Windows.Forms.DataGridView()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbCodigo = New System.Windows.Forms.RadioButton()
        Me.rdbDescripcion = New System.Windows.Forms.RadioButton()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        CType(Me.DgvTipoDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator.Location = New System.Drawing.Point(0, 301)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(564, 25)
        Me.BindingNavigator.TabIndex = 227
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'DgvTipoDevolucion
        '
        Me.DgvTipoDevolucion.AllowUserToAddRows = False
        Me.DgvTipoDevolucion.AllowUserToDeleteRows = False
        Me.DgvTipoDevolucion.AllowUserToResizeColumns = False
        Me.DgvTipoDevolucion.AllowUserToResizeRows = False
        Me.DgvTipoDevolucion.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvTipoDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvTipoDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTipoDevolucion.Location = New System.Drawing.Point(3, 95)
        Me.DgvTipoDevolucion.MultiSelect = False
        Me.DgvTipoDevolucion.Name = "DgvTipoDevolucion"
        Me.DgvTipoDevolucion.ReadOnly = True
        Me.DgvTipoDevolucion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvTipoDevolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvTipoDevolucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTipoDevolucion.Size = New System.Drawing.Size(556, 199)
        Me.DgvTipoDevolucion.StandardTab = True
        Me.DgvTipoDevolucion.TabIndex = 223
        Me.DgvTipoDevolucion.TabStop = False
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rdbCodigo)
        Me.groupBox1.Controls.Add(Me.rdbDescripcion)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.groupBox1.Location = New System.Drawing.Point(256, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(165, 38)
        Me.groupBox1.TabIndex = 226
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Criterios de Búsqueda"
        '
        'rdbCodigo
        '
        Me.rdbCodigo.AutoSize = True
        Me.rdbCodigo.Location = New System.Drawing.Point(6, 15)
        Me.rdbCodigo.Name = "rdbCodigo"
        Me.rdbCodigo.Size = New System.Drawing.Size(64, 19)
        Me.rdbCodigo.TabIndex = 6
        Me.rdbCodigo.Text = "Código"
        Me.rdbCodigo.UseVisualStyleBackColor = True
        '
        'rdbDescripcion
        '
        Me.rdbDescripcion.AutoSize = True
        Me.rdbDescripcion.Checked = True
        Me.rdbDescripcion.Location = New System.Drawing.Point(76, 15)
        Me.rdbDescripcion.Name = "rdbDescripcion"
        Me.rdbDescripcion.Size = New System.Drawing.Size(87, 19)
        Me.rdbDescripcion.TabIndex = 3
        Me.rdbDescripcion.TabStop = True
        Me.rdbDescripcion.Text = "Descripción"
        Me.rdbDescripcion.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(257, 61)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(45, 15)
        Me.label7.TabIndex = 225
        Me.label7.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(308, 58)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(242, 23)
        Me.txtBuscar.TabIndex = 222
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(3, 4)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(247, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 228
        Me.PicBoxLogo.TabStop = False
        '
        'frm_buscar_tipo_devolucion_venta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 326)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.BindingNavigator)
        Me.Controls.Add(Me.DgvTipoDevolucion)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtBuscar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_buscar_tipo_devolucion_venta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar Tipos de Devolución"
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        CType(Me.DgvTipoDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents DgvTipoDevolucion As DataGridView
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents rdbCodigo As RadioButton
    Friend WithEvents rdbDescripcion As RadioButton
    Private WithEvents label7 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
End Class
