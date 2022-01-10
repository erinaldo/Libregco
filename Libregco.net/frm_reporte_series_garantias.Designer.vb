<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_series_garantias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_series_garantias))
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
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbxTaller = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbxServicio = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbxInstalacion = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbxMantenimiento = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbxTransporte = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxManoObra = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbxVariacionValor = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.btnSubCategoria = New System.Windows.Forms.Button()
        Me.btnDepartamento = New System.Windows.Forms.Button()
        Me.btnBuscarTipoProducto = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoProducto = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.btnGarantia = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGarantia = New System.Windows.Forms.TextBox()
        Me.txtIDGarantia = New System.Windows.Forms.TextBox()
        Me.btnSuplidor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 49)
        Me.GroupBox2.TabIndex = 258
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las Fechas de Factura"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinal.Location = New System.Drawing.Point(203, 17)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinal.TabIndex = 2
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = ""
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicial.Location = New System.Drawing.Point(52, 17)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaInicial.TabIndex = 1
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
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 259
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(465, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(260, 95)
        Me.MenuStrip1.TabIndex = 44
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
        Me.cbxTipoOrden.TabIndex = 38
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
        Me.CbxOrden.TabIndex = 37
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 485)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 260
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
        Me.GbCondiciones.Controls.Add(Me.Label21)
        Me.GbCondiciones.Controls.Add(Me.cbxTaller)
        Me.GbCondiciones.Controls.Add(Me.Label20)
        Me.GbCondiciones.Controls.Add(Me.cbxServicio)
        Me.GbCondiciones.Controls.Add(Me.Label19)
        Me.GbCondiciones.Controls.Add(Me.cbxInstalacion)
        Me.GbCondiciones.Controls.Add(Me.Label18)
        Me.GbCondiciones.Controls.Add(Me.cbxMantenimiento)
        Me.GbCondiciones.Controls.Add(Me.Label17)
        Me.GbCondiciones.Controls.Add(Me.cbxTransporte)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxManoObra)
        Me.GbCondiciones.Controls.Add(Me.Label24)
        Me.GbCondiciones.Controls.Add(Me.cbxVariacionValor)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(522, 5)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 364)
        Me.GbCondiciones.TabIndex = 343
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(12, 316)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 15)
        Me.Label21.TabIndex = 116
        Me.Label21.Text = "Taller"
        '
        'cbxTaller
        '
        Me.cbxTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTaller.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTaller.FormattingEnabled = True
        Me.cbxTaller.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxTaller.Location = New System.Drawing.Point(12, 334)
        Me.cbxTaller.Name = "cbxTaller"
        Me.cbxTaller.Size = New System.Drawing.Size(170, 23)
        Me.cbxTaller.TabIndex = 115
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(12, 272)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 15)
        Me.Label20.TabIndex = 114
        Me.Label20.Text = "Servicio Residencial"
        '
        'cbxServicio
        '
        Me.cbxServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxServicio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxServicio.FormattingEnabled = True
        Me.cbxServicio.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxServicio.Location = New System.Drawing.Point(12, 290)
        Me.cbxServicio.Name = "cbxServicio"
        Me.cbxServicio.Size = New System.Drawing.Size(170, 23)
        Me.cbxServicio.TabIndex = 113
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(12, 228)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 15)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Instalación"
        '
        'cbxInstalacion
        '
        Me.cbxInstalacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInstalacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxInstalacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxInstalacion.FormattingEnabled = True
        Me.cbxInstalacion.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxInstalacion.Location = New System.Drawing.Point(12, 246)
        Me.cbxInstalacion.Name = "cbxInstalacion"
        Me.cbxInstalacion.Size = New System.Drawing.Size(170, 23)
        Me.cbxInstalacion.TabIndex = 111
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(12, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 15)
        Me.Label18.TabIndex = 110
        Me.Label18.Text = "Mantenimiento"
        '
        'cbxMantenimiento
        '
        Me.cbxMantenimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMantenimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMantenimiento.FormattingEnabled = True
        Me.cbxMantenimiento.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxMantenimiento.Location = New System.Drawing.Point(12, 198)
        Me.cbxMantenimiento.Name = "cbxMantenimiento"
        Me.cbxMantenimiento.Size = New System.Drawing.Size(170, 23)
        Me.cbxMantenimiento.TabIndex = 109
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(12, 134)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 15)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Transporte "
        '
        'cbxTransporte
        '
        Me.cbxTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTransporte.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTransporte.FormattingEnabled = True
        Me.cbxTransporte.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxTransporte.Location = New System.Drawing.Point(12, 154)
        Me.cbxTransporte.Name = "cbxTransporte"
        Me.cbxTransporte.Size = New System.Drawing.Size(170, 23)
        Me.cbxTransporte.TabIndex = 107
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(12, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 15)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Mano de Obra"
        '
        'cbxManoObra
        '
        Me.cbxManoObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxManoObra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxManoObra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxManoObra.FormattingEnabled = True
        Me.cbxManoObra.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxManoObra.Location = New System.Drawing.Point(12, 108)
        Me.cbxManoObra.Name = "cbxManoObra"
        Me.cbxManoObra.Size = New System.Drawing.Size(170, 23)
        Me.cbxManoObra.TabIndex = 105
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(12, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 15)
        Me.Label24.TabIndex = 104
        Me.Label24.Text = "Variación de Valor"
        '
        'cbxVariacionValor
        '
        Me.cbxVariacionValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVariacionValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVariacionValor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxVariacionValor.FormattingEnabled = True
        Me.cbxVariacionValor.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxVariacionValor.Location = New System.Drawing.Point(12, 64)
        Me.cbxVariacionValor.Name = "cbxVariacionValor"
        Me.cbxVariacionValor.Size = New System.Drawing.Size(170, 23)
        Me.cbxVariacionValor.TabIndex = 103
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label12.Location = New System.Drawing.Point(3, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(184, 2)
        Me.Label12.TabIndex = 98
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(10, 17)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 28
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'btnCategoria
        '
        Me.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(190, 201)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnCategoria.TabIndex = 358
        Me.btnCategoria.UseVisualStyleBackColor = True
        '
        'btnSubCategoria
        '
        Me.btnSubCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSubCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubCategoria.Image = CType(resources.GetObject("btnSubCategoria.Image"), System.Drawing.Image)
        Me.btnSubCategoria.Location = New System.Drawing.Point(190, 230)
        Me.btnSubCategoria.Name = "btnSubCategoria"
        Me.btnSubCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnSubCategoria.TabIndex = 354
        Me.btnSubCategoria.UseVisualStyleBackColor = True
        '
        'btnDepartamento
        '
        Me.btnDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDepartamento.Image = CType(resources.GetObject("btnDepartamento.Image"), System.Drawing.Image)
        Me.btnDepartamento.Location = New System.Drawing.Point(190, 172)
        Me.btnDepartamento.Name = "btnDepartamento"
        Me.btnDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnDepartamento.TabIndex = 350
        Me.btnDepartamento.UseVisualStyleBackColor = True
        '
        'btnBuscarTipoProducto
        '
        Me.btnBuscarTipoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoProducto.Image = CType(resources.GetObject("btnBuscarTipoProducto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoProducto.Location = New System.Drawing.Point(190, 143)
        Me.btnBuscarTipoProducto.Name = "btnBuscarTipoProducto"
        Me.btnBuscarTipoProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoProducto.TabIndex = 347
        Me.btnBuscarTipoProducto.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 206)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 356
        Me.Label11.Text = "Categoría"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 352
        Me.Label1.Text = "Sub-Categoría"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 15)
        Me.Label8.TabIndex = 346
        Me.Label8.Text = "Tipo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 15)
        Me.Label4.TabIndex = 344
        Me.Label4.Text = "Departamento"
        '
        'txtCategoria
        '
        Me.txtCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Location = New System.Drawing.Point(212, 201)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(305, 23)
        Me.txtCategoria.TabIndex = 359
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubCategoria.Enabled = False
        Me.txtSubCategoria.Location = New System.Drawing.Point(212, 230)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.ReadOnly = True
        Me.txtSubCategoria.Size = New System.Drawing.Size(305, 23)
        Me.txtSubCategoria.TabIndex = 355
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(212, 172)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(305, 23)
        Me.txtDepartamento.TabIndex = 351
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Location = New System.Drawing.Point(212, 143)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(305, 23)
        Me.txtTipoProducto.TabIndex = 348
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Location = New System.Drawing.Point(89, 201)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCategoria.TabIndex = 357
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(89, 230)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSubCategoria.TabIndex = 353
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Location = New System.Drawing.Point(89, 172)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDDepartamento.TabIndex = 349
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDTipoProducto
        '
        Me.txtIDTipoProducto.Location = New System.Drawing.Point(89, 143)
        Me.txtIDTipoProducto.Name = "txtIDTipoProducto"
        Me.txtIDTipoProducto.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoProducto.TabIndex = 345
        Me.txtIDTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(190, 85)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarProducto.TabIndex = 363
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 366
        Me.Label6.Text = "Producto"
        '
        'txtArticulo
        '
        Me.txtArticulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArticulo.Enabled = False
        Me.txtArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtArticulo.Location = New System.Drawing.Point(212, 85)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.ReadOnly = True
        Me.txtArticulo.Size = New System.Drawing.Size(305, 23)
        Me.txtArticulo.TabIndex = 367
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(89, 85)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDArticulo.TabIndex = 362
        Me.txtIDArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(190, 56)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 361
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(4, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 364
        Me.Label2.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(212, 56)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(305, 23)
        Me.txtCliente.TabIndex = 365
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(89, 56)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCliente.TabIndex = 360
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGarantia
        '
        Me.btnGarantia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGarantia.Image = CType(resources.GetObject("btnGarantia.Image"), System.Drawing.Image)
        Me.btnGarantia.Location = New System.Drawing.Point(189, 259)
        Me.btnGarantia.Name = "btnGarantia"
        Me.btnGarantia.Size = New System.Drawing.Size(23, 23)
        Me.btnGarantia.TabIndex = 370
        Me.btnGarantia.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 264)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 368
        Me.Label3.Text = "Garantía"
        '
        'txtGarantia
        '
        Me.txtGarantia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGarantia.Enabled = False
        Me.txtGarantia.Location = New System.Drawing.Point(211, 259)
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.ReadOnly = True
        Me.txtGarantia.Size = New System.Drawing.Size(305, 23)
        Me.txtGarantia.TabIndex = 371
        '
        'txtIDGarantia
        '
        Me.txtIDGarantia.Location = New System.Drawing.Point(88, 259)
        Me.txtIDGarantia.Name = "txtIDGarantia"
        Me.txtIDGarantia.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGarantia.TabIndex = 369
        Me.txtIDGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSuplidor
        '
        Me.btnSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSuplidor.Image = CType(resources.GetObject("btnSuplidor.Image"), System.Drawing.Image)
        Me.btnSuplidor.Location = New System.Drawing.Point(189, 288)
        Me.btnSuplidor.Name = "btnSuplidor"
        Me.btnSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnSuplidor.TabIndex = 374
        Me.btnSuplidor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 293)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "Suplidor"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Location = New System.Drawing.Point(211, 288)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(305, 23)
        Me.txtSuplidor.TabIndex = 375
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Location = New System.Drawing.Point(88, 288)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSuplidor.TabIndex = 373
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSucursal
        '
        Me.btnSucursal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSucursal.Image = CType(resources.GetObject("btnSucursal.Image"), System.Drawing.Image)
        Me.btnSucursal.Location = New System.Drawing.Point(189, 317)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(23, 23)
        Me.btnSucursal.TabIndex = 381
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 15)
        Me.Label7.TabIndex = 382
        Me.Label7.Text = "Sucursal"
        '
        'txtSucursal
        '
        Me.txtSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(211, 317)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(305, 23)
        Me.txtSucursal.TabIndex = 383
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(88, 317)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSucursal.TabIndex = 380
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(189, 346)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 377
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(4, 351)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 15)
        Me.Label14.TabIndex = 378
        Me.Label14.Text = "Almacén"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(211, 346)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(305, 23)
        Me.txtAlmacen.TabIndex = 379
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(88, 346)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 376
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(190, 114)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(23, 23)
        Me.btnMarca.TabIndex = 385
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(4, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 386
        Me.Label15.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMarca.Enabled = False
        Me.txtMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMarca.Location = New System.Drawing.Point(212, 114)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(305, 23)
        Me.txtMarca.TabIndex = 387
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMarca.Location = New System.Drawing.Point(89, 114)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMarca.TabIndex = 384
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_reporte_series_garantias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 510)
        Me.Controls.Add(Me.btnMarca)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.txtIDMarca)
        Me.Controls.Add(Me.btnSucursal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtIDSucursal)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.btnSuplidor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.btnGarantia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGarantia)
        Me.Controls.Add(Me.txtIDGarantia)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.txtIDArticulo)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.btnCategoria)
        Me.Controls.Add(Me.btnSubCategoria)
        Me.Controls.Add(Me.btnDepartamento)
        Me.Controls.Add(Me.btnBuscarTipoProducto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtSubCategoria)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.txtTipoProducto)
        Me.Controls.Add(Me.txtIDCategoria)
        Me.Controls.Add(Me.txtIDSubCategoria)
        Me.Controls.Add(Me.txtIDDepartamento)
        Me.Controls.Add(Me.txtIDTipoProducto)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporte_series_garantias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "78"
        Me.Text = "Reportes de series y garantías"
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
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
    Private WithEvents btnCategoria As System.Windows.Forms.Button
    Private WithEvents btnSubCategoria As System.Windows.Forms.Button
    Private WithEvents btnDepartamento As System.Windows.Forms.Button
    Private WithEvents btnBuscarTipoProducto As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Private WithEvents btnGarantia As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGarantia As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGarantia As System.Windows.Forms.TextBox
    Private WithEvents btnSuplidor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents btnMarca As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbxTaller As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cbxServicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbxInstalacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbxMantenimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbxTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxManoObra As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbxVariacionValor As System.Windows.Forms.ComboBox
End Class
