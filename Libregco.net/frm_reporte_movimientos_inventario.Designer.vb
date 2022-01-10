<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_movimientos_inventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_movimientos_inventario))
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.chkSoloconExistencia = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkEspecificarDesde = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.btnBuscarTipoProducto = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.txtIDTipoProducto = New System.Windows.Forms.TextBox()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.btnBuscarDepartamento = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.btnCategoria = New System.Windows.Forms.Button()
        Me.btnSubCategoria = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkReparaciones = New System.Windows.Forms.CheckBox()
        Me.chkTransferencias = New System.Windows.Forms.CheckBox()
        Me.chkDevCompras = New System.Windows.Forms.CheckBox()
        Me.chkDevVentas = New System.Windows.Forms.CheckBox()
        Me.chkSalidas = New System.Windows.Forms.CheckBox()
        Me.chkEntradas = New System.Windows.Forms.CheckBox()
        Me.chkVentas = New System.Windows.Forms.CheckBox()
        Me.chkCompras = New System.Windows.Forms.CheckBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.chkEntradaRep = New System.Windows.Forms.CheckBox()
        Me.GbCondiciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.chkSoloconExistencia)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(523, 4)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 255)
        Me.GbCondiciones.TabIndex = 259
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'chkSoloconExistencia
        '
        Me.chkSoloconExistencia.AutoSize = True
        Me.chkSoloconExistencia.Location = New System.Drawing.Point(10, 47)
        Me.chkSoloconExistencia.Name = "chkSoloconExistencia"
        Me.chkSoloconExistencia.Size = New System.Drawing.Size(131, 19)
        Me.chkSoloconExistencia.TabIndex = 99
        Me.chkSoloconExistencia.Text = "Solos con existencia"
        Me.chkSoloconExistencia.UseVisualStyleBackColor = True
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
        Me.chkResumir.TabIndex = 97
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(7, 211)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 15)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(10, 229)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 91
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 352)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 258
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(465, 6)
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
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.chkEspecificarDesde)
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 49)
        Me.GroupBox2.TabIndex = 257
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las Fechas"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(315, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(2, 25)
        Me.Label17.TabIndex = 288
        '
        'chkEspecificarDesde
        '
        Me.chkEspecificarDesde.AutoSize = True
        Me.chkEspecificarDesde.Checked = True
        Me.chkEspecificarDesde.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificarDesde.Location = New System.Drawing.Point(328, 20)
        Me.chkEspecificarDesde.Name = "chkEspecificarDesde"
        Me.chkEspecificarDesde.Size = New System.Drawing.Size(135, 19)
        Me.chkEspecificarDesde.TabIndex = 287
        Me.chkEspecificarDesde.Text = "No especificar Desde"
        Me.chkEspecificarDesde.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = "yyyy-MM-dd"
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(203, 17)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinal.TabIndex = 134
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = "yyyy-MM-dd"
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 460)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(725, 25)
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
        'btnBuscarTipoProducto
        '
        Me.btnBuscarTipoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoProducto.Image = CType(resources.GetObject("btnBuscarTipoProducto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoProducto.Location = New System.Drawing.Point(195, 236)
        Me.btnBuscarTipoProducto.Name = "btnBuscarTipoProducto"
        Me.btnBuscarTipoProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoProducto.TabIndex = 296
        Me.btnBuscarTipoProducto.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 295
        Me.Label8.Text = "Tipo Producto"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Location = New System.Drawing.Point(217, 236)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(298, 23)
        Me.txtTipoProducto.TabIndex = 297
        '
        'txtIDTipoProducto
        '
        Me.txtIDTipoProducto.Location = New System.Drawing.Point(94, 236)
        Me.txtIDTipoProducto.Name = "txtIDTipoProducto"
        Me.txtIDTipoProducto.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoProducto.TabIndex = 294
        Me.txtIDTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(195, 207)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 292
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(7, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 290
        Me.Label3.Text = "Almacén"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(217, 207)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(298, 23)
        Me.txtAlmacen.TabIndex = 293
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(94, 207)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 291
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarDepartamento
        '
        Me.btnBuscarDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarDepartamento.Image = CType(resources.GetObject("btnBuscarDepartamento.Image"), System.Drawing.Image)
        Me.btnBuscarDepartamento.Location = New System.Drawing.Point(196, 91)
        Me.btnBuscarDepartamento.Name = "btnBuscarDepartamento"
        Me.btnBuscarDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarDepartamento.TabIndex = 283
        Me.btnBuscarDepartamento.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(7, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 288
        Me.Label7.Text = "Departamento"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartamento.Location = New System.Drawing.Point(218, 91)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(298, 23)
        Me.txtDepartamento.TabIndex = 289
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDepartamento.Location = New System.Drawing.Point(95, 91)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDDepartamento.TabIndex = 282
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(195, 178)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(23, 23)
        Me.btnMarca.TabIndex = 285
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(7, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 286
        Me.Label2.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMarca.Location = New System.Drawing.Point(217, 178)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(298, 23)
        Me.txtMarca.TabIndex = 287
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMarca.Location = New System.Drawing.Point(94, 178)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMarca.TabIndex = 284
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(196, 62)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarProducto.TabIndex = 279
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(7, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 280
        Me.Label6.Text = "Producto"
        '
        'txtArticulo
        '
        Me.txtArticulo.Enabled = False
        Me.txtArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtArticulo.Location = New System.Drawing.Point(218, 62)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.ReadOnly = True
        Me.txtArticulo.Size = New System.Drawing.Size(298, 23)
        Me.txtArticulo.TabIndex = 281
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(95, 62)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDArticulo.TabIndex = 278
        Me.txtIDArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCategoria
        '
        Me.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCategoria.Image = CType(resources.GetObject("btnCategoria.Image"), System.Drawing.Image)
        Me.btnCategoria.Location = New System.Drawing.Point(196, 120)
        Me.btnCategoria.Name = "btnCategoria"
        Me.btnCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnCategoria.TabIndex = 304
        Me.btnCategoria.UseVisualStyleBackColor = True
        '
        'btnSubCategoria
        '
        Me.btnSubCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSubCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSubCategoria.Image = CType(resources.GetObject("btnSubCategoria.Image"), System.Drawing.Image)
        Me.btnSubCategoria.Location = New System.Drawing.Point(196, 149)
        Me.btnSubCategoria.Name = "btnSubCategoria"
        Me.btnSubCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnSubCategoria.TabIndex = 300
        Me.btnSubCategoria.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 123)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 302
        Me.Label11.Text = "Categoría"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Sub-Categoría"
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Location = New System.Drawing.Point(218, 120)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(297, 23)
        Me.txtCategoria.TabIndex = 305
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Enabled = False
        Me.txtSubCategoria.Location = New System.Drawing.Point(218, 149)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.ReadOnly = True
        Me.txtSubCategoria.Size = New System.Drawing.Size(297, 23)
        Me.txtSubCategoria.TabIndex = 301
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Location = New System.Drawing.Point(95, 120)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCategoria.TabIndex = 303
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(95, 149)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSubCategoria.TabIndex = 299
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkEntradaRep)
        Me.GroupBox3.Controls.Add(Me.chkReparaciones)
        Me.GroupBox3.Controls.Add(Me.chkTransferencias)
        Me.GroupBox3.Controls.Add(Me.chkDevCompras)
        Me.GroupBox3.Controls.Add(Me.chkDevVentas)
        Me.GroupBox3.Controls.Add(Me.chkSalidas)
        Me.GroupBox3.Controls.Add(Me.chkEntradas)
        Me.GroupBox3.Controls.Add(Me.chkVentas)
        Me.GroupBox3.Controls.Add(Me.chkCompras)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 265)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(707, 75)
        Me.GroupBox3.TabIndex = 306
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transacciones de Inventarios"
        '
        'chkReparaciones
        '
        Me.chkReparaciones.AutoSize = True
        Me.chkReparaciones.Checked = True
        Me.chkReparaciones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReparaciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkReparaciones.Location = New System.Drawing.Point(347, 21)
        Me.chkReparaciones.Name = "chkReparaciones"
        Me.chkReparaciones.Size = New System.Drawing.Size(96, 19)
        Me.chkReparaciones.TabIndex = 7
        Me.chkReparaciones.Text = "Reparaciones"
        Me.chkReparaciones.UseVisualStyleBackColor = True
        '
        'chkTransferencias
        '
        Me.chkTransferencias.AutoSize = True
        Me.chkTransferencias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkTransferencias.Location = New System.Drawing.Point(347, 45)
        Me.chkTransferencias.Name = "chkTransferencias"
        Me.chkTransferencias.Size = New System.Drawing.Size(101, 19)
        Me.chkTransferencias.TabIndex = 6
        Me.chkTransferencias.Text = "Transferencias"
        Me.chkTransferencias.UseVisualStyleBackColor = True
        '
        'chkDevCompras
        '
        Me.chkDevCompras.AutoSize = True
        Me.chkDevCompras.Checked = True
        Me.chkDevCompras.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDevCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDevCompras.Location = New System.Drawing.Point(225, 46)
        Me.chkDevCompras.Name = "chkDevCompras"
        Me.chkDevCompras.Size = New System.Drawing.Size(116, 19)
        Me.chkDevCompras.TabIndex = 5
        Me.chkDevCompras.Text = "Dev. de Compras"
        Me.chkDevCompras.UseVisualStyleBackColor = True
        '
        'chkDevVentas
        '
        Me.chkDevVentas.AutoSize = True
        Me.chkDevVentas.Checked = True
        Me.chkDevVentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDevVentas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkDevVentas.Location = New System.Drawing.Point(225, 21)
        Me.chkDevVentas.Name = "chkDevVentas"
        Me.chkDevVentas.Size = New System.Drawing.Size(102, 19)
        Me.chkDevVentas.TabIndex = 4
        Me.chkDevVentas.Text = "Dev. de Ventas"
        Me.chkDevVentas.UseVisualStyleBackColor = True
        '
        'chkSalidas
        '
        Me.chkSalidas.AutoSize = True
        Me.chkSalidas.Checked = True
        Me.chkSalidas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSalidas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSalidas.Location = New System.Drawing.Point(91, 46)
        Me.chkSalidas.Name = "chkSalidas"
        Me.chkSalidas.Size = New System.Drawing.Size(119, 19)
        Me.chkSalidas.TabIndex = 3
        Me.chkSalidas.Text = "Ajustes de Salidas"
        Me.chkSalidas.UseVisualStyleBackColor = True
        '
        'chkEntradas
        '
        Me.chkEntradas.AutoSize = True
        Me.chkEntradas.Checked = True
        Me.chkEntradas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEntradas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEntradas.Location = New System.Drawing.Point(91, 21)
        Me.chkEntradas.Name = "chkEntradas"
        Me.chkEntradas.Size = New System.Drawing.Size(128, 19)
        Me.chkEntradas.TabIndex = 2
        Me.chkEntradas.Text = "Ajustes de Entradas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkEntradas.UseVisualStyleBackColor = True
        '
        'chkVentas
        '
        Me.chkVentas.AutoSize = True
        Me.chkVentas.Checked = True
        Me.chkVentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVentas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkVentas.Location = New System.Drawing.Point(11, 46)
        Me.chkVentas.Name = "chkVentas"
        Me.chkVentas.Size = New System.Drawing.Size(60, 19)
        Me.chkVentas.TabIndex = 1
        Me.chkVentas.Text = "Ventas"
        Me.chkVentas.UseVisualStyleBackColor = True
        '
        'chkCompras
        '
        Me.chkCompras.AutoSize = True
        Me.chkCompras.Checked = True
        Me.chkCompras.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompras.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkCompras.Location = New System.Drawing.Point(11, 21)
        Me.chkCompras.Name = "chkCompras"
        Me.chkCompras.Size = New System.Drawing.Size(74, 19)
        Me.chkCompras.TabIndex = 0
        Me.chkCompras.Text = "Compras"
        Me.chkCompras.UseVisualStyleBackColor = True
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'chkEntradaRep
        '
        Me.chkEntradaRep.AutoSize = True
        Me.chkEntradaRep.Checked = True
        Me.chkEntradaRep.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEntradaRep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEntradaRep.Location = New System.Drawing.Point(459, 22)
        Me.chkEntradaRep.Name = "chkEntradaRep"
        Me.chkEntradaRep.Size = New System.Drawing.Size(146, 19)
        Me.chkEntradaRep.TabIndex = 8
        Me.chkEntradaRep.Text = "Entradas de reparación"
        Me.chkEntradaRep.UseVisualStyleBackColor = True
        '
        'frm_reporte_movimientos_inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 485)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCategoria)
        Me.Controls.Add(Me.btnSubCategoria)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtSubCategoria)
        Me.Controls.Add(Me.txtIDCategoria)
        Me.Controls.Add(Me.txtIDSubCategoria)
        Me.Controls.Add(Me.btnBuscarTipoProducto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTipoProducto)
        Me.Controls.Add(Me.txtIDTipoProducto)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.btnBuscarDepartamento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.txtIDDepartamento)
        Me.Controls.Add(Me.btnMarca)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.txtIDMarca)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.txtIDArticulo)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_movimientos_inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "40"
        Me.Text = "Reportes de movimientos de inventario"
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents chkSoloconExistencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
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
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Private WithEvents btnBuscarTipoProducto As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoProducto As System.Windows.Forms.TextBox
    Friend WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarDepartamento As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents btnMarca As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Private WithEvents btnCategoria As System.Windows.Forms.Button
    Private WithEvents btnSubCategoria As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTransferencias As System.Windows.Forms.CheckBox
    Friend WithEvents chkDevCompras As System.Windows.Forms.CheckBox
    Friend WithEvents chkDevVentas As System.Windows.Forms.CheckBox
    Friend WithEvents chkSalidas As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntradas As System.Windows.Forms.CheckBox
    Friend WithEvents chkVentas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompras As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkEspecificarDesde As System.Windows.Forms.CheckBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents chkReparaciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkEntradaRep As System.Windows.Forms.CheckBox
End Class
