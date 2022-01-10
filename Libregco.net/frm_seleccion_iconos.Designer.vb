<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_seleccion_iconos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_seleccion_iconos))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbx256 = New System.Windows.Forms.RadioButton()
        Me.rdbx72 = New System.Windows.Forms.RadioButton()
        Me.rdbx48 = New System.Windows.Forms.RadioButton()
        Me.rdbx32 = New System.Windows.Forms.RadioButton()
        Me.rdbx20 = New System.Windows.Forms.RadioButton()
        Me.GaleriaImagenes1 = New Libregco.GaleriaImagenes()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(663, 567)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(207, 48)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Seleccionar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdbx256)
        Me.GroupBox1.Controls.Add(Me.rdbx72)
        Me.GroupBox1.Controls.Add(Me.rdbx48)
        Me.GroupBox1.Controls.Add(Me.rdbx32)
        Me.GroupBox1.Controls.Add(Me.rdbx20)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 568)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 43)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Píxeles"
        '
        'rdbx256
        '
        Me.rdbx256.AutoSize = True
        Me.rdbx256.Location = New System.Drawing.Point(198, 15)
        Me.rdbx256.Name = "rdbx256"
        Me.rdbx256.Size = New System.Drawing.Size(48, 17)
        Me.rdbx256.TabIndex = 5
        Me.rdbx256.Text = "x256"
        Me.rdbx256.UseVisualStyleBackColor = True
        '
        'rdbx72
        '
        Me.rdbx72.AutoSize = True
        Me.rdbx72.Checked = True
        Me.rdbx72.Location = New System.Drawing.Point(150, 15)
        Me.rdbx72.Name = "rdbx72"
        Me.rdbx72.Size = New System.Drawing.Size(42, 17)
        Me.rdbx72.TabIndex = 4
        Me.rdbx72.TabStop = True
        Me.rdbx72.Text = "x72"
        Me.rdbx72.UseVisualStyleBackColor = True
        '
        'rdbx48
        '
        Me.rdbx48.AutoSize = True
        Me.rdbx48.Location = New System.Drawing.Point(102, 15)
        Me.rdbx48.Name = "rdbx48"
        Me.rdbx48.Size = New System.Drawing.Size(42, 17)
        Me.rdbx48.TabIndex = 3
        Me.rdbx48.Text = "x48"
        Me.rdbx48.UseVisualStyleBackColor = True
        '
        'rdbx32
        '
        Me.rdbx32.AutoSize = True
        Me.rdbx32.Location = New System.Drawing.Point(54, 15)
        Me.rdbx32.Name = "rdbx32"
        Me.rdbx32.Size = New System.Drawing.Size(42, 17)
        Me.rdbx32.TabIndex = 2
        Me.rdbx32.Text = "x32"
        Me.rdbx32.UseVisualStyleBackColor = True
        '
        'rdbx20
        '
        Me.rdbx20.AutoSize = True
        Me.rdbx20.Location = New System.Drawing.Point(6, 15)
        Me.rdbx20.Name = "rdbx20"
        Me.rdbx20.Size = New System.Drawing.Size(42, 17)
        Me.rdbx20.TabIndex = 1
        Me.rdbx20.Text = "x20"
        Me.rdbx20.UseVisualStyleBackColor = True
        '
        'GaleriaImagenes1
        '
        Me.GaleriaImagenes1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GaleriaImagenes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GaleriaImagenes1.Directorypath = Nothing
        Me.GaleriaImagenes1.Location = New System.Drawing.Point(6, 8)
        Me.GaleriaImagenes1.Name = "GaleriaImagenes1"
        Me.GaleriaImagenes1.SelectedPath = Nothing
        Me.GaleriaImagenes1.Size = New System.Drawing.Size(864, 553)
        Me.GaleriaImagenes1.TabIndex = 0
        '
        'frm_seleccion_iconos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 623)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GaleriaImagenes1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_seleccion_iconos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selecciona el ícono"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GaleriaImagenes1 As Libregco.GaleriaImagenes
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbx256 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbx72 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbx48 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbx32 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbx20 As System.Windows.Forms.RadioButton
End Class
