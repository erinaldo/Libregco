<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_factura_cxp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_factura_cxp))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarSuplidorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerificarSubtotalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaFact = New System.Windows.Forms.DateTimePicker()
        Me.label20 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.label19 = New System.Windows.Forms.Label()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txtNCF = New System.Windows.Forms.MaskedTextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtNoFact = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarSup = New System.Windows.Forms.Button()
        Me.txtUltimoMonto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreSuplidor = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtBalanceSup = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.CbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.DtpDiaRecibido = New System.Windows.Forms.DateTimePicker()
        Me.label24 = New System.Windows.Forms.Label()
        Me.label21 = New System.Windows.Forms.Label()
        Me.CbxEmpleadoRec = New System.Windows.Forms.ComboBox()
        Me.txtNotaCompra = New System.Windows.Forms.TextBox()
        Me.label27 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIDCompra = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.btnSubirFactura = New System.Windows.Forms.ToolStripButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtTasa = New System.Windows.Forms.TextBox()
        Me.txtCantDecimales = New System.Windows.Forms.NumericUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbxMoneda = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbxGasto = New System.Windows.Forms.ComboBox()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.chkEnviarReporte = New System.Windows.Forms.CheckBox()
        Me.chkEnviarCopiaDigital = New System.Windows.Forms.CheckBox()
        Me.btnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.edtTo = New DevExpress.XtraEditors.TokenEdit()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.edtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(990, 24)
        Me.MenuStrip1.TabIndex = 233
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarSuplidorToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.VerificarSubtotalesToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarSuplidorToolStripMenuItem
        '
        Me.BuscarSuplidorToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarSuplidorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarSuplidorToolStripMenuItem.Name = "BuscarSuplidorToolStripMenuItem"
        Me.BuscarSuplidorToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarSuplidorToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.BuscarSuplidorToolStripMenuItem.Text = "Buscar "
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'VerificarSubtotalesToolStripMenuItem
        '
        Me.VerificarSubtotalesToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Duplicatex32
        Me.VerificarSubtotalesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.VerificarSubtotalesToolStripMenuItem.Name = "VerificarSubtotalesToolStripMenuItem"
        Me.VerificarSubtotalesToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.VerificarSubtotalesToolStripMenuItem.Text = "Control de subtotales"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(203, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarCompraToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarCompraToolStripMenuItem
        '
        Me.BuscarCompraToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarCompraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarCompraToolStripMenuItem.Name = "BuscarCompraToolStripMenuItem"
        Me.BuscarCompraToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarCompraToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
        Me.BuscarCompraToolStripMenuItem.Text = "Buscar Compra"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(212, 38)
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
        'DtpVencimiento
        '
        Me.DtpVencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.DtpVencimiento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(263, 38)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.Size = New System.Drawing.Size(106, 20)
        Me.DtpVencimiento.TabIndex = 5
        '
        'DtpFechaFact
        '
        Me.DtpFechaFact.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpFechaFact.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFechaFact.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFact.Location = New System.Drawing.Point(12, 38)
        Me.DtpFechaFact.Name = "DtpFechaFact"
        Me.DtpFechaFact.Size = New System.Drawing.Size(103, 20)
        Me.DtpFechaFact.TabIndex = 3
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label20.Location = New System.Drawing.Point(118, 22)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(53, 13)
        Me.label20.TabIndex = 265
        Me.label20.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCondicion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(121, 38)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(136, 21)
        Me.cbxCondicion.TabIndex = 4
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label19.Location = New System.Drawing.Point(263, 22)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(64, 13)
        Me.label19.TabIndex = 264
        Me.label19.Text = "Vencimiento"
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(638, 38)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(162, 21)
        Me.CbxTipoComprobante.TabIndex = 7
        '
        'txtNCF
        '
        Me.txtNCF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNCF.Location = New System.Drawing.Point(806, 38)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.Size = New System.Drawing.Size(168, 20)
        Me.txtNCF.TabIndex = 8
        Me.txtNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label10.Location = New System.Drawing.Point(508, 22)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(59, 13)
        Me.label10.TabIndex = 263
        Me.label10.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(511, 38)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReferencia.Size = New System.Drawing.Size(121, 20)
        Me.txtReferencia.TabIndex = 14
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label9.Location = New System.Drawing.Point(372, 22)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(64, 13)
        Me.label9.TabIndex = 262
        Me.label9.Text = "No. Factura"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label8.Location = New System.Drawing.Point(8, 22)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(89, 13)
        Me.label8.TabIndex = 261
        Me.label8.Text = "Fecha de factura"
        '
        'txtNoFact
        '
        Me.txtNoFact.BackColor = System.Drawing.Color.White
        Me.txtNoFact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoFact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNoFact.Location = New System.Drawing.Point(375, 38)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.Size = New System.Drawing.Size(130, 20)
        Me.txtNoFact.TabIndex = 6
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnBuscarSup)
        Me.groupBox1.Controls.Add(Me.txtUltimoMonto)
        Me.groupBox1.Controls.Add(Me.Label28)
        Me.groupBox1.Controls.Add(Me.txtUltimoPago)
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.txtNombreSuplidor)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.label15)
        Me.groupBox1.Controls.Add(Me.txtBalanceSup)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.txtIDSuplidor)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(4, 121)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(643, 78)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos Suplidor"
        '
        'btnBuscarSup
        '
        Me.btnBuscarSup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarSup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarSup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarSup.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarSup.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarSup.Location = New System.Drawing.Point(162, 17)
        Me.btnBuscarSup.Name = "btnBuscarSup"
        Me.btnBuscarSup.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarSup.TabIndex = 1
        Me.btnBuscarSup.UseVisualStyleBackColor = True
        '
        'txtUltimoMonto
        '
        Me.txtUltimoMonto.Enabled = False
        Me.txtUltimoMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoMonto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoMonto.Location = New System.Drawing.Point(480, 46)
        Me.txtUltimoMonto.Name = "txtUltimoMonto"
        Me.txtUltimoMonto.ReadOnly = True
        Me.txtUltimoMonto.Size = New System.Drawing.Size(157, 23)
        Me.txtUltimoMonto.TabIndex = 233
        Me.txtUltimoMonto.TabStop = False
        Me.txtUltimoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(431, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(43, 15)
        Me.Label28.TabIndex = 232
        Me.Label28.Text = "Monto"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(286, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(139, 23)
        Me.txtUltimoPago.TabIndex = 231
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(207, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Último Pago"
        '
        'txtNombreSuplidor
        '
        Me.txtNombreSuplidor.Enabled = False
        Me.txtNombreSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombreSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombreSuplidor.Location = New System.Drawing.Point(248, 17)
        Me.txtNombreSuplidor.Name = "txtNombreSuplidor"
        Me.txtNombreSuplidor.ReadOnly = True
        Me.txtNombreSuplidor.Size = New System.Drawing.Size(389, 23)
        Me.txtNombreSuplidor.TabIndex = 183
        Me.txtNombreSuplidor.TabStop = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label1.Location = New System.Drawing.Point(191, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 15)
        Me.label1.TabIndex = 184
        Me.label1.Text = "Suplidor"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label15.Location = New System.Drawing.Point(8, 20)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(46, 15)
        Me.label15.TabIndex = 131
        Me.label15.Text = "Código"
        '
        'txtBalanceSup
        '
        Me.txtBalanceSup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBalanceSup.Enabled = False
        Me.txtBalanceSup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceSup.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceSup.Location = New System.Drawing.Point(66, 46)
        Me.txtBalanceSup.Name = "txtBalanceSup"
        Me.txtBalanceSup.ReadOnly = True
        Me.txtBalanceSup.Size = New System.Drawing.Size(135, 23)
        Me.txtBalanceSup.TabIndex = 227
        Me.txtBalanceSup.TabStop = False
        Me.txtBalanceSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label5.Location = New System.Drawing.Point(9, 49)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 15)
        Me.label5.TabIndex = 228
        Me.label5.Text = "Balance"
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDSuplidor.Location = New System.Drawing.Point(66, 17)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.ReadOnly = True
        Me.txtIDSuplidor.Size = New System.Drawing.Size(100, 23)
        Me.txtIDSuplidor.TabIndex = 130
        Me.txtIDSuplidor.TabStop = False
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(474, 95)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 280
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label12.Location = New System.Drawing.Point(399, 30)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(47, 13)
        Me.label12.TabIndex = 278
        Me.label12.Text = "Almacén"
        '
        'CbxAlmacen
        '
        Me.CbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxAlmacen.FormattingEnabled = True
        Me.CbxAlmacen.Location = New System.Drawing.Point(402, 48)
        Me.CbxAlmacen.Name = "CbxAlmacen"
        Me.CbxAlmacen.Size = New System.Drawing.Size(161, 21)
        Me.CbxAlmacen.TabIndex = 13
        '
        'DtpDiaRecibido
        '
        Me.DtpDiaRecibido.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpDiaRecibido.CustomFormat = "dd/MM/yyyy"
        Me.DtpDiaRecibido.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpDiaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDiaRecibido.Location = New System.Drawing.Point(13, 48)
        Me.DtpDiaRecibido.Name = "DtpDiaRecibido"
        Me.DtpDiaRecibido.Size = New System.Drawing.Size(110, 20)
        Me.DtpDiaRecibido.TabIndex = 11
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label24.Location = New System.Drawing.Point(13, 30)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(100, 13)
        Me.label24.TabIndex = 186
        Me.label24.Text = "Fecha de recepción"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label21.Location = New System.Drawing.Point(126, 30)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(109, 13)
        Me.label21.TabIndex = 184
        Me.label21.Text = "Usuario recepcionista"
        '
        'CbxEmpleadoRec
        '
        Me.CbxEmpleadoRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxEmpleadoRec.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxEmpleadoRec.FormattingEnabled = True
        Me.CbxEmpleadoRec.Location = New System.Drawing.Point(129, 48)
        Me.CbxEmpleadoRec.Name = "CbxEmpleadoRec"
        Me.CbxEmpleadoRec.Size = New System.Drawing.Size(267, 21)
        Me.CbxEmpleadoRec.TabIndex = 12
        '
        'txtNotaCompra
        '
        Me.txtNotaCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNotaCompra.Location = New System.Drawing.Point(8, 26)
        Me.txtNotaCompra.Multiline = True
        Me.txtNotaCompra.Name = "txtNotaCompra"
        Me.txtNotaCompra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotaCompra.Size = New System.Drawing.Size(964, 96)
        Me.txtNotaCompra.TabIndex = 9
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label27.Location = New System.Drawing.Point(771, 577)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(58, 13)
        Me.label27.TabIndex = 290
        Me.label27.Text = "Descuento"
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(834, 574)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(152, 20)
        Me.txtDescuento.TabIndex = 16
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label18.Location = New System.Drawing.Point(771, 655)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(57, 13)
        Me.label18.TabIndex = 288
        Me.label18.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(834, 652)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(152, 20)
        Me.txtNeto.TabIndex = 19
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label17.Location = New System.Drawing.Point(771, 629)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(31, 13)
        Me.label17.TabIndex = 286
        Me.label17.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFlete.Location = New System.Drawing.Point(834, 626)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(152, 20)
        Me.txtFlete.TabIndex = 18
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label16.Location = New System.Drawing.Point(771, 603)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(33, 13)
        Me.label16.TabIndex = 285
        Me.label16.Text = "ITBIS"
        '
        'txtItbis
        '
        Me.txtItbis.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtItbis.ForeColor = System.Drawing.Color.Black
        Me.txtItbis.Location = New System.Drawing.Point(834, 600)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.Size = New System.Drawing.Size(152, 20)
        Me.txtItbis.TabIndex = 17
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.label14.Location = New System.Drawing.Point(771, 550)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(56, 13)
        Me.label14.TabIndex = 283
        Me.label14.Text = "Sub. Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(834, 547)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(152, 20)
        Me.txtSubTotal.TabIndex = 15
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCompra)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(653, 121)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(333, 78)
        Me.GbxUserInfo.TabIndex = 291
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(173, 18)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(157, 23)
        Me.txtSecondID.TabIndex = 281
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(58, 47)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 280
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(173, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "Hora"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(212, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 278
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "Código"
        '
        'txtIDCompra
        '
        Me.txtIDCompra.Enabled = False
        Me.txtIDCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCompra.Location = New System.Drawing.Point(58, 18)
        Me.txtIDCompra.Name = "txtIDCompra"
        Me.txtIDCompra.ReadOnly = True
        Me.txtIDCompra.Size = New System.Drawing.Size(109, 23)
        Me.txtIDCompra.TabIndex = 275
        Me.txtIDCompra.TabStop = False
        Me.txtIDCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(554, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscarCompra, Me.btnEliminar, Me.btnImprimir})
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
        'btnBuscarCompra
        '
        Me.btnBuscarCompra.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscarCompra.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCompra.Name = "btnBuscarCompra"
        Me.btnBuscarCompra.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscarCompra.Text = "Buscar"
        Me.btnBuscarCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 27)
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
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.btnSubirFactura})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 681)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(990, 27)
        Me.BarraEstado.TabIndex = 330
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 24)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 24)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 24)
        Me.lblStatusBar.Text = "Listo"
        '
        'btnSubirFactura
        '
        Me.btnSubirFactura.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSubirFactura.Image = CType(resources.GetObject("btnSubirFactura.Image"), System.Drawing.Image)
        Me.btnSubirFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSubirFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSubirFactura.Name = "btnSubirFactura"
        Me.btnSubirFactura.Size = New System.Drawing.Size(132, 24)
        Me.btnSubirFactura.Text = " F10 - Subir Factura"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.CbxTipoComprobante)
        Me.GroupControl1.Controls.Add(Me.txtNCF)
        Me.GroupControl1.Controls.Add(Me.DtpFechaFact)
        Me.GroupControl1.Controls.Add(Me.label8)
        Me.GroupControl1.Controls.Add(Me.cbxCondicion)
        Me.GroupControl1.Controls.Add(Me.label20)
        Me.GroupControl1.Controls.Add(Me.label9)
        Me.GroupControl1.Controls.Add(Me.label19)
        Me.GroupControl1.Controls.Add(Me.txtReferencia)
        Me.GroupControl1.Controls.Add(Me.txtNoFact)
        Me.GroupControl1.Controls.Add(Me.label10)
        Me.GroupControl1.Controls.Add(Me.DtpVencimiento)
        Me.GroupControl1.Location = New System.Drawing.Point(4, 205)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(982, 68)
        Me.GroupControl1.TabIndex = 331
        Me.GroupControl1.Text = "Informaciones de la factura"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.Location = New System.Drawing.Point(803, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 267
        Me.Label11.Text = "NCF"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(635, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "Comprobante fiscal"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.Panel1)
        Me.GroupControl2.Controls.Add(Me.txtNotaCompra)
        Me.GroupControl2.Location = New System.Drawing.Point(4, 279)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(982, 148)
        Me.GroupControl2.TabIndex = 332
        Me.GroupControl2.Text = "Notas y/o Descripciones de la factura"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(2, 128)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(978, 18)
        Me.Panel1.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label30.Location = New System.Drawing.Point(5, 2)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(110, 13)
        Me.Label30.TabIndex = 185
        Me.Label30.Text = "Cant. de caracteres: "
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(4, 433)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(734, 235)
        Me.XtraTabControl1.TabIndex = 334
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Label29)
        Me.XtraTabPage1.Controls.Add(Me.Label22)
        Me.XtraTabPage1.Controls.Add(Me.Label42)
        Me.XtraTabPage1.Controls.Add(Me.SeparatorControl1)
        Me.XtraTabPage1.Controls.Add(Me.txtTasa)
        Me.XtraTabPage1.Controls.Add(Me.CbxAlmacen)
        Me.XtraTabPage1.Controls.Add(Me.txtCantDecimales)
        Me.XtraTabPage1.Controls.Add(Me.label24)
        Me.XtraTabPage1.Controls.Add(Me.Label25)
        Me.XtraTabPage1.Controls.Add(Me.label12)
        Me.XtraTabPage1.Controls.Add(Me.Label13)
        Me.XtraTabPage1.Controls.Add(Me.DtpDiaRecibido)
        Me.XtraTabPage1.Controls.Add(Me.cbxMoneda)
        Me.XtraTabPage1.Controls.Add(Me.CbxEmpleadoRec)
        Me.XtraTabPage1.Controls.Add(Me.Label23)
        Me.XtraTabPage1.Controls.Add(Me.label21)
        Me.XtraTabPage1.Controls.Add(Me.cbxGasto)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(728, 207)
        Me.XtraTabPage1.Text = "Recepción y Moneda"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label29.Location = New System.Drawing.Point(13, 94)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 342
        Me.Label29.Text = "• Moneda"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.Location = New System.Drawing.Point(13, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 13)
        Me.Label22.TabIndex = 341
        Me.Label22.Text = "• Recepción de factura"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label42.Location = New System.Drawing.Point(13, 176)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(54, 13)
        Me.Label42.TabIndex = 340
        Me.Label42.Text = "Decimales"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.Location = New System.Drawing.Point(3, 74)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(722, 23)
        Me.SeparatorControl1.TabIndex = 279
        '
        'txtTasa
        '
        Me.txtTasa.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTasa.Location = New System.Drawing.Point(452, 145)
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(111, 20)
        Me.txtTasa.TabIndex = 337
        Me.txtTasa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCantDecimales
        '
        Me.txtCantDecimales.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantDecimales.Location = New System.Drawing.Point(88, 173)
        Me.txtCantDecimales.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtCantDecimales.Name = "txtCantDecimales"
        Me.txtCantDecimales.Size = New System.Drawing.Size(51, 20)
        Me.txtCantDecimales.TabIndex = 339
        Me.txtCantDecimales.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(359, 148)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 13)
        Me.Label25.TabIndex = 338
        Me.Label25.Text = "Tasa en factura"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(13, 148)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 336
        Me.Label13.Text = "Moneda"
        '
        'cbxMoneda
        '
        Me.cbxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxMoneda.FormattingEnabled = True
        Me.cbxMoneda.Location = New System.Drawing.Point(88, 145)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Size = New System.Drawing.Size(265, 21)
        Me.cbxMoneda.TabIndex = 335
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(13, 119)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 13)
        Me.Label23.TabIndex = 334
        Me.Label23.Text = "Tipo de gasto"
        '
        'cbxGasto
        '
        Me.cbxGasto.DropDownHeight = 80
        Me.cbxGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGasto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxGasto.FormattingEnabled = True
        Me.cbxGasto.IntegralHeight = False
        Me.cbxGasto.Location = New System.Drawing.Point(88, 116)
        Me.cbxGasto.MaxDropDownItems = 6
        Me.cbxGasto.Name = "cbxGasto"
        Me.cbxGasto.Size = New System.Drawing.Size(475, 21)
        Me.cbxGasto.TabIndex = 333
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.chkEnviarReporte)
        Me.XtraTabPage3.Controls.Add(Me.chkEnviarCopiaDigital)
        Me.XtraTabPage3.Controls.Add(Me.btnSend)
        Me.XtraTabPage3.Controls.Add(Me.edtTo)
        Me.XtraTabPage3.Controls.Add(Me.Label26)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(728, 207)
        Me.XtraTabPage3.Text = "Envío de datos"
        '
        'chkEnviarReporte
        '
        Me.chkEnviarReporte.AutoSize = True
        Me.chkEnviarReporte.Location = New System.Drawing.Point(10, 173)
        Me.chkEnviarReporte.Name = "chkEnviarReporte"
        Me.chkEnviarReporte.Size = New System.Drawing.Size(148, 17)
        Me.chkEnviarReporte.TabIndex = 19
        Me.chkEnviarReporte.Text = "Enviar reporte de compra"
        Me.chkEnviarReporte.UseVisualStyleBackColor = True
        '
        'chkEnviarCopiaDigital
        '
        Me.chkEnviarCopiaDigital.AutoSize = True
        Me.chkEnviarCopiaDigital.Location = New System.Drawing.Point(10, 151)
        Me.chkEnviarCopiaDigital.Name = "chkEnviarCopiaDigital"
        Me.chkEnviarCopiaDigital.Size = New System.Drawing.Size(115, 17)
        Me.chkEnviarCopiaDigital.TabIndex = 18
        Me.chkEnviarCopiaDigital.Text = "Enviar copia digital"
        Me.chkEnviarCopiaDigital.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Mailx48
        Me.btnSend.Location = New System.Drawing.Point(571, 144)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(145, 51)
        Me.btnSend.TabIndex = 17
        Me.btnSend.Text = "Enviar"
        '
        'edtTo
        '
        Me.edtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtTo.Location = New System.Drawing.Point(10, 26)
        Me.edtTo.Name = "edtTo"
        Me.edtTo.Properties.DropDownRowCount = 6
        Me.edtTo.Properties.EditMode = DevExpress.XtraEditors.TokenEditMode.Manual
        Me.edtTo.Properties.EditValueType = DevExpress.XtraEditors.TokenEditValueType.List
        Me.edtTo.Properties.Separators.AddRange(New String() {";"})
        Me.edtTo.Size = New System.Drawing.Size(705, 20)
        Me.edtTo.TabIndex = 16
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Destinatarios"
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.WareHouse_x48, "Compra guardada", "La compra ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.WareHouse_x48, "Compra modificada", "La compra ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("cbe55110-c722-4ca2-9365-c18e3679b1d7", Global.Libregco.My.Resources.Resources.Products_x48, "Descripción modificada", "La descripción del artículo ha sido modificada.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("41f0a004-b804-40e9-8b3e-51d9bf78cd7f", Global.Libregco.My.Resources.Resources.Products_x48, "Costos y precios modificados", "Los precios del artículo han sido modificados.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'frm_factura_cxp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 708)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.label27)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.label17)
        Me.Controls.Add(Me.txtFlete)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_factura_cxp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "128"
        Me.Text = "Registro de facturas <<CXP>>"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        Me.XtraTabPage3.PerformLayout()
        CType(Me.edtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DtpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaFact As System.Windows.Forms.DateTimePicker
    Friend WithEvents label20 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents label19 As System.Windows.Forms.Label
    Friend WithEvents CbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents txtNCF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUltimoMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombreSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceSup As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents CbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents DtpDiaRecibido As System.Windows.Forms.DateTimePicker
    Private WithEvents label24 As System.Windows.Forms.Label
    Friend WithEvents txtNotaCompra As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents CbxEmpleadoRec As System.Windows.Forms.ComboBox
    Friend WithEvents label27 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents txtItbis As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIDCompra As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BuscarSuplidorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscarSup As System.Windows.Forms.Button
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnSubirFactura As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label42 As Label
    Friend WithEvents txtTasa As TextBox
    Friend WithEvents txtCantDecimales As NumericUpDown
    Private WithEvents Label25 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cbxMoneda As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cbxGasto As ComboBox
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents chkEnviarReporte As CheckBox
    Friend WithEvents chkEnviarCopiaDigital As CheckBox
    Friend WithEvents btnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents edtTo As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents Label26 As Label
    Private WithEvents Label29 As Label
    Private WithEvents Label22 As Label
    Friend WithEvents Panel1 As Panel
    Private WithEvents Label30 As Label
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents VerificarSubtotalesToolStripMenuItem As ToolStripMenuItem
End Class
