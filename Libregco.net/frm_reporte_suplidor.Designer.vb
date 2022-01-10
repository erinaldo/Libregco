<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_suplidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_suplidor))
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoFinal = New System.Windows.Forms.TextBox()
        Me.txtCodigoInicial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkEspCodigo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnTipoSuplidor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDTipoSuplidor = New System.Windows.Forms.TextBox()
        Me.btnProvincia = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProvincia = New System.Windows.Forms.TextBox()
        Me.txtIDProvincia = New System.Windows.Forms.TextBox()
        Me.btnTipoDocumento = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTipoDocumento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoDocumento = New System.Windows.Forms.TextBox()
        Me.btnMunicipio = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.txtIDMunicipio = New System.Windows.Forms.TextBox()
        Me.btnCondicion = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.txtIDCondicion = New System.Windows.Forms.TextBox()
        Me.btnNCF = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.txtIDNCF = New System.Windows.Forms.TextBox()
        Me.btnGasto = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtGasto = New System.Windows.Forms.TextBox()
        Me.txtIDGasto = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkSinEspecificar = New System.Windows.Forms.CheckBox()
        Me.dtpFinalRegistro = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicialIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GbCondiciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 434)
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 546)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 256
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCodigoFinal)
        Me.GroupBox2.Controls.Add(Me.txtCodigoInicial)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ChkEspCodigo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox2.TabIndex = 286
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
        'btnTipoSuplidor
        '
        Me.btnTipoSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoSuplidor.Image = CType(resources.GetObject("btnTipoSuplidor.Image"), System.Drawing.Image)
        Me.btnTipoSuplidor.Location = New System.Drawing.Point(187, 53)
        Me.btnTipoSuplidor.Name = "btnTipoSuplidor"
        Me.btnTipoSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoSuplidor.TabIndex = 288
        Me.btnTipoSuplidor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 15)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Tipo Suplidor"
        '
        'txtTipoSuplidor
        '
        Me.txtTipoSuplidor.Enabled = False
        Me.txtTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoSuplidor.Location = New System.Drawing.Point(209, 53)
        Me.txtTipoSuplidor.Name = "txtTipoSuplidor"
        Me.txtTipoSuplidor.ReadOnly = True
        Me.txtTipoSuplidor.Size = New System.Drawing.Size(307, 23)
        Me.txtTipoSuplidor.TabIndex = 290
        '
        'txtIDTipoSuplidor
        '
        Me.txtIDTipoSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoSuplidor.Location = New System.Drawing.Point(86, 53)
        Me.txtIDTipoSuplidor.Name = "txtIDTipoSuplidor"
        Me.txtIDTipoSuplidor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoSuplidor.TabIndex = 287
        Me.txtIDTipoSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnProvincia
        '
        Me.btnProvincia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnProvincia.Image = CType(resources.GetObject("btnProvincia.Image"), System.Drawing.Image)
        Me.btnProvincia.Location = New System.Drawing.Point(187, 111)
        Me.btnProvincia.Name = "btnProvincia"
        Me.btnProvincia.Size = New System.Drawing.Size(23, 23)
        Me.btnProvincia.TabIndex = 292
        Me.btnProvincia.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 293
        Me.Label1.Text = "Provincia"
        '
        'txtProvincia
        '
        Me.txtProvincia.Enabled = False
        Me.txtProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvincia.Location = New System.Drawing.Point(209, 111)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.ReadOnly = True
        Me.txtProvincia.Size = New System.Drawing.Size(307, 23)
        Me.txtProvincia.TabIndex = 294
        '
        'txtIDProvincia
        '
        Me.txtIDProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDProvincia.Location = New System.Drawing.Point(86, 111)
        Me.txtIDProvincia.Name = "txtIDProvincia"
        Me.txtIDProvincia.Size = New System.Drawing.Size(102, 23)
        Me.txtIDProvincia.TabIndex = 291
        Me.txtIDProvincia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTipoDocumento
        '
        Me.btnTipoDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoDocumento.Image = CType(resources.GetObject("btnTipoDocumento.Image"), System.Drawing.Image)
        Me.btnTipoDocumento.Location = New System.Drawing.Point(187, 82)
        Me.btnTipoDocumento.Name = "btnTipoDocumento"
        Me.btnTipoDocumento.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoDocumento.TabIndex = 296
        Me.btnTipoDocumento.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 297
        Me.Label6.Text = "Tipo de Doc."
        '
        'txtTipoDocumento
        '
        Me.txtTipoDocumento.Enabled = False
        Me.txtTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoDocumento.Location = New System.Drawing.Point(209, 82)
        Me.txtTipoDocumento.Name = "txtTipoDocumento"
        Me.txtTipoDocumento.ReadOnly = True
        Me.txtTipoDocumento.Size = New System.Drawing.Size(307, 23)
        Me.txtTipoDocumento.TabIndex = 298
        '
        'txtIDTipoDocumento
        '
        Me.txtIDTipoDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoDocumento.Location = New System.Drawing.Point(86, 82)
        Me.txtIDTipoDocumento.Name = "txtIDTipoDocumento"
        Me.txtIDTipoDocumento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoDocumento.TabIndex = 295
        Me.txtIDTipoDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMunicipio
        '
        Me.btnMunicipio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnMunicipio.Image = CType(resources.GetObject("btnMunicipio.Image"), System.Drawing.Image)
        Me.btnMunicipio.Location = New System.Drawing.Point(187, 140)
        Me.btnMunicipio.Name = "btnMunicipio"
        Me.btnMunicipio.Size = New System.Drawing.Size(23, 23)
        Me.btnMunicipio.TabIndex = 300
        Me.btnMunicipio.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 15)
        Me.Label7.TabIndex = 301
        Me.Label7.Text = "Municipio"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Enabled = False
        Me.txtMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipio.Location = New System.Drawing.Point(209, 140)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.ReadOnly = True
        Me.txtMunicipio.Size = New System.Drawing.Size(307, 23)
        Me.txtMunicipio.TabIndex = 302
        '
        'txtIDMunicipio
        '
        Me.txtIDMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMunicipio.Location = New System.Drawing.Point(86, 140)
        Me.txtIDMunicipio.Name = "txtIDMunicipio"
        Me.txtIDMunicipio.Size = New System.Drawing.Size(102, 23)
        Me.txtIDMunicipio.TabIndex = 299
        Me.txtIDMunicipio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCondicion
        '
        Me.btnCondicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCondicion.Image = CType(resources.GetObject("btnCondicion.Image"), System.Drawing.Image)
        Me.btnCondicion.Location = New System.Drawing.Point(187, 169)
        Me.btnCondicion.Name = "btnCondicion"
        Me.btnCondicion.Size = New System.Drawing.Size(23, 23)
        Me.btnCondicion.TabIndex = 304
        Me.btnCondicion.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(6, 172)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 305
        Me.Label8.Text = "Condición"
        '
        'txtCondicion
        '
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(209, 169)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(307, 23)
        Me.txtCondicion.TabIndex = 306
        '
        'txtIDCondicion
        '
        Me.txtIDCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCondicion.Location = New System.Drawing.Point(86, 169)
        Me.txtIDCondicion.Name = "txtIDCondicion"
        Me.txtIDCondicion.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCondicion.TabIndex = 303
        Me.txtIDCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNCF
        '
        Me.btnNCF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNCF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNCF.Image = CType(resources.GetObject("btnNCF.Image"), System.Drawing.Image)
        Me.btnNCF.Location = New System.Drawing.Point(187, 198)
        Me.btnNCF.Name = "btnNCF"
        Me.btnNCF.Size = New System.Drawing.Size(23, 23)
        Me.btnNCF.TabIndex = 308
        Me.btnNCF.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 309
        Me.Label9.Text = "Tipo de NCF"
        '
        'txtNCF
        '
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.Location = New System.Drawing.Point(209, 198)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(307, 23)
        Me.txtNCF.TabIndex = 310
        '
        'txtIDNCF
        '
        Me.txtIDNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNCF.Location = New System.Drawing.Point(86, 198)
        Me.txtIDNCF.Name = "txtIDNCF"
        Me.txtIDNCF.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNCF.TabIndex = 307
        Me.txtIDNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGasto
        '
        Me.btnGasto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGasto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGasto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGasto.Image = CType(resources.GetObject("btnGasto.Image"), System.Drawing.Image)
        Me.btnGasto.Location = New System.Drawing.Point(187, 227)
        Me.btnGasto.Name = "btnGasto"
        Me.btnGasto.Size = New System.Drawing.Size(23, 23)
        Me.btnGasto.TabIndex = 312
        Me.btnGasto.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(6, 230)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 313
        Me.Label10.Text = "Gasto"
        '
        'txtGasto
        '
        Me.txtGasto.Enabled = False
        Me.txtGasto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGasto.Location = New System.Drawing.Point(209, 227)
        Me.txtGasto.Name = "txtGasto"
        Me.txtGasto.ReadOnly = True
        Me.txtGasto.Size = New System.Drawing.Size(307, 23)
        Me.txtGasto.TabIndex = 314
        '
        'txtIDGasto
        '
        Me.txtIDGasto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGasto.Location = New System.Drawing.Point(86, 227)
        Me.txtIDGasto.Name = "txtIDGasto"
        Me.txtIDGasto.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGasto.TabIndex = 311
        Me.txtIDGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkSinEspecificar)
        Me.GroupBox3.Controls.Add(Me.dtpFinalRegistro)
        Me.GroupBox3.Controls.Add(Me.dtpInicialIngreso)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 256)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(417, 46)
        Me.GroupBox3.TabIndex = 352
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha de Ingreso"
        '
        'chkSinEspecificar
        '
        Me.chkSinEspecificar.AutoSize = True
        Me.chkSinEspecificar.Checked = True
        Me.chkSinEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSinEspecificar.Location = New System.Drawing.Point(313, 19)
        Me.chkSinEspecificar.Name = "chkSinEspecificar"
        Me.chkSinEspecificar.Size = New System.Drawing.Size(100, 19)
        Me.chkSinEspecificar.TabIndex = 53
        Me.chkSinEspecificar.Text = "Sin Especificar"
        Me.chkSinEspecificar.UseVisualStyleBackColor = True
        '
        'dtpFinalRegistro
        '
        Me.dtpFinalRegistro.CustomFormat = ""
        Me.dtpFinalRegistro.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFinalRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFinalRegistro.Location = New System.Drawing.Point(203, 17)
        Me.dtpFinalRegistro.Name = "dtpFinalRegistro"
        Me.dtpFinalRegistro.Size = New System.Drawing.Size(104, 23)
        Me.dtpFinalRegistro.TabIndex = 2
        '
        'dtpInicialIngreso
        '
        Me.dtpInicialIngreso.CustomFormat = ""
        Me.dtpInicialIngreso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpInicialIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicialIngreso.Location = New System.Drawing.Point(52, 17)
        Me.dtpInicialIngreso.Name = "dtpInicialIngreso"
        Me.dtpInicialIngreso.Size = New System.Drawing.Size(104, 23)
        Me.dtpInicialIngreso.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(162, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Hasta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 15)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Desde"
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.Label14)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(522, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 426)
        Me.GbCondiciones.TabIndex = 353
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'frm_reporte_suplidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 571)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGasto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtGasto)
        Me.Controls.Add(Me.txtIDGasto)
        Me.Controls.Add(Me.btnNCF)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNCF)
        Me.Controls.Add(Me.txtIDNCF)
        Me.Controls.Add(Me.btnCondicion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCondicion)
        Me.Controls.Add(Me.txtIDCondicion)
        Me.Controls.Add(Me.btnMunicipio)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMunicipio)
        Me.Controls.Add(Me.txtIDMunicipio)
        Me.Controls.Add(Me.btnTipoDocumento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTipoDocumento)
        Me.Controls.Add(Me.txtIDTipoDocumento)
        Me.Controls.Add(Me.btnProvincia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProvincia)
        Me.Controls.Add(Me.txtIDProvincia)
        Me.Controls.Add(Me.btnTipoSuplidor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTipoSuplidor)
        Me.Controls.Add(Me.txtIDTipoSuplidor)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_suplidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "132"
        Me.Text = "Reporte de Suplidores"
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
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoInicial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkEspCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnTipoSuplidor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTipoSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents btnProvincia As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProvincia As System.Windows.Forms.TextBox
    Friend WithEvents txtIDProvincia As System.Windows.Forms.TextBox
    Friend WithEvents btnTipoDocumento As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents btnMunicipio As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents btnCondicion As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCondicion As System.Windows.Forms.TextBox
    Friend WithEvents btnNCF As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNCF As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNCF As System.Windows.Forms.TextBox
    Friend WithEvents btnGasto As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGasto As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGasto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSinEspecificar As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFinalRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicialIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
End Class
