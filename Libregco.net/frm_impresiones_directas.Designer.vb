<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_impresiones_directas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_impresiones_directas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbxFormato = New System.Windows.Forms.ComboBox()
        Me.VisorDocumento = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbExcel = New System.Windows.Forms.RadioButton()
        Me.rdbPDF = New System.Windows.Forms.RadioButton()
        Me.rdbImpresora = New System.Windows.Forms.RadioButton()
        Me.btnPresentar = New System.Windows.Forms.Button()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDialog = New System.Windows.Forms.PrintDialog()
        Me.PanelDuplicidad = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkOriginal = New System.Windows.Forms.CheckBox()
        Me.chkContabilidad = New System.Windows.Forms.CheckBox()
        Me.chkDespacho = New System.Windows.Forms.CheckBox()
        Me.chkDuplicado = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.PanelDuplicidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 516)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Formato"
        '
        'CbxFormato
        '
        Me.CbxFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbxFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFormato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxFormato.FormattingEnabled = True
        Me.CbxFormato.Location = New System.Drawing.Point(278, 510)
        Me.CbxFormato.Name = "CbxFormato"
        Me.CbxFormato.Size = New System.Drawing.Size(374, 23)
        Me.CbxFormato.TabIndex = 1
        '
        'VisorDocumento
        '
        Me.VisorDocumento.ActiveViewIndex = -1
        Me.VisorDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VisorDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VisorDocumento.Cursor = System.Windows.Forms.Cursors.Default
        Me.VisorDocumento.Location = New System.Drawing.Point(0, 0)
        Me.VisorDocumento.Name = "VisorDocumento"
        Me.VisorDocumento.ShowCloseButton = False
        Me.VisorDocumento.ShowGroupTreeButton = False
        Me.VisorDocumento.ShowLogo = False
        Me.VisorDocumento.ShowParameterPanelButton = False
        Me.VisorDocumento.ShowRefreshButton = False
        Me.VisorDocumento.Size = New System.Drawing.Size(811, 487)
        Me.VisorDocumento.TabIndex = 45
        Me.VisorDocumento.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdbExcel)
        Me.GroupBox1.Controls.Add(Me.rdbPDF)
        Me.GroupBox1.Controls.Add(Me.rdbImpresora)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 501)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(213, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de salida"
        '
        'rdbExcel
        '
        Me.rdbExcel.AutoSize = True
        Me.rdbExcel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbExcel.Location = New System.Drawing.Point(144, 15)
        Me.rdbExcel.Name = "rdbExcel"
        Me.rdbExcel.Size = New System.Drawing.Size(50, 17)
        Me.rdbExcel.TabIndex = 5
        Me.rdbExcel.Text = "Excel"
        Me.rdbExcel.UseVisualStyleBackColor = True
        '
        'rdbPDF
        '
        Me.rdbPDF.AutoSize = True
        Me.rdbPDF.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbPDF.Location = New System.Drawing.Point(92, 15)
        Me.rdbPDF.Name = "rdbPDF"
        Me.rdbPDF.Size = New System.Drawing.Size(44, 17)
        Me.rdbPDF.TabIndex = 4
        Me.rdbPDF.Text = "PDF"
        Me.rdbPDF.UseVisualStyleBackColor = True
        '
        'rdbImpresora
        '
        Me.rdbImpresora.AutoSize = True
        Me.rdbImpresora.Checked = True
        Me.rdbImpresora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.rdbImpresora.Location = New System.Drawing.Point(8, 15)
        Me.rdbImpresora.Name = "rdbImpresora"
        Me.rdbImpresora.Size = New System.Drawing.Size(74, 17)
        Me.rdbImpresora.TabIndex = 3
        Me.rdbImpresora.TabStop = True
        Me.rdbImpresora.Text = "Impresora"
        Me.rdbImpresora.UseVisualStyleBackColor = True
        '
        'btnPresentar
        '
        Me.btnPresentar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPresentar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPresentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPresentar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPresentar.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.btnPresentar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPresentar.Location = New System.Drawing.Point(659, 490)
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(149, 67)
        Me.btnPresentar.TabIndex = 0
        Me.btnPresentar.Text = "Presentar  Ctrl+P"
        Me.btnPresentar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPresentar.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 559)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(811, 25)
        Me.BarraEstado.TabIndex = 254
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
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'PanelDuplicidad
        '
        Me.PanelDuplicidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDuplicidad.BackColor = System.Drawing.SystemColors.Control
        Me.PanelDuplicidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDuplicidad.Controls.Add(Me.Label2)
        Me.PanelDuplicidad.Controls.Add(Me.chkOriginal)
        Me.PanelDuplicidad.Controls.Add(Me.chkContabilidad)
        Me.PanelDuplicidad.Controls.Add(Me.chkDespacho)
        Me.PanelDuplicidad.Controls.Add(Me.chkDuplicado)
        Me.PanelDuplicidad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PanelDuplicidad.Location = New System.Drawing.Point(0, 463)
        Me.PanelDuplicidad.Name = "PanelDuplicidad"
        Me.PanelDuplicidad.Size = New System.Drawing.Size(811, 24)
        Me.PanelDuplicidad.TabIndex = 255
        Me.PanelDuplicidad.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Impresiones activas"
        '
        'chkOriginal
        '
        Me.chkOriginal.AutoSize = True
        Me.chkOriginal.Checked = True
        Me.chkOriginal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOriginal.Location = New System.Drawing.Point(110, 3)
        Me.chkOriginal.Name = "chkOriginal"
        Me.chkOriginal.Size = New System.Drawing.Size(62, 17)
        Me.chkOriginal.TabIndex = 3
        Me.chkOriginal.Text = "Original"
        Me.chkOriginal.UseVisualStyleBackColor = True
        '
        'chkContabilidad
        '
        Me.chkContabilidad.AutoSize = True
        Me.chkContabilidad.Location = New System.Drawing.Point(335, 3)
        Me.chkContabilidad.Name = "chkContabilidad"
        Me.chkContabilidad.Size = New System.Drawing.Size(85, 17)
        Me.chkContabilidad.TabIndex = 2
        Me.chkContabilidad.Text = "Contabilidad"
        Me.chkContabilidad.UseVisualStyleBackColor = True
        '
        'chkDespacho
        '
        Me.chkDespacho.AutoSize = True
        Me.chkDespacho.Location = New System.Drawing.Point(256, 3)
        Me.chkDespacho.Name = "chkDespacho"
        Me.chkDespacho.Size = New System.Drawing.Size(73, 17)
        Me.chkDespacho.TabIndex = 1
        Me.chkDespacho.Text = "Despacho"
        Me.chkDespacho.UseVisualStyleBackColor = True
        '
        'chkDuplicado
        '
        Me.chkDuplicado.AutoSize = True
        Me.chkDuplicado.Location = New System.Drawing.Point(178, 3)
        Me.chkDuplicado.Name = "chkDuplicado"
        Me.chkDuplicado.Size = New System.Drawing.Size(72, 17)
        Me.chkDuplicado.TabIndex = 0
        Me.chkDuplicado.Text = "Duplicado"
        Me.chkDuplicado.UseVisualStyleBackColor = True
        '
        'frm_impresiones_directas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 584)
        Me.Controls.Add(Me.PanelDuplicidad)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbxFormato)
        Me.Controls.Add(Me.btnPresentar)
        Me.Controls.Add(Me.VisorDocumento)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(470, 562)
        Me.Name = "frm_impresiones_directas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impresiones directas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.PanelDuplicidad.ResumeLayout(False)
        Me.PanelDuplicidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbxFormato As System.Windows.Forms.ComboBox
    Friend WithEvents VisorDocumento As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPDF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents btnPresentar As System.Windows.Forms.Button
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PanelDuplicidad As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents chkOriginal As CheckBox
    Friend WithEvents chkContabilidad As CheckBox
    Friend WithEvents chkDespacho As CheckBox
    Friend WithEvents chkDuplicado As CheckBox
End Class
