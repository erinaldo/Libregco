<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cartas_modelos_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cartas_modelos_clientes))
        Me.DgvReportes = New System.Windows.Forms.DataGridView()
        Me.IDReporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicSalida = New System.Windows.Forms.PictureBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.rdbPresentacion = New System.Windows.Forms.RadioButton()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.LtCliente = New System.Windows.Forms.ListBox()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        CType(Me.DgvReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvReportes
        '
        Me.DgvReportes.AllowUserToAddRows = False
        Me.DgvReportes.AllowUserToDeleteRows = False
        Me.DgvReportes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvReportes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDReporte, Me.Descripcion, Me.Ruta})
        Me.DgvReportes.Location = New System.Drawing.Point(12, 221)
        Me.DgvReportes.Name = "DgvReportes"
        Me.DgvReportes.ReadOnly = True
        Me.DgvReportes.Size = New System.Drawing.Size(700, 201)
        Me.DgvReportes.TabIndex = 340
        '
        'IDReporte
        '
        Me.IDReporte.HeaderText = "ID"
        Me.IDReporte.Name = "IDReporte"
        Me.IDReporte.ReadOnly = True
        Me.IDReporte.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 658
        '
        'Ruta
        '
        Me.Ruta.HeaderText = "Ruta"
        Me.Ruta.Name = "Ruta"
        Me.Ruta.ReadOnly = True
        Me.Ruta.Visible = False
        Me.Ruta.Width = 600
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 428)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(725, 109)
        Me.Panel1.TabIndex = 348
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBuscar, Me.btnLimpiar, Me.btnCerrar})
        Me.MenuStrip1.Location = New System.Drawing.Point(465, 6)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(260, 95)
        Me.MenuStrip1.TabIndex = 193
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 91)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(84, 91)
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Libregco.My.Resources.Resources.Home_x72
        Me.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(84, 91)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicSalida)
        Me.GroupBox1.Controls.Add(Me.rdbExcel)
        Me.GroupBox1.Controls.Add(Me.rdbPDF)
        Me.GroupBox1.Controls.Add(Me.rdbImpresora)
        Me.GroupBox1.Controls.Add(Me.rdbPresentacion)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 97)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el Tipo de Salida"
        '
        'PicSalida
        '
        Me.PicSalida.Location = New System.Drawing.Point(107, 20)
        Me.PicSalida.Name = "PicSalida"
        Me.PicSalida.Size = New System.Drawing.Size(75, 71)
        Me.PicSalida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSalida.TabIndex = 4
        Me.PicSalida.TabStop = False
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(11, 75)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(51, 19)
        Me.rdbExcel.TabIndex = 3
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(11, 55)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(46, 19)
        Me.rdbPDF.TabIndex = 2
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(11, 35)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(78, 19)
        Me.rdbImpresora.TabIndex = 1
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'rdbPresentacion
        '
        Me.rdbPresentacion.AutoSize = True
        Me.rdbPresentacion.Checked = True
        Me.rdbPresentacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPresentacion.Location = New System.Drawing.Point(11, 15)
        Me.rdbPresentacion.Name = "rdbPresentacion"
        Me.rdbPresentacion.Size = New System.Drawing.Size(93, 19)
        Me.rdbPresentacion.TabIndex = 0
        Me.rdbPresentacion.TabStop = True
        Me.rdbPresentacion.Text = "Presentación"
        Me.rdbPresentacion.UseVisualStyleBackColor = True
        '
        'btnCliente
        '
        Me.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(311, 25)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(23, 23)
        Me.btnCliente.TabIndex = 350
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 35)
        Me.Label1.TabIndex = 351
        Me.Label1.Text = "Escriba el código del cliente para realizar la correspondencia"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(333, 25)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(379, 23)
        Me.txtCliente.TabIndex = 352
        '
        'txtIDCliente
        '
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.Location = New System.Drawing.Point(210, 25)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.Size = New System.Drawing.Size(102, 23)
        Me.txtIDCliente.TabIndex = 349
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LtCliente
        '
        Me.LtCliente.FormattingEnabled = True
        Me.LtCliente.ItemHeight = 15
        Me.LtCliente.Location = New System.Drawing.Point(12, 61)
        Me.LtCliente.Name = "LtCliente"
        Me.LtCliente.Size = New System.Drawing.Size(544, 154)
        Me.LtCliente.TabIndex = 353
        '
        'PicFoto
        '
        Me.PicFoto.Location = New System.Drawing.Point(562, 61)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(154, 154)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicFoto.TabIndex = 354
        Me.PicFoto.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 540)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(724, 25)
        Me.BarraEstado.TabIndex = 355
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
        'frm_cartas_modelos_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 565)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicFoto)
        Me.Controls.Add(Me.LtCliente)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.txtIDCliente)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgvReportes)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_cartas_modelos_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "258"
        Me.Text = "Cartas y correspondencia sobre clientes"
        CType(Me.DgvReportes,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.PicSalida,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PicFoto,System.ComponentModel.ISupportInitialize).EndInit
        Me.BarraEstado.ResumeLayout(false)
        Me.BarraEstado.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents DgvReportes As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicSalida As System.Windows.Forms.PictureBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPresentacion As System.Windows.Forms.RadioButton
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents LtCliente As System.Windows.Forms.ListBox
    Friend WithEvents PicFoto As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IDReporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ruta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
