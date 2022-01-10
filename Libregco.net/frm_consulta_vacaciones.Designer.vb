<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_vacaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_vacaciones))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbGeneral = New System.Windows.Forms.RadioButton()
        Me.rdbEspecifico = New System.Windows.Forms.RadioButton()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarCons = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPresentar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStructure = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.DgvVacaciones = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.lblSumaTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscarTipoComprobante = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.DgvVacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(5, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "Formato Reporte:"
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = True
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(9, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 44
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(9, 34)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbGeneral)
        Me.Panel1.Controls.Add(Me.rdbEspecifico)
        Me.Panel1.Location = New System.Drawing.Point(6, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 23)
        Me.Panel1.TabIndex = 347
        '
        'rdbGeneral
        '
        Me.rdbGeneral.AutoSize = True
        Me.rdbGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbGeneral.Location = New System.Drawing.Point(88, 2)
        Me.rdbGeneral.Name = "rdbGeneral"
        Me.rdbGeneral.Size = New System.Drawing.Size(69, 19)
        Me.rdbGeneral.TabIndex = 347
        Me.rdbGeneral.Text = "General"
        Me.rdbGeneral.UseVisualStyleBackColor = True
        '
        'rdbEspecifico
        '
        Me.rdbEspecifico.AutoSize = True
        Me.rdbEspecifico.Checked = True
        Me.rdbEspecifico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbEspecifico.Location = New System.Drawing.Point(2, 2)
        Me.rdbEspecifico.Name = "rdbEspecifico"
        Me.rdbEspecifico.Size = New System.Drawing.Size(80, 19)
        Me.rdbEspecifico.TabIndex = 346
        Me.rdbEspecifico.TabStop = True
        Me.rdbEspecifico.Text = "Específico"
        Me.rdbEspecifico.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 465)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(781, 25)
        Me.BarraEstado.TabIndex = 459
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
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(108, 15)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(1, 389)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(347, 71)
        Me.IconPanel.TabIndex = 458
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnBuscarCons, Me.btnPresentar, Me.btnModificar, Me.btnStructure})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(347, 71)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 67)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.Size = New System.Drawing.Size(60, 67)
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnPresentar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(68, 67)
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(70, 67)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStructure
        '
        Me.btnStructure.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.btnStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnStructure.Name = "btnStructure"
        Me.btnStructure.Size = New System.Drawing.Size(72, 67)
        Me.btnStructure.Text = "Estructura"
        Me.btnStructure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCantidad.Location = New System.Drawing.Point(8, 361)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(127, 15)
        Me.lblCantidad.TabIndex = 457
        Me.lblCantidad.Text = "Registros Encontrados:"
        '
        'DgvVacaciones
        '
        Me.DgvVacaciones.AllowUserToAddRows = False
        Me.DgvVacaciones.AllowUserToDeleteRows = False
        Me.DgvVacaciones.AllowUserToResizeColumns = False
        Me.DgvVacaciones.AllowUserToResizeRows = False
        Me.DgvVacaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvVacaciones.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvVacaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvVacaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvVacaciones.Location = New System.Drawing.Point(6, 92)
        Me.DgvVacaciones.MultiSelect = False
        Me.DgvVacaciones.Name = "DgvVacaciones"
        Me.DgvVacaciones.ReadOnly = True
        Me.DgvVacaciones.RowHeadersWidth = 20
        Me.DgvVacaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvVacaciones.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure
        Me.DgvVacaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvVacaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvVacaciones.Size = New System.Drawing.Size(770, 256)
        Me.DgvVacaciones.StandardTab = True
        Me.DgvVacaciones.TabIndex = 456
        Me.DgvVacaciones.TabStop = False
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(108, 34)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'lblSumaTotal
        '
        Me.lblSumaTotal.AutoSize = True
        Me.lblSumaTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSumaTotal.Location = New System.Drawing.Point(589, 349)
        Me.lblSumaTotal.Name = "lblSumaTotal"
        Me.lblSumaTotal.Size = New System.Drawing.Size(69, 15)
        Me.lblSumaTotal.TabIndex = 445
        Me.lblSumaTotal.Text = "Suma Total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Estado"
        '
        'cbxEstado
        '
        Me.cbxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Todos", "Sólo Activos", "Nulos"})
        Me.cbxEstado.Location = New System.Drawing.Point(6, 41)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(135, 23)
        Me.cbxEstado.TabIndex = 33
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.chkResumir)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CbxFormato)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.GroupBox3.Location = New System.Drawing.Point(347, 361)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(429, 97)
        Me.GroupBox3.TabIndex = 460
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de Reporte"
        '
        'chkResumir
        '
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(132, 40)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(121, 19)
        Me.chkResumir.TabIndex = 350
        Me.chkResumir.Text = "[Resumir Reporte]"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox4.Controls.Add(Me.rdbImpresora)
        Me.GroupBox4.Controls.Add(Me.rdbPDF)
        Me.GroupBox4.Controls.Add(Me.rdbExcel)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(257, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(166, 60)
        Me.GroupBox4.TabIndex = 349
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Salida"
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(6, 61)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(247, 23)
        Me.CbxFormato.TabIndex = 348
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = ""
        Me.txtFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaFinal.Location = New System.Drawing.Point(53, 54)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaFinal.TabIndex = 342
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbxEstado)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(629, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 83)
        Me.GroupBox2.TabIndex = 449
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Condiciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta:"
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmpleado.Enabled = False
        Me.txtEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmpleado.Location = New System.Drawing.Point(306, 20)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(317, 23)
        Me.txtEmpleado.TabIndex = 450
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEmpleado.Location = New System.Drawing.Point(171, 20)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.Size = New System.Drawing.Size(118, 23)
        Me.txtIDEmpleado.TabIndex = 444
        Me.txtIDEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 86)
        Me.GroupBox1.TabIndex = 443
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Entre Fechas"
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = ""
        Me.txtFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicial.Location = New System.Drawing.Point(53, 22)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaInicial.TabIndex = 341
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(171, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 455
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(303, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 15)
        Me.Label4.TabIndex = 454
        Me.Label4.Text = "Sucursal"
        '
        'btnBuscarTipoComprobante
        '
        Me.btnBuscarTipoComprobante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoComprobante.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTipoComprobante.Image = CType(resources.GetObject("btnBuscarTipoComprobante.Image"), System.Drawing.Image)
        Me.btnBuscarTipoComprobante.Location = New System.Drawing.Point(285, 63)
        Me.btnBuscarTipoComprobante.Name = "btnBuscarTipoComprobante"
        Me.btnBuscarTipoComprobante.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTipoComprobante.TabIndex = 448
        Me.btnBuscarTipoComprobante.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(306, 63)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(317, 23)
        Me.txtSucursal.TabIndex = 453
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(171, 63)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(118, 23)
        Me.txtIDSucursal.TabIndex = 447
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(171, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 452
        Me.Label6.Text = "Código"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(303, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 451
        Me.Label5.Text = "Empleado"
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarEmpleado.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarEmpleado.Image = CType(resources.GetObject("btnBuscarEmpleado.Image"), System.Drawing.Image)
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(285, 20)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarEmpleado.TabIndex = 446
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = True
        '
        'frm_consulta_vacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 490)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.DgvVacaciones)
        Me.Controls.Add(Me.lblSumaTotal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtEmpleado)
        Me.Controls.Add(Me.txtIDEmpleado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscarTipoComprobante)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.txtIDSucursal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscarEmpleado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_vacaciones"
        Me.Tag = "271"
        Me.Text = "Consulta de vacaciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.DgvVacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdbGeneral As RadioButton
    Friend WithEvents rdbEspecifico As RadioButton
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnLimpiar As ToolStripMenuItem
    Friend WithEvents btnBuscarCons As ToolStripMenuItem
    Friend WithEvents btnPresentar As ToolStripMenuItem
    Friend WithEvents btnModificar As ToolStripMenuItem
    Friend WithEvents btnStructure As ToolStripMenuItem
    Friend WithEvents lblCantidad As Label
    Friend WithEvents DgvVacaciones As DataGridView
    Friend WithEvents Fecha As Timer
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents lblSumaTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxEstado As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkResumir As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CbxFormato As ComboBox
    Friend WithEvents txtFechaFinal As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEmpleado As TextBox
    Friend WithEvents txtIDEmpleado As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFechaInicial As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBuscarTipoComprobante As Button
    Friend WithEvents txtSucursal As TextBox
    Friend WithEvents txtIDSucursal As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBuscarEmpleado As Button
End Class
