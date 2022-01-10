<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_introduccion_servidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_introduccion_servidor))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPuerto = New Libregco.Watermark()
        Me.txtUsuario = New Libregco.Watermark()
        Me.txtDDNS = New Libregco.Watermark()
        Me.txtNombreServidor = New Libregco.Watermark()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Terminalx128
        Me.PictureBox1.Location = New System.Drawing.Point(246, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.Label1.ForeColor = System.Drawing.Color.MediumAquamarine
        Me.Label1.Location = New System.Drawing.Point(29, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(562, 50)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Configuración de terminal a Servidor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(19, 228)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(583, 83)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Para conectarse al sistema es necesario especificar el nombre del equipo Servidor" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Esta configuración es básica e irrepetible para los usuarios. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label3.Location = New System.Drawing.Point(107, 325)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(406, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Por favor escriba el nombre del equipo al que desea conectarse."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 554)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(617, 25)
        Me.BarraEstado.TabIndex = 394
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = CType(resources.GetObject("PicLoading.Image"), System.Drawing.Image)
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
        Me.PicLogo.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
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
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Button1.Location = New System.Drawing.Point(107, 450)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(406, 52)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Comprobar conexión"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(364, 421)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(149, 23)
        Me.txtPuerto.TabIndex = 3
        Me.txtPuerto.Text = "3306"
        Me.txtPuerto.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPuerto.WatermarkText = "Puerto"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(107, 421)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(251, 23)
        Me.txtUsuario.TabIndex = 2
        Me.txtUsuario.Text = "root"
        Me.txtUsuario.WatermarkColor = System.Drawing.Color.Gray
        Me.txtUsuario.WatermarkText = "Usuario"
        '
        'txtDDNS
        '
        Me.txtDDNS.Location = New System.Drawing.Point(107, 392)
        Me.txtDDNS.Name = "txtDDNS"
        Me.txtDDNS.Size = New System.Drawing.Size(406, 23)
        Me.txtDDNS.TabIndex = 1
        Me.txtDDNS.WatermarkColor = System.Drawing.Color.Gray
        Me.txtDDNS.WatermarkText = "DDNS (Opcional)"
        '
        'txtNombreServidor
        '
        Me.txtNombreServidor.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.txtNombreServidor.Location = New System.Drawing.Point(107, 343)
        Me.txtNombreServidor.Name = "txtNombreServidor"
        Me.txtNombreServidor.Size = New System.Drawing.Size(406, 43)
        Me.txtNombreServidor.TabIndex = 0
        Me.txtNombreServidor.WatermarkColor = System.Drawing.Color.Gray
        Me.txtNombreServidor.WatermarkText = "Nombre del Servidor"
        '
        'frm_introduccion_servidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 579)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtDDNS)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtNombreServidor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_introduccion_servidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Introducción del servidor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreServidor As Libregco.Watermark
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDDNS As Libregco.Watermark
    Friend WithEvents txtUsuario As Libregco.Watermark
    Friend WithEvents txtPuerto As Libregco.Watermark
    Friend WithEvents Button1 As Button
End Class
