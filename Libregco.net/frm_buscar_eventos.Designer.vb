<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_buscar_eventos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_buscar_eventos))
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.DgvEventos = New System.Windows.Forms.DataGridView()
        Me.IDEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Logo = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Evento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Finaliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(4, 3)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(241, 78)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 235
        Me.PicBoxLogo.TabStop = False
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(273, 44)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(45, 15)
        Me.label7.TabIndex = 233
        Me.label7.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBuscar.Location = New System.Drawing.Point(324, 41)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(414, 23)
        Me.txtBuscar.TabIndex = 230
        '
        'DgvEventos
        '
        Me.DgvEventos.AllowUserToAddRows = False
        Me.DgvEventos.AllowUserToDeleteRows = False
        Me.DgvEventos.AllowUserToResizeColumns = False
        Me.DgvEventos.AllowUserToResizeRows = False
        Me.DgvEventos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvEventos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvEventos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDEvento, Me.Logo, Me.Evento, Me.Finaliza})
        Me.DgvEventos.Location = New System.Drawing.Point(8, 90)
        Me.DgvEventos.MultiSelect = False
        Me.DgvEventos.Name = "DgvEventos"
        Me.DgvEventos.ReadOnly = True
        Me.DgvEventos.RowHeadersWidth = 60
        Me.DgvEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvEventos.RowTemplate.Height = 40
        Me.DgvEventos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvEventos.Size = New System.Drawing.Size(750, 341)
        Me.DgvEventos.TabIndex = 231
        '
        'IDEvento
        '
        Me.IDEvento.HeaderText = "IDEvento"
        Me.IDEvento.Name = "IDEvento"
        Me.IDEvento.ReadOnly = True
        Me.IDEvento.Visible = False
        '
        'Logo
        '
        Me.Logo.HeaderText = ""
        Me.Logo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Logo.Name = "Logo"
        Me.Logo.ReadOnly = True
        Me.Logo.Width = 200
        '
        'Evento
        '
        Me.Evento.HeaderText = "Evento"
        Me.Evento.Name = "Evento"
        Me.Evento.ReadOnly = True
        Me.Evento.Width = 410
        '
        'Finaliza
        '
        Me.Finaliza.HeaderText = "Finaliza"
        Me.Finaliza.Name = "Finaliza"
        Me.Finaliza.ReadOnly = True
        '
        'frm_buscar_eventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 443)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.DgvEventos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_buscar_eventos"
        Me.Text = "Búsqueda de eventos"
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicBoxLogo As PictureBox
    Private WithEvents label7 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents DgvEventos As DataGridView
    Friend WithEvents IDEvento As DataGridViewTextBoxColumn
    Friend WithEvents Logo As DataGridViewImageColumn
    Friend WithEvents Evento As DataGridViewTextBoxColumn
    Friend WithEvents Finaliza As DataGridViewTextBoxColumn
End Class
