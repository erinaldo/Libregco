<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_recibos_cobros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_recibos_cobros))
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblSumaTotal = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbGeneral = New System.Windows.Forms.RadioButton()
        Me.rdbEspecifico = New System.Windows.Forms.RadioButton()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnTipoRecibo = New System.Windows.Forms.Button()
        Me.txtTipoRecibo = New System.Windows.Forms.TextBox()
        Me.txtIDTipoRecibo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEntrega = New System.Windows.Forms.Button()
        Me.txtEntrega = New System.Windows.Forms.TextBox()
        Me.txtIDEntrega = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkNulos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvRecibos = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.IconPanel.SuspendLayout
        Me.MenuStrip2.SuspendLayout
        Me.BarraEstado.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.GroupBox1.SuspendLayout
        CType(Me.DgvRecibos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblCantidad.AutoSize = true
        Me.lblCantidad.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.lblCantidad.Location = New System.Drawing.Point(8, 362)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(127, 15)
        Me.lblCantidad.TabIndex = 369
        Me.lblCantidad.Text = "Registros Encontrados:"
        '
        'lblSumaTotal
        '
        Me.lblSumaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblSumaTotal.AutoSize = true
        Me.lblSumaTotal.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.lblSumaTotal.Location = New System.Drawing.Point(576, 349)
        Me.lblSumaTotal.Name = "lblSumaTotal"
        Me.lblSumaTotal.Size = New System.Drawing.Size(69, 15)
        Me.lblSumaTotal.TabIndex = 366
        Me.lblSumaTotal.Text = "Suma Total:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkResumir)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CbxFormato)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle))
        Me.GroupBox3.Location = New System.Drawing.Point(349, 359)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(429, 97)
        Me.GroupBox3.TabIndex = 368
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Tipo de Reporte"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = true
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(131, 42)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 350
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = true
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox4.Controls.Add(Me.rdbImpresora)
        Me.GroupBox4.Controls.Add(Me.rdbPDF)
        Me.GroupBox4.Controls.Add(Me.rdbExcel)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(257, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(166, 60)
        Me.GroupBox4.TabIndex = 349
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Tipo de Salida"
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = true
        Me.rdbPresentacion.Checked = true
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(9, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 44
        Me.rdbPresentacion.TabStop = true
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = true
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = true
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.rdbImpresora.Location = New System.Drawing.Point(9, 34)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = true
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = true
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.rdbPDF.Location = New System.Drawing.Point(108, 15)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = true
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = true
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.rdbExcel.Location = New System.Drawing.Point(108, 34)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = true
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.CbxFormato.FormattingEnabled = true
        Me.CbxFormato.Location = New System.Drawing.Point(5, 63)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 348
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label8.Location = New System.Drawing.Point(4, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "Formato Reporte:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbGeneral)
        Me.Panel1.Controls.Add(Me.rdbEspecifico)
        Me.Panel1.Location = New System.Drawing.Point(6, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 23)
        Me.Panel1.TabIndex = 347
        '
        'rdbGeneral
        '
        Me.rdbGeneral.AutoSize = true
        Me.rdbGeneral.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.rdbGeneral.Location = New System.Drawing.Point(88, 2)
        Me.rdbGeneral.Name = "rdbGeneral"
        Me.rdbGeneral.Size = New System.Drawing.Size(69, 19)
        Me.rdbGeneral.TabIndex = 347
        Me.rdbGeneral.Text = "General"
        Me.rdbGeneral.UseVisualStyleBackColor = true
        '
        'rdbEspecifico
        '
        Me.rdbEspecifico.AutoSize = true
        Me.rdbEspecifico.Checked = true
        Me.rdbEspecifico.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.rdbEspecifico.Location = New System.Drawing.Point(2, 2)
        Me.rdbEspecifico.Name = "rdbEspecifico"
        Me.rdbEspecifico.Size = New System.Drawing.Size(80, 19)
        Me.rdbEspecifico.TabIndex = 346
        Me.rdbEspecifico.TabStop = true
        Me.rdbEspecifico.Text = "Específico"
        Me.rdbEspecifico.UseVisualStyleBackColor = true
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(5, 377)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(397, 82)
        Me.IconPanel.TabIndex = 367
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
        Me.MenuStrip2.Size = New System.Drawing.Size(397, 82)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 78)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.Size = New System.Drawing.Size(60, 78)
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnPresentar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(68, 78)
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(70, 78)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStructure
        '
        Me.btnStructure.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.btnStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnStructure.Name = "btnStructure"
        Me.btnStructure.Size = New System.Drawing.Size(72, 78)
        Me.btnStructure.Text = "Estructura"
        Me.btnStructure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 465)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(781, 25)
        Me.BarraEstado.TabIndex = 365
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
        Me.PicLoading.Visible = false
        '
        'ToolSeparator
        '
        Me.ToolSeparator.Name = "ToolSeparator"
        Me.ToolSeparator.Size = New System.Drawing.Size(6, 25)
        Me.ToolSeparator.Visible = false
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
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle))
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
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label3.Location = New System.Drawing.Point(182, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 381
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label4.Location = New System.Drawing.Point(311, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 380
        Me.Label4.Text = "Tipo recibo"
        '
        'btnTipoRecibo
        '
        Me.btnTipoRecibo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTipoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.btnTipoRecibo.Image = CType(resources.GetObject("btnTipoRecibo.Image"),System.Drawing.Image)
        Me.btnTipoRecibo.Location = New System.Drawing.Point(293, 66)
        Me.btnTipoRecibo.Name = "btnTipoRecibo"
        Me.btnTipoRecibo.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoRecibo.TabIndex = 378
        Me.btnTipoRecibo.UseVisualStyleBackColor = true
        '
        'txtTipoRecibo
        '
        Me.txtTipoRecibo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTipoRecibo.Enabled = false
        Me.txtTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.txtTipoRecibo.Location = New System.Drawing.Point(314, 66)
        Me.txtTipoRecibo.Name = "txtTipoRecibo"
        Me.txtTipoRecibo.ReadOnly = true
        Me.txtTipoRecibo.Size = New System.Drawing.Size(313, 23)
        Me.txtTipoRecibo.TabIndex = 379
        '
        'txtIDTipoRecibo
        '
        Me.txtIDTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.txtIDTipoRecibo.Location = New System.Drawing.Point(185, 66)
        Me.txtIDTipoRecibo.Name = "txtIDTipoRecibo"
        Me.txtIDTipoRecibo.Size = New System.Drawing.Size(109, 23)
        Me.txtIDTipoRecibo.TabIndex = 377
        Me.txtIDTipoRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label6.Location = New System.Drawing.Point(182, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 376
        Me.Label6.Text = "Código"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.Label5.Location = New System.Drawing.Point(311, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 375
        Me.Label5.Text = "Entrega"
        '
        'btnEntrega
        '
        Me.btnEntrega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEntrega.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.btnEntrega.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnEntrega.Location = New System.Drawing.Point(293, 22)
        Me.btnEntrega.Name = "btnEntrega"
        Me.btnEntrega.Size = New System.Drawing.Size(23, 23)
        Me.btnEntrega.TabIndex = 373
        Me.btnEntrega.UseVisualStyleBackColor = true
        '
        'txtEntrega
        '
        Me.txtEntrega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtEntrega.Enabled = false
        Me.txtEntrega.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.txtEntrega.Location = New System.Drawing.Point(314, 22)
        Me.txtEntrega.Name = "txtEntrega"
        Me.txtEntrega.ReadOnly = true
        Me.txtEntrega.Size = New System.Drawing.Size(313, 23)
        Me.txtEntrega.TabIndex = 374
        '
        'txtIDEntrega
        '
        Me.txtIDEntrega.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.txtIDEntrega.Location = New System.Drawing.Point(185, 22)
        Me.txtIDEntrega.Name = "txtIDEntrega"
        Me.txtIDEntrega.Size = New System.Drawing.Size(109, 23)
        Me.txtIDEntrega.TabIndex = 372
        Me.txtIDEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkNulos)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.GroupBox2.Location = New System.Drawing.Point(632, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 91)
        Me.GroupBox2.TabIndex = 371
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Condiciones"
        '
        'chkNulos
        '
        Me.chkNulos.AutoSize = true
        Me.chkNulos.Location = New System.Drawing.Point(13, 20)
        Me.chkNulos.Name = "chkNulos"
        Me.chkNulos.Size = New System.Drawing.Size(76, 19)
        Me.chkNulos.TabIndex = 6
        Me.chkNulos.Text = "Ver Nulos"
        Me.chkNulos.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 91)
        Me.GroupBox1.TabIndex = 370
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Entre Fechas"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = "yyyy-MM-dd"
        Me.txtFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFinal.Location = New System.Drawing.Point(55, 57)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(112, 23)
        Me.txtFechaFinal.TabIndex = 340
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = "yyyy-MM-dd"
        Me.txtFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicial.Location = New System.Drawing.Point(55, 21)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(112, 23)
        Me.txtFechaInicial.TabIndex = 339
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial:"
        '
        'DgvRecibos
        '
        Me.DgvRecibos.AllowUserToAddRows = False
        Me.DgvRecibos.AllowUserToDeleteRows = False
        Me.DgvRecibos.AllowUserToResizeColumns = False
        Me.DgvRecibos.AllowUserToResizeRows = False
        Me.DgvRecibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvRecibos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvRecibos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecibos.Location = New System.Drawing.Point(5, 102)
        Me.DgvRecibos.MultiSelect = False
        Me.DgvRecibos.Name = "DgvRecibos"
        Me.DgvRecibos.ReadOnly = True
        Me.DgvRecibos.RowHeadersWidth = 20
        Me.DgvRecibos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvRecibos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure
        Me.DgvRecibos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecibos.Size = New System.Drawing.Size(770, 257)
        Me.DgvRecibos.StandardTab = True
        Me.DgvRecibos.TabIndex = 382
        Me.DgvRecibos.TabStop = False
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'frm_consulta_recibos_cobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 490)
        Me.Controls.Add(Me.lblSumaTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnTipoRecibo)
        Me.Controls.Add(Me.txtTipoRecibo)
        Me.Controls.Add(Me.txtIDTipoRecibo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnEntrega)
        Me.Controls.Add(Me.txtEntrega)
        Me.Controls.Add(Me.txtIDEntrega)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DgvRecibos)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_recibos_cobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "219"
        Me.Text = "Consulta de recibos de cobros"
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.IconPanel.ResumeLayout(false)
        Me.IconPanel.PerformLayout
        Me.MenuStrip2.ResumeLayout(false)
        Me.MenuStrip2.PerformLayout
        Me.BarraEstado.ResumeLayout(false)
        Me.BarraEstado.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.DgvRecibos,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblSumaTotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEspecifico As System.Windows.Forms.RadioButton
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnTipoRecibo As System.Windows.Forms.Button
    Friend WithEvents txtTipoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnEntrega As System.Windows.Forms.Button
    Friend WithEvents txtEntrega As System.Windows.Forms.TextBox
    Friend WithEvents txtIDEntrega As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNulos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.Timer
End Class
