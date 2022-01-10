<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cambiar_fondoinicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cambiar_fondoinicio))
        Me.PicBackGround = New System.Windows.Forms.PictureBox()
        Me.lblFondoInicio = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.StatusStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.TabPagesFondos = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.DgvFondosDisponibles = New System.Windows.Forms.DataGridView()
        Me.Rutas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fondos = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IDColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuFondoInicio = New System.Windows.Forms.MenuStrip()
        Me.btnBuscarFondoInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVisualizarFondoInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarFondoInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MenuFondos = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVerFondos = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarFondos = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgvFondos = New System.Windows.Forms.DataGridView()
        Me.FlashMenu = New System.Windows.Forms.ToolStrip()
        Me.btnChangeWindows = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        CType(Me.PicBackGround, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.TabPagesFondos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvFondosDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuFondoInicio.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.MenuFondos.SuspendLayout()
        CType(Me.DgvFondos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlashMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBackGround
        '
        Me.PicBackGround.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicBackGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBackGround.Location = New System.Drawing.Point(0, 0)
        Me.PicBackGround.Name = "PicBackGround"
        Me.PicBackGround.Size = New System.Drawing.Size(614, 405)
        Me.PicBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBackGround.TabIndex = 0
        Me.PicBackGround.TabStop = False
        '
        'lblFondoInicio
        '
        Me.lblFondoInicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFondoInicio.Location = New System.Drawing.Point(8, 408)
        Me.lblFondoInicio.Name = "lblFondoInicio"
        Me.lblFondoInicio.Size = New System.Drawing.Size(447, 17)
        Me.lblFondoInicio.TabIndex = 1
        '
        'BarraEstado
        '
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.PicLoading, Me.ToolSeparator2, Me.NameSys, Me.ToolSeparator, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 455)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(922, 22)
        Me.BarraEstado.SizingGrip = False
        Me.BarraEstado.TabIndex = 191
        Me.BarraEstado.Text = "StatusStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 20)
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = Global.Libregco.My.Resources.Resources.Loading
        Me.PicLoading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLoading.Name = "PicLoading"
        Me.PicLoading.Size = New System.Drawing.Size(23, 21)
        Me.PicLoading.Text = "ToolStripButton1"
        Me.PicLoading.Visible = False
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 23)
        Me.ToolSeparator2.Visible = False
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 20)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator
        '
        Me.ToolSeparator.Name = "ToolSeparator"
        Me.ToolSeparator.Size = New System.Drawing.Size(6, 23)
        Me.ToolSeparator.Visible = False
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 20)
        Me.lblStatusBar.Text = "Listo"
        '
        'TabPagesFondos
        '
        Me.TabPagesFondos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabPagesFondos.Controls.Add(Me.TabPage1)
        Me.TabPagesFondos.Controls.Add(Me.TabPage2)
        Me.TabPagesFondos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabPagesFondos.Location = New System.Drawing.Point(0, 1)
        Me.TabPagesFondos.Multiline = True
        Me.TabPagesFondos.Name = "TabPagesFondos"
        Me.TabPagesFondos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPagesFondos.SelectedIndex = 0
        Me.TabPagesFondos.Size = New System.Drawing.Size(923, 451)
        Me.TabPagesFondos.TabIndex = 192
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblColor)
        Me.TabPage1.Controls.Add(Me.DgvFondosDisponibles)
        Me.TabPage1.Controls.Add(Me.MenuFondoInicio)
        Me.TabPage1.Controls.Add(Me.lblFondoInicio)
        Me.TabPage1.Controls.Add(Me.PicBackGround)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(915, 425)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fondo Inicio"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblColor
        '
        Me.lblColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(461, 408)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(0, 13)
        Me.lblColor.TabIndex = 12
        '
        'DgvFondosDisponibles
        '
        Me.DgvFondosDisponibles.AllowUserToAddRows = False
        Me.DgvFondosDisponibles.AllowUserToDeleteRows = False
        Me.DgvFondosDisponibles.AllowUserToResizeColumns = False
        Me.DgvFondosDisponibles.AllowUserToResizeRows = False
        Me.DgvFondosDisponibles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvFondosDisponibles.BackgroundColor = System.Drawing.Color.White
        Me.DgvFondosDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvFondosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvFondosDisponibles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rutas, Me.Fondos, Me.IDColor})
        Me.DgvFondosDisponibles.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvFondosDisponibles.Location = New System.Drawing.Point(613, 0)
        Me.DgvFondosDisponibles.Name = "DgvFondosDisponibles"
        Me.DgvFondosDisponibles.ReadOnly = True
        Me.DgvFondosDisponibles.RowHeadersVisible = False
        Me.DgvFondosDisponibles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvFondosDisponibles.RowTemplate.Height = 80
        Me.DgvFondosDisponibles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvFondosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFondosDisponibles.Size = New System.Drawing.Size(222, 408)
        Me.DgvFondosDisponibles.TabIndex = 11
        '
        'Rutas
        '
        Me.Rutas.HeaderText = "Rutas"
        Me.Rutas.Name = "Rutas"
        Me.Rutas.ReadOnly = True
        Me.Rutas.Visible = False
        '
        'Fondos
        '
        Me.Fondos.HeaderText = "Fondos Disponibles"
        Me.Fondos.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Fondos.Name = "Fondos"
        Me.Fondos.ReadOnly = True
        Me.Fondos.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Fondos.Width = 220
        '
        'IDColor
        '
        Me.IDColor.HeaderText = "Color"
        Me.IDColor.Name = "IDColor"
        Me.IDColor.ReadOnly = True
        Me.IDColor.Visible = False
        '
        'MenuFondoInicio
        '
        Me.MenuFondoInicio.BackColor = System.Drawing.Color.White
        Me.MenuFondoInicio.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuFondoInicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscarFondoInicio, Me.btnVisualizarFondoInicio, Me.btnGuardarFondoInicio})
        Me.MenuFondoInicio.Location = New System.Drawing.Point(838, 3)
        Me.MenuFondoInicio.Name = "MenuFondoInicio"
        Me.MenuFondoInicio.Size = New System.Drawing.Size(74, 419)
        Me.MenuFondoInicio.TabIndex = 10
        Me.MenuFondoInicio.Text = "MenuStrip1"
        '
        'btnBuscarFondoInicio
        '
        Me.btnBuscarFondoInicio.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarFondoInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarFondoInicio.Name = "btnBuscarFondoInicio"
        Me.btnBuscarFondoInicio.Size = New System.Drawing.Size(61, 67)
        Me.btnBuscarFondoInicio.Text = "Buscar"
        Me.btnBuscarFondoInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnVisualizarFondoInicio
        '
        Me.btnVisualizarFondoInicio.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnVisualizarFondoInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnVisualizarFondoInicio.Name = "btnVisualizarFondoInicio"
        Me.btnVisualizarFondoInicio.Size = New System.Drawing.Size(61, 67)
        Me.btnVisualizarFondoInicio.Text = "Visualizar"
        Me.btnVisualizarFondoInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarFondoInicio
        '
        Me.btnGuardarFondoInicio.Image = Global.Libregco.My.Resources.Resources.Save_Option_x48
        Me.btnGuardarFondoInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarFondoInicio.Name = "btnGuardarFondoInicio"
        Me.btnGuardarFondoInicio.Size = New System.Drawing.Size(61, 67)
        Me.btnGuardarFondoInicio.Text = "Guardar"
        Me.btnGuardarFondoInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.MenuFondos)
        Me.TabPage2.Controls.Add(Me.DgvFondos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(915, 425)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Fondos de Pantalla"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MenuFondos
        '
        Me.MenuFondos.BackColor = System.Drawing.Color.White
        Me.MenuFondos.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuFondos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnEliminar, Me.btnVerFondos, Me.btnGuardarFondos})
        Me.MenuFondos.Location = New System.Drawing.Point(838, 3)
        Me.MenuFondos.Name = "MenuFondos"
        Me.MenuFondos.Size = New System.Drawing.Size(74, 419)
        Me.MenuFondos.TabIndex = 1
        Me.MenuFondos.Text = "MenuStrip1"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(61, 67)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x48
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(61, 67)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnVerFondos
        '
        Me.btnVerFondos.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnVerFondos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnVerFondos.Name = "btnVerFondos"
        Me.btnVerFondos.Size = New System.Drawing.Size(61, 67)
        Me.btnVerFondos.Text = "Visualizar"
        Me.btnVerFondos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarFondos
        '
        Me.btnGuardarFondos.Image = Global.Libregco.My.Resources.Resources.Save_Option_x48
        Me.btnGuardarFondos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarFondos.Name = "btnGuardarFondos"
        Me.btnGuardarFondos.Size = New System.Drawing.Size(61, 67)
        Me.btnGuardarFondos.Text = "Guardar"
        Me.btnGuardarFondos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DgvFondos
        '
        Me.DgvFondos.AllowUserToAddRows = False
        Me.DgvFondos.AllowUserToDeleteRows = False
        Me.DgvFondos.AllowUserToResizeColumns = False
        Me.DgvFondos.AllowUserToResizeRows = False
        Me.DgvFondos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvFondos.BackgroundColor = System.Drawing.Color.White
        Me.DgvFondos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvFondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvFondos.Location = New System.Drawing.Point(-2, 1)
        Me.DgvFondos.Name = "DgvFondos"
        Me.DgvFondos.RowHeadersVisible = False
        Me.DgvFondos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvFondos.RowTemplate.Height = 80
        Me.DgvFondos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvFondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFondos.Size = New System.Drawing.Size(837, 424)
        Me.DgvFondos.TabIndex = 0
        '
        'FlashMenu
        '
        Me.FlashMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlashMenu.AutoSize = False
        Me.FlashMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.FlashMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.FlashMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnChangeWindows, Me.btnClose})
        Me.FlashMenu.Location = New System.Drawing.Point(750, 418)
        Me.FlashMenu.Name = "FlashMenu"
        Me.FlashMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.FlashMenu.Size = New System.Drawing.Size(282, 39)
        Me.FlashMenu.TabIndex = 193
        Me.FlashMenu.Visible = False
        '
        'btnChangeWindows
        '
        Me.btnChangeWindows.ForeColor = System.Drawing.Color.Black
        Me.btnChangeWindows.Image = Global.Libregco.My.Resources.Resources.Mission_Control_x32
        Me.btnChangeWindows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnChangeWindows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChangeWindows.Name = "btnChangeWindows"
        Me.btnChangeWindows.Size = New System.Drawing.Size(98, 36)
        Me.btnChangeWindows.Text = "Maximizar"
        Me.btnChangeWindows.ToolTipText = "Maximizar o restaurar la ventana"
        Me.btnChangeWindows.Visible = False
        '
        'btnClose
        '
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = Global.Libregco.My.Resources.Resources.TurnOff_x32
        Me.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 36)
        Me.btnClose.Text = "Cerrar"
        Me.btnClose.ToolTipText = "Cerrar el Sistema"
        '
        'frm_cambiar_fondoinicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 477)
        Me.Controls.Add(Me.TabPagesFondos)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.FlashMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cambiar_fondoinicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fondos de pantalla"
        CType(Me.PicBackGround, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.TabPagesFondos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvFondosDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuFondoInicio.ResumeLayout(False)
        Me.MenuFondoInicio.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.MenuFondos.ResumeLayout(False)
        Me.MenuFondos.PerformLayout()
        CType(Me.DgvFondos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlashMenu.ResumeLayout(False)
        Me.FlashMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicBackGround As System.Windows.Forms.PictureBox
    Friend WithEvents lblFondoInicio As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents TabPagesFondos As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DgvFondos As DataGridView
    Friend WithEvents MenuFondos As MenuStrip
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnVerFondos As ToolStripMenuItem
    Friend WithEvents btnGuardarFondos As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents FlashMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents btnChangeWindows As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuFondoInicio As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscarFondoInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnVisualizarFondoInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarFondoInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvFondosDisponibles As System.Windows.Forms.DataGridView
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Rutas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fondos As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents IDColor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
End Class
