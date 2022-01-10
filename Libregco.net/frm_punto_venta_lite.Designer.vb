<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_punto_venta_lite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_punto_venta_lite))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IrAOtrasInformacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IrAOpcionesDeCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IrADatosDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IrADatosDeLaFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.CambiarCondiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarNCFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificarPreciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReducirCantidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnfocarBuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblIDFactura = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.lblSecondID = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.lblIDTransaccion = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.lblFecha = New System.Windows.Forms.ToolStripLabel()
        Me.lblHora = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblFechaLarga = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.lblVisualNCF = New System.Windows.Forms.ToolStripLabel()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalFactura = New System.Windows.Forms.Label()
        Me.lblPrecioArticulo = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTotalNeto2 = New System.Windows.Forms.Label()
        Me.lblTotalNeto = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFlete = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblItbis = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnInsertarArticulo = New System.Windows.Forms.Button()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.cbxMedida = New System.Windows.Forms.ComboBox()
        Me.TabInfoFactura = New System.Windows.Forms.TabControl()
        Me.TpDatosFact = New System.Windows.Forms.TabPage()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblTipoItbis = New System.Windows.Forms.Label()
        Me.lblSubCategoria = New System.Windows.Forms.Label()
        Me.lblTipoProducto = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.btnModificarPrecio = New System.Windows.Forms.Button()
        Me.btnQuitarArticulo = New System.Windows.Forms.Button()
        Me.btnBuscarArticulo = New System.Windows.Forms.Button()
        Me.btnReducirCantidad = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PicImage = New System.Windows.Forms.PictureBox()
        Me.TpDatosCliente = New System.Windows.Forms.TabPage()
        Me.txtNivelPrecio = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.chkEntregarporConduce = New System.Windows.Forms.CheckBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.btnCambiarNCF = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCambiarCondicion = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCreditoDisponible = New System.Windows.Forms.TextBox()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnModificarCliente = New System.Windows.Forms.Button()
        Me.btnConsultaRNC = New System.Windows.Forms.Button()
        Me.btnCrearCliente = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.TpDatosCredito = New System.Windows.Forms.TabPage()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        Me.chkFichaDatos = New System.Windows.Forms.CheckBox()
        Me.txtCondicionContado = New System.Windows.Forms.TextBox()
        Me.chkHabilitarNota = New System.Windows.Forms.CheckBox()
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFechaAdicional = New System.Windows.Forms.MaskedTextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtAdicional = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMontoPagos = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCantidadPagos = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDiasCondicion = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.TpOtrasInform = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxVehiculo = New System.Windows.Forms.ComboBox()
        Me.CbxChofer = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.chkDesactivar = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbxPrecio = New System.Windows.Forms.ComboBox()
        Me.txtIDArticulo = New Libregco.Watermark()
        Me.lblRazon = New System.Windows.Forms.Label()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblRNC = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.MenuBarra.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabInfoFactura.SuspendLayout()
        Me.TpDatosFact.SuspendLayout()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpDatosCliente.SuspendLayout()
        Me.TpDatosCredito.SuspendLayout()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpOtrasInform.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(1406, 24)
        Me.MenuBarra.TabIndex = 328
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator3, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Cliente"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(203, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IrAOtrasInformacionesToolStripMenuItem, Me.IrAOpcionesDeCréditoToolStripMenuItem, Me.IrADatosDelClienteToolStripMenuItem, Me.IrADatosDeLaFacturaToolStripMenuItem, Me.ToolStripSeparator8, Me.BuscarArtículosToolStripMenuItem, Me.ToolStripSeparator9, Me.CambiarCondiciónToolStripMenuItem, Me.CambiarNCFToolStripMenuItem, Me.ToolStripSeparator10, Me.ModificarPreciosToolStripMenuItem, Me.ReducirCantidadToolStripMenuItem, Me.QuitarProductoToolStripMenuItem, Me.EnfocarBuscarArtículosToolStripMenuItem, Me.ToolStripSeparator11, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'IrAOtrasInformacionesToolStripMenuItem
        '
        Me.IrAOtrasInformacionesToolStripMenuItem.Image = CType(resources.GetObject("IrAOtrasInformacionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IrAOtrasInformacionesToolStripMenuItem.Name = "IrAOtrasInformacionesToolStripMenuItem"
        Me.IrAOtrasInformacionesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.IrAOtrasInformacionesToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.IrAOtrasInformacionesToolStripMenuItem.Text = "Ir a Otras informaciones"
        '
        'IrAOpcionesDeCréditoToolStripMenuItem
        '
        Me.IrAOpcionesDeCréditoToolStripMenuItem.Image = CType(resources.GetObject("IrAOpcionesDeCréditoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IrAOpcionesDeCréditoToolStripMenuItem.Name = "IrAOpcionesDeCréditoToolStripMenuItem"
        Me.IrAOpcionesDeCréditoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.IrAOpcionesDeCréditoToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.IrAOpcionesDeCréditoToolStripMenuItem.Text = "Ir a Opciones de Crédito"
        '
        'IrADatosDelClienteToolStripMenuItem
        '
        Me.IrADatosDelClienteToolStripMenuItem.Image = CType(resources.GetObject("IrADatosDelClienteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IrADatosDelClienteToolStripMenuItem.Name = "IrADatosDelClienteToolStripMenuItem"
        Me.IrADatosDelClienteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.IrADatosDelClienteToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.IrADatosDelClienteToolStripMenuItem.Text = "Ir a Datos del Cliente"
        '
        'IrADatosDeLaFacturaToolStripMenuItem
        '
        Me.IrADatosDeLaFacturaToolStripMenuItem.Image = CType(resources.GetObject("IrADatosDeLaFacturaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.IrADatosDeLaFacturaToolStripMenuItem.Name = "IrADatosDeLaFacturaToolStripMenuItem"
        Me.IrADatosDeLaFacturaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.IrADatosDeLaFacturaToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.IrADatosDeLaFacturaToolStripMenuItem.Text = "Ir a Datos de la Factura"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(224, 6)
        '
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar Artículos"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(224, 6)
        '
        'CambiarCondiciónToolStripMenuItem
        '
        Me.CambiarCondiciónToolStripMenuItem.Image = CType(resources.GetObject("CambiarCondiciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CambiarCondiciónToolStripMenuItem.Name = "CambiarCondiciónToolStripMenuItem"
        Me.CambiarCondiciónToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.CambiarCondiciónToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CambiarCondiciónToolStripMenuItem.Text = "Cambiar condición"
        '
        'CambiarNCFToolStripMenuItem
        '
        Me.CambiarNCFToolStripMenuItem.Image = CType(resources.GetObject("CambiarNCFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CambiarNCFToolStripMenuItem.Name = "CambiarNCFToolStripMenuItem"
        Me.CambiarNCFToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.CambiarNCFToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CambiarNCFToolStripMenuItem.Text = "Cambiar NCF"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(224, 6)
        '
        'ModificarPreciosToolStripMenuItem
        '
        Me.ModificarPreciosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.ModificarPreciosToolStripMenuItem.Name = "ModificarPreciosToolStripMenuItem"
        Me.ModificarPreciosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.ModificarPreciosToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ModificarPreciosToolStripMenuItem.Text = "Modificar Precios"
        '
        'ReducirCantidadToolStripMenuItem
        '
        Me.ReducirCantidadToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Down_x32
        Me.ReducirCantidadToolStripMenuItem.Name = "ReducirCantidadToolStripMenuItem"
        Me.ReducirCantidadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.ReducirCantidadToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ReducirCantidadToolStripMenuItem.Text = "Reducir cantidad"
        '
        'QuitarProductoToolStripMenuItem
        '
        Me.QuitarProductoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarProductoToolStripMenuItem.Name = "QuitarProductoToolStripMenuItem"
        Me.QuitarProductoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.QuitarProductoToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.QuitarProductoToolStripMenuItem.Text = "Quitar producto"
        '
        'EnfocarBuscarArtículosToolStripMenuItem
        '
        Me.EnfocarBuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.EnfocarBuscarArtículosToolStripMenuItem.Name = "EnfocarBuscarArtículosToolStripMenuItem"
        Me.EnfocarBuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.EnfocarBuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.EnfocarBuscarArtículosToolStripMenuItem.Text = "Enfocar Buscar Artículos"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(224, 6)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
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
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 751)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1406, 25)
        Me.BarraEstado.TabIndex = 330
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
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.lblUsuario, Me.ToolStripSeparator4, Me.ToolStripLabel1, Me.lblIDFactura, Me.ToolStripSeparator5, Me.ToolStripLabel4, Me.lblSecondID, Me.ToolStripSeparator6, Me.ToolStripLabel3, Me.lblIDTransaccion, Me.ToolStripSeparator1, Me.ToolStripLabel6, Me.lblFecha, Me.lblHora, Me.ToolStripSeparator7, Me.lblFechaLarga, Me.ToolStripSeparator12, Me.ToolStripLabel5, Me.lblVisualNCF})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 726)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1406, 25)
        Me.ToolStrip1.TabIndex = 332
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel2.Text = "Usuario:"
        '
        'lblUsuario
        '
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(91, 22)
        Me.lblUsuario.Text = "NombreUsuario"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripLabel1.Text = "Código:"
        '
        'lblIDFactura
        '
        Me.lblIDFactura.Name = "lblIDFactura"
        Me.lblIDFactura.Size = New System.Drawing.Size(37, 22)
        Me.lblIDFactura.Text = "00000"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(71, 22)
        Me.ToolStripLabel4.Text = "No. Factura:"
        '
        'lblSecondID
        '
        Me.lblSecondID.Name = "lblSecondID"
        Me.lblSecondID.Size = New System.Drawing.Size(37, 22)
        Me.lblSecondID.Text = "00000"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripLabel3.Text = "No. Transacción:"
        '
        'lblIDTransaccion
        '
        Me.lblIDTransaccion.Name = "lblIDTransaccion"
        Me.lblIDTransaccion.Size = New System.Drawing.Size(37, 22)
        Me.lblIDTransaccion.Text = "00000"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(41, 22)
        Me.ToolStripLabel6.Text = "Fecha:"
        '
        'lblFecha
        '
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(38, 22)
        Me.lblFecha.Text = "Fecha"
        '
        'lblHora
        '
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(33, 22)
        Me.lblHora.Text = "Hora"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'lblFechaLarga
        '
        Me.lblFechaLarga.Name = "lblFechaLarga"
        Me.lblFechaLarga.Size = New System.Drawing.Size(67, 22)
        Me.lblFechaLarga.Text = "FechaLarga"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripLabel5.Text = "NCF:"
        '
        'lblVisualNCF
        '
        Me.lblVisualNCF.Name = "lblVisualNCF"
        Me.lblVisualNCF.Size = New System.Drawing.Size(49, 22)
        Me.lblVisualNCF.Text = "No.NCF"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.lblTotalFactura)
        Me.Panel1.Controls.Add(Me.lblPrecioArticulo)
        Me.Panel1.Controls.Add(Me.lblDescripcion)
        Me.Panel1.Location = New System.Drawing.Point(5, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 94)
        Me.Panel1.TabIndex = 333
        '
        'lblTotalFactura
        '
        Me.lblTotalFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalFactura.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalFactura.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalFactura.ForeColor = System.Drawing.Color.White
        Me.lblTotalFactura.Location = New System.Drawing.Point(686, 57)
        Me.lblTotalFactura.Name = "lblTotalFactura"
        Me.lblTotalFactura.Size = New System.Drawing.Size(350, 34)
        Me.lblTotalFactura.TabIndex = 2
        Me.lblTotalFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrecioArticulo
        '
        Me.lblPrecioArticulo.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecioArticulo.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioArticulo.ForeColor = System.Drawing.Color.White
        Me.lblPrecioArticulo.Location = New System.Drawing.Point(3, 57)
        Me.lblPrecioArticulo.Name = "lblPrecioArticulo"
        Me.lblPrecioArticulo.Size = New System.Drawing.Size(286, 34)
        Me.lblPrecioArticulo.TabIndex = 1
        Me.lblPrecioArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescripcion
        '
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Candara", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.White
        Me.lblDescripcion.Location = New System.Drawing.Point(4, 2)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(568, 54)
        Me.lblDescripcion.TabIndex = 0
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.BackgroundColor = System.Drawing.Color.White
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArticulos.GridColor = System.Drawing.Color.White
        Me.DgvArticulos.Location = New System.Drawing.Point(5, 258)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.RowTemplate.Height = 30
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(1040, 393)
        Me.DgvArticulos.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1036, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Escriba el código del producto o código de barras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(720, 698)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 21)
        Me.Label14.TabIndex = 360
        Me.Label14.Text = "TOTAL"
        '
        'lblTotalNeto2
        '
        Me.lblTotalNeto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalNeto2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblTotalNeto2.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalNeto2.ForeColor = System.Drawing.Color.White
        Me.lblTotalNeto2.Location = New System.Drawing.Point(782, 692)
        Me.lblTotalNeto2.Name = "lblTotalNeto2"
        Me.lblTotalNeto2.Size = New System.Drawing.Size(263, 32)
        Me.lblTotalNeto2.TabIndex = 359
        Me.lblTotalNeto2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalNeto.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblTotalNeto.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.Color.White
        Me.lblTotalNeto.Location = New System.Drawing.Point(550, 669)
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.Size = New System.Drawing.Size(158, 20)
        Me.lblTotalNeto.TabIndex = 358
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(550, 654)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 357
        Me.Label12.Text = "TotalNeto"
        '
        'lblFlete
        '
        Me.lblFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFlete.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblFlete.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlete.ForeColor = System.Drawing.Color.White
        Me.lblFlete.Location = New System.Drawing.Point(414, 669)
        Me.lblFlete.Name = "lblFlete"
        Me.lblFlete.Size = New System.Drawing.Size(130, 20)
        Me.lblFlete.TabIndex = 356
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(414, 654)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 15)
        Me.Label10.TabIndex = 355
        Me.Label10.Text = "Flete"
        '
        'lblItbis
        '
        Me.lblItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItbis.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblItbis.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItbis.ForeColor = System.Drawing.Color.White
        Me.lblItbis.Location = New System.Drawing.Point(278, 669)
        Me.lblItbis.Name = "lblItbis"
        Me.lblItbis.Size = New System.Drawing.Size(130, 20)
        Me.lblItbis.TabIndex = 354
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(278, 654)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 353
        Me.Label8.Text = "Itbis"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(142, 654)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 351
        Me.Label6.Text = "Descuento"
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblSubTotal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTotal.ForeColor = System.Drawing.Color.White
        Me.lblSubTotal.Location = New System.Drawing.Point(6, 669)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(130, 20)
        Me.lblSubTotal.TabIndex = 350
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 654)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 349
        Me.Label3.Text = "Subtotal"
        '
        'btnInsertarArticulo
        '
        Me.btnInsertarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarArticulo.Location = New System.Drawing.Point(1015, 5)
        Me.btnInsertarArticulo.Name = "btnInsertarArticulo"
        Me.btnInsertarArticulo.Size = New System.Drawing.Size(21, 23)
        Me.btnInsertarArticulo.TabIndex = 2
        Me.btnInsertarArticulo.UseVisualStyleBackColor = True
        '
        'lblDescuento
        '
        Me.lblDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescuento.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblDescuento.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.ForeColor = System.Drawing.Color.White
        Me.lblDescuento.Location = New System.Drawing.Point(142, 669)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(130, 20)
        Me.lblDescuento.TabIndex = 352
        '
        'cbxMedida
        '
        Me.cbxMedida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMedida.FormattingEnabled = True
        Me.cbxMedida.Location = New System.Drawing.Point(847, 5)
        Me.cbxMedida.Name = "cbxMedida"
        Me.cbxMedida.Size = New System.Drawing.Size(97, 23)
        Me.cbxMedida.TabIndex = 1
        Me.cbxMedida.TabStop = False
        '
        'TabInfoFactura
        '
        Me.TabInfoFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabInfoFactura.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabInfoFactura.Controls.Add(Me.TpDatosFact)
        Me.TabInfoFactura.Controls.Add(Me.TpDatosCliente)
        Me.TabInfoFactura.Controls.Add(Me.TpDatosCredito)
        Me.TabInfoFactura.Controls.Add(Me.TpOtrasInform)
        Me.TabInfoFactura.Location = New System.Drawing.Point(1051, 27)
        Me.TabInfoFactura.Multiline = True
        Me.TabInfoFactura.Name = "TabInfoFactura"
        Me.TabInfoFactura.SelectedIndex = 0
        Me.TabInfoFactura.Size = New System.Drawing.Size(352, 614)
        Me.TabInfoFactura.TabIndex = 366
        '
        'TpDatosFact
        '
        Me.TpDatosFact.BackColor = System.Drawing.Color.White
        Me.TpDatosFact.Controls.Add(Me.Label37)
        Me.TpDatosFact.Controls.Add(Me.Label36)
        Me.TpDatosFact.Controls.Add(Me.lblTipoItbis)
        Me.TpDatosFact.Controls.Add(Me.lblSubCategoria)
        Me.TpDatosFact.Controls.Add(Me.lblTipoProducto)
        Me.TpDatosFact.Controls.Add(Me.lblDepartamento)
        Me.TpDatosFact.Controls.Add(Me.lblCategoria)
        Me.TpDatosFact.Controls.Add(Me.lblMarca)
        Me.TpDatosFact.Controls.Add(Me.btnModificarPrecio)
        Me.TpDatosFact.Controls.Add(Me.btnQuitarArticulo)
        Me.TpDatosFact.Controls.Add(Me.btnBuscarArticulo)
        Me.TpDatosFact.Controls.Add(Me.btnReducirCantidad)
        Me.TpDatosFact.Controls.Add(Me.Button2)
        Me.TpDatosFact.Controls.Add(Me.PicImage)
        Me.TpDatosFact.Location = New System.Drawing.Point(4, 53)
        Me.TpDatosFact.Name = "TpDatosFact"
        Me.TpDatosFact.Padding = New System.Windows.Forms.Padding(3)
        Me.TpDatosFact.Size = New System.Drawing.Size(344, 557)
        Me.TpDatosFact.TabIndex = 0
        Me.TpDatosFact.Text = "[F1] Datos de la Factura"
        '
        'Label37
        '
        Me.Label37.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label37.Location = New System.Drawing.Point(13, 364)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(322, 15)
        Me.Label37.TabIndex = 394
        Me.Label37.Text = "- - - - - - - - - - - - - - - Acciones - - - - - - - - - - - - - - -"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label36.BackColor = System.Drawing.Color.DimGray
        Me.Label36.Location = New System.Drawing.Point(8, 355)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(327, 3)
        Me.Label36.TabIndex = 393
        '
        'lblTipoItbis
        '
        Me.lblTipoItbis.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTipoItbis.AutoSize = True
        Me.lblTipoItbis.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTipoItbis.Location = New System.Drawing.Point(9, 329)
        Me.lblTipoItbis.Name = "lblTipoItbis"
        Me.lblTipoItbis.Size = New System.Drawing.Size(87, 19)
        Me.lblTipoItbis.TabIndex = 392
        Me.lblTipoItbis.Text = "Tipo de Itbis:"
        '
        'lblSubCategoria
        '
        Me.lblSubCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSubCategoria.AutoSize = True
        Me.lblSubCategoria.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubCategoria.Location = New System.Drawing.Point(9, 310)
        Me.lblSubCategoria.Name = "lblSubCategoria"
        Me.lblSubCategoria.Size = New System.Drawing.Size(94, 19)
        Me.lblSubCategoria.TabIndex = 391
        Me.lblSubCategoria.Text = "SubCategoría:"
        '
        'lblTipoProducto
        '
        Me.lblTipoProducto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTipoProducto.AutoSize = True
        Me.lblTipoProducto.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTipoProducto.Location = New System.Drawing.Point(9, 234)
        Me.lblTipoProducto.Name = "lblTipoProducto"
        Me.lblTipoProducto.Size = New System.Drawing.Size(98, 19)
        Me.lblTipoProducto.TabIndex = 390
        Me.lblTipoProducto.Text = "Tipo Producto:"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDepartamento.Location = New System.Drawing.Point(9, 272)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(101, 19)
        Me.lblDepartamento.TabIndex = 389
        Me.lblDepartamento.Text = "Departamento:"
        '
        'lblCategoria
        '
        Me.lblCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCategoria.Location = New System.Drawing.Point(9, 291)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(71, 19)
        Me.lblCategoria.TabIndex = 388
        Me.lblCategoria.Text = "Categoría:"
        '
        'lblMarca
        '
        Me.lblMarca.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblMarca.Location = New System.Drawing.Point(9, 253)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(50, 19)
        Me.lblMarca.TabIndex = 387
        Me.lblMarca.Text = "Marca:"
        '
        'btnModificarPrecio
        '
        Me.btnModificarPrecio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnModificarPrecio.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnModificarPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarPrecio.Location = New System.Drawing.Point(6, 413)
        Me.btnModificarPrecio.Name = "btnModificarPrecio"
        Me.btnModificarPrecio.Size = New System.Drawing.Size(333, 23)
        Me.btnModificarPrecio.TabIndex = 1
        Me.btnModificarPrecio.Text = "[F8] Modificar Precio"
        Me.btnModificarPrecio.UseVisualStyleBackColor = True
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitarArticulo.Location = New System.Drawing.Point(6, 471)
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(333, 23)
        Me.btnQuitarArticulo.TabIndex = 3
        Me.btnQuitarArticulo.Text = "[F10] Quitar artículo "
        Me.btnQuitarArticulo.UseVisualStyleBackColor = True
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(6, 384)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(333, 23)
        Me.btnBuscarArticulo.TabIndex = 0
        Me.btnBuscarArticulo.Text = "[F5] Buscar artículo   "
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'btnReducirCantidad
        '
        Me.btnReducirCantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReducirCantidad.Image = Global.Libregco.My.Resources.Resources.Down_x32
        Me.btnReducirCantidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReducirCantidad.Location = New System.Drawing.Point(6, 442)
        Me.btnReducirCantidad.Name = "btnReducirCantidad"
        Me.btnReducirCantidad.Size = New System.Drawing.Size(333, 23)
        Me.btnReducirCantidad.TabIndex = 2
        Me.btnReducirCantidad.Text = "[F9] Reducir Cantidad"
        Me.btnReducirCantidad.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Image = Global.Libregco.My.Resources.Resources.Save_and_Clean_x32
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(6, 500)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(333, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "[F11] Última Factura "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PicImage
        '
        Me.PicImage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PicImage.Image = CType(resources.GetObject("PicImage.Image"), System.Drawing.Image)
        Me.PicImage.Location = New System.Drawing.Point(0, 0)
        Me.PicImage.Name = "PicImage"
        Me.PicImage.Size = New System.Drawing.Size(344, 227)
        Me.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImage.TabIndex = 376
        Me.PicImage.TabStop = False
        '
        'TpDatosCliente
        '
        Me.TpDatosCliente.Controls.Add(Me.txtNivelPrecio)
        Me.TpDatosCliente.Controls.Add(Me.Label38)
        Me.TpDatosCliente.Controls.Add(Me.txtRNC)
        Me.TpDatosCliente.Controls.Add(Me.chkEntregarporConduce)
        Me.TpDatosCliente.Controls.Add(Me.txtVendedor)
        Me.TpDatosCliente.Controls.Add(Me.txtIDVendedor)
        Me.TpDatosCliente.Controls.Add(Me.Label11)
        Me.TpDatosCliente.Controls.Add(Me.Label35)
        Me.TpDatosCliente.Controls.Add(Me.txtTelefono)
        Me.TpDatosCliente.Controls.Add(Me.Label34)
        Me.TpDatosCliente.Controls.Add(Me.txtDireccion)
        Me.TpDatosCliente.Controls.Add(Me.CbxTipoComprobante)
        Me.TpDatosCliente.Controls.Add(Me.btnCambiarNCF)
        Me.TpDatosCliente.Controls.Add(Me.Label33)
        Me.TpDatosCliente.Controls.Add(Me.Label9)
        Me.TpDatosCliente.Controls.Add(Me.txtCobrador)
        Me.TpDatosCliente.Controls.Add(Me.cbxCondicion)
        Me.TpDatosCliente.Controls.Add(Me.Label4)
        Me.TpDatosCliente.Controls.Add(Me.btnCambiarCondicion)
        Me.TpDatosCliente.Controls.Add(Me.Label32)
        Me.TpDatosCliente.Controls.Add(Me.Label28)
        Me.TpDatosCliente.Controls.Add(Me.txtCreditoDisponible)
        Me.TpDatosCliente.Controls.Add(Me.txtCalificacion)
        Me.TpDatosCliente.Controls.Add(Me.Label29)
        Me.TpDatosCliente.Controls.Add(Me.nombre_label)
        Me.TpDatosCliente.Controls.Add(Me.txtIDCliente)
        Me.TpDatosCliente.Controls.Add(Me.txtNombre)
        Me.TpDatosCliente.Controls.Add(Me.txtUltimoPago)
        Me.TpDatosCliente.Controls.Add(Me.Label30)
        Me.TpDatosCliente.Controls.Add(Me.txtBalanceGeneral)
        Me.TpDatosCliente.Controls.Add(Me.Label31)
        Me.TpDatosCliente.Controls.Add(Me.btnModificarCliente)
        Me.TpDatosCliente.Controls.Add(Me.btnConsultaRNC)
        Me.TpDatosCliente.Controls.Add(Me.btnCrearCliente)
        Me.TpDatosCliente.Controls.Add(Me.btnBuscarCliente)
        Me.TpDatosCliente.Location = New System.Drawing.Point(4, 53)
        Me.TpDatosCliente.Name = "TpDatosCliente"
        Me.TpDatosCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.TpDatosCliente.Size = New System.Drawing.Size(344, 557)
        Me.TpDatosCliente.TabIndex = 3
        Me.TpDatosCliente.Text = "[F2] Datos del Cliente"
        Me.TpDatosCliente.UseVisualStyleBackColor = True
        '
        'txtNivelPrecio
        '
        Me.txtNivelPrecio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNivelPrecio.Enabled = False
        Me.txtNivelPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNivelPrecio.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNivelPrecio.Location = New System.Drawing.Point(305, 41)
        Me.txtNivelPrecio.Name = "txtNivelPrecio"
        Me.txtNivelPrecio.ReadOnly = True
        Me.txtNivelPrecio.Size = New System.Drawing.Size(33, 23)
        Me.txtNivelPrecio.TabIndex = 398
        Me.txtNivelPrecio.TabStop = False
        Me.txtNivelPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label38.Location = New System.Drawing.Point(4, 84)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(31, 15)
        Me.Label38.TabIndex = 397
        Me.Label38.Text = "RNC"
        '
        'txtRNC
        '
        Me.txtRNC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtRNC.Enabled = False
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(62, 68)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.ReadOnly = True
        Me.txtRNC.Size = New System.Drawing.Size(276, 23)
        Me.txtRNC.TabIndex = 396
        Me.txtRNC.TabStop = False
        '
        'chkEntregarporConduce
        '
        Me.chkEntregarporConduce.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkEntregarporConduce.AutoSize = True
        Me.chkEntregarporConduce.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEntregarporConduce.Location = New System.Drawing.Point(175, 331)
        Me.chkEntregarporConduce.Name = "chkEntregarporConduce"
        Me.chkEntregarporConduce.Size = New System.Drawing.Size(161, 19)
        Me.chkEntregarporConduce.TabIndex = 395
        Me.chkEntregarporConduce.Text = "Entrega sólo por conduce"
        Me.chkEntregarporConduce.UseVisualStyleBackColor = True
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(68, 353)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(248, 23)
        Me.txtVendedor.TabIndex = 394
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(7, 353)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(55, 23)
        Me.txtIDVendedor.TabIndex = 392
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(4, 335)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 15)
        Me.Label11.TabIndex = 393
        Me.Label11.Text = "Vendedor"
        '
        'Label35
        '
        Me.Label35.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label35.Location = New System.Drawing.Point(4, 141)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 15)
        Me.Label35.TabIndex = 391
        Me.Label35.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefono.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTelefono.Location = New System.Drawing.Point(62, 125)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(275, 23)
        Me.txtTelefono.TabIndex = 2
        Me.txtTelefono.TabStop = False
        '
        'Label34
        '
        Me.Label34.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label34.Location = New System.Drawing.Point(4, 112)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(57, 15)
        Me.Label34.TabIndex = 389
        Me.Label34.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDireccion.Enabled = False
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtDireccion.Location = New System.Drawing.Point(62, 96)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(276, 23)
        Me.txtDireccion.TabIndex = 1
        Me.txtDireccion.TabStop = False
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(62, 239)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(277, 25)
        Me.CbxTipoComprobante.TabIndex = 3
        '
        'btnCambiarNCF
        '
        Me.btnCambiarNCF.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCambiarNCF.Location = New System.Drawing.Point(8, 503)
        Me.btnCambiarNCF.Name = "btnCambiarNCF"
        Me.btnCambiarNCF.Size = New System.Drawing.Size(331, 23)
        Me.btnCambiarNCF.TabIndex = 8
        Me.btnCambiarNCF.Text = "[F7] Cambiar NCF"
        Me.btnCambiarNCF.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label33.Location = New System.Drawing.Point(4, 226)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(57, 15)
        Me.Label33.TabIndex = 386
        Me.Label33.Text = "Cobrador"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(4, 257)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 374
        Me.Label9.Text = "T/ NCF"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(62, 210)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(275, 23)
        Me.txtCobrador.TabIndex = 385
        Me.txtCobrador.TabStop = False
        '
        'cbxCondicion
        '
        Me.cbxCondicion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(62, 270)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(276, 25)
        Me.cbxCondicion.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(4, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 365
        Me.Label4.Text = "Cond"
        '
        'btnCambiarCondicion
        '
        Me.btnCambiarCondicion.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCambiarCondicion.Location = New System.Drawing.Point(8, 479)
        Me.btnCambiarCondicion.Name = "btnCambiarCondicion"
        Me.btnCambiarCondicion.Size = New System.Drawing.Size(331, 23)
        Me.btnCambiarCondicion.TabIndex = 7
        Me.btnCambiarCondicion.Text = "[F6] Cambiar condición"
        Me.btnCambiarCondicion.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label32.Location = New System.Drawing.Point(4, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 15)
        Me.Label32.TabIndex = 383
        Me.Label32.Text = "Código"
        '
        'Label28
        '
        Me.Label28.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(131, 186)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(94, 15)
        Me.Label28.TabIndex = 382
        Me.Label28.Text = "Créd. Disponible"
        '
        'txtCreditoDisponible
        '
        Me.txtCreditoDisponible.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCreditoDisponible.Enabled = False
        Me.txtCreditoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreditoDisponible.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCreditoDisponible.Location = New System.Drawing.Point(228, 183)
        Me.txtCreditoDisponible.Name = "txtCreditoDisponible"
        Me.txtCreditoDisponible.ReadOnly = True
        Me.txtCreditoDisponible.Size = New System.Drawing.Size(110, 23)
        Me.txtCreditoDisponible.TabIndex = 381
        Me.txtCreditoDisponible.TabStop = False
        Me.txtCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(62, 181)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(64, 23)
        Me.txtCalificacion.TabIndex = 380
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label29.Location = New System.Drawing.Point(4, 198)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(55, 15)
        Me.Label29.TabIndex = 379
        Me.Label29.Text = "Calificac:"
        '
        'nombre_label
        '
        Me.nombre_label.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(4, 55)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 100
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(62, 12)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(92, 23)
        Me.txtIDCliente.TabIndex = 98
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(62, 41)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(238, 23)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.TabStop = False
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(238, 154)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(100, 23)
        Me.txtUltimoPago.TabIndex = 378
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label30.Location = New System.Drawing.Point(179, 157)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 15)
        Me.Label30.TabIndex = 377
        Me.Label30.Text = "Últ. Pago"
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBalanceGeneral.Enabled = False
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(62, 153)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(114, 23)
        Me.txtBalanceGeneral.TabIndex = 376
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label31.Location = New System.Drawing.Point(4, 170)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 15)
        Me.Label31.TabIndex = 375
        Me.Label31.Text = "Bce. Gral"
        '
        'btnModificarCliente
        '
        Me.btnModificarCliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnModificarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnModificarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnModificarCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnModificarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnModificarCliente.Image = Global.Libregco.My.Resources.Resources.PittyBill_x32
        Me.btnModificarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarCliente.Location = New System.Drawing.Point(245, 11)
        Me.btnModificarCliente.Name = "btnModificarCliente"
        Me.btnModificarCliente.Size = New System.Drawing.Size(94, 24)
        Me.btnModificarCliente.TabIndex = 387
        Me.btnModificarCliente.Text = "Modificar"
        Me.btnModificarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarCliente.UseVisualStyleBackColor = True
        '
        'btnConsultaRNC
        '
        Me.btnConsultaRNC.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConsultaRNC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConsultaRNC.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsultaRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnConsultaRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnConsultaRNC.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnConsultaRNC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaRNC.Location = New System.Drawing.Point(175, 527)
        Me.btnConsultaRNC.Name = "btnConsultaRNC"
        Me.btnConsultaRNC.Size = New System.Drawing.Size(165, 24)
        Me.btnConsultaRNC.TabIndex = 10
        Me.btnConsultaRNC.Text = "         Consulta de RNC"
        Me.btnConsultaRNC.UseVisualStyleBackColor = True
        '
        'btnCrearCliente
        '
        Me.btnCrearCliente.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCrearCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCrearCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCrearCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCrearCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCrearCliente.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.btnCrearCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrearCliente.Location = New System.Drawing.Point(9, 527)
        Me.btnCrearCliente.Name = "btnCrearCliente"
        Me.btnCrearCliente.Size = New System.Drawing.Size(160, 24)
        Me.btnCrearCliente.TabIndex = 9
        Me.btnCrearCliente.Text = "       Nuevo Cliente"
        Me.btnCrearCliente.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(155, 11)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(88, 24)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.Text = "Buscar "
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'TpDatosCredito
        '
        Me.TpDatosCredito.Controls.Add(Me.Label23)
        Me.TpDatosCredito.Controls.Add(Me.DgvPagares)
        Me.TpDatosCredito.Controls.Add(Me.chkFichaDatos)
        Me.TpDatosCredito.Controls.Add(Me.txtCondicionContado)
        Me.TpDatosCredito.Controls.Add(Me.chkHabilitarNota)
        Me.TpDatosCredito.Controls.Add(Me.txtFechaVencimiento)
        Me.TpDatosCredito.Controls.Add(Me.label25)
        Me.TpDatosCredito.Controls.Add(Me.Label21)
        Me.TpDatosCredito.Controls.Add(Me.txtFechaAdicional)
        Me.TpDatosCredito.Controls.Add(Me.label16)
        Me.TpDatosCredito.Controls.Add(Me.Label18)
        Me.TpDatosCredito.Controls.Add(Me.txtAdicional)
        Me.TpDatosCredito.Controls.Add(Me.Label19)
        Me.TpDatosCredito.Controls.Add(Me.txtMontoPagos)
        Me.TpDatosCredito.Controls.Add(Me.Label20)
        Me.TpDatosCredito.Controls.Add(Me.txtCantidadPagos)
        Me.TpDatosCredito.Controls.Add(Me.Label13)
        Me.TpDatosCredito.Controls.Add(Me.txtDiasCondicion)
        Me.TpDatosCredito.Controls.Add(Me.label17)
        Me.TpDatosCredito.Controls.Add(Me.txtBalance)
        Me.TpDatosCredito.Controls.Add(Me.Label15)
        Me.TpDatosCredito.Controls.Add(Me.txtInicial)
        Me.TpDatosCredito.Location = New System.Drawing.Point(4, 53)
        Me.TpDatosCredito.Name = "TpDatosCredito"
        Me.TpDatosCredito.Padding = New System.Windows.Forms.Padding(3)
        Me.TpDatosCredito.Size = New System.Drawing.Size(344, 557)
        Me.TpDatosCredito.TabIndex = 1
        Me.TpDatosCredito.Text = "[F3] Opciones de Crédito"
        Me.TpDatosCredito.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(3, 301)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(144, 15)
        Me.Label23.TabIndex = 127
        Me.Label23.Text = "Visualización de los pagos"
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DgvPagares.BackgroundColor = System.Drawing.Color.White
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvPagares.Location = New System.Drawing.Point(6, 319)
        Me.DgvPagares.MultiSelect = False
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.RowHeadersWidth = 10
        Me.DgvPagares.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPagares.Size = New System.Drawing.Size(332, 102)
        Me.DgvPagares.TabIndex = 126
        '
        'chkFichaDatos
        '
        Me.chkFichaDatos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkFichaDatos.AutoSize = True
        Me.chkFichaDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFichaDatos.Location = New System.Drawing.Point(132, 237)
        Me.chkFichaDatos.Name = "chkFichaDatos"
        Me.chkFichaDatos.Size = New System.Drawing.Size(102, 19)
        Me.chkFichaDatos.TabIndex = 7
        Me.chkFichaDatos.Text = "Habilitar Ficha"
        Me.chkFichaDatos.UseVisualStyleBackColor = True
        '
        'txtCondicionContado
        '
        Me.txtCondicionContado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCondicionContado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicionContado.Location = New System.Drawing.Point(6, 259)
        Me.txtCondicionContado.Multiline = True
        Me.txtCondicionContado.Name = "txtCondicionContado"
        Me.txtCondicionContado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCondicionContado.Size = New System.Drawing.Size(332, 39)
        Me.txtCondicionContado.TabIndex = 8
        '
        'chkHabilitarNota
        '
        Me.chkHabilitarNota.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkHabilitarNota.AutoSize = True
        Me.chkHabilitarNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkHabilitarNota.Location = New System.Drawing.Point(9, 237)
        Me.chkHabilitarNota.Name = "chkHabilitarNota"
        Me.chkHabilitarNota.Size = New System.Drawing.Size(117, 19)
        Me.chkHabilitarNota.TabIndex = 6
        Me.chkHabilitarNota.Text = "Nota de Contado"
        Me.chkHabilitarNota.UseVisualStyleBackColor = True
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtFechaVencimiento.Enabled = False
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(132, 209)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(137, 23)
        Me.txtFechaVencimiento.TabIndex = 5
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label25
        '
        Me.label25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label25.AutoSize = True
        Me.label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label25.Location = New System.Drawing.Point(6, 212)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(123, 15)
        Me.label25.TabIndex = 121
        Me.label25.Text = "Fecha de Vencimiento"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(221, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 15)
        Me.Label21.TabIndex = 120
        Me.Label21.Text = "días"
        '
        'txtFechaAdicional
        '
        Me.txtFechaAdicional.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtFechaAdicional.Enabled = False
        Me.txtFechaAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaAdicional.Location = New System.Drawing.Point(132, 180)
        Me.txtFechaAdicional.Name = "txtFechaAdicional"
        Me.txtFechaAdicional.Size = New System.Drawing.Size(137, 23)
        Me.txtFechaAdicional.TabIndex = 4
        Me.txtFechaAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label16.Location = New System.Drawing.Point(6, 183)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(105, 15)
        Me.label16.TabIndex = 119
        Me.label16.Text = "Fecha de adicional"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(6, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 15)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Pago adicional"
        '
        'txtAdicional
        '
        Me.txtAdicional.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAdicional.Location = New System.Drawing.Point(132, 151)
        Me.txtAdicional.Name = "txtAdicional"
        Me.txtAdicional.Size = New System.Drawing.Size(137, 23)
        Me.txtAdicional.TabIndex = 3
        Me.txtAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(6, 125)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(117, 15)
        Me.Label19.TabIndex = 117
        Me.Label19.Text = "Montos de los pagos"
        '
        'txtMontoPagos
        '
        Me.txtMontoPagos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMontoPagos.Enabled = False
        Me.txtMontoPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoPagos.Location = New System.Drawing.Point(132, 122)
        Me.txtMontoPagos.Name = "txtMontoPagos"
        Me.txtMontoPagos.ReadOnly = True
        Me.txtMontoPagos.Size = New System.Drawing.Size(137, 23)
        Me.txtMontoPagos.TabIndex = 116
        Me.txtMontoPagos.TabStop = False
        Me.txtMontoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(6, 97)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 15)
        Me.Label20.TabIndex = 115
        Me.Label20.Text = "Cantidad de pagos"
        '
        'txtCantidadPagos
        '
        Me.txtCantidadPagos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCantidadPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadPagos.Location = New System.Drawing.Point(132, 94)
        Me.txtCantidadPagos.Name = "txtCantidadPagos"
        Me.txtCantidadPagos.Size = New System.Drawing.Size(137, 23)
        Me.txtCantidadPagos.TabIndex = 2
        Me.txtCantidadPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(6, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 15)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Condición de pago c/"
        '
        'txtDiasCondicion
        '
        Me.txtDiasCondicion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDiasCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiasCondicion.Location = New System.Drawing.Point(132, 7)
        Me.txtDiasCondicion.Name = "txtDiasCondicion"
        Me.txtDiasCondicion.Size = New System.Drawing.Size(83, 23)
        Me.txtDiasCondicion.TabIndex = 0
        Me.txtDiasCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label17
        '
        Me.label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label17.Location = New System.Drawing.Point(6, 68)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(120, 15)
        Me.label17.TabIndex = 109
        Me.label17.Text = "Total restante a pagar"
        '
        'txtBalance
        '
        Me.txtBalance.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.Location = New System.Drawing.Point(132, 65)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(208, 23)
        Me.txtBalance.TabIndex = 108
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(6, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 15)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Inicial de la factura"
        '
        'txtInicial
        '
        Me.txtInicial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInicial.Location = New System.Drawing.Point(132, 36)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(208, 23)
        Me.txtInicial.TabIndex = 1
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TpOtrasInform
        '
        Me.TpOtrasInform.Controls.Add(Me.GroupBox1)
        Me.TpOtrasInform.Controls.Add(Me.chkDesactivar)
        Me.TpOtrasInform.Controls.Add(Me.Label27)
        Me.TpOtrasInform.Controls.Add(Me.txtObservacion)
        Me.TpOtrasInform.Controls.Add(Me.Label26)
        Me.TpOtrasInform.Controls.Add(Me.txtNIF)
        Me.TpOtrasInform.Controls.Add(Me.Label24)
        Me.TpOtrasInform.Controls.Add(Me.txtNCF)
        Me.TpOtrasInform.Location = New System.Drawing.Point(4, 53)
        Me.TpOtrasInform.Name = "TpOtrasInform"
        Me.TpOtrasInform.Size = New System.Drawing.Size(344, 557)
        Me.TpOtrasInform.TabIndex = 2
        Me.TpOtrasInform.Text = "[F4] Otras Informaciones"
        Me.TpOtrasInform.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.cbxVehiculo)
        Me.GroupBox1.Controls.Add(Me.CbxChofer)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.label22)
        Me.GroupBox1.Controls.Add(Me.cbxAlmacen)
        Me.GroupBox1.Controls.Add(Me.label7)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 124)
        Me.GroupBox1.TabIndex = 389
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control Sucursal"
        '
        'cbxVehiculo
        '
        Me.cbxVehiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxVehiculo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cbxVehiculo.FormattingEnabled = True
        Me.cbxVehiculo.Location = New System.Drawing.Point(69, 83)
        Me.cbxVehiculo.Name = "cbxVehiculo"
        Me.cbxVehiculo.Size = New System.Drawing.Size(254, 25)
        Me.cbxVehiculo.TabIndex = 6
        '
        'CbxChofer
        '
        Me.CbxChofer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxChofer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxChofer.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.CbxChofer.FormattingEnabled = True
        Me.CbxChofer.Location = New System.Drawing.Point(69, 52)
        Me.CbxChofer.Name = "CbxChofer"
        Me.CbxChofer.Size = New System.Drawing.Size(254, 25)
        Me.CbxChofer.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 379
        Me.Label5.Text = "Chofer"
        '
        'label22
        '
        Me.label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label22.Location = New System.Drawing.Point(7, 88)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(52, 15)
        Me.label22.TabIndex = 380
        Me.label22.Text = "Vehículo"
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(69, 21)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(254, 25)
        Me.cbxAlmacen.TabIndex = 5
        '
        'label7
        '
        Me.label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(6, 26)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(54, 15)
        Me.label7.TabIndex = 372
        Me.label7.Text = "Almacén"
        '
        'chkDesactivar
        '
        Me.chkDesactivar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkDesactivar.AutoSize = True
        Me.chkDesactivar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDesactivar.Location = New System.Drawing.Point(257, 412)
        Me.chkDesactivar.Name = "chkDesactivar"
        Me.chkDesactivar.Size = New System.Drawing.Size(80, 19)
        Me.chkDesactivar.TabIndex = 388
        Me.chkDesactivar.Text = "Desactivar"
        Me.chkDesactivar.UseVisualStyleBackColor = True
        Me.chkDesactivar.Visible = False
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label27.Location = New System.Drawing.Point(8, 257)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(164, 15)
        Me.Label27.TabIndex = 387
        Me.Label27.Text = "Observaciones y Comentarios"
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(8, 275)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(329, 131)
        Me.txtObservacion.TabIndex = 0
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(8, 170)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(174, 15)
        Me.Label26.TabIndex = 385
        Me.Label26.Text = "Número de comprobante Fiscal"
        '
        'txtNIF
        '
        Me.txtNIF.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNIF.Enabled = False
        Me.txtNIF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIF.Location = New System.Drawing.Point(11, 232)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.ReadOnly = True
        Me.txtNIF.Size = New System.Drawing.Size(324, 23)
        Me.txtNIF.TabIndex = 2
        Me.txtNIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(8, 214)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(153, 15)
        Me.Label24.TabIndex = 383
        Me.Label24.Text = "Número de impresión fiscal"
        '
        'txtNCF
        '
        Me.txtNCF.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNCF.Location = New System.Drawing.Point(8, 188)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(327, 23)
        Me.txtNCF.TabIndex = 1
        Me.txtNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(1066, 642)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(321, 76)
        Me.IconPanel.TabIndex = 385
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(321, 76)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.ShortcutKeyDisplayString = ""
        Me.btnNuevo.Size = New System.Drawing.Size(60, 72)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x48
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(61, 72)
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
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 72)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x48
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(60, 72)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x48
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(65, 72)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Yellow
        Me.Panel2.Controls.Add(Me.cbxPrecio)
        Me.Panel2.Controls.Add(Me.txtIDArticulo)
        Me.Panel2.Controls.Add(Me.cbxMedida)
        Me.Panel2.Controls.Add(Me.btnInsertarArticulo)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(5, 209)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1039, 51)
        Me.Panel2.TabIndex = 0
        '
        'cbxPrecio
        '
        Me.cbxPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxPrecio.FormattingEnabled = True
        Me.cbxPrecio.Location = New System.Drawing.Point(950, 5)
        Me.cbxPrecio.Name = "cbxPrecio"
        Me.cbxPrecio.Size = New System.Drawing.Size(61, 23)
        Me.cbxPrecio.TabIndex = 386
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDArticulo.Location = New System.Drawing.Point(6, 4)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(835, 23)
        Me.txtIDArticulo.TabIndex = 0
        Me.txtIDArticulo.WatermarkColor = System.Drawing.Color.Gray
        Me.txtIDArticulo.WatermarkText = "[F12] Para enfocar la búsqueda de artículos..."
        '
        'lblRazon
        '
        Me.lblRazon.AutoSize = True
        Me.lblRazon.BackColor = System.Drawing.Color.Transparent
        Me.lblRazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazon.ForeColor = System.Drawing.Color.Black
        Me.lblRazon.Location = New System.Drawing.Point(274, 37)
        Me.lblRazon.Name = "lblRazon"
        Me.lblRazon.Size = New System.Drawing.Size(0, 15)
        Me.lblRazon.TabIndex = 367
        Me.lblRazon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.BackColor = System.Drawing.Color.Transparent
        Me.lblSlogan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSlogan.ForeColor = System.Drawing.Color.Black
        Me.lblSlogan.Location = New System.Drawing.Point(274, 51)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 15)
        Me.lblSlogan.TabIndex = 368
        Me.lblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.BackColor = System.Drawing.Color.Transparent
        Me.lblDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(274, 66)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(0, 15)
        Me.lblDireccion.TabIndex = 369
        Me.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRNC
        '
        Me.lblRNC.AutoSize = True
        Me.lblRNC.BackColor = System.Drawing.Color.Transparent
        Me.lblRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRNC.ForeColor = System.Drawing.Color.Black
        Me.lblRNC.Location = New System.Drawing.Point(274, 81)
        Me.lblRNC.Name = "lblRNC"
        Me.lblRNC.Size = New System.Drawing.Size(0, 15)
        Me.lblRNC.TabIndex = 370
        Me.lblRNC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 329
        Me.PicBoxLogo.TabStop = False
        '
        'frm_punto_venta_lite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 776)
        Me.Controls.Add(Me.TabInfoFactura)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.DgvArticulos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblTotalNeto2)
        Me.Controls.Add(Me.lblTotalNeto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblFlete)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblItbis)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.lblRazon)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.lblDireccion)
        Me.Controls.Add(Me.lblRNC)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frm_punto_venta_lite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "68"
        Me.Text = "Punto de Venta Lite"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabInfoFactura.ResumeLayout(False)
        Me.TpDatosFact.ResumeLayout(False)
        Me.TpDatosFact.PerformLayout()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpDatosCliente.ResumeLayout(False)
        Me.TpDatosCliente.PerformLayout()
        Me.TpDatosCredito.ResumeLayout(False)
        Me.TpDatosCredito.PerformLayout()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpOtrasInform.ResumeLayout(False)
        Me.TpOtrasInform.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblIDFactura As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblSecondID As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblFecha As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblHora As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTotalFactura As System.Windows.Forms.Label
    Friend WithEvents lblPrecioArticulo As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTotalNeto2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalNeto As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblFlete As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblItbis As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnInsertarArticulo As System.Windows.Forms.Button
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents cbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents TabInfoFactura As System.Windows.Forms.TabControl
    Friend WithEvents TpDatosCredito As System.Windows.Forms.TabPage
    Friend WithEvents TpOtrasInform As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDiasCondicion As System.Windows.Forms.TextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFechaAdicional As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtAdicional As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMontoPagos As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPagos As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents label25 As System.Windows.Forms.Label
    Friend WithEvents chkHabilitarNota As System.Windows.Forms.CheckBox
    Friend WithEvents txtCondicionContado As System.Windows.Forms.TextBox
    Friend WithEvents chkFichaDatos As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents TpDatosFact As System.Windows.Forms.TabPage
    Friend WithEvents PicImage As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents CbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents CbxChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNCF As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtNIF As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents btnReducirCantidad As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnCambiarCondicion As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents chkDesactivar As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblFechaLarga As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblRazon As System.Windows.Forms.Label
    Friend WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents lblRNC As System.Windows.Forms.Label
    Friend WithEvents btnCambiarNCF As System.Windows.Forms.Button
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.Button
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarCondiciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarNCFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReducirCantidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TpDatosCliente As System.Windows.Forms.TabPage
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Private WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCreditoDisponible As System.Windows.Forms.TextBox
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGeneral As System.Windows.Forms.TextBox
    Private WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblIDTransaccion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IrAOtrasInformacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IrAOpcionesDeCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IrADatosDelClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IrADatosDeLaFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EnfocarBuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtIDArticulo As Watermark
    Friend WithEvents btnModificarPrecio As System.Windows.Forms.Button
    Friend WithEvents ModificarPreciosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblVisualNCF As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblTipoItbis As System.Windows.Forms.Label
    Friend WithEvents lblSubCategoria As System.Windows.Forms.Label
    Friend WithEvents lblTipoProducto As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Private WithEvents btnCrearCliente As System.Windows.Forms.Button
    Private WithEvents btnConsultaRNC As System.Windows.Forms.Button
    Private WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Private WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Private WithEvents btnModificarCliente As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEntregarporConduce As System.Windows.Forms.CheckBox
    Private WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtRNC As System.Windows.Forms.TextBox
    Friend WithEvents txtNivelPrecio As System.Windows.Forms.TextBox
    Friend WithEvents cbxPrecio As System.Windows.Forms.ComboBox
End Class
