<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visualizar_imagenes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visualizar_imagenes))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.DgvImagenes = New System.Windows.Forms.DataGridView()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BarraEstado.SuspendLayout()
        CType(Me.DgvImagenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 720)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(594, 25)
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
        'DgvImagenes
        '
        Me.DgvImagenes.AllowUserToAddRows = False
        Me.DgvImagenes.AllowUserToDeleteRows = False
        Me.DgvImagenes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvImagenes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvImagenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvImagenes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Imagen})
        Me.DgvImagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvImagenes.Location = New System.Drawing.Point(0, 0)
        Me.DgvImagenes.Name = "DgvImagenes"
        Me.DgvImagenes.ReadOnly = True
        Me.DgvImagenes.RowTemplate.Height = 120
        Me.DgvImagenes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvImagenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvImagenes.Size = New System.Drawing.Size(594, 720)
        Me.DgvImagenes.TabIndex = 415
        '
        'Descripcion
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 220
        '
        'Imagen
        '
        Me.Imagen.HeaderText = "Imagen"
        Me.Imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Imagen.Name = "Imagen"
        Me.Imagen.ReadOnly = True
        Me.Imagen.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Imagen.Width = 340
        '
        'frm_visualizar_imagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 745)
        Me.Controls.Add(Me.DgvImagenes)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_visualizar_imagenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Imágenes del artículo"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.DgvImagenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DgvImagenes As System.Windows.Forms.DataGridView
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Imagen As System.Windows.Forms.DataGridViewImageColumn
End Class
