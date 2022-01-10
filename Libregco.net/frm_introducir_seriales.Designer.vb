<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_introducir_seriales
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_introducir_seriales))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtClienteFact = New System.Windows.Forms.TextBox()
        Me.DgvArticulosSerial = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.txtIDArticulo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtIDTipoUso = New System.Windows.Forms.TextBox()
        Me.txtTipoUso = New System.Windows.Forms.TextBox()
        Me.btnTipoUso = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkSoloMaterialesIndicado = New System.Windows.Forms.CheckBox()
        Me.chkTrasladoRes = New System.Windows.Forms.CheckBox()
        Me.ChkServTaller = New System.Windows.Forms.CheckBox()
        Me.chkServResidencial = New System.Windows.Forms.CheckBox()
        Me.chkServInstalacion = New System.Windows.Forms.CheckBox()
        Me.ChkMantenimiento = New System.Windows.Forms.CheckBox()
        Me.chkTransporteRep = New System.Windows.Forms.CheckBox()
        Me.chkManoObra = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNoSerial = New System.Windows.Forms.TextBox()
        Me.btnInsertar = New System.Windows.Forms.Button()
        Me.txtIDGarantia = New System.Windows.Forms.TextBox()
        Me.txtGarantia = New System.Windows.Forms.TextBox()
        Me.btnGarantia = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtVencimiento = New System.Windows.Forms.TextBox()
        Me.txtIDTarjeta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantidadDias = New System.Windows.Forms.TextBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        CType(Me.DgvArticulosSerial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "No. Factura"
        '
        'txtFactura
        '
        Me.txtFactura.BackColor = System.Drawing.SystemColors.Info
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.txtFactura.Location = New System.Drawing.Point(154, 19)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(232, 32)
        Me.txtFactura.TabIndex = 0
        Me.txtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtClienteFact
        '
        Me.txtClienteFact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClienteFact.Enabled = False
        Me.txtClienteFact.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtClienteFact.Location = New System.Drawing.Point(7, 114)
        Me.txtClienteFact.Name = "txtClienteFact"
        Me.txtClienteFact.ReadOnly = True
        Me.txtClienteFact.Size = New System.Drawing.Size(731, 29)
        Me.txtClienteFact.TabIndex = 5
        '
        'DgvArticulosSerial
        '
        Me.DgvArticulosSerial.AllowUserToAddRows = False
        Me.DgvArticulosSerial.AllowUserToDeleteRows = False
        Me.DgvArticulosSerial.AllowUserToResizeColumns = False
        Me.DgvArticulosSerial.AllowUserToResizeRows = False
        Me.DgvArticulosSerial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulosSerial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DgvArticulosSerial.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvArticulosSerial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulosSerial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvArticulosSerial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvArticulosSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArticulosSerial.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulosSerial.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvArticulosSerial.GridColor = System.Drawing.Color.DarkGray
        Me.DgvArticulosSerial.Location = New System.Drawing.Point(6, 19)
        Me.DgvArticulosSerial.MultiSelect = False
        Me.DgvArticulosSerial.Name = "DgvArticulosSerial"
        Me.DgvArticulosSerial.ReadOnly = True
        Me.DgvArticulosSerial.RowHeadersWidth = 35
        Me.DgvArticulosSerial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DgvArticulosSerial.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvArticulosSerial.RowTemplate.Height = 52
        Me.DgvArticulosSerial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulosSerial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulosSerial.Size = New System.Drawing.Size(923, 386)
        Me.DgvArticulosSerial.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.DgvArticulosSerial)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(935, 411)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control de series"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(692, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(244, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "[Seleccione con {Enter} o {Doble click} el artículo]"
        '
        'txtFecha
        '
        Me.txtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(744, 120)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(111, 23)
        Me.txtFecha.TabIndex = 200
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(740, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 20)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Nombre del cliente"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 567)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(948, 25)
        Me.BarraEstado.TabIndex = 304
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'txtIDArticulo
        '
        Me.txtIDArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDArticulo.Enabled = False
        Me.txtIDArticulo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtIDArticulo.Location = New System.Drawing.Point(76, 51)
        Me.txtIDArticulo.Name = "txtIDArticulo"
        Me.txtIDArticulo.ReadOnly = True
        Me.txtIDArticulo.Size = New System.Drawing.Size(88, 23)
        Me.txtIDArticulo.TabIndex = 204
        Me.txtIDArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(170, 51)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(403, 23)
        Me.txtDescripcion.TabIndex = 8
        '
        'txtReferencia
        '
        Me.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReferencia.Enabled = False
        Me.txtReferencia.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(579, 51)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(155, 23)
        Me.txtReferencia.TabIndex = 306
        '
        'txtIDTipoUso
        '
        Me.txtIDTipoUso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoUso.Location = New System.Drawing.Point(76, 109)
        Me.txtIDTipoUso.Name = "txtIDTipoUso"
        Me.txtIDTipoUso.Size = New System.Drawing.Size(95, 23)
        Me.txtIDTipoUso.TabIndex = 6
        Me.txtIDTipoUso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipoUso
        '
        Me.txtTipoUso.Enabled = False
        Me.txtTipoUso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoUso.Location = New System.Drawing.Point(193, 109)
        Me.txtTipoUso.Name = "txtTipoUso"
        Me.txtTipoUso.ReadOnly = True
        Me.txtTipoUso.Size = New System.Drawing.Size(541, 23)
        Me.txtTipoUso.TabIndex = 309
        '
        'btnTipoUso
        '
        Me.btnTipoUso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTipoUso.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTipoUso.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnTipoUso.Location = New System.Drawing.Point(170, 109)
        Me.btnTipoUso.Name = "btnTipoUso"
        Me.btnTipoUso.Size = New System.Drawing.Size(24, 23)
        Me.btnTipoUso.TabIndex = 7
        Me.btnTipoUso.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(3, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 310
        Me.Label7.Text = "Tipo de Uso"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.chkSoloMaterialesIndicado)
        Me.GroupBox4.Controls.Add(Me.chkTrasladoRes)
        Me.GroupBox4.Controls.Add(Me.ChkServTaller)
        Me.GroupBox4.Controls.Add(Me.chkServResidencial)
        Me.GroupBox4.Controls.Add(Me.chkServInstalacion)
        Me.GroupBox4.Controls.Add(Me.ChkMantenimiento)
        Me.GroupBox4.Controls.Add(Me.chkTransporteRep)
        Me.GroupBox4.Controls.Add(Me.chkManoObra)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 132)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(456, 90)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Coberturas"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox1.Location = New System.Drawing.Point(339, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Seleccionar todo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkSoloMaterialesIndicado
        '
        Me.chkSoloMaterialesIndicado.AutoSize = True
        Me.chkSoloMaterialesIndicado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkSoloMaterialesIndicado.Location = New System.Drawing.Point(150, 64)
        Me.chkSoloMaterialesIndicado.Name = "chkSoloMaterialesIndicado"
        Me.chkSoloMaterialesIndicado.Size = New System.Drawing.Size(175, 17)
        Me.chkSoloMaterialesIndicado.TabIndex = 17
        Me.chkSoloMaterialesIndicado.Text = "Sólo los materiales indicados"
        Me.chkSoloMaterialesIndicado.UseVisualStyleBackColor = True
        '
        'chkTrasladoRes
        '
        Me.chkTrasladoRes.AutoSize = True
        Me.chkTrasladoRes.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkTrasladoRes.Location = New System.Drawing.Point(10, 64)
        Me.chkTrasladoRes.Name = "chkTrasladoRes"
        Me.chkTrasladoRes.Size = New System.Drawing.Size(126, 17)
        Me.chkTrasladoRes.TabIndex = 16
        Me.chkTrasladoRes.Text = "Traslado residencial"
        Me.chkTrasladoRes.UseVisualStyleBackColor = True
        '
        'ChkServTaller
        '
        Me.ChkServTaller.AutoSize = True
        Me.ChkServTaller.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ChkServTaller.Location = New System.Drawing.Point(150, 41)
        Me.ChkServTaller.Name = "ChkServTaller"
        Me.ChkServTaller.Size = New System.Drawing.Size(110, 17)
        Me.ChkServTaller.TabIndex = 14
        Me.ChkServTaller.Text = "Servicio de Taller"
        Me.ChkServTaller.UseVisualStyleBackColor = True
        '
        'chkServResidencial
        '
        Me.chkServResidencial.AutoSize = True
        Me.chkServResidencial.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkServResidencial.Location = New System.Drawing.Point(10, 41)
        Me.chkServResidencial.Name = "chkServResidencial"
        Me.chkServResidencial.Size = New System.Drawing.Size(126, 17)
        Me.chkServResidencial.TabIndex = 13
        Me.chkServResidencial.Text = "Servicio Residencial"
        Me.chkServResidencial.UseVisualStyleBackColor = True
        '
        'chkServInstalacion
        '
        Me.chkServInstalacion.AutoSize = True
        Me.chkServInstalacion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkServInstalacion.Location = New System.Drawing.Point(311, 41)
        Me.chkServInstalacion.Name = "chkServInstalacion"
        Me.chkServInstalacion.Size = New System.Drawing.Size(140, 17)
        Me.chkServInstalacion.TabIndex = 15
        Me.chkServInstalacion.Text = "Servicio de Instalación"
        Me.chkServInstalacion.UseVisualStyleBackColor = True
        '
        'ChkMantenimiento
        '
        Me.ChkMantenimiento.AutoSize = True
        Me.ChkMantenimiento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ChkMantenimiento.Location = New System.Drawing.Point(311, 18)
        Me.ChkMantenimiento.Name = "ChkMantenimiento"
        Me.ChkMantenimiento.Size = New System.Drawing.Size(105, 17)
        Me.ChkMantenimiento.TabIndex = 12
        Me.ChkMantenimiento.Text = "Mantenimiento"
        Me.ChkMantenimiento.UseVisualStyleBackColor = True
        '
        'chkTransporteRep
        '
        Me.chkTransporteRep.AutoSize = True
        Me.chkTransporteRep.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkTransporteRep.Location = New System.Drawing.Point(150, 18)
        Me.chkTransporteRep.Name = "chkTransporteRep"
        Me.chkTransporteRep.Size = New System.Drawing.Size(154, 17)
        Me.chkTransporteRep.TabIndex = 11
        Me.chkTransporteRep.Text = "Transporte de reparación"
        Me.chkTransporteRep.UseVisualStyleBackColor = True
        '
        'chkManoObra
        '
        Me.chkManoObra.AutoSize = True
        Me.chkManoObra.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkManoObra.Location = New System.Drawing.Point(10, 18)
        Me.chkManoObra.Name = "chkManoObra"
        Me.chkManoObra.Size = New System.Drawing.Size(99, 17)
        Me.chkManoObra.TabIndex = 10
        Me.chkManoObra.Text = "Mano de obra"
        Me.chkManoObra.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtNoSerial)
        Me.GroupBox3.Controls.Add(Me.btnInsertar)
        Me.GroupBox3.Location = New System.Drawing.Point(468, 138)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(461, 67)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 21)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "No. Serial"
        '
        'txtNoSerial
        '
        Me.txtNoSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoSerial.Font = New System.Drawing.Font("Courier New", 16.0!)
        Me.txtNoSerial.Location = New System.Drawing.Point(89, 24)
        Me.txtNoSerial.Name = "txtNoSerial"
        Me.txtNoSerial.Size = New System.Drawing.Size(268, 32)
        Me.txtNoSerial.TabIndex = 19
        '
        'btnInsertar
        '
        Me.btnInsertar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInsertar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsertar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnInsertar.Image = Global.Libregco.My.Resources.Resources.Refresh_x32
        Me.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInsertar.Location = New System.Drawing.Point(356, 14)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(95, 47)
        Me.btnInsertar.TabIndex = 20
        Me.btnInsertar.Text = "Insertar"
        Me.btnInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'txtIDGarantia
        '
        Me.txtIDGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGarantia.Location = New System.Drawing.Point(76, 80)
        Me.txtIDGarantia.Name = "txtIDGarantia"
        Me.txtIDGarantia.Size = New System.Drawing.Size(95, 23)
        Me.txtIDGarantia.TabIndex = 4
        Me.txtIDGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtGarantia
        '
        Me.txtGarantia.Enabled = False
        Me.txtGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGarantia.Location = New System.Drawing.Point(193, 80)
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.ReadOnly = True
        Me.txtGarantia.Size = New System.Drawing.Size(541, 23)
        Me.txtGarantia.TabIndex = 315
        '
        'btnGarantia
        '
        Me.btnGarantia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGarantia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGarantia.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnGarantia.Location = New System.Drawing.Point(170, 80)
        Me.btnGarantia.Name = "btnGarantia"
        Me.btnGarantia.Size = New System.Drawing.Size(24, 23)
        Me.btnGarantia.TabIndex = 5
        Me.btnGarantia.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(3, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 316
        Me.Label8.Text = "Garantía"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtVencimiento)
        Me.GroupBox2.Controls.Add(Me.txtIDTarjeta)
        Me.GroupBox2.Controls.Add(Me.txtReferencia)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Controls.Add(Me.btnGarantia)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.btnTipoUso)
        Me.GroupBox2.Controls.Add(Me.txtIDArticulo)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.txtTipoUso)
        Me.GroupBox2.Controls.Add(Me.txtGarantia)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtIDGarantia)
        Me.GroupBox2.Controls.Add(Me.txtIDTipoUso)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 339)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(935, 222)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información de artículo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(3, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 329
        Me.Label3.Text = "Artículo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PictureBox1.Location = New System.Drawing.Point(740, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(187, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 321
        Me.PictureBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label12.Location = New System.Drawing.Point(6, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(169, 15)
        Me.Label12.TabIndex = 320
        Me.Label12.Text = "ID Serial / Tarjeta de Garantía"
        '
        'txtVencimiento
        '
        Me.txtVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVencimiento.Enabled = False
        Me.txtVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVencimiento.Location = New System.Drawing.Point(579, 22)
        Me.txtVencimiento.Name = "txtVencimiento"
        Me.txtVencimiento.ReadOnly = True
        Me.txtVencimiento.Size = New System.Drawing.Size(133, 16)
        Me.txtVencimiento.TabIndex = 317
        Me.txtVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDTarjeta
        '
        Me.txtIDTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIDTarjeta.Enabled = False
        Me.txtIDTarjeta.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDTarjeta.Location = New System.Drawing.Point(181, 23)
        Me.txtIDTarjeta.Name = "txtIDTarjeta"
        Me.txtIDTarjeta.ReadOnly = True
        Me.txtIDTarjeta.Size = New System.Drawing.Size(145, 21)
        Me.txtIDTarjeta.TabIndex = 319
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(438, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 15)
        Me.Label10.TabIndex = 318
        Me.Label10.Text = "Vencimiento de garantía"
        Me.Label10.Visible = False
        '
        'txtCantidadDias
        '
        Me.txtCantidadDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCantidadDias.Enabled = False
        Me.txtCantidadDias.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadDias.Location = New System.Drawing.Point(858, 120)
        Me.txtCantidadDias.Name = "txtCantidadDias"
        Me.txtCantidadDias.ReadOnly = True
        Me.txtCantidadDias.Size = New System.Drawing.Size(84, 23)
        Me.txtCantidadDias.TabIndex = 305
        Me.txtCantidadDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(517, 1)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 328
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'btnAnular
        '
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 95)
        Me.btnAnular.Text = "Eliminar"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Button1.Image = Global.Libregco.My.Resources.Resources.Search_x48
        Me.Button1.Location = New System.Drawing.Point(385, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.txtFactura)
        Me.GroupBox5.Location = New System.Drawing.Point(52, 10)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(433, 70)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'frm_introducir_seriales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(948, 592)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.txtCantidadDias)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtClienteFact)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_introducir_seriales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "71"
        Me.Text = "Controles de serie y garantías"
        CType(Me.DgvArticulosSerial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteFact As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulosSerial As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents txtIDArticulo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoUso As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoUso As System.Windows.Forms.TextBox
    Friend WithEvents btnTipoUso As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSoloMaterialesIndicado As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrasladoRes As System.Windows.Forms.CheckBox
    Friend WithEvents ChkServTaller As System.Windows.Forms.CheckBox
    Friend WithEvents chkServResidencial As System.Windows.Forms.CheckBox
    Friend WithEvents chkServInstalacion As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMantenimiento As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransporteRep As System.Windows.Forms.CheckBox
    Friend WithEvents chkManoObra As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNoSerial As System.Windows.Forms.TextBox
    Friend WithEvents btnInsertar As System.Windows.Forms.Button
    Friend WithEvents txtIDGarantia As System.Windows.Forms.TextBox
    Friend WithEvents txtGarantia As System.Windows.Forms.TextBox
    Friend WithEvents btnGarantia As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIDTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadDias As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnAnular As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox5 As GroupBox
End Class
