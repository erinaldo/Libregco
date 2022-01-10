<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_LoginSistema
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_LoginSistema))
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVersionTop = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Iniciar = New System.Windows.Forms.Button()
        Me.IrAyuda = New System.Windows.Forms.LinkLabel()
        Me.lblIntentos = New System.Windows.Forms.Label()
        Me.lblInformacion = New System.Windows.Forms.Label()
        Me.lblIntentosFallidos = New System.Windows.Forms.Label()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.PanelIzquierdo = New System.Windows.Forms.Panel()
        Me.lblIcoConnection = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblConnection = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDesktopAccess = New System.Windows.Forms.Label()
        Me.lblEquipo = New System.Windows.Forms.Label()
        Me.lblNetworkIco = New System.Windows.Forms.Label()
        Me.lblAccesoInternet = New System.Windows.Forms.Label()
        Me.lblInternetIco = New System.Windows.Forms.Label()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.PanelInferior = New System.Windows.Forms.Panel()
        Me.LogoLibregco = New System.Windows.Forms.PictureBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblUnderBare = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TimeAnimationMoney = New System.Windows.Forms.Timer(Me.components)
        Me.HelperTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.BarradeProgreso = New System.Windows.Forms.ProgressBar()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtPassword = New Libregco.NewTextbox()
        Me.txtUser = New Libregco.NewTextbox()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.PanelAviso = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.PanelLogin.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAviso.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblVersion.Location = New System.Drawing.Point(854, 609)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(236, 15)
        Me.lblVersion.TabIndex = 74
        Me.lblVersion.Text = "© Libregco"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(165, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 19)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Sistema Modular Integral"
        '
        'lblVersionTop
        '
        Me.lblVersionTop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblVersionTop.AutoSize = True
        Me.lblVersionTop.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblVersionTop.Location = New System.Drawing.Point(277, 76)
        Me.lblVersionTop.Name = "lblVersionTop"
        Me.lblVersionTop.Size = New System.Drawing.Size(12, 15)
        Me.lblVersionTop.TabIndex = 72
        Me.lblVersionTop.Text = "v"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 26.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(169, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 47)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Libregco"
        '
        'btn_Iniciar
        '
        Me.btn_Iniciar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btn_Iniciar.BackColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btn_Iniciar.FlatAppearance.BorderSize = 0
        Me.btn_Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Iniciar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Iniciar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_Iniciar.Location = New System.Drawing.Point(67, 245)
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.Size = New System.Drawing.Size(261, 42)
        Me.btn_Iniciar.TabIndex = 2
        Me.btn_Iniciar.Text = "Iniciar Sesión"
        Me.btn_Iniciar.UseVisualStyleBackColor = False
        '
        'IrAyuda
        '
        Me.IrAyuda.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.IrAyuda.AutoSize = True
        Me.IrAyuda.BackColor = System.Drawing.Color.Transparent
        Me.IrAyuda.DisabledLinkColor = System.Drawing.Color.WhiteSmoke
        Me.IrAyuda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.IrAyuda.LinkColor = System.Drawing.SystemColors.Highlight
        Me.IrAyuda.Location = New System.Drawing.Point(218, 327)
        Me.IrAyuda.Name = "IrAyuda"
        Me.IrAyuda.Size = New System.Drawing.Size(110, 15)
        Me.IrAyuda.TabIndex = 3
        Me.IrAyuda.TabStop = True
        Me.IrAyuda.Text = "¿ Necesitas Ayuda ?"
        '
        'lblIntentos
        '
        Me.lblIntentos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIntentos.AutoSize = True
        Me.lblIntentos.BackColor = System.Drawing.Color.Transparent
        Me.lblIntentos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIntentos.ForeColor = System.Drawing.Color.Red
        Me.lblIntentos.Location = New System.Drawing.Point(162, 327)
        Me.lblIntentos.Name = "lblIntentos"
        Me.lblIntentos.Size = New System.Drawing.Size(13, 15)
        Me.lblIntentos.TabIndex = 76
        Me.lblIntentos.Text = "0"
        Me.lblIntentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIntentos.Visible = False
        '
        'lblInformacion
        '
        Me.lblInformacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblInformacion.BackColor = System.Drawing.Color.Transparent
        Me.lblInformacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformacion.ForeColor = System.Drawing.Color.Red
        Me.lblInformacion.Location = New System.Drawing.Point(2, 288)
        Me.lblInformacion.Name = "lblInformacion"
        Me.lblInformacion.Size = New System.Drawing.Size(392, 38)
        Me.lblInformacion.TabIndex = 74
        Me.lblInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntentosFallidos
        '
        Me.lblIntentosFallidos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIntentosFallidos.AutoSize = True
        Me.lblIntentosFallidos.BackColor = System.Drawing.Color.Transparent
        Me.lblIntentosFallidos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIntentosFallidos.ForeColor = System.Drawing.Color.Red
        Me.lblIntentosFallidos.Location = New System.Drawing.Point(64, 327)
        Me.lblIntentosFallidos.Name = "lblIntentosFallidos"
        Me.lblIntentosFallidos.Size = New System.Drawing.Size(96, 15)
        Me.lblIntentosFallidos.TabIndex = 75
        Me.lblIntentosFallidos.Text = "Intentos Fallidos:"
        Me.lblIntentosFallidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIntentosFallidos.Visible = False
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'PanelIzquierdo
        '
        Me.PanelIzquierdo.BackColor = System.Drawing.SystemColors.Highlight
        Me.PanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelIzquierdo.Location = New System.Drawing.Point(0, 0)
        Me.PanelIzquierdo.Name = "PanelIzquierdo"
        Me.PanelIzquierdo.Size = New System.Drawing.Size(10, 655)
        Me.PanelIzquierdo.TabIndex = 84
        '
        'lblIcoConnection
        '
        Me.lblIcoConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIcoConnection.BackColor = System.Drawing.Color.Transparent
        Me.lblIcoConnection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblIcoConnection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIcoConnection.Image = Global.Libregco.My.Resources.Resources.Beep_Signal_24
        Me.lblIcoConnection.Location = New System.Drawing.Point(6, 628)
        Me.lblIcoConnection.Name = "lblIcoConnection"
        Me.lblIcoConnection.Size = New System.Drawing.Size(24, 24)
        Me.lblIcoConnection.TabIndex = 92
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(841, 630)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 2)
        Me.Label4.TabIndex = 81
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Visible = False
        '
        'lblConnection
        '
        Me.lblConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConnection.AutoSize = True
        Me.lblConnection.BackColor = System.Drawing.Color.Transparent
        Me.lblConnection.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblConnection.ForeColor = System.Drawing.Color.Black
        Me.lblConnection.Location = New System.Drawing.Point(33, 633)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(0, 13)
        Me.lblConnection.TabIndex = 80
        Me.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(841, 655)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 2)
        Me.Label2.TabIndex = 80
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Visible = False
        '
        'lblDesktopAccess
        '
        Me.lblDesktopAccess.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDesktopAccess.BackColor = System.Drawing.Color.Transparent
        Me.lblDesktopAccess.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDesktopAccess.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDesktopAccess.Image = Global.Libregco.My.Resources.Resources.Computer_Desktop_24
        Me.lblDesktopAccess.Location = New System.Drawing.Point(6, 573)
        Me.lblDesktopAccess.Name = "lblDesktopAccess"
        Me.lblDesktopAccess.Size = New System.Drawing.Size(24, 24)
        Me.lblDesktopAccess.TabIndex = 91
        Me.lblDesktopAccess.Visible = False
        '
        'lblEquipo
        '
        Me.lblEquipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEquipo.AutoSize = True
        Me.lblEquipo.BackColor = System.Drawing.Color.Transparent
        Me.lblEquipo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEquipo.ForeColor = System.Drawing.Color.Black
        Me.lblEquipo.Location = New System.Drawing.Point(33, 579)
        Me.lblEquipo.Name = "lblEquipo"
        Me.lblEquipo.Size = New System.Drawing.Size(0, 13)
        Me.lblEquipo.TabIndex = 90
        Me.lblEquipo.Visible = False
        '
        'lblNetworkIco
        '
        Me.lblNetworkIco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNetworkIco.BackColor = System.Drawing.Color.Transparent
        Me.lblNetworkIco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNetworkIco.Image = Global.Libregco.My.Resources.Resources.Network_Home_24
        Me.lblNetworkIco.Location = New System.Drawing.Point(6, 591)
        Me.lblNetworkIco.Name = "lblNetworkIco"
        Me.lblNetworkIco.Size = New System.Drawing.Size(24, 24)
        Me.lblNetworkIco.TabIndex = 89
        '
        'lblAccesoInternet
        '
        Me.lblAccesoInternet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAccesoInternet.AutoSize = True
        Me.lblAccesoInternet.BackColor = System.Drawing.Color.Transparent
        Me.lblAccesoInternet.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblAccesoInternet.ForeColor = System.Drawing.Color.Black
        Me.lblAccesoInternet.Location = New System.Drawing.Point(33, 615)
        Me.lblAccesoInternet.Name = "lblAccesoInternet"
        Me.lblAccesoInternet.Size = New System.Drawing.Size(0, 13)
        Me.lblAccesoInternet.TabIndex = 86
        '
        'lblInternetIco
        '
        Me.lblInternetIco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInternetIco.BackColor = System.Drawing.Color.Transparent
        Me.lblInternetIco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblInternetIco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblInternetIco.Image = Global.Libregco.My.Resources.Resources.Network_Earth_24
        Me.lblInternetIco.Location = New System.Drawing.Point(6, 609)
        Me.lblInternetIco.Name = "lblInternetIco"
        Me.lblInternetIco.Size = New System.Drawing.Size(24, 24)
        Me.lblInternetIco.TabIndex = 88
        Me.lblInternetIco.Visible = False
        '
        'lblIP
        '
        Me.lblIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIP.AutoSize = True
        Me.lblIP.BackColor = System.Drawing.Color.Transparent
        Me.lblIP.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIP.ForeColor = System.Drawing.Color.Black
        Me.lblIP.Location = New System.Drawing.Point(33, 597)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(0, 13)
        Me.lblIP.TabIndex = 87
        '
        'PanelInferior
        '
        Me.PanelInferior.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInferior.BackColor = System.Drawing.Color.Gray
        Me.PanelInferior.Location = New System.Drawing.Point(394, 645)
        Me.PanelInferior.Name = "PanelInferior"
        Me.PanelInferior.Size = New System.Drawing.Size(700, 10)
        Me.PanelInferior.TabIndex = 85
        '
        'LogoLibregco
        '
        Me.LogoLibregco.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LogoLibregco.BackColor = System.Drawing.Color.Transparent
        Me.LogoLibregco.Location = New System.Drawing.Point(72, 35)
        Me.LogoLibregco.Name = "LogoLibregco"
        Me.LogoLibregco.Size = New System.Drawing.Size(88, 76)
        Me.LogoLibregco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoLibregco.TabIndex = 70
        Me.LogoLibregco.TabStop = False
        Me.LogoLibregco.Tag = "1"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Segoe UI", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblEmpresa.Location = New System.Drawing.Point(12, 20)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(0, 32)
        Me.lblEmpresa.TabIndex = 87
        Me.lblEmpresa.Visible = False
        '
        'lblUnderBare
        '
        Me.lblUnderBare.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnderBare.AutoSize = True
        Me.lblUnderBare.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnderBare.Location = New System.Drawing.Point(2, 0)
        Me.lblUnderBare.Name = "lblUnderBare"
        Me.lblUnderBare.Size = New System.Drawing.Size(0, 15)
        Me.lblUnderBare.TabIndex = 88
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblUnderBare)
        Me.Panel1.Location = New System.Drawing.Point(2, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 17)
        Me.Panel1.TabIndex = 89
        '
        'TimeAnimationMoney
        '
        Me.TimeAnimationMoney.Interval = 75
        '
        'HelperTT
        '
        Me.HelperTT.IsBalloon = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 6)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(187, 76)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 69
        Me.PicBoxLogo.TabStop = False
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.LibregcoCirclex48, "Acceso de administrador", "Tiene acceso temporal a todos los formularios y reportes del sistema.", "Todos los permisos están garantizados.", DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.IM, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.[Default], DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("6486fbff-4e28-41ec-a823-0f8c7734a0da", Global.Libregco.My.Resources.Resources.Bugx48, "Notificación de error al administrador", "Estamos reportando un error al administrador.", "Por favor espere a que se mande la notificación.", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Panel3.Controls.Add(Me.PicBoxLogo)
        Me.Panel3.Controls.Add(Me.PanelLogin)
        Me.Panel3.Controls.Add(Me.ProgressPanel1)
        Me.Panel3.Controls.Add(Me.lblIcoConnection)
        Me.Panel3.Controls.Add(Me.lblNetworkIco)
        Me.Panel3.Controls.Add(Me.lblInternetIco)
        Me.Panel3.Controls.Add(Me.lblConnection)
        Me.Panel3.Controls.Add(Me.lblIP)
        Me.Panel3.Controls.Add(Me.lblDesktopAccess)
        Me.Panel3.Controls.Add(Me.lblAccesoInternet)
        Me.Panel3.Controls.Add(Me.lblEquipo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(10, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 655)
        Me.Panel3.TabIndex = 0
        '
        'PanelLogin
        '
        Me.PanelLogin.Controls.Add(Me.BarradeProgreso)
        Me.PanelLogin.Controls.Add(Me.SeparatorControl1)
        Me.PanelLogin.Controls.Add(Me.txtPassword)
        Me.PanelLogin.Controls.Add(Me.LogoLibregco)
        Me.PanelLogin.Controls.Add(Me.Panel1)
        Me.PanelLogin.Controls.Add(Me.btn_Iniciar)
        Me.PanelLogin.Controls.Add(Me.IrAyuda)
        Me.PanelLogin.Controls.Add(Me.txtUser)
        Me.PanelLogin.Controls.Add(Me.lblIntentosFallidos)
        Me.PanelLogin.Controls.Add(Me.Label3)
        Me.PanelLogin.Controls.Add(Me.lblInformacion)
        Me.PanelLogin.Controls.Add(Me.lblVersionTop)
        Me.PanelLogin.Controls.Add(Me.lblIntentos)
        Me.PanelLogin.Controls.Add(Me.Label1)
        Me.PanelLogin.Controls.Add(Me.SeparatorControl2)
        Me.PanelLogin.Location = New System.Drawing.Point(0, 90)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(395, 462)
        Me.PanelLogin.TabIndex = 0
        Me.PanelLogin.TabStop = True
        '
        'BarradeProgreso
        '
        Me.BarradeProgreso.Location = New System.Drawing.Point(0, 418)
        Me.BarradeProgreso.Name = "BarradeProgreso"
        Me.BarradeProgreso.Size = New System.Drawing.Size(395, 16)
        Me.BarradeProgreso.TabIndex = 97
        Me.BarradeProgreso.Visible = False
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.SeparatorControl1.Location = New System.Drawing.Point(2, 4)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(391, 23)
        Me.SeparatorControl1.TabIndex = 93
        Me.SeparatorControl1.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtPassword.ChangeColorOnMouseEnter = True
        Me.txtPassword.IsPassword = True
        Me.txtPassword.Location = New System.Drawing.Point(67, 177)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.SetBackColorOnFocus = System.Drawing.SystemColors.Highlight
        Me.txtPassword.SetBackColorOnMouseEnter = System.Drawing.Color.LightGray
        Me.txtPassword.SetDefaultBackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPassword.SetDefaultImage = Global.Libregco.My.Resources.Resources.Lock_Black
        Me.txtPassword.SetForeColorText = System.Drawing.Color.Black
        Me.txtPassword.SetImageOnFocus = Global.Libregco.My.Resources.Resources.Lock_White
        Me.txtPassword.SetWaterMarkColor = System.Drawing.Color.Gray
        Me.txtPassword.SetWaterMarkText = "Contraseña"
        Me.txtPassword.Size = New System.Drawing.Size(261, 51)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.Text = Nothing
        Me.txtPassword.TextMessage = ""
        Me.txtPassword.TextMessageColor = System.Drawing.Color.Red
        '
        'txtUser
        '
        Me.txtUser.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUser.BackColor = System.Drawing.Color.Transparent
        Me.txtUser.ChangeColorOnMouseEnter = True
        Me.txtUser.IsPassword = False
        Me.txtUser.Location = New System.Drawing.Point(67, 126)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.SetBackColorOnFocus = System.Drawing.SystemColors.Highlight
        Me.txtUser.SetBackColorOnMouseEnter = System.Drawing.Color.LightGray
        Me.txtUser.SetDefaultBackColor = System.Drawing.Color.WhiteSmoke
        Me.txtUser.SetDefaultImage = Global.Libregco.My.Resources.Resources.Account_Black
        Me.txtUser.SetForeColorText = System.Drawing.Color.Black
        Me.txtUser.SetImageOnFocus = Global.Libregco.My.Resources.Resources.Account_White
        Me.txtUser.SetWaterMarkColor = System.Drawing.Color.Gray
        Me.txtUser.SetWaterMarkText = "Usuario"
        Me.txtUser.Size = New System.Drawing.Size(261, 51)
        Me.txtUser.TabIndex = 0
        Me.txtUser.Text = Nothing
        Me.txtUser.TextMessage = ""
        Me.txtUser.TextMessageColor = System.Drawing.Color.Red
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.SeparatorControl2.Location = New System.Drawing.Point(2, 389)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(391, 23)
        Me.SeparatorControl2.TabIndex = 94
        Me.SeparatorControl2.TabStop = False
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.BarAnimationElementThickness = 2
        Me.ProgressPanel1.Description = ""
        Me.ProgressPanel1.Location = New System.Drawing.Point(135, 197)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.RingAnimationDiameter = 120
        Me.ProgressPanel1.ShowCaption = False
        Me.ProgressPanel1.ShowDescription = False
        Me.ProgressPanel1.Size = New System.Drawing.Size(120, 120)
        Me.ProgressPanel1.TabIndex = 96
        Me.ProgressPanel1.Text = "ProgressPanel1"
        Me.ProgressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Ring
        '
        'PanelAviso
        '
        Me.PanelAviso.BackColor = System.Drawing.Color.White
        Me.PanelAviso.Controls.Add(Me.Label6)
        Me.PanelAviso.Controls.Add(Me.PictureBox2)
        Me.PanelAviso.Controls.Add(Me.Label5)
        Me.PanelAviso.Location = New System.Drawing.Point(413, 7)
        Me.PanelAviso.Name = "PanelAviso"
        Me.PanelAviso.Size = New System.Drawing.Size(227, 65)
        Me.PanelAviso.TabIndex = 93
        Me.PanelAviso.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(74, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 42)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "En este momento se están realizado operaciones de mantenimiento."
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.Libregco.My.Resources.Resources.ExclamationGif
        Me.PictureBox2.InitialImage = CType(resources.GetObject("PictureBox2.InitialImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(65, 65)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 95
        Me.PictureBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Aviso importante"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(867, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(223, 43)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Por favor no eliminar el icono de acceso directo del escritorio o modificar la ub" &
    "icación o el nombre del mismo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Libregco_v
        Me.PictureBox1.Location = New System.Drawing.Point(830, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 33)
        Me.PictureBox1.TabIndex = 95
        Me.PictureBox1.TabStop = False
        '
        'frm_LoginSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1094, 655)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PanelAviso)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.PanelInferior)
        Me.Controls.Add(Me.PanelIzquierdo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 555)
        Me.Name = "frm_LoginSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de sesión"
        CType(Me.LogoLibregco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PanelLogin.ResumeLayout(False)
        Me.PanelLogin.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAviso.ResumeLayout(False)
        Me.PanelAviso.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVersionTop As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Iniciar As System.Windows.Forms.Button
    Friend WithEvents IrAyuda As System.Windows.Forms.LinkLabel
    Friend WithEvents LogoLibregco As System.Windows.Forms.PictureBox
    Private WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents lblInformacion As System.Windows.Forms.Label
    Friend WithEvents lblIntentos As System.Windows.Forms.Label
    Friend WithEvents lblIntentosFallidos As System.Windows.Forms.Label
    Friend WithEvents PanelIzquierdo As System.Windows.Forms.Panel
    Friend WithEvents PanelInferior As System.Windows.Forms.Panel
    Friend WithEvents lblAccesoInternet As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblUnderBare As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents lblInternetIco As System.Windows.Forms.Label
    Friend WithEvents lblNetworkIco As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TimeAnimationMoney As System.Windows.Forms.Timer
    Friend WithEvents HelperTT As System.Windows.Forms.ToolTip
    Friend WithEvents lblDesktopAccess As System.Windows.Forms.Label
    Friend WithEvents lblEquipo As System.Windows.Forms.Label
    Friend WithEvents lblConnection As System.Windows.Forms.Label
    Friend WithEvents lblIcoConnection As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As NewTextbox
    Friend WithEvents txtUser As NewTextbox
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents Panel3 As Panel
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents PanelAviso As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents BarradeProgreso As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
