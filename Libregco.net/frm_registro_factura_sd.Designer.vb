<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_registro_factura_sd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_registro_factura_sd))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtHoraFactura = New System.Windows.Forms.TextBox()
        Me.txtIDFactura = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtFechaFactura = New System.Windows.Forms.MaskedTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtITBIS = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.TxtDescuentoSuma = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDiasCondicion = New System.Windows.Forms.TextBox()
        Me.txtFechaAdicional = New System.Windows.Forms.MaskedTextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtAdicional = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtMontoPagos = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCantidadPagos = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.txtCondicionContado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkFichaDatos = New System.Windows.Forms.CheckBox()
        Me.chkHabilitarNota = New System.Windows.Forms.CheckBox()
        Me.TabPagCondicion = New System.Windows.Forms.TabControl()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.GbClientes = New System.Windows.Forms.GroupBox()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.lblRNC = New System.Windows.Forms.Label()
        Me.lblModificar = New System.Windows.Forms.LinkLabel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.label20 = New System.Windows.Forms.Label()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.txtCreditoDisponible = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.chkEntregarporConduce = New System.Windows.Forms.CheckBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NavBarControl3 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarRecordatorios = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer2 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.NavBarGroupControlContainer4 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.chkNotificacionSolicitudes = New DevExpress.XtraEditors.ToggleSwitch()
        Me.DgvSolicitudes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorFondoSoliciud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EsVencida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.NavBarSolicitudes = New DevExpress.XtraNavBar.NavBarGroup()
        Me.MenuBarra.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPagCondicion.SuspendLayout()
        Me.GbClientes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NavBarControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl3.SuspendLayout()
        Me.NavBarGroupControlContainer2.SuspendLayout()
        Me.NavBarGroupControlContainer4.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.chkNotificacionSolicitudes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(1067, 24)
        Me.MenuBarra.TabIndex = 190
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
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
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarArtículosToolStripMenuItem, Me.QuitarArtículoToolStripMenuItem, Me.ModificarArtículoToolStripMenuItem, Me.ToolStripSeparator2, Me.BuscarFacturaToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'LimpiarArtículosToolStripMenuItem
        '
        Me.LimpiarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.LimpiarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LimpiarArtículosToolStripMenuItem.Name = "LimpiarArtículosToolStripMenuItem"
        Me.LimpiarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.LimpiarArtículosToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.LimpiarArtículosToolStripMenuItem.Text = "Limpiar"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Quitar"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(205, 6)
        '
        'BuscarFacturaToolStripMenuItem
        '
        Me.BuscarFacturaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarFacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarFacturaToolStripMenuItem.Name = "BuscarFacturaToolStripMenuItem"
        Me.BuscarFacturaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarFacturaToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
        Me.BuscarFacturaToolStripMenuItem.Text = "Buscar Factura"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(208, 38)
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
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.label1)
        Me.GbxUserInfo.Controls.Add(Me.txtHoraFactura)
        Me.GbxUserInfo.Controls.Add(Me.txtIDFactura)
        Me.GbxUserInfo.Controls.Add(Me.label4)
        Me.GbxUserInfo.Controls.Add(Me.label3)
        Me.GbxUserInfo.Controls.Add(Me.txtFechaFactura)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(747, 127)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(317, 72)
        Me.GbxUserInfo.TabIndex = 192
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(156, 15)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(152, 23)
        Me.txtSecondID.TabIndex = 111
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.Location = New System.Drawing.Point(161, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 15)
        Me.label1.TabIndex = 108
        Me.label1.Text = "Hora"
        '
        'txtHoraFactura
        '
        Me.txtHoraFactura.Enabled = False
        Me.txtHoraFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHoraFactura.Location = New System.Drawing.Point(205, 42)
        Me.txtHoraFactura.Name = "txtHoraFactura"
        Me.txtHoraFactura.ReadOnly = True
        Me.txtHoraFactura.Size = New System.Drawing.Size(103, 23)
        Me.txtHoraFactura.TabIndex = 107
        Me.txtHoraFactura.TabStop = False
        Me.txtHoraFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDFactura
        '
        Me.txtIDFactura.Enabled = False
        Me.txtIDFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFactura.Location = New System.Drawing.Point(59, 15)
        Me.txtIDFactura.Name = "txtIDFactura"
        Me.txtIDFactura.ReadOnly = True
        Me.txtIDFactura.Size = New System.Drawing.Size(91, 23)
        Me.txtIDFactura.TabIndex = 106
        Me.txtIDFactura.TabStop = False
        Me.txtIDFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label4.Location = New System.Drawing.Point(7, 45)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(38, 15)
        Me.label4.TabIndex = 105
        Me.label4.Text = "Fecha"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label3.Location = New System.Drawing.Point(7, 18)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(46, 15)
        Me.label3.TabIndex = 104
        Me.label3.Text = "Código"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFactura.Location = New System.Drawing.Point(59, 42)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(91, 23)
        Me.txtFechaFactura.TabIndex = 103
        Me.txtFechaFactura.TabStop = False
        Me.txtFechaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaFactura.ValidatingType = GetType(Date)
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(13, 122)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 15)
        Me.Label27.TabIndex = 197
        Me.Label27.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(75, 119)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(224, 23)
        Me.txtCobrador.TabIndex = 196
        Me.txtCobrador.TabStop = False
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(871, 249)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 15)
        Me.Label24.TabIndex = 207
        Me.Label24.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFlete.Location = New System.Drawing.Point(908, 246)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(142, 23)
        Me.txtFlete.TabIndex = 20
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label12.Location = New System.Drawing.Point(869, 224)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(33, 15)
        Me.label12.TabIndex = 204
        Me.label12.Text = "ITBIS"
        '
        'txtITBIS
        '
        Me.txtITBIS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtITBIS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtITBIS.Location = New System.Drawing.Point(908, 221)
        Me.txtITBIS.Name = "txtITBIS"
        Me.txtITBIS.Size = New System.Drawing.Size(142, 23)
        Me.txtITBIS.TabIndex = 19
        Me.txtITBIS.TabStop = False
        Me.txtITBIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label13.Location = New System.Drawing.Point(839, 274)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(62, 15)
        Me.label13.TabIndex = 206
        Me.label13.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNeto.Location = New System.Drawing.Point(908, 271)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(142, 23)
        Me.txtNeto.TabIndex = 205
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(840, 199)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(63, 15)
        Me.label11.TabIndex = 202
        Me.label11.Text = "Descuento"
        '
        'TxtDescuentoSuma
        '
        Me.TxtDescuentoSuma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescuentoSuma.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtDescuentoSuma.Location = New System.Drawing.Point(908, 196)
        Me.TxtDescuentoSuma.Name = "TxtDescuentoSuma"
        Me.TxtDescuentoSuma.Size = New System.Drawing.Size(142, 23)
        Me.TxtDescuentoSuma.TabIndex = 18
        Me.TxtDescuentoSuma.TabStop = False
        Me.TxtDescuentoSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(844, 174)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(58, 15)
        Me.label10.TabIndex = 200
        Me.label10.Text = "Sub-Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.Location = New System.Drawing.Point(908, 171)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(142, 23)
        Me.txtSubTotal.TabIndex = 17
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(723, 21)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(224, 23)
        Me.CbxTipoComprobante.TabIndex = 6
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkNulo.Location = New System.Drawing.Point(435, 40)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(52, 19)
        Me.ChkNulo.TabIndex = 274
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(633, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 19
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
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 669)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1067, 25)
        Me.BarraEstado.TabIndex = 331
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
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.Location = New System.Drawing.Point(13, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(62, 15)
        Me.Label33.TabIndex = 333
        Me.Label33.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(16, 18)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(197, 23)
        Me.cbxCondicion.TabIndex = 3
        '
        'Label29
        '
        Me.Label29.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.Location = New System.Drawing.Point(13, 54)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(87, 15)
        Me.Label29.TabIndex = 336
        Me.Label29.Text = "Observaciones:"
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(219, 18)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(190, 23)
        Me.cbxAlmacen.TabIndex = 4
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(16, 72)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(820, 31)
        Me.txtObservacion.TabIndex = 7
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(216, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(54, 15)
        Me.label7.TabIndex = 337
        Me.label7.Text = "Almacén"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DgvPagares)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(713, 93)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pagares"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPagares.Location = New System.Drawing.Point(6, 6)
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.Size = New System.Drawing.Size(670, 88)
        Me.DgvPagares.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtDiasCondicion)
        Me.TabPage1.Controls.Add(Me.txtFechaAdicional)
        Me.TabPage1.Controls.Add(Me.label17)
        Me.TabPage1.Controls.Add(Me.txtBalance)
        Me.TabPage1.Controls.Add(Me.label16)
        Me.TabPage1.Controls.Add(Me.label15)
        Me.TabPage1.Controls.Add(Me.txtAdicional)
        Me.TabPage1.Controls.Add(Me.label14)
        Me.TabPage1.Controls.Add(Me.txtMontoPagos)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.txtCantidadPagos)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.txtInicial)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtFechaVencimiento)
        Me.TabPage1.Controls.Add(Me.txtCondicionContado)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.chkFichaDatos)
        Me.TabPage1.Controls.Add(Me.chkHabilitarNota)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(713, 93)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Factura"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 311
        Me.Label6.Text = "Cond."
        '
        'txtDiasCondicion
        '
        Me.txtDiasCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiasCondicion.Location = New System.Drawing.Point(6, 23)
        Me.txtDiasCondicion.Name = "txtDiasCondicion"
        Me.txtDiasCondicion.Size = New System.Drawing.Size(40, 23)
        Me.txtDiasCondicion.TabIndex = 9
        Me.txtDiasCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaAdicional
        '
        Me.txtFechaAdicional.Enabled = False
        Me.txtFechaAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaAdicional.Location = New System.Drawing.Point(618, 23)
        Me.txtFechaAdicional.Name = "txtFechaAdicional"
        Me.txtFechaAdicional.Size = New System.Drawing.Size(89, 23)
        Me.txtFechaAdicional.TabIndex = 13
        Me.txtFechaAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label17.Location = New System.Drawing.Point(165, 5)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(75, 15)
        Me.label17.TabIndex = 309
        Me.label17.Text = "Total a Pagar"
        '
        'txtBalance
        '
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.Location = New System.Drawing.Point(168, 23)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(125, 23)
        Me.txtBalance.TabIndex = 308
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label16.Location = New System.Drawing.Point(615, 5)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(91, 15)
        Me.label16.TabIndex = 307
        Me.label16.Text = "Fecha Adicional"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.Location = New System.Drawing.Point(495, 4)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(87, 15)
        Me.label15.TabIndex = 306
        Me.label15.Text = "Pago Adicional"
        '
        'txtAdicional
        '
        Me.txtAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAdicional.Location = New System.Drawing.Point(498, 22)
        Me.txtAdicional.Name = "txtAdicional"
        Me.txtAdicional.Size = New System.Drawing.Size(114, 23)
        Me.txtAdicional.TabIndex = 12
        Me.txtAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label14.Location = New System.Drawing.Point(375, 5)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(117, 15)
        Me.label14.TabIndex = 305
        Me.label14.Text = "Montos de los Pagos"
        '
        'txtMontoPagos
        '
        Me.txtMontoPagos.Enabled = False
        Me.txtMontoPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoPagos.Location = New System.Drawing.Point(378, 23)
        Me.txtMontoPagos.Name = "txtMontoPagos"
        Me.txtMontoPagos.ReadOnly = True
        Me.txtMontoPagos.Size = New System.Drawing.Size(114, 23)
        Me.txtMontoPagos.TabIndex = 304
        Me.txtMontoPagos.TabStop = False
        Me.txtMontoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(296, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 15)
        Me.Label18.TabIndex = 303
        Me.Label18.Text = "Cant. Pagos"
        '
        'txtCantidadPagos
        '
        Me.txtCantidadPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadPagos.Location = New System.Drawing.Point(299, 23)
        Me.txtCantidadPagos.Name = "txtCantidadPagos"
        Me.txtCantidadPagos.Size = New System.Drawing.Size(73, 23)
        Me.txtCantidadPagos.TabIndex = 11
        Me.txtCantidadPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(53, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 15)
        Me.Label22.TabIndex = 302
        Me.Label22.Text = "Inicial"
        '
        'txtInicial
        '
        Me.txtInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInicial.Location = New System.Drawing.Point(52, 23)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(110, 23)
        Me.txtInicial.TabIndex = 10
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(130, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 15)
        Me.Label9.TabIndex = 297
        Me.Label9.Text = "Condición de Contado"
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaVencimiento.Enabled = False
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(602, 66)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(105, 23)
        Me.txtFechaVencimiento.TabIndex = 295
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCondicionContado
        '
        Me.txtCondicionContado.Enabled = False
        Me.txtCondicionContado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicionContado.Location = New System.Drawing.Point(133, 67)
        Me.txtCondicionContado.Name = "txtCondicionContado"
        Me.txtCondicionContado.Size = New System.Drawing.Size(465, 23)
        Me.txtCondicionContado.TabIndex = 16
        Me.txtCondicionContado.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(599, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 15)
        Me.Label8.TabIndex = 296
        Me.Label8.Text = "Fecha Vencimiento"
        '
        'chkFichaDatos
        '
        Me.chkFichaDatos.AutoSize = True
        Me.chkFichaDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFichaDatos.Location = New System.Drawing.Point(6, 70)
        Me.chkFichaDatos.Name = "chkFichaDatos"
        Me.chkFichaDatos.Size = New System.Drawing.Size(102, 19)
        Me.chkFichaDatos.TabIndex = 15
        Me.chkFichaDatos.Text = "Habilitar Ficha"
        Me.chkFichaDatos.UseVisualStyleBackColor = True
        '
        'chkHabilitarNota
        '
        Me.chkHabilitarNota.AutoSize = True
        Me.chkHabilitarNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkHabilitarNota.Location = New System.Drawing.Point(7, 49)
        Me.chkHabilitarNota.Name = "chkHabilitarNota"
        Me.chkHabilitarNota.Size = New System.Drawing.Size(117, 19)
        Me.chkHabilitarNota.TabIndex = 14
        Me.chkHabilitarNota.Text = "Nota de Contado"
        Me.chkHabilitarNota.UseVisualStyleBackColor = True
        '
        'TabPagCondicion
        '
        Me.TabPagCondicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabPagCondicion.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabPagCondicion.Controls.Add(Me.TabPage1)
        Me.TabPagCondicion.Controls.Add(Me.TabPage2)
        Me.TabPagCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPagCondicion.Location = New System.Drawing.Point(12, 171)
        Me.TabPagCondicion.Name = "TabPagCondicion"
        Me.TabPagCondicion.SelectedIndex = 0
        Me.TabPagCondicion.Size = New System.Drawing.Size(721, 124)
        Me.TabPagCondicion.TabIndex = 8
        Me.TabPagCondicion.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(723, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 15)
        Me.Label23.TabIndex = 338
        Me.Label23.Text = "Comprobante Fiscal"
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(957, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(25, 15)
        Me.Label25.TabIndex = 340
        Me.Label25.Text = "NIF"
        '
        'txtNIF
        '
        Me.txtNIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNIF.Enabled = False
        Me.txtNIF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNIF.Location = New System.Drawing.Point(957, 21)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.Size = New System.Drawing.Size(224, 23)
        Me.txtNIF.TabIndex = 339
        Me.txtNIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbClientes
        '
        Me.GbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbClientes.Controls.Add(Me.txtRNC)
        Me.GbClientes.Controls.Add(Me.lblRNC)
        Me.GbClientes.Controls.Add(Me.lblModificar)
        Me.GbClientes.Controls.Add(Me.Label34)
        Me.GbClientes.Controls.Add(Me.Panel1)
        Me.GbClientes.Controls.Add(Me.lblTelefonos)
        Me.GbClientes.Controls.Add(Me.lblDireccion)
        Me.GbClientes.Controls.Add(Me.txtTelefonos)
        Me.GbClientes.Controls.Add(Me.txtDireccion)
        Me.GbClientes.Controls.Add(Me.btnBuscarCliente)
        Me.GbClientes.Controls.Add(Me.nombre_label)
        Me.GbClientes.Controls.Add(Me.txtIDCliente)
        Me.GbClientes.Controls.Add(Me.txtNombre)
        Me.GbClientes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbClientes.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GbClientes.Location = New System.Drawing.Point(6, 127)
        Me.GbClientes.Name = "GbClientes"
        Me.GbClientes.Size = New System.Drawing.Size(735, 72)
        Me.GbClientes.TabIndex = 0
        Me.GbClientes.TabStop = False
        Me.GbClientes.Text = "Datos Cliente"
        '
        'txtRNC
        '
        Me.txtRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(573, 105)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.Size = New System.Drawing.Size(156, 23)
        Me.txtRNC.TabIndex = 331
        Me.txtRNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRNC.Visible = False
        '
        'lblRNC
        '
        Me.lblRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRNC.AutoSize = True
        Me.lblRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblRNC.Location = New System.Drawing.Point(538, 108)
        Me.lblRNC.Name = "lblRNC"
        Me.lblRNC.Size = New System.Drawing.Size(31, 15)
        Me.lblRNC.TabIndex = 330
        Me.lblRNC.Text = "RNC"
        Me.lblRNC.Visible = False
        '
        'lblModificar
        '
        Me.lblModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModificar.AutoSize = True
        Me.lblModificar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModificar.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblModificar.LinkColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblModificar.Location = New System.Drawing.Point(650, -1)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(83, 15)
        Me.lblModificar.TabIndex = 328
        Me.lblModificar.TabStop = True
        Me.lblModificar.Text = "Ctrl+Modificar"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label34.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label34.Location = New System.Drawing.Point(640, 131)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(90, 15)
        Me.Label34.TabIndex = 329
        Me.Label34.Text = "Volver a ajustar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.label20)
        Me.Panel1.Controls.Add(Me.txtBalanceGeneral)
        Me.Panel1.Controls.Add(Me.label21)
        Me.Panel1.Controls.Add(Me.txtUltimoPago)
        Me.Panel1.Controls.Add(Me.txtCreditoDisponible)
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.txtCalificacion)
        Me.Panel1.Location = New System.Drawing.Point(3, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 25)
        Me.Panel1.TabIndex = 328
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(4, 4)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(53, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Bce. Gral"
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.Enabled = False
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(64, 1)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(117, 23)
        Me.txtBalanceGeneral.TabIndex = 124
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(187, 4)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Últ. Pago"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(248, 1)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(89, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCreditoDisponible
        '
        Me.txtCreditoDisponible.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreditoDisponible.Enabled = False
        Me.txtCreditoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreditoDisponible.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCreditoDisponible.Location = New System.Drawing.Point(597, 1)
        Me.txtCreditoDisponible.Name = "txtCreditoDisponible"
        Me.txtCreditoDisponible.ReadOnly = True
        Me.txtCreditoDisponible.Size = New System.Drawing.Size(130, 23)
        Me.txtCreditoDisponible.TabIndex = 180
        Me.txtCreditoDisponible.TabStop = False
        Me.txtCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label2.Location = New System.Drawing.Point(343, 3)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(69, 15)
        Me.label2.TabIndex = 129
        Me.label2.Text = "Calificación"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(487, 4)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(104, 15)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = "Crédito disponible"
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(418, 1)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(66, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTelefonos
        '
        Me.lblTelefonos.AutoSize = True
        Me.lblTelefonos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTelefonos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTelefonos.Location = New System.Drawing.Point(8, 108)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(58, 15)
        Me.lblTelefonos.TabIndex = 186
        Me.lblTelefonos.Text = "Teléfonos"
        Me.lblTelefonos.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDireccion.Location = New System.Drawing.Point(8, 79)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(57, 15)
        Me.lblDireccion.TabIndex = 185
        Me.lblDireccion.Text = "Dirección"
        Me.lblDireccion.Visible = False
        '
        'txtTelefonos
        '
        Me.txtTelefonos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefonos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefonos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTelefonos.Location = New System.Drawing.Point(67, 105)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.Size = New System.Drawing.Size(469, 23)
        Me.txtTelefonos.TabIndex = 3
        Me.txtTelefonos.Visible = False
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtDireccion.Location = New System.Drawing.Point(67, 76)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(663, 23)
        Me.txtDireccion.TabIndex = 2
        Me.txtDireccion.Visible = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(172, 15)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 1
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(7, 18)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(66, 15)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(108, 23)
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
        Me.txtNombre.Location = New System.Drawing.Point(193, 15)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(537, 23)
        Me.txtNombre.TabIndex = 2
        Me.txtNombre.TabStop = False
        '
        'chkEntregarporConduce
        '
        Me.chkEntregarporConduce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEntregarporConduce.AutoSize = True
        Me.chkEntregarporConduce.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEntregarporConduce.Location = New System.Drawing.Point(234, 171)
        Me.chkEntregarporConduce.Name = "chkEntregarporConduce"
        Me.chkEntregarporConduce.Size = New System.Drawing.Size(161, 19)
        Me.chkEntregarporConduce.TabIndex = 342
        Me.chkEntregarporConduce.Text = "Entrega sólo por conduce"
        Me.chkEntregarporConduce.UseVisualStyleBackColor = True
        Me.chkEntregarporConduce.Visible = False
        '
        'txtVendedor
        '
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(481, 21)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(236, 23)
        Me.txtVendedor.TabIndex = 345
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(420, 21)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(55, 23)
        Me.txtIDVendedor.TabIndex = 5
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(417, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 344
        Me.Label5.Text = "Vendedor"
        '
        'NavBarControl3
        '
        Me.NavBarControl3.ActiveGroup = Me.NavBarRecordatorios
        Me.NavBarControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NavBarControl3.Controls.Add(Me.NavBarGroupControlContainer2)
        Me.NavBarControl3.Controls.Add(Me.NavBarGroupControlContainer4)
        Me.NavBarControl3.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarRecordatorios, Me.NavBarSolicitudes})
        Me.NavBarControl3.Location = New System.Drawing.Point(5, 201)
        Me.NavBarControl3.Name = "NavBarControl3"
        Me.NavBarControl3.OptionsNavPane.ExpandedWidth = 1058
        Me.NavBarControl3.OptionsNavPane.ShowExpandButton = False
        Me.NavBarControl3.OptionsNavPane.ShowGroupImageInHeader = True
        Me.NavBarControl3.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl3.Size = New System.Drawing.Size(1058, 465)
        Me.NavBarControl3.TabIndex = 346
        Me.NavBarControl3.Text = "NavBarControl3"
        '
        'NavBarRecordatorios
        '
        Me.NavBarRecordatorios.Caption = "Facturación"
        Me.NavBarRecordatorios.ControlContainer = Me.NavBarGroupControlContainer2
        Me.NavBarRecordatorios.Expanded = True
        Me.NavBarRecordatorios.GroupClientHeight = 261
        Me.NavBarRecordatorios.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarRecordatorios.ImageOptions.LargeImage = CType(resources.GetObject("NavBarRecordatorios.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarRecordatorios.Name = "NavBarRecordatorios"
        '
        'NavBarGroupControlContainer2
        '
        Me.NavBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer2.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label33)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.chkEntregarporConduce)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.cbxCondicion)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.label7)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label25)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtNIF)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.TabPagCondicion)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label24)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtCobrador)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtFlete)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.cbxAlmacen)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.label12)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label27)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtITBIS)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label5)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.label13)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label29)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtNeto)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtObservacion)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.label11)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.Label23)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.TxtDescuentoSuma)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtIDVendedor)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.label10)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.CbxTipoComprobante)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtSubTotal)
        Me.NavBarGroupControlContainer2.Controls.Add(Me.txtVendedor)
        Me.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2"
        Me.NavBarGroupControlContainer2.Size = New System.Drawing.Size(1058, 298)
        Me.NavBarGroupControlContainer2.TabIndex = 0
        '
        'NavBarGroupControlContainer4
        '
        Me.NavBarGroupControlContainer4.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer4.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer4.Controls.Add(Me.Panel24)
        Me.NavBarGroupControlContainer4.Name = "NavBarGroupControlContainer4"
        Me.NavBarGroupControlContainer4.Size = New System.Drawing.Size(823, 492)
        Me.NavBarGroupControlContainer4.TabIndex = 1
        '
        'Panel24
        '
        Me.Panel24.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.LabelControl4)
        Me.Panel24.Controls.Add(Me.chkNotificacionSolicitudes)
        Me.Panel24.Controls.Add(Me.DgvSolicitudes)
        Me.Panel24.Controls.Add(Me.Label31)
        Me.Panel24.Controls.Add(Me.Label32)
        Me.Panel24.Location = New System.Drawing.Point(0, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(823, 489)
        Me.Panel24.TabIndex = 51
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl4.Location = New System.Drawing.Point(680, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 42
        Me.LabelControl4.Text = "Notificación"
        '
        'chkNotificacionSolicitudes
        '
        Me.chkNotificacionSolicitudes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNotificacionSolicitudes.Location = New System.Drawing.Point(741, 7)
        Me.chkNotificacionSolicitudes.Name = "chkNotificacionSolicitudes"
        Me.chkNotificacionSolicitudes.Properties.OffText = "No"
        Me.chkNotificacionSolicitudes.Properties.OnText = "Si"
        Me.chkNotificacionSolicitudes.Properties.ShowText = False
        Me.chkNotificacionSolicitudes.Size = New System.Drawing.Size(70, 24)
        Me.chkNotificacionSolicitudes.TabIndex = 41
        '
        'DgvSolicitudes
        '
        Me.DgvSolicitudes.AllowUserToAddRows = False
        Me.DgvSolicitudes.AllowUserToDeleteRows = False
        Me.DgvSolicitudes.AllowUserToResizeColumns = False
        Me.DgvSolicitudes.AllowUserToResizeRows = False
        Me.DgvSolicitudes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvSolicitudes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvSolicitudes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSolicitudes.ColumnHeadersVisible = False
        Me.DgvSolicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.ValorColor, Me.ColorFondoSoliciud, Me.Descripcion, Me.EsVencida})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSolicitudes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSolicitudes.EnableHeadersVisualStyles = False
        Me.DgvSolicitudes.GridColor = System.Drawing.Color.WhiteSmoke
        Me.DgvSolicitudes.Location = New System.Drawing.Point(13, 42)
        Me.DgvSolicitudes.Name = "DgvSolicitudes"
        Me.DgvSolicitudes.ReadOnly = True
        Me.DgvSolicitudes.RowHeadersVisible = False
        Me.DgvSolicitudes.RowTemplate.Height = 19
        Me.DgvSolicitudes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSolicitudes.Size = New System.Drawing.Size(798, 436)
        Me.DgvSolicitudes.TabIndex = 40
        Me.DgvSolicitudes.TabStop = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Formato"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 5
        '
        'ValorColor
        '
        Me.ValorColor.HeaderText = "ValorStatusColor"
        Me.ValorColor.Name = "ValorColor"
        Me.ValorColor.ReadOnly = True
        Me.ValorColor.Visible = False
        '
        'ColorFondoSoliciud
        '
        Me.ColorFondoSoliciud.HeaderText = "ColorStatus"
        Me.ColorFondoSoliciud.Name = "ColorFondoSoliciud"
        Me.ColorFondoSoliciud.ReadOnly = True
        Me.ColorFondoSoliciud.Width = 5
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 105
        '
        'EsVencida
        '
        Me.EsVencida.HeaderText = "EsVencida"
        Me.EsVencida.Name = "EsVencida"
        Me.EsVencida.ReadOnly = True
        Me.EsVencida.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.DarkTurquoise
        Me.Label31.Location = New System.Drawing.Point(11, 10)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(6, 26)
        Me.Label31.TabIndex = 37
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI Light", 18.0!)
        Me.Label32.Location = New System.Drawing.Point(17, 6)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(120, 32)
        Me.Label32.TabIndex = 36
        Me.Label32.Text = "Solicitudes"
        '
        'NavBarSolicitudes
        '
        Me.NavBarSolicitudes.Caption = "Financiamientos"
        Me.NavBarSolicitudes.ControlContainer = Me.NavBarGroupControlContainer4
        Me.NavBarSolicitudes.GroupClientHeight = 463
        Me.NavBarSolicitudes.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarSolicitudes.ImageOptions.LargeImage = CType(resources.GetObject("NavBarSolicitudes.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarSolicitudes.Name = "NavBarSolicitudes"
        '
        'frm_registro_factura_sd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 694)
        Me.Controls.Add(Me.NavBarControl3)
        Me.Controls.Add(Me.GbClientes)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.MenuBarra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_registro_factura_sd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "69"
        Me.Text = "Registro de Facturación"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPagCondicion.ResumeLayout(False)
        Me.GbClientes.ResumeLayout(False)
        Me.GbClientes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NavBarControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl3.ResumeLayout(False)
        Me.NavBarGroupControlContainer2.ResumeLayout(False)
        Me.NavBarGroupControlContainer2.PerformLayout()
        Me.NavBarGroupControlContainer4.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel24.PerformLayout()
        CType(Me.chkNotificacionSolicitudes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LimpiarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BuscarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtIDFactura As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFactura As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents txtITBIS As System.Windows.Forms.TextBox
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuentoSuma As System.Windows.Forms.TextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents CbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtCondicionContado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkFichaDatos As System.Windows.Forms.CheckBox
    Friend WithEvents chkHabilitarNota As System.Windows.Forms.CheckBox
    Friend WithEvents TabPagCondicion As System.Windows.Forms.TabControl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiasCondicion As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAdicional As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents txtAdicional As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtMontoPagos As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPagos As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtNIF As System.Windows.Forms.TextBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents GbClientes As System.Windows.Forms.GroupBox
    Friend WithEvents txtRNC As System.Windows.Forms.TextBox
    Private WithEvents lblRNC As System.Windows.Forms.Label
    Friend WithEvents lblModificar As System.Windows.Forms.LinkLabel
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents label20 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGeneral As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditoDisponible As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents lblTelefonos As System.Windows.Forms.Label
    Private WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents chkEntregarporConduce As System.Windows.Forms.CheckBox
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NavBarControl3 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarRecordatorios As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer2 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavBarGroupControlContainer4 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents Panel24 As Panel
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkNotificacionSolicitudes As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents DgvSolicitudes As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents ValorColor As DataGridViewTextBoxColumn
    Friend WithEvents ColorFondoSoliciud As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents EsVencida As DataGridViewTextBoxColumn
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents NavBarSolicitudes As DevExpress.XtraNavBar.NavBarGroup
End Class
