<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_clientes))
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkEspecificarIngreso = New System.Windows.Forms.CheckBox()
        Me.dtpIngresoFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpIngresoInicial = New System.Windows.Forms.DateTimePicker()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.cbxCalificacion = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CbxCtaIncobrable = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbxRecepCheques = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbxStatusCredito = New System.Windows.Forms.ComboBox()
        Me.cbxGeneracionCargo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGenero = New System.Windows.Forms.TextBox()
        Me.txtIDGenero = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipoDocumento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoDocumento = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoFinal = New System.Windows.Forms.TextBox()
        Me.txtCodigoInicial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkEspCodigo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNacionalidad = New System.Windows.Forms.TextBox()
        Me.txtIDNacionalidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.txtIDProvincia = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.txtIDMunicipio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtOcupacion = New System.Windows.Forms.TextBox()
        Me.txtIDOcupacion = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEstadoCivil = New System.Windows.Forms.TextBox()
        Me.txtIDEstadoCivil = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTipoCliente = New System.Windows.Forms.TextBox()
        Me.txtIDTipoCliente = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.txtIDNcf = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.btnTipoNCF = New System.Windows.Forms.Button()
        Me.btnCobrador = New System.Windows.Forms.Button()
        Me.btnTipoCliente = New System.Windows.Forms.Button()
        Me.btnGrupo = New System.Windows.Forms.Button()
        Me.btnEstadoCivil = New System.Windows.Forms.Button()
        Me.btnOcupacion = New System.Windows.Forms.Button()
        Me.btnMunicipio = New System.Windows.Forms.Button()
        Me.btnProvincia = New System.Windows.Forms.Button()
        Me.btnNacionalidad = New System.Windows.Forms.Button()
        Me.btnGenero = New System.Windows.Forms.Button()
        Me.btnTipoDocumento = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 436)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 253
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 546)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.chkEspecificarIngreso)
        Me.GroupBox3.Controls.Add(Me.dtpIngresoFinal)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtpIngresoInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 377)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox3.TabIndex = 255
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
        'chkEspecificarIngreso
        '
        Me.chkEspecificarIngreso.AutoSize = True
        Me.chkEspecificarIngreso.Checked = True
        Me.chkEspecificarIngreso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificarIngreso.Location = New System.Drawing.Point(11, 20)
        Me.chkEspecificarIngreso.Name = "chkEspecificarIngreso"
        Me.chkEspecificarIngreso.Size = New System.Drawing.Size(101, 19)
        Me.chkEspecificarIngreso.TabIndex = 16
        Me.chkEspecificarIngreso.Text = "Sin Especificar"
        Me.chkEspecificarIngreso.UseVisualStyleBackColor = True
        '
        'dtpIngresoFinal
        '
        Me.dtpIngresoFinal.CustomFormat = "yyyy-MM-dd"
        Me.dtpIngresoFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
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
        Me.dtpIngresoInicial.CustomFormat = "yyyy-MM-dd"
        Me.dtpIngresoInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpIngresoInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIngresoInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpIngresoInicial.Name = "dtpIngresoInicial"
        Me.dtpIngresoInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpIngresoInicial.TabIndex = 17
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.cbxCalificacion)
        Me.GbCondiciones.Controls.Add(Me.Label26)
        Me.GbCondiciones.Controls.Add(Me.Label25)
        Me.GbCondiciones.Controls.Add(Me.CbxCtaIncobrable)
        Me.GbCondiciones.Controls.Add(Me.Label24)
        Me.GbCondiciones.Controls.Add(Me.cbxRecepCheques)
        Me.GbCondiciones.Controls.Add(Me.Label22)
        Me.GbCondiciones.Controls.Add(Me.cbxStatusCredito)
        Me.GbCondiciones.Controls.Add(Me.cbxGeneracionCargo)
        Me.GbCondiciones.Controls.Add(Me.Label18)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(522, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 426)
        Me.GbCondiciones.TabIndex = 256
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'cbxCalificacion
        '
        Me.cbxCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCalificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCalificacion.FormattingEnabled = True
        Me.cbxCalificacion.Items.AddRange(New Object() {"Todos", "Aplican", "No Aplican"})
        Me.cbxCalificacion.Location = New System.Drawing.Point(13, 172)
        Me.cbxCalificacion.Name = "cbxCalificacion"
        Me.cbxCalificacion.Size = New System.Drawing.Size(170, 23)
        Me.cbxCalificacion.TabIndex = 105
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(13, 154)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 15)
        Me.Label26.TabIndex = 106
        Me.Label26.Text = "Calificación"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(13, 286)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 15)
        Me.Label25.TabIndex = 104
        Me.Label25.Text = "Cuentas Incobrables"
        '
        'CbxCtaIncobrable
        '
        Me.CbxCtaIncobrable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCtaIncobrable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxCtaIncobrable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxCtaIncobrable.FormattingEnabled = True
        Me.CbxCtaIncobrable.Items.AddRange(New Object() {"Todos", "Sólo las incobrables", "Sólo las cobrables"})
        Me.CbxCtaIncobrable.Location = New System.Drawing.Point(13, 304)
        Me.CbxCtaIncobrable.Name = "CbxCtaIncobrable"
        Me.CbxCtaIncobrable.Size = New System.Drawing.Size(170, 23)
        Me.CbxCtaIncobrable.TabIndex = 103
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(13, 242)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 15)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Recepción de Cheques"
        '
        'cbxRecepCheques
        '
        Me.cbxRecepCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRecepCheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRecepCheques.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxRecepCheques.FormattingEnabled = True
        Me.cbxRecepCheques.Items.AddRange(New Object() {"Todos", "Permitidos", "No Permitidos"})
        Me.cbxRecepCheques.Location = New System.Drawing.Point(13, 260)
        Me.cbxRecepCheques.Name = "cbxRecepCheques"
        Me.cbxRecepCheques.Size = New System.Drawing.Size(170, 23)
        Me.cbxRecepCheques.TabIndex = 101
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(13, 330)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 15)
        Me.Label22.TabIndex = 100
        Me.Label22.Text = "Estado de Crédito"
        '
        'cbxStatusCredito
        '
        Me.cbxStatusCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStatusCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxStatusCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxStatusCredito.FormattingEnabled = True
        Me.cbxStatusCredito.Items.AddRange(New Object() {"Todos", "Sólo Abiertos", "Sólo Cerrados"})
        Me.cbxStatusCredito.Location = New System.Drawing.Point(13, 348)
        Me.cbxStatusCredito.Name = "cbxStatusCredito"
        Me.cbxStatusCredito.Size = New System.Drawing.Size(170, 23)
        Me.cbxStatusCredito.TabIndex = 99
        '
        'cbxGeneracionCargo
        '
        Me.cbxGeneracionCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGeneracionCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxGeneracionCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGeneracionCargo.FormattingEnabled = True
        Me.cbxGeneracionCargo.Items.AddRange(New Object() {"Todos", "Aplican", "No Aplican"})
        Me.cbxGeneracionCargo.Location = New System.Drawing.Point(13, 216)
        Me.cbxGeneracionCargo.Name = "cbxGeneracionCargo"
        Me.cbxGeneracionCargo.Size = New System.Drawing.Size(170, 23)
        Me.cbxGeneracionCargo.TabIndex = 29
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(13, 198)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(123, 15)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Generación de Cargos"
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
        Me.Label16.Location = New System.Drawing.Point(13, 374)
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
        Me.cbxEstado.Location = New System.Drawing.Point(13, 392)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Género"
        '
        'txtGenero
        '
        Me.txtGenero.Enabled = False
        Me.txtGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGenero.Location = New System.Drawing.Point(209, 87)
        Me.txtGenero.Name = "txtGenero"
        Me.txtGenero.ReadOnly = True
        Me.txtGenero.Size = New System.Drawing.Size(307, 23)
        Me.txtGenero.TabIndex = 265
        '
        'txtIDGenero
        '
        Me.txtIDGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGenero.Location = New System.Drawing.Point(86, 87)
        Me.txtIDGenero.Name = "txtIDGenero"
        Me.txtIDGenero.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGenero.TabIndex = 260
        Me.txtIDGenero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "Tipo de Doc."
        '
        'txtTipoDocumento
        '
        Me.txtTipoDocumento.Enabled = False
        Me.txtTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoDocumento.Location = New System.Drawing.Point(209, 58)
        Me.txtTipoDocumento.Name = "txtTipoDocumento"
        Me.txtTipoDocumento.ReadOnly = True
        Me.txtTipoDocumento.Size = New System.Drawing.Size(307, 23)
        Me.txtTipoDocumento.TabIndex = 263
        '
        'txtIDTipoDocumento
        '
        Me.txtIDTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoDocumento.Location = New System.Drawing.Point(86, 58)
        Me.txtIDTipoDocumento.Name = "txtIDTipoDocumento"
        Me.txtIDTipoDocumento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoDocumento.TabIndex = 258
        Me.txtIDTipoDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoFinal)
        Me.GroupBox2.Controls.Add(Me.txtCodigoInicial)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ChkEspCodigo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox2.TabIndex = 285
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Códigos"
        '
        'txtCodigoFinal
        '
        Me.txtCodigoFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodigoFinal.Location = New System.Drawing.Point(297, 15)
        Me.txtCodigoFinal.Name = "txtCodigoFinal"
        Me.txtCodigoFinal.Size = New System.Drawing.Size(102, 23)
        Me.txtCodigoFinal.TabIndex = 286
        Me.txtCodigoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCodigoInicial
        '
        Me.txtCodigoInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCodigoInicial.Location = New System.Drawing.Point(168, 15)
        Me.txtCodigoInicial.Name = "txtCodigoInicial"
        Me.txtCodigoInicial.Size = New System.Drawing.Size(102, 23)
        Me.txtCodigoInicial.TabIndex = 285
        Me.txtCodigoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(121, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(2, 25)
        Me.Label2.TabIndex = 284
        '
        'ChkEspCodigo
        '
        Me.ChkEspCodigo.AutoSize = True
        Me.ChkEspCodigo.Checked = True
        Me.ChkEspCodigo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEspCodigo.Location = New System.Drawing.Point(11, 20)
        Me.ChkEspCodigo.Name = "ChkEspCodigo"
        Me.ChkEspCodigo.Size = New System.Drawing.Size(101, 19)
        Me.ChkEspCodigo.TabIndex = 16
        Me.ChkEspCodigo.Text = "Sin Especificar"
        Me.ChkEspCodigo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(278, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 15)
        Me.Label3.TabIndex = 281
        Me.Label3.Text = "y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(128, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Entre"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 288
        Me.Label6.Text = "Nacionalidad"
        '
        'txtNacionalidad
        '
        Me.txtNacionalidad.Enabled = False
        Me.txtNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidad.Location = New System.Drawing.Point(209, 116)
        Me.txtNacionalidad.Name = "txtNacionalidad"
        Me.txtNacionalidad.ReadOnly = True
        Me.txtNacionalidad.Size = New System.Drawing.Size(307, 23)
        Me.txtNacionalidad.TabIndex = 289
        '
        'txtIDNacionalidad
        '
        Me.txtIDNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNacionalidad.Location = New System.Drawing.Point(86, 116)
        Me.txtIDNacionalidad.Name = "txtIDNacionalidad"
        Me.txtIDNacionalidad.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNacionalidad.TabIndex = 286
        Me.txtIDNacionalidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 292
        Me.Label7.Text = "Provincia"
        '
        'txtProvincia
        '
        Me.txtProvincia.Enabled = False
        Me.txtProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvincia.Location = New System.Drawing.Point(209, 145)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(307, 23)
        Me.txtProvincia.TabIndex = 293
        '
        'txtIDProvincia
        '
        Me.txtIDProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDProvincia.Location = New System.Drawing.Point(86, 145)
        Me.txtIDProvincia.Name = "txtIDProvincia"
        Me.txtIDProvincia.Size = New System.Drawing.Size(102, 23)
        Me.txtIDProvincia.TabIndex = 290
        Me.txtIDProvincia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 296
        Me.Label9.Text = "Municipio"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Enabled = False
        Me.txtMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipio.Location = New System.Drawing.Point(209, 174)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.ReadOnly = True
        Me.txtMunicipio.Size = New System.Drawing.Size(307, 23)
        Me.txtMunicipio.TabIndex = 297
        '
        'txtIDMunicipio
        '
        Me.txtIDMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMunicipio.Location = New System.Drawing.Point(86, 174)
        Me.txtIDMunicipio.Name = "txtIDMunicipio"
        Me.txtIDMunicipio.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMunicipio.TabIndex = 294
        Me.txtIDMunicipio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(6, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 15)
        Me.Label10.TabIndex = 300
        Me.Label10.Text = "Ocupación"
        '
        'txtOcupacion
        '
        Me.txtOcupacion.Enabled = False
        Me.txtOcupacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOcupacion.Location = New System.Drawing.Point(209, 203)
        Me.txtOcupacion.Name = "txtOcupacion"
        Me.txtOcupacion.ReadOnly = True
        Me.txtOcupacion.Size = New System.Drawing.Size(307, 23)
        Me.txtOcupacion.TabIndex = 301
        '
        'txtIDOcupacion
        '
        Me.txtIDOcupacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDOcupacion.Location = New System.Drawing.Point(86, 203)
        Me.txtIDOcupacion.Name = "txtIDOcupacion"
        Me.txtIDOcupacion.Size = New System.Drawing.Size(102, 23)
        Me.txtIDOcupacion.TabIndex = 298
        Me.txtIDOcupacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(6, 235)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 304
        Me.Label15.Text = "Estado Civil"
        '
        'txtEstadoCivil
        '
        Me.txtEstadoCivil.Enabled = False
        Me.txtEstadoCivil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEstadoCivil.Location = New System.Drawing.Point(209, 232)
        Me.txtEstadoCivil.Name = "txtEstadoCivil"
        Me.txtEstadoCivil.ReadOnly = True
        Me.txtEstadoCivil.Size = New System.Drawing.Size(307, 23)
        Me.txtEstadoCivil.TabIndex = 305
        '
        'txtIDEstadoCivil
        '
        Me.txtIDEstadoCivil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEstadoCivil.Location = New System.Drawing.Point(86, 232)
        Me.txtIDEstadoCivil.Name = "txtIDEstadoCivil"
        Me.txtIDEstadoCivil.Size = New System.Drawing.Size(102, 23)
        Me.txtIDEstadoCivil.TabIndex = 302
        Me.txtIDEstadoCivil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(6, 264)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 15)
        Me.Label17.TabIndex = 308
        Me.Label17.Text = "Grupo"
        '
        'txtGrupo
        '
        Me.txtGrupo.Enabled = False
        Me.txtGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGrupo.Location = New System.Drawing.Point(209, 261)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.ReadOnly = True
        Me.txtGrupo.Size = New System.Drawing.Size(307, 23)
        Me.txtGrupo.TabIndex = 309
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(86, 261)
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGrupo.TabIndex = 306
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(6, 293)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 15)
        Me.Label19.TabIndex = 312
        Me.Label19.Text = "Tipo "
        '
        'txtTipoCliente
        '
        Me.txtTipoCliente.Enabled = False
        Me.txtTipoCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoCliente.Location = New System.Drawing.Point(209, 290)
        Me.txtTipoCliente.Name = "txtTipoCliente"
        Me.txtTipoCliente.ReadOnly = True
        Me.txtTipoCliente.Size = New System.Drawing.Size(307, 23)
        Me.txtTipoCliente.TabIndex = 313
        '
        'txtIDTipoCliente
        '
        Me.txtIDTipoCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoCliente.Location = New System.Drawing.Point(86, 290)
        Me.txtIDTipoCliente.Name = "txtIDTipoCliente"
        Me.txtIDTipoCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoCliente.TabIndex = 310
        Me.txtIDTipoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(6, 322)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 15)
        Me.Label20.TabIndex = 316
        Me.Label20.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(209, 319)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(307, 23)
        Me.txtCobrador.TabIndex = 317
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(86, 319)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCobrador.TabIndex = 314
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(6, 351)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 15)
        Me.Label21.TabIndex = 320
        Me.Label21.Text = "Tipo de NCF"
        '
        'txtNCF
        '
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.Location = New System.Drawing.Point(209, 348)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(307, 23)
        Me.txtNCF.TabIndex = 321
        '
        'txtIDNcf
        '
        Me.txtIDNcf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNcf.Location = New System.Drawing.Point(86, 348)
        Me.txtIDNcf.Name = "txtIDNcf"
        Me.txtIDNcf.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNcf.TabIndex = 318
        Me.txtIDNcf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'btnTipoNCF
        '
        Me.btnTipoNCF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoNCF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoNCF.Image = CType(resources.GetObject("btnTipoNCF.Image"), System.Drawing.Image)
        Me.btnTipoNCF.Location = New System.Drawing.Point(187, 348)
        Me.btnTipoNCF.Name = "btnTipoNCF"
        Me.btnTipoNCF.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoNCF.TabIndex = 319
        Me.btnTipoNCF.UseVisualStyleBackColor = True
        '
        'btnCobrador
        '
        Me.btnCobrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCobrador.Image = CType(resources.GetObject("btnCobrador.Image"), System.Drawing.Image)
        Me.btnCobrador.Location = New System.Drawing.Point(187, 319)
        Me.btnCobrador.Name = "btnCobrador"
        Me.btnCobrador.Size = New System.Drawing.Size(23, 23)
        Me.btnCobrador.TabIndex = 315
        Me.btnCobrador.UseVisualStyleBackColor = True
        '
        'btnTipoCliente
        '
        Me.btnTipoCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoCliente.Image = CType(resources.GetObject("btnTipoCliente.Image"), System.Drawing.Image)
        Me.btnTipoCliente.Location = New System.Drawing.Point(187, 290)
        Me.btnTipoCliente.Name = "btnTipoCliente"
        Me.btnTipoCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoCliente.TabIndex = 311
        Me.btnTipoCliente.UseVisualStyleBackColor = True
        '
        'btnGrupo
        '
        Me.btnGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGrupo.Image = CType(resources.GetObject("btnGrupo.Image"), System.Drawing.Image)
        Me.btnGrupo.Location = New System.Drawing.Point(187, 261)
        Me.btnGrupo.Name = "btnGrupo"
        Me.btnGrupo.Size = New System.Drawing.Size(23, 23)
        Me.btnGrupo.TabIndex = 307
        Me.btnGrupo.UseVisualStyleBackColor = True
        '
        'btnEstadoCivil
        '
        Me.btnEstadoCivil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEstadoCivil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEstadoCivil.Image = CType(resources.GetObject("btnEstadoCivil.Image"), System.Drawing.Image)
        Me.btnEstadoCivil.Location = New System.Drawing.Point(187, 232)
        Me.btnEstadoCivil.Name = "btnEstadoCivil"
        Me.btnEstadoCivil.Size = New System.Drawing.Size(23, 23)
        Me.btnEstadoCivil.TabIndex = 303
        Me.btnEstadoCivil.UseVisualStyleBackColor = True
        '
        'btnOcupacion
        '
        Me.btnOcupacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOcupacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOcupacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnOcupacion.Image = CType(resources.GetObject("btnOcupacion.Image"), System.Drawing.Image)
        Me.btnOcupacion.Location = New System.Drawing.Point(187, 203)
        Me.btnOcupacion.Name = "btnOcupacion"
        Me.btnOcupacion.Size = New System.Drawing.Size(23, 23)
        Me.btnOcupacion.TabIndex = 299
        Me.btnOcupacion.UseVisualStyleBackColor = True
        '
        'btnMunicipio
        '
        Me.btnMunicipio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMunicipio.Image = CType(resources.GetObject("btnMunicipio.Image"), System.Drawing.Image)
        Me.btnMunicipio.Location = New System.Drawing.Point(187, 174)
        Me.btnMunicipio.Name = "btnMunicipio"
        Me.btnMunicipio.Size = New System.Drawing.Size(23, 23)
        Me.btnMunicipio.TabIndex = 295
        Me.btnMunicipio.UseVisualStyleBackColor = True
        '
        'btnProvincia
        '
        Me.btnProvincia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnProvincia.Image = CType(resources.GetObject("btnProvincia.Image"), System.Drawing.Image)
        Me.btnProvincia.Location = New System.Drawing.Point(187, 145)
        Me.btnProvincia.Name = "btnProvincia"
        Me.btnProvincia.Size = New System.Drawing.Size(23, 23)
        Me.btnProvincia.TabIndex = 291
        Me.btnProvincia.UseVisualStyleBackColor = True
        '
        'btnNacionalidad
        '
        Me.btnNacionalidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNacionalidad.Image = CType(resources.GetObject("btnNacionalidad.Image"), System.Drawing.Image)
        Me.btnNacionalidad.Location = New System.Drawing.Point(187, 116)
        Me.btnNacionalidad.Name = "btnNacionalidad"
        Me.btnNacionalidad.Size = New System.Drawing.Size(23, 23)
        Me.btnNacionalidad.TabIndex = 287
        Me.btnNacionalidad.UseVisualStyleBackColor = True
        '
        'btnGenero
        '
        Me.btnGenero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGenero.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGenero.Image = CType(resources.GetObject("btnGenero.Image"), System.Drawing.Image)
        Me.btnGenero.Location = New System.Drawing.Point(187, 87)
        Me.btnGenero.Name = "btnGenero"
        Me.btnGenero.Size = New System.Drawing.Size(23, 23)
        Me.btnGenero.TabIndex = 261
        Me.btnGenero.UseVisualStyleBackColor = True
        '
        'btnTipoDocumento
        '
        Me.btnTipoDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoDocumento.Image = CType(resources.GetObject("btnTipoDocumento.Image"), System.Drawing.Image)
        Me.btnTipoDocumento.Location = New System.Drawing.Point(187, 58)
        Me.btnTipoDocumento.Name = "btnTipoDocumento"
        Me.btnTipoDocumento.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoDocumento.TabIndex = 259
        Me.btnTipoDocumento.UseVisualStyleBackColor = True
        '
        'frm_reporte_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 571)
        Me.Controls.Add(Me.btnTipoNCF)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtNCF)
        Me.Controls.Add(Me.txtIDNcf)
        Me.Controls.Add(Me.btnCobrador)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.Controls.Add(Me.btnTipoCliente)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtTipoCliente)
        Me.Controls.Add(Me.txtIDTipoCliente)
        Me.Controls.Add(Me.btnGrupo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.btnEstadoCivil)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtEstadoCivil)
        Me.Controls.Add(Me.txtIDEstadoCivil)
        Me.Controls.Add(Me.btnOcupacion)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtOcupacion)
        Me.Controls.Add(Me.txtIDOcupacion)
        Me.Controls.Add(Me.btnMunicipio)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMunicipio)
        Me.Controls.Add(Me.txtIDMunicipio)
        Me.Controls.Add(Me.btnProvincia)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtProvincia)
        Me.Controls.Add(Me.txtIDProvincia)
        Me.Controls.Add(Me.btnNacionalidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNacionalidad)
        Me.Controls.Add(Me.txtIDNacionalidad)
        Me.Controls.Add(Me.btnGenero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGenero)
        Me.Controls.Add(Me.txtIDGenero)
        Me.Controls.Add(Me.btnTipoDocumento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTipoDocumento)
        Me.Controls.Add(Me.txtIDTipoDocumento)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "103"
        Me.Text = "Reporte de Clientes"
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkEspecificarIngreso As System.Windows.Forms.CheckBox
    Friend WithEvents dtpIngresoFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpIngresoInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents cbxGeneracionCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenero As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGenero As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGenero As System.Windows.Forms.TextBox
    Friend WithEvents btnTipoDocumento As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkEspCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnNacionalidad As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNacionalidad As System.Windows.Forms.TextBox
    Friend WithEvents btnProvincia As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtIDProvincia As System.Windows.Forms.TextBox
    Friend WithEvents btnMunicipio As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents btnOcupacion As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtOcupacion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDOcupacion As System.Windows.Forms.TextBox
    Friend WithEvents btnEstadoCivil As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEstadoCivil As System.Windows.Forms.TextBox
    Friend WithEvents txtIDEstadoCivil As System.Windows.Forms.TextBox
    Friend WithEvents btnGrupo As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents btnTipoCliente As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnCobrador As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobrador As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CbxCtaIncobrable As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbxRecepCheques As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbxStatusCredito As System.Windows.Forms.ComboBox
    Friend WithEvents btnTipoNCF As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNCF As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNcf As System.Windows.Forms.TextBox
    Friend WithEvents cbxCalificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.Timer
End Class
