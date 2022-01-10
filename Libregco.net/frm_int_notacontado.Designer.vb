<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_int_notacontado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_int_notacontado))
        Me.lblAntesDe = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblSolo = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.btn_Insert = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblAntesDe
        '
        Me.lblAntesDe.AutoSize = True
        Me.lblAntesDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntesDe.Location = New System.Drawing.Point(13, 17)
        Me.lblAntesDe.Name = "lblAntesDe"
        Me.lblAntesDe.Size = New System.Drawing.Size(80, 20)
        Me.lblAntesDe.TabIndex = 0
        Me.lblAntesDe.Text = "Antes del "
        '
        'DtpFecha
        '
        Me.DtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(99, 12)
        Me.DtpFecha.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(128, 26)
        Me.DtpFecha.TabIndex = 0
        '
        'lblSolo
        '
        Me.lblSolo.AutoSize = True
        Me.lblSolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolo.Location = New System.Drawing.Point(21, 52)
        Me.lblSolo.Name = "lblSolo"
        Me.lblSolo.Size = New System.Drawing.Size(72, 20)
        Me.lblSolo.TabIndex = 2
        Me.lblSolo.Text = "Solo por:"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(99, 49)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(128, 26)
        Me.txtMonto.TabIndex = 1
        '
        'btn_Insert
        '
        Me.btn_Insert.Enabled = False
        Me.btn_Insert.Location = New System.Drawing.Point(234, 12)
        Me.btn_Insert.Name = "btn_Insert"
        Me.btn_Insert.Size = New System.Drawing.Size(61, 63)
        Me.btn_Insert.TabIndex = 2
        Me.btn_Insert.Text = "Insertar Nota"
        Me.btn_Insert.UseVisualStyleBackColor = True
        '
        'frm_int_notacontado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 95)
        Me.Controls.Add(Me.btn_Insert)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.lblSolo)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.lblAntesDe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_int_notacontado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nota de contado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAntesDe As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSolo As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents btn_Insert As System.Windows.Forms.Button
End Class
