<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_ventas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_ventas))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.chkNulos = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarCons = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPresentar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStructure = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarTipoMemo = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.chkResumir = New System.Windows.Forms.CheckBox()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.CbxTipoOrden = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxOrden = New System.Windows.Forms.ComboBox()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrevisualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImpresiónDirectaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.btnSubir = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImagen = New System.Windows.Forms.ToolStripMenuItem()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(10, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "Vendedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(172, 59)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(410, 20)
        Me.txtVendedor.TabIndex = 323
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(67, 59)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(79, 20)
        Me.txtIDVendedor.TabIndex = 4
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label5.Location = New System.Drawing.Point(10, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 321
        Me.Label5.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCliente.Location = New System.Drawing.Point(172, 30)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(410, 20)
        Me.txtCliente.TabIndex = 320
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(68, 30)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(78, 20)
        Me.txtIDCliente.TabIndex = 2
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.CustomFormat = "yyyy-MM-dd"
        Me.txtFechaFinal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFinal.Location = New System.Drawing.Point(52, 60)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaFinal.TabIndex = 338
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.CustomFormat = "yyyy-MM-dd"
        Me.txtFechaInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicial.Location = New System.Drawing.Point(52, 29)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(100, 23)
        Me.txtFechaInicial.TabIndex = 337
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 335
        Me.Label7.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownHeight = 100
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.IntegralHeight = False
        Me.cbxCondicion.Location = New System.Drawing.Point(67, 29)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(148, 21)
        Me.cbxCondicion.TabIndex = 7
        '
        'chkNulos
        '
        Me.chkNulos.AutoSize = True
        Me.chkNulos.BackColor = System.Drawing.Color.Transparent
        Me.chkNulos.Location = New System.Drawing.Point(146, 1)
        Me.chkNulos.Name = "chkNulos"
        Me.chkNulos.Size = New System.Drawing.Size(71, 17)
        Me.chkNulos.TabIndex = 6
        Me.chkNulos.Text = "Ver Nulos"
        Me.chkNulos.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(10, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "Formato"
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.IconPanel.Location = New System.Drawing.Point(3, 532)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(545, 71)
        Me.IconPanel.TabIndex = 344
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLimpiar, Me.btnBuscarCons, Me.btnPresentar, Me.btnModificar, Me.btnStructure, Me.btnSubir, Me.btnImagen})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(545, 71)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.Clean_x48
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 67)
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.btnBuscarCons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.btnBuscarCons.Size = New System.Drawing.Size(60, 67)
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Preview_x48
        Me.btnPresentar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.btnPresentar.Size = New System.Drawing.Size(68, 67)
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Libregco.My.Resources.Resources.New_x48
        Me.btnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.btnModificar.Size = New System.Drawing.Size(70, 67)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnStructure
        '
        Me.btnStructure.Image = Global.Libregco.My.Resources.Resources.Iterm_x48
        Me.btnStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnStructure.Name = "btnStructure"
        Me.btnStructure.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.btnStructure.Size = New System.Drawing.Size(72, 67)
        Me.btnStructure.Text = "Estructura"
        Me.btnStructure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscarTipoMemo
        '
        Me.btnBuscarTipoMemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTipoMemo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTipoMemo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarTipoMemo.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarTipoMemo.Location = New System.Drawing.Point(145, 59)
        Me.btnBuscarTipoMemo.Name = "btnBuscarTipoMemo"
        Me.btnBuscarTipoMemo.Size = New System.Drawing.Size(28, 20)
        Me.btnBuscarTipoMemo.TabIndex = 5
        Me.btnBuscarTipoMemo.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(145, 30)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(28, 20)
        Me.btnBuscarCliente.TabIndex = 3
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'chkResumir
        '
        Me.chkResumir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkResumir.AutoSize = True
        Me.chkResumir.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkResumir.ForeColor = System.Drawing.Color.Black
        Me.chkResumir.Location = New System.Drawing.Point(396, 37)
        Me.chkResumir.Name = "chkResumir"
        Me.chkResumir.Size = New System.Drawing.Size(64, 17)
        Me.chkResumir.TabIndex = 350
        Me.chkResumir.Text = "Resumir"
        Me.chkResumir.UseVisualStyleBackColor = True
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(63, 34)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(327, 21)
        Me.CbxFormato.TabIndex = 348
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rdbGeneral)
        Me.Panel1.Controls.Add(Me.rdbEspecifico)
        Me.Panel1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Panel1.Location = New System.Drawing.Point(299, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 23)
        Me.Panel1.TabIndex = 347
        '
        'rdbGeneral
        '
        Me.rdbGeneral.AutoSize = True
        Me.rdbGeneral.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbGeneral.Location = New System.Drawing.Point(88, 2)
        Me.rdbGeneral.Name = "rdbGeneral"
        Me.rdbGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdbGeneral.TabIndex = 347
        Me.rdbGeneral.Text = "General"
        Me.rdbGeneral.UseVisualStyleBackColor = True
        '
        'rdbEspecifico
        '
        Me.rdbEspecifico.AutoSize = True
        Me.rdbEspecifico.Checked = True
        Me.rdbEspecifico.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbEspecifico.Location = New System.Drawing.Point(2, 2)
        Me.rdbEspecifico.Name = "rdbEspecifico"
        Me.rdbEspecifico.Size = New System.Drawing.Size(72, 17)
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
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.ToolStripSeparator1})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 682)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(997, 25)
        Me.BarraEstado.TabIndex = 346
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Calendarx24
        Me.GroupControl1.Controls.Add(Me.txtFechaFinal)
        Me.GroupControl1.Controls.Add(Me.txtFechaInicial)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Location = New System.Drawing.Point(4, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(164, 92)
        Me.GroupControl1.TabIndex = 347
        Me.GroupControl1.Text = "Rango de fechas"
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl2.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Relationx24
        Me.GroupControl2.Controls.Add(Me.Label5)
        Me.GroupControl2.Controls.Add(Me.txtIDCliente)
        Me.GroupControl2.Controls.Add(Me.txtCliente)
        Me.GroupControl2.Controls.Add(Me.btnBuscarCliente)
        Me.GroupControl2.Controls.Add(Me.txtIDVendedor)
        Me.GroupControl2.Controls.Add(Me.txtVendedor)
        Me.GroupControl2.Controls.Add(Me.btnBuscarTipoMemo)
        Me.GroupControl2.Controls.Add(Me.Label4)
        Me.GroupControl2.Location = New System.Drawing.Point(174, 4)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(593, 92)
        Me.GroupControl2.TabIndex = 348
        Me.GroupControl2.Text = "Relacionados"
        '
        'GroupControl3
        '
        Me.GroupControl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl3.Controls.Add(Me.CbxTipoOrden)
        Me.GroupControl3.Controls.Add(Me.Label6)
        Me.GroupControl3.Controls.Add(Me.cbxOrden)
        Me.GroupControl3.Controls.Add(Me.chkNulos)
        Me.GroupControl3.Controls.Add(Me.cbxCondicion)
        Me.GroupControl3.Controls.Add(Me.Label7)
        Me.GroupControl3.Location = New System.Drawing.Point(773, 4)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(220, 92)
        Me.GroupControl3.TabIndex = 349
        Me.GroupControl3.Text = "Otros"
        '
        'CbxTipoOrden
        '
        Me.CbxTipoOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxTipoOrden.FormattingEnabled = True
        Me.CbxTipoOrden.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.CbxTipoOrden.Location = New System.Drawing.Point(156, 58)
        Me.CbxTipoOrden.Name = "CbxTipoOrden"
        Me.CbxTipoOrden.Size = New System.Drawing.Size(59, 21)
        Me.CbxTipoOrden.TabIndex = 424
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 423
        Me.Label6.Text = "Ordenar"
        '
        'cbxOrden
        '
        Me.cbxOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxOrden.FormattingEnabled = True
        Me.cbxOrden.Items.AddRange(New Object() {"Documento", "Fecha", "Cliente", "Total"})
        Me.cbxOrden.Location = New System.Drawing.Point(67, 58)
        Me.cbxOrden.Name = "cbxOrden"
        Me.cbxOrden.Size = New System.Drawing.Size(85, 21)
        Me.cbxOrden.TabIndex = 422
        '
        'GroupControl4
        '
        Me.GroupControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl4.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Outputx24
        Me.GroupControl4.Controls.Add(Me.rdbPresentacion)
        Me.GroupControl4.Controls.Add(Me.rdbImpresora)
        Me.GroupControl4.Controls.Add(Me.rdbExcel)
        Me.GroupControl4.Controls.Add(Me.rdbPDF)
        Me.GroupControl4.Location = New System.Drawing.Point(6, 609)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(518, 67)
        Me.GroupControl4.TabIndex = 417
        Me.GroupControl4.Text = "Tipos de salida"
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbPresentacion.Image = Global.Libregco.My.Resources.Resources.Documentx24
        Me.rdbPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbPresentacion.Location = New System.Drawing.Point(4, 25)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(125, 39)
        Me.rdbPresentacion.TabIndex = 44
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbImpresora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbImpresora.Image = Global.Libregco.My.Resources.Resources.Printerx24
        Me.rdbImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbImpresora.Location = New System.Drawing.Point(135, 25)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(105, 39)
        Me.rdbImpresora.TabIndex = 41
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbExcel
        '
        Me.rdbExcel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbExcel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbExcel.Image = Global.Libregco.My.Resources.Resources.excelx24
        Me.rdbExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbExcel.Location = New System.Drawing.Point(376, 25)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(136, 39)
        Me.rdbExcel.TabIndex = 43
        Me.rdbExcel.Text = "Convertir a Excel"
        Me.rdbExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPDF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbPDF.Image = Global.Libregco.My.Resources.Resources.Pdfx24
        Me.rdbPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbPDF.Location = New System.Drawing.Point(245, 25)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(125, 39)
        Me.rdbPDF.TabIndex = 42
        Me.rdbPDF.Text = "Convertir a PDF"
        Me.rdbPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'GroupControl5
        '
        Me.GroupControl5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl5.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Reportx16
        Me.GroupControl5.Controls.Add(Me.Panel1)
        Me.GroupControl5.Controls.Add(Me.chkResumir)
        Me.GroupControl5.Controls.Add(Me.Label8)
        Me.GroupControl5.Controls.Add(Me.CbxFormato)
        Me.GroupControl5.Location = New System.Drawing.Point(528, 609)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(465, 67)
        Me.GroupControl5.TabIndex = 418
        Me.GroupControl5.Text = "Gestor de reportes"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Location = New System.Drawing.Point(0, 102)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(997, 427)
        Me.GridControl1.TabIndex = 420
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrevisualizarToolStripMenuItem, Me.ToolStripSeparator3, Me.ImpresiónDirectaToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ToolStripSeparator2, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem5})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(158, 170)
        '
        'PrevisualizarToolStripMenuItem
        '
        Me.PrevisualizarToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PrevisualizarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.reportx24
        Me.PrevisualizarToolStripMenuItem.Name = "PrevisualizarToolStripMenuItem"
        Me.PrevisualizarToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PrevisualizarToolStripMenuItem.Text = "Previsualizar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(154, 6)
        '
        'ImpresiónDirectaToolStripMenuItem
        '
        Me.ImpresiónDirectaToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ImpresiónDirectaToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.printx24
        Me.ImpresiónDirectaToolStripMenuItem.Name = "ImpresiónDirectaToolStripMenuItem"
        Me.ImpresiónDirectaToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ImpresiónDirectaToolStripMenuItem.Text = "Impresión directa"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.excelblackx24
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem1.Text = "Exportar a Excel"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripMenuItem4.Image = Global.Libregco.My.Resources.Resources.pdfblackx24
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem4.Text = "Exportar a PDF"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(154, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripMenuItem2.Image = Global.Libregco.My.Resources.Resources.cellx24
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem2.Text = "Copiar celda"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripMenuItem3.Image = Global.Libregco.My.Resources.Resources.rowx24
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem3.Text = "Copiar fila"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripMenuItem5.Image = Global.Libregco.My.Resources.Resources.columnx24
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem5.Text = "Copiar columna"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'btnSubir
        '
        Me.btnSubir.Image = Global.Libregco.My.Resources.Resources.Cloudx48
        Me.btnSubir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(60, 67)
        Me.btnSubir.Text = "Subir"
        Me.btnSubir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSubir.Visible = False
        '
        'btnImagen
        '
        Me.btnImagen.Image = Global.Libregco.My.Resources.Resources.Image_Capture_x48
        Me.btnImagen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(60, 67)
        Me.btnImagen.Text = "Imagen"
        Me.btnImagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnImagen.Visible = False
        '
        'frm_consulta_ventas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 707)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl5)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_consulta_ventas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "46"
        Me.Text = "Consulta de ventas"
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarTipoMemo As System.Windows.Forms.Button
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtIDVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarCons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPresentar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEspecifico As System.Windows.Forms.RadioButton
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents chkNulos As System.Windows.Forms.CheckBox
    Friend WithEvents chkResumir As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents CbxTipoOrden As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxOrden As ComboBox
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdbPresentacion As RadioButton
    Friend WithEvents rdbImpresora As RadioButton
    Friend WithEvents rdbExcel As RadioButton
    Friend WithEvents rdbPDF As RadioButton
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PrevisualizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ImpresiónDirectaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents btnSubir As ToolStripMenuItem
    Friend WithEvents btnImagen As ToolStripMenuItem
End Class
