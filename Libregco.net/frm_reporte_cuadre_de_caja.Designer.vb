<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_cuadre_de_caja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_cuadre_de_caja))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxCorteCaja = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.btnUsuario = New System.Windows.Forms.Button()
        Me.btnVendedor = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDUsuario = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkFinanciamiento = New System.Windows.Forms.CheckBox()
        Me.chkPagoFinanciamiento = New System.Windows.Forms.CheckBox()
        Me.chkRecibosEgreso = New System.Windows.Forms.CheckBox()
        Me.chkDevolucionVenta = New System.Windows.Forms.CheckBox()
        Me.chkCobrosAdelantados = New System.Windows.Forms.CheckBox()
        Me.chkOtrosIngresos = New System.Windows.Forms.CheckBox()
        Me.chkRecibosIngresos = New System.Windows.Forms.CheckBox()
        Me.chkFactCred = New System.Windows.Forms.CheckBox()
        Me.chkFactCont = New System.Windows.Forms.CheckBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEquipo = New System.Windows.Forms.TextBox()
        Me.txtIDEquipo = New System.Windows.Forms.TextBox()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 49)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las fechas"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinal.Location = New System.Drawing.Point(203, 17)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinal.TabIndex = 134
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = ""
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicial.Location = New System.Drawing.Point(52, 17)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaInicial.TabIndex = 133
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(162, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Desde"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 378)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 120
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(463, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(260, 95)
        Me.MenuStrip1.TabIndex = 193
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 91)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 91)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x72
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 91)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GbOpciones
        '
        Me.GbOpciones.Controls.Add(Me.Label23)
        Me.GbOpciones.Controls.Add(Me.cbxTipoOrden)
        Me.GbOpciones.Controls.Add(Me.CbxOrden)
        Me.GbOpciones.Controls.Add(Me.Label13)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(262, 96)
        Me.GbOpciones.TabIndex = 85
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'Label23
        '
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
        Me.cbxTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoOrden.FormattingEnabled = True
        Me.cbxTipoOrden.Items.AddRange(New Object() {"Ascendente", "Descendente"})
        Me.cbxTipoOrden.Location = New System.Drawing.Point(133, 65)
        Me.cbxTipoOrden.Name = "cbxTipoOrden"
        Me.cbxTipoOrden.Size = New System.Drawing.Size(120, 23)
        Me.cbxTipoOrden.TabIndex = 49
        '
        'CbxOrden
        '
        Me.CbxOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxOrden.FormattingEnabled = True
        Me.CbxOrden.Location = New System.Drawing.Point(6, 65)
        Me.CbxOrden.Name = "CbxOrden"
        Me.CbxOrden.Size = New System.Drawing.Size(121, 23)
        Me.CbxOrden.TabIndex = 46
        '
        'Label13
        '
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
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 19)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 45
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicSalida)
        Me.GroupBox1.Controls.Add(Me.rdbExcel)
        Me.GroupBox1.Controls.Add(Me.rdbPDF)
        Me.GroupBox1.Controls.Add(Me.rdbImpresora)
        Me.GroupBox1.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox1.TabIndex = 44
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
        Me.rdbExcel.TabIndex = 3
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
        Me.rdbPDF.TabIndex = 2
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
        Me.rdbImpresora.TabIndex = 1
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
        Me.rdbPresentacion.TabIndex = 0
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.Label5)
        Me.GbCondiciones.Controls.Add(Me.cbxCorteCaja)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(519, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 370)
        Me.GbCondiciones.TabIndex = 253
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 15)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Trans. cortes de caja"
        '
        'cbxCorteCaja
        '
        Me.cbxCorteCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCorteCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCorteCaja.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCorteCaja.FormattingEnabled = True
        Me.cbxCorteCaja.Items.AddRange(New Object() {"Todas las transacciones", "Con corte de caja", "Sin corte de caja"})
        Me.cbxCorteCaja.Location = New System.Drawing.Point(12, 283)
        Me.cbxCorteCaja.Name = "cbxCorteCaja"
        Me.cbxCorteCaja.Size = New System.Drawing.Size(174, 23)
        Me.cbxCorteCaja.TabIndex = 100
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(12, 312)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 15)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(12, 332)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(174, 23)
        Me.cbxEstado.TabIndex = 98
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Checked = True
        Me.chkResumir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(10, 17)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 97
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'btnUsuario
        '
        Me.btnUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUsuario.Image = CType(resources.GetObject("btnUsuario.Image"), System.Drawing.Image)
        Me.btnUsuario.Location = New System.Drawing.Point(184, 57)
        Me.btnUsuario.Name = "btnUsuario"
        Me.btnUsuario.Size = New System.Drawing.Size(23, 23)
        Me.btnUsuario.TabIndex = 260
        Me.btnUsuario.UseVisualStyleBackColor = True
        '
        'btnVendedor
        '
        Me.btnVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnVendedor.Image = CType(resources.GetObject("btnVendedor.Image"), System.Drawing.Image)
        Me.btnVendedor.Location = New System.Drawing.Point(184, 86)
        Me.btnVendedor.Name = "btnVendedor"
        Me.btnVendedor.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedor.TabIndex = 257
        Me.btnVendedor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(10, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 255
        Me.Label6.Text = "Usuario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(10, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Vendedor"
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(206, 57)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(304, 23)
        Me.txtUsuario.TabIndex = 261
        '
        'txtVendedor
        '
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(206, 86)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(304, 23)
        Me.txtVendedor.TabIndex = 258
        '
        'txtIDUsuario
        '
        Me.txtIDUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDUsuario.Location = New System.Drawing.Point(83, 57)
        Me.txtIDUsuario.Name = "txtIDUsuario"
        Me.txtIDUsuario.Size = New System.Drawing.Size(102, 23)
        Me.txtIDUsuario.TabIndex = 259
        Me.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(83, 86)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDVendedor.TabIndex = 256
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.chkFinanciamiento)
        Me.GroupBox3.Controls.Add(Me.chkPagoFinanciamiento)
        Me.GroupBox3.Controls.Add(Me.chkRecibosEgreso)
        Me.GroupBox3.Controls.Add(Me.chkDevolucionVenta)
        Me.GroupBox3.Controls.Add(Me.chkCobrosAdelantados)
        Me.GroupBox3.Controls.Add(Me.chkOtrosIngresos)
        Me.GroupBox3.Controls.Add(Me.chkRecibosIngresos)
        Me.GroupBox3.Controls.Add(Me.chkFactCred)
        Me.GroupBox3.Controls.Add(Me.chkFactCont)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 202)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(447, 100)
        Me.GroupBox3.TabIndex = 262
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Procesos"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.CheckBox1.Location = New System.Drawing.Point(348, 1)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Seleccionar todo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkFinanciamiento
        '
        Me.chkFinanciamiento.AutoSize = True
        Me.chkFinanciamiento.Checked = True
        Me.chkFinanciamiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFinanciamiento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFinanciamiento.Location = New System.Drawing.Point(11, 68)
        Me.chkFinanciamiento.Name = "chkFinanciamiento"
        Me.chkFinanciamiento.Size = New System.Drawing.Size(102, 17)
        Me.chkFinanciamiento.TabIndex = 8
        Me.chkFinanciamiento.Text = "Financiamientos"
        Me.chkFinanciamiento.UseVisualStyleBackColor = True
        '
        'chkPagoFinanciamiento
        '
        Me.chkPagoFinanciamiento.AutoSize = True
        Me.chkPagoFinanciamiento.Checked = True
        Me.chkPagoFinanciamiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPagoFinanciamiento.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPagoFinanciamiento.Location = New System.Drawing.Point(145, 68)
        Me.chkPagoFinanciamiento.Name = "chkPagoFinanciamiento"
        Me.chkPagoFinanciamiento.Size = New System.Drawing.Size(134, 17)
        Me.chkPagoFinanciamiento.TabIndex = 7
        Me.chkPagoFinanciamiento.Text = "Pagos Financiamientos"
        Me.chkPagoFinanciamiento.UseVisualStyleBackColor = True
        '
        'chkRecibosEgreso
        '
        Me.chkRecibosEgreso.AutoSize = True
        Me.chkRecibosEgreso.Checked = True
        Me.chkRecibosEgreso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecibosEgreso.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRecibosEgreso.Location = New System.Drawing.Point(145, 45)
        Me.chkRecibosEgreso.Name = "chkRecibosEgreso"
        Me.chkRecibosEgreso.Size = New System.Drawing.Size(119, 17)
        Me.chkRecibosEgreso.TabIndex = 6
        Me.chkRecibosEgreso.Text = "Recibos de Egresos"
        Me.chkRecibosEgreso.UseVisualStyleBackColor = True
        '
        'chkDevolucionVenta
        '
        Me.chkDevolucionVenta.AutoSize = True
        Me.chkDevolucionVenta.Checked = True
        Me.chkDevolucionVenta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDevolucionVenta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkDevolucionVenta.Location = New System.Drawing.Point(295, 68)
        Me.chkDevolucionVenta.Name = "chkDevolucionVenta"
        Me.chkDevolucionVenta.Size = New System.Drawing.Size(140, 17)
        Me.chkDevolucionVenta.TabIndex = 5
        Me.chkDevolucionVenta.Text = "Devoluciones de Ventas"
        Me.chkDevolucionVenta.UseVisualStyleBackColor = True
        '
        'chkCobrosAdelantados
        '
        Me.chkCobrosAdelantados.AutoSize = True
        Me.chkCobrosAdelantados.Checked = True
        Me.chkCobrosAdelantados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCobrosAdelantados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCobrosAdelantados.Location = New System.Drawing.Point(295, 45)
        Me.chkCobrosAdelantados.Name = "chkCobrosAdelantados"
        Me.chkCobrosAdelantados.Size = New System.Drawing.Size(123, 17)
        Me.chkCobrosAdelantados.TabIndex = 4
        Me.chkCobrosAdelantados.Text = "Cobros Adelantados"
        Me.chkCobrosAdelantados.UseVisualStyleBackColor = True
        '
        'chkOtrosIngresos
        '
        Me.chkOtrosIngresos.AutoSize = True
        Me.chkOtrosIngresos.Checked = True
        Me.chkOtrosIngresos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOtrosIngresos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkOtrosIngresos.Location = New System.Drawing.Point(11, 45)
        Me.chkOtrosIngresos.Name = "chkOtrosIngresos"
        Me.chkOtrosIngresos.Size = New System.Drawing.Size(98, 17)
        Me.chkOtrosIngresos.TabIndex = 3
        Me.chkOtrosIngresos.Text = "Otros Ingresos"
        Me.chkOtrosIngresos.UseVisualStyleBackColor = True
        '
        'chkRecibosIngresos
        '
        Me.chkRecibosIngresos.AutoSize = True
        Me.chkRecibosIngresos.Checked = True
        Me.chkRecibosIngresos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecibosIngresos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRecibosIngresos.Location = New System.Drawing.Point(295, 22)
        Me.chkRecibosIngresos.Name = "chkRecibosIngresos"
        Me.chkRecibosIngresos.Size = New System.Drawing.Size(123, 17)
        Me.chkRecibosIngresos.TabIndex = 2
        Me.chkRecibosIngresos.Text = "Recibos de Ingresos"
        Me.chkRecibosIngresos.UseVisualStyleBackColor = True
        '
        'chkFactCred
        '
        Me.chkFactCred.AutoSize = True
        Me.chkFactCred.Checked = True
        Me.chkFactCred.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFactCred.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFactCred.Location = New System.Drawing.Point(145, 22)
        Me.chkFactCred.Name = "chkFactCred"
        Me.chkFactCred.Size = New System.Drawing.Size(106, 17)
        Me.chkFactCred.TabIndex = 1
        Me.chkFactCred.Text = "Ventas a Crédito"
        Me.chkFactCred.UseVisualStyleBackColor = True
        '
        'chkFactCont
        '
        Me.chkFactCont.AutoSize = True
        Me.chkFactCont.Checked = True
        Me.chkFactCont.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFactCont.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFactCont.Location = New System.Drawing.Point(11, 22)
        Me.chkFactCont.Name = "chkFactCont"
        Me.chkFactCont.Size = New System.Drawing.Size(118, 17)
        Me.chkFactCont.TabIndex = 0
        Me.chkFactCont.Text = "Ventas de Contado"
        Me.chkFactCont.UseVisualStyleBackColor = True
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 490)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(720, 25)
        Me.BarraEstado.TabIndex = 263
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Equipo"
        '
        'txtEquipo
        '
        Me.txtEquipo.Enabled = False
        Me.txtEquipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEquipo.Location = New System.Drawing.Point(186, 173)
        Me.txtEquipo.Name = "txtEquipo"
        Me.txtEquipo.ReadOnly = True
        Me.txtEquipo.Size = New System.Drawing.Size(324, 23)
        Me.txtEquipo.TabIndex = 267
        '
        'txtIDEquipo
        '
        Me.txtIDEquipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEquipo.Location = New System.Drawing.Point(83, 173)
        Me.txtIDEquipo.Name = "txtIDEquipo"
        Me.txtIDEquipo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDEquipo.TabIndex = 265
        Me.txtIDEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(184, 144)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 270
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(10, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 268
        Me.Label2.Text = "Almacen"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(206, 144)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(304, 23)
        Me.txtAlmacen.TabIndex = 271
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(83, 144)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 269
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSucursal
        '
        Me.btnSucursal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSucursal.Image = CType(resources.GetObject("btnSucursal.Image"), System.Drawing.Image)
        Me.btnSucursal.Location = New System.Drawing.Point(184, 115)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(23, 23)
        Me.btnSucursal.TabIndex = 274
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(10, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 272
        Me.Label3.Text = "Sucursal"
        '
        'txtSucursal
        '
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(206, 115)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(304, 23)
        Me.txtSucursal.TabIndex = 275
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(83, 115)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSucursal.TabIndex = 273
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_reporte_cuadre_de_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 515)
        Me.Controls.Add(Me.btnSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtIDSucursal)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEquipo)
        Me.Controls.Add(Me.txtIDEquipo)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnUsuario)
        Me.Controls.Add(Me.btnVendedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.txtIDUsuario)
        Me.Controls.Add(Me.txtIDVendedor)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_cuadre_de_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "79"
        Me.Text = "Reportes de cuadres de caja"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnLimpiar As ToolStripMenuItem
    Friend WithEvents btnCerrar As ToolStripMenuItem
    Friend WithEvents GbOpciones As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cbxTipoOrden As ComboBox
    Friend WithEvents CbxOrden As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CbxFormato As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicSalida As PictureBox
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents GbCondiciones As GroupBox
    Friend WithEvents chkResumir As CheckBox
    Friend WithEvents btnUsuario As Button
    Friend WithEvents btnVendedor As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtIDUsuario As TextBox
    Friend WithEvents txtIDVendedor As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkRecibosEgreso As CheckBox
    Friend WithEvents chkDevolucionVenta As CheckBox
    Friend WithEvents chkCobrosAdelantados As CheckBox
    Friend WithEvents chkOtrosIngresos As CheckBox
    Friend WithEvents chkRecibosIngresos As CheckBox
    Friend WithEvents chkFactCred As CheckBox
    Friend WithEvents chkFactCont As CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEquipo As TextBox
    Friend WithEvents txtIDEquipo As TextBox
    Friend WithEvents btnAlmacen As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAlmacen As TextBox
    Friend WithEvents txtIDAlmacen As TextBox
    Friend WithEvents btnSucursal As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSucursal As TextBox
    Friend WithEvents txtIDSucursal As TextBox
    Friend WithEvents chkFinanciamiento As CheckBox
    Friend WithEvents chkPagoFinanciamiento As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbxCorteCaja As ComboBox
End Class
