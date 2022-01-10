<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_financiamiento
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_financiamiento))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblMensajeCalificacion = New System.Windows.Forms.Label()
        Me.GbClientes = New System.Windows.Forms.GroupBox()
        Me.txtBalanceGeneralCargos = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.lblRNC = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.lblTelefonos = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtIDFinanciamiento = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTiempoPeriodos = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCantidadCuotas = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMontoPrestamo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtGranTotal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRedondearCuotas = New System.Windows.Forms.CheckBox()
        Me.chkPoseeGarantia = New System.Windows.Forms.CheckBox()
        Me.ChkEvitSunday = New System.Windows.Forms.CheckBox()
        Me.ChkEvitSaturday = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbxFormaPago = New System.Windows.Forms.ComboBox()
        Me.cbxMetodo = New System.Windows.Forms.ComboBox()
        Me.txtCostoTramite = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPorcInteres = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtMeses = New System.Windows.Forms.TextBox()
        Me.txtMontoPagos = New System.Windows.Forms.TextBox()
        Me.txtTotalAPagar = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DgvCuotas = New System.Windows.Forms.DataGridView()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtTasaItbis = New System.Windows.Forms.TextBox()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbxVendedor = New System.Windows.Forms.ComboBox()
        Me.chkGenerarItbis = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtITBIS = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.IDPagare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intereses = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SumaLetra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GbClientes.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMensajeCalificacion
        '
        Me.lblMensajeCalificacion.AutoSize = True
        Me.lblMensajeCalificacion.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeCalificacion.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeCalificacion.Location = New System.Drawing.Point(412, 112)
        Me.lblMensajeCalificacion.Name = "lblMensajeCalificacion"
        Me.lblMensajeCalificacion.Size = New System.Drawing.Size(250, 15)
        Me.lblMensajeCalificacion.TabIndex = 333
        Me.lblMensajeCalificacion.Text = "El cliente posee una calificación de alto riesgo.!"
        Me.lblMensajeCalificacion.Visible = False
        '
        'GbClientes
        '
        Me.GbClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbClientes.Controls.Add(Me.txtBalanceGeneralCargos)
        Me.GbClientes.Controls.Add(Me.label21)
        Me.GbClientes.Controls.Add(Me.txtRNC)
        Me.GbClientes.Controls.Add(Me.label2)
        Me.GbClientes.Controls.Add(Me.Label24)
        Me.GbClientes.Controls.Add(Me.txtUltimoPago)
        Me.GbClientes.Controls.Add(Me.txtCalificacion)
        Me.GbClientes.Controls.Add(Me.lblRNC)
        Me.GbClientes.Controls.Add(Me.label20)
        Me.GbClientes.Controls.Add(Me.Label34)
        Me.GbClientes.Controls.Add(Me.txtBalanceGeneral)
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
        Me.GbClientes.Location = New System.Drawing.Point(7, 122)
        Me.GbClientes.Name = "GbClientes"
        Me.GbClientes.Size = New System.Drawing.Size(754, 72)
        Me.GbClientes.TabIndex = 0
        Me.GbClientes.TabStop = False
        Me.GbClientes.Text = "Datos"
        '
        'txtBalanceGeneralCargos
        '
        Me.txtBalanceGeneralCargos.Enabled = False
        Me.txtBalanceGeneralCargos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneralCargos.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneralCargos.Location = New System.Drawing.Point(276, 42)
        Me.txtBalanceGeneralCargos.Name = "txtBalanceGeneralCargos"
        Me.txtBalanceGeneralCargos.ReadOnly = True
        Me.txtBalanceGeneralCargos.Size = New System.Drawing.Size(130, 23)
        Me.txtBalanceGeneralCargos.TabIndex = 419
        Me.txtBalanceGeneralCargos.TabStop = False
        Me.txtBalanceGeneralCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(412, 46)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Últ. Pago"
        '
        'txtRNC
        '
        Me.txtRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(592, 105)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.Size = New System.Drawing.Size(156, 23)
        Me.txtRNC.TabIndex = 331
        Me.txtRNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtRNC.Visible = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label2.Location = New System.Drawing.Point(609, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(69, 15)
        Me.label2.TabIndex = 129
        Me.label2.Text = "Calificación"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label24.Location = New System.Drawing.Point(203, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 15)
        Me.Label24.TabIndex = 418
        Me.Label24.Text = "con cargos"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(473, 42)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(132, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(684, 42)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(65, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRNC
        '
        Me.lblRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRNC.AutoSize = True
        Me.lblRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblRNC.Location = New System.Drawing.Point(557, 108)
        Me.lblRNC.Name = "lblRNC"
        Me.lblRNC.Size = New System.Drawing.Size(31, 15)
        Me.lblRNC.TabIndex = 330
        Me.lblRNC.Text = "RNC"
        Me.lblRNC.Visible = False
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(8, 46)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(53, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Bce. Gral"
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label34.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label34.Location = New System.Drawing.Point(659, 131)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(90, 15)
        Me.Label34.TabIndex = 329
        Me.Label34.Text = "Volver a ajustar"
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.Enabled = False
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(67, 42)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(130, 23)
        Me.txtBalanceGeneral.TabIndex = 124
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.txtTelefonos.Size = New System.Drawing.Size(488, 23)
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
        Me.txtDireccion.Size = New System.Drawing.Size(682, 23)
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
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(172, 14)
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
        Me.nombre_label.Location = New System.Drawing.Point(7, 17)
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
        Me.txtIDCliente.Location = New System.Drawing.Point(66, 14)
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
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(193, 14)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(555, 23)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TabStop = False
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 332
        Me.PicBoxLogo.TabStop = False
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(645, 23)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 331
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
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = CType(resources.GetObject("btnGuardarC.Image"), System.Drawing.Image)
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
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
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.label1)
        Me.GbxUserInfo.Controls.Add(Me.txtIDFinanciamiento)
        Me.GbxUserInfo.Controls.Add(Me.label4)
        Me.GbxUserInfo.Controls.Add(Me.label3)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(767, 122)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(305, 72)
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
        'txtIDFinanciamiento
        '
        Me.txtIDFinanciamiento.Enabled = False
        Me.txtIDFinanciamiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFinanciamiento.Location = New System.Drawing.Point(59, 15)
        Me.txtIDFinanciamiento.Name = "txtIDFinanciamiento"
        Me.txtIDFinanciamiento.ReadOnly = True
        Me.txtIDFinanciamiento.Size = New System.Drawing.Size(94, 23)
        Me.txtIDFinanciamiento.TabIndex = 106
        Me.txtIDFinanciamiento.TabStop = False
        Me.txtIDFinanciamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.txtMontoPrestamo)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtInicial)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtGranTotal)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cbxFormaPago)
        Me.GroupBox1.Controls.Add(Me.cbxMetodo)
        Me.GroupBox1.Controls.Add(Me.txtCostoTramite)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPorcInteres)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.SeparatorControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1065, 180)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Financiamiento"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTiempoPeriodos)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtCantidadCuotas)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(340, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(287, 105)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Período de financiamiento"
        '
        'txtTiempoPeriodos
        '
        Me.txtTiempoPeriodos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtTiempoPeriodos.ForeColor = System.Drawing.Color.Black
        Me.txtTiempoPeriodos.Location = New System.Drawing.Point(8, 75)
        Me.txtTiempoPeriodos.Name = "txtTiempoPeriodos"
        Me.txtTiempoPeriodos.ReadOnly = True
        Me.txtTiempoPeriodos.Size = New System.Drawing.Size(270, 20)
        Me.txtTiempoPeriodos.TabIndex = 353
        Me.txtTiempoPeriodos.TabStop = False
        Me.txtTiempoPeriodos.Tag = "0"
        Me.txtTiempoPeriodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(5, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(178, 13)
        Me.Label23.TabIndex = 352
        Me.Label23.Text = "Tiempo comprendido entre períodos"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaFinal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaFinal.Enabled = False
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(181, 34)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaFinal.TabIndex = 350
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(5, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 339
        Me.Label11.Text = "Fecha de inicio"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(8, 34)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInicio.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.DimGray
        Me.Label22.Location = New System.Drawing.Point(178, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 13)
        Me.Label22.TabIndex = 351
        Me.Label22.Text = "Fecha de término"
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(111, 34)
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(62, 20)
        Me.txtCantidadCuotas.TabIndex = 15
        Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(107, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Cuotas"
        '
        'txtMontoPrestamo
        '
        Me.txtMontoPrestamo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtMontoPrestamo.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoPrestamo.Enabled = False
        Me.txtMontoPrestamo.Location = New System.Drawing.Point(909, 134)
        Me.txtMontoPrestamo.Name = "txtMontoPrestamo"
        Me.txtMontoPrestamo.Size = New System.Drawing.Size(145, 20)
        Me.txtMontoPrestamo.TabIndex = 348
        Me.txtMontoPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(791, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 13)
        Me.Label18.TabIndex = 347
        Me.Label18.Text = "Monto préstamo RD$"
        '
        'txtInicial
        '
        Me.txtInicial.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtInicial.Location = New System.Drawing.Point(909, 55)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(145, 20)
        Me.txtInicial.TabIndex = 2
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label19.Location = New System.Drawing.Point(791, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 348
        Me.Label19.Text = "Inicial RD$"
        '
        'txtGranTotal
        '
        Me.txtGranTotal.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtGranTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGranTotal.Location = New System.Drawing.Point(909, 81)
        Me.txtGranTotal.Name = "txtGranTotal"
        Me.txtGranTotal.ReadOnly = True
        Me.txtGranTotal.Size = New System.Drawing.Size(145, 21)
        Me.txtGranTotal.TabIndex = 347
        Me.txtGranTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(791, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 346
        Me.Label14.Text = "Financiamiento RD$"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRedondearCuotas)
        Me.GroupBox2.Controls.Add(Me.chkPoseeGarantia)
        Me.GroupBox2.Controls.Add(Me.ChkEvitSunday)
        Me.GroupBox2.Controls.Add(Me.ChkEvitSaturday)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.GroupBox2.Location = New System.Drawing.Point(632, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 105)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opcionales"
        '
        'chkRedondearCuotas
        '
        Me.chkRedondearCuotas.AutoSize = True
        Me.chkRedondearCuotas.ForeColor = System.Drawing.Color.Black
        Me.chkRedondearCuotas.Location = New System.Drawing.Point(13, 78)
        Me.chkRedondearCuotas.Name = "chkRedondearCuotas"
        Me.chkRedondearCuotas.Size = New System.Drawing.Size(114, 17)
        Me.chkRedondearCuotas.TabIndex = 20
        Me.chkRedondearCuotas.Tag = "0"
        Me.chkRedondearCuotas.Text = "Redondear cuotas"
        Me.chkRedondearCuotas.UseVisualStyleBackColor = True
        '
        'chkPoseeGarantia
        '
        Me.chkPoseeGarantia.AutoSize = True
        Me.chkPoseeGarantia.ForeColor = System.Drawing.Color.Black
        Me.chkPoseeGarantia.Location = New System.Drawing.Point(13, 58)
        Me.chkPoseeGarantia.Name = "chkPoseeGarantia"
        Me.chkPoseeGarantia.Size = New System.Drawing.Size(103, 17)
        Me.chkPoseeGarantia.TabIndex = 19
        Me.chkPoseeGarantia.Tag = "0"
        Me.chkPoseeGarantia.Text = "Posee garantías"
        Me.chkPoseeGarantia.UseVisualStyleBackColor = True
        '
        'ChkEvitSunday
        '
        Me.ChkEvitSunday.AutoSize = True
        Me.ChkEvitSunday.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkEvitSunday.ForeColor = System.Drawing.Color.Black
        Me.ChkEvitSunday.Location = New System.Drawing.Point(13, 38)
        Me.ChkEvitSunday.Name = "ChkEvitSunday"
        Me.ChkEvitSunday.Size = New System.Drawing.Size(102, 17)
        Me.ChkEvitSunday.TabIndex = 18
        Me.ChkEvitSunday.Tag = "0"
        Me.ChkEvitSunday.Text = "Evitar domingos"
        Me.ChkEvitSunday.UseVisualStyleBackColor = True
        '
        'ChkEvitSaturday
        '
        Me.ChkEvitSaturday.AutoSize = True
        Me.ChkEvitSaturday.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkEvitSaturday.ForeColor = System.Drawing.Color.Black
        Me.ChkEvitSaturday.Location = New System.Drawing.Point(13, 19)
        Me.ChkEvitSaturday.Name = "ChkEvitSaturday"
        Me.ChkEvitSaturday.Size = New System.Drawing.Size(97, 17)
        Me.ChkEvitSaturday.TabIndex = 17
        Me.ChkEvitSaturday.Tag = "0"
        Me.ChkEvitSaturday.Text = "Evitar sábados"
        Me.ChkEvitSaturday.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label13.Location = New System.Drawing.Point(8, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 341
        Me.Label13.Text = "Tipo de cálculo"
        '
        'cbxFormaPago
        '
        Me.cbxFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFormaPago.FormattingEnabled = True
        Me.cbxFormaPago.Location = New System.Drawing.Point(116, 114)
        Me.cbxFormaPago.Name = "cbxFormaPago"
        Me.cbxFormaPago.Size = New System.Drawing.Size(212, 21)
        Me.cbxFormaPago.TabIndex = 8
        '
        'cbxMetodo
        '
        Me.cbxMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMetodo.FormattingEnabled = True
        Me.cbxMetodo.Location = New System.Drawing.Point(116, 87)
        Me.cbxMetodo.Name = "cbxMetodo"
        Me.cbxMetodo.Size = New System.Drawing.Size(212, 21)
        Me.cbxMetodo.TabIndex = 5
        '
        'txtCostoTramite
        '
        Me.txtCostoTramite.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtCostoTramite.Location = New System.Drawing.Point(909, 108)
        Me.txtCostoTramite.Name = "txtCostoTramite"
        Me.txtCostoTramite.Size = New System.Drawing.Size(145, 20)
        Me.txtCostoTramite.TabIndex = 3
        Me.txtCostoTramite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(791, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Trámites RD$"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 340
        Me.Label10.Text = "Forma de pago"
        '
        'txtPorcInteres
        '
        Me.txtPorcInteres.Location = New System.Drawing.Point(116, 142)
        Me.txtPorcInteres.Name = "txtPorcInteres"
        Me.txtPorcInteres.Size = New System.Drawing.Size(79, 20)
        Me.txtPorcInteres.TabIndex = 11
        Me.txtPorcInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "% Interés mensual"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 338
        Me.Label12.Text = "Método"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(791, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Valor RD$"
        '
        'txtMonto
        '
        Me.txtMonto.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txtMonto.Location = New System.Drawing.Point(909, 29)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(145, 20)
        Me.txtMonto.TabIndex = 1
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Location = New System.Drawing.Point(72, 20)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(696, 34)
        Me.txtDescripcion.TabIndex = 0
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.Location = New System.Drawing.Point(66, 56)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(719, 19)
        Me.SeparatorControl1.TabIndex = 4
        '
        'txtMeses
        '
        Me.txtMeses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMeses.BackColor = System.Drawing.SystemColors.Info
        Me.txtMeses.Enabled = False
        Me.txtMeses.Location = New System.Drawing.Point(455, 696)
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.Size = New System.Drawing.Size(74, 20)
        Me.txtMeses.TabIndex = 354
        Me.txtMeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMontoPagos
        '
        Me.txtMontoPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoPagos.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoPagos.Enabled = False
        Me.txtMontoPagos.Location = New System.Drawing.Point(662, 696)
        Me.txtMontoPagos.Name = "txtMontoPagos"
        Me.txtMontoPagos.Size = New System.Drawing.Size(147, 20)
        Me.txtMontoPagos.TabIndex = 352
        Me.txtMontoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotalAPagar
        '
        Me.txtTotalAPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAPagar.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalAPagar.Enabled = False
        Me.txtTotalAPagar.Location = New System.Drawing.Point(922, 696)
        Me.txtTotalAPagar.Name = "txtTotalAPagar"
        Me.txtTotalAPagar.Size = New System.Drawing.Size(147, 20)
        Me.txtTotalAPagar.TabIndex = 350
        Me.txtTotalAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(823, 699)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(94, 13)
        Me.Label17.TabIndex = 349
        Me.Label17.Text = "Total a Pagar RD$"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(545, 699)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 13)
        Me.Label16.TabIndex = 351
        Me.Label16.Text = "Monto por pagos RD$"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(411, 699)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 353
        Me.Label15.Text = "Meses"
        '
        'DgvCuotas
        '
        Me.DgvCuotas.AllowUserToAddRows = False
        Me.DgvCuotas.AllowUserToDeleteRows = False
        Me.DgvCuotas.AllowUserToResizeColumns = False
        Me.DgvCuotas.AllowUserToResizeRows = False
        Me.DgvCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvCuotas.BackgroundColor = System.Drawing.Color.White
        Me.DgvCuotas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPagare, Me.NoCuota, Me.MontoCuota, Me.Vencimiento, Me.Capital, Me.Intereses, Me.Balance, Me.SumaLetra})
        Me.DgvCuotas.Location = New System.Drawing.Point(-1, 3)
        Me.DgvCuotas.Name = "DgvCuotas"
        Me.DgvCuotas.ReadOnly = True
        Me.DgvCuotas.RowHeadersWidth = 57
        Me.DgvCuotas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvCuotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCuotas.Size = New System.Drawing.Size(1061, 275)
        Me.DgvCuotas.TabIndex = 0
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 726)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1079, 25)
        Me.BarraEstado.TabIndex = 413
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
        Me.PicLoading.Image = CType(resources.GetObject("PicLoading.Image"), System.Drawing.Image)
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cuota"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 140
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pago"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 163
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vence El"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 260
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Capital"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 163
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Intereses"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 163
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 163
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(6, 381)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1065, 306)
        Me.XtraTabControl1.TabIndex = 414
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.DgvCuotas)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1059, 278)
        Me.XtraTabPage1.Text = "Cuotas"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.Label30)
        Me.XtraTabPage2.Controls.Add(Me.txtTasaItbis)
        Me.XtraTabPage2.Controls.Add(Me.SeparatorControl3)
        Me.XtraTabPage2.Controls.Add(Me.Label25)
        Me.XtraTabPage2.Controls.Add(Me.cbxVendedor)
        Me.XtraTabPage2.Controls.Add(Me.chkGenerarItbis)
        Me.XtraTabPage2.Controls.Add(Me.Label27)
        Me.XtraTabPage2.Controls.Add(Me.txtSubTotal)
        Me.XtraTabPage2.Controls.Add(Me.txtITBIS)
        Me.XtraTabPage2.Controls.Add(Me.Label31)
        Me.XtraTabPage2.Controls.Add(Me.txtNeto)
        Me.XtraTabPage2.Controls.Add(Me.Label26)
        Me.XtraTabPage2.Controls.Add(Me.CbxTipoComprobante)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1059, 278)
        Me.XtraTabPage2.Text = "Facturación"
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(698, 221)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 13)
        Me.Label30.TabIndex = 346
        Me.Label30.Text = "% Itbis"
        Me.Label30.Visible = False
        '
        'txtTasaItbis
        '
        Me.txtTasaItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTasaItbis.Location = New System.Drawing.Point(746, 218)
        Me.txtTasaItbis.Name = "txtTasaItbis"
        Me.txtTasaItbis.Size = New System.Drawing.Size(64, 21)
        Me.txtTasaItbis.TabIndex = 345
        Me.txtTasaItbis.Text = "0"
        Me.txtTasaItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTasaItbis.Visible = False
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl3.Location = New System.Drawing.Point(4, 54)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(1053, 19)
        Me.SeparatorControl3.TabIndex = 343
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(284, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 13)
        Me.Label25.TabIndex = 288
        Me.Label25.Text = "Vendedor"
        '
        'cbxVendedor
        '
        Me.cbxVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxVendedor.FormattingEnabled = True
        Me.cbxVendedor.Location = New System.Drawing.Point(287, 25)
        Me.cbxVendedor.Name = "cbxVendedor"
        Me.cbxVendedor.Size = New System.Drawing.Size(266, 21)
        Me.cbxVendedor.TabIndex = 287
        '
        'chkGenerarItbis
        '
        Me.chkGenerarItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkGenerarItbis.AutoSize = True
        Me.chkGenerarItbis.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkGenerarItbis.Location = New System.Drawing.Point(816, 221)
        Me.chkGenerarItbis.Name = "chkGenerarItbis"
        Me.chkGenerarItbis.Size = New System.Drawing.Size(89, 17)
        Me.chkGenerarItbis.TabIndex = 286
        Me.chkGenerarItbis.Text = "Generar Itbis"
        Me.chkGenerarItbis.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label27.Location = New System.Drawing.Point(816, 192)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 13)
        Me.Label27.TabIndex = 279
        Me.Label27.Text = "Sub-Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSubTotal.Location = New System.Drawing.Point(908, 189)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(142, 20)
        Me.txtSubTotal.TabIndex = 278
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtITBIS
        '
        Me.txtITBIS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtITBIS.Enabled = False
        Me.txtITBIS.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtITBIS.Location = New System.Drawing.Point(908, 218)
        Me.txtITBIS.Name = "txtITBIS"
        Me.txtITBIS.ReadOnly = True
        Me.txtITBIS.Size = New System.Drawing.Size(142, 20)
        Me.txtITBIS.TabIndex = 282
        Me.txtITBIS.TabStop = False
        Me.txtITBIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label31.Location = New System.Drawing.Point(816, 250)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 13)
        Me.Label31.TabIndex = 285
        Me.Label31.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNeto.Location = New System.Drawing.Point(908, 247)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(142, 20)
        Me.txtNeto.TabIndex = 284
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label26.Location = New System.Drawing.Point(8, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(135, 13)
        Me.Label26.TabIndex = 275
        Me.Label26.Text = "Tipo de comprobante fiscal"
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(11, 25)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(266, 21)
        Me.CbxTipoComprobante.TabIndex = 274
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Facturacionx48, "Financiamiento guardada", "El financiamiento ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.Facturacionx48, "Financiamiento modificado", "El financimiento ha sido modificada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'chkNulo
        '
        Me.chkNulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Enabled = False
        Me.chkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkNulo.Location = New System.Drawing.Point(275, 103)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(61, 19)
        Me.chkNulo.TabIndex = 415
        Me.chkNulo.Text = "Anular"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(1079, 24)
        Me.MenuBarra.TabIndex = 416
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator3, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(203, 6)
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
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarFacturaToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarFacturaToolStripMenuItem
        '
        Me.BuscarFacturaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarFacturaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarFacturaToolStripMenuItem.Name = "BuscarFacturaToolStripMenuItem"
        Me.BuscarFacturaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarFacturaToolStripMenuItem.Size = New System.Drawing.Size(251, 38)
        Me.BuscarFacturaToolStripMenuItem.Text = "Buscar Financiamiento"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(251, 38)
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
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 693)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(399, 23)
        Me.ProgressBar1.TabIndex = 417
        Me.ProgressBar1.Visible = False
        '
        'IDPagare
        '
        Me.IDPagare.HeaderText = "IDPagare"
        Me.IDPagare.Name = "IDPagare"
        Me.IDPagare.ReadOnly = True
        Me.IDPagare.Visible = False
        '
        'NoCuota
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoCuota.DefaultCellStyle = DataGridViewCellStyle2
        Me.NoCuota.HeaderText = "No. Cuota"
        Me.NoCuota.Name = "NoCuota"
        Me.NoCuota.ReadOnly = True
        Me.NoCuota.Width = 80
        '
        'MontoCuota
        '
        Me.MontoCuota.HeaderText = "Pago"
        Me.MontoCuota.Name = "MontoCuota"
        Me.MontoCuota.ReadOnly = True
        Me.MontoCuota.Width = 163
        '
        'Vencimiento
        '
        Me.Vencimiento.HeaderText = "Vence el"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        Me.Vencimiento.Width = 260
        '
        'Capital
        '
        Me.Capital.HeaderText = "Capital"
        Me.Capital.Name = "Capital"
        Me.Capital.ReadOnly = True
        Me.Capital.Width = 163
        '
        'Intereses
        '
        Me.Intereses.HeaderText = "Intereses"
        Me.Intereses.Name = "Intereses"
        Me.Intereses.ReadOnly = True
        Me.Intereses.Width = 163
        '
        'Balance
        '
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        Me.Balance.Width = 170
        '
        'SumaLetra
        '
        Me.SumaLetra.HeaderText = "SumaLetra"
        Me.SumaLetra.Name = "SumaLetra"
        Me.SumaLetra.ReadOnly = True
        Me.SumaLetra.Visible = False
        Me.SumaLetra.Width = 400
        '
        'frm_financiamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 751)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lblMensajeCalificacion)
        Me.Controls.Add(Me.GbClientes)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.txtMeses)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtMontoPagos)
        Me.Controls.Add(Me.txtTotalAPagar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1095, 790)
        Me.Name = "frm_financiamiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "272"
        Me.Text = "Financiamientos"
        Me.GbClientes.ResumeLayout(False)
        Me.GbClientes.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMensajeCalificacion As Label
    Friend WithEvents GbClientes As GroupBox
    Friend WithEvents txtRNC As TextBox
    Private WithEvents lblRNC As Label
    Friend WithEvents Label34 As Label
    Private WithEvents label20 As Label
    Friend WithEvents txtBalanceGeneral As TextBox
    Private WithEvents label21 As Label
    Friend WithEvents txtUltimoPago As TextBox
    Private WithEvents label2 As Label
    Friend WithEvents txtCalificacion As TextBox
    Private WithEvents lblTelefonos As Label
    Private WithEvents lblDireccion As Label
    Friend WithEvents txtTelefonos As TextBox
    Friend WithEvents txtDireccion As TextBox
    Private WithEvents btnBuscarCliente As Button
    Private WithEvents nombre_label As Label
    Friend WithEvents txtIDCliente As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents PicBoxLogo As PictureBox
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnAnular As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents GbxUserInfo As GroupBox
    Friend WithEvents txtHora As DateTimePicker
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents txtFecha As DateTimePicker
    Private WithEvents label1 As Label
    Friend WithEvents txtIDFinanciamiento As TextBox
    Private WithEvents label4 As Label
    Private WithEvents label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCantidadCuotas As TextBox
    Friend WithEvents cbxFormaPago As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxMetodo As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPorcInteres As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCostoTramite As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents ChkEvitSunday As CheckBox
    Friend WithEvents ChkEvitSaturday As CheckBox
    Friend WithEvents txtMontoPrestamo As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtMeses As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtMontoPagos As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTotalAPagar As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents GbCuotas As GroupBox
    Friend WithEvents DgvCuotas As DataGridView
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents chkPoseeGarantia As CheckBox
    Friend WithEvents txtInicial As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtGranTotal As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents txtTiempoPeriodos As TextBox
    Friend WithEvents Hora As Timer
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label26 As Label
    Friend WithEvents CbxTipoComprobante As ComboBox
    Friend WithEvents chkGenerarItbis As CheckBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents txtITBIS As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtNeto As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cbxVendedor As ComboBox
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label30 As Label
    Friend WithEvents txtTasaItbis As TextBox
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents chkNulo As CheckBox
    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarFacturaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents chkRedondearCuotas As CheckBox
    Friend WithEvents txtBalanceGeneralCargos As TextBox
    Private WithEvents Label24 As Label
    Friend WithEvents IDPagare As DataGridViewTextBoxColumn
    Friend WithEvents NoCuota As DataGridViewTextBoxColumn
    Friend WithEvents MontoCuota As DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As DataGridViewTextBoxColumn
    Friend WithEvents Capital As DataGridViewTextBoxColumn
    Friend WithEvents Intereses As DataGridViewTextBoxColumn
    Friend WithEvents Balance As DataGridViewTextBoxColumn
    Friend WithEvents SumaLetra As DataGridViewTextBoxColumn
End Class
