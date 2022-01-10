<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CardBoard
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
        Me.PicImage = New System.Windows.Forms.PictureBox()
        Me.PanelOferta = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ListDescription = New System.Windows.Forms.TextBox()
        Me.ListMarca = New System.Windows.Forms.Label()
        Me.ListModel = New System.Windows.Forms.Label()
        Me.ListPrice = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelOferta.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicImage
        '
        Me.PicImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicImage.Location = New System.Drawing.Point(-1, 5)
        Me.PicImage.Name = "PicImage"
        Me.PicImage.Size = New System.Drawing.Size(65, 65)
        Me.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImage.TabIndex = 1
        Me.PicImage.TabStop = False
        '
        'PanelOferta
        '
        Me.PanelOferta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelOferta.Controls.Add(Me.Label1)
        Me.PanelOferta.Controls.Add(Me.PictureBox1)
        Me.PanelOferta.Location = New System.Drawing.Point(-2, 75)
        Me.PanelOferta.Name = "PanelOferta"
        Me.PanelOferta.Size = New System.Drawing.Size(62, 16)
        Me.PanelOferta.TabIndex = 13
        Me.PanelOferta.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Oferta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.ImageOferta
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'ListDescription
        '
        Me.ListDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListDescription.BackColor = System.Drawing.Color.White
        Me.ListDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListDescription.Enabled = False
        Me.ListDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDescription.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.ListDescription.Location = New System.Drawing.Point(68, 2)
        Me.ListDescription.Multiline = True
        Me.ListDescription.Name = "ListDescription"
        Me.ListDescription.ReadOnly = True
        Me.ListDescription.Size = New System.Drawing.Size(194, 34)
        Me.ListDescription.TabIndex = 14
        Me.ListDescription.TabStop = False
        '
        'ListMarca
        '
        Me.ListMarca.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListMarca.BackColor = System.Drawing.Color.Transparent
        Me.ListMarca.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.ListMarca.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ListMarca.Location = New System.Drawing.Point(68, 36)
        Me.ListMarca.Name = "ListMarca"
        Me.ListMarca.Size = New System.Drawing.Size(105, 15)
        Me.ListMarca.TabIndex = 15
        '
        'ListModel
        '
        Me.ListModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListModel.BackColor = System.Drawing.Color.Transparent
        Me.ListModel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ListModel.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ListModel.Location = New System.Drawing.Point(167, 39)
        Me.ListModel.Name = "ListModel"
        Me.ListModel.Size = New System.Drawing.Size(88, 15)
        Me.ListModel.TabIndex = 16
        Me.ListModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListPrice
        '
        Me.ListPrice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListPrice.AutoSize = True
        Me.ListPrice.BackColor = System.Drawing.Color.Transparent
        Me.ListPrice.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice.Location = New System.Drawing.Point(68, 50)
        Me.ListPrice.Name = "ListPrice"
        Me.ListPrice.Size = New System.Drawing.Size(0, 21)
        Me.ListPrice.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Button1.Location = New System.Drawing.Point(204, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 22)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CardBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ListMarca)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListPrice)
        Me.Controls.Add(Me.ListDescription)
        Me.Controls.Add(Me.PanelOferta)
        Me.Controls.Add(Me.PicImage)
        Me.Controls.Add(Me.ListModel)
        Me.DoubleBuffered = True
        Me.Name = "CardBoard"
        Me.Size = New System.Drawing.Size(265, 91)
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelOferta.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicImage As PictureBox
    Friend WithEvents PanelOferta As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ListDescription As TextBox
    Friend WithEvents ListMarca As Label
    Friend WithEvents ListModel As Label
    Friend WithEvents ListPrice As Label
    Friend WithEvents Button1 As Button
End Class
