<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_corte_caja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_corte_caja))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEfectivoContado = New System.Windows.Forms.TextBox()
        Me.txtChequeContado = New System.Windows.Forms.TextBox()
        Me.txtTarjetaContado = New System.Windows.Forms.TextBox()
        Me.txtTotalContado = New System.Windows.Forms.TextBox()
        Me.txtEgresosContado = New System.Windows.Forms.TextBox()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEgresosCalculado = New System.Windows.Forms.TextBox()
        Me.txtTotalCalculado = New System.Windows.Forms.TextBox()
        Me.txtTarjetaCalculado = New System.Windows.Forms.TextBox()
        Me.txtChequeCalculado = New System.Windows.Forms.TextBox()
        Me.txtEfectivoCalculado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEgresosDiferencia = New System.Windows.Forms.TextBox()
        Me.txtTotalDiferencia = New System.Windows.Forms.TextBox()
        Me.txtTarjetaDiferencia = New System.Windows.Forms.TextBox()
        Me.txtChequeDiferencia = New System.Windows.Forms.TextBox()
        Me.txtEfectivoDiferencia = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SeparatorControl4 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtOtrasRetirar = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtBonosRetirar = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtPermutaRetirar = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtDepositoRetirar = New System.Windows.Forms.TextBox()
        Me.SeparatorControl7 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtTransferenciaRetirar = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SeparatorControl5 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtEgresosRetirar = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalRetirar = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTarjetaRetirar = New System.Windows.Forms.TextBox()
        Me.txtEfectivoRetirar = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtChequeRetirar = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
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
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtTransferenciaDiferencia = New System.Windows.Forms.TextBox()
        Me.txtTransferenciaCalculado = New System.Windows.Forms.TextBox()
        Me.txtTransferenciaContado = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTransferenciadeCaja = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Hora = New System.Windows.Forms.Timer(Me.components)
        Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtOtrasDiferencia = New System.Windows.Forms.TextBox()
        Me.txtOtrasCalculado = New System.Windows.Forms.TextBox()
        Me.txtOtrasContado = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtPermutaDiferencia = New System.Windows.Forms.TextBox()
        Me.txtPermutaCalculado = New System.Windows.Forms.TextBox()
        Me.txtPermutaContado = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtBonosDiferencia = New System.Windows.Forms.TextBox()
        Me.txtBonosCalculado = New System.Windows.Forms.TextBox()
        Me.txtBonosContado = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtDepositoContado = New System.Windows.Forms.TextBox()
        Me.txtDepositoCalculado = New System.Windows.Forms.TextBox()
        Me.txtDepositoDiferencia = New System.Windows.Forms.TextBox()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl2 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtOtras = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtPermutas = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtBonos = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtPagosFinanciamientos = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFinanciamientos = New System.Windows.Forms.TextBox()
        Me.txtCantTransaccion = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtGranTotal = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtVentaContado = New System.Windows.Forms.TextBox()
        Me.txtTotalEgresos = New System.Windows.Forms.TextBox()
        Me.txtVentaCredito = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRecibosEgresos = New System.Windows.Forms.TextBox()
        Me.txtReciboIngreso = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtDevolucionesEfect = New System.Windows.Forms.TextBox()
        Me.txtDevolucionesEfectivo = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.txtOtrosIngresos = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtDeposito = New System.Windows.Forms.TextBox()
        Me.txtCobrosAdelantados = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.txtDevoluciones = New System.Windows.Forms.TextBox()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtDevolucionesCredito = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtDevolucionesBoucher = New System.Windows.Forms.TextBox()
        Me.XtraTabPage5 = New DevExpress.XtraTab.XtraTabPage()
        Me.DgvTransacciones = New System.Windows.Forms.DataGridView()
        Me.BindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabControl3 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage6 = New DevExpress.XtraTab.XtraTabPage()
        Me.DgvHistorial = New System.Windows.Forms.DataGridView()
        Me.IDCorte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioPic = New System.Windows.Forms.DataGridViewImageColumn()
        Me.NombreUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalculadoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantTransacciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetiroTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XtraTabPage7 = New DevExpress.XtraTab.XtraTabPage()
        Me.DgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewLinkColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GbxUserInfo = New System.Windows.Forms.GroupBox()
        Me.txtHora = New System.Windows.Forms.DateTimePicker()
        Me.txtSecondID = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIDCorte = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.MenuBarra = New System.Windows.Forms.MenuStrip()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarRegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitarArtículoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaLibregcoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarTransacciones = New System.Windows.Forms.Button()
        Me.cbxAreaImpresion = New System.Windows.Forms.ComboBox()
        Me.cbxEmpleado = New System.Windows.Forms.ComboBox()
        Me.ToastNotificationsManager1 = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.ChkNulo = New System.Windows.Forms.CheckBox()
        Me.chkTodoRango = New System.Windows.Forms.CheckBox()
        Me.NavBarControl2 = New DevExpress.XtraNavBar.NavBarControl()
        Me.NavBarGroup3 = New DevExpress.XtraNavBar.NavBarGroup()
        Me.NavBarGroupControlContainer3 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.lblAreaImpresion = New System.Windows.Forms.Label()
        Me.lblRango = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.NavBarGroupControlContainer4 = New DevExpress.XtraNavBar.NavBarGroupControlContainer()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.NavBarGroup4 = New DevExpress.XtraNavBar.NavBarGroup()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraEstado.SuspendLayout()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl2.SuspendLayout()
        Me.XtraTabPage4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.XtraTabPage5.SuspendLayout()
        CType(Me.DgvTransacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl3.SuspendLayout()
        Me.XtraTabPage6.SuspendLayout()
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage7.SuspendLayout()
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbxUserInfo.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBarra.SuspendLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavBarControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl2.SuspendLayout()
        Me.NavBarGroupControlContainer3.SuspendLayout()
        Me.NavBarGroupControlContainer4.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Area de caja"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Chocolate
        Me.Label2.Location = New System.Drawing.Point(25, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Efectivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 286)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Vales"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tarjetas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cheques"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Total"
        '
        'txtEfectivoContado
        '
        Me.txtEfectivoContado.Location = New System.Drawing.Point(119, 28)
        Me.txtEfectivoContado.Name = "txtEfectivoContado"
        Me.txtEfectivoContado.Size = New System.Drawing.Size(120, 21)
        Me.txtEfectivoContado.TabIndex = 5
        Me.txtEfectivoContado.Text = "0"
        '
        'txtChequeContado
        '
        Me.txtChequeContado.Location = New System.Drawing.Point(119, 84)
        Me.txtChequeContado.Name = "txtChequeContado"
        Me.txtChequeContado.Size = New System.Drawing.Size(120, 21)
        Me.txtChequeContado.TabIndex = 7
        Me.txtChequeContado.Text = "0"
        '
        'txtTarjetaContado
        '
        Me.txtTarjetaContado.Location = New System.Drawing.Point(119, 55)
        Me.txtTarjetaContado.Name = "txtTarjetaContado"
        Me.txtTarjetaContado.Size = New System.Drawing.Size(120, 21)
        Me.txtTarjetaContado.TabIndex = 6
        Me.txtTarjetaContado.Text = "0"
        '
        'txtTotalContado
        '
        Me.txtTotalContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalContado.Location = New System.Drawing.Point(119, 324)
        Me.txtTotalContado.Name = "txtTotalContado"
        Me.txtTotalContado.ReadOnly = True
        Me.txtTotalContado.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalContado.TabIndex = 10
        Me.txtTotalContado.TabStop = False
        Me.txtTotalContado.Text = "0"
        '
        'txtEgresosContado
        '
        Me.txtEgresosContado.Location = New System.Drawing.Point(119, 282)
        Me.txtEgresosContado.Name = "txtEgresosContado"
        Me.txtEgresosContado.Size = New System.Drawing.Size(120, 21)
        Me.txtEgresosContado.TabIndex = 13
        Me.txtEgresosContado.Text = "0"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl2.Location = New System.Drawing.Point(10, 304)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(579, 18)
        Me.SeparatorControl2.TabIndex = 12
        Me.SeparatorControl2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(152, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Contado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(268, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Calculado"
        '
        'txtEgresosCalculado
        '
        Me.txtEgresosCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEgresosCalculado.Location = New System.Drawing.Point(238, 282)
        Me.txtEgresosCalculado.Name = "txtEgresosCalculado"
        Me.txtEgresosCalculado.ReadOnly = True
        Me.txtEgresosCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtEgresosCalculado.TabIndex = 9
        Me.txtEgresosCalculado.TabStop = False
        Me.txtEgresosCalculado.Text = "0"
        '
        'txtTotalCalculado
        '
        Me.txtTotalCalculado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCalculado.Location = New System.Drawing.Point(238, 324)
        Me.txtTotalCalculado.Name = "txtTotalCalculado"
        Me.txtTotalCalculado.ReadOnly = True
        Me.txtTotalCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalCalculado.TabIndex = 17
        Me.txtTotalCalculado.TabStop = False
        Me.txtTotalCalculado.Text = "0"
        '
        'txtTarjetaCalculado
        '
        Me.txtTarjetaCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTarjetaCalculado.Location = New System.Drawing.Point(238, 55)
        Me.txtTarjetaCalculado.Name = "txtTarjetaCalculado"
        Me.txtTarjetaCalculado.ReadOnly = True
        Me.txtTarjetaCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtTarjetaCalculado.TabIndex = 7
        Me.txtTarjetaCalculado.TabStop = False
        Me.txtTarjetaCalculado.Text = "0"
        '
        'txtChequeCalculado
        '
        Me.txtChequeCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtChequeCalculado.Location = New System.Drawing.Point(238, 84)
        Me.txtChequeCalculado.Name = "txtChequeCalculado"
        Me.txtChequeCalculado.ReadOnly = True
        Me.txtChequeCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtChequeCalculado.TabIndex = 6
        Me.txtChequeCalculado.TabStop = False
        Me.txtChequeCalculado.Text = "0"
        '
        'txtEfectivoCalculado
        '
        Me.txtEfectivoCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEfectivoCalculado.Location = New System.Drawing.Point(238, 28)
        Me.txtEfectivoCalculado.Name = "txtEfectivoCalculado"
        Me.txtEfectivoCalculado.ReadOnly = True
        Me.txtEfectivoCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtEfectivoCalculado.TabIndex = 5
        Me.txtEfectivoCalculado.TabStop = False
        Me.txtEfectivoCalculado.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label9.Location = New System.Drawing.Point(385, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Diferencia"
        '
        'txtEgresosDiferencia
        '
        Me.txtEgresosDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEgresosDiferencia.Location = New System.Drawing.Point(357, 282)
        Me.txtEgresosDiferencia.Name = "txtEgresosDiferencia"
        Me.txtEgresosDiferencia.ReadOnly = True
        Me.txtEgresosDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtEgresosDiferencia.TabIndex = 14
        Me.txtEgresosDiferencia.TabStop = False
        Me.txtEgresosDiferencia.Text = "0"
        '
        'txtTotalDiferencia
        '
        Me.txtTotalDiferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiferencia.Location = New System.Drawing.Point(357, 324)
        Me.txtTotalDiferencia.Name = "txtTotalDiferencia"
        Me.txtTotalDiferencia.ReadOnly = True
        Me.txtTotalDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalDiferencia.TabIndex = 23
        Me.txtTotalDiferencia.TabStop = False
        Me.txtTotalDiferencia.Text = "0"
        '
        'txtTarjetaDiferencia
        '
        Me.txtTarjetaDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTarjetaDiferencia.Location = New System.Drawing.Point(357, 55)
        Me.txtTarjetaDiferencia.Name = "txtTarjetaDiferencia"
        Me.txtTarjetaDiferencia.ReadOnly = True
        Me.txtTarjetaDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtTarjetaDiferencia.TabIndex = 12
        Me.txtTarjetaDiferencia.TabStop = False
        Me.txtTarjetaDiferencia.Text = "0"
        '
        'txtChequeDiferencia
        '
        Me.txtChequeDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtChequeDiferencia.Location = New System.Drawing.Point(357, 84)
        Me.txtChequeDiferencia.Name = "txtChequeDiferencia"
        Me.txtChequeDiferencia.ReadOnly = True
        Me.txtChequeDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtChequeDiferencia.TabIndex = 11
        Me.txtChequeDiferencia.TabStop = False
        Me.txtChequeDiferencia.Text = "0"
        '
        'txtEfectivoDiferencia
        '
        Me.txtEfectivoDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEfectivoDiferencia.Location = New System.Drawing.Point(357, 28)
        Me.txtEfectivoDiferencia.Name = "txtEfectivoDiferencia"
        Me.txtEfectivoDiferencia.ReadOnly = True
        Me.txtEfectivoDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtEfectivoDiferencia.TabIndex = 10
        Me.txtEfectivoDiferencia.TabStop = False
        Me.txtEfectivoDiferencia.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 373)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(208, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Total de transferencias de cortes de caja:"
        '
        'SeparatorControl4
        '
        Me.SeparatorControl4.Location = New System.Drawing.Point(29, 386)
        Me.SeparatorControl4.Name = "SeparatorControl4"
        Me.SeparatorControl4.Size = New System.Drawing.Size(466, 18)
        Me.SeparatorControl4.TabIndex = 28
        Me.SeparatorControl4.TabStop = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.txtOtrasRetirar)
        Me.GroupControl1.Controls.Add(Me.Label54)
        Me.GroupControl1.Controls.Add(Me.txtBonosRetirar)
        Me.GroupControl1.Controls.Add(Me.Label53)
        Me.GroupControl1.Controls.Add(Me.txtPermutaRetirar)
        Me.GroupControl1.Controls.Add(Me.Label52)
        Me.GroupControl1.Controls.Add(Me.txtDepositoRetirar)
        Me.GroupControl1.Controls.Add(Me.SeparatorControl7)
        Me.GroupControl1.Controls.Add(Me.txtTransferenciaRetirar)
        Me.GroupControl1.Controls.Add(Me.Label48)
        Me.GroupControl1.Controls.Add(Me.Label17)
        Me.GroupControl1.Controls.Add(Me.SeparatorControl5)
        Me.GroupControl1.Controls.Add(Me.txtEgresosRetirar)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.txtTotalRetirar)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.txtTarjetaRetirar)
        Me.GroupControl1.Controls.Add(Me.txtEfectivoRetirar)
        Me.GroupControl1.Controls.Add(Me.Label14)
        Me.GroupControl1.Controls.Add(Me.Label15)
        Me.GroupControl1.Controls.Add(Me.txtChequeRetirar)
        Me.GroupControl1.Controls.Add(Me.Label13)
        Me.GroupControl1.Location = New System.Drawing.Point(588, -1)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(284, 404)
        Me.GroupControl1.TabIndex = 14
        Me.GroupControl1.Text = "Retirar por corte"
        '
        'txtOtrasRetirar
        '
        Me.txtOtrasRetirar.Location = New System.Drawing.Point(106, 246)
        Me.txtOtrasRetirar.Name = "txtOtrasRetirar"
        Me.txtOtrasRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtOtrasRetirar.TabIndex = 22
        Me.txtOtrasRetirar.Text = "0"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(27, 249)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(34, 13)
        Me.Label54.TabIndex = 342
        Me.Label54.Text = "Otras"
        '
        'txtBonosRetirar
        '
        Me.txtBonosRetirar.Location = New System.Drawing.Point(106, 192)
        Me.txtBonosRetirar.Name = "txtBonosRetirar"
        Me.txtBonosRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtBonosRetirar.TabIndex = 20
        Me.txtBonosRetirar.Text = "0"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(27, 195)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(36, 13)
        Me.Label53.TabIndex = 340
        Me.Label53.Text = "Bonos"
        '
        'txtPermutaRetirar
        '
        Me.txtPermutaRetirar.Location = New System.Drawing.Point(106, 220)
        Me.txtPermutaRetirar.Name = "txtPermutaRetirar"
        Me.txtPermutaRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtPermutaRetirar.TabIndex = 21
        Me.txtPermutaRetirar.Text = "0"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(27, 223)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(52, 13)
        Me.Label52.TabIndex = 338
        Me.Label52.Text = "Permutas"
        '
        'txtDepositoRetirar
        '
        Me.txtDepositoRetirar.Location = New System.Drawing.Point(106, 113)
        Me.txtDepositoRetirar.Name = "txtDepositoRetirar"
        Me.txtDepositoRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtDepositoRetirar.TabIndex = 18
        Me.txtDepositoRetirar.Text = "0"
        '
        'SeparatorControl7
        '
        Me.SeparatorControl7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl7.Location = New System.Drawing.Point(4, 167)
        Me.SeparatorControl7.Name = "SeparatorControl7"
        Me.SeparatorControl7.Size = New System.Drawing.Size(274, 18)
        Me.SeparatorControl7.TabIndex = 334
        Me.SeparatorControl7.TabStop = False
        '
        'txtTransferenciaRetirar
        '
        Me.txtTransferenciaRetirar.Location = New System.Drawing.Point(106, 140)
        Me.txtTransferenciaRetirar.Name = "txtTransferenciaRetirar"
        Me.txtTransferenciaRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtTransferenciaRetirar.TabIndex = 19
        Me.txtTransferenciaRetirar.Text = "0"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(27, 117)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(54, 13)
        Me.Label48.TabIndex = 336
        Me.Label48.Text = "Depósitos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 143)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Transfencias"
        '
        'SeparatorControl5
        '
        Me.SeparatorControl5.Location = New System.Drawing.Point(17, 298)
        Me.SeparatorControl5.Name = "SeparatorControl5"
        Me.SeparatorControl5.Size = New System.Drawing.Size(256, 18)
        Me.SeparatorControl5.TabIndex = 22
        Me.SeparatorControl5.TabStop = False
        '
        'txtEgresosRetirar
        '
        Me.txtEgresosRetirar.Location = New System.Drawing.Point(106, 273)
        Me.txtEgresosRetirar.Name = "txtEgresosRetirar"
        Me.txtEgresosRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtEgresosRetirar.TabIndex = 23
        Me.txtEgresosRetirar.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Vales"
        '
        'txtTotalRetirar
        '
        Me.txtTotalRetirar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetirar.Location = New System.Drawing.Point(106, 330)
        Me.txtTotalRetirar.Name = "txtTotalRetirar"
        Me.txtTotalRetirar.ReadOnly = True
        Me.txtTotalRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalRetirar.TabIndex = 20
        Me.txtTotalRetirar.TabStop = False
        Me.txtTotalRetirar.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(32, 334)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Total"
        '
        'txtTarjetaRetirar
        '
        Me.txtTarjetaRetirar.Location = New System.Drawing.Point(106, 59)
        Me.txtTarjetaRetirar.Name = "txtTarjetaRetirar"
        Me.txtTarjetaRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtTarjetaRetirar.TabIndex = 16
        Me.txtTarjetaRetirar.Text = "0"
        '
        'txtEfectivoRetirar
        '
        Me.txtEfectivoRetirar.Location = New System.Drawing.Point(106, 32)
        Me.txtEfectivoRetirar.Name = "txtEfectivoRetirar"
        Me.txtEfectivoRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtEfectivoRetirar.TabIndex = 15
        Me.txtEfectivoRetirar.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Tarjetas"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(27, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Efectivo"
        '
        'txtChequeRetirar
        '
        Me.txtChequeRetirar.Location = New System.Drawing.Point(106, 86)
        Me.txtChequeRetirar.Name = "txtChequeRetirar"
        Me.txtChequeRetirar.Size = New System.Drawing.Size(120, 21)
        Me.txtChequeRetirar.TabIndex = 17
        Me.txtChequeRetirar.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(27, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Cheques"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 691)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(887, 25)
        Me.BarraEstado.TabIndex = 264
        Me.BarraEstado.Text = "ToolStrip1"
        '
        'lblDate
        '
        Me.lblDate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 22)
        Me.lblDate.Text = "Date"
        '
        'PicLoading
        '
        Me.PicLoading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PicLoading.Image = CType(resources.GetObject("PicLoading.Image"), System.Drawing.Image)
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
        Me.IconPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(453, 26)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 327
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnGuardarC, Me.btnBuscar, Me.btnAnular, Me.btnImprimir})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip2.Size = New System.Drawing.Size(434, 99)
        Me.MenuStrip2.TabIndex = 192
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(84, 95)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardarC
        '
        Me.btnGuardarC.Image = CType(resources.GetObject("btnGuardarC.Image"), System.Drawing.Image)
        Me.btnGuardarC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnGuardarC.Name = "btnGuardarC"
        Me.btnGuardarC.Size = New System.Drawing.Size(84, 95)
        Me.btnGuardarC.Text = "Guardar"
        Me.btnGuardarC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 95)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAnular
        '
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
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
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(84, 95)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txtTransferenciaDiferencia
        '
        Me.txtTransferenciaDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTransferenciaDiferencia.Location = New System.Drawing.Point(357, 140)
        Me.txtTransferenciaDiferencia.Name = "txtTransferenciaDiferencia"
        Me.txtTransferenciaDiferencia.ReadOnly = True
        Me.txtTransferenciaDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtTransferenciaDiferencia.TabIndex = 13
        Me.txtTransferenciaDiferencia.TabStop = False
        Me.txtTransferenciaDiferencia.Text = "0"
        '
        'txtTransferenciaCalculado
        '
        Me.txtTransferenciaCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTransferenciaCalculado.Location = New System.Drawing.Point(238, 140)
        Me.txtTransferenciaCalculado.Name = "txtTransferenciaCalculado"
        Me.txtTransferenciaCalculado.ReadOnly = True
        Me.txtTransferenciaCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtTransferenciaCalculado.TabIndex = 8
        Me.txtTransferenciaCalculado.TabStop = False
        Me.txtTransferenciaCalculado.Text = "0"
        '
        'txtTransferenciaContado
        '
        Me.txtTransferenciaContado.Location = New System.Drawing.Point(119, 140)
        Me.txtTransferenciaContado.Name = "txtTransferenciaContado"
        Me.txtTransferenciaContado.Size = New System.Drawing.Size(120, 21)
        Me.txtTransferenciaContado.TabIndex = 9
        Me.txtTransferenciaContado.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(25, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 328
        Me.Label16.Text = "Transferencias"
        '
        'txtTransferenciadeCaja
        '
        Me.txtTransferenciadeCaja.BackColor = System.Drawing.Color.White
        Me.txtTransferenciadeCaja.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTransferenciadeCaja.Location = New System.Drawing.Point(239, 374)
        Me.txtTransferenciadeCaja.Name = "txtTransferenciadeCaja"
        Me.txtTransferenciadeCaja.ReadOnly = True
        Me.txtTransferenciadeCaja.Size = New System.Drawing.Size(139, 14)
        Me.txtTransferenciadeCaja.TabIndex = 332
        Me.txtTransferenciadeCaja.TabStop = False
        Me.txtTransferenciadeCaja.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(7, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 334
        Me.Label18.Text = "Empleado"
        '
        'Hora
        '
        Me.Hora.Enabled = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(45, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 342
        Me.Label20.Text = "Desde"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(254, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 13)
        Me.Label21.TabIndex = 344
        Me.Label21.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.Location = New System.Drawing.Point(82, 29)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(165, 20)
        Me.dtpDesde.TabIndex = 1
        '
        'dtpHasta
        '
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.Location = New System.Drawing.Point(290, 29)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(163, 20)
        Me.dtpHasta.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(570, 206)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 45)
        Me.GroupBox1.TabIndex = 347
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Último corte de caja"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label22.Location = New System.Drawing.Point(6, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(253, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "No se han encontrado cortes de cajas al día de hoy"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(8, 251)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(877, 431)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.Black
        Me.XtraTabPage1.Appearance.PageClient.Options.UseBackColor = True
        Me.XtraTabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.XtraTabPage1.Controls.Add(Me.SeparatorControl3)
        Me.XtraTabPage1.Controls.Add(Me.txtOtrasDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtOtrasCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtOtrasContado)
        Me.XtraTabPage1.Controls.Add(Me.Label51)
        Me.XtraTabPage1.Controls.Add(Me.txtPermutaDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtPermutaCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtPermutaContado)
        Me.XtraTabPage1.Controls.Add(Me.Label50)
        Me.XtraTabPage1.Controls.Add(Me.txtBonosDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtBonosCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtBonosContado)
        Me.XtraTabPage1.Controls.Add(Me.Label49)
        Me.XtraTabPage1.Controls.Add(Me.Label47)
        Me.XtraTabPage1.Controls.Add(Me.txtDepositoContado)
        Me.XtraTabPage1.Controls.Add(Me.txtDepositoCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtDepositoDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.Label7)
        Me.XtraTabPage1.Controls.Add(Me.Label2)
        Me.XtraTabPage1.Controls.Add(Me.Label4)
        Me.XtraTabPage1.Controls.Add(Me.Label5)
        Me.XtraTabPage1.Controls.Add(Me.txtEfectivoContado)
        Me.XtraTabPage1.Controls.Add(Me.txtChequeContado)
        Me.XtraTabPage1.Controls.Add(Me.txtTarjetaContado)
        Me.XtraTabPage1.Controls.Add(Me.txtEfectivoCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtChequeCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtTarjetaCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtTransferenciadeCaja)
        Me.XtraTabPage1.Controls.Add(Me.Label8)
        Me.XtraTabPage1.Controls.Add(Me.txtTransferenciaDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtEfectivoDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtTransferenciaCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtChequeDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtTransferenciaContado)
        Me.XtraTabPage1.Controls.Add(Me.txtTarjetaDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.Label16)
        Me.XtraTabPage1.Controls.Add(Me.Label9)
        Me.XtraTabPage1.Controls.Add(Me.Label6)
        Me.XtraTabPage1.Controls.Add(Me.txtTotalContado)
        Me.XtraTabPage1.Controls.Add(Me.GroupControl1)
        Me.XtraTabPage1.Controls.Add(Me.txtTotalCalculado)
        Me.XtraTabPage1.Controls.Add(Me.txtTotalDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.Label10)
        Me.XtraTabPage1.Controls.Add(Me.Label3)
        Me.XtraTabPage1.Controls.Add(Me.txtEgresosDiferencia)
        Me.XtraTabPage1.Controls.Add(Me.txtEgresosContado)
        Me.XtraTabPage1.Controls.Add(Me.txtEgresosCalculado)
        Me.XtraTabPage1.Controls.Add(Me.SeparatorControl4)
        Me.XtraTabPage1.Controls.Add(Me.SeparatorControl1)
        Me.XtraTabPage1.Controls.Add(Me.SeparatorControl2)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(871, 403)
        Me.XtraTabPage1.Text = "Generales"
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl3.Location = New System.Drawing.Point(10, 259)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(579, 18)
        Me.SeparatorControl3.TabIndex = 350
        Me.SeparatorControl3.TabStop = False
        '
        'txtOtrasDiferencia
        '
        Me.txtOtrasDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtOtrasDiferencia.Location = New System.Drawing.Point(357, 235)
        Me.txtOtrasDiferencia.Name = "txtOtrasDiferencia"
        Me.txtOtrasDiferencia.ReadOnly = True
        Me.txtOtrasDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtOtrasDiferencia.TabIndex = 348
        Me.txtOtrasDiferencia.TabStop = False
        Me.txtOtrasDiferencia.Text = "0"
        '
        'txtOtrasCalculado
        '
        Me.txtOtrasCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtOtrasCalculado.Location = New System.Drawing.Point(238, 235)
        Me.txtOtrasCalculado.Name = "txtOtrasCalculado"
        Me.txtOtrasCalculado.ReadOnly = True
        Me.txtOtrasCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtOtrasCalculado.TabIndex = 346
        Me.txtOtrasCalculado.TabStop = False
        Me.txtOtrasCalculado.Text = "0"
        '
        'txtOtrasContado
        '
        Me.txtOtrasContado.Location = New System.Drawing.Point(119, 235)
        Me.txtOtrasContado.Name = "txtOtrasContado"
        Me.txtOtrasContado.Size = New System.Drawing.Size(120, 21)
        Me.txtOtrasContado.TabIndex = 12
        Me.txtOtrasContado.Text = "0"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(25, 239)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(34, 13)
        Me.Label51.TabIndex = 349
        Me.Label51.Text = "Otras"
        '
        'txtPermutaDiferencia
        '
        Me.txtPermutaDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPermutaDiferencia.Location = New System.Drawing.Point(357, 208)
        Me.txtPermutaDiferencia.Name = "txtPermutaDiferencia"
        Me.txtPermutaDiferencia.ReadOnly = True
        Me.txtPermutaDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtPermutaDiferencia.TabIndex = 344
        Me.txtPermutaDiferencia.TabStop = False
        Me.txtPermutaDiferencia.Text = "0"
        '
        'txtPermutaCalculado
        '
        Me.txtPermutaCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPermutaCalculado.Location = New System.Drawing.Point(238, 208)
        Me.txtPermutaCalculado.Name = "txtPermutaCalculado"
        Me.txtPermutaCalculado.ReadOnly = True
        Me.txtPermutaCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtPermutaCalculado.TabIndex = 342
        Me.txtPermutaCalculado.TabStop = False
        Me.txtPermutaCalculado.Text = "0"
        '
        'txtPermutaContado
        '
        Me.txtPermutaContado.Location = New System.Drawing.Point(119, 208)
        Me.txtPermutaContado.Name = "txtPermutaContado"
        Me.txtPermutaContado.Size = New System.Drawing.Size(120, 21)
        Me.txtPermutaContado.TabIndex = 11
        Me.txtPermutaContado.Text = "0"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(25, 212)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(52, 13)
        Me.Label50.TabIndex = 345
        Me.Label50.Text = "Permutas"
        '
        'txtBonosDiferencia
        '
        Me.txtBonosDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtBonosDiferencia.Location = New System.Drawing.Point(357, 181)
        Me.txtBonosDiferencia.Name = "txtBonosDiferencia"
        Me.txtBonosDiferencia.ReadOnly = True
        Me.txtBonosDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtBonosDiferencia.TabIndex = 340
        Me.txtBonosDiferencia.TabStop = False
        Me.txtBonosDiferencia.Text = "0"
        '
        'txtBonosCalculado
        '
        Me.txtBonosCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtBonosCalculado.Location = New System.Drawing.Point(238, 181)
        Me.txtBonosCalculado.Name = "txtBonosCalculado"
        Me.txtBonosCalculado.ReadOnly = True
        Me.txtBonosCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtBonosCalculado.TabIndex = 338
        Me.txtBonosCalculado.TabStop = False
        Me.txtBonosCalculado.Text = "0"
        '
        'txtBonosContado
        '
        Me.txtBonosContado.Location = New System.Drawing.Point(119, 181)
        Me.txtBonosContado.Name = "txtBonosContado"
        Me.txtBonosContado.Size = New System.Drawing.Size(120, 21)
        Me.txtBonosContado.TabIndex = 10
        Me.txtBonosContado.Text = "0"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(25, 185)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(36, 13)
        Me.Label49.TabIndex = 341
        Me.Label49.Text = "Bonos"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(25, 114)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(54, 13)
        Me.Label47.TabIndex = 334
        Me.Label47.Text = "Depósitos"
        '
        'txtDepositoContado
        '
        Me.txtDepositoContado.Location = New System.Drawing.Point(119, 111)
        Me.txtDepositoContado.Name = "txtDepositoContado"
        Me.txtDepositoContado.Size = New System.Drawing.Size(120, 21)
        Me.txtDepositoContado.TabIndex = 8
        Me.txtDepositoContado.Text = "0"
        '
        'txtDepositoCalculado
        '
        Me.txtDepositoCalculado.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDepositoCalculado.Location = New System.Drawing.Point(238, 111)
        Me.txtDepositoCalculado.Name = "txtDepositoCalculado"
        Me.txtDepositoCalculado.ReadOnly = True
        Me.txtDepositoCalculado.Size = New System.Drawing.Size(120, 21)
        Me.txtDepositoCalculado.TabIndex = 336
        Me.txtDepositoCalculado.TabStop = False
        Me.txtDepositoCalculado.Text = "0"
        '
        'txtDepositoDiferencia
        '
        Me.txtDepositoDiferencia.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtDepositoDiferencia.Location = New System.Drawing.Point(357, 111)
        Me.txtDepositoDiferencia.Name = "txtDepositoDiferencia"
        Me.txtDepositoDiferencia.ReadOnly = True
        Me.txtDepositoDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.txtDepositoDiferencia.TabIndex = 337
        Me.txtDepositoDiferencia.TabStop = False
        Me.txtDepositoDiferencia.Text = "0"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.Location = New System.Drawing.Point(10, 161)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(579, 18)
        Me.SeparatorControl1.TabIndex = 333
        Me.SeparatorControl1.TabStop = False
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.AutoScroll = True
        Me.XtraTabPage2.Controls.Add(Me.XtraTabControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(871, 403)
        Me.XtraTabPage2.Text = "Transacciones"
        '
        'XtraTabControl2
        '
        Me.XtraTabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XtraTabControl2.Location = New System.Drawing.Point(3, 2)
        Me.XtraTabControl2.Name = "XtraTabControl2"
        Me.XtraTabControl2.SelectedTabPage = Me.XtraTabPage4
        Me.XtraTabControl2.Size = New System.Drawing.Size(865, 398)
        Me.XtraTabControl2.TabIndex = 0
        Me.XtraTabControl2.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage4, Me.XtraTabPage5})
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.Panel1)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(859, 370)
        Me.XtraTabPage4.Text = "Resumen"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.txtOtras)
        Me.Panel1.Controls.Add(Me.Label57)
        Me.Panel1.Controls.Add(Me.txtPermutas)
        Me.Panel1.Controls.Add(Me.Label56)
        Me.Panel1.Controls.Add(Me.txtBonos)
        Me.Panel1.Controls.Add(Me.Label55)
        Me.Panel1.Controls.Add(Me.Label46)
        Me.Panel1.Controls.Add(Me.Label45)
        Me.Panel1.Controls.Add(Me.txtPagosFinanciamientos)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.txtFinanciamientos)
        Me.Panel1.Controls.Add(Me.txtCantTransaccion)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txtGranTotal)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label43)
        Me.Panel1.Controls.Add(Me.txtVentaContado)
        Me.Panel1.Controls.Add(Me.txtTotalEgresos)
        Me.Panel1.Controls.Add(Me.txtVentaCredito)
        Me.Panel1.Controls.Add(Me.Label44)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.txtRecibosEgresos)
        Me.Panel1.Controls.Add(Me.txtReciboIngreso)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.txtDevolucionesEfect)
        Me.Panel1.Controls.Add(Me.txtDevolucionesEfectivo)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.txtSubtotal)
        Me.Panel1.Controls.Add(Me.txtOtrosIngresos)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.txtDeposito)
        Me.Panel1.Controls.Add(Me.txtCobrosAdelantados)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.txtTarjeta)
        Me.Panel1.Controls.Add(Me.txtDevoluciones)
        Me.Panel1.Controls.Add(Me.txtCheque)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.txtEfectivo)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Controls.Add(Me.txtDevolucionesCredito)
        Me.Panel1.Controls.Add(Me.Label41)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.Label42)
        Me.Panel1.Controls.Add(Me.txtDevolucionesBoucher)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 370)
        Me.Panel1.TabIndex = 0
        '
        'txtOtras
        '
        Me.txtOtras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtras.BackColor = System.Drawing.Color.White
        Me.txtOtras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOtras.Location = New System.Drawing.Point(738, 215)
        Me.txtOtras.Name = "txtOtras"
        Me.txtOtras.ReadOnly = True
        Me.txtOtras.Size = New System.Drawing.Size(121, 14)
        Me.txtOtras.TabIndex = 66
        '
        'Label57
        '
        Me.Label57.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(623, 215)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(34, 13)
        Me.Label57.TabIndex = 65
        Me.Label57.Text = "Otras"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPermutas
        '
        Me.txtPermutas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPermutas.BackColor = System.Drawing.Color.White
        Me.txtPermutas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPermutas.Location = New System.Drawing.Point(738, 188)
        Me.txtPermutas.Name = "txtPermutas"
        Me.txtPermutas.ReadOnly = True
        Me.txtPermutas.Size = New System.Drawing.Size(121, 14)
        Me.txtPermutas.TabIndex = 64
        '
        'Label56
        '
        Me.Label56.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(623, 188)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(52, 13)
        Me.Label56.TabIndex = 63
        Me.Label56.Text = "Permutas"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBonos
        '
        Me.txtBonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBonos.BackColor = System.Drawing.Color.White
        Me.txtBonos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBonos.Location = New System.Drawing.Point(738, 161)
        Me.txtBonos.Name = "txtBonos"
        Me.txtBonos.ReadOnly = True
        Me.txtBonos.Size = New System.Drawing.Size(121, 14)
        Me.txtBonos.TabIndex = 62
        '
        'Label55
        '
        Me.Label55.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(623, 161)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(36, 13)
        Me.Label55.TabIndex = 61
        Me.Label55.Text = "Bonos"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(623, 324)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(64, 13)
        Me.Label46.TabIndex = 60
        Me.Label46.Text = "Gran total"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(15, 201)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(117, 13)
        Me.Label45.TabIndex = 58
        Me.Label45.Text = "Pagos financiamientos:"
        '
        'txtPagosFinanciamientos
        '
        Me.txtPagosFinanciamientos.BackColor = System.Drawing.Color.White
        Me.txtPagosFinanciamientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPagosFinanciamientos.Location = New System.Drawing.Point(138, 201)
        Me.txtPagosFinanciamientos.Name = "txtPagosFinanciamientos"
        Me.txtPagosFinanciamientos.ReadOnly = True
        Me.txtPagosFinanciamientos.Size = New System.Drawing.Size(125, 14)
        Me.txtPagosFinanciamientos.TabIndex = 59
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(15, 175)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(87, 13)
        Me.Label33.TabIndex = 56
        Me.Label33.Text = "Financiamientos:"
        '
        'txtFinanciamientos
        '
        Me.txtFinanciamientos.BackColor = System.Drawing.Color.White
        Me.txtFinanciamientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFinanciamientos.Location = New System.Drawing.Point(138, 175)
        Me.txtFinanciamientos.Name = "txtFinanciamientos"
        Me.txtFinanciamientos.ReadOnly = True
        Me.txtFinanciamientos.Size = New System.Drawing.Size(125, 14)
        Me.txtFinanciamientos.TabIndex = 57
        '
        'txtCantTransaccion
        '
        Me.txtCantTransaccion.BackColor = System.Drawing.Color.White
        Me.txtCantTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCantTransaccion.Location = New System.Drawing.Point(121, 9)
        Me.txtCantTransaccion.Name = "txtCantTransaccion"
        Me.txtCantTransaccion.ReadOnly = True
        Me.txtCantTransaccion.Size = New System.Drawing.Size(125, 14)
        Me.txtCantTransaccion.TabIndex = 17
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 13)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Cant. Transacciones:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(101, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Ventas de contado:"
        '
        'txtGranTotal
        '
        Me.txtGranTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGranTotal.BackColor = System.Drawing.Color.White
        Me.txtGranTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGranTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGranTotal.Location = New System.Drawing.Point(738, 322)
        Me.txtGranTotal.Name = "txtGranTotal"
        Me.txtGranTotal.ReadOnly = True
        Me.txtGranTotal.Size = New System.Drawing.Size(121, 14)
        Me.txtGranTotal.TabIndex = 54
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(95, 13)
        Me.Label27.TabIndex = 16
        Me.Label27.Text = "Ventas de crédito:"
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(316, 2987)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 13)
        Me.Label43.TabIndex = 53
        Me.Label43.Text = "Gran total"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVentaContado
        '
        Me.txtVentaContado.BackColor = System.Drawing.Color.White
        Me.txtVentaContado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVentaContado.Location = New System.Drawing.Point(138, 42)
        Me.txtVentaContado.Name = "txtVentaContado"
        Me.txtVentaContado.ReadOnly = True
        Me.txtVentaContado.Size = New System.Drawing.Size(125, 14)
        Me.txtVentaContado.TabIndex = 18
        '
        'txtTotalEgresos
        '
        Me.txtTotalEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalEgresos.BackColor = System.Drawing.Color.White
        Me.txtTotalEgresos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalEgresos.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEgresos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalEgresos.Location = New System.Drawing.Point(738, 295)
        Me.txtTotalEgresos.Name = "txtTotalEgresos"
        Me.txtTotalEgresos.ReadOnly = True
        Me.txtTotalEgresos.Size = New System.Drawing.Size(121, 14)
        Me.txtTotalEgresos.TabIndex = 52
        '
        'txtVentaCredito
        '
        Me.txtVentaCredito.BackColor = System.Drawing.Color.White
        Me.txtVentaCredito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVentaCredito.Location = New System.Drawing.Point(138, 69)
        Me.txtVentaCredito.Name = "txtVentaCredito"
        Me.txtVentaCredito.ReadOnly = True
        Me.txtVentaCredito.Size = New System.Drawing.Size(125, 14)
        Me.txtVentaCredito.TabIndex = 19
        '
        'Label44
        '
        Me.Label44.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(623, 295)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(101, 13)
        Me.Label44.TabIndex = 51
        Me.Label44.Text = "Total de egresos"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 96)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(106, 13)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Recibos de ingresos:"
        '
        'txtRecibosEgresos
        '
        Me.txtRecibosEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecibosEgresos.BackColor = System.Drawing.Color.White
        Me.txtRecibosEgresos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRecibosEgresos.Location = New System.Drawing.Point(738, 268)
        Me.txtRecibosEgresos.Name = "txtRecibosEgresos"
        Me.txtRecibosEgresos.ReadOnly = True
        Me.txtRecibosEgresos.Size = New System.Drawing.Size(121, 14)
        Me.txtRecibosEgresos.TabIndex = 50
        '
        'txtReciboIngreso
        '
        Me.txtReciboIngreso.BackColor = System.Drawing.Color.White
        Me.txtReciboIngreso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReciboIngreso.Location = New System.Drawing.Point(138, 96)
        Me.txtReciboIngreso.Name = "txtReciboIngreso"
        Me.txtReciboIngreso.ReadOnly = True
        Me.txtReciboIngreso.Size = New System.Drawing.Size(125, 14)
        Me.txtReciboIngreso.TabIndex = 21
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(623, 268)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(107, 13)
        Me.Label36.TabIndex = 49
        Me.Label36.Text = "- Recibos de egresos"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(27, 251)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(131, 13)
        Me.Label29.TabIndex = 22
        Me.Label29.Text = "Devoluciones de efectivo:"
        '
        'txtDevolucionesEfect
        '
        Me.txtDevolucionesEfect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDevolucionesEfect.BackColor = System.Drawing.Color.White
        Me.txtDevolucionesEfect.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDevolucionesEfect.Location = New System.Drawing.Point(738, 241)
        Me.txtDevolucionesEfect.Name = "txtDevolucionesEfect"
        Me.txtDevolucionesEfect.ReadOnly = True
        Me.txtDevolucionesEfect.Size = New System.Drawing.Size(121, 14)
        Me.txtDevolucionesEfect.TabIndex = 48
        '
        'txtDevolucionesEfectivo
        '
        Me.txtDevolucionesEfectivo.BackColor = System.Drawing.Color.White
        Me.txtDevolucionesEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDevolucionesEfectivo.Location = New System.Drawing.Point(227, 251)
        Me.txtDevolucionesEfectivo.Name = "txtDevolucionesEfectivo"
        Me.txtDevolucionesEfectivo.ReadOnly = True
        Me.txtDevolucionesEfectivo.Size = New System.Drawing.Size(125, 14)
        Me.txtDevolucionesEfectivo.TabIndex = 23
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(623, 241)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(94, 13)
        Me.Label37.TabIndex = 47
        Me.Label37.Text = "- Dev. en efectivo"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(15, 123)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(81, 13)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "Otros ingresos:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.BackColor = System.Drawing.Color.White
        Me.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubtotal.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSubtotal.Location = New System.Drawing.Point(738, 134)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(121, 14)
        Me.txtSubtotal.TabIndex = 46
        '
        'txtOtrosIngresos
        '
        Me.txtOtrosIngresos.BackColor = System.Drawing.Color.White
        Me.txtOtrosIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOtrosIngresos.Location = New System.Drawing.Point(138, 123)
        Me.txtOtrosIngresos.Name = "txtOtrosIngresos"
        Me.txtOtrosIngresos.ReadOnly = True
        Me.txtOtrosIngresos.Size = New System.Drawing.Size(125, 14)
        Me.txtOtrosIngresos.TabIndex = 25
        '
        'Label38
        '
        Me.Label38.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(623, 134)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(55, 13)
        Me.Label38.TabIndex = 45
        Me.Label38.Text = "Subtotal"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 150)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(107, 13)
        Me.Label31.TabIndex = 26
        Me.Label31.Text = "Cobros adelantados:"
        '
        'txtDeposito
        '
        Me.txtDeposito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeposito.BackColor = System.Drawing.Color.White
        Me.txtDeposito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDeposito.Location = New System.Drawing.Point(738, 107)
        Me.txtDeposito.Name = "txtDeposito"
        Me.txtDeposito.ReadOnly = True
        Me.txtDeposito.Size = New System.Drawing.Size(121, 14)
        Me.txtDeposito.TabIndex = 44
        '
        'txtCobrosAdelantados
        '
        Me.txtCobrosAdelantados.BackColor = System.Drawing.Color.White
        Me.txtCobrosAdelantados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCobrosAdelantados.Location = New System.Drawing.Point(138, 150)
        Me.txtCobrosAdelantados.Name = "txtCobrosAdelantados"
        Me.txtCobrosAdelantados.ReadOnly = True
        Me.txtCobrosAdelantados.Size = New System.Drawing.Size(125, 14)
        Me.txtCobrosAdelantados.TabIndex = 27
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(623, 107)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(65, 13)
        Me.Label39.TabIndex = 43
        Me.Label39.Text = "+ Depósitos"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(15, 228)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(74, 13)
        Me.Label32.TabIndex = 28
        Me.Label32.Text = "Devoluciones:"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTarjeta.BackColor = System.Drawing.Color.White
        Me.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTarjeta.Location = New System.Drawing.Point(738, 80)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.ReadOnly = True
        Me.txtTarjeta.Size = New System.Drawing.Size(121, 14)
        Me.txtTarjeta.TabIndex = 42
        '
        'txtDevoluciones
        '
        Me.txtDevoluciones.BackColor = System.Drawing.Color.White
        Me.txtDevoluciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDevoluciones.Location = New System.Drawing.Point(138, 227)
        Me.txtDevoluciones.Name = "txtDevoluciones"
        Me.txtDevoluciones.ReadOnly = True
        Me.txtDevoluciones.Size = New System.Drawing.Size(125, 14)
        Me.txtDevoluciones.TabIndex = 29
        '
        'txtCheque
        '
        Me.txtCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCheque.BackColor = System.Drawing.Color.White
        Me.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCheque.Location = New System.Drawing.Point(738, 53)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.ReadOnly = True
        Me.txtCheque.Size = New System.Drawing.Size(121, 14)
        Me.txtCheque.TabIndex = 41
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(27, 278)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(177, 13)
        Me.Label34.TabIndex = 32
        Me.Label34.Text = "Devoluciones de facturas a crédito:"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.BackColor = System.Drawing.Color.White
        Me.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtEfectivo.Location = New System.Drawing.Point(738, 26)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.ReadOnly = True
        Me.txtEfectivo.Size = New System.Drawing.Size(121, 14)
        Me.txtEfectivo.TabIndex = 40
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(623, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(58, 13)
        Me.Label40.TabIndex = 39
        Me.Label40.Text = "+ Tarjetas"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDevolucionesCredito
        '
        Me.txtDevolucionesCredito.BackColor = System.Drawing.Color.White
        Me.txtDevolucionesCredito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDevolucionesCredito.Location = New System.Drawing.Point(227, 278)
        Me.txtDevolucionesCredito.Name = "txtDevolucionesCredito"
        Me.txtDevolucionesCredito.ReadOnly = True
        Me.txtDevolucionesCredito.Size = New System.Drawing.Size(125, 14)
        Me.txtDevolucionesCredito.TabIndex = 33
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(623, 53)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(60, 13)
        Me.Label41.TabIndex = 38
        Me.Label41.Text = "+ Cheques"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(27, 305)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(181, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Devoluciones  aplicadas en boucher:"
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(623, 26)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(57, 13)
        Me.Label42.TabIndex = 37
        Me.Label42.Text = "+ Efectivo"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDevolucionesBoucher
        '
        Me.txtDevolucionesBoucher.BackColor = System.Drawing.Color.White
        Me.txtDevolucionesBoucher.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDevolucionesBoucher.Location = New System.Drawing.Point(227, 305)
        Me.txtDevolucionesBoucher.Name = "txtDevolucionesBoucher"
        Me.txtDevolucionesBoucher.ReadOnly = True
        Me.txtDevolucionesBoucher.Size = New System.Drawing.Size(125, 14)
        Me.txtDevolucionesBoucher.TabIndex = 35
        '
        'XtraTabPage5
        '
        Me.XtraTabPage5.Controls.Add(Me.DgvTransacciones)
        Me.XtraTabPage5.Controls.Add(Me.BindingNavigator)
        Me.XtraTabPage5.Name = "XtraTabPage5"
        Me.XtraTabPage5.Size = New System.Drawing.Size(859, 370)
        Me.XtraTabPage5.Text = "Detalles"
        '
        'DgvTransacciones
        '
        Me.DgvTransacciones.AllowUserToAddRows = False
        Me.DgvTransacciones.AllowUserToDeleteRows = False
        Me.DgvTransacciones.AllowUserToResizeColumns = False
        Me.DgvTransacciones.AllowUserToResizeRows = False
        Me.DgvTransacciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvTransacciones.BackgroundColor = System.Drawing.Color.White
        Me.DgvTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTransacciones.Location = New System.Drawing.Point(3, 3)
        Me.DgvTransacciones.Name = "DgvTransacciones"
        Me.DgvTransacciones.ReadOnly = True
        Me.DgvTransacciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvTransacciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTransacciones.ShowCellErrors = False
        Me.DgvTransacciones.Size = New System.Drawing.Size(851, 339)
        Me.DgvTransacciones.TabIndex = 3
        '
        'BindingNavigator
        '
        Me.BindingNavigator.AddNewItem = Nothing
        Me.BindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator.DeleteItem = Nothing
        Me.BindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator.Location = New System.Drawing.Point(0, 345)
        Me.BindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator.Name = "BindingNavigator"
        Me.BindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator.Size = New System.Drawing.Size(859, 25)
        Me.BindingNavigator.TabIndex = 1
        Me.BindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.XtraTabControl3)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(871, 403)
        Me.XtraTabPage3.Text = "Historial"
        '
        'XtraTabControl3
        '
        Me.XtraTabControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl3.Location = New System.Drawing.Point(2, 4)
        Me.XtraTabControl3.Name = "XtraTabControl3"
        Me.XtraTabControl3.SelectedTabPage = Me.XtraTabPage6
        Me.XtraTabControl3.Size = New System.Drawing.Size(864, 396)
        Me.XtraTabControl3.TabIndex = 1
        Me.XtraTabControl3.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage6, Me.XtraTabPage7})
        '
        'XtraTabPage6
        '
        Me.XtraTabPage6.Controls.Add(Me.DgvHistorial)
        Me.XtraTabPage6.Name = "XtraTabPage6"
        Me.XtraTabPage6.Size = New System.Drawing.Size(858, 368)
        Me.XtraTabPage6.Text = "Historial de cortes"
        '
        'DgvHistorial
        '
        Me.DgvHistorial.AllowUserToAddRows = False
        Me.DgvHistorial.AllowUserToDeleteRows = False
        Me.DgvHistorial.AllowUserToResizeColumns = False
        Me.DgvHistorial.AllowUserToResizeRows = False
        Me.DgvHistorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.DgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvHistorial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDCorte, Me.Documento, Me.Fecha, Me.UsuarioPic, Me.NombreUsuario, Me.Horario, Me.CalculadoTotal, Me.CantTransacciones, Me.Diferencia, Me.RetiroTotal})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvHistorial.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvHistorial.Location = New System.Drawing.Point(2, 2)
        Me.DgvHistorial.MultiSelect = False
        Me.DgvHistorial.Name = "DgvHistorial"
        Me.DgvHistorial.ReadOnly = True
        Me.DgvHistorial.RowHeadersWidth = 10
        Me.DgvHistorial.RowTemplate.Height = 40
        Me.DgvHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvHistorial.ShowCellErrors = False
        Me.DgvHistorial.Size = New System.Drawing.Size(856, 369)
        Me.DgvHistorial.TabIndex = 0
        '
        'IDCorte
        '
        Me.IDCorte.HeaderText = "IDCorte"
        Me.IDCorte.Name = "IDCorte"
        Me.IDCorte.ReadOnly = True
        Me.IDCorte.Visible = False
        '
        'Documento
        '
        Me.Documento.ActiveLinkColor = System.Drawing.Color.BlueViolet
        Me.Documento.HeaderText = "Documento"
        Me.Documento.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.Documento.LinkColor = System.Drawing.Color.DodgerBlue
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Documento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Documento.VisitedLinkColor = System.Drawing.Color.Gray
        Me.Documento.Width = 95
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 140
        '
        'UsuarioPic
        '
        Me.UsuarioPic.HeaderText = ""
        Me.UsuarioPic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.UsuarioPic.Name = "UsuarioPic"
        Me.UsuarioPic.ReadOnly = True
        Me.UsuarioPic.Width = 40
        '
        'NombreUsuario
        '
        Me.NombreUsuario.HeaderText = "Usuario"
        Me.NombreUsuario.Name = "NombreUsuario"
        Me.NombreUsuario.ReadOnly = True
        Me.NombreUsuario.Width = 220
        '
        'Horario
        '
        Me.Horario.HeaderText = "Horario"
        Me.Horario.Name = "Horario"
        Me.Horario.ReadOnly = True
        Me.Horario.Width = 250
        '
        'CalculadoTotal
        '
        Me.CalculadoTotal.HeaderText = "Contado"
        Me.CalculadoTotal.Name = "CalculadoTotal"
        Me.CalculadoTotal.ReadOnly = True
        '
        'CantTransacciones
        '
        Me.CantTransacciones.HeaderText = "Calculado"
        Me.CantTransacciones.Name = "CantTransacciones"
        Me.CantTransacciones.ReadOnly = True
        '
        'Diferencia
        '
        Me.Diferencia.HeaderText = "Diferencia"
        Me.Diferencia.Name = "Diferencia"
        Me.Diferencia.ReadOnly = True
        '
        'RetiroTotal
        '
        Me.RetiroTotal.HeaderText = "Retiro"
        Me.RetiroTotal.Name = "RetiroTotal"
        Me.RetiroTotal.ReadOnly = True
        '
        'XtraTabPage7
        '
        Me.XtraTabPage7.Controls.Add(Me.DgvMovimientos)
        Me.XtraTabPage7.Name = "XtraTabPage7"
        Me.XtraTabPage7.Size = New System.Drawing.Size(858, 368)
        Me.XtraTabPage7.Text = "Movimientos"
        '
        'DgvMovimientos
        '
        Me.DgvMovimientos.AllowUserToAddRows = False
        Me.DgvMovimientos.AllowUserToDeleteRows = False
        Me.DgvMovimientos.AllowUserToResizeColumns = False
        Me.DgvMovimientos.AllowUserToResizeRows = False
        Me.DgvMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvMovimientos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.DgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewLinkColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.Nulo})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvMovimientos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DgvMovimientos.Location = New System.Drawing.Point(2, 2)
        Me.DgvMovimientos.MultiSelect = False
        Me.DgvMovimientos.Name = "DgvMovimientos"
        Me.DgvMovimientos.ReadOnly = True
        Me.DgvMovimientos.RowHeadersWidth = 40
        Me.DgvMovimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMovimientos.ShowCellErrors = False
        Me.DgvMovimientos.ShowEditingIcon = False
        Me.DgvMovimientos.ShowRowErrors = False
        Me.DgvMovimientos.Size = New System.Drawing.Size(859, 369)
        Me.DgvMovimientos.TabIndex = 1
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 135
        '
        'DataGridViewLinkColumn1
        '
        Me.DataGridViewLinkColumn1.HeaderText = "Documento"
        Me.DataGridViewLinkColumn1.Name = "DataGridViewLinkColumn1"
        Me.DataGridViewLinkColumn1.ReadOnly = True
        Me.DataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewLinkColumn1.Width = 165
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Usuario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 160
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn8.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 65
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Entradas"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Salidas"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn7.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Nulo
        '
        Me.Nulo.HeaderText = "Nulo"
        Me.Nulo.Name = "Nulo"
        Me.Nulo.ReadOnly = True
        Me.Nulo.Visible = False
        '
        'GbxUserInfo
        '
        Me.GbxUserInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbxUserInfo.Controls.Add(Me.txtHora)
        Me.GbxUserInfo.Controls.Add(Me.txtSecondID)
        Me.GbxUserInfo.Controls.Add(Me.txtFecha)
        Me.GbxUserInfo.Controls.Add(Me.Label23)
        Me.GbxUserInfo.Controls.Add(Me.txtIDCorte)
        Me.GbxUserInfo.Controls.Add(Me.Label24)
        Me.GbxUserInfo.Controls.Add(Me.Label25)
        Me.GbxUserInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbxUserInfo.ForeColor = System.Drawing.Color.DarkRed
        Me.GbxUserInfo.Location = New System.Drawing.Point(570, 127)
        Me.GbxUserInfo.Name = "GbxUserInfo"
        Me.GbxUserInfo.Size = New System.Drawing.Size(307, 72)
        Me.GbxUserInfo.TabIndex = 349
        Me.GbxUserInfo.TabStop = False
        Me.GbxUserInfo.Text = "User Info"
        '
        'txtHora
        '
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.Enabled = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.txtHora.Location = New System.Drawing.Point(198, 42)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(98, 23)
        Me.txtHora.TabIndex = 416
        Me.txtHora.Value = New Date(2016, 10, 18, 12, 56, 0, 0)
        '
        'txtSecondID
        '
        Me.txtSecondID.Enabled = False
        Me.txtSecondID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSecondID.Location = New System.Drawing.Point(159, 15)
        Me.txtSecondID.Name = "txtSecondID"
        Me.txtSecondID.ReadOnly = True
        Me.txtSecondID.Size = New System.Drawing.Size(137, 23)
        Me.txtSecondID.TabIndex = 110
        Me.txtSecondID.TabStop = False
        Me.txtSecondID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        Me.txtFecha.CustomFormat = "dd/MM/yyyy"
        Me.txtFecha.Enabled = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(59, 42)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(97, 23)
        Me.txtFecha.TabIndex = 415
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(159, 45)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 15)
        Me.Label23.TabIndex = 108
        Me.Label23.Text = "Hora"
        '
        'txtIDCorte
        '
        Me.txtIDCorte.Enabled = False
        Me.txtIDCorte.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDCorte.Location = New System.Drawing.Point(59, 15)
        Me.txtIDCorte.Name = "txtIDCorte"
        Me.txtIDCorte.ReadOnly = True
        Me.txtIDCorte.Size = New System.Drawing.Size(94, 23)
        Me.txtIDCorte.TabIndex = 106
        Me.txtIDCorte.TabStop = False
        Me.txtIDCorte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(7, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(38, 15)
        Me.Label24.TabIndex = 105
        Me.Label24.Text = "Fecha"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(7, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 15)
        Me.Label25.TabIndex = 104
        Me.Label25.Text = "Código"
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicBoxLogo.ImageLocation = ""
        Me.PicBoxLogo.Location = New System.Drawing.Point(5, 27)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(263, 85)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 351
        Me.PicBoxLogo.TabStop = False
        '
        'MenuBarra
        '
        Me.MenuBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesosToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuBarra.Location = New System.Drawing.Point(0, 0)
        Me.MenuBarra.Name = "MenuBarra"
        Me.MenuBarra.Size = New System.Drawing.Size(887, 24)
        Me.MenuBarra.TabIndex = 350
        Me.MenuBarra.Text = "MenuStrip1"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoRegistroToolStripMenuItem, Me.GuardarRegistroToolStripMenuItem, Me.BuscarToolStripMenuItem, Me.ImprimirToolStripMenuItem, Me.ToolStripSeparator3, Me.SalirToolStripMenuItem})
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
        Me.NuevoRegistroToolStripMenuItem.Size = New System.Drawing.Size(241, 38)
        Me.NuevoRegistroToolStripMenuItem.Text = "Nuevo "
        '
        'GuardarRegistroToolStripMenuItem
        '
        Me.GuardarRegistroToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.GuardarRegistroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarRegistroToolStripMenuItem.Name = "GuardarRegistroToolStripMenuItem"
        Me.GuardarRegistroToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.GuardarRegistroToolStripMenuItem.Size = New System.Drawing.Size(241, 38)
        Me.GuardarRegistroToolStripMenuItem.Text = "Guardar"
        '
        'BuscarToolStripMenuItem
        '
        Me.BuscarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.BuscarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BuscarToolStripMenuItem.Name = "BuscarToolStripMenuItem"
        Me.BuscarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.BuscarToolStripMenuItem.Size = New System.Drawing.Size(241, 38)
        Me.BuscarToolStripMenuItem.Text = "Buscar cortes de caja"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(241, 38)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(238, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.SalirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(241, 38)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitarArtículoToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ConsultasToolStripMenuItem.Text = "Edición"
        '
        'QuitarArtículoToolStripMenuItem
        '
        Me.QuitarArtículoToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.QuitarArtículoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitarArtículoToolStripMenuItem.Name = "QuitarArtículoToolStripMenuItem"
        Me.QuitarArtículoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.QuitarArtículoToolStripMenuItem.Size = New System.Drawing.Size(144, 38)
        Me.QuitarArtículoToolStripMenuItem.Text = "Anular"
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
        'btnBuscarTransacciones
        '
        Me.btnBuscarTransacciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarTransacciones.ForeColor = System.Drawing.Color.Black
        Me.btnBuscarTransacciones.Image = Global.Libregco.My.Resources.Resources.Search_x72
        Me.btnBuscarTransacciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarTransacciones.Location = New System.Drawing.Point(332, 2)
        Me.btnBuscarTransacciones.Name = "btnBuscarTransacciones"
        Me.btnBuscarTransacciones.Size = New System.Drawing.Size(199, 52)
        Me.btnBuscarTransacciones.TabIndex = 3
        Me.btnBuscarTransacciones.Text = "Buscar transacciones"
        Me.btnBuscarTransacciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarTransacciones.UseVisualStyleBackColor = True
        '
        'cbxAreaImpresion
        '
        Me.cbxAreaImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAreaImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAreaImpresion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxAreaImpresion.FormattingEnabled = True
        Me.cbxAreaImpresion.Location = New System.Drawing.Point(84, 55)
        Me.cbxAreaImpresion.Name = "cbxAreaImpresion"
        Me.cbxAreaImpresion.Size = New System.Drawing.Size(412, 21)
        Me.cbxAreaImpresion.TabIndex = 336
        '
        'cbxEmpleado
        '
        Me.cbxEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxEmpleado.FormattingEnabled = True
        Me.cbxEmpleado.Location = New System.Drawing.Point(84, 28)
        Me.cbxEmpleado.Name = "cbxEmpleado"
        Me.cbxEmpleado.Size = New System.Drawing.Size(412, 21)
        Me.cbxEmpleado.TabIndex = 335
        '
        'ToastNotificationsManager1
        '
        Me.ToastNotificationsManager1.ApplicationId = "8665bdf0-48fe-4a2f-bf23-41855dbebccb"
        Me.ToastNotificationsManager1.ApplicationName = "Libregco"
        Me.ToastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.[False]
        Me.ToastNotificationsManager1.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("5b8ab0b7-4fdb-4fa5-98a9-662149f8ae76", Global.Libregco.My.Resources.Resources.Prefacturax48, "Corte de caja guardado", "El corte de caja ha sido guardada satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("33dfd5d7-dece-4a75-8aac-7f9c16ba326c", Global.Libregco.My.Resources.Resources.Prefacturax48, "Corte de caja modificada", "El corte de caja ha sido modificado satisfactoriamente.", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'ChkNulo
        '
        Me.ChkNulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNulo.AutoSize = True
        Me.ChkNulo.Enabled = False
        Me.ChkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChkNulo.Location = New System.Drawing.Point(274, 102)
        Me.ChkNulo.Name = "ChkNulo"
        Me.ChkNulo.Size = New System.Drawing.Size(52, 19)
        Me.ChkNulo.TabIndex = 340
        Me.ChkNulo.Text = "Nulo"
        Me.ChkNulo.UseVisualStyleBackColor = True
        Me.ChkNulo.Visible = False
        '
        'chkTodoRango
        '
        Me.chkTodoRango.AutoSize = True
        Me.chkTodoRango.BackColor = System.Drawing.Color.Transparent
        Me.chkTodoRango.Checked = True
        Me.chkTodoRango.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodoRango.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.chkTodoRango.ForeColor = System.Drawing.Color.Black
        Me.chkTodoRango.Location = New System.Drawing.Point(366, 3)
        Me.chkTodoRango.Name = "chkTodoRango"
        Me.chkTodoRango.Size = New System.Drawing.Size(140, 17)
        Me.chkTodoRango.TabIndex = 348
        Me.chkTodoRango.Text = "Todas las transacciones"
        Me.chkTodoRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTodoRango.UseVisualStyleBackColor = False
        '
        'NavBarControl2
        '
        Me.NavBarControl2.ActiveGroup = Me.NavBarGroup3
        Me.NavBarControl2.Controls.Add(Me.NavBarGroupControlContainer3)
        Me.NavBarControl2.Controls.Add(Me.NavBarGroupControlContainer4)
        Me.NavBarControl2.ExplorerBarStretchLastGroup = True
        Me.NavBarControl2.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup3, Me.NavBarGroup4})
        Me.NavBarControl2.Location = New System.Drawing.Point(12, 127)
        Me.NavBarControl2.Name = "NavBarControl2"
        Me.NavBarControl2.OptionsNavPane.ExpandedWidth = 542
        Me.NavBarControl2.OptionsNavPane.ShowExpandButton = False
        Me.NavBarControl2.OptionsNavPane.ShowGroupImageInHeader = True
        Me.NavBarControl2.OptionsNavPane.ShowOverflowPanel = False
        Me.NavBarControl2.OptionsNavPane.ShowSplitter = False
        Me.NavBarControl2.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar
        Me.NavBarControl2.Size = New System.Drawing.Size(542, 124)
        Me.NavBarControl2.TabIndex = 355
        Me.NavBarControl2.Text = "NavBarControl2"
        '
        'NavBarGroup3
        '
        Me.NavBarGroup3.Caption = "Búsqueda"
        Me.NavBarGroup3.ControlContainer = Me.NavBarGroupControlContainer3
        Me.NavBarGroup3.Expanded = True
        Me.NavBarGroup3.GroupClientHeight = 61
        Me.NavBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarGroup3.ImageOptions.LargeImage = CType(resources.GetObject("NavBarGroup3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarGroup3.Name = "NavBarGroup3"
        '
        'NavBarGroupControlContainer3
        '
        Me.NavBarGroupControlContainer3.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer3.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer3.Controls.Add(Me.btnBuscarTransacciones)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.lblAreaImpresion)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.lblRango)
        Me.NavBarGroupControlContainer3.Controls.Add(Me.lblUsuario)
        Me.NavBarGroupControlContainer3.Name = "NavBarGroupControlContainer3"
        Me.NavBarGroupControlContainer3.Size = New System.Drawing.Size(534, 57)
        Me.NavBarGroupControlContainer3.TabIndex = 0
        '
        'lblAreaImpresion
        '
        Me.lblAreaImpresion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblAreaImpresion.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblAreaImpresion.Image = CType(resources.GetObject("lblAreaImpresion.Image"), System.Drawing.Image)
        Me.lblAreaImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAreaImpresion.Location = New System.Drawing.Point(3, 37)
        Me.lblAreaImpresion.Name = "lblAreaImpresion"
        Me.lblAreaImpresion.Size = New System.Drawing.Size(323, 16)
        Me.lblAreaImpresion.TabIndex = 9
        Me.lblAreaImpresion.Text = "       La consulta incluye todos las cajas o áreas de impresión"
        Me.lblAreaImpresion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRango
        '
        Me.lblRango.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblRango.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblRango.Image = CType(resources.GetObject("lblRango.Image"), System.Drawing.Image)
        Me.lblRango.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRango.Location = New System.Drawing.Point(3, 0)
        Me.lblRango.Name = "lblRango"
        Me.lblRango.Size = New System.Drawing.Size(284, 16)
        Me.lblRango.TabIndex = 8
        Me.lblRango.Text = "       El rango de fechas está completado"
        Me.lblRango.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblUsuario.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblUsuario.Image = CType(resources.GetObject("lblUsuario.Image"), System.Drawing.Image)
        Me.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUsuario.Location = New System.Drawing.Point(3, 18)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(284, 16)
        Me.lblUsuario.TabIndex = 7
        Me.lblUsuario.Text = "       La consulta incluye a todos los usuarios"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NavBarGroupControlContainer4
        '
        Me.NavBarGroupControlContainer4.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarGroupControlContainer4.Appearance.Options.UseBackColor = True
        Me.NavBarGroupControlContainer4.Controls.Add(Me.GroupControl4)
        Me.NavBarGroupControlContainer4.Controls.Add(Me.GroupControl3)
        Me.NavBarGroupControlContainer4.Name = "NavBarGroupControlContainer4"
        Me.NavBarGroupControlContainer4.Size = New System.Drawing.Size(534, 131)
        Me.NavBarGroupControlContainer4.TabIndex = 1
        '
        'GroupControl4
        '
        Me.GroupControl4.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Relationx24
        Me.GroupControl4.Controls.Add(Me.cbxEmpleado)
        Me.GroupControl4.Controls.Add(Me.Label1)
        Me.GroupControl4.Controls.Add(Me.Label18)
        Me.GroupControl4.Controls.Add(Me.cbxAreaImpresion)
        Me.GroupControl4.Location = New System.Drawing.Point(1, 63)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(509, 84)
        Me.GroupControl4.TabIndex = 1
        Me.GroupControl4.Text = "Relaciones"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionImageOptions.Image = Global.Libregco.My.Resources.Resources.Calendarx24
        Me.GroupControl3.Controls.Add(Me.Label20)
        Me.GroupControl3.Controls.Add(Me.Label21)
        Me.GroupControl3.Controls.Add(Me.dtpHasta)
        Me.GroupControl3.Controls.Add(Me.chkTodoRango)
        Me.GroupControl3.Controls.Add(Me.dtpDesde)
        Me.GroupControl3.Location = New System.Drawing.Point(1, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(509, 59)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "Rango de fechas"
        '
        'NavBarGroup4
        '
        Me.NavBarGroup4.Caption = "Control de filtrado"
        Me.NavBarGroup4.ControlContainer = Me.NavBarGroupControlContainer4
        Me.NavBarGroup4.GroupClientHeight = 135
        Me.NavBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarGroup4.ImageOptions.LargeImage = CType(resources.GetObject("NavBarGroup4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.NavBarGroup4.Name = "NavBarGroup4"
        '
        'frm_corte_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(887, 716)
        Me.Controls.Add(Me.NavBarControl2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ChkNulo)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.MenuBarra)
        Me.Controls.Add(Me.GbxUserInfo)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(903, 755)
        Me.Name = "frm_corte_caja"
        Me.Tag = "278"
        Me.Text = "Corte de caja"
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.SeparatorControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.XtraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl2.ResumeLayout(False)
        Me.XtraTabPage4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.XtraTabPage5.ResumeLayout(False)
        Me.XtraTabPage5.PerformLayout()
        CType(Me.DgvTransacciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator.ResumeLayout(False)
        Me.BindingNavigator.PerformLayout()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.XtraTabControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl3.ResumeLayout(False)
        Me.XtraTabPage6.ResumeLayout(False)
        CType(Me.DgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage7.ResumeLayout(False)
        CType(Me.DgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbxUserInfo.ResumeLayout(False)
        Me.GbxUserInfo.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBarra.ResumeLayout(False)
        Me.MenuBarra.PerformLayout()
        CType(Me.ToastNotificationsManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavBarControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl2.ResumeLayout(False)
        Me.NavBarGroupControlContainer3.ResumeLayout(False)
        Me.NavBarGroupControlContainer4.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEfectivoContado As TextBox
    Friend WithEvents txtChequeContado As TextBox
    Friend WithEvents txtTarjetaContado As TextBox
    Friend WithEvents txtTotalContado As TextBox
    Friend WithEvents txtEgresosContado As TextBox
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEgresosCalculado As TextBox
    Friend WithEvents txtTotalCalculado As TextBox
    Friend WithEvents txtTarjetaCalculado As TextBox
    Friend WithEvents txtChequeCalculado As TextBox
    Friend WithEvents txtEfectivoCalculado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtEgresosDiferencia As TextBox
    Friend WithEvents txtTotalDiferencia As TextBox
    Friend WithEvents txtTarjetaDiferencia As TextBox
    Friend WithEvents txtChequeDiferencia As TextBox
    Friend WithEvents txtEfectivoDiferencia As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents SeparatorControl4 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SeparatorControl5 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents txtEgresosRetirar As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalRetirar As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTarjetaRetirar As TextBox
    Friend WithEvents txtChequeRetirar As TextBox
    Friend WithEvents txtEfectivoRetirar As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents BarraEstado As ToolStrip
    Friend WithEvents lblDate As ToolStripLabel
    Friend WithEvents PicLoading As ToolStripButton
    Friend WithEvents ToolSeparator As ToolStripSeparator
    Friend WithEvents PicLogo As ToolStripButton
    Friend WithEvents NameSys As ToolStripLabel
    Friend WithEvents ToolSeparator2 As ToolStripSeparator
    Friend WithEvents lblStatusBar As ToolStripLabel
    Friend WithEvents IconPanel As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents btnNuevo As ToolStripMenuItem
    Friend WithEvents btnGuardarC As ToolStripMenuItem
    Friend WithEvents btnBuscar As ToolStripMenuItem
    Friend WithEvents btnAnular As ToolStripMenuItem
    Friend WithEvents btnImprimir As ToolStripMenuItem
    Friend WithEvents txtTransferenciaRetirar As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtTransferenciaDiferencia As TextBox
    Friend WithEvents txtTransferenciaCalculado As TextBox
    Friend WithEvents txtTransferenciaContado As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTransferenciadeCaja As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Hora As Timer
    Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents BindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents GbxUserInfo As GroupBox
    Friend WithEvents txtHora As DateTimePicker
    Friend WithEvents txtSecondID As TextBox
    Friend WithEvents txtFecha As DateTimePicker
    Private WithEvents Label23 As Label
    Friend WithEvents txtIDCorte As TextBox
    Private WithEvents Label24 As Label
    Private WithEvents Label25 As Label
    Friend WithEvents PicBoxLogo As PictureBox
    Friend WithEvents MenuBarra As MenuStrip
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarRegistroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitarArtículoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaLibregcoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnBuscarTransacciones As Button
    Friend WithEvents cbxAreaImpresion As ComboBox
    Friend WithEvents cbxEmpleado As ComboBox
    Friend WithEvents txtDevolucionesCredito As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtDevoluciones As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtCobrosAdelantados As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtOtrosIngresos As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtDevolucionesEfectivo As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtReciboIngreso As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtVentaCredito As TextBox
    Friend WithEvents txtVentaContado As TextBox
    Friend WithEvents txtCantTransaccion As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtGranTotal As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents txtTotalEgresos As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents txtRecibosEgresos As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtDevolucionesEfect As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txtDeposito As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txtTarjeta As TextBox
    Friend WithEvents txtCheque As TextBox
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents txtDevolucionesBoucher As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents DgvTransacciones As DataGridView
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label45 As Label
    Friend WithEvents txtPagosFinanciamientos As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtFinanciamientos As TextBox
    Friend WithEvents ToastNotificationsManager1 As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents ChkNulo As CheckBox
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DgvHistorial As DataGridView
    Friend WithEvents Label46 As Label
    Friend WithEvents SeparatorControl7 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents chkTodoRango As CheckBox
    Friend WithEvents NavBarControl2 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup3 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroupControlContainer3 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents lblAreaImpresion As Label
    Friend WithEvents lblRango As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents NavBarGroupControlContainer4 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents NavBarGroup4 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents XtraTabControl2 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents XtraTabPage5 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents IDCorte As DataGridViewTextBoxColumn
    Friend WithEvents Documento As DataGridViewLinkColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioPic As DataGridViewImageColumn
    Friend WithEvents NombreUsuario As DataGridViewTextBoxColumn
    Friend WithEvents Horario As DataGridViewTextBoxColumn
    Friend WithEvents CalculadoTotal As DataGridViewTextBoxColumn
    Friend WithEvents CantTransacciones As DataGridViewTextBoxColumn
    Friend WithEvents Diferencia As DataGridViewTextBoxColumn
    Friend WithEvents RetiroTotal As DataGridViewTextBoxColumn
    Friend WithEvents XtraTabControl3 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage6 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage7 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents DgvMovimientos As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewLinkColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents Nulo As DataGridViewTextBoxColumn
    Friend WithEvents txtOtrasRetirar As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents txtBonosRetirar As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents txtPermutaRetirar As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents txtDepositoRetirar As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents txtOtrasDiferencia As TextBox
    Friend WithEvents txtOtrasCalculado As TextBox
    Friend WithEvents txtOtrasContado As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents txtPermutaDiferencia As TextBox
    Friend WithEvents txtPermutaCalculado As TextBox
    Friend WithEvents txtPermutaContado As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents txtBonosDiferencia As TextBox
    Friend WithEvents txtBonosCalculado As TextBox
    Friend WithEvents txtBonosContado As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents txtDepositoContado As TextBox
    Friend WithEvents txtDepositoCalculado As TextBox
    Friend WithEvents txtDepositoDiferencia As TextBox
    Friend WithEvents txtOtras As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents txtPermutas As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents txtBonos As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents SeparatorControl3 As XtraEditors.SeparatorControl
End Class
