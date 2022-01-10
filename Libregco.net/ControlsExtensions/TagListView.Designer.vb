<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TagListView
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
        Me.ListSymbol = New System.Windows.Forms.Label()
        Me.ListPrice = New System.Windows.Forms.Label()
        Me.ListEnvio = New System.Windows.Forms.Label()
        Me.ListExistencia = New System.Windows.Forms.Label()
        Me.ListMarca = New System.Windows.Forms.Label()
        Me.ListModel = New System.Windows.Forms.Label()
        Me.ListLastPrice = New System.Windows.Forms.Label()
        Me.ListDescription = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PicImage = New System.Windows.Forms.PictureBox()
        Me.PanelOferta = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelOferta.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListSymbol
        '
        Me.ListSymbol.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListSymbol.AutoSize = True
        Me.ListSymbol.BackColor = System.Drawing.Color.Transparent
        Me.ListSymbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ListSymbol.Location = New System.Drawing.Point(177, 70)
        Me.ListSymbol.Name = "ListSymbol"
        Me.ListSymbol.Size = New System.Drawing.Size(0, 17)
        Me.ListSymbol.TabIndex = 2
        Me.ListSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListPrice
        '
        Me.ListPrice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListPrice.AutoSize = True
        Me.ListPrice.BackColor = System.Drawing.Color.Transparent
        Me.ListPrice.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice.Location = New System.Drawing.Point(193, 62)
        Me.ListPrice.Name = "ListPrice"
        Me.ListPrice.Size = New System.Drawing.Size(0, 30)
        Me.ListPrice.TabIndex = 3
        '
        'ListEnvio
        '
        Me.ListEnvio.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListEnvio.AutoSize = True
        Me.ListEnvio.BackColor = System.Drawing.Color.Transparent
        Me.ListEnvio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ListEnvio.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ListEnvio.Location = New System.Drawing.Point(177, 94)
        Me.ListEnvio.Name = "ListEnvio"
        Me.ListEnvio.Size = New System.Drawing.Size(0, 15)
        Me.ListEnvio.TabIndex = 4
        '
        'ListExistencia
        '
        Me.ListExistencia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListExistencia.AutoSize = True
        Me.ListExistencia.BackColor = System.Drawing.Color.Transparent
        Me.ListExistencia.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ListExistencia.ForeColor = System.Drawing.Color.IndianRed
        Me.ListExistencia.Location = New System.Drawing.Point(177, 113)
        Me.ListExistencia.Name = "ListExistencia"
        Me.ListExistencia.Size = New System.Drawing.Size(0, 13)
        Me.ListExistencia.TabIndex = 5
        '
        'ListMarca
        '
        Me.ListMarca.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListMarca.AutoSize = True
        Me.ListMarca.BackColor = System.Drawing.Color.Transparent
        Me.ListMarca.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListMarca.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ListMarca.Location = New System.Drawing.Point(177, 41)
        Me.ListMarca.Name = "ListMarca"
        Me.ListMarca.Size = New System.Drawing.Size(0, 15)
        Me.ListMarca.TabIndex = 7
        '
        'ListModel
        '
        Me.ListModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListModel.BackColor = System.Drawing.Color.Transparent
        Me.ListModel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ListModel.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ListModel.Location = New System.Drawing.Point(563, 47)
        Me.ListModel.Name = "ListModel"
        Me.ListModel.Size = New System.Drawing.Size(150, 15)
        Me.ListModel.TabIndex = 8
        Me.ListModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListLastPrice
        '
        Me.ListLastPrice.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ListLastPrice.AutoSize = True
        Me.ListLastPrice.BackColor = System.Drawing.Color.Transparent
        Me.ListLastPrice.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListLastPrice.ForeColor = System.Drawing.Color.Gray
        Me.ListLastPrice.Location = New System.Drawing.Point(358, 55)
        Me.ListLastPrice.Name = "ListLastPrice"
        Me.ListLastPrice.Size = New System.Drawing.Size(0, 25)
        Me.ListLastPrice.TabIndex = 9
        Me.ListLastPrice.Visible = False
        '
        'ListDescription
        '
        Me.ListDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListDescription.BackColor = System.Drawing.Color.White
        Me.ListDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListDescription.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDescription.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.ListDescription.Location = New System.Drawing.Point(177, 3)
        Me.ListDescription.Multiline = True
        Me.ListDescription.Name = "ListDescription"
        Me.ListDescription.ReadOnly = True
        Me.ListDescription.Size = New System.Drawing.Size(533, 34)
        Me.ListDescription.TabIndex = 10
        Me.ListDescription.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.ofertaimagen2
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'PicImage
        '
        Me.PicImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PicImage.Location = New System.Drawing.Point(0, 0)
        Me.PicImage.Name = "PicImage"
        Me.PicImage.Size = New System.Drawing.Size(172, 140)
        Me.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicImage.TabIndex = 0
        Me.PicImage.TabStop = False
        '
        'PanelOferta
        '
        Me.PanelOferta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelOferta.Controls.Add(Me.Label1)
        Me.PanelOferta.Controls.Add(Me.PictureBox1)
        Me.PanelOferta.Location = New System.Drawing.Point(630, 113)
        Me.PanelOferta.Name = "PanelOferta"
        Me.PanelOferta.Size = New System.Drawing.Size(84, 16)
        Me.PanelOferta.TabIndex = 12
        Me.PanelOferta.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Oferta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TagListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ListDescription)
        Me.Controls.Add(Me.PanelOferta)
        Me.Controls.Add(Me.ListLastPrice)
        Me.Controls.Add(Me.ListMarca)
        Me.Controls.Add(Me.ListExistencia)
        Me.Controls.Add(Me.ListEnvio)
        Me.Controls.Add(Me.ListPrice)
        Me.Controls.Add(Me.ListSymbol)
        Me.Controls.Add(Me.PicImage)
        Me.Controls.Add(Me.ListModel)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Name = "TagListView"
        Me.Size = New System.Drawing.Size(716, 140)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelOferta.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicImage As PictureBox
    Friend WithEvents ListSymbol As Label
    Friend WithEvents ListPrice As Label
    Friend WithEvents ListEnvio As Label
    Friend WithEvents ListExistencia As Label
    Friend WithEvents ListMarca As Label
    Friend WithEvents ListModel As Label
    Friend WithEvents ListLastPrice As Label
    Friend WithEvents ListDescription As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PanelOferta As Panel
    Friend WithEvents Label1 As Label
End Class
