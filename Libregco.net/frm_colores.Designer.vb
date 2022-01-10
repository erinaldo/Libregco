<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_colores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_colores))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
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
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.IcoMenu = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CPEColor = New DevExpress.XtraEditors.ColorPickEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgregarColor = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNombreColor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescrip = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.DgvColoresDetallados = New System.Windows.Forms.DataGridView()
        Me.IDColorDetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDetailColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArgbDetailColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColorDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnBuscarColro = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNuevoColor = New DevExpress.XtraEditors.SimpleButton()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelStatus = New System.Windows.Forms.ToolStripLabel()
        Me.txtIDColor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.CMenuProducts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuitarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.MenuBar.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.IcoMenu.SuspendLayout()
        CType(Me.CPEColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.DgvColoresDetallados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.CMenuProducts.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(558, 24)
        Me.MenuBar.TabIndex = 329
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
        Me.NuevoRegistroToolStripMenuItem.Image = CType(resources.GetObject("NuevoRegistroToolStripMenuItem.Image"), System.Drawing.Image)
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
        Me.BuscarToolStripMenuItem.Image = CType(resources.GetObject("BuscarToolStripMenuItem.Image"), System.Drawing.Image)
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
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
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
        Me.AnularToolStripMenuItem.Image = CType(resources.GetObject("AnularToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(184, 38)
        Me.AnularToolStripMenuItem.Text = "Desactivar"
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
        Me.AyudaLibregcoToolStripMenuItem.Image = CType(resources.GetObject("AyudaLibregcoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(192, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.IcoMenu)
        Me.IconPanel.Location = New System.Drawing.Point(211, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(347, 99)
        Me.IconPanel.TabIndex = 330
        '
        'IcoMenu
        '
        Me.IcoMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IcoMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar})
        Me.IcoMenu.Location = New System.Drawing.Point(0, 0)
        Me.IcoMenu.Name = "IcoMenu"
        Me.IcoMenu.Size = New System.Drawing.Size(347, 99)
        Me.IcoMenu.TabIndex = 192
        Me.IcoMenu.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = CType(resources.GetObject("btnGuardarC.Image"), System.Drawing.Image)
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 95)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CPEColor
        '
        Me.BehaviorManager1.SetBehaviors(Me.CPEColor, New DevExpress.Utils.Behaviors.Behavior() {CType(DevExpress.XtraEditors.Behaviors.MagnifierBehavior.Create(GetType(DevExpress.XtraEditors.Behaviors.MagnifierBehaviorSourceForColorEdit), EditorButtonImageOptions1, 2.0!, True, False, DevExpress.Utils.ColorFormat.RGB), DevExpress.Utils.Behaviors.Behavior)})
        Me.CPEColor.EditValue = System.Drawing.Color.White
        Me.CPEColor.Location = New System.Drawing.Point(163, 28)
        Me.CPEColor.Name = "CPEColor"
        Me.CPEColor.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.CPEColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CPEColor.Properties.ColorDialogType = DevExpress.XtraEditors.Popup.ColorDialogType.Advanced
        Me.CPEColor.Properties.ShowWebSafeColors = True
        Me.CPEColor.Size = New System.Drawing.Size(202, 20)
        Me.CPEColor.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.btnAgregarColor)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.CPEColor)
        Me.GroupControl1.Controls.Add(Me.Panel1)
        Me.GroupControl1.Controls.Add(Me.txtNombreColor)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 23)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupControl1.Size = New System.Drawing.Size(524, 130)
        Me.GroupControl1.TabIndex = 334
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(163, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 418
        Me.Label4.Text = "Nombre del color"
        '
        'btnAgregarColor
        '
        Me.btnAgregarColor.ImageOptions.Image = CType(resources.GetObject("btnAgregarColor.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAgregarColor.Location = New System.Drawing.Point(478, 86)
        Me.btnAgregarColor.Name = "btnAgregarColor"
        Me.btnAgregarColor.Size = New System.Drawing.Size(40, 38)
        Me.btnAgregarColor.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(5, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 417
        Me.Label3.Text = "Muestra"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(7, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 100)
        Me.Panel1.TabIndex = 416
        '
        'txtNombreColor
        '
        Me.txtNombreColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreColor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNombreColor.Location = New System.Drawing.Point(163, 75)
        Me.txtNombreColor.Multiline = True
        Me.txtNombreColor.Name = "txtNombreColor"
        Me.txtNombreColor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNombreColor.Size = New System.Drawing.Size(309, 50)
        Me.txtNombreColor.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(163, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 415
        Me.Label2.Text = "Selección del color"
        '
        'txtDescrip
        '
        Me.txtDescrip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescrip.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDescrip.Location = New System.Drawing.Point(122, 138)
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(424, 20)
        Me.txtDescrip.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 336
        Me.Label1.Text = "Grupo de colores"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.DgvColoresDetallados)
        Me.GroupControl2.Controls.Add(Me.btnBuscarColro)
        Me.GroupControl2.Controls.Add(Me.btnNuevoColor)
        Me.GroupControl2.Controls.Add(Me.GroupControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(12, 167)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(534, 348)
        Me.GroupControl2.TabIndex = 337
        Me.GroupControl2.Text = "Colores"
        '
        'DgvColoresDetallados
        '
        Me.DgvColoresDetallados.AllowDrop = True
        Me.DgvColoresDetallados.AllowUserToAddRows = False
        Me.DgvColoresDetallados.AllowUserToDeleteRows = False
        Me.DgvColoresDetallados.AllowUserToResizeColumns = False
        Me.DgvColoresDetallados.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvColoresDetallados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvColoresDetallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvColoresDetallados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColorDetalle, Me.NameDetailColor, Me.ArgbDetailColor, Me.ColorDetail})
        Me.DgvColoresDetallados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvColoresDetallados.Location = New System.Drawing.Point(2, 159)
        Me.DgvColoresDetallados.MultiSelect = False
        Me.DgvColoresDetallados.Name = "DgvColoresDetallados"
        Me.DgvColoresDetallados.ReadOnly = True
        Me.DgvColoresDetallados.RowTemplate.Height = 46
        Me.DgvColoresDetallados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvColoresDetallados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvColoresDetallados.Size = New System.Drawing.Size(530, 187)
        Me.DgvColoresDetallados.StandardTab = True
        Me.DgvColoresDetallados.TabIndex = 338
        Me.DgvColoresDetallados.TabStop = False
        '
        'IDColorDetalle
        '
        Me.IDColorDetalle.HeaderText = "ID-Sub"
        Me.IDColorDetalle.Name = "IDColorDetalle"
        Me.IDColorDetalle.ReadOnly = True
        Me.IDColorDetalle.Visible = False
        '
        'NameDetailColor
        '
        Me.NameDetailColor.HeaderText = "Descripción"
        Me.NameDetailColor.Name = "NameDetailColor"
        Me.NameDetailColor.ReadOnly = True
        Me.NameDetailColor.Width = 300
        '
        'ArgbDetailColor
        '
        Me.ArgbDetailColor.HeaderText = ""
        Me.ArgbDetailColor.Name = "ArgbDetailColor"
        Me.ArgbDetailColor.ReadOnly = True
        Me.ArgbDetailColor.Visible = False
        '
        'ColorDetail
        '
        Me.ColorDetail.HeaderText = "Muestra"
        Me.ColorDetail.Name = "ColorDetail"
        Me.ColorDetail.ReadOnly = True
        Me.ColorDetail.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColorDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColorDetail.Width = 200
        '
        'btnBuscarColro
        '
        Me.btnBuscarColro.ImageOptions.Image = CType(resources.GetObject("btnBuscarColro.ImageOptions.Image"), System.Drawing.Image)
        Me.btnBuscarColro.Location = New System.Drawing.Point(482, 4)
        Me.btnBuscarColro.Name = "btnBuscarColro"
        Me.btnBuscarColro.Size = New System.Drawing.Size(40, 38)
        Me.btnBuscarColro.TabIndex = 5
        '
        'btnNuevoColor
        '
        Me.btnNuevoColor.ImageOptions.Image = CType(resources.GetObject("btnNuevoColor.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNuevoColor.Location = New System.Drawing.Point(438, 4)
        Me.btnNuevoColor.Name = "btnNuevoColor"
        Me.btnNuevoColor.Size = New System.Drawing.Size(40, 38)
        Me.btnNuevoColor.TabIndex = 4
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.LabelStatus})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 527)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(558, 25)
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
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 22)
        Me.LabelStatus.Text = "Listo"
        '
        'txtIDColor
        '
        Me.txtIDColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDColor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtIDColor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDColor.Location = New System.Drawing.Point(12, 138)
        Me.txtIDColor.Name = "txtIDColor"
        Me.txtIDColor.ReadOnly = True
        Me.txtIDColor.Size = New System.Drawing.Size(104, 20)
        Me.txtIDColor.TabIndex = 415
        Me.txtIDColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "ID"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID-Sub"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = ""
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Muestra"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNulo.Location = New System.Drawing.Point(68, 76)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(48, 17)
        Me.chkNulo.TabIndex = 339
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'CMenuProducts
        '
        Me.CMenuProducts.BackColor = System.Drawing.Color.White
        Me.CMenuProducts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarToolStripMenuItem1, Me.ModificarToolStripMenuItem1})
        Me.CMenuProducts.Name = "ContextMenuStrip1"
        Me.CMenuProducts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CMenuProducts.Size = New System.Drawing.Size(134, 64)
        Me.CMenuProducts.Text = "Opciones"
        '
        'QuitarToolStripMenuItem1
        '
        Me.QuitarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Delete_x24
        Me.QuitarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarToolStripMenuItem1.Name = "QuitarToolStripMenuItem1"
        Me.QuitarToolStripMenuItem1.Size = New System.Drawing.Size(133, 30)
        Me.QuitarToolStripMenuItem1.Text = "Quitar"
        '
        'ModificarToolStripMenuItem1
        '
        Me.ModificarToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.TextEdit_x24
        Me.ModificarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModificarToolStripMenuItem1.Name = "ModificarToolStripMenuItem1"
        Me.ModificarToolStripMenuItem1.Size = New System.Drawing.Size(133, 30)
        Me.ModificarToolStripMenuItem1.Text = "Modificar"
        '
        'frm_colores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 552)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIDColor)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescrip)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.MenuBar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_colores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "271"
        Me.Text = "Centro de colores"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.IcoMenu.ResumeLayout(False)
        Me.IcoMenu.PerformLayout()
        CType(Me.CPEColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.DgvColoresDetallados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.CMenuProducts.ResumeLayout(False)
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents IconPanel As Panel
    Friend WithEvents IcoMenu As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents CPEColor As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtDescrip As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnBuscarColro As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNuevoColor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtNombreColor As TextBox
    Friend WithEvents btnAgregarColor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents LabelStatus As ToolStripLabel
    Friend WithEvents DgvColoresDetallados As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents txtIDColor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents IDColorDetalle As DataGridViewTextBoxColumn
    Friend WithEvents NameDetailColor As DataGridViewTextBoxColumn
    Friend WithEvents ArgbDetailColor As DataGridViewTextBoxColumn
    Friend WithEvents ColorDetail As DataGridViewTextBoxColumn
    Friend WithEvents chkNulo As CheckBox
    Friend WithEvents CMenuProducts As ContextMenuStrip
    Friend WithEvents QuitarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ModificarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BehaviorManager1 As Utils.Behaviors.BehaviorManager
End Class
