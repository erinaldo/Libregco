<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListControl
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblItemsCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSelectedValue = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImageViewIco = New System.Windows.Forms.PictureBox()
        Me.ListViewIco = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListHeader = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.flpListBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ImageViewIco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListViewIco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.lblItemsCount)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblSelectedValue)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 23)
        Me.Panel1.TabIndex = 1
        '
        'lblItemsCount
        '
        Me.lblItemsCount.AutoSize = True
        Me.lblItemsCount.Location = New System.Drawing.Point(6, 5)
        Me.lblItemsCount.Name = "lblItemsCount"
        Me.lblItemsCount.Size = New System.Drawing.Size(41, 13)
        Me.lblItemsCount.TabIndex = 0
        Me.lblItemsCount.Text = "Item(s):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(380, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'lblSelectedValue
        '
        Me.lblSelectedValue.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSelectedValue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSelectedValue.Location = New System.Drawing.Point(199, 5)
        Me.lblSelectedValue.Name = "lblSelectedValue"
        Me.lblSelectedValue.Size = New System.Drawing.Size(600, 13)
        Me.lblSelectedValue.TabIndex = 2
        Me.lblSelectedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ImageViewIco)
        Me.Panel2.Controls.Add(Me.ListViewIco)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ListHeader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(802, 26)
        Me.Panel2.TabIndex = 2
        '
        'ImageViewIco
        '
        Me.ImageViewIco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageViewIco.Image = My.Resources.Resources.imageviewgray
        Me.ImageViewIco.Location = New System.Drawing.Point(775, 2)
        Me.ImageViewIco.Name = "ImageViewIco"
        Me.ImageViewIco.Size = New System.Drawing.Size(22, 22)
        Me.ImageViewIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImageViewIco.TabIndex = 1
        Me.ImageViewIco.TabStop = False
        '
        'ListViewIco
        '
        Me.ListViewIco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewIco.Image = My.Resources.Resources.listvieworange
        Me.ListViewIco.Location = New System.Drawing.Point(747, 2)
        Me.ListViewIco.Name = "ListViewIco"
        Me.ListViewIco.Size = New System.Drawing.Size(22, 22)
        Me.ListViewIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ListViewIco.TabIndex = 0
        Me.ListViewIco.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(0, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(802, 1)
        Me.Label2.TabIndex = 2
        '
        'ListHeader
        '
        Me.ListHeader.BackColor = System.Drawing.Color.White
        Me.ListHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListHeader.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ListHeader.Location = New System.Drawing.Point(4, 4)
        Me.ListHeader.Name = "ListHeader"
        Me.ListHeader.Size = New System.Drawing.Size(737, 15)
        Me.ListHeader.TabIndex = 8
        Me.ListHeader.Text = "Listado de Control"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.flpListBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(802, 238)
        Me.Panel3.TabIndex = 3
        '
        'flpListBox
        '
        Me.flpListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpListBox.AutoScroll = True
        Me.flpListBox.BackColor = System.Drawing.Color.White
        Me.flpListBox.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpListBox.Location = New System.Drawing.Point(0, 0)
        Me.flpListBox.Margin = New System.Windows.Forms.Padding(0)
        Me.flpListBox.Name = "flpListBox"
        Me.flpListBox.Size = New System.Drawing.Size(802, 238)
        Me.flpListBox.TabIndex = 0
        Me.flpListBox.WrapContents = False
        '
        'ListControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ListControl"
        Me.Size = New System.Drawing.Size(802, 287)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ImageViewIco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListViewIco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpListBox As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblItemsCount As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSelectedValue As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListViewIco As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ImageViewIco As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ListHeader As Label
End Class
