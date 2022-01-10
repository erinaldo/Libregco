<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_alerta_impresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_alerta_impresion))
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblImpresoraElegida = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblImpresoraRecomendado = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 24)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(700, 23)
        Me.SeparatorControl1.TabIndex = 344
        Me.SeparatorControl1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(390, 13)
        Me.Label2.TabIndex = 343
        Me.Label2.Text = "Se ha detectado que desea imprimir en una impresora diferente a la prestablecida" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 300)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(700, 25)
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
        'GroupControl2
        '
        Me.GroupControl2.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.uncheckedx32
        Me.GroupControl2.Controls.Add(Me.SimpleButton2)
        Me.GroupControl2.Controls.Add(Me.lblImpresoraElegida)
        Me.GroupControl2.Location = New System.Drawing.Point(362, 53)
        Me.GroupControl2.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(320, 206)
        Me.GroupControl2.TabIndex = 347
        Me.GroupControl2.Text = "Impresora seleccionada"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Enabled = False
        Me.SimpleButton2.Location = New System.Drawing.Point(19, 112)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(280, 67)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "Seleccionar impresora"
        '
        'lblImpresoraElegida
        '
        Me.lblImpresoraElegida.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblImpresoraElegida.Location = New System.Drawing.Point(19, 51)
        Me.lblImpresoraElegida.Name = "lblImpresoraElegida"
        Me.lblImpresoraElegida.Size = New System.Drawing.Size(285, 45)
        Me.lblImpresoraElegida.TabIndex = 1
        Me.lblImpresoraElegida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.lblImpresoraRecomendado)
        Me.GroupControl1.Location = New System.Drawing.Point(19, 53)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(320, 206)
        Me.GroupControl1.TabIndex = 346
        Me.GroupControl1.Text = "Impresora pre-establecida"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Enabled = False
        Me.SimpleButton1.Location = New System.Drawing.Point(21, 112)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(280, 67)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Seleccionar impresora"
        '
        'lblImpresoraRecomendado
        '
        Me.lblImpresoraRecomendado.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblImpresoraRecomendado.Location = New System.Drawing.Point(21, 51)
        Me.lblImpresoraRecomendado.Name = "lblImpresoraRecomendado"
        Me.lblImpresoraRecomendado.Size = New System.Drawing.Size(285, 45)
        Me.lblImpresoraRecomendado.TabIndex = 0
        Me.lblImpresoraRecomendado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 353
        Me.Label1.Text = "El tiempo de espera es de "
        '
        'frm_alerta_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 325)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_alerta_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALERTA de impresión"
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label2 As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblImpresoraElegida As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblImpresoraRecomendado As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
End Class
