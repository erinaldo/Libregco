<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visualizar_detalle_pagares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visualizar_detalle_pagares))
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        Me.NoPagare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPagares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoPagare, Me.FechaVencimiento, Me.Concepto, Me.Monto})
        Me.DgvPagares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPagares.Location = New System.Drawing.Point(0, 0)
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.RowHeadersVisible = False
        Me.DgvPagares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPagares.Size = New System.Drawing.Size(903, 387)
        Me.DgvPagares.TabIndex = 0
        '
        'NoPagare
        '
        Me.NoPagare.HeaderText = "No. Pagaré"
        Me.NoPagare.Name = "NoPagare"
        Me.NoPagare.ReadOnly = True
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.HeaderText = "Fecha de Vencimiento"
        Me.FechaVencimiento.Name = "FechaVencimiento"
        Me.FechaVencimiento.ReadOnly = True
        Me.FechaVencimiento.Width = 200
        '
        'Concepto
        '
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        Me.Concepto.Width = 460
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 140
        '
        'frm_visualizar_detalle_pagares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 387)
        Me.Controls.Add(Me.DgvPagares)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_visualizar_detalle_pagares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visualización de detalles de pagare(s)"
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents NoPagare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
