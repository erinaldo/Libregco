<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_cambiar_nuevo_password
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cambiar_nuevo_password))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.lblLenConfPassword = New System.Windows.Forms.Label()
        Me.lblLenPassword = New System.Windows.Forms.Label()
        Me.lblConfirmacionPassword = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConfirmarPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.LogoLibregco = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMenu.SuspendLayout()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel3.Controls.Add(Me.PicBoxLogo)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(631, 74)
        Me.Panel3.TabIndex = 146
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 3)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(208, 68)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.White
        Me.PanelMenu.Controls.Add(Me.lblLenConfPassword)
        Me.PanelMenu.Controls.Add(Me.lblLenPassword)
        Me.PanelMenu.Controls.Add(Me.lblConfirmacionPassword)
        Me.PanelMenu.Controls.Add(Me.Label4)
        Me.PanelMenu.Controls.Add(Me.txtConfirmarPassword)
        Me.PanelMenu.Controls.Add(Me.txtPassword)
        Me.PanelMenu.Controls.Add(Me.btn_Iniciar)
        Me.PanelMenu.Controls.Add(Me.Label1)
        Me.PanelMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.PanelMenu.Location = New System.Drawing.Point(250, 80)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(370, 300)
        Me.PanelMenu.TabIndex = 141
        '
        'lblLenConfPassword
        '
        Me.lblLenConfPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLenConfPassword.Location = New System.Drawing.Point(264, 118)
        Me.lblLenConfPassword.Name = "lblLenConfPassword"
        Me.lblLenConfPassword.Size = New System.Drawing.Size(26, 23)
        Me.lblLenConfPassword.TabIndex = 11
        Me.lblLenConfPassword.Text = "0"
        Me.lblLenConfPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLenPassword
        '
        Me.lblLenPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLenPassword.Location = New System.Drawing.Point(264, 72)
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
        Me.lblConfirmacionPassword.Location = New System.Drawing.Point(16, 100)
        Me.lblConfirmacionPassword.Name = "lblConfirmacionPassword"
        Me.lblConfirmacionPassword.Size = New System.Drawing.Size(131, 15)
        Me.lblConfirmacionPassword.TabIndex = 9
        Me.lblConfirmacionPassword.Text = "Confirma tu contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Escriba la nueva contraseña"
        '
        'txtConfirmarPassword
        '
        Me.txtConfirmarPassword.Location = New System.Drawing.Point(19, 118)
        Me.txtConfirmarPassword.Name = "txtConfirmarPassword"
        Me.txtConfirmarPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarPassword.Size = New System.Drawing.Size(246, 23)
        Me.txtConfirmarPassword.TabIndex = 7
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(19, 72)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(246, 23)
        Me.txtPassword.TabIndex = 6
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
        Me.btn_Iniciar.Location = New System.Drawing.Point(232, 158)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(120, 32)
        Me.btn_Iniciar.TabIndex = 5
        Me.btn_Iniciar.Text = "Continuar"
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(352, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Restableciendo Nueva Contraseña"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Location = New System.Drawing.Point(0, 388)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 74)
        Me.Panel1.TabIndex = 144
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblVersion.Location = New System.Drawing.Point(205, 206)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(15, 15)
        Me.lblVersion.TabIndex = 142
        Me.lblVersion.Text = " v"
        '
        'LogoLibregco
        '
        Me.LogoLibregco.BackColor = System.Drawing.Color.Transparent
        Me.LogoLibregco.Location = New System.Drawing.Point(7, 169)
        Me.LogoLibregco.Name = "LogoLibregco"
        Me.LogoLibregco.Size = New System.Drawing.Size(88, 76)
        Me.LogoLibregco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoLibregco.TabIndex = 140
        Me.LogoLibregco.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(97, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 45)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Libregco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(100, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 15)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Sistema Modular Integral"
        '
        'frm_cambiar_nuevo_password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 462)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.LogoLibregco)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cambiar_nuevo_password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Restablecer contraseña"
        Me.Panel3.ResumeLayout(False)
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelMenu.PerformLayout()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelMenu As System.Windows.Forms.Panel
    Friend WithEvents lblConfirmacionPassword As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmarPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btn_Iniciar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents LogoLibregco As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLenConfPassword As System.Windows.Forms.Label
    Friend WithEvents lblLenPassword As System.Windows.Forms.Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
End Class
