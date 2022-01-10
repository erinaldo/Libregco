<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_historialpagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_historialpagos))
        Me.DgvHistorial = New System.Windows.Forms.DataGridView()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkChequesDev = New System.Windows.Forms.CheckBox()
        Me.chkDevoluciones = New System.Windows.Forms.CheckBox()
        Me.chkNotaDebito = New System.Windows.Forms.CheckBox()
        Me.chkNotaCredito = New System.Windows.Forms.CheckBox()
        Me.chkAbono = New System.Windows.Forms.CheckBox()
        Me.chkCargos = New System.Windows.Forms.CheckBox()
        Me.chkFacturaContado = New System.Windows.Forms.CheckBox()
        Me.chkFacturaCredito = New System.Windows.Forms.CheckBox()
        Me.ColorCargos = New System.Windows.Forms.Label()
        Me.ColorNotaDebito = New System.Windows.Forms.Label()
        Me.ColorNotaCredito = New System.Windows.Forms.Label()
        Me.ColorDevoluciones = New System.Windows.Forms.Label()
        Me.ColorChequesDev = New System.Windows.Forms.Label()
        Me.ColorAbonos = New System.Windows.Forms.Label()
        Me.ColorFactContado = New System.Windows.Forms.Label()
        Me.ColorFactCredito = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.LueMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.LueMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvHistorial
        '
        Me.DgvHistorial.AllowUserToAddRows = False
        Me.DgvHistorial.AllowUserToDeleteRows = False
        Me.DgvHistorial.AllowUserToResizeColumns = False
        Me.DgvHistorial.AllowUserToResizeRows = False
        Me.DgvHistorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DgvHistorial.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvHistorial.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvHistorial.Location = New System.Drawing.Point(2, 48)
        Me.DgvHistorial.MultiSelect = False
        Me.DgvHistorial.Name = "DgvHistorial"
        Me.DgvHistorial.ReadOnly = True
        Me.DgvHistorial.RowHeadersWidth = 30
        Me.DgvHistorial.RowTemplate.Height = 25
        Me.DgvHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvHistorial.Size = New System.Drawing.Size(966, 416)
        Me.DgvHistorial.TabIndex = 2
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(8, 23)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(93, 20)
        Me.txtIDCliente.TabIndex = 3
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Enabled = False
        Me.txtNombreCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNombreCliente.Location = New System.Drawing.Point(107, 23)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(478, 20)
        Me.txtNombreCliente.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(5, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(104, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.SimpleButton2)
        Me.GroupBox1.Controls.Add(Me.SimpleButton1)
        Me.GroupBox1.Controls.Add(Me.chkChequesDev)
        Me.GroupBox1.Controls.Add(Me.chkDevoluciones)
        Me.GroupBox1.Controls.Add(Me.chkNotaDebito)
        Me.GroupBox1.Controls.Add(Me.chkNotaCredito)
        Me.GroupBox1.Controls.Add(Me.chkAbono)
        Me.GroupBox1.Controls.Add(Me.chkCargos)
        Me.GroupBox1.Controls.Add(Me.chkFacturaContado)
        Me.GroupBox1.Controls.Add(Me.chkFacturaCredito)
        Me.GroupBox1.Controls.Add(Me.ColorCargos)
        Me.GroupBox1.Controls.Add(Me.ColorNotaDebito)
        Me.GroupBox1.Controls.Add(Me.ColorNotaCredito)
        Me.GroupBox1.Controls.Add(Me.ColorDevoluciones)
        Me.GroupBox1.Controls.Add(Me.ColorChequesDev)
        Me.GroupBox1.Controls.Add(Me.ColorAbonos)
        Me.GroupBox1.Controls.Add(Me.ColorFactContado)
        Me.GroupBox1.Controls.Add(Me.ColorFactCredito)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 470)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(963, 58)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Leyenda"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Refresh_x72
        Me.SimpleButton1.Location = New System.Drawing.Point(583, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(144, 39)
        Me.SimpleButton1.TabIndex = 33
        Me.SimpleButton1.Text = "Actualizar"
        '
        'chkChequesDev
        '
        Me.chkChequesDev.AutoSize = True
        Me.chkChequesDev.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkChequesDev.Checked = True
        Me.chkChequesDev.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChequesDev.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkChequesDev.Location = New System.Drawing.Point(458, 15)
        Me.chkChequesDev.Name = "chkChequesDev"
        Me.chkChequesDev.Size = New System.Drawing.Size(119, 17)
        Me.chkChequesDev.TabIndex = 31
        Me.chkChequesDev.Text = "Cheques Devueltos"
        Me.chkChequesDev.UseVisualStyleBackColor = True
        '
        'chkDevoluciones
        '
        Me.chkDevoluciones.AutoSize = True
        Me.chkDevoluciones.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDevoluciones.Checked = True
        Me.chkDevoluciones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDevoluciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkDevoluciones.Location = New System.Drawing.Point(458, 36)
        Me.chkDevoluciones.Name = "chkDevoluciones"
        Me.chkDevoluciones.Size = New System.Drawing.Size(119, 17)
        Me.chkDevoluciones.TabIndex = 30
        Me.chkDevoluciones.Text = "Devoluciones          "
        Me.chkDevoluciones.UseVisualStyleBackColor = True
        '
        'chkNotaDebito
        '
        Me.chkNotaDebito.AutoSize = True
        Me.chkNotaDebito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNotaDebito.Checked = True
        Me.chkNotaDebito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNotaDebito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkNotaDebito.Location = New System.Drawing.Point(304, 15)
        Me.chkNotaDebito.Name = "chkNotaDebito"
        Me.chkNotaDebito.Size = New System.Drawing.Size(106, 17)
        Me.chkNotaDebito.TabIndex = 29
        Me.chkNotaDebito.Text = "Notas de Débito "
        Me.chkNotaDebito.UseVisualStyleBackColor = True
        '
        'chkNotaCredito
        '
        Me.chkNotaCredito.AutoSize = True
        Me.chkNotaCredito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNotaCredito.Checked = True
        Me.chkNotaCredito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNotaCredito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkNotaCredito.Location = New System.Drawing.Point(304, 36)
        Me.chkNotaCredito.Name = "chkNotaCredito"
        Me.chkNotaCredito.Size = New System.Drawing.Size(107, 17)
        Me.chkNotaCredito.TabIndex = 28
        Me.chkNotaCredito.Text = "Notas de Crédito"
        Me.chkNotaCredito.UseVisualStyleBackColor = True
        '
        'chkAbono
        '
        Me.chkAbono.AutoSize = True
        Me.chkAbono.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAbono.Checked = True
        Me.chkAbono.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAbono.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkAbono.Location = New System.Drawing.Point(199, 15)
        Me.chkAbono.Name = "chkAbono"
        Me.chkAbono.Size = New System.Drawing.Size(62, 17)
        Me.chkAbono.TabIndex = 27
        Me.chkAbono.Text = "Abonos"
        Me.chkAbono.UseVisualStyleBackColor = True
        '
        'chkCargos
        '
        Me.chkCargos.AutoSize = True
        Me.chkCargos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCargos.Checked = True
        Me.chkCargos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCargos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCargos.Location = New System.Drawing.Point(199, 36)
        Me.chkCargos.Name = "chkCargos"
        Me.chkCargos.Size = New System.Drawing.Size(63, 17)
        Me.chkCargos.TabIndex = 26
        Me.chkCargos.Text = "Cargos "
        Me.chkCargos.UseVisualStyleBackColor = True
        '
        'chkFacturaContado
        '
        Me.chkFacturaContado.AutoSize = True
        Me.chkFacturaContado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFacturaContado.Checked = True
        Me.chkFacturaContado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFacturaContado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFacturaContado.Location = New System.Drawing.Point(33, 36)
        Me.chkFacturaContado.Name = "chkFacturaContado"
        Me.chkFacturaContado.Size = New System.Drawing.Size(121, 17)
        Me.chkFacturaContado.TabIndex = 25
        Me.chkFacturaContado.Text = "Facturas a Contado"
        Me.chkFacturaContado.UseVisualStyleBackColor = True
        '
        'chkFacturaCredito
        '
        Me.chkFacturaCredito.AutoSize = True
        Me.chkFacturaCredito.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFacturaCredito.Checked = True
        Me.chkFacturaCredito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFacturaCredito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFacturaCredito.Location = New System.Drawing.Point(33, 15)
        Me.chkFacturaCredito.Name = "chkFacturaCredito"
        Me.chkFacturaCredito.Size = New System.Drawing.Size(121, 17)
        Me.chkFacturaCredito.TabIndex = 24
        Me.chkFacturaCredito.Text = "Facturas a Crédito  "
        Me.chkFacturaCredito.UseVisualStyleBackColor = True
        '
        'ColorCargos
        '
        Me.ColorCargos.BackColor = System.Drawing.Color.Black
        Me.ColorCargos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorCargos.Location = New System.Drawing.Point(178, 36)
        Me.ColorCargos.Name = "ColorCargos"
        Me.ColorCargos.Size = New System.Drawing.Size(15, 15)
        Me.ColorCargos.TabIndex = 22
        '
        'ColorNotaDebito
        '
        Me.ColorNotaDebito.BackColor = System.Drawing.Color.Black
        Me.ColorNotaDebito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorNotaDebito.Location = New System.Drawing.Point(283, 15)
        Me.ColorNotaDebito.Name = "ColorNotaDebito"
        Me.ColorNotaDebito.Size = New System.Drawing.Size(15, 15)
        Me.ColorNotaDebito.TabIndex = 20
        '
        'ColorNotaCredito
        '
        Me.ColorNotaCredito.BackColor = System.Drawing.Color.Black
        Me.ColorNotaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorNotaCredito.Location = New System.Drawing.Point(283, 36)
        Me.ColorNotaCredito.Name = "ColorNotaCredito"
        Me.ColorNotaCredito.Size = New System.Drawing.Size(15, 15)
        Me.ColorNotaCredito.TabIndex = 13
        '
        'ColorDevoluciones
        '
        Me.ColorDevoluciones.BackColor = System.Drawing.Color.Black
        Me.ColorDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorDevoluciones.Location = New System.Drawing.Point(437, 36)
        Me.ColorDevoluciones.Name = "ColorDevoluciones"
        Me.ColorDevoluciones.Size = New System.Drawing.Size(15, 15)
        Me.ColorDevoluciones.TabIndex = 12
        '
        'ColorChequesDev
        '
        Me.ColorChequesDev.BackColor = System.Drawing.Color.Black
        Me.ColorChequesDev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorChequesDev.Location = New System.Drawing.Point(437, 15)
        Me.ColorChequesDev.Name = "ColorChequesDev"
        Me.ColorChequesDev.Size = New System.Drawing.Size(15, 15)
        Me.ColorChequesDev.TabIndex = 11
        '
        'ColorAbonos
        '
        Me.ColorAbonos.BackColor = System.Drawing.Color.Black
        Me.ColorAbonos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorAbonos.Location = New System.Drawing.Point(178, 15)
        Me.ColorAbonos.Name = "ColorAbonos"
        Me.ColorAbonos.Size = New System.Drawing.Size(15, 15)
        Me.ColorAbonos.TabIndex = 10
        '
        'ColorFactContado
        '
        Me.ColorFactContado.BackColor = System.Drawing.Color.Black
        Me.ColorFactContado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorFactContado.Location = New System.Drawing.Point(12, 36)
        Me.ColorFactContado.Name = "ColorFactContado"
        Me.ColorFactContado.Size = New System.Drawing.Size(15, 15)
        Me.ColorFactContado.TabIndex = 1
        '
        'ColorFactCredito
        '
        Me.ColorFactCredito.BackColor = System.Drawing.Color.Black
        Me.ColorFactCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorFactCredito.Location = New System.Drawing.Point(12, 15)
        Me.ColorFactCredito.Name = "ColorFactCredito"
        Me.ColorFactCredito.Size = New System.Drawing.Size(15, 15)
        Me.ColorFactCredito.TabIndex = 0
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 538)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(973, 25)
        Me.BarraEstado.TabIndex = 270
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
        'LueMoneda
        '
        Me.LueMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LueMoneda.Location = New System.Drawing.Point(690, 23)
        Me.LueMoneda.Name = "LueMoneda"
        Me.LueMoneda.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.LueMoneda.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.LueMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.LueMoneda.Properties.Appearance.Options.UseFont = True
        Me.LueMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.LueMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LueMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LueMoneda.Properties.DropDownRows = 6
        Me.LueMoneda.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.LueMoneda.Properties.SmallImages = Me.imgFlags
        Me.LueMoneda.Size = New System.Drawing.Size(278, 20)
        Me.LueMoneda.TabIndex = 340
        Me.LueMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(687, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 341
        Me.Label4.Text = "Moneda"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.SimpleButton2.Location = New System.Drawing.Point(780, 12)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(178, 39)
        Me.SimpleButton2.TabIndex = 342
        Me.SimpleButton2.Text = "Estado de cuenta"
        '
        'frm_historialpagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 563)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LueMoneda)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.DgvHistorial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_historialpagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "116"
        Me.Text = "Historia"
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.LueMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvHistorial As System.Windows.Forms.DataGridView
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ColorNotaCredito As Label
    Friend WithEvents ColorDevoluciones As Label
    Friend WithEvents ColorChequesDev As Label
    Friend WithEvents ColorAbonos As Label
    Friend WithEvents ColorFactContado As Label
    Friend WithEvents ColorFactCredito As Label
    Friend WithEvents ColorCargos As Label
    Friend WithEvents ColorNotaDebito As Label
    Friend WithEvents chkChequesDev As CheckBox
    Friend WithEvents chkDevoluciones As CheckBox
    Friend WithEvents chkNotaDebito As CheckBox
    Friend WithEvents chkNotaCredito As CheckBox
    Friend WithEvents chkAbono As CheckBox
    Friend WithEvents chkCargos As CheckBox
    Friend WithEvents chkFacturaContado As CheckBox
    Friend WithEvents chkFacturaCredito As CheckBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LueMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
