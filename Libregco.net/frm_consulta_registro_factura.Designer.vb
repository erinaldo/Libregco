<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_registro_factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_registro_factura))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.chkNulos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarCons = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPresentar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStructure = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbGeneral = New System.Windows.Forms.RadioButton()
        Me.rdbEspecifico = New System.Windows.Forms.RadioButton()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnBuscarTipoMemo = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.DgvVentas = New System.Windows.Forms.DataGridView()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.DgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 335
        Me.Label7.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownHeight = 100
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.IntegralHeight = False
        Me.cbxCondicion.Location = New System.Drawing.Point(68, 26)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(119, 21)
        Me.cbxCondicion.TabIndex = 7
        '
        'chkNulos
        '
        Me.chkNulos.AutoSize = True
        Me.chkNulos.BackColor = System.Drawing.Color.Transparent
        Me.chkNulos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkNulos.Location = New System.Drawing.Point(123, 2)
        Me.chkNulos.Name = "chkNulos"
        Me.chkNulos.Size = New System.Drawing.Size(71, 17)
        Me.chkNulos.TabIndex = 6
        Me.chkNulos.Text = "Ver Nulos"
        Me.chkNulos.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 336
        Me.Label4.Text = "Vendedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(160, 56)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(350, 20)
        Me.txtVendedor.TabIndex = 335
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(75, 56)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(65, 20)
        Me.txtIDVendedor.TabIndex = 329
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 333
        Me.Label5.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCliente.Location = New System.Drawing.Point(160, 30)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(350, 20)
        Me.txtCliente.TabIndex = 332
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(75, 30)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(65, 20)
        Me.txtIDCliente.TabIndex = 327
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = ""
        Me.txtFechaFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinal.Location = New System.Drawing.Point(48, 58)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(96, 20)
        Me.txtFechaFinal.TabIndex = 340
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = ""
        Me.txtFechaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicial.Location = New System.Drawing.Point(48, 26)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(96, 20)
        Me.txtFechaInicial.TabIndex = 339
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(7, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Del"
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(5, 427)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(426, 71)
        Me.IconPanel.TabIndex = 345
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnBuscarCons, Me.btnPresentar, Me.btnModificar, Me.btnStructure})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(426, 71)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 67)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.Size = New System.Drawing.Size(60, 67)
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnPresentar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(68, 67)
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(70, 67)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStructure
        '
        Me.btnStructure.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.btnStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnStructure.Name = "btnStructure"
        Me.btnStructure.Size = New System.Drawing.Size(72, 67)
        Me.btnStructure.Text = "Estructura"
        Me.btnStructure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 574)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(897, 25)
        Me.BarraEstado.TabIndex = 347
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
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(397, 31)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(64, 17)
        Me.chkResumir.TabIndex = 350
        Me.chkResumir.Text = "Resumir"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(63, 38)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(328, 21)
        Me.CbxFormato.TabIndex = 348
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(8, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "Formato"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rdbGeneral)
        Me.Panel1.Controls.Add(Me.rdbEspecifico)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Panel1.Location = New System.Drawing.Point(318, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(149, 23)
        Me.Panel1.TabIndex = 347
        '
        'rdbGeneral
        '
        Me.rdbGeneral.AutoSize = True
        Me.rdbGeneral.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbGeneral.Location = New System.Drawing.Point(84, 2)
        Me.rdbGeneral.Name = "rdbGeneral"
        Me.rdbGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdbGeneral.TabIndex = 347
        Me.rdbGeneral.Text = "General"
        Me.rdbGeneral.UseVisualStyleBackColor = True
        '
        'rdbEspecifico
        '
        Me.rdbEspecifico.AutoSize = True
        Me.rdbEspecifico.Checked = True
        Me.rdbEspecifico.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbEspecifico.Location = New System.Drawing.Point(6, 2)
        Me.rdbEspecifico.Name = "rdbEspecifico"
        Me.rdbEspecifico.Size = New System.Drawing.Size(72, 17)
        Me.rdbEspecifico.TabIndex = 346
        Me.rdbEspecifico.TabStop = True
        Me.rdbEspecifico.Text = "Específico"
        Me.rdbEspecifico.UseVisualStyleBackColor = True
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnBuscarTipoMemo
        '
        Me.btnBuscarTipoMemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoMemo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoMemo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarTipoMemo.Image = CType(resources.GetObject("btnBuscarTipoMemo.Image"), System.Drawing.Image)
        Me.btnBuscarTipoMemo.Location = New System.Drawing.Point(139, 56)
        Me.btnBuscarTipoMemo.Name = "btnBuscarTipoMemo"
        Me.btnBuscarTipoMemo.Size = New System.Drawing.Size(23, 20)
        Me.btnBuscarTipoMemo.TabIndex = 330
        Me.btnBuscarTipoMemo.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(139, 30)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 20)
        Me.btnBuscarCliente.TabIndex = 328
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'GroupControl4
        '
        Me.GroupControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl4.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Outputx24
        Me.GroupControl4.Controls.Add(Me.rdbPresentacion)
        Me.GroupControl4.Controls.Add(Me.rdbImpresora)
        Me.GroupControl4.Controls.Add(Me.rdbExcel)
        Me.GroupControl4.Controls.Add(Me.rdbPDF)
        Me.GroupControl4.Location = New System.Drawing.Point(5, 501)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(518, 67)
        Me.GroupControl4.TabIndex = 417
        Me.GroupControl4.Text = "Tipos de salida"
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbPresentacion.Image = Global.Libregco.My.Resources.Resources.Documentx24
        Me.rdbPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbPresentacion.Location = New System.Drawing.Point(4, 25)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(125, 39)
        Me.rdbPresentacion.TabIndex = 44
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbImpresora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbImpresora.Image = Global.Libregco.My.Resources.Resources.Printerx24
        Me.rdbImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbImpresora.Location = New System.Drawing.Point(135, 25)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(105, 39)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbExcel
        '
        Me.rdbExcel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbExcel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbExcel.Image = Global.Libregco.My.Resources.Resources.excelx24
        Me.rdbExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbExcel.Location = New System.Drawing.Point(376, 25)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(136, 39)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Convertir a Excel"
        Me.rdbExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPDF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbPDF.Image = Global.Libregco.My.Resources.Resources.Pdfx24
        Me.rdbPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbPDF.Location = New System.Drawing.Point(245, 25)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(125, 39)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "Convertir a PDF"
        Me.rdbPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Reportx16
        Me.GroupControl1.Controls.Add(Me.Panel1)
        Me.GroupControl1.Controls.Add(Me.chkResumir)
        Me.GroupControl1.Controls.Add(Me.CbxFormato)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Location = New System.Drawing.Point(527, 501)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(467, 67)
        Me.GroupControl1.TabIndex = 418
        Me.GroupControl1.Text = "Gestor de reportes"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Calendarx24
        Me.GroupControl2.Controls.Add(Me.txtFechaFinal)
        Me.GroupControl2.Controls.Add(Me.txtFechaInicial)
        Me.GroupControl2.Controls.Add(Me.Label1)
        Me.GroupControl2.Controls.Add(Me.Label2)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 3)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(156, 88)
        Me.GroupControl2.TabIndex = 419
        Me.GroupControl2.Text = " Rango de fechas"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Relationx24
        Me.GroupControl3.Controls.Add(Me.Label4)
        Me.GroupControl3.Controls.Add(Me.txtIDCliente)
        Me.GroupControl3.Controls.Add(Me.txtCliente)
        Me.GroupControl3.Controls.Add(Me.btnBuscarCliente)
        Me.GroupControl3.Controls.Add(Me.Label5)
        Me.GroupControl3.Controls.Add(Me.txtIDVendedor)
        Me.GroupControl3.Controls.Add(Me.txtVendedor)
        Me.GroupControl3.Controls.Add(Me.btnBuscarTipoMemo)
        Me.GroupControl3.Location = New System.Drawing.Point(165, 3)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(521, 88)
        Me.GroupControl3.TabIndex = 420
        Me.GroupControl3.Text = "Relacionados"
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.cbxCondicion)
        Me.GroupControl5.Controls.Add(Me.Label7)
        Me.GroupControl5.Controls.Add(Me.chkNulos)
        Me.GroupControl5.Location = New System.Drawing.Point(692, 3)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(199, 88)
        Me.GroupControl5.TabIndex = 421
        Me.GroupControl5.Text = "Otros"
        '
        'DgvVentas
        '
        Me.DgvVentas.AllowUserToAddRows = False
        Me.DgvVentas.AllowUserToDeleteRows = False
        Me.DgvVentas.AllowUserToResizeColumns = False
        Me.DgvVentas.AllowUserToResizeRows = False
        Me.DgvVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvVentas.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvVentas.Location = New System.Drawing.Point(5, 102)
        Me.DgvVentas.MultiSelect = False
        Me.DgvVentas.Name = "DgvVentas"
        Me.DgvVentas.ReadOnly = True
        Me.DgvVentas.RowHeadersWidth = 20
        Me.DgvVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvVentas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure
        Me.DgvVentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvVentas.Size = New System.Drawing.Size(886, 319)
        Me.DgvVentas.StandardTab = True
        Me.DgvVentas.TabIndex = 338
        Me.DgvVentas.TabStop = False
        '
        'frm_consulta_registro_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 599)
        Me.Controls.Add(Me.GroupControl5)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.DgvVentas)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_registro_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "83"
        Me.Text = "Consulta de registro de facturas"
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.DgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents chkNulos As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarTipoMemo As System.Windows.Forms.Button
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarCons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPresentar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEspecifico As System.Windows.Forms.RadioButton
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DgvVentas As DataGridView
End Class
