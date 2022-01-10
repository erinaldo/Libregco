<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cotizacion_detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cotizacion_detalle))
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCondicion = New System.Windows.Forms.Button()
        Me.txtIDCondicion = New System.Windows.Forms.TextBox()
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.btnNcf = New System.Windows.Forms.Button()
        Me.rdbGubernamental = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rdbRegimenEsp = New System.Windows.Forms.RadioButton()
        Me.txtTipoNcf = New System.Windows.Forms.TextBox()
        Me.rdbConsumidorFin = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnVendedor = New System.Windows.Forms.Button()
        Me.txtIDNcf = New System.Windows.Forms.TextBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.rdbCreditoFiscal = New System.Windows.Forms.RadioButton()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIDVendedor = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DgvNombre = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRNC = New System.Windows.Forms.TextBox()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        CType(Me.DgvNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 300
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label29.Location = New System.Drawing.Point(8, 111)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 15)
        Me.Label29.TabIndex = 342
        Me.Label29.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(11, 129)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(591, 75)
        Me.txtObservacion.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Condición"
        '
        'btnCondicion
        '
        Me.btnCondicion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCondicion.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCondicion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCondicion.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnCondicion.Location = New System.Drawing.Point(172, 48)
        Me.btnCondicion.Name = "btnCondicion"
        Me.btnCondicion.Size = New System.Drawing.Size(23, 23)
        Me.btnCondicion.TabIndex = 13
        Me.btnCondicion.TabStop = False
        Me.btnCondicion.UseVisualStyleBackColor = True
        '
        'txtIDCondicion
        '
        Me.txtIDCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCondicion.Location = New System.Drawing.Point(69, 48)
        Me.txtIDCondicion.Name = "txtIDCondicion"
        Me.txtIDCondicion.Size = New System.Drawing.Size(104, 23)
        Me.txtIDCondicion.TabIndex = 8
        Me.txtIDCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCondicion
        '
        Me.txtCondicion.Enabled = False
        Me.txtCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicion.Location = New System.Drawing.Point(194, 48)
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.ReadOnly = True
        Me.txtCondicion.Size = New System.Drawing.Size(406, 23)
        Me.txtCondicion.TabIndex = 338
        '
        'btnNcf
        '
        Me.btnNcf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNcf.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnNcf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNcf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNcf.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnNcf.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnNcf.Location = New System.Drawing.Point(172, 77)
        Me.btnNcf.Name = "btnNcf"
        Me.btnNcf.Size = New System.Drawing.Size(23, 23)
        Me.btnNcf.TabIndex = 15
        Me.btnNcf.TabStop = False
        Me.btnNcf.UseVisualStyleBackColor = True
        '
        'rdbGubernamental
        '
        Me.rdbGubernamental.AutoSize = True
        Me.rdbGubernamental.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbGubernamental.Location = New System.Drawing.Point(502, 105)
        Me.rdbGubernamental.Name = "rdbGubernamental"
        Me.rdbGubernamental.Size = New System.Drawing.Size(98, 17)
        Me.rdbGubernamental.TabIndex = 13
        Me.rdbGubernamental.Text = "Gubernamental"
        Me.rdbGubernamental.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 15)
        Me.Label4.TabIndex = 335
        Me.Label4.Text = "NCF"
        '
        'rdbRegimenEsp
        '
        Me.rdbRegimenEsp.AutoSize = True
        Me.rdbRegimenEsp.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbRegimenEsp.Location = New System.Drawing.Point(389, 105)
        Me.rdbRegimenEsp.Name = "rdbRegimenEsp"
        Me.rdbRegimenEsp.Size = New System.Drawing.Size(107, 17)
        Me.rdbRegimenEsp.TabIndex = 12
        Me.rdbRegimenEsp.Text = "Regimen Especial"
        Me.rdbRegimenEsp.UseVisualStyleBackColor = True
        '
        'txtTipoNcf
        '
        Me.txtTipoNcf.Enabled = False
        Me.txtTipoNcf.Location = New System.Drawing.Point(194, 77)
        Me.txtTipoNcf.Name = "txtTipoNcf"
        Me.txtTipoNcf.ReadOnly = True
        Me.txtTipoNcf.Size = New System.Drawing.Size(406, 23)
        Me.txtTipoNcf.TabIndex = 5
        '
        'rdbConsumidorFin
        '
        Me.rdbConsumidorFin.AutoSize = True
        Me.rdbConsumidorFin.Checked = True
        Me.rdbConsumidorFin.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbConsumidorFin.Location = New System.Drawing.Point(182, 105)
        Me.rdbConsumidorFin.Name = "rdbConsumidorFin"
        Me.rdbConsumidorFin.Size = New System.Drawing.Size(106, 17)
        Me.rdbConsumidorFin.TabIndex = 10
        Me.rdbConsumidorFin.TabStop = True
        Me.rdbConsumidorFin.Text = "Consumidor Final"
        Me.rdbConsumidorFin.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(6, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 334
        Me.Label3.Text = "Vendedor"
        '
        'btnVendedor
        '
        Me.btnVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVendedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnVendedor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnVendedor.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnVendedor.Location = New System.Drawing.Point(172, 19)
        Me.btnVendedor.Name = "btnVendedor"
        Me.btnVendedor.Size = New System.Drawing.Size(23, 23)
        Me.btnVendedor.TabIndex = 10
        Me.btnVendedor.TabStop = False
        Me.btnVendedor.UseVisualStyleBackColor = True
        '
        'txtIDNcf
        '
        Me.txtIDNcf.Location = New System.Drawing.Point(69, 77)
        Me.txtIDNcf.Name = "txtIDNcf"
        Me.txtIDNcf.Size = New System.Drawing.Size(104, 23)
        Me.txtIDNcf.TabIndex = 9
        Me.txtIDNcf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 536)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(625, 25)
        Me.BarraEstado.TabIndex = 345
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.Image = Global.Libregco.My.Resources.Resources.Libregco_v
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
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.Location = New System.Drawing.Point(420, 480)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(189, 37)
        Me.btnCancelar.TabIndex = 344
        Me.btnCancelar.Text = "  Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnContinuar
        '
        Me.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnContinuar.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.btnContinuar.Image = CType(resources.GetObject("btnContinuar.Image"), System.Drawing.Image)
        Me.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnContinuar.Location = New System.Drawing.Point(420, 410)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(189, 64)
        Me.btnContinuar.TabIndex = 343
        Me.btnContinuar.Text = "F10 Continuar"
        Me.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
        Me.label13.Location = New System.Drawing.Point(18, 432)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(101, 25)
        Me.label13.TabIndex = 347
        Me.label13.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.txtNeto.Location = New System.Drawing.Point(18, 460)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(266, 43)
        Me.txtNeto.TabIndex = 346
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rdbCreditoFiscal
        '
        Me.rdbCreditoFiscal.AutoSize = True
        Me.rdbCreditoFiscal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbCreditoFiscal.Location = New System.Drawing.Point(294, 105)
        Me.rdbCreditoFiscal.Name = "rdbCreditoFiscal"
        Me.rdbCreditoFiscal.Size = New System.Drawing.Size(89, 17)
        Me.rdbCreditoFiscal.TabIndex = 11
        Me.rdbCreditoFiscal.Text = "Crédito Fiscal"
        Me.rdbCreditoFiscal.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cédula / RNC"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 108
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtObservacion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnCondicion)
        Me.GroupBox2.Controls.Add(Me.txtIDCondicion)
        Me.GroupBox2.Controls.Add(Me.txtCondicion)
        Me.GroupBox2.Controls.Add(Me.btnNcf)
        Me.GroupBox2.Controls.Add(Me.rdbGubernamental)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.rdbRegimenEsp)
        Me.GroupBox2.Controls.Add(Me.txtTipoNcf)
        Me.GroupBox2.Controls.Add(Me.rdbConsumidorFin)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.rdbCreditoFiscal)
        Me.GroupBox2.Controls.Add(Me.btnVendedor)
        Me.GroupBox2.Controls.Add(Me.txtIDVendedor)
        Me.GroupBox2.Controls.Add(Me.txtVendedor)
        Me.GroupBox2.Controls.Add(Me.txtIDNcf)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(608, 216)
        Me.GroupBox2.TabIndex = 342
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de facturación"
        '
        'txtIDVendedor
        '
        Me.txtIDVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDVendedor.Location = New System.Drawing.Point(69, 19)
        Me.txtIDVendedor.Name = "txtIDVendedor"
        Me.txtIDVendedor.Size = New System.Drawing.Size(104, 23)
        Me.txtIDVendedor.TabIndex = 7
        Me.txtIDVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVendedor
        '
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(194, 19)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(406, 23)
        Me.txtVendedor.TabIndex = 286
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(192, 19)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(410, 23)
        Me.txtNombre.TabIndex = 1
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(101, 19)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(72, 23)
        Me.txtIDCliente.TabIndex = 16
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(171, 19)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(8, 24)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 100
        Me.nombre_label.Text = "Nombre"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtOrden)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.BindingNavigator)
        Me.GroupBox1.Controls.Add(Me.DgvNombre)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtRNC)
        Me.GroupBox1.Controls.Add(Me.txtIDCliente)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.nombre_label)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 178)
        Me.GroupBox1.TabIndex = 341
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'txtOrden
        '
        Me.txtOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrden.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOrden.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtOrden.Location = New System.Drawing.Point(69, 149)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(126, 23)
        Me.txtOrden.TabIndex = 5
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label8.Location = New System.Drawing.Point(8, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 341
        Me.Label8.Text = "# Orden"
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator.Location = New System.Drawing.Point(3, 150)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(602, 25)
        Me.BindingNavigator.TabIndex = 340
        Me.BindingNavigator.Text = "BindingNavigator1"
        Me.BindingNavigator.Visible = False
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'DgvNombre
        '
        Me.DgvNombre.AllowUserToAddRows = False
        Me.DgvNombre.AllowUserToDeleteRows = False
        Me.DgvNombre.AllowUserToResizeColumns = False
        Me.DgvNombre.AllowUserToResizeRows = False
        Me.DgvNombre.BackgroundColor = System.Drawing.Color.White
        Me.DgvNombre.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgvNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNombre.ColumnHeadersVisible = False
        Me.DgvNombre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvNombre.GridColor = System.Drawing.SystemColors.MenuHighlight
        Me.DgvNombre.Location = New System.Drawing.Point(192, 41)
        Me.DgvNombre.MultiSelect = False
        Me.DgvNombre.Name = "DgvNombre"
        Me.DgvNombre.ReadOnly = True
        Me.DgvNombre.RowHeadersVisible = False
        Me.DgvNombre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNombre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvNombre.Size = New System.Drawing.Size(410, 102)
        Me.DgvNombre.TabIndex = 339
        Me.DgvNombre.TabStop = False
        Me.DgvNombre.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label7.Location = New System.Drawing.Point(66, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 338
        Me.Label7.Text = "[F12]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(8, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 337
        Me.Label6.Text = "Teléfonos"
        '
        'txtTelefono
        '
        Me.txtTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefono.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtTelefono.Location = New System.Drawing.Point(69, 120)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(210, 23)
        Me.txtTelefono.TabIndex = 4
        Me.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 335
        Me.Label5.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtDireccion.Location = New System.Drawing.Point(69, 77)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccion.Size = New System.Drawing.Size(533, 37)
        Me.txtDireccion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 333
        Me.Label1.Text = "RNC"
        '
        'txtRNC
        '
        Me.txtRNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRNC.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRNC.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtRNC.Location = New System.Drawing.Point(69, 48)
        Me.txtRNC.Name = "txtRNC"
        Me.txtRNC.Size = New System.Drawing.Size(210, 23)
        Me.txtRNC.TabIndex = 2
        Me.txtRNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_cotizacion_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 561)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cotizacion_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles de la cotización"
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        CType(Me.DgvNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Label29 As Label
    Friend WithEvents txtObservacion As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents btnCondicion As Button
    Friend WithEvents txtIDCondicion As TextBox
    Friend WithEvents txtCondicion As TextBox
    Private WithEvents btnNcf As Button
    Friend WithEvents rdbGubernamental As RadioButton
    Private WithEvents Label4 As Label
    Friend WithEvents rdbRegimenEsp As RadioButton
    Friend WithEvents txtTipoNcf As TextBox
    Friend WithEvents rdbConsumidorFin As RadioButton
    Private WithEvents Label3 As Label
    Private WithEvents btnVendedor As Button
    Friend WithEvents txtIDNcf As TextBox
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnContinuar As Button
    Friend WithEvents label13 As Label
    Friend WithEvents txtNeto As TextBox
    Friend WithEvents rdbCreditoFiscal As RadioButton
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtIDVendedor As TextBox
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtIDCliente As TextBox
    Private WithEvents btnBuscarCliente As Button
    Private WithEvents nombre_label As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtOrden As TextBox
    Private WithEvents Label8 As Label
    Friend WithEvents BindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents DgvNombre As DataGridView
    Friend WithEvents Label7 As Label
    Private WithEvents Label6 As Label
    Friend WithEvents txtTelefono As TextBox
    Private WithEvents Label5 As Label
    Friend WithEvents txtDireccion As TextBox
    Private WithEvents Label1 As Label
    Friend WithEvents txtRNC As TextBox
End Class
