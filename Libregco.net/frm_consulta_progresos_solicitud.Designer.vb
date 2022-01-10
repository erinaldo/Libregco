<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_progresos_solicitud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_progresos_solicitud))
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkChoosePrint = New System.Windows.Forms.CheckBox()
        Me.cbxFormatoImp = New System.Windows.Forms.ComboBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnPresentar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscarCons = New System.Windows.Forms.Button()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.DgvMovimientosBanc = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMontoFinal = New Libregco.Watermark()
        Me.txtMontoInicial = New Libregco.Watermark()
        Me.chkNulos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.txtIDCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipoMovimiento = New System.Windows.Forms.TextBox()
        Me.txtIDTipoMovimiento = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaFinal = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaInicial = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarCuentaBancaria = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgvMovimientosBanc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtQuery
        '
        Me.txtQuery.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.txtQuery.ForeColor = System.Drawing.Color.Black
        Me.txtQuery.Location = New System.Drawing.Point(6, 444)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ReadOnly = True
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQuery.Size = New System.Drawing.Size(675, 33)
        Me.txtQuery.TabIndex = 352
        Me.txtQuery.TabStop = False
        Me.txtQuery.Text = "SQL Query:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.chkChoosePrint)
        Me.GroupBox3.Controls.Add(Me.cbxFormatoImp)
        Me.GroupBox3.Controls.Add(Me.btnModificar)
        Me.GroupBox3.Controls.Add(Me.btnPresentar)
        Me.GroupBox3.Controls.Add(Me.btnLimpiar)
        Me.GroupBox3.Controls.Add(Me.btnBuscarCons)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 380)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(675, 57)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(461, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 342
        Me.Label8.Text = "Formato Página:"
        '
        'chkChoosePrint
        '
        Me.chkChoosePrint.AutoSize = True
        Me.chkChoosePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.chkChoosePrint.Location = New System.Drawing.Point(561, 10)
        Me.chkChoosePrint.Name = "chkChoosePrint"
        Me.chkChoosePrint.Size = New System.Drawing.Size(101, 17)
        Me.chkChoosePrint.TabIndex = 15
        Me.chkChoosePrint.Text = "Elegir Impresora"
        Me.chkChoosePrint.UseVisualStyleBackColor = True
        '
        'cbxFormatoImp
        '
        Me.cbxFormatoImp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFormatoImp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbxFormatoImp.FormattingEnabled = True
        Me.cbxFormatoImp.Location = New System.Drawing.Point(464, 27)
        Me.cbxFormatoImp.Name = "cbxFormatoImp"
        Me.cbxFormatoImp.Size = New System.Drawing.Size(198, 23)
        Me.cbxFormatoImp.TabIndex = 14
        '
        'btnModificar
        '
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(310, 19)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(95, 30)
        Me.btnModificar.TabIndex = 13
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnPresentar
        '
        Me.btnPresentar.Image = CType(resources.GetObject("btnPresentar.Image"), System.Drawing.Image)
        Me.btnPresentar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPresentar.Location = New System.Drawing.Point(209, 19)
        Me.btnPresentar.Name = "btnPresentar"
        Me.btnPresentar.Size = New System.Drawing.Size(95, 30)
        Me.btnPresentar.TabIndex = 12
        Me.btnPresentar.Text = "Presentar"
        Me.btnPresentar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPresentar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(7, 19)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(95, 30)
        Me.btnLimpiar.TabIndex = 10
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscarCons
        '
        Me.btnBuscarCons.Image = CType(resources.GetObject("btnBuscarCons.Image"), System.Drawing.Image)
        Me.btnBuscarCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCons.Location = New System.Drawing.Point(108, 19)
        Me.btnBuscarCons.Name = "btnBuscarCons"
        Me.btnBuscarCons.Size = New System.Drawing.Size(95, 30)
        Me.btnBuscarCons.TabIndex = 11
        Me.btnBuscarCons.Text = "Buscar"
        Me.btnBuscarCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCons.UseVisualStyleBackColor = True
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCantidad.Location = New System.Drawing.Point(3, 364)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(127, 15)
        Me.lblCantidad.TabIndex = 350
        Me.lblCantidad.Text = "Registros Encontrados:"
        '
        'DgvMovimientosBanc
        '
        Me.DgvMovimientosBanc.AllowUserToAddRows = False
        Me.DgvMovimientosBanc.AllowUserToDeleteRows = False
        Me.DgvMovimientosBanc.AllowUserToResizeColumns = False
        Me.DgvMovimientosBanc.AllowUserToResizeRows = False
        Me.DgvMovimientosBanc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvMovimientosBanc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMovimientosBanc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMovimientosBanc.Location = New System.Drawing.Point(4, 95)
        Me.DgvMovimientosBanc.MultiSelect = False
        Me.DgvMovimientosBanc.Name = "DgvMovimientosBanc"
        Me.DgvMovimientosBanc.ReadOnly = True
        Me.DgvMovimientosBanc.RowHeadersWidth = 20
        Me.DgvMovimientosBanc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvMovimientosBanc.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure
        Me.DgvMovimientosBanc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMovimientosBanc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMovimientosBanc.Size = New System.Drawing.Size(675, 265)
        Me.DgvMovimientosBanc.StandardTab = True
        Me.DgvMovimientosBanc.TabIndex = 349
        Me.DgvMovimientosBanc.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMontoFinal)
        Me.GroupBox2.Controls.Add(Me.txtMontoInicial)
        Me.GroupBox2.Controls.Add(Me.chkNulos)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(563, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(118, 83)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Montos"
        '
        'txtMontoFinal
        '
        Me.txtMontoFinal.Location = New System.Drawing.Point(9, 39)
        Me.txtMontoFinal.Name = "txtMontoFinal"
        Me.txtMontoFinal.Size = New System.Drawing.Size(100, 23)
        Me.txtMontoFinal.TabIndex = 7
        Me.txtMontoFinal.WatermarkColor = System.Drawing.Color.Gray
        Me.txtMontoFinal.WatermarkText = "Final"
        '
        'txtMontoInicial
        '
        Me.txtMontoInicial.Location = New System.Drawing.Point(9, 15)
        Me.txtMontoInicial.Name = "txtMontoInicial"
        Me.txtMontoInicial.Size = New System.Drawing.Size(100, 23)
        Me.txtMontoInicial.TabIndex = 6
        Me.txtMontoInicial.WatermarkColor = System.Drawing.Color.Gray
        Me.txtMontoInicial.WatermarkText = "Inicial"
        '
        'chkNulos
        '
        Me.chkNulos.AutoSize = True
        Me.chkNulos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chkNulos.Location = New System.Drawing.Point(21, 64)
        Me.chkNulos.Name = "chkNulos"
        Me.chkNulos.Size = New System.Drawing.Size(75, 17)
        Me.chkNulos.TabIndex = 8
        Me.chkNulos.Text = "Ver Nulos"
        Me.chkNulos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(148, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 348
        Me.Label3.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(258, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 347
        Me.Label4.Text = "Cuenta Bancaria"
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Enabled = False
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(258, 65)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.ReadOnly = True
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(299, 23)
        Me.txtCuentaBancaria.TabIndex = 346
        '
        'txtIDCuentaBancaria
        '
        Me.txtIDCuentaBancaria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCuentaBancaria.Location = New System.Drawing.Point(148, 65)
        Me.txtIDCuentaBancaria.Name = "txtIDCuentaBancaria"
        Me.txtIDCuentaBancaria.Size = New System.Drawing.Size(68, 23)
        Me.txtIDCuentaBancaria.TabIndex = 4
        Me.txtIDCuentaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(148, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 345
        Me.Label6.Text = "Código"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(258, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 15)
        Me.Label5.TabIndex = 344
        Me.Label5.Text = "Tipo Movimiento Bancario"
        '
        'txtTipoMovimiento
        '
        Me.txtTipoMovimiento.Enabled = False
        Me.txtTipoMovimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoMovimiento.Location = New System.Drawing.Point(258, 22)
        Me.txtTipoMovimiento.Name = "txtTipoMovimiento"
        Me.txtTipoMovimiento.ReadOnly = True
        Me.txtTipoMovimiento.Size = New System.Drawing.Size(299, 23)
        Me.txtTipoMovimiento.TabIndex = 343
        '
        'txtIDTipoMovimiento
        '
        Me.txtIDTipoMovimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTipoMovimiento.Location = New System.Drawing.Point(148, 22)
        Me.txtIDTipoMovimiento.Name = "txtIDTipoMovimiento"
        Me.txtIDTipoMovimiento.Size = New System.Drawing.Size(68, 23)
        Me.txtIDTipoMovimiento.TabIndex = 2
        Me.txtIDTipoMovimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaFinal)
        Me.GroupBox1.Controls.Add(Me.txtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 83)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Entre Fechas"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.Location = New System.Drawing.Point(48, 49)
        Me.txtFechaFinal.Mask = "00/00/0000"
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(80, 23)
        Me.txtFechaFinal.TabIndex = 1
        Me.txtFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaFinal.ValidatingType = GetType(Date)
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.Location = New System.Drawing.Point(48, 19)
        Me.txtFechaInicial.Mask = "00/00/0000"
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(80, 23)
        Me.txtFechaInicial.TabIndex = 0
        Me.txtFechaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaInicial.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Inicial:"
        '
        'btnBuscarCuentaBancaria
        '
        Me.btnBuscarCuentaBancaria.BackgroundImage = Global.Libregco.My.Resources.Resources.Search
        Me.btnBuscarCuentaBancaria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCuentaBancaria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCuentaBancaria.Location = New System.Drawing.Point(222, 61)
        Me.btnBuscarCuentaBancaria.Name = "btnBuscarCuentaBancaria"
        Me.btnBuscarCuentaBancaria.Size = New System.Drawing.Size(30, 30)
        Me.btnBuscarCuentaBancaria.TabIndex = 5
        Me.btnBuscarCuentaBancaria.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImage = Global.Libregco.My.Resources.Resources.Search
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(222, 18)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(30, 30)
        Me.btnBuscarCliente.TabIndex = 3
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'frm_consulta_mov_bancarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 482)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.DgvMovimientosBanc)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscarCuentaBancaria)
        Me.Controls.Add(Me.txtCuentaBancaria)
        Me.Controls.Add(Me.txtIDCuentaBancaria)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.txtTipoMovimiento)
        Me.Controls.Add(Me.txtIDTipoMovimiento)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_consulta_mov_bancarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgvMovimientosBanc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkChoosePrint As System.Windows.Forms.CheckBox
    Friend WithEvents cbxFormatoImp As System.Windows.Forms.ComboBox
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnPresentar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCons As System.Windows.Forms.Button
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents DgvMovimientosBanc As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNulos As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuentaBancaria As System.Windows.Forms.Button
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtTipoMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTipoMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaInicial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMontoFinal As Libregco.Watermark
    Friend WithEvents txtMontoInicial As Libregco.Watermark
End Class
