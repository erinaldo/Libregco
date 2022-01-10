<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_registro_cuentasbancarias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_registro_cuentasbancarias))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNocuenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTitular = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtOficial = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkCheques = New System.Windows.Forms.CheckBox()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.txtCuentaCont = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIDCuentaCont = New System.Windows.Forms.TextBox()
        Me.txtUltimoCheque = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtChequeFinal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUltimoBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUltimoMonto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripcionCta = New System.Windows.Forms.TextBox()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.btn_BuscarCtaContable = New System.Windows.Forms.Button()
        Me.txtFechaCreacion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardarC = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardaryLimpiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_buscar_moneda = New System.Windows.Forms.Button()
        Me.txtIDMoneda = New System.Windows.Forms.TextBox()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnBuscarBanco = New System.Windows.Forms.Button()
        Me.txtIDBanco = New System.Windows.Forms.TextBox()
        Me.txtBanco = New System.Windows.Forms.TextBox()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtIDCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtLimiteReserva = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.GbxUserInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "No. Cuenta"
        '
        'txtNocuenta
        '
        Me.txtNocuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNocuenta.Location = New System.Drawing.Point(86, 211)
        Me.txtNocuenta.Name = "txtNocuenta"
        Me.txtNocuenta.Size = New System.Drawing.Size(382, 23)
        Me.txtNocuenta.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(8, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 15)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Titular"
        '
        'txtTitular
        '
        Me.txtTitular.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTitular.Location = New System.Drawing.Point(86, 240)
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(382, 23)
        Me.txtTitular.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Suc. Directa"
        '
        'txtSucursal
        '
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(86, 269)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(382, 23)
        Me.txtSucursal.TabIndex = 5
        '
        'txtOficial
        '
        Me.txtOficial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOficial.Location = New System.Drawing.Point(86, 298)
        Me.txtOficial.Name = "txtOficial"
        Me.txtOficial.Size = New System.Drawing.Size(382, 23)
        Me.txtOficial.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 183
        Me.Label5.Text = "Oficial"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(86, 327)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(174, 23)
        Me.txtTelefono.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 186
        Me.Label6.Text = "Teléfono"
        '
        'chkCheques
        '
        Me.chkCheques.AutoSize = True
        Me.chkCheques.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkCheques.Location = New System.Drawing.Point(657, 207)
        Me.chkCheques.Name = "chkCheques"
        Me.chkCheques.Size = New System.Drawing.Size(156, 19)
        Me.chkCheques.TabIndex = 1
        Me.chkCheques.Text = "Habilitar uso de cheques"
        Me.chkCheques.UseVisualStyleBackColor = True
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Enabled = False
        Me.chkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkNulo.Location = New System.Drawing.Point(407, 528)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(61, 19)
        Me.chkNulo.TabIndex = 270
        Me.chkNulo.Text = "Anular"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'txtCuentaCont
        '
        Me.txtCuentaCont.Enabled = False
        Me.txtCuentaCont.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuentaCont.Location = New System.Drawing.Point(199, 407)
        Me.txtCuentaCont.Name = "txtCuentaCont"
        Me.txtCuentaCont.ReadOnly = True
        Me.txtCuentaCont.Size = New System.Drawing.Size(269, 23)
        Me.txtCuentaCont.TabIndex = 193
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(8, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 191
        Me.Label7.Text = "Cuenta"
        '
        'txtIDCuentaCont
        '
        Me.txtIDCuentaCont.Enabled = False
        Me.txtIDCuentaCont.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCuentaCont.Location = New System.Drawing.Point(86, 385)
        Me.txtIDCuentaCont.Name = "txtIDCuentaCont"
        Me.txtIDCuentaCont.ReadOnly = True
        Me.txtIDCuentaCont.Size = New System.Drawing.Size(94, 23)
        Me.txtIDCuentaCont.TabIndex = 192
        Me.txtIDCuentaCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUltimoCheque
        '
        Me.txtUltimoCheque.Enabled = False
        Me.txtUltimoCheque.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.txtUltimoCheque.Location = New System.Drawing.Point(7, 40)
        Me.txtUltimoCheque.Name = "txtUltimoCheque"
        Me.txtUltimoCheque.ReadOnly = True
        Me.txtUltimoCheque.Size = New System.Drawing.Size(325, 39)
        Me.txtUltimoCheque.TabIndex = 194
        Me.txtUltimoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 195
        Me.Label8.Text = "Cheque No."
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlogan.Location = New System.Drawing.Point(70, 110)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 12)
        Me.lblSlogan.TabIndex = 235
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(819, 24)
        Me.MenuStrip1.TabIndex = 237
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'NuevoRegistroToolStripMenuItem
        '
        Me.NuevoRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.NuevoRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NuevoRegistroToolStripMenuItem.Name = "NuevoRegistroToolStripMenuItem"
        Me.NuevoRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(238, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(238, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(238, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar Cta. Bancaria"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(235, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(238, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'AnularToolStripMenuItem
        '
        Me.AnularToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.AnularToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AnularToolStripMenuItem.Name = "AnularToolStripMenuItem"
        Me.AnularToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.AnularToolStripMenuItem.Size = New System.Drawing.Size(165, 38)
        Me.AnularToolStripMenuItem.Text = "Anular"
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
        Me.AyudaLibregcoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AyudaLibregcoToolStripMenuItem.Name = "AyudaLibregcoToolStripMenuItem"
        Me.AyudaLibregcoToolStripMenuItem.Size = New System.Drawing.Size(173, 38)
        Me.AyudaLibregcoToolStripMenuItem.Text = "Ayuda Libregco"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtChequeFinal)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtUltimoBeneficiario)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtUltimoMonto)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtUltimoCheque)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(477, 210)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 350)
        Me.GroupBox1.TabIndex = 238
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Últimas transacciones"
        '
        'txtChequeFinal
        '
        Me.txtChequeFinal.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChequeFinal.ForeColor = System.Drawing.Color.Black
        Me.txtChequeFinal.Location = New System.Drawing.Point(7, 302)
        Me.txtChequeFinal.Name = "txtChequeFinal"
        Me.txtChequeFinal.Size = New System.Drawing.Size(325, 39)
        Me.txtChequeFinal.TabIndex = 200
        Me.txtChequeFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(6, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 15)
        Me.Label14.TabIndex = 201
        Me.Label14.Text = "Cheque Actual"
        '
        'txtUltimoBeneficiario
        '
        Me.txtUltimoBeneficiario.Enabled = False
        Me.txtUltimoBeneficiario.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoBeneficiario.Location = New System.Drawing.Point(6, 161)
        Me.txtUltimoBeneficiario.Multiline = True
        Me.txtUltimoBeneficiario.Name = "txtUltimoBeneficiario"
        Me.txtUltimoBeneficiario.ReadOnly = True
        Me.txtUltimoBeneficiario.Size = New System.Drawing.Size(326, 117)
        Me.txtUltimoBeneficiario.TabIndex = 198
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(3, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 199
        Me.Label13.Text = "Beneficiario"
        '
        'txtUltimoMonto
        '
        Me.txtUltimoMonto.Enabled = False
        Me.txtUltimoMonto.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.txtUltimoMonto.Location = New System.Drawing.Point(6, 101)
        Me.txtUltimoMonto.Name = "txtUltimoMonto"
        Me.txtUltimoMonto.ReadOnly = True
        Me.txtUltimoMonto.Size = New System.Drawing.Size(326, 39)
        Me.txtUltimoMonto.TabIndex = 196
        Me.txtUltimoMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(3, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 15)
        Me.Label9.TabIndex = 197
        Me.Label9.Text = "Monto"
        '
        'txtBalance
        '
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.Location = New System.Drawing.Point(194, 526)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(179, 23)
        Me.txtBalance.TabIndex = 198
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(197, 508)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 15)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "Balance Actual"
        '
        'txtDescripcionCta
        '
        Me.txtDescripcionCta.Enabled = False
        Me.txtDescripcionCta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescripcionCta.Location = New System.Drawing.Point(199, 385)
        Me.txtDescripcionCta.Name = "txtDescripcionCta"
        Me.txtDescripcionCta.ReadOnly = True
        Me.txtDescripcionCta.Size = New System.Drawing.Size(269, 23)
        Me.txtDescripcionCta.TabIndex = 267
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'btn_BuscarCtaContable
        '
        Me.btn_BuscarCtaContable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_BuscarCtaContable.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_BuscarCtaContable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_BuscarCtaContable.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btn_BuscarCtaContable.Location = New System.Drawing.Point(177, 385)
        Me.btn_BuscarCtaContable.Name = "btn_BuscarCtaContable"
        Me.btn_BuscarCtaContable.Size = New System.Drawing.Size(23, 23)
        Me.btn_BuscarCtaContable.TabIndex = 8
        Me.btn_BuscarCtaContable.UseVisualStyleBackColor = True
        '
        'txtFechaCreacion
        '
        Me.txtFechaCreacion.Enabled = False
        Me.txtFechaCreacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaCreacion.Location = New System.Drawing.Point(9, 526)
        Me.txtFechaCreacion.Name = "txtFechaCreacion"
        Me.txtFechaCreacion.ReadOnly = True
        Me.txtFechaCreacion.Size = New System.Drawing.Size(179, 23)
        Me.txtFechaCreacion.TabIndex = 268
        Me.txtFechaCreacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(6, 508)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(102, 15)
        Me.Label16.TabIndex = 269
        Me.Label16.Text = "Fecha de creación"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PicBoxLogo.Location = New System.Drawing.Point(9, 29)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(276, 98)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 271
        Me.PicBoxLogo.TabStop = False
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 567)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(819, 25)
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
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(469, 20)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(350, 102)
        Me.IconPanel.TabIndex = 414
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnDesactivar})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip2.Size = New System.Drawing.Size(350, 102)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Libregco.My.Resources.Resources.New_x72
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 98)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnGuardaryLimpiar})
        Me.btnGuardarC.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 98)
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
        Me.btnBuscar.Size = New System.Drawing.Size(84, 98)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDesactivar
        '
        Me.btnDesactivar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnDesactivar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(84, 98)
        Me.btnDesactivar.Text = "Anular"
        Me.btnDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btn_buscar_moneda
        '
        Me.btn_buscar_moneda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_buscar_moneda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscar_moneda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_buscar_moneda.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btn_buscar_moneda.Location = New System.Drawing.Point(178, 181)
        Me.btn_buscar_moneda.Name = "btn_buscar_moneda"
        Me.btn_buscar_moneda.Size = New System.Drawing.Size(23, 23)
        Me.btn_buscar_moneda.TabIndex = 416
        Me.btn_buscar_moneda.UseVisualStyleBackColor = True
        '
        'txtIDMoneda
        '
        Me.txtIDMoneda.Enabled = False
        Me.txtIDMoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDMoneda.Location = New System.Drawing.Point(86, 181)
        Me.txtIDMoneda.Name = "txtIDMoneda"
        Me.txtIDMoneda.ReadOnly = True
        Me.txtIDMoneda.Size = New System.Drawing.Size(94, 23)
        Me.txtIDMoneda.TabIndex = 417
        Me.txtIDMoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMoneda
        '
        Me.txtMoneda.Enabled = False
        Me.txtMoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMoneda.Location = New System.Drawing.Point(199, 181)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(269, 23)
        Me.txtMoneda.TabIndex = 415
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(8, 185)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 15)
        Me.Label15.TabIndex = 418
        Me.Label15.Text = "Moneda"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(6, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 15)
        Me.Label17.TabIndex = 422
        Me.Label17.Text = "Banco"
        '
        'btnBuscarBanco
        '
        Me.btnBuscarBanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarBanco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarBanco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarBanco.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarBanco.Location = New System.Drawing.Point(178, 152)
        Me.btnBuscarBanco.Name = "btnBuscarBanco"
        Me.btnBuscarBanco.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarBanco.TabIndex = 420
        Me.btnBuscarBanco.UseVisualStyleBackColor = True
        '
        'txtIDBanco
        '
        Me.txtIDBanco.Enabled = False
        Me.txtIDBanco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDBanco.Location = New System.Drawing.Point(86, 152)
        Me.txtIDBanco.Name = "txtIDBanco"
        Me.txtIDBanco.ReadOnly = True
        Me.txtIDBanco.Size = New System.Drawing.Size(94, 23)
        Me.txtIDBanco.TabIndex = 421
        Me.txtIDBanco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBanco
        '
        Me.txtBanco.Enabled = False
        Me.txtBanco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBanco.Location = New System.Drawing.Point(200, 152)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.ReadOnly = True
        Me.txtBanco.Size = New System.Drawing.Size(268, 23)
        Me.txtBanco.TabIndex = 419
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCuenta)
        Me.GbxUserInfo.Controls.Add(Me.Label2)
        Me.GbxUserInfo.Controls.Add(Me.Label11)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.Label12)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(477, 128)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(338, 76)
        Me.GbxUserInfo.TabIndex = 423
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(173, 16)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(159, 23)
        Me.txtSecondID.TabIndex = 168
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDCuenta
        '
        Me.txtIDCuenta.Enabled = False
        Me.txtIDCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCuenta.Location = New System.Drawing.Point(58, 16)
        Me.txtIDCuenta.Name = "txtIDCuenta"
        Me.txtIDCuenta.ReadOnly = True
        Me.txtIDCuenta.Size = New System.Drawing.Size(108, 23)
        Me.txtIDCuenta.TabIndex = 139
        Me.txtIDCuenta.TabStop = False
        Me.txtIDCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Código"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(6, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 15)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "Fecha"
        '
        'txtHora
        '
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Location = New System.Drawing.Point(213, 45)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(119, 23)
        Me.txtHora.TabIndex = 163
        Me.txtHora.TabStop = False
        Me.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(174, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 15)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "Hora"
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Location = New System.Drawing.Point(58, 44)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(109, 23)
        Me.txtFecha.TabIndex = 167
        Me.txtFecha.TabStop = False
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLimiteReserva
        '
        Me.txtLimiteReserva.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLimiteReserva.Location = New System.Drawing.Point(86, 356)
        Me.txtLimiteReserva.Name = "txtLimiteReserva"
        Me.txtLimiteReserva.Size = New System.Drawing.Size(175, 23)
        Me.txtLimiteReserva.TabIndex = 424
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label18.Location = New System.Drawing.Point(7, 359)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 15)
        Me.Label18.TabIndex = 425
        Me.Label18.Text = "Lím. Reserva"
        '
        'frm_registro_cuentasbancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 592)
        Me.Controls.Add(Me.txtLimiteReserva)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.chkCheques)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnBuscarBanco)
        Me.Controls.Add(Me.txtIDBanco)
        Me.Controls.Add(Me.txtBanco)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btn_buscar_moneda)
        Me.Controls.Add(Me.txtIDMoneda)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtFechaCreacion)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDescripcionCta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.btn_BuscarCtaContable)
        Me.Controls.Add(Me.txtCuentaCont)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtIDCuentaCont)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtOficial)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTitular)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNocuenta)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_registro_cuentasbancarias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "172"
        Me.Text = "Cuentas Bancarias"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_BuscarCtaContable As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents lblSlogan As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnularToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Hora As System.Windows.Forms.Timer
    Friend WithEvents txtNocuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtTitular As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtOficial As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCuentaCont As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCuentaCont As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionCta As System.Windows.Forms.TextBox
    Friend WithEvents chkCheques As System.Windows.Forms.CheckBox
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCreacion As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardarC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGuardaryLimpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesactivar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_buscar_moneda As System.Windows.Forms.Button
    Friend WithEvents txtIDMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarBanco As System.Windows.Forms.Button
    Friend WithEvents txtIDBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GbxUserInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecondID As System.Windows.Forms.TextBox
    Friend WithEvents txtIDCuenta As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Private WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents txtLimiteReserva As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
