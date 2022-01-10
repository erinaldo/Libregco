<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_detalle_compras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_detalle_compras))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cbxTipoOrden = New System.Windows.Forms.ComboBox()
        Me.CbxOrden = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.cbxNCF = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxTipoItbis = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBuscarSubCat = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.btnBuscarCategoria = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.btnBuscarDepartamento = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.btnSuplidor = New System.Windows.Forms.Button()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.btnRecepcion = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtRecepcion = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDMarca = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDRecepcion = New System.Windows.Forms.TextBox()
        Me.btnBuscarTipoSuplidor = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.btnBuscarUsuario = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtIDUsuario = New System.Windows.Forms.TextBox()
        Me.btnBuscarTipoProducto = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.txtIDTipoProducto = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 482)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 374)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 257
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(465, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(260, 95)
        Me.MenuStrip1.TabIndex = 40
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
        Me.GbOpciones.Controls.Add(Me.Label19)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(262, 96)
        Me.GbOpciones.TabIndex = 36
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
        Me.cbxTipoOrden.TabIndex = 39
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
        Me.CbxOrden.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 15)
        Me.Label19.TabIndex = 48
        Me.Label19.Text = "Campo"
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
        Me.CbxFormato.TabIndex = 37
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
        Me.GroupBox1.TabIndex = 31
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
        Me.rdbExcel.TabIndex = 35
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
        Me.rdbPDF.TabIndex = 34
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
        Me.rdbImpresora.TabIndex = 33
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
        Me.rdbPresentacion.TabIndex = 32
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.cbxNCF)
        Me.GbCondiciones.Controls.Add(Me.Label18)
        Me.GbCondiciones.Controls.Add(Me.Label15)
        Me.GbCondiciones.Controls.Add(Me.cbxTipoItbis)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.Label17)
        Me.GbCondiciones.Controls.Add(Me.cbxCondicion)
        Me.GbCondiciones.Controls.Add(Me.Label14)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(517, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 361)
        Me.GbCondiciones.TabIndex = 256
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'cbxNCF
        '
        Me.cbxNCF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNCF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxNCF.FormattingEnabled = True
        Me.cbxNCF.Location = New System.Drawing.Point(10, 196)
        Me.cbxNCF.Name = "cbxNCF"
        Me.cbxNCF.Size = New System.Drawing.Size(177, 23)
        Me.cbxNCF.TabIndex = 101
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(10, 178)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 15)
        Me.Label18.TabIndex = 107
        Me.Label18.Text = "Comprobante Fiscal"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(10, 222)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 15)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "Tipo Itbis"
        '
        'cbxTipoItbis
        '
        Me.cbxTipoItbis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoItbis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoItbis.FormattingEnabled = True
        Me.cbxTipoItbis.Items.AddRange(New Object() {"Todos", "Incluido", "No Incluido", "No Itbis"})
        Me.cbxTipoItbis.Location = New System.Drawing.Point(10, 240)
        Me.cbxTipoItbis.Name = "cbxTipoItbis"
        Me.cbxTipoItbis.Size = New System.Drawing.Size(177, 23)
        Me.cbxTipoItbis.TabIndex = 102
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(10, 310)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 15)
        Me.Label16.TabIndex = 106
        Me.Label16.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(10, 328)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(177, 23)
        Me.cbxEstado.TabIndex = 104
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(10, 266)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 15)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(10, 284)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(177, 23)
        Me.cbxCondicion.TabIndex = 103
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Label14.Location = New System.Drawing.Point(3, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(184, 2)
        Me.Label14.TabIndex = 98
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(10, 17)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 26
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 49)
        Me.GroupBox2.TabIndex = 255
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las Fechas"
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
        'btnBuscarSubCat
        '
        Me.btnBuscarSubCat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarSubCat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarSubCat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarSubCat.Image = CType(resources.GetObject("btnBuscarSubCat.Image"), System.Drawing.Image)
        Me.btnBuscarSubCat.Location = New System.Drawing.Point(176, 228)
        Me.btnBuscarSubCat.Name = "btnBuscarSubCat"
        Me.btnBuscarSubCat.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarSubCat.TabIndex = 268
        Me.btnBuscarSubCat.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(12, 232)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 15)
        Me.Label13.TabIndex = 301
        Me.Label13.Text = "Sub-Cat."
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Enabled = False
        Me.txtSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubCategoria.Location = New System.Drawing.Point(198, 228)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.ReadOnly = True
        Me.txtSubCategoria.Size = New System.Drawing.Size(313, 23)
        Me.txtSubCategoria.TabIndex = 302
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(75, 228)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSubCategoria.TabIndex = 267
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarCategoria
        '
        Me.btnBuscarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCategoria.Image = CType(resources.GetObject("btnBuscarCategoria.Image"), System.Drawing.Image)
        Me.btnBuscarCategoria.Location = New System.Drawing.Point(176, 199)
        Me.btnBuscarCategoria.Name = "btnBuscarCategoria"
        Me.btnBuscarCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCategoria.TabIndex = 266
        Me.btnBuscarCategoria.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(12, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 299
        Me.Label12.Text = "Categoría"
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategoria.Location = New System.Drawing.Point(198, 199)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(313, 23)
        Me.txtCategoria.TabIndex = 300
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCategoria.Location = New System.Drawing.Point(75, 199)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCategoria.TabIndex = 265
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarDepartamento
        '
        Me.btnBuscarDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarDepartamento.Image = CType(resources.GetObject("btnBuscarDepartamento.Image"), System.Drawing.Image)
        Me.btnBuscarDepartamento.Location = New System.Drawing.Point(176, 170)
        Me.btnBuscarDepartamento.Name = "btnBuscarDepartamento"
        Me.btnBuscarDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarDepartamento.TabIndex = 264
        Me.btnBuscarDepartamento.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(12, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 297
        Me.Label7.Text = "Depart."
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartamento.Location = New System.Drawing.Point(198, 170)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(313, 23)
        Me.txtDepartamento.TabIndex = 298
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDepartamento.Location = New System.Drawing.Point(75, 170)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDDepartamento.TabIndex = 263
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarProducto.Image = CType(resources.GetObject("btnBuscarProducto.Image"), System.Drawing.Image)
        Me.btnBuscarProducto.Location = New System.Drawing.Point(176, 112)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarProducto.TabIndex = 262
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(12, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 295
        Me.Label6.Text = "Producto"
        '
        'txtArticulo
        '
        Me.txtArticulo.Enabled = False
        Me.txtArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtArticulo.Location = New System.Drawing.Point(198, 112)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.ReadOnly = True
        Me.txtArticulo.Size = New System.Drawing.Size(313, 23)
        Me.txtArticulo.TabIndex = 296
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(75, 112)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDArticulo.TabIndex = 261
        Me.txtIDArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSuplidor
        '
        Me.btnSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSuplidor.Image = CType(resources.GetObject("btnSuplidor.Image"), System.Drawing.Image)
        Me.btnSuplidor.Location = New System.Drawing.Point(176, 54)
        Me.btnSuplidor.Name = "btnSuplidor"
        Me.btnSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnSuplidor.TabIndex = 274
        Me.btnSuplidor.UseVisualStyleBackColor = True
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(176, 286)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 272
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'btnMarca
        '
        Me.btnMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMarca.Image = CType(resources.GetObject("btnMarca.Image"), System.Drawing.Image)
        Me.btnMarca.Location = New System.Drawing.Point(176, 257)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(23, 23)
        Me.btnMarca.TabIndex = 270
        Me.btnMarca.UseVisualStyleBackColor = True
        '
        'btnRecepcion
        '
        Me.btnRecepcion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRecepcion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRecepcion.Image = CType(resources.GetObject("btnRecepcion.Image"), System.Drawing.Image)
        Me.btnRecepcion.Location = New System.Drawing.Point(176, 315)
        Me.btnRecepcion.Name = "btnRecepcion"
        Me.btnRecepcion.Size = New System.Drawing.Size(23, 23)
        Me.btnRecepcion.TabIndex = 276
        Me.btnRecepcion.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 286
        Me.Label5.Text = "Suplidor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 285
        Me.Label4.Text = "Recepción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = "Marca"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(198, 286)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(313, 23)
        Me.txtAlmacen.TabIndex = 290
        '
        'txtMarca
        '
        Me.txtMarca.Enabled = False
        Me.txtMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMarca.Location = New System.Drawing.Point(198, 257)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(313, 23)
        Me.txtMarca.TabIndex = 289
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(198, 54)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(313, 23)
        Me.txtSuplidor.TabIndex = 288
        '
        'txtRecepcion
        '
        Me.txtRecepcion.Enabled = False
        Me.txtRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRecepcion.Location = New System.Drawing.Point(198, 315)
        Me.txtRecepcion.Name = "txtRecepcion"
        Me.txtRecepcion.ReadOnly = True
        Me.txtRecepcion.Size = New System.Drawing.Size(313, 23)
        Me.txtRecepcion.TabIndex = 287
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(75, 286)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 271
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDMarca
        '
        Me.txtIDMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMarca.Location = New System.Drawing.Point(75, 257)
        Me.txtIDMarca.Name = "txtIDMarca"
        Me.txtIDMarca.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMarca.TabIndex = 269
        Me.txtIDMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(75, 54)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSuplidor.TabIndex = 273
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDRecepcion
        '
        Me.txtIDRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDRecepcion.Location = New System.Drawing.Point(75, 315)
        Me.txtIDRecepcion.Name = "txtIDRecepcion"
        Me.txtIDRecepcion.Size = New System.Drawing.Size(102, 23)
        Me.txtIDRecepcion.TabIndex = 275
        Me.txtIDRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarTipoSuplidor
        '
        Me.btnBuscarTipoSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoSuplidor.Image = CType(resources.GetObject("btnBuscarTipoSuplidor.Image"), System.Drawing.Image)
        Me.btnBuscarTipoSuplidor.Location = New System.Drawing.Point(176, 83)
        Me.btnBuscarTipoSuplidor.Name = "btnBuscarTipoSuplidor"
        Me.btnBuscarTipoSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoSuplidor.TabIndex = 304
        Me.btnBuscarTipoSuplidor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 305
        Me.Label1.Text = "Tipo Sup."
        '
        'txtTipoSuplidor
        '
        Me.txtTipoSuplidor.Enabled = False
        Me.txtTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoSuplidor.Location = New System.Drawing.Point(198, 83)
        Me.txtTipoSuplidor.Name = "txtTipoSuplidor"
        Me.txtTipoSuplidor.ReadOnly = True
        Me.txtTipoSuplidor.Size = New System.Drawing.Size(313, 23)
        Me.txtTipoSuplidor.TabIndex = 306
        '
        'txtIDTipoSuplidor
        '
        Me.txtIDTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoSuplidor.Location = New System.Drawing.Point(75, 83)
        Me.txtIDTipoSuplidor.Name = "txtIDTipoSuplidor"
        Me.txtIDTipoSuplidor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoSuplidor.TabIndex = 303
        Me.txtIDTipoSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarUsuario
        '
        Me.btnBuscarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarUsuario.Image = CType(resources.GetObject("btnBuscarUsuario.Image"), System.Drawing.Image)
        Me.btnBuscarUsuario.Location = New System.Drawing.Point(176, 344)
        Me.btnBuscarUsuario.Name = "btnBuscarUsuario"
        Me.btnBuscarUsuario.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarUsuario.TabIndex = 308
        Me.btnBuscarUsuario.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(12, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 309
        Me.Label8.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(198, 344)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(313, 23)
        Me.txtUsuario.TabIndex = 310
        '
        'txtIDUsuario
        '
        Me.txtIDUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDUsuario.Location = New System.Drawing.Point(75, 344)
        Me.txtIDUsuario.Name = "txtIDUsuario"
        Me.txtIDUsuario.Size = New System.Drawing.Size(102, 23)
        Me.txtIDUsuario.TabIndex = 307
        Me.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarTipoProducto
        '
        Me.btnBuscarTipoProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarTipoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoProducto.Image = CType(resources.GetObject("btnBuscarTipoProducto.Image"), System.Drawing.Image)
        Me.btnBuscarTipoProducto.Location = New System.Drawing.Point(176, 141)
        Me.btnBuscarTipoProducto.Name = "btnBuscarTipoProducto"
        Me.btnBuscarTipoProducto.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoProducto.TabIndex = 312
        Me.btnBuscarTipoProducto.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(12, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 15)
        Me.Label11.TabIndex = 313
        Me.Label11.Text = "Tipo"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Enabled = False
        Me.txtTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoProducto.Location = New System.Drawing.Point(198, 141)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ReadOnly = True
        Me.txtTipoProducto.Size = New System.Drawing.Size(313, 23)
        Me.txtTipoProducto.TabIndex = 314
        '
        'txtIDTipoProducto
        '
        Me.txtIDTipoProducto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoProducto.Location = New System.Drawing.Point(75, 141)
        Me.txtIDTipoProducto.Name = "txtIDTipoProducto"
        Me.txtIDTipoProducto.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoProducto.TabIndex = 311
        Me.txtIDTipoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'frm_reporte_detalle_compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 507)
        Me.Controls.Add(Me.btnBuscarTipoProducto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTipoProducto)
        Me.Controls.Add(Me.txtIDTipoProducto)
        Me.Controls.Add(Me.btnBuscarUsuario)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtIDUsuario)
        Me.Controls.Add(Me.btnBuscarTipoSuplidor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoSuplidor)
        Me.Controls.Add(Me.txtIDTipoSuplidor)
        Me.Controls.Add(Me.btnBuscarSubCat)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSubCategoria)
        Me.Controls.Add(Me.txtIDSubCategoria)
        Me.Controls.Add(Me.btnBuscarCategoria)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtIDCategoria)
        Me.Controls.Add(Me.btnBuscarDepartamento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.txtIDDepartamento)
        Me.Controls.Add(Me.btnBuscarProducto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.txtIDArticulo)
        Me.Controls.Add(Me.btnSuplidor)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.btnMarca)
        Me.Controls.Add(Me.btnRecepcion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtMarca)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.txtRecepcion)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.txtIDMarca)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.txtIDRecepcion)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_detalle_compras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "36"
        Me.Text = "Reportes de detalles de compras"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnLimpiar As ToolStripMenuItem
    Friend WithEvents btnCerrar As ToolStripMenuItem
    Friend WithEvents GbOpciones As GroupBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cbxTipoOrden As ComboBox
    Friend WithEvents CbxOrden As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents CbxFormato As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicSalida As PictureBox
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents GbCondiciones As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents chkResumir As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnBuscarSubCat As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSubCategoria As TextBox
    Friend WithEvents txtIDSubCategoria As TextBox
    Friend WithEvents btnBuscarCategoria As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCategoria As TextBox
    Friend WithEvents txtIDCategoria As TextBox
    Friend WithEvents btnBuscarDepartamento As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDepartamento As TextBox
    Friend WithEvents txtIDDepartamento As TextBox
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtArticulo As TextBox
    Friend WithEvents txtIDArticulo As TextBox
    Friend WithEvents btnSuplidor As Button
    Friend WithEvents btnAlmacen As Button
    Friend WithEvents btnMarca As Button
    Friend WithEvents btnRecepcion As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAlmacen As TextBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents txtSuplidor As TextBox
    Friend WithEvents txtRecepcion As TextBox
    Friend WithEvents txtIDAlmacen As TextBox
    Friend WithEvents txtIDMarca As TextBox
    Friend WithEvents txtIDSuplidor As TextBox
    Friend WithEvents txtIDRecepcion As TextBox
    Friend WithEvents btnBuscarTipoSuplidor As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTipoSuplidor As TextBox
    Friend WithEvents txtIDTipoSuplidor As TextBox
    Friend WithEvents btnBuscarUsuario As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtIDUsuario As TextBox
    Friend WithEvents btnBuscarTipoProducto As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTipoProducto As TextBox
    Friend WithEvents txtIDTipoProducto As TextBox
    Friend WithEvents cbxNCF As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cbxTipoItbis As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbxEstado As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cbxCondicion As ComboBox
    Friend WithEvents Fecha As Timer
End Class
