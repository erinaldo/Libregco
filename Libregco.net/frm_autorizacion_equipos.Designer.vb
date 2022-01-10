<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_autorizacion_equipos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_autorizacion_equipos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreEquipo = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIDPublicoString = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPasswordWindows = New System.Windows.Forms.TextBox()
        Me.txtUserWindows = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNoEmision = New System.Windows.Forms.MaskedTextBox()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.lblSistemaOperativo = New System.Windows.Forms.Label()
        Me.lblPlataforma = New System.Windows.Forms.Label()
        Me.lblIPPrivado = New System.Windows.Forms.Label()
        Me.lblIPPublico = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblFechaRegistro = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtSuperClave = New Libregco.Watermark()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(511, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre del Equipo:"
        '
        'lblNombreEquipo
        '
        Me.lblNombreEquipo.AutoSize = True
        Me.lblNombreEquipo.Location = New System.Drawing.Point(623, 201)
        Me.lblNombreEquipo.Name = "lblNombreEquipo"
        Me.lblNombreEquipo.Size = New System.Drawing.Size(91, 15)
        Me.lblNombreEquipo.TabIndex = 2
        Me.lblNombreEquipo.Text = "Nombre Equipo"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(511, 220)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(274, 50)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Este equipo no está autorizado para el acceso al sistema."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(511, 310)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "IP Privado:"
        '
        'lblIDPublicoString
        '
        Me.lblIDPublicoString.AutoSize = True
        Me.lblIDPublicoString.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIDPublicoString.Location = New System.Drawing.Point(511, 330)
        Me.lblIDPublicoString.Name = "lblIDPublicoString"
        Me.lblIDPublicoString.Size = New System.Drawing.Size(63, 15)
        Me.lblIDPublicoString.TabIndex = 5
        Me.lblIDPublicoString.Text = "IP Público:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(14, 471)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(383, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Escriba la superclave para autorizar el acceso de este terminal al sistema"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(511, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Plataforma:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.IMG_0327
        Me.PictureBox1.Location = New System.Drawing.Point(-2, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(800, 191)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label7.Location = New System.Drawing.Point(511, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "S.O:"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 529)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(797, 25)
        Me.BarraEstado.TabIndex = 258
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
        'btnAutorizar
        '
        Me.btnAutorizar.Location = New System.Drawing.Point(314, 489)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(196, 35)
        Me.btnAutorizar.TabIndex = 5
        Me.btnAutorizar.Text = "Autorizar terminal"
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblSucursal)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAlmacen)
        Me.GroupBox1.Controls.Add(Me.txtIDAlmacen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 273)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicación del Punto de Emisión"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtPasswordWindows)
        Me.GroupBox3.Controls.Add(Me.txtUserWindows)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 85)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(471, 85)
        Me.GroupBox3.TabIndex = 431
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Crendenciales de windows"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label15.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label15.Location = New System.Drawing.Point(209, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(263, 13)
        Me.Label15.TabIndex = 431
        Me.Label15.Text = "Recomendamos llenar los credenciales del equipo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 428
        Me.Label4.Text = "Usuario"
        '
        'txtPasswordWindows
        '
        Me.txtPasswordWindows.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPasswordWindows.Location = New System.Drawing.Point(79, 49)
        Me.txtPasswordWindows.Name = "txtPasswordWindows"
        Me.txtPasswordWindows.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordWindows.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPasswordWindows.Size = New System.Drawing.Size(386, 23)
        Me.txtPasswordWindows.TabIndex = 429
        Me.txtPasswordWindows.UseSystemPasswordChar = True
        '
        'txtUserWindows
        '
        Me.txtUserWindows.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUserWindows.Location = New System.Drawing.Point(79, 20)
        Me.txtUserWindows.Name = "txtUserWindows"
        Me.txtUserWindows.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUserWindows.Size = New System.Drawing.Size(386, 23)
        Me.txtUserWindows.TabIndex = 427
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(6, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 15)
        Me.Label10.TabIndex = 430
        Me.Label10.Text = "Contraseña"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtNoEmision)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(473, 89)
        Me.GroupBox2.TabIndex = 426
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estructura de los números de comprobantes fiscales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 31)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "021"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(163, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 30)
        Me.Label11.TabIndex = 418
        Me.Label11.Text = "0100000005"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 30)
        Me.Label12.TabIndex = 419
        Me.Label12.Text = "A02001"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 15)
        Me.Label13.TabIndex = 420
        Me.Label13.Text = "Area de Impresión"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label14.Location = New System.Drawing.Point(184, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(259, 15)
        Me.Label14.TabIndex = 261
        Me.Label14.Text = "3 dígitos de identificación del área de impresión"
        '
        'txtNoEmision
        '
        Me.txtNoEmision.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoEmision.Location = New System.Drawing.Point(114, 52)
        Me.txtNoEmision.Mask = "000"
        Me.txtNoEmision.Name = "txtNoEmision"
        Me.txtNoEmision.Size = New System.Drawing.Size(64, 26)
        Me.txtNoEmision.TabIndex = 3
        Me.txtNoEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSucursal.Location = New System.Drawing.Point(242, 11)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(0, 15)
        Me.lblSucursal.TabIndex = 424
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(88, 58)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(394, 23)
        Me.txtObservacion.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(15, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 422
        Me.Label16.Text = "Observac:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(188, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 261
        Me.Label9.Text = "Sucursal: "
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(169, 29)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 1
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(15, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 415
        Me.Label8.Text = "Almacén"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(191, 29)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(291, 23)
        Me.txtAlmacen.TabIndex = 416
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(88, 29)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(82, 23)
        Me.txtIDAlmacen.TabIndex = 0
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSistemaOperativo
        '
        Me.lblSistemaOperativo.AutoSize = True
        Me.lblSistemaOperativo.Location = New System.Drawing.Point(580, 270)
        Me.lblSistemaOperativo.Name = "lblSistemaOperativo"
        Me.lblSistemaOperativo.Size = New System.Drawing.Size(103, 15)
        Me.lblSistemaOperativo.TabIndex = 261
        Me.lblSistemaOperativo.Text = "Sistema Operativo"
        '
        'lblPlataforma
        '
        Me.lblPlataforma.AutoSize = True
        Me.lblPlataforma.Location = New System.Drawing.Point(580, 290)
        Me.lblPlataforma.Name = "lblPlataforma"
        Me.lblPlataforma.Size = New System.Drawing.Size(128, 15)
        Me.lblPlataforma.TabIndex = 263
        Me.lblPlataforma.Text = "Nombre de Plataforma"
        '
        'lblIPPrivado
        '
        Me.lblIPPrivado.AutoSize = True
        Me.lblIPPrivado.Location = New System.Drawing.Point(580, 311)
        Me.lblIPPrivado.Name = "lblIPPrivado"
        Me.lblIPPrivado.Size = New System.Drawing.Size(60, 15)
        Me.lblIPPrivado.TabIndex = 264
        Me.lblIPPrivado.Text = "IP Privado"
        '
        'lblIPPublico
        '
        Me.lblIPPublico.AutoSize = True
        Me.lblIPPublico.Location = New System.Drawing.Point(580, 330)
        Me.lblIPPublico.Name = "lblIPPublico"
        Me.lblIPPublico.Size = New System.Drawing.Size(60, 15)
        Me.lblIPPublico.TabIndex = 265
        Me.lblIPPublico.Text = "IP Público"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label22.Location = New System.Drawing.Point(511, 374)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(199, 15)
        Me.Label22.TabIndex = 266
        Me.Label22.Text = "Fecha de Registro de Punto de Venta"
        '
        'lblFechaRegistro
        '
        Me.lblFechaRegistro.AutoSize = True
        Me.lblFechaRegistro.Location = New System.Drawing.Point(511, 392)
        Me.lblFechaRegistro.Name = "lblFechaRegistro"
        Me.lblFechaRegistro.Size = New System.Drawing.Size(137, 15)
        Me.lblFechaRegistro.TabIndex = 267
        Me.lblFechaRegistro.Text = "Fecha de Punto de Venta"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DodgerBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(16, 499)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(177, 15)
        Me.LinkLabel1.TabIndex = 425
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Eliminar autorización del equipo"
        Me.LinkLabel1.Visible = False
        '
        'txtSuperClave
        '
        Me.txtSuperClave.Location = New System.Drawing.Point(17, 496)
        Me.txtSuperClave.Name = "txtSuperClave"
        Me.txtSuperClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSuperClave.Size = New System.Drawing.Size(291, 23)
        Me.txtSuperClave.TabIndex = 4
        Me.txtSuperClave.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSuperClave.WatermarkText = "Superclave de Registro"
        '
        'frm_autorizacion_equipos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 554)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.lblFechaRegistro)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.lblIPPublico)
        Me.Controls.Add(Me.lblIPPrivado)
        Me.Controls.Add(Me.lblPlataforma)
        Me.Controls.Add(Me.lblSistemaOperativo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSuperClave)
        Me.Controls.Add(Me.lblIDPublicoString)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblNombreEquipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_autorizacion_equipos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Autorización de Equipos"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNombreEquipo As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIDPublicoString As System.Windows.Forms.Label
    Friend WithEvents txtSuperClave As Watermark
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNoEmision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents lblSistemaOperativo As System.Windows.Forms.Label
    Friend WithEvents lblPlataforma As System.Windows.Forms.Label
    Friend WithEvents lblIPPrivado As System.Windows.Forms.Label
    Friend WithEvents lblIPPublico As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPasswordWindows As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUserWindows As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
