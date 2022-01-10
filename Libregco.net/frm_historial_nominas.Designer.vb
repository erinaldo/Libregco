<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_historial_nominas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_historial_nominas))
        Me.DgvDetalleNominas = New System.Windows.Forms.DataGridView()
        Me.DgvNominas = New System.Windows.Forms.DataGridView()
        Me.lblBruto = New System.Windows.Forms.Label()
        Me.lblDeducciones = New System.Windows.Forms.Label()
        Me.lblNeto = New System.Windows.Forms.Label()
        Me.lblCorrientes = New System.Windows.Forms.Label()
        CType(Me.DgvDetalleNominas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvNominas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvDetalleNominas
        '
        Me.DgvDetalleNominas.AllowUserToAddRows = False
        Me.DgvDetalleNominas.AllowUserToDeleteRows = False
        Me.DgvDetalleNominas.AllowUserToResizeColumns = False
        Me.DgvDetalleNominas.AllowUserToResizeRows = False
        Me.DgvDetalleNominas.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvDetalleNominas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvDetalleNominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalleNominas.Location = New System.Drawing.Point(-1, 293)
        Me.DgvDetalleNominas.MultiSelect = False
        Me.DgvDetalleNominas.Name = "DgvDetalleNominas"
        Me.DgvDetalleNominas.ReadOnly = True
        Me.DgvDetalleNominas.RowHeadersWidth = 37
        Me.DgvDetalleNominas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvDetalleNominas.RowTemplate.Height = 20
        Me.DgvDetalleNominas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetalleNominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalleNominas.Size = New System.Drawing.Size(830, 199)
        Me.DgvDetalleNominas.TabIndex = 5
        '
        'DgvNominas
        '
        Me.DgvNominas.AllowUserToAddRows = False
        Me.DgvNominas.AllowUserToDeleteRows = False
        Me.DgvNominas.AllowUserToResizeColumns = False
        Me.DgvNominas.AllowUserToResizeRows = False
        Me.DgvNominas.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DgvNominas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvNominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNominas.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvNominas.Location = New System.Drawing.Point(-1, 2)
        Me.DgvNominas.MultiSelect = False
        Me.DgvNominas.Name = "DgvNominas"
        Me.DgvNominas.ReadOnly = True
        Me.DgvNominas.RowHeadersWidth = 37
        Me.DgvNominas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNominas.RowTemplate.Height = 25
        Me.DgvNominas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvNominas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvNominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvNominas.Size = New System.Drawing.Size(830, 271)
        Me.DgvNominas.TabIndex = 4
        '
        'lblBruto
        '
        Me.lblBruto.AutoSize = True
        Me.lblBruto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBruto.Location = New System.Drawing.Point(174, 274)
        Me.lblBruto.Name = "lblBruto"
        Me.lblBruto.Size = New System.Drawing.Size(39, 15)
        Me.lblBruto.TabIndex = 6
        Me.lblBruto.Text = "Bruto:"
        '
        'lblDeducciones
        '
        Me.lblDeducciones.AutoSize = True
        Me.lblDeducciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDeducciones.Location = New System.Drawing.Point(324, 274)
        Me.lblDeducciones.Name = "lblDeducciones"
        Me.lblDeducciones.Size = New System.Drawing.Size(78, 15)
        Me.lblDeducciones.TabIndex = 7
        Me.lblDeducciones.Text = "Deducciones:"
        '
        'lblNeto
        '
        Me.lblNeto.AutoSize = True
        Me.lblNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNeto.Location = New System.Drawing.Point(666, 274)
        Me.lblNeto.Name = "lblNeto"
        Me.lblNeto.Size = New System.Drawing.Size(65, 15)
        Me.lblNeto.TabIndex = 8
        Me.lblNeto.Text = "Total Neto:"
        '
        'lblCorrientes
        '
        Me.lblCorrientes.AutoSize = True
        Me.lblCorrientes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCorrientes.Location = New System.Drawing.Point(501, 274)
        Me.lblCorrientes.Name = "lblCorrientes"
        Me.lblCorrientes.Size = New System.Drawing.Size(64, 15)
        Me.lblCorrientes.TabIndex = 9
        Me.lblCorrientes.Text = "Corrientes:"
        '
        'frm_historial_nominas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 496)
        Me.Controls.Add(Me.lblCorrientes)
        Me.Controls.Add(Me.lblNeto)
        Me.Controls.Add(Me.lblDeducciones)
        Me.Controls.Add(Me.lblBruto)
        Me.Controls.Add(Me.DgvDetalleNominas)
        Me.Controls.Add(Me.DgvNominas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_historial_nominas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Historial de Nóminas"
        CType(Me.DgvDetalleNominas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvNominas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvDetalleNominas As System.Windows.Forms.DataGridView
    Friend WithEvents DgvNominas As System.Windows.Forms.DataGridView
    Friend WithEvents lblBruto As System.Windows.Forms.Label
    Friend WithEvents lblDeducciones As System.Windows.Forms.Label
    Friend WithEvents lblNeto As System.Windows.Forms.Label
    Friend WithEvents lblCorrientes As System.Windows.Forms.Label
End Class
