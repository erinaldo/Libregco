<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_otros_ingresos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_otros_ingresos))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDIngreso = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCreditoDisponible = New System.Windows.Forms.TextBox()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.label20 = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.MenuBar.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(1010, 24)
        Me.MenuBar.TabIndex = 182
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
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
        Me.BuscarToolStripMenuItem.Text = "Buscar Cliente"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
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
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(192, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkNulo.Location = New System.Drawing.Point(296, 27)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(52, 19)
        Me.ChkNulo.TabIndex = 192
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDIngreso)
        Me.GbxUserInfo.Controls.Add(Me.label8)
        Me.GbxUserInfo.Controls.Add(Me.Label1)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(668, 124)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 204
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(174, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(157, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDIngreso
        '
        Me.txtIDIngreso.Enabled = False
        Me.txtIDIngreso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDIngreso.Location = New System.Drawing.Point(59, 17)
        Me.txtIDIngreso.Name = "txtIDIngreso"
        Me.txtIDIngreso.ReadOnly = True
        Me.txtIDIngreso.Size = New System.Drawing.Size(109, 23)
        Me.txtIDIngreso.TabIndex = 139
        Me.txtIDIngreso.TabStop = False
        Me.txtIDIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label8.Location = New System.Drawing.Point(6, 20)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(46, 15)
        Me.label8.TabIndex = 140
        Me.label8.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(174, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(59, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Monto a Aplicar"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Info
        Me.txtMonto.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtMonto.Location = New System.Drawing.Point(110, 206)
        Me.txtMonto.MaxLength = 150
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(270, 32)
        Me.txtMonto.TabIndex = 2
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(387, 214)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 211
        Me.Label5.Text = "Referencia:"
        '
        'txtReferencia
        '
        Me.txtReferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(458, 211)
        Me.txtReferencia.MaxLength = 150
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(203, 23)
        Me.txtReferencia.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Concepto:"
        '
        'txtConcepto
        '
        Me.txtConcepto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConcepto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConcepto.Location = New System.Drawing.Point(110, 244)
        Me.txtConcepto.MaxLength = 150
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConcepto.Size = New System.Drawing.Size(888, 167)
        Me.txtConcepto.TabIndex = 4
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(576, 19)
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
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
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
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.groupBox1.Controls.Add(Me.Label28)
        Me.groupBox1.Controls.Add(Me.txtCalificacion)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.txtCreditoDisponible)
        Me.groupBox1.Controls.Add(Me.txtUltimoPago)
        Me.groupBox1.Controls.Add(Me.label21)
        Me.groupBox1.Controls.Add(Me.txtBalanceGeneral)
        Me.groupBox1.Controls.Add(Me.label20)
        Me.groupBox1.Controls.Add(Me.nombre_label)
        Me.groupBox1.Controls.Add(Me.txtIDCliente)
        Me.groupBox1.Controls.Add(Me.txtNombre)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(5, 124)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(657, 76)
        Me.groupBox1.TabIndex = 328
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos Cliente"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(172, 17)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(457, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 15)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = "Créd. Disp."
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(403, 46)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(48, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(330, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Calificación"
        '
        'txtCreditoDisponible
        '
        Me.txtCreditoDisponible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreditoDisponible.Enabled = False
        Me.txtCreditoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreditoDisponible.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCreditoDisponible.Location = New System.Drawing.Point(527, 45)
        Me.txtCreditoDisponible.Name = "txtCreditoDisponible"
        Me.txtCreditoDisponible.ReadOnly = True
        Me.txtCreditoDisponible.Size = New System.Drawing.Size(124, 23)
        Me.txtCreditoDisponible.TabIndex = 180
        Me.txtCreditoDisponible.TabStop = False
        Me.txtCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(247, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(77, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(186, 48)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Últ. Pago"
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.Enabled = False
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(64, 45)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(116, 23)
        Me.txtBalanceGeneral.TabIndex = 124
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(7, 49)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(53, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Bce. Gral"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(7, 20)
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
        Me.txtIDCliente.Location = New System.Drawing.Point(64, 17)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(110, 23)
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
        Me.txtNombre.Location = New System.Drawing.Point(193, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(458, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 329
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 426)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(1010, 25)
        Me.BarraEstado.TabIndex = 347
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
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'frm_otros_ingresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 451)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.MenuBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_otros_ingresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "97"
        Me.Text = "Otros Ingresos"
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDIngreso As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnGuardar As ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnEliminar As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCreditoDisponible As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGeneral As System.Windows.Forms.TextBox
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
End Class
