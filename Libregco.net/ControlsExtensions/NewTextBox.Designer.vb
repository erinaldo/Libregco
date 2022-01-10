<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewTextbox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.PanelMessage = New System.Windows.Forms.Panel()
        Me.ShapedPanel1 = New Libregco.ShapedPanel()
        Me.ShapedPanel2 = New Libregco.ShapedPanel()
        Me.btnClear = New System.Windows.Forms.PictureBox()
        Me.Watermark1 = New Libregco.Watermark()
        Me.PicImage = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.ShapedPanel1.SuspendLayout()
        Me.ShapedPanel2.SuspendLayout()
        CType(Me.btnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.PanelMessage)
        Me.Panel2.Controls.Add(Me.ShapedPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 51)
        Me.Panel2.TabIndex = 2
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(-2, 32)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(131, 15)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "This is the real message"
        '
        'PanelMessage
        '
        Me.PanelMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelMessage.BackColor = System.Drawing.Color.Red
        Me.PanelMessage.ForeColor = System.Drawing.Color.DodgerBlue
        Me.PanelMessage.Location = New System.Drawing.Point(0, 47)
        Me.PanelMessage.Name = "PanelMessage"
        Me.PanelMessage.Size = New System.Drawing.Size(270, 1)
        Me.PanelMessage.TabIndex = 5
        '
        'ShapedPanel1
        '
        Me.ShapedPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.ShapedPanel1.BorderColor = System.Drawing.Color.Transparent
        Me.ShapedPanel1.Controls.Add(Me.ShapedPanel2)
        Me.ShapedPanel1.Controls.Add(Me.PicImage)
        Me.ShapedPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ShapedPanel1.Edge = 5
        Me.ShapedPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ShapedPanel1.Name = "ShapedPanel1"
        Me.ShapedPanel1.Size = New System.Drawing.Size(300, 30)
        Me.ShapedPanel1.TabIndex = 3
        '
        'ShapedPanel2
        '
        Me.ShapedPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShapedPanel2.BackColor = System.Drawing.Color.White
        Me.ShapedPanel2.BorderColor = System.Drawing.Color.White
        Me.ShapedPanel2.Controls.Add(Me.btnClear)
        Me.ShapedPanel2.Controls.Add(Me.Watermark1)
        Me.ShapedPanel2.Edge = 8
        Me.ShapedPanel2.Location = New System.Drawing.Point(39, 1)
        Me.ShapedPanel2.Name = "ShapedPanel2"
        Me.ShapedPanel2.Size = New System.Drawing.Size(260, 28)
        Me.ShapedPanel2.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnClear.Image = Global.Libregco.My.Resources.Resources.icons8_cancel_24
        Me.btnClear.Location = New System.Drawing.Point(234, 3)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(21, 21)
        Me.btnClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnClear.TabIndex = 1
        Me.btnClear.TabStop = False
        Me.btnClear.Visible = False
        '
        'Watermark1
        '
        Me.Watermark1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Watermark1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Watermark1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Watermark1.ForeColor = System.Drawing.Color.Black
        Me.Watermark1.Location = New System.Drawing.Point(3, 3)
        Me.Watermark1.Name = "Watermark1"
        Me.Watermark1.ShortcutsEnabled = False
        Me.Watermark1.Size = New System.Drawing.Size(254, 20)
        Me.Watermark1.TabIndex = 0
        Me.Watermark1.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark1.WatermarkText = ""
        '
        'PicImage
        '
        Me.PicImage.BackColor = System.Drawing.Color.Transparent
        Me.PicImage.Location = New System.Drawing.Point(7, 3)
        Me.PicImage.Name = "PicImage"
        Me.PicImage.Size = New System.Drawing.Size(24, 24)
        Me.PicImage.TabIndex = 1
        Me.PicImage.TabStop = False
        '
        'NewTextbox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.Name = "NewTextbox"
        Me.Size = New System.Drawing.Size(300, 51)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ShapedPanel1.ResumeLayout(False)
        Me.ShapedPanel2.ResumeLayout(False)
        Me.ShapedPanel2.PerformLayout()
        CType(Me.btnClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Watermark1 As Watermark
    Friend WithEvents PicImage As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ShapedPanel1 As ShapedPanel
    Friend WithEvents ShapedPanel2 As ShapedPanel
    Friend WithEvents btnClear As PictureBox
    Friend WithEvents lblMessage As Label
    Friend WithEvents PanelMessage As Panel
End Class
