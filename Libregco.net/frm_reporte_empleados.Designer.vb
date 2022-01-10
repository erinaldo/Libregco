<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_empleados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_empleados))
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIDEmpleadoDesde = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscarArtDesde = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIDEmpleadoHasta = New System.Windows.Forms.TextBox()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CbxPeriodo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxAlertas = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxHabilitadoNomina = New System.Windows.Forms.ComboBox()
        Me.btnNacionalidad = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNacionalidad = New System.Windows.Forms.TextBox()
        Me.txtIDNacionalidad = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEspecificarVenc = New System.Windows.Forms.CheckBox()
        Me.dtpIngresoFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpIngresoInicial = New System.Windows.Forms.DateTimePicker()
        Me.btnGenero = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGenero = New System.Windows.Forms.TextBox()
        Me.txtIDGenero = New System.Windows.Forms.TextBox()
        Me.btnProvincia = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.txtIDProvincia = New System.Windows.Forms.TextBox()
        Me.btnMunicipio = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.txtIDMunicipio = New System.Windows.Forms.TextBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.btnAlmacen = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.txtIDAlmacen = New System.Windows.Forms.TextBox()
        Me.btnNomina = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNomina = New System.Windows.Forms.TextBox()
        Me.txtIDNomina = New System.Windows.Forms.TextBox()
        Me.btnCargo = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.txtIDCargo = New System.Windows.Forms.TextBox()
        Me.btnTanda = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTanda = New System.Windows.Forms.TextBox()
        Me.txtIDTanda = New System.Windows.Forms.TextBox()
        Me.btnARS = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtARS = New System.Windows.Forms.TextBox()
        Me.txtIDARS = New System.Windows.Forms.TextBox()
        Me.btnAFP = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtAFP = New System.Windows.Forms.TextBox()
        Me.txtIDAfp = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkSinEspecNacimiento = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinalNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.DtpFechaInicialNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnDepartamento = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 612)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 254
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
        Me.Panel1.Location = New System.Drawing.Point(0, 502)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 255
        '
        'MenuStrip1
        '
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIDEmpleadoDesde)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.btnBuscarArtDesde)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtIDEmpleadoHasta)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 49)
        Me.GroupBox2.TabIndex = 256
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Código"
        '
        'txtIDEmpleadoDesde
        '
        Me.txtIDEmpleadoDesde.Location = New System.Drawing.Point(72, 19)
        Me.txtIDEmpleadoDesde.Name = "txtIDEmpleadoDesde"
        Me.txtIDEmpleadoDesde.Size = New System.Drawing.Size(115, 23)
        Me.txtIDEmpleadoDesde.TabIndex = 0
        Me.txtIDEmpleadoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(192, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Hasta"
        '
        'btnBuscarArtDesde
        '
        Me.btnBuscarArtDesde.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarArtDesde.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarArtDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarArtDesde.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarArtDesde.Location = New System.Drawing.Point(50, 19)
        Me.btnBuscarArtDesde.Name = "btnBuscarArtDesde"
        Me.btnBuscarArtDesde.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarArtDesde.TabIndex = 19
        Me.btnBuscarArtDesde.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Desde"
        '
        'txtIDEmpleadoHasta
        '
        Me.txtIDEmpleadoHasta.Location = New System.Drawing.Point(235, 19)
        Me.txtIDEmpleadoHasta.Name = "txtIDEmpleadoHasta"
        Me.txtIDEmpleadoHasta.Size = New System.Drawing.Size(115, 23)
        Me.txtIDEmpleadoHasta.TabIndex = 50
        Me.txtIDEmpleadoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.Label24)
        Me.GbCondiciones.Controls.Add(Me.CbxPeriodo)
        Me.GbCondiciones.Controls.Add(Me.Label3)
        Me.GbCondiciones.Controls.Add(Me.cbxAlertas)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.Label15)
        Me.GbCondiciones.Controls.Add(Me.cbxHabilitadoNomina)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(523, 3)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 493)
        Me.GbCondiciones.TabIndex = 257
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(7, 312)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(94, 15)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Período de Pago"
        '
        'CbxPeriodo
        '
        Me.CbxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxPeriodo.FormattingEnabled = True
        Me.CbxPeriodo.Location = New System.Drawing.Point(10, 330)
        Me.CbxPeriodo.Name = "CbxPeriodo"
        Me.CbxPeriodo.Size = New System.Drawing.Size(170, 23)
        Me.CbxPeriodo.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(10, 356)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Alertas"
        '
        'cbxAlertas
        '
        Me.cbxAlertas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlertas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlertas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlertas.FormattingEnabled = True
        Me.cbxAlertas.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxAlertas.Location = New System.Drawing.Point(10, 374)
        Me.cbxAlertas.Name = "cbxAlertas"
        Me.cbxAlertas.Size = New System.Drawing.Size(170, 23)
        Me.cbxAlertas.TabIndex = 30
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
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(10, 444)
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
        Me.cbxEstado.Location = New System.Drawing.Point(10, 462)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(10, 400)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 15)
        Me.Label15.TabIndex = 90
        Me.Label15.Text = "Habilitado en nómina"
        '
        'cbxHabilitadoNomina
        '
        Me.cbxHabilitadoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxHabilitadoNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxHabilitadoNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxHabilitadoNomina.FormattingEnabled = True
        Me.cbxHabilitadoNomina.Items.AddRange(New Object() {"Todos", "Sí", "No"})
        Me.cbxHabilitadoNomina.Location = New System.Drawing.Point(10, 418)
        Me.cbxHabilitadoNomina.Name = "cbxHabilitadoNomina"
        Me.cbxHabilitadoNomina.Size = New System.Drawing.Size(170, 23)
        Me.cbxHabilitadoNomina.TabIndex = 31
        '
        'btnNacionalidad
        '
        Me.btnNacionalidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNacionalidad.Image = CType(resources.GetObject("btnNacionalidad.Image"), System.Drawing.Image)
        Me.btnNacionalidad.Location = New System.Drawing.Point(187, 153)
        Me.btnNacionalidad.Name = "btnNacionalidad"
        Me.btnNacionalidad.Size = New System.Drawing.Size(23, 23)
        Me.btnNacionalidad.TabIndex = 259
        Me.btnNacionalidad.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(4, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Nacionalidad"
        '
        'txtNacionalidad
        '
        Me.txtNacionalidad.Enabled = False
        Me.txtNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidad.Location = New System.Drawing.Point(209, 153)
        Me.txtNacionalidad.Name = "txtNacionalidad"
        Me.txtNacionalidad.ReadOnly = True
        Me.txtNacionalidad.Size = New System.Drawing.Size(308, 23)
        Me.txtNacionalidad.TabIndex = 261
        '
        'txtIDNacionalidad
        '
        Me.txtIDNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNacionalidad.Location = New System.Drawing.Point(86, 153)
        Me.txtIDNacionalidad.Name = "txtIDNacionalidad"
        Me.txtIDNacionalidad.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNacionalidad.TabIndex = 258
        Me.txtIDNacionalidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.chkEspecificarVenc)
        Me.GroupBox3.Controls.Add(Me.dtpIngresoFinal)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtpIngresoInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 55)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox3.TabIndex = 262
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha de Ingreso"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(121, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(2, 25)
        Me.Label14.TabIndex = 284
        '
        'chkEspecificarVenc
        '
        Me.chkEspecificarVenc.AutoSize = True
        Me.chkEspecificarVenc.Checked = True
        Me.chkEspecificarVenc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificarVenc.Location = New System.Drawing.Point(11, 20)
        Me.chkEspecificarVenc.Name = "chkEspecificarVenc"
        Me.chkEspecificarVenc.Size = New System.Drawing.Size(101, 19)
        Me.chkEspecificarVenc.TabIndex = 16
        Me.chkEspecificarVenc.Text = "Sin Especificar"
        Me.chkEspecificarVenc.UseVisualStyleBackColor = True
        '
        'dtpIngresoFinal
        '
        Me.dtpIngresoFinal.CustomFormat = ""
        Me.dtpIngresoFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoFinal.Location = New System.Drawing.Point(297, 15)
        Me.dtpIngresoFinal.Name = "dtpIngresoFinal"
        Me.dtpIngresoFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpIngresoFinal.TabIndex = 18
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
        'dtpIngresoInicial
        '
        Me.dtpIngresoInicial.CustomFormat = ""
        Me.dtpIngresoInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpIngresoInicial.Name = "dtpIngresoInicial"
        Me.dtpIngresoInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpIngresoInicial.TabIndex = 17
        '
        'btnGenero
        '
        Me.btnGenero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGenero.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGenero.Image = CType(resources.GetObject("btnGenero.Image"), System.Drawing.Image)
        Me.btnGenero.Location = New System.Drawing.Point(187, 182)
        Me.btnGenero.Name = "btnGenero"
        Me.btnGenero.Size = New System.Drawing.Size(23, 23)
        Me.btnGenero.TabIndex = 264
        Me.btnGenero.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "Género"
        '
        'txtGenero
        '
        Me.txtGenero.Enabled = False
        Me.txtGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGenero.Location = New System.Drawing.Point(209, 182)
        Me.txtGenero.Name = "txtGenero"
        Me.txtGenero.ReadOnly = True
        Me.txtGenero.Size = New System.Drawing.Size(308, 23)
        Me.txtGenero.TabIndex = 266
        '
        'txtIDGenero
        '
        Me.txtIDGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGenero.Location = New System.Drawing.Point(86, 182)
        Me.txtIDGenero.Name = "txtIDGenero"
        Me.txtIDGenero.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGenero.TabIndex = 263
        Me.txtIDGenero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnProvincia
        '
        Me.btnProvincia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnProvincia.Image = CType(resources.GetObject("btnProvincia.Image"), System.Drawing.Image)
        Me.btnProvincia.Location = New System.Drawing.Point(187, 211)
        Me.btnProvincia.Name = "btnProvincia"
        Me.btnProvincia.Size = New System.Drawing.Size(23, 23)
        Me.btnProvincia.TabIndex = 268
        Me.btnProvincia.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(4, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 269
        Me.Label2.Text = "Provincia"
        '
        'txtProvincia
        '
        Me.txtProvincia.Enabled = False
        Me.txtProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvincia.Location = New System.Drawing.Point(209, 211)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(308, 23)
        Me.txtProvincia.TabIndex = 270
        '
        'txtIDProvincia
        '
        Me.txtIDProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDProvincia.Location = New System.Drawing.Point(86, 211)
        Me.txtIDProvincia.Name = "txtIDProvincia"
        Me.txtIDProvincia.Size = New System.Drawing.Size(102, 23)
        Me.txtIDProvincia.TabIndex = 267
        Me.txtIDProvincia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMunicipio
        '
        Me.btnMunicipio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMunicipio.Image = CType(resources.GetObject("btnMunicipio.Image"), System.Drawing.Image)
        Me.btnMunicipio.Location = New System.Drawing.Point(187, 240)
        Me.btnMunicipio.Name = "btnMunicipio"
        Me.btnMunicipio.Size = New System.Drawing.Size(23, 23)
        Me.btnMunicipio.TabIndex = 272
        Me.btnMunicipio.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(4, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "Municipio"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Enabled = False
        Me.txtMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipio.Location = New System.Drawing.Point(209, 240)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.ReadOnly = True
        Me.txtMunicipio.Size = New System.Drawing.Size(308, 23)
        Me.txtMunicipio.TabIndex = 274
        '
        'txtIDMunicipio
        '
        Me.txtIDMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMunicipio.Location = New System.Drawing.Point(86, 240)
        Me.txtIDMunicipio.Name = "txtIDMunicipio"
        Me.txtIDMunicipio.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMunicipio.TabIndex = 271
        Me.txtIDMunicipio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSucursal
        '
        Me.btnSucursal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSucursal.Image = CType(resources.GetObject("btnSucursal.Image"), System.Drawing.Image)
        Me.btnSucursal.Location = New System.Drawing.Point(187, 269)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(23, 23)
        Me.btnSucursal.TabIndex = 276
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "Sucursal"
        '
        'txtSucursal
        '
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(209, 269)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(308, 23)
        Me.txtSucursal.TabIndex = 278
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(86, 269)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(102, 23)
        Me.txtIDSucursal.TabIndex = 275
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAlmacen
        '
        Me.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAlmacen.Image = CType(resources.GetObject("btnAlmacen.Image"), System.Drawing.Image)
        Me.btnAlmacen.Location = New System.Drawing.Point(187, 298)
        Me.btnAlmacen.Name = "btnAlmacen"
        Me.btnAlmacen.Size = New System.Drawing.Size(23, 23)
        Me.btnAlmacen.TabIndex = 280
        Me.btnAlmacen.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 301)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 281
        Me.Label7.Text = "Almacén"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Enabled = False
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(209, 298)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(308, 23)
        Me.txtAlmacen.TabIndex = 282
        '
        'txtIDAlmacen
        '
        Me.txtIDAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAlmacen.Location = New System.Drawing.Point(86, 298)
        Me.txtIDAlmacen.Name = "txtIDAlmacen"
        Me.txtIDAlmacen.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAlmacen.TabIndex = 279
        Me.txtIDAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNomina
        '
        Me.btnNomina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNomina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNomina.Image = CType(resources.GetObject("btnNomina.Image"), System.Drawing.Image)
        Me.btnNomina.Location = New System.Drawing.Point(187, 327)
        Me.btnNomina.Name = "btnNomina"
        Me.btnNomina.Size = New System.Drawing.Size(23, 23)
        Me.btnNomina.TabIndex = 284
        Me.btnNomina.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(4, 330)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 15)
        Me.Label17.TabIndex = 285
        Me.Label17.Text = "Nómina"
        '
        'txtNomina
        '
        Me.txtNomina.Enabled = False
        Me.txtNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNomina.Location = New System.Drawing.Point(209, 327)
        Me.txtNomina.Name = "txtNomina"
        Me.txtNomina.ReadOnly = True
        Me.txtNomina.Size = New System.Drawing.Size(308, 23)
        Me.txtNomina.TabIndex = 286
        '
        'txtIDNomina
        '
        Me.txtIDNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNomina.Location = New System.Drawing.Point(86, 327)
        Me.txtIDNomina.Name = "txtIDNomina"
        Me.txtIDNomina.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNomina.TabIndex = 283
        Me.txtIDNomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCargo
        '
        Me.btnCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCargo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCargo.Image = CType(resources.GetObject("btnCargo.Image"), System.Drawing.Image)
        Me.btnCargo.Location = New System.Drawing.Point(187, 357)
        Me.btnCargo.Name = "btnCargo"
        Me.btnCargo.Size = New System.Drawing.Size(23, 23)
        Me.btnCargo.TabIndex = 288
        Me.btnCargo.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(4, 360)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 15)
        Me.Label18.TabIndex = 289
        Me.Label18.Text = "Cargo"
        '
        'txtCargo
        '
        Me.txtCargo.Enabled = False
        Me.txtCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCargo.Location = New System.Drawing.Point(209, 357)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.ReadOnly = True
        Me.txtCargo.Size = New System.Drawing.Size(308, 23)
        Me.txtCargo.TabIndex = 290
        '
        'txtIDCargo
        '
        Me.txtIDCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCargo.Location = New System.Drawing.Point(86, 357)
        Me.txtIDCargo.Name = "txtIDCargo"
        Me.txtIDCargo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCargo.TabIndex = 287
        Me.txtIDCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTanda
        '
        Me.btnTanda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTanda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTanda.Image = CType(resources.GetObject("btnTanda.Image"), System.Drawing.Image)
        Me.btnTanda.Location = New System.Drawing.Point(187, 415)
        Me.btnTanda.Name = "btnTanda"
        Me.btnTanda.Size = New System.Drawing.Size(23, 23)
        Me.btnTanda.TabIndex = 296
        Me.btnTanda.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(4, 418)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 15)
        Me.Label20.TabIndex = 297
        Me.Label20.Text = "Tanda"
        '
        'txtTanda
        '
        Me.txtTanda.Enabled = False
        Me.txtTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTanda.Location = New System.Drawing.Point(209, 415)
        Me.txtTanda.Name = "txtTanda"
        Me.txtTanda.ReadOnly = True
        Me.txtTanda.Size = New System.Drawing.Size(308, 23)
        Me.txtTanda.TabIndex = 298
        '
        'txtIDTanda
        '
        Me.txtIDTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTanda.Location = New System.Drawing.Point(86, 415)
        Me.txtIDTanda.Name = "txtIDTanda"
        Me.txtIDTanda.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTanda.TabIndex = 295
        Me.txtIDTanda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnARS
        '
        Me.btnARS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnARS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnARS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnARS.Image = CType(resources.GetObject("btnARS.Image"), System.Drawing.Image)
        Me.btnARS.Location = New System.Drawing.Point(187, 444)
        Me.btnARS.Name = "btnARS"
        Me.btnARS.Size = New System.Drawing.Size(23, 23)
        Me.btnARS.TabIndex = 300
        Me.btnARS.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(4, 439)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(28, 15)
        Me.Label21.TabIndex = 301
        Me.Label21.Text = "ARS"
        '
        'txtARS
        '
        Me.txtARS.Enabled = False
        Me.txtARS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtARS.Location = New System.Drawing.Point(209, 444)
        Me.txtARS.Name = "txtARS"
        Me.txtARS.ReadOnly = True
        Me.txtARS.Size = New System.Drawing.Size(308, 23)
        Me.txtARS.TabIndex = 302
        '
        'txtIDARS
        '
        Me.txtIDARS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDARS.Location = New System.Drawing.Point(86, 444)
        Me.txtIDARS.Name = "txtIDARS"
        Me.txtIDARS.Size = New System.Drawing.Size(102, 23)
        Me.txtIDARS.TabIndex = 299
        Me.txtIDARS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAFP
        '
        Me.btnAFP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAFP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAFP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAFP.Image = CType(resources.GetObject("btnAFP.Image"), System.Drawing.Image)
        Me.btnAFP.Location = New System.Drawing.Point(187, 473)
        Me.btnAFP.Name = "btnAFP"
        Me.btnAFP.Size = New System.Drawing.Size(23, 23)
        Me.btnAFP.TabIndex = 304
        Me.btnAFP.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(4, 468)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 15)
        Me.Label22.TabIndex = 305
        Me.Label22.Text = "AFP"
        '
        'txtAFP
        '
        Me.txtAFP.Enabled = False
        Me.txtAFP.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAFP.Location = New System.Drawing.Point(209, 473)
        Me.txtAFP.Name = "txtAFP"
        Me.txtAFP.ReadOnly = True
        Me.txtAFP.Size = New System.Drawing.Size(308, 23)
        Me.txtAFP.TabIndex = 306
        '
        'txtIDAfp
        '
        Me.txtIDAfp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAfp.Location = New System.Drawing.Point(86, 473)
        Me.txtIDAfp.Name = "txtIDAfp"
        Me.txtIDAfp.Size = New System.Drawing.Size(102, 23)
        Me.txtIDAfp.TabIndex = 303
        Me.txtIDAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.chkSinEspecNacimiento)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFinalNacimiento)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.DtpFechaInicialNacimiento)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 102)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox4.TabIndex = 285
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha de Nacimiento"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(121, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(2, 25)
        Me.Label19.TabIndex = 284
        '
        'chkSinEspecNacimiento
        '
        Me.chkSinEspecNacimiento.AutoSize = True
        Me.chkSinEspecNacimiento.Checked = True
        Me.chkSinEspecNacimiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSinEspecNacimiento.Location = New System.Drawing.Point(11, 20)
        Me.chkSinEspecNacimiento.Name = "chkSinEspecNacimiento"
        Me.chkSinEspecNacimiento.Size = New System.Drawing.Size(101, 19)
        Me.chkSinEspecNacimiento.TabIndex = 16
        Me.chkSinEspecNacimiento.Text = "Sin Especificar"
        Me.chkSinEspecNacimiento.UseVisualStyleBackColor = True
        '
        'dtpFechaFinalNacimiento
        '
        Me.dtpFechaFinalNacimiento.CustomFormat = ""
        Me.dtpFechaFinalNacimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinalNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinalNacimiento.Location = New System.Drawing.Point(297, 15)
        Me.dtpFechaFinalNacimiento.Name = "dtpFechaFinalNacimiento"
        Me.dtpFechaFinalNacimiento.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinalNacimiento.TabIndex = 18
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(278, 19)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(13, 15)
        Me.Label25.TabIndex = 281
        Me.Label25.Text = "y"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(128, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 15)
        Me.Label26.TabIndex = 280
        Me.Label26.Text = "Entre"
        '
        'DtpFechaInicialNacimiento
        '
        Me.DtpFechaInicialNacimiento.CustomFormat = ""
        Me.DtpFechaInicialNacimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaInicialNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicialNacimiento.Location = New System.Drawing.Point(168, 15)
        Me.DtpFechaInicialNacimiento.Name = "DtpFechaInicialNacimiento"
        Me.DtpFechaInicialNacimiento.Size = New System.Drawing.Size(104, 23)
        Me.DtpFechaInicialNacimiento.TabIndex = 17
        '
        'btnDepartamento
        '
        Me.btnDepartamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDepartamento.Image = CType(resources.GetObject("btnDepartamento.Image"), System.Drawing.Image)
        Me.btnDepartamento.Location = New System.Drawing.Point(187, 386)
        Me.btnDepartamento.Name = "btnDepartamento"
        Me.btnDepartamento.Size = New System.Drawing.Size(23, 23)
        Me.btnDepartamento.TabIndex = 308
        Me.btnDepartamento.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label27.Location = New System.Drawing.Point(4, 389)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(83, 15)
        Me.Label27.TabIndex = 309
        Me.Label27.Text = "Departamento"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartamento.Location = New System.Drawing.Point(209, 386)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(308, 23)
        Me.txtDepartamento.TabIndex = 310
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDepartamento.Location = New System.Drawing.Point(86, 386)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDDepartamento.TabIndex = 307
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_reporte_empleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 637)
        Me.Controls.Add(Me.btnDepartamento)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.txtIDDepartamento)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnAFP)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtAFP)
        Me.Controls.Add(Me.txtIDAfp)
        Me.Controls.Add(Me.btnARS)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtARS)
        Me.Controls.Add(Me.txtIDARS)
        Me.Controls.Add(Me.btnTanda)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtTanda)
        Me.Controls.Add(Me.txtIDTanda)
        Me.Controls.Add(Me.btnCargo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCargo)
        Me.Controls.Add(Me.txtIDCargo)
        Me.Controls.Add(Me.btnNomina)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNomina)
        Me.Controls.Add(Me.txtIDNomina)
        Me.Controls.Add(Me.btnAlmacen)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAlmacen)
        Me.Controls.Add(Me.txtIDAlmacen)
        Me.Controls.Add(Me.btnSucursal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtIDSucursal)
        Me.Controls.Add(Me.btnMunicipio)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMunicipio)
        Me.Controls.Add(Me.txtIDMunicipio)
        Me.Controls.Add(Me.btnProvincia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProvincia)
        Me.Controls.Add(Me.txtIDProvincia)
        Me.Controls.Add(Me.btnGenero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGenero)
        Me.Controls.Add(Me.txtIDGenero)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnNacionalidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNacionalidad)
        Me.Controls.Add(Me.txtIDNacionalidad)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label27)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_empleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "162"
        Me.Text = "Reporte de empleados"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents txtIDEmpleadoDesde As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents btnBuscarArtDesde As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIDEmpleadoHasta As System.Windows.Forms.TextBox
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxAlertas As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbxHabilitadoNomina As System.Windows.Forms.ComboBox
    Friend WithEvents btnNacionalidad As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEspecificarVenc As System.Windows.Forms.CheckBox
    Friend WithEvents dtpIngresoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpIngresoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenero As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGenero As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGenero As System.Windows.Forms.TextBox
    Friend WithEvents btnProvincia As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtIDProvincia As System.Windows.Forms.TextBox
    Friend WithEvents btnMunicipio As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnNomina As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNomina As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNomina As System.Windows.Forms.TextBox
    Friend WithEvents btnCargo As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCargo As System.Windows.Forms.TextBox
    Friend WithEvents btnTanda As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTanda As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTanda As System.Windows.Forms.TextBox
    Friend WithEvents btnARS As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtARS As System.Windows.Forms.TextBox
    Friend WithEvents txtIDARS As System.Windows.Forms.TextBox
    Friend WithEvents btnAFP As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtAFP As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAfp As System.Windows.Forms.TextBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CbxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents chkSinEspecNacimiento As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFinalNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents DtpFechaInicialNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDepartamento As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
End Class
