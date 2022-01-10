<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devolucion_compras
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devolucion_compras))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDevoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.GbMotivos = New System.Windows.Forms.GroupBox()
        Me.CbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNCFDev = New System.Windows.Forms.MaskedTextBox()
        Me.btnBuscarMotivo = New System.Windows.Forms.Button()
        Me.ChkDevolverItbis = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIDMotivoDevolucion = New System.Windows.Forms.TextBox()
        Me.txtMotivoDevolucion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMontoDevolver = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarFactura = New System.Windows.Forms.Button()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtIDDevolucion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.cod_cliente_label = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStatusCompra = New System.Windows.Forms.Label()
        Me.txtBalanceFactura = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.GbMotivos.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1020, 24)
        Me.MenuStrip1.TabIndex = 303
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Compra"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(209, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarDevoluciónToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarDevoluciónToolStripMenuItem
        '
        Me.BuscarDevoluciónToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarDevoluciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarDevoluciónToolStripMenuItem.Name = "BuscarDevoluciónToolStripMenuItem"
        Me.BuscarDevoluciónToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.BuscarDevoluciónToolStripMenuItem.Size = New System.Drawing.Size(231, 38)
        Me.BuscarDevoluciónToolStripMenuItem.Text = "Buscar Devolución"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(231, 38)
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
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'GbMotivos
        '
        Me.GbMotivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbMotivos.Controls.Add(Me.CbxAlmacen)
        Me.GbMotivos.Controls.Add(Me.Label16)
        Me.GbMotivos.Controls.Add(Me.txtNCFDev)
        Me.GbMotivos.Controls.Add(Me.btnBuscarMotivo)
        Me.GbMotivos.Controls.Add(Me.ChkDevolverItbis)
        Me.GbMotivos.Controls.Add(Me.Label8)
        Me.GbMotivos.Controls.Add(Me.txtIDMotivoDevolucion)
        Me.GbMotivos.Controls.Add(Me.txtMotivoDevolucion)
        Me.GbMotivos.Controls.Add(Me.Label1)
        Me.GbMotivos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbMotivos.Location = New System.Drawing.Point(6, 551)
        Me.GbMotivos.Name = "GbMotivos"
        Me.GbMotivos.Size = New System.Drawing.Size(632, 85)
        Me.GbMotivos.TabIndex = 351
        Me.GbMotivos.TabStop = False
        Me.GbMotivos.Text = "Información de la Devolución"
        '
        'CbxAlmacen
        '
        Me.CbxAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxAlmacen.FormattingEnabled = True
        Me.CbxAlmacen.Location = New System.Drawing.Point(63, 48)
        Me.CbxAlmacen.Name = "CbxAlmacen"
        Me.CbxAlmacen.Size = New System.Drawing.Size(190, 23)
        Me.CbxAlmacen.TabIndex = 314
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(3, 49)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 315
        Me.Label16.Text = "Almacén"
        '
        'txtNCFDev
        '
        Me.txtNCFDev.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.txtNCFDev.Location = New System.Drawing.Point(313, 48)
        Me.txtNCFDev.Name = "txtNCFDev"
        Me.txtNCFDev.Size = New System.Drawing.Size(206, 24)
        Me.txtNCFDev.TabIndex = 313
        Me.txtNCFDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarMotivo
        '
        Me.btnBuscarMotivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarMotivo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarMotivo.Location = New System.Drawing.Point(161, 19)
        Me.btnBuscarMotivo.Name = "btnBuscarMotivo"
        Me.btnBuscarMotivo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarMotivo.TabIndex = 2
        Me.btnBuscarMotivo.UseVisualStyleBackColor = True
        '
        'ChkDevolverItbis
        '
        Me.ChkDevolverItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkDevolverItbis.AutoSize = True
        Me.ChkDevolverItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkDevolverItbis.Location = New System.Drawing.Point(526, 22)
        Me.ChkDevolverItbis.Name = "ChkDevolverItbis"
        Me.ChkDevolverItbis.Size = New System.Drawing.Size(100, 19)
        Me.ChkDevolverItbis.TabIndex = 5
        Me.ChkDevolverItbis.Text = "Devolver ITBIS"
        Me.ChkDevolverItbis.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(259, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 15)
        Me.Label8.TabIndex = 312
        Me.Label8.Text = "NCF:"
        '
        'txtIDMotivoDevolucion
        '
        Me.txtIDMotivoDevolucion.Enabled = False
        Me.txtIDMotivoDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMotivoDevolucion.Location = New System.Drawing.Point(63, 19)
        Me.txtIDMotivoDevolucion.Name = "txtIDMotivoDevolucion"
        Me.txtIDMotivoDevolucion.ReadOnly = True
        Me.txtIDMotivoDevolucion.Size = New System.Drawing.Size(100, 23)
        Me.txtIDMotivoDevolucion.TabIndex = 310
        Me.txtIDMotivoDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMotivoDevolucion
        '
        Me.txtMotivoDevolucion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotivoDevolucion.Enabled = False
        Me.txtMotivoDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMotivoDevolucion.Location = New System.Drawing.Point(183, 19)
        Me.txtMotivoDevolucion.Name = "txtMotivoDevolucion"
        Me.txtMotivoDevolucion.ReadOnly = True
        Me.txtMotivoDevolucion.Size = New System.Drawing.Size(336, 23)
        Me.txtMotivoDevolucion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Motivo:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(771, 612)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 349
        Me.Label12.Text = "A Devolver:"
        '
        'txtMontoDevolver
        '
        Me.txtMontoDevolver.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoDevolver.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtMontoDevolver.Enabled = False
        Me.txtMontoDevolver.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoDevolver.Location = New System.Drawing.Point(844, 609)
        Me.txtMontoDevolver.Name = "txtMontoDevolver"
        Me.txtMontoDevolver.Size = New System.Drawing.Size(171, 23)
        Me.txtMontoDevolver.TabIndex = 348
        Me.txtMontoDevolver.TabStop = False
        Me.txtMontoDevolver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(197, 202)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 15)
        Me.Label14.TabIndex = 345
        Me.Label14.Text = "Fecha Factura"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFactura.Location = New System.Drawing.Point(198, 220)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(104, 23)
        Me.txtFechaFactura.TabIndex = 344
        Me.txtFechaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(384, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 343
        Me.Label13.Text = "Condición"
        '
        'txtCondicion
        '
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(387, 220)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(104, 23)
        Me.txtCondicion.TabIndex = 342
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(494, 202)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 15)
        Me.Label11.TabIndex = 340
        Me.Label11.Text = "Comprobante Fiscal"
        '
        'txtComprobante
        '
        Me.txtComprobante.Enabled = False
        Me.txtComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtComprobante.Location = New System.Drawing.Point(497, 220)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(174, 23)
        Me.txtComprobante.TabIndex = 339
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnBuscarFactura)
        Me.GroupBox4.Controls.Add(Me.txtFactura)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 198)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 49)
        Me.GroupBox4.TabIndex = 316
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Código de compra"
        '
        'btnBuscarFactura
        '
        Me.btnBuscarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarFactura.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarFactura.Location = New System.Drawing.Point(157, 18)
        Me.btnBuscarFactura.Name = "btnBuscarFactura"
        Me.btnBuscarFactura.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarFactura.TabIndex = 1
        Me.btnBuscarFactura.UseVisualStyleBackColor = True
        '
        'txtFactura
        '
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFactura.Location = New System.Drawing.Point(6, 18)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(152, 23)
        Me.txtFactura.TabIndex = 0
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(430, 36)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 337
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(92, 100)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 336
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.txtIDDevolucion)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label2)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(692, 124)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(324, 74)
        Me.GbxUserInfo.TabIndex = 329
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(171, 16)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(145, 23)
        Me.txtSecondID.TabIndex = 254
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(56, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 253
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDDevolucion
        '
        Me.txtIDDevolucion.Enabled = False
        Me.txtIDDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDevolucion.Location = New System.Drawing.Point(56, 17)
        Me.txtIDDevolucion.Name = "txtIDDevolucion"
        Me.txtIDDevolucion.ReadOnly = True
        Me.txtIDDevolucion.Size = New System.Drawing.Size(109, 23)
        Me.txtIDDevolucion.TabIndex = 248
        Me.txtIDDevolucion.TabStop = False
        Me.txtIDDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Código"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(210, 44)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(106, 23)
        Me.txtHora.TabIndex = 251
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(171, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Hora"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(781, 559)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 328
        Me.Label5.Text = "SubTotal"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotal.Location = New System.Drawing.Point(844, 551)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(171, 23)
        Me.txtTotal.TabIndex = 327
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(809, 584)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 15)
        Me.Label4.TabIndex = 326
        Me.Label4.Text = "Itbis"
        '
        'txtItbis
        '
        Me.txtItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItbis.Enabled = False
        Me.txtItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtItbis.Location = New System.Drawing.Point(844, 580)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.ReadOnly = True
        Me.txtItbis.Size = New System.Drawing.Size(171, 23)
        Me.txtItbis.TabIndex = 325
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.AllowUserToResizeColumns = False
        Me.DgvArticulos.AllowUserToResizeRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvArticulos.Location = New System.Drawing.Point(6, 250)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArticulos.RowTemplate.Height = 34
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(1009, 295)
        Me.DgvArticulos.TabIndex = 317
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(305, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 324
        Me.Label3.Text = "Días "
        '
        'txtDias
        '
        Me.txtDias.Enabled = False
        Me.txtDias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDias.Location = New System.Drawing.Point(308, 220)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ReadOnly = True
        Me.txtDias.Size = New System.Drawing.Size(73, 23)
        Me.txtDias.TabIndex = 323
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(804, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 15)
        Me.Label10.TabIndex = 353
        Me.Label10.Text = "NCF"
        '
        'txtNCF
        '
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.ForeColor = System.Drawing.Color.Black
        Me.txtNCF.Location = New System.Drawing.Point(807, 220)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(136, 23)
        Me.txtNCF.TabIndex = 352
        Me.txtNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(586, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 354
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
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
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
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
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(214, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
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
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 95)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(222, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(451, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.BackColor = System.Drawing.Color.LightGray
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDSuplidor.Location = New System.Drawing.Point(62, 15)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.ReadOnly = True
        Me.txtIDSuplidor.Size = New System.Drawing.Size(97, 23)
        Me.txtIDSuplidor.TabIndex = 93
        Me.txtIDSuplidor.TabStop = False
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(165, 18)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'cod_cliente_label
        '
        Me.cod_cliente_label.AutoSize = True
        Me.cod_cliente_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cod_cliente_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.cod_cliente_label.Location = New System.Drawing.Point(10, 19)
        Me.cod_cliente_label.Name = "cod_cliente_label"
        Me.cod_cliente_label.Size = New System.Drawing.Size(46, 15)
        Me.cod_cliente_label.TabIndex = 100
        Me.cod_cliente_label.Text = "Código"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(199, 47)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(72, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Balance Gral"
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.Enabled = False
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGral.Location = New System.Drawing.Point(277, 44)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(137, 23)
        Me.txtBalanceGral.TabIndex = 124
        Me.txtBalanceGral.TabStop = False
        Me.txtBalanceGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(420, 48)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(73, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Último Pago"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(499, 45)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(103, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(10, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "RNC"
        '
        'txtRNC
        '
        Me.txtRNC.Enabled = False
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(62, 44)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.ReadOnly = True
        Me.txtRNC.Size = New System.Drawing.Size(131, 23)
        Me.txtRNC.TabIndex = 132
        Me.txtRNC.TabStop = False
        Me.txtRNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtRNC)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtUltimoPago)
        Me.GroupBox3.Controls.Add(Me.label21)
        Me.GroupBox3.Controls.Add(Me.txtBalanceGral)
        Me.GroupBox3.Controls.Add(Me.label20)
        Me.GroupBox3.Controls.Add(Me.cod_cliente_label)
        Me.GroupBox3.Controls.Add(Me.nombre_label)
        Me.GroupBox3.Controls.Add(Me.txtIDSuplidor)
        Me.GroupBox3.Controls.Add(Me.txtNombre)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Location = New System.Drawing.Point(7, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(679, 74)
        Me.GroupBox3.TabIndex = 315
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos Suplidor"
        '
        'lblStatusCompra
        '
        Me.lblStatusCompra.AutoSize = True
        Me.lblStatusCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatusCompra.Location = New System.Drawing.Point(4, 547)
        Me.lblStatusCompra.Name = "lblStatusCompra"
        Me.lblStatusCompra.Size = New System.Drawing.Size(0, 15)
        Me.lblStatusCompra.TabIndex = 355
        '
        'txtBalanceFactura
        '
        Me.txtBalanceFactura.Enabled = False
        Me.txtBalanceFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceFactura.ForeColor = System.Drawing.Color.Black
        Me.txtBalanceFactura.Location = New System.Drawing.Point(677, 220)
        Me.txtBalanceFactura.Name = "txtBalanceFactura"
        Me.txtBalanceFactura.ReadOnly = True
        Me.txtBalanceFactura.Size = New System.Drawing.Size(126, 23)
        Me.txtBalanceFactura.TabIndex = 356
        Me.txtBalanceFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(674, 202)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 15)
        Me.Label15.TabIndex = 357
        Me.Label15.Text = "Balance"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 358
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 639)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1020, 25)
        Me.BarraEstado.TabIndex = 359
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
        'frm_devolucion_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 664)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtBalanceFactura)
        Me.Controls.Add(Me.lblStatusCompra)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNCF)
        Me.Controls.Add(Me.GbMotivos)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMontoDevolver)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFechaFactura)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtCondicion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtComprobante)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.DgvArticulos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_devolucion_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "22"
        Me.Text = "Devoluciones de compras"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbMotivos.ResumeLayout(False)
        Me.GbMotivos.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
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
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents GbMotivos As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarMotivo As System.Windows.Forms.Button
    Friend WithEvents txtIDMotivoDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivoDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkDevolverItbis As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMontoDevolver As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscarFactura As System.Windows.Forms.Button
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtItbis As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents txtNCF As System.Windows.Forms.TextBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Private WithEvents cod_cliente_label As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGral As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRNC As System.Windows.Forms.TextBox
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatusCompra As System.Windows.Forms.Label
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNCFDev As System.Windows.Forms.MaskedTextBox
    Private WithEvents txtBalanceFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDevoluciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
