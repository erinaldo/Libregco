<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_prestamos_emp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_prestamos_emp))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarPréstamoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.txtTipoPrestamo = New System.Windows.Forms.TextBox()
        Me.txtIDTipoPrestamo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCuota = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.btnBuscarTipoPrestamo = New System.Windows.Forms.Button()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicMinLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDPrestamo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(863, 24)
        Me.MenuStrip1.TabIndex = 257
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarPréstamoToolStripMenuItem, Me.ToolStripMenuItem1, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.NuevoRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarPréstamoToolStripMenuItem
        '
        Me.BuscarPréstamoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarPréstamoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarPréstamoToolStripMenuItem.Name = "BuscarPréstamoToolStripMenuItem"
        Me.BuscarPréstamoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarPréstamoToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.BuscarPréstamoToolStripMenuItem.Text = "Buscar préstamo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(219, 38)
        Me.ToolStripMenuItem1.Text = "Buscar tipo préstamo"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar empleado"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(219, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaLibregcoToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AyudaLibregcoToolStripMenuItem
        '
        Me.AyudaLibregcoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(85, 96)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 259
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.txtCedula)
        Me.groupBox1.Controls.Add(Me.btnBuscarEmpleado)
        Me.groupBox1.Controls.Add(Me.txtEmpleado)
        Me.groupBox1.Controls.Add(Me.txtBalance)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.txtIDEmpleado)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(7, 133)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(504, 75)
        Me.groupBox1.TabIndex = 278
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = " Empleado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(3, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Cédula"
        '
        'txtCedula
        '
        Me.txtCedula.Enabled = False
        Me.txtCedula.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCedula.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCedula.Location = New System.Drawing.Point(53, 44)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.ReadOnly = True
        Me.txtCedula.Size = New System.Drawing.Size(173, 23)
        Me.txtCedula.TabIndex = 279
        Me.txtCedula.TabStop = False
        Me.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarEmpleado.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarEmpleado.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(110, 15)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarEmpleado.TabIndex = 0
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = True
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Enabled = False
        Me.txtEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmpleado.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtEmpleado.Location = New System.Drawing.Point(132, 15)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(366, 23)
        Me.txtEmpleado.TabIndex = 183
        Me.txtEmpleado.TabStop = False
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalance.Location = New System.Drawing.Point(285, 43)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(213, 23)
        Me.txtBalance.TabIndex = 227
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label5.Location = New System.Drawing.Point(232, 47)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 15)
        Me.label5.TabIndex = 228
        Me.label5.Text = "Balance"
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Enabled = False
        Me.txtIDEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEmpleado.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDEmpleado.Location = New System.Drawing.Point(6, 15)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(105, 23)
        Me.txtIDEmpleado.TabIndex = 130
        Me.txtIDEmpleado.TabStop = False
        Me.txtIDEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipoPrestamo
        '
        Me.txtTipoPrestamo.Enabled = False
        Me.txtTipoPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoPrestamo.Location = New System.Drawing.Point(124, 241)
        Me.txtTipoPrestamo.Name = "txtTipoPrestamo"
        Me.txtTipoPrestamo.ReadOnly = True
        Me.txtTipoPrestamo.Size = New System.Drawing.Size(350, 23)
        Me.txtTipoPrestamo.TabIndex = 282
        '
        'txtIDTipoPrestamo
        '
        Me.txtIDTipoPrestamo.Enabled = False
        Me.txtIDTipoPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoPrestamo.Location = New System.Drawing.Point(7, 241)
        Me.txtIDTipoPrestamo.Name = "txtIDTipoPrestamo"
        Me.txtIDTipoPrestamo.ReadOnly = True
        Me.txtIDTipoPrestamo.Size = New System.Drawing.Size(96, 23)
        Me.txtIDTipoPrestamo.TabIndex = 281
        Me.txtIDTipoPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(4, 222)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 15)
        Me.Label20.TabIndex = 280
        Me.Label20.Text = "Tipo de Préstamo"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMonto.ForeColor = System.Drawing.Color.Black
        Me.txtMonto.Location = New System.Drawing.Point(480, 242)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(162, 23)
        Me.txtMonto.TabIndex = 284
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(477, 222)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 15)
        Me.Label17.TabIndex = 285
        Me.Label17.Text = "Monto"
        '
        'txtCuota
        '
        Me.txtCuota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuota.ForeColor = System.Drawing.Color.Black
        Me.txtCuota.Location = New System.Drawing.Point(648, 242)
        Me.txtCuota.Name = "txtCuota"
        Me.txtCuota.Size = New System.Drawing.Size(156, 23)
        Me.txtCuota.TabIndex = 286
        Me.txtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(645, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 15)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Monto de las cuota(s)"
        '
        'txtConcepto
        '
        Me.txtConcepto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConcepto.ForeColor = System.Drawing.Color.Black
        Me.txtConcepto.Location = New System.Drawing.Point(7, 289)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(848, 148)
        Me.txtConcepto.TabIndex = 288
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(4, 271)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 289
        Me.Label9.Text = "Concepto:"
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(292, 110)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 290
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'btnBuscarTipoPrestamo
        '
        Me.btnBuscarTipoPrestamo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoPrestamo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarTipoPrestamo.Location = New System.Drawing.Point(102, 241)
        Me.btnBuscarTipoPrestamo.Name = "btnBuscarTipoPrestamo"
        Me.btnBuscarTipoPrestamo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoPrestamo.TabIndex = 279
        Me.btnBuscarTipoPrestamo.UseVisualStyleBackColor = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 294
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicMinLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 457)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(863, 25)
        Me.BarraEstado.TabIndex = 330
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicMinLogo
        '
        Me.PicMinLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicMinLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicMinLogo.Name = "PicMinLogo"
        Me.PicMinLogo.Size = New System.Drawing.Size(23, 22)
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
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(429, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 331
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnDesactivar, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnGuardaryLimpiar
        '
        Me.btnGuardaryLimpiar.Image = CType(resources.GetObject("btnGuardaryLimpiar.Image"), System.Drawing.Image)
        Me.btnGuardaryLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardaryLimpiar.Name = "btnGuardaryLimpiar"
        Me.btnGuardaryLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnGuardaryLimpiar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardaryLimpiar.Text = "Guardar y Limpiar"
        Me.btnGuardaryLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDesactivar
        '
        Me.btnDesactivar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnDesactivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(84, 95)
        Me.btnDesactivar.Text = "Anular"
        Me.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDPrestamo)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Controls.Add(Me.Label4)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(517, 132)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 193
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(173, 16)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(159, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDPrestamo
        '
        Me.txtIDPrestamo.Enabled = False
        Me.txtIDPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDPrestamo.Location = New System.Drawing.Point(58, 16)
        Me.txtIDPrestamo.Name = "txtIDPrestamo"
        Me.txtIDPrestamo.ReadOnly = True
        Me.txtIDPrestamo.Size = New System.Drawing.Size(108, 23)
        Me.txtIDPrestamo.TabIndex = 139
        Me.txtIDPrestamo.TabStop = False
        Me.txtIDPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 45)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(119, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(174, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 15)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(58, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_mant_prestamos_emp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 482)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCuota)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnBuscarTipoPrestamo)
        Me.Controls.Add(Me.txtTipoPrestamo)
        Me.Controls.Add(Me.txtIDTipoPrestamo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_prestamos_emp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "157"
        Me.Text = "Préstamos a Empleados"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarEmpleado As System.Windows.Forms.Button
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents txtIDEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarTipoPrestamo As System.Windows.Forms.Button
    Friend WithEvents txtTipoPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicMinLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesactivar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents txtIDPrestamo As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarPréstamoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
