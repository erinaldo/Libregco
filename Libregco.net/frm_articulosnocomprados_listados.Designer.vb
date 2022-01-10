<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_articulosnocomprados_listados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_articulosnocomprados_listados))
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.btnMarcarRecibido = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.rdbRecibidos = New System.Windows.Forms.RadioButton()
        Me.rdbEnTransito = New System.Windows.Forms.RadioButton()
        Me.rdbNoPedidos = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvArticulos
        '
        Me.DgvArticulos.AllowUserToAddRows = False
        Me.DgvArticulos.AllowUserToDeleteRows = False
        Me.DgvArticulos.AllowUserToResizeColumns = False
        Me.DgvArticulos.AllowUserToResizeRows = False
        Me.DgvArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvArticulos.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.DgvArticulos.Location = New System.Drawing.Point(0, 97)
        Me.DgvArticulos.MultiSelect = False
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.ReadOnly = True
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.RowTemplate.Height = 44
        Me.DgvArticulos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(964, 528)
        Me.DgvArticulos.TabIndex = 3
        Me.DgvArticulos.TabStop = False
        '
        'btnMarcarRecibido
        '
        Me.btnMarcarRecibido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarRecibido.Image = Global.Libregco.My.Resources.Resources.Checkedx32
        Me.btnMarcarRecibido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcarRecibido.Location = New System.Drawing.Point(5, 631)
        Me.btnMarcarRecibido.Name = "btnMarcarRecibido"
        Me.btnMarcarRecibido.Size = New System.Drawing.Size(160, 43)
        Me.btnMarcarRecibido.TabIndex = 4
        Me.btnMarcarRecibido.Text = "Marcar como recibido"
        Me.btnMarcarRecibido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMarcarRecibido.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.Libregco.My.Resources.Resources.Stocks_x32
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(171, 631)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 43)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Marcar como Pedido"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.rdbRecibidos)
        Me.GroupControl1.Controls.Add(Me.rdbEnTransito)
        Me.GroupControl1.Controls.Add(Me.rdbNoPedidos)
        Me.GroupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.BeforeText
        Me.GroupControl1.Location = New System.Drawing.Point(8, 7)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(947, 84)
        Me.GroupControl1.TabIndex = 12
        Me.GroupControl1.Text = "Estado de Solicitud"
        '
        'rdbRecibidos
        '
        Me.rdbRecibidos.Image = Global.Libregco.My.Resources.Resources.Checkedx32
        Me.rdbRecibidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbRecibidos.Location = New System.Drawing.Point(357, 28)
        Me.rdbRecibidos.Name = "rdbRecibidos"
        Me.rdbRecibidos.Size = New System.Drawing.Size(120, 47)
        Me.rdbRecibidos.TabIndex = 2
        Me.rdbRecibidos.TabStop = True
        Me.rdbRecibidos.Text = "Recibidos"
        Me.rdbRecibidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbRecibidos.UseVisualStyleBackColor = True
        '
        'rdbEnTransito
        '
        Me.rdbEnTransito.Image = Global.Libregco.My.Resources.Resources.Stocks_x32
        Me.rdbEnTransito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbEnTransito.Location = New System.Drawing.Point(211, 28)
        Me.rdbEnTransito.Name = "rdbEnTransito"
        Me.rdbEnTransito.Size = New System.Drawing.Size(120, 47)
        Me.rdbEnTransito.TabIndex = 1
        Me.rdbEnTransito.TabStop = True
        Me.rdbEnTransito.Text = "En tránsito"
        Me.rdbEnTransito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbEnTransito.UseVisualStyleBackColor = True
        '
        'rdbNoPedidos
        '
        Me.rdbNoPedidos.Image = Global.Libregco.My.Resources.Resources.uncheckedx32
        Me.rdbNoPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdbNoPedidos.Location = New System.Drawing.Point(17, 28)
        Me.rdbNoPedidos.Name = "rdbNoPedidos"
        Me.rdbNoPedidos.Size = New System.Drawing.Size(178, 47)
        Me.rdbNoPedidos.TabIndex = 0
        Me.rdbNoPedidos.TabStop = True
        Me.rdbNoPedidos.Text = "No pedidos / comprados"
        Me.rdbNoPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rdbNoPedidos.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.Libregco.My.Resources.Resources.uncheckedx32
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(330, 631)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(171, 43)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Marcar como no recibido"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frm_articulosnocomprados_listados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 681)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnMarcarRecibido)
        Me.Controls.Add(Me.DgvArticulos)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_articulosnocomprados_listados"
        Me.Text = "Listado de artículos / No Comprados"
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvArticulos As DataGridView
    Friend WithEvents btnMarcarRecibido As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdbRecibidos As RadioButton
    Friend WithEvents rdbEnTransito As RadioButton
    Friend WithEvents rdbNoPedidos As RadioButton
    Friend WithEvents Button2 As Button
End Class
