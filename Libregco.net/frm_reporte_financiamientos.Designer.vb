<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_financiamientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_financiamientos))
        Me.GbCondiciones = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxBalance = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdbNoVencidas = New System.Windows.Forms.RadioButton()
        Me.rdbVencidas = New System.Windows.Forms.RadioButton()
        Me.rdbTodas = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.chkSinEspecificar = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnUsuario = New System.Windows.Forms.Button()
        Me.btnVendedor = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDUsuario = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTipoFinanciamiento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoFinanciamiento = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.txtIDFormaPago = New System.Windows.Forms.TextBox()
        Me.btnCobrador = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.btnTipoNCF = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.txtIDNcf = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEquipo = New System.Windows.Forms.TextBox()
        Me.txtIDEquipo = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdbCuotasNoVencidas = New System.Windows.Forms.RadioButton()
        Me.rdbVencidasCuotas = New System.Windows.Forms.RadioButton()
        Me.rdbTodasCuotas = New System.Windows.Forms.RadioButton()
        Me.cbxBalanceCuotas = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GbCondiciones.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbCondiciones
        '
        Me.GbCondiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondiciones.Controls.Add(Me.GroupBox3)
        Me.GbCondiciones.Controls.Add(Me.GroupBox4)
        Me.GbCondiciones.Controls.Add(Me.Label12)
        Me.GbCondiciones.Controls.Add(Me.chkResumir)
        Me.GbCondiciones.Controls.Add(Me.Label16)
        Me.GbCondiciones.Controls.Add(Me.cbxEstado)
        Me.GbCondiciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GbCondiciones.Location = New System.Drawing.Point(520, 2)
        Me.GbCondiciones.Name = "GbCondiciones"
        Me.GbCondiciones.Size = New System.Drawing.Size(193, 385)
        Me.GbCondiciones.TabIndex = 404
        Me.GbCondiciones.TabStop = False
        Me.GbCondiciones.Text = "Condiciones"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(7, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 394
        Me.Label11.Text = "Balance"
        '
        'cbxBalance
        '
        Me.cbxBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxBalance.FormattingEnabled = True
        Me.cbxBalance.Items.AddRange(New Object() {"Todos", "Sólo pendientes", "En cero"})
        Me.cbxBalance.Location = New System.Drawing.Point(10, 100)
        Me.cbxBalance.Name = "cbxBalance"
        Me.cbxBalance.Size = New System.Drawing.Size(165, 23)
        Me.cbxBalance.TabIndex = 393
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbNoVencidas)
        Me.GroupBox4.Controls.Add(Me.cbxBalance)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.rdbVencidas)
        Me.GroupBox4.Controls.Add(Me.rdbTodas)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 48)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(181, 132)
        Me.GroupBox4.TabIndex = 392
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status del financiamiento"
        '
        'rdbNoVencidas
        '
        Me.rdbNoVencidas.AutoSize = True
        Me.rdbNoVencidas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbNoVencidas.Location = New System.Drawing.Point(6, 60)
        Me.rdbNoVencidas.Name = "rdbNoVencidas"
        Me.rdbNoVencidas.Size = New System.Drawing.Size(90, 19)
        Me.rdbNoVencidas.TabIndex = 2
        Me.rdbNoVencidas.Text = "No Vencidas"
        Me.rdbNoVencidas.UseVisualStyleBackColor = True
        '
        'rdbVencidas
        '
        Me.rdbVencidas.AutoSize = True
        Me.rdbVencidas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbVencidas.Location = New System.Drawing.Point(6, 37)
        Me.rdbVencidas.Name = "rdbVencidas"
        Me.rdbVencidas.Size = New System.Drawing.Size(71, 19)
        Me.rdbVencidas.TabIndex = 1
        Me.rdbVencidas.Text = "Vencidas"
        Me.rdbVencidas.UseVisualStyleBackColor = True
        '
        'rdbTodas
        '
        Me.rdbTodas.AutoSize = True
        Me.rdbTodas.Checked = True
        Me.rdbTodas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbTodas.Location = New System.Drawing.Point(6, 16)
        Me.rdbTodas.Name = "rdbTodas"
        Me.rdbTodas.Size = New System.Drawing.Size(56, 19)
        Me.rdbTodas.TabIndex = 0
        Me.rdbTodas.TabStop = True
        Me.rdbTodas.Text = "Todas"
        Me.rdbTodas.UseVisualStyleBackColor = True
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
        Me.Label16.Location = New System.Drawing.Point(13, 326)
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
        Me.cbxEstado.Location = New System.Drawing.Point(13, 344)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(170, 23)
        Me.cbxEstado.TabIndex = 32
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 506)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(721, 25)
        Me.BarraEstado.TabIndex = 403
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
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 393)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 402
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(459, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(266, 109)
        Me.Panel2.TabIndex = 40
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(266, 109)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 105)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 105)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x72
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 105)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSinEspecificar)
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(417, 47)
        Me.GroupBox2.TabIndex = 401
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las fechas"
        '
        'chkSinEspecificar
        '
        Me.chkSinEspecificar.AutoSize = True
        Me.chkSinEspecificar.Checked = True
        Me.chkSinEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSinEspecificar.Location = New System.Drawing.Point(313, 20)
        Me.chkSinEspecificar.Name = "chkSinEspecificar"
        Me.chkSinEspecificar.Size = New System.Drawing.Size(100, 19)
        Me.chkSinEspecificar.TabIndex = 54
        Me.chkSinEspecificar.Text = "Sin Especificar"
        Me.chkSinEspecificar.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Enabled = False
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
        Me.dtpFechaInicial.Enabled = False
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
        'btnUsuario
        '
        Me.btnUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnUsuario.Image = CType(resources.GetObject("btnUsuario.Image"), System.Drawing.Image)
        Me.btnUsuario.Location = New System.Drawing.Point(185, 86)
        Me.btnUsuario.Name = "btnUsuario"
        Me.btnUsuario.Size = New System.Drawing.Size(23, 23)
        Me.btnUsuario.TabIndex = 415
        Me.btnUsuario.UseVisualStyleBackColor = True
        '
        'btnVendedor
        '
        Me.btnVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnVendedor.Image = CType(resources.GetObject("btnVendedor.Image"), System.Drawing.Image)
        Me.btnVendedor.Location = New System.Drawing.Point(185, 115)
        Me.btnVendedor.Name = "btnVendedor"
        Me.btnVendedor.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedor.TabIndex = 412
        Me.btnVendedor.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(185, 57)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 409
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(8, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 15)
        Me.Label8.TabIndex = 408
        Me.Label8.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 406
        Me.Label6.Text = "Usuario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Vendedor"
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(207, 86)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(304, 23)
        Me.txtUsuario.TabIndex = 416
        '
        'txtVendedor
        '
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(207, 115)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(304, 23)
        Me.txtVendedor.TabIndex = 413
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(207, 57)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(304, 23)
        Me.txtCliente.TabIndex = 410
        '
        'txtIDUsuario
        '
        Me.txtIDUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDUsuario.Location = New System.Drawing.Point(84, 86)
        Me.txtIDUsuario.Name = "txtIDUsuario"
        Me.txtIDUsuario.Size = New System.Drawing.Size(102, 23)
        Me.txtIDUsuario.TabIndex = 414
        Me.txtIDUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(84, 115)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(102, 23)
        Me.txtIDVendedor.TabIndex = 411
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(84, 57)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCliente.TabIndex = 407
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(185, 144)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 419
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 417
        Me.Label1.Text = "Tipo Financ"
        '
        'txtTipoFinanciamiento
        '
        Me.txtTipoFinanciamiento.Enabled = False
        Me.txtTipoFinanciamiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoFinanciamiento.Location = New System.Drawing.Point(207, 144)
        Me.txtTipoFinanciamiento.Name = "txtTipoFinanciamiento"
        Me.txtTipoFinanciamiento.ReadOnly = True
        Me.txtTipoFinanciamiento.Size = New System.Drawing.Size(304, 23)
        Me.txtTipoFinanciamiento.TabIndex = 420
        '
        'txtIDTipoFinanciamiento
        '
        Me.txtIDTipoFinanciamiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoFinanciamiento.Location = New System.Drawing.Point(84, 144)
        Me.txtIDTipoFinanciamiento.Name = "txtIDTipoFinanciamiento"
        Me.txtIDTipoFinanciamiento.Size = New System.Drawing.Size(102, 23)
        Me.txtIDTipoFinanciamiento.TabIndex = 418
        Me.txtIDTipoFinanciamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(185, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 423
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "Forma pago"
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Enabled = False
        Me.txtFormaPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFormaPago.Location = New System.Drawing.Point(207, 173)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ReadOnly = True
        Me.txtFormaPago.Size = New System.Drawing.Size(304, 23)
        Me.txtFormaPago.TabIndex = 424
        '
        'txtIDFormaPago
        '
        Me.txtIDFormaPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFormaPago.Location = New System.Drawing.Point(84, 173)
        Me.txtIDFormaPago.Name = "txtIDFormaPago"
        Me.txtIDFormaPago.Size = New System.Drawing.Size(102, 23)
        Me.txtIDFormaPago.TabIndex = 422
        Me.txtIDFormaPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCobrador
        '
        Me.btnCobrador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCobrador.Image = CType(resources.GetObject("btnCobrador.Image"), System.Drawing.Image)
        Me.btnCobrador.Location = New System.Drawing.Point(185, 231)
        Me.btnCobrador.Name = "btnCobrador"
        Me.btnCobrador.Size = New System.Drawing.Size(23, 23)
        Me.btnCobrador.TabIndex = 431
        Me.btnCobrador.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 429
        Me.Label5.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(207, 231)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(304, 23)
        Me.txtCobrador.TabIndex = 432
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(84, 231)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCobrador.TabIndex = 430
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTipoNCF
        '
        Me.btnTipoNCF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTipoNCF.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnTipoNCF.Image = CType(resources.GetObject("btnTipoNCF.Image"), System.Drawing.Image)
        Me.btnTipoNCF.Location = New System.Drawing.Point(185, 202)
        Me.btnTipoNCF.Name = "btnTipoNCF"
        Me.btnTipoNCF.Size = New System.Drawing.Size(23, 23)
        Me.btnTipoNCF.TabIndex = 426
        Me.btnTipoNCF.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(8, 205)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(73, 15)
        Me.Label21.TabIndex = 427
        Me.Label21.Text = "Tipo de NCF"
        '
        'txtNCF
        '
        Me.txtNCF.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNCF.Enabled = False
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.Location = New System.Drawing.Point(207, 202)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(304, 23)
        Me.txtNCF.TabIndex = 428
        '
        'txtIDNcf
        '
        Me.txtIDNcf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNcf.Location = New System.Drawing.Point(84, 202)
        Me.txtIDNcf.Name = "txtIDNcf"
        Me.txtIDNcf.Size = New System.Drawing.Size(102, 23)
        Me.txtIDNcf.TabIndex = 425
        Me.txtIDNcf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 263)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "Equipo"
        '
        'txtEquipo
        '
        Me.txtEquipo.Enabled = False
        Me.txtEquipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEquipo.Location = New System.Drawing.Point(187, 260)
        Me.txtEquipo.Name = "txtEquipo"
        Me.txtEquipo.ReadOnly = True
        Me.txtEquipo.Size = New System.Drawing.Size(324, 23)
        Me.txtEquipo.TabIndex = 435
        '
        'txtIDEquipo
        '
        Me.txtIDEquipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEquipo.Location = New System.Drawing.Point(84, 260)
        Me.txtIDEquipo.Name = "txtIDEquipo"
        Me.txtIDEquipo.Size = New System.Drawing.Size(102, 23)
        Me.txtIDEquipo.TabIndex = 434
        Me.txtIDEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbxBalanceCuotas)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.rdbCuotasNoVencidas)
        Me.GroupBox3.Controls.Add(Me.rdbVencidasCuotas)
        Me.GroupBox3.Controls.Add(Me.rdbTodasCuotas)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 186)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(187, 137)
        Me.GroupBox3.TabIndex = 393
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status de las cuotas"
        '
        'rdbCuotasNoVencidas
        '
        Me.rdbCuotasNoVencidas.AutoSize = True
        Me.rdbCuotasNoVencidas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbCuotasNoVencidas.Location = New System.Drawing.Point(6, 60)
        Me.rdbCuotasNoVencidas.Name = "rdbCuotasNoVencidas"
        Me.rdbCuotasNoVencidas.Size = New System.Drawing.Size(90, 19)
        Me.rdbCuotasNoVencidas.TabIndex = 2
        Me.rdbCuotasNoVencidas.Text = "No Vencidas"
        Me.rdbCuotasNoVencidas.UseVisualStyleBackColor = True
        '
        'rdbVencidasCuotas
        '
        Me.rdbVencidasCuotas.AutoSize = True
        Me.rdbVencidasCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbVencidasCuotas.Location = New System.Drawing.Point(6, 37)
        Me.rdbVencidasCuotas.Name = "rdbVencidasCuotas"
        Me.rdbVencidasCuotas.Size = New System.Drawing.Size(71, 19)
        Me.rdbVencidasCuotas.TabIndex = 1
        Me.rdbVencidasCuotas.Text = "Vencidas"
        Me.rdbVencidasCuotas.UseVisualStyleBackColor = True
        '
        'rdbTodasCuotas
        '
        Me.rdbTodasCuotas.AutoSize = True
        Me.rdbTodasCuotas.Checked = True
        Me.rdbTodasCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbTodasCuotas.Location = New System.Drawing.Point(6, 16)
        Me.rdbTodasCuotas.Name = "rdbTodasCuotas"
        Me.rdbTodasCuotas.Size = New System.Drawing.Size(56, 19)
        Me.rdbTodasCuotas.TabIndex = 0
        Me.rdbTodasCuotas.TabStop = True
        Me.rdbTodasCuotas.Text = "Todas"
        Me.rdbTodasCuotas.UseVisualStyleBackColor = True
        '
        'cbxBalanceCuotas
        '
        Me.cbxBalanceCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBalanceCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBalanceCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxBalanceCuotas.FormattingEnabled = True
        Me.cbxBalanceCuotas.Items.AddRange(New Object() {"Todas", "Sólo pendientes", "En cero"})
        Me.cbxBalanceCuotas.Location = New System.Drawing.Point(10, 100)
        Me.cbxBalanceCuotas.Name = "cbxBalanceCuotas"
        Me.cbxBalanceCuotas.Size = New System.Drawing.Size(165, 23)
        Me.cbxBalanceCuotas.TabIndex = 395
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(7, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 15)
        Me.Label7.TabIndex = 396
        Me.Label7.Text = "Balance"
        '
        'frm_reporte_financiamientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 531)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEquipo)
        Me.Controls.Add(Me.txtIDEquipo)
        Me.Controls.Add(Me.btnCobrador)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.Controls.Add(Me.btnTipoNCF)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtNCF)
        Me.Controls.Add(Me.txtIDNcf)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtFormaPago)
        Me.Controls.Add(Me.txtIDFormaPago)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoFinanciamiento)
        Me.Controls.Add(Me.txtIDTipoFinanciamiento)
        Me.Controls.Add(Me.btnUsuario)
        Me.Controls.Add(Me.btnVendedor)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDUsuario)
        Me.Controls.Add(Me.txtIDVendedor)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.GbCondiciones)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_financiamientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "274"
        Me.Text = "Reporte de financiamientos"
        Me.GbCondiciones.ResumeLayout(False)
        Me.GbCondiciones.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GbOpciones.ResumeLayout(False)
        Me.GbOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GbCondiciones As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rdbNoVencidas As RadioButton
    Friend WithEvents rdbVencidas As RadioButton
    Friend WithEvents rdbTodas As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents chkResumir As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbxEstado As ComboBox
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
    Friend WithEvents Label13 As Label
    Friend WithEvents CbxFormato As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PicSalida As PictureBox
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkSinEspecificar As CheckBox
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnUsuario As Button
    Friend WithEvents btnVendedor As Button
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtIDUsuario As TextBox
    Friend WithEvents txtIDVendedor As TextBox
    Friend WithEvents txtIDCliente As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTipoFinanciamiento As TextBox
    Friend WithEvents txtIDTipoFinanciamiento As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFormaPago As TextBox
    Friend WithEvents txtIDFormaPago As TextBox
    Friend WithEvents btnCobrador As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCobrador As TextBox
    Friend WithEvents txtIDCobrador As TextBox
    Friend WithEvents btnTipoNCF As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents txtNCF As TextBox
    Friend WithEvents txtIDNcf As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEquipo As TextBox
    Friend WithEvents txtIDEquipo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbxBalance As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdbCuotasNoVencidas As RadioButton
    Friend WithEvents rdbVencidasCuotas As RadioButton
    Friend WithEvents rdbTodasCuotas As RadioButton
    Friend WithEvents cbxBalanceCuotas As ComboBox
    Friend WithEvents Label7 As Label
End Class
