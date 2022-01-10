<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_facturacion))
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.label22 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtIDFactura = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.lblModificar = New System.Windows.Forms.LinkLabel()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.lblRNC = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblCalificacionColor = New System.Windows.Forms.Label()
        Me.txtNivelPrecio = New System.Windows.Forms.TextBox()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.txtCreditoDisponible = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.TabPagCondicion = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDiasCondicion = New System.Windows.Forms.TextBox()
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.label25 = New System.Windows.Forms.Label()
        Me.txtFechaAdicional = New System.Windows.Forms.MaskedTextBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtCondicionContado = New System.Windows.Forms.TextBox()
        Me.chkFichaDatos = New System.Windows.Forms.CheckBox()
        Me.chkHabilitarNota = New System.Windows.Forms.CheckBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtAdicional = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtMontoPagos = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtCantidadPagos = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtITBIS = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.TxtDescuentoSuma = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.CbxChofer = New System.Windows.Forms.ComboBox()
        Me.TbSelectProductos = New System.Windows.Forms.GroupBox()
        Me.GPExistencia = New DevExpress.XtraEditors.GroupControl()
        Me.TreeViewExistencia = New System.Windows.Forms.TreeView()
        Me.cbxPrecio = New System.Windows.Forms.ComboBox()
        Me.btnInsertarArticulo = New System.Windows.Forms.Button()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
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
        Me.dgvArticulosFactura = New System.Windows.Forms.DataGridView()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.cbxVehiculo = New System.Windows.Forms.ComboBox()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.HistorialDelClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultacotizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresiónDePagarésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LimpiarArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BuscarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ModificarClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkDesactivar = New System.Windows.Forms.CheckBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TabInfoFactura = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtCobrador = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtVendedor = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkItbis = New System.Windows.Forms.CheckBox()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkPreviewImages = New System.Windows.Forms.CheckBox()
        Me.chkEntregarporConduce = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnVisualizarPagares = New System.Windows.Forms.ToolStripButton()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.CMenuProducts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IrAArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.lblMensajeCalificacion = New System.Windows.Forms.Label()
        Me.GbClientes = New DevExpress.XtraEditors.GroupControl()
        Me.lblTasa = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtUltimoMonto = New System.Windows.Forms.TextBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.label2 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ILbcBalances = New DevExpress.XtraEditors.ImageListBoxControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblUsuario = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.TabPagCondicion.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbSelectProductos.SuspendLayout()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPExistencia.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarra.SuspendLayout()
        Me.TabInfoFactura.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.txtCobrador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuProducts.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GbClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbClientes.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(176, 17)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(243, 21)
        Me.CbxTipoComprobante.TabIndex = 6
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label22.Location = New System.Drawing.Point(4, 83)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(52, 15)
        Me.label22.TabIndex = 165
        Me.label22.Text = "Vehículo"
        Me.label22.Visible = False
        '
        'txtHora
        '
        Me.txtHora.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtHora.Location = New System.Drawing.Point(168, 30)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(95, 21)
        Me.txtHora.TabIndex = 416
        Me.txtHora.Value = New Date(2016, 10, 18, 12, 56, 0, 0)
        '
        'txtSecondID
        '
        Me.txtSecondID.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtSecondID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtSecondID.Location = New System.Drawing.Point(179, 5)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(89, 14)
        Me.txtSecondID.TabIndex = 110
        Me.txtSecondID.TabStop = False
        '
        'txtFecha
        '
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(64, 30)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(98, 21)
        Me.txtFecha.TabIndex = 415
        '
        'txtIDFactura
        '
        Me.txtIDFactura.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtIDFactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDFactura.Enabled = False
        Me.txtIDFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtIDFactura.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDFactura.Location = New System.Drawing.Point(105, 5)
        Me.txtIDFactura.Name = "txtIDFactura"
        Me.txtIDFactura.ReadOnly = True
        Me.txtIDFactura.Size = New System.Drawing.Size(66, 13)
        Me.txtIDFactura.TabIndex = 106
        Me.txtIDFactura.TabStop = False
        Me.txtIDFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.label4.Location = New System.Drawing.Point(8, 33)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(36, 13)
        Me.label4.TabIndex = 105
        Me.label4.Text = "Fecha"
        '
        'lblModificar
        '
        Me.lblModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModificar.AutoSize = True
        Me.lblModificar.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblModificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblModificar.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblModificar.LinkColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblModificar.Location = New System.Drawing.Point(620, 4)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(75, 13)
        Me.lblModificar.TabIndex = 328
        Me.lblModificar.TabStop = True
        Me.lblModificar.Text = "Ctrl+Modificar"
        '
        'txtRNC
        '
        Me.txtRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRNC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(541, 146)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.Size = New System.Drawing.Size(149, 20)
        Me.txtRNC.TabIndex = 331
        Me.txtRNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRNC
        '
        Me.lblRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRNC.AutoSize = True
        Me.lblRNC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblRNC.Location = New System.Drawing.Point(514, 149)
        Me.lblRNC.Name = "lblRNC"
        Me.lblRNC.Size = New System.Drawing.Size(28, 13)
        Me.lblRNC.TabIndex = 330
        Me.lblRNC.Text = "RNC"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label34.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label34.Location = New System.Drawing.Point(609, 169)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(83, 13)
        Me.Label34.TabIndex = 329
        Me.Label34.Text = "Volver a ajustar"
        '
        'lblCalificacionColor
        '
        Me.lblCalificacionColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCalificacionColor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblCalificacionColor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCalificacionColor.Location = New System.Drawing.Point(602, 37)
        Me.lblCalificacionColor.Name = "lblCalificacionColor"
        Me.lblCalificacionColor.Size = New System.Drawing.Size(36, 3)
        Me.lblCalificacionColor.TabIndex = 184
        '
        'txtNivelPrecio
        '
        Me.txtNivelPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNivelPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtNivelPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNivelPrecio.Enabled = False
        Me.txtNivelPrecio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNivelPrecio.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNivelPrecio.Location = New System.Drawing.Point(671, 45)
        Me.txtNivelPrecio.Name = "txtNivelPrecio"
        Me.txtNivelPrecio.ReadOnly = True
        Me.txtNivelPrecio.Size = New System.Drawing.Size(21, 13)
        Me.txtNivelPrecio.TabIndex = 183
        Me.txtNivelPrecio.TabStop = False
        Me.txtNivelPrecio.Text = "A"
        Me.txtNivelPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.txtBalanceGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalanceGeneral.Enabled = False
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(524, 4)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(10, 16)
        Me.txtBalanceGeneral.TabIndex = 124
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtBalanceGeneral.Visible = False
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUltimoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUltimoPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(539, 73)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(61, 13)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCreditoDisponible
        '
        Me.txtCreditoDisponible.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreditoDisponible.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCreditoDisponible.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreditoDisponible.Enabled = False
        Me.txtCreditoDisponible.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCreditoDisponible.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCreditoDisponible.Location = New System.Drawing.Point(367, 28)
        Me.txtCreditoDisponible.Name = "txtCreditoDisponible"
        Me.txtCreditoDisponible.ReadOnly = True
        Me.txtCreditoDisponible.Size = New System.Drawing.Size(91, 13)
        Me.txtCreditoDisponible.TabIndex = 180
        Me.txtCreditoDisponible.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(269, 27)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(92, 13)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = "Crédito disponible"
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCalificacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(602, 24)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(90, 13)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.Text = "A+"
        '
        'lblTelefonos
        '
        Me.lblTelefonos.AutoSize = True
        Me.lblTelefonos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTelefonos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTelefonos.Location = New System.Drawing.Point(64, 149)
        Me.lblTelefonos.Name = "lblTelefonos"
        Me.lblTelefonos.Size = New System.Drawing.Size(54, 13)
        Me.lblTelefonos.TabIndex = 186
        Me.lblTelefonos.Text = "Teléfonos"
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDireccion.Location = New System.Drawing.Point(64, 123)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(50, 13)
        Me.lblDireccion.TabIndex = 185
        Me.lblDireccion.Text = "Dirección"
        '
        'txtTelefonos
        '
        Me.txtTelefonos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefonos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTelefonos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTelefonos.Location = New System.Drawing.Point(121, 146)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.Size = New System.Drawing.Size(388, 20)
        Me.txtTelefonos.TabIndex = 3
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtDireccion.Location = New System.Drawing.Point(121, 120)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(569, 20)
        Me.txtDireccion.TabIndex = 2
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(37, 61)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(525, -1)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(1, 23)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIDCliente.Visible = False
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(121, 91)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(569, 23)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TabStop = False
        '
        'TabPagCondicion
        '
        Me.TabPagCondicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabPagCondicion.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabPagCondicion.Controls.Add(Me.tabPage1)
        Me.TabPagCondicion.Controls.Add(Me.tabPage2)
        Me.TabPagCondicion.Enabled = False
        Me.TabPagCondicion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabPagCondicion.Location = New System.Drawing.Point(8, 549)
        Me.TabPagCondicion.Name = "TabPagCondicion"
        Me.TabPagCondicion.SelectedIndex = 0
        Me.TabPagCondicion.Size = New System.Drawing.Size(758, 124)
        Me.TabPagCondicion.TabIndex = 14
        '
        'tabPage1
        '
        Me.tabPage1.AccessibleName = "credito_controls"
        Me.tabPage1.Controls.Add(Me.Label5)
        Me.tabPage1.Controls.Add(Me.txtDiasCondicion)
        Me.tabPage1.Controls.Add(Me.txtFechaVencimiento)
        Me.tabPage1.Controls.Add(Me.label25)
        Me.tabPage1.Controls.Add(Me.txtFechaAdicional)
        Me.tabPage1.Controls.Add(Me.label18)
        Me.tabPage1.Controls.Add(Me.txtCondicionContado)
        Me.tabPage1.Controls.Add(Me.chkFichaDatos)
        Me.tabPage1.Controls.Add(Me.chkHabilitarNota)
        Me.tabPage1.Controls.Add(Me.label17)
        Me.tabPage1.Controls.Add(Me.txtBalance)
        Me.tabPage1.Controls.Add(Me.label16)
        Me.tabPage1.Controls.Add(Me.label15)
        Me.tabPage1.Controls.Add(Me.txtAdicional)
        Me.tabPage1.Controls.Add(Me.label14)
        Me.tabPage1.Controls.Add(Me.txtMontoPagos)
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.txtCantidadPagos)
        Me.tabPage1.Controls.Add(Me.label8)
        Me.tabPage1.Controls.Add(Me.txtInicial)
        Me.tabPage1.Location = New System.Drawing.Point(4, 25)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(750, 95)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Condiciones"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(3, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Cond."
        '
        'txtDiasCondicion
        '
        Me.txtDiasCondicion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDiasCondicion.Location = New System.Drawing.Point(6, 19)
        Me.txtDiasCondicion.Name = "txtDiasCondicion"
        Me.txtDiasCondicion.Size = New System.Drawing.Size(40, 20)
        Me.txtDiasCondicion.TabIndex = 104
        Me.txtDiasCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.Enabled = False
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(616, 63)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(128, 20)
        Me.txtFechaVencimiento.TabIndex = 103
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label25.Location = New System.Drawing.Point(613, 45)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(111, 13)
        Me.label25.TabIndex = 101
        Me.label25.Text = "Fecha de Vencimiento"
        '
        'txtFechaAdicional
        '
        Me.txtFechaAdicional.Enabled = False
        Me.txtFechaAdicional.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFechaAdicional.Location = New System.Drawing.Point(655, 19)
        Me.txtFechaAdicional.Name = "txtFechaAdicional"
        Me.txtFechaAdicional.Size = New System.Drawing.Size(89, 20)
        Me.txtFechaAdicional.TabIndex = 19
        Me.txtFechaAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label18.Location = New System.Drawing.Point(126, 45)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(112, 13)
        Me.label18.TabIndex = 100
        Me.label18.Text = "Condición de Contado"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCondicionContado
        '
        Me.txtCondicionContado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCondicionContado.Location = New System.Drawing.Point(129, 63)
        Me.txtCondicionContado.Name = "txtCondicionContado"
        Me.txtCondicionContado.Size = New System.Drawing.Size(481, 20)
        Me.txtCondicionContado.TabIndex = 22
        '
        'chkFichaDatos
        '
        Me.chkFichaDatos.AutoSize = True
        Me.chkFichaDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFichaDatos.Location = New System.Drawing.Point(6, 67)
        Me.chkFichaDatos.Name = "chkFichaDatos"
        Me.chkFichaDatos.Size = New System.Drawing.Size(93, 17)
        Me.chkFichaDatos.TabIndex = 21
        Me.chkFichaDatos.Text = "Habilitar Ficha"
        Me.chkFichaDatos.UseVisualStyleBackColor = True
        '
        'chkHabilitarNota
        '
        Me.chkHabilitarNota.AutoSize = True
        Me.chkHabilitarNota.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkHabilitarNota.Location = New System.Drawing.Point(6, 45)
        Me.chkHabilitarNota.Name = "chkHabilitarNota"
        Me.chkHabilitarNota.Size = New System.Drawing.Size(108, 17)
        Me.chkHabilitarNota.TabIndex = 20
        Me.chkHabilitarNota.Text = "Nota de Contado"
        Me.chkHabilitarNota.UseVisualStyleBackColor = True
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label17.Location = New System.Drawing.Point(180, 1)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(71, 13)
        Me.label17.TabIndex = 97
        Me.label17.Text = "Total a Pagar"
        '
        'txtBalance
        '
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtBalance.Location = New System.Drawing.Point(183, 19)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(125, 20)
        Me.txtBalance.TabIndex = 96
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label16.Location = New System.Drawing.Point(652, 1)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(81, 13)
        Me.label16.TabIndex = 95
        Me.label16.Text = "Fecha Adicional"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label15.Location = New System.Drawing.Point(521, 1)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(76, 13)
        Me.label15.TabIndex = 93
        Me.label15.Text = "Pago Adicional"
        '
        'txtAdicional
        '
        Me.txtAdicional.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtAdicional.Location = New System.Drawing.Point(524, 19)
        Me.txtAdicional.Name = "txtAdicional"
        Me.txtAdicional.ReadOnly = True
        Me.txtAdicional.Size = New System.Drawing.Size(125, 20)
        Me.txtAdicional.TabIndex = 18
        Me.txtAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label14.Location = New System.Drawing.Point(390, 1)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(105, 13)
        Me.label14.TabIndex = 91
        Me.label14.Text = "Montos de los Pagos"
        '
        'txtMontoPagos
        '
        Me.txtMontoPagos.Enabled = False
        Me.txtMontoPagos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMontoPagos.Location = New System.Drawing.Point(393, 19)
        Me.txtMontoPagos.Name = "txtMontoPagos"
        Me.txtMontoPagos.ReadOnly = True
        Me.txtMontoPagos.Size = New System.Drawing.Size(125, 20)
        Me.txtMontoPagos.TabIndex = 90
        Me.txtMontoPagos.TabStop = False
        Me.txtMontoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label9.Location = New System.Drawing.Point(311, 1)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(66, 13)
        Me.label9.TabIndex = 89
        Me.label9.Text = "Cant. Pagos"
        '
        'txtCantidadPagos
        '
        Me.txtCantidadPagos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantidadPagos.Location = New System.Drawing.Point(314, 19)
        Me.txtCantidadPagos.Name = "txtCantidadPagos"
        Me.txtCantidadPagos.Size = New System.Drawing.Size(73, 20)
        Me.txtCantidadPagos.TabIndex = 17
        Me.txtCantidadPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label8.Location = New System.Drawing.Point(53, 1)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(34, 13)
        Me.label8.TabIndex = 87
        Me.label8.Text = "Inicial"
        '
        'txtInicial
        '
        Me.txtInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtInicial.Location = New System.Drawing.Point(52, 19)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(125, 20)
        Me.txtInicial.TabIndex = 12
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.DgvPagares)
        Me.tabPage2.Location = New System.Drawing.Point(4, 25)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(750, 95)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Pagares"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvPagares.Location = New System.Drawing.Point(5, 7)
        Me.DgvPagares.MultiSelect = False
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.RowHeadersWidth = 10
        Me.DgvPagares.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPagares.Size = New System.Drawing.Size(739, 79)
        Me.DgvPagares.TabIndex = 0
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label13.Location = New System.Drawing.Point(767, 653)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(62, 15)
        Me.label13.TabIndex = 153
        Me.label13.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNeto.Location = New System.Drawing.Point(836, 650)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(142, 23)
        Me.txtNeto.TabIndex = 152
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label12.Location = New System.Drawing.Point(797, 603)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(32, 15)
        Me.label12.TabIndex = 151
        Me.label12.Text = "ITBIS"
        '
        'txtITBIS
        '
        Me.txtITBIS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtITBIS.Enabled = False
        Me.txtITBIS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtITBIS.Location = New System.Drawing.Point(836, 600)
        Me.txtITBIS.Name = "txtITBIS"
        Me.txtITBIS.ReadOnly = True
        Me.txtITBIS.Size = New System.Drawing.Size(142, 23)
        Me.txtITBIS.TabIndex = 150
        Me.txtITBIS.TabStop = False
        Me.txtITBIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(768, 578)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(63, 15)
        Me.label11.TabIndex = 149
        Me.label11.Text = "Descuento"
        '
        'TxtDescuentoSuma
        '
        Me.TxtDescuentoSuma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescuentoSuma.Enabled = False
        Me.TxtDescuentoSuma.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtDescuentoSuma.Location = New System.Drawing.Point(836, 575)
        Me.TxtDescuentoSuma.Name = "TxtDescuentoSuma"
        Me.TxtDescuentoSuma.ReadOnly = True
        Me.TxtDescuentoSuma.Size = New System.Drawing.Size(142, 23)
        Me.TxtDescuentoSuma.TabIndex = 148
        Me.TxtDescuentoSuma.TabStop = False
        Me.TxtDescuentoSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(772, 553)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(57, 15)
        Me.label10.TabIndex = 147
        Me.label10.Text = "Sub-Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.Location = New System.Drawing.Point(836, 550)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(142, 23)
        Me.txtSubTotal.TabIndex = 146
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(4, 23)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(54, 15)
        Me.label7.TabIndex = 145
        Me.label7.Text = "Almacén"
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(63, 22)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(169, 23)
        Me.cbxAlmacen.TabIndex = 4
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label6.Location = New System.Drawing.Point(4, 54)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(43, 15)
        Me.label6.TabIndex = 142
        Me.label6.Text = "Chofer"
        '
        'CbxChofer
        '
        Me.CbxChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxChofer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxChofer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxChofer.FormattingEnabled = True
        Me.CbxChofer.Location = New System.Drawing.Point(63, 51)
        Me.CbxChofer.Name = "CbxChofer"
        Me.CbxChofer.Size = New System.Drawing.Size(169, 23)
        Me.CbxChofer.TabIndex = 5
        '
        'TbSelectProductos
        '
        Me.TbSelectProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbSelectProductos.Controls.Add(Me.GPExistencia)
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
        Me.TbSelectProductos.Controls.Add(Me.dgvArticulosFactura)
        Me.TbSelectProductos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TbSelectProductos.Location = New System.Drawing.Point(0, 36)
        Me.TbSelectProductos.Name = "TbSelectProductos"
        Me.TbSelectProductos.Size = New System.Drawing.Size(966, 265)
        Me.TbSelectProductos.TabIndex = 8
        Me.TbSelectProductos.TabStop = False
        '
        'GPExistencia
        '
        Me.GPExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GPExistencia.Controls.Add(Me.TreeViewExistencia)
        Me.GPExistencia.Location = New System.Drawing.Point(6, 144)
        Me.GPExistencia.Name = "GPExistencia"
        Me.GPExistencia.Size = New System.Drawing.Size(303, 88)
        Me.GPExistencia.TabIndex = 253
        Me.GPExistencia.Text = "Existencias"
        '
        'TreeViewExistencia
        '
        Me.TreeViewExistencia.BackColor = System.Drawing.SystemColors.Info
        Me.TreeViewExistencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewExistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewExistencia.Location = New System.Drawing.Point(2, 20)
        Me.TreeViewExistencia.Name = "TreeViewExistencia"
        Me.TreeViewExistencia.Size = New System.Drawing.Size(299, 66)
        Me.TreeViewExistencia.TabIndex = 208
        '
        'cbxPrecio
        '
        Me.cbxPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxPrecio.FormattingEnabled = True
        Me.cbxPrecio.Location = New System.Drawing.Point(595, 11)
        Me.cbxPrecio.Name = "cbxPrecio"
        Me.cbxPrecio.Size = New System.Drawing.Size(61, 23)
        Me.cbxPrecio.TabIndex = 13
        '
        'btnInsertarArticulo
        '
        Me.btnInsertarArticulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInsertarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnInsertarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsertarArticulo.Image = Global.Libregco.My.Resources.Resources.Tag_x32
        Me.btnInsertarArticulo.Location = New System.Drawing.Point(938, 11)
        Me.btnInsertarArticulo.Name = "btnInsertarArticulo"
        Me.btnInsertarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnInsertarArticulo.TabIndex = 15
        Me.btnInsertarArticulo.UseVisualStyleBackColor = True
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlanquear, Me.btnQuitarArticulo, Me.btnModificar})
        Me.BarraOpciones.Location = New System.Drawing.Point(3, 237)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraOpciones.Size = New System.Drawing.Size(960, 25)
        Me.BarraOpciones.TabIndex = 252
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnBlanquear
        '
        Me.btnBlanquear.Image = Global.Libregco.My.Resources.Resources.Clean_x32
        Me.btnBlanquear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlanquear.Name = "btnBlanquear"
        Me.btnBlanquear.Size = New System.Drawing.Size(134, 22)
        Me.btnBlanquear.Text = "F1 - Blanquear Listado"
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(118, 22)
        Me.btnQuitarArticulo.Text = "F2 - Quitar Artículo"
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.TextEdit_x24
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
        Me.CbxMedida.Location = New System.Drawing.Point(139, 11)
        Me.CbxMedida.Name = "CbxMedida"
        Me.CbxMedida.Size = New System.Drawing.Size(61, 23)
        Me.CbxMedida.TabIndex = 10
        '
        'txtTotalArt
        '
        Me.txtTotalArt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalArt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalArt.Location = New System.Drawing.Point(788, 11)
        Me.txtTotalArt.Name = "txtTotalArt"
        Me.txtTotalArt.ReadOnly = True
        Me.txtTotalArt.Size = New System.Drawing.Size(151, 23)
        Me.txtTotalArt.TabIndex = 169
        Me.txtTotalArt.TabStop = False
        Me.txtTotalArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantidadArticulo
        '
        Me.txtCantidadArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadArticulo.Location = New System.Drawing.Point(206, 11)
        Me.txtCantidadArticulo.Name = "txtCantidadArticulo"
        Me.txtCantidadArticulo.Size = New System.Drawing.Size(46, 23)
        Me.txtCantidadArticulo.TabIndex = 11
        Me.txtCantidadArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrecio
        '
        Me.txtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrecio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPrecio.Location = New System.Drawing.Point(663, 11)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(120, 23)
        Me.txtPrecio.TabIndex = 14
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionArticulo
        '
        Me.txtDescripcionArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionArticulo.Enabled = False
        Me.txtDescripcionArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionArticulo.Location = New System.Drawing.Point(256, 11)
        Me.txtDescripcionArticulo.Name = "txtDescripcionArticulo"
        Me.txtDescripcionArticulo.ReadOnly = True
        Me.txtDescripcionArticulo.Size = New System.Drawing.Size(333, 23)
        Me.txtDescripcionArticulo.TabIndex = 12
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArticulo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArticulo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(108, 11)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArticulo.TabIndex = 9
        Me.btnBuscarArticulo.TabStop = False
        Me.btnBuscarArticulo.UseVisualStyleBackColor = True
        '
        'txtCodigoArticulo
        '
        Me.txtCodigoArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodigoArticulo.Location = New System.Drawing.Point(4, 11)
        Me.txtCodigoArticulo.Name = "txtCodigoArticulo"
        Me.txtCodigoArticulo.Size = New System.Drawing.Size(105, 23)
        Me.txtCodigoArticulo.TabIndex = 8
        Me.txtCodigoArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvArticulosFactura
        '
        Me.dgvArticulosFactura.AllowUserToAddRows = False
        Me.dgvArticulosFactura.AllowUserToDeleteRows = False
        Me.dgvArticulosFactura.AllowUserToResizeColumns = False
        Me.dgvArticulosFactura.AllowUserToResizeRows = False
        Me.dgvArticulosFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticulosFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvArticulosFactura.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvArticulosFactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvArticulosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulosFactura.Location = New System.Drawing.Point(4, 40)
        Me.dgvArticulosFactura.Name = "dgvArticulosFactura"
        Me.dgvArticulosFactura.ReadOnly = True
        Me.dgvArticulosFactura.RowHeadersWidth = 30
        Me.dgvArticulosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulosFactura.Size = New System.Drawing.Size(958, 194)
        Me.dgvArticulosFactura.TabIndex = 162
        Me.dgvArticulosFactura.TabStop = False
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Location = New System.Drawing.Point(66, 40)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.cbxMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.cbxMoneda.Properties.Appearance.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(456, 18)
        Me.cbxMoneda.TabIndex = 340
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(799, 628)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 15)
        Me.Label24.TabIndex = 170
        Me.Label24.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFlete.Location = New System.Drawing.Point(836, 625)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(142, 23)
        Me.txtFlete.TabIndex = 23
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxVehiculo
        '
        Me.cbxVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVehiculo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxVehiculo.FormattingEnabled = True
        Me.cbxVehiculo.Location = New System.Drawing.Point(63, 80)
        Me.cbxVehiculo.Name = "cbxVehiculo"
        Me.cbxVehiculo.Size = New System.Drawing.Size(169, 23)
        Me.cbxVehiculo.TabIndex = 6
        Me.cbxVehiculo.Visible = False
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(984, 24)
        Me.MenuBarra.TabIndex = 177
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.BuscarArtículosToolStripMenuItem, Me.ToolStripSeparator3, Me.HistorialDelClienteToolStripMenuItem, Me.ConsultacotizacionToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.ImpresiónDePagarésToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.BuscarToolStripMenuItem.Text = "Buscar Cliente"
        '
        'BuscarArtículosToolStripMenuItem
        '
        Me.BuscarArtículosToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarArtículosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarArtículosToolStripMenuItem.Name = "BuscarArtículosToolStripMenuItem"
        Me.BuscarArtículosToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.BuscarArtículosToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.BuscarArtículosToolStripMenuItem.Text = "Buscar Artículos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(249, 6)
        '
        'HistorialDelClienteToolStripMenuItem
        '
        Me.HistorialDelClienteToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.HistorialDelClienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.HistorialDelClienteToolStripMenuItem.Name = "HistorialDelClienteToolStripMenuItem"
        Me.HistorialDelClienteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HistorialDelClienteToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.HistorialDelClienteToolStripMenuItem.Text = "Historial del Cliente"
        '
        'ConsultacotizacionToolStripMenuItem
        '
        Me.ConsultacotizacionToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ConsultacotizacionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConsultacotizacionToolStripMenuItem.Name = "ConsultacotizacionToolStripMenuItem"
        Me.ConsultacotizacionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ConsultacotizacionToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ConsultacotizacionToolStripMenuItem.Text = "Consulta de cotización"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(249, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ImpresiónDePagarésToolStripMenuItem
        '
        Me.ImpresiónDePagarésToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImpresiónDePagarésToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImpresiónDePagarésToolStripMenuItem.Name = "ImpresiónDePagarésToolStripMenuItem"
        Me.ImpresiónDePagarésToolStripMenuItem.Size = New System.Drawing.Size(252, 38)
        Me.ImpresiónDePagarésToolStripMenuItem.Text = "Impresión de pagarés"
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
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LimpiarArtículosToolStripMenuItem, Me.QuitarArtículoToolStripMenuItem, Me.ModificarArtículoToolStripMenuItem, Me.ToolStripSeparator2, Me.BuscarFacturaToolStripMenuItem, Me.AnularToolStripMenuItem, Me.ToolStripSeparator4, Me.ModificarClienteToolStripMenuItem})
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
        Me.LimpiarArtículosToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.LimpiarArtículosToolStripMenuItem.Text = "Blanquear Listado"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Quitar Artículo"
        '
        'ModificarArtículoToolStripMenuItem
        '
        Me.ModificarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.ModificarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarArtículoToolStripMenuItem.Name = "ModificarArtículoToolStripMenuItem"
        Me.ModificarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.ModificarArtículoToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.ModificarArtículoToolStripMenuItem.Text = "Modificar Artículo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(223, 6)
        '
        'BuscarFacturaToolStripMenuItem
        '
        Me.BuscarFacturaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarFacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarFacturaToolStripMenuItem.Name = "BuscarFacturaToolStripMenuItem"
        Me.BuscarFacturaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarFacturaToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.BuscarFacturaToolStripMenuItem.Text = "Buscar Factura"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(223, 6)
        '
        'ModificarClienteToolStripMenuItem
        '
        Me.ModificarClienteToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.ModificarClienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarClienteToolStripMenuItem.Name = "ModificarClienteToolStripMenuItem"
        Me.ModificarClienteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ModificarClienteToolStripMenuItem.Size = New System.Drawing.Size(226, 38)
        Me.ModificarClienteToolStripMenuItem.Text = "Modificar Cliente"
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
        'chkDesactivar
        '
        Me.chkDesactivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDesactivar.AutoSize = True
        Me.chkDesactivar.Enabled = False
        Me.chkDesactivar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDesactivar.Location = New System.Drawing.Point(12, 67)
        Me.chkDesactivar.Name = "chkDesactivar"
        Me.chkDesactivar.Size = New System.Drawing.Size(101, 19)
        Me.chkDesactivar.TabIndex = 101
        Me.chkDesactivar.Text = "Anular factura"
        Me.chkDesactivar.UseVisualStyleBackColor = True
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label27.Location = New System.Drawing.Point(693, 1)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 13)
        Me.Label27.TabIndex = 181
        Me.Label27.Text = "Cobrador"
        '
        'TabInfoFactura
        '
        Me.TabInfoFactura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabInfoFactura.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabInfoFactura.Controls.Add(Me.TabPage3)
        Me.TabInfoFactura.Controls.Add(Me.TabPage4)
        Me.TabInfoFactura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabInfoFactura.Location = New System.Drawing.Point(7, 214)
        Me.TabInfoFactura.Name = "TabInfoFactura"
        Me.TabInfoFactura.SelectedIndex = 0
        Me.TabInfoFactura.Size = New System.Drawing.Size(977, 333)
        Me.TabInfoFactura.TabIndex = 4
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.txtCobrador)
        Me.TabPage3.Controls.Add(Me.txtVendedor)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.cbxCondicion)
        Me.TabPage3.Controls.Add(Me.CbxTipoComprobante)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.TbSelectProductos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(969, 304)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Información"
        '
        'txtCobrador
        '
        Me.txtCobrador.EditValue = ""
        Me.txtCobrador.Location = New System.Drawing.Point(696, 18)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCobrador.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCobrador.Properties.Appearance.Options.UseFont = True
        Me.txtCobrador.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", 30, True, True, True, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtCobrador.Properties.LookAndFeel.SkinName = "Office 2013 Light Gray"
        Me.txtCobrador.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtCobrador.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtCobrador.Properties.ReadOnly = True
        Me.txtCobrador.Properties.ShowNullValuePromptWhenFocused = True
        Me.txtCobrador.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCobrador.Size = New System.Drawing.Size(265, 20)
        Me.txtCobrador.TabIndex = 283
        '
        'txtVendedor
        '
        Me.txtVendedor.EditValue = ""
        Me.txtVendedor.Location = New System.Drawing.Point(425, 18)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtVendedor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtVendedor.Properties.Appearance.Options.UseFont = True
        Me.txtVendedor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", 30, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.txtVendedor.Properties.LookAndFeel.SkinName = "Office 2013 Light Gray"
        Me.txtVendedor.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.txtVendedor.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtVendedor.Properties.ReadOnly = True
        Me.txtVendedor.Properties.ShowNullValuePromptWhenFocused = True
        Me.txtVendedor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtVendedor.Size = New System.Drawing.Size(265, 20)
        Me.txtVendedor.TabIndex = 282
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(422, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 13)
        Me.Label23.TabIndex = 281
        Me.Label23.Text = "Vendedor"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label33.Location = New System.Drawing.Point(4, 1)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(53, 13)
        Me.Label33.TabIndex = 274
        Me.Label33.Text = "Condición"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label26.Location = New System.Drawing.Point(173, 1)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 13)
        Me.Label26.TabIndex = 273
        Me.Label26.Text = "Tipo de NCF"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(4, 16)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(166, 21)
        Me.cbxCondicion.TabIndex = 5
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.txtOrden)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.txtObservacion)
        Me.TabPage4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabPage4.ForeColor = System.Drawing.Color.Black
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(969, 304)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Detalles"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(703, 26)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(184, 23)
        Me.txtOrden.TabIndex = 170
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label30.Location = New System.Drawing.Point(700, 8)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(66, 15)
        Me.Label30.TabIndex = 169
        Me.Label30.Text = "# de Orden"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkItbis)
        Me.GroupBox3.Controls.Add(Me.txtNIF)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Location = New System.Drawing.Point(231, 137)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 170)
        Me.GroupBox3.TabIndex = 168
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = ""
        Me.GroupBox3.Text = "Fiscal"
        '
        'chkItbis
        '
        Me.chkItbis.AutoCheck = False
        Me.chkItbis.AutoSize = True
        Me.chkItbis.Location = New System.Drawing.Point(12, 22)
        Me.chkItbis.Name = "chkItbis"
        Me.chkItbis.Size = New System.Drawing.Size(67, 19)
        Me.chkItbis.TabIndex = 108
        Me.chkItbis.Text = "No itbis"
        Me.chkItbis.UseVisualStyleBackColor = True
        '
        'txtNIF
        '
        Me.txtNIF.Enabled = False
        Me.txtNIF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNIF.Location = New System.Drawing.Point(6, 69)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.ReadOnly = True
        Me.txtNIF.Size = New System.Drawing.Size(204, 23)
        Me.txtNIF.TabIndex = 106
        Me.txtNIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(5, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(153, 15)
        Me.Label19.TabIndex = 107
        Me.Label19.Text = "Número de impresión fiscal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkPreviewImages)
        Me.GroupBox2.Controls.Add(Me.chkEntregarporConduce)
        Me.GroupBox2.Controls.Add(Me.chkDesactivar)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(216, 170)
        Me.GroupBox2.TabIndex = 167
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'chkPreviewImages
        '
        Me.chkPreviewImages.AutoSize = True
        Me.chkPreviewImages.Location = New System.Drawing.Point(12, 43)
        Me.chkPreviewImages.Name = "chkPreviewImages"
        Me.chkPreviewImages.Size = New System.Drawing.Size(96, 19)
        Me.chkPreviewImages.TabIndex = 166
        Me.chkPreviewImages.Text = "Ver imágenes"
        Me.chkPreviewImages.UseVisualStyleBackColor = True
        '
        'chkEntregarporConduce
        '
        Me.chkEntregarporConduce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEntregarporConduce.AutoSize = True
        Me.chkEntregarporConduce.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEntregarporConduce.Location = New System.Drawing.Point(12, 19)
        Me.chkEntregarporConduce.Name = "chkEntregarporConduce"
        Me.chkEntregarporConduce.Size = New System.Drawing.Size(161, 19)
        Me.chkEntregarporConduce.TabIndex = 102
        Me.chkEntregarporConduce.Text = "Entrega sólo por conduce"
        Me.chkEntregarporConduce.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxAlmacen)
        Me.GroupBox1.Controls.Add(Me.label22)
        Me.GroupBox1.Controls.Add(Me.label6)
        Me.GroupBox1.Controls.Add(Me.CbxChofer)
        Me.GroupBox1.Controls.Add(Me.label7)
        Me.GroupBox1.Controls.Add(Me.cbxVehiculo)
        Me.GroupBox1.Location = New System.Drawing.Point(453, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 170)
        Me.GroupBox1.TabIndex = 166
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.Location = New System.Drawing.Point(6, 8)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 15)
        Me.Label29.TabIndex = 105
        Me.Label29.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(9, 26)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(682, 105)
        Me.txtObservacion.TabIndex = 104
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.btnVisualizarPagares, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 678)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(984, 25)
        Me.BarraEstado.TabIndex = 269
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
        'btnVisualizarPagares
        '
        Me.btnVisualizarPagares.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnVisualizarPagares.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVisualizarPagares.Name = "btnVisualizarPagares"
        Me.btnVisualizarPagares.Size = New System.Drawing.Size(120, 22)
        Me.btnVisualizarPagares.Text = "Visualizar Pagarés"
        Me.btnVisualizarPagares.Visible = False
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
        Me.IconPanel.Location = New System.Drawing.Point(548, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 96)
        Me.IconPanel.TabIndex = 326
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 96)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 92)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 92)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 92)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 92)
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
        Me.btnImprimir.Size = New System.Drawing.Size(84, 92)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 28)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 327
        Me.PicBoxLogo.TabStop = False
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
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Facturacionx48, "Factura guardada", "La factura ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.Facturacionx48, "Factura modificada", "La factura ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'lblMensajeCalificacion
        '
        Me.lblMensajeCalificacion.AutoSize = True
        Me.lblMensajeCalificacion.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCalificacion.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeCalificacion.Location = New System.Drawing.Point(412, 215)
        Me.lblMensajeCalificacion.Name = "lblMensajeCalificacion"
        Me.lblMensajeCalificacion.Size = New System.Drawing.Size(250, 15)
        Me.lblMensajeCalificacion.TabIndex = 328
        Me.lblMensajeCalificacion.Text = "El cliente posee una calificación de alto riesgo.!"
        Me.lblMensajeCalificacion.Visible = False
        '
        'GbClientes
        '
        Me.GbClientes.AllowHtmlText = True
        Me.GbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbClientes.CaptionImageOptions.Image = CType(resources.GetObject("GbClientes.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GbClientes.Controls.Add(Me.lblTasa)
        Me.GbClientes.Controls.Add(Me.Label3)
        Me.GbClientes.Controls.Add(Me.Label1)
        Me.GbClientes.Controls.Add(Me.Label34)
        Me.GbClientes.Controls.Add(Me.txtRNC)
        Me.GbClientes.Controls.Add(Me.lblModificar)
        Me.GbClientes.Controls.Add(Me.lblRNC)
        Me.GbClientes.Controls.Add(Me.Label31)
        Me.GbClientes.Controls.Add(Me.txtNivelPrecio)
        Me.GbClientes.Controls.Add(Me.Label28)
        Me.GbClientes.Controls.Add(Me.txtTelefonos)
        Me.GbClientes.Controls.Add(Me.lblTelefonos)
        Me.GbClientes.Controls.Add(Me.txtCreditoDisponible)
        Me.GbClientes.Controls.Add(Me.lblDireccion)
        Me.GbClientes.Controls.Add(Me.txtDireccion)
        Me.GbClientes.Controls.Add(Me.txtUltimoMonto)
        Me.GbClientes.Controls.Add(Me.txtBalanceGeneral)
        Me.GbClientes.Controls.Add(Me.lblCalificacionColor)
        Me.GbClientes.Controls.Add(Me.txtCalificacion)
        Me.GbClientes.Controls.Add(Me.LabelControl7)
        Me.GbClientes.Controls.Add(Me.LabelControl6)
        Me.GbClientes.Controls.Add(Me.txtUltimoPago)
        Me.GbClientes.Controls.Add(Me.LabelControl5)
        Me.GbClientes.Controls.Add(Me.label2)
        Me.GbClientes.Controls.Add(Me.SeparatorControl1)
        Me.GbClientes.Controls.Add(Me.txtNombre)
        Me.GbClientes.Controls.Add(Me.txtIDCliente)
        Me.GbClientes.Controls.Add(Me.LabelControl3)
        Me.GbClientes.Controls.Add(Me.btnBuscarCliente)
        Me.GbClientes.Controls.Add(Me.ILbcBalances)
        Me.GbClientes.Controls.Add(Me.cbxMoneda)
        Me.GbClientes.Controls.Add(Me.LabelControl11)
        Me.GbClientes.Controls.Add(Me.PicImagen)
        Me.GbClientes.Location = New System.Drawing.Point(7, 122)
        Me.GbClientes.Name = "GbClientes"
        Me.GbClientes.Size = New System.Drawing.Size(697, 90)
        Me.GbClientes.TabIndex = 329
        Me.GbClientes.Text = "Información general"
        '
        'lblTasa
        '
        Me.lblTasa.AutoSize = True
        Me.lblTasa.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTasa.Location = New System.Drawing.Point(493, 28)
        Me.lblTasa.Name = "lblTasa"
        Me.lblTasa.Size = New System.Drawing.Size(0, 13)
        Me.lblTasa.TabIndex = 432
        Me.lblTasa.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(464, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "Tasa"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(64, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Nombre"
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label31.ForeColor = System.Drawing.Color.Gray
        Me.Label31.Location = New System.Drawing.Point(637, 45)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 13)
        Me.Label31.TabIndex = 429
        Me.Label31.Text = "Precio"
        '
        'txtUltimoMonto
        '
        Me.txtUltimoMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUltimoMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtUltimoMonto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoMonto.Enabled = False
        Me.txtUltimoMonto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUltimoMonto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoMonto.Location = New System.Drawing.Point(606, 73)
        Me.txtUltimoMonto.Name = "txtUltimoMonto"
        Me.txtUltimoMonto.ReadOnly = True
        Me.txtUltimoMonto.Size = New System.Drawing.Size(84, 13)
        Me.txtUltimoMonto.TabIndex = 428
        Me.txtUltimoMonto.TabStop = False
        Me.txtUltimoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelControl7
        '
        Me.LabelControl7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Location = New System.Drawing.Point(539, 44)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl7.TabIndex = 427
        Me.LabelControl7.Text = "Último pago"
        '
        'LabelControl6
        '
        Me.LabelControl6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Location = New System.Drawing.Point(539, 58)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl6.TabIndex = 426
        Me.LabelControl6.Text = "Fecha"
        '
        'LabelControl5
        '
        Me.LabelControl5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(606, 58)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl5.TabIndex = 425
        Me.LabelControl5.Text = "Monto"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(536, 25)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(60, 13)
        Me.label2.TabIndex = 423
        Me.label2.Text = "Calificación"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.Location = New System.Drawing.Point(528, 29)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(162, 23)
        Me.SeparatorControl1.TabIndex = 424
        '
        'LabelControl3
        '
        Me.LabelControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(539, 4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl3.TabIndex = 418
        Me.LabelControl3.Text = "Resumen"
        '
        'ILbcBalances
        '
        Me.ILbcBalances.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ILbcBalances.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ILbcBalances.Appearance.Options.UseBackColor = True
        Me.ILbcBalances.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ILbcBalances.ColumnWidth = 130
        Me.ILbcBalances.Cursor = System.Windows.Forms.Cursors.Default
        Me.ILbcBalances.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned
        Me.ILbcBalances.HorzScrollStep = 8
        Me.ILbcBalances.Location = New System.Drawing.Point(64, 60)
        Me.ILbcBalances.Margin = New System.Windows.Forms.Padding(0)
        Me.ILbcBalances.MultiColumn = True
        Me.ILbcBalances.Name = "ILbcBalances"
        Me.ILbcBalances.Size = New System.Drawing.Size(469, 24)
        Me.ILbcBalances.TabIndex = 417
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.Options.UseFont = True
        Me.LabelControl11.Location = New System.Drawing.Point(66, 27)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl11.TabIndex = 416
        Me.LabelControl11.Text = "Balance General"
        '
        'PicImagen
        '
        Me.PicImagen.BackColor = System.Drawing.Color.White
        Me.PicImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicImagen.Image = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicImagen.Location = New System.Drawing.Point(4, 25)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Size = New System.Drawing.Size(56, 59)
        Me.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicImagen.TabIndex = 2
        Me.PicImagen.TabStop = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl1.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl1.Controls.Add(Me.lblUsuario)
        Me.GroupControl1.Controls.Add(Me.LabelControl12)
        Me.GroupControl1.Controls.Add(Me.txtHora)
        Me.GroupControl1.Controls.Add(Me.txtIDFactura)
        Me.GroupControl1.Controls.Add(Me.txtFecha)
        Me.GroupControl1.Controls.Add(Me.txtSecondID)
        Me.GroupControl1.Controls.Add(Me.label4)
        Me.GroupControl1.Location = New System.Drawing.Point(707, 122)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(271, 90)
        Me.GroupControl1.TabIndex = 284
        Me.GroupControl1.Text = " # Documento"
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(68, 66)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(0, 13)
        Me.lblUsuario.TabIndex = 423
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(8, 64)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl12.TabIndex = 422
        Me.LabelControl12.Text = "Usuario"
        '
        'frm_facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 703)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.lblMensajeCalificacion)
        Me.Controls.Add(Me.GbClientes)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.TabInfoFactura)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.TabPagCondicion)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.TxtDescuentoSuma)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtFlete)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.txtITBIS)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txtNeto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1000, 742)
        Me.Name = "frm_facturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "15"
        Me.Text = "Facturación"
        Me.TabPagCondicion.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbSelectProductos.ResumeLayout(False)
        Me.TbSelectProductos.PerformLayout()
        CType(Me.GPExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPExistencia.ResumeLayout(False)
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.TabInfoFactura.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.txtCobrador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuProducts.ResumeLayout(False)
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GbClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbClientes.ResumeLayout(False)
        Me.GbClientes.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ILbcBalances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TbSelectProductos As System.Windows.Forms.GroupBox
    Friend WithEvents btnInsertarArticulo As System.Windows.Forms.Button
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents TabPagCondicion As System.Windows.Forms.TabControl
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents txtITBIS As System.Windows.Forms.TextBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuentoSuma As System.Windows.Forms.TextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents CbxChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents txtIDFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Friend WithEvents txtBalanceGeneral As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaAdicional As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionContado As System.Windows.Forms.TextBox
    Friend WithEvents chkHabilitarNota As System.Windows.Forms.CheckBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents txtAdicional As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtMontoPagos As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPagos As System.Windows.Forms.TextBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents chkFichaDatos As System.Windows.Forms.CheckBox
    Friend WithEvents cbxVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
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
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents txtCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalArt As System.Windows.Forms.TextBox
    Friend WithEvents CbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents dgvArticulosFactura As System.Windows.Forms.DataGridView
    Friend WithEvents chkDesactivar As System.Windows.Forms.CheckBox
    Friend WithEvents label25 As System.Windows.Forms.Label
    Friend WithEvents CbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents txtCreditoDisponible As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LimpiarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarArtículoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents TabInfoFactura As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents ConsultacotizacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlanquear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistorialDelClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtNIF As System.Windows.Forms.TextBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnVisualizarPagares As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDiasCondicion As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents lblTelefonos As System.Windows.Forms.Label
    Private WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents BuscarArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ModificarClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblModificar As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEntregarporConduce As System.Windows.Forms.CheckBox
    Friend WithEvents txtRNC As System.Windows.Forms.TextBox
    Private WithEvents lblRNC As System.Windows.Forms.Label
    Friend WithEvents ImpresiónDePagarésToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents txtNivelPrecio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkItbis As CheckBox
    Friend WithEvents CMenuProducts As ContextMenuStrip
    Friend WithEvents IrAArtículosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents chkPreviewImages As CheckBox
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents lblCalificacionColor As Label
    Friend WithEvents lblMensajeCalificacion As Label
    Friend WithEvents txtVendedor As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtCobrador As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents GPExistencia As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TreeViewExistencia As TreeView
    Friend WithEvents txtOrden As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents GbClientes As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PicImagen As PictureBox
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ILbcBalances As DevExpress.XtraEditors.ImageListBoxControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Private WithEvents label2 As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtUltimoMonto As TextBox
    Private WithEvents Label31 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblUsuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Private WithEvents Label1 As Label
    Friend WithEvents lblTasa As Label
    Friend WithEvents Label3 As Label
End Class
