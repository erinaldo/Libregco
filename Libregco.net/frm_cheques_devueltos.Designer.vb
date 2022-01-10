<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cheques_devueltos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cheques_devueltos))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarCuentaBancariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarBancoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbCliente = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBancoCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GbDetalle = New System.Windows.Forms.GroupBox()
        Me.txtBancoDevuelve = New System.Windows.Forms.TextBox()
        Me.btnBuscarBanco = New System.Windows.Forms.Button()
        Me.txtIDBancoDevuelve = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDCheque = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.txtIDCuenta = New System.Windows.Forms.TextBox()
        Me.btnBuscarCuenta = New System.Windows.Forms.Button()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.MenuBar.SuspendLayout()
        Me.GbCliente.SuspendLayout()
        Me.GbDetalle.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(953, 24)
        Me.MenuBar.TabIndex = 179
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarCuentaBancariaToolStripMenuItem, Me.BuscarBancoToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Cliente"
        '
        'BuscarCuentaBancariaToolStripMenuItem
        '
        Me.BuscarCuentaBancariaToolStripMenuItem.Image = CType(resources.GetObject("BuscarCuentaBancariaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BuscarCuentaBancariaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarCuentaBancariaToolStripMenuItem.Name = "BuscarCuentaBancariaToolStripMenuItem"
        Me.BuscarCuentaBancariaToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.BuscarCuentaBancariaToolStripMenuItem.Text = "Buscar Cuenta Bancaria"
        '
        'BuscarBancoToolStripMenuItem
        '
        Me.BuscarBancoToolStripMenuItem.Image = CType(resources.GetObject("BuscarBancoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BuscarBancoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarBancoToolStripMenuItem.Name = "BuscarBancoToolStripMenuItem"
        Me.BuscarBancoToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.BuscarBancoToolStripMenuItem.Text = "Buscar Banco"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(214, 38)
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
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(192, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'GbCliente
        '
        Me.GbCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCliente.Controls.Add(Me.btnBuscarCliente)
        Me.GbCliente.Controls.Add(Me.txtCalificacion)
        Me.GbCliente.Controls.Add(Me.Label10)
        Me.GbCliente.Controls.Add(Me.txtUltimoPago)
        Me.GbCliente.Controls.Add(Me.Label11)
        Me.GbCliente.Controls.Add(Me.txtBalanceGral)
        Me.GbCliente.Controls.Add(Me.Label12)
        Me.GbCliente.Controls.Add(Me.Label13)
        Me.GbCliente.Controls.Add(Me.Label14)
        Me.GbCliente.Controls.Add(Me.txtIDCliente)
        Me.GbCliente.Controls.Add(Me.txtNombre)
        Me.GbCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GbCliente.Location = New System.Drawing.Point(5, 130)
        Me.GbCliente.Name = "GbCliente"
        Me.GbCliente.Size = New System.Drawing.Size(599, 76)
        Me.GbCliente.TabIndex = 0
        Me.GbCliente.TabStop = False
        Me.GbCliente.Text = "Datos Cliente"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(152, 18)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(491, 46)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(102, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label10.Location = New System.Drawing.Point(416, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 15)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Calificación"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(296, 47)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(114, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.Location = New System.Drawing.Point(217, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Último Pago"
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.Enabled = False
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGral.Location = New System.Drawing.Point(88, 47)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(122, 23)
        Me.txtBalanceGral.TabIndex = 124
        Me.txtBalanceGral.TabStop = False
        Me.txtBalanceGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.Location = New System.Drawing.Point(10, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "Balance Gral"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.Location = New System.Drawing.Point(10, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 15)
        Me.Label13.TabIndex = 100
        Me.Label13.Text = "Código"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label14.Location = New System.Drawing.Point(180, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(62, 18)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(92, 23)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(237, 18)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(356, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Cuenta Bancaria"
        '
        'txtBancoCuenta
        '
        Me.txtBancoCuenta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBancoCuenta.Enabled = False
        Me.txtBancoCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBancoCuenta.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBancoCuenta.Location = New System.Drawing.Point(106, 244)
        Me.txtBancoCuenta.Name = "txtBancoCuenta"
        Me.txtBancoCuenta.ReadOnly = True
        Me.txtBancoCuenta.Size = New System.Drawing.Size(641, 23)
        Me.txtBancoCuenta.TabIndex = 131
        Me.txtBancoCuenta.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(9, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "Banco Emisor"
        '
        'GbDetalle
        '
        Me.GbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbDetalle.Controls.Add(Me.txtBancoDevuelve)
        Me.GbDetalle.Controls.Add(Me.btnBuscarBanco)
        Me.GbDetalle.Controls.Add(Me.txtIDBancoDevuelve)
        Me.GbDetalle.Controls.Add(Me.Label8)
        Me.GbDetalle.Controls.Add(Me.Label7)
        Me.GbDetalle.Controls.Add(Me.Label6)
        Me.GbDetalle.Controls.Add(Me.Label5)
        Me.GbDetalle.Controls.Add(Me.Label4)
        Me.GbDetalle.Controls.Add(Me.Label3)
        Me.GbDetalle.Controls.Add(Me.txtConcepto)
        Me.GbDetalle.Controls.Add(Me.txtTotal)
        Me.GbDetalle.Controls.Add(Me.txtCargo)
        Me.GbDetalle.Controls.Add(Me.txtMonto)
        Me.GbDetalle.Controls.Add(Me.txtNoCheque)
        Me.GbDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GbDetalle.Location = New System.Drawing.Point(5, 270)
        Me.GbDetalle.Name = "GbDetalle"
        Me.GbDetalle.Size = New System.Drawing.Size(936, 281)
        Me.GbDetalle.TabIndex = 2
        Me.GbDetalle.TabStop = False
        Me.GbDetalle.Text = "Cheque devuelto"
        '
        'txtBancoDevuelve
        '
        Me.txtBancoDevuelve.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBancoDevuelve.Enabled = False
        Me.txtBancoDevuelve.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBancoDevuelve.Location = New System.Drawing.Point(238, 45)
        Me.txtBancoDevuelve.Name = "txtBancoDevuelve"
        Me.txtBancoDevuelve.ReadOnly = True
        Me.txtBancoDevuelve.Size = New System.Drawing.Size(498, 23)
        Me.txtBancoDevuelve.TabIndex = 313
        '
        'btnBuscarBanco
        '
        Me.btnBuscarBanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarBanco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarBanco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarBanco.Image = CType(resources.GetObject("btnBuscarBanco.Image"), System.Drawing.Image)
        Me.btnBuscarBanco.Location = New System.Drawing.Point(216, 45)
        Me.btnBuscarBanco.Name = "btnBuscarBanco"
        Me.btnBuscarBanco.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarBanco.TabIndex = 312
        Me.btnBuscarBanco.UseVisualStyleBackColor = True
        '
        'txtIDBancoDevuelve
        '
        Me.txtIDBancoDevuelve.Enabled = False
        Me.txtIDBancoDevuelve.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDBancoDevuelve.Location = New System.Drawing.Point(81, 45)
        Me.txtIDBancoDevuelve.Name = "txtIDBancoDevuelve"
        Me.txtIDBancoDevuelve.ReadOnly = True
        Me.txtIDBancoDevuelve.Size = New System.Drawing.Size(136, 23)
        Me.txtIDBancoDevuelve.TabIndex = 237
        Me.txtIDBancoDevuelve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(5, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 15)
        Me.Label8.TabIndex = 236
        Me.Label8.Text = "Concepto"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(5, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 235
        Me.Label7.Text = "Monto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(5, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 234
        Me.Label6.Text = "Cargo "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 254)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 21)
        Me.Label5.TabIndex = 233
        Me.Label5.Text = "Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(5, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 232
        Me.Label4.Text = "Banco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(5, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 231
        Me.Label3.Text = "Cheque No."
        '
        'txtConcepto
        '
        Me.txtConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConcepto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConcepto.Location = New System.Drawing.Point(81, 74)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConcepto.Size = New System.Drawing.Size(655, 108)
        Me.txtConcepto.TabIndex = 7
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.Location = New System.Drawing.Point(81, 246)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(254, 29)
        Me.txtTotal.TabIndex = 229
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCargo
        '
        Me.txtCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCargo.Location = New System.Drawing.Point(81, 217)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(255, 23)
        Me.txtCargo.TabIndex = 6
        Me.txtCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMonto.Location = New System.Drawing.Point(81, 188)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(254, 23)
        Me.txtMonto.TabIndex = 5
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNoCheque.Location = New System.Drawing.Point(81, 16)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(254, 23)
        Me.txtNoCheque.TabIndex = 3
        Me.txtNoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCheque)
        Me.GbxUserInfo.Controls.Add(Me.Label9)
        Me.GbxUserInfo.Controls.Add(Me.Label15)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label16)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(610, 130)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 220
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(174, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(157, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDCheque
        '
        Me.txtIDCheque.Enabled = False
        Me.txtIDCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCheque.Location = New System.Drawing.Point(59, 17)
        Me.txtIDCheque.Name = "txtIDCheque"
        Me.txtIDCheque.ReadOnly = True
        Me.txtIDCheque.Size = New System.Drawing.Size(109, 23)
        Me.txtIDCheque.TabIndex = 139
        Me.txtIDCheque.TabStop = False
        Me.txtIDCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = "Código"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(6, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 15)
        Me.Label15.TabIndex = 142
        Me.Label15.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(174, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 15)
        Me.Label16.TabIndex = 164
        Me.Label16.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(59, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(900, 212)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 223
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(519, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 328
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
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
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 95)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 329
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 580)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(953, 25)
        Me.BarraEstado.TabIndex = 348
        Me.BarraEstado.Text = "ToolStrip1"
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
        'txtIDCuenta
        '
        Me.txtIDCuenta.Enabled = False
        Me.txtIDCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCuenta.Location = New System.Drawing.Point(106, 215)
        Me.txtIDCuenta.Name = "txtIDCuenta"
        Me.txtIDCuenta.ReadOnly = True
        Me.txtIDCuenta.Size = New System.Drawing.Size(122, 23)
        Me.txtIDCuenta.TabIndex = 314
        Me.txtIDCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCuenta.Image = CType(resources.GetObject("btnBuscarCuenta.Image"), System.Drawing.Image)
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(227, 215)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCuenta.TabIndex = 314
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCuentaBancaria.Enabled = False
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(249, 215)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.ReadOnly = True
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(498, 23)
        Me.txtCuentaBancaria.TabIndex = 314
        '
        'frm_cheques_devueltos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 605)
        Me.Controls.Add(Me.txtCuentaBancaria)
        Me.Controls.Add(Me.btnBuscarCuenta)
        Me.Controls.Add(Me.txtIDCuenta)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.GbDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBancoCuenta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GbCliente)
        Me.Controls.Add(Me.MenuBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_cheques_devueltos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "99"
        Me.Text = "Cheques Devueltos"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.GbCliente.ResumeLayout(False)
        Me.GbCliente.PerformLayout()
        Me.GbDetalle.ResumeLayout(False)
        Me.GbDetalle.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents GbCliente As System.Windows.Forms.GroupBox
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGral As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBancoCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GbDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDCheque As System.Windows.Forms.TextBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtIDBancoDevuelve As System.Windows.Forms.TextBox
    Friend WithEvents txtBancoDevuelve As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarBanco As System.Windows.Forms.Button
    Friend WithEvents txtIDCuenta As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents BuscarCuentaBancariaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarBancoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
