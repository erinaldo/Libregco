<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devolucion_fact
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devolucion_fact))
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMotivoDevolucion = New System.Windows.Forms.TextBox()
        Me.ChkDevolverItbis = New System.Windows.Forms.CheckBox()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtIDDevolucion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarDevoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.btnBuscarFactura = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.txtIDMotivoDevolucion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkGenerarNCF = New System.Windows.Forms.CheckBox()
        Me.btnBuscarMotivo = New System.Windows.Forms.Button()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMontoDevolucion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rdbDevEfectivo = New System.Windows.Forms.RadioButton()
        Me.rdbVoucher = New System.Windows.Forms.RadioButton()
        Me.rdbDevCredito = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxUserInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFactura
        '
        Me.txtFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtFactura.Location = New System.Drawing.Point(70, 119)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(161, 27)
        Me.txtFactura.TabIndex = 0
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(5, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Motivo"
        '
        'txtMotivoDevolucion
        '
        Me.txtMotivoDevolucion.Enabled = False
        Me.txtMotivoDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMotivoDevolucion.Location = New System.Drawing.Point(178, 24)
        Me.txtMotivoDevolucion.Name = "txtMotivoDevolucion"
        Me.txtMotivoDevolucion.ReadOnly = True
        Me.txtMotivoDevolucion.Size = New System.Drawing.Size(418, 23)
        Me.txtMotivoDevolucion.TabIndex = 3
        '
        'ChkDevolverItbis
        '
        Me.ChkDevolverItbis.AutoCheck = False
        Me.ChkDevolverItbis.AutoSize = True
        Me.ChkDevolverItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkDevolverItbis.Location = New System.Drawing.Point(489, 58)
        Me.ChkDevolverItbis.Name = "ChkDevolverItbis"
        Me.ChkDevolverItbis.Size = New System.Drawing.Size(100, 19)
        Me.ChkDevolverItbis.TabIndex = 5
        Me.ChkDevolverItbis.Text = "Devolver ITBIS"
        Me.ChkDevolverItbis.UseVisualStyleBackColor = True
        '
        'txtDias
        '
        Me.txtDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDias.Enabled = False
        Me.txtDias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDias.Location = New System.Drawing.Point(174, 181)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ReadOnly = True
        Me.txtDias.Size = New System.Drawing.Size(60, 23)
        Me.txtDias.TabIndex = 158
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.AllowUserToResizeColumns = False
        Me.DgvArticulos.AllowUserToResizeRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulos.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvArticulos.Location = New System.Drawing.Point(5, 210)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.RowHeadersVisible = False
        Me.DgvArticulos.RowHeadersWidth = 5
        Me.DgvArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(1071, 280)
        Me.DgvArticulos.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(862, 534)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 15)
        Me.Label4.TabIndex = 162
        Me.Label4.Text = "Itbis"
        '
        'txtItbis
        '
        Me.txtItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItbis.Enabled = False
        Me.txtItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtItbis.Location = New System.Drawing.Point(896, 531)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.ReadOnly = True
        Me.txtItbis.Size = New System.Drawing.Size(180, 23)
        Me.txtItbis.TabIndex = 161
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotal.Location = New System.Drawing.Point(896, 560)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(180, 23)
        Me.txtTotal.TabIndex = 163
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(857, 564)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 164
        Me.Label5.Text = "Total"
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.txtIDDevolucion)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label2)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(752, 130)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(324, 74)
        Me.GbxUserInfo.TabIndex = 277
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(171, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(145, 23)
        Me.txtSecondID.TabIndex = 254
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(56, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 253
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDDevolucion
        '
        Me.txtIDDevolucion.Enabled = False
        Me.txtIDDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDevolucion.Location = New System.Drawing.Point(56, 17)
        Me.txtIDDevolucion.Name = "txtIDDevolucion"
        Me.txtIDDevolucion.ReadOnly = True
        Me.txtIDDevolucion.Size = New System.Drawing.Size(109, 23)
        Me.txtIDDevolucion.TabIndex = 248
        Me.txtIDDevolucion.TabStop = False
        Me.txtIDDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Código"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(210, 45)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(106, 23)
        Me.txtHora.TabIndex = 251
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(171, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Hora"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(8, 154)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(70, 151)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(69, 23)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(145, 151)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(597, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1083, 24)
        Me.MenuStrip1.TabIndex = 289
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar factura"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(206, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarDevoluciónToolStripMenuItem, Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'BuscarDevoluciónToolStripMenuItem
        '
        Me.BuscarDevoluciónToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarDevoluciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarDevoluciónToolStripMenuItem.Name = "BuscarDevoluciónToolStripMenuItem"
        Me.BuscarDevoluciónToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.BuscarDevoluciónToolStripMenuItem.Size = New System.Drawing.Size(228, 38)
        Me.BuscarDevoluciónToolStripMenuItem.Text = "Buscar devolución"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(228, 38)
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
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(90, 99)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 291
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkNulo.Location = New System.Drawing.Point(699, 601)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(52, 19)
        Me.chkNulo.TabIndex = 292
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'btnBuscarFactura
        '
        Me.btnBuscarFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscarFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarFactura.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarFactura.Location = New System.Drawing.Point(229, 119)
        Me.btnBuscarFactura.Name = "btnBuscarFactura"
        Me.btnBuscarFactura.Size = New System.Drawing.Size(27, 27)
        Me.btnBuscarFactura.TabIndex = 1
        Me.btnBuscarFactura.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(237, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "día(s)"
        '
        'txtComprobante
        '
        Me.txtComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComprobante.Enabled = False
        Me.txtComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtComprobante.Location = New System.Drawing.Point(315, 181)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(168, 23)
        Me.txtComprobante.TabIndex = 296
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.Location = New System.Drawing.Point(279, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 15)
        Me.Label11.TabIndex = 297
        Me.Label11.Text = "NCF"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label14.Location = New System.Drawing.Point(8, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 15)
        Me.Label14.TabIndex = 304
        Me.Label14.Text = "Fecha"
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(479, 130)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(263, 16)
        Me.txtVendedor.TabIndex = 299
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFactura.Location = New System.Drawing.Point(70, 181)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(101, 23)
        Me.txtFechaFactura.TabIndex = 303
        Me.txtFechaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCondicion
        '
        Me.txtCondicion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(557, 181)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(185, 23)
        Me.txtCondicion.TabIndex = 301
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label13.Location = New System.Drawing.Point(489, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 302
        Me.Label13.Text = "Condición"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(837, 505)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 309
        Me.Label12.Text = "SubTotal"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubtotal.Enabled = False
        Me.txtSubtotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubtotal.Location = New System.Drawing.Point(896, 502)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(180, 23)
        Me.txtSubtotal.TabIndex = 308
        Me.txtSubtotal.TabStop = False
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDMotivoDevolucion
        '
        Me.txtIDMotivoDevolucion.Enabled = False
        Me.txtIDMotivoDevolucion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMotivoDevolucion.Location = New System.Drawing.Point(65, 24)
        Me.txtIDMotivoDevolucion.Name = "txtIDMotivoDevolucion"
        Me.txtIDMotivoDevolucion.ReadOnly = True
        Me.txtIDMotivoDevolucion.Size = New System.Drawing.Size(94, 23)
        Me.txtIDMotivoDevolucion.TabIndex = 310
        Me.txtIDMotivoDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cbxAlmacen)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ChkGenerarNCF)
        Me.GroupBox2.Controls.Add(Me.ChkDevolverItbis)
        Me.GroupBox2.Controls.Add(Me.btnBuscarMotivo)
        Me.GroupBox2.Controls.Add(Me.txtIDMotivoDevolucion)
        Me.GroupBox2.Controls.Add(Me.txtMotivoDevolucion)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 533)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(602, 84)
        Me.GroupBox2.TabIndex = 314
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información de la devolución"
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.Location = New System.Drawing.Point(65, 53)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(223, 23)
        Me.cbxAlmacen.TabIndex = 317
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(5, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 15)
        Me.Label8.TabIndex = 318
        Me.Label8.Text = "Almacén"
        '
        'ChkGenerarNCF
        '
        Me.ChkGenerarNCF.AutoSize = True
        Me.ChkGenerarNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkGenerarNCF.ForeColor = System.Drawing.Color.Black
        Me.ChkGenerarNCF.Location = New System.Drawing.Point(390, 58)
        Me.ChkGenerarNCF.Name = "ChkGenerarNCF"
        Me.ChkGenerarNCF.Size = New System.Drawing.Size(93, 19)
        Me.ChkGenerarNCF.TabIndex = 328
        Me.ChkGenerarNCF.Text = "Generar NCF"
        Me.ChkGenerarNCF.UseVisualStyleBackColor = True
        '
        'btnBuscarMotivo
        '
        Me.btnBuscarMotivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarMotivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarMotivo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarMotivo.Location = New System.Drawing.Point(157, 24)
        Me.btnBuscarMotivo.Name = "btnBuscarMotivo"
        Me.btnBuscarMotivo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarMotivo.TabIndex = 2
        Me.btnBuscarMotivo.UseVisualStyleBackColor = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(647, 23)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnGuardaryLimpiar
        '
        Me.btnGuardaryLimpiar.Image = CType(resources.GetObject("btnGuardaryLimpiar.Image"), System.Drawing.Image)
        Me.btnGuardaryLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardaryLimpiar.Name = "btnGuardaryLimpiar"
        Me.btnGuardaryLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnGuardaryLimpiar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardaryLimpiar.Text = "Guardar y Limpiar"
        Me.btnGuardaryLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 95)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 630)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1083, 25)
        Me.BarraEstado.TabIndex = 413
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 332
        Me.PicBoxLogo.TabStop = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(757, 592)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 20)
        Me.Label15.TabIndex = 415
        Me.Label15.Text = "Monto a devolver"
        '
        'txtMontoDevolucion
        '
        Me.txtMontoDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoDevolucion.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoDevolucion.Enabled = False
        Me.txtMontoDevolucion.Font = New System.Drawing.Font("Segoe UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDevolucion.Location = New System.Drawing.Point(896, 589)
        Me.txtMontoDevolucion.Name = "txtMontoDevolucion"
        Me.txtMontoDevolucion.ReadOnly = True
        Me.txtMontoDevolucion.Size = New System.Drawing.Size(180, 27)
        Me.txtMontoDevolucion.TabIndex = 414
        Me.txtMontoDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(8, 126)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 15)
        Me.Label16.TabIndex = 416
        Me.Label16.Text = "Factura #"
        '
        'rdbDevEfectivo
        '
        Me.rdbDevEfectivo.AutoSize = True
        Me.rdbDevEfectivo.Checked = True
        Me.rdbDevEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbDevEfectivo.Location = New System.Drawing.Point(16, 15)
        Me.rdbDevEfectivo.Name = "rdbDevEfectivo"
        Me.rdbDevEfectivo.Size = New System.Drawing.Size(146, 19)
        Me.rdbDevEfectivo.TabIndex = 315
        Me.rdbDevEfectivo.TabStop = True
        Me.rdbDevEfectivo.Text = "Devolución de efectivo"
        Me.rdbDevEfectivo.UseVisualStyleBackColor = True
        '
        'rdbVoucher
        '
        Me.rdbVoucher.AutoSize = True
        Me.rdbVoucher.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbVoucher.Location = New System.Drawing.Point(168, 15)
        Me.rdbVoucher.Name = "rdbVoucher"
        Me.rdbVoucher.Size = New System.Drawing.Size(129, 19)
        Me.rdbVoucher.TabIndex = 314
        Me.rdbVoucher.Text = "Voucher por crédito"
        Me.rdbVoucher.UseVisualStyleBackColor = True
        '
        'rdbDevCredito
        '
        Me.rdbDevCredito.AutoSize = True
        Me.rdbDevCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbDevCredito.Location = New System.Drawing.Point(305, 15)
        Me.rdbDevCredito.Name = "rdbDevCredito"
        Me.rdbDevCredito.Size = New System.Drawing.Size(190, 19)
        Me.rdbDevCredito.TabIndex = 316
        Me.rdbDevCredito.Text = "Devolución de factura a crédito"
        Me.rdbDevCredito.UseVisualStyleBackColor = True
        Me.rdbDevCredito.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.rdbDevCredito)
        Me.GroupBox5.Controls.Add(Me.rdbVoucher)
        Me.GroupBox5.Controls.Add(Me.rdbDevEfectivo)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 492)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(596, 39)
        Me.GroupBox5.TabIndex = 330
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Forma de devolución"
        '
        'frm_devolucion_fact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1083, 655)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnBuscarFactura)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMontoDevolucion)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.nombre_label)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.txtComprobante)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtFechaFactura)
        Me.Controls.Add(Me.txtCondicion)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.DgvArticulos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1099, 694)
        Me.Name = "frm_devolucion_fact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "16"
        Me.Text = "Devoluciones de ventas"
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkDevolverItbis As System.Windows.Forms.CheckBox
    Private WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarFactura As System.Windows.Forms.Button
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Private WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents txtCondicion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMotivoDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDMotivoDevolucion As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMotivo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents ChkGenerarNCF As CheckBox
    Friend WithEvents txtItbis As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarDevoluciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label15 As Label
    Friend WithEvents txtMontoDevolucion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents rdbDevEfectivo As RadioButton
    Friend WithEvents rdbVoucher As RadioButton
    Friend WithEvents rdbDevCredito As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
End Class
