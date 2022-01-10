<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_asistencias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_asistencias))
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DgvAsistencias = New System.Windows.Forms.DataGridView()
        Me.IDAsistencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiaHabil = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.IDEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageEmpleado = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Empleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Validado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkEspecificar = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCantidadHoras = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTiempoSalidas = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCantidadSalidas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvBitacora = New System.Windows.Forms.DataGridView()
        Me.IDAsistenciaDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DuracionLetras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.SchedulerControl2 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBar.SuspendLayout()
        CType(Me.DgvAsistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DgvBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.SchedulerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(690, 26)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(351, 102)
        Me.IconPanel.TabIndex = 427
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnDesactivar, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip2.Size = New System.Drawing.Size(351, 102)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 98)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 98)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDesactivar
        '
        Me.btnDesactivar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnDesactivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(84, 98)
        Me.btnDesactivar.Text = "Anular"
        Me.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 98)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 28)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 426
        Me.PicBoxLogo.TabStop = False
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1034, 24)
        Me.MenuBar.TabIndex = 428
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.NuevoRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaLibregcoToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AyudaLibregcoToolStripMenuItem
        '
        Me.AyudaLibregcoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'DgvAsistencias
        '
        Me.DgvAsistencias.AllowUserToAddRows = False
        Me.DgvAsistencias.AllowUserToDeleteRows = False
        Me.DgvAsistencias.AllowUserToResizeColumns = False
        Me.DgvAsistencias.AllowUserToResizeRows = False
        Me.DgvAsistencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvAsistencias.BackgroundColor = System.Drawing.Color.White
        Me.DgvAsistencias.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAsistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAsistencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDAsistencia, Me.DiaHabil, Me.IDEmpleado, Me.ImageEmpleado, Me.Empleado, Me.Tipo, Me.Validado, Me.Observacion})
        Me.DgvAsistencias.Location = New System.Drawing.Point(-1, 5)
        Me.DgvAsistencias.MultiSelect = False
        Me.DgvAsistencias.Name = "DgvAsistencias"
        Me.DgvAsistencias.RowHeadersWidth = 20
        Me.DgvAsistencias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvAsistencias.RowTemplate.Height = 36
        Me.DgvAsistencias.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvAsistencias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAsistencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAsistencias.Size = New System.Drawing.Size(1020, 498)
        Me.DgvAsistencias.TabIndex = 429
        '
        'IDAsistencia
        '
        Me.IDAsistencia.HeaderText = "IDAsistencia"
        Me.IDAsistencia.Name = "IDAsistencia"
        Me.IDAsistencia.ReadOnly = True
        Me.IDAsistencia.Visible = False
        '
        'DiaHabil
        '
        Me.DiaHabil.ActiveLinkColor = System.Drawing.Color.Black
        Me.DiaHabil.FillWeight = 51.0!
        Me.DiaHabil.HeaderText = "Día"
        Me.DiaHabil.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.DiaHabil.LinkColor = System.Drawing.Color.DodgerBlue
        Me.DiaHabil.Name = "DiaHabil"
        Me.DiaHabil.ReadOnly = True
        Me.DiaHabil.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DiaHabil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DiaHabil.Width = 85
        '
        'IDEmpleado
        '
        Me.IDEmpleado.HeaderText = "IDEmpleado"
        Me.IDEmpleado.Name = "IDEmpleado"
        Me.IDEmpleado.ReadOnly = True
        Me.IDEmpleado.Visible = False
        '
        'ImageEmpleado
        '
        Me.ImageEmpleado.FillWeight = 25.01087!
        Me.ImageEmpleado.HeaderText = ""
        Me.ImageEmpleado.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.ImageEmpleado.Name = "ImageEmpleado"
        Me.ImageEmpleado.ReadOnly = True
        Me.ImageEmpleado.Width = 42
        '
        'Empleado
        '
        Me.Empleado.FillWeight = 202.9599!
        Me.Empleado.HeaderText = "Empleado"
        Me.Empleado.Name = "Empleado"
        Me.Empleado.ReadOnly = True
        Me.Empleado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Empleado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Empleado.Width = 338
        '
        'Tipo
        '
        Me.Tipo.FillWeight = 109.969!
        Me.Tipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 183
        '
        'Validado
        '
        Me.Validado.FillWeight = 23.22665!
        Me.Validado.HeaderText = "Válido"
        Me.Validado.Name = "Validado"
        Me.Validado.Width = 39
        '
        'Observacion
        '
        Me.Observacion.FillWeight = 187.8337!
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Width = 313
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 713)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1034, 25)
        Me.BarraEstado.TabIndex = 430
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkEspecificar)
        Me.GroupBox2.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox2.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 49)
        Me.GroupBox2.TabIndex = 431
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione las fechas"
        '
        'chkEspecificar
        '
        Me.chkEspecificar.AutoSize = True
        Me.chkEspecificar.Checked = True
        Me.chkEspecificar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEspecificar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkEspecificar.Location = New System.Drawing.Point(297, 20)
        Me.chkEspecificar.Name = "chkEspecificar"
        Me.chkEspecificar.Size = New System.Drawing.Size(94, 17)
        Me.chkEspecificar.TabIndex = 53
        Me.chkEspecificar.Text = "Sin Especificar"
        Me.chkEspecificar.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.CustomFormat = ""
        Me.dtpFechaFinal.Enabled = False
        Me.dtpFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFinal.Location = New System.Drawing.Point(189, 17)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaFinal.TabIndex = 2
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.CustomFormat = ""
        Me.dtpFechaInicial.Enabled = False
        Me.dtpFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicial.Location = New System.Drawing.Point(45, 17)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(95, 23)
        Me.dtpFechaInicial.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(151, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Desde"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDAsistencia"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Día"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "IDEmpleado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "EntradaMatutina"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "SalidaMatutina"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Observación"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 210
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(6, 177)
        Me.XtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.XtraTabControl1.Size = New System.Drawing.Size(1025, 534)
        Me.XtraTabControl1.TabIndex = 432
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.DgvAsistencias)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1019, 506)
        Me.XtraTabPage1.Text = "Asistencias"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GroupControl1)
        Me.XtraTabPage2.Controls.Add(Me.DgvBitacora)
        Me.XtraTabPage2.Controls.Add(Me.SeparatorControl1)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1019, 506)
        Me.XtraTabPage2.Text = "Bitácora"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.lblCantidadHoras)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.lblTiempoSalidas)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.lblCantidadSalidas)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 396)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1010, 104)
        Me.GroupControl1.TabIndex = 34
        Me.GroupControl1.Text = "Resultados"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(387, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 48)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "0"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(387, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Cantidad de horas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(387, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Horas extras"
        '
        'lblCantidadHoras
        '
        Me.lblCantidadHoras.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadHoras.Location = New System.Drawing.Point(8, 38)
        Me.lblCantidadHoras.Name = "lblCantidadHoras"
        Me.lblCantidadHoras.Size = New System.Drawing.Size(158, 48)
        Me.lblCantidadHoras.TabIndex = 8
        Me.lblCantidadHoras.Text = "0"
        Me.lblCantidadHoras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(372, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1, 85)
        Me.Label8.TabIndex = 7
        '
        'lblTiempoSalidas
        '
        Me.lblTiempoSalidas.AutoSize = True
        Me.lblTiempoSalidas.Location = New System.Drawing.Point(290, 61)
        Me.lblTiempoSalidas.Name = "lblTiempoSalidas"
        Me.lblTiempoSalidas.Size = New System.Drawing.Size(13, 13)
        Me.lblTiempoSalidas.TabIndex = 6
        Me.lblTiempoSalidas.Text = "0"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(183, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1, 85)
        Me.Label6.TabIndex = 5
        '
        'lblCantidadSalidas
        '
        Me.lblCantidadSalidas.AutoSize = True
        Me.lblCantidadSalidas.Location = New System.Drawing.Point(290, 35)
        Me.lblCantidadSalidas.Name = "lblCantidadSalidas"
        Me.lblCantidadSalidas.Size = New System.Drawing.Size(13, 13)
        Me.lblCantidadSalidas.TabIndex = 4
        Me.lblCantidadSalidas.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tiempo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cant. de salidas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Horas laboradas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(200, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Salidas"
        '
        'DgvBitacora
        '
        Me.DgvBitacora.AllowUserToAddRows = False
        Me.DgvBitacora.AllowUserToDeleteRows = False
        Me.DgvBitacora.AllowUserToResizeColumns = False
        Me.DgvBitacora.AllowUserToResizeRows = False
        Me.DgvBitacora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvBitacora.BackgroundColor = System.Drawing.Color.White
        Me.DgvBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvBitacora.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvBitacora.ColumnHeadersHeight = 30
        Me.DgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvBitacora.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDAsistenciaDetalle, Me.FechaRegistro, Me.DataGridViewTextBoxColumn11, Me.Duracion, Me.DuracionLetras})
        Me.DgvBitacora.Location = New System.Drawing.Point(-1, 3)
        Me.DgvBitacora.MultiSelect = False
        Me.DgvBitacora.Name = "DgvBitacora"
        Me.DgvBitacora.ReadOnly = True
        Me.DgvBitacora.RowHeadersVisible = False
        Me.DgvBitacora.RowTemplate.Height = 28
        Me.DgvBitacora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvBitacora.Size = New System.Drawing.Size(1020, 387)
        Me.DgvBitacora.TabIndex = 32
        '
        'IDAsistenciaDetalle
        '
        Me.IDAsistenciaDetalle.HeaderText = "IDAsistenciaDetalle"
        Me.IDAsistenciaDetalle.Name = "IDAsistenciaDetalle"
        Me.IDAsistenciaDetalle.ReadOnly = True
        Me.IDAsistenciaDetalle.Visible = False
        '
        'FechaRegistro
        '
        Me.FechaRegistro.FillWeight = 58.82353!
        Me.FechaRegistro.HeaderText = "Hora"
        Me.FechaRegistro.Name = "FechaRegistro"
        Me.FechaRegistro.ReadOnly = True
        Me.FechaRegistro.Width = 150
        '
        'DataGridViewTextBoxColumn11
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn11.FillWeight = 89.32445!
        Me.DataGridViewTextBoxColumn11.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 228
        '
        'Duracion
        '
        Me.Duracion.FillWeight = 85.79575!
        Me.Duracion.HeaderText = "Duración"
        Me.Duracion.Name = "Duracion"
        Me.Duracion.ReadOnly = True
        Me.Duracion.Width = 219
        '
        'DuracionLetras
        '
        Me.DuracionLetras.FillWeight = 166.0563!
        Me.DuracionLetras.HeaderText = "Descripción"
        Me.DuracionLetras.Name = "DuracionLetras"
        Me.DuracionLetras.ReadOnly = True
        Me.DuracionLetras.Width = 423
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(5, 291)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(1011, 23)
        Me.SeparatorControl1.TabIndex = 33
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.SchedulerControl2)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.PageVisible = False
        Me.XtraTabPage3.Size = New System.Drawing.Size(1019, 506)
        Me.XtraTabPage3.Text = "Calendario"
        '
        'SchedulerControl2
        '
        Me.SchedulerControl2.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.FullWeek
        Me.SchedulerControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.SchedulerControl2.DataStorage = Me.SchedulerStorage1
        Me.SchedulerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedulerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SchedulerControl2.Name = "SchedulerControl2"
        Me.SchedulerControl2.OptionsBehavior.ShowRemindersForm = False
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentConflicts = DevExpress.XtraScheduler.AppointmentConflictsMode.Forbidden
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentMultiSelect = False
        Me.SchedulerControl2.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None
        Me.SchedulerControl2.Size = New System.Drawing.Size(1019, 506)
        Me.SchedulerControl2.Start = New Date(2019, 5, 12, 0, 0, 0, 0)
        Me.SchedulerControl2.TabIndex = 1
        Me.SchedulerControl2.Views.AgendaView.Enabled = False
        Me.SchedulerControl2.Views.DayView.Enabled = False
        Me.SchedulerControl2.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl2.Views.FullWeekView.Enabled = True
        Me.SchedulerControl2.Views.FullWeekView.ShowAllDayArea = False
        TimeRuler2.ShowMinutes = True
        Me.SchedulerControl2.Views.FullWeekView.TimeRulers.Add(TimeRuler2)
        Me.SchedulerControl2.Views.FullWeekView.VisibleTime = New DevExpress.XtraScheduler.TimeOfDayInterval(System.TimeSpan.Parse("07:00:00"), System.TimeSpan.Parse("22:00:00"))
        Me.SchedulerControl2.Views.FullWeekView.WorkTime = New DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("07:00:00"), System.TimeSpan.Parse("18:00:00"))
        Me.SchedulerControl2.Views.GanttView.Enabled = False
        Me.SchedulerControl2.Views.TimelineView.Enabled = False
        Me.SchedulerControl2.Views.WeekView.Enabled = False
        Me.SchedulerControl2.Views.WorkWeekView.TimeRulers.Add(TimeRuler3)
        '
        'frm_asistencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 738)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_asistencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "267"
        Me.Text = "Control de asistencias"
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        CType(Me.DgvAsistencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DgvBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.SchedulerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents PicBoxLogo As PictureBox
    Friend WithEvents MenuBar As MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DgvAsistencias As DataGridView
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkEspecificar As CheckBox
    Friend WithEvents dtpFechaFinal As DateTimePicker
    Friend WithEvents dtpFechaInicial As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents btnDesactivar As ToolStripMenuItem
    Friend WithEvents IDAsistencia As DataGridViewTextBoxColumn
    Friend WithEvents DiaHabil As DataGridViewLinkColumn
    Friend WithEvents IDEmpleado As DataGridViewTextBoxColumn
    Friend WithEvents ImageEmpleado As DataGridViewImageColumn
    Friend WithEvents Empleado As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewComboBoxColumn
    Friend WithEvents Validado As DataGridViewCheckBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DgvBitacora As DataGridView
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents lblCantidadHoras As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTiempoSalidas As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblCantidadSalidas As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents IDAsistenciaDetalle As DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistro As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents Duracion As DataGridViewTextBoxColumn
    Friend WithEvents DuracionLetras As DataGridViewTextBoxColumn
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Friend WithEvents SchedulerControl2 As DevExpress.XtraScheduler.SchedulerControl
End Class
