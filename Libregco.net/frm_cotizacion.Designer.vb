<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cotizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cotizacion))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtHoraCotizacion = New System.Windows.Forms.TextBox()
        Me.txtIDCotizacion = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtFechaCotizacion = New System.Windows.Forms.MaskedTextBox()
        Me.GbArticulos = New System.Windows.Forms.GroupBox()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GPExistencia = New DevExpress.XtraEditors.GroupControl()
        Me.TreeViewExistencia = New System.Windows.Forms.TreeView()
        Me.cbxPrecio = New System.Windows.Forms.ComboBox()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnBlanquear = New System.Windows.Forms.ToolStripButton()
        Me.btnQuitarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.CbxMedida = New System.Windows.Forms.ComboBox()
        Me.txtTotalArt = New System.Windows.Forms.TextBox()
        Me.btnInsertarArticulo = New System.Windows.Forms.Button()
        Me.txtCantidadArticulo = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtDescripcionArticulo = New System.Windows.Forms.TextBox()
        Me.btnBuscarArticulo = New System.Windows.Forms.Button()
        Me.txtCodigoArticulo = New System.Windows.Forms.TextBox()
        Me.dgvArticulos = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtITBIS = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.TxtDescuento = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtVendedor = New DevExpress.XtraEditors.ButtonEdit()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.GbClientes = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtNivelPrecio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblModificar = New System.Windows.Forms.Label()
        Me.lblAjustarGbClientes = New System.Windows.Forms.Label()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.CMenuProducts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IrAArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.MenuBarra.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.GbArticulos.SuspendLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPExistencia.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtVendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbClientes.SuspendLayout()
        Me.CMenuProducts.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarArtículosToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar artículos"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
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
        Me.LimpiarArtículosToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
        Me.LimpiarArtículosToolStripMenuItem.Text = "Blanquear Listado"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Quitar Artículo"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.TextEdit_x32
        Me.ModificarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar Artículo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(222, 6)
        '
        'BuscarFacturaToolStripMenuItem
        '
        Me.BuscarFacturaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarFacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarFacturaToolStripMenuItem.Name = "BuscarFacturaToolStripMenuItem"
        Me.BuscarFacturaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarFacturaToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
        Me.BuscarFacturaToolStripMenuItem.Text = "Buscar Cotización"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(225, 38)
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
        Me.lblSlogan.Location = New System.Drawing.Point(100, 105)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 180
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.label1)
        Me.GbxUserInfo.Controls.Add(Me.txtHoraCotizacion)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCotizacion)
        Me.GbxUserInfo.Controls.Add(Me.label4)
        Me.GbxUserInfo.Controls.Add(Me.label3)
        Me.GbxUserInfo.Controls.Add(Me.txtFechaCotizacion)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(627, 123)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(349, 76)
        Me.GbxUserInfo.TabIndex = 182
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(173, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(167, 23)
        Me.txtSecondID.TabIndex = 111
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.Location = New System.Drawing.Point(173, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 15)
        Me.label1.TabIndex = 108
        Me.label1.Text = "Hora"
        '
        'txtHoraCotizacion
        '
        Me.txtHoraCotizacion.Enabled = False
        Me.txtHoraCotizacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHoraCotizacion.Location = New System.Drawing.Point(226, 46)
        Me.txtHoraCotizacion.Name = "txtHoraCotizacion"
        Me.txtHoraCotizacion.ReadOnly = True
        Me.txtHoraCotizacion.Size = New System.Drawing.Size(114, 23)
        Me.txtHoraCotizacion.TabIndex = 107
        Me.txtHoraCotizacion.TabStop = False
        Me.txtHoraCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDCotizacion
        '
        Me.txtIDCotizacion.Enabled = False
        Me.txtIDCotizacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCotizacion.Location = New System.Drawing.Point(58, 17)
        Me.txtIDCotizacion.Name = "txtIDCotizacion"
        Me.txtIDCotizacion.ReadOnly = True
        Me.txtIDCotizacion.Size = New System.Drawing.Size(109, 23)
        Me.txtIDCotizacion.TabIndex = 106
        Me.txtIDCotizacion.TabStop = False
        Me.txtIDCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label4.Location = New System.Drawing.Point(6, 47)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(38, 15)
        Me.label4.TabIndex = 105
        Me.label4.Text = "Fecha"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label3.Location = New System.Drawing.Point(6, 20)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(46, 15)
        Me.label3.TabIndex = 104
        Me.label3.Text = "Código"
        '
        'txtFechaCotizacion
        '
        Me.txtFechaCotizacion.Enabled = False
        Me.txtFechaCotizacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaCotizacion.Location = New System.Drawing.Point(58, 46)
        Me.txtFechaCotizacion.Name = "txtFechaCotizacion"
        Me.txtFechaCotizacion.ReadOnly = True
        Me.txtFechaCotizacion.Size = New System.Drawing.Size(109, 23)
        Me.txtFechaCotizacion.TabIndex = 103
        Me.txtFechaCotizacion.TabStop = False
        Me.txtFechaCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaCotizacion.ValidatingType = GetType(Date)
        '
        'GbArticulos
        '
        Me.GbArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbArticulos.Controls.Add(Me.cbxMoneda)
        Me.GbArticulos.Controls.Add(Me.GPExistencia)
        Me.GbArticulos.Controls.Add(Me.cbxPrecio)
        Me.GbArticulos.Controls.Add(Me.BarraOpciones)
        Me.GbArticulos.Controls.Add(Me.CbxMedida)
        Me.GbArticulos.Controls.Add(Me.txtTotalArt)
        Me.GbArticulos.Controls.Add(Me.btnInsertarArticulo)
        Me.GbArticulos.Controls.Add(Me.txtCantidadArticulo)
        Me.GbArticulos.Controls.Add(Me.txtPrecio)
        Me.GbArticulos.Controls.Add(Me.txtDescripcionArticulo)
        Me.GbArticulos.Controls.Add(Me.btnBuscarArticulo)
        Me.GbArticulos.Controls.Add(Me.txtCodigoArticulo)
        Me.GbArticulos.Controls.Add(Me.dgvArticulos)
        Me.GbArticulos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GbArticulos.Location = New System.Drawing.Point(9, 202)
        Me.GbArticulos.Name = "GbArticulos"
        Me.GbArticulos.Size = New System.Drawing.Size(971, 323)
        Me.GbArticulos.TabIndex = 1
        Me.GbArticulos.TabStop = False
        Me.GbArticulos.Text = "Artículos"
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxMoneda.Location = New System.Drawing.Point(698, 298)
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
        Me.cbxMoneda.Size = New System.Drawing.Size(265, 18)
        Me.cbxMoneda.TabIndex = 339
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'GPExistencia
        '
        Me.GPExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GPExistencia.Controls.Add(Me.TreeViewExistencia)
        Me.GPExistencia.Location = New System.Drawing.Point(2, 202)
        Me.GPExistencia.Name = "GPExistencia"
        Me.GPExistencia.Size = New System.Drawing.Size(284, 88)
        Me.GPExistencia.TabIndex = 252
        Me.GPExistencia.Text = "Existencias"
        '
        'TreeViewExistencia
        '
        Me.TreeViewExistencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TreeViewExistencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewExistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewExistencia.Location = New System.Drawing.Point(2, 20)
        Me.TreeViewExistencia.Name = "TreeViewExistencia"
        Me.TreeViewExistencia.Size = New System.Drawing.Size(280, 66)
        Me.TreeViewExistencia.TabIndex = 208
        '
        'cbxPrecio
        '
        Me.cbxPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxPrecio.FormattingEnabled = True
        Me.cbxPrecio.Location = New System.Drawing.Point(601, 17)
        Me.cbxPrecio.Name = "cbxPrecio"
        Me.cbxPrecio.Size = New System.Drawing.Size(61, 23)
        Me.cbxPrecio.TabIndex = 5
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlanquear, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 295)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraOpciones.Size = New System.Drawing.Size(965, 25)
        Me.BarraOpciones.TabIndex = 251
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBlanquear.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(134, 22)
        Me.btnBlanquear.Text = "F1 - Blanquear Listado"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(118, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar Artículo"
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.TextEdit_x32
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(131, 22)
        Me.btnModificar.Text = "F3 - Modificar Artículo"
        '
        'CbxMedida
        '
        Me.CbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxMedida.FormattingEnabled = True
        Me.CbxMedida.Location = New System.Drawing.Point(191, 18)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(61, 23)
        Me.CbxMedida.TabIndex = 3
        '
        'txtTotalArt
        '
        Me.txtTotalArt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalArt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalArt.Location = New System.Drawing.Point(795, 17)
        Me.txtTotalArt.Name = "txtTotalArt"
        Me.txtTotalArt.ReadOnly = True
        Me.txtTotalArt.Size = New System.Drawing.Size(148, 23)
        Me.txtTotalArt.TabIndex = 169
        Me.txtTotalArt.TabStop = False
        Me.txtTotalArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnInsertarArticulo
        '
        Me.btnInsertarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInsertarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnInsertarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertarArticulo.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnInsertarArticulo.Location = New System.Drawing.Point(942, 17)
        Me.btnInsertarArticulo.Name = "btnInsertarArticulo"
        Me.btnInsertarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArticulo.TabIndex = 7
        Me.btnInsertarArticulo.UseVisualStyleBackColor = True
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(139, 18)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(46, 23)
        Me.txtCantidadArticulo.TabIndex = 2
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(668, 17)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(121, 23)
        Me.txtPrecio.TabIndex = 6
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(258, 18)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.ReadOnly = True
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(337, 23)
        Me.txtDescripcionArticulo.TabIndex = 4
        Me.txtDescripcionArticulo.TabStop = False
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(110, 17)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 1
        Me.btnBuscarArticulo.TabStop = False
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(3, 17)
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(108, 23)
        Me.txtCodigoArticulo.TabIndex = 0
        Me.txtCodigoArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvArticulos
        '
        Me.dgvArticulos.AllowUserToAddRows = False
        Me.dgvArticulos.AllowUserToDeleteRows = False
        Me.dgvArticulos.AllowUserToResizeColumns = False
        Me.dgvArticulos.AllowUserToResizeRows = False
        Me.dgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticulos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulos.Location = New System.Drawing.Point(0, 46)
        Me.dgvArticulos.MultiSelect = False
        Me.dgvArticulos.Name = "dgvArticulos"
        Me.dgvArticulos.RowHeadersWidth = 30
        Me.dgvArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulos.Size = New System.Drawing.Size(967, 246)
        Me.dgvArticulos.TabIndex = 162
        Me.dgvArticulos.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(4, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 194
        Me.Label5.Text = "Observ:"
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComentario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtComentario.Location = New System.Drawing.Point(67, 49)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentario.Size = New System.Drawing.Size(536, 33)
        Me.txtComentario.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(795, 613)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(31, 13)
        Me.Label24.TabIndex = 215
        Me.Label24.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlete.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFlete.Location = New System.Drawing.Point(835, 607)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(142, 20)
        Me.txtFlete.TabIndex = 13
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label12.Location = New System.Drawing.Point(792, 586)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(33, 13)
        Me.label12.TabIndex = 212
        Me.label12.Text = "ITBIS"
        '
        'txtITBIS
        '
        Me.txtITBIS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtITBIS.Enabled = False
        Me.txtITBIS.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtITBIS.Location = New System.Drawing.Point(835, 583)
        Me.txtITBIS.Name = "txtITBIS"
        Me.txtITBIS.ReadOnly = True
        Me.txtITBIS.Size = New System.Drawing.Size(142, 20)
        Me.txtITBIS.TabIndex = 211
        Me.txtITBIS.TabStop = False
        Me.txtITBIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label13.Location = New System.Drawing.Point(766, 634)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(57, 13)
        Me.label13.TabIndex = 214
        Me.label13.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNeto.Location = New System.Drawing.Point(835, 631)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(142, 20)
        Me.txtNeto.TabIndex = 213
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label11.Location = New System.Drawing.Point(763, 562)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(58, 13)
        Me.label11.TabIndex = 210
        Me.label11.Text = "Descuento"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescuento.Enabled = False
        Me.TxtDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TxtDescuento.Location = New System.Drawing.Point(835, 559)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.ReadOnly = True
        Me.TxtDescuento.Size = New System.Drawing.Size(142, 20)
        Me.TxtDescuento.TabIndex = 209
        Me.TxtDescuento.TabStop = False
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label10.Location = New System.Drawing.Point(769, 541)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(53, 13)
        Me.label10.TabIndex = 208
        Me.label10.Text = "Sub-Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSubTotal.Location = New System.Drawing.Point(835, 535)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(142, 20)
        Me.txtSubTotal.TabIndex = 207
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(425, 100)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 216
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Vendedor"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtVendedor)
        Me.GroupBox1.Controls.Add(Me.cbxAlmacen)
        Me.GroupBox1.Controls.Add(Me.label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtComentario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 531)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 122)
        Me.GroupBox1.TabIndex = 251
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informaciones"
        '
        'txtVendedor
        '
        Me.txtVendedor.EditValue = ""
        Me.txtVendedor.Location = New System.Drawing.Point(67, 21)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtVendedor.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Properties.Appearance.Options.UseFont = True
        Me.txtVendedor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", 30, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtVendedor.Properties.LookAndFeel.SkinName = "Office 2013 Light Gray"
        Me.txtVendedor.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtVendedor.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtVendedor.Properties.ReadOnly = True
        Me.txtVendedor.Properties.ShowNullValuePromptWhenFocused = True
        Me.txtVendedor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtVendedor.Size = New System.Drawing.Size(536, 22)
        Me.txtVendedor.TabIndex = 10
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(67, 89)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(223, 21)
        Me.cbxAlmacen.TabIndex = 277
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label7.Location = New System.Drawing.Point(4, 92)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(47, 13)
        Me.label7.TabIndex = 278
        Me.label7.Text = "Almacén"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label33.Location = New System.Drawing.Point(8, 48)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(53, 13)
        Me.Label33.TabIndex = 276
        Me.Label33.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownHeight = 100
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.IntegralHeight = False
        Me.cbxCondicion.Location = New System.Drawing.Point(112, 45)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(268, 21)
        Me.cbxCondicion.TabIndex = 2
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(558, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(426, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(426, 99)
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
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 664)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(984, 25)
        Me.BarraEstado.TabIndex = 328
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 329
        Me.PicBoxLogo.TabStop = False
        '
        'GbClientes
        '
        Me.GbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbClientes.Controls.Add(Me.btnBuscarCliente)
        Me.GbClientes.Controls.Add(Me.txtNivelPrecio)
        Me.GbClientes.Controls.Add(Me.Label2)
        Me.GbClientes.Controls.Add(Me.lblModificar)
        Me.GbClientes.Controls.Add(Me.lblAjustarGbClientes)
        Me.GbClientes.Controls.Add(Me.lblTelefonos)
        Me.GbClientes.Controls.Add(Me.Label33)
        Me.GbClientes.Controls.Add(Me.lblDireccion)
        Me.GbClientes.Controls.Add(Me.cbxCondicion)
        Me.GbClientes.Controls.Add(Me.txtTelefonos)
        Me.GbClientes.Controls.Add(Me.txtDireccion)
        Me.GbClientes.Controls.Add(Me.nombre_label)
        Me.GbClientes.Controls.Add(Me.txtIDCliente)
        Me.GbClientes.Controls.Add(Me.txtNombre)
        Me.GbClientes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GbClientes.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GbClientes.Location = New System.Drawing.Point(6, 126)
        Me.GbClientes.Name = "GbClientes"
        Me.GbClientes.Size = New System.Drawing.Size(615, 73)
        Me.GbClientes.TabIndex = 330
        Me.GbClientes.TabStop = False
        Me.GbClientes.Text = "Datos Cliente"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(190, 17)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(20, 20)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtNivelPrecio
        '
        Me.txtNivelPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNivelPrecio.Enabled = False
        Me.txtNivelPrecio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNivelPrecio.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNivelPrecio.Location = New System.Drawing.Point(587, 17)
        Me.txtNivelPrecio.Name = "txtNivelPrecio"
        Me.txtNivelPrecio.ReadOnly = True
        Me.txtNivelPrecio.Size = New System.Drawing.Size(21, 20)
        Me.txtNivelPrecio.TabIndex = 338
        Me.txtNivelPrecio.TabStop = False
        Me.txtNivelPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(73, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 337
        Me.Label2.Text = "[F12]"
        '
        'lblModificar
        '
        Me.lblModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModificar.AutoSize = True
        Me.lblModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblModificar.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblModificar.Location = New System.Drawing.Point(558, -1)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(50, 13)
        Me.lblModificar.TabIndex = 328
        Me.lblModificar.Text = "Modificar"
        '
        'lblAjustarGbClientes
        '
        Me.lblAjustarGbClientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAjustarGbClientes.AutoSize = True
        Me.lblAjustarGbClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAjustarGbClientes.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblAjustarGbClientes.Location = New System.Drawing.Point(520, 131)
        Me.lblAjustarGbClientes.Name = "lblAjustarGbClientes"
        Me.lblAjustarGbClientes.Size = New System.Drawing.Size(83, 13)
        Me.lblAjustarGbClientes.TabIndex = 329
        Me.lblAjustarGbClientes.Text = "Volver a ajustar"
        '
        'lblTelefonos
        '
        Me.lblTelefonos.AutoSize = True
        Me.lblTelefonos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTelefonos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTelefonos.Location = New System.Drawing.Point(8, 108)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(57, 15)
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
        Me.txtTelefonos.Size = New System.Drawing.Size(543, 23)
        Me.txtTelefonos.TabIndex = 184
        Me.txtTelefonos.TabStop = False
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
        Me.txtDireccion.Size = New System.Drawing.Size(543, 23)
        Me.txtDireccion.TabIndex = 183
        Me.txtDireccion.TabStop = False
        Me.txtDireccion.Visible = False
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(7, 20)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(44, 13)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(112, 17)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(79, 20)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(209, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(374, 20)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TabStop = False
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
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Prefacturax48, "Cotización guardada", "La cotización ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.Prefacturax48, "Cotización modificada", "La cotización ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'frm_cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 689)
        Me.Controls.Add(Me.GbClientes)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtFlete)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.txtITBIS)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.GbArticulos)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.MenuBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frm_cotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "191"
        Me.Text = "Cotización"
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.GbArticulos.ResumeLayout(False)
        Me.GbArticulos.PerformLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPExistencia.ResumeLayout(False)
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtVendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbClientes.ResumeLayout(False)
        Me.GbClientes.PerformLayout()
        Me.CMenuProducts.ResumeLayout(False)
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtHoraCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCotizacion As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCotizacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalArt As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents dgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents txtITBIS As System.Windows.Forms.TextBox
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents GbClientes As System.Windows.Forms.GroupBox
    Friend WithEvents lblModificar As System.Windows.Forms.Label
    Friend WithEvents lblAjustarGbClientes As System.Windows.Forms.Label
    Private WithEvents lblTelefonos As System.Windows.Forms.Label
    Private WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNivelPrecio As TextBox
    Friend WithEvents cbxPrecio As ComboBox
    Friend WithEvents cbxAlmacen As ComboBox
    Friend WithEvents label7 As Label
    Friend WithEvents CMenuProducts As ContextMenuStrip
    Friend WithEvents IrAArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents txtVendedor As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents GPExistencia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TreeViewExistencia As TreeView
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
End Class
