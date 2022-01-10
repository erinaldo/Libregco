<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_current_version_sys
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_current_version_sys))
        Me.PicImagenLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblversion = New System.Windows.Forms.Label()
        Me.lblLanzamiento = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DgvNotas = New System.Windows.Forms.DataGridView()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.lblAño = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PicImagenLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicImagenLogo
        '
        Me.PicImagenLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicImagenLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicImagenLogo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PicImagenLogo.Location = New System.Drawing.Point(24, 12)
        Me.PicImagenLogo.Name = "PicImagenLogo"
        Me.PicImagenLogo.Size = New System.Drawing.Size(237, 218)
        Me.PicImagenLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagenLogo.TabIndex = 179
        Me.PicImagenLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 46.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(277, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 84)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "Libregco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(286, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 19)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Sistema Modular Integral"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(286, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 19)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Ultima versión:"
        '
        'lblversion
        '
        Me.lblversion.AutoSize = True
        Me.lblversion.BackColor = System.Drawing.Color.Transparent
        Me.lblversion.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblversion.Location = New System.Drawing.Point(392, 148)
        Me.lblversion.Name = "lblversion"
        Me.lblversion.Size = New System.Drawing.Size(0, 19)
        Me.lblversion.TabIndex = 183
        '
        'lblLanzamiento
        '
        Me.lblLanzamiento.AutoSize = True
        Me.lblLanzamiento.BackColor = System.Drawing.Color.Transparent
        Me.lblLanzamiento.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblLanzamiento.Location = New System.Drawing.Point(392, 167)
        Me.lblLanzamiento.Name = "lblLanzamiento"
        Me.lblLanzamiento.Size = New System.Drawing.Size(0, 19)
        Me.lblLanzamiento.TabIndex = 185
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(286, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 19)
        Me.Label5.TabIndex = 184
        Me.Label5.Text = "Lanzada el:"
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.BackColor = System.Drawing.Color.Transparent
        Me.lblBuild.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblBuild.Location = New System.Drawing.Point(392, 129)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(0, 19)
        Me.lblBuild.TabIndex = 187
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(286, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 19)
        Me.Label7.TabIndex = 186
        Me.Label7.Text = "ID Build:"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.BackColor = System.Drawing.Color.Transparent
        Me.lblSize.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSize.Location = New System.Drawing.Point(392, 205)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(0, 19)
        Me.lblSize.TabIndex = 189
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label9.Location = New System.Drawing.Point(286, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 19)
        Me.Label9.TabIndex = 188
        Me.Label9.Text = "Tamaño:"
        '
        'DgvNotas
        '
        Me.DgvNotas.AllowUserToAddRows = False
        Me.DgvNotas.AllowUserToDeleteRows = False
        Me.DgvNotas.AllowUserToResizeColumns = False
        Me.DgvNotas.AllowUserToResizeRows = False
        Me.DgvNotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvNotas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DgvNotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvNotas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DgvNotas.Location = New System.Drawing.Point(18, 247)
        Me.DgvNotas.MultiSelect = False
        Me.DgvNotas.Name = "DgvNotas"
        Me.DgvNotas.ReadOnly = True
        Me.DgvNotas.RowHeadersVisible = False
        Me.DgvNotas.RowHeadersWidth = 40
        Me.DgvNotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNotas.RowTemplate.Height = 42
        Me.DgvNotas.RowTemplate.ReadOnly = True
        Me.DgvNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvNotas.Size = New System.Drawing.Size(735, 302)
        Me.DgvNotas.TabIndex = 190
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 563)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(771, 25)
        Me.BarraEstado.TabIndex = 348
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
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.BackColor = System.Drawing.Color.Transparent
        Me.lblAño.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblAño.Location = New System.Drawing.Point(392, 186)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(0, 19)
        Me.lblAño.TabIndex = 349
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn2.HeaderText = "Novedades"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 740
        '
        'frm_current_version_sys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(771, 588)
        Me.Controls.Add(Me.lblAño)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.DgvNotas)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblBuild)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLanzamiento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblversion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PicImagenLogo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_current_version_sys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Versión actual del sistema"
        CType(Me.PicImagenLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicImagenLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblversion As System.Windows.Forms.Label
    Friend WithEvents lblLanzamiento As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblBuild As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DgvNotas As System.Windows.Forms.DataGridView
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
