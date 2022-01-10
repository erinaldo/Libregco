<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_mant_tandas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_tandas))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIDTanda = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicMinLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.DgvTandasDetalle = New System.Windows.Forms.DataGridView()
        Me.dtpDomingode = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpdomingohasta = New System.Windows.Forms.DateTimePicker()
        Me.chkdomingolaborable = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpluneshasta = New System.Windows.Forms.DateTimePicker()
        Me.chkluneslaborable = New System.Windows.Forms.CheckBox()
        Me.dtplunesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpmarteshasta = New System.Windows.Forms.DateTimePicker()
        Me.chkmarteslaborable = New System.Windows.Forms.CheckBox()
        Me.dtpmartesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpmiercoleshasta = New System.Windows.Forms.DateTimePicker()
        Me.chkmiercoleslaborable = New System.Windows.Forms.CheckBox()
        Me.dtpmiercoelsde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpjueveshasta = New System.Windows.Forms.DateTimePicker()
        Me.chkjueveslaborable = New System.Windows.Forms.CheckBox()
        Me.dtpjuevesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpvierneshasta = New System.Windows.Forms.DateTimePicker()
        Me.chkvierneslaborable = New System.Windows.Forms.CheckBox()
        Me.dtpviernesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpsabadohasta = New System.Windows.Forms.DateTimePicker()
        Me.chksabadolaborable = New System.Windows.Forms.CheckBox()
        Me.dtpsabadode = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rdbTarde = New System.Windows.Forms.RadioButton()
        Me.rdbDia = New System.Windows.Forms.RadioButton()
        Me.rdbNoche = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtDescripcionHorario = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Domingo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Lunes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Martes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Miercoles = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Jueves = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Viernes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Sabado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTandaDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradaDomingo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalidaDomingo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LunesEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LunesSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MartesEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MartesSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiercolesEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiercolesSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradaJueves = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalidaJueves = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViernesEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViernesSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradaSabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalidaSabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParteDia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMenuPermisos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.bt = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.DgvTandasDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuPermisos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "Código"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(118, 135)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(719, 23)
        Me.txtDescripcion.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(118, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Descripción"
        '
        'txtIDTanda
        '
        Me.txtIDTanda.Enabled = False
        Me.txtIDTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTanda.Location = New System.Drawing.Point(15, 135)
        Me.txtIDTanda.Name = "txtIDTanda"
        Me.txtIDTanda.ReadOnly = True
        Me.txtIDTanda.Size = New System.Drawing.Size(97, 23)
        Me.txtIDTanda.TabIndex = 185
        Me.txtIDTanda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(15, 91)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 184
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1149, 24)
        Me.MenuStrip1.TabIndex = 183
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(174, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
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
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(6, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(232, 81)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular})
        Me.MenuStrip2.Location = New System.Drawing.Point(802, 26)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(344, 95)
        Me.MenuStrip2.TabIndex = 240
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 91)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 91)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(226, 38)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnGuardaryLimpiar
        '
        Me.btnGuardaryLimpiar.Image = Global.Libregco.My.Resources.Resources.Save_and_Clean_x32
        Me.btnGuardaryLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardaryLimpiar.Name = "btnGuardaryLimpiar"
        Me.btnGuardaryLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnGuardaryLimpiar.Size = New System.Drawing.Size(226, 38)
        Me.btnGuardaryLimpiar.Text = "Guardar y Limpiar"
        Me.btnGuardaryLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
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
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 91)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicMinLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 659)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1149, 25)
        Me.BarraEstado.TabIndex = 274
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicMinLogo
        '
        Me.PicMinLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicMinLogo.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x20
        Me.PicMinLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicMinLogo.Name = "PicMinLogo"
        Me.PicMinLogo.Size = New System.Drawing.Size(23, 22)
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
        'DgvTandasDetalle
        '
        Me.DgvTandasDetalle.AllowUserToAddRows = False
        Me.DgvTandasDetalle.AllowUserToDeleteRows = False
        Me.DgvTandasDetalle.AllowUserToResizeColumns = False
        Me.DgvTandasDetalle.AllowUserToResizeRows = False
        Me.DgvTandasDetalle.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvTandasDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTandasDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTandasDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTandasDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idTandaDetalle, Me.Column1, Me.Descripción, Me.Domingo, Me.EntradaDomingo, Me.SalidaDomingo, Me.Lunes, Me.LunesEntrada, Me.LunesSalida, Me.Martes, Me.MartesEntrada, Me.MartesSalida, Me.Miercoles, Me.MiercolesEntrada, Me.MiercolesSalida, Me.Jueves, Me.EntradaJueves, Me.SalidaJueves, Me.Viernes, Me.ViernesEntrada, Me.ViernesSalida, Me.Sabado, Me.EntradaSabado, Me.SalidaSabado, Me.ParteDia})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTandasDetalle.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTandasDetalle.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvTandasDetalle.Location = New System.Drawing.Point(0, 303)
        Me.DgvTandasDetalle.MultiSelect = False
        Me.DgvTandasDetalle.Name = "DgvTandasDetalle"
        Me.DgvTandasDetalle.ReadOnly = True
        Me.DgvTandasDetalle.RowHeadersVisible = False
        Me.DgvTandasDetalle.RowHeadersWidth = 10
        Me.DgvTandasDetalle.RowTemplate.Height = 40
        Me.DgvTandasDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTandasDetalle.Size = New System.Drawing.Size(1149, 356)
        Me.DgvTandasDetalle.TabIndex = 275
        '
        'dtpDomingode
        '
        Me.dtpDomingode.CustomFormat = "hh:mm:ss tt"
        Me.dtpDomingode.Enabled = False
        Me.dtpDomingode.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpDomingode.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpDomingode.Location = New System.Drawing.Point(59, 19)
        Me.dtpDomingode.Name = "dtpDomingode"
        Me.dtpDomingode.ShowUpDown = True
        Me.dtpDomingode.Size = New System.Drawing.Size(87, 20)
        Me.dtpDomingode.TabIndex = 276
        Me.dtpDomingode.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpdomingohasta)
        Me.GroupBox1.Controls.Add(Me.chkdomingolaborable)
        Me.GroupBox1.Controls.Add(Me.dtpDomingode)
        Me.GroupBox1.Location = New System.Drawing.Point(56, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox1.TabIndex = 277
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Domingo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "De"
        '
        'dtpdomingohasta
        '
        Me.dtpdomingohasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpdomingohasta.Enabled = False
        Me.dtpdomingohasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpdomingohasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpdomingohasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpdomingohasta.Name = "dtpdomingohasta"
        Me.dtpdomingohasta.ShowUpDown = True
        Me.dtpdomingohasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpdomingohasta.TabIndex = 277
        Me.dtpdomingohasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkdomingolaborable
        '
        Me.chkdomingolaborable.AutoSize = True
        Me.chkdomingolaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkdomingolaborable.Name = "chkdomingolaborable"
        Me.chkdomingolaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkdomingolaborable.TabIndex = 0
        Me.chkdomingolaborable.Text = "Laborable"
        Me.chkdomingolaborable.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpluneshasta)
        Me.GroupBox2.Controls.Add(Me.chkluneslaborable)
        Me.GroupBox2.Controls.Add(Me.dtplunesde)
        Me.GroupBox2.Location = New System.Drawing.Point(213, 184)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox2.TabIndex = 280
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lunes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 279
        Me.Label5.Text = "Hasta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 278
        Me.Label6.Text = "De"
        '
        'dtpluneshasta
        '
        Me.dtpluneshasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpluneshasta.Enabled = False
        Me.dtpluneshasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpluneshasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpluneshasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpluneshasta.Name = "dtpluneshasta"
        Me.dtpluneshasta.ShowUpDown = True
        Me.dtpluneshasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpluneshasta.TabIndex = 277
        Me.dtpluneshasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkluneslaborable
        '
        Me.chkluneslaborable.AutoSize = True
        Me.chkluneslaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkluneslaborable.Name = "chkluneslaborable"
        Me.chkluneslaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkluneslaborable.TabIndex = 0
        Me.chkluneslaborable.Text = "Laborable"
        Me.chkluneslaborable.UseVisualStyleBackColor = True
        '
        'dtplunesde
        '
        Me.dtplunesde.CustomFormat = "hh:mm:ss tt"
        Me.dtplunesde.Enabled = False
        Me.dtplunesde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtplunesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtplunesde.Location = New System.Drawing.Point(59, 19)
        Me.dtplunesde.Name = "dtplunesde"
        Me.dtplunesde.ShowUpDown = True
        Me.dtplunesde.Size = New System.Drawing.Size(87, 20)
        Me.dtplunesde.TabIndex = 276
        Me.dtplunesde.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.dtpmarteshasta)
        Me.GroupBox3.Controls.Add(Me.chkmarteslaborable)
        Me.GroupBox3.Controls.Add(Me.dtpmartesde)
        Me.GroupBox3.Location = New System.Drawing.Point(368, 184)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox3.TabIndex = 281
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Martes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 279
        Me.Label7.Text = "Hasta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 13)
        Me.Label8.TabIndex = 278
        Me.Label8.Text = "De"
        '
        'dtpmarteshasta
        '
        Me.dtpmarteshasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpmarteshasta.Enabled = False
        Me.dtpmarteshasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpmarteshasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpmarteshasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpmarteshasta.Name = "dtpmarteshasta"
        Me.dtpmarteshasta.ShowUpDown = True
        Me.dtpmarteshasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpmarteshasta.TabIndex = 277
        Me.dtpmarteshasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkmarteslaborable
        '
        Me.chkmarteslaborable.AutoSize = True
        Me.chkmarteslaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkmarteslaborable.Name = "chkmarteslaborable"
        Me.chkmarteslaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkmarteslaborable.TabIndex = 0
        Me.chkmarteslaborable.Text = "Laborable"
        Me.chkmarteslaborable.UseVisualStyleBackColor = True
        '
        'dtpmartesde
        '
        Me.dtpmartesde.CustomFormat = "hh:mm:ss tt"
        Me.dtpmartesde.Enabled = False
        Me.dtpmartesde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpmartesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpmartesde.Location = New System.Drawing.Point(59, 19)
        Me.dtpmartesde.Name = "dtpmartesde"
        Me.dtpmartesde.ShowUpDown = True
        Me.dtpmartesde.Size = New System.Drawing.Size(87, 20)
        Me.dtpmartesde.TabIndex = 276
        Me.dtpmartesde.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.dtpmiercoleshasta)
        Me.GroupBox4.Controls.Add(Me.chkmiercoleslaborable)
        Me.GroupBox4.Controls.Add(Me.dtpmiercoelsde)
        Me.GroupBox4.Location = New System.Drawing.Point(522, 184)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox4.TabIndex = 282
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Miércoles"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 279
        Me.Label9.Text = "Hasta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 13)
        Me.Label10.TabIndex = 278
        Me.Label10.Text = "De"
        '
        'dtpmiercoleshasta
        '
        Me.dtpmiercoleshasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpmiercoleshasta.Enabled = False
        Me.dtpmiercoleshasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpmiercoleshasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpmiercoleshasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpmiercoleshasta.Name = "dtpmiercoleshasta"
        Me.dtpmiercoleshasta.ShowUpDown = True
        Me.dtpmiercoleshasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpmiercoleshasta.TabIndex = 277
        Me.dtpmiercoleshasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkmiercoleslaborable
        '
        Me.chkmiercoleslaborable.AutoSize = True
        Me.chkmiercoleslaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkmiercoleslaborable.Name = "chkmiercoleslaborable"
        Me.chkmiercoleslaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkmiercoleslaborable.TabIndex = 0
        Me.chkmiercoleslaborable.Text = "Laborable"
        Me.chkmiercoleslaborable.UseVisualStyleBackColor = True
        '
        'dtpmiercoelsde
        '
        Me.dtpmiercoelsde.CustomFormat = "hh:mm:ss tt"
        Me.dtpmiercoelsde.Enabled = False
        Me.dtpmiercoelsde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpmiercoelsde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpmiercoelsde.Location = New System.Drawing.Point(59, 19)
        Me.dtpmiercoelsde.Name = "dtpmiercoelsde"
        Me.dtpmiercoelsde.ShowUpDown = True
        Me.dtpmiercoelsde.Size = New System.Drawing.Size(87, 20)
        Me.dtpmiercoelsde.TabIndex = 276
        Me.dtpmiercoelsde.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.dtpjueveshasta)
        Me.GroupBox5.Controls.Add(Me.chkjueveslaborable)
        Me.GroupBox5.Controls.Add(Me.dtpjuevesde)
        Me.GroupBox5.Location = New System.Drawing.Point(677, 184)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox5.TabIndex = 283
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Jueves"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 279
        Me.Label11.Text = "Hasta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(18, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 13)
        Me.Label12.TabIndex = 278
        Me.Label12.Text = "De"
        '
        'dtpjueveshasta
        '
        Me.dtpjueveshasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpjueveshasta.Enabled = False
        Me.dtpjueveshasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpjueveshasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpjueveshasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpjueveshasta.Name = "dtpjueveshasta"
        Me.dtpjueveshasta.ShowUpDown = True
        Me.dtpjueveshasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpjueveshasta.TabIndex = 277
        Me.dtpjueveshasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkjueveslaborable
        '
        Me.chkjueveslaborable.AutoSize = True
        Me.chkjueveslaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkjueveslaborable.Name = "chkjueveslaborable"
        Me.chkjueveslaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkjueveslaborable.TabIndex = 0
        Me.chkjueveslaborable.Text = "Laborable"
        Me.chkjueveslaborable.UseVisualStyleBackColor = True
        '
        'dtpjuevesde
        '
        Me.dtpjuevesde.CustomFormat = "hh:mm:ss tt"
        Me.dtpjuevesde.Enabled = False
        Me.dtpjuevesde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpjuevesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpjuevesde.Location = New System.Drawing.Point(59, 19)
        Me.dtpjuevesde.Name = "dtpjuevesde"
        Me.dtpjuevesde.ShowUpDown = True
        Me.dtpjuevesde.Size = New System.Drawing.Size(87, 20)
        Me.dtpjuevesde.TabIndex = 276
        Me.dtpjuevesde.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.dtpvierneshasta)
        Me.GroupBox6.Controls.Add(Me.chkvierneslaborable)
        Me.GroupBox6.Controls.Add(Me.dtpviernesde)
        Me.GroupBox6.Location = New System.Drawing.Point(833, 184)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox6.TabIndex = 284
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Viernes"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 279
        Me.Label13.Text = "Hasta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 13)
        Me.Label14.TabIndex = 278
        Me.Label14.Text = "De"
        '
        'dtpvierneshasta
        '
        Me.dtpvierneshasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpvierneshasta.Enabled = False
        Me.dtpvierneshasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpvierneshasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpvierneshasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpvierneshasta.Name = "dtpvierneshasta"
        Me.dtpvierneshasta.ShowUpDown = True
        Me.dtpvierneshasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpvierneshasta.TabIndex = 277
        Me.dtpvierneshasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chkvierneslaborable
        '
        Me.chkvierneslaborable.AutoSize = True
        Me.chkvierneslaborable.Location = New System.Drawing.Point(80, 0)
        Me.chkvierneslaborable.Name = "chkvierneslaborable"
        Me.chkvierneslaborable.Size = New System.Drawing.Size(73, 17)
        Me.chkvierneslaborable.TabIndex = 0
        Me.chkvierneslaborable.Text = "Laborable"
        Me.chkvierneslaborable.UseVisualStyleBackColor = True
        '
        'dtpviernesde
        '
        Me.dtpviernesde.CustomFormat = "hh:mm:ss tt"
        Me.dtpviernesde.Enabled = False
        Me.dtpviernesde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpviernesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpviernesde.Location = New System.Drawing.Point(59, 19)
        Me.dtpviernesde.Name = "dtpviernesde"
        Me.dtpviernesde.ShowUpDown = True
        Me.dtpviernesde.Size = New System.Drawing.Size(87, 20)
        Me.dtpviernesde.TabIndex = 276
        Me.dtpviernesde.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.dtpsabadohasta)
        Me.GroupBox7.Controls.Add(Me.chksabadolaborable)
        Me.GroupBox7.Controls.Add(Me.dtpsabadode)
        Me.GroupBox7.Location = New System.Drawing.Point(987, 184)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(160, 78)
        Me.GroupBox7.TabIndex = 285
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Sábado"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 279
        Me.Label15.Text = "Hasta"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 13)
        Me.Label16.TabIndex = 278
        Me.Label16.Text = "De"
        '
        'dtpsabadohasta
        '
        Me.dtpsabadohasta.CustomFormat = "hh:mm:ss tt"
        Me.dtpsabadohasta.Enabled = False
        Me.dtpsabadohasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpsabadohasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpsabadohasta.Location = New System.Drawing.Point(59, 45)
        Me.dtpsabadohasta.Name = "dtpsabadohasta"
        Me.dtpsabadohasta.ShowUpDown = True
        Me.dtpsabadohasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpsabadohasta.TabIndex = 277
        Me.dtpsabadohasta.Value = New Date(2019, 3, 24, 12, 0, 0, 0)
        '
        'chksabadolaborable
        '
        Me.chksabadolaborable.AutoSize = True
        Me.chksabadolaborable.Location = New System.Drawing.Point(80, 0)
        Me.chksabadolaborable.Name = "chksabadolaborable"
        Me.chksabadolaborable.Size = New System.Drawing.Size(73, 17)
        Me.chksabadolaborable.TabIndex = 0
        Me.chksabadolaborable.Text = "Laborable"
        Me.chksabadolaborable.UseVisualStyleBackColor = True
        '
        'dtpsabadode
        '
        Me.dtpsabadode.CustomFormat = "hh:mm:ss tt"
        Me.dtpsabadode.Enabled = False
        Me.dtpsabadode.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpsabadode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpsabadode.Location = New System.Drawing.Point(59, 19)
        Me.dtpsabadode.Name = "dtpsabadode"
        Me.dtpsabadode.ShowUpDown = True
        Me.dtpsabadode.Size = New System.Drawing.Size(87, 20)
        Me.dtpsabadode.TabIndex = 276
        Me.dtpsabadode.Value = New Date(2019, 3, 24, 8, 0, 0, 0)
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rdbTarde)
        Me.GroupBox8.Controls.Add(Me.rdbDia)
        Me.GroupBox8.Controls.Add(Me.rdbNoche)
        Me.GroupBox8.Controls.Add(Me.PictureBox1)
        Me.GroupBox8.Location = New System.Drawing.Point(-1, 184)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(58, 113)
        Me.GroupBox8.TabIndex = 286
        Me.GroupBox8.TabStop = False
        '
        'rdbTarde
        '
        Me.rdbTarde.AutoSize = True
        Me.rdbTarde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbTarde.Location = New System.Drawing.Point(6, 33)
        Me.rdbTarde.Name = "rdbTarde"
        Me.rdbTarde.Size = New System.Drawing.Size(53, 17)
        Me.rdbTarde.TabIndex = 2
        Me.rdbTarde.Text = "Tarde"
        Me.rdbTarde.UseVisualStyleBackColor = True
        '
        'rdbDia
        '
        Me.rdbDia.AutoSize = True
        Me.rdbDia.Checked = True
        Me.rdbDia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbDia.Location = New System.Drawing.Point(6, 12)
        Me.rdbDia.Name = "rdbDia"
        Me.rdbDia.Size = New System.Drawing.Size(40, 17)
        Me.rdbDia.TabIndex = 1
        Me.rdbDia.TabStop = True
        Me.rdbDia.Text = "Día"
        Me.rdbDia.UseVisualStyleBackColor = True
        '
        'rdbNoche
        '
        Me.rdbNoche.AutoSize = True
        Me.rdbNoche.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbNoche.Location = New System.Drawing.Point(6, 53)
        Me.rdbNoche.Name = "rdbNoche"
        Me.rdbNoche.Size = New System.Drawing.Size(55, 17)
        Me.rdbNoche.TabIndex = 3
        Me.rdbNoche.Text = "Noche"
        Me.rdbNoche.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Morningx512
        Me.PictureBox1.Location = New System.Drawing.Point(10, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "1"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Button1.Location = New System.Drawing.Point(850, 266)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(295, 24)
        Me.Button1.TabIndex = 287
        Me.Button1.Text = "Insertar horario"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 161)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(1130, 23)
        Me.SeparatorControl1.TabIndex = 288
        '
        'txtDescripcionHorario
        '
        Me.txtDescripcionHorario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionHorario.Location = New System.Drawing.Point(193, 267)
        Me.txtDescripcionHorario.Name = "txtDescripcionHorario"
        Me.txtDescripcionHorario.Size = New System.Drawing.Size(653, 23)
        Me.txtDescripcionHorario.TabIndex = 290
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(61, 270)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 15)
        Me.Label17.TabIndex = 288
        Me.Label17.Text = "Descripcion de horario"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(0, 284)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(1149, 23)
        Me.SeparatorControl2.TabIndex = 292
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Domingo
        '
        Me.Domingo.HeaderText = "Dom"
        Me.Domingo.Name = "Domingo"
        Me.Domingo.ReadOnly = True
        Me.Domingo.Width = 35
        '
        'Lunes
        '
        Me.Lunes.HeaderText = "Lun"
        Me.Lunes.Name = "Lunes"
        Me.Lunes.ReadOnly = True
        Me.Lunes.Width = 35
        '
        'Martes
        '
        Me.Martes.HeaderText = "Mar"
        Me.Martes.Name = "Martes"
        Me.Martes.ReadOnly = True
        Me.Martes.Width = 35
        '
        'Miercoles
        '
        Me.Miercoles.HeaderText = "Mié"
        Me.Miercoles.Name = "Miercoles"
        Me.Miercoles.ReadOnly = True
        Me.Miercoles.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Miercoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Miercoles.Width = 35
        '
        'Jueves
        '
        Me.Jueves.HeaderText = "Jue"
        Me.Jueves.Name = "Jueves"
        Me.Jueves.ReadOnly = True
        Me.Jueves.Width = 35
        '
        'Viernes
        '
        Me.Viernes.HeaderText = "Vie"
        Me.Viernes.Name = "Viernes"
        Me.Viernes.ReadOnly = True
        Me.Viernes.Width = 35
        '
        'Sabado
        '
        Me.Sabado.HeaderText = "Sáb"
        Me.Sabado.Name = "Sabado"
        Me.Sabado.ReadOnly = True
        Me.Sabado.Width = 35
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "idTanda"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.Format = "hh:mm:ss tt"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 70
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 70
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 70
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 70
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.Width = 70
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn13.Width = 70
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Width = 70
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Entrada"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.Width = 70
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Salida"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn16.Width = 70
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Column2"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'idTandaDetalle
        '
        Me.idTandaDetalle.HeaderText = "idTandaDetalle"
        Me.idTandaDetalle.Name = "idTandaDetalle"
        Me.idTandaDetalle.ReadOnly = True
        Me.idTandaDetalle.Visible = False
        Me.idTandaDetalle.Width = 80
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Descripción"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        Me.Descripción.Width = 250
        '
        'EntradaDomingo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "hh:mm:ss tt"
        Me.EntradaDomingo.DefaultCellStyle = DataGridViewCellStyle2
        Me.EntradaDomingo.HeaderText = "Entrada"
        Me.EntradaDomingo.Name = "EntradaDomingo"
        Me.EntradaDomingo.ReadOnly = True
        Me.EntradaDomingo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EntradaDomingo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EntradaDomingo.Width = 70
        '
        'SalidaDomingo
        '
        Me.SalidaDomingo.HeaderText = "Salida"
        Me.SalidaDomingo.Name = "SalidaDomingo"
        Me.SalidaDomingo.ReadOnly = True
        Me.SalidaDomingo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalidaDomingo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SalidaDomingo.Width = 70
        '
        'LunesEntrada
        '
        Me.LunesEntrada.HeaderText = "Entrada"
        Me.LunesEntrada.Name = "LunesEntrada"
        Me.LunesEntrada.ReadOnly = True
        Me.LunesEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LunesEntrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LunesEntrada.Width = 70
        '
        'LunesSalida
        '
        Me.LunesSalida.HeaderText = "Salida"
        Me.LunesSalida.Name = "LunesSalida"
        Me.LunesSalida.ReadOnly = True
        Me.LunesSalida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LunesSalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LunesSalida.Width = 70
        '
        'MartesEntrada
        '
        Me.MartesEntrada.HeaderText = "Entrada"
        Me.MartesEntrada.Name = "MartesEntrada"
        Me.MartesEntrada.ReadOnly = True
        Me.MartesEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MartesEntrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MartesEntrada.Width = 70
        '
        'MartesSalida
        '
        Me.MartesSalida.HeaderText = "Salida"
        Me.MartesSalida.Name = "MartesSalida"
        Me.MartesSalida.ReadOnly = True
        Me.MartesSalida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MartesSalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MartesSalida.Width = 70
        '
        'MiercolesEntrada
        '
        Me.MiercolesEntrada.HeaderText = "Entrada"
        Me.MiercolesEntrada.Name = "MiercolesEntrada"
        Me.MiercolesEntrada.ReadOnly = True
        Me.MiercolesEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MiercolesEntrada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MiercolesEntrada.Width = 70
        '
        'MiercolesSalida
        '
        Me.MiercolesSalida.HeaderText = "Salida"
        Me.MiercolesSalida.Name = "MiercolesSalida"
        Me.MiercolesSalida.ReadOnly = True
        Me.MiercolesSalida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MiercolesSalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MiercolesSalida.Width = 70
        '
        'EntradaJueves
        '
        Me.EntradaJueves.HeaderText = "Entrada"
        Me.EntradaJueves.Name = "EntradaJueves"
        Me.EntradaJueves.ReadOnly = True
        Me.EntradaJueves.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EntradaJueves.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EntradaJueves.Width = 70
        '
        'SalidaJueves
        '
        Me.SalidaJueves.HeaderText = "Salida"
        Me.SalidaJueves.Name = "SalidaJueves"
        Me.SalidaJueves.ReadOnly = True
        Me.SalidaJueves.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalidaJueves.Width = 70
        '
        'ViernesEntrada
        '
        Me.ViernesEntrada.HeaderText = "Entrada"
        Me.ViernesEntrada.Name = "ViernesEntrada"
        Me.ViernesEntrada.ReadOnly = True
        Me.ViernesEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViernesEntrada.Width = 70
        '
        'ViernesSalida
        '
        Me.ViernesSalida.HeaderText = "Salida"
        Me.ViernesSalida.Name = "ViernesSalida"
        Me.ViernesSalida.ReadOnly = True
        Me.ViernesSalida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViernesSalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ViernesSalida.Width = 70
        '
        'EntradaSabado
        '
        Me.EntradaSabado.HeaderText = "Entrada"
        Me.EntradaSabado.Name = "EntradaSabado"
        Me.EntradaSabado.ReadOnly = True
        Me.EntradaSabado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EntradaSabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EntradaSabado.Width = 70
        '
        'SalidaSabado
        '
        Me.SalidaSabado.HeaderText = "Salida"
        Me.SalidaSabado.Name = "SalidaSabado"
        Me.SalidaSabado.ReadOnly = True
        Me.SalidaSabado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SalidaSabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SalidaSabado.Width = 70
        '
        'ParteDia
        '
        Me.ParteDia.HeaderText = "Column2"
        Me.ParteDia.Name = "ParteDia"
        Me.ParteDia.ReadOnly = True
        Me.ParteDia.Visible = False
        '
        'CMenuPermisos
        '
        Me.CMenuPermisos.BackColor = System.Drawing.Color.White
        Me.CMenuPermisos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bt})
        Me.CMenuPermisos.Name = "ContextMenuStrip1"
        Me.CMenuPermisos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuPermisos.Size = New System.Drawing.Size(156, 34)
        Me.CMenuPermisos.Text = "Opciones"
        '
        'bt
        '
        Me.bt.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.bt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bt.Image = Global.Libregco.My.Resources.Resources.Delete_x24
        Me.bt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.bt.Name = "bt"
        Me.bt.Size = New System.Drawing.Size(155, 30)
        Me.bt.Text = "Eliminar horario"
        '
        'frm_mant_tandas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 684)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDescripcionHorario)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.DgvTandasDetalle)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIDTanda)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_tandas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "149"
        Me.Text = "Tandas"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.DgvTandasDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuPermisos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIDTanda As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicMinLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvTandasDetalle As DataGridView
    Friend WithEvents dtpDomingode As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpdomingohasta As DateTimePicker
    Friend WithEvents chkdomingolaborable As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpluneshasta As DateTimePicker
    Friend WithEvents chkluneslaborable As CheckBox
    Friend WithEvents dtplunesde As DateTimePicker
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpmarteshasta As DateTimePicker
    Friend WithEvents chkmarteslaborable As CheckBox
    Friend WithEvents dtpmartesde As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpmiercoleshasta As DateTimePicker
    Friend WithEvents chkmiercoleslaborable As CheckBox
    Friend WithEvents dtpmiercoelsde As DateTimePicker
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dtpjueveshasta As DateTimePicker
    Friend WithEvents chkjueveslaborable As CheckBox
    Friend WithEvents dtpjuevesde As DateTimePicker
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpvierneshasta As DateTimePicker
    Friend WithEvents chkvierneslaborable As CheckBox
    Friend WithEvents dtpviernesde As DateTimePicker
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents dtpsabadohasta As DateTimePicker
    Friend WithEvents chksabadolaborable As CheckBox
    Friend WithEvents dtpsabadode As DateTimePicker
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtDescripcionHorario As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents rdbTarde As RadioButton
    Friend WithEvents rdbDia As RadioButton
    Friend WithEvents rdbNoche As RadioButton
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents idTandaDetalle As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewImageColumn
    Friend WithEvents Descripción As DataGridViewTextBoxColumn
    Friend WithEvents Domingo As DataGridViewCheckBoxColumn
    Friend WithEvents EntradaDomingo As DataGridViewTextBoxColumn
    Friend WithEvents SalidaDomingo As DataGridViewTextBoxColumn
    Friend WithEvents Lunes As DataGridViewCheckBoxColumn
    Friend WithEvents LunesEntrada As DataGridViewTextBoxColumn
    Friend WithEvents LunesSalida As DataGridViewTextBoxColumn
    Friend WithEvents Martes As DataGridViewCheckBoxColumn
    Friend WithEvents MartesEntrada As DataGridViewTextBoxColumn
    Friend WithEvents MartesSalida As DataGridViewTextBoxColumn
    Friend WithEvents Miercoles As DataGridViewCheckBoxColumn
    Friend WithEvents MiercolesEntrada As DataGridViewTextBoxColumn
    Friend WithEvents MiercolesSalida As DataGridViewTextBoxColumn
    Friend WithEvents Jueves As DataGridViewCheckBoxColumn
    Friend WithEvents EntradaJueves As DataGridViewTextBoxColumn
    Friend WithEvents SalidaJueves As DataGridViewTextBoxColumn
    Friend WithEvents Viernes As DataGridViewCheckBoxColumn
    Friend WithEvents ViernesEntrada As DataGridViewTextBoxColumn
    Friend WithEvents ViernesSalida As DataGridViewTextBoxColumn
    Friend WithEvents Sabado As DataGridViewCheckBoxColumn
    Friend WithEvents EntradaSabado As DataGridViewTextBoxColumn
    Friend WithEvents SalidaSabado As DataGridViewTextBoxColumn
    Friend WithEvents ParteDia As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents CMenuPermisos As ContextMenuStrip
    Friend WithEvents bt As ToolStripMenuItem
End Class
