<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_historial_suplidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_historial_suplidor))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCantCompras = New System.Windows.Forms.Label()
        Me.DgvArticulosComprados = New System.Windows.Forms.DataGridView()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.DgvCompras = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblCantCXP = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DgvCxP = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblCantPagos = New System.Windows.Forms.Label()
        Me.txtTotalPagos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgvPagos = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DgvOrdenes = New System.Windows.Forms.DataGridView()
        Me.lblCantNotas = New System.Windows.Forms.Label()
        Me.lblNombreSuplidor = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvArticulosComprados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DgvCxP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DgvPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DgvOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(4, 42)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(820, 462)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblCantCompras)
        Me.TabPage1.Controls.Add(Me.DgvArticulosComprados)
        Me.TabPage1.Controls.Add(Me.txtTotal)
        Me.TabPage1.Controls.Add(Me.DgvCompras)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(812, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Compras"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(584, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "TOTAL"
        '
        'lblCantCompras
        '
        Me.lblCantCompras.AutoSize = True
        Me.lblCantCompras.Location = New System.Drawing.Point(6, 207)
        Me.lblCantCompras.Name = "lblCantCompras"
        Me.lblCantCompras.Size = New System.Drawing.Size(103, 15)
        Me.lblCantCompras.TabIndex = 6
        Me.lblCantCompras.Text = "Cant. de compras:"
        '
        'DgvArticulosComprados
        '
        Me.DgvArticulosComprados.AllowUserToAddRows = False
        Me.DgvArticulosComprados.AllowUserToDeleteRows = False
        Me.DgvArticulosComprados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvArticulosComprados.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvArticulosComprados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulosComprados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArticulosComprados.Location = New System.Drawing.Point(3, 233)
        Me.DgvArticulosComprados.MultiSelect = False
        Me.DgvArticulosComprados.Name = "DgvArticulosComprados"
        Me.DgvArticulosComprados.ReadOnly = True
        Me.DgvArticulosComprados.RowHeadersWidth = 37
        Me.DgvArticulosComprados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvArticulosComprados.RowTemplate.Height = 20
        Me.DgvArticulosComprados.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulosComprados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulosComprados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulosComprados.Size = New System.Drawing.Size(800, 191)
        Me.DgvArticulosComprados.TabIndex = 3
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotal.Location = New System.Drawing.Point(647, 203)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(159, 23)
        Me.txtTotal.TabIndex = 2
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DgvCompras
        '
        Me.DgvCompras.AllowUserToAddRows = False
        Me.DgvCompras.AllowUserToDeleteRows = False
        Me.DgvCompras.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCompras.Location = New System.Drawing.Point(6, 6)
        Me.DgvCompras.MultiSelect = False
        Me.DgvCompras.Name = "DgvCompras"
        Me.DgvCompras.ReadOnly = True
        Me.DgvCompras.RowHeadersWidth = 37
        Me.DgvCompras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvCompras.RowTemplate.Height = 20
        Me.DgvCompras.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCompras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCompras.Size = New System.Drawing.Size(800, 191)
        Me.DgvCompras.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblCantCXP)
        Me.TabPage2.Controls.Add(Me.txtBalance)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.DgvCxP)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(812, 434)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cuentas por Pagar"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblCantCXP
        '
        Me.lblCantCXP.AutoSize = True
        Me.lblCantCXP.Location = New System.Drawing.Point(5, 409)
        Me.lblCantCXP.Name = "lblCantCXP"
        Me.lblCantCXP.Size = New System.Drawing.Size(152, 15)
        Me.lblCantCXP.TabIndex = 5
        Me.lblCantCXP.Text = "Cant. de cuentas por pagar:"
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Info
        Me.txtBalance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(647, 402)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(159, 26)
        Me.txtBalance.TabIndex = 4
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(584, 405)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TOTAL"
        '
        'DgvCxP
        '
        Me.DgvCxP.AllowUserToAddRows = False
        Me.DgvCxP.AllowUserToDeleteRows = False
        Me.DgvCxP.AllowUserToResizeColumns = False
        Me.DgvCxP.AllowUserToResizeRows = False
        Me.DgvCxP.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvCxP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCxP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCxP.Location = New System.Drawing.Point(6, 6)
        Me.DgvCxP.MultiSelect = False
        Me.DgvCxP.Name = "DgvCxP"
        Me.DgvCxP.ReadOnly = True
        Me.DgvCxP.RowHeadersWidth = 37
        Me.DgvCxP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvCxP.RowTemplate.Height = 20
        Me.DgvCxP.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvCxP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvCxP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCxP.Size = New System.Drawing.Size(800, 390)
        Me.DgvCxP.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lblCantPagos)
        Me.TabPage3.Controls.Add(Me.txtTotalPagos)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.DgvPagos)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(812, 434)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pagos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblCantPagos
        '
        Me.lblCantPagos.AutoSize = True
        Me.lblCantPagos.Location = New System.Drawing.Point(6, 413)
        Me.lblCantPagos.Name = "lblCantPagos"
        Me.lblCantPagos.Size = New System.Drawing.Size(89, 15)
        Me.lblCantPagos.TabIndex = 8
        Me.lblCantPagos.Text = "Cant. de pagos:"
        '
        'txtTotalPagos
        '
        Me.txtTotalPagos.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalPagos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagos.Location = New System.Drawing.Point(647, 402)
        Me.txtTotalPagos.Name = "txtTotalPagos"
        Me.txtTotalPagos.ReadOnly = True
        Me.txtTotalPagos.Size = New System.Drawing.Size(159, 26)
        Me.txtTotalPagos.TabIndex = 7
        Me.txtTotalPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(584, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TOTAL"
        '
        'DgvPagos
        '
        Me.DgvPagos.AllowUserToAddRows = False
        Me.DgvPagos.AllowUserToDeleteRows = False
        Me.DgvPagos.AllowUserToResizeColumns = False
        Me.DgvPagos.AllowUserToResizeRows = False
        Me.DgvPagos.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvPagos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPagos.Location = New System.Drawing.Point(6, 6)
        Me.DgvPagos.MultiSelect = False
        Me.DgvPagos.Name = "DgvPagos"
        Me.DgvPagos.ReadOnly = True
        Me.DgvPagos.RowHeadersWidth = 37
        Me.DgvPagos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPagos.RowTemplate.Height = 20
        Me.DgvPagos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvPagos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPagos.Size = New System.Drawing.Size(800, 390)
        Me.DgvPagos.TabIndex = 5
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DgvOrdenes)
        Me.TabPage4.Controls.Add(Me.lblCantNotas)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(812, 434)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ordenes de compras"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DgvOrdenes
        '
        Me.DgvOrdenes.AllowUserToAddRows = False
        Me.DgvOrdenes.AllowUserToDeleteRows = False
        Me.DgvOrdenes.AllowUserToResizeColumns = False
        Me.DgvOrdenes.AllowUserToResizeRows = False
        Me.DgvOrdenes.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOrdenes.Location = New System.Drawing.Point(6, 6)
        Me.DgvOrdenes.MultiSelect = False
        Me.DgvOrdenes.Name = "DgvOrdenes"
        Me.DgvOrdenes.ReadOnly = True
        Me.DgvOrdenes.RowHeadersWidth = 37
        Me.DgvOrdenes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvOrdenes.RowTemplate.Height = 20
        Me.DgvOrdenes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvOrdenes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvOrdenes.Size = New System.Drawing.Size(800, 406)
        Me.DgvOrdenes.TabIndex = 7
        '
        'lblCantNotas
        '
        Me.lblCantNotas.AutoSize = True
        Me.lblCantNotas.Location = New System.Drawing.Point(6, 416)
        Me.lblCantNotas.Name = "lblCantNotas"
        Me.lblCantNotas.Size = New System.Drawing.Size(142, 15)
        Me.lblCantNotas.TabIndex = 6
        Me.lblCantNotas.Text = "Cant. de notas de pedido:"
        '
        'lblNombreSuplidor
        '
        Me.lblNombreSuplidor.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreSuplidor.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.lblNombreSuplidor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombreSuplidor.Location = New System.Drawing.Point(5, 9)
        Me.lblNombreSuplidor.Name = "lblNombreSuplidor"
        Me.lblNombreSuplidor.Size = New System.Drawing.Size(815, 23)
        Me.lblNombreSuplidor.TabIndex = 1
        Me.lblNombreSuplidor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 504)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(826, 25)
        Me.BarraEstado.TabIndex = 330
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
        'frm_historial_suplidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 529)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.lblNombreSuplidor)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_historial_suplidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "139"
        Me.Text = "Historial del suplidor"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DgvArticulosComprados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DgvCxP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DgvPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.DgvOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lblNombreSuplidor As System.Windows.Forms.Label
    Friend WithEvents DgvCompras As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulosComprados As System.Windows.Forms.DataGridView
    Friend WithEvents DgvCxP As System.Windows.Forms.DataGridView
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgvPagos As System.Windows.Forms.DataGridView
    Friend WithEvents lblCantCompras As System.Windows.Forms.Label
    Friend WithEvents lblCantCXP As System.Windows.Forms.Label
    Friend WithEvents lblCantPagos As System.Windows.Forms.Label
    Friend WithEvents lblCantNotas As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DgvOrdenes As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
