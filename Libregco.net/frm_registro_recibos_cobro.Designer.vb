<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_registro_recibos_cobro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_registro_recibos_cobro))
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend5 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblEstadoCobrador = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIDCobradorC = New System.Windows.Forms.TextBox()
        Me.txtCobradorC = New System.Windows.Forms.TextBox()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.PicCliente = New System.Windows.Forms.Panel()
        Me.SimilarFindButton = New System.Windows.Forms.Panel()
        Me.label20 = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.cbxNoEntrega = New System.Windows.Forms.ComboBox()
        Me.cbxNoRecibo = New System.Windows.Forms.ComboBox()
        Me.lblIDRecibo = New System.Windows.Forms.Label()
        Me.lblIDEntrega = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.labeltipo = New System.Windows.Forms.Label()
        Me.cbxTipoRecibo = New System.Windows.Forms.ComboBox()
        Me.DtpFechaRecibo = New System.Windows.Forms.DateTimePicker()
        Me.labelFecha = New System.Windows.Forms.Label()
        Me.DgvDetalleRecibos = New System.Windows.Forms.DataGridView()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPagareStatus = New System.Windows.Forms.TextBox()
        Me.txtDiasVenc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMontoPagare = New System.Windows.Forms.TextBox()
        Me.txtFechaVenc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBalancePagare = New System.Windows.Forms.TextBox()
        Me.lblIDFactura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComision = New System.Windows.Forms.TextBox()
        Me.btnInsertDetalle = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CbxTipoComision = New System.Windows.Forms.ComboBox()
        Me.CbxFactura = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CbxNoPagare = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblIDPagare = New System.Windows.Forms.Label()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblIDDetalle = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnQuitarArticulo = New System.Windows.Forms.ToolStripButton()
        Me.lblCountRows = New System.Windows.Forms.ToolStripLabel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarHistorial = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConsultarEntrega = New System.Windows.Forms.Button()
        Me.lblDescripcionEntrega = New System.Windows.Forms.Label()
        Me.lblComisionEntrega = New System.Windows.Forms.Label()
        Me.lblRangoEntrega = New System.Windows.Forms.Label()
        Me.lblCantidadEntrega = New System.Windows.Forms.Label()
        Me.lblUsuarioEntrega = New System.Windows.Forms.Label()
        Me.lblCobradorEntrega = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblCheckNotaDescuento = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DgvAuditoria = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdbMonto = New System.Windows.Forms.RadioButton()
        Me.rdbCantidad = New System.Windows.Forms.RadioButton()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.lblAnular = New System.Windows.Forms.LinkLabel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgvRecibos = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.txtCargos = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblMensajeAuditor = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtMontoRecibos = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Format = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDReciboAuditoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDReciboCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReciboSecondID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaReciboAuditoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConceptoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        Me.PicCliente.SuspendLayout()
        CType(Me.DgvDetalleRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.DgvAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1221, 24)
        Me.MenuStrip1.TabIndex = 247
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
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
        Me.BuscarCompraToolStripMenuItem.Size = New System.Drawing.Size(175, 38)
        Me.BuscarCompraToolStripMenuItem.Text = "Historial"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(175, 38)
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
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(1161, 126)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 277
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(773, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 311
        Me.Label2.Text = "Observaciones:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label29.Location = New System.Drawing.Point(673, 33)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(63, 13)
        Me.Label29.TabIndex = 310
        Me.Label29.Text = "Calificación"
        '
        'lblEstadoCobrador
        '
        Me.lblEstadoCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.lblEstadoCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEstadoCobrador.Location = New System.Drawing.Point(773, 54)
        Me.lblEstadoCobrador.Name = "lblEstadoCobrador"
        Me.lblEstadoCobrador.Size = New System.Drawing.Size(377, 33)
        Me.lblEstadoCobrador.TabIndex = 308
        Me.lblEstadoCobrador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label22.Location = New System.Drawing.Point(420, 79)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(1, 60)
        Me.Label22.TabIndex = 307
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label19.Location = New System.Drawing.Point(428, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 131
        Me.Label19.Text = "Cobrador"
        '
        'txtIDCobradorC
        '
        Me.txtIDCobradorC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDCobradorC.BackColor = System.Drawing.SystemColors.Control
        Me.txtIDCobradorC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCobradorC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCobradorC.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDCobradorC.Location = New System.Drawing.Point(641, 121)
        Me.txtIDCobradorC.Name = "txtIDCobradorC"
        Me.txtIDCobradorC.ReadOnly = True
        Me.txtIDCobradorC.Size = New System.Drawing.Size(49, 16)
        Me.txtIDCobradorC.TabIndex = 306
        Me.txtIDCobradorC.TabStop = False
        '
        'txtCobradorC
        '
        Me.txtCobradorC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobradorC.BackColor = System.Drawing.SystemColors.Control
        Me.txtCobradorC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobradorC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobradorC.Location = New System.Drawing.Point(431, 107)
        Me.txtCobradorC.Name = "txtCobradorC"
        Me.txtCobradorC.ReadOnly = True
        Me.txtCobradorC.Size = New System.Drawing.Size(329, 16)
        Me.txtCobradorC.TabIndex = 304
        Me.txtCobradorC.TabStop = False
        '
        'txtCalificacion
        '
        Me.txtCalificacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(676, 51)
        Me.txtCalificacion.Multiline = True
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(71, 47)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.BackColor = System.Drawing.SystemColors.Control
        Me.txtUltimoPago.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(241, 116)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(147, 20)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(154, 120)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(67, 13)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Último Pago"
        '
        'PicCliente
        '
        Me.PicCliente.BackgroundImage = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicCliente.Controls.Add(Me.SimilarFindButton)
        Me.PicCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicCliente.Location = New System.Drawing.Point(18, 26)
        Me.PicCliente.Name = "PicCliente"
        Me.PicCliente.Size = New System.Drawing.Size(125, 125)
        Me.PicCliente.TabIndex = 312
        '
        'SimilarFindButton
        '
        Me.SimilarFindButton.BackColor = System.Drawing.Color.Transparent
        Me.SimilarFindButton.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.SimilarFindButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimilarFindButton.Location = New System.Drawing.Point(93, 92)
        Me.SimilarFindButton.Name = "SimilarFindButton"
        Me.SimilarFindButton.Size = New System.Drawing.Size(32, 32)
        Me.SimilarFindButton.TabIndex = 10
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(154, 90)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(84, 13)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Balance General"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(154, 26)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(45, 13)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtIDCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDCliente.Location = New System.Drawing.Point(154, 71)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(65, 16)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(154, 42)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(461, 29)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        Me.txtNombre.Text = "No hay un cliente seleccionado"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Location = New System.Drawing.Point(610, 55)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(0, 0)
        Me.btnBuscarCliente.TabIndex = 313
        Me.btnBuscarCliente.Text = "Button1"
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'cbxNoEntrega
        '
        Me.cbxNoEntrega.DropDownHeight = 105
        Me.cbxNoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNoEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNoEntrega.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxNoEntrega.ForeColor = System.Drawing.Color.Black
        Me.cbxNoEntrega.FormattingEnabled = True
        Me.cbxNoEntrega.IntegralHeight = False
        Me.cbxNoEntrega.Location = New System.Drawing.Point(144, 55)
        Me.cbxNoEntrega.Name = "cbxNoEntrega"
        Me.cbxNoEntrega.Size = New System.Drawing.Size(205, 38)
        Me.cbxNoEntrega.TabIndex = 0
        '
        'cbxNoRecibo
        '
        Me.cbxNoRecibo.DropDownHeight = 105
        Me.cbxNoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxNoRecibo.ForeColor = System.Drawing.Color.Black
        Me.cbxNoRecibo.FormattingEnabled = True
        Me.cbxNoRecibo.IntegralHeight = False
        Me.cbxNoRecibo.ItemHeight = 15
        Me.cbxNoRecibo.Location = New System.Drawing.Point(75, 24)
        Me.cbxNoRecibo.Name = "cbxNoRecibo"
        Me.cbxNoRecibo.Size = New System.Drawing.Size(152, 23)
        Me.cbxNoRecibo.TabIndex = 3
        '
        'lblIDRecibo
        '
        Me.lblIDRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIDRecibo.ForeColor = System.Drawing.Color.Black
        Me.lblIDRecibo.Location = New System.Drawing.Point(72, 50)
        Me.lblIDRecibo.Name = "lblIDRecibo"
        Me.lblIDRecibo.Size = New System.Drawing.Size(123, 13)
        Me.lblIDRecibo.TabIndex = 309
        Me.lblIDRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDEntrega
        '
        Me.lblIDEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblIDEntrega.Location = New System.Drawing.Point(642, 22)
        Me.lblIDEntrega.Name = "lblIDEntrega"
        Me.lblIDEntrega.Size = New System.Drawing.Size(82, 13)
        Me.lblIDEntrega.TabIndex = 308
        Me.lblIDEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(603, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 302
        Me.Label5.Text = "Monto"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoTotal.Enabled = False
        Me.txtMontoTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoTotal.ForeColor = System.Drawing.Color.Black
        Me.txtMontoTotal.Location = New System.Drawing.Point(652, 24)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.Size = New System.Drawing.Size(151, 23)
        Me.txtMontoTotal.TabIndex = 6
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 307
        Me.Label8.Text = "No. Recibo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 21)
        Me.Label7.TabIndex = 306
        Me.Label7.Text = "No. Entrega"
        '
        'labeltipo
        '
        Me.labeltipo.AutoSize = True
        Me.labeltipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.labeltipo.ForeColor = System.Drawing.Color.Black
        Me.labeltipo.Location = New System.Drawing.Point(384, 29)
        Me.labeltipo.Name = "labeltipo"
        Me.labeltipo.Size = New System.Drawing.Size(30, 15)
        Me.labeltipo.TabIndex = 304
        Me.labeltipo.Text = "Tipo"
        '
        'cbxTipoRecibo
        '
        Me.cbxTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoRecibo.ForeColor = System.Drawing.Color.Black
        Me.cbxTipoRecibo.FormattingEnabled = True
        Me.cbxTipoRecibo.Location = New System.Drawing.Point(421, 24)
        Me.cbxTipoRecibo.Name = "cbxTipoRecibo"
        Me.cbxTipoRecibo.Size = New System.Drawing.Size(176, 23)
        Me.cbxTipoRecibo.TabIndex = 5
        '
        'DtpFechaRecibo
        '
        Me.DtpFechaRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaRecibo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaRecibo.Location = New System.Drawing.Point(274, 24)
        Me.DtpFechaRecibo.Name = "DtpFechaRecibo"
        Me.DtpFechaRecibo.Size = New System.Drawing.Size(104, 23)
        Me.DtpFechaRecibo.TabIndex = 4
        '
        'labelFecha
        '
        Me.labelFecha.AutoSize = True
        Me.labelFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.labelFecha.ForeColor = System.Drawing.Color.Black
        Me.labelFecha.Location = New System.Drawing.Point(230, 29)
        Me.labelFecha.Name = "labelFecha"
        Me.labelFecha.Size = New System.Drawing.Size(38, 15)
        Me.labelFecha.TabIndex = 300
        Me.labelFecha.Text = "Fecha"
        '
        'DgvDetalleRecibos
        '
        Me.DgvDetalleRecibos.AllowUserToAddRows = False
        Me.DgvDetalleRecibos.AllowUserToDeleteRows = False
        Me.DgvDetalleRecibos.AllowUserToResizeColumns = False
        Me.DgvDetalleRecibos.AllowUserToResizeRows = False
        Me.DgvDetalleRecibos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvDetalleRecibos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvDetalleRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvDetalleRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalleRecibos.GridColor = System.Drawing.SystemColors.MenuHighlight
        Me.DgvDetalleRecibos.Location = New System.Drawing.Point(14, 55)
        Me.DgvDetalleRecibos.MultiSelect = False
        Me.DgvDetalleRecibos.Name = "DgvDetalleRecibos"
        Me.DgvDetalleRecibos.ReadOnly = True
        Me.DgvDetalleRecibos.RowHeadersVisible = False
        Me.DgvDetalleRecibos.RowHeadersWidth = 30
        Me.DgvDetalleRecibos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvDetalleRecibos.RowTemplate.Height = 36
        Me.DgvDetalleRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalleRecibos.Size = New System.Drawing.Size(1170, 261)
        Me.DgvDetalleRecibos.TabIndex = 300
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.txtIDCobrador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCobrador.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtIDCobrador.Location = New System.Drawing.Point(545, 396)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.ReadOnly = True
        Me.txtIDCobrador.Size = New System.Drawing.Size(67, 16)
        Me.txtIDCobrador.TabIndex = 325
        Me.txtIDCobrador.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(545, 361)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(99, 13)
        Me.Label28.TabIndex = 324
        Me.Label28.Text = "Cobrador Asignado"
        '
        'txtCobrador
        '
        Me.txtCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.txtCobrador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(545, 378)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(366, 16)
        Me.txtCobrador.TabIndex = 323
        Me.txtCobrador.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label17.Location = New System.Drawing.Point(545, 419)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 322
        Me.Label17.Text = "Status"
        '
        'txtPagareStatus
        '
        Me.txtPagareStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtPagareStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPagareStatus.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.txtPagareStatus.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPagareStatus.Location = New System.Drawing.Point(545, 432)
        Me.txtPagareStatus.Name = "txtPagareStatus"
        Me.txtPagareStatus.ReadOnly = True
        Me.txtPagareStatus.Size = New System.Drawing.Size(365, 29)
        Me.txtPagareStatus.TabIndex = 321
        Me.txtPagareStatus.TabStop = False
        '
        'txtDiasVenc
        '
        Me.txtDiasVenc.BackColor = System.Drawing.SystemColors.Control
        Me.txtDiasVenc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDiasVenc.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtDiasVenc.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtDiasVenc.Location = New System.Drawing.Point(456, 383)
        Me.txtDiasVenc.Name = "txtDiasVenc"
        Me.txtDiasVenc.ReadOnly = True
        Me.txtDiasVenc.Size = New System.Drawing.Size(63, 28)
        Me.txtDiasVenc.TabIndex = 319
        Me.txtDiasVenc.TabStop = False
        Me.txtDiasVenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label15.Location = New System.Drawing.Point(6, 365)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 318
        Me.Label15.Text = "Monto"
        '
        'txtMontoPagare
        '
        Me.txtMontoPagare.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoPagare.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMontoPagare.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoPagare.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtMontoPagare.Location = New System.Drawing.Point(9, 383)
        Me.txtMontoPagare.Name = "txtMontoPagare"
        Me.txtMontoPagare.ReadOnly = True
        Me.txtMontoPagare.Size = New System.Drawing.Size(150, 28)
        Me.txtMontoPagare.TabIndex = 317
        Me.txtMontoPagare.TabStop = False
        '
        'txtFechaVenc
        '
        Me.txtFechaVenc.BackColor = System.Drawing.SystemColors.Control
        Me.txtFechaVenc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaVenc.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtFechaVenc.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtFechaVenc.Location = New System.Drawing.Point(315, 383)
        Me.txtFechaVenc.Name = "txtFechaVenc"
        Me.txtFechaVenc.ReadOnly = True
        Me.txtFechaVenc.Size = New System.Drawing.Size(135, 28)
        Me.txtFechaVenc.TabIndex = 315
        Me.txtFechaVenc.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(165, 365)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 15)
        Me.Label13.TabIndex = 314
        Me.Label13.Text = "Balance actual"
        '
        'txtBalancePagare
        '
        Me.txtBalancePagare.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalancePagare.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalancePagare.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtBalancePagare.ForeColor = System.Drawing.Color.Blue
        Me.txtBalancePagare.Location = New System.Drawing.Point(165, 383)
        Me.txtBalancePagare.Name = "txtBalancePagare"
        Me.txtBalancePagare.ReadOnly = True
        Me.txtBalancePagare.Size = New System.Drawing.Size(150, 28)
        Me.txtBalancePagare.TabIndex = 313
        Me.txtBalancePagare.TabStop = False
        '
        'lblIDFactura
        '
        Me.lblIDFactura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblIDFactura.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIDFactura.Location = New System.Drawing.Point(86, 11)
        Me.lblIDFactura.Name = "lblIDFactura"
        Me.lblIDFactura.Size = New System.Drawing.Size(65, 13)
        Me.lblIDFactura.TabIndex = 320
        Me.lblIDFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(841, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 319
        Me.Label1.Text = "Comisión"
        '
        'txtComision
        '
        Me.txtComision.Enabled = False
        Me.txtComision.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtComision.Location = New System.Drawing.Point(844, 28)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(131, 20)
        Me.txtComision.TabIndex = 13
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnInsertDetalle
        '
        Me.btnInsertDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInsertDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnInsertDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertDetalle.Location = New System.Drawing.Point(981, 25)
        Me.btnInsertDetalle.Name = "btnInsertDetalle"
        Me.btnInsertDetalle.Size = New System.Drawing.Size(83, 24)
        Me.btnInsertDetalle.TabIndex = 13
        Me.btnInsertDetalle.Text = "Anexar"
        Me.btnInsertDetalle.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(604, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 13)
        Me.Label12.TabIndex = 316
        Me.Label12.Text = "Tipo de Comisión"
        '
        'CbxTipoComision
        '
        Me.CbxTipoComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxTipoComision.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxTipoComision.FormattingEnabled = True
        Me.CbxTipoComision.Location = New System.Drawing.Point(607, 27)
        Me.CbxTipoComision.Name = "CbxTipoComision"
        Me.CbxTipoComision.Size = New System.Drawing.Size(231, 21)
        Me.CbxTipoComision.TabIndex = 12
        '
        'CbxFactura
        '
        Me.CbxFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFactura.Enabled = False
        Me.CbxFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFactura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxFactura.FormattingEnabled = True
        Me.CbxFactura.Location = New System.Drawing.Point(13, 27)
        Me.CbxFactura.Name = "CbxFactura"
        Me.CbxFactura.Size = New System.Drawing.Size(138, 21)
        Me.CbxFactura.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(278, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 314
        Me.Label11.Text = "Débito"
        '
        'CbxNoPagare
        '
        Me.CbxNoPagare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxNoPagare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxNoPagare.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxNoPagare.FormattingEnabled = True
        Me.CbxNoPagare.Location = New System.Drawing.Point(158, 27)
        Me.CbxNoPagare.Name = "CbxNoPagare"
        Me.CbxNoPagare.Size = New System.Drawing.Size(115, 21)
        Me.CbxNoPagare.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(392, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 313
        Me.Label6.Text = "Descuento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(12, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "No. Factura"
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescuento.Location = New System.Drawing.Point(395, 28)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuento.TabIndex = 10
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(155, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 308
        Me.Label4.Text = "No. Pagaré"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtMonto.Location = New System.Drawing.Point(279, 28)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(110, 20)
        Me.txtMonto.TabIndex = 9
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblIDPagare
        '
        Me.lblIDPagare.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblIDPagare.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblIDPagare.Location = New System.Drawing.Point(226, 11)
        Me.lblIDPagare.Name = "lblIDPagare"
        Me.lblIDPagare.Size = New System.Drawing.Size(47, 13)
        Me.lblIDPagare.TabIndex = 310
        Me.lblIDPagare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraOpciones
        '
        Me.BarraOpciones.AutoSize = False
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.None
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblIDDetalle, Me.ToolStripSeparator2, Me.btnQuitarArticulo, Me.lblCountRows})
        Me.BarraOpciones.Location = New System.Drawing.Point(1, 319)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraOpciones.Size = New System.Drawing.Size(1190, 35)
        Me.BarraOpciones.TabIndex = 302
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(130, 32)
        Me.ToolStripLabel1.Text = "Código de Transacción:"
        '
        'lblIDDetalle
        '
        Me.lblIDDetalle.Name = "lblIDDetalle"
        Me.lblIDDetalle.Size = New System.Drawing.Size(0, 32)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'btnQuitarArticulo
        '
        Me.btnQuitarArticulo.Image = Global.Libregco.My.Resources.Resources.Minusx24
        Me.btnQuitarArticulo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnQuitarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarArticulo.Name = "btnQuitarArticulo"
        Me.btnQuitarArticulo.Size = New System.Drawing.Size(94, 32)
        Me.btnQuitarArticulo.Text = "F2 - Quitar "
        '
        'lblCountRows
        '
        Me.lblCountRows.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCountRows.Name = "lblCountRows"
        Me.lblCountRows.Size = New System.Drawing.Size(0, 32)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(3, 451)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(192, 15)
        Me.Label18.TabIndex = 316
        Me.Label18.Text = "Escribas las observaciones del pago"
        '
        'txtNota
        '
        Me.txtNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNota.Location = New System.Drawing.Point(6, 469)
        Me.txtNota.Multiline = True
        Me.txtNota.Name = "txtNota"
        Me.txtNota.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNota.Size = New System.Drawing.Size(904, 39)
        Me.txtNota.TabIndex = 13
        Me.txtNota.Tag = "14"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(11, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 317
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 704)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1221, 25)
        Me.BarraEstado.TabIndex = 416
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = Global.Libregco.My.Resources.Resources.Loading
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
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(871, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(352, 99)
        Me.IconPanel.TabIndex = 417
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.GuardarToolStripMenuItem, Me.btnBuscarHistorial, Me.btnAnular})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(352, 99)
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
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
        Me.GuardarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.GuardarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        Me.GuardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(216, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnBuscarHistorial
        '
        Me.btnBuscarHistorial.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnBuscarHistorial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarHistorial.Name = "btnBuscarHistorial"
        Me.btnBuscarHistorial.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscarHistorial.Text = "Imprimir"
        Me.btnBuscarHistorial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'btnConsultarEntrega
        '
        Me.btnConsultarEntrega.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultarEntrega.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConsultarEntrega.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultarEntrega.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btnConsultarEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultarEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarEntrega.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnConsultarEntrega.Location = New System.Drawing.Point(235, 94)
        Me.btnConsultarEntrega.Name = "btnConsultarEntrega"
        Me.btnConsultarEntrega.Size = New System.Drawing.Size(114, 25)
        Me.btnConsultarEntrega.TabIndex = 8
        Me.btnConsultarEntrega.Text = "Consultar Entrega"
        Me.btnConsultarEntrega.UseVisualStyleBackColor = False
        '
        'lblDescripcionEntrega
        '
        Me.lblDescripcionEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblDescripcionEntrega.Location = New System.Drawing.Point(144, 266)
        Me.lblDescripcionEntrega.Name = "lblDescripcionEntrega"
        Me.lblDescripcionEntrega.Size = New System.Drawing.Size(208, 36)
        Me.lblDescripcionEntrega.TabIndex = 322
        '
        'lblComisionEntrega
        '
        Me.lblComisionEntrega.AutoSize = True
        Me.lblComisionEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComisionEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblComisionEntrega.Location = New System.Drawing.Point(144, 241)
        Me.lblComisionEntrega.Name = "lblComisionEntrega"
        Me.lblComisionEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblComisionEntrega.TabIndex = 321
        '
        'lblRangoEntrega
        '
        Me.lblRangoEntrega.AutoSize = True
        Me.lblRangoEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRangoEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblRangoEntrega.Location = New System.Drawing.Point(144, 216)
        Me.lblRangoEntrega.Name = "lblRangoEntrega"
        Me.lblRangoEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblRangoEntrega.TabIndex = 320
        '
        'lblCantidadEntrega
        '
        Me.lblCantidadEntrega.AutoSize = True
        Me.lblCantidadEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadEntrega.Location = New System.Drawing.Point(144, 191)
        Me.lblCantidadEntrega.Name = "lblCantidadEntrega"
        Me.lblCantidadEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblCantidadEntrega.TabIndex = 319
        '
        'lblUsuarioEntrega
        '
        Me.lblUsuarioEntrega.AutoSize = True
        Me.lblUsuarioEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioEntrega.Location = New System.Drawing.Point(144, 166)
        Me.lblUsuarioEntrega.Name = "lblUsuarioEntrega"
        Me.lblUsuarioEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblUsuarioEntrega.TabIndex = 318
        '
        'lblCobradorEntrega
        '
        Me.lblCobradorEntrega.AutoSize = True
        Me.lblCobradorEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobradorEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblCobradorEntrega.Location = New System.Drawing.Point(144, 141)
        Me.lblCobradorEntrega.Name = "lblCobradorEntrega"
        Me.lblCobradorEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblCobradorEntrega.TabIndex = 317
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblFechaEntrega.Location = New System.Drawing.Point(144, 116)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(0, 15)
        Me.lblFechaEntrega.TabIndex = 316
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(9, 166)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 15)
        Me.Label27.TabIndex = 315
        Me.Label27.Text = "Usuario"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(9, 266)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 15)
        Me.Label26.TabIndex = 314
        Me.Label26.Text = "Descripción"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(9, 241)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(110, 15)
        Me.Label25.TabIndex = 313
        Me.Label25.Text = "Comisión Obtenida"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(9, 216)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(41, 15)
        Me.Label24.TabIndex = 312
        Me.Label24.Text = "Rango"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(9, 191)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 15)
        Me.Label23.TabIndex = 311
        Me.Label23.Text = "Cantidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(9, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 15)
        Me.Label10.TabIndex = 310
        Me.Label10.Text = "Cobrador"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 309
        Me.Label9.Text = "Fecha de Entrega"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 44)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(42, 15)
        Me.LinkLabel1.TabIndex = 324
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Nuevo"
        Me.LinkLabel1.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic)
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label31.Location = New System.Drawing.Point(3, 3)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 13)
        Me.Label31.TabIndex = 418
        Me.Label31.Text = "Datos del cliente"
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalanceGral.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtBalanceGral.ForeColor = System.Drawing.Color.Red
        Me.txtBalanceGral.Location = New System.Drawing.Point(241, 82)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(173, 28)
        Me.txtBalanceGral.TabIndex = 419
        Me.txtBalanceGral.TabStop = False
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label30.Location = New System.Drawing.Point(766, 34)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(1, 105)
        Me.Label30.TabIndex = 420
        '
        'lblCheckNotaDescuento
        '
        Me.lblCheckNotaDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.lblCheckNotaDescuento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCheckNotaDescuento.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblCheckNotaDescuento.Location = New System.Drawing.Point(773, 90)
        Me.lblCheckNotaDescuento.Name = "lblCheckNotaDescuento"
        Me.lblCheckNotaDescuento.Size = New System.Drawing.Size(377, 49)
        Me.lblCheckNotaDescuento.TabIndex = 421
        Me.lblCheckNotaDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(312, 365)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(120, 15)
        Me.Label34.TabIndex = 424
        Me.Label34.Text = "Fecha de vencimiento"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label14.Location = New System.Drawing.Point(51, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(0, 17)
        Me.Label14.TabIndex = 425
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label16.Location = New System.Drawing.Point(538, 365)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(1, 90)
        Me.Label16.TabIndex = 426
        '
        'DgvAuditoria
        '
        Me.DgvAuditoria.AllowUserToAddRows = False
        Me.DgvAuditoria.AllowUserToDeleteRows = False
        Me.DgvAuditoria.AllowUserToResizeColumns = False
        Me.DgvAuditoria.AllowUserToResizeRows = False
        Me.DgvAuditoria.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAuditoria.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAuditoria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDReciboAuditoria, Me.IDReciboCobro, Me.ReciboSecondID, Me.FechaReciboAuditoria, Me.TotalRecibo, Me.ConceptoRecibo, Me.IDAbono})
        Me.DgvAuditoria.GridColor = System.Drawing.SystemColors.MenuHighlight
        Me.DgvAuditoria.Location = New System.Drawing.Point(36, 50)
        Me.DgvAuditoria.MultiSelect = False
        Me.DgvAuditoria.Name = "DgvAuditoria"
        Me.DgvAuditoria.ReadOnly = True
        Me.DgvAuditoria.RowHeadersVisible = False
        Me.DgvAuditoria.RowHeadersWidth = 30
        Me.DgvAuditoria.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvAuditoria.RowTemplate.Height = 32
        Me.DgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAuditoria.Size = New System.Drawing.Size(1151, 371)
        Me.DgvAuditoria.TabIndex = 427
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(3, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 25)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(11, 153)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1198, 548)
        Me.TabControl1.TabIndex = 430
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Chart2)
        Me.TabPage1.Controls.Add(Me.lblAnular)
        Me.TabPage1.Controls.Add(Me.Label32)
        Me.TabPage1.Controls.Add(Me.Label36)
        Me.TabPage1.Controls.Add(Me.Label35)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.btnConsultarEntrega)
        Me.TabPage1.Controls.Add(Me.DgvRecibos)
        Me.TabPage1.Controls.Add(Me.lblDescripcionEntrega)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.lblComisionEntrega)
        Me.TabPage1.Controls.Add(Me.cbxNoEntrega)
        Me.TabPage1.Controls.Add(Me.lblRangoEntrega)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lblCantidadEntrega)
        Me.TabPage1.Controls.Add(Me.lblIDEntrega)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.lblUsuarioEntrega)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.lblCobradorEntrega)
        Me.TabPage1.Controls.Add(Me.lblFechaEntrega)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1190, 517)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Selección de entrega y recibo de cobro"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdbMonto)
        Me.GroupBox3.Controls.Add(Me.rdbCantidad)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(202, 477)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(157, 37)
        Me.GroupBox3.TabIndex = 348
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consulta de recibos"
        '
        'rdbMonto
        '
        Me.rdbMonto.AutoSize = True
        Me.rdbMonto.Checked = True
        Me.rdbMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbMonto.Location = New System.Drawing.Point(9, 15)
        Me.rdbMonto.Name = "rdbMonto"
        Me.rdbMonto.Size = New System.Drawing.Size(61, 19)
        Me.rdbMonto.TabIndex = 2
        Me.rdbMonto.TabStop = True
        Me.rdbMonto.Text = "Monto"
        Me.rdbMonto.UseVisualStyleBackColor = True
        '
        'rdbCantidad
        '
        Me.rdbCantidad.AutoSize = True
        Me.rdbCantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbCantidad.Location = New System.Drawing.Point(76, 15)
        Me.rdbCantidad.Name = "rdbCantidad"
        Me.rdbCantidad.Size = New System.Drawing.Size(73, 19)
        Me.rdbCantidad.TabIndex = 0
        Me.rdbCantidad.Text = "Cantidad"
        Me.rdbCantidad.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.SystemColors.Control
        ChartArea5.BackColor = System.Drawing.SystemColors.Control
        ChartArea5.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea5)
        Legend5.Alignment = System.Drawing.StringAlignment.Center
        Legend5.BackColor = System.Drawing.SystemColors.Control
        Legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend5.ItemColumnSpacing = 0
        Legend5.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend5)
        Me.Chart2.Location = New System.Drawing.Point(0, 308)
        Me.Chart2.Name = "Chart2"
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series7.IsValueShownAsLabel = True
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Me.Chart2.Series.Add(Series7)
        Me.Chart2.Size = New System.Drawing.Size(359, 163)
        Me.Chart2.TabIndex = 347
        Me.Chart2.Text = "Chart2"
        Title3.Name = "Title1"
        Title3.Text = "Clasificación de recibos por montos"
        Me.Chart2.Titles.Add(Title3)
        '
        'lblAnular
        '
        Me.lblAnular.AutoSize = True
        Me.lblAnular.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAnular.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAnular.ForeColor = System.Drawing.Color.Black
        Me.lblAnular.LinkColor = System.Drawing.Color.Firebrick
        Me.lblAnular.Location = New System.Drawing.Point(373, 495)
        Me.lblAnular.Name = "lblAnular"
        Me.lblAnular.Size = New System.Drawing.Size(42, 15)
        Me.lblAnular.TabIndex = 325
        Me.lblAnular.TabStop = True
        Me.lblAnular.Text = "Anular"
        Me.lblAnular.Visible = False
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.LightGray
        Me.Label32.Location = New System.Drawing.Point(365, 1)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(2, 515)
        Me.Label32.TabIndex = 346
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label36.Location = New System.Drawing.Point(3, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(211, 15)
        Me.Label36.TabIndex = 345
        Me.Label36.Text = "Selección de Entrega y recibo de cobro"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label35.Location = New System.Drawing.Point(6, 3)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(106, 25)
        Me.Label35.TabIndex = 344
        Me.Label35.Text = "Paso No. 1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1001, 469)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(183, 41)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Continuar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.cbxTipoRecibo)
        Me.GroupBox1.Controls.Add(Me.labeltipo)
        Me.GroupBox1.Controls.Add(Me.lblIDRecibo)
        Me.GroupBox1.Controls.Add(Me.cbxNoRecibo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DtpFechaRecibo)
        Me.GroupBox1.Controls.Add(Me.txtMontoTotal)
        Me.GroupBox1.Controls.Add(Me.labelFecha)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(375, 389)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(809, 75)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el número de recibo"
        '
        'DgvRecibos
        '
        Me.DgvRecibos.AllowUserToAddRows = False
        Me.DgvRecibos.AllowUserToDeleteRows = False
        Me.DgvRecibos.AllowUserToResizeColumns = False
        Me.DgvRecibos.AllowUserToResizeRows = False
        Me.DgvRecibos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvRecibos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvRecibos.ColumnHeadersHeight = 30
        Me.DgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvRecibos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.PreRecibo, Me.NoRecibo, Me.FechaRecibo, Me.IDTipoRecibo, Me.TipoRecibo, Me.Comentario, Me.Monto, Me.Format})
        Me.DgvRecibos.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvRecibos.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvRecibos.Location = New System.Drawing.Point(375, 6)
        Me.DgvRecibos.MultiSelect = False
        Me.DgvRecibos.Name = "DgvRecibos"
        Me.DgvRecibos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvRecibos.RowHeadersVisible = False
        Me.DgvRecibos.RowHeadersWidth = 25
        Me.DgvRecibos.RowTemplate.Height = 45
        Me.DgvRecibos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecibos.Size = New System.Drawing.Size(809, 377)
        Me.DgvRecibos.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Controls.Add(Me.Label38)
        Me.TabPage3.Controls.Add(Me.PicCliente)
        Me.TabPage3.Controls.Add(Me.txtNombre)
        Me.TabPage3.Controls.Add(Me.txtIDCliente)
        Me.TabPage3.Controls.Add(Me.nombre_label)
        Me.TabPage3.Controls.Add(Me.label20)
        Me.TabPage3.Controls.Add(Me.label21)
        Me.TabPage3.Controls.Add(Me.txtUltimoPago)
        Me.TabPage3.Controls.Add(Me.btnBuscarCliente)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.txtCobradorC)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.txtIDCobradorC)
        Me.TabPage3.Controls.Add(Me.lblCheckNotaDescuento)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.lblEstadoCobrador)
        Me.TabPage3.Controls.Add(Me.txtCalificacion)
        Me.TabPage3.Controls.Add(Me.Label29)
        Me.TabPage3.Controls.Add(Me.Label30)
        Me.TabPage3.Controls.Add(Me.txtBalanceGral)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.Chart1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1190, 517)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Selección de cliente"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1062, 473)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(125, 41)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Continuar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label37.Location = New System.Drawing.Point(1073, 28)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(114, 15)
        Me.Label37.TabIndex = 424
        Me.Label37.Text = "Selección del cliente"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.Location = New System.Drawing.Point(1081, 3)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(106, 25)
        Me.Label38.TabIndex = 423
        Me.Label38.Text = "Paso No. 2"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.SystemColors.Control
        ChartArea6.AxisX.LabelStyle.Format = "MM/yy"
        ChartArea6.AxisY.LabelStyle.Format = "C"
        ChartArea6.AxisY2.LabelStyle.Format = "C"
        ChartArea6.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea6)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend6.Alignment = System.Drawing.StringAlignment.Center
        Legend6.BorderColor = System.Drawing.SystemColors.Control
        Legend6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend6.Name = "Legend1"
        Legend6.TitleBackColor = System.Drawing.SystemColors.Control
        Me.Chart1.Legends.Add(Legend6)
        Me.Chart1.Location = New System.Drawing.Point(0, 157)
        Me.Chart1.Name = "Chart1"
        Series8.BorderWidth = 3
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series8.IsValueShownAsLabel = True
        Series8.LabelFormat = "C"
        Series8.Legend = "Legend1"
        Series8.Name = "Pagos"
        Series9.BorderWidth = 3
        Series9.ChartArea = "ChartArea1"
        Series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series9.IsValueShownAsLabel = True
        Series9.LabelFormat = "C"
        Series9.Legend = "Legend1"
        Series9.Name = "Compromisos"
        Me.Chart1.Series.Add(Series8)
        Me.Chart1.Series.Add(Series9)
        Me.Chart1.Size = New System.Drawing.Size(1190, 360)
        Me.Chart1.TabIndex = 426
        Me.Chart1.Text = "Chart1"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.txtCargos)
        Me.TabPage6.Controls.Add(Me.Label52)
        Me.TabPage6.Controls.Add(Me.Button4)
        Me.TabPage6.Controls.Add(Me.Label39)
        Me.TabPage6.Controls.Add(Me.Label40)
        Me.TabPage6.Controls.Add(Me.Label3)
        Me.TabPage6.Controls.Add(Me.Label16)
        Me.TabPage6.Controls.Add(Me.Label4)
        Me.TabPage6.Controls.Add(Me.btnInsertDetalle)
        Me.TabPage6.Controls.Add(Me.txtPagareStatus)
        Me.TabPage6.Controls.Add(Me.txtMonto)
        Me.TabPage6.Controls.Add(Me.Label17)
        Me.TabPage6.Controls.Add(Me.txtDescuento)
        Me.TabPage6.Controls.Add(Me.txtIDCobrador)
        Me.TabPage6.Controls.Add(Me.lblIDPagare)
        Me.TabPage6.Controls.Add(Me.Label6)
        Me.TabPage6.Controls.Add(Me.txtCobrador)
        Me.TabPage6.Controls.Add(Me.CbxNoPagare)
        Me.TabPage6.Controls.Add(Me.Label28)
        Me.TabPage6.Controls.Add(Me.Label11)
        Me.TabPage6.Controls.Add(Me.Label34)
        Me.TabPage6.Controls.Add(Me.CbxFactura)
        Me.TabPage6.Controls.Add(Me.CbxTipoComision)
        Me.TabPage6.Controls.Add(Me.Label12)
        Me.TabPage6.Controls.Add(Me.txtDiasVenc)
        Me.TabPage6.Controls.Add(Me.DgvDetalleRecibos)
        Me.TabPage6.Controls.Add(Me.txtFechaVenc)
        Me.TabPage6.Controls.Add(Me.txtComision)
        Me.TabPage6.Controls.Add(Me.txtMontoPagare)
        Me.TabPage6.Controls.Add(Me.Label1)
        Me.TabPage6.Controls.Add(Me.txtBalancePagare)
        Me.TabPage6.Controls.Add(Me.lblIDFactura)
        Me.TabPage6.Controls.Add(Me.Label13)
        Me.TabPage6.Controls.Add(Me.BarraOpciones)
        Me.TabPage6.Controls.Add(Me.Label15)
        Me.TabPage6.Controls.Add(Me.txtNota)
        Me.TabPage6.Controls.Add(Me.Label18)
        Me.TabPage6.Location = New System.Drawing.Point(4, 27)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1190, 517)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Aplicación de pagos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'txtCargos
        '
        Me.txtCargos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCargos.Location = New System.Drawing.Point(501, 28)
        Me.txtCargos.Name = "txtCargos"
        Me.txtCargos.Size = New System.Drawing.Size(100, 20)
        Me.txtCargos.TabIndex = 11
        Me.txtCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label52.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label52.Location = New System.Drawing.Point(498, 10)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(41, 13)
        Me.Label52.TabIndex = 430
        Me.Label52.Text = "Cargos"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1031, 470)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(153, 41)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Continuar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label39.Location = New System.Drawing.Point(1070, 28)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(114, 15)
        Me.Label39.TabIndex = 428
        Me.Label39.Text = "Aplicación de pagos"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label40.Location = New System.Drawing.Point(1078, 3)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(106, 25)
        Me.Label40.TabIndex = 427
        Me.Label40.Text = "Paso No. 3"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button5)
        Me.TabPage4.Controls.Add(Me.lblMensajeAuditor)
        Me.TabPage4.Controls.Add(Me.Label51)
        Me.TabPage4.Controls.Add(Me.txtMontoRecibos)
        Me.TabPage4.Controls.Add(Me.Label41)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Controls.Add(Me.DgvAuditoria)
        Me.TabPage4.Location = New System.Drawing.Point(4, 27)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1190, 517)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Auditar recibo"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = Global.Libregco.My.Resources.Resources.Minusx24
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(36, 427)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(109, 27)
        Me.Button5.TabIndex = 434
        Me.Button5.Text = "Quitar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'lblMensajeAuditor
        '
        Me.lblMensajeAuditor.AutoSize = True
        Me.lblMensajeAuditor.Location = New System.Drawing.Point(33, 477)
        Me.lblMensajeAuditor.Name = "lblMensajeAuditor"
        Me.lblMensajeAuditor.Size = New System.Drawing.Size(173, 15)
        Me.lblMensajeAuditor.TabIndex = 433
        Me.lblMensajeAuditor.Text = "Este es el mensaje de auditoría.!"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(925, 434)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(70, 15)
        Me.Label51.TabIndex = 432
        Me.Label51.Text = "Monto total"
        '
        'txtMontoRecibos
        '
        Me.txtMontoRecibos.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoRecibos.Location = New System.Drawing.Point(1001, 427)
        Me.txtMontoRecibos.Name = "txtMontoRecibos"
        Me.txtMontoRecibos.ReadOnly = True
        Me.txtMontoRecibos.Size = New System.Drawing.Size(176, 27)
        Me.txtMontoRecibos.TabIndex = 431
        Me.txtMontoRecibos.Text = "RD$ 0.00"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label41.Location = New System.Drawing.Point(976, 32)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(212, 15)
        Me.Label41.TabIndex = 430
        Me.Label41.Text = "Auditoría y cierre de recibos de ingreso"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label42.Location = New System.Drawing.Point(1081, 5)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(106, 25)
        Me.Label42.TabIndex = 429
        Me.Label42.Text = "Paso No. 4"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.Label49)
        Me.GroupBox2.Controls.Add(Me.Label48)
        Me.GroupBox2.Controls.Add(Me.Label47)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.Label43)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(569, 120)
        Me.GroupBox2.TabIndex = 431
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resumen"
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label50.Location = New System.Drawing.Point(470, 37)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(94, 65)
        Me.Label50.TabIndex = 323
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(470, 16)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(50, 13)
        Me.Label49.TabIndex = 322
        Me.Label49.Text = "Auditoría"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label48.Location = New System.Drawing.Point(462, 13)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(2, 100)
        Me.Label48.TabIndex = 321
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.Label47.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label47.Location = New System.Drawing.Point(324, 37)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(0, 25)
        Me.Label47.TabIndex = 320
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label46.Location = New System.Drawing.Point(178, 34)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(0, 30)
        Me.Label46.TabIndex = 319
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label45.Location = New System.Drawing.Point(176, 65)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(0, 37)
        Me.Label45.TabIndex = 318
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(115, 75)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(40, 13)
        Me.Label44.TabIndex = 317
        Me.Label44.Text = "Monto:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(261, 44)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(61, 13)
        Me.Label43.TabIndex = 316
        Me.Label43.Text = "Recibo No:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(115, 44)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 13)
        Me.Label33.TabIndex = 315
        Me.Label33.Text = "Entrega No:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TextBox1.Location = New System.Drawing.Point(114, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(342, 22)
        Me.TextBox1.TabIndex = 314
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "No hay un cliente seleccionado"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Libregco.My.Resources.Resources.no_photo
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(8, 14)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 100)
        Me.Panel1.TabIndex = 313
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDReciboCobro"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Pre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "No. Recibo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "IDTipoRecibo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 120
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Comentario"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 300
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Monto"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 140
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Format"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "IDAuditoria"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "IDRecibo"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "No. Recibo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 120
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 180
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 180
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 470
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "IDAbono"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'PreRecibo
        '
        Me.PreRecibo.HeaderText = "Pre"
        Me.PreRecibo.Name = "PreRecibo"
        Me.PreRecibo.ReadOnly = True
        Me.PreRecibo.Width = 50
        '
        'NoRecibo
        '
        Me.NoRecibo.HeaderText = "No. Recibo"
        Me.NoRecibo.Name = "NoRecibo"
        Me.NoRecibo.ReadOnly = True
        '
        'FechaRecibo
        '
        Me.FechaRecibo.HeaderText = "Fecha"
        Me.FechaRecibo.Name = "FechaRecibo"
        Me.FechaRecibo.ReadOnly = True
        '
        'IDTipoRecibo
        '
        Me.IDTipoRecibo.HeaderText = "IDTipoRecibo"
        Me.IDTipoRecibo.Name = "IDTipoRecibo"
        Me.IDTipoRecibo.ReadOnly = True
        Me.IDTipoRecibo.Visible = False
        '
        'TipoRecibo
        '
        Me.TipoRecibo.HeaderText = "Tipo"
        Me.TipoRecibo.Name = "TipoRecibo"
        Me.TipoRecibo.ReadOnly = True
        Me.TipoRecibo.Width = 120
        '
        'Comentario
        '
        Me.Comentario.HeaderText = "Comentario"
        Me.Comentario.Name = "Comentario"
        Me.Comentario.ReadOnly = True
        Me.Comentario.Width = 300
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 140
        '
        'Format
        '
        Me.Format.HeaderText = "Format"
        Me.Format.Name = "Format"
        Me.Format.ReadOnly = True
        Me.Format.Visible = False
        '
        'IDReciboAuditoria
        '
        Me.IDReciboAuditoria.HeaderText = "IDAuditoria"
        Me.IDReciboAuditoria.Name = "IDReciboAuditoria"
        Me.IDReciboAuditoria.ReadOnly = True
        Me.IDReciboAuditoria.Visible = False
        '
        'IDReciboCobro
        '
        Me.IDReciboCobro.HeaderText = "IDRecibo"
        Me.IDReciboCobro.Name = "IDReciboCobro"
        Me.IDReciboCobro.ReadOnly = True
        Me.IDReciboCobro.Visible = False
        '
        'ReciboSecondID
        '
        Me.ReciboSecondID.HeaderText = "No. Recibo"
        Me.ReciboSecondID.Name = "ReciboSecondID"
        Me.ReciboSecondID.ReadOnly = True
        Me.ReciboSecondID.Width = 120
        '
        'FechaReciboAuditoria
        '
        Me.FechaReciboAuditoria.HeaderText = "Fecha"
        Me.FechaReciboAuditoria.Name = "FechaReciboAuditoria"
        Me.FechaReciboAuditoria.ReadOnly = True
        Me.FechaReciboAuditoria.Width = 180
        '
        'TotalRecibo
        '
        Me.TotalRecibo.HeaderText = "Total"
        Me.TotalRecibo.Name = "TotalRecibo"
        Me.TotalRecibo.ReadOnly = True
        Me.TotalRecibo.Width = 180
        '
        'ConceptoRecibo
        '
        Me.ConceptoRecibo.HeaderText = "Concepto"
        Me.ConceptoRecibo.Name = "ConceptoRecibo"
        Me.ConceptoRecibo.ReadOnly = True
        Me.ConceptoRecibo.Width = 470
        '
        'IDAbono
        '
        Me.IDAbono.HeaderText = "IDAbono"
        Me.IDAbono.Name = "IDAbono"
        Me.IDAbono.ReadOnly = True
        Me.IDAbono.Visible = False
        '
        'frm_registro_recibos_cobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1221, 729)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_registro_recibos_cobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Tag = "205"
        Me.Text = "Registro de cobros"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PicCliente.ResumeLayout(False)
        CType(Me.DgvDetalleRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.DgvAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents BuscarCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents cbxNoEntrega As System.Windows.Forms.ComboBox
    Friend WithEvents cbxNoRecibo As System.Windows.Forms.ComboBox
    Friend WithEvents labeltipo As System.Windows.Forms.Label
    Friend WithEvents cbxTipoRecibo As System.Windows.Forms.ComboBox
    Friend WithEvents txtMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents labelFecha As System.Windows.Forms.Label
    Friend WithEvents DtpFechaRecibo As System.Windows.Forms.DateTimePicker
    Friend WithEvents DgvDetalleRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCobradorC As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobradorC As System.Windows.Forms.TextBox
    Friend WithEvents BarraOpciones As System.Windows.Forms.ToolStrip
    Friend WithEvents lblIDRecibo As System.Windows.Forms.Label
    Friend WithEvents lblIDEntrega As System.Windows.Forms.Label
    Friend WithEvents lblIDPagare As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbxNoPagare As System.Windows.Forms.ComboBox
    Friend WithEvents CbxFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CbxTipoComision As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComision As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblIDDetalle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPagareStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasVenc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMontoPagare As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVenc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBalancePagare As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCountRows As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarHistorial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblDescripcionEntrega As System.Windows.Forms.Label
    Friend WithEvents lblComisionEntrega As System.Windows.Forms.Label
    Friend WithEvents lblRangoEntrega As System.Windows.Forms.Label
    Friend WithEvents lblCantidadEntrega As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioEntrega As System.Windows.Forms.Label
    Friend WithEvents lblCobradorEntrega As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnConsultarEntrega As System.Windows.Forms.Button
    Friend WithEvents btnInsertDetalle As System.Windows.Forms.Button
    Friend WithEvents lblEstadoCobrador As System.Windows.Forms.Label
    Friend WithEvents lblIDFactura As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobrador As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents PicCliente As System.Windows.Forms.Panel
    Friend WithEvents SimilarFindButton As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGral As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblCheckNotaDescuento As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DgvAuditoria As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DgvRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comentario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Format As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtMontoRecibos As System.Windows.Forms.TextBox
    Friend WithEvents lblMensajeAuditor As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents IDReciboAuditoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDReciboCobro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReciboSecondID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaReciboAuditoria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConceptoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAnular As System.Windows.Forms.LinkLabel
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbMonto As System.Windows.Forms.RadioButton
    Friend WithEvents rdbCantidad As System.Windows.Forms.RadioButton
    Friend WithEvents txtCargos As TextBox
    Friend WithEvents Label52 As Label
End Class
