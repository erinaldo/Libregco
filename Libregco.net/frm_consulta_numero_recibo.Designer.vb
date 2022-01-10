<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_numero_recibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_numero_recibo))
        Me.DgvRecibos = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarCierre = New System.Windows.Forms.Button()
        Me.txtGrupo = New System.Windows.Forms.TextBox()
        Me.txtIDGrupo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.txtFechaGrupo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtIDCobrador = New System.Windows.Forms.TextBox()
        Me.DgvDetalle = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New Libregco.Watermark()
        Me.IDFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPagare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPagare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvRecibos
        '
        Me.DgvRecibos.AllowUserToAddRows = False
        Me.DgvRecibos.AllowUserToDeleteRows = False
        Me.DgvRecibos.AllowUserToResizeColumns = False
        Me.DgvRecibos.AllowUserToResizeRows = False
        Me.DgvRecibos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvRecibos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvRecibos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecibos.Location = New System.Drawing.Point(7, 205)
        Me.DgvRecibos.Name = "DgvRecibos"
        Me.DgvRecibos.RowHeadersVisible = False
        Me.DgvRecibos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvRecibos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecibos.Size = New System.Drawing.Size(742, 283)
        Me.DgvRecibos.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(755, 24)
        Me.MenuStrip1.TabIndex = 375
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(174, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
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
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 611)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(755, 25)
        Me.BarraEstado.TabIndex = 423
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
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(7, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 425
        Me.PicBoxLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(438, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 15)
        Me.Label1.TabIndex = 426
        Me.Label1.Text = "[Escriba el No. de recibo de cobro]"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 430
        Me.Label6.Text = "Grupo"
        '
        'btnBuscarCierre
        '
        Me.btnBuscarCierre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBuscarCierre.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCierre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCierre.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCierre.Location = New System.Drawing.Point(168, 118)
        Me.btnBuscarCierre.Name = "btnBuscarCierre"
        Me.btnBuscarCierre.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCierre.TabIndex = 428
        Me.btnBuscarCierre.UseVisualStyleBackColor = True
        '
        'txtGrupo
        '
        Me.txtGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGrupo.Enabled = False
        Me.txtGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtGrupo.Location = New System.Drawing.Point(190, 118)
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.ReadOnly = True
        Me.txtGrupo.Size = New System.Drawing.Size(345, 23)
        Me.txtGrupo.TabIndex = 429
        '
        'txtIDGrupo
        '
        Me.txtIDGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDGrupo.Location = New System.Drawing.Point(71, 118)
        Me.txtIDGrupo.Name = "txtIDGrupo"
        Me.txtIDGrupo.Size = New System.Drawing.Size(98, 23)
        Me.txtIDGrupo.TabIndex = 427
        Me.txtIDGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 433
        Me.Label5.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(8, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 436
        Me.Label7.Text = "Cobrador"
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.Enabled = False
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(175, 147)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(360, 23)
        Me.txtCobrador.TabIndex = 437
        '
        'txtFechaGrupo
        '
        Me.txtFechaGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFechaGrupo.Enabled = False
        Me.txtFechaGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaGrupo.Location = New System.Drawing.Point(71, 176)
        Me.txtFechaGrupo.Name = "txtFechaGrupo"
        Me.txtFechaGrupo.ReadOnly = True
        Me.txtFechaGrupo.Size = New System.Drawing.Size(164, 23)
        Me.txtFechaGrupo.TabIndex = 439
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(241, 176)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(508, 23)
        Me.txtDescripcion.TabIndex = 440
        '
        'txtIDCobrador
        '
        Me.txtIDCobrador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIDCobrador.Enabled = False
        Me.txtIDCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCobrador.Location = New System.Drawing.Point(71, 147)
        Me.txtIDCobrador.Name = "txtIDCobrador"
        Me.txtIDCobrador.ReadOnly = True
        Me.txtIDCobrador.Size = New System.Drawing.Size(98, 23)
        Me.txtIDCobrador.TabIndex = 441
        Me.txtIDCobrador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvDetalle
        '
        Me.DgvDetalle.AllowUserToAddRows = False
        Me.DgvDetalle.AllowUserToDeleteRows = False
        Me.DgvDetalle.AllowUserToResizeColumns = False
        Me.DgvDetalle.AllowUserToResizeRows = False
        Me.DgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDFactura, Me.Factura, Me.IDPagare, Me.NoPagare, Me.Debito, Me.Descuento, Me.Comision, Me.TipoComision})
        Me.DgvDetalle.Location = New System.Drawing.Point(7, 494)
        Me.DgvDetalle.Name = "DgvDetalle"
        Me.DgvDetalle.ReadOnly = True
        Me.DgvDetalle.RowHeadersVisible = False
        Me.DgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalle.Size = New System.Drawing.Size(742, 114)
        Me.DgvDetalle.TabIndex = 442
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(441, 60)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(302, 23)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.WatermarkColor = System.Drawing.Color.Gray
        Me.txtBuscar.WatermarkText = "No. Recibo a Buscar"
        '
        'IDFactura
        '
        Me.IDFactura.HeaderText = "IDFactura"
        Me.IDFactura.Name = "IDFactura"
        Me.IDFactura.ReadOnly = True
        Me.IDFactura.Visible = False
        '
        'Factura
        '
        Me.Factura.HeaderText = "Factura"
        Me.Factura.Name = "Factura"
        Me.Factura.ReadOnly = True
        Me.Factura.Width = 130
        '
        'IDPagare
        '
        Me.IDPagare.HeaderText = "IDPagare"
        Me.IDPagare.Name = "IDPagare"
        Me.IDPagare.ReadOnly = True
        Me.IDPagare.Visible = False
        '
        'NoPagare
        '
        Me.NoPagare.HeaderText = "No. Pagaré"
        Me.NoPagare.Name = "NoPagare"
        Me.NoPagare.ReadOnly = True
        Me.NoPagare.Width = 120
        '
        'Debito
        '
        Me.Debito.HeaderText = "Débito"
        Me.Debito.Name = "Debito"
        Me.Debito.ReadOnly = True
        Me.Debito.Width = 110
        '
        'Descuento
        '
        Me.Descuento.HeaderText = "Descuento"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        '
        'Comision
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Comision.DefaultCellStyle = DataGridViewCellStyle1
        Me.Comision.HeaderText = "Balance"
        Me.Comision.Name = "Comision"
        Me.Comision.ReadOnly = True
        Me.Comision.Width = 140
        '
        'TipoComision
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        Me.TipoComision.DefaultCellStyle = DataGridViewCellStyle2
        Me.TipoComision.HeaderText = "Balance Cerrado"
        Me.TipoComision.Name = "TipoComision"
        Me.TipoComision.ReadOnly = True
        Me.TipoComision.Width = 140
        '
        'frm_consulta_numero_recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 636)
        Me.Controls.Add(Me.DgvDetalle)
        Me.Controls.Add(Me.txtIDCobrador)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtFechaGrupo)
        Me.Controls.Add(Me.txtCobrador)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBuscarCierre)
        Me.Controls.Add(Me.txtGrupo)
        Me.Controls.Add(Me.txtIDGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.DgvRecibos)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_numero_recibo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "211"
        Me.Text = "Consulta de No. Recibo"
        CType(Me.DgvRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvRecibos As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As Watermark
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCierre As System.Windows.Forms.Button
    Friend WithEvents txtGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtIDGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCobrador As System.Windows.Forms.TextBox
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DgvDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents IDFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPagare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoPagare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoComision As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
