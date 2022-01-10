<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_ncf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_ncf))
        Me.DgvNCF = New System.Windows.Forms.DataGridView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicMinLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.cbxEsctructuracion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvNCFArea = New System.Windows.Forms.DataGridView()
        Me.CbxEquipos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DgvNCF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.DgvNCFArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvNCF
        '
        Me.DgvNCF.AllowUserToAddRows = False
        Me.DgvNCF.AllowUserToDeleteRows = False
        Me.DgvNCF.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DgvNCF.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNCF.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvNCF.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvNCF.Location = New System.Drawing.Point(7, 130)
        Me.DgvNCF.MultiSelect = False
        Me.DgvNCF.Name = "DgvNCF"
        Me.DgvNCF.RowHeadersWidth = 20
        Me.DgvNCF.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNCF.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DgvNCF.RowTemplate.DividerHeight = 2
        Me.DgvNCF.RowTemplate.Height = 32
        Me.DgvNCF.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNCF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNCF.Size = New System.Drawing.Size(893, 311)
        Me.DgvNCF.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(746, 445)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(151, 57)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 7)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicMinLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 505)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(909, 25)
        Me.BarraEstado.TabIndex = 272
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicMinLogo
        '
        Me.PicMinLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicMinLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicMinLogo.Name = "PicMinLogo"
        Me.PicMinLogo.Size = New System.Drawing.Size(23, 22)
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
        'cbxEsctructuracion
        '
        Me.cbxEsctructuracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEsctructuracion.Enabled = False
        Me.cbxEsctructuracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEsctructuracion.FormattingEnabled = True
        Me.cbxEsctructuracion.Items.AddRange(New Object() {"Método 1: Estructuración Generalizada", "Método 2: Estructuración por Punto de Venta", "Método 3: Normativa 2018 Generalizada (Nueva Serie)"})
        Me.cbxEsctructuracion.Location = New System.Drawing.Point(448, 42)
        Me.cbxEsctructuracion.Name = "cbxEsctructuracion"
        Me.cbxEsctructuracion.Size = New System.Drawing.Size(449, 21)
        Me.cbxEsctructuracion.TabIndex = 273
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(445, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 274
        Me.Label1.Text = "Tipo de Estructuración"
        '
        'DgvNCFArea
        '
        Me.DgvNCFArea.AllowUserToAddRows = False
        Me.DgvNCFArea.AllowUserToDeleteRows = False
        Me.DgvNCFArea.AllowUserToResizeColumns = False
        Me.DgvNCFArea.AllowUserToResizeRows = False
        Me.DgvNCFArea.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DgvNCFArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvNCFArea.ColumnHeadersHeight = 50
        Me.DgvNCFArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNCFArea.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvNCFArea.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvNCFArea.Location = New System.Drawing.Point(7, 130)
        Me.DgvNCFArea.MultiSelect = False
        Me.DgvNCFArea.Name = "DgvNCFArea"
        Me.DgvNCFArea.RowHeadersWidth = 20
        Me.DgvNCFArea.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNCFArea.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.DgvNCFArea.RowTemplate.DividerHeight = 2
        Me.DgvNCFArea.RowTemplate.Height = 32
        Me.DgvNCFArea.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNCFArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNCFArea.Size = New System.Drawing.Size(893, 311)
        Me.DgvNCFArea.TabIndex = 275
        '
        'CbxEquipos
        '
        Me.CbxEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxEquipos.FormattingEnabled = True
        Me.CbxEquipos.Location = New System.Drawing.Point(113, 103)
        Me.CbxEquipos.Name = "CbxEquipos"
        Me.CbxEquipos.Size = New System.Drawing.Size(276, 21)
        Me.CbxEquipos.TabIndex = 276
        Me.CbxEquipos.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = "Equipos Autorizados:"
        Me.Label2.Visible = False
        '
        'frm_mant_ncf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 530)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CbxEquipos)
        Me.Controls.Add(Me.DgvNCFArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxEsctructuracion)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.DgvNCF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_ncf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento de secuencias de comprobantes"
        CType(Me.DgvNCF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.DgvNCFArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvNCF As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicMinLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cbxEsctructuracion As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvNCFArea As System.Windows.Forms.DataGridView
    Friend WithEvents CbxEquipos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
