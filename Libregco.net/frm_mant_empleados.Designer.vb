<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mant_empleados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mant_empleados))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabCEmpleados = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.txtFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminarFoto = New System.Windows.Forms.Button()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.btnCargarFoto = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAbrirFoto = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.txtTelefonoHogar = New System.Windows.Forms.MaskedTextBox()
        Me.txtTelefonoPersonal = New System.Windows.Forms.MaskedTextBox()
        Me.txtCedula = New System.Windows.Forms.MaskedTextBox()
        Me.cbxMunicipio = New System.Windows.Forms.ComboBox()
        Me.CbxProvincia = New System.Windows.Forms.ComboBox()
        Me.CbxGenero = New System.Windows.Forms.ComboBox()
        Me.cbxNacionalidad = New System.Windows.Forms.ComboBox()
        Me.tel_hogar_label = New System.Windows.Forms.Label()
        Me.municipio_label = New System.Windows.Forms.Label()
        Me.tel_personal_label = New System.Windows.Forms.Label()
        Me.direccion_label = New System.Windows.Forms.Label()
        Me.provincia_label = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Nacionalidad_label = New System.Windows.Forms.Label()
        Me.nacimiento_label = New System.Windows.Forms.Label()
        Me.cedula_label = New System.Windows.Forms.Label()
        Me.genero_label = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkCobrador = New System.Windows.Forms.CheckBox()
        Me.chkVendedor = New System.Windows.Forms.CheckBox()
        Me.chkHabNomina = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtCotizable = New System.Windows.Forms.TextBox()
        Me.cbxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtIDSucursal = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPuesto = New System.Windows.Forms.TextBox()
        Me.btnBuscarNomina = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnBuscarAfp = New System.Windows.Forms.Button()
        Me.txtCarnet = New System.Windows.Forms.TextBox()
        Me.txtAfp = New System.Windows.Forms.TextBox()
        Me.txtIDAfp = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btn_buscarArs = New System.Windows.Forms.Button()
        Me.txtArs = New System.Windows.Forms.TextBox()
        Me.txtIDArs = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.label5 = New System.Windows.Forms.Label()
        Me.btnBuscarTanda = New System.Windows.Forms.Button()
        Me.label12 = New System.Windows.Forms.Label()
        Me.txtTanda = New System.Windows.Forms.TextBox()
        Me.txtTiempoLaboral = New System.Windows.Forms.TextBox()
        Me.txtIDTanda = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTipoNomina = New System.Windows.Forms.TextBox()
        Me.txtIDNomina = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSalarioDiario = New System.Windows.Forms.TextBox()
        Me.btnBuscarCargo = New System.Windows.Forms.Button()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox()
        Me.CbxPeriodoPago = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSeguroComplementario = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCuotaCuenta = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chkISR = New System.Windows.Forms.CheckBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkTesoreria = New System.Windows.Forms.CheckBox()
        Me.txtConsFlota = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCuotaPrestamo = New System.Windows.Forms.TextBox()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgvDeducciones = New System.Windows.Forms.DataGridView()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.btnProgramarVacaciones = New System.Windows.Forms.Button()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtIDVacaciones = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtTotalVacaciones = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDiasVacaciones = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.dtpVacacionInicia = New System.Windows.Forms.DateTimePicker()
        Me.dtpVacacionTermina = New System.Windows.Forms.DateTimePicker()
        Me.DgvVacaciones = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiasVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoPagoVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.dtpFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.DgvMensualidades = New System.Windows.Forms.DataGridView()
        Me.NumeroSalario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalarioMensualidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionesSalarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalesSalario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTiempoLaborado = New System.Windows.Forms.TextBox()
        Me.txtSumaSalarios = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtSalarioPromedioMensual = New System.Windows.Forms.TextBox()
        Me.TSNavidad = New DevExpress.XtraEditors.ToggleSwitch()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtNavidad = New System.Windows.Forms.TextBox()
        Me.txtSalarioPromedioDiario = New System.Windows.Forms.TextBox()
        Me.TSVacaciones = New DevExpress.XtraEditors.ToggleSwitch()
        Me.txtPreaviso = New System.Windows.Forms.TextBox()
        Me.txtVacaciones = New System.Windows.Forms.TextBox()
        Me.TsPreaviso = New DevExpress.XtraEditors.ToggleSwitch()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.TSCesantia = New DevExpress.XtraEditors.ToggleSwitch()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtCensantiaAntes = New System.Windows.Forms.TextBox()
        Me.txtCesantiaNuevo = New System.Windows.Forms.TextBox()
        Me.SeparatorControl5 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtTotalRecibir = New System.Windows.Forms.TextBox()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RutaDocumentoInfraccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiasLicencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.btnEliminarChat = New System.Windows.Forms.Button()
        Me.btnCargarChat = New System.Windows.Forms.Button()
        Me.btnAbrirChat = New System.Windows.Forms.Button()
        Me.btnEliminarCedula = New System.Windows.Forms.Button()
        Me.btnCargarCedula = New System.Windows.Forms.Button()
        Me.btnAbrirCedula = New System.Windows.Forms.Button()
        Me.cbxEstadoChat = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PicChat = New System.Windows.Forms.PictureBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.PicBCedula = New System.Windows.Forms.PictureBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PicLogo2 = New System.Windows.Forms.PictureBox()
        Me.CbxPrivilegios = New System.Windows.Forms.ComboBox()
        Me.label18 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMensajeFactores = New System.Windows.Forms.Label()
        Me.txtPasswordFactorRep = New Libregco.Watermark()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtPasswordFactor = New Libregco.Watermark()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblPassInfo = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.label15 = New System.Windows.Forms.Label()
        Me.txtConfirmacionPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.ChkAlertas = New System.Windows.Forms.CheckBox()
        Me.lblFechaPassword = New System.Windows.Forms.Label()
        Me.chkNulo = New System.Windows.Forms.CheckBox()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.cod_cliente_label = New System.Windows.Forms.Label()
        Me.apodo_label = New System.Windows.Forms.Label()
        Me.nombre_label = New System.Windows.Forms.Label()
        Me.txtIDEmpleado = New System.Windows.Forms.TextBox()
        Me.txtApodo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblSlogan = New System.Windows.Forms.Label()
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarFotoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirFotoDelEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarFotoDelEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CédulaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarImagenDeIndetificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImagenDelChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.lblDate = New System.Windows.Forms.ToolStripLabel()
        Me.PicLoading = New System.Windows.Forms.ToolStripButton()
        Me.ToolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.Fecha = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabCEmpleados.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvDeducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DgvVacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.DgvMensualidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSNavidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSVacaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TsPreaviso.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSCesantia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage3.SuspendLayout()
        CType(Me.PicChat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.PicLogo2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IconPanel.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.MenuBar.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCEmpleados
        '
        Me.TabCEmpleados.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabCEmpleados.Controls.Add(Me.tabPage1)
        Me.TabCEmpleados.Controls.Add(Me.tabPage2)
        Me.TabCEmpleados.Controls.Add(Me.TabPage4)
        Me.TabCEmpleados.Controls.Add(Me.TabPage6)
        Me.TabCEmpleados.Controls.Add(Me.tabPage3)
        Me.TabCEmpleados.Controls.Add(Me.TabPage5)
        Me.TabCEmpleados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabCEmpleados.Location = New System.Drawing.Point(12, 178)
        Me.TabCEmpleados.Name = "TabCEmpleados"
        Me.TabCEmpleados.SelectedIndex = 0
        Me.TabCEmpleados.Size = New System.Drawing.Size(732, 394)
        Me.TabCEmpleados.TabIndex = 2
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.txtFechaNacimiento)
        Me.tabPage1.Controls.Add(Me.btnEliminarFoto)
        Me.tabPage1.Controls.Add(Me.txtCorreo)
        Me.tabPage1.Controls.Add(Me.btnCargarFoto)
        Me.tabPage1.Controls.Add(Me.Label1)
        Me.tabPage1.Controls.Add(Me.btnAbrirFoto)
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.label4)
        Me.tabPage1.Controls.Add(Me.label3)
        Me.tabPage1.Controls.Add(Me.PicFoto)
        Me.tabPage1.Controls.Add(Me.txtTelefonoHogar)
        Me.tabPage1.Controls.Add(Me.txtTelefonoPersonal)
        Me.tabPage1.Controls.Add(Me.txtCedula)
        Me.tabPage1.Controls.Add(Me.cbxMunicipio)
        Me.tabPage1.Controls.Add(Me.CbxProvincia)
        Me.tabPage1.Controls.Add(Me.CbxGenero)
        Me.tabPage1.Controls.Add(Me.cbxNacionalidad)
        Me.tabPage1.Controls.Add(Me.tel_hogar_label)
        Me.tabPage1.Controls.Add(Me.municipio_label)
        Me.tabPage1.Controls.Add(Me.tel_personal_label)
        Me.tabPage1.Controls.Add(Me.direccion_label)
        Me.tabPage1.Controls.Add(Me.provincia_label)
        Me.tabPage1.Controls.Add(Me.txtDireccion)
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.txtEdad)
        Me.tabPage1.Controls.Add(Me.Nacionalidad_label)
        Me.tabPage1.Controls.Add(Me.nacimiento_label)
        Me.tabPage1.Controls.Add(Me.cedula_label)
        Me.tabPage1.Controls.Add(Me.genero_label)
        Me.tabPage1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.tabPage1.Location = New System.Drawing.Point(4, 25)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(724, 365)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Datos Generales"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'txtFechaNacimiento
        '
        Me.txtFechaNacimiento.CustomFormat = ""
        Me.txtFechaNacimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaNacimiento.Location = New System.Drawing.Point(159, 92)
        Me.txtFechaNacimiento.Name = "txtFechaNacimiento"
        Me.txtFechaNacimiento.Size = New System.Drawing.Size(96, 23)
        Me.txtFechaNacimiento.TabIndex = 5
        '
        'btnEliminarFoto
        '
        Me.btnEliminarFoto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEliminarFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnEliminarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarFoto.Location = New System.Drawing.Point(691, 331)
        Me.btnEliminarFoto.Name = "btnEliminarFoto"
        Me.btnEliminarFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarFoto.TabIndex = 15
        Me.btnEliminarFoto.UseVisualStyleBackColor = True
        '
        'txtCorreo
        '
        Me.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCorreo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCorreo.ForeColor = System.Drawing.Color.Blue
        Me.txtCorreo.Location = New System.Drawing.Point(212, 307)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(230, 23)
        Me.txtCorreo.TabIndex = 11
        '
        'btnCargarFoto
        '
        Me.btnCargarFoto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCargarFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnCargarFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarFoto.Location = New System.Drawing.Point(629, 331)
        Me.btnCargarFoto.Name = "btnCargarFoto"
        Me.btnCargarFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarFoto.TabIndex = 13
        Me.btnCargarFoto.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(209, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Correo Electrónico"
        '
        'btnAbrirFoto
        '
        Me.btnAbrirFoto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAbrirFoto.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrirFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirFoto.Location = New System.Drawing.Point(660, 331)
        Me.btnAbrirFoto.Name = "btnAbrirFoto"
        Me.btnAbrirFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirFoto.TabIndex = 14
        Me.btnAbrirFoto.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(1, 6)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(67, 15)
        Me.label2.TabIndex = 105
        Me.label2.Text = "Descripción"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label4.Location = New System.Drawing.Point(104, 287)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(40, 15)
        Me.label4.TabIndex = 104
        Me.label4.Text = "Hogar"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(1, 270)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(59, 15)
        Me.label3.TabIndex = 103
        Me.label3.Text = "Contactos"
        '
        'PicFoto
        '
        Me.PicFoto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PicFoto.BackColor = System.Drawing.Color.White
        Me.PicFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFoto.Image = CType(resources.GetObject("PicFoto.Image"), System.Drawing.Image)
        Me.PicFoto.Location = New System.Drawing.Point(448, 1)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(276, 330)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicFoto.TabIndex = 106
        Me.PicFoto.TabStop = False
        '
        'txtTelefonoHogar
        '
        Me.txtTelefonoHogar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefonoHogar.Location = New System.Drawing.Point(107, 307)
        Me.txtTelefonoHogar.Name = "txtTelefonoHogar"
        Me.txtTelefonoHogar.Size = New System.Drawing.Size(100, 23)
        Me.txtTelefonoHogar.TabIndex = 10
        Me.txtTelefonoHogar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTelefonoPersonal
        '
        Me.txtTelefonoPersonal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTelefonoPersonal.Location = New System.Drawing.Point(1, 307)
        Me.txtTelefonoPersonal.Name = "txtTelefonoPersonal"
        Me.txtTelefonoPersonal.Size = New System.Drawing.Size(100, 23)
        Me.txtTelefonoPersonal.TabIndex = 9
        Me.txtTelefonoPersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCedula
        '
        Me.txtCedula.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCedula.Location = New System.Drawing.Point(261, 43)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(181, 23)
        Me.txtCedula.TabIndex = 3
        Me.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxMunicipio
        '
        Me.cbxMunicipio.DropDownHeight = 100
        Me.cbxMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMunicipio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMunicipio.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxMunicipio.FormattingEnabled = True
        Me.cbxMunicipio.IntegralHeight = False
        Me.cbxMunicipio.Location = New System.Drawing.Point(212, 168)
        Me.cbxMunicipio.Name = "cbxMunicipio"
        Me.cbxMunicipio.Size = New System.Drawing.Size(230, 23)
        Me.cbxMunicipio.TabIndex = 7
        '
        'CbxProvincia
        '
        Me.CbxProvincia.DropDownHeight = 105
        Me.CbxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxProvincia.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxProvincia.FormattingEnabled = True
        Me.CbxProvincia.IntegralHeight = False
        Me.CbxProvincia.Location = New System.Drawing.Point(1, 168)
        Me.CbxProvincia.Name = "CbxProvincia"
        Me.CbxProvincia.Size = New System.Drawing.Size(205, 23)
        Me.CbxProvincia.TabIndex = 6
        '
        'CbxGenero
        '
        Me.CbxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxGenero.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxGenero.FormattingEnabled = True
        Me.CbxGenero.Location = New System.Drawing.Point(4, 92)
        Me.CbxGenero.Name = "CbxGenero"
        Me.CbxGenero.Size = New System.Drawing.Size(149, 23)
        Me.CbxGenero.TabIndex = 4
        '
        'cbxNacionalidad
        '
        Me.cbxNacionalidad.DropDownHeight = 100
        Me.cbxNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNacionalidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxNacionalidad.FormattingEnabled = True
        Me.cbxNacionalidad.IntegralHeight = False
        Me.cbxNacionalidad.Location = New System.Drawing.Point(4, 43)
        Me.cbxNacionalidad.Name = "cbxNacionalidad"
        Me.cbxNacionalidad.Size = New System.Drawing.Size(251, 23)
        Me.cbxNacionalidad.TabIndex = 2
        '
        'tel_hogar_label
        '
        Me.tel_hogar_label.AutoSize = True
        Me.tel_hogar_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tel_hogar_label.Location = New System.Drawing.Point(261, 74)
        Me.tel_hogar_label.Name = "tel_hogar_label"
        Me.tel_hogar_label.Size = New System.Drawing.Size(33, 15)
        Me.tel_hogar_label.TabIndex = 100
        Me.tel_hogar_label.Text = "Edad"
        '
        'municipio_label
        '
        Me.municipio_label.AutoSize = True
        Me.municipio_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.municipio_label.Location = New System.Drawing.Point(209, 149)
        Me.municipio_label.Name = "municipio_label"
        Me.municipio_label.Size = New System.Drawing.Size(61, 15)
        Me.municipio_label.TabIndex = 99
        Me.municipio_label.Text = "Municipio"
        '
        'tel_personal_label
        '
        Me.tel_personal_label.AutoSize = True
        Me.tel_personal_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tel_personal_label.Location = New System.Drawing.Point(1, 287)
        Me.tel_personal_label.Name = "tel_personal_label"
        Me.tel_personal_label.Size = New System.Drawing.Size(52, 15)
        Me.tel_personal_label.TabIndex = 98
        Me.tel_personal_label.Text = "Personal"
        '
        'direccion_label
        '
        Me.direccion_label.AutoSize = True
        Me.direccion_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.direccion_label.Location = New System.Drawing.Point(1, 197)
        Me.direccion_label.Name = "direccion_label"
        Me.direccion_label.Size = New System.Drawing.Size(57, 15)
        Me.direccion_label.TabIndex = 97
        Me.direccion_label.Text = "Dirección"
        '
        'provincia_label
        '
        Me.provincia_label.AutoSize = True
        Me.provincia_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.provincia_label.Location = New System.Drawing.Point(1, 149)
        Me.provincia_label.Name = "provincia_label"
        Me.provincia_label.Size = New System.Drawing.Size(56, 15)
        Me.provincia_label.TabIndex = 96
        Me.provincia_label.Text = "Provincia"
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(1, 216)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccion.Size = New System.Drawing.Size(441, 42)
        Me.txtDireccion.TabIndex = 8
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(1, 131)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(55, 15)
        Me.label9.TabIndex = 95
        Me.label9.Text = "Domicilio"
        '
        'txtEdad
        '
        Me.txtEdad.Enabled = False
        Me.txtEdad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEdad.Location = New System.Drawing.Point(261, 93)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.ReadOnly = True
        Me.txtEdad.Size = New System.Drawing.Size(181, 23)
        Me.txtEdad.TabIndex = 102
        Me.txtEdad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Nacionalidad_label
        '
        Me.Nacionalidad_label.AutoSize = True
        Me.Nacionalidad_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Nacionalidad_label.Location = New System.Drawing.Point(1, 24)
        Me.Nacionalidad_label.Name = "Nacionalidad_label"
        Me.Nacionalidad_label.Size = New System.Drawing.Size(77, 15)
        Me.Nacionalidad_label.TabIndex = 94
        Me.Nacionalidad_label.Text = "Nacionalidad"
        '
        'nacimiento_label
        '
        Me.nacimiento_label.AutoSize = True
        Me.nacimiento_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nacimiento_label.Location = New System.Drawing.Point(156, 73)
        Me.nacimiento_label.Name = "nacimiento_label"
        Me.nacimiento_label.Size = New System.Drawing.Size(69, 15)
        Me.nacimiento_label.TabIndex = 91
        Me.nacimiento_label.Text = "Nacimiento"
        '
        'cedula_label
        '
        Me.cedula_label.AutoSize = True
        Me.cedula_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cedula_label.Location = New System.Drawing.Point(258, 24)
        Me.cedula_label.Name = "cedula_label"
        Me.cedula_label.Size = New System.Drawing.Size(79, 15)
        Me.cedula_label.TabIndex = 89
        Me.cedula_label.Text = "Identificación"
        '
        'genero_label
        '
        Me.genero_label.AutoSize = True
        Me.genero_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.genero_label.Location = New System.Drawing.Point(1, 73)
        Me.genero_label.Name = "genero_label"
        Me.genero_label.Size = New System.Drawing.Size(45, 15)
        Me.genero_label.TabIndex = 87
        Me.genero_label.Text = "Género"
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.GroupBox5)
        Me.tabPage2.Controls.Add(Me.Label35)
        Me.tabPage2.Controls.Add(Me.txtCotizable)
        Me.tabPage2.Controls.Add(Me.cbxAlmacen)
        Me.tabPage2.Controls.Add(Me.Label33)
        Me.tabPage2.Controls.Add(Me.btnSucursal)
        Me.tabPage2.Controls.Add(Me.txtSucursal)
        Me.tabPage2.Controls.Add(Me.txtIDSucursal)
        Me.tabPage2.Controls.Add(Me.Label32)
        Me.tabPage2.Controls.Add(Me.Label31)
        Me.tabPage2.Controls.Add(Me.txtPuesto)
        Me.tabPage2.Controls.Add(Me.btnBuscarNomina)
        Me.tabPage2.Controls.Add(Me.Label29)
        Me.tabPage2.Controls.Add(Me.btnBuscarAfp)
        Me.tabPage2.Controls.Add(Me.txtCarnet)
        Me.tabPage2.Controls.Add(Me.txtAfp)
        Me.tabPage2.Controls.Add(Me.txtIDAfp)
        Me.tabPage2.Controls.Add(Me.Label28)
        Me.tabPage2.Controls.Add(Me.btn_buscarArs)
        Me.tabPage2.Controls.Add(Me.txtArs)
        Me.tabPage2.Controls.Add(Me.txtIDArs)
        Me.tabPage2.Controls.Add(Me.Label26)
        Me.tabPage2.Controls.Add(Me.dtpFechaIngreso)
        Me.tabPage2.Controls.Add(Me.label5)
        Me.tabPage2.Controls.Add(Me.btnBuscarTanda)
        Me.tabPage2.Controls.Add(Me.label12)
        Me.tabPage2.Controls.Add(Me.txtTanda)
        Me.tabPage2.Controls.Add(Me.txtTiempoLaboral)
        Me.tabPage2.Controls.Add(Me.txtIDTanda)
        Me.tabPage2.Controls.Add(Me.Label22)
        Me.tabPage2.Controls.Add(Me.txtTipoNomina)
        Me.tabPage2.Controls.Add(Me.txtIDNomina)
        Me.tabPage2.Controls.Add(Me.Label20)
        Me.tabPage2.Controls.Add(Me.Label11)
        Me.tabPage2.Controls.Add(Me.txtSalarioDiario)
        Me.tabPage2.Controls.Add(Me.btnBuscarCargo)
        Me.tabPage2.Controls.Add(Me.txtDepartamento)
        Me.tabPage2.Controls.Add(Me.txtIDDepartamento)
        Me.tabPage2.Controls.Add(Me.CbxPeriodoPago)
        Me.tabPage2.Controls.Add(Me.Label8)
        Me.tabPage2.Controls.Add(Me.label6)
        Me.tabPage2.Controls.Add(Me.label7)
        Me.tabPage2.Controls.Add(Me.txtSalario)
        Me.tabPage2.Location = New System.Drawing.Point(4, 25)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(724, 365)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Contrato"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkCobrador)
        Me.GroupBox5.Controls.Add(Me.chkVendedor)
        Me.GroupBox5.Controls.Add(Me.chkHabNomina)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 272)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(443, 87)
        Me.GroupBox5.TabIndex = 274
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Roles del usuario"
        '
        'chkCobrador
        '
        Me.chkCobrador.AutoSize = True
        Me.chkCobrador.Location = New System.Drawing.Point(6, 49)
        Me.chkCobrador.Name = "chkCobrador"
        Me.chkCobrador.Size = New System.Drawing.Size(436, 17)
        Me.chkCobrador.TabIndex = 29
        Me.chkCobrador.Text = "El empleado puede ser reconocido como encargado de cuentas por cobrar (Cobrador)"
        Me.chkCobrador.UseVisualStyleBackColor = True
        '
        'chkVendedor
        '
        Me.chkVendedor.AutoSize = True
        Me.chkVendedor.Location = New System.Drawing.Point(6, 26)
        Me.chkVendedor.Name = "chkVendedor"
        Me.chkVendedor.Size = New System.Drawing.Size(307, 17)
        Me.chkVendedor.TabIndex = 28
        Me.chkVendedor.Text = "El empleado puede realizar y/o generar ventas (Vendedor)"
        Me.chkVendedor.UseVisualStyleBackColor = True
        '
        'chkHabNomina
        '
        Me.chkHabNomina.AutoSize = True
        Me.chkHabNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkHabNomina.Location = New System.Drawing.Point(312, 0)
        Me.chkHabNomina.Name = "chkHabNomina"
        Me.chkHabNomina.Size = New System.Drawing.Size(131, 19)
        Me.chkHabNomina.TabIndex = 27
        Me.chkHabNomina.Text = "Habilitar en nómina"
        Me.chkHabNomina.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label35.Location = New System.Drawing.Point(455, 181)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(56, 15)
        Me.Label35.TabIndex = 273
        Me.Label35.Text = "Cotizable"
        '
        'txtCotizable
        '
        Me.txtCotizable.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCotizable.Location = New System.Drawing.Point(455, 199)
        Me.txtCotizable.Name = "txtCotizable"
        Me.txtCotizable.Size = New System.Drawing.Size(261, 23)
        Me.txtCotizable.TabIndex = 22
        Me.txtCotizable.Text = "0"
        Me.txtCotizable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxAlmacen
        '
        Me.cbxAlmacen.DropDownHeight = 100
        Me.cbxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAlmacen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxAlmacen.FormattingEnabled = True
        Me.cbxAlmacen.IntegralHeight = False
        Me.cbxAlmacen.Location = New System.Drawing.Point(455, 23)
        Me.cbxAlmacen.Name = "cbxAlmacen"
        Me.cbxAlmacen.Size = New System.Drawing.Size(261, 23)
        Me.cbxAlmacen.TabIndex = 13
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label33.Location = New System.Drawing.Point(455, 5)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(54, 15)
        Me.Label33.TabIndex = 269
        Me.Label33.Text = "Almacén"
        '
        'btnSucursal
        '
        Me.btnSucursal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSucursal.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSucursal.Image = CType(resources.GetObject("btnSucursal.Image"), System.Drawing.Image)
        Me.btnSucursal.Location = New System.Drawing.Point(104, 23)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(23, 23)
        Me.btnSucursal.TabIndex = 267
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.Enabled = False
        Me.txtSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSucursal.Location = New System.Drawing.Point(125, 23)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(324, 23)
        Me.txtSucursal.TabIndex = 265
        '
        'txtIDSucursal
        '
        Me.txtIDSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDSucursal.Location = New System.Drawing.Point(2, 23)
        Me.txtIDSucursal.Name = "txtIDSucursal"
        Me.txtIDSucursal.Size = New System.Drawing.Size(103, 23)
        Me.txtIDSucursal.TabIndex = 12
        Me.txtIDSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label32.Location = New System.Drawing.Point(-1, 5)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(51, 15)
        Me.Label32.TabIndex = 263
        Me.Label32.Text = "Sucursal"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label31.Location = New System.Drawing.Point(455, 93)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(43, 15)
        Me.Label31.TabIndex = 262
        Me.Label31.Text = "Puesto"
        '
        'txtPuesto
        '
        Me.txtPuesto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPuesto.Location = New System.Drawing.Point(455, 111)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(261, 23)
        Me.txtPuesto.TabIndex = 16
        '
        'btnBuscarNomina
        '
        Me.btnBuscarNomina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarNomina.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarNomina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarNomina.Image = CType(resources.GetObject("btnBuscarNomina.Image"), System.Drawing.Image)
        Me.btnBuscarNomina.Location = New System.Drawing.Point(104, 67)
        Me.btnBuscarNomina.Name = "btnBuscarNomina"
        Me.btnBuscarNomina.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarNomina.TabIndex = 259
        Me.btnBuscarNomina.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label29.Location = New System.Drawing.Point(455, 226)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 15)
        Me.Label29.TabIndex = 258
        Me.Label29.Text = "ID - Carnet"
        '
        'btnBuscarAfp
        '
        Me.btnBuscarAfp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarAfp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarAfp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarAfp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarAfp.Image = CType(resources.GetObject("btnBuscarAfp.Image"), System.Drawing.Image)
        Me.btnBuscarAfp.Location = New System.Drawing.Point(103, 243)
        Me.btnBuscarAfp.Name = "btnBuscarAfp"
        Me.btnBuscarAfp.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarAfp.TabIndex = 22
        Me.btnBuscarAfp.UseVisualStyleBackColor = True
        '
        'txtCarnet
        '
        Me.txtCarnet.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarnet.Location = New System.Drawing.Point(455, 243)
        Me.txtCarnet.Name = "txtCarnet"
        Me.txtCarnet.Size = New System.Drawing.Size(261, 23)
        Me.txtCarnet.TabIndex = 20
        Me.txtCarnet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAfp
        '
        Me.txtAfp.Enabled = False
        Me.txtAfp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAfp.Location = New System.Drawing.Point(125, 243)
        Me.txtAfp.Name = "txtAfp"
        Me.txtAfp.ReadOnly = True
        Me.txtAfp.Size = New System.Drawing.Size(324, 23)
        Me.txtAfp.TabIndex = 255
        '
        'txtIDAfp
        '
        Me.txtIDAfp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDAfp.Location = New System.Drawing.Point(3, 243)
        Me.txtIDAfp.Name = "txtIDAfp"
        Me.txtIDAfp.Size = New System.Drawing.Size(103, 23)
        Me.txtIDAfp.TabIndex = 19
        Me.txtIDAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(1, 225)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(28, 15)
        Me.Label28.TabIndex = 253
        Me.Label28.Text = "AFP"
        '
        'btn_buscarArs
        '
        Me.btn_buscarArs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_buscarArs.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_buscarArs.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_buscarArs.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btn_buscarArs.Image = CType(resources.GetObject("btn_buscarArs.Image"), System.Drawing.Image)
        Me.btn_buscarArs.Location = New System.Drawing.Point(105, 199)
        Me.btn_buscarArs.Name = "btn_buscarArs"
        Me.btn_buscarArs.Size = New System.Drawing.Size(23, 23)
        Me.btn_buscarArs.TabIndex = 21
        Me.btn_buscarArs.UseVisualStyleBackColor = True
        '
        'txtArs
        '
        Me.txtArs.Enabled = False
        Me.txtArs.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtArs.Location = New System.Drawing.Point(125, 199)
        Me.txtArs.Name = "txtArs"
        Me.txtArs.ReadOnly = True
        Me.txtArs.Size = New System.Drawing.Size(324, 23)
        Me.txtArs.TabIndex = 250
        '
        'txtIDArs
        '
        Me.txtIDArs.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDArs.Location = New System.Drawing.Point(3, 199)
        Me.txtIDArs.Name = "txtIDArs"
        Me.txtIDArs.Size = New System.Drawing.Size(103, 23)
        Me.txtIDArs.TabIndex = 18
        Me.txtIDArs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(1, 181)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 15)
        Me.Label26.TabIndex = 248
        Me.Label26.Text = "ARS"
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.CustomFormat = ""
        Me.dtpFechaIngreso.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(456, 307)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(101, 23)
        Me.dtpFechaIngreso.TabIndex = 24
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label5.Location = New System.Drawing.Point(454, 289)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(96, 15)
        Me.label5.TabIndex = 102
        Me.label5.Text = "Fecha de Ingreso"
        '
        'btnBuscarTanda
        '
        Me.btnBuscarTanda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarTanda.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarTanda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarTanda.Image = CType(resources.GetObject("btnBuscarTanda.Image"), System.Drawing.Image)
        Me.btnBuscarTanda.Location = New System.Drawing.Point(103, 155)
        Me.btnBuscarTanda.Name = "btnBuscarTanda"
        Me.btnBuscarTanda.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarTanda.TabIndex = 20
        Me.btnBuscarTanda.UseVisualStyleBackColor = True
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label12.Location = New System.Drawing.Point(561, 289)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(89, 15)
        Me.label12.TabIndex = 107
        Me.label12.Text = "Tiempo Laboral"
        '
        'txtTanda
        '
        Me.txtTanda.Enabled = False
        Me.txtTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTanda.Location = New System.Drawing.Point(125, 155)
        Me.txtTanda.Name = "txtTanda"
        Me.txtTanda.ReadOnly = True
        Me.txtTanda.Size = New System.Drawing.Size(324, 23)
        Me.txtTanda.TabIndex = 244
        '
        'txtTiempoLaboral
        '
        Me.txtTiempoLaboral.Enabled = False
        Me.txtTiempoLaboral.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTiempoLaboral.Location = New System.Drawing.Point(564, 307)
        Me.txtTiempoLaboral.Name = "txtTiempoLaboral"
        Me.txtTiempoLaboral.ReadOnly = True
        Me.txtTiempoLaboral.Size = New System.Drawing.Size(153, 23)
        Me.txtTiempoLaboral.TabIndex = 227
        Me.txtTiempoLaboral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIDTanda
        '
        Me.txtIDTanda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDTanda.Location = New System.Drawing.Point(3, 155)
        Me.txtIDTanda.Name = "txtIDTanda"
        Me.txtIDTanda.Size = New System.Drawing.Size(103, 23)
        Me.txtIDTanda.TabIndex = 17
        Me.txtIDTanda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(0, 137)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 15)
        Me.Label22.TabIndex = 242
        Me.Label22.Text = "Tanda"
        '
        'txtTipoNomina
        '
        Me.txtTipoNomina.Enabled = False
        Me.txtTipoNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTipoNomina.Location = New System.Drawing.Point(125, 67)
        Me.txtTipoNomina.Name = "txtTipoNomina"
        Me.txtTipoNomina.ReadOnly = True
        Me.txtTipoNomina.Size = New System.Drawing.Size(324, 23)
        Me.txtTipoNomina.TabIndex = 239
        '
        'txtIDNomina
        '
        Me.txtIDNomina.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDNomina.Location = New System.Drawing.Point(2, 67)
        Me.txtIDNomina.Name = "txtIDNomina"
        Me.txtIDNomina.Size = New System.Drawing.Size(103, 23)
        Me.txtIDNomina.TabIndex = 14
        Me.txtIDNomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(-1, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 15)
        Me.Label20.TabIndex = 237
        Me.Label20.Text = "Nómina"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(593, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 15)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "Salario Diario"
        '
        'txtSalarioDiario
        '
        Me.txtSalarioDiario.Enabled = False
        Me.txtSalarioDiario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSalarioDiario.Location = New System.Drawing.Point(596, 155)
        Me.txtSalarioDiario.Name = "txtSalarioDiario"
        Me.txtSalarioDiario.ReadOnly = True
        Me.txtSalarioDiario.Size = New System.Drawing.Size(121, 23)
        Me.txtSalarioDiario.TabIndex = 235
        Me.txtSalarioDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarCargo
        '
        Me.btnBuscarCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCargo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCargo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnBuscarCargo.Image = CType(resources.GetObject("btnBuscarCargo.Image"), System.Drawing.Image)
        Me.btnBuscarCargo.Location = New System.Drawing.Point(104, 111)
        Me.btnBuscarCargo.Name = "btnBuscarCargo"
        Me.btnBuscarCargo.Size = New System.Drawing.Size(23, 23)
        Me.btnBuscarCargo.TabIndex = 19
        Me.btnBuscarCargo.UseVisualStyleBackColor = True
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartamento.Location = New System.Drawing.Point(125, 111)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(324, 23)
        Me.txtDepartamento.TabIndex = 232
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDDepartamento.Location = New System.Drawing.Point(2, 111)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.Size = New System.Drawing.Size(103, 23)
        Me.txtIDDepartamento.TabIndex = 15
        Me.txtIDDepartamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CbxPeriodoPago
        '
        Me.CbxPeriodoPago.DropDownHeight = 100
        Me.CbxPeriodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPeriodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxPeriodoPago.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxPeriodoPago.FormattingEnabled = True
        Me.CbxPeriodoPago.IntegralHeight = False
        Me.CbxPeriodoPago.Location = New System.Drawing.Point(455, 67)
        Me.CbxPeriodoPago.Name = "CbxPeriodoPago"
        Me.CbxPeriodoPago.Size = New System.Drawing.Size(261, 23)
        Me.CbxPeriodoPago.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(455, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 230
        Me.Label8.Text = "Período Pago"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label6.Location = New System.Drawing.Point(2, 93)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(83, 15)
        Me.label6.TabIndex = 101
        Me.label6.Text = "Departamento"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label7.Location = New System.Drawing.Point(455, 137)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(42, 15)
        Me.label7.TabIndex = 99
        Me.label7.Text = "Salario"
        '
        'txtSalario
        '
        Me.txtSalario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSalario.Location = New System.Drawing.Point(455, 155)
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.Size = New System.Drawing.Size(135, 23)
        Me.txtSalario.TabIndex = 21
        Me.txtSalario.Text = "0"
        Me.txtSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(724, 365)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Deducciones"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSeguroComplementario)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCuotaCuenta)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.chkISR)
        Me.GroupBox2.Controls.Add(Me.txtBalance)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.chkTesoreria)
        Me.GroupBox2.Controls.Add(Me.txtConsFlota)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtCuotaPrestamo)
        Me.GroupBox2.Controls.Add(Me.txtCuentaBancaria)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(283, 354)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'txtSeguroComplementario
        '
        Me.txtSeguroComplementario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSeguroComplementario.Location = New System.Drawing.Point(132, 206)
        Me.txtSeguroComplementario.Name = "txtSeguroComplementario"
        Me.txtSeguroComplementario.Size = New System.Drawing.Size(143, 23)
        Me.txtSeguroComplementario.TabIndex = 257
        Me.txtSeguroComplementario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label42.Location = New System.Drawing.Point(7, 200)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(103, 36)
        Me.Label42.TabIndex = 258
        Me.Label42.Text = "Seguro complementario"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(7, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 15)
        Me.Label10.TabIndex = 256
        Me.Label10.Text = "Cuota de CXC"
        '
        'txtCuotaCuenta
        '
        Me.txtCuotaCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuotaCuenta.Location = New System.Drawing.Point(132, 148)
        Me.txtCuotaCuenta.Name = "txtCuotaCuenta"
        Me.txtCuotaCuenta.Size = New System.Drawing.Size(143, 23)
        Me.txtCuotaCuenta.TabIndex = 31
        Me.txtCuotaCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(7, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 15)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "Balance de préstamos"
        '
        'chkISR
        '
        Me.chkISR.AutoSize = True
        Me.chkISR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkISR.Location = New System.Drawing.Point(6, 329)
        Me.chkISR.Name = "chkISR"
        Me.chkISR.Size = New System.Drawing.Size(189, 19)
        Me.chkISR.TabIndex = 34
        Me.chkISR.Text = "Cobrar Impuesto sobre la renta"
        Me.chkISR.UseVisualStyleBackColor = True
        '
        'txtBalance
        '
        Me.txtBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBalance.Enabled = False
        Me.txtBalance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBalance.Location = New System.Drawing.Point(132, 90)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(143, 23)
        Me.txtBalance.TabIndex = 270
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(7, 122)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 15)
        Me.Label24.TabIndex = 250
        Me.Label24.Text = "Cuota de Préstamo"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(9, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(93, 15)
        Me.Label23.TabIndex = 248
        Me.Label23.Text = "Cuenta Bancaria"
        '
        'chkTesoreria
        '
        Me.chkTesoreria.AutoSize = True
        Me.chkTesoreria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkTesoreria.Location = New System.Drawing.Point(6, 304)
        Me.chkTesoreria.Name = "chkTesoreria"
        Me.chkTesoreria.Size = New System.Drawing.Size(217, 19)
        Me.chkTesoreria.TabIndex = 33
        Me.chkTesoreria.Text = "Cobrar Tesorería de Seguridad Social"
        Me.chkTesoreria.UseVisualStyleBackColor = True
        '
        'txtConsFlota
        '
        Me.txtConsFlota.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConsFlota.Location = New System.Drawing.Point(132, 177)
        Me.txtConsFlota.Name = "txtConsFlota"
        Me.txtConsFlota.Size = New System.Drawing.Size(143, 23)
        Me.txtConsFlota.TabIndex = 32
        Me.txtConsFlota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(7, 180)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 15)
        Me.Label14.TabIndex = 252
        Me.Label14.Text = "Consumo Flota"
        '
        'txtCuotaPrestamo
        '
        Me.txtCuotaPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuotaPrestamo.Location = New System.Drawing.Point(132, 119)
        Me.txtCuotaPrestamo.Name = "txtCuotaPrestamo"
        Me.txtCuotaPrestamo.Size = New System.Drawing.Size(143, 23)
        Me.txtCuotaPrestamo.TabIndex = 30
        Me.txtCuotaPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(8, 38)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(267, 23)
        Me.txtCuentaBancaria.TabIndex = 25
        Me.txtCuentaBancaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgvDeducciones)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(292, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 354)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Deducciones e ingresos variables"
        '
        'DgvDeducciones
        '
        Me.DgvDeducciones.AllowUserToAddRows = False
        Me.DgvDeducciones.AllowUserToDeleteRows = False
        Me.DgvDeducciones.AllowUserToResizeColumns = False
        Me.DgvDeducciones.AllowUserToResizeRows = False
        Me.DgvDeducciones.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvDeducciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDeducciones.Location = New System.Drawing.Point(8, 18)
        Me.DgvDeducciones.Name = "DgvDeducciones"
        Me.DgvDeducciones.RowHeadersWidth = 10
        Me.DgvDeducciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvDeducciones.Size = New System.Drawing.Size(412, 330)
        Me.DgvDeducciones.TabIndex = 36
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.TabControl1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(724, 365)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Derechos"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabPage10)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(718, 359)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Label45)
        Me.TabPage7.Controls.Add(Me.GroupBox4)
        Me.TabPage7.Controls.Add(Me.DgvVacaciones)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(710, 330)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Vacaciones"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.SystemColors.Info
        Me.Label45.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label45.Location = New System.Drawing.Point(3, 308)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(704, 18)
        Me.Label45.TabIndex = 276
        Me.Label45.Text = "El empleado no posee vacaciones programadas en el año vigente..."
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.btnProgramarVacaciones)
        Me.GroupBox4.Controls.Add(Me.Label57)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.txtIDVacaciones)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.txtTotalVacaciones)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.txtDiasVacaciones)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Controls.Add(Me.dtpVacacionInicia)
        Me.GroupBox4.Controls.Add(Me.dtpVacacionTermina)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(4, -6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(701, 69)
        Me.GroupBox4.TabIndex = 275
        Me.GroupBox4.TabStop = False
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label59.Location = New System.Drawing.Point(510, 9)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(1, 55)
        Me.Label59.TabIndex = 283
        '
        'btnProgramarVacaciones
        '
        Me.btnProgramarVacaciones.Location = New System.Drawing.Point(518, 21)
        Me.btnProgramarVacaciones.Name = "btnProgramarVacaciones"
        Me.btnProgramarVacaciones.Size = New System.Drawing.Size(177, 34)
        Me.btnProgramarVacaciones.TabIndex = 278
        Me.btnProgramarVacaciones.Text = "Programar vacaciones"
        Me.btnProgramarVacaciones.UseVisualStyleBackColor = True
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label57.Location = New System.Drawing.Point(569, 16)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(18, 13)
        Me.Label57.TabIndex = 281
        Me.Label57.Text = "ID"
        Me.Label57.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(409, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 282
        Me.Button1.Text = "Calcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtIDVacaciones
        '
        Me.txtIDVacaciones.BackColor = System.Drawing.SystemColors.Info
        Me.txtIDVacaciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDVacaciones.Location = New System.Drawing.Point(593, 13)
        Me.txtIDVacaciones.Name = "txtIDVacaciones"
        Me.txtIDVacaciones.ReadOnly = True
        Me.txtIDVacaciones.Size = New System.Drawing.Size(102, 20)
        Me.txtIDVacaciones.TabIndex = 280
        Me.txtIDVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIDVacaciones.Visible = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label44.Location = New System.Drawing.Point(155, 43)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(87, 13)
        Me.Label44.TabIndex = 281
        Me.Label44.Text = "Total vacaciones"
        '
        'txtTotalVacaciones
        '
        Me.txtTotalVacaciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTotalVacaciones.Location = New System.Drawing.Point(271, 41)
        Me.txtTotalVacaciones.Name = "txtTotalVacaciones"
        Me.txtTotalVacaciones.Size = New System.Drawing.Size(132, 20)
        Me.txtTotalVacaciones.TabIndex = 280
        Me.txtTotalVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label43.Location = New System.Drawing.Point(155, 17)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(111, 13)
        Me.Label43.TabIndex = 279
        Me.Label43.Text = "Cant. de días a pagar"
        '
        'txtDiasVacaciones
        '
        Me.txtDiasVacaciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDiasVacaciones.Location = New System.Drawing.Point(271, 15)
        Me.txtDiasVacaciones.Name = "txtDiasVacaciones"
        Me.txtDiasVacaciones.ReadOnly = True
        Me.txtDiasVacaciones.Size = New System.Drawing.Size(68, 20)
        Me.txtDiasVacaciones.TabIndex = 278
        Me.txtDiasVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label37.Location = New System.Drawing.Point(4, 43)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(45, 13)
        Me.Label37.TabIndex = 277
        Me.Label37.Text = "Entrada"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label36.Location = New System.Drawing.Point(4, 19)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(35, 13)
        Me.Label36.TabIndex = 276
        Me.Label36.Text = "Salida"
        '
        'dtpVacacionInicia
        '
        Me.dtpVacacionInicia.CustomFormat = ""
        Me.dtpVacacionInicia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpVacacionInicia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVacacionInicia.Location = New System.Drawing.Point(52, 14)
        Me.dtpVacacionInicia.Name = "dtpVacacionInicia"
        Me.dtpVacacionInicia.Size = New System.Drawing.Size(97, 20)
        Me.dtpVacacionInicia.TabIndex = 275
        '
        'dtpVacacionTermina
        '
        Me.dtpVacacionTermina.CustomFormat = ""
        Me.dtpVacacionTermina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpVacacionTermina.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVacacionTermina.Location = New System.Drawing.Point(52, 40)
        Me.dtpVacacionTermina.Name = "dtpVacacionTermina"
        Me.dtpVacacionTermina.Size = New System.Drawing.Size(97, 20)
        Me.dtpVacacionTermina.TabIndex = 274
        '
        'DgvVacaciones
        '
        Me.DgvVacaciones.AllowUserToAddRows = False
        Me.DgvVacaciones.AllowUserToDeleteRows = False
        Me.DgvVacaciones.AllowUserToResizeColumns = False
        Me.DgvVacaciones.AllowUserToResizeRows = False
        Me.DgvVacaciones.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DgvVacaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvVacaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvVacaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvVacaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Codigo, Me.FechaInicio, Me.FechaSalida, Me.DiasVacaciones, Me.Concepto, Me.MontoPagoVacaciones})
        Me.DgvVacaciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DgvVacaciones.Location = New System.Drawing.Point(3, 67)
        Me.DgvVacaciones.MultiSelect = False
        Me.DgvVacaciones.Name = "DgvVacaciones"
        Me.DgvVacaciones.ReadOnly = True
        Me.DgvVacaciones.RowHeadersWidth = 45
        Me.DgvVacaciones.RowTemplate.Height = 28
        Me.DgvVacaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvVacaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvVacaciones.Size = New System.Drawing.Size(704, 260)
        Me.DgvVacaciones.TabIndex = 277
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 80
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 80
        '
        'FechaInicio
        '
        Me.FechaInicio.HeaderText = "Fecha de salida"
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.ReadOnly = True
        '
        'FechaSalida
        '
        Me.FechaSalida.HeaderText = "Fecha de entrada"
        Me.FechaSalida.Name = "FechaSalida"
        Me.FechaSalida.ReadOnly = True
        '
        'DiasVacaciones
        '
        Me.DiasVacaciones.HeaderText = "Días"
        Me.DiasVacaciones.Name = "DiasVacaciones"
        Me.DiasVacaciones.ReadOnly = True
        Me.DiasVacaciones.Width = 60
        '
        'Concepto
        '
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        Me.Concepto.Width = 200
        '
        'MontoPagoVacaciones
        '
        Me.MontoPagoVacaciones.HeaderText = "Monto"
        Me.MontoPagoVacaciones.Name = "MontoPagoVacaciones"
        Me.MontoPagoVacaciones.ReadOnly = True
        Me.MontoPagoVacaciones.Width = 120
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.White
        Me.TabPage8.Controls.Add(Me.dtpFechaSalida)
        Me.TabPage8.Controls.Add(Me.Label58)
        Me.TabPage8.Controls.Add(Me.Label56)
        Me.TabPage8.Controls.Add(Me.DgvMensualidades)
        Me.TabPage8.Controls.Add(Me.txtTiempoLaborado)
        Me.TabPage8.Controls.Add(Me.txtSumaSalarios)
        Me.TabPage8.Controls.Add(Me.Label48)
        Me.TabPage8.Controls.Add(Me.Label47)
        Me.TabPage8.Controls.Add(Me.Label54)
        Me.TabPage8.Controls.Add(Me.txtSalarioPromedioMensual)
        Me.TabPage8.Controls.Add(Me.TSNavidad)
        Me.TabPage8.Controls.Add(Me.Label46)
        Me.TabPage8.Controls.Add(Me.txtNavidad)
        Me.TabPage8.Controls.Add(Me.txtSalarioPromedioDiario)
        Me.TabPage8.Controls.Add(Me.TSVacaciones)
        Me.TabPage8.Controls.Add(Me.txtPreaviso)
        Me.TabPage8.Controls.Add(Me.txtVacaciones)
        Me.TabPage8.Controls.Add(Me.TsPreaviso)
        Me.TabPage8.Controls.Add(Me.Label53)
        Me.TabPage8.Controls.Add(Me.Label49)
        Me.TabPage8.Controls.Add(Me.Label50)
        Me.TabPage8.Controls.Add(Me.Label52)
        Me.TabPage8.Controls.Add(Me.TSCesantia)
        Me.TabPage8.Controls.Add(Me.Label51)
        Me.TabPage8.Controls.Add(Me.txtCensantiaAntes)
        Me.TabPage8.Controls.Add(Me.txtCesantiaNuevo)
        Me.TabPage8.Controls.Add(Me.SeparatorControl5)
        Me.TabPage8.Controls.Add(Me.SeparatorControl1)
        Me.TabPage8.Controls.Add(Me.Panel1)
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(710, 330)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Derechos adquiridos"
        '
        'dtpFechaSalida
        '
        Me.dtpFechaSalida.CustomFormat = ""
        Me.dtpFechaSalida.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaSalida.Location = New System.Drawing.Point(609, 307)
        Me.dtpFechaSalida.Name = "dtpFechaSalida"
        Me.dtpFechaSalida.Size = New System.Drawing.Size(101, 23)
        Me.dtpFechaSalida.TabIndex = 103
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label58.Location = New System.Drawing.Point(519, 311)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(88, 15)
        Me.Label58.TabIndex = 104
        Me.Label58.Text = "Fecha de Salida"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label56.Location = New System.Drawing.Point(535, 274)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(86, 13)
        Me.Label56.TabIndex = 50
        Me.Label56.Text = "Tiempo laborado"
        '
        'DgvMensualidades
        '
        Me.DgvMensualidades.AllowUserToAddRows = False
        Me.DgvMensualidades.AllowUserToDeleteRows = False
        Me.DgvMensualidades.AllowUserToResizeColumns = False
        Me.DgvMensualidades.AllowUserToResizeRows = False
        Me.DgvMensualidades.BackgroundColor = System.Drawing.Color.White
        Me.DgvMensualidades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvMensualidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMensualidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumeroSalario, Me.Mes, Me.SalarioMensualidad, Me.ComisionesSalarios, Me.TotalesSalario})
        Me.DgvMensualidades.Dock = System.Windows.Forms.DockStyle.Left
        Me.DgvMensualidades.Location = New System.Drawing.Point(3, 3)
        Me.DgvMensualidades.MultiSelect = False
        Me.DgvMensualidades.Name = "DgvMensualidades"
        Me.DgvMensualidades.ReadOnly = True
        Me.DgvMensualidades.RowHeadersVisible = False
        Me.DgvMensualidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvMensualidades.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvMensualidades.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvMensualidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMensualidades.Size = New System.Drawing.Size(361, 324)
        Me.DgvMensualidades.TabIndex = 20
        '
        'NumeroSalario
        '
        Me.NumeroSalario.HeaderText = "No."
        Me.NumeroSalario.Name = "NumeroSalario"
        Me.NumeroSalario.ReadOnly = True
        Me.NumeroSalario.Width = 40
        '
        'Mes
        '
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        Me.Mes.Width = 70
        '
        'SalarioMensualidad
        '
        Me.SalarioMensualidad.HeaderText = "Salario"
        Me.SalarioMensualidad.Name = "SalarioMensualidad"
        Me.SalarioMensualidad.ReadOnly = True
        Me.SalarioMensualidad.Width = 85
        '
        'ComisionesSalarios
        '
        Me.ComisionesSalarios.HeaderText = "Comisiones"
        Me.ComisionesSalarios.Name = "ComisionesSalarios"
        Me.ComisionesSalarios.ReadOnly = True
        Me.ComisionesSalarios.Width = 75
        '
        'TotalesSalario
        '
        Me.TotalesSalario.HeaderText = "Totales"
        Me.TotalesSalario.Name = "TotalesSalario"
        Me.TotalesSalario.ReadOnly = True
        Me.TotalesSalario.Width = 90
        '
        'txtTiempoLaborado
        '
        Me.txtTiempoLaborado.BackColor = System.Drawing.Color.White
        Me.txtTiempoLaborado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTiempoLaborado.Location = New System.Drawing.Point(538, 290)
        Me.txtTiempoLaborado.Name = "txtTiempoLaborado"
        Me.txtTiempoLaborado.ReadOnly = True
        Me.txtTiempoLaborado.Size = New System.Drawing.Size(160, 13)
        Me.txtTiempoLaborado.TabIndex = 49
        Me.txtTiempoLaborado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSumaSalarios
        '
        Me.txtSumaSalarios.BackColor = System.Drawing.Color.White
        Me.txtSumaSalarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSumaSalarios.Location = New System.Drawing.Point(406, 21)
        Me.txtSumaSalarios.Name = "txtSumaSalarios"
        Me.txtSumaSalarios.ReadOnly = True
        Me.txtSumaSalarios.Size = New System.Drawing.Size(118, 13)
        Me.txtSumaSalarios.TabIndex = 21
        Me.txtSumaSalarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label48.Location = New System.Drawing.Point(545, 6)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(128, 13)
        Me.Label48.TabIndex = 25
        Me.Label48.Text = "Salario promedio mensual"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label47.Location = New System.Drawing.Point(406, 6)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(125, 13)
        Me.Label47.TabIndex = 24
        Me.Label47.Text = "Sumatoria de los salarios"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label54.Location = New System.Drawing.Point(375, 202)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(46, 13)
        Me.Label54.TabIndex = 46
        Me.Label54.Text = "Navidad"
        '
        'txtSalarioPromedioMensual
        '
        Me.txtSalarioPromedioMensual.BackColor = System.Drawing.Color.White
        Me.txtSalarioPromedioMensual.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSalarioPromedioMensual.Location = New System.Drawing.Point(545, 21)
        Me.txtSalarioPromedioMensual.Name = "txtSalarioPromedioMensual"
        Me.txtSalarioPromedioMensual.ReadOnly = True
        Me.txtSalarioPromedioMensual.Size = New System.Drawing.Size(118, 13)
        Me.txtSalarioPromedioMensual.TabIndex = 22
        Me.txtSalarioPromedioMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSNavidad
        '
        Me.TSNavidad.EditValue = True
        Me.TSNavidad.Location = New System.Drawing.Point(468, 197)
        Me.TSNavidad.Name = "TSNavidad"
        Me.TSNavidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSNavidad.Properties.OffText = "No"
        Me.TSNavidad.Properties.OnText = "Sí"
        Me.TSNavidad.Size = New System.Drawing.Size(95, 24)
        Me.TSNavidad.TabIndex = 45
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label46.Location = New System.Drawing.Point(370, 274)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(115, 13)
        Me.Label46.TabIndex = 26
        Me.Label46.Text = "Salario promedio diario"
        '
        'txtNavidad
        '
        Me.txtNavidad.BackColor = System.Drawing.Color.White
        Me.txtNavidad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNavidad.Location = New System.Drawing.Point(552, 206)
        Me.txtNavidad.Name = "txtNavidad"
        Me.txtNavidad.ReadOnly = True
        Me.txtNavidad.Size = New System.Drawing.Size(156, 13)
        Me.txtNavidad.TabIndex = 44
        Me.txtNavidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSalarioPromedioDiario
        '
        Me.txtSalarioPromedioDiario.BackColor = System.Drawing.Color.White
        Me.txtSalarioPromedioDiario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSalarioPromedioDiario.Location = New System.Drawing.Point(373, 290)
        Me.txtSalarioPromedioDiario.Name = "txtSalarioPromedioDiario"
        Me.txtSalarioPromedioDiario.ReadOnly = True
        Me.txtSalarioPromedioDiario.Size = New System.Drawing.Size(118, 13)
        Me.txtSalarioPromedioDiario.TabIndex = 23
        Me.txtSalarioPromedioDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSVacaciones
        '
        Me.TSVacaciones.EditValue = True
        Me.TSVacaciones.Location = New System.Drawing.Point(468, 167)
        Me.TSVacaciones.Name = "TSVacaciones"
        Me.TSVacaciones.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSVacaciones.Properties.OffText = "No"
        Me.TSVacaciones.Properties.OnText = "Sí"
        Me.TSVacaciones.Size = New System.Drawing.Size(95, 24)
        Me.TSVacaciones.TabIndex = 42
        '
        'txtPreaviso
        '
        Me.txtPreaviso.BackColor = System.Drawing.Color.White
        Me.txtPreaviso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPreaviso.Enabled = False
        Me.txtPreaviso.Location = New System.Drawing.Point(552, 58)
        Me.txtPreaviso.Name = "txtPreaviso"
        Me.txtPreaviso.ReadOnly = True
        Me.txtPreaviso.Size = New System.Drawing.Size(156, 13)
        Me.txtPreaviso.TabIndex = 32
        Me.txtPreaviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVacaciones
        '
        Me.txtVacaciones.BackColor = System.Drawing.Color.White
        Me.txtVacaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVacaciones.Location = New System.Drawing.Point(552, 173)
        Me.txtVacaciones.Name = "txtVacaciones"
        Me.txtVacaciones.ReadOnly = True
        Me.txtVacaciones.Size = New System.Drawing.Size(156, 13)
        Me.txtVacaciones.TabIndex = 41
        Me.txtVacaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TsPreaviso
        '
        Me.TsPreaviso.Location = New System.Drawing.Point(468, 53)
        Me.TsPreaviso.Name = "TsPreaviso"
        Me.TsPreaviso.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TsPreaviso.Properties.OffText = "No"
        Me.TsPreaviso.Properties.OnText = "Sí"
        Me.TsPreaviso.Size = New System.Drawing.Size(95, 24)
        Me.TsPreaviso.TabIndex = 33
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label53.Location = New System.Drawing.Point(376, 172)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(60, 13)
        Me.Label53.TabIndex = 43
        Me.Label53.Text = "Vacaciones"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label49.Location = New System.Drawing.Point(376, 57)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(48, 13)
        Me.Label49.TabIndex = 34
        Me.Label49.Text = "Preaviso"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label50.Location = New System.Drawing.Point(375, 87)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(49, 13)
        Me.Label50.TabIndex = 40
        Me.Label50.Text = "Cesantía"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label52.Location = New System.Drawing.Point(380, 141)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(154, 13)
        Me.Label52.TabIndex = 38
        Me.Label52.Text = "Art. 80 C.T despues de 1992.:"
        '
        'TSCesantia
        '
        Me.TSCesantia.EditValue = True
        Me.TSCesantia.Location = New System.Drawing.Point(468, 83)
        Me.TSCesantia.Name = "TSCesantia"
        Me.TSCesantia.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.TSCesantia.Properties.OffText = "No"
        Me.TSCesantia.Properties.OnText = "Sí"
        Me.TSCesantia.Size = New System.Drawing.Size(95, 24)
        Me.TSCesantia.TabIndex = 39
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label51.Location = New System.Drawing.Point(393, 115)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(141, 13)
        Me.Label51.TabIndex = 37
        Me.Label51.Text = "Art. 80 C.T antes de 1992.:"
        '
        'txtCensantiaAntes
        '
        Me.txtCensantiaAntes.BackColor = System.Drawing.Color.White
        Me.txtCensantiaAntes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCensantiaAntes.Location = New System.Drawing.Point(552, 115)
        Me.txtCensantiaAntes.Name = "txtCensantiaAntes"
        Me.txtCensantiaAntes.ReadOnly = True
        Me.txtCensantiaAntes.Size = New System.Drawing.Size(156, 13)
        Me.txtCensantiaAntes.TabIndex = 35
        Me.txtCensantiaAntes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCesantiaNuevo
        '
        Me.txtCesantiaNuevo.BackColor = System.Drawing.Color.White
        Me.txtCesantiaNuevo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCesantiaNuevo.Location = New System.Drawing.Point(552, 141)
        Me.txtCesantiaNuevo.Name = "txtCesantiaNuevo"
        Me.txtCesantiaNuevo.ReadOnly = True
        Me.txtCesantiaNuevo.Size = New System.Drawing.Size(156, 13)
        Me.txtCesantiaNuevo.TabIndex = 36
        Me.txtCesantiaNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SeparatorControl5
        '
        Me.SeparatorControl5.Location = New System.Drawing.Point(362, 30)
        Me.SeparatorControl5.Name = "SeparatorControl5"
        Me.SeparatorControl5.Size = New System.Drawing.Size(352, 23)
        Me.SeparatorControl5.TabIndex = 51
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(362, 151)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(348, 23)
        Me.SeparatorControl1.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Panel1.Controls.Add(Me.Label55)
        Me.Panel1.Controls.Add(Me.txtTotalRecibir)
        Me.Panel1.Location = New System.Drawing.Point(362, 233)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(345, 35)
        Me.Panel1.TabIndex = 54
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Label55.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(119, 11)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(91, 13)
        Me.Label55.TabIndex = 48
        Me.Label55.Text = "Total a recibir.:"
        '
        'txtTotalRecibir
        '
        Me.txtTotalRecibir.BackColor = System.Drawing.Color.LightSeaGreen
        Me.txtTotalRecibir.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalRecibir.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRecibir.ForeColor = System.Drawing.Color.White
        Me.txtTotalRecibir.Location = New System.Drawing.Point(222, 10)
        Me.txtTotalRecibir.Name = "txtTotalRecibir"
        Me.txtTotalRecibir.ReadOnly = True
        Me.txtTotalRecibir.Size = New System.Drawing.Size(120, 14)
        Me.txtTotalRecibir.TabIndex = 47
        Me.txtTotalRecibir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.DataGridView1)
        Me.TabPage9.Location = New System.Drawing.Point(4, 25)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(710, 330)
        Me.TabPage9.TabIndex = 2
        Me.TabPage9.Text = "Infracciones"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.IDEmpleado, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.RutaDocumentoInfraccion, Me.Documento})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 45
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(710, 327)
        Me.DataGridView1.TabIndex = 278
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'IDEmpleado
        '
        Me.IDEmpleado.HeaderText = "IDUsuario"
        Me.IDEmpleado.Name = "IDEmpleado"
        Me.IDEmpleado.ReadOnly = True
        Me.IDEmpleado.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Notificado"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn15.Width = 70
        '
        'DataGridViewTextBoxColumn16
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn16.HeaderText = "Violaciones"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 350
        '
        'RutaDocumentoInfraccion
        '
        Me.RutaDocumentoInfraccion.HeaderText = "Ruta"
        Me.RutaDocumentoInfraccion.Name = "RutaDocumentoInfraccion"
        Me.RutaDocumentoInfraccion.ReadOnly = True
        Me.RutaDocumentoInfraccion.Visible = False
        '
        'Documento
        '
        Me.Documento.HeaderText = ""
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 70
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.DataGridView2)
        Me.TabPage10.Location = New System.Drawing.Point(4, 25)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(710, 330)
        Me.TabPage10.TabIndex = 3
        Me.TabPage10.Text = "Licencias"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DiasLicencia, Me.Hasta, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewImageColumn1})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView2.Location = New System.Drawing.Point(0, 3)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 35
        Me.DataGridView2.RowTemplate.Height = 28
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(710, 327)
        Me.DataGridView2.TabIndex = 280
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 60
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "IDUsuario"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Desde"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 80
        '
        'DiasLicencia
        '
        Me.DiasLicencia.HeaderText = "Días"
        Me.DiasLicencia.Name = "DiasLicencia"
        Me.DiasLicencia.ReadOnly = True
        Me.DiasLicencia.Width = 40
        '
        'Hasta
        '
        Me.Hasta.HeaderText = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.ReadOnly = True
        Me.Hasta.Width = 80
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Aprob."
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn19
        '
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn19.HeaderText = "Diagnóstico"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 320
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Ruta"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 80
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 50
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.btnEliminarChat)
        Me.tabPage3.Controls.Add(Me.btnCargarChat)
        Me.tabPage3.Controls.Add(Me.btnAbrirChat)
        Me.tabPage3.Controls.Add(Me.btnEliminarCedula)
        Me.tabPage3.Controls.Add(Me.btnCargarCedula)
        Me.tabPage3.Controls.Add(Me.btnAbrirCedula)
        Me.tabPage3.Controls.Add(Me.cbxEstadoChat)
        Me.tabPage3.Controls.Add(Me.Label25)
        Me.tabPage3.Controls.Add(Me.Label21)
        Me.tabPage3.Controls.Add(Me.PicChat)
        Me.tabPage3.Controls.Add(Me.label13)
        Me.tabPage3.Controls.Add(Me.PicBCedula)
        Me.tabPage3.Location = New System.Drawing.Point(4, 25)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(724, 365)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Imágenes"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'btnEliminarChat
        '
        Me.btnEliminarChat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEliminarChat.BackgroundImage = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnEliminarChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarChat.Location = New System.Drawing.Point(688, 88)
        Me.btnEliminarChat.Name = "btnEliminarChat"
        Me.btnEliminarChat.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarChat.TabIndex = 42
        Me.btnEliminarChat.UseVisualStyleBackColor = True
        '
        'btnCargarChat
        '
        Me.btnCargarChat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCargarChat.BackgroundImage = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnCargarChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarChat.Location = New System.Drawing.Point(688, 24)
        Me.btnCargarChat.Name = "btnCargarChat"
        Me.btnCargarChat.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarChat.TabIndex = 40
        Me.btnCargarChat.UseVisualStyleBackColor = True
        '
        'btnAbrirChat
        '
        Me.btnAbrirChat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAbrirChat.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrirChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirChat.Location = New System.Drawing.Point(688, 56)
        Me.btnAbrirChat.Name = "btnAbrirChat"
        Me.btnAbrirChat.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirChat.TabIndex = 41
        Me.btnAbrirChat.UseVisualStyleBackColor = True
        '
        'btnEliminarCedula
        '
        Me.btnEliminarCedula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEliminarCedula.BackgroundImage = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.btnEliminarCedula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarCedula.Location = New System.Drawing.Point(259, 88)
        Me.btnEliminarCedula.Name = "btnEliminarCedula"
        Me.btnEliminarCedula.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarCedula.TabIndex = 39
        Me.btnEliminarCedula.UseVisualStyleBackColor = True
        '
        'btnCargarCedula
        '
        Me.btnCargarCedula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCargarCedula.BackgroundImage = Global.Libregco.My.Resources.Resources.Image_Capture_x32
        Me.btnCargarCedula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCargarCedula.Location = New System.Drawing.Point(259, 24)
        Me.btnCargarCedula.Name = "btnCargarCedula"
        Me.btnCargarCedula.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarCedula.TabIndex = 37
        Me.btnCargarCedula.UseVisualStyleBackColor = True
        '
        'btnAbrirCedula
        '
        Me.btnAbrirCedula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAbrirCedula.BackgroundImage = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnAbrirCedula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirCedula.Location = New System.Drawing.Point(259, 56)
        Me.btnAbrirCedula.Name = "btnAbrirCedula"
        Me.btnAbrirCedula.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirCedula.TabIndex = 38
        Me.btnAbrirCedula.UseVisualStyleBackColor = True
        '
        'cbxEstadoChat
        '
        Me.cbxEstadoChat.DropDownHeight = 100
        Me.cbxEstadoChat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstadoChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstadoChat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbxEstadoChat.FormattingEnabled = True
        Me.cbxEstadoChat.IntegralHeight = False
        Me.cbxEstadoChat.Location = New System.Drawing.Point(433, 329)
        Me.cbxEstadoChat.Name = "cbxEstadoChat"
        Me.cbxEstadoChat.Size = New System.Drawing.Size(205, 23)
        Me.cbxEstadoChat.TabIndex = 134
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(385, 332)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 15)
        Me.Label25.TabIndex = 135
        Me.Label25.Text = "Estado"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(383, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(94, 15)
        Me.Label21.TabIndex = 133
        Me.Label21.Text = "Imagen del Chat"
        '
        'PicChat
        '
        Me.PicChat.BackColor = System.Drawing.SystemColors.Control
        Me.PicChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicChat.Location = New System.Drawing.Point(386, 23)
        Me.PicChat.Name = "PicChat"
        Me.PicChat.Size = New System.Drawing.Size(300, 300)
        Me.PicChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicChat.TabIndex = 132
        Me.PicChat.TabStop = False
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label13.Location = New System.Drawing.Point(7, 5)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(170, 15)
        Me.label13.TabIndex = 113
        Me.label13.Text = "Cédula de Identidad y Electoral"
        '
        'PicBCedula
        '
        Me.PicBCedula.BackColor = System.Drawing.Color.Gainsboro
        Me.PicBCedula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicBCedula.Image = Global.Libregco.My.Resources.Resources.no_photo
        Me.PicBCedula.Location = New System.Drawing.Point(6, 23)
        Me.PicBCedula.Name = "PicBCedula"
        Me.PicBCedula.Size = New System.Drawing.Size(250, 337)
        Me.PicBCedula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBCedula.TabIndex = 110
        Me.PicBCedula.TabStop = False
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.PicLogo2)
        Me.TabPage5.Controls.Add(Me.CbxPrivilegios)
        Me.TabPage5.Controls.Add(Me.label18)
        Me.TabPage5.Controls.Add(Me.Label30)
        Me.TabPage5.Controls.Add(Me.Label27)
        Me.TabPage5.Controls.Add(Me.GroupBox3)
        Me.TabPage5.Controls.Add(Me.Label34)
        Me.TabPage5.Controls.Add(Me.ChkAlertas)
        Me.TabPage5.Controls.Add(Me.lblFechaPassword)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(724, 365)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Acceso"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'PicLogo2
        '
        Me.PicLogo2.Location = New System.Drawing.Point(21, 7)
        Me.PicLogo2.Name = "PicLogo2"
        Me.PicLogo2.Size = New System.Drawing.Size(24, 24)
        Me.PicLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicLogo2.TabIndex = 130
        Me.PicLogo2.TabStop = False
        '
        'CbxPrivilegios
        '
        Me.CbxPrivilegios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxPrivilegios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxPrivilegios.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CbxPrivilegios.FormattingEnabled = True
        Me.CbxPrivilegios.Location = New System.Drawing.Point(476, 323)
        Me.CbxPrivilegios.Name = "CbxPrivilegios"
        Me.CbxPrivilegios.Size = New System.Drawing.Size(238, 23)
        Me.CbxPrivilegios.TabIndex = 28
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.BackColor = System.Drawing.Color.Transparent
        Me.label18.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label18.Location = New System.Drawing.Point(409, 326)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(61, 15)
        Me.label18.TabIndex = 122
        Me.label18.Text = "Privilegios"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label30.Location = New System.Drawing.Point(339, 47)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(379, 270)
        Me.Label30.TabIndex = 128
        Me.Label30.Text = resources.GetString("Label30.Text")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(339, 20)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(202, 17)
        Me.Label27.TabIndex = 129
        Me.Label27.Text = "Recomendaciones de seguridad"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblMensajeFactores)
        Me.GroupBox3.Controls.Add(Me.txtPasswordFactorRep)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtPasswordFactor)
        Me.GroupBox3.Controls.Add(Me.Label39)
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.lblPassInfo)
        Me.GroupBox3.Controls.Add(Me.txtLogin)
        Me.GroupBox3.Controls.Add(Me.label17)
        Me.GroupBox3.Controls.Add(Me.label15)
        Me.GroupBox3.Controls.Add(Me.txtConfirmacionPassword)
        Me.GroupBox3.Controls.Add(Me.txtPassword)
        Me.GroupBox3.Controls.Add(Me.label16)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 308)
        Me.GroupBox3.TabIndex = 43
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "         Acceso a Libregco"
        '
        'lblMensajeFactores
        '
        Me.lblMensajeFactores.AutoSize = True
        Me.lblMensajeFactores.BackColor = System.Drawing.Color.Transparent
        Me.lblMensajeFactores.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMensajeFactores.Location = New System.Drawing.Point(9, 287)
        Me.lblMensajeFactores.Name = "lblMensajeFactores"
        Me.lblMensajeFactores.Size = New System.Drawing.Size(0, 15)
        Me.lblMensajeFactores.TabIndex = 134
        '
        'txtPasswordFactorRep
        '
        Me.txtPasswordFactorRep.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtPasswordFactorRep.Location = New System.Drawing.Point(227, 238)
        Me.txtPasswordFactorRep.MaxLength = 4
        Me.txtPasswordFactorRep.Name = "txtPasswordFactorRep"
        Me.txtPasswordFactorRep.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordFactorRep.Size = New System.Drawing.Size(54, 43)
        Me.txtPasswordFactorRep.TabIndex = 133
        Me.txtPasswordFactorRep.WatermarkColor = System.Drawing.Color.DimGray
        Me.txtPasswordFactorRep.WatermarkText = ""
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label41.Location = New System.Drawing.Point(69, 249)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(152, 15)
        Me.Label41.TabIndex = 132
        Me.Label41.Text = "Repita la clave de 4 factores"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label40.Location = New System.Drawing.Point(163, 208)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(124, 15)
        Me.Label40.TabIndex = 131
        Me.Label40.Text = "Sólo valores númericos"
        '
        'txtPasswordFactor
        '
        Me.txtPasswordFactor.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.txtPasswordFactor.Location = New System.Drawing.Point(8, 238)
        Me.txtPasswordFactor.MaxLength = 4
        Me.txtPasswordFactor.Name = "txtPasswordFactor"
        Me.txtPasswordFactor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordFactor.Size = New System.Drawing.Size(54, 43)
        Me.txtPasswordFactor.TabIndex = 130
        Me.txtPasswordFactor.WatermarkColor = System.Drawing.Color.DimGray
        Me.txtPasswordFactor.WatermarkText = ""
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label39.Location = New System.Drawing.Point(12, 208)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(137, 15)
        Me.Label39.TabIndex = 129
        Me.Label39.Text = "Contraseña de 4 factores"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label38.Location = New System.Drawing.Point(6, 227)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(275, 2)
        Me.Label38.TabIndex = 128
        '
        'lblPassInfo
        '
        Me.lblPassInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblPassInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPassInfo.Location = New System.Drawing.Point(6, 167)
        Me.lblPassInfo.Name = "lblPassInfo"
        Me.lblPassInfo.Size = New System.Drawing.Size(286, 35)
        Me.lblPassInfo.TabIndex = 127
        '
        'txtLogin
        '
        Me.txtLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtLogin.Location = New System.Drawing.Point(12, 37)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(275, 27)
        Me.txtLogin.TabIndex = 44
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.BackColor = System.Drawing.Color.Transparent
        Me.label17.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label17.Location = New System.Drawing.Point(9, 118)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(114, 15)
        Me.label17.TabIndex = 121
        Me.label17.Text = "Confirmar password"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.BackColor = System.Drawing.Color.Transparent
        Me.label15.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label15.Location = New System.Drawing.Point(9, 18)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(37, 15)
        Me.label15.TabIndex = 117
        Me.label15.Text = "Login"
        '
        'txtConfirmacionPassword
        '
        Me.txtConfirmacionPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtConfirmacionPassword.Location = New System.Drawing.Point(12, 137)
        Me.txtConfirmacionPassword.Name = "txtConfirmacionPassword"
        Me.txtConfirmacionPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmacionPassword.Size = New System.Drawing.Size(275, 27)
        Me.txtConfirmacionPassword.TabIndex = 46
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPassword.Location = New System.Drawing.Point(12, 87)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(275, 27)
        Me.txtPassword.TabIndex = 45
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.BackColor = System.Drawing.Color.Transparent
        Me.label16.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.label16.Location = New System.Drawing.Point(9, 68)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(57, 15)
        Me.label16.TabIndex = 119
        Me.label16.Text = "Password"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(130, 328)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(104, 13)
        Me.Label34.TabIndex = 127
        Me.Label34.Text = "Fecha de Password:"
        '
        'ChkAlertas
        '
        Me.ChkAlertas.AutoSize = True
        Me.ChkAlertas.Location = New System.Drawing.Point(12, 328)
        Me.ChkAlertas.Name = "ChkAlertas"
        Me.ChkAlertas.Size = New System.Drawing.Size(100, 17)
        Me.ChkAlertas.TabIndex = 47
        Me.ChkAlertas.Text = "Mostrar Alertas"
        Me.ChkAlertas.UseVisualStyleBackColor = True
        '
        'lblFechaPassword
        '
        Me.lblFechaPassword.AutoSize = True
        Me.lblFechaPassword.Location = New System.Drawing.Point(248, 328)
        Me.lblFechaPassword.Name = "lblFechaPassword"
        Me.lblFechaPassword.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaPassword.TabIndex = 128
        '
        'chkNulo
        '
        Me.chkNulo.AutoSize = True
        Me.chkNulo.Enabled = False
        Me.chkNulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkNulo.Location = New System.Drawing.Point(692, 130)
        Me.chkNulo.Name = "chkNulo"
        Me.chkNulo.Size = New System.Drawing.Size(52, 19)
        Me.chkNulo.TabIndex = 106
        Me.chkNulo.Text = "Nulo"
        Me.chkNulo.UseVisualStyleBackColor = True
        Me.chkNulo.Visible = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSiguiente.Location = New System.Drawing.Point(670, 576)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(74, 24)
        Me.btnSiguiente.TabIndex = 16
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnAnterior.Location = New System.Drawing.Point(11, 576)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(74, 24)
        Me.btnAnterior.TabIndex = 17
        Me.btnAnterior.Text = "Anterior"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'cod_cliente_label
        '
        Me.cod_cliente_label.AutoSize = True
        Me.cod_cliente_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cod_cliente_label.Location = New System.Drawing.Point(9, 129)
        Me.cod_cliente_label.Name = "cod_cliente_label"
        Me.cod_cliente_label.Size = New System.Drawing.Size(46, 15)
        Me.cod_cliente_label.TabIndex = 101
        Me.cod_cliente_label.Text = "Código"
        '
        'apodo_label
        '
        Me.apodo_label.AutoSize = True
        Me.apodo_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.apodo_label.Location = New System.Drawing.Point(600, 130)
        Me.apodo_label.Name = "apodo_label"
        Me.apodo_label.Size = New System.Drawing.Size(43, 15)
        Me.apodo_label.TabIndex = 93
        Me.apodo_label.Text = "Apodo"
        '
        'nombre_label
        '
        Me.nombre_label.AutoSize = True
        Me.nombre_label.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nombre_label.Location = New System.Drawing.Point(125, 129)
        Me.nombre_label.Name = "nombre_label"
        Me.nombre_label.Size = New System.Drawing.Size(51, 15)
        Me.nombre_label.TabIndex = 84
        Me.nombre_label.Text = "Nombre"
        '
        'txtIDEmpleado
        '
        Me.txtIDEmpleado.BackColor = System.Drawing.Color.LightGray
        Me.txtIDEmpleado.Enabled = False
        Me.txtIDEmpleado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIDEmpleado.Location = New System.Drawing.Point(12, 149)
        Me.txtIDEmpleado.Name = "txtIDEmpleado"
        Me.txtIDEmpleado.ReadOnly = True
        Me.txtIDEmpleado.Size = New System.Drawing.Size(110, 23)
        Me.txtIDEmpleado.TabIndex = 78
        Me.txtIDEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtApodo
        '
        Me.txtApodo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApodo.Location = New System.Drawing.Point(603, 149)
        Me.txtApodo.Name = "txtApodo"
        Me.txtApodo.Size = New System.Drawing.Size(137, 23)
        Me.txtApodo.TabIndex = 1
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNombre.Location = New System.Drawing.Point(128, 149)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(469, 23)
        Me.txtNombre.TabIndex = 0
        '
        'lblSlogan
        '
        Me.lblSlogan.AutoSize = True
        Me.lblSlogan.Location = New System.Drawing.Point(90, 97)
        Me.lblSlogan.Name = "lblSlogan"
        Me.lblSlogan.Size = New System.Drawing.Size(0, 13)
        Me.lblSlogan.TabIndex = 102
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
        Me.PicBoxLogo.TabIndex = 328
        Me.PicBoxLogo.TabStop = False
        '
        'IconPanel
        '
        Me.IconPanel.Controls.Add(Me.MenuStrip2)
        Me.IconPanel.Location = New System.Drawing.Point(316, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(434, 99)
        Me.IconPanel.TabIndex = 330
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.GuardarToolStripMenuItem, Me.btnBuscar, Me.btnEliminar, Me.btnImprimir})
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
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Image = Global.Libregco.My.Resources.Resources.Save_Option_x72
        Me.GuardarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(84, 95)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        Me.GuardarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Libregco.My.Resources.Resources.Delete_x72
        Me.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 95)
        Me.btnEliminar.Text = "Anular"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'MenuBar
        '
        Me.MenuBar.AutoSize = False
        Me.MenuBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem10, Me.AccionesToolStripMenuItem, Me.ToolStripMenuItem12})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuBar.Size = New System.Drawing.Size(751, 24)
        Me.MenuBar.TabIndex = 329
        Me.MenuBar.Text = "MenuStrip1"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ImprimirToolStripMenuItem1, Me.ToolStripSeparator2, Me.ToolStripMenuItem9})
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(66, 20)
        Me.ToolStripMenuItem5.Text = "Procesos"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = Global.Libregco.My.Resources.Resources.New_x32
        Me.ToolStripMenuItem6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem6.Text = "Nuevo "
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = Global.Libregco.My.Resources.Resources.Save_x32
        Me.ToolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.G), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem7.Text = "Guardar"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.ToolStripMenuItem8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem8.Text = "Buscar"
        '
        'ImprimirToolStripMenuItem1
        '
        Me.ImprimirToolStripMenuItem1.Image = Global.Libregco.My.Resources.Resources.Printer_x32
        Me.ImprimirToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirToolStripMenuItem1.Name = "ImprimirToolStripMenuItem1"
        Me.ImprimirToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem1.Size = New System.Drawing.Size(177, 38)
        Me.ImprimirToolStripMenuItem1.Text = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(174, 6)
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = Global.Libregco.My.Resources.Resources.Home_x32
        Me.ToolStripMenuItem9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(177, 38)
        Me.ToolStripMenuItem9.Text = "Salir"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem11})
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(58, 20)
        Me.ToolStripMenuItem10.Text = "Edición"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = Global.Libregco.My.Resources.Resources.Delete_x32
        Me.ToolStripMenuItem11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(165, 38)
        Me.ToolStripMenuItem11.Text = "Anular"
        '
        'AccionesToolStripMenuItem
        '
        Me.AccionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FotoToolStripMenuItem, Me.CargarFotoToolStripMenuItem, Me.AbrirFotoDelEmpleadoToolStripMenuItem, Me.EliminarFotoDelEmpleadoToolStripMenuItem, Me.ToolStripSeparator1, Me.CédulaToolStripMenuItem, Me.CargarImagenDeIndetificaciónToolStripMenuItem, Me.AbrirImagenDeIdentificaciónToolStripMenuItem, Me.EliminarImagenDeIdentificaciónToolStripMenuItem, Me.ToolStripSeparator3, Me.ImagenDelChatToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.AccionesToolStripMenuItem.Name = "AccionesToolStripMenuItem"
        Me.AccionesToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AccionesToolStripMenuItem.Text = "Acciones"
        '
        'FotoToolStripMenuItem
        '
        Me.FotoToolStripMenuItem.Enabled = False
        Me.FotoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FotoToolStripMenuItem.Name = "FotoToolStripMenuItem"
        Me.FotoToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.FotoToolStripMenuItem.Text = "Foto del empleado"
        '
        'CargarFotoToolStripMenuItem
        '
        Me.CargarFotoToolStripMenuItem.Image = CType(resources.GetObject("CargarFotoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CargarFotoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CargarFotoToolStripMenuItem.Name = "CargarFotoToolStripMenuItem"
        Me.CargarFotoToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.CargarFotoToolStripMenuItem.Text = "Cargar imagen"
        '
        'AbrirFotoDelEmpleadoToolStripMenuItem
        '
        Me.AbrirFotoDelEmpleadoToolStripMenuItem.Image = CType(resources.GetObject("AbrirFotoDelEmpleadoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirFotoDelEmpleadoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AbrirFotoDelEmpleadoToolStripMenuItem.Name = "AbrirFotoDelEmpleadoToolStripMenuItem"
        Me.AbrirFotoDelEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.AbrirFotoDelEmpleadoToolStripMenuItem.Text = "Abrir imagen"
        '
        'EliminarFotoDelEmpleadoToolStripMenuItem
        '
        Me.EliminarFotoDelEmpleadoToolStripMenuItem.Image = CType(resources.GetObject("EliminarFotoDelEmpleadoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarFotoDelEmpleadoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarFotoDelEmpleadoToolStripMenuItem.Name = "EliminarFotoDelEmpleadoToolStripMenuItem"
        Me.EliminarFotoDelEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.EliminarFotoDelEmpleadoToolStripMenuItem.Text = "Eliminar imagen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(218, 6)
        '
        'CédulaToolStripMenuItem
        '
        Me.CédulaToolStripMenuItem.Enabled = False
        Me.CédulaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CédulaToolStripMenuItem.Name = "CédulaToolStripMenuItem"
        Me.CédulaToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.CédulaToolStripMenuItem.Text = "Cédula"
        '
        'CargarImagenDeIndetificaciónToolStripMenuItem
        '
        Me.CargarImagenDeIndetificaciónToolStripMenuItem.Image = CType(resources.GetObject("CargarImagenDeIndetificaciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CargarImagenDeIndetificaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CargarImagenDeIndetificaciónToolStripMenuItem.Name = "CargarImagenDeIndetificaciónToolStripMenuItem"
        Me.CargarImagenDeIndetificaciónToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.CargarImagenDeIndetificaciónToolStripMenuItem.Text = "Cargar cédula"
        '
        'AbrirImagenDeIdentificaciónToolStripMenuItem
        '
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem.Image = CType(resources.GetObject("AbrirImagenDeIdentificaciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem.Name = "AbrirImagenDeIdentificaciónToolStripMenuItem"
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.AbrirImagenDeIdentificaciónToolStripMenuItem.Text = "Abrir cédula"
        '
        'EliminarImagenDeIdentificaciónToolStripMenuItem
        '
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem.Image = CType(resources.GetObject("EliminarImagenDeIdentificaciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem.Name = "EliminarImagenDeIdentificaciónToolStripMenuItem"
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.EliminarImagenDeIdentificaciónToolStripMenuItem.Text = "Eliminar cédula"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(218, 6)
        '
        'ImagenDelChatToolStripMenuItem
        '
        Me.ImagenDelChatToolStripMenuItem.Enabled = False
        Me.ImagenDelChatToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImagenDelChatToolStripMenuItem.Name = "ImagenDelChatToolStripMenuItem"
        Me.ImagenDelChatToolStripMenuItem.Size = New System.Drawing.Size(221, 38)
        Me.ImagenDelChatToolStripMenuItem.Text = "Imagen del chat"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(221, 38)
        Me.ToolStripMenuItem1.Text = "Cargar imagen del chat"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(221, 38)
        Me.ToolStripMenuItem2.Text = "Abrir imagen del chat"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(221, 38)
        Me.ToolStripMenuItem3.Text = "Eliminar imagen del chat"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem13})
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(53, 20)
        Me.ToolStripMenuItem12.Text = "Ayuda"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Image = Global.Libregco.My.Resources.Resources.LibregcoCircle_x32
        Me.ToolStripMenuItem13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(173, 38)
        Me.ToolStripMenuItem13.Text = "Ayuda Libregco"
        '
        'BarraEstado
        '
        Me.BarraEstado.BackColor = System.Drawing.Color.White
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDate, Me.PicLoading, Me.ToolSeparator, Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 604)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(751, 25)
        Me.BarraEstado.TabIndex = 412
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
        'Fecha
        '
        Me.Fecha.Enabled = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha de salida"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha de entrada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 260
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Monto"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "No."
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 40
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Salario"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 85
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Comisiones"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 75
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Totales"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 90
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Totales"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 90
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Totales"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 90
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Hasta"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 80
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "Día"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 40
        '
        'DataGridViewTextBoxColumn23
        '
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn23.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn23.HeaderText = "Diagnóstico"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        Me.DataGridViewTextBoxColumn23.Width = 280
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "Ruta"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        Me.DataGridViewTextBoxColumn24.Width = 80
        '
        'frm_mant_empleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 629)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.PicBoxLogo)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.lblSlogan)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.TabCEmpleados)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtApodo)
        Me.Controls.Add(Me.chkNulo)
        Me.Controls.Add(Me.txtIDEmpleado)
        Me.Controls.Add(Me.nombre_label)
        Me.Controls.Add(Me.cod_cliente_label)
        Me.Controls.Add(Me.apodo_label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_mant_empleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "147"
        Me.Text = "Mantenimiento de empleados"
        Me.TabCEmpleados.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DgvDeducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DgvVacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.DgvMensualidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSNavidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSVacaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TsPreaviso.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSCesantia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage3.PerformLayout()
        CType(Me.PicChat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBCedula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.PicLogo2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IconPanel.ResumeLayout(False)
        Me.IconPanel.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents cod_cliente_label As System.Windows.Forms.Label
    Private WithEvents apodo_label As System.Windows.Forms.Label
    Private WithEvents nombre_label As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnEliminarFoto As System.Windows.Forms.Button
    Private WithEvents btnCargarFoto As System.Windows.Forms.Button
    Private WithEvents btnAbrirFoto As System.Windows.Forms.Button
    Friend WithEvents chkNulo As System.Windows.Forms.CheckBox
    Friend WithEvents PicFoto As System.Windows.Forms.PictureBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonoHogar As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelefonoPersonal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbxMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents CbxProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CbxGenero As System.Windows.Forms.ComboBox
    Friend WithEvents cbxNacionalidad As System.Windows.Forms.ComboBox
    Friend WithEvents tel_hogar_label As System.Windows.Forms.Label
    Friend WithEvents municipio_label As System.Windows.Forms.Label
    Friend WithEvents tel_personal_label As System.Windows.Forms.Label
    Friend WithEvents direccion_label As System.Windows.Forms.Label
    Friend WithEvents provincia_label As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents txtEdad As System.Windows.Forms.TextBox
    Friend WithEvents Nacionalidad_label As System.Windows.Forms.Label
    Friend WithEvents nacimiento_label As System.Windows.Forms.Label
    Friend WithEvents cedula_label As System.Windows.Forms.Label
    Friend WithEvents genero_label As System.Windows.Forms.Label
    Friend WithEvents txtIDEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents txtApodo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents label12 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txtSalario As System.Windows.Forms.TextBox
    Friend WithEvents CbxPrivilegios As System.Windows.Forms.ComboBox
    Friend WithEvents txtConfirmacionPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents PicBCedula As System.Windows.Forms.PictureBox
    Friend WithEvents txtTiempoLaboral As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbxPeriodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents TabCEmpleados As System.Windows.Forms.TabControl
    Friend WithEvents lblSlogan As System.Windows.Forms.Label
    Private WithEvents btnBuscarTanda As System.Windows.Forms.Button
    Friend WithEvents txtTanda As System.Windows.Forms.TextBox
    Friend WithEvents txtIDTanda As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTipoNomina As System.Windows.Forms.TextBox
    Friend WithEvents txtIDNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSalarioDiario As System.Windows.Forms.TextBox
    Private WithEvents btnBuscarCargo As System.Windows.Forms.Button
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvDeducciones As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtConsFlota As System.Windows.Forms.TextBox
    Friend WithEvents ChkAlertas As System.Windows.Forms.CheckBox
    Private WithEvents lblPassInfo As System.Windows.Forms.Label
    Private WithEvents btnBuscarAfp As System.Windows.Forms.Button
    Friend WithEvents txtAfp As System.Windows.Forms.TextBox
    Friend WithEvents txtIDAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Private WithEvents btn_buscarArs As System.Windows.Forms.Button
    Friend WithEvents txtArs As System.Windows.Forms.TextBox
    Friend WithEvents txtIDArs As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCarnet As System.Windows.Forms.TextBox
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnBuscarNomina As System.Windows.Forms.Button
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PicLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Fecha As System.Windows.Forms.Timer
    Friend WithEvents chkHabNomina As System.Windows.Forms.CheckBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As System.Windows.Forms.TextBox
    Private WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtIDSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblFechaPassword As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents CargarFotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirFotoDelEmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarFotoDelEmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CargarImagenDeIndetificaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirImagenDeIdentificaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarImagenDeIdentificaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkISR As System.Windows.Forms.CheckBox
    Friend WithEvents chkTesoreria As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCuotaCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents cbxEstadoChat As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PicChat As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Private WithEvents btnEliminarCedula As System.Windows.Forms.Button
    Private WithEvents btnCargarCedula As System.Windows.Forms.Button
    Private WithEvents btnAbrirCedula As System.Windows.Forms.Button
    Private WithEvents btnEliminarChat As System.Windows.Forms.Button
    Private WithEvents btnCargarChat As System.Windows.Forms.Button
    Private WithEvents btnAbrirChat As System.Windows.Forms.Button
    Friend WithEvents PicLogo2 As System.Windows.Forms.PictureBox
    Private WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents FotoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CédulaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImagenDelChatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtCotizable As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents dtpVacacionInicia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpVacacionTermina As System.Windows.Forms.DateTimePicker
    Private WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Private WithEvents lblMensajeFactores As System.Windows.Forms.Label
    Friend WithEvents txtPasswordFactorRep As Libregco.Watermark
    Private WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordFactor As Libregco.Watermark
    Friend WithEvents txtSeguroComplementario As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents Label44 As Label
    Friend WithEvents txtTotalVacaciones As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents txtDiasVacaciones As TextBox
    Friend WithEvents DgvVacaciones As DataGridView
    Friend WithEvents Label45 As Label
    Friend WithEvents DgvMensualidades As DataGridView
    Friend WithEvents txtSalarioPromedioDiario As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtSalarioPromedioMensual As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents txtSumaSalarios As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents TsPreaviso As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents txtPreaviso As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents TSCesantia As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents txtCensantiaAntes As TextBox
    Friend WithEvents txtCesantiaNuevo As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents TSVacaciones As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents txtVacaciones As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents TSNavidad As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents txtNavidad As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents txtTotalRecibir As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents txtTiempoLaborado As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents SeparatorControl5 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Label57 As Label
    Friend WithEvents txtIDVacaciones As TextBox
    Friend WithEvents btnProgramarVacaciones As Button
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NumeroSalario As DataGridViewTextBoxColumn
    Friend WithEvents Mes As DataGridViewTextBoxColumn
    Friend WithEvents SalarioMensualidad As DataGridViewTextBoxColumn
    Friend WithEvents ComisionesSalarios As DataGridViewTextBoxColumn
    Friend WithEvents TotalesSalario As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents dtpFechaSalida As DateTimePicker
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DiasLicencia As DataGridViewTextBoxColumn
    Friend WithEvents Hasta As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents IDEmpleado As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents RutaDocumentoInfraccion As DataGridViewTextBoxColumn
    Friend WithEvents Documento As DataGridViewImageColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents FechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents FechaSalida As DataGridViewTextBoxColumn
    Friend WithEvents DiasVacaciones As DataGridViewTextBoxColumn
    Friend WithEvents Concepto As DataGridViewTextBoxColumn
    Friend WithEvents MontoPagoVacaciones As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkCobrador As CheckBox
    Friend WithEvents chkVendedor As CheckBox
End Class
