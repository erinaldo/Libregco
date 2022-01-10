<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_conduce_reparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_conduce_reparacion))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIDConduce = New Libregco.Watermark()
        Me.chkNulos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStatusReparacion = New System.Windows.Forms.TextBox()
        Me.txtIDStatusReparacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.DgvConduces = New System.Windows.Forms.DataGridView()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnBuscarStatus = New System.Windows.Forms.Button()
        Me.btnBuscarSuplidor = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.DgvConduces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIDConduce)
        Me.GroupBox2.Controls.Add(Me.chkNulos)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(623, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 83)
        Me.GroupBox2.TabIndex = 372
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Condiciones"
        '
        'txtIDConduce
        '
        Me.txtIDConduce.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDConduce.Location = New System.Drawing.Point(7, 23)
        Me.txtIDConduce.Name = "txtIDConduce"
        Me.txtIDConduce.Size = New System.Drawing.Size(139, 23)
        Me.txtIDConduce.TabIndex = 372
        Me.txtIDConduce.WatermarkColor = System.Drawing.Color.Gray
        Me.txtIDConduce.WatermarkText = "No. Conduce"
        '
        'chkNulos
        '
        Me.chkNulos.AutoSize = True
        Me.chkNulos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkNulos.Location = New System.Drawing.Point(70, 56)
        Me.chkNulos.Name = "chkNulos"
        Me.chkNulos.Size = New System.Drawing.Size(76, 19)
        Me.chkNulos.TabIndex = 6
        Me.chkNulos.Text = "Ver Nulos"
        Me.chkNulos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(177, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 378
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(306, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "Status"
        '
        'txtStatusReparacion
        '
        Me.txtStatusReparacion.Enabled = False
        Me.txtStatusReparacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStatusReparacion.Location = New System.Drawing.Point(304, 62)
        Me.txtStatusReparacion.Name = "txtStatusReparacion"
        Me.txtStatusReparacion.ReadOnly = True
        Me.txtStatusReparacion.Size = New System.Drawing.Size(313, 23)
        Me.txtStatusReparacion.TabIndex = 376
        '
        'txtIDStatusReparacion
        '
        Me.txtIDStatusReparacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDStatusReparacion.Location = New System.Drawing.Point(177, 62)
        Me.txtIDStatusReparacion.Name = "txtIDStatusReparacion"
        Me.txtIDStatusReparacion.Size = New System.Drawing.Size(109, 23)
        Me.txtIDStatusReparacion.TabIndex = 370
        Me.txtIDStatusReparacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(177, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 375
        Me.Label6.Text = "Código"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(304, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 374
        Me.Label5.Text = "Suplidor"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(304, 19)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(313, 23)
        Me.txtSuplidor.TabIndex = 373
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(177, 19)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(109, 23)
        Me.txtIDSuplidor.TabIndex = 368
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 83)
        Me.GroupBox1.TabIndex = 367
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Entre Fechas"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = ""
        Me.txtFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinal.Location = New System.Drawing.Point(55, 48)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaFinal.TabIndex = 340
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = ""
        Me.txtFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicial.Location = New System.Drawing.Point(55, 17)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaInicial.TabIndex = 339
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkResumir)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CbxFormato)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.GroupBox3.Location = New System.Drawing.Point(344, 361)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(429, 97)
        Me.GroupBox3.TabIndex = 382
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Reporte"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(132, 40)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 350
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox4.Controls.Add(Me.rdbImpresora)
        Me.GroupBox4.Controls.Add(Me.rdbPDF)
        Me.GroupBox4.Controls.Add(Me.rdbExcel)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(257, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(166, 60)
        Me.GroupBox4.TabIndex = 349
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Salida"
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = True
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(9, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 44
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(9, 34)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(108, 15)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(108, 34)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 61)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 348
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(5, 45)
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
        Me.rdbGeneral.AutoSize = True
        Me.rdbGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbGeneral.Location = New System.Drawing.Point(88, 2)
        Me.rdbGeneral.Name = "rdbGeneral"
        Me.rdbGeneral.Size = New System.Drawing.Size(69, 19)
        Me.rdbGeneral.TabIndex = 347
        Me.rdbGeneral.Text = "General"
        Me.rdbGeneral.UseVisualStyleBackColor = True
        '
        'rdbEspecifico
        '
        Me.rdbEspecifico.AutoSize = True
        Me.rdbEspecifico.Checked = True
        Me.rdbEspecifico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbEspecifico.Location = New System.Drawing.Point(2, 2)
        Me.rdbEspecifico.Name = "rdbEspecifico"
        Me.rdbEspecifico.Size = New System.Drawing.Size(80, 19)
        Me.rdbEspecifico.TabIndex = 346
        Me.rdbEspecifico.TabStop = True
        Me.rdbEspecifico.Text = "Específico"
        Me.rdbEspecifico.UseVisualStyleBackColor = True
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(-3, 390)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(348, 71)
        Me.IconPanel.TabIndex = 381
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnBuscarCons, Me.btnPresentar, Me.btnModificar, Me.btnStructure})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(348, 71)
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
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCantidad.Location = New System.Drawing.Point(9, 372)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(127, 15)
        Me.lblCantidad.TabIndex = 380
        Me.lblCantidad.Text = "Registros Encontrados:"
        '
        'DgvConduces
        '
        Me.DgvConduces.AllowUserToAddRows = False
        Me.DgvConduces.AllowUserToDeleteRows = False
        Me.DgvConduces.AllowUserToResizeColumns = False
        Me.DgvConduces.AllowUserToResizeRows = False
        Me.DgvConduces.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvConduces.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvConduces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvConduces.Location = New System.Drawing.Point(5, 91)
        Me.DgvConduces.MultiSelect = False
        Me.DgvConduces.Name = "DgvConduces"
        Me.DgvConduces.ReadOnly = True
        Me.DgvConduces.RowHeadersWidth = 20
        Me.DgvConduces.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvConduces.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure
        Me.DgvConduces.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvConduces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvConduces.Size = New System.Drawing.Size(771, 264)
        Me.DgvConduces.StandardTab = True
        Me.DgvConduces.TabIndex = 379
        Me.DgvConduces.TabStop = False
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
        Me.BarraEstado.TabIndex = 383
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnBuscarStatus
        '
        Me.btnBuscarStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarStatus.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarStatus.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarStatus.Location = New System.Drawing.Point(284, 62)
        Me.btnBuscarStatus.Name = "btnBuscarStatus"
        Me.btnBuscarStatus.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarStatus.TabIndex = 371
        Me.btnBuscarStatus.UseVisualStyleBackColor = True
        '
        'btnBuscarSuplidor
        '
        Me.btnBuscarSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarSuplidor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarSuplidor.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarSuplidor.Location = New System.Drawing.Point(284, 19)
        Me.btnBuscarSuplidor.Name = "btnBuscarSuplidor"
        Me.btnBuscarSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarSuplidor.TabIndex = 369
        Me.btnBuscarSuplidor.UseVisualStyleBackColor = True
        '
        'frm_consulta_conduce_reparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 490)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.DgvConduces)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscarStatus)
        Me.Controls.Add(Me.txtStatusReparacion)
        Me.Controls.Add(Me.txtIDStatusReparacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscarSuplidor)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_conduce_reparacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "56"
        Me.Text = "Consulta de conduces de reparación"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.DgvConduces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDConduce As Watermark
    Friend WithEvents chkNulos As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarStatus As System.Windows.Forms.Button
    Friend WithEvents txtStatusReparacion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDStatusReparacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarSuplidor As System.Windows.Forms.Button
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents DgvConduces As System.Windows.Forms.DataGridView
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
End Class
