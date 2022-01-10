<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_recibos_cobros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_recibos_cobros))
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxNaturaleza = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CbxCerrado = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
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
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkSinEspecificar = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTipoRecibo = New System.Windows.Forms.TextBox()
        Me.txtIDTipoRecibo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEntrega = New System.Windows.Forms.TextBox()
        Me.txtIDEntrega = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGrupoRecibo = New System.Windows.Forms.TextBox()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTalonario = New System.Windows.Forms.TextBox()
        Me.txtIDTalonario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtIDFactura = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRecepcion = New System.Windows.Forms.TextBox()
        Me.txtIDRecepcion = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnFactura = New System.Windows.Forms.Button()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.btnTalonario = New System.Windows.Forms.Button()
        Me.btnGrupoRecibos = New System.Windows.Forms.Button()
        Me.btnEntrega = New System.Windows.Forms.Button()
        Me.btnTipoRecibo = New System.Windows.Forms.Button()
        Me.btnCobrador = New System.Windows.Forms.Button()
        Me.GbCondiciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Controls.Add(Me.Label9)
        Me.GbCondiciones.Controls.Add(Me.cbxNaturaleza)
        Me.GbCondiciones.Controls.Add(Me.Label15)
        Me.GbCondiciones.Controls.Add(Me.CbxCerrado)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(519, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 340)
        Me.GbCondiciones.TabIndex = 306
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(9, 146)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 15)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(9, 164)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 103
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(9, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Naturaleza"
        '
        'cbxNaturaleza
        '
        Me.cbxNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNaturaleza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNaturaleza.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxNaturaleza.FormattingEnabled = True
        Me.cbxNaturaleza.Items.AddRange(New Object() {"Todos", "Recibos de cobros", "Recibos de ingresos", "Ajustes"})
        Me.cbxNaturaleza.Location = New System.Drawing.Point(9, 68)
        Me.cbxNaturaleza.Name = "cbxNaturaleza"
        Me.cbxNaturaleza.Size = New System.Drawing.Size(178, 23)
        Me.cbxNaturaleza.TabIndex = 101
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(9, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Cerrado"
        '
        'CbxCerrado
        '
        Me.CbxCerrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCerrado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxCerrado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxCerrado.FormattingEnabled = True
        Me.CbxCerrado.Items.AddRange(New Object() {"Todos", "Sólo cerrados", "Sólo abiertos"})
        Me.CbxCerrado.Location = New System.Drawing.Point(9, 112)
        Me.CbxCerrado.Name = "CbxCerrado"
        Me.CbxCerrado.Size = New System.Drawing.Size(178, 23)
        Me.CbxCerrado.TabIndex = 99
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 305
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
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 461)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 304
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(8, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 310
        Me.Label7.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(210, 53)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(300, 23)
        Me.txtCobrador.TabIndex = 311
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(87, 53)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCobrador.TabIndex = 308
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.chkSinEspecificar)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 45)
        Me.GroupBox3.TabIndex = 307
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(121, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(2, 25)
        Me.Label14.TabIndex = 284
        '
        'chkSinEspecificar
        '
        Me.chkSinEspecificar.AutoSize = True
        Me.chkSinEspecificar.Checked = True
        Me.chkSinEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSinEspecificar.Location = New System.Drawing.Point(11, 20)
        Me.chkSinEspecificar.Name = "chkSinEspecificar"
        Me.chkSinEspecificar.Size = New System.Drawing.Size(101, 19)
        Me.chkSinEspecificar.TabIndex = 16
        Me.chkSinEspecificar.Text = "Sin Especificar"
        Me.chkSinEspecificar.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinal.Location = New System.Drawing.Point(297, 15)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinal.TabIndex = 18
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
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = ""
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicial.Location = New System.Drawing.Point(168, 15)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaInicial.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 314
        Me.Label1.Text = "Tipo"
        '
        'txtTipoRecibo
        '
        Me.txtTipoRecibo.Enabled = False
        Me.txtTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoRecibo.Location = New System.Drawing.Point(210, 111)
        Me.txtTipoRecibo.Name = "txtTipoRecibo"
        Me.txtTipoRecibo.ReadOnly = True
        Me.txtTipoRecibo.Size = New System.Drawing.Size(300, 23)
        Me.txtTipoRecibo.TabIndex = 315
        '
        'txtIDTipoRecibo
        '
        Me.txtIDTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoRecibo.Location = New System.Drawing.Point(87, 111)
        Me.txtIDTipoRecibo.Name = "txtIDTipoRecibo"
        Me.txtIDTipoRecibo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoRecibo.TabIndex = 312
        Me.txtIDTipoRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 318
        Me.Label2.Text = "Entrega"
        '
        'txtEntrega
        '
        Me.txtEntrega.Enabled = False
        Me.txtEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEntrega.Location = New System.Drawing.Point(210, 140)
        Me.txtEntrega.Name = "txtEntrega"
        Me.txtEntrega.ReadOnly = True
        Me.txtEntrega.Size = New System.Drawing.Size(300, 23)
        Me.txtEntrega.TabIndex = 319
        '
        'txtIDEntrega
        '
        Me.txtIDEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEntrega.Location = New System.Drawing.Point(87, 140)
        Me.txtIDEntrega.Name = "txtIDEntrega"
        Me.txtIDEntrega.Size = New System.Drawing.Size(102, 23)
        Me.txtIDEntrega.TabIndex = 316
        Me.txtIDEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 322
        Me.Label3.Text = "Grupo"
        '
        'txtGrupoRecibo
        '
        Me.txtGrupoRecibo.Enabled = False
        Me.txtGrupoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGrupoRecibo.Location = New System.Drawing.Point(210, 169)
        Me.txtGrupoRecibo.Name = "txtGrupoRecibo"
        Me.txtGrupoRecibo.ReadOnly = True
        Me.txtGrupoRecibo.Size = New System.Drawing.Size(300, 23)
        Me.txtGrupoRecibo.TabIndex = 323
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(87, 169)
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDGrupo.TabIndex = 320
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 326
        Me.Label4.Text = "Talonario"
        '
        'txtTalonario
        '
        Me.txtTalonario.Enabled = False
        Me.txtTalonario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTalonario.Location = New System.Drawing.Point(210, 198)
        Me.txtTalonario.Name = "txtTalonario"
        Me.txtTalonario.ReadOnly = True
        Me.txtTalonario.Size = New System.Drawing.Size(300, 23)
        Me.txtTalonario.TabIndex = 327
        '
        'txtIDTalonario
        '
        Me.txtIDTalonario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTalonario.Location = New System.Drawing.Point(87, 198)
        Me.txtIDTalonario.Name = "txtIDTalonario"
        Me.txtIDTalonario.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTalonario.TabIndex = 324
        Me.txtIDTalonario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 230)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 330
        Me.Label5.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(210, 227)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(300, 23)
        Me.txtCliente.TabIndex = 331
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(87, 227)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCliente.TabIndex = 328
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 334
        Me.Label6.Text = "Factura"
        '
        'txtFactura
        '
        Me.txtFactura.Enabled = False
        Me.txtFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFactura.Location = New System.Drawing.Point(210, 256)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(300, 23)
        Me.txtFactura.TabIndex = 335
        '
        'txtIDFactura
        '
        Me.txtIDFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFactura.Location = New System.Drawing.Point(87, 256)
        Me.txtIDFactura.Name = "txtIDFactura"
        Me.txtIDFactura.Size = New System.Drawing.Size(102, 23)
        Me.txtIDFactura.TabIndex = 332
        Me.txtIDFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(8, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 342
        Me.Label10.Text = "Recepción"
        '
        'txtRecepcion
        '
        Me.txtRecepcion.Enabled = False
        Me.txtRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRecepcion.Location = New System.Drawing.Point(210, 82)
        Me.txtRecepcion.Name = "txtRecepcion"
        Me.txtRecepcion.ReadOnly = True
        Me.txtRecepcion.Size = New System.Drawing.Size(300, 23)
        Me.txtRecepcion.TabIndex = 343
        '
        'txtIDRecepcion
        '
        Me.txtIDRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDRecepcion.Location = New System.Drawing.Point(87, 82)
        Me.txtIDRecepcion.Name = "txtIDRecepcion"
        Me.txtIDRecepcion.Size = New System.Drawing.Size(102, 23)
        Me.txtIDRecepcion.TabIndex = 340
        Me.txtIDRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button8
        '
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.Location = New System.Drawing.Point(188, 82)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(23, 23)
        Me.Button8.TabIndex = 341
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btnFactura
        '
        Me.btnFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnFactura.Image = CType(resources.GetObject("btnFactura.Image"), System.Drawing.Image)
        Me.btnFactura.Location = New System.Drawing.Point(188, 256)
        Me.btnFactura.Name = "btnFactura"
        Me.btnFactura.Size = New System.Drawing.Size(23, 23)
        Me.btnFactura.TabIndex = 333
        Me.btnFactura.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(188, 227)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnCliente.TabIndex = 329
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'btnTalonario
        '
        Me.btnTalonario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTalonario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTalonario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTalonario.Image = CType(resources.GetObject("btnTalonario.Image"), System.Drawing.Image)
        Me.btnTalonario.Location = New System.Drawing.Point(188, 198)
        Me.btnTalonario.Name = "btnTalonario"
        Me.btnTalonario.Size = New System.Drawing.Size(23, 23)
        Me.btnTalonario.TabIndex = 325
        Me.btnTalonario.UseVisualStyleBackColor = True
        '
        'btnGrupoRecibos
        '
        Me.btnGrupoRecibos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGrupoRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGrupoRecibos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGrupoRecibos.Image = CType(resources.GetObject("btnGrupoRecibos.Image"), System.Drawing.Image)
        Me.btnGrupoRecibos.Location = New System.Drawing.Point(188, 169)
        Me.btnGrupoRecibos.Name = "btnGrupoRecibos"
        Me.btnGrupoRecibos.Size = New System.Drawing.Size(23, 23)
        Me.btnGrupoRecibos.TabIndex = 321
        Me.btnGrupoRecibos.UseVisualStyleBackColor = True
        '
        'btnEntrega
        '
        Me.btnEntrega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEntrega.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEntrega.Image = CType(resources.GetObject("btnEntrega.Image"), System.Drawing.Image)
        Me.btnEntrega.Location = New System.Drawing.Point(188, 140)
        Me.btnEntrega.Name = "btnEntrega"
        Me.btnEntrega.Size = New System.Drawing.Size(23, 23)
        Me.btnEntrega.TabIndex = 317
        Me.btnEntrega.UseVisualStyleBackColor = True
        '
        'btnTipoRecibo
        '
        Me.btnTipoRecibo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoRecibo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoRecibo.Image = CType(resources.GetObject("btnTipoRecibo.Image"), System.Drawing.Image)
        Me.btnTipoRecibo.Location = New System.Drawing.Point(188, 111)
        Me.btnTipoRecibo.Name = "btnTipoRecibo"
        Me.btnTipoRecibo.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoRecibo.TabIndex = 313
        Me.btnTipoRecibo.UseVisualStyleBackColor = True
        '
        'btnCobrador
        '
        Me.btnCobrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCobrador.Image = CType(resources.GetObject("btnCobrador.Image"), System.Drawing.Image)
        Me.btnCobrador.Location = New System.Drawing.Point(188, 53)
        Me.btnCobrador.Name = "btnCobrador"
        Me.btnCobrador.Size = New System.Drawing.Size(23, 23)
        Me.btnCobrador.TabIndex = 309
        Me.btnCobrador.UseVisualStyleBackColor = True
        '
        'frm_reporte_recibos_cobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 486)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRecepcion)
        Me.Controls.Add(Me.txtIDRecepcion)
        Me.Controls.Add(Me.btnFactura)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.txtIDFactura)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.btnTalonario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTalonario)
        Me.Controls.Add(Me.txtIDTalonario)
        Me.Controls.Add(Me.btnGrupoRecibos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGrupoRecibo)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.btnEntrega)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEntrega)
        Me.Controls.Add(Me.txtIDEntrega)
        Me.Controls.Add(Me.btnTipoRecibo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoRecibo)
        Me.Controls.Add(Me.txtIDTipoRecibo)
        Me.Controls.Add(Me.btnCobrador)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_recibos_cobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "213"
        Me.Text = "Reporte de recibos de cobros"
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
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GbCondiciones As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
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
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents btnCobrador As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobrador As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkSinEspecificar As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnTipoRecibo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTipoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents btnEntrega As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEntrega As System.Windows.Forms.TextBox
    Friend WithEvents txtIDEntrega As System.Windows.Forms.TextBox
    Friend WithEvents btnGrupoRecibos As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoRecibo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents btnTalonario As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTalonario As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTalonario As System.Windows.Forms.TextBox
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CbxCerrado As System.Windows.Forms.ComboBox
    Friend WithEvents btnFactura As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtIDFactura As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxNaturaleza As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
End Class
