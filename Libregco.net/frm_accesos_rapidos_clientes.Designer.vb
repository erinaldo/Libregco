<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_accesos_rapidos_clientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_accesos_rapidos_clientes))
        Me.btnFacturacion = New System.Windows.Forms.Button()
        Me.btnIngresos = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFacturacion
        '
        Me.btnFacturacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFacturacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFacturacion.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturacion.Image = Global.Libregco.My.Resources.Resources.Facturacionx48
        Me.btnFacturacion.Location = New System.Drawing.Point(-5, 78)
        Me.btnFacturacion.Name = "btnFacturacion"
        Me.btnFacturacion.Size = New System.Drawing.Size(109, 72)
        Me.btnFacturacion.TabIndex = 0
        Me.btnFacturacion.Text = "Facturación"
        Me.btnFacturacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnFacturacion.UseVisualStyleBackColor = True
        '
        'btnIngresos
        '
        Me.btnIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIngresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresos.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresos.Image = Global.Libregco.My.Resources.Resources.creditcard_flatx48
        Me.btnIngresos.Location = New System.Drawing.Point(-5, 154)
        Me.btnIngresos.Name = "btnIngresos"
        Me.btnIngresos.Size = New System.Drawing.Size(109, 72)
        Me.btnIngresos.TabIndex = 1
        Me.btnIngresos.Text = "Ingresos"
        Me.btnIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnIngresos.UseVisualStyleBackColor = True
        '
        'btnClientes
        '
        Me.btnClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClientes.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClientes.Image = Global.Libregco.My.Resources.Resources.MenUserx48
        Me.btnClientes.Location = New System.Drawing.Point(-5, 4)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(109, 72)
        Me.btnClientes.TabIndex = 2
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'frm_accesos_rapidos_clientes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(102, 230)
        Me.Controls.Add(Me.btnClientes)
        Me.Controls.Add(Me.btnIngresos)
        Me.Controls.Add(Me.btnFacturacion)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_accesos_rapidos_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Accesos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFacturacion As System.Windows.Forms.Button
    Friend WithEvents btnIngresos As System.Windows.Forms.Button
    Friend WithEvents btnClientes As System.Windows.Forms.Button
End Class
