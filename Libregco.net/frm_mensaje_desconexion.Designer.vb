<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mensaje_desconexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mensaje_desconexion))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblIcoConnection = New System.Windows.Forms.Label()
        Me.lblConnection = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Libregco.My.Resources.Resources.Disc
        Me.PictureBox1.Location = New System.Drawing.Point(-7, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(873, 429)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(56, 324)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(748, 37)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "No se ha encontrado ningún tipo de conexión a la base de datos!"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 380)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(835, 81)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(639, 464)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 36)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Eliminar registro de conexión a servidor"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblIcoConnection
        '
        Me.lblIcoConnection.BackColor = System.Drawing.Color.Transparent
        Me.lblIcoConnection.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblIcoConnection.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIcoConnection.Image = Global.Libregco.My.Resources.Resources.Beep_Signal_24
        Me.lblIcoConnection.Location = New System.Drawing.Point(12, 479)
        Me.lblIcoConnection.Name = "lblIcoConnection"
        Me.lblIcoConnection.Size = New System.Drawing.Size(24, 24)
        Me.lblIcoConnection.TabIndex = 94
        '
        'lblConnection
        '
        Me.lblConnection.AutoSize = True
        Me.lblConnection.BackColor = System.Drawing.Color.Transparent
        Me.lblConnection.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblConnection.ForeColor = System.Drawing.Color.Black
        Me.lblConnection.Location = New System.Drawing.Point(39, 484)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(99, 13)
        Me.lblConnection.TabIndex = 93
        Me.lblConnection.Text = "CONEXIÓN LOCAL"
        Me.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_mensaje_desconexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(859, 512)
        Me.Controls.Add(Me.lblIcoConnection)
        Me.Controls.Add(Me.lblConnection)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mensaje_desconexion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "No hay comunicación con el servidor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblIcoConnection As Label
    Friend WithEvents lblConnection As Label
End Class
