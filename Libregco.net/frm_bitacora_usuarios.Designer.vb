<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_bitacora_usuarios
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_bitacora_usuarios))
        Me.DgvAccesos = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formulario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxEmpleado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cbxPermiso = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkImprimir = New System.Windows.Forms.CheckBox()
        Me.chkModificar = New System.Windows.Forms.CheckBox()
        Me.chkCrear = New System.Windows.Forms.CheckBox()
        Me.chkAcceso = New System.Windows.Forms.CheckBox()
        Me.DgvPermisosOtorgados = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.DataGridViewCheckBoxColumn53 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn54 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn55 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn97 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPermiso = New System.Windows.Forms.Label()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMenuPermisos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bt = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAprobar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNegar = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvAccesos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DgvPermisosOtorgados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuPermisos.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvAccesos
        '
        Me.DgvAccesos.AllowUserToAddRows = False
        Me.DgvAccesos.AllowUserToDeleteRows = False
        Me.DgvAccesos.BackgroundColor = System.Drawing.Color.White
        Me.DgvAccesos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAccesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAccesos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Equipo, Me.Entrada, Me.Formulario})
        Me.DgvAccesos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvAccesos.Location = New System.Drawing.Point(3, 47)
        Me.DgvAccesos.MultiSelect = False
        Me.DgvAccesos.Name = "DgvAccesos"
        Me.DgvAccesos.ReadOnly = True
        Me.DgvAccesos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAccesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAccesos.Size = New System.Drawing.Size(1001, 616)
        Me.DgvAccesos.TabIndex = 1
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 170
        '
        'Equipo
        '
        Me.Equipo.HeaderText = "Equipo"
        Me.Equipo.Name = "Equipo"
        Me.Equipo.ReadOnly = True
        Me.Equipo.Width = 140
        '
        'Entrada
        '
        Me.Entrada.HeaderText = "Entrada"
        Me.Entrada.Name = "Entrada"
        Me.Entrada.ReadOnly = True
        Me.Entrada.Width = 400
        '
        'Formulario
        '
        Me.Formulario.HeaderText = "Formulario"
        Me.Formulario.Name = "Formulario"
        Me.Formulario.ReadOnly = True
        Me.Formulario.Width = 260
        '
        'cbxEmpleado
        '
        Me.cbxEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEmpleado.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.cbxEmpleado.FormattingEnabled = True
        Me.cbxEmpleado.Location = New System.Drawing.Point(74, 8)
        Me.cbxEmpleado.Name = "cbxEmpleado"
        Me.cbxEmpleado.Size = New System.Drawing.Size(447, 33)
        Me.cbxEmpleado.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empleado"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 765)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1015, 25)
        Me.BarraEstado.TabIndex = 414
        Me.BarraEstado.Text = "ToolStrip1"
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, -1)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(172, 19)
        Me.CheckBox1.TabIndex = 415
        Me.CheckBox1.Text = "Específicar Rango de fechas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpFinal)
        Me.GroupBox1.Controls.Add(Me.dtpInicial)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(696, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 55)
        Me.GroupBox1.TabIndex = 416
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(157, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 418
        Me.Label3.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 417
        Me.Label2.Text = "Desde"
        '
        'dtpFinal
        '
        Me.dtpFinal.Enabled = False
        Me.dtpFinal.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(198, 22)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(99, 22)
        Me.dtpFinal.TabIndex = 417
        '
        'dtpInicial
        '
        Me.dtpInicial.Enabled = False
        Me.dtpInicial.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicial.Location = New System.Drawing.Point(50, 22)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(99, 22)
        Me.dtpInicial.TabIndex = 416
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(0, 65)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1015, 697)
        Me.TabControl1.TabIndex = 417
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DgvAccesos)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cbxEmpleado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1007, 666)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bitácora"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TabControl2)
        Me.TabPage2.Controls.Add(Me.cbxPermiso)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1007, 666)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Estadísticas"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Permiso"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl2.Location = New System.Drawing.Point(3, 45)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1001, 618)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Chart1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(993, 590)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Gráfico de permisos en equipos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(987, 584)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'cbxPermiso
        '
        Me.cbxPermiso.DropDownHeight = 90
        Me.cbxPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPermiso.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.cbxPermiso.FormattingEnabled = True
        Me.cbxPermiso.IntegralHeight = False
        Me.cbxPermiso.Location = New System.Drawing.Point(68, 6)
        Me.cbxPermiso.Name = "cbxPermiso"
        Me.cbxPermiso.Size = New System.Drawing.Size(447, 33)
        Me.cbxPermiso.TabIndex = 4
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Controls.Add(Me.chkImprimir)
        Me.TabPage4.Controls.Add(Me.chkModificar)
        Me.TabPage4.Controls.Add(Me.chkCrear)
        Me.TabPage4.Controls.Add(Me.chkAcceso)
        Me.TabPage4.Controls.Add(Me.DgvPermisosOtorgados)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.lblPermiso)
        Me.TabPage4.Controls.Add(Me.lblProceso)
        Me.TabPage4.Controls.Add(Me.lblModulo)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Controls.Add(Me.Label5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 27)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1007, 666)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Permisos otorgados"
        '
        'chkImprimir
        '
        Me.chkImprimir.AutoSize = True
        Me.chkImprimir.Location = New System.Drawing.Point(979, 63)
        Me.chkImprimir.Name = "chkImprimir"
        Me.chkImprimir.Size = New System.Drawing.Size(15, 14)
        Me.chkImprimir.TabIndex = 36
        Me.chkImprimir.UseVisualStyleBackColor = True
        '
        'chkModificar
        '
        Me.chkModificar.AutoSize = True
        Me.chkModificar.Location = New System.Drawing.Point(877, 63)
        Me.chkModificar.Name = "chkModificar"
        Me.chkModificar.Size = New System.Drawing.Size(15, 14)
        Me.chkModificar.TabIndex = 35
        Me.chkModificar.UseVisualStyleBackColor = True
        '
        'chkCrear
        '
        Me.chkCrear.AutoSize = True
        Me.chkCrear.Location = New System.Drawing.Point(778, 63)
        Me.chkCrear.Name = "chkCrear"
        Me.chkCrear.Size = New System.Drawing.Size(15, 14)
        Me.chkCrear.TabIndex = 34
        Me.chkCrear.UseVisualStyleBackColor = True
        '
        'chkAcceso
        '
        Me.chkAcceso.AutoSize = True
        Me.chkAcceso.Location = New System.Drawing.Point(677, 63)
        Me.chkAcceso.Name = "chkAcceso"
        Me.chkAcceso.Size = New System.Drawing.Size(15, 14)
        Me.chkAcceso.TabIndex = 33
        Me.chkAcceso.UseVisualStyleBackColor = True
        '
        'DgvPermisosOtorgados
        '
        Me.DgvPermisosOtorgados.AllowUserToAddRows = False
        Me.DgvPermisosOtorgados.AllowUserToDeleteRows = False
        Me.DgvPermisosOtorgados.AllowUserToResizeColumns = False
        Me.DgvPermisosOtorgados.AllowUserToResizeRows = False
        Me.DgvPermisosOtorgados.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvPermisosOtorgados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPermisosOtorgados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPermisosOtorgados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn52, Me.Imagen, Me.DataGridViewTextBoxColumn53, Me.DataGridViewCheckBoxColumn53, Me.DataGridViewCheckBoxColumn54, Me.DataGridViewCheckBoxColumn55, Me.DataGridViewCheckBoxColumn97})
        Me.DgvPermisosOtorgados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvPermisosOtorgados.Location = New System.Drawing.Point(3, 58)
        Me.DgvPermisosOtorgados.MultiSelect = False
        Me.DgvPermisosOtorgados.Name = "DgvPermisosOtorgados"
        Me.DgvPermisosOtorgados.RowHeadersWidth = 45
        Me.DgvPermisosOtorgados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPermisosOtorgados.RowTemplate.Height = 50
        Me.DgvPermisosOtorgados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPermisosOtorgados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPermisosOtorgados.Size = New System.Drawing.Size(1001, 605)
        Me.DgvPermisosOtorgados.TabIndex = 32
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.HeaderText = "#ID Permiso"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        '
        'Imagen
        '
        Me.Imagen.HeaderText = ""
        Me.Imagen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.Imagen.Name = "Imagen"
        Me.Imagen.ReadOnly = True
        Me.Imagen.Width = 55
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.ActiveLinkColor = System.Drawing.Color.White
        Me.DataGridViewTextBoxColumn53.HeaderText = "Empleado"
        Me.DataGridViewTextBoxColumn53.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.DataGridViewTextBoxColumn53.LinkColor = System.Drawing.Color.Black
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        Me.DataGridViewTextBoxColumn53.ReadOnly = True
        Me.DataGridViewTextBoxColumn53.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn53.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn53.Width = 400
        '
        'DataGridViewCheckBoxColumn53
        '
        Me.DataGridViewCheckBoxColumn53.HeaderText = "Acceso"
        Me.DataGridViewCheckBoxColumn53.Name = "DataGridViewCheckBoxColumn53"
        '
        'DataGridViewCheckBoxColumn54
        '
        Me.DataGridViewCheckBoxColumn54.HeaderText = "Crear"
        Me.DataGridViewCheckBoxColumn54.Name = "DataGridViewCheckBoxColumn54"
        Me.DataGridViewCheckBoxColumn54.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn54.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewCheckBoxColumn55
        '
        Me.DataGridViewCheckBoxColumn55.HeaderText = "Modificar"
        Me.DataGridViewCheckBoxColumn55.Name = "DataGridViewCheckBoxColumn55"
        '
        'DataGridViewCheckBoxColumn97
        '
        Me.DataGridViewCheckBoxColumn97.HeaderText = "Imprimir"
        Me.DataGridViewCheckBoxColumn97.Name = "DataGridViewCheckBoxColumn97"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(296, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Permiso"
        '
        'lblPermiso
        '
        Me.lblPermiso.AutoSize = True
        Me.lblPermiso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermiso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPermiso.Location = New System.Drawing.Point(297, 33)
        Me.lblPermiso.Name = "lblPermiso"
        Me.lblPermiso.Size = New System.Drawing.Size(0, 13)
        Me.lblPermiso.TabIndex = 5
        '
        'lblProceso
        '
        Me.lblProceso.AutoSize = True
        Me.lblProceso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProceso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblProceso.Location = New System.Drawing.Point(172, 33)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(0, 13)
        Me.lblProceso.TabIndex = 4
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblModulo.Location = New System.Drawing.Point(27, 33)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(0, 13)
        Me.lblModulo.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(172, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Proceso ---->"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Módulo ---->"
        '
        'CMenuPermisos
        '
        Me.CMenuPermisos.BackColor = System.Drawing.Color.White
        Me.CMenuPermisos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bt, Me.ToolStripSeparator5, Me.btnAprobar, Me.btnNegar})
        Me.CMenuPermisos.Name = "ContextMenuStrip1"
        Me.CMenuPermisos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuPermisos.Size = New System.Drawing.Size(175, 100)
        Me.CMenuPermisos.Text = "Opciones"
        '
        'bt
        '
        Me.bt.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.bt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bt.Image = Global.Libregco.My.Resources.Resources.Delete_x24
        Me.bt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.bt.Name = "bt"
        Me.bt.Size = New System.Drawing.Size(174, 30)
        Me.bt.Text = "Descartar permisos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(171, 6)
        '
        'btnAprobar
        '
        Me.btnAprobar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnAprobar.ForeColor = System.Drawing.Color.Green
        Me.btnAprobar.Image = Global.Libregco.My.Resources.Resources.Addx24
        Me.btnAprobar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(174, 30)
        Me.btnAprobar.Text = "Aprobar permisos"
        '
        'btnNegar
        '
        Me.btnNegar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnNegar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNegar.Image = Global.Libregco.My.Resources.Resources.Minusx24
        Me.btnNegar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNegar.Name = "btnNegar"
        Me.btnNegar.Size = New System.Drawing.Size(174, 30)
        Me.btnNegar.Text = "Negar permisos"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 170
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Equipo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 140
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 400
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Formulario"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 260
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "# ID Permiso"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Empleado"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 440
        '
        'frm_bitacora_usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 790)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_bitacora_usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bitácora de usuarios"
        CType(Me.DgvAccesos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DgvPermisosOtorgados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuPermisos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvAccesos As System.Windows.Forms.DataGridView
    Friend WithEvents cbxEmpleado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Formulario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents cbxPermiso As ComboBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPermiso As Label
    Friend WithEvents lblProceso As Label
    Friend WithEvents lblModulo As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DgvPermisosOtorgados As DataGridView
    Friend WithEvents chkImprimir As CheckBox
    Friend WithEvents chkModificar As CheckBox
    Friend WithEvents chkCrear As CheckBox
    Friend WithEvents chkAcceso As CheckBox
    Friend WithEvents CMenuPermisos As ContextMenuStrip
    Friend WithEvents bt As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnAprobar As ToolStripMenuItem
    Friend WithEvents btnNegar As ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn
    Friend WithEvents Imagen As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As DataGridViewLinkColumn
    Friend WithEvents DataGridViewCheckBoxColumn53 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn54 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn55 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn97 As DataGridViewCheckBoxColumn
End Class
