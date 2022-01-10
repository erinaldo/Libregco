<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_pagares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_pagares))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblDesdeTiempo = New System.Windows.Forms.Label()
        Me.txtCantidadTiempo = New Libregco.Watermark()
        Me.cbxTiempo = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rdbNoVencidasPagares = New System.Windows.Forms.RadioButton()
        Me.rdbVencidasPagares = New System.Windows.Forms.RadioButton()
        Me.rdbTodasPagares = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbNoVencidas = New System.Windows.Forms.RadioButton()
        Me.rdbVencidas = New System.Windows.Forms.RadioButton()
        Me.rdbTodasFacturas = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CbxCtaIncobrable = New System.Windows.Forms.ComboBox()
        Me.cbxGeneracionCargo = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbxEstadoPagare = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEspecificarVencFactura = New System.Windows.Forms.CheckBox()
        Me.dtpVencimientoFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpVencimientoInicial = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkSVencPagares = New System.Windows.Forms.CheckBox()
        Me.dtpVencPagareFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpVencPagareInicial = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkSFechaFactura = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFacturaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaFacturaInicial = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.btnCobrador = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.btnCondicion = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.txtIDCondicion = New System.Windows.Forms.TextBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.btnUsuario = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtIDUsuario = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnVendedor = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbxTipoOrden = New System.Windows.Forms.ComboBox()
        Me.CbxOrden = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.rdbIgualqueCero = New System.Windows.Forms.RadioButton()
        Me.rdbDiferenteaCero = New System.Windows.Forms.RadioButton()
        Me.rdbMayorqueCero = New System.Windows.Forms.RadioButton()
        Me.rdbMenorqueCero = New System.Windows.Forms.RadioButton()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.BarraEstado.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 552)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 258
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
        'GbCondiciones
        '
        Me.GbCondiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondiciones.Controls.Add(Me.GroupBox7)
        Me.GbCondiciones.Controls.Add(Me.GroupBox6)
        Me.GbCondiciones.Controls.Add(Me.Label22)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.GroupBox2)
        Me.GbCondiciones.Controls.Add(Me.Label25)
        Me.GbCondiciones.Controls.Add(Me.CbxCtaIncobrable)
        Me.GbCondiciones.Controls.Add(Me.cbxGeneracionCargo)
        Me.GbCondiciones.Controls.Add(Me.Label20)
        Me.GbCondiciones.Controls.Add(Me.cbxEstadoPagare)
        Me.GbCondiciones.Controls.Add(Me.Label15)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(522, 5)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 435)
        Me.GbCondiciones.TabIndex = 343
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.lblDesdeTiempo)
        Me.GroupBox7.Controls.Add(Me.txtCantidadTiempo)
        Me.GroupBox7.Controls.Add(Me.cbxTiempo)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(181, 64)
        Me.GroupBox7.TabIndex = 428
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tiempo"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(3, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 434
        Me.Label24.Text = "Desde"
        '
        'lblDesdeTiempo
        '
        Me.lblDesdeTiempo.AutoSize = True
        Me.lblDesdeTiempo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDesdeTiempo.Location = New System.Drawing.Point(40, 47)
        Me.lblDesdeTiempo.Name = "lblDesdeTiempo"
        Me.lblDesdeTiempo.Size = New System.Drawing.Size(0, 13)
        Me.lblDesdeTiempo.TabIndex = 433
        '
        'txtCantidadTiempo
        '
        Me.txtCantidadTiempo.Location = New System.Drawing.Point(5, 21)
        Me.txtCantidadTiempo.Name = "txtCantidadTiempo"
        Me.txtCantidadTiempo.Size = New System.Drawing.Size(72, 23)
        Me.txtCantidadTiempo.TabIndex = 431
        Me.txtCantidadTiempo.WatermarkColor = System.Drawing.Color.Gray
        Me.txtCantidadTiempo.WatermarkText = "Cantidad"
        '
        'cbxTiempo
        '
        Me.cbxTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTiempo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTiempo.FormattingEnabled = True
        Me.cbxTiempo.Items.AddRange(New Object() {"día(s)", "mes(es)", "años(es)"})
        Me.cbxTiempo.Location = New System.Drawing.Point(82, 21)
        Me.cbxTiempo.Name = "cbxTiempo"
        Me.cbxTiempo.Size = New System.Drawing.Size(93, 23)
        Me.cbxTiempo.TabIndex = 429
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rdbNoVencidasPagares)
        Me.GroupBox6.Controls.Add(Me.rdbVencidasPagares)
        Me.GroupBox6.Controls.Add(Me.rdbTodasPagares)
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 117)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(181, 67)
        Me.GroupBox6.TabIndex = 427
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Pagarés"
        '
        'rdbNoVencidasPagares
        '
        Me.rdbNoVencidasPagares.AutoSize = True
        Me.rdbNoVencidasPagares.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbNoVencidasPagares.Location = New System.Drawing.Point(83, 41)
        Me.rdbNoVencidasPagares.Name = "rdbNoVencidasPagares"
        Me.rdbNoVencidasPagares.Size = New System.Drawing.Size(88, 17)
        Me.rdbNoVencidasPagares.TabIndex = 2
        Me.rdbNoVencidasPagares.Text = "No vencidos"
        Me.rdbNoVencidasPagares.UseVisualStyleBackColor = True
        '
        'rdbVencidasPagares
        '
        Me.rdbVencidasPagares.AutoSize = True
        Me.rdbVencidasPagares.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbVencidasPagares.Location = New System.Drawing.Point(6, 41)
        Me.rdbVencidasPagares.Name = "rdbVencidasPagares"
        Me.rdbVencidasPagares.Size = New System.Drawing.Size(71, 17)
        Me.rdbVencidasPagares.TabIndex = 1
        Me.rdbVencidasPagares.Text = "Vencidos"
        Me.rdbVencidasPagares.UseVisualStyleBackColor = True
        '
        'rdbTodasPagares
        '
        Me.rdbTodasPagares.AutoSize = True
        Me.rdbTodasPagares.Checked = True
        Me.rdbTodasPagares.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbTodasPagares.Location = New System.Drawing.Point(6, 18)
        Me.rdbTodasPagares.Name = "rdbTodasPagares"
        Me.rdbTodasPagares.Size = New System.Drawing.Size(55, 17)
        Me.rdbTodasPagares.TabIndex = 0
        Me.rdbTodasPagares.TabStop = True
        Me.rdbTodasPagares.Text = "Todos"
        Me.rdbTodasPagares.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(12, 251)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(42, 15)
        Me.Label22.TabIndex = 428
        Me.Label22.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(12, 269)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 427
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbNoVencidas)
        Me.GroupBox2.Controls.Add(Me.rdbVencidas)
        Me.GroupBox2.Controls.Add(Me.rdbTodasFacturas)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(181, 69)
        Me.GroupBox2.TabIndex = 426
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Facturas"
        '
        'rdbNoVencidas
        '
        Me.rdbNoVencidas.AutoSize = True
        Me.rdbNoVencidas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbNoVencidas.Location = New System.Drawing.Point(83, 40)
        Me.rdbNoVencidas.Name = "rdbNoVencidas"
        Me.rdbNoVencidas.Size = New System.Drawing.Size(87, 17)
        Me.rdbNoVencidas.TabIndex = 2
        Me.rdbNoVencidas.Text = "No vencidas"
        Me.rdbNoVencidas.UseVisualStyleBackColor = True
        '
        'rdbVencidas
        '
        Me.rdbVencidas.AutoSize = True
        Me.rdbVencidas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbVencidas.Location = New System.Drawing.Point(6, 40)
        Me.rdbVencidas.Name = "rdbVencidas"
        Me.rdbVencidas.Size = New System.Drawing.Size(70, 17)
        Me.rdbVencidas.TabIndex = 1
        Me.rdbVencidas.Text = "Vencidas"
        Me.rdbVencidas.UseVisualStyleBackColor = True
        '
        'rdbTodasFacturas
        '
        Me.rdbTodasFacturas.AutoSize = True
        Me.rdbTodasFacturas.Checked = True
        Me.rdbTodasFacturas.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.rdbTodasFacturas.Location = New System.Drawing.Point(6, 19)
        Me.rdbTodasFacturas.Name = "rdbTodasFacturas"
        Me.rdbTodasFacturas.Size = New System.Drawing.Size(54, 17)
        Me.rdbTodasFacturas.TabIndex = 0
        Me.rdbTodasFacturas.TabStop = True
        Me.rdbTodasFacturas.Text = "Todas"
        Me.rdbTodasFacturas.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(12, 383)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 15)
        Me.Label25.TabIndex = 425
        Me.Label25.Text = "Cuentas Incobrables"
        '
        'CbxCtaIncobrable
        '
        Me.CbxCtaIncobrable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCtaIncobrable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxCtaIncobrable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxCtaIncobrable.FormattingEnabled = True
        Me.CbxCtaIncobrable.Items.AddRange(New Object() {"Todos", "Sólo las incobrables", "Sólo las cobrables"})
        Me.CbxCtaIncobrable.Location = New System.Drawing.Point(12, 401)
        Me.CbxCtaIncobrable.Name = "CbxCtaIncobrable"
        Me.CbxCtaIncobrable.Size = New System.Drawing.Size(170, 23)
        Me.CbxCtaIncobrable.TabIndex = 424
        '
        'cbxGeneracionCargo
        '
        Me.cbxGeneracionCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGeneracionCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxGeneracionCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGeneracionCargo.FormattingEnabled = True
        Me.cbxGeneracionCargo.Items.AddRange(New Object() {"Todos", "Aplican", "No Aplican"})
        Me.cbxGeneracionCargo.Location = New System.Drawing.Point(12, 357)
        Me.cbxGeneracionCargo.Name = "cbxGeneracionCargo"
        Me.cbxGeneracionCargo.Size = New System.Drawing.Size(170, 23)
        Me.cbxGeneracionCargo.TabIndex = 422
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(12, 339)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(123, 15)
        Me.Label20.TabIndex = 423
        Me.Label20.Text = "Generación de Cargos"
        '
        'cbxEstadoPagare
        '
        Me.cbxEstadoPagare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstadoPagare.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstadoPagare.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstadoPagare.FormattingEnabled = True
        Me.cbxEstadoPagare.Location = New System.Drawing.Point(12, 313)
        Me.cbxEstadoPagare.Name = "cbxEstadoPagare"
        Me.cbxEstadoPagare.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstadoPagare.TabIndex = 421
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(12, 295)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 15)
        Me.Label15.TabIndex = 420
        Me.Label15.Text = "Estado de pagaré"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.Location = New System.Drawing.Point(3, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(215, 2)
        Me.Label12.TabIndex = 98
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(12, 20)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 28
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.chkEspecificarVencFactura)
        Me.GroupBox3.Controls.Add(Me.dtpVencimientoFinal)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtpVencimientoInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox3.TabIndex = 344
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha de vencimiento de facturas"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(121, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(2, 25)
        Me.Label14.TabIndex = 284
        '
        'chkEspecificarVencFactura
        '
        Me.chkEspecificarVencFactura.AutoSize = True
        Me.chkEspecificarVencFactura.Checked = True
        Me.chkEspecificarVencFactura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificarVencFactura.Location = New System.Drawing.Point(11, 20)
        Me.chkEspecificarVencFactura.Name = "chkEspecificarVencFactura"
        Me.chkEspecificarVencFactura.Size = New System.Drawing.Size(101, 19)
        Me.chkEspecificarVencFactura.TabIndex = 16
        Me.chkEspecificarVencFactura.Text = "Sin Especificar"
        Me.chkEspecificarVencFactura.UseVisualStyleBackColor = True
        '
        'dtpVencimientoFinal
        '
        Me.dtpVencimientoFinal.CustomFormat = ""
        Me.dtpVencimientoFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencimientoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencimientoFinal.Location = New System.Drawing.Point(297, 15)
        Me.dtpVencimientoFinal.Name = "dtpVencimientoFinal"
        Me.dtpVencimientoFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpVencimientoFinal.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(278, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 15)
        Me.Label8.TabIndex = 281
        Me.Label8.Text = "y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(128, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 15)
        Me.Label11.TabIndex = 280
        Me.Label11.Text = "Entre"
        '
        'dtpVencimientoInicial
        '
        Me.dtpVencimientoInicial.CustomFormat = ""
        Me.dtpVencimientoInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencimientoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencimientoInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpVencimientoInicial.Name = "dtpVencimientoInicial"
        Me.dtpVencimientoInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpVencimientoInicial.TabIndex = 17
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.chkSVencPagares)
        Me.GroupBox5.Controls.Add(Me.dtpVencPagareFinal)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.dtpVencPagareInicial)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 93)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox5.TabIndex = 345
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha de vencimiento de pagarés"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(121, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2, 25)
        Me.Label1.TabIndex = 284
        '
        'chkSVencPagares
        '
        Me.chkSVencPagares.AutoSize = True
        Me.chkSVencPagares.Checked = True
        Me.chkSVencPagares.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSVencPagares.Location = New System.Drawing.Point(11, 20)
        Me.chkSVencPagares.Name = "chkSVencPagares"
        Me.chkSVencPagares.Size = New System.Drawing.Size(101, 19)
        Me.chkSVencPagares.TabIndex = 16
        Me.chkSVencPagares.Text = "Sin Especificar"
        Me.chkSVencPagares.UseVisualStyleBackColor = True
        '
        'dtpVencPagareFinal
        '
        Me.dtpVencPagareFinal.CustomFormat = ""
        Me.dtpVencPagareFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencPagareFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencPagareFinal.Location = New System.Drawing.Point(297, 15)
        Me.dtpVencPagareFinal.Name = "dtpVencPagareFinal"
        Me.dtpVencPagareFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpVencPagareFinal.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(278, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 281
        Me.Label2.Text = "y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(128, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 280
        Me.Label3.Text = "Entre"
        '
        'dtpVencPagareInicial
        '
        Me.dtpVencPagareInicial.CustomFormat = ""
        Me.dtpVencPagareInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencPagareInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencPagareInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpVencPagareInicial.Name = "dtpVencPagareInicial"
        Me.dtpVencPagareInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpVencPagareInicial.TabIndex = 17
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.chkSFechaFactura)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFacturaFinal)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFacturaInicial)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox4.TabIndex = 345
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha de facturas"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(121, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(2, 25)
        Me.Label4.TabIndex = 284
        '
        'chkSFechaFactura
        '
        Me.chkSFechaFactura.AutoSize = True
        Me.chkSFechaFactura.Checked = True
        Me.chkSFechaFactura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSFechaFactura.Location = New System.Drawing.Point(11, 20)
        Me.chkSFechaFactura.Name = "chkSFechaFactura"
        Me.chkSFechaFactura.Size = New System.Drawing.Size(101, 19)
        Me.chkSFechaFactura.TabIndex = 16
        Me.chkSFechaFactura.Text = "Sin Especificar"
        Me.chkSFechaFactura.UseVisualStyleBackColor = True
        '
        'dtpFechaFacturaFinal
        '
        Me.dtpFechaFacturaFinal.CustomFormat = ""
        Me.dtpFechaFacturaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFacturaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFacturaFinal.Location = New System.Drawing.Point(297, 15)
        Me.dtpFechaFacturaFinal.Name = "dtpFechaFacturaFinal"
        Me.dtpFechaFacturaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFacturaFinal.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(278, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 15)
        Me.Label5.TabIndex = 281
        Me.Label5.Text = "y"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(128, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 280
        Me.Label6.Text = "Entre"
        '
        'dtpFechaFacturaInicial
        '
        Me.dtpFechaFacturaInicial.CustomFormat = ""
        Me.dtpFechaFacturaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFacturaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFacturaInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpFechaFacturaInicial.Name = "dtpFechaFacturaInicial"
        Me.dtpFechaFacturaInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFacturaInicial.TabIndex = 17
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(168, 144)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 348
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 347
        Me.Label7.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(190, 144)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(326, 23)
        Me.txtCliente.TabIndex = 349
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(67, 144)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCliente.TabIndex = 346
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCobrador
        '
        Me.btnCobrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCobrador.Image = CType(resources.GetObject("btnCobrador.Image"), System.Drawing.Image)
        Me.btnCobrador.Location = New System.Drawing.Point(168, 173)
        Me.btnCobrador.Name = "btnCobrador"
        Me.btnCobrador.Size = New System.Drawing.Size(23, 23)
        Me.btnCobrador.TabIndex = 352
        Me.btnCobrador.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(4, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 350
        Me.Label9.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(190, 173)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(326, 23)
        Me.txtCobrador.TabIndex = 353
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(67, 173)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCobrador.TabIndex = 351
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(167, 318)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 409
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(4, 323)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 410
        Me.Label16.Text = "Almacén"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(189, 318)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(326, 23)
        Me.txtAlmacen.TabIndex = 411
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(66, 318)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 408
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCondicion
        '
        Me.btnCondicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCondicion.Image = CType(resources.GetObject("btnCondicion.Image"), System.Drawing.Image)
        Me.btnCondicion.Location = New System.Drawing.Point(167, 260)
        Me.btnCondicion.Name = "btnCondicion"
        Me.btnCondicion.Size = New System.Drawing.Size(23, 23)
        Me.btnCondicion.TabIndex = 405
        Me.btnCondicion.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(4, 265)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 15)
        Me.Label17.TabIndex = 406
        Me.Label17.Text = "Condición"
        '
        'txtCondicion
        '
        Me.txtCondicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(189, 260)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(326, 23)
        Me.txtCondicion.TabIndex = 407
        '
        'txtIDCondicion
        '
        Me.txtIDCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCondicion.Location = New System.Drawing.Point(66, 260)
        Me.txtIDCondicion.Name = "txtIDCondicion"
        Me.txtIDCondicion.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCondicion.TabIndex = 404
        Me.txtIDCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSucursal
        '
        Me.btnSucursal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSucursal.Image = CType(resources.GetObject("btnSucursal.Image"), System.Drawing.Image)
        Me.btnSucursal.Location = New System.Drawing.Point(167, 289)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(23, 23)
        Me.btnSucursal.TabIndex = 401
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(4, 294)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 15)
        Me.Label18.TabIndex = 402
        Me.Label18.Text = "Sucursal"
        '
        'txtSucursal
        '
        Me.txtSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(189, 289)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(326, 23)
        Me.txtSucursal.TabIndex = 403
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(66, 289)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSucursal.TabIndex = 400
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnUsuario
        '
        Me.btnUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUsuario.Image = CType(resources.GetObject("btnUsuario.Image"), System.Drawing.Image)
        Me.btnUsuario.Location = New System.Drawing.Point(167, 202)
        Me.btnUsuario.Name = "btnUsuario"
        Me.btnUsuario.Size = New System.Drawing.Size(23, 23)
        Me.btnUsuario.TabIndex = 414
        Me.btnUsuario.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(4, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 15)
        Me.Label19.TabIndex = 412
        Me.Label19.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(189, 202)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(327, 23)
        Me.txtUsuario.TabIndex = 415
        '
        'txtIDUsuario
        '
        Me.txtIDUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDUsuario.Location = New System.Drawing.Point(66, 202)
        Me.txtIDUsuario.Name = "txtIDUsuario"
        Me.txtIDUsuario.Size = New System.Drawing.Size(102, 23)
        Me.txtIDUsuario.TabIndex = 413
        Me.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnVendedor
        '
        Me.btnVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnVendedor.Image = CType(resources.GetObject("btnVendedor.Image"), System.Drawing.Image)
        Me.btnVendedor.Location = New System.Drawing.Point(167, 231)
        Me.btnVendedor.Name = "btnVendedor"
        Me.btnVendedor.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedor.TabIndex = 418
        Me.btnVendedor.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(4, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 15)
        Me.Label10.TabIndex = 416
        Me.Label10.Text = "Vendedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(189, 231)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(327, 23)
        Me.txtVendedor.TabIndex = 419
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(66, 231)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDVendedor.TabIndex = 417
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 443)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 420
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Location = New System.Drawing.Point(465, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(260, 100)
        Me.Panel3.TabIndex = 40
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(260, 100)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 96)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 96)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x72
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 96)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbOpciones
        '
        Me.GbOpciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbOpciones.Controls.Add(Me.Label23)
        Me.GbOpciones.Controls.Add(Me.cbxTipoOrden)
        Me.GbOpciones.Controls.Add(Me.CbxOrden)
        Me.GbOpciones.Controls.Add(Me.Label13)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(262, 96)
        Me.GbOpciones.TabIndex = 35
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(130, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 15)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "Orden"
        '
        'cbxTipoOrden
        '
        Me.cbxTipoOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoOrden.FormattingEnabled = True
        Me.cbxTipoOrden.Items.AddRange(New Object() {"Ascendente", "Descendente"})
        Me.cbxTipoOrden.Location = New System.Drawing.Point(133, 65)
        Me.cbxTipoOrden.Name = "cbxTipoOrden"
        Me.cbxTipoOrden.Size = New System.Drawing.Size(120, 23)
        Me.cbxTipoOrden.TabIndex = 38
        '
        'CbxOrden
        '
        Me.CbxOrden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxOrden.FormattingEnabled = True
        Me.CbxOrden.Location = New System.Drawing.Point(6, 65)
        Me.CbxOrden.Name = "CbxOrden"
        Me.CbxOrden.Size = New System.Drawing.Size(121, 23)
        Me.CbxOrden.TabIndex = 37
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Campo"
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 19)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 36
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PicSalida)
        Me.GroupBox1.Controls.Add(Me.rdbExcel)
        Me.GroupBox1.Controls.Add(Me.rdbPDF)
        Me.GroupBox1.Controls.Add(Me.rdbImpresora)
        Me.GroupBox1.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el Tipo de Salida"
        '
        'PicSalida
        '
        Me.PicSalida.Location = New System.Drawing.Point(107, 20)
        Me.PicSalida.Name = "PicSalida"
        Me.PicSalida.Size = New System.Drawing.Size(75, 71)
        Me.PicSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSalida.TabIndex = 4
        Me.PicSalida.TabStop = False
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(11, 75)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(11, 55)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(11, 35)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = True
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(11, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 40
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.rdbIgualqueCero)
        Me.Panel2.Controls.Add(Me.rdbDiferenteaCero)
        Me.Panel2.Controls.Add(Me.rdbMayorqueCero)
        Me.Panel2.Controls.Add(Me.rdbMenorqueCero)
        Me.Panel2.Controls.Add(Me.rdbTodos)
        Me.Panel2.Location = New System.Drawing.Point(0, 415)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(510, 26)
        Me.Panel2.TabIndex = 421
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(2, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 422
        Me.Label21.Text = "Balance:"
        '
        'rdbIgualqueCero
        '
        Me.rdbIgualqueCero.AutoSize = True
        Me.rdbIgualqueCero.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.rdbIgualqueCero.Location = New System.Drawing.Point(314, 5)
        Me.rdbIgualqueCero.Name = "rdbIgualqueCero"
        Me.rdbIgualqueCero.Size = New System.Drawing.Size(87, 16)
        Me.rdbIgualqueCero.TabIndex = 427
        Me.rdbIgualqueCero.Text = "Igual que cero"
        Me.rdbIgualqueCero.UseVisualStyleBackColor = True
        '
        'rdbDiferenteaCero
        '
        Me.rdbDiferenteaCero.AutoSize = True
        Me.rdbDiferenteaCero.Checked = True
        Me.rdbDiferenteaCero.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.rdbDiferenteaCero.Location = New System.Drawing.Point(407, 5)
        Me.rdbDiferenteaCero.Name = "rdbDiferenteaCero"
        Me.rdbDiferenteaCero.Size = New System.Drawing.Size(92, 16)
        Me.rdbDiferenteaCero.TabIndex = 426
        Me.rdbDiferenteaCero.TabStop = True
        Me.rdbDiferenteaCero.Text = "Diferente a cero"
        Me.rdbDiferenteaCero.UseVisualStyleBackColor = True
        '
        'rdbMayorqueCero
        '
        Me.rdbMayorqueCero.AutoSize = True
        Me.rdbMayorqueCero.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.rdbMayorqueCero.Location = New System.Drawing.Point(115, 5)
        Me.rdbMayorqueCero.Name = "rdbMayorqueCero"
        Me.rdbMayorqueCero.Size = New System.Drawing.Size(93, 16)
        Me.rdbMayorqueCero.TabIndex = 425
        Me.rdbMayorqueCero.Text = "Mayor que cero"
        Me.rdbMayorqueCero.UseVisualStyleBackColor = True
        '
        'rdbMenorqueCero
        '
        Me.rdbMenorqueCero.AutoSize = True
        Me.rdbMenorqueCero.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.rdbMenorqueCero.Location = New System.Drawing.Point(214, 5)
        Me.rdbMenorqueCero.Name = "rdbMenorqueCero"
        Me.rdbMenorqueCero.Size = New System.Drawing.Size(94, 16)
        Me.rdbMenorqueCero.TabIndex = 424
        Me.rdbMenorqueCero.Text = "Menor que cero"
        Me.rdbMenorqueCero.UseVisualStyleBackColor = True
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.Font = New System.Drawing.Font("Segoe UI", 7.5!)
        Me.rdbTodos.Location = New System.Drawing.Point(59, 5)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(49, 16)
        Me.rdbTodos.TabIndex = 423
        Me.rdbTodos.Text = "Todos"
        Me.rdbTodos.UseVisualStyleBackColor = True
        '
        'frm_reporte_pagares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 577)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnVendedor)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.txtIDVendedor)
        Me.Controls.Add(Me.btnUsuario)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtIDUsuario)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.btnCondicion)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCondicion)
        Me.Controls.Add(Me.txtIDCondicion)
        Me.Controls.Add(Me.btnSucursal)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtIDSucursal)
        Me.Controls.Add(Me.btnCobrador)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_pagares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "77"
        Me.Text = "Reportes de pagarés"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEspecificarVencFactura As System.Windows.Forms.CheckBox
    Friend WithEvents dtpVencimientoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimientoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSVencPagares As System.Windows.Forms.CheckBox
    Friend WithEvents dtpVencPagareFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpVencPagareInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSFechaFactura As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFacturaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFacturaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnCobrador As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobrador As System.Windows.Forms.TextBox
    Friend WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnCondicion As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCondicion As System.Windows.Forms.TextBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnUsuario As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtIDUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnVendedor As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CbxCtaIncobrable As System.Windows.Forms.ComboBox
    Friend WithEvents cbxGeneracionCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbxEstadoPagare As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoOrden As System.Windows.Forms.ComboBox
    Friend WithEvents CbxOrden As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicSalida As System.Windows.Forms.PictureBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNoVencidas As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVencidas As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTodasFacturas As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdbIgualqueCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDiferenteaCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMayorqueCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMenorqueCero As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNoVencidasPagares As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVencidasPagares As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTodasPagares As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCantidadTiempo As Watermark
    Friend WithEvents cbxTiempo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDesdeTiempo As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
