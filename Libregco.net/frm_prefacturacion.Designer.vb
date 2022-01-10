<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_prefacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_prefacturacion))
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MantenimientoDeArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConsultaDeCotizaciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.GbClientes = New System.Windows.Forms.GroupBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnControlTipoPago = New System.Windows.Forms.Button()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtNivelPrecio = New System.Windows.Forms.TextBox()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.txtIDCondicion = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtIDFactura = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.TbSelectProductos = New System.Windows.Forms.GroupBox()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkAplicarAutomaticamente = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GPExistencia = New DevExpress.XtraEditors.GroupControl()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.TreeViewExistencia = New System.Windows.Forms.TreeView()
        Me.dgvArticulosFactura = New System.Windows.Forms.DataGridView()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.cbxPrecio = New System.Windows.Forms.ComboBox()
        Me.btnInsertarArticulo = New System.Windows.Forms.Button()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBlanquear = New System.Windows.Forms.ToolStripButton()
        Me.btnQuitarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.CbxMedida = New System.Windows.Forms.ComboBox()
        Me.txtTotalArt = New System.Windows.Forms.TextBox()
        Me.txtCantidadArticulo = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionArticulo = New System.Windows.Forms.TextBox()
        Me.btnBuscarArticulo = New System.Windows.Forms.Button()
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.AvanzadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertirACotizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicarPrefacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PickingListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.CMenuProducts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IrAArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitProbabilidades = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FlowProbabilidades = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowSimilares = New System.Windows.Forms.FlowLayoutPanel()
        Me.SplitSimilares = New System.Windows.Forms.SplitContainer()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkMostrarRelacionados = New System.Windows.Forms.CheckBox()
        Me.chkMostrarSimilares = New System.Windows.Forms.CheckBox()
        Me.DoSimilarities = New System.ComponentModel.BackgroundWorker()
        Me.DoProbabilidades = New System.ComponentModel.BackgroundWorker()
        Me.ToastNotificationsManager2 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.MenuBarra.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbClientes.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.TbSelectProductos.SuspendLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPExistencia.SuspendLayout()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraOpciones.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.CMenuProducts.SuspendLayout()
        CType(Me.SplitProbabilidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitProbabilidades.Panel1.SuspendLayout()
        Me.SplitProbabilidades.Panel2.SuspendLayout()
        Me.SplitProbabilidades.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitSimilares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitSimilares.Panel1.SuspendLayout()
        Me.SplitSimilares.Panel2.SuspendLayout()
        Me.SplitSimilares.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.ToastNotificationsManager2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(984, 24)
        Me.MenuBarra.TabIndex = 178
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarArtículosToolStripMenuItem, Me.MantenimientoDeArtículosToolStripMenuItem, Me.ToolStripSeparator1, Me.ConsultaDeCotizaciToolStripMenuItem, Me.ToolStripSeparator3, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar cliente"
        '
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar artículos"
        '
        'MantenimientoDeArtículosToolStripMenuItem
        '
        Me.MantenimientoDeArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Products_x32
        Me.MantenimientoDeArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MantenimientoDeArtículosToolStripMenuItem.Name = "MantenimientoDeArtículosToolStripMenuItem"
        Me.MantenimientoDeArtículosToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.MantenimientoDeArtículosToolStripMenuItem.Text = "Mantenimiento de artículos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(249, 6)
        '
        'ConsultaDeCotizaciToolStripMenuItem
        '
        Me.ConsultaDeCotizaciToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ConsultaDeCotizaciToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultaDeCotizaciToolStripMenuItem.Name = "ConsultaDeCotizaciToolStripMenuItem"
        Me.ConsultaDeCotizaciToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConsultaDeCotizaciToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ConsultaDeCotizaciToolStripMenuItem.Text = "Consulta de cotización"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(249, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarArtículosToolStripMenuItem, Me.QuitarArtículoToolStripMenuItem, Me.ModificarArtículoToolStripMenuItem})
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
        Me.LimpiarArtículosToolStripMenuItem.Size = New System.Drawing.Size(205, 38)
        Me.LimpiarArtículosToolStripMenuItem.Text = "Blanquear Listado"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(205, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Quitar Artículo"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(205, 38)
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar Artículo"
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(211, 72)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'GbClientes
        '
        Me.GbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbClientes.Controls.Add(Me.txtOrden)
        Me.GbClientes.Controls.Add(Me.Label2)
        Me.GbClientes.Controls.Add(Me.btnControlTipoPago)
        Me.GbClientes.Controls.Add(Me.LabelControl1)
        Me.GbClientes.Controls.Add(Me.txtNombre)
        Me.GbClientes.Controls.Add(Me.txtNivelPrecio)
        Me.GbClientes.Controls.Add(Me.txtCondicion)
        Me.GbClientes.Controls.Add(Me.txtIDCondicion)
        Me.GbClientes.Controls.Add(Me.Label33)
        Me.GbClientes.Controls.Add(Me.btnBuscarCliente)
        Me.GbClientes.Controls.Add(Me.txtIDCliente)
        Me.GbClientes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbClientes.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GbClientes.Location = New System.Drawing.Point(5, 3)
        Me.GbClientes.Name = "GbClientes"
        Me.GbClientes.Size = New System.Drawing.Size(665, 72)
        Me.GbClientes.TabIndex = 329
        Me.GbClientes.TabStop = False
        Me.GbClientes.Text = "Datos del cliente"
        '
        'txtOrden
        '
        Me.txtOrden.BackColor = System.Drawing.SystemColors.Info
        Me.txtOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOrden.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtOrden.Location = New System.Drawing.Point(394, 43)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(121, 23)
        Me.txtOrden.TabIndex = 345
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(352, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 344
        Me.Label2.Text = "Orden"
        '
        'btnControlTipoPago
        '
        Me.btnControlTipoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnControlTipoPago.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnControlTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnControlTipoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnControlTipoPago.ForeColor = System.Drawing.Color.Black
        Me.btnControlTipoPago.Image = Global.Libregco.My.Resources.Resources.Facturacion_x90
        Me.btnControlTipoPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnControlTipoPago.Location = New System.Drawing.Point(522, 43)
        Me.btnControlTipoPago.Name = "btnControlTipoPago"
        Me.btnControlTipoPago.Size = New System.Drawing.Size(136, 23)
        Me.btnControlTipoPago.TabIndex = 0
        Me.btnControlTipoPago.Tag = "3"
        Me.btnControlTipoPago.Text = "Pago Mixto / Otros"
        Me.btnControlTipoPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnControlTipoPago.UseVisualStyleBackColor = True
        '
        'LabelControl1
        '
        Me.LabelControl1.AllowHtmlString = True
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl1.Location = New System.Drawing.Point(11, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(78, 15)
        Me.LabelControl1.TabIndex = 343
        Me.LabelControl1.Text = "<u><color=30,144,255><B>[F12]</B></color></u>  Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(177, 15)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(482, 23)
        Me.txtNombre.TabIndex = 1
        '
        'txtNivelPrecio
        '
        Me.txtNivelPrecio.Enabled = False
        Me.txtNivelPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNivelPrecio.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNivelPrecio.Location = New System.Drawing.Point(321, 43)
        Me.txtNivelPrecio.Name = "txtNivelPrecio"
        Me.txtNivelPrecio.ReadOnly = True
        Me.txtNivelPrecio.Size = New System.Drawing.Size(21, 23)
        Me.txtNivelPrecio.TabIndex = 335
        Me.txtNivelPrecio.TabStop = False
        Me.txtNivelPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCondicion
        '
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCondicion.Location = New System.Drawing.Point(155, 43)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(167, 23)
        Me.txtCondicion.TabIndex = 334
        Me.txtCondicion.TabStop = False
        '
        'txtIDCondicion
        '
        Me.txtIDCondicion.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCondicion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCondicion.Location = New System.Drawing.Point(100, 43)
        Me.txtIDCondicion.Name = "txtIDCondicion"
        Me.txtIDCondicion.Size = New System.Drawing.Size(56, 23)
        Me.txtIDCondicion.TabIndex = 2
        Me.txtIDCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.Location = New System.Drawing.Point(8, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(62, 15)
        Me.Label33.TabIndex = 332
        Me.Label33.Text = "Condición"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(155, 15)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(100, 15)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(56, 23)
        Me.txtIDCliente.TabIndex = 0
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.label1)
        Me.GbxUserInfo.Controls.Add(Me.txtIDFactura)
        Me.GbxUserInfo.Controls.Add(Me.label4)
        Me.GbxUserInfo.Controls.Add(Me.label3)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(674, 3)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(307, 72)
        Me.GbxUserInfo.TabIndex = 330
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtHora
        '
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtHora.Location = New System.Drawing.Point(198, 42)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(98, 23)
        Me.txtHora.TabIndex = 416
        Me.txtHora.Value = New Date(2016, 10, 18, 12, 56, 0, 0)
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(159, 15)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(137, 23)
        Me.txtSecondID.TabIndex = 110
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(59, 42)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(97, 23)
        Me.txtFecha.TabIndex = 415
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.Location = New System.Drawing.Point(159, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 15)
        Me.label1.TabIndex = 108
        Me.label1.Text = "Hora"
        '
        'txtIDFactura
        '
        Me.txtIDFactura.Enabled = False
        Me.txtIDFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFactura.Location = New System.Drawing.Point(59, 15)
        Me.txtIDFactura.Name = "txtIDFactura"
        Me.txtIDFactura.ReadOnly = True
        Me.txtIDFactura.Size = New System.Drawing.Size(94, 23)
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
        'TbSelectProductos
        '
        Me.TbSelectProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbSelectProductos.Controls.Add(Me.cbxMoneda)
        Me.TbSelectProductos.Controls.Add(Me.SplitContainer1)
        Me.TbSelectProductos.Controls.Add(Me.txtNeto)
        Me.TbSelectProductos.Controls.Add(Me.cbxPrecio)
        Me.TbSelectProductos.Controls.Add(Me.btnInsertarArticulo)
        Me.TbSelectProductos.Controls.Add(Me.BarraOpciones)
        Me.TbSelectProductos.Controls.Add(Me.CbxMedida)
        Me.TbSelectProductos.Controls.Add(Me.txtTotalArt)
        Me.TbSelectProductos.Controls.Add(Me.txtCantidadArticulo)
        Me.TbSelectProductos.Controls.Add(Me.txtPrecio)
        Me.TbSelectProductos.Controls.Add(Me.txtDescripcionArticulo)
        Me.TbSelectProductos.Controls.Add(Me.btnBuscarArticulo)
        Me.TbSelectProductos.Controls.Add(Me.txtCodigoArticulo)
        Me.TbSelectProductos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbSelectProductos.Location = New System.Drawing.Point(5, 76)
        Me.TbSelectProductos.Name = "TbSelectProductos"
        Me.TbSelectProductos.Size = New System.Drawing.Size(976, 463)
        Me.TbSelectProductos.TabIndex = 3
        Me.TbSelectProductos.TabStop = False
        Me.TbSelectProductos.Text = "Artículos"
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMoneda.Location = New System.Drawing.Point(616, 438)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.cbxMoneda.Properties.Appearance.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(223, 18)
        Me.cbxMoneda.TabIndex = 338
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 45)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.SimpleButton1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkAplicarAutomaticamente)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SeparatorControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GPExistencia)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvArticulosFactura)
        Me.SplitContainer1.Panel2MinSize = 10
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 387)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 337
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Checkedx32
        Me.SimpleButton1.Location = New System.Drawing.Point(852, 5)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(116, 20)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "[F10] Aplicar"
        '
        'chkAplicarAutomaticamente
        '
        Me.chkAplicarAutomaticamente.AutoSize = True
        Me.chkAplicarAutomaticamente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkAplicarAutomaticamente.Location = New System.Drawing.Point(685, 7)
        Me.chkAplicarAutomaticamente.Name = "chkAplicarAutomaticamente"
        Me.chkAplicarAutomaticamente.Size = New System.Drawing.Size(167, 17)
        Me.chkAplicarAutomaticamente.TabIndex = 3
        Me.chkAplicarAutomaticamente.Text = "[F9] Aplicar automáticamente"
        Me.chkAplicarAutomaticamente.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(1, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 1
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, -11)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(973, 23)
        Me.SeparatorControl1.TabIndex = 0
        '
        'GPExistencia
        '
        Me.GPExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GPExistencia.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.GPExistencia.Appearance.Options.UseBackColor = True
        Me.GPExistencia.Controls.Add(Me.PicFoto)
        Me.GPExistencia.Controls.Add(Me.TreeViewExistencia)
        Me.GPExistencia.Location = New System.Drawing.Point(3, 264)
        Me.GPExistencia.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GPExistencia.Name = "GPExistencia"
        Me.GPExistencia.Size = New System.Drawing.Size(509, 91)
        Me.GPExistencia.TabIndex = 163
        Me.GPExistencia.Text = "Existencias"
        '
        'PicFoto
        '
        Me.PicFoto.BackColor = System.Drawing.Color.White
        Me.PicFoto.Dock = System.Windows.Forms.DockStyle.Left
        Me.PicFoto.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicFoto.Location = New System.Drawing.Point(2, 20)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(71, 69)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicFoto.TabIndex = 209
        Me.PicFoto.TabStop = False
        '
        'TreeViewExistencia
        '
        Me.TreeViewExistencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewExistencia.BackColor = System.Drawing.SystemColors.Info
        Me.TreeViewExistencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewExistencia.Location = New System.Drawing.Point(75, 20)
        Me.TreeViewExistencia.Name = "TreeViewExistencia"
        Me.TreeViewExistencia.Size = New System.Drawing.Size(432, 69)
        Me.TreeViewExistencia.TabIndex = 208
        '
        'dgvArticulosFactura
        '
        Me.dgvArticulosFactura.AllowUserToAddRows = False
        Me.dgvArticulosFactura.AllowUserToDeleteRows = False
        Me.dgvArticulosFactura.AllowUserToResizeColumns = False
        Me.dgvArticulosFactura.AllowUserToResizeRows = False
        Me.dgvArticulosFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvArticulosFactura.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvArticulosFactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvArticulosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulosFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArticulosFactura.Location = New System.Drawing.Point(0, 0)
        Me.dgvArticulosFactura.MultiSelect = False
        Me.dgvArticulosFactura.Name = "dgvArticulosFactura"
        Me.dgvArticulosFactura.RowHeadersWidth = 30
        Me.dgvArticulosFactura.RowTemplate.Height = 24
        Me.dgvArticulosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulosFactura.Size = New System.Drawing.Size(970, 358)
        Me.dgvArticulosFactura.TabIndex = 162
        Me.dgvArticulosFactura.TabStop = False
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNeto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(844, 436)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(129, 20)
        Me.txtNeto.TabIndex = 335
        Me.txtNeto.TabStop = False
        '
        'cbxPrecio
        '
        Me.cbxPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxPrecio.FormattingEnabled = True
        Me.cbxPrecio.Location = New System.Drawing.Point(605, 17)
        Me.cbxPrecio.Name = "cbxPrecio"
        Me.cbxPrecio.Size = New System.Drawing.Size(61, 23)
        Me.cbxPrecio.TabIndex = 5
        '
        'btnInsertarArticulo
        '
        Me.btnInsertarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInsertarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnInsertarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertarArticulo.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnInsertarArticulo.Location = New System.Drawing.Point(948, 17)
        Me.btnInsertarArticulo.Name = "btnInsertarArticulo"
        Me.btnInsertarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArticulo.TabIndex = 7
        Me.btnInsertarArticulo.UseVisualStyleBackColor = True
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator2, Me.btnBlanquear, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 435)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraOpciones.Size = New System.Drawing.Size(970, 25)
        Me.BarraOpciones.TabIndex = 252
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Libregco.My.Resources.Resources.Products_x24
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButton1.Text = "Artículos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBlanquear.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(97, 22)
        Me.btnBlanquear.Text = "F1 - Blanquear"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(79, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar"
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(92, 22)
        Me.btnModificar.Text = "F3 - Modificar"
        '
        'CbxMedida
        '
        Me.CbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxMedida.FormattingEnabled = True
        Me.CbxMedida.Location = New System.Drawing.Point(189, 16)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(61, 23)
        Me.CbxMedida.TabIndex = 3
        '
        'txtTotalArt
        '
        Me.txtTotalArt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalArt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalArt.Location = New System.Drawing.Point(798, 17)
        Me.txtTotalArt.Name = "txtTotalArt"
        Me.txtTotalArt.ReadOnly = True
        Me.txtTotalArt.Size = New System.Drawing.Size(151, 23)
        Me.txtTotalArt.TabIndex = 10
        Me.txtTotalArt.TabStop = False
        Me.txtTotalArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(137, 17)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(46, 23)
        Me.txtCantidadArticulo.TabIndex = 2
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(673, 17)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(120, 23)
        Me.txtPrecio.TabIndex = 6
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(256, 17)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.ReadOnly = True
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(343, 23)
        Me.txtDescripcionArticulo.TabIndex = 4
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(108, 17)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 1
        Me.btnBuscarArticulo.TabStop = False
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(6, 17)
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(103, 23)
        Me.txtCodigoArticulo.TabIndex = 0
        Me.txtCodigoArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 666)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(984, 25)
        Me.BarraEstado.TabIndex = 337
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
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.IconPanel.Location = New System.Drawing.Point(639, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(345, 99)
        Me.IconPanel.TabIndex = 338
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.AvanzadoToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(345, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'AvanzadoToolStripMenuItem
        '
        Me.AvanzadoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConvertirACotizaciónToolStripMenuItem, Me.DuplicarPrefacturaciónToolStripMenuItem, Me.PickingListToolStripMenuItem})
        Me.AvanzadoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AvanzadoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Reportesx72
        Me.AvanzadoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AvanzadoToolStripMenuItem.Name = "AvanzadoToolStripMenuItem"
        Me.AvanzadoToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.AvanzadoToolStripMenuItem.Text = "Avanzado"
        Me.AvanzadoToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ConvertirACotizaciónToolStripMenuItem
        '
        Me.ConvertirACotizaciónToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ConvertirACotizaciónToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Procesox32
        Me.ConvertirACotizaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConvertirACotizaciónToolStripMenuItem.Name = "ConvertirACotizaciónToolStripMenuItem"
        Me.ConvertirACotizaciónToolStripMenuItem.Size = New System.Drawing.Size(236, 38)
        Me.ConvertirACotizaciónToolStripMenuItem.Text = "Convertir a Cotización"
        '
        'DuplicarPrefacturaciónToolStripMenuItem
        '
        Me.DuplicarPrefacturaciónToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Prefacturax32
        Me.DuplicarPrefacturaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DuplicarPrefacturaciónToolStripMenuItem.Name = "DuplicarPrefacturaciónToolStripMenuItem"
        Me.DuplicarPrefacturaciónToolStripMenuItem.Size = New System.Drawing.Size(236, 38)
        Me.DuplicarPrefacturaciónToolStripMenuItem.Text = "Duplicar prefacturación"
        Me.DuplicarPrefacturaciónToolStripMenuItem.Visible = False
        '
        'PickingListToolStripMenuItem
        '
        Me.PickingListToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Archivox32
        Me.PickingListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PickingListToolStripMenuItem.Name = "PickingListToolStripMenuItem"
        Me.PickingListToolStripMenuItem.Size = New System.Drawing.Size(236, 38)
        Me.PickingListToolStripMenuItem.Text = "Picking List (Lista de Selección)"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'ChkNulo
        '
        Me.ChkNulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Enabled = False
        Me.ChkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkNulo.Location = New System.Drawing.Point(258, 99)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(52, 19)
        Me.ChkNulo.TabIndex = 339
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'CMenuProducts
        '
        Me.CMenuProducts.BackColor = System.Drawing.Color.White
        Me.CMenuProducts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IrAArtículosToolStripMenuItem, Me.ToolStripSeparator5, Me.QuitarToolStripMenuItem1, Me.ModificarToolStripMenuItem1})
        Me.CMenuProducts.Name = "ContextMenuStrip1"
        Me.CMenuProducts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuProducts.Size = New System.Drawing.Size(147, 100)
        Me.CMenuProducts.Text = "Opciones"
        '
        'IrAArtículosToolStripMenuItem
        '
        Me.IrAArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Products_x24
        Me.IrAArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.IrAArtículosToolStripMenuItem.Name = "IrAArtículosToolStripMenuItem"
        Me.IrAArtículosToolStripMenuItem.Size = New System.Drawing.Size(146, 30)
        Me.IrAArtículosToolStripMenuItem.Text = "Ir a artículos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(143, 6)
        '
        'QuitarToolStripMenuItem1
        '
        Me.QuitarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Delete_x24
        Me.QuitarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem1.Name = "QuitarToolStripMenuItem1"
        Me.QuitarToolStripMenuItem1.Size = New System.Drawing.Size(146, 30)
        Me.QuitarToolStripMenuItem1.Text = "Quitar"
        '
        'ModificarToolStripMenuItem1
        '
        Me.ModificarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.TextEdit_x24
        Me.ModificarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem1.Name = "ModificarToolStripMenuItem1"
        Me.ModificarToolStripMenuItem1.Size = New System.Drawing.Size(146, 30)
        Me.ModificarToolStripMenuItem1.Text = "Modificar"
        '
        'SplitProbabilidades
        '
        Me.SplitProbabilidades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitProbabilidades.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitProbabilidades.IsSplitterFixed = True
        Me.SplitProbabilidades.Location = New System.Drawing.Point(0, 0)
        Me.SplitProbabilidades.Name = "SplitProbabilidades"
        '
        'SplitProbabilidades.Panel1
        '
        Me.SplitProbabilidades.Panel1.Controls.Add(Me.GbClientes)
        Me.SplitProbabilidades.Panel1.Controls.Add(Me.GbxUserInfo)
        Me.SplitProbabilidades.Panel1.Controls.Add(Me.TbSelectProductos)
        '
        'SplitProbabilidades.Panel2
        '
        Me.SplitProbabilidades.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitProbabilidades.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitProbabilidades.Panel2Collapsed = True
        Me.SplitProbabilidades.Size = New System.Drawing.Size(984, 542)
        Me.SplitProbabilidades.SplitterDistance = 672
        Me.SplitProbabilidades.TabIndex = 0
        Me.SplitProbabilidades.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(96, 100)
        Me.TabControl1.TabIndex = 340
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FlowProbabilidades)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(88, 74)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Los clientes también compraron"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FlowProbabilidades
        '
        Me.FlowProbabilidades.AutoScroll = True
        Me.FlowProbabilidades.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowProbabilidades.BackColor = System.Drawing.Color.White
        Me.FlowProbabilidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowProbabilidades.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowProbabilidades.Location = New System.Drawing.Point(3, 3)
        Me.FlowProbabilidades.Name = "FlowProbabilidades"
        Me.FlowProbabilidades.Size = New System.Drawing.Size(82, 68)
        Me.FlowProbabilidades.TabIndex = 0
        Me.FlowProbabilidades.WrapContents = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(4, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(273, 1)
        Me.Label6.TabIndex = 2
        '
        'FlowSimilares
        '
        Me.FlowSimilares.AutoScroll = True
        Me.FlowSimilares.BackColor = System.Drawing.Color.White
        Me.FlowSimilares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowSimilares.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FlowSimilares.Location = New System.Drawing.Point(3, 3)
        Me.FlowSimilares.Name = "FlowSimilares"
        Me.FlowSimilares.Size = New System.Drawing.Size(136, 14)
        Me.FlowSimilares.TabIndex = 4
        Me.FlowSimilares.WrapContents = False
        '
        'SplitSimilares
        '
        Me.SplitSimilares.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitSimilares.Location = New System.Drawing.Point(0, 121)
        Me.SplitSimilares.Name = "SplitSimilares"
        Me.SplitSimilares.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitSimilares.Panel1
        '
        Me.SplitSimilares.Panel1.Controls.Add(Me.SplitProbabilidades)
        '
        'SplitSimilares.Panel2
        '
        Me.SplitSimilares.Panel2.Controls.Add(Me.TabControl2)
        Me.SplitSimilares.Panel2Collapsed = True
        Me.SplitSimilares.Size = New System.Drawing.Size(984, 542)
        Me.SplitSimilares.SplitterDistance = 385
        Me.SplitSimilares.TabIndex = 342
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(150, 46)
        Me.TabControl2.TabIndex = 0
        Me.TabControl2.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FlowSimilares)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(142, 20)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Productos similares"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkMostrarRelacionados
        '
        Me.chkMostrarRelacionados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMostrarRelacionados.AutoSize = True
        Me.chkMostrarRelacionados.Checked = True
        Me.chkMostrarRelacionados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarRelacionados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarRelacionados.Location = New System.Drawing.Point(472, 105)
        Me.chkMostrarRelacionados.Name = "chkMostrarRelacionados"
        Me.chkMostrarRelacionados.Size = New System.Drawing.Size(126, 17)
        Me.chkMostrarRelacionados.TabIndex = 337
        Me.chkMostrarRelacionados.TabStop = False
        Me.chkMostrarRelacionados.Text = "Mostrar relacionados"
        Me.chkMostrarRelacionados.UseVisualStyleBackColor = True
        '
        'chkMostrarSimilares
        '
        Me.chkMostrarSimilares.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMostrarSimilares.AutoSize = True
        Me.chkMostrarSimilares.Checked = True
        Me.chkMostrarSimilares.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarSimilares.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarSimilares.Location = New System.Drawing.Point(360, 105)
        Me.chkMostrarSimilares.Name = "chkMostrarSimilares"
        Me.chkMostrarSimilares.Size = New System.Drawing.Size(106, 17)
        Me.chkMostrarSimilares.TabIndex = 338
        Me.chkMostrarSimilares.TabStop = False
        Me.chkMostrarSimilares.Text = "Mostrar similares"
        Me.chkMostrarSimilares.UseVisualStyleBackColor = True
        '
        'DoSimilarities
        '
        Me.DoSimilarities.WorkerReportsProgress = True
        Me.DoSimilarities.WorkerSupportsCancellation = True
        '
        'DoProbabilidades
        '
        Me.DoProbabilidades.WorkerReportsProgress = True
        Me.DoProbabilidades.WorkerSupportsCancellation = True
        '
        'ToastNotificationsManager2
        '
        Me.ToastNotificationsManager2.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager2.ApplicationName = "Libregco"
        Me.ToastNotificationsManager2.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager2.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Prefacturax48, "Prefactura guardada", "La prefactura ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.Prefacturax48, "Prefactura modificada", "La prefactura ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("96986139-5003-4beb-9e42-01c21f7def6a", Global.Libregco.My.Resources.Resources.Prefacturax48, "Prefactura duplicada", "La prefactura ha sido duplicada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'frm_prefacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 691)
        Me.Controls.Add(Me.chkMostrarSimilares)
        Me.Controls.Add(Me.chkMostrarRelacionados)
        Me.Controls.Add(Me.SplitSimilares)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.ChkNulo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1000, 700)
        Me.Name = "frm_prefacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "257"
        Me.Text = "Prefacturación"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbClientes.ResumeLayout(False)
        Me.GbClientes.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.TbSelectProductos.ResumeLayout(False)
        Me.TbSelectProductos.PerformLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPExistencia.ResumeLayout(False)
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.CMenuProducts.ResumeLayout(False)
        Me.SplitProbabilidades.Panel1.ResumeLayout(False)
        Me.SplitProbabilidades.Panel2.ResumeLayout(False)
        CType(Me.SplitProbabilidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitProbabilidades.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitSimilares.Panel1.ResumeLayout(False)
        Me.SplitSimilares.Panel2.ResumeLayout(False)
        CType(Me.SplitSimilares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitSimilares.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.ToastNotificationsManager2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LimpiarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents GbClientes As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtIDFactura As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCondicion As System.Windows.Forms.TextBox
    Friend WithEvents TbSelectProductos As System.Windows.Forms.GroupBox
    Friend WithEvents cbxPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents btnInsertarArticulo As System.Windows.Forms.Button
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalArt As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents dgvArticulosFactura As System.Windows.Forms.DataGridView
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents txtNivelPrecio As System.Windows.Forms.TextBox
    Friend WithEvents CMenuProducts As ContextMenuStrip
    Friend WithEvents IrAArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btnControlTipoPago As Button
    Friend WithEvents SplitProbabilidades As SplitContainer
    Friend WithEvents FlowProbabilidades As FlowLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents FlowSimilares As FlowLayoutPanel
    Friend WithEvents SplitSimilares As SplitContainer
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents chkMostrarSimilares As CheckBox
    Friend WithEvents chkMostrarRelacionados As CheckBox
    Friend WithEvents DoSimilarities As System.ComponentModel.BackgroundWorker
    Friend WithEvents DoProbabilidades As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToastNotificationsManager2 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents ConsultaDeCotizaciToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label5 As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents chkAplicarAutomaticamente As CheckBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GPExistencia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TreeViewExistencia As TreeView
    Friend WithEvents txtOrden As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents AvanzadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConvertirACotizaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MantenimientoDeArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PickingListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PicFoto As PictureBox
    Friend WithEvents DuplicarPrefacturaciónToolStripMenuItem As ToolStripMenuItem
End Class
