<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_acuerdos_pago
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_acuerdos_pago))
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDeuda = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotaAcuerdo = New System.Windows.Forms.TextBox()
        Me.LabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDAcuerdo = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCalificacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUltimoPago = New System.Windows.Forms.TextBox()
        Me.label21 = New System.Windows.Forms.Label()
        Me.txtBalanceGral = New System.Windows.Forms.TextBox()
        Me.label20 = New System.Windows.Forms.Label()
        Me.cod_cliente_label = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdbCerrado = New System.Windows.Forms.RadioButton()
        Me.rdbAbierto = New System.Windows.Forms.RadioButton()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDeudor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDomicilioDeudor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbxIdentificacionDeudor = New System.Windows.Forms.ComboBox()
        Me.cbxIdentificacionAcreedor = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDomicilioAcreedor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAcreedor = New System.Windows.Forms.TextBox()
        Me.cbxTipoIdentNotario = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDomicilioNotario = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNotario = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNacionalidadNotario = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNacionalidadAcreedor = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtNacionalidadDeudor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCiudadAcuerdo = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtMunicipioAcuerdo = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtProvinciaAcuerdo = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtProvinciaAcreedor = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtMunicipioAcreedor = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtProvinciaDeudor = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMunicipioDeudor = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCantidadCuotas = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtDiasPago = New System.Windows.Forms.NumericUpDown()
        Me.txtTestigo1 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtMontoCuotas = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtIdentificacionAcreedor = New System.Windows.Forms.MaskedTextBox()
        Me.txtEstadoCivilAcreedor = New System.Windows.Forms.TextBox()
        Me.txtTratamientoAcreedor = New System.Windows.Forms.TextBox()
        Me.txtOcupacionAcreedor = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cbxGeneroAcreedor = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIdentificacionDeudor = New System.Windows.Forms.MaskedTextBox()
        Me.txtEstadoCivilDeudor = New System.Windows.Forms.TextBox()
        Me.txtTratamientoDeudor = New System.Windows.Forms.TextBox()
        Me.txtOcupacionDeudor = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cbxGeneroDeudor = New System.Windows.Forms.ComboBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblSumaLetraCuotas = New System.Windows.Forms.Label()
        Me.lblSumaLetraMonto = New System.Windows.Forms.Label()
        Me.cbxGeneroNotario = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtIdentificacionTestigo2 = New System.Windows.Forms.MaskedTextBox()
        Me.txtIdentificacionTestigo1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtNoRegistroNotario = New System.Windows.Forms.TextBox()
        Me.txtIdentificacionNotario = New System.Windows.Forms.MaskedTextBox()
        Me.dtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtInteres = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtNacionalidadTestigo2 = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtDomicilioTestigo2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cbxIdentificacionTestigo2 = New System.Windows.Forms.ComboBox()
        Me.txtTestigo2 = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtNacionalidadTestigo1 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtDomicilioTestigo1 = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cbxIdentificacionTestigo1 = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextAcuerdo = New System.Windows.Forms.RichTextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkPagareNotarial = New System.Windows.Forms.RadioButton()
        Me.chkAcuerdoSimplificado = New System.Windows.Forms.RadioButton()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibosEmitidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbxUserInfo.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        CType(Me.txtDiasPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'EstadoDeCuentaToolStripMenuItem
        '
        Me.EstadoDeCuentaToolStripMenuItem.Name = "EstadoDeCuentaToolStripMenuItem"
        Me.EstadoDeCuentaToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EstadoDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.EstadoDeCuentaToolStripMenuItem.Text = "Estado de Cuenta"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(203, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaLibregcoToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AyudaLibregcoToolStripMenuItem
        '
        Me.AyudaLibregcoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(92, 110)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 197
        '
        'DtpFecha
        '
        Me.DtpFecha.CalendarFont = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFecha.CustomFormat = "yyyy-MM-dd"
        Me.DtpFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFecha.Location = New System.Drawing.Point(92, 6)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(102, 23)
        Me.DtpFecha.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Fecha "
        '
        'txtDeuda
        '
        Me.txtDeuda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDeuda.ForeColor = System.Drawing.Color.Black
        Me.txtDeuda.Location = New System.Drawing.Point(92, 269)
        Me.txtDeuda.Name = "txtDeuda"
        Me.txtDeuda.Size = New System.Drawing.Size(146, 23)
        Me.txtDeuda.TabIndex = 34
        Me.txtDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 272)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Monto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(484, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "Notas"
        '
        'txtNotaAcuerdo
        '
        Me.txtNotaAcuerdo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNotaAcuerdo.Location = New System.Drawing.Point(563, 241)
        Me.txtNotaAcuerdo.Multiline = True
        Me.txtNotaAcuerdo.Name = "txtNotaAcuerdo"
        Me.txtNotaAcuerdo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotaAcuerdo.Size = New System.Drawing.Size(360, 39)
        Me.txtNotaAcuerdo.TabIndex = 48
        '
        'LabelStatus
        '
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(32, 17)
        Me.LabelStatus.Text = "Listo"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDAcuerdo)
        Me.GbxUserInfo.Controls.Add(Me.label8)
        Me.GbxUserInfo.Controls.Add(Me.Label6)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label7)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(614, 127)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 205
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(174, 18)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(158, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDAcuerdo
        '
        Me.txtIDAcuerdo.Enabled = False
        Me.txtIDAcuerdo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAcuerdo.Location = New System.Drawing.Point(59, 17)
        Me.txtIDAcuerdo.Name = "txtIDAcuerdo"
        Me.txtIDAcuerdo.ReadOnly = True
        Me.txtIDAcuerdo.Size = New System.Drawing.Size(109, 23)
        Me.txtIDAcuerdo.TabIndex = 139
        Me.txtIDAcuerdo.TabStop = False
        Me.txtIDAcuerdo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label8.Location = New System.Drawing.Point(6, 20)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(46, 15)
        Me.label8.TabIndex = 140
        Me.label8.Text = "Código"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(6, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 47)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(118, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(174, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(59, 46)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.groupBox1.Controls.Add(Me.txtCalificacion)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Controls.Add(Me.txtUltimoPago)
        Me.groupBox1.Controls.Add(Me.label21)
        Me.groupBox1.Controls.Add(Me.txtBalanceGral)
        Me.groupBox1.Controls.Add(Me.label20)
        Me.groupBox1.Controls.Add(Me.cod_cliente_label)
        Me.groupBox1.Controls.Add(Me.nombre_label)
        Me.groupBox1.Controls.Add(Me.txtIDCliente)
        Me.groupBox1.Controls.Add(Me.txtNombre)
        Me.groupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.groupBox1.Location = New System.Drawing.Point(8, 127)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(602, 76)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Datos Cliente"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(155, 17)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnBuscarCliente.TabIndex = 0
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtCalificacion
        '
        Me.txtCalificacion.Enabled = False
        Me.txtCalificacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCalificacion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtCalificacion.Location = New System.Drawing.Point(501, 47)
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ReadOnly = True
        Me.txtCalificacion.Size = New System.Drawing.Size(94, 23)
        Me.txtCalificacion.TabIndex = 130
        Me.txtCalificacion.TabStop = False
        Me.txtCalificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(426, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 15)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Calificación"
        '
        'txtUltimoPago
        '
        Me.txtUltimoPago.Enabled = False
        Me.txtUltimoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUltimoPago.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtUltimoPago.Location = New System.Drawing.Point(298, 46)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.ReadOnly = True
        Me.txtUltimoPago.Size = New System.Drawing.Size(122, 23)
        Me.txtUltimoPago.TabIndex = 126
        Me.txtUltimoPago.TabStop = False
        Me.txtUltimoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label21.Location = New System.Drawing.Point(219, 49)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(73, 15)
        Me.label21.TabIndex = 125
        Me.label21.Text = "Último Pago"
        '
        'txtBalanceGral
        '
        Me.txtBalanceGral.Enabled = False
        Me.txtBalanceGral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalanceGral.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtBalanceGral.Location = New System.Drawing.Point(88, 46)
        Me.txtBalanceGral.Name = "txtBalanceGral"
        Me.txtBalanceGral.ReadOnly = True
        Me.txtBalanceGral.Size = New System.Drawing.Size(125, 23)
        Me.txtBalanceGral.TabIndex = 124
        Me.txtBalanceGral.TabStop = False
        Me.txtBalanceGral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.label20.Location = New System.Drawing.Point(10, 49)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(72, 15)
        Me.label20.TabIndex = 123
        Me.label20.Text = "Balance Gral"
        '
        'cod_cliente_label
        '
        Me.cod_cliente_label.AutoSize = True
        Me.cod_cliente_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cod_cliente_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.cod_cliente_label.Location = New System.Drawing.Point(10, 20)
        Me.cod_cliente_label.Name = "cod_cliente_label"
        Me.cod_cliente_label.Size = New System.Drawing.Size(46, 15)
        Me.cod_cliente_label.TabIndex = 100
        Me.cod_cliente_label.Text = "Código"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nombre_label.Location = New System.Drawing.Point(182, 20)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 96
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDCliente
        '
        Me.txtIDCliente.BackColor = System.Drawing.Color.LightGray
        Me.txtIDCliente.Enabled = False
        Me.txtIDCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDCliente.Location = New System.Drawing.Point(62, 17)
        Me.txtIDCliente.Name = "txtIDCliente"
        Me.txtIDCliente.ReadOnly = True
        Me.txtIDCliente.Size = New System.Drawing.Size(95, 23)
        Me.txtIDCliente.TabIndex = 93
        Me.txtIDCliente.TabStop = False
        Me.txtIDCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombre.Location = New System.Drawing.Point(239, 17)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(356, 23)
        Me.txtNombre.TabIndex = 94
        Me.txtNombre.TabStop = False
        '
        'ChkNulo
        '
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Location = New System.Drawing.Point(404, 104)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(48, 17)
        Me.ChkNulo.TabIndex = 206
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem6, Me.ToolStripMenuItem8})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(956, 24)
        Me.MenuStrip1.TabIndex = 289
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator2, Me.ToolStripMenuItem5})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(66, 20)
        Me.ToolStripMenuItem1.Text = "Procesos"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem2.Text = "Nuevo "
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.ToolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem3.Text = "Guardar"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ToolStripMenuItem4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem4.Text = "Buscar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(177, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.ToolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem5.Text = "Salir"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7})
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(58, 20)
        Me.ToolStripMenuItem6.Text = "Edición"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.ToolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(165, 38)
        Me.ToolStripMenuItem7.Text = "Anular"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem9})
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripMenuItem8.Text = "Ayuda"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.ToolStripMenuItem9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(173, 38)
        Me.ToolStripMenuItem9.Text = "Ayuda Libregco"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdbCerrado)
        Me.GroupBox3.Controls.Add(Me.rdbAbierto)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(778, 280)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 41)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status del Acuerdo"
        '
        'rdbCerrado
        '
        Me.rdbCerrado.AutoSize = True
        Me.rdbCerrado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbCerrado.Location = New System.Drawing.Point(73, 15)
        Me.rdbCerrado.Name = "rdbCerrado"
        Me.rdbCerrado.Size = New System.Drawing.Size(67, 19)
        Me.rdbCerrado.TabIndex = 50
        Me.rdbCerrado.Text = "Cerrado"
        Me.rdbCerrado.UseVisualStyleBackColor = True
        '
        'rdbAbierto
        '
        Me.rdbAbierto.AutoSize = True
        Me.rdbAbierto.Checked = True
        Me.rdbAbierto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbAbierto.Location = New System.Drawing.Point(9, 15)
        Me.rdbAbierto.Name = "rdbAbierto"
        Me.rdbAbierto.Size = New System.Drawing.Size(64, 19)
        Me.rdbAbierto.TabIndex = 49
        Me.rdbAbierto.TabStop = True
        Me.rdbAbierto.Text = "Abierto"
        Me.rdbAbierto.UseVisualStyleBackColor = True
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(525, 23)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 328
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.btnGuardar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardar.Text = "Solo Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnGuardaryLimpiar
        '
        Me.btnGuardaryLimpiar.Image = CType(resources.GetObject("btnGuardaryLimpiar.Image"), System.Drawing.Image)
        Me.btnGuardaryLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardaryLimpiar.Name = "btnGuardaryLimpiar"
        Me.btnGuardaryLimpiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.btnGuardaryLimpiar.Size = New System.Drawing.Size(242, 54)
        Me.btnGuardaryLimpiar.Text = "Guardar y Limpiar"
        Me.btnGuardaryLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(84, 95)
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Checked = True
        Me.btnImprimir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnImprimir.Image = Global.Libregco.My.Resources.Resources.Printer_x72
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar, Me.ToolStripLabel1})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 608)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(956, 25)
        Me.BarraEstado.TabIndex = 329
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(404, 22)
        Me.ToolStripLabel1.Text = "Complete todos los campos para la impresión de documentos de uso legal."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 15)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Deudor"
        '
        'txtDeudor
        '
        Me.txtDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtDeudor.Location = New System.Drawing.Point(94, 46)
        Me.txtDeudor.Name = "txtDeudor"
        Me.txtDeudor.Size = New System.Drawing.Size(362, 23)
        Me.txtDeudor.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Domicilio"
        '
        'txtDomicilioDeudor
        '
        Me.txtDomicilioDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDomicilioDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtDomicilioDeudor.Location = New System.Drawing.Point(94, 75)
        Me.txtDomicilioDeudor.Name = "txtDomicilioDeudor"
        Me.txtDomicilioDeudor.Size = New System.Drawing.Size(362, 23)
        Me.txtDomicilioDeudor.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(9, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Identificación"
        '
        'cbxIdentificacionDeudor
        '
        Me.cbxIdentificacionDeudor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxIdentificacionDeudor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxIdentificacionDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxIdentificacionDeudor.ForeColor = System.Drawing.Color.Black
        Me.cbxIdentificacionDeudor.FormattingEnabled = True
        Me.cbxIdentificacionDeudor.Location = New System.Drawing.Point(94, 104)
        Me.cbxIdentificacionDeudor.Name = "cbxIdentificacionDeudor"
        Me.cbxIdentificacionDeudor.Size = New System.Drawing.Size(137, 23)
        Me.cbxIdentificacionDeudor.TabIndex = 5
        '
        'cbxIdentificacionAcreedor
        '
        Me.cbxIdentificacionAcreedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxIdentificacionAcreedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxIdentificacionAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxIdentificacionAcreedor.ForeColor = System.Drawing.Color.Black
        Me.cbxIdentificacionAcreedor.FormattingEnabled = True
        Me.cbxIdentificacionAcreedor.Location = New System.Drawing.Point(91, 103)
        Me.cbxIdentificacionAcreedor.Name = "cbxIdentificacionAcreedor"
        Me.cbxIdentificacionAcreedor.Size = New System.Drawing.Size(146, 23)
        Me.cbxIdentificacionAcreedor.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 15)
        Me.Label11.TabIndex = 102
        Me.Label11.Text = "Identificación"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Domicilio"
        '
        'txtDomicilioAcreedor
        '
        Me.txtDomicilioAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDomicilioAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtDomicilioAcreedor.Location = New System.Drawing.Point(91, 74)
        Me.txtDomicilioAcreedor.Name = "txtDomicilioAcreedor"
        Me.txtDomicilioAcreedor.Size = New System.Drawing.Size(340, 23)
        Me.txtDomicilioAcreedor.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(6, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 15)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Acreedor"
        '
        'txtAcreedor
        '
        Me.txtAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtAcreedor.Location = New System.Drawing.Point(91, 45)
        Me.txtAcreedor.Name = "txtAcreedor"
        Me.txtAcreedor.Size = New System.Drawing.Size(340, 23)
        Me.txtAcreedor.TabIndex = 14
        '
        'cbxTipoIdentNotario
        '
        Me.cbxTipoIdentNotario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoIdentNotario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoIdentNotario.ForeColor = System.Drawing.Color.Black
        Me.cbxTipoIdentNotario.FormattingEnabled = True
        Me.cbxTipoIdentNotario.Location = New System.Drawing.Point(92, 151)
        Me.cbxTipoIdentNotario.Name = "cbxTipoIdentNotario"
        Me.cbxTipoIdentNotario.Size = New System.Drawing.Size(146, 23)
        Me.cbxTipoIdentNotario.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(7, 154)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 15)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "Identificación"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(7, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 15)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Domicilio"
        '
        'txtDomicilioNotario
        '
        Me.txtDomicilioNotario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDomicilioNotario.ForeColor = System.Drawing.Color.Black
        Me.txtDomicilioNotario.Location = New System.Drawing.Point(92, 122)
        Me.txtDomicilioNotario.Name = "txtDomicilioNotario"
        Me.txtDomicilioNotario.Size = New System.Drawing.Size(363, 23)
        Me.txtDomicilioNotario.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(7, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 15)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Notario"
        '
        'txtNotario
        '
        Me.txtNotario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNotario.ForeColor = System.Drawing.Color.Black
        Me.txtNotario.Location = New System.Drawing.Point(93, 64)
        Me.txtNotario.Name = "txtNotario"
        Me.txtNotario.Size = New System.Drawing.Size(362, 23)
        Me.txtNotario.TabIndex = 26
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(7, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 15)
        Me.Label17.TabIndex = 292
        Me.Label17.Text = "Nacionalidad"
        '
        'txtNacionalidadNotario
        '
        Me.txtNacionalidadNotario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidadNotario.ForeColor = System.Drawing.Color.Black
        Me.txtNacionalidadNotario.Location = New System.Drawing.Point(92, 180)
        Me.txtNacionalidadNotario.Name = "txtNacionalidadNotario"
        Me.txtNacionalidadNotario.Size = New System.Drawing.Size(363, 23)
        Me.txtNacionalidadNotario.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(6, 135)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 15)
        Me.Label18.TabIndex = 294
        Me.Label18.Text = "Nacionalidad"
        '
        'txtNacionalidadAcreedor
        '
        Me.txtNacionalidadAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidadAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtNacionalidadAcreedor.Location = New System.Drawing.Point(91, 132)
        Me.txtNacionalidadAcreedor.Name = "txtNacionalidadAcreedor"
        Me.txtNacionalidadAcreedor.Size = New System.Drawing.Size(340, 23)
        Me.txtNacionalidadAcreedor.TabIndex = 18
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(9, 136)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(77, 15)
        Me.Label19.TabIndex = 294
        Me.Label19.Text = "Nacionalidad"
        '
        'txtNacionalidadDeudor
        '
        Me.txtNacionalidadDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidadDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtNacionalidadDeudor.Location = New System.Drawing.Point(94, 133)
        Me.txtNacionalidadDeudor.Name = "txtNacionalidadDeudor"
        Me.txtNacionalidadDeudor.Size = New System.Drawing.Size(362, 23)
        Me.txtNacionalidadDeudor.TabIndex = 7
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(7, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 15)
        Me.Label22.TabIndex = 294
        Me.Label22.Text = "Ciudad"
        '
        'txtCiudadAcuerdo
        '
        Me.txtCiudadAcuerdo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCiudadAcuerdo.ForeColor = System.Drawing.Color.Black
        Me.txtCiudadAcuerdo.Location = New System.Drawing.Point(92, 35)
        Me.txtCiudadAcuerdo.Name = "txtCiudadAcuerdo"
        Me.txtCiudadAcuerdo.Size = New System.Drawing.Size(175, 23)
        Me.txtCiudadAcuerdo.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(9, 165)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 15)
        Me.Label23.TabIndex = 295
        Me.Label23.Text = "Estado Civil"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(6, 164)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 15)
        Me.Label24.TabIndex = 297
        Me.Label24.Text = "Estado Civil"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(7, 212)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 15)
        Me.Label25.TabIndex = 296
        Me.Label25.Text = "Municipio"
        '
        'txtMunicipioAcuerdo
        '
        Me.txtMunicipioAcuerdo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipioAcuerdo.ForeColor = System.Drawing.Color.Black
        Me.txtMunicipioAcuerdo.Location = New System.Drawing.Point(92, 209)
        Me.txtMunicipioAcuerdo.Name = "txtMunicipioAcuerdo"
        Me.txtMunicipioAcuerdo.Size = New System.Drawing.Size(363, 23)
        Me.txtMunicipioAcuerdo.TabIndex = 32
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(8, 241)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 15)
        Me.Label26.TabIndex = 298
        Me.Label26.Text = "Provincia"
        '
        'txtProvinciaAcuerdo
        '
        Me.txtProvinciaAcuerdo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvinciaAcuerdo.ForeColor = System.Drawing.Color.Black
        Me.txtProvinciaAcuerdo.Location = New System.Drawing.Point(93, 238)
        Me.txtProvinciaAcuerdo.Name = "txtProvinciaAcuerdo"
        Me.txtProvinciaAcuerdo.Size = New System.Drawing.Size(363, 23)
        Me.txtProvinciaAcuerdo.TabIndex = 33
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(7, 251)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 15)
        Me.Label27.TabIndex = 302
        Me.Label27.Text = "Provincia"
        '
        'txtProvinciaAcreedor
        '
        Me.txtProvinciaAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvinciaAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtProvinciaAcreedor.Location = New System.Drawing.Point(92, 248)
        Me.txtProvinciaAcreedor.Name = "txtProvinciaAcreedor"
        Me.txtProvinciaAcreedor.Size = New System.Drawing.Size(340, 23)
        Me.txtProvinciaAcreedor.TabIndex = 22
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(6, 222)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 15)
        Me.Label28.TabIndex = 300
        Me.Label28.Text = "Municipio"
        '
        'txtMunicipioAcreedor
        '
        Me.txtMunicipioAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipioAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtMunicipioAcreedor.Location = New System.Drawing.Point(91, 219)
        Me.txtMunicipioAcreedor.Name = "txtMunicipioAcreedor"
        Me.txtMunicipioAcreedor.Size = New System.Drawing.Size(340, 23)
        Me.txtMunicipioAcreedor.TabIndex = 21
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(11, 252)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 15)
        Me.Label29.TabIndex = 302
        Me.Label29.Text = "Provincia"
        '
        'txtProvinciaDeudor
        '
        Me.txtProvinciaDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtProvinciaDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtProvinciaDeudor.Location = New System.Drawing.Point(96, 249)
        Me.txtProvinciaDeudor.Name = "txtProvinciaDeudor"
        Me.txtProvinciaDeudor.Size = New System.Drawing.Size(357, 23)
        Me.txtProvinciaDeudor.TabIndex = 11
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(10, 223)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 15)
        Me.Label30.TabIndex = 300
        Me.Label30.Text = "Municipio"
        '
        'txtMunicipioDeudor
        '
        Me.txtMunicipioDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMunicipioDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtMunicipioDeudor.Location = New System.Drawing.Point(95, 220)
        Me.txtMunicipioDeudor.Name = "txtMunicipioDeudor"
        Me.txtMunicipioDeudor.Size = New System.Drawing.Size(357, 23)
        Me.txtMunicipioDeudor.TabIndex = 10
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(6, 302)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(75, 15)
        Me.Label31.TabIndex = 299
        Me.Label31.Text = "Cant. Cuotas"
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCantidadCuotas.ForeColor = System.Drawing.Color.Black
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(92, 298)
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(119, 23)
        Me.txtCantidadCuotas.TabIndex = 35
        Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(566, 349)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 15)
        Me.Label32.TabIndex = 302
        Me.Label32.Text = "Día de pago"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(715, 350)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 15)
        Me.Label33.TabIndex = 303
        Me.Label33.Text = "de c/mes"
        '
        'txtDiasPago
        '
        Me.txtDiasPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiasPago.Location = New System.Drawing.Point(653, 347)
        Me.txtDiasPago.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.txtDiasPago.Name = "txtDiasPago"
        Me.txtDiasPago.Size = New System.Drawing.Size(56, 23)
        Me.txtDiasPago.TabIndex = 36
        Me.txtDiasPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTestigo1
        '
        Me.txtTestigo1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTestigo1.ForeColor = System.Drawing.Color.Black
        Me.txtTestigo1.Location = New System.Drawing.Point(566, 9)
        Me.txtTestigo1.Name = "txtTestigo1"
        Me.txtTestigo1.Size = New System.Drawing.Size(358, 23)
        Me.txtTestigo1.TabIndex = 38
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(484, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(54, 15)
        Me.Label34.TabIndex = 306
        Me.Label34.Text = "Testigo 1"
        '
        'txtMontoCuotas
        '
        Me.txtMontoCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMontoCuotas.ForeColor = System.Drawing.Color.Black
        Me.txtMontoCuotas.Location = New System.Drawing.Point(307, 299)
        Me.txtMontoCuotas.Name = "txtMontoCuotas"
        Me.txtMontoCuotas.ReadOnly = True
        Me.txtMontoCuotas.Size = New System.Drawing.Size(149, 23)
        Me.txtMontoCuotas.TabIndex = 312
        Me.txtMontoCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(217, 302)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(84, 15)
        Me.Label37.TabIndex = 311
        Me.Label37.Text = "Cuotas de RD$"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(8, 209)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(942, 396)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(934, 368)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Deudor & Acreedor"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtIdentificacionAcreedor)
        Me.GroupBox4.Controls.Add(Me.txtEstadoCivilAcreedor)
        Me.GroupBox4.Controls.Add(Me.txtTratamientoAcreedor)
        Me.GroupBox4.Controls.Add(Me.txtOcupacionAcreedor)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.cbxGeneroAcreedor)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.txtProvinciaAcreedor)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.txtAcreedor)
        Me.GroupBox4.Controls.Add(Me.cbxIdentificacionAcreedor)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.txtDomicilioAcreedor)
        Me.GroupBox4.Controls.Add(Me.txtNacionalidadAcreedor)
        Me.GroupBox4.Controls.Add(Me.txtMunicipioAcreedor)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(485, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(443, 316)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Acreedor"
        '
        'txtIdentificacionAcreedor
        '
        Me.txtIdentificacionAcreedor.Location = New System.Drawing.Point(243, 103)
        Me.txtIdentificacionAcreedor.Name = "txtIdentificacionAcreedor"
        Me.txtIdentificacionAcreedor.Size = New System.Drawing.Size(188, 23)
        Me.txtIdentificacionAcreedor.TabIndex = 17
        Me.txtIdentificacionAcreedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEstadoCivilAcreedor
        '
        Me.txtEstadoCivilAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEstadoCivilAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtEstadoCivilAcreedor.Location = New System.Drawing.Point(91, 161)
        Me.txtEstadoCivilAcreedor.Name = "txtEstadoCivilAcreedor"
        Me.txtEstadoCivilAcreedor.Size = New System.Drawing.Size(140, 23)
        Me.txtEstadoCivilAcreedor.TabIndex = 19
        '
        'txtTratamientoAcreedor
        '
        Me.txtTratamientoAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTratamientoAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtTratamientoAcreedor.Location = New System.Drawing.Point(309, 16)
        Me.txtTratamientoAcreedor.Name = "txtTratamientoAcreedor"
        Me.txtTratamientoAcreedor.Size = New System.Drawing.Size(122, 23)
        Me.txtTratamientoAcreedor.TabIndex = 13
        '
        'txtOcupacionAcreedor
        '
        Me.txtOcupacionAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOcupacionAcreedor.ForeColor = System.Drawing.Color.Black
        Me.txtOcupacionAcreedor.Location = New System.Drawing.Point(91, 190)
        Me.txtOcupacionAcreedor.Name = "txtOcupacionAcreedor"
        Me.txtOcupacionAcreedor.Size = New System.Drawing.Size(357, 23)
        Me.txtOcupacionAcreedor.TabIndex = 20
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(234, 19)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(71, 15)
        Me.Label51.TabIndex = 310
        Me.Label51.Text = "Tratamiento"
        '
        'cbxGeneroAcreedor
        '
        Me.cbxGeneroAcreedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGeneroAcreedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxGeneroAcreedor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGeneroAcreedor.ForeColor = System.Drawing.Color.Black
        Me.cbxGeneroAcreedor.FormattingEnabled = True
        Me.cbxGeneroAcreedor.Location = New System.Drawing.Point(91, 16)
        Me.cbxGeneroAcreedor.Name = "cbxGeneroAcreedor"
        Me.cbxGeneroAcreedor.Size = New System.Drawing.Size(137, 23)
        Me.cbxGeneroAcreedor.TabIndex = 12
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(6, 19)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(45, 15)
        Me.Label49.TabIndex = 308
        Me.Label49.Text = "Género"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(6, 193)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(57, 15)
        Me.Label47.TabIndex = 306
        Me.Label47.Text = "Profesión"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIdentificacionDeudor)
        Me.GroupBox2.Controls.Add(Me.txtEstadoCivilDeudor)
        Me.GroupBox2.Controls.Add(Me.txtTratamientoDeudor)
        Me.GroupBox2.Controls.Add(Me.txtOcupacionDeudor)
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.cbxGeneroDeudor)
        Me.GroupBox2.Controls.Add(Me.Label48)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtNacionalidadDeudor)
        Me.GroupBox2.Controls.Add(Me.Label44)
        Me.GroupBox2.Controls.Add(Me.cbxIdentificacionDeudor)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtProvinciaDeudor)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDeudor)
        Me.GroupBox2.Controls.Add(Me.txtMunicipioDeudor)
        Me.GroupBox2.Controls.Add(Me.txtDomicilioDeudor)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(463, 318)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Deudor"
        '
        'txtIdentificacionDeudor
        '
        Me.txtIdentificacionDeudor.Location = New System.Drawing.Point(237, 104)
        Me.txtIdentificacionDeudor.Name = "txtIdentificacionDeudor"
        Me.txtIdentificacionDeudor.Size = New System.Drawing.Size(219, 23)
        Me.txtIdentificacionDeudor.TabIndex = 6
        Me.txtIdentificacionDeudor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEstadoCivilDeudor
        '
        Me.txtEstadoCivilDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEstadoCivilDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtEstadoCivilDeudor.Location = New System.Drawing.Point(95, 162)
        Me.txtEstadoCivilDeudor.Name = "txtEstadoCivilDeudor"
        Me.txtEstadoCivilDeudor.Size = New System.Drawing.Size(140, 23)
        Me.txtEstadoCivilDeudor.TabIndex = 8
        '
        'txtTratamientoDeudor
        '
        Me.txtTratamientoDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTratamientoDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtTratamientoDeudor.Location = New System.Drawing.Point(316, 17)
        Me.txtTratamientoDeudor.Name = "txtTratamientoDeudor"
        Me.txtTratamientoDeudor.Size = New System.Drawing.Size(140, 23)
        Me.txtTratamientoDeudor.TabIndex = 2
        '
        'txtOcupacionDeudor
        '
        Me.txtOcupacionDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOcupacionDeudor.ForeColor = System.Drawing.Color.Black
        Me.txtOcupacionDeudor.Location = New System.Drawing.Point(94, 191)
        Me.txtOcupacionDeudor.Name = "txtOcupacionDeudor"
        Me.txtOcupacionDeudor.Size = New System.Drawing.Size(357, 23)
        Me.txtOcupacionDeudor.TabIndex = 9
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(238, 19)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(71, 15)
        Me.Label50.TabIndex = 308
        Me.Label50.Text = "Tratamiento"
        '
        'cbxGeneroDeudor
        '
        Me.cbxGeneroDeudor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGeneroDeudor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxGeneroDeudor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGeneroDeudor.ForeColor = System.Drawing.Color.Black
        Me.cbxGeneroDeudor.FormattingEnabled = True
        Me.cbxGeneroDeudor.Location = New System.Drawing.Point(95, 17)
        Me.cbxGeneroDeudor.Name = "cbxGeneroDeudor"
        Me.cbxGeneroDeudor.Size = New System.Drawing.Size(137, 23)
        Me.cbxGeneroDeudor.TabIndex = 1
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(10, 20)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(45, 15)
        Me.Label48.TabIndex = 306
        Me.Label48.Text = "Género"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label44.ForeColor = System.Drawing.Color.Black
        Me.Label44.Location = New System.Drawing.Point(10, 194)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(57, 15)
        Me.Label44.TabIndex = 304
        Me.Label44.Text = "Profesión"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.lblSumaLetraCuotas)
        Me.TabPage3.Controls.Add(Me.lblSumaLetraMonto)
        Me.TabPage3.Controls.Add(Me.cbxGeneroNotario)
        Me.TabPage3.Controls.Add(Me.Label53)
        Me.TabPage3.Controls.Add(Me.txtIdentificacionTestigo2)
        Me.TabPage3.Controls.Add(Me.txtIdentificacionTestigo1)
        Me.TabPage3.Controls.Add(Me.Label52)
        Me.TabPage3.Controls.Add(Me.txtNoRegistroNotario)
        Me.TabPage3.Controls.Add(Me.txtIdentificacionNotario)
        Me.TabPage3.Controls.Add(Me.dtpVencimiento)
        Me.TabPage3.Controls.Add(Me.Label38)
        Me.TabPage3.Controls.Add(Me.Label46)
        Me.TabPage3.Controls.Add(Me.txtInteres)
        Me.TabPage3.Controls.Add(Me.Label45)
        Me.TabPage3.Controls.Add(Me.txtNacionalidadTestigo2)
        Me.TabPage3.Controls.Add(Me.Label40)
        Me.TabPage3.Controls.Add(Me.txtDomicilioTestigo2)
        Me.TabPage3.Controls.Add(Me.Label41)
        Me.TabPage3.Controls.Add(Me.Label42)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.txtNotaAcuerdo)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.cbxIdentificacionTestigo2)
        Me.TabPage3.Controls.Add(Me.txtTestigo2)
        Me.TabPage3.Controls.Add(Me.Label43)
        Me.TabPage3.Controls.Add(Me.txtNacionalidadTestigo1)
        Me.TabPage3.Controls.Add(Me.Label35)
        Me.TabPage3.Controls.Add(Me.txtDomicilioTestigo1)
        Me.TabPage3.Controls.Add(Me.Label39)
        Me.TabPage3.Controls.Add(Me.Label36)
        Me.TabPage3.Controls.Add(Me.cbxIdentificacionTestigo1)
        Me.TabPage3.Controls.Add(Me.txtMontoCuotas)
        Me.TabPage3.Controls.Add(Me.DtpFecha)
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.txtDeuda)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.txtNotario)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtTestigo1)
        Me.TabPage3.Controls.Add(Me.txtDomicilioNotario)
        Me.TabPage3.Controls.Add(Me.Label34)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txtDiasPago)
        Me.TabPage3.Controls.Add(Me.Label33)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.cbxTipoIdentNotario)
        Me.TabPage3.Controls.Add(Me.txtCantidadCuotas)
        Me.TabPage3.Controls.Add(Me.txtNacionalidadNotario)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.txtCiudadAcuerdo)
        Me.TabPage3.Controls.Add(Me.txtProvinciaAcuerdo)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.txtMunicipioAcuerdo)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(934, 368)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Datos del Acuerdo"
        '
        'lblSumaLetraCuotas
        '
        Me.lblSumaLetraCuotas.AutoSize = True
        Me.lblSumaLetraCuotas.Location = New System.Drawing.Point(462, 303)
        Me.lblSumaLetraCuotas.Name = "lblSumaLetraCuotas"
        Me.lblSumaLetraCuotas.Size = New System.Drawing.Size(0, 15)
        Me.lblSumaLetraCuotas.TabIndex = 340
        '
        'lblSumaLetraMonto
        '
        Me.lblSumaLetraMonto.AutoSize = True
        Me.lblSumaLetraMonto.Location = New System.Drawing.Point(244, 272)
        Me.lblSumaLetraMonto.Name = "lblSumaLetraMonto"
        Me.lblSumaLetraMonto.Size = New System.Drawing.Size(0, 15)
        Me.lblSumaLetraMonto.TabIndex = 339
        '
        'cbxGeneroNotario
        '
        Me.cbxGeneroNotario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxGeneroNotario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxGeneroNotario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxGeneroNotario.ForeColor = System.Drawing.Color.Black
        Me.cbxGeneroNotario.FormattingEnabled = True
        Me.cbxGeneroNotario.Location = New System.Drawing.Point(324, 35)
        Me.cbxGeneroNotario.Name = "cbxGeneroNotario"
        Me.cbxGeneroNotario.Size = New System.Drawing.Size(129, 23)
        Me.cbxGeneroNotario.TabIndex = 337
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(273, 38)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(45, 15)
        Me.Label53.TabIndex = 338
        Me.Label53.Text = "Género"
        '
        'txtIdentificacionTestigo2
        '
        Me.txtIdentificacionTestigo2.Location = New System.Drawing.Point(718, 154)
        Me.txtIdentificacionTestigo2.Name = "txtIdentificacionTestigo2"
        Me.txtIdentificacionTestigo2.Size = New System.Drawing.Size(205, 23)
        Me.txtIdentificacionTestigo2.TabIndex = 45
        Me.txtIdentificacionTestigo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdentificacionTestigo1
        '
        Me.txtIdentificacionTestigo1.Location = New System.Drawing.Point(718, 38)
        Me.txtIdentificacionTestigo1.Name = "txtIdentificacionTestigo1"
        Me.txtIdentificacionTestigo1.Size = New System.Drawing.Size(205, 23)
        Me.txtIdentificacionTestigo1.TabIndex = 40
        Me.txtIdentificacionTestigo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(6, 96)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(72, 15)
        Me.Label52.TabIndex = 336
        Me.Label52.Text = "No. Registro"
        '
        'txtNoRegistroNotario
        '
        Me.txtNoRegistroNotario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNoRegistroNotario.ForeColor = System.Drawing.Color.Black
        Me.txtNoRegistroNotario.Location = New System.Drawing.Point(92, 93)
        Me.txtNoRegistroNotario.Name = "txtNoRegistroNotario"
        Me.txtNoRegistroNotario.Size = New System.Drawing.Size(363, 23)
        Me.txtNoRegistroNotario.TabIndex = 27
        '
        'txtIdentificacionNotario
        '
        Me.txtIdentificacionNotario.Location = New System.Drawing.Point(244, 151)
        Me.txtIdentificacionNotario.Name = "txtIdentificacionNotario"
        Me.txtIdentificacionNotario.Size = New System.Drawing.Size(211, 23)
        Me.txtIdentificacionNotario.TabIndex = 30
        Me.txtIdentificacionNotario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpVencimiento
        '
        Me.dtpVencimiento.CalendarFont = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencimiento.CustomFormat = "yyyy-MM-dd"
        Me.dtpVencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencimiento.Location = New System.Drawing.Point(280, 6)
        Me.dtpVencimiento.Name = "dtpVencimiento"
        Me.dtpVencimiento.Size = New System.Drawing.Size(102, 23)
        Me.dtpVencimiento.TabIndex = 24
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(200, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(73, 15)
        Me.Label38.TabIndex = 333
        Me.Label38.Text = "Vencimiento"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(164, 330)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(128, 15)
        Me.Label46.TabIndex = 331
        Me.Label46.Text = "sobre el saldo absoluto"
        '
        'txtInteres
        '
        Me.txtInteres.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtInteres.ForeColor = System.Drawing.Color.Black
        Me.txtInteres.Location = New System.Drawing.Point(92, 327)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(66, 23)
        Me.txtInteres.TabIndex = 37
        Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(7, 330)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(45, 15)
        Me.Label45.TabIndex = 330
        Me.Label45.Text = "Interés "
        '
        'txtNacionalidadTestigo2
        '
        Me.txtNacionalidadTestigo2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidadTestigo2.ForeColor = System.Drawing.Color.Black
        Me.txtNacionalidadTestigo2.Location = New System.Drawing.Point(564, 212)
        Me.txtNacionalidadTestigo2.Name = "txtNacionalidadTestigo2"
        Me.txtNacionalidadTestigo2.Size = New System.Drawing.Size(359, 23)
        Me.txtNacionalidadTestigo2.TabIndex = 47
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(484, 215)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(77, 15)
        Me.Label40.TabIndex = 328
        Me.Label40.Text = "Nacionalidad"
        '
        'txtDomicilioTestigo2
        '
        Me.txtDomicilioTestigo2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDomicilioTestigo2.ForeColor = System.Drawing.Color.Black
        Me.txtDomicilioTestigo2.Location = New System.Drawing.Point(565, 183)
        Me.txtDomicilioTestigo2.Name = "txtDomicilioTestigo2"
        Me.txtDomicilioTestigo2.Size = New System.Drawing.Size(359, 23)
        Me.txtDomicilioTestigo2.TabIndex = 46
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(484, 186)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(58, 15)
        Me.Label41.TabIndex = 326
        Me.Label41.Text = "Domicilio"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(484, 157)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(79, 15)
        Me.Label42.TabIndex = 323
        Me.Label42.Text = "Identificación"
        '
        'cbxIdentificacionTestigo2
        '
        Me.cbxIdentificacionTestigo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxIdentificacionTestigo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxIdentificacionTestigo2.ForeColor = System.Drawing.Color.Black
        Me.cbxIdentificacionTestigo2.FormattingEnabled = True
        Me.cbxIdentificacionTestigo2.Location = New System.Drawing.Point(565, 154)
        Me.cbxIdentificacionTestigo2.Name = "cbxIdentificacionTestigo2"
        Me.cbxIdentificacionTestigo2.Size = New System.Drawing.Size(146, 23)
        Me.cbxIdentificacionTestigo2.TabIndex = 44
        '
        'txtTestigo2
        '
        Me.txtTestigo2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTestigo2.ForeColor = System.Drawing.Color.Black
        Me.txtTestigo2.Location = New System.Drawing.Point(565, 125)
        Me.txtTestigo2.Name = "txtTestigo2"
        Me.txtTestigo2.Size = New System.Drawing.Size(358, 23)
        Me.txtTestigo2.TabIndex = 43
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(484, 128)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(54, 15)
        Me.Label43.TabIndex = 321
        Me.Label43.Text = "Testigo 2"
        '
        'txtNacionalidadTestigo1
        '
        Me.txtNacionalidadTestigo1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNacionalidadTestigo1.ForeColor = System.Drawing.Color.Black
        Me.txtNacionalidadTestigo1.Location = New System.Drawing.Point(565, 96)
        Me.txtNacionalidadTestigo1.Name = "txtNacionalidadTestigo1"
        Me.txtNacionalidadTestigo1.Size = New System.Drawing.Size(359, 23)
        Me.txtNacionalidadTestigo1.TabIndex = 42
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(484, 99)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(77, 15)
        Me.Label35.TabIndex = 319
        Me.Label35.Text = "Nacionalidad"
        '
        'txtDomicilioTestigo1
        '
        Me.txtDomicilioTestigo1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDomicilioTestigo1.ForeColor = System.Drawing.Color.Black
        Me.txtDomicilioTestigo1.Location = New System.Drawing.Point(566, 67)
        Me.txtDomicilioTestigo1.Name = "txtDomicilioTestigo1"
        Me.txtDomicilioTestigo1.Size = New System.Drawing.Size(359, 23)
        Me.txtDomicilioTestigo1.TabIndex = 41
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(484, 70)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(58, 15)
        Me.Label39.TabIndex = 317
        Me.Label39.Text = "Domicilio"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(484, 41)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(79, 15)
        Me.Label36.TabIndex = 314
        Me.Label36.Text = "Identificación"
        '
        'cbxIdentificacionTestigo1
        '
        Me.cbxIdentificacionTestigo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxIdentificacionTestigo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxIdentificacionTestigo1.ForeColor = System.Drawing.Color.Black
        Me.cbxIdentificacionTestigo1.FormattingEnabled = True
        Me.cbxIdentificacionTestigo1.Location = New System.Drawing.Point(566, 38)
        Me.cbxIdentificacionTestigo1.Name = "cbxIdentificacionTestigo1"
        Me.cbxIdentificacionTestigo1.Size = New System.Drawing.Size(146, 23)
        Me.cbxIdentificacionTestigo1.TabIndex = 39
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.RichTextAcuerdo)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(934, 368)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Formato de Acuerdo"
        '
        'RichTextAcuerdo
        '
        Me.RichTextAcuerdo.Location = New System.Drawing.Point(159, 6)
        Me.RichTextAcuerdo.Name = "RichTextAcuerdo"
        Me.RichTextAcuerdo.Size = New System.Drawing.Size(769, 315)
        Me.RichTextAcuerdo.TabIndex = 1
        Me.RichTextAcuerdo.Text = ""
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkPagareNotarial)
        Me.GroupBox5.Controls.Add(Me.chkAcuerdoSimplificado)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(147, 318)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tipo de Formato"
        '
        'chkPagareNotarial
        '
        Me.chkPagareNotarial.AutoSize = True
        Me.chkPagareNotarial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkPagareNotarial.Location = New System.Drawing.Point(6, 44)
        Me.chkPagareNotarial.Name = "chkPagareNotarial"
        Me.chkPagareNotarial.Size = New System.Drawing.Size(106, 19)
        Me.chkPagareNotarial.TabIndex = 1
        Me.chkPagareNotarial.Text = "Pagaré Notarial"
        Me.chkPagareNotarial.UseVisualStyleBackColor = True
        '
        'chkAcuerdoSimplificado
        '
        Me.chkAcuerdoSimplificado.AutoSize = True
        Me.chkAcuerdoSimplificado.Checked = True
        Me.chkAcuerdoSimplificado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkAcuerdoSimplificado.Location = New System.Drawing.Point(6, 19)
        Me.chkAcuerdoSimplificado.Name = "chkAcuerdoSimplificado"
        Me.chkAcuerdoSimplificado.Size = New System.Drawing.Size(138, 19)
        Me.chkAcuerdoSimplificado.TabIndex = 0
        Me.chkAcuerdoSimplificado.TabStop = True
        Me.chkAcuerdoSimplificado.Text = "Acuerdo simplificado"
        Me.chkAcuerdoSimplificado.UseVisualStyleBackColor = True
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(8, 23)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 222
        Me.PicBoxLogo.TabStop = False
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.AnularToolStripMenuItem.Text = "Anular"
        '
        'RecibosEmitidoToolStripMenuItem
        '
        Me.RecibosEmitidoToolStripMenuItem.Name = "RecibosEmitidoToolStripMenuItem"
        Me.RecibosEmitidoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RecibosEmitidoToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RecibosEmitidoToolStripMenuItem.Text = "Buscar Recibos"
        '
        'frm_acuerdos_pago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 633)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.lblSlogan)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_acuerdos_pago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "100"
        Me.Text = "Acuerdos de Pago"
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        CType(Me.txtDiasPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecibosEmitidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDeuda As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNotaAcuerdo As System.Windows.Forms.TextBox
    Friend WithEvents LabelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDAcuerdo As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCalificacion As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUltimoPago As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceGral As System.Windows.Forms.TextBox
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents cod_cliente_label As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Friend WithEvents txtIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ChkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbCerrado As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAbierto As System.Windows.Forms.RadioButton
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDeudor As System.Windows.Forms.TextBox
    Friend WithEvents cbxIdentificacionDeudor As System.Windows.Forms.ComboBox
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioDeudor As System.Windows.Forms.TextBox
    Friend WithEvents cbxIdentificacionAcreedor As System.Windows.Forms.ComboBox
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioAcreedor As System.Windows.Forms.TextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAcreedor As System.Windows.Forms.TextBox
    Friend WithEvents cbxTipoIdentNotario As System.Windows.Forms.ComboBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioNotario As System.Windows.Forms.TextBox
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNotario As System.Windows.Forms.TextBox
    Private WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidadNotario As System.Windows.Forms.TextBox
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidadAcreedor As System.Windows.Forms.TextBox
    Private WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidadDeudor As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCiudadAcuerdo As System.Windows.Forms.TextBox
    Private WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents Label24 As System.Windows.Forms.Label
    Private WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipioAcuerdo As System.Windows.Forms.TextBox
    Private WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtProvinciaAcuerdo As System.Windows.Forms.TextBox
    Private WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtProvinciaAcreedor As System.Windows.Forms.TextBox
    Private WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipioAcreedor As System.Windows.Forms.TextBox
    Private WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtProvinciaDeudor As System.Windows.Forms.TextBox
    Private WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipioDeudor As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtDiasPago As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTestigo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtMontoCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtNacionalidadTestigo2 As System.Windows.Forms.TextBox
    Private WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioTestigo2 As System.Windows.Forms.TextBox
    Private WithEvents Label41 As System.Windows.Forms.Label
    Private WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbxIdentificacionTestigo2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtTestigo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtNacionalidadTestigo1 As System.Windows.Forms.TextBox
    Private WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilioTestigo1 As System.Windows.Forms.TextBox
    Private WithEvents Label39 As System.Windows.Forms.Label
    Private WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cbxIdentificacionTestigo1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtInteres As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents dtpVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Private WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextAcuerdo As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPagareNotarial As System.Windows.Forms.RadioButton
    Friend WithEvents chkAcuerdoSimplificado As System.Windows.Forms.RadioButton
    Private WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cbxGeneroAcreedor As System.Windows.Forms.ComboBox
    Private WithEvents Label49 As System.Windows.Forms.Label
    Private WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cbxGeneroDeudor As System.Windows.Forms.ComboBox
    Private WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtOcupacionAcreedor As System.Windows.Forms.TextBox
    Friend WithEvents txtOcupacionDeudor As System.Windows.Forms.TextBox
    Friend WithEvents txtTratamientoAcreedor As System.Windows.Forms.TextBox
    Friend WithEvents txtTratamientoDeudor As System.Windows.Forms.TextBox
    Friend WithEvents txtEstadoCivilAcreedor As System.Windows.Forms.TextBox
    Friend WithEvents txtEstadoCivilDeudor As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentificacionAcreedor As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIdentificacionDeudor As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIdentificacionNotario As System.Windows.Forms.MaskedTextBox
    Private WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtNoRegistroNotario As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtIdentificacionTestigo2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIdentificacionTestigo1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxGeneroNotario As System.Windows.Forms.ComboBox
    Private WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lblSumaLetraMonto As System.Windows.Forms.Label
    Friend WithEvents lblSumaLetraCuotas As System.Windows.Forms.Label
End Class
