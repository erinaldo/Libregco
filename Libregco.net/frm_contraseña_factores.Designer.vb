<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_contraseña_factores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_contraseña_factores))
        Me.lblMensajeFactores = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.PicEmpleado = New System.Windows.Forms.PictureBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPasswordFactor = New Libregco.Watermark()
        Me.txtPasswordFactorRep = New Libregco.Watermark()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMensajeFactores
        '
        Me.lblMensajeFactores.AutoSize = True
        Me.lblMensajeFactores.BackColor = System.Drawing.Color.Transparent
        Me.lblMensajeFactores.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMensajeFactores.Location = New System.Drawing.Point(15, 99)
        Me.lblMensajeFactores.Name = "lblMensajeFactores"
        Me.lblMensajeFactores.Size = New System.Drawing.Size(0, 15)
        Me.lblMensajeFactores.TabIndex = 141
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label41.Location = New System.Drawing.Point(75, 61)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(152, 15)
        Me.Label41.TabIndex = 139
        Me.Label41.Text = "Repita la clave de 4 factores"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label40.Location = New System.Drawing.Point(169, 20)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(124, 15)
        Me.Label40.TabIndex = 138
        Me.Label40.Text = "Sólo valores númericos"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label39.Location = New System.Drawing.Point(18, 20)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(137, 15)
        Me.Label39.TabIndex = 136
        Me.Label39.Text = "Contraseña de 4 factores"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label38.Location = New System.Drawing.Point(12, 39)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(275, 2)
        Me.Label38.TabIndex = 135
        '
        'PicEmpleado
        '
        Me.PicEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.PicEmpleado.Location = New System.Drawing.Point(215, 24)
        Me.PicEmpleado.Name = "PicEmpleado"
        Me.PicEmpleado.Size = New System.Drawing.Size(130, 130)
        Me.PicEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEmpleado.TabIndex = 142
        Me.PicEmpleado.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI Light", 14.0!)
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(13, 166)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(536, 32)
        Me.lblNombre.TabIndex = 143
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(18, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 53)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(17, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(204, 21)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Te tenemos buenas noticias!"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 611)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(560, 25)
        Me.BarraEstado.TabIndex = 413
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(382, 537)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 46)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Continuar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label30.Location = New System.Drawing.Point(18, 286)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(523, 150)
        Me.Label30.TabIndex = 417
        Me.Label30.Text = resources.GetString("Label30.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label39)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.txtPasswordFactor)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.txtPasswordFactorRep)
        Me.GroupBox1.Controls.Add(Me.lblMensajeFactores)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 418)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtPasswordFactor
        '
        Me.txtPasswordFactor.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtPasswordFactor.Location = New System.Drawing.Point(14, 50)
        Me.txtPasswordFactor.MaxLength = 4
        Me.txtPasswordFactor.Name = "txtPasswordFactor"
        Me.txtPasswordFactor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordFactor.Size = New System.Drawing.Size(54, 43)
        Me.txtPasswordFactor.TabIndex = 0
        Me.txtPasswordFactor.WatermarkColor = System.Drawing.Color.DimGray
        Me.txtPasswordFactor.WatermarkText = ""
        '
        'txtPasswordFactorRep
        '
        Me.txtPasswordFactorRep.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtPasswordFactorRep.Location = New System.Drawing.Point(233, 50)
        Me.txtPasswordFactorRep.MaxLength = 4
        Me.txtPasswordFactorRep.Name = "txtPasswordFactorRep"
        Me.txtPasswordFactorRep.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordFactorRep.Size = New System.Drawing.Size(54, 43)
        Me.txtPasswordFactorRep.TabIndex = 1
        Me.txtPasswordFactorRep.WatermarkColor = System.Drawing.Color.DimGray
        Me.txtPasswordFactorRep.WatermarkText = ""
        '
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'frm_contraseña_factores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 636)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicEmpleado)
        Me.Controls.Add(Me.lblNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_contraseña_factores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Contraseña de factores"
        CType(Me.PicEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblMensajeFactores As System.Windows.Forms.Label
    Friend WithEvents txtPasswordFactorRep As Libregco.Watermark
    Private WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordFactor As Libregco.Watermark
    Private WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents PicEmpleado As System.Windows.Forms.PictureBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Fecha As System.Windows.Forms.Timer
End Class
