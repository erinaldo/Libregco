<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_entrada_asistencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_entrada_asistencia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdbCarnet = New System.Windows.Forms.RadioButton()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.PicImagen = New DevExpress.XtraEditors.PictureEdit()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.rdbDactilar = New System.Windows.Forms.RadioButton()
        Me.rdbPassword = New System.Windows.Forms.RadioButton()
        Me.rdbReconocimiento = New System.Windows.Forms.RadioButton()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl4 = New DevExpress.XtraEditors.SeparatorControl()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CameraControl1 = New DevExpress.XtraEditors.Camera.CameraControl()
        Me.lblIndicador = New System.Windows.Forms.Label()
        Me.SeparatorControl5 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DgvAsistencias = New System.Windows.Forms.DataGridView()
        Me.IDAsistenciaDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DuracionLetras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPassword = New Libregco.Watermark()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCarnet = New Libregco.Watermark()
        Me.SeparatorControl6 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl7 = New DevExpress.XtraEditors.SeparatorControl()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage6 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.DgvAsistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage6.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Carnetx256
        Me.PictureBox1.Location = New System.Drawing.Point(64, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(2, 241)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Use su carnet o código de identificación para dar entrada a la bitácora de asiste" &
    "ncias"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdbCarnet
        '
        Me.rdbCarnet.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbCarnet.Image = CType(resources.GetObject("rdbCarnet.Image"), System.Drawing.Image)
        Me.rdbCarnet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbCarnet.Location = New System.Drawing.Point(203, 30)
        Me.rdbCarnet.Name = "rdbCarnet"
        Me.rdbCarnet.Size = New System.Drawing.Size(108, 55)
        Me.rdbCarnet.TabIndex = 2
        Me.rdbCarnet.Text = "Carnet"
        Me.rdbCarnet.UseVisualStyleBackColor = True
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(503, 12)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(28, 323)
        Me.SeparatorControl1.TabIndex = 3
        '
        'PicImagen
        '
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicImagen.Location = New System.Drawing.Point(225, 3)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PicImagen.Properties.Appearance.Options.UseBackColor = True
        Me.PicImagen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PicImagen.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle
        Me.PicImagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PicImagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PicImagen.Size = New System.Drawing.Size(140, 140)
        Me.PicImagen.TabIndex = 13
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblNombre.Location = New System.Drawing.Point(0, 146)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(627, 22)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdbDactilar
        '
        Me.rdbDactilar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbDactilar.Enabled = False
        Me.rdbDactilar.Image = CType(resources.GetObject("rdbDactilar.Image"), System.Drawing.Image)
        Me.rdbDactilar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbDactilar.Location = New System.Drawing.Point(317, 22)
        Me.rdbDactilar.Name = "rdbDactilar"
        Me.rdbDactilar.Size = New System.Drawing.Size(117, 71)
        Me.rdbDactilar.TabIndex = 3
        Me.rdbDactilar.Text = "Dactilar"
        Me.rdbDactilar.UseVisualStyleBackColor = True
        '
        'rdbPassword
        '
        Me.rdbPassword.Checked = True
        Me.rdbPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbPassword.Image = CType(resources.GetObject("rdbPassword.Image"), System.Drawing.Image)
        Me.rdbPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPassword.Location = New System.Drawing.Point(72, 30)
        Me.rdbPassword.Name = "rdbPassword"
        Me.rdbPassword.Size = New System.Drawing.Size(124, 55)
        Me.rdbPassword.TabIndex = 1
        Me.rdbPassword.TabStop = True
        Me.rdbPassword.Text = "Contraseña"
        Me.rdbPassword.UseVisualStyleBackColor = True
        '
        'rdbReconocimiento
        '
        Me.rdbReconocimiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdbReconocimiento.Image = CType(resources.GetObject("rdbReconocimiento.Image"), System.Drawing.Image)
        Me.rdbReconocimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbReconocimiento.Location = New System.Drawing.Point(440, 22)
        Me.rdbReconocimiento.Name = "rdbReconocimiento"
        Me.rdbReconocimiento.Size = New System.Drawing.Size(152, 71)
        Me.rdbReconocimiento.TabIndex = 4
        Me.rdbReconocimiento.Text = "Reconocimiento"
        Me.rdbReconocimiento.UseVisualStyleBackColor = True
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(3, 8)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(606, 23)
        Me.SeparatorControl2.TabIndex = 19
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Location = New System.Drawing.Point(10, 54)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(606, 23)
        Me.SeparatorControl3.TabIndex = 20
        '
        'SeparatorControl4
        '
        Me.SeparatorControl4.Location = New System.Drawing.Point(10, 115)
        Me.SeparatorControl4.Name = "SeparatorControl4"
        Me.SeparatorControl4.Size = New System.Drawing.Size(606, 23)
        Me.SeparatorControl4.TabIndex = 21
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Location = New System.Drawing.Point(7, 445)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(105, 52)
        Me.btnNuevo.TabIndex = 24
        Me.btnNuevo.Text = "+ Nueva Entrada"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.Appearance.Options.UseFont = True
        Me.ProgressPanel1.BarAnimationElementThickness = 2
        Me.ProgressPanel1.Caption = "Esperando captura de datos"
        Me.ProgressPanel1.Location = New System.Drawing.Point(27, 284)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.ShowDescription = False
        Me.ProgressPanel1.Size = New System.Drawing.Size(222, 42)
        Me.ProgressPanel1.TabIndex = 25
        Me.ProgressPanel1.Text = "00"
        Me.ProgressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.HumanResources_x32, "Registro de asistencia", "Registro de asistencia", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'Timer1
        '
        Me.Timer1.Interval = 4000
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.SeparatorControl2)
        Me.Panel1.Controls.Add(Me.rdbCarnet)
        Me.Panel1.Controls.Add(Me.rdbDactilar)
        Me.Panel1.Controls.Add(Me.rdbPassword)
        Me.Panel1.Controls.Add(Me.rdbReconocimiento)
        Me.Panel1.Location = New System.Drawing.Point(5, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 96)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Método de entrada"
        '
        'CameraControl1
        '
        Me.CameraControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.CameraControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CameraControl1.DeviceNotFoundString = "No se ha encontrado un dispositivo de captura para poder utilizar este método de " &
    "entrada"
        Me.CameraControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CameraControl1.Location = New System.Drawing.Point(0, 0)
        Me.CameraControl1.Name = "CameraControl1"
        Me.CameraControl1.ShowSettingsButton = False
        Me.CameraControl1.Size = New System.Drawing.Size(629, 364)
        Me.CameraControl1.TabIndex = 32
        Me.CameraControl1.Text = "CameraControl1"
        '
        'lblIndicador
        '
        Me.lblIndicador.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblIndicador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndicador.ForeColor = System.Drawing.Color.White
        Me.lblIndicador.Location = New System.Drawing.Point(316, 118)
        Me.lblIndicador.Name = "lblIndicador"
        Me.lblIndicador.Size = New System.Drawing.Size(81, 20)
        Me.lblIndicador.TabIndex = 27
        Me.lblIndicador.Text = "Entrada"
        Me.lblIndicador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SeparatorControl5
        '
        Me.SeparatorControl5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl5.Location = New System.Drawing.Point(0, 161)
        Me.SeparatorControl5.Name = "SeparatorControl5"
        Me.SeparatorControl5.Size = New System.Drawing.Size(651, 23)
        Me.SeparatorControl5.TabIndex = 28
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblNombre)
        Me.Panel2.Controls.Add(Me.DgvAsistencias)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblIndicador)
        Me.Panel2.Controls.Add(Me.PicImagen)
        Me.Panel2.Controls.Add(Me.SeparatorControl5)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(637, 472)
        Me.Panel2.TabIndex = 29
        '
        'DgvAsistencias
        '
        Me.DgvAsistencias.AllowUserToAddRows = False
        Me.DgvAsistencias.AllowUserToDeleteRows = False
        Me.DgvAsistencias.AllowUserToResizeColumns = False
        Me.DgvAsistencias.AllowUserToResizeRows = False
        Me.DgvAsistencias.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvAsistencias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAsistencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvAsistencias.ColumnHeadersHeight = 30
        Me.DgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvAsistencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDAsistenciaDetalle, Me.FechaRegistro, Me.Tipo, Me.Duracion, Me.DuracionLetras})
        Me.DgvAsistencias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvAsistencias.Location = New System.Drawing.Point(0, 213)
        Me.DgvAsistencias.MultiSelect = False
        Me.DgvAsistencias.Name = "DgvAsistencias"
        Me.DgvAsistencias.ReadOnly = True
        Me.DgvAsistencias.RowHeadersVisible = False
        Me.DgvAsistencias.RowTemplate.Height = 28
        Me.DgvAsistencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAsistencias.Size = New System.Drawing.Size(637, 259)
        Me.DgvAsistencias.TabIndex = 31
        '
        'IDAsistenciaDetalle
        '
        Me.IDAsistenciaDetalle.HeaderText = "IDAsistenciaDetalle"
        Me.IDAsistenciaDetalle.Name = "IDAsistenciaDetalle"
        Me.IDAsistenciaDetalle.ReadOnly = True
        Me.IDAsistenciaDetalle.Visible = False
        '
        'FechaRegistro
        '
        Me.FechaRegistro.HeaderText = "Hora"
        Me.FechaRegistro.Name = "FechaRegistro"
        Me.FechaRegistro.ReadOnly = True
        Me.FechaRegistro.Width = 200
        '
        'Tipo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 110
        '
        'Duracion
        '
        Me.Duracion.HeaderText = "Duración"
        Me.Duracion.Name = "Duracion"
        Me.Duracion.ReadOnly = True
        Me.Duracion.Visible = False
        Me.Duracion.Width = 220
        '
        'DuracionLetras
        '
        Me.DuracionLetras.HeaderText = "Duración"
        Me.DuracionLetras.Name = "DuracionLetras"
        Me.DuracionLetras.ReadOnly = True
        Me.DuracionLetras.Width = 320
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(68, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(245, 29)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "TimeSpan"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(1, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 29)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Duración"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDAsistenciaDetalle"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Hora"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Duración"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 220
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Duración"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 220
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtPassword.Location = New System.Drawing.Point(80, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(460, 30)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPassword.WatermarkText = "Escriba su contraseña para realizar el registro..."
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(264, 3)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(651, 506)
        Me.XtraTabControl1.TabIndex = 30
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Panel1)
        Me.XtraTabPage1.Controls.Add(Me.XtraTabControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(645, 478)
        Me.XtraTabPage1.Text = "Métodos"
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XtraTabControl2.Location = New System.Drawing.Point(5, 105)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.XtraTabPage3
        Me.XtraTabControl2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.XtraTabControl2.Size = New System.Drawing.Size(635, 370)
        Me.XtraTabControl2.TabIndex = 1
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage3, Me.XtraTabPage4, Me.XtraTabPage5, Me.XtraTabPage6})
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.Label4)
        Me.XtraTabPage3.Controls.Add(Me.txtPassword)
        Me.XtraTabPage3.Controls.Add(Me.SeparatorControl4)
        Me.XtraTabPage3.Controls.Add(Me.SeparatorControl3)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(629, 364)
        Me.XtraTabPage3.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(-1, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(627, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Puede utilizar su contraseña completa o el factor númerico del sistema"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.Label5)
        Me.XtraTabPage4.Controls.Add(Me.txtCarnet)
        Me.XtraTabPage4.Controls.Add(Me.SeparatorControl6)
        Me.XtraTabPage4.Controls.Add(Me.SeparatorControl7)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(629, 364)
        Me.XtraTabPage4.Text = "Carnet"
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(-1, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(627, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Utilice el dispositivo lector en el código de carnet o identificación"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCarnet
        '
        Me.txtCarnet.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtCarnet.Location = New System.Drawing.Point(80, 80)
        Me.txtCarnet.Name = "txtCarnet"
        Me.txtCarnet.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCarnet.Size = New System.Drawing.Size(460, 30)
        Me.txtCarnet.TabIndex = 23
        Me.txtCarnet.WatermarkColor = System.Drawing.Color.Gray
        Me.txtCarnet.WatermarkText = "Esperando lectura del dispositivo..."
        '
        'SeparatorControl6
        '
        Me.SeparatorControl6.Location = New System.Drawing.Point(0, 115)
        Me.SeparatorControl6.Name = "SeparatorControl6"
        Me.SeparatorControl6.Size = New System.Drawing.Size(629, 23)
        Me.SeparatorControl6.TabIndex = 25
        '
        'SeparatorControl7
        '
        Me.SeparatorControl7.Location = New System.Drawing.Point(0, 54)
        Me.SeparatorControl7.Name = "SeparatorControl7"
        Me.SeparatorControl7.Size = New System.Drawing.Size(629, 23)
        Me.SeparatorControl7.TabIndex = 24
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(629, 364)
        Me.XtraTabPage5.Text = "Dactilar"
        '
        'XtraTabPage6
        '
        Me.XtraTabPage6.Controls.Add(Me.CameraControl1)
        Me.XtraTabPage6.Name = "XtraTabPage6"
        Me.XtraTabPage6.Size = New System.Drawing.Size(629, 364)
        Me.XtraTabPage6.Text = "Facial"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.Panel2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.PageVisible = False
        Me.XtraTabPage2.Size = New System.Drawing.Size(645, 478)
        Me.XtraTabPage2.Text = "Bitácora"
        '
        'frm_entrada_asistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 513)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.ProgressPanel1)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_entrada_asistencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de entrada y salida empleados"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DgvAsistencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        Me.XtraTabPage3.PerformLayout()
        Me.XtraTabPage4.ResumeLayout(False)
        Me.XtraTabPage4.PerformLayout()
        CType(Me.SeparatorControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage6.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rdbCarnet As RadioButton
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents PicImagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblNombre As Label
    Friend WithEvents rdbDactilar As RadioButton
    Friend WithEvents rdbPassword As RadioButton
    Friend WithEvents rdbReconocimiento As RadioButton
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl4 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtPassword As Watermark
    Friend WithEvents btnNuevo As Button
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lblIndicador As Label
    Friend WithEvents SeparatorControl5 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DgvAsistencias As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents IDAsistenciaDetalle As DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistro As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents Duracion As DataGridViewTextBoxColumn
    Friend WithEvents DuracionLetras As DataGridViewTextBoxColumn
    Friend WithEvents CameraControl1 As DevExpress.XtraEditors.Camera.CameraControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCarnet As Watermark
    Friend WithEvents SeparatorControl6 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl7 As DevExpress.XtraEditors.SeparatorControl
End Class
