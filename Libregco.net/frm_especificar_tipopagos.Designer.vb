<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_especificar_tipopagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_especificar_tipopagos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbMixto = New System.Windows.Forms.RadioButton()
        Me.rdbTarjeta = New System.Windows.Forms.RadioButton()
        Me.rdbEfectivo = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(373, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Se ha establecido el control de tipo de pagos para establecer los descuentos"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdbMixto)
        Me.Panel1.Controls.Add(Me.rdbTarjeta)
        Me.Panel1.Controls.Add(Me.rdbEfectivo)
        Me.Panel1.Location = New System.Drawing.Point(13, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(771, 136)
        Me.Panel1.TabIndex = 0
        Me.Panel1.TabStop = True
        '
        'rdbMixto
        '
        Me.rdbMixto.Checked = True
        Me.rdbMixto.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.rdbMixto.ForeColor = System.Drawing.Color.Gray
        Me.rdbMixto.Image = Global.Libregco.My.Resources.Resources.Facturacion_x90
        Me.rdbMixto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbMixto.Location = New System.Drawing.Point(27, 14)
        Me.rdbMixto.Name = "rdbMixto"
        Me.rdbMixto.Size = New System.Drawing.Size(263, 106)
        Me.rdbMixto.TabIndex = 1
        Me.rdbMixto.TabStop = True
        Me.rdbMixto.Text = "Mixto / Otros"
        Me.rdbMixto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbMixto.UseVisualStyleBackColor = True
        '
        'rdbTarjeta
        '
        Me.rdbTarjeta.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.rdbTarjeta.ForeColor = System.Drawing.Color.Gray
        Me.rdbTarjeta.Image = Global.Libregco.My.Resources.Resources.creditcardx90gray
        Me.rdbTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbTarjeta.Location = New System.Drawing.Point(531, 14)
        Me.rdbTarjeta.Name = "rdbTarjeta"
        Me.rdbTarjeta.Size = New System.Drawing.Size(209, 106)
        Me.rdbTarjeta.TabIndex = 3
        Me.rdbTarjeta.Text = "Tarjeta"
        Me.rdbTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbTarjeta.UseVisualStyleBackColor = True
        '
        'rdbEfectivo
        '
        Me.rdbEfectivo.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbEfectivo.ForeColor = System.Drawing.Color.Gray
        Me.rdbEfectivo.Image = Global.Libregco.My.Resources.Resources.dollar_iconx90gray
        Me.rdbEfectivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbEfectivo.Location = New System.Drawing.Point(303, 14)
        Me.rdbEfectivo.Name = "rdbEfectivo"
        Me.rdbEfectivo.Size = New System.Drawing.Size(215, 106)
        Me.rdbEfectivo.TabIndex = 2
        Me.rdbEfectivo.Text = "Efectivo"
        Me.rdbEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbEfectivo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(292, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(213, 56)
        Me.Button1.TabIndex = 4
        Me.Button1.TabStop = False
        Me.Button1.Text = "Seleccionar método de pago"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 19)
        Me.Label2.TabIndex = 340
        Me.Label2.Text = "Cuál es el método de pago a utilizar?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(11, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(450, 19)
        Me.Label3.TabIndex = 341
        Me.Label3.Text = "POR FAVOR PREGUNTE EL TIPO DE PAGO AL CLIENTE"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'frm_especificar_tipopagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 315)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_especificar_tipopagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Control de tipo de pago"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdbTarjeta As RadioButton
    Friend WithEvents rdbEfectivo As RadioButton
    Friend WithEvents rdbMixto As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
End Class
