<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_hacer_foto_cliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_hacer_foto_cliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PreviewPictureBox = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.RotateBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.rdbCortar = New System.Windows.Forms.RadioButton()
        Me.rdbMover = New System.Windows.Forms.RadioButton()
        Me.PanelPic = New System.Windows.Forms.Panel()
        Me.crobPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.PreviewPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.BarraEstado.SuspendLayout
        Me.PanelPic.SuspendLayout
        CType(Me.crobPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Imagen seleccionada"
        '
        'PreviewPictureBox
        '
        Me.PreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewPictureBox.Location = New System.Drawing.Point(432, 22)
        Me.PreviewPictureBox.Name = "PreviewPictureBox"
        Me.PreviewPictureBox.Size = New System.Drawing.Size(300, 300)
        Me.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PreviewPictureBox.TabIndex = 1
        Me.PreviewPictureBox.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 639)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(737, 25)
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
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'RotateBtn
        '
        Me.RotateBtn.Location = New System.Drawing.Point(190, 578)
        Me.RotateBtn.Name = "RotateBtn"
        Me.RotateBtn.Size = New System.Drawing.Size(79, 36)
        Me.RotateBtn.TabIndex = 415
        Me.RotateBtn.Text = "Rotar"
        Me.RotateBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 617)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 15)
        Me.Label2.TabIndex = 416
        Me.Label2.Text = "Ubicación del archivo:"
        '
        'lblPath
        '
        Me.lblPath.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPath.Location = New System.Drawing.Point(130, 617)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(595, 22)
        Me.lblPath.TabIndex = 417
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(429, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 418
        Me.Label3.Text = "Preview"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(432, 328)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(159, 23)
        Me.btnGuardar.TabIndex = 419
        Me.btnGuardar.Text = "Guardar imagen..."
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(597, 328)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 23)
        Me.Button2.TabIndex = 420
        Me.Button2.Text = "Seleccionar como foto"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.Libregco.My.Resources.Resources.Picture_x32
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(3, 578)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(181, 36)
        Me.Button3.TabIndex = 421
        Me.Button3.Text = "Seleccionar otra imagen"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(275, 578)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 36)
        Me.Button1.TabIndex = 426
        Me.Button1.Text = "Zoom +"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(346, 578)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 36)
        Me.Button4.TabIndex = 427
        Me.Button4.Text = "Zoom -"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'rdbCortar
        '
        Me.rdbCortar.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdbCortar.AutoSize = True
        Me.rdbCortar.Checked = True
        Me.rdbCortar.Location = New System.Drawing.Point(316, 6)
        Me.rdbCortar.Name = "rdbCortar"
        Me.rdbCortar.Size = New System.Drawing.Size(50, 25)
        Me.rdbCortar.TabIndex = 428
        Me.rdbCortar.TabStop = True
        Me.rdbCortar.Text = "Cortar"
        Me.rdbCortar.UseVisualStyleBackColor = True
        '
        'rdbMover
        '
        Me.rdbMover.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdbMover.AutoSize = True
        Me.rdbMover.Location = New System.Drawing.Point(372, 6)
        Me.rdbMover.Name = "rdbMover"
        Me.rdbMover.Size = New System.Drawing.Size(51, 25)
        Me.rdbMover.TabIndex = 429
        Me.rdbMover.Text = "Mover"
        Me.rdbMover.UseVisualStyleBackColor = True
        '
        'PanelPic
        '
        Me.PanelPic.AutoScroll = True
        Me.PanelPic.Controls.Add(Me.crobPictureBox)
        Me.PanelPic.Location = New System.Drawing.Point(7, 21)
        Me.PanelPic.Name = "PanelPic"
        Me.PanelPic.Size = New System.Drawing.Size(416, 551)
        Me.PanelPic.TabIndex = 430
        '
        'crobPictureBox
        '
        Me.crobPictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.crobPictureBox.Location = New System.Drawing.Point(0, 3)
        Me.crobPictureBox.Name = "crobPictureBox"
        Me.crobPictureBox.Size = New System.Drawing.Size(413, 545)
        Me.crobPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.crobPictureBox.TabIndex = 2
        Me.crobPictureBox.TabStop = false
        '
        'frm_hacer_foto_cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 664)
        Me.Controls.Add(Me.rdbMover)
        Me.Controls.Add(Me.rdbCortar)
        Me.Controls.Add(Me.PanelPic)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RotateBtn)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PreviewPictureBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frm_hacer_foto_cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selección y recortes de imagen"
        CType(Me.PreviewPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.BarraEstado.ResumeLayout(false)
        Me.BarraEstado.PerformLayout
        Me.PanelPic.ResumeLayout(false)
        CType(Me.crobPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents PreviewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents RotateBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents rdbCortar As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMover As System.Windows.Forms.RadioButton
    Friend WithEvents PanelPic As System.Windows.Forms.Panel
    Friend WithEvents crobPictureBox As System.Windows.Forms.PictureBox
End Class
