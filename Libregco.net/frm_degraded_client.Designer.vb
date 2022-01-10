<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_degraded_client
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_degraded_client))
        Me.lblCalificacion = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblBalanceGeneral = New System.Windows.Forms.Label()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lblEstadoCredito = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.PicImagen = New DevExpress.XtraEditors.PictureEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.lblCalificacionAutonoma = New System.Windows.Forms.Label()
        Me.DgvFacturas = New System.Windows.Forms.DataGridView()
        Me.ClFacturas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClDAtraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClDiasDurados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCalificacion
        '
        Me.lblCalificacion.Font = New System.Drawing.Font("Segoe UI", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalificacion.Location = New System.Drawing.Point(21, 142)
        Me.lblCalificacion.Name = "lblCalificacion"
        Me.lblCalificacion.Size = New System.Drawing.Size(502, 105)
        Me.lblCalificacion.TabIndex = 0
        Me.lblCalificacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(-1, 249)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(538, 26)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Calificación ponderada"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(505, 44)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "El cliente seleccionado posee una calificación la cual requiere atención especial" &
    " para la otorgación de créditos. "
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(2, 482)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(535, 23)
        Me.SeparatorControl1.TabIndex = 4
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(2, 153)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(535, 23)
        Me.SeparatorControl2.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(18, 497)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(505, 122)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lblBalanceGeneral)
        Me.GroupControl1.Location = New System.Drawing.Point(18, 317)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(212, 70)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Balance General"
        '
        'lblBalanceGeneral
        '
        Me.lblBalanceGeneral.AutoSize = True
        Me.lblBalanceGeneral.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceGeneral.Location = New System.Drawing.Point(5, 31)
        Me.lblBalanceGeneral.Name = "lblBalanceGeneral"
        Me.lblBalanceGeneral.Size = New System.Drawing.Size(108, 25)
        Me.lblBalanceGeneral.TabIndex = 0
        Me.lblBalanceGeneral.Text = "RD$ 0.00"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.lblEstadoCredito)
        Me.GroupControl3.Location = New System.Drawing.Point(370, 317)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(153, 70)
        Me.GroupControl3.TabIndex = 9
        Me.GroupControl3.Text = "Estado de crédito"
        '
        'lblEstadoCredito
        '
        Me.lblEstadoCredito.AutoSize = True
        Me.lblEstadoCredito.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCredito.Location = New System.Drawing.Point(5, 31)
        Me.lblEstadoCredito.Name = "lblEstadoCredito"
        Me.lblEstadoCredito.Size = New System.Drawing.Size(77, 25)
        Me.lblEstadoCredito.TabIndex = 2
        Me.lblEstadoCredito.Text = "Activo"
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(12, 142)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(511, 18)
        Me.lblNombre.TabIndex = 10
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicImagen
        '
        Me.PicImagen.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicImagen.Location = New System.Drawing.Point(199, 1)
        Me.PicImagen.Name = "PicImagen"
        Me.PicImagen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PicImagen.Properties.Appearance.Options.UseBackColor = True
        Me.PicImagen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PicImagen.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle
        Me.PicImagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PicImagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PicImagen.Size = New System.Drawing.Size(140, 140)
        Me.PicImagen.TabIndex = 12
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.lblCalificacionAutonoma)
        Me.GroupControl2.Location = New System.Drawing.Point(236, 317)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(128, 70)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "Calificación Autónoma"
        '
        'lblCalificacionAutonoma
        '
        Me.lblCalificacionAutonoma.AutoSize = True
        Me.lblCalificacionAutonoma.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalificacionAutonoma.Location = New System.Drawing.Point(5, 31)
        Me.lblCalificacionAutonoma.Name = "lblCalificacionAutonoma"
        Me.lblCalificacionAutonoma.Size = New System.Drawing.Size(25, 25)
        Me.lblCalificacionAutonoma.TabIndex = 2
        Me.lblCalificacionAutonoma.Text = "0"
        '
        'DgvFacturas
        '
        Me.DgvFacturas.AllowUserToAddRows = False
        Me.DgvFacturas.AllowUserToDeleteRows = False
        Me.DgvFacturas.AllowUserToResizeColumns = False
        Me.DgvFacturas.AllowUserToResizeRows = False
        Me.DgvFacturas.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvFacturas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClFacturas, Me.CLFecha, Me.ClBalance, Me.ClDAtraso, Me.ClDiasDurados})
        Me.DgvFacturas.Location = New System.Drawing.Point(18, 395)
        Me.DgvFacturas.MultiSelect = False
        Me.DgvFacturas.Name = "DgvFacturas"
        Me.DgvFacturas.ReadOnly = True
        Me.DgvFacturas.RowHeadersVisible = False
        Me.DgvFacturas.RowHeadersWidth = 15
        Me.DgvFacturas.RowTemplate.Height = 28
        Me.DgvFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFacturas.Size = New System.Drawing.Size(505, 92)
        Me.DgvFacturas.TabIndex = 13
        '
        'ClFacturas
        '
        Me.ClFacturas.HeaderText = "Facturas"
        Me.ClFacturas.Name = "ClFacturas"
        Me.ClFacturas.ReadOnly = True
        Me.ClFacturas.Width = 135
        '
        'CLFecha
        '
        Me.CLFecha.HeaderText = "Fecha"
        Me.CLFecha.Name = "CLFecha"
        Me.CLFecha.ReadOnly = True
        '
        'ClBalance
        '
        Me.ClBalance.HeaderText = "Balance"
        Me.ClBalance.Name = "ClBalance"
        Me.ClBalance.ReadOnly = True
        Me.ClBalance.Width = 110
        '
        'ClDAtraso
        '
        Me.ClDAtraso.HeaderText = "Días de atraso"
        Me.ClDAtraso.Name = "ClDAtraso"
        Me.ClDAtraso.ReadOnly = True
        Me.ClDAtraso.Width = 80
        '
        'ClDiasDurados
        '
        Me.ClDiasDurados.HeaderText = "Días durados"
        Me.ClDiasDurados.Name = "ClDiasDurados"
        Me.ClDiasDurados.ReadOnly = True
        Me.ClDiasDurados.Width = 80
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Facturas"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 135
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Días de atraso"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Días durados"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'frm_degraded_client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 640)
        Me.Controls.Add(Me.DgvFacturas)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PicImagen)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.lblCalificacion)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_degraded_client"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Alerta de calificación"
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.PicImagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.DgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCalificacion As Label
    Friend WithEvents label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblBalanceGeneral As Label
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblEstadoCredito As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents PicImagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblCalificacionAutonoma As Label
    Friend WithEvents DgvFacturas As DataGridView
    Friend WithEvents ClFacturas As DataGridViewTextBoxColumn
    Friend WithEvents CLFecha As DataGridViewTextBoxColumn
    Friend WithEvents ClBalance As DataGridViewTextBoxColumn
    Friend WithEvents ClDAtraso As DataGridViewTextBoxColumn
    Friend WithEvents ClDiasDurados As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
