<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_combinada_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_combinada_clientes))
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.DgvClientes = New System.Windows.Forms.DataGridView()
        Me.cbxTipoIdentificacion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxProvincia = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxMunicipio = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxGenero = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxNacionalidad = New System.Windows.Forms.ComboBox()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstructuiraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxOcupacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarCons = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStructure = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbxMedida = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxArticulos = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbxVehiculo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.cbxChofer = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxUsuario = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxVendedor = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbxCalificacion = New System.Windows.Forms.ComboBox()
        Me.cbxCobrador = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbxGrupoClientes = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxTipoCredito = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDireccion = New Watermark()
        Me.txtNombre = New Watermark()
        Me.BarraEstado.SuspendLayout()
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarra.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblDate, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 663)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1046, 25)
        Me.BarraEstado.TabIndex = 394
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
        'lblDate
        '
        Me.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 22)
        Me.lblDate.Text = "Date"
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
        'DgvClientes
        '
        Me.DgvClientes.AllowUserToAddRows = False
        Me.DgvClientes.AllowUserToDeleteRows = False
        Me.DgvClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvClientes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvClientes.GridColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DgvClientes.Location = New System.Drawing.Point(294, 26)
        Me.DgvClientes.Name = "DgvClientes"
        Me.DgvClientes.ReadOnly = True
        Me.DgvClientes.RowTemplate.Height = 20
        Me.DgvClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvClientes.Size = New System.Drawing.Size(752, 634)
        Me.DgvClientes.TabIndex = 396
        '
        'cbxTipoIdentificacion
        '
        Me.cbxTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxTipoIdentificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoIdentificacion.FormattingEnabled = True
        Me.cbxTipoIdentificacion.Location = New System.Drawing.Point(95, 62)
        Me.cbxTipoIdentificacion.Name = "cbxTipoIdentificacion"
        Me.cbxTipoIdentificacion.Size = New System.Drawing.Size(187, 23)
        Me.cbxTipoIdentificacion.TabIndex = 398
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Tipo de Ident."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Provincia"
        '
        'cbxProvincia
        '
        Me.cbxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxProvincia.FormattingEnabled = True
        Me.cbxProvincia.Location = New System.Drawing.Point(95, 182)
        Me.cbxProvincia.Name = "cbxProvincia"
        Me.cbxProvincia.Size = New System.Drawing.Size(187, 23)
        Me.cbxProvincia.TabIndex = 400
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(4, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 403
        Me.Label3.Text = "Municipio"
        '
        'cbxMunicipio
        '
        Me.cbxMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMunicipio.FormattingEnabled = True
        Me.cbxMunicipio.Location = New System.Drawing.Point(95, 206)
        Me.cbxMunicipio.Name = "cbxMunicipio"
        Me.cbxMunicipio.Size = New System.Drawing.Size(187, 23)
        Me.cbxMunicipio.TabIndex = 402
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Género"
        '
        'cbxGenero
        '
        Me.cbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGenero.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGenero.FormattingEnabled = True
        Me.cbxGenero.Location = New System.Drawing.Point(95, 86)
        Me.cbxGenero.Name = "cbxGenero"
        Me.cbxGenero.Size = New System.Drawing.Size(187, 23)
        Me.cbxGenero.TabIndex = 404
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(4, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 407
        Me.Label5.Text = "Nacionalidad"
        '
        'cbxNacionalidad
        '
        Me.cbxNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxNacionalidad.FormattingEnabled = True
        Me.cbxNacionalidad.Location = New System.Drawing.Point(95, 110)
        Me.cbxNacionalidad.Name = "cbxNacionalidad"
        Me.cbxNacionalidad.Size = New System.Drawing.Size(187, 23)
        Me.cbxNacionalidad.TabIndex = 406
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(1046, 24)
        Me.MenuBarra.TabIndex = 397
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.EstructuiraToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.NuevoRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(187, 54)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(187, 54)
        Me.BuscarToolStripMenuItem.Text = "Buscar"
        '
        'EstructuiraToolStripMenuItem
        '
        Me.EstructuiraToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.EstructuiraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EstructuiraToolStripMenuItem.Name = "EstructuiraToolStripMenuItem"
        Me.EstructuiraToolStripMenuItem.Size = New System.Drawing.Size(187, 54)
        Me.EstructuiraToolStripMenuItem.Text = "Estructura"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x48
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(187, 54)
        Me.SalirToolStripMenuItem.Text = "Salir"
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
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(4, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 409
        Me.Label6.Text = "Ocupación"
        '
        'cbxOcupacion
        '
        Me.cbxOcupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOcupacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxOcupacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxOcupacion.FormattingEnabled = True
        Me.cbxOcupacion.Location = New System.Drawing.Point(95, 158)
        Me.cbxOcupacion.Name = "cbxOcupacion"
        Me.cbxOcupacion.Size = New System.Drawing.Size(187, 23)
        Me.cbxOcupacion.TabIndex = 408
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(4, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 411
        Me.Label7.Text = "Estado Civil"
        '
        'cbxEstadoCivil
        '
        Me.cbxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxEstadoCivil.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstadoCivil.FormattingEnabled = True
        Me.cbxEstadoCivil.Location = New System.Drawing.Point(95, 134)
        Me.cbxEstadoCivil.Name = "cbxEstadoCivil"
        Me.cbxEstadoCivil.Size = New System.Drawing.Size(187, 23)
        Me.cbxEstadoCivil.TabIndex = 410
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel1.Controls.Add(Me.IconPanel)
        Me.Panel1.Controls.Add(Me.cbxMedida)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.cbxArticulos)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.cbxVehiculo)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.cbxAlmacen)
        Me.Panel1.Controls.Add(Me.cbxChofer)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.cbxCondicion)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cbxUsuario)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.cbxVendedor)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cbxTipoComprobante)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cbxCalificacion)
        Me.Panel1.Controls.Add(Me.cbxCobrador)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cbxGrupoClientes)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cbxTipoCredito)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cbxGenero)
        Me.Panel1.Controls.Add(Me.txtDireccion)
        Me.Panel1.Controls.Add(Me.cbxMunicipio)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbxEstadoCivil)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cbxProvincia)
        Me.Panel1.Controls.Add(Me.cbxOcupacion)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtNombre)
        Me.Panel1.Controls.Add(Me.cbxTipoIdentificacion)
        Me.Panel1.Controls.Add(Me.cbxNacionalidad)
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 634)
        Me.Panel1.TabIndex = 413
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(5, 554)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(279, 71)
        Me.IconPanel.TabIndex = 414
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnBuscarCons, Me.btnStructure, Me.btnCerrar})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(279, 71)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.White
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 67)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.ForeColor = System.Drawing.Color.White
        Me.btnBuscarCons.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.Size = New System.Drawing.Size(60, 67)
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStructure
        '
        Me.btnStructure.ForeColor = System.Drawing.Color.White
        Me.btnStructure.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.btnStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnStructure.Name = "btnStructure"
        Me.btnStructure.Size = New System.Drawing.Size(72, 67)
        Me.btnStructure.Text = "Estructura"
        Me.btnStructure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x48
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(60, 67)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cbxMedida
        '
        Me.cbxMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxMedida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMedida.FormattingEnabled = True
        Me.cbxMedida.Location = New System.Drawing.Point(95, 518)
        Me.cbxMedida.Name = "cbxMedida"
        Me.cbxMedida.Size = New System.Drawing.Size(187, 23)
        Me.cbxMedida.TabIndex = 437
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(4, 426)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 15)
        Me.Label16.TabIndex = 438
        Me.Label16.Text = "Almacén"
        '
        'cbxArticulos
        '
        Me.cbxArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxArticulos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxArticulos.FormattingEnabled = True
        Me.cbxArticulos.Location = New System.Drawing.Point(95, 494)
        Me.cbxArticulos.Name = "cbxArticulos"
        Me.cbxArticulos.Size = New System.Drawing.Size(187, 23)
        Me.cbxArticulos.TabIndex = 435
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(4, 521)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 15)
        Me.Label17.TabIndex = 436
        Me.Label17.Text = "Medida"
        '
        'cbxVehiculo
        '
        Me.cbxVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxVehiculo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxVehiculo.FormattingEnabled = True
        Me.cbxVehiculo.Location = New System.Drawing.Point(95, 470)
        Me.cbxVehiculo.Name = "cbxVehiculo"
        Me.cbxVehiculo.Size = New System.Drawing.Size(187, 23)
        Me.cbxVehiculo.TabIndex = 433
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(4, 497)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 15)
        Me.Label18.TabIndex = 434
        Me.Label18.Text = "Artículos"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(4, 449)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 15)
        Me.Label19.TabIndex = 432
        Me.Label19.Text = "Chofer"
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(95, 422)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(187, 23)
        Me.cbxAlmacen.TabIndex = 431
        '
        'cbxChofer
        '
        Me.cbxChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxChofer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxChofer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxChofer.FormattingEnabled = True
        Me.cbxChofer.Location = New System.Drawing.Point(95, 446)
        Me.cbxChofer.Name = "cbxChofer"
        Me.cbxChofer.Size = New System.Drawing.Size(187, 23)
        Me.cbxChofer.TabIndex = 429
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(4, 473)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 15)
        Me.Label20.TabIndex = 430
        Me.Label20.Text = "Vehículo"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(95, 398)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(187, 23)
        Me.cbxCondicion.TabIndex = 427
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(4, 402)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 428
        Me.Label15.Text = "Condición"
        '
        'cbxUsuario
        '
        Me.cbxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxUsuario.FormattingEnabled = True
        Me.cbxUsuario.Location = New System.Drawing.Point(95, 374)
        Me.cbxUsuario.Name = "cbxUsuario"
        Me.cbxUsuario.Size = New System.Drawing.Size(187, 23)
        Me.cbxUsuario.TabIndex = 425
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(4, 378)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 15)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Usuario"
        '
        'cbxVendedor
        '
        Me.cbxVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxVendedor.FormattingEnabled = True
        Me.cbxVendedor.Location = New System.Drawing.Point(95, 350)
        Me.cbxVendedor.Name = "cbxVendedor"
        Me.cbxVendedor.Size = New System.Drawing.Size(187, 23)
        Me.cbxVendedor.TabIndex = 423
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(4, 354)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 15)
        Me.Label13.TabIndex = 424
        Me.Label13.Text = "Vendedor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(4, 282)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 15)
        Me.Label12.TabIndex = 422
        Me.Label12.Text = "Tipo NCF"
        '
        'cbxTipoComprobante
        '
        Me.cbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoComprobante.FormattingEnabled = True
        Me.cbxTipoComprobante.Location = New System.Drawing.Point(95, 278)
        Me.cbxTipoComprobante.Name = "cbxTipoComprobante"
        Me.cbxTipoComprobante.Size = New System.Drawing.Size(187, 23)
        Me.cbxTipoComprobante.TabIndex = 421
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(4, 307)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 15)
        Me.Label11.TabIndex = 420
        Me.Label11.Text = "Calificación"
        '
        'cbxCalificacion
        '
        Me.cbxCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCalificacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCalificacion.FormattingEnabled = True
        Me.cbxCalificacion.Location = New System.Drawing.Point(95, 302)
        Me.cbxCalificacion.Name = "cbxCalificacion"
        Me.cbxCalificacion.Size = New System.Drawing.Size(187, 23)
        Me.cbxCalificacion.TabIndex = 419
        '
        'cbxCobrador
        '
        Me.cbxCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCobrador.FormattingEnabled = True
        Me.cbxCobrador.Location = New System.Drawing.Point(95, 326)
        Me.cbxCobrador.Name = "cbxCobrador"
        Me.cbxCobrador.Size = New System.Drawing.Size(187, 23)
        Me.cbxCobrador.TabIndex = 417
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(4, 330)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 15)
        Me.Label10.TabIndex = 418
        Me.Label10.Text = "Cobrador"
        '
        'cbxGrupoClientes
        '
        Me.cbxGrupoClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGrupoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxGrupoClientes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGrupoClientes.FormattingEnabled = True
        Me.cbxGrupoClientes.Location = New System.Drawing.Point(95, 254)
        Me.cbxGrupoClientes.Name = "cbxGrupoClientes"
        Me.cbxGrupoClientes.Size = New System.Drawing.Size(187, 23)
        Me.cbxGrupoClientes.TabIndex = 415
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 257)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 15)
        Me.Label9.TabIndex = 416
        Me.Label9.Text = "Grupo "
        '
        'cbxTipoCredito
        '
        Me.cbxTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxTipoCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxTipoCredito.FormattingEnabled = True
        Me.cbxTipoCredito.Location = New System.Drawing.Point(95, 230)
        Me.cbxTipoCredito.Name = "cbxTipoCredito"
        Me.cbxTipoCredito.Size = New System.Drawing.Size(187, 23)
        Me.cbxTipoCredito.TabIndex = 413
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 15)
        Me.Label8.TabIndex = 414
        Me.Label8.Text = "Tipo de Crédito"
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(8, 26)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(274, 23)
        Me.txtDireccion.TabIndex = 412
        Me.txtDireccion.WatermarkColor = System.Drawing.Color.Gray
        Me.txtDireccion.WatermarkText = "Dirección del Cliente"
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.Location = New System.Drawing.Point(8, 3)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(274, 23)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.WatermarkColor = System.Drawing.Color.Gray
        Me.txtNombre.WatermarkText = "[F1] Nombre del Cliente o Apodos"
        '
        'frm_consulta_combinada_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 688)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.DgvClientes)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_combinada_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "86"
        Me.Text = "Consulta de específica de clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.DgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DgvClientes As System.Windows.Forms.DataGridView
    Friend WithEvents txtNombre As Watermark
    Friend WithEvents cbxTipoIdentificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxNacionalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxGenero As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuBarra As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxOcupacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbxEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents txtDireccion As Watermark
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbxUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbxCalificacion As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCobrador As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbxGrupoClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoCredito As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbxMedida As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxArticulos As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbxVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents cbxChofer As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarCons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstructuiraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
End Class
