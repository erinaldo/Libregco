<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_previsualizacion_compra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_previsualizacion_compra))
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIDCompra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUltimoMonto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreSuplidor = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtBalanceSup = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtIDSuplidor = New System.Windows.Forms.TextBox()
        Me.DtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.DtpFechaFact = New System.Windows.Forms.DateTimePicker()
        Me.label20 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.label19 = New System.Windows.Forms.Label()
        Me.GbComprobante = New System.Windows.Forms.GroupBox()
        Me.CbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txtNCF = New System.Windows.Forms.MaskedTextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtNoFact = New System.Windows.Forms.TextBox()
        Me.DgvArticulos = New System.Windows.Forms.DataGridView()
        Me.txtPorDescuento2 = New System.Windows.Forms.TextBox()
        Me.txtDescuento2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.GbRecepcion = New System.Windows.Forms.GroupBox()
        Me.chkAveriados = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkpreciosdiferidos = New System.Windows.Forms.CheckBox()
        Me.chkrenegociarflete = New System.Windows.Forms.CheckBox()
        Me.chkArtfuerapedido = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkcreditospendientes = New System.Windows.Forms.CheckBox()
        Me.txtRecepcion = New System.Windows.Forms.TextBox()
        Me.txtIDRecepcion = New System.Windows.Forms.TextBox()
        Me.DtpDiaRecibido = New System.Windows.Forms.DateTimePicker()
        Me.label24 = New System.Windows.Forms.Label()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtNotaCompra = New System.Windows.Forms.TextBox()
        Me.label22 = New System.Windows.Forms.Label()
        Me.CbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtItbis = New System.Windows.Forms.TextBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.btnSubirFactura = New System.Windows.Forms.ToolStripButton()
        Me.GbxUserInfo.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.GbComprobante.SuspendLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbRecepcion.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCompra)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label3)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(655, 6)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(341, 78)
        Me.GbxUserInfo.TabIndex = 250
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(175, 17)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(159, 23)
        Me.txtSecondID.TabIndex = 240
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(8, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 235
        Me.Label7.Text = "Código"
        '
        'txtIDCompra
        '
        Me.txtIDCompra.Enabled = False
        Me.txtIDCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCompra.Location = New System.Drawing.Point(60, 16)
        Me.txtIDCompra.Name = "txtIDCompra"
        Me.txtIDCompra.ReadOnly = True
        Me.txtIDCompra.Size = New System.Drawing.Size(109, 23)
        Me.txtIDCompra.TabIndex = 234
        Me.txtIDCompra.TabStop = False
        Me.txtIDCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 236
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(216, 46)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 237
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(177, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(60, 45)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(111, 23)
        Me.txtFecha.TabIndex = 239
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.txtUltimoMonto)
        Me.groupBox1.Controls.Add(Me.Label28)
        Me.groupBox1.Controls.Add(Me.txtUltimoPago)
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.txtNombreSuplidor)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.label15)
        Me.groupBox1.Controls.Add(Me.txtBalanceSup)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.txtIDSuplidor)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(7, 6)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(642, 78)
        Me.groupBox1.TabIndex = 249
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos del Suplidor"
        '
        'txtUltimoMonto
        '
        Me.txtUltimoMonto.Enabled = False
        Me.txtUltimoMonto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoMonto.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoMonto.Location = New System.Drawing.Point(473, 46)
        Me.txtUltimoMonto.Name = "txtUltimoMonto"
        Me.txtUltimoMonto.ReadOnly = True
        Me.txtUltimoMonto.Size = New System.Drawing.Size(163, 23)
        Me.txtUltimoMonto.TabIndex = 233
        Me.txtUltimoMonto.TabStop = False
        Me.txtUltimoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(421, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 15)
        Me.Label28.TabIndex = 232
        Me.Label28.Text = "Monto:"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(302, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(112, 23)
        Me.txtUltimoPago.TabIndex = 231
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(223, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "Último Pago"
        '
        'txtNombreSuplidor
        '
        Me.txtNombreSuplidor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreSuplidor.Enabled = False
        Me.txtNombreSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombreSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombreSuplidor.Location = New System.Drawing.Point(248, 16)
        Me.txtNombreSuplidor.Name = "txtNombreSuplidor"
        Me.txtNombreSuplidor.ReadOnly = True
        Me.txtNombreSuplidor.Size = New System.Drawing.Size(388, 23)
        Me.txtNombreSuplidor.TabIndex = 183
        Me.txtNombreSuplidor.TabStop = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label1.Location = New System.Drawing.Point(191, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 15)
        Me.label1.TabIndex = 184
        Me.label1.Text = "Suplidor"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label15.Location = New System.Drawing.Point(8, 20)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(46, 15)
        Me.label15.TabIndex = 131
        Me.label15.Text = "Código"
        '
        'txtBalanceSup
        '
        Me.txtBalanceSup.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBalanceSup.Enabled = False
        Me.txtBalanceSup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceSup.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceSup.Location = New System.Drawing.Point(60, 47)
        Me.txtBalanceSup.Name = "txtBalanceSup"
        Me.txtBalanceSup.ReadOnly = True
        Me.txtBalanceSup.Size = New System.Drawing.Size(157, 23)
        Me.txtBalanceSup.TabIndex = 227
        Me.txtBalanceSup.TabStop = False
        Me.txtBalanceSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label5.Location = New System.Drawing.Point(5, 49)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 15)
        Me.label5.TabIndex = 228
        Me.label5.Text = "Balance"
        '
        'txtIDSuplidor
        '
        Me.txtIDSuplidor.Enabled = False
        Me.txtIDSuplidor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSuplidor.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDSuplidor.Location = New System.Drawing.Point(60, 17)
        Me.txtIDSuplidor.Name = "txtIDSuplidor"
        Me.txtIDSuplidor.ReadOnly = True
        Me.txtIDSuplidor.Size = New System.Drawing.Size(125, 23)
        Me.txtIDSuplidor.TabIndex = 130
        Me.txtIDSuplidor.TabStop = False
        Me.txtIDSuplidor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DtpVencimiento
        '
        Me.DtpVencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpVencimiento.CustomFormat = ""
        Me.DtpVencimiento.Enabled = False
        Me.DtpVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpVencimiento.Location = New System.Drawing.Point(263, 112)
        Me.DtpVencimiento.Name = "DtpVencimiento"
        Me.DtpVencimiento.Size = New System.Drawing.Size(110, 23)
        Me.DtpVencimiento.TabIndex = 253
        '
        'DtpFechaFact
        '
        Me.DtpFechaFact.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpFechaFact.CustomFormat = ""
        Me.DtpFechaFact.Enabled = False
        Me.DtpFechaFact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaFact.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFact.Location = New System.Drawing.Point(12, 112)
        Me.DtpFechaFact.Name = "DtpFechaFact"
        Me.DtpFechaFact.Size = New System.Drawing.Size(103, 23)
        Me.DtpFechaFact.TabIndex = 251
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.Location = New System.Drawing.Point(118, 94)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(62, 15)
        Me.label20.TabIndex = 261
        Me.label20.Text = "Condición"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.Enabled = False
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCondicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(121, 111)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(136, 23)
        Me.cbxCondicion.TabIndex = 252
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label19.Location = New System.Drawing.Point(260, 94)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(73, 15)
        Me.label19.TabIndex = 260
        Me.label19.Text = "Vencimiento"
        '
        'GbComprobante
        '
        Me.GbComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbComprobante.Controls.Add(Me.CbxTipoComprobante)
        Me.GbComprobante.Controls.Add(Me.txtNCF)
        Me.GbComprobante.Enabled = False
        Me.GbComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbComprobante.Location = New System.Drawing.Point(647, 90)
        Me.GbComprobante.Name = "GbComprobante"
        Me.GbComprobante.Size = New System.Drawing.Size(350, 50)
        Me.GbComprobante.TabIndex = 256
        Me.GbComprobante.TabStop = False
        Me.GbComprobante.Text = "Comprobante Fiscal"
        '
        'CbxTipoComprobante
        '
        Me.CbxTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.CbxTipoComprobante.FormattingEnabled = True
        Me.CbxTipoComprobante.Location = New System.Drawing.Point(8, 20)
        Me.CbxTipoComprobante.Name = "CbxTipoComprobante"
        Me.CbxTipoComprobante.Size = New System.Drawing.Size(162, 21)
        Me.CbxTipoComprobante.TabIndex = 6
        '
        'txtNCF
        '
        Me.txtNCF.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.txtNCF.Location = New System.Drawing.Point(176, 17)
        Me.txtNCF.Mask = "A000000000000000000"
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.Size = New System.Drawing.Size(165, 24)
        Me.txtNCF.TabIndex = 7
        Me.txtNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label10.Location = New System.Drawing.Point(512, 94)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(62, 15)
        Me.label10.TabIndex = 259
        Me.label10.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(515, 111)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(121, 23)
        Me.txtReferencia.TabIndex = 255
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label9.Location = New System.Drawing.Point(376, 94)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(68, 15)
        Me.label9.TabIndex = 258
        Me.label9.Text = "No. Factura"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label8.Location = New System.Drawing.Point(13, 94)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(80, 15)
        Me.label8.TabIndex = 257
        Me.label8.Text = "Fecha Factura"
        '
        'txtNoFact
        '
        Me.txtNoFact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoFact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNoFact.Location = New System.Drawing.Point(379, 111)
        Me.txtNoFact.Name = "txtNoFact"
        Me.txtNoFact.ReadOnly = True
        Me.txtNoFact.Size = New System.Drawing.Size(130, 23)
        Me.txtNoFact.TabIndex = 254
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
        Me.DgvArticulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.DgvArticulos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvArticulos.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvArticulos.Enabled = False
        Me.DgvArticulos.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.DgvArticulos.Location = New System.Drawing.Point(11, 146)
        Me.DgvArticulos.Name = "DgvArticulos"
        Me.DgvArticulos.RowHeadersWidth = 30
        Me.DgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvArticulos.Size = New System.Drawing.Size(984, 256)
        Me.DgvArticulos.TabIndex = 262
        Me.DgvArticulos.TabStop = False
        '
        'txtPorDescuento2
        '
        Me.txtPorDescuento2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPorDescuento2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPorDescuento2.Location = New System.Drawing.Point(839, 457)
        Me.txtPorDescuento2.Name = "txtPorDescuento2"
        Me.txtPorDescuento2.ReadOnly = True
        Me.txtPorDescuento2.Size = New System.Drawing.Size(50, 23)
        Me.txtPorDescuento2.TabIndex = 264
        Me.txtPorDescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescuento2
        '
        Me.txtDescuento2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescuento2.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescuento2.Enabled = False
        Me.txtDescuento2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescuento2.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento2.Location = New System.Drawing.Point(889, 457)
        Me.txtDescuento2.Name = "txtDescuento2"
        Me.txtDescuento2.Size = New System.Drawing.Size(109, 23)
        Me.txtDescuento2.TabIndex = 275
        Me.txtDescuento2.TabStop = False
        Me.txtDescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(762, 463)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 15)
        Me.Label11.TabIndex = 276
        Me.Label11.Text = "Descuento 2"
        '
        'label27
        '
        Me.label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label27.AutoSize = True
        Me.label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label27.Location = New System.Drawing.Point(771, 437)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(63, 15)
        Me.label27.TabIndex = 274
        Me.label27.Text = "Descuento"
        '
        'txtDescuento
        '
        Me.txtDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(839, 434)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(159, 23)
        Me.txtDescuento.TabIndex = 273
        Me.txtDescuento.TabStop = False
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbRecepcion
        '
        Me.GbRecepcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbRecepcion.Controls.Add(Me.chkAveriados)
        Me.GbRecepcion.Controls.Add(Me.Label25)
        Me.GbRecepcion.Controls.Add(Me.chkpreciosdiferidos)
        Me.GbRecepcion.Controls.Add(Me.chkrenegociarflete)
        Me.GbRecepcion.Controls.Add(Me.chkArtfuerapedido)
        Me.GbRecepcion.Controls.Add(Me.Label4)
        Me.GbRecepcion.Controls.Add(Me.chkcreditospendientes)
        Me.GbRecepcion.Controls.Add(Me.txtRecepcion)
        Me.GbRecepcion.Controls.Add(Me.txtIDRecepcion)
        Me.GbRecepcion.Controls.Add(Me.DtpDiaRecibido)
        Me.GbRecepcion.Controls.Add(Me.label24)
        Me.GbRecepcion.Controls.Add(Me.label21)
        Me.GbRecepcion.Controls.Add(Me.txtNotaCompra)
        Me.GbRecepcion.Controls.Add(Me.label22)
        Me.GbRecepcion.Controls.Add(Me.CbxAlmacen)
        Me.GbRecepcion.Controls.Add(Me.label12)
        Me.GbRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbRecepcion.Location = New System.Drawing.Point(7, 408)
        Me.GbRecepcion.Name = "GbRecepcion"
        Me.GbRecepcion.Size = New System.Drawing.Size(749, 137)
        Me.GbRecepcion.TabIndex = 263
        Me.GbRecepcion.TabStop = False
        Me.GbRecepcion.Text = "Recepción"
        '
        'chkAveriados
        '
        Me.chkAveriados.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkAveriados.AutoSize = True
        Me.chkAveriados.Enabled = False
        Me.chkAveriados.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkAveriados.Location = New System.Drawing.Point(368, 114)
        Me.chkAveriados.Name = "chkAveriados"
        Me.chkAveriados.Size = New System.Drawing.Size(78, 19)
        Me.chkAveriados.TabIndex = 23
        Me.chkAveriados.Text = "Averiados"
        Me.chkAveriados.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label25.Location = New System.Drawing.Point(2, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(745, 4)
        Me.Label25.TabIndex = 256
        '
        'chkpreciosdiferidos
        '
        Me.chkpreciosdiferidos.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkpreciosdiferidos.AutoSize = True
        Me.chkpreciosdiferidos.Enabled = False
        Me.chkpreciosdiferidos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkpreciosdiferidos.Location = New System.Drawing.Point(112, 114)
        Me.chkpreciosdiferidos.Name = "chkpreciosdiferidos"
        Me.chkpreciosdiferidos.Size = New System.Drawing.Size(113, 19)
        Me.chkpreciosdiferidos.TabIndex = 21
        Me.chkpreciosdiferidos.Text = "Precios diferidos"
        Me.chkpreciosdiferidos.UseVisualStyleBackColor = True
        '
        'chkrenegociarflete
        '
        Me.chkrenegociarflete.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkrenegociarflete.AutoSize = True
        Me.chkrenegociarflete.Enabled = False
        Me.chkrenegociarflete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkrenegociarflete.Location = New System.Drawing.Point(616, 114)
        Me.chkrenegociarflete.Name = "chkrenegociarflete"
        Me.chkrenegociarflete.Size = New System.Drawing.Size(116, 19)
        Me.chkrenegociarflete.TabIndex = 25
        Me.chkrenegociarflete.Text = "Re-negociar flete"
        Me.chkrenegociarflete.UseVisualStyleBackColor = True
        '
        'chkArtfuerapedido
        '
        Me.chkArtfuerapedido.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkArtfuerapedido.AutoSize = True
        Me.chkArtfuerapedido.Enabled = False
        Me.chkArtfuerapedido.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkArtfuerapedido.Location = New System.Drawing.Point(452, 114)
        Me.chkArtfuerapedido.Name = "chkArtfuerapedido"
        Me.chkArtfuerapedido.Size = New System.Drawing.Size(159, 19)
        Me.chkArtfuerapedido.TabIndex = 24
        Me.chkArtfuerapedido.Text = "Artículos fuera de pedido"
        Me.chkArtfuerapedido.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 15)
        Me.Label4.TabIndex = 247
        Me.Label4.Text = "Otras opciones:"
        '
        'chkcreditospendientes
        '
        Me.chkcreditospendientes.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.chkcreditospendientes.AutoSize = True
        Me.chkcreditospendientes.Enabled = False
        Me.chkcreditospendientes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkcreditospendientes.Location = New System.Drawing.Point(231, 114)
        Me.chkcreditospendientes.Name = "chkcreditospendientes"
        Me.chkcreditospendientes.Size = New System.Drawing.Size(131, 19)
        Me.chkcreditospendientes.TabIndex = 22
        Me.chkcreditospendientes.Text = "Créditos pendientes"
        Me.chkcreditospendientes.UseVisualStyleBackColor = True
        '
        'txtRecepcion
        '
        Me.txtRecepcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecepcion.Enabled = False
        Me.txtRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRecepcion.Location = New System.Drawing.Point(186, 47)
        Me.txtRecepcion.Name = "txtRecepcion"
        Me.txtRecepcion.ReadOnly = True
        Me.txtRecepcion.Size = New System.Drawing.Size(558, 23)
        Me.txtRecepcion.TabIndex = 245
        '
        'txtIDRecepcion
        '
        Me.txtIDRecepcion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDRecepcion.Location = New System.Drawing.Point(81, 47)
        Me.txtIDRecepcion.Name = "txtIDRecepcion"
        Me.txtIDRecepcion.ReadOnly = True
        Me.txtIDRecepcion.Size = New System.Drawing.Size(100, 23)
        Me.txtIDRecepcion.TabIndex = 19
        Me.txtIDRecepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DtpDiaRecibido
        '
        Me.DtpDiaRecibido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DtpDiaRecibido.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DtpDiaRecibido.CustomFormat = ""
        Me.DtpDiaRecibido.Enabled = False
        Me.DtpDiaRecibido.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpDiaRecibido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDiaRecibido.Location = New System.Drawing.Point(427, 18)
        Me.DtpDiaRecibido.Name = "DtpDiaRecibido"
        Me.DtpDiaRecibido.Size = New System.Drawing.Size(105, 23)
        Me.DtpDiaRecibido.TabIndex = 18
        '
        'label24
        '
        Me.label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label24.AutoSize = True
        Me.label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label24.Location = New System.Drawing.Point(326, 21)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(95, 15)
        Me.label24.TabIndex = 186
        Me.label24.Text = "Día de recepción"
        '
        'label21
        '
        Me.label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.Location = New System.Drawing.Point(9, 50)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(65, 15)
        Me.label21.TabIndex = 184
        Me.label21.Text = "Recepción:"
        '
        'txtNotaCompra
        '
        Me.txtNotaCompra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotaCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNotaCompra.Location = New System.Drawing.Point(81, 76)
        Me.txtNotaCompra.Name = "txtNotaCompra"
        Me.txtNotaCompra.ReadOnly = True
        Me.txtNotaCompra.Size = New System.Drawing.Size(664, 23)
        Me.txtNotaCompra.TabIndex = 20
        '
        'label22
        '
        Me.label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label22.Location = New System.Drawing.Point(9, 79)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(59, 15)
        Me.label22.TabIndex = 182
        Me.label22.Text = "Obserac. :"
        '
        'CbxAlmacen
        '
        Me.CbxAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxAlmacen.Enabled = False
        Me.CbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxAlmacen.FormattingEnabled = True
        Me.CbxAlmacen.Location = New System.Drawing.Point(80, 18)
        Me.CbxAlmacen.Name = "CbxAlmacen"
        Me.CbxAlmacen.Size = New System.Drawing.Size(240, 23)
        Me.CbxAlmacen.TabIndex = 17
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label12.Location = New System.Drawing.Point(9, 24)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(54, 15)
        Me.label12.TabIndex = 243
        Me.label12.Text = "Almacén"
        '
        'label18
        '
        Me.label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.Location = New System.Drawing.Point(768, 529)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(65, 15)
        Me.label18.TabIndex = 272
        Me.label18.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.BackColor = System.Drawing.SystemColors.Control
        Me.txtNeto.Enabled = False
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNeto.ForeColor = System.Drawing.Color.Black
        Me.txtNeto.Location = New System.Drawing.Point(839, 526)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.Size = New System.Drawing.Size(159, 23)
        Me.txtNeto.TabIndex = 271
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label17
        '
        Me.label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label17.Location = New System.Drawing.Point(802, 506)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(32, 15)
        Me.label17.TabIndex = 270
        Me.label17.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFlete.Location = New System.Drawing.Point(839, 503)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.ReadOnly = True
        Me.txtFlete.Size = New System.Drawing.Size(159, 23)
        Me.txtFlete.TabIndex = 265
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label16.Location = New System.Drawing.Point(801, 485)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(33, 15)
        Me.label16.TabIndex = 269
        Me.label16.Text = "ITBIS"
        '
        'label14
        '
        Me.label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label14.Location = New System.Drawing.Point(774, 414)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(59, 15)
        Me.label14.TabIndex = 267
        Me.label14.Text = "Sub. Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(839, 411)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(159, 23)
        Me.txtSubTotal.TabIndex = 266
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtItbis
        '
        Me.txtItbis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItbis.BackColor = System.Drawing.SystemColors.Control
        Me.txtItbis.Enabled = False
        Me.txtItbis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtItbis.ForeColor = System.Drawing.Color.Black
        Me.txtItbis.Location = New System.Drawing.Point(839, 480)
        Me.txtItbis.Name = "txtItbis"
        Me.txtItbis.Size = New System.Drawing.Size(159, 23)
        Me.txtItbis.TabIndex = 268
        Me.txtItbis.TabStop = False
        Me.txtItbis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.btnSubirFactura})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 554)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(1004, 27)
        Me.BarraEstado.TabIndex = 277
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLogo
        '
        Me.PicLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(23, 24)
        '
        'NameSys
        '
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.NameSys.Name = "NameSys"
        Me.NameSys.Size = New System.Drawing.Size(63, 24)
        Me.NameSys.Text = "Libregco"
        '
        'ToolSeparator2
        '
        Me.ToolSeparator2.Name = "ToolSeparator2"
        Me.ToolSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'lblStatusBar
        '
        Me.lblStatusBar.Name = "lblStatusBar"
        Me.lblStatusBar.Size = New System.Drawing.Size(32, 24)
        Me.lblStatusBar.Text = "Listo"
        '
        'btnSubirFactura
        '
        Me.btnSubirFactura.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSubirFactura.Image = CType(resources.GetObject("btnSubirFactura.Image"), System.Drawing.Image)
        Me.btnSubirFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSubirFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSubirFactura.Name = "btnSubirFactura"
        Me.btnSubirFactura.Size = New System.Drawing.Size(180, 24)
        Me.btnSubirFactura.Text = "Visualizar copia de la factura"
        '
        'frm_previsualizacion_compra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 581)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtPorDescuento2)
        Me.Controls.Add(Me.txtDescuento2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.label27)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.GbRecepcion)
        Me.Controls.Add(Me.label18)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.label17)
        Me.Controls.Add(Me.txtFlete)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.txtItbis)
        Me.Controls.Add(Me.DgvArticulos)
        Me.Controls.Add(Me.DtpVencimiento)
        Me.Controls.Add(Me.DtpFechaFact)
        Me.Controls.Add(Me.label20)
        Me.Controls.Add(Me.cbxCondicion)
        Me.Controls.Add(Me.label19)
        Me.Controls.Add(Me.GbComprobante)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.txtNoFact)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.groupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_previsualizacion_compra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Previsualización de compra"
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GbComprobante.ResumeLayout(False)
        Me.GbComprobante.PerformLayout()
        CType(Me.DgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbRecepcion.ResumeLayout(False)
        Me.GbRecepcion.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIDCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUltimoMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombreSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceSup As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents txtIDSuplidor As System.Windows.Forms.TextBox
    Friend WithEvents DtpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFechaFact As System.Windows.Forms.DateTimePicker
    Friend WithEvents label20 As System.Windows.Forms.Label
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents label19 As System.Windows.Forms.Label
    Friend WithEvents GbComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents CbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents txtNCF As System.Windows.Forms.MaskedTextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents txtNoFact As System.Windows.Forms.TextBox
    Friend WithEvents DgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents txtPorDescuento2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuento2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents label27 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents GbRecepcion As System.Windows.Forms.GroupBox
    Friend WithEvents chkAveriados As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkpreciosdiferidos As System.Windows.Forms.CheckBox
    Friend WithEvents chkrenegociarflete As System.Windows.Forms.CheckBox
    Friend WithEvents chkArtfuerapedido As System.Windows.Forms.CheckBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkcreditospendientes As System.Windows.Forms.CheckBox
    Friend WithEvents txtRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents txtIDRecepcion As System.Windows.Forms.TextBox
    Friend WithEvents DtpDiaRecibido As System.Windows.Forms.DateTimePicker
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtNotaCompra As System.Windows.Forms.TextBox
    Private WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents CbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtItbis As System.Windows.Forms.TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnSubirFactura As System.Windows.Forms.ToolStripButton
End Class
