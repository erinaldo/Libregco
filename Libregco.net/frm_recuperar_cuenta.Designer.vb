<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_recuperar_cuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recuperar_cuenta))
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.rdbPCAutorizado = New System.Windows.Forms.RadioButton()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.MessageWatermark = New Libregco.Watermark()
        Me.rdbOtroMotivo = New System.Windows.Forms.RadioButton()
        Me.rdbNoUserName = New System.Windows.Forms.RadioButton()
        Me.rdbNoPassword = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.LogoLibregco = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelMenu.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelInferior
        '
        Me.PanelInferior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInferior.BackColor = System.Drawing.SystemColors.Highlight
        Me.PanelInferior.Location = New System.Drawing.Point(-1, 361)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(633, 74)
        Me.PanelInferior.TabIndex = 138
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.White
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMessage.ForeColor = System.Drawing.Color.Black
        Me.lblMessage.Location = New System.Drawing.Point(16, 161)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(325, 32)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Ingresa tu dirección de correo electrónico. No importa el tipo de dirección este " &
    "asociada a tu cuenta."
        '
        'PanelMenu
        '
        Me.PanelMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelMenu.BackColor = System.Drawing.Color.White
        Me.PanelMenu.Controls.Add(Me.rdbPCAutorizado)
        Me.PanelMenu.Controls.Add(Me.btn_Iniciar)
        Me.PanelMenu.Controls.Add(Me.lblMessage)
        Me.PanelMenu.Controls.Add(Me.MessageWatermark)
        Me.PanelMenu.Controls.Add(Me.rdbOtroMotivo)
        Me.PanelMenu.Controls.Add(Me.rdbNoUserName)
        Me.PanelMenu.Controls.Add(Me.rdbNoPassword)
        Me.PanelMenu.Controls.Add(Me.Label1)
        Me.PanelMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PanelMenu.Location = New System.Drawing.Point(249, 38)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(370, 317)
        Me.PanelMenu.TabIndex = 0
        '
        'rdbPCAutorizado
        '
        Me.rdbPCAutorizado.AutoSize = True
        Me.rdbPCAutorizado.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rdbPCAutorizado.Location = New System.Drawing.Point(19, 135)
        Me.rdbPCAutorizado.Name = "rdbPCAutorizado"
        Me.rdbPCAutorizado.Size = New System.Drawing.Size(201, 23)
        Me.rdbPCAutorizado.TabIndex = 6
        Me.rdbPCAutorizado.Text = "El equipo no está autorizado"
        Me.rdbPCAutorizado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdbPCAutorizado.UseVisualStyleBackColor = True
        '
        'btn_Iniciar
        '
        Me.btn_Iniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Iniciar.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderSize = 0
        Me.btn_Iniciar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Iniciar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_Iniciar.Location = New System.Drawing.Point(232, 273)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(120, 32)
        Me.btn_Iniciar.TabIndex = 5
        Me.btn_Iniciar.Text = "Continuar"
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'MessageWatermark
        '
        Me.MessageWatermark.Location = New System.Drawing.Point(19, 196)
        Me.MessageWatermark.Name = "MessageWatermark"
        Me.MessageWatermark.Size = New System.Drawing.Size(261, 23)
        Me.MessageWatermark.TabIndex = 4
        Me.MessageWatermark.WatermarkColor = System.Drawing.Color.Gray
        Me.MessageWatermark.WatermarkText = ""
        '
        'rdbOtroMotivo
        '
        Me.rdbOtroMotivo.AutoSize = True
        Me.rdbOtroMotivo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rdbOtroMotivo.Location = New System.Drawing.Point(19, 106)
        Me.rdbOtroMotivo.Name = "rdbOtroMotivo"
        Me.rdbOtroMotivo.Size = New System.Drawing.Size(286, 23)
        Me.rdbOtroMotivo.TabIndex = 3
        Me.rdbOtroMotivo.Text = "No puedo iniciar sesión por otros motivos."
        Me.rdbOtroMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdbOtroMotivo.UseVisualStyleBackColor = True
        '
        'rdbNoUserName
        '
        Me.rdbNoUserName.AutoSize = True
        Me.rdbNoUserName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rdbNoUserName.Location = New System.Drawing.Point(19, 78)
        Me.rdbNoUserName.Name = "rdbNoUserName"
        Me.rdbNoUserName.Size = New System.Drawing.Size(201, 23)
        Me.rdbNoUserName.TabIndex = 2
        Me.rdbNoUserName.Text = "No sé mi nombre de usuario"
        Me.rdbNoUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdbNoUserName.UseVisualStyleBackColor = True
        '
        'rdbNoPassword
        '
        Me.rdbNoPassword.AutoSize = True
        Me.rdbNoPassword.Checked = True
        Me.rdbNoPassword.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.rdbNoPassword.Location = New System.Drawing.Point(19, 49)
        Me.rdbNoPassword.Name = "rdbNoPassword"
        Me.rdbNoPassword.Size = New System.Drawing.Size(152, 23)
        Me.rdbNoPassword.TabIndex = 0
        Me.rdbNoPassword.TabStop = True
        Me.rdbNoPassword.Text = "No sé mi contraseña"
        Me.rdbNoPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdbNoPassword.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(338, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "¿Tienes problemas para acceder?"
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelSuperior.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(631, 32)
        Me.PanelSuperior.TabIndex = 140
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 198)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(232, 84)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'LogoLibregco
        '
        Me.LogoLibregco.BackColor = System.Drawing.Color.Transparent
        Me.LogoLibregco.Location = New System.Drawing.Point(7, 115)
        Me.LogoLibregco.Name = "LogoLibregco"
        Me.LogoLibregco.Size = New System.Drawing.Size(88, 76)
        Me.LogoLibregco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoLibregco.TabIndex = 136
        Me.LogoLibregco.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(97, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 45)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Libregco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(100, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 15)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Sistema Modular Integral"
        '
        'frm_recuperar_cuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 435)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelSuperior)
        Me.Controls.Add(Me.PanelInferior)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.LogoLibregco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_recuperar_cuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Soporte de accesos"
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenu.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents PanelMenu As System.Windows.Forms.Panel
    Friend WithEvents rdbOtroMotivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNoUserName As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNoPassword As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_Iniciar As System.Windows.Forms.Button
    Friend WithEvents PanelSuperior As System.Windows.Forms.Panel
    Friend WithEvents LogoLibregco As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents MessageWatermark As Watermark
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents rdbPCAutorizado As System.Windows.Forms.RadioButton
End Class
