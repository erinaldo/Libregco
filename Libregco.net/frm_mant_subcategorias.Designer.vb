<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_subcategorias
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_subcategorias))
        Me.btn_BuscarCategoria = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIDCategoria = New System.Windows.Forms.TextBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSubCategoria = New System.Windows.Forms.TextBox()
        Me.txtIDSubCategoria = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.DgvSubCategoria = New System.Windows.Forms.DataGridView()
        Me.IDCategoriaD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoriaD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDSubCategoriaD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubCategoriaD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelHibrido = New System.Windows.Forms.Panel()
        Me.btnGuardarMultiple = New System.Windows.Forms.Button()
        Me.btnMultipleRegistro = New System.Windows.Forms.Button()
        Me.btnEliminarFoto = New System.Windows.Forms.Button()
        Me.btnCargarFoto = New System.Windows.Forms.Button()
        Me.btnAbrirFoto = New System.Windows.Forms.Button()
        Me.PicImagen = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.DgvSubCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelHibrido.SuspendLayout()
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_BuscarCategoria
        '
        Me.btn_BuscarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_BuscarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_BuscarCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_BuscarCategoria.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btn_BuscarCategoria.Location = New System.Drawing.Point(107, 124)
        Me.btn_BuscarCategoria.Name = "btn_BuscarCategoria"
        Me.btn_BuscarCategoria.Size = New System.Drawing.Size(23, 23)
        Me.btn_BuscarCategoria.TabIndex = 0
        Me.btn_BuscarCategoria.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 171
        Me.Label4.Text = "Código"
        '
        'txtCategoria
        '
        Me.txtCategoria.Enabled = False
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategoria.Location = New System.Drawing.Point(129, 124)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(311, 23)
        Me.txtCategoria.TabIndex = 154
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(126, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "Categoría"
        '
        'txtIDCategoria
        '
        Me.txtIDCategoria.Enabled = False
        Me.txtIDCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCategoria.Location = New System.Drawing.Point(8, 124)
        Me.txtIDCategoria.Name = "txtIDCategoria"
        Me.txtIDCategoria.ReadOnly = True
        Me.txtIDCategoria.Size = New System.Drawing.Size(100, 23)
        Me.txtIDCategoria.TabIndex = 169
        Me.txtIDCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Location = New System.Drawing.Point(404, 106)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 168
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(453, 24)
        Me.MenuStrip1.TabIndex = 164
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(220, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(220, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(220, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Categoría"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(217, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(220, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistorialToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'HistorialToolStripMenuItem
        '
        Me.HistorialToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.HistorialToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.HistorialToolStripMenuItem.Name = "HistorialToolStripMenuItem"
        Me.HistorialToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
        Me.HistorialToolStripMenuItem.Text = "Buscar Sub-Categorías"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(209, 38)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(112, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 175
        Me.Label2.Text = "Sub - Categoría"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 174
        Me.Label1.Text = "Código"
        '
        'txtSubCategoria
        '
        Me.txtSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubCategoria.Location = New System.Drawing.Point(115, 174)
        Me.txtSubCategoria.Name = "txtSubCategoria"
        Me.txtSubCategoria.Size = New System.Drawing.Size(325, 23)
        Me.txtSubCategoria.TabIndex = 1
        '
        'txtIDSubCategoria
        '
        Me.txtIDSubCategoria.Enabled = False
        Me.txtIDSubCategoria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSubCategoria.Location = New System.Drawing.Point(8, 174)
        Me.txtIDSubCategoria.Name = "txtIDSubCategoria"
        Me.txtIDSubCategoria.ReadOnly = True
        Me.txtIDSubCategoria.Size = New System.Drawing.Size(100, 23)
        Me.txtIDSubCategoria.TabIndex = 173
        Me.txtIDSubCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(196, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(256, 79)
        Me.IconPanel.TabIndex = 235
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(256, 79)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 75)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x48
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(61, 75)
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
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 75)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x48
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 75)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(8, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(193, 73)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 236
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 468)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(453, 25)
        Me.BarraEstado.TabIndex = 414
        Me.BarraEstado.Text = "ToolStrip1"
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
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 22)
        Me.LabelStatus.Text = "Listo"
        '
        'DgvSubCategoria
        '
        Me.DgvSubCategoria.AllowUserToAddRows = False
        Me.DgvSubCategoria.AllowUserToDeleteRows = False
        Me.DgvSubCategoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvSubCategoria.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DgvSubCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvSubCategoria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvSubCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSubCategoria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCategoriaD, Me.CategoriaD, Me.IDSubCategoriaD, Me.SubCategoriaD})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvSubCategoria.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvSubCategoria.Location = New System.Drawing.Point(3, 31)
        Me.DgvSubCategoria.MultiSelect = False
        Me.DgvSubCategoria.Name = "DgvSubCategoria"
        Me.DgvSubCategoria.ReadOnly = True
        Me.DgvSubCategoria.RowHeadersWidth = 20
        Me.DgvSubCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSubCategoria.Size = New System.Drawing.Size(450, 0)
        Me.DgvSubCategoria.TabIndex = 415
        '
        'IDCategoriaD
        '
        Me.IDCategoriaD.HeaderText = "IDCategoria"
        Me.IDCategoriaD.Name = "IDCategoriaD"
        Me.IDCategoriaD.ReadOnly = True
        Me.IDCategoriaD.Visible = False
        '
        'CategoriaD
        '
        Me.CategoriaD.HeaderText = "Categoria"
        Me.CategoriaD.Name = "CategoriaD"
        Me.CategoriaD.ReadOnly = True
        Me.CategoriaD.Width = 170
        '
        'IDSubCategoriaD
        '
        Me.IDSubCategoriaD.HeaderText = "IDSubCategoria"
        Me.IDSubCategoriaD.Name = "IDSubCategoriaD"
        Me.IDSubCategoriaD.ReadOnly = True
        Me.IDSubCategoriaD.Visible = False
        '
        'SubCategoriaD
        '
        Me.SubCategoriaD.HeaderText = "SubCategoría"
        Me.SubCategoriaD.Name = "SubCategoriaD"
        Me.SubCategoriaD.ReadOnly = True
        Me.SubCategoriaD.Width = 260
        '
        'PanelHibrido
        '
        Me.PanelHibrido.Controls.Add(Me.btnGuardarMultiple)
        Me.PanelHibrido.Controls.Add(Me.btnMultipleRegistro)
        Me.PanelHibrido.Controls.Add(Me.DgvSubCategoria)
        Me.PanelHibrido.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelHibrido.Location = New System.Drawing.Point(0, 437)
        Me.PanelHibrido.Name = "PanelHibrido"
        Me.PanelHibrido.Size = New System.Drawing.Size(453, 31)
        Me.PanelHibrido.TabIndex = 2
        '
        'btnGuardarMultiple
        '
        Me.btnGuardarMultiple.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnGuardarMultiple.Location = New System.Drawing.Point(280, 280)
        Me.btnGuardarMultiple.Name = "btnGuardarMultiple"
        Me.btnGuardarMultiple.Size = New System.Drawing.Size(170, 23)
        Me.btnGuardarMultiple.TabIndex = 417
        Me.btnGuardarMultiple.Text = "Guardar subcategorías"
        Me.btnGuardarMultiple.UseVisualStyleBackColor = True
        '
        'btnMultipleRegistro
        '
        Me.btnMultipleRegistro.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnMultipleRegistro.Location = New System.Drawing.Point(3, 3)
        Me.btnMultipleRegistro.Name = "btnMultipleRegistro"
        Me.btnMultipleRegistro.Size = New System.Drawing.Size(447, 23)
        Me.btnMultipleRegistro.TabIndex = 3
        Me.btnMultipleRegistro.Text = "Modo de múltiples registros"
        Me.btnMultipleRegistro.UseVisualStyleBackColor = True
        '
        'btnEliminarFoto
        '
        Me.btnEliminarFoto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEliminarFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnEliminarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarFoto.Location = New System.Drawing.Point(403, 397)
        Me.btnEliminarFoto.Name = "btnEliminarFoto"
        Me.btnEliminarFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarFoto.TabIndex = 422
        Me.btnEliminarFoto.UseVisualStyleBackColor = True
        '
        'btnCargarFoto
        '
        Me.btnCargarFoto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCargarFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnCargarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarFoto.Location = New System.Drawing.Point(341, 397)
        Me.btnCargarFoto.Name = "btnCargarFoto"
        Me.btnCargarFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarFoto.TabIndex = 420
        Me.btnCargarFoto.UseVisualStyleBackColor = True
        '
        'btnAbrirFoto
        '
        Me.btnAbrirFoto.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAbrirFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrirFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirFoto.Location = New System.Drawing.Point(372, 397)
        Me.btnAbrirFoto.Name = "btnAbrirFoto"
        Me.btnAbrirFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirFoto.TabIndex = 421
        Me.btnAbrirFoto.UseVisualStyleBackColor = True
        '
        'PicImagen
        '
        Me.PicImagen.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PicImagen.BackColor = System.Drawing.Color.White
        Me.PicImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicImagen.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicImagen.Location = New System.Drawing.Point(7, 203)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Size = New System.Drawing.Size(433, 228)
        Me.PicImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImagen.TabIndex = 419
        Me.PicImagen.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDCategoria"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Categoria"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 170
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "IDSubCategoria"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "SubCategoría"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 260
        '
        'frm_mant_subcategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 493)
        Me.Controls.Add(Me.btnEliminarFoto)
        Me.Controls.Add(Me.btnCargarFoto)
        Me.Controls.Add(Me.btnAbrirFoto)
        Me.Controls.Add(Me.PicImagen)
        Me.Controls.Add(Me.PanelHibrido)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSubCategoria)
        Me.Controls.Add(Me.txtIDSubCategoria)
        Me.Controls.Add(Me.btn_BuscarCategoria)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIDCategoria)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_subcategorias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "6"
        Me.Text = "Mantenimiento de subcategorías"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.DgvSubCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelHibrido.ResumeLayout(False)
        CType(Me.PicImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_BuscarCategoria As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIDCategoria As System.Windows.Forms.TextBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistorialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSubCategoria As System.Windows.Forms.TextBox
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DgvSubCategoria As DataGridView
    Friend WithEvents PanelHibrido As Panel
    Friend WithEvents btnGuardarMultiple As Button
    Friend WithEvents btnMultipleRegistro As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents IDCategoriaD As DataGridViewTextBoxColumn
    Friend WithEvents CategoriaD As DataGridViewTextBoxColumn
    Friend WithEvents IDSubCategoriaD As DataGridViewTextBoxColumn
    Friend WithEvents SubCategoriaD As DataGridViewTextBoxColumn
    Private WithEvents btnEliminarFoto As Button
    Private WithEvents btnCargarFoto As Button
    Private WithEvents btnAbrirFoto As Button
    Friend WithEvents PicImagen As PictureBox
End Class
