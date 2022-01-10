<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_antiguedad_saldos_cxp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_antiguedad_saldos_cxp))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbOpciones = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
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
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkNoEspecificar = New System.Windows.Forms.CheckBox()
        Me.btnBuscarSuplidor = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSuplidor = New System.Windows.Forms.TextBox()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.DgvAntiguedad = New System.Windows.Forms.DataGridView()
        Me.IDSuplidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Suplidor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.De1a15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.De16a30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.De31a45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.De46a60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.De61a90 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mas90 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt1a15 = New System.Windows.Forms.TextBox()
        Me.txt16a30 = New System.Windows.Forms.TextBox()
        Me.txt31a45 = New System.Windows.Forms.TextBox()
        Me.txt46a60 = New System.Windows.Forms.TextBox()
        Me.txt61a90 = New System.Windows.Forms.TextBox()
        Me.txtmas90 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GbOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GbOpciones)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, 560)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 109)
        Me.Panel1.TabIndex = 256
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnActualizar, Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(852, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(344, 95)
        Me.MenuStrip1.TabIndex = 44
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Libregco.My.Resources.Resources.Refresh_x72
        Me.btnActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(84, 91)
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.GbOpciones.Controls.Add(Me.chkResumir)
        Me.GbOpciones.Controls.Add(Me.CbxFormato)
        Me.GbOpciones.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbOpciones.Location = New System.Drawing.Point(200, 3)
        Me.GbOpciones.Name = "GbOpciones"
        Me.GbOpciones.Size = New System.Drawing.Size(305, 96)
        Me.GbOpciones.TabIndex = 35
        Me.GbOpciones.TabStop = False
        Me.GbOpciones.Text = "Formato"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(178, 25)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 357
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'CbxFormato
        '
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 50)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(291, 23)
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
        Me.BarraEstado.Location = New System.Drawing.Point(0, 669)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1193, 25)
        Me.BarraEstado.TabIndex = 257
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
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(51, 22)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(99, 23)
        Me.dtpFechaInicial.TabIndex = 258
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(199, 22)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(99, 23)
        Me.dtpFechaFinal.TabIndex = 259
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 56)
        Me.GroupBox2.TabIndex = 261
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Entre fechas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "Desde"
        '
        'chkNoEspecificar
        '
        Me.chkNoEspecificar.AutoSize = True
        Me.chkNoEspecificar.Checked = True
        Me.chkNoEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoEspecificar.Location = New System.Drawing.Point(210, 3)
        Me.chkNoEspecificar.Name = "chkNoEspecificar"
        Me.chkNoEspecificar.Size = New System.Drawing.Size(101, 19)
        Me.chkNoEspecificar.TabIndex = 0
        Me.chkNoEspecificar.Text = "No especificar"
        Me.chkNoEspecificar.UseVisualStyleBackColor = True
        '
        'btnBuscarSuplidor
        '
        Me.btnBuscarSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarSuplidor.Image = CType(resources.GetObject("btnBuscarSuplidor.Image"), System.Drawing.Image)
        Me.btnBuscarSuplidor.Location = New System.Drawing.Point(458, 32)
        Me.btnBuscarSuplidor.Name = "btnBuscarSuplidor"
        Me.btnBuscarSuplidor.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarSuplidor.TabIndex = 354
        Me.btnBuscarSuplidor.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(324, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 353
        Me.Label8.Text = "Suplidor"
        '
        'txtSuplidor
        '
        Me.txtSuplidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSuplidor.Enabled = False
        Me.txtSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSuplidor.Location = New System.Drawing.Point(480, 32)
        Me.txtSuplidor.Name = "txtSuplidor"
        Me.txtSuplidor.ReadOnly = True
        Me.txtSuplidor.Size = New System.Drawing.Size(701, 23)
        Me.txtSuplidor.TabIndex = 355
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.Location = New System.Drawing.Point(327, 32)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.Size = New System.Drawing.Size(137, 23)
        Me.txtIDSuplidor.TabIndex = 352
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvAntiguedad
        '
        Me.DgvAntiguedad.AllowUserToAddRows = False
        Me.DgvAntiguedad.AllowUserToDeleteRows = False
        Me.DgvAntiguedad.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvAntiguedad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAntiguedad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAntiguedad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDSuplidor, Me.Suplidor, Me.De1a15, Me.De16a30, Me.De31a45, Me.De46a60, Me.De61a90, Me.Mas90, Me.Balance})
        Me.DgvAntiguedad.Location = New System.Drawing.Point(0, 65)
        Me.DgvAntiguedad.Name = "DgvAntiguedad"
        Me.DgvAntiguedad.ReadOnly = True
        Me.DgvAntiguedad.RowHeadersWidth = 20
        Me.DgvAntiguedad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAntiguedad.Size = New System.Drawing.Size(1193, 440)
        Me.DgvAntiguedad.TabIndex = 356
        '
        'IDSuplidor
        '
        Me.IDSuplidor.HeaderText = "Código"
        Me.IDSuplidor.Name = "IDSuplidor"
        Me.IDSuplidor.ReadOnly = True
        '
        'Suplidor
        '
        Me.Suplidor.HeaderText = "Suplidor"
        Me.Suplidor.Name = "Suplidor"
        Me.Suplidor.ReadOnly = True
        Me.Suplidor.Width = 340
        '
        'De1a15
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.De1a15.DefaultCellStyle = DataGridViewCellStyle1
        Me.De1a15.HeaderText = "1-15 días"
        Me.De1a15.Name = "De1a15"
        Me.De1a15.ReadOnly = True
        '
        'De16a30
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.De16a30.DefaultCellStyle = DataGridViewCellStyle2
        Me.De16a30.HeaderText = "16-30 días"
        Me.De16a30.Name = "De16a30"
        Me.De16a30.ReadOnly = True
        '
        'De31a45
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.De31a45.DefaultCellStyle = DataGridViewCellStyle3
        Me.De31a45.HeaderText = "31-45 días"
        Me.De31a45.Name = "De31a45"
        Me.De31a45.ReadOnly = True
        '
        'De46a60
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.De46a60.DefaultCellStyle = DataGridViewCellStyle4
        Me.De46a60.HeaderText = "46-60 días"
        Me.De46a60.Name = "De46a60"
        Me.De46a60.ReadOnly = True
        '
        'De61a90
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.De61a90.DefaultCellStyle = DataGridViewCellStyle5
        Me.De61a90.HeaderText = "61-90 días"
        Me.De61a90.Name = "De61a90"
        Me.De61a90.ReadOnly = True
        '
        'Mas90
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.Mas90.DefaultCellStyle = DataGridViewCellStyle6
        Me.Mas90.HeaderText = "Más de 90 días"
        Me.Mas90.Name = "Mas90"
        Me.Mas90.ReadOnly = True
        Me.Mas90.Width = 125
        '
        'Balance
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Balance.DefaultCellStyle = DataGridViewCellStyle7
        Me.Balance.HeaderText = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.ReadOnly = True
        Me.Balance.Width = 108
        '
        'txt1a15
        '
        Me.txt1a15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt1a15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt1a15.Location = New System.Drawing.Point(458, 526)
        Me.txt1a15.Name = "txt1a15"
        Me.txt1a15.ReadOnly = True
        Me.txt1a15.Size = New System.Drawing.Size(103, 23)
        Me.txt1a15.TabIndex = 357
        Me.txt1a15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt16a30
        '
        Me.txt16a30.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt16a30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt16a30.Location = New System.Drawing.Point(563, 526)
        Me.txt16a30.Name = "txt16a30"
        Me.txt16a30.ReadOnly = True
        Me.txt16a30.Size = New System.Drawing.Size(94, 23)
        Me.txt16a30.TabIndex = 358
        Me.txt16a30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt31a45
        '
        Me.txt31a45.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txt31a45.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt31a45.Location = New System.Drawing.Point(659, 526)
        Me.txt31a45.Name = "txt31a45"
        Me.txt31a45.ReadOnly = True
        Me.txt31a45.Size = New System.Drawing.Size(101, 23)
        Me.txt31a45.TabIndex = 359
        Me.txt31a45.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt46a60
        '
        Me.txt46a60.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt46a60.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt46a60.Location = New System.Drawing.Point(762, 526)
        Me.txt46a60.Name = "txt46a60"
        Me.txt46a60.ReadOnly = True
        Me.txt46a60.Size = New System.Drawing.Size(94, 23)
        Me.txt46a60.TabIndex = 360
        Me.txt46a60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt61a90
        '
        Me.txt61a90.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txt61a90.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt61a90.Location = New System.Drawing.Point(857, 526)
        Me.txt61a90.Name = "txt61a90"
        Me.txt61a90.ReadOnly = True
        Me.txt61a90.Size = New System.Drawing.Size(103, 23)
        Me.txt61a90.TabIndex = 361
        Me.txt61a90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtmas90
        '
        Me.txtmas90.BackColor = System.Drawing.Color.Maroon
        Me.txtmas90.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtmas90.ForeColor = System.Drawing.Color.White
        Me.txtmas90.Location = New System.Drawing.Point(961, 526)
        Me.txtmas90.Name = "txtmas90"
        Me.txtmas90.ReadOnly = True
        Me.txtmas90.Size = New System.Drawing.Size(118, 23)
        Me.txtmas90.TabIndex = 362
        Me.txtmas90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(477, 508)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 363
        Me.Label1.Text = "1 a 15 días"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(577, 508)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 364
        Me.Label4.Text = "16 a 30 días"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(679, 508)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 365
        Me.Label5.Text = "31 a 45 días"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(780, 508)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 366
        Me.Label6.Text = "46 a 60 días"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(876, 508)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 367
        Me.Label7.Text = "61 a 90 días"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(981, 508)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 368
        Me.Label9.Text = "Más de 90 días"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1107, 508)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 15)
        Me.Label10.TabIndex = 370
        Me.Label10.Text = "Balance"
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.White
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.ForeColor = System.Drawing.Color.Black
        Me.txtBalance.Location = New System.Drawing.Point(1080, 526)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(113, 23)
        Me.txtBalance.TabIndex = 369
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frm_antiguedad_saldos_cxp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 694)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtmas90)
        Me.Controls.Add(Me.txt61a90)
        Me.Controls.Add(Me.txt46a60)
        Me.Controls.Add(Me.txt31a45)
        Me.Controls.Add(Me.txt16a30)
        Me.Controls.Add(Me.txt1a15)
        Me.Controls.Add(Me.DgvAntiguedad)
        Me.Controls.Add(Me.btnBuscarSuplidor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSuplidor)
        Me.Controls.Add(Me.txtIDSuplidor)
        Me.Controls.Add(Me.chkNoEspecificar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_antiguedad_saldos_cxp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "146"
        Me.Text = "Antiguedad de saldos CXP"
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
        CType(Me.DgvAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GbOpciones As System.Windows.Forms.GroupBox
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
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkNoEspecificar As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarSuplidor As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents DgvAntiguedad As System.Windows.Forms.DataGridView
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt1a15 As System.Windows.Forms.TextBox
    Friend WithEvents txt16a30 As System.Windows.Forms.TextBox
    Friend WithEvents txt31a45 As System.Windows.Forms.TextBox
    Friend WithEvents txt46a60 As System.Windows.Forms.TextBox
    Friend WithEvents txt61a90 As System.Windows.Forms.TextBox
    Friend WithEvents txtmas90 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents IDSuplidor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Suplidor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De1a15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De16a30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De31a45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De46a60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De61a90 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mas90 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balance As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
