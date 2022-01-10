<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visualizacion_pagares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visualizacion_pagares))
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.AllowUserToResizeColumns = False
        Me.DgvPagares.AllowUserToResizeRows = False
        Me.DgvPagares.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPagares.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPagares.Location = New System.Drawing.Point(0, 0)
        Me.DgvPagares.MultiSelect = False
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.RowHeadersWidth = 10
        Me.DgvPagares.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPagares.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Info
        Me.DgvPagares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPagares.Size = New System.Drawing.Size(851, 518)
        Me.DgvPagares.TabIndex = 6
        '
        'frm_visualizacion_pagares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 518)
        Me.Controls.Add(Me.DgvPagares)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_visualizacion_pagares"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pagares de factura"
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
End Class
