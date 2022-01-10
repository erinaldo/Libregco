<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_previsualizacion_facturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_previsualizacion_facturas))
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFlete = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtITBIS = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtFechaFactura = New System.Windows.Forms.TextBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtHoraFactura = New System.Windows.Forms.TextBox()
        Me.txtIDFactura = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtCreditoDisponible = New System.Windows.Forms.TextBox()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtBalanceGeneral = New System.Windows.Forms.TextBox()
        Me.label20 = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.tab_condicion_credito = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.txtFechaAdicional = New System.Windows.Forms.TextBox()
        Me.txtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label18 = New System.Windows.Forms.Label()
        Me.txtCondicionContado = New System.Windows.Forms.TextBox()
        Me.chkFichaDatos = New System.Windows.Forms.CheckBox()
        Me.chkHabilitarNota = New System.Windows.Forms.CheckBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.txtTotalPagar = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtAdicional = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.txtMontoPagos = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtCantidadPagos = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.DgvPagares = New System.Windows.Forms.DataGridView()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.TxtDescuentoSuma = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.TbSelectProductos = New System.Windows.Forms.GroupBox()
        Me.dgvArticulosFactura = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVehiculo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtCobrador = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtDiasVencidos = New System.Windows.Forms.TextBox()
        Me.txtCargos = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TbcComprobante = New System.Windows.Forms.GroupBox()
        Me.txtNCF = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.txtTipoComprobante = New System.Windows.Forms.TextBox()
        Me.label23 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.GbxUserInfo.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.tab_condicion_credito.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbSelectProductos.SuspendLayout()
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TbcComprobante.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(792, 495)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 15)
        Me.Label24.TabIndex = 284
        Me.Label24.Text = "Flete"
        '
        'txtFlete
        '
        Me.txtFlete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlete.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFlete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFlete.Location = New System.Drawing.Point(829, 494)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.ReadOnly = True
        Me.txtFlete.Size = New System.Drawing.Size(142, 16)
        Me.txtFlete.TabIndex = 274
        Me.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label12.Location = New System.Drawing.Point(790, 470)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(32, 15)
        Me.label12.TabIndex = 280
        Me.label12.Text = "ITBIS"
        '
        'txtITBIS
        '
        Me.txtITBIS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtITBIS.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtITBIS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtITBIS.Location = New System.Drawing.Point(829, 469)
        Me.txtITBIS.Name = "txtITBIS"
        Me.txtITBIS.ReadOnly = True
        Me.txtITBIS.Size = New System.Drawing.Size(142, 16)
        Me.txtITBIS.TabIndex = 279
        Me.txtITBIS.TabStop = False
        Me.txtITBIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtFechaFactura)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.label1)
        Me.GbxUserInfo.Controls.Add(Me.txtHoraFactura)
        Me.GbxUserInfo.Controls.Add(Me.txtIDFactura)
        Me.GbxUserInfo.Controls.Add(Me.label4)
        Me.GbxUserInfo.Controls.Add(Me.label3)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(667, 2)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(305, 76)
        Me.GbxUserInfo.TabIndex = 283
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaFactura.Location = New System.Drawing.Point(59, 47)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.ReadOnly = True
        Me.txtFechaFactura.Size = New System.Drawing.Size(99, 23)
        Me.txtFechaFactura.TabIndex = 111
        Me.txtFechaFactura.TabStop = False
        Me.txtFechaFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(159, 18)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(137, 23)
        Me.txtSecondID.TabIndex = 110
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label1.Location = New System.Drawing.Point(159, 48)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(33, 15)
        Me.label1.TabIndex = 108
        Me.label1.Text = "Hora"
        '
        'txtHoraFactura
        '
        Me.txtHoraFactura.Enabled = False
        Me.txtHoraFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHoraFactura.Location = New System.Drawing.Point(197, 45)
        Me.txtHoraFactura.Name = "txtHoraFactura"
        Me.txtHoraFactura.ReadOnly = True
        Me.txtHoraFactura.Size = New System.Drawing.Size(99, 23)
        Me.txtHoraFactura.TabIndex = 107
        Me.txtHoraFactura.TabStop = False
        Me.txtHoraFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDFactura
        '
        Me.txtIDFactura.Enabled = False
        Me.txtIDFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDFactura.Location = New System.Drawing.Point(59, 18)
        Me.txtIDFactura.Name = "txtIDFactura"
        Me.txtIDFactura.ReadOnly = True
        Me.txtIDFactura.Size = New System.Drawing.Size(94, 23)
        Me.txtIDFactura.TabIndex = 106
        Me.txtIDFactura.TabStop = False
        Me.txtIDFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label4.Location = New System.Drawing.Point(7, 48)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(38, 15)
        Me.label4.TabIndex = 105
        Me.label4.Text = "Fecha"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label3.Location = New System.Drawing.Point(7, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(46, 15)
        Me.label3.TabIndex = 104
        Me.label3.Text = "Código"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Label28)
        Me.groupBox1.Controls.Add(Me.txtCalificacion)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.txtCreditoDisponible)
        Me.groupBox1.Controls.Add(Me.txtUltimoPago)
        Me.groupBox1.Controls.Add(Me.label21)
        Me.groupBox1.Controls.Add(Me.txtBalanceGeneral)
        Me.groupBox1.Controls.Add(Me.label20)
        Me.groupBox1.Controls.Add(Me.nombre_label)
        Me.groupBox1.Controls.Add(Me.txtIDCliente)
        Me.groupBox1.Controls.Add(Me.txtNombre)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(4, 2)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(657, 76)
        Me.groupBox1.TabIndex = 270
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos Cliente"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(457, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(64, 15)
        Me.Label28.TabIndex = 182
        Me.Label28.Text = "Créd. Disp."
        '
        'txtCalificacion
        '
        Me.txtCalificacion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(403, 46)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(48, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label2.Location = New System.Drawing.Point(330, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(69, 15)
        Me.label2.TabIndex = 129
        Me.label2.Text = "Calificación"
        '
        'txtCreditoDisponible
        '
        Me.txtCreditoDisponible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreditoDisponible.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCreditoDisponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditoDisponible.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCreditoDisponible.Location = New System.Drawing.Point(526, 45)
        Me.txtCreditoDisponible.Name = "txtCreditoDisponible"
        Me.txtCreditoDisponible.ReadOnly = True
        Me.txtCreditoDisponible.Size = New System.Drawing.Size(124, 23)
        Me.txtCreditoDisponible.TabIndex = 180
        Me.txtCreditoDisponible.TabStop = False
        Me.txtCreditoDisponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(247, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(77, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(186, 48)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Últ. Pago"
        '
        'txtBalanceGeneral
        '
        Me.txtBalanceGeneral.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtBalanceGeneral.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalanceGeneral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGeneral.Location = New System.Drawing.Point(64, 45)
        Me.txtBalanceGeneral.Name = "txtBalanceGeneral"
        Me.txtBalanceGeneral.ReadOnly = True
        Me.txtBalanceGeneral.Size = New System.Drawing.Size(116, 23)
        Me.txtBalanceGeneral.TabIndex = 124
        Me.txtBalanceGeneral.TabStop = False
        Me.txtBalanceGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(7, 49)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(53, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Bce. Gral"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(7, 20)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(64, 17)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(116, 25)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(186, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(464, 25)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'tab_condicion_credito
        '
        Me.tab_condicion_credito.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tab_condicion_credito.Controls.Add(Me.tabPage1)
        Me.tab_condicion_credito.Controls.Add(Me.tabPage2)
        Me.tab_condicion_credito.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_condicion_credito.Location = New System.Drawing.Point(5, 415)
        Me.tab_condicion_credito.Name = "tab_condicion_credito"
        Me.tab_condicion_credito.SelectedIndex = 0
        Me.tab_condicion_credito.Size = New System.Drawing.Size(715, 125)
        Me.tab_condicion_credito.TabIndex = 273
        '
        'tabPage1
        '
        Me.tabPage1.AccessibleName = "credito_controls"
        Me.tabPage1.Controls.Add(Me.txtFechaAdicional)
        Me.tabPage1.Controls.Add(Me.txtFechaVencimiento)
        Me.tabPage1.Controls.Add(Me.label25)
        Me.tabPage1.Controls.Add(Me.label18)
        Me.tabPage1.Controls.Add(Me.txtCondicionContado)
        Me.tabPage1.Controls.Add(Me.chkFichaDatos)
        Me.tabPage1.Controls.Add(Me.chkHabilitarNota)
        Me.tabPage1.Controls.Add(Me.label17)
        Me.tabPage1.Controls.Add(Me.txtTotalPagar)
        Me.tabPage1.Controls.Add(Me.label16)
        Me.tabPage1.Controls.Add(Me.label15)
        Me.tabPage1.Controls.Add(Me.txtAdicional)
        Me.tabPage1.Controls.Add(Me.label14)
        Me.tabPage1.Controls.Add(Me.txtMontoPagos)
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.txtCantidadPagos)
        Me.tabPage1.Controls.Add(Me.label8)
        Me.tabPage1.Controls.Add(Me.txtInicial)
        Me.tabPage1.Location = New System.Drawing.Point(4, 27)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(707, 94)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Condiciones"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'txtFechaAdicional
        '
        Me.txtFechaAdicional.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaAdicional.Location = New System.Drawing.Point(610, 23)
        Me.txtFechaAdicional.Name = "txtFechaAdicional"
        Me.txtFechaAdicional.ReadOnly = True
        Me.txtFechaAdicional.Size = New System.Drawing.Size(88, 16)
        Me.txtFechaAdicional.TabIndex = 104
        Me.txtFechaAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(571, 67)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(128, 16)
        Me.txtFechaVencimiento.TabIndex = 103
        Me.txtFechaVencimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label25.Location = New System.Drawing.Point(568, 47)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(123, 15)
        Me.label25.TabIndex = 101
        Me.label25.Text = "Fecha de Vencimiento"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label18.Location = New System.Drawing.Point(135, 47)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(127, 15)
        Me.label18.TabIndex = 100
        Me.label18.Text = "Condición de Contado"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCondicionContado
        '
        Me.txtCondicionContado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCondicionContado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCondicionContado.Location = New System.Drawing.Point(138, 67)
        Me.txtCondicionContado.Name = "txtCondicionContado"
        Me.txtCondicionContado.ReadOnly = True
        Me.txtCondicionContado.Size = New System.Drawing.Size(427, 16)
        Me.txtCondicionContado.TabIndex = 18
        '
        'chkFichaDatos
        '
        Me.chkFichaDatos.AutoSize = True
        Me.chkFichaDatos.Enabled = False
        Me.chkFichaDatos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFichaDatos.Location = New System.Drawing.Point(12, 70)
        Me.chkFichaDatos.Name = "chkFichaDatos"
        Me.chkFichaDatos.Size = New System.Drawing.Size(102, 19)
        Me.chkFichaDatos.TabIndex = 17
        Me.chkFichaDatos.Text = "Habilitar Ficha"
        Me.chkFichaDatos.UseVisualStyleBackColor = True
        '
        'chkHabilitarNota
        '
        Me.chkHabilitarNota.AutoSize = True
        Me.chkHabilitarNota.Enabled = False
        Me.chkHabilitarNota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkHabilitarNota.Location = New System.Drawing.Point(12, 48)
        Me.chkHabilitarNota.Name = "chkHabilitarNota"
        Me.chkHabilitarNota.Size = New System.Drawing.Size(117, 19)
        Me.chkHabilitarNota.TabIndex = 16
        Me.chkHabilitarNota.Text = "Nota de Contado"
        Me.chkHabilitarNota.UseVisualStyleBackColor = True
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label17.Location = New System.Drawing.Point(135, 3)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(74, 15)
        Me.label17.TabIndex = 97
        Me.label17.Text = "Total a Pagar"
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalPagar.Location = New System.Drawing.Point(138, 23)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.Size = New System.Drawing.Size(125, 16)
        Me.txtTotalPagar.TabIndex = 96
        Me.txtTotalPagar.TabStop = False
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label16.Location = New System.Drawing.Point(607, 3)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(91, 15)
        Me.label16.TabIndex = 95
        Me.label16.Text = "Fecha Adicional"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.Location = New System.Drawing.Point(476, 3)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(87, 15)
        Me.label15.TabIndex = 93
        Me.label15.Text = "Pago Adicional"
        '
        'txtAdicional
        '
        Me.txtAdicional.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAdicional.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAdicional.Location = New System.Drawing.Point(479, 23)
        Me.txtAdicional.Name = "txtAdicional"
        Me.txtAdicional.ReadOnly = True
        Me.txtAdicional.Size = New System.Drawing.Size(125, 16)
        Me.txtAdicional.TabIndex = 14
        Me.txtAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label14.Location = New System.Drawing.Point(345, 3)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(117, 15)
        Me.label14.TabIndex = 91
        Me.label14.Text = "Montos de los Pagos"
        '
        'txtMontoPagos
        '
        Me.txtMontoPagos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMontoPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoPagos.Location = New System.Drawing.Point(348, 23)
        Me.txtMontoPagos.Name = "txtMontoPagos"
        Me.txtMontoPagos.ReadOnly = True
        Me.txtMontoPagos.Size = New System.Drawing.Size(125, 16)
        Me.txtMontoPagos.TabIndex = 90
        Me.txtMontoPagos.TabStop = False
        Me.txtMontoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label9.Location = New System.Drawing.Point(266, 3)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(58, 15)
        Me.label9.TabIndex = 89
        Me.label9.Text = "Cant. Pag"
        '
        'txtCantidadPagos
        '
        Me.txtCantidadPagos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCantidadPagos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadPagos.Location = New System.Drawing.Point(269, 23)
        Me.txtCantidadPagos.Name = "txtCantidadPagos"
        Me.txtCantidadPagos.ReadOnly = True
        Me.txtCantidadPagos.Size = New System.Drawing.Size(73, 16)
        Me.txtCantidadPagos.TabIndex = 13
        Me.txtCantidadPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label8.Location = New System.Drawing.Point(8, 3)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(38, 15)
        Me.label8.TabIndex = 87
        Me.label8.Text = "Inicial"
        '
        'txtInicial
        '
        Me.txtInicial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInicial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInicial.Location = New System.Drawing.Point(7, 23)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.ReadOnly = True
        Me.txtInicial.Size = New System.Drawing.Size(125, 16)
        Me.txtInicial.TabIndex = 12
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.DgvPagares)
        Me.tabPage2.Location = New System.Drawing.Point(4, 27)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(707, 94)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Pagares"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'DgvPagares
        '
        Me.DgvPagares.AllowUserToAddRows = False
        Me.DgvPagares.AllowUserToDeleteRows = False
        Me.DgvPagares.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPagares.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvPagares.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.DgvPagares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvPagares.Location = New System.Drawing.Point(5, 5)
        Me.DgvPagares.MultiSelect = False
        Me.DgvPagares.Name = "DgvPagares"
        Me.DgvPagares.ReadOnly = True
        Me.DgvPagares.RowHeadersWidth = 10
        Me.DgvPagares.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvPagares.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvPagares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPagares.Size = New System.Drawing.Size(696, 84)
        Me.DgvPagares.TabIndex = 0
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label13.Location = New System.Drawing.Point(760, 520)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(62, 15)
        Me.label13.TabIndex = 282
        Me.label13.Text = "Total Neto"
        '
        'txtNeto
        '
        Me.txtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNeto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNeto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNeto.Location = New System.Drawing.Point(829, 519)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(142, 16)
        Me.txtNeto.TabIndex = 281
        Me.txtNeto.TabStop = False
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(761, 445)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(63, 15)
        Me.label11.TabIndex = 278
        Me.label11.Text = "Descuento"
        '
        'TxtDescuentoSuma
        '
        Me.TxtDescuentoSuma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescuentoSuma.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescuentoSuma.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtDescuentoSuma.Location = New System.Drawing.Point(829, 444)
        Me.TxtDescuentoSuma.Name = "TxtDescuentoSuma"
        Me.TxtDescuentoSuma.ReadOnly = True
        Me.TxtDescuentoSuma.Size = New System.Drawing.Size(142, 16)
        Me.TxtDescuentoSuma.TabIndex = 277
        Me.TxtDescuentoSuma.TabStop = False
        Me.TxtDescuentoSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label10
        '
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(765, 420)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(57, 15)
        Me.label10.TabIndex = 276
        Me.label10.Text = "Sub-Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubTotal.Location = New System.Drawing.Point(829, 419)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(142, 16)
        Me.txtSubTotal.TabIndex = 275
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TbSelectProductos
        '
        Me.TbSelectProductos.Controls.Add(Me.dgvArticulosFactura)
        Me.TbSelectProductos.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbSelectProductos.Location = New System.Drawing.Point(5, 200)
        Me.TbSelectProductos.Name = "TbSelectProductos"
        Me.TbSelectProductos.Size = New System.Drawing.Size(971, 209)
        Me.TbSelectProductos.TabIndex = 272
        Me.TbSelectProductos.TabStop = False
        Me.TbSelectProductos.Text = "Artículos"
        '
        'dgvArticulosFactura
        '
        Me.dgvArticulosFactura.AllowUserToAddRows = False
        Me.dgvArticulosFactura.AllowUserToResizeColumns = False
        Me.dgvArticulosFactura.AllowUserToResizeRows = False
        Me.dgvArticulosFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticulosFactura.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvArticulosFactura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvArticulosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulosFactura.Location = New System.Drawing.Point(3, 16)
        Me.dgvArticulosFactura.Name = "dgvArticulosFactura"
        Me.dgvArticulosFactura.ReadOnly = True
        Me.dgvArticulosFactura.RowHeadersWidth = 30
        Me.dgvArticulosFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvArticulosFactura.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvArticulosFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulosFactura.Size = New System.Drawing.Size(965, 186)
        Me.dgvArticulosFactura.TabIndex = 162
        Me.dgvArticulosFactura.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtAlmacen)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtVehiculo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtChofer)
        Me.GroupBox2.Controls.Add(Me.txtVendedor)
        Me.GroupBox2.Controls.Add(Me.txtCobrador)
        Me.GroupBox2.Controls.Add(Me.label5)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(656, 72)
        Me.GroupBox2.TabIndex = 295
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Facturación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(192, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 15)
        Me.Label19.TabIndex = 212
        Me.Label19.Text = "Vehículo"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAlmacen.Location = New System.Drawing.Point(72, 46)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(114, 16)
        Me.txtAlmacen.TabIndex = 211
        Me.txtAlmacen.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(8, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 210
        Me.Label7.Text = "Almacén"
        '
        'txtVehiculo
        '
        Me.txtVehiculo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVehiculo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVehiculo.Location = New System.Drawing.Point(246, 46)
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.ReadOnly = True
        Me.txtVehiculo.Size = New System.Drawing.Size(152, 16)
        Me.txtVehiculo.TabIndex = 209
        Me.txtVehiculo.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(404, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "Chofer"
        '
        'txtChofer
        '
        Me.txtChofer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChofer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtChofer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtChofer.Location = New System.Drawing.Point(453, 46)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.ReadOnly = True
        Me.txtChofer.Size = New System.Drawing.Size(197, 16)
        Me.txtChofer.TabIndex = 207
        Me.txtChofer.TabStop = False
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtVendedor.Location = New System.Drawing.Point(72, 17)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(262, 16)
        Me.txtVendedor.TabIndex = 206
        Me.txtVendedor.TabStop = False
        '
        'txtCobrador
        '
        Me.txtCobrador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCobrador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobrador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCobrador.Location = New System.Drawing.Point(401, 17)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.ReadOnly = True
        Me.txtCobrador.Size = New System.Drawing.Size(248, 16)
        Me.txtCobrador.TabIndex = 204
        Me.txtCobrador.TabStop = False
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(8, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(58, 15)
        Me.label5.TabIndex = 203
        Me.label5.Text = "Vendedor"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(339, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 15)
        Me.Label27.TabIndex = 205
        Me.Label27.Text = "Cobrador"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStatus.Location = New System.Drawing.Point(804, 177)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(168, 16)
        Me.txtStatus.TabIndex = 294
        Me.txtStatus.TabStop = False
        Me.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBalance
        '
        Me.txtBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(804, 90)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(168, 16)
        Me.txtBalance.TabIndex = 293
        Me.txtBalance.TabStop = False
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiasVencidos
        '
        Me.txtDiasVencidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiasVencidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDiasVencidos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiasVencidos.Location = New System.Drawing.Point(804, 148)
        Me.txtDiasVencidos.Name = "txtDiasVencidos"
        Me.txtDiasVencidos.ReadOnly = True
        Me.txtDiasVencidos.Size = New System.Drawing.Size(168, 16)
        Me.txtDiasVencidos.TabIndex = 291
        Me.txtDiasVencidos.TabStop = False
        Me.txtDiasVencidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCargos
        '
        Me.txtCargos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCargos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCargos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCargos.Location = New System.Drawing.Point(804, 119)
        Me.txtCargos.Name = "txtCargos"
        Me.txtCargos.ReadOnly = True
        Me.txtCargos.Size = New System.Drawing.Size(168, 16)
        Me.txtCargos.TabIndex = 288
        Me.txtCargos.TabStop = False
        Me.txtCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(756, 178)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(42, 15)
        Me.Label32.TabIndex = 292
        Me.Label32.Text = "Status"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(715, 149)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(82, 15)
        Me.Label31.TabIndex = 290
        Me.Label31.Text = "Días Vencidos"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(734, 120)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 15)
        Me.Label30.TabIndex = 289
        Me.Label30.Text = "Cargos Ac."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(748, 91)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 15)
        Me.Label26.TabIndex = 287
        Me.Label26.Text = "Balance"
        '
        'TbcComprobante
        '
        Me.TbcComprobante.Controls.Add(Me.txtNCF)
        Me.TbcComprobante.Controls.Add(Me.Label34)
        Me.TbcComprobante.Controls.Add(Me.Label33)
        Me.TbcComprobante.Controls.Add(Me.txtNIF)
        Me.TbcComprobante.Controls.Add(Me.txtTipoComprobante)
        Me.TbcComprobante.Controls.Add(Me.label23)
        Me.TbcComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbcComprobante.Location = New System.Drawing.Point(4, 79)
        Me.TbcComprobante.Name = "TbcComprobante"
        Me.TbcComprobante.Size = New System.Drawing.Size(657, 45)
        Me.TbcComprobante.TabIndex = 286
        Me.TbcComprobante.TabStop = False
        Me.TbcComprobante.Text = "Tipo de Número de Comprobante Fiscal"
        '
        'txtNCF
        '
        Me.txtNCF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNCF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNCF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNCF.Location = New System.Drawing.Point(340, 18)
        Me.txtNCF.Name = "txtNCF"
        Me.txtNCF.ReadOnly = True
        Me.txtNCF.Size = New System.Drawing.Size(145, 16)
        Me.txtNCF.TabIndex = 184
        Me.txtNCF.TabStop = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label34.Location = New System.Drawing.Point(491, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(25, 15)
        Me.Label34.TabIndex = 183
        Me.Label34.Text = "NIF"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.Location = New System.Drawing.Point(305, 19)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(30, 15)
        Me.Label33.TabIndex = 182
        Me.Label33.Text = "NCF"
        '
        'txtNIF
        '
        Me.txtNIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNIF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNIF.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNIF.Location = New System.Drawing.Point(518, 18)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.ReadOnly = True
        Me.txtNIF.Size = New System.Drawing.Size(133, 16)
        Me.txtNIF.TabIndex = 181
        Me.txtNIF.TabStop = False
        '
        'txtTipoComprobante
        '
        Me.txtTipoComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTipoComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoComprobante.Location = New System.Drawing.Point(120, 18)
        Me.txtTipoComprobante.Name = "txtTipoComprobante"
        Me.txtTipoComprobante.ReadOnly = True
        Me.txtTipoComprobante.Size = New System.Drawing.Size(179, 16)
        Me.txtTipoComprobante.TabIndex = 180
        Me.txtTipoComprobante.TabStop = False
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label23.Location = New System.Drawing.Point(6, 20)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(107, 15)
        Me.label23.TabIndex = 2
        Me.label23.Text = "Tipo Combrobante"
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(99, 548)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(874, 16)
        Me.txtObservacion.TabIndex = 296
        Me.txtObservacion.TabStop = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 549)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 15)
        Me.Label22.TabIndex = 297
        Me.Label22.Text = "Observaciones:"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 576)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(980, 25)
        Me.BarraEstado.TabIndex = 413
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = Global.Libregco.My.Resources.Resources.Loading
        Me.PicLoading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PicLoading.Name = "PicLoading"
        Me.PicLoading.Size = New System.Drawing.Size(23, 22)
        Me.PicLoading.Text = "ToolStripButton1"
        Me.PicLoading.Visible = False
        '
        'ToolSeparator
        '
        Me.ToolSeparator.Name = "ToolSeparator"
        Me.ToolSeparator.Size = New System.Drawing.Size(6, 25)
        Me.ToolSeparator.Visible = False
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
        Me.NameSys.Font = New System.Drawing.Font("Segoe UI", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
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
        'frm_previsualizacion_facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 601)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.txtDiasVencidos)
        Me.Controls.Add(Me.txtCargos)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TbcComprobante)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtFlete)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.txtITBIS)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.tab_condicion_credito)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.TxtDescuentoSuma)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.TbSelectProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_previsualizacion_facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visualizacion de Facturas"
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.tab_condicion_credito.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        CType(Me.DgvPagares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbSelectProductos.ResumeLayout(False)
        CType(Me.dgvArticulosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TbcComprobante.ResumeLayout(False)
        Me.TbcComprobante.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents txtITBIS As System.Windows.Forms.TextBox
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtIDFactura As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents txtCreditoDisponible As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGeneral As System.Windows.Forms.TextBox
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents tab_condicion_credito As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents label25 As System.Windows.Forms.Label
    Friend WithEvents label18 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionContado As System.Windows.Forms.TextBox
    Friend WithEvents chkFichaDatos As System.Windows.Forms.CheckBox
    Friend WithEvents chkHabilitarNota As System.Windows.Forms.CheckBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents label16 As System.Windows.Forms.Label
    Friend WithEvents label15 As System.Windows.Forms.Label
    Friend WithEvents txtAdicional As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents txtMontoPagos As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPagos As System.Windows.Forms.TextBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DgvPagares As System.Windows.Forms.DataGridView
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuentoSuma As System.Windows.Forms.TextBox
    Friend WithEvents label10 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents TbSelectProductos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvArticulosFactura As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalPagar As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculo As System.Windows.Forms.TextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtCobrador As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasVencidos As System.Windows.Forms.TextBox
    Friend WithEvents txtCargos As System.Windows.Forms.TextBox
    Private WithEvents Label32 As System.Windows.Forms.Label
    Private WithEvents Label31 As System.Windows.Forms.Label
    Private WithEvents Label30 As System.Windows.Forms.Label
    Private WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TbcComprobante As System.Windows.Forms.GroupBox
    Friend WithEvents txtNCF As System.Windows.Forms.TextBox
    Private WithEvents Label34 As System.Windows.Forms.Label
    Private WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtNIF As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoComprobante As System.Windows.Forms.TextBox
    Private WithEvents label23 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtFechaAdicional As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
End Class
