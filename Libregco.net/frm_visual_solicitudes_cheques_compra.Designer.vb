<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_visual_solicitudes_cheques_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_visual_solicitudes_cheques_compra))
        Me.DgvCheques = New System.Windows.Forms.DataGridView()
        Me.IDSolicitudCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaBancaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNombreSuplidor = New System.Windows.Forms.Label()
        Me.cbxFactura = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        CType(Me.DgvCheques,System.ComponentModel.ISupportInitialize).BeginInit
        Me.BarraEstado.SuspendLayout
        Me.SuspendLayout
        '
        'DgvCheques
        '
        Me.DgvCheques.AllowUserToAddRows = false
        Me.DgvCheques.AllowUserToDeleteRows = false
        Me.DgvCheques.AllowUserToResizeColumns = false
        Me.DgvCheques.AllowUserToResizeRows = false
        Me.DgvCheques.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvCheques.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDSolicitudCheque, Me.Solicitud, Me.Banco, Me.CuentaBancaria, Me.FechaPago, Me.Monto, Me.Observacion, Me.Estado})
        Me.DgvCheques.Location = New System.Drawing.Point(0, 67)
        Me.DgvCheques.Name = "DgvCheques"
        Me.DgvCheques.ReadOnly = true
        Me.DgvCheques.RowHeadersVisible = false
        Me.DgvCheques.RowTemplate.Height = 30
        Me.DgvCheques.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvCheques.Size = New System.Drawing.Size(1198, 258)
        Me.DgvCheques.TabIndex = 0
        '
        'IDSolicitudCheque
        '
        Me.IDSolicitudCheque.HeaderText = "IDSolicitudCheque"
        Me.IDSolicitudCheque.Name = "IDSolicitudCheque"
        Me.IDSolicitudCheque.ReadOnly = true
        Me.IDSolicitudCheque.Visible = false
        '
        'Solicitud
        '
        Me.Solicitud.HeaderText = "No. Solicitud"
        Me.Solicitud.Name = "Solicitud"
        Me.Solicitud.ReadOnly = true
        Me.Solicitud.Width = 110
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.Name = "Banco"
        Me.Banco.ReadOnly = true
        Me.Banco.Width = 270
        '
        'CuentaBancaria
        '
        Me.CuentaBancaria.HeaderText = "Cuenta Bancaria"
        Me.CuentaBancaria.Name = "CuentaBancaria"
        Me.CuentaBancaria.ReadOnly = true
        Me.CuentaBancaria.Width = 160
        '
        'FechaPago
        '
        Me.FechaPago.HeaderText = "Fecha"
        Me.FechaPago.Name = "FechaPago"
        Me.FechaPago.ReadOnly = true
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = true
        Me.Monto.Width = 120
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = true
        Me.Observacion.Width = 250
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = true
        Me.Estado.Width = 180
        '
        'lblNombreSuplidor
        '
        Me.lblNombreSuplidor.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreSuplidor.Font = New System.Drawing.Font("Arial", 16!)
        Me.lblNombreSuplidor.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombreSuplidor.Location = New System.Drawing.Point(0, 5)
        Me.lblNombreSuplidor.Name = "lblNombreSuplidor"
        Me.lblNombreSuplidor.Size = New System.Drawing.Size(1186, 27)
        Me.lblNombreSuplidor.TabIndex = 2
        Me.lblNombreSuplidor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxFactura
        '
        Me.cbxFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxFactura.FormattingEnabled = true
        Me.cbxFactura.Location = New System.Drawing.Point(61, 35)
        Me.cbxFactura.Name = "cbxFactura"
        Me.cbxFactura.Size = New System.Drawing.Size(180, 23)
        Me.cbxFactura.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Factura"
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 328)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1198, 25)
        Me.BarraEstado.TabIndex = 331
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 22)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic),System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 22)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 22)
        Me.lblStatusBar.Text = "Listo"
        '
        'frm_visual_solicitudes_cheques_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 353)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxFactura)
        Me.Controls.Add(Me.lblNombreSuplidor)
        Me.Controls.Add(Me.DgvCheques)
        Me.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frm_visual_solicitudes_cheques_compra"
        Me.Text = "Cheques programados"
        CType(Me.DgvCheques,System.ComponentModel.ISupportInitialize).EndInit
        Me.BarraEstado.ResumeLayout(false)
        Me.BarraEstado.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents DgvCheques As System.Windows.Forms.DataGridView
    Friend WithEvents lblNombreSuplidor As System.Windows.Forms.Label
    Friend WithEvents cbxFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IDSolicitudCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CuentaBancaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
