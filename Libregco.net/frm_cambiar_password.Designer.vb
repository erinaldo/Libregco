<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_cambiar_password
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cambiar_password))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.lblVersionTop = New System.Windows.Forms.Label()
        Me.LogoLibregco = New System.Windows.Forms.PictureBox()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.lblCurrentPassword = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtActualPassword = New System.Windows.Forms.TextBox()
        Me.lblLenConfPassword = New System.Windows.Forms.Label()
        Me.lblLenPassword = New System.Windows.Forms.Label()
        Me.lblConfirmacionPassword = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConfirmarPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel3.Controls.Add(Me.PicBoxLogo)
        Me.Panel3.Location = New System.Drawing.Point(-1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(631, 74)
        Me.Panel3.TabIndex = 147
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(8, 5)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(190, 63)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'lblVersionTop
        '
        Me.lblVersionTop.AutoSize = True
        Me.lblVersionTop.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblVersionTop.Location = New System.Drawing.Point(205, 207)
        Me.lblVersionTop.Name = "lblVersionTop"
        Me.lblVersionTop.Size = New System.Drawing.Size(15, 15)
        Me.lblVersionTop.TabIndex = 151
        Me.lblVersionTop.Text = " v"
        '
        'LogoLibregco
        '
        Me.LogoLibregco.BackColor = System.Drawing.Color.Transparent
        Me.LogoLibregco.Location = New System.Drawing.Point(6, 174)
        Me.LogoLibregco.Name = "LogoLibregco"
        Me.LogoLibregco.Size = New System.Drawing.Size(88, 76)
        Me.LogoLibregco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoLibregco.TabIndex = 148
        Me.LogoLibregco.TabStop = False
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.White
        Me.PanelMenu.Controls.Add(Me.lblCurrentPassword)
        Me.PanelMenu.Controls.Add(Me.Label5)
        Me.PanelMenu.Controls.Add(Me.txtActualPassword)
        Me.PanelMenu.Controls.Add(Me.lblLenConfPassword)
        Me.PanelMenu.Controls.Add(Me.lblLenPassword)
        Me.PanelMenu.Controls.Add(Me.lblConfirmacionPassword)
        Me.PanelMenu.Controls.Add(Me.Label4)
        Me.PanelMenu.Controls.Add(Me.txtConfirmarPassword)
        Me.PanelMenu.Controls.Add(Me.txtPassword)
        Me.PanelMenu.Controls.Add(Me.btn_Iniciar)
        Me.PanelMenu.Controls.Add(Me.Label1)
        Me.PanelMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PanelMenu.Location = New System.Drawing.Point(250, 82)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(370, 300)
        Me.PanelMenu.TabIndex = 149
        '
        'lblCurrentPassword
        '
        Me.lblCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentPassword.Location = New System.Drawing.Point(264, 60)
        Me.lblCurrentPassword.Name = "lblCurrentPassword"
        Me.lblCurrentPassword.Size = New System.Drawing.Size(26, 23)
        Me.lblCurrentPassword.TabIndex = 14
        Me.lblCurrentPassword.Text = "0"
        Me.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Escriba la contraseña actual"
        '
        'txtActualPassword
        '
        Me.txtActualPassword.Location = New System.Drawing.Point(19, 60)
        Me.txtActualPassword.Name = "txtActualPassword"
        Me.txtActualPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtActualPassword.Size = New System.Drawing.Size(246, 23)
        Me.txtActualPassword.TabIndex = 0
        '
        'lblLenConfPassword
        '
        Me.lblLenConfPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLenConfPassword.Location = New System.Drawing.Point(264, 148)
        Me.lblLenConfPassword.Name = "lblLenConfPassword"
        Me.lblLenConfPassword.Size = New System.Drawing.Size(26, 23)
        Me.lblLenConfPassword.TabIndex = 11
        Me.lblLenConfPassword.Text = "0"
        Me.lblLenConfPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLenPassword
        '
        Me.lblLenPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLenPassword.Location = New System.Drawing.Point(264, 104)
        Me.lblLenPassword.Name = "lblLenPassword"
        Me.lblLenPassword.Size = New System.Drawing.Size(26, 23)
        Me.lblLenPassword.TabIndex = 10
        Me.lblLenPassword.Text = "0"
        Me.lblLenPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblConfirmacionPassword
        '
        Me.lblConfirmacionPassword.AutoSize = True
        Me.lblConfirmacionPassword.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmacionPassword.Location = New System.Drawing.Point(16, 130)
        Me.lblConfirmacionPassword.Name = "lblConfirmacionPassword"
        Me.lblConfirmacionPassword.Size = New System.Drawing.Size(131, 15)
        Me.lblConfirmacionPassword.TabIndex = 9
        Me.lblConfirmacionPassword.Text = "Confirma tu contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Escriba la nueva contraseña"
        '
        'txtConfirmarPassword
        '
        Me.txtConfirmarPassword.Location = New System.Drawing.Point(19, 148)
        Me.txtConfirmarPassword.Name = "txtConfirmarPassword"
        Me.txtConfirmarPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarPassword.Size = New System.Drawing.Size(246, 23)
        Me.txtConfirmarPassword.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(19, 104)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(246, 23)
        Me.txtPassword.TabIndex = 1
        '
        'btn_Iniciar
        '
        Me.btn_Iniciar.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderSize = 0
        Me.btn_Iniciar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Iniciar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_Iniciar.Location = New System.Drawing.Point(236, 188)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(120, 32)
        Me.btn_Iniciar.TabIndex = 3
        Me.btn_Iniciar.Text = "Continuar"
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(14, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cambiando Contraseña"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(97, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 45)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Libregco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(100, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 15)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Sistema Modular Integral"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Location = New System.Drawing.Point(0, 390)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 74)
        Me.Panel1.TabIndex = 153
        '
        'frm_cambiar_password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 462)
        Me.Controls.Add(Me.lblVersionTop)
        Me.Controls.Add(Me.LogoLibregco)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cambiar_password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar contraseña"
        Me.Panel3.ResumeLayout(False)
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblVersionTop As Label
    Friend WithEvents LogoLibregco As PictureBox
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents lblLenConfPassword As Label
    Friend WithEvents lblLenPassword As Label
    Friend WithEvents lblConfirmacionPassword As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtConfirmarPassword As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btn_Iniciar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtActualPassword As TextBox
    Friend WithEvents lblCurrentPassword As Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
End Class
