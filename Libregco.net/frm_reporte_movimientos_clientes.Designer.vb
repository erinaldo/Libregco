<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte_movimientos_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporte_movimientos_clientes))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkSoloPendientes = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkEspecificar = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.DgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.IDFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Credito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pendiente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acumulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Efectivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deposito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditoBoucher = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LueMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LueMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 463)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1056, 109)
        Me.Panel1.TabIndex = 253
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Location = New System.Drawing.Point(793, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(260, 100)
        Me.Panel2.TabIndex = 45
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
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
        Me.GbOpciones.Controls.Add(Me.chkResumir)
        Me.GbOpciones.Controls.Add(Me.Label23)
        Me.GbOpciones.Controls.Add(Me.cbxTipoOrden)
        Me.GbOpciones.Controls.Add(Me.CbxOrden)
        Me.GbOpciones.Controls.Add(Me.Label13)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(389, 96)
        Me.GbOpciones.TabIndex = 35
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(264, 21)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 51
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(207, 47)
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
        Me.cbxTipoOrden.Location = New System.Drawing.Point(210, 65)
        Me.cbxTipoOrden.Name = "cbxTipoOrden"
        Me.cbxTipoOrden.Size = New System.Drawing.Size(175, 23)
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
        Me.CbxOrden.Size = New System.Drawing.Size(198, 23)
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
        Me.CbxFormato.Size = New System.Drawing.Size(252, 23)
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
        Me.rdbExcel.Size = New System.Drawing.Size(52, 19)
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
        Me.BarraEstado.Location = New System.Drawing.Point(0, 575)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1056, 25)
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.chkSoloPendientes)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkEspecificar)
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(468, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 49)
        Me.GroupBox2.TabIndex = 255
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las fechas"
        '
        'chkSoloPendientes
        '
        Me.chkSoloPendientes.AutoSize = True
        Me.chkSoloPendientes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSoloPendientes.Location = New System.Drawing.Point(421, 20)
        Me.chkSoloPendientes.Name = "chkSoloPendientes"
        Me.chkSoloPendientes.Size = New System.Drawing.Size(145, 17)
        Me.chkSoloPendientes.TabIndex = 55
        Me.chkSoloPendientes.Tag = "-1"
        Me.chkSoloPendientes.Text = "Sólo facturas pendientes"
        Me.chkSoloPendientes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label1.Location = New System.Drawing.Point(403, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1, 30)
        Me.Label1.TabIndex = 54
        '
        'chkEspecificar
        '
        Me.chkEspecificar.AutoSize = True
        Me.chkEspecificar.Checked = True
        Me.chkEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkEspecificar.Location = New System.Drawing.Point(305, 20)
        Me.chkEspecificar.Name = "chkEspecificar"
        Me.chkEspecificar.Size = New System.Drawing.Size(94, 17)
        Me.chkEspecificar.TabIndex = 53
        Me.chkEspecificar.Text = "Sin Especificar"
        Me.chkEspecificar.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinal.Location = New System.Drawing.Point(194, 17)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaFinal.TabIndex = 2
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = ""
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicial.Location = New System.Drawing.Point(45, 17)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(104, 23)
        Me.dtpFechaInicial.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(153, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(4, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Desde"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(65, 24)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 20)
        Me.btnBuscarCliente.TabIndex = 258
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(5, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(202, 13)
        Me.Label8.TabIndex = 257
        Me.Label8.Text = "Seleccione el cliente que desea consultar"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCliente.Location = New System.Drawing.Point(87, 24)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(314, 20)
        Me.txtCliente.TabIndex = 259
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(5, 24)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(61, 20)
        Me.txtIDCliente.TabIndex = 256
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvMovimientos
        '
        Me.DgvMovimientos.AllowUserToAddRows = False
        Me.DgvMovimientos.AllowUserToDeleteRows = False
        Me.DgvMovimientos.AllowUserToResizeColumns = False
        Me.DgvMovimientos.AllowUserToResizeRows = False
        Me.DgvMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvMovimientos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFactura, Me.Documento, Me.FechaFactura, Me.IDTipoDocumento, Me.TipoDocumento, Me.Moneda, Me.Debito, Me.Credito, Me.Cargos, Me.Pendiente, Me.Acumulado, Me.FechaOrder, Me.Efectivo, Me.Cheque, Me.Deposito, Me.Tarjeta, Me.CreditoBoucher})
        Me.DgvMovimientos.Location = New System.Drawing.Point(1, 58)
        Me.DgvMovimientos.MultiSelect = False
        Me.DgvMovimientos.Name = "DgvMovimientos"
        Me.DgvMovimientos.ReadOnly = True
        Me.DgvMovimientos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvMovimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMovimientos.Size = New System.Drawing.Size(1056, 399)
        Me.DgvMovimientos.TabIndex = 260
        '
        'IDFactura
        '
        Me.IDFactura.HeaderText = "IDFactura"
        Me.IDFactura.Name = "IDFactura"
        Me.IDFactura.ReadOnly = True
        Me.IDFactura.Visible = False
        '
        'Documento
        '
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        '
        'FechaFactura
        '
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaFactura.DefaultCellStyle = DataGridViewCellStyle19
        Me.FechaFactura.HeaderText = "Fecha"
        Me.FechaFactura.Name = "FechaFactura"
        Me.FechaFactura.ReadOnly = True
        Me.FechaFactura.Width = 140
        '
        'IDTipoDocumento
        '
        Me.IDTipoDocumento.HeaderText = "IDTipoDocumento"
        Me.IDTipoDocumento.Name = "IDTipoDocumento"
        Me.IDTipoDocumento.ReadOnly = True
        Me.IDTipoDocumento.Visible = False
        '
        'TipoDocumento
        '
        Me.TipoDocumento.HeaderText = "Tipo Documento"
        Me.TipoDocumento.Name = "TipoDocumento"
        Me.TipoDocumento.ReadOnly = True
        Me.TipoDocumento.Width = 160
        '
        'Moneda
        '
        Me.Moneda.HeaderText = "Tipo Pago"
        Me.Moneda.Name = "Moneda"
        Me.Moneda.ReadOnly = True
        Me.Moneda.Width = 95
        '
        'Debito
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Debito.DefaultCellStyle = DataGridViewCellStyle20
        Me.Debito.HeaderText = "Débito"
        Me.Debito.Name = "Debito"
        Me.Debito.ReadOnly = True
        '
        'Credito
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Credito.DefaultCellStyle = DataGridViewCellStyle21
        Me.Credito.HeaderText = "Crédito"
        Me.Credito.Name = "Credito"
        Me.Credito.ReadOnly = True
        '
        'Cargos
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cargos.DefaultCellStyle = DataGridViewCellStyle22
        Me.Cargos.HeaderText = "Cargos"
        Me.Cargos.Name = "Cargos"
        Me.Cargos.ReadOnly = True
        Me.Cargos.Width = 90
        '
        'Pendiente
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pendiente.DefaultCellStyle = DataGridViewCellStyle23
        Me.Pendiente.HeaderText = "Pendiente"
        Me.Pendiente.Name = "Pendiente"
        Me.Pendiente.ReadOnly = True
        Me.Pendiente.Width = 105
        '
        'Acumulado
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.Acumulado.DefaultCellStyle = DataGridViewCellStyle24
        Me.Acumulado.HeaderText = "Acumulado"
        Me.Acumulado.Name = "Acumulado"
        Me.Acumulado.ReadOnly = True
        Me.Acumulado.Width = 120
        '
        'FechaOrder
        '
        Me.FechaOrder.HeaderText = "FechaOrder"
        Me.FechaOrder.Name = "FechaOrder"
        Me.FechaOrder.ReadOnly = True
        Me.FechaOrder.Visible = False
        Me.FechaOrder.Width = 200
        '
        'Efectivo
        '
        Me.Efectivo.HeaderText = "Efectivo"
        Me.Efectivo.Name = "Efectivo"
        Me.Efectivo.ReadOnly = True
        Me.Efectivo.Visible = False
        '
        'Cheque
        '
        Me.Cheque.HeaderText = "Cheque"
        Me.Cheque.Name = "Cheque"
        Me.Cheque.ReadOnly = True
        Me.Cheque.Visible = False
        '
        'Deposito
        '
        Me.Deposito.HeaderText = "Deposito"
        Me.Deposito.Name = "Deposito"
        Me.Deposito.ReadOnly = True
        Me.Deposito.Visible = False
        '
        'Tarjeta
        '
        Me.Tarjeta.HeaderText = "Tarjeta"
        Me.Tarjeta.Name = "Tarjeta"
        Me.Tarjeta.ReadOnly = True
        Me.Tarjeta.Visible = False
        '
        'CreditoBoucher
        '
        Me.CreditoBoucher.HeaderText = "CreditoBoucher"
        Me.CreditoBoucher.Name = "CreditoBoucher"
        Me.CreditoBoucher.ReadOnly = True
        Me.CreditoBoucher.Visible = False
        '
        'LueMoneda
        '
        Me.LueMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LueMoneda.Location = New System.Drawing.Point(407, 24)
        Me.LueMoneda.Name = "LueMoneda"
        Me.LueMoneda.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.LueMoneda.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.LueMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.LueMoneda.Properties.Appearance.Options.UseFont = True
        Me.LueMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.LueMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LueMoneda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.LueMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LueMoneda.Properties.DropDownRows = 6
        Me.LueMoneda.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LueMoneda.Properties.SmallImages = Me.imgFlags
        Me.LueMoneda.Size = New System.Drawing.Size(52, 20)
        Me.LueMoneda.TabIndex = 342
        Me.LueMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(407, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 343
        Me.Label2.Text = "Moneda"
        '
        'frm_reporte_movimientos_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 600)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LueMoneda)
        Me.Controls.Add(Me.DgvMovimientos)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_reporte_movimientos_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "106"
        Me.Text = "Movimientos de clientes"
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
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LueMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkEspecificar As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents DgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents IDFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Credito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pendiente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acumulado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Efectivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deposito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditoBoucher As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSoloPendientes As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LueMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents Label2 As Label
End Class
