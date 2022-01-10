<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_verificacion_correo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_verificacion_correo))
        Me.PicEmpleado = New System.Windows.Forms.PictureBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.btnModificarCorreo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEnviarCodigo = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnComprobar = New System.Windows.Forms.Button()
        Me.btnVolverAEnviar = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRevisar = New System.Windows.Forms.Button()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.txtCodigo = New Libregco.Watermark()
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicEmpleado
        '
        Me.PicEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.PicEmpleado.Location = New System.Drawing.Point(214, 26)
        Me.PicEmpleado.Name = "PicEmpleado"
        Me.PicEmpleado.Size = New System.Drawing.Size(130, 130)
        Me.PicEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEmpleado.TabIndex = 417
        Me.PicEmpleado.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI Light", 14.0!)
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(13, 165)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(536, 32)
        Me.lblNombre.TabIndex = 418
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 613)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(560, 25)
        Me.BarraEstado.TabIndex = 421
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'lblDate
        '
        Me.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 22)
        Me.lblDate.Text = "Date"
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(14, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(308, 21)
        Me.Label2.TabIndex = 423
        Me.Label2.Text = "Aún te faltan algunos pasos por completar!"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(15, 245)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 23)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "Hemos verificado que aún no has verificado la cuenta de correo de tu cuenta"
        '
        'txtCorreo
        '
        Me.txtCorreo.Enabled = False
        Me.txtCorreo.Location = New System.Drawing.Point(18, 271)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.ReadOnly = True
        Me.txtCorreo.Size = New System.Drawing.Size(233, 23)
        Me.txtCorreo.TabIndex = 0
        '
        'btnModificarCorreo
        '
        Me.btnModificarCorreo.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnModificarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnModificarCorreo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarCorreo.ForeColor = System.Drawing.Color.White
        Me.btnModificarCorreo.Location = New System.Drawing.Point(247, 271)
        Me.btnModificarCorreo.Name = "btnModificarCorreo"
        Me.btnModificarCorreo.Size = New System.Drawing.Size(75, 23)
        Me.btnModificarCorreo.TabIndex = 1
        Me.btnModificarCorreo.Text = "Modificar"
        Me.btnModificarCorreo.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(15, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(511, 43)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Una vez revisado tu correo, haz click en envíar código de verificación para inici" &
    "ar el proceso de validación de tu cuenta"
        '
        'btnEnviarCodigo
        '
        Me.btnEnviarCodigo.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEnviarCodigo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarCodigo.ForeColor = System.Drawing.Color.White
        Me.btnEnviarCodigo.Location = New System.Drawing.Point(96, 3)
        Me.btnEnviarCodigo.Name = "btnEnviarCodigo"
        Me.btnEnviarCodigo.Size = New System.Drawing.Size(368, 68)
        Me.btnEnviarCodigo.TabIndex = 2
        Me.btnEnviarCodigo.Text = "Envíar código de verificación"
        Me.btnEnviarCodigo.UseVisualStyleBackColor = False
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblMensaje.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblMensaje.Location = New System.Drawing.Point(0, 51)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(560, 18)
        Me.lblMensaje.TabIndex = 430
        Me.lblMensaje.Text = "Escriba la secuencia de 4 dígitos recibió en su correo electrónico. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(560, 48)
        Me.Label6.TabIndex = 431
        Me.Label6.Text = "En caso de que no reciba una notificación por favor revise la carpeta de correos " &
    "no deseados o spam o vuelve a envíar el código de verificación."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnComprobar)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblMensaje)
        Me.Panel1.Location = New System.Drawing.Point(0, 460)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 152)
        Me.Panel1.TabIndex = 4
        Me.Panel1.Visible = False
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(0, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(560, 18)
        Me.Label7.TabIndex = 433
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnComprobar
        '
        Me.btnComprobar.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnComprobar.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComprobar.ForeColor = System.Drawing.Color.White
        Me.btnComprobar.Location = New System.Drawing.Point(280, 7)
        Me.btnComprobar.Name = "btnComprobar"
        Me.btnComprobar.Size = New System.Drawing.Size(102, 39)
        Me.btnComprobar.TabIndex = 6
        Me.btnComprobar.Text = "Comprobar"
        Me.btnComprobar.UseVisualStyleBackColor = False
        '
        'btnVolverAEnviar
        '
        Me.btnVolverAEnviar.AutoSize = True
        Me.btnVolverAEnviar.LinkColor = System.Drawing.Color.DodgerBlue
        Me.btnVolverAEnviar.Location = New System.Drawing.Point(345, 74)
        Me.btnVolverAEnviar.Name = "btnVolverAEnviar"
        Me.btnVolverAEnviar.Size = New System.Drawing.Size(123, 15)
        Me.btnVolverAEnviar.TabIndex = 3
        Me.btnVolverAEnviar.TabStop = True
        Me.btnVolverAEnviar.Text = "Volver a envíar código"
        Me.btnVolverAEnviar.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnEnviarCodigo)
        Me.Panel2.Controls.Add(Me.btnVolverAEnviar)
        Me.Panel2.Location = New System.Drawing.Point(0, 419)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(560, 92)
        Me.Panel2.TabIndex = 427
        '
        'btnRevisar
        '
        Me.btnRevisar.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRevisar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevisar.ForeColor = System.Drawing.Color.White
        Me.btnRevisar.Location = New System.Drawing.Point(247, 271)
        Me.btnRevisar.Name = "btnRevisar"
        Me.btnRevisar.Size = New System.Drawing.Size(75, 23)
        Me.btnRevisar.TabIndex = 428
        Me.btnRevisar.Text = "Revisar"
        Me.btnRevisar.UseVisualStyleBackColor = False
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Mailx48, "Correo envíado", "Se ha envíado un correo electrónico con el código de confirmación.", "Verífique el código para confirmar", DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.IM, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.[Default], DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("6486fbff-4e28-41ec-a823-0f8c7734a0da", Global.Libregco.My.Resources.Resources.Checkedx32, "Verificación completada", "El correo electrónico ha sido verificado satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.txtCodigo.Location = New System.Drawing.Point(192, 7)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(91, 39)
        Me.txtCodigo.TabIndex = 5
        Me.txtCodigo.WatermarkColor = System.Drawing.Color.Gray
        Me.txtCodigo.WatermarkText = ""
        '
        'frm_verificacion_correo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 638)
        Me.Controls.Add(Me.btnRevisar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnModificarCorreo)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicEmpleado)
        Me.Controls.Add(Me.lblNombre)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_verificacion_correo"
        Me.Text = "Verificación de correo electrónico"
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicEmpleado As PictureBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents Fecha As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents btnModificarCorreo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEnviarCodigo As Button
    Friend WithEvents txtCodigo As Watermark
    Friend WithEvents lblMensaje As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents btnComprobar As Button
    Friend WithEvents btnVolverAEnviar As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnRevisar As Button
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
End Class
