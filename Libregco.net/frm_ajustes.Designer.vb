<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ajustes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ajustes))
        Me.PicBoxLogo = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.EmpresaInfoTab = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnModificarEmpresa = New System.Windows.Forms.Button()
        Me.LboxInfoEmpresa = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cbxMoneda = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.imgFlags = New DevExpress.Utils.ImageCollection(Me.components)
        Me.Label94 = New System.Windows.Forms.Label()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.txtTasaTSS = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.rdbDirecto = New System.Windows.Forms.RadioButton()
        Me.rdbPredictivo = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLimiteConsultas = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbxPlazoContrato = New System.Windows.Forms.ComboBox()
        Me.txtDiasCondicion = New System.Windows.Forms.TextBox()
        Me.cbxCobradorPred = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxNacionalidad = New System.Windows.Forms.ComboBox()
        Me.cbxNCFPredeterminado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CbxOcupacion = New System.Windows.Forms.ComboBox()
        Me.txtItbisGeneral = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbxCondicion = New System.Windows.Forms.ComboBox()
        Me.cbxEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox38 = New System.Windows.Forms.GroupBox()
        Me.lblSensibilidadDescripcion = New System.Windows.Forms.Label()
        Me.TBSensibilidadDescripcion = New System.Windows.Forms.TrackBar()
        Me.chkFraccionesTexto = New System.Windows.Forms.CheckBox()
        Me.GroupBox37 = New System.Windows.Forms.GroupBox()
        Me.btnFracciones = New System.Windows.Forms.Button()
        Me.chkControlDigitalFactura = New System.Windows.Forms.CheckBox()
        Me.ChkFacturarconVencidas = New System.Windows.Forms.CheckBox()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIDClienteContraEntrega = New System.Windows.Forms.TextBox()
        Me.txtNombreContraEntrega = New System.Windows.Forms.TextBox()
        Me.chkHabilitarContraEntrega = New System.Windows.Forms.CheckBox()
        Me.chkRedondearPrecios = New System.Windows.Forms.CheckBox()
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
        Me.ICBERedondeoHacia = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.txtDiasNotas = New System.Windows.Forms.NumericUpDown()
        Me.chkControlarNotasContado = New System.Windows.Forms.CheckBox()
        Me.chkBloquearFactArtSNComprasVentas = New System.Windows.Forms.CheckBox()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.chkSensibilidadControlVenta = New System.Windows.Forms.CheckBox()
        Me.chkBloqueoPrecioCero = New System.Windows.Forms.CheckBox()
        Me.chkHabilitarControlDespacho = New System.Windows.Forms.CheckBox()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.chkControlDespachoPunto = New System.Windows.Forms.CheckBox()
        Me.chkControlDespachoMedia = New System.Windows.Forms.CheckBox()
        Me.chkControlDespachoPagina = New System.Windows.Forms.CheckBox()
        Me.cbxControlDespachoPuntoVenta = New System.Windows.Forms.ComboBox()
        Me.cbxControlDespachoMediaPagina = New System.Windows.Forms.ComboBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.cbxControlDespachoPaginaCompleta = New System.Windows.Forms.ComboBox()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.NUSensibilidadRelacionados = New System.Windows.Forms.NumericUpDown()
        Me.chkSoloconExistenciaRelacionados = New System.Windows.Forms.CheckBox()
        Me.chkMostrarRelacionadasPrefac = New System.Windows.Forms.CheckBox()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.chkSoloconExistSimilares = New System.Windows.Forms.CheckBox()
        Me.chkMostrarSimiliaresPrefact = New System.Windows.Forms.CheckBox()
        Me.chkMostrarNoOrden = New System.Windows.Forms.CheckBox()
        Me.chkPermitirFactLimiteAgotado = New System.Windows.Forms.CheckBox()
        Me.chkControlarPreciosNiveles = New System.Windows.Forms.CheckBox()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.cbxReporteCredito = New System.Windows.Forms.ComboBox()
        Me.cbxReporteContado = New System.Windows.Forms.ComboBox()
        Me.chkUtilizarReportesPredFacturacion = New System.Windows.Forms.CheckBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.chkVisualArticulosCompletos = New System.Windows.Forms.CheckBox()
        Me.chkSolConfirmacionVendedor = New System.Windows.Forms.CheckBox()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PicFacturacion = New System.Windows.Forms.PictureBox()
        Me.TrackBarFactura = New System.Windows.Forms.TrackBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PicPrefactura = New System.Windows.Forms.PictureBox()
        Me.TrackBarPrefactura = New System.Windows.Forms.TrackBar()
        Me.chkPermitirDev30 = New System.Windows.Forms.CheckBox()
        Me.chkRNCInteligente = New System.Windows.Forms.CheckBox()
        Me.chkPermitirFactSinPrefact = New System.Windows.Forms.CheckBox()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.chkControlarTipoPago = New System.Windows.Forms.CheckBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.chkHoraCortesCaja = New System.Windows.Forms.CheckBox()
        Me.chkPermitirReimpresion = New System.Windows.Forms.CheckBox()
        Me.chkPermitirModPrefactura = New System.Windows.Forms.CheckBox()
        Me.chkPermitirDuplicidadFacturacion = New System.Windows.Forms.CheckBox()
        Me.chkPermitirFiltradoCorte = New System.Windows.Forms.CheckBox()
        Me.chkCalculoCorteCaja = New System.Windows.Forms.CheckBox()
        Me.chkImpresionCopiaMultiple = New System.Windows.Forms.CheckBox()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.chkCopiaDespacho = New System.Windows.Forms.CheckBox()
        Me.chkCopiaContabilidad = New System.Windows.Forms.CheckBox()
        Me.chkCopiaCliente = New System.Windows.Forms.CheckBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.chkSolInformacionAdc = New System.Windows.Forms.CheckBox()
        Me.chkSolDireccionCompleta = New System.Windows.Forms.CheckBox()
        Me.chkSolGarante = New System.Windows.Forms.CheckBox()
        Me.chkSolTelefonoPersonal2 = New System.Windows.Forms.CheckBox()
        Me.chkSolTelefonoPersonal1 = New System.Windows.Forms.CheckBox()
        Me.chkNoIdentObligatoria = New System.Windows.Forms.CheckBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.chkIdentificacionFisiscaObligatoria = New System.Windows.Forms.CheckBox()
        Me.ChkPermitirTarjetasFacturacion = New System.Windows.Forms.CheckBox()
        Me.chkBloqueoFacturacionSimultanea = New System.Windows.Forms.CheckBox()
        Me.chkControlMontoMinimoPagare = New System.Windows.Forms.CheckBox()
        Me.chkControlCantidadCreditos = New System.Windows.Forms.CheckBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtMontoMinimoPagare = New System.Windows.Forms.TextBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.txtCantMaximaFacturasCredito = New System.Windows.Forms.TextBox()
        Me.chkControlCantidadPagaresVencidos = New System.Windows.Forms.CheckBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtCantMaximaPagaresVencidos = New System.Windows.Forms.TextBox()
        Me.chkObligacionSeriales = New System.Windows.Forms.CheckBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.chkDarExpiracionPrefacturaciion = New System.Windows.Forms.CheckBox()
        Me.cbxVidaUtilPrefacturacion = New System.Windows.Forms.ComboBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.dtpBlackFridayEnds = New System.Windows.Forms.DateTimePicker()
        Me.chkBlackFridayLiberarFacturacion = New System.Windows.Forms.CheckBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.dtpBlackFridayStart = New System.Windows.Forms.DateTimePicker()
        Me.chkActivacionBlackFriday = New System.Windows.Forms.CheckBox()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkModificacionArticuloBase = New System.Windows.Forms.CheckBox()
        Me.chkFacturacionSinInvArticuloBase = New System.Windows.Forms.CheckBox()
        Me.chkBloqueoImpresionRapida = New System.Windows.Forms.CheckBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.chkGenerarNCFCargo = New System.Windows.Forms.CheckBox()
        Me.rdbUnicaMora = New System.Windows.Forms.RadioButton()
        Me.rdbMoraMensual = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkHabilitarCobroCargos = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMoraDiaria = New System.Windows.Forms.TextBox()
        Me.txtMoraAnual = New System.Windows.Forms.TextBox()
        Me.txtMoraMensual = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtDiasparaCerrarCredito = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.chkCerrarCreditoporAntiguedad = New System.Windows.Forms.CheckBox()
        Me.txtCargosMonto = New System.Windows.Forms.TextBox()
        Me.chkCerrarCreditoconCargo = New System.Windows.Forms.CheckBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.chkControlarventassinInicial = New System.Windows.Forms.CheckBox()
        Me.chkHabModContenido = New System.Windows.Forms.CheckBox()
        Me.chkImponerRncTel = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtLimiteMaximoSolNombre = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.chkSolicitarNombreLimite = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtRelacionSalario = New System.Windows.Forms.TextBox()
        Me.chkControlarMontoPagosxSalario = New System.Windows.Forms.CheckBox()
        Me.chkControlarFactMenores = New System.Windows.Forms.CheckBox()
        Me.chkControlarInfoTarjetas = New System.Windows.Forms.CheckBox()
        Me.chkGenerarPagares = New System.Windows.Forms.CheckBox()
        Me.chkCambiarFechaFact = New System.Windows.Forms.CheckBox()
        Me.chkPedirAutCredito = New System.Windows.Forms.CheckBox()
        Me.chkPermCredSSol = New System.Windows.Forms.CheckBox()
        Me.chkPerCambioPlazoSol = New System.Windows.Forms.CheckBox()
        Me.chkFacturarSExistencia = New System.Windows.Forms.CheckBox()
        Me.chkMostpreciosFact = New System.Windows.Forms.CheckBox()
        Me.chkFactDebajoCosto = New System.Windows.Forms.CheckBox()
        Me.chkFactNCFAgotado = New System.Windows.Forms.CheckBox()
        Me.chkPermitirDevoSucursal = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkCodigoPrimarioClientes = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.chkCXCFormatoLargo = New System.Windows.Forms.CheckBox()
        Me.chkPermitirCobrosTarjeta = New System.Windows.Forms.CheckBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.chkControlarDescuentos = New System.Windows.Forms.CheckBox()
        Me.txtLimiteDescuentos = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtCantRevisionNombre = New System.Windows.Forms.TextBox()
        Me.chkShowIncompletesInfoClientes = New System.Windows.Forms.CheckBox()
        Me.chkCambiarFechaRecibos = New System.Windows.Forms.CheckBox()
        Me.txtUltimaActCXC = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.chkEvitDomingos = New System.Windows.Forms.CheckBox()
        Me.chkMultiplesCliRec = New System.Windows.Forms.CheckBox()
        Me.chkShowPagaresenCobro = New System.Windows.Forms.CheckBox()
        Me.chkEvitSabados = New System.Windows.Forms.CheckBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkVisualDigitalesCXP = New System.Windows.Forms.CheckBox()
        Me.chkAumentarPreciosRelacionCOsto = New System.Windows.Forms.CheckBox()
        Me.chkLlenarListadoProductos = New System.Windows.Forms.CheckBox()
        Me.cbkActPreciosMedidas = New System.Windows.Forms.CheckBox()
        Me.chkRedondearPreciosPiezaje = New System.Windows.Forms.CheckBox()
        Me.chkGuardarCalculosPiezaje = New System.Windows.Forms.CheckBox()
        Me.chkGuardarAutPietaje = New System.Windows.Forms.CheckBox()
        Me.chkLlenarAutVerificacionSub = New System.Windows.Forms.CheckBox()
        Me.chkSolConfRecCompra = New System.Windows.Forms.CheckBox()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PicCompras = New System.Windows.Forms.PictureBox()
        Me.TrackBarCompras = New System.Windows.Forms.TrackBar()
        Me.chkPermitirDuplicidadCompras = New System.Windows.Forms.CheckBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtCantDecimales = New System.Windows.Forms.NumericUpDown()
        Me.chkRevalidarTotales = New System.Windows.Forms.CheckBox()
        Me.chkAvisarIncosistencia = New System.Windows.Forms.CheckBox()
        Me.chkActSupenArt = New System.Windows.Forms.CheckBox()
        Me.chkActCostos = New System.Windows.Forms.CheckBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.chkDeshabilitarVerificacionCorreo = New System.Windows.Forms.CheckBox()
        Me.chkBloquearUsuarios = New System.Windows.Forms.CheckBox()
        Me.chkMultipleUsuarios = New System.Windows.Forms.CheckBox()
        Me.chkMostrarBotonAsistenciaInicio = New System.Windows.Forms.CheckBox()
        Me.txtDiasGuardarBitacora = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkModificarModal = New System.Windows.Forms.CheckBox()
        Me.chkPerContraerEncInicio = New System.Windows.Forms.CheckBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtDiasUtilesPassword = New System.Windows.Forms.TextBox()
        Me.txtTiempoInactividad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkPerDesactivarAudio = New System.Windows.Forms.CheckBox()
        Me.chkPerDeshBloqueoInact = New System.Windows.Forms.CheckBox()
        Me.chkPerDeshInicioAutomatico = New System.Windows.Forms.CheckBox()
        Me.ChkPerDeshConsejos = New System.Windows.Forms.CheckBox()
        Me.chkPerDeshConNotify = New System.Windows.Forms.CheckBox()
        Me.chkPerDeshNotificaciones = New System.Windows.Forms.CheckBox()
        Me.chkLimPassLife = New System.Windows.Forms.CheckBox()
        Me.chkMostrarUsuarios = New System.Windows.Forms.CheckBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.chkDesactivarSuperclaves = New System.Windows.Forms.CheckBox()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.DgvSuperClaves = New System.Windows.Forms.DataGridView()
        Me.IDSuperClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.DgvAcciones = New System.Windows.Forms.DataGridView()
        Me.IDAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReportesTab = New System.Windows.Forms.TabPage()
        Me.TabControl4 = New System.Windows.Forms.TabControl()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtPieDeposito = New System.Windows.Forms.TextBox()
        Me.txtEncDeposito = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.txtPieFactCredito = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtEncFactCredito = New System.Windows.Forms.TextBox()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.txtPieFact = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEncFact = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtEncCotizacion = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPieCotizacion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEncReciboIngreso = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPieReciboIngreso = New System.Windows.Forms.TextBox()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.DgvFormatos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PrinterKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCFs = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkNoGenerarNCFparaDevoluciones = New System.Windows.Forms.CheckBox()
        Me.GboxEstructuraNCF = New System.Windows.Forms.GroupBox()
        Me.lblExplicacionNCF = New System.Windows.Forms.Label()
        Me.rdbMetodo2 = New System.Windows.Forms.RadioButton()
        Me.rdbMetodo3 = New System.Windows.Forms.RadioButton()
        Me.rdbMetodo1 = New System.Windows.Forms.RadioButton()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblSecuencia = New System.Windows.Forms.Label()
        Me.lblDN = New System.Windows.Forms.Label()
        Me.lblAI = New System.Windows.Forms.Label()
        Me.lblTC = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lblPE = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.AlertasTab = New System.Windows.Forms.TabPage()
        Me.txtDiasAlertasAcuerdos = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtDiasRestAlertPass = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMaxSizeofFiles = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantMinimaparaAlertaNCF = New System.Windows.Forms.TextBox()
        Me.txtDiasVencimientoCheque = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDiasSolicitudClientes = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Filtados = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtPalabraClaveCosto = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ColorFactCredito = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ColorFactContado = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ColorAbonos = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ColorChequesDev = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ColorDevoluciones = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ColorNotaCredito = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ColorNotaDebito = New System.Windows.Forms.Label()
        Me.ColorCargos = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.BarraEstado = New System.Windows.Forms.ToolStrip()
        Me.PicLogo = New System.Windows.Forms.ToolStripButton()
        Me.NameSys = New System.Windows.Forms.ToolStripLabel()
        Me.ToolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblStatusBar = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDescripDuplicado = New System.Windows.Forms.TextBox()
        Me.txtDescripDespacho = New System.Windows.Forms.TextBox()
        Me.txtDescripContabilidad = New System.Windows.Forms.TextBox()
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.EmpresaInfoTab.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox30.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox29.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox38.SuspendLayout()
        CType(Me.TBSensibilidadDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox37.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        Me.GroupBox35.SuspendLayout()
        CType(Me.ICBERedondeoHacia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox34.SuspendLayout()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox33.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        CType(Me.NUSensibilidadRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PicFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PicPrefactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarPrefactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox25.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox24.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PicCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        CType(Me.DgvSuperClaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.DgvAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ReportesTab.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        CType(Me.DgvFormatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NCFs.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GboxEstructuraNCF.SuspendLayout()
        Me.AlertasTab.SuspendLayout()
        Me.Filtados.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.BarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBoxLogo
        '
        Me.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicBoxLogo.Location = New System.Drawing.Point(0, 0)
        Me.PicBoxLogo.Name = "PicBoxLogo"
        Me.PicBoxLogo.Size = New System.Drawing.Size(249, 78)
        Me.PicBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicBoxLogo.TabIndex = 1
        Me.PicBoxLogo.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.EmpresaInfoTab)
        Me.TabControl1.Controls.Add(Me.GeneralTab)
        Me.TabControl1.Controls.Add(Me.ReportesTab)
        Me.TabControl1.Controls.Add(Me.NCFs)
        Me.TabControl1.Controls.Add(Me.AlertasTab)
        Me.TabControl1.Controls.Add(Me.Filtados)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(825, 543)
        Me.TabControl1.TabIndex = 192
        '
        'EmpresaInfoTab
        '
        Me.EmpresaInfoTab.Controls.Add(Me.Panel1)
        Me.EmpresaInfoTab.Controls.Add(Me.btnModificarEmpresa)
        Me.EmpresaInfoTab.Controls.Add(Me.LboxInfoEmpresa)
        Me.EmpresaInfoTab.Controls.Add(Me.Label1)
        Me.EmpresaInfoTab.Location = New System.Drawing.Point(4, 25)
        Me.EmpresaInfoTab.Name = "EmpresaInfoTab"
        Me.EmpresaInfoTab.Padding = New System.Windows.Forms.Padding(3)
        Me.EmpresaInfoTab.Size = New System.Drawing.Size(817, 514)
        Me.EmpresaInfoTab.TabIndex = 0
        Me.EmpresaInfoTab.Text = "Empresa Información"
        Me.EmpresaInfoTab.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PicBoxLogo)
        Me.Panel1.Location = New System.Drawing.Point(8, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 78)
        Me.Panel1.TabIndex = 211
        '
        'btnModificarEmpresa
        '
        Me.btnModificarEmpresa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModificarEmpresa.Image = Global.Libregco.My.Resources.Resources.System_Settingsx32
        Me.btnModificarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarEmpresa.Location = New System.Drawing.Point(660, 61)
        Me.btnModificarEmpresa.Name = "btnModificarEmpresa"
        Me.btnModificarEmpresa.Size = New System.Drawing.Size(151, 38)
        Me.btnModificarEmpresa.TabIndex = 210
        Me.btnModificarEmpresa.Text = "Modificar Empresa"
        Me.btnModificarEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarEmpresa.UseVisualStyleBackColor = True
        '
        'LboxInfoEmpresa
        '
        Me.LboxInfoEmpresa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LboxInfoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LboxInfoEmpresa.Enabled = False
        Me.LboxInfoEmpresa.FormattingEnabled = True
        Me.LboxInfoEmpresa.Location = New System.Drawing.Point(6, 106)
        Me.LboxInfoEmpresa.Name = "LboxInfoEmpresa"
        Me.LboxInfoEmpresa.Size = New System.Drawing.Size(805, 444)
        Me.LboxInfoEmpresa.TabIndex = 209
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 208
        Me.Label1.Text = "Logo de la Empresa"
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.TabControl2)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 25)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(817, 514)
        Me.GeneralTab.TabIndex = 3
        Me.GeneralTab.Text = "Generales"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.TabControl2.Location = New System.Drawing.Point(3, 3)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(811, 508)
        Me.TabControl2.TabIndex = 271
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.cbxMoneda)
        Me.TabPage2.Controls.Add(Me.Label94)
        Me.TabPage2.Controls.Add(Me.SeparatorControl3)
        Me.TabPage2.Controls.Add(Me.GroupBox30)
        Me.TabPage2.Controls.Add(Me.GroupBox29)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtLimiteConsultas)
        Me.TabPage2.Controls.Add(Me.Label58)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.cbxPlazoContrato)
        Me.TabPage2.Controls.Add(Me.txtDiasCondicion)
        Me.TabPage2.Controls.Add(Me.cbxCobradorPred)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.cbxNacionalidad)
        Me.TabPage2.Controls.Add(Me.cbxNCFPredeterminado)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.CbxOcupacion)
        Me.TabPage2.Controls.Add(Me.txtItbisGeneral)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.cbxCondicion)
        Me.TabPage2.Controls.Add(Me.cbxEstadoCivil)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(803, 479)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pre-establecidos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbxMoneda
        '
        Me.cbxMoneda.Location = New System.Drawing.Point(96, 265)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.cbxMoneda.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cbxMoneda.Properties.Appearance.Options.UseBackColor = True
        Me.cbxMoneda.Properties.Appearance.Options.UseFont = True
        Me.cbxMoneda.Properties.Appearance.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cbxMoneda.Properties.AppearanceDropDown.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.cbxMoneda.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cbxMoneda.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.cbxMoneda.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbxMoneda.Properties.DropDownRows = 6
        Me.cbxMoneda.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.cbxMoneda.Properties.SmallImages = Me.imgFlags
        Me.cbxMoneda.Size = New System.Drawing.Size(281, 18)
        Me.cbxMoneda.TabIndex = 339
        Me.cbxMoneda.TabStop = False
        '
        'imgFlags
        '
        Me.imgFlags.ImageStream = CType(resources.GetObject("imgFlags.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.imgFlags.Images.SetKeyName(0, "flag_dr.png")
        Me.imgFlags.Images.SetKeyName(1, "flag_usa.png")
        Me.imgFlags.Images.SetKeyName(2, "flag_eu.png")
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(11, 267)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(45, 13)
        Me.Label94.TabIndex = 337
        Me.Label94.Text = "Moneda"
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl3.Location = New System.Drawing.Point(453, 9)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Size = New System.Drawing.Size(24, 467)
        Me.SeparatorControl3.TabIndex = 269
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.Panel4)
        Me.GroupBox30.Location = New System.Drawing.Point(14, 300)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(441, 211)
        Me.GroupBox30.TabIndex = 268
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Seguridad Social"
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.Label62)
        Me.Panel4.Controls.Add(Me.Label38)
        Me.Panel4.Controls.Add(Me.SeparatorControl2)
        Me.Panel4.Controls.Add(Me.TextBox9)
        Me.Panel4.Controls.Add(Me.txtTasaTSS)
        Me.Panel4.Controls.Add(Me.TextBox7)
        Me.Panel4.Controls.Add(Me.Label89)
        Me.Panel4.Controls.Add(Me.TextBox8)
        Me.Panel4.Controls.Add(Me.Label90)
        Me.Panel4.Controls.Add(Me.Label91)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.Label92)
        Me.Panel4.Controls.Add(Me.TextBox4)
        Me.Panel4.Controls.Add(Me.Label88)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(435, 192)
        Me.Panel4.TabIndex = 47
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(152, 7)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(280, 28)
        Me.Label62.TabIndex = 46
        Me.Label62.Text = "Resultado del porcentaje de la cuota respecto al salario y su división con el por" &
    "centaje a pagar por el asalariado." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(8, 14)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(66, 13)
        Me.Label38.TabIndex = 40
        Me.Label38.Text = "Tasa de TSS"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(6, 31)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(426, 23)
        Me.SeparatorControl2.TabIndex = 0
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(242, 106)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(57, 20)
        Me.TextBox9.TabIndex = 266
        Me.TextBox9.Text = "2.87"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTasaTSS
        '
        Me.txtTasaTSS.Location = New System.Drawing.Point(79, 11)
        Me.txtTasaTSS.Name = "txtTasaTSS"
        Me.txtTasaTSS.Size = New System.Drawing.Size(70, 20)
        Me.txtTasaTSS.TabIndex = 39
        Me.txtTasaTSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(242, 54)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(57, 20)
        Me.TextBox7.TabIndex = 262
        Me.TextBox7.Text = "3.04"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Location = New System.Drawing.Point(8, 137)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(127, 13)
        Me.Label89.TabIndex = 253
        Me.Label89.Text = "Contribución Pensión C.P"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(242, 80)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(57, 20)
        Me.TextBox8.TabIndex = 264
        Me.TextBox8.Text = "7.09"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(8, 111)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(115, 13)
        Me.Label90.TabIndex = 255
        Me.Label90.Text = "Retención Pensión R.P"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Location = New System.Drawing.Point(8, 85)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(227, 13)
        Me.Label91.TabIndex = 257
        Me.Label91.Text = "Contribución Seguro Familiar de Salud C.S.F.S"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(242, 132)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(57, 20)
        Me.TextBox1.TabIndex = 250
        Me.TextBox1.Text = "7.10"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(8, 163)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(158, 13)
        Me.Label92.TabIndex = 259
        Me.Label92.Text = "Seguro de Riesgo Laboral S.R.L"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(242, 158)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(57, 20)
        Me.TextBox4.TabIndex = 256
        Me.TextBox4.Text = "1.15"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Location = New System.Drawing.Point(8, 57)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(215, 13)
        Me.Label88.TabIndex = 251
        Me.Label88.Text = "Retención Seguro Familiar de Salud R.S.F.S"
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.rdbDirecto)
        Me.GroupBox29.Controls.Add(Me.rdbPredictivo)
        Me.GroupBox29.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox29.Location = New System.Drawing.Point(483, 7)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(267, 47)
        Me.GroupBox29.TabIndex = 249
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Tipo de consulta durante la búsqueda de artículos"
        '
        'rdbDirecto
        '
        Me.rdbDirecto.AutoSize = True
        Me.rdbDirecto.Location = New System.Drawing.Point(10, 19)
        Me.rdbDirecto.Name = "rdbDirecto"
        Me.rdbDirecto.Size = New System.Drawing.Size(59, 17)
        Me.rdbDirecto.TabIndex = 1
        Me.rdbDirecto.Text = "Directo"
        Me.rdbDirecto.UseVisualStyleBackColor = True
        '
        'rdbPredictivo
        '
        Me.rdbPredictivo.AutoSize = True
        Me.rdbPredictivo.Checked = True
        Me.rdbPredictivo.Location = New System.Drawing.Point(75, 19)
        Me.rdbPredictivo.Name = "rdbPredictivo"
        Me.rdbPredictivo.Size = New System.Drawing.Size(72, 17)
        Me.rdbPredictivo.TabIndex = 0
        Me.rdbPredictivo.TabStop = True
        Me.rdbPredictivo.Text = "Predictivo"
        Me.rdbPredictivo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(483, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(208, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Cantidad de registros a limitar en consulta"
        '
        'txtLimiteConsultas
        '
        Me.txtLimiteConsultas.Location = New System.Drawing.Point(697, 61)
        Me.txtLimiteConsultas.Name = "txtLimiteConsultas"
        Me.txtLimiteConsultas.Size = New System.Drawing.Size(54, 20)
        Me.txtLimiteConsultas.TabIndex = 7
        Me.txtLimiteConsultas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(11, 235)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(32, 13)
        Me.Label58.TabIndex = 43
        Me.Label58.Text = "Plazo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Tipo de NCF"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(11, 38)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(74, 13)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "Días condición"
        '
        'cbxPlazoContrato
        '
        Me.cbxPlazoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPlazoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPlazoContrato.FormattingEnabled = True
        Me.cbxPlazoContrato.Location = New System.Drawing.Point(99, 235)
        Me.cbxPlazoContrato.Name = "cbxPlazoContrato"
        Me.cbxPlazoContrato.Size = New System.Drawing.Size(281, 21)
        Me.cbxPlazoContrato.TabIndex = 44
        '
        'txtDiasCondicion
        '
        Me.txtDiasCondicion.Location = New System.Drawing.Point(99, 35)
        Me.txtDiasCondicion.Name = "txtDiasCondicion"
        Me.txtDiasCondicion.Size = New System.Drawing.Size(85, 20)
        Me.txtDiasCondicion.TabIndex = 37
        Me.txtDiasCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxCobradorPred
        '
        Me.cbxCobradorPred.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCobradorPred.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCobradorPred.FormattingEnabled = True
        Me.cbxCobradorPred.Location = New System.Drawing.Point(99, 90)
        Me.cbxCobradorPred.Name = "cbxCobradorPred"
        Me.cbxCobradorPred.Size = New System.Drawing.Size(281, 21)
        Me.cbxCobradorPred.TabIndex = 28
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(11, 209)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(67, 13)
        Me.Label34.TabIndex = 41
        Me.Label34.Text = "Nacionalidad"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Cobrador "
        '
        'cbxNacionalidad
        '
        Me.cbxNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNacionalidad.FormattingEnabled = True
        Me.cbxNacionalidad.Location = New System.Drawing.Point(99, 206)
        Me.cbxNacionalidad.Name = "cbxNacionalidad"
        Me.cbxNacionalidad.Size = New System.Drawing.Size(281, 21)
        Me.cbxNacionalidad.TabIndex = 42
        '
        'cbxNCFPredeterminado
        '
        Me.cbxNCFPredeterminado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNCFPredeterminado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNCFPredeterminado.FormattingEnabled = True
        Me.cbxNCFPredeterminado.Location = New System.Drawing.Point(99, 61)
        Me.cbxNCFPredeterminado.Name = "cbxNCFPredeterminado"
        Me.cbxNCFPredeterminado.Size = New System.Drawing.Size(281, 21)
        Me.cbxNCFPredeterminado.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Itbis General"
        '
        'CbxOcupacion
        '
        Me.CbxOcupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxOcupacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxOcupacion.FormattingEnabled = True
        Me.CbxOcupacion.Location = New System.Drawing.Point(99, 177)
        Me.CbxOcupacion.Name = "CbxOcupacion"
        Me.CbxOcupacion.Size = New System.Drawing.Size(281, 21)
        Me.CbxOcupacion.TabIndex = 40
        '
        'txtItbisGeneral
        '
        Me.txtItbisGeneral.Location = New System.Drawing.Point(99, 6)
        Me.txtItbisGeneral.Name = "txtItbisGeneral"
        Me.txtItbisGeneral.Size = New System.Drawing.Size(85, 20)
        Me.txtItbisGeneral.TabIndex = 14
        Me.txtItbisGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(11, 122)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 13)
        Me.Label31.TabIndex = 35
        Me.Label31.Text = "Condición"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(11, 180)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(57, 13)
        Me.Label33.TabIndex = 39
        Me.Label33.Text = "Ocupación"
        '
        'cbxCondicion
        '
        Me.cbxCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCondicion.FormattingEnabled = True
        Me.cbxCondicion.Location = New System.Drawing.Point(99, 119)
        Me.cbxCondicion.Name = "cbxCondicion"
        Me.cbxCondicion.Size = New System.Drawing.Size(281, 21)
        Me.cbxCondicion.TabIndex = 36
        '
        'cbxEstadoCivil
        '
        Me.cbxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxEstadoCivil.FormattingEnabled = True
        Me.cbxEstadoCivil.Location = New System.Drawing.Point(99, 148)
        Me.cbxEstadoCivil.Name = "cbxEstadoCivil"
        Me.cbxEstadoCivil.Size = New System.Drawing.Size(281, 21)
        Me.cbxEstadoCivil.TabIndex = 38
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(11, 151)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 37
        Me.Label32.Text = "Estado Civil"
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.GroupBox38)
        Me.TabPage1.Controls.Add(Me.chkFraccionesTexto)
        Me.TabPage1.Controls.Add(Me.GroupBox37)
        Me.TabPage1.Controls.Add(Me.chkControlDigitalFactura)
        Me.TabPage1.Controls.Add(Me.ChkFacturarconVencidas)
        Me.TabPage1.Controls.Add(Me.GroupBox36)
        Me.TabPage1.Controls.Add(Me.chkRedondearPrecios)
        Me.TabPage1.Controls.Add(Me.GroupBox35)
        Me.TabPage1.Controls.Add(Me.Label96)
        Me.TabPage1.Controls.Add(Me.txtDiasNotas)
        Me.TabPage1.Controls.Add(Me.chkControlarNotasContado)
        Me.TabPage1.Controls.Add(Me.chkBloquearFactArtSNComprasVentas)
        Me.TabPage1.Controls.Add(Me.GroupBox34)
        Me.TabPage1.Controls.Add(Me.chkBloqueoPrecioCero)
        Me.TabPage1.Controls.Add(Me.chkHabilitarControlDespacho)
        Me.TabPage1.Controls.Add(Me.GroupBox33)
        Me.TabPage1.Controls.Add(Me.GroupBox32)
        Me.TabPage1.Controls.Add(Me.GroupBox31)
        Me.TabPage1.Controls.Add(Me.chkMostrarNoOrden)
        Me.TabPage1.Controls.Add(Me.chkPermitirFactLimiteAgotado)
        Me.TabPage1.Controls.Add(Me.chkControlarPreciosNiveles)
        Me.TabPage1.Controls.Add(Me.GroupBox28)
        Me.TabPage1.Controls.Add(Me.chkVisualArticulosCompletos)
        Me.TabPage1.Controls.Add(Me.chkSolConfirmacionVendedor)
        Me.TabPage1.Controls.Add(Me.GroupBox26)
        Me.TabPage1.Controls.Add(Me.chkPermitirDev30)
        Me.TabPage1.Controls.Add(Me.chkRNCInteligente)
        Me.TabPage1.Controls.Add(Me.chkPermitirFactSinPrefact)
        Me.TabPage1.Controls.Add(Me.GroupBox25)
        Me.TabPage1.Controls.Add(Me.chkHoraCortesCaja)
        Me.TabPage1.Controls.Add(Me.chkPermitirReimpresion)
        Me.TabPage1.Controls.Add(Me.chkPermitirModPrefactura)
        Me.TabPage1.Controls.Add(Me.chkPermitirDuplicidadFacturacion)
        Me.TabPage1.Controls.Add(Me.chkPermitirFiltradoCorte)
        Me.TabPage1.Controls.Add(Me.chkCalculoCorteCaja)
        Me.TabPage1.Controls.Add(Me.chkImpresionCopiaMultiple)
        Me.TabPage1.Controls.Add(Me.GroupBox24)
        Me.TabPage1.Controls.Add(Me.GroupBox23)
        Me.TabPage1.Controls.Add(Me.ChkPermitirTarjetasFacturacion)
        Me.TabPage1.Controls.Add(Me.chkBloqueoFacturacionSimultanea)
        Me.TabPage1.Controls.Add(Me.chkControlMontoMinimoPagare)
        Me.TabPage1.Controls.Add(Me.chkControlCantidadCreditos)
        Me.TabPage1.Controls.Add(Me.GroupBox19)
        Me.TabPage1.Controls.Add(Me.GroupBox18)
        Me.TabPage1.Controls.Add(Me.chkControlCantidadPagaresVencidos)
        Me.TabPage1.Controls.Add(Me.GroupBox17)
        Me.TabPage1.Controls.Add(Me.chkObligacionSeriales)
        Me.TabPage1.Controls.Add(Me.GroupBox15)
        Me.TabPage1.Controls.Add(Me.GroupBox14)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.chkBloqueoImpresionRapida)
        Me.TabPage1.Controls.Add(Me.GroupBox11)
        Me.TabPage1.Controls.Add(Me.GroupBox10)
        Me.TabPage1.Controls.Add(Me.chkControlarventassinInicial)
        Me.TabPage1.Controls.Add(Me.chkHabModContenido)
        Me.TabPage1.Controls.Add(Me.chkImponerRncTel)
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.chkControlarFactMenores)
        Me.TabPage1.Controls.Add(Me.chkControlarInfoTarjetas)
        Me.TabPage1.Controls.Add(Me.chkGenerarPagares)
        Me.TabPage1.Controls.Add(Me.chkCambiarFechaFact)
        Me.TabPage1.Controls.Add(Me.chkPedirAutCredito)
        Me.TabPage1.Controls.Add(Me.chkPermCredSSol)
        Me.TabPage1.Controls.Add(Me.chkPerCambioPlazoSol)
        Me.TabPage1.Controls.Add(Me.chkFacturarSExistencia)
        Me.TabPage1.Controls.Add(Me.chkMostpreciosFact)
        Me.TabPage1.Controls.Add(Me.chkFactDebajoCosto)
        Me.TabPage1.Controls.Add(Me.chkFactNCFAgotado)
        Me.TabPage1.Controls.Add(Me.chkPermitirDevoSucursal)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.TabPage1.Size = New System.Drawing.Size(803, 479)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Facturación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox38
        '
        Me.GroupBox38.Controls.Add(Me.lblSensibilidadDescripcion)
        Me.GroupBox38.Controls.Add(Me.TBSensibilidadDescripcion)
        Me.GroupBox38.Location = New System.Drawing.Point(10, 1526)
        Me.GroupBox38.Name = "GroupBox38"
        Me.GroupBox38.Size = New System.Drawing.Size(324, 65)
        Me.GroupBox38.TabIndex = 119
        Me.GroupBox38.TabStop = False
        Me.GroupBox38.Text = "Longitud de descripción de artículos"
        '
        'lblSensibilidadDescripcion
        '
        Me.lblSensibilidadDescripcion.Location = New System.Drawing.Point(11, 44)
        Me.lblSensibilidadDescripcion.Name = "lblSensibilidadDescripcion"
        Me.lblSensibilidadDescripcion.Size = New System.Drawing.Size(289, 13)
        Me.lblSensibilidadDescripcion.TabIndex = 85
        Me.lblSensibilidadDescripcion.Text = "NINGUNA"
        Me.lblSensibilidadDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBSensibilidadDescripcion
        '
        Me.TBSensibilidadDescripcion.AutoSize = False
        Me.TBSensibilidadDescripcion.LargeChange = 1
        Me.TBSensibilidadDescripcion.Location = New System.Drawing.Point(6, 17)
        Me.TBSensibilidadDescripcion.Maximum = 3
        Me.TBSensibilidadDescripcion.Minimum = 1
        Me.TBSensibilidadDescripcion.Name = "TBSensibilidadDescripcion"
        Me.TBSensibilidadDescripcion.Size = New System.Drawing.Size(292, 31)
        Me.TBSensibilidadDescripcion.TabIndex = 105
        Me.TBSensibilidadDescripcion.Value = 1
        '
        'chkFraccionesTexto
        '
        Me.chkFraccionesTexto.AutoSize = True
        Me.chkFraccionesTexto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFraccionesTexto.Location = New System.Drawing.Point(10, 1471)
        Me.chkFraccionesTexto.Name = "chkFraccionesTexto"
        Me.chkFraccionesTexto.Size = New System.Drawing.Size(244, 17)
        Me.chkFraccionesTexto.TabIndex = 117
        Me.chkFraccionesTexto.Text = "Convertir fracciones en caracteres especiales"
        Me.chkFraccionesTexto.UseVisualStyleBackColor = True
        '
        'GroupBox37
        '
        Me.GroupBox37.Controls.Add(Me.btnFracciones)
        Me.GroupBox37.Location = New System.Drawing.Point(10, 1476)
        Me.GroupBox37.Name = "GroupBox37"
        Me.GroupBox37.Size = New System.Drawing.Size(324, 44)
        Me.GroupBox37.TabIndex = 118
        Me.GroupBox37.TabStop = False
        '
        'btnFracciones
        '
        Me.btnFracciones.Location = New System.Drawing.Point(6, 15)
        Me.btnFracciones.Name = "btnFracciones"
        Me.btnFracciones.Size = New System.Drawing.Size(159, 23)
        Me.btnFracciones.TabIndex = 0
        Me.btnFracciones.Text = "Convertir a fracciones (3/8)"
        Me.btnFracciones.UseVisualStyleBackColor = True
        '
        'chkControlDigitalFactura
        '
        Me.chkControlDigitalFactura.AutoSize = True
        Me.chkControlDigitalFactura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlDigitalFactura.Location = New System.Drawing.Point(10, 1448)
        Me.chkControlDigitalFactura.Name = "chkControlDigitalFactura"
        Me.chkControlDigitalFactura.Size = New System.Drawing.Size(268, 17)
        Me.chkControlDigitalFactura.TabIndex = 116
        Me.chkControlDigitalFactura.Text = "Visualizar controles para subir digitales de facturas"
        Me.chkControlDigitalFactura.UseVisualStyleBackColor = True
        '
        'ChkFacturarconVencidas
        '
        Me.ChkFacturarconVencidas.AutoSize = True
        Me.ChkFacturarconVencidas.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkFacturarconVencidas.Location = New System.Drawing.Point(10, 99)
        Me.ChkFacturarconVencidas.Name = "ChkFacturarconVencidas"
        Me.ChkFacturarconVencidas.Size = New System.Drawing.Size(175, 17)
        Me.ChkFacturarconVencidas.TabIndex = 115
        Me.ChkFacturarconVencidas.Text = "Facturar con facturas vencidas"
        Me.ChkFacturarconVencidas.UseVisualStyleBackColor = True
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox36.Controls.Add(Me.txtIDClienteContraEntrega)
        Me.GroupBox36.Controls.Add(Me.txtNombreContraEntrega)
        Me.GroupBox36.Controls.Add(Me.chkHabilitarContraEntrega)
        Me.GroupBox36.Location = New System.Drawing.Point(370, 1319)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(394, 57)
        Me.GroupBox36.TabIndex = 114
        Me.GroupBox36.TabStop = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnBuscarCliente.Image = Global.Libregco.My.Resources.Resources.Search_x32
        Me.btnBuscarCliente.Location = New System.Drawing.Point(66, 22)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(20, 20)
        Me.btnBuscarCliente.TabIndex = 417
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIDClienteContraEntrega
        '
        Me.txtIDClienteContraEntrega.BackColor = System.Drawing.Color.LightGray
        Me.txtIDClienteContraEntrega.Enabled = False
        Me.txtIDClienteContraEntrega.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtIDClienteContraEntrega.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtIDClienteContraEntrega.Location = New System.Drawing.Point(6, 22)
        Me.txtIDClienteContraEntrega.Name = "txtIDClienteContraEntrega"
        Me.txtIDClienteContraEntrega.ReadOnly = True
        Me.txtIDClienteContraEntrega.Size = New System.Drawing.Size(61, 20)
        Me.txtIDClienteContraEntrega.TabIndex = 419
        Me.txtIDClienteContraEntrega.TabStop = False
        Me.txtIDClienteContraEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombreContraEntrega
        '
        Me.txtNombreContraEntrega.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreContraEntrega.Enabled = False
        Me.txtNombreContraEntrega.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNombreContraEntrega.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.txtNombreContraEntrega.Location = New System.Drawing.Point(85, 22)
        Me.txtNombreContraEntrega.Name = "txtNombreContraEntrega"
        Me.txtNombreContraEntrega.ReadOnly = True
        Me.txtNombreContraEntrega.Size = New System.Drawing.Size(302, 20)
        Me.txtNombreContraEntrega.TabIndex = 418
        Me.txtNombreContraEntrega.TabStop = False
        '
        'chkHabilitarContraEntrega
        '
        Me.chkHabilitarContraEntrega.AutoSize = True
        Me.chkHabilitarContraEntrega.Location = New System.Drawing.Point(5, -1)
        Me.chkHabilitarContraEntrega.Name = "chkHabilitarContraEntrega"
        Me.chkHabilitarContraEntrega.Size = New System.Drawing.Size(305, 17)
        Me.chkHabilitarContraEntrega.TabIndex = 416
        Me.chkHabilitarContraEntrega.Text = "Habilitar código para facturas de contado a contraentrega"
        Me.chkHabilitarContraEntrega.UseVisualStyleBackColor = True
        '
        'chkRedondearPrecios
        '
        Me.chkRedondearPrecios.AutoSize = True
        Me.chkRedondearPrecios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRedondearPrecios.Location = New System.Drawing.Point(10, 1070)
        Me.chkRedondearPrecios.Name = "chkRedondearPrecios"
        Me.chkRedondearPrecios.Size = New System.Drawing.Size(309, 17)
        Me.chkRedondearPrecios.TabIndex = 97
        Me.chkRedondearPrecios.Text = "Redondear al entero más cercano durante precios y costos"
        Me.chkRedondearPrecios.UseVisualStyleBackColor = True
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.ICBERedondeoHacia)
        Me.GroupBox35.Controls.Add(Me.LabelControl2)
        Me.GroupBox35.Location = New System.Drawing.Point(10, 1070)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(324, 48)
        Me.GroupBox35.TabIndex = 113
        Me.GroupBox35.TabStop = False
        '
        'ICBERedondeoHacia
        '
        Me.ICBERedondeoHacia.Enabled = False
        Me.ICBERedondeoHacia.Location = New System.Drawing.Point(56, 20)
        Me.ICBERedondeoHacia.Name = "ICBERedondeoHacia"
        Me.ICBERedondeoHacia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ICBERedondeoHacia.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.ImageComboBoxItem() {New DevExpress.XtraEditors.Controls.ImageComboBoxItem("hacia la unidad ", "1", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("hacia el quintena", "5", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("hacia la decena", "10", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("hacia la centena", "100", -1), New DevExpress.XtraEditors.Controls.ImageComboBoxItem("hacia la milésima", "1000", -1)})
        Me.ICBERedondeoHacia.Size = New System.Drawing.Size(164, 20)
        Me.ICBERedondeoHacia.TabIndex = 98
        '
        'LabelControl2
        '
        Me.LabelControl2.Enabled = False
        Me.LabelControl2.Location = New System.Drawing.Point(6, 23)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl2.TabIndex = 99
        Me.LabelControl2.Text = "Distancia"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(284, 1426)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(26, 13)
        Me.Label96.TabIndex = 112
        Me.Label96.Text = "días"
        '
        'txtDiasNotas
        '
        Me.txtDiasNotas.Enabled = False
        Me.txtDiasNotas.Location = New System.Drawing.Point(232, 1424)
        Me.txtDiasNotas.Name = "txtDiasNotas"
        Me.txtDiasNotas.Size = New System.Drawing.Size(52, 20)
        Me.txtDiasNotas.TabIndex = 111
        Me.txtDiasNotas.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'chkControlarNotasContado
        '
        Me.chkControlarNotasContado.AutoSize = True
        Me.chkControlarNotasContado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarNotasContado.Location = New System.Drawing.Point(10, 1425)
        Me.chkControlarNotasContado.Name = "chkControlarNotasContado"
        Me.chkControlarNotasContado.Size = New System.Drawing.Size(224, 17)
        Me.chkControlarNotasContado.TabIndex = 110
        Me.chkControlarNotasContado.Text = "Controlar tiempo de las notas de contado"
        Me.chkControlarNotasContado.UseVisualStyleBackColor = True
        '
        'chkBloquearFactArtSNComprasVentas
        '
        Me.chkBloquearFactArtSNComprasVentas.AutoSize = True
        Me.chkBloquearFactArtSNComprasVentas.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBloquearFactArtSNComprasVentas.Location = New System.Drawing.Point(10, 1402)
        Me.chkBloquearFactArtSNComprasVentas.Name = "chkBloquearFactArtSNComprasVentas"
        Me.chkBloquearFactArtSNComprasVentas.Size = New System.Drawing.Size(299, 17)
        Me.chkBloquearFactArtSNComprasVentas.TabIndex = 109
        Me.chkBloquearFactArtSNComprasVentas.Text = "No permitir facturación de artículos sin compras ni ventas"
        Me.chkBloquearFactArtSNComprasVentas.UseVisualStyleBackColor = True
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.Label95)
        Me.GroupBox34.Controls.Add(Me.TrackBar2)
        Me.GroupBox34.Controls.Add(Me.chkSensibilidadControlVenta)
        Me.GroupBox34.Location = New System.Drawing.Point(10, 1306)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(324, 90)
        Me.GroupBox34.TabIndex = 105
        Me.GroupBox34.TabStop = False
        '
        'Label95
        '
        Me.Label95.ForeColor = System.Drawing.Color.Gray
        Me.Label95.Location = New System.Drawing.Point(6, 46)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(312, 40)
        Me.Label95.TabIndex = 104
        Me.Label95.Text = "Activar este control flexibilizará las facturaciones a crédito cuando el inicial " &
    "cubra el porcentaje establecido del costo total de la venta"
        '
        'TrackBar2
        '
        Me.TrackBar2.AutoSize = False
        Me.TrackBar2.Location = New System.Drawing.Point(26, 16)
        Me.TrackBar2.Maximum = 200
        Me.TrackBar2.Minimum = 70
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(292, 31)
        Me.TrackBar2.TabIndex = 103
        Me.TrackBar2.TickFrequency = 5
        Me.TrackBar2.Value = 70
        '
        'chkSensibilidadControlVenta
        '
        Me.chkSensibilidadControlVenta.AutoSize = True
        Me.chkSensibilidadControlVenta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSensibilidadControlVenta.Location = New System.Drawing.Point(0, 0)
        Me.chkSensibilidadControlVenta.Name = "chkSensibilidadControlVenta"
        Me.chkSensibilidadControlVenta.Size = New System.Drawing.Size(290, 17)
        Me.chkSensibilidadControlVenta.TabIndex = 102
        Me.chkSensibilidadControlVenta.Text = "Activar sensibilidad de venta sobre el costo de venta al"
        Me.chkSensibilidadControlVenta.UseVisualStyleBackColor = True
        '
        'chkBloqueoPrecioCero
        '
        Me.chkBloqueoPrecioCero.AutoSize = True
        Me.chkBloqueoPrecioCero.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBloqueoPrecioCero.Location = New System.Drawing.Point(10, 1283)
        Me.chkBloqueoPrecioCero.Name = "chkBloqueoPrecioCero"
        Me.chkBloqueoPrecioCero.Size = New System.Drawing.Size(291, 17)
        Me.chkBloqueoPrecioCero.TabIndex = 107
        Me.chkBloqueoPrecioCero.Text = "Bloquear facturación de artículos con precio cero RD$ 0"
        Me.chkBloqueoPrecioCero.UseVisualStyleBackColor = True
        '
        'chkHabilitarControlDespacho
        '
        Me.chkHabilitarControlDespacho.AutoSize = True
        Me.chkHabilitarControlDespacho.Location = New System.Drawing.Point(376, 1188)
        Me.chkHabilitarControlDespacho.Name = "chkHabilitarControlDespacho"
        Me.chkHabilitarControlDespacho.Size = New System.Drawing.Size(237, 17)
        Me.chkHabilitarControlDespacho.TabIndex = 0
        Me.chkHabilitarControlDespacho.Text = "Habilitar control de despacho en facturación"
        Me.chkHabilitarControlDespacho.UseVisualStyleBackColor = True
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.chkControlDespachoPunto)
        Me.GroupBox33.Controls.Add(Me.chkControlDespachoMedia)
        Me.GroupBox33.Controls.Add(Me.chkControlDespachoPagina)
        Me.GroupBox33.Controls.Add(Me.cbxControlDespachoPuntoVenta)
        Me.GroupBox33.Controls.Add(Me.cbxControlDespachoMediaPagina)
        Me.GroupBox33.Controls.Add(Me.Label93)
        Me.GroupBox33.Controls.Add(Me.cbxControlDespachoPaginaCompleta)
        Me.GroupBox33.Location = New System.Drawing.Point(370, 1185)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(353, 128)
        Me.GroupBox33.TabIndex = 106
        Me.GroupBox33.TabStop = False
        '
        'chkControlDespachoPunto
        '
        Me.chkControlDespachoPunto.AutoSize = True
        Me.chkControlDespachoPunto.Location = New System.Drawing.Point(6, 97)
        Me.chkControlDespachoPunto.Name = "chkControlDespachoPunto"
        Me.chkControlDespachoPunto.Size = New System.Drawing.Size(100, 17)
        Me.chkControlDespachoPunto.TabIndex = 109
        Me.chkControlDespachoPunto.Text = "Punto de venta"
        Me.chkControlDespachoPunto.UseVisualStyleBackColor = True
        '
        'chkControlDespachoMedia
        '
        Me.chkControlDespachoMedia.AutoSize = True
        Me.chkControlDespachoMedia.Location = New System.Drawing.Point(6, 70)
        Me.chkControlDespachoMedia.Name = "chkControlDespachoMedia"
        Me.chkControlDespachoMedia.Size = New System.Drawing.Size(89, 17)
        Me.chkControlDespachoMedia.TabIndex = 108
        Me.chkControlDespachoMedia.Text = "Media página"
        Me.chkControlDespachoMedia.UseVisualStyleBackColor = True
        '
        'chkControlDespachoPagina
        '
        Me.chkControlDespachoPagina.AutoSize = True
        Me.chkControlDespachoPagina.Location = New System.Drawing.Point(6, 43)
        Me.chkControlDespachoPagina.Name = "chkControlDespachoPagina"
        Me.chkControlDespachoPagina.Size = New System.Drawing.Size(104, 17)
        Me.chkControlDespachoPagina.TabIndex = 107
        Me.chkControlDespachoPagina.Text = "Página completa"
        Me.chkControlDespachoPagina.UseVisualStyleBackColor = True
        '
        'cbxControlDespachoPuntoVenta
        '
        Me.cbxControlDespachoPuntoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxControlDespachoPuntoVenta.FormattingEnabled = True
        Me.cbxControlDespachoPuntoVenta.Location = New System.Drawing.Point(112, 95)
        Me.cbxControlDespachoPuntoVenta.Name = "cbxControlDespachoPuntoVenta"
        Me.cbxControlDespachoPuntoVenta.Size = New System.Drawing.Size(234, 21)
        Me.cbxControlDespachoPuntoVenta.TabIndex = 91
        '
        'cbxControlDespachoMediaPagina
        '
        Me.cbxControlDespachoMediaPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxControlDespachoMediaPagina.FormattingEnabled = True
        Me.cbxControlDespachoMediaPagina.Location = New System.Drawing.Point(112, 68)
        Me.cbxControlDespachoMediaPagina.Name = "cbxControlDespachoMediaPagina"
        Me.cbxControlDespachoMediaPagina.Size = New System.Drawing.Size(234, 21)
        Me.cbxControlDespachoMediaPagina.TabIndex = 90
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.Location = New System.Drawing.Point(110, 21)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(125, 13)
        Me.Label93.TabIndex = 86
        Me.Label93.Text = "Reportes disponibles"
        '
        'cbxControlDespachoPaginaCompleta
        '
        Me.cbxControlDespachoPaginaCompleta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxControlDespachoPaginaCompleta.FormattingEnabled = True
        Me.cbxControlDespachoPaginaCompleta.Location = New System.Drawing.Point(113, 41)
        Me.cbxControlDespachoPaginaCompleta.Name = "cbxControlDespachoPaginaCompleta"
        Me.cbxControlDespachoPaginaCompleta.Size = New System.Drawing.Size(234, 21)
        Me.cbxControlDespachoPaginaCompleta.TabIndex = 85
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.Label97)
        Me.GroupBox32.Controls.Add(Me.NUSensibilidadRelacionados)
        Me.GroupBox32.Controls.Add(Me.chkSoloconExistenciaRelacionados)
        Me.GroupBox32.Controls.Add(Me.chkMostrarRelacionadasPrefac)
        Me.GroupBox32.Location = New System.Drawing.Point(8, 1168)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(313, 62)
        Me.GroupBox32.TabIndex = 105
        Me.GroupBox32.TabStop = False
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(25, 39)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(62, 13)
        Me.Label97.TabIndex = 106
        Me.Label97.Text = "Sensibilidad"
        '
        'NUSensibilidadRelacionados
        '
        Me.NUSensibilidadRelacionados.Location = New System.Drawing.Point(93, 37)
        Me.NUSensibilidadRelacionados.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NUSensibilidadRelacionados.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUSensibilidadRelacionados.Name = "NUSensibilidadRelacionados"
        Me.NUSensibilidadRelacionados.Size = New System.Drawing.Size(58, 20)
        Me.NUSensibilidadRelacionados.TabIndex = 105
        Me.NUSensibilidadRelacionados.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkSoloconExistenciaRelacionados
        '
        Me.chkSoloconExistenciaRelacionados.AutoSize = True
        Me.chkSoloconExistenciaRelacionados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSoloconExistenciaRelacionados.Location = New System.Drawing.Point(25, 19)
        Me.chkSoloconExistenciaRelacionados.Name = "chkSoloconExistenciaRelacionados"
        Me.chkSoloconExistenciaRelacionados.Size = New System.Drawing.Size(199, 17)
        Me.chkSoloconExistenciaRelacionados.TabIndex = 104
        Me.chkSoloconExistenciaRelacionados.Text = "Mostrar sólo artículos con existencia"
        Me.chkSoloconExistenciaRelacionados.UseVisualStyleBackColor = True
        '
        'chkMostrarRelacionadasPrefac
        '
        Me.chkMostrarRelacionadasPrefac.AutoSize = True
        Me.chkMostrarRelacionadasPrefac.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarRelacionadasPrefac.Location = New System.Drawing.Point(2, 0)
        Me.chkMostrarRelacionadasPrefac.Name = "chkMostrarRelacionadasPrefac"
        Me.chkMostrarRelacionadasPrefac.Size = New System.Drawing.Size(294, 17)
        Me.chkMostrarRelacionadasPrefac.TabIndex = 103
        Me.chkMostrarRelacionadasPrefac.Text = "Mostrar artículos relacionados durante la prefacturación"
        Me.chkMostrarRelacionadasPrefac.UseVisualStyleBackColor = True
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.chkSoloconExistSimilares)
        Me.GroupBox31.Controls.Add(Me.chkMostrarSimiliaresPrefact)
        Me.GroupBox31.Location = New System.Drawing.Point(10, 1236)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(311, 41)
        Me.GroupBox31.TabIndex = 104
        Me.GroupBox31.TabStop = False
        '
        'chkSoloconExistSimilares
        '
        Me.chkSoloconExistSimilares.AutoSize = True
        Me.chkSoloconExistSimilares.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSoloconExistSimilares.Location = New System.Drawing.Point(23, 19)
        Me.chkSoloconExistSimilares.Name = "chkSoloconExistSimilares"
        Me.chkSoloconExistSimilares.Size = New System.Drawing.Size(199, 17)
        Me.chkSoloconExistSimilares.TabIndex = 103
        Me.chkSoloconExistSimilares.Text = "Mostrar sólo artículos con existencia"
        Me.chkSoloconExistSimilares.UseVisualStyleBackColor = True
        '
        'chkMostrarSimiliaresPrefact
        '
        Me.chkMostrarSimiliaresPrefact.AutoSize = True
        Me.chkMostrarSimiliaresPrefact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarSimiliaresPrefact.Location = New System.Drawing.Point(0, 0)
        Me.chkMostrarSimiliaresPrefact.Name = "chkMostrarSimiliaresPrefact"
        Me.chkMostrarSimiliaresPrefact.Size = New System.Drawing.Size(274, 17)
        Me.chkMostrarSimiliaresPrefact.TabIndex = 102
        Me.chkMostrarSimiliaresPrefact.Text = "Mostrar artículos similares durante la prefacturación"
        Me.chkMostrarSimiliaresPrefact.UseVisualStyleBackColor = True
        '
        'chkMostrarNoOrden
        '
        Me.chkMostrarNoOrden.AutoSize = True
        Me.chkMostrarNoOrden.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarNoOrden.Location = New System.Drawing.Point(10, 1145)
        Me.chkMostrarNoOrden.Name = "chkMostrarNoOrden"
        Me.chkMostrarNoOrden.Size = New System.Drawing.Size(285, 17)
        Me.chkMostrarNoOrden.TabIndex = 101
        Me.chkMostrarNoOrden.Text = "Mostrar campo de número de orden en prefacturación"
        Me.chkMostrarNoOrden.UseVisualStyleBackColor = True
        '
        'chkPermitirFactLimiteAgotado
        '
        Me.chkPermitirFactLimiteAgotado.AutoSize = True
        Me.chkPermitirFactLimiteAgotado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirFactLimiteAgotado.Location = New System.Drawing.Point(10, 1122)
        Me.chkPermitirFactLimiteAgotado.Name = "chkPermitirFactLimiteAgotado"
        Me.chkPermitirFactLimiteAgotado.Size = New System.Drawing.Size(260, 17)
        Me.chkPermitirFactLimiteAgotado.TabIndex = 100
        Me.chkPermitirFactLimiteAgotado.Text = "Permitir facturación con límite de crédito agotado"
        Me.chkPermitirFactLimiteAgotado.UseVisualStyleBackColor = True
        '
        'chkControlarPreciosNiveles
        '
        Me.chkControlarPreciosNiveles.AutoSize = True
        Me.chkControlarPreciosNiveles.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarPreciosNiveles.Location = New System.Drawing.Point(10, 53)
        Me.chkControlarPreciosNiveles.Name = "chkControlarPreciosNiveles"
        Me.chkControlarPreciosNiveles.Size = New System.Drawing.Size(209, 17)
        Me.chkControlarPreciosNiveles.TabIndex = 99
        Me.chkControlarPreciosNiveles.Text = "Controlar precios de venta por niveles"
        Me.chkControlarPreciosNiveles.UseVisualStyleBackColor = True
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.Label87)
        Me.GroupBox28.Controls.Add(Me.cbxReporteCredito)
        Me.GroupBox28.Controls.Add(Me.cbxReporteContado)
        Me.GroupBox28.Controls.Add(Me.chkUtilizarReportesPredFacturacion)
        Me.GroupBox28.Controls.Add(Me.Label86)
        Me.GroupBox28.Controls.Add(Me.Label85)
        Me.GroupBox28.Location = New System.Drawing.Point(370, 1085)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(353, 94)
        Me.GroupBox28.TabIndex = 98
        Me.GroupBox28.TabStop = False
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(65, 20)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(125, 13)
        Me.Label87.TabIndex = 84
        Me.Label87.Text = "Reportes disponibles"
        '
        'cbxReporteCredito
        '
        Me.cbxReporteCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxReporteCredito.FormattingEnabled = True
        Me.cbxReporteCredito.Location = New System.Drawing.Point(68, 64)
        Me.cbxReporteCredito.Name = "cbxReporteCredito"
        Me.cbxReporteCredito.Size = New System.Drawing.Size(278, 21)
        Me.cbxReporteCredito.TabIndex = 83
        '
        'cbxReporteContado
        '
        Me.cbxReporteContado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxReporteContado.FormattingEnabled = True
        Me.cbxReporteContado.Location = New System.Drawing.Point(68, 37)
        Me.cbxReporteContado.Name = "cbxReporteContado"
        Me.cbxReporteContado.Size = New System.Drawing.Size(278, 21)
        Me.cbxReporteContado.TabIndex = 82
        '
        'chkUtilizarReportesPredFacturacion
        '
        Me.chkUtilizarReportesPredFacturacion.AutoSize = True
        Me.chkUtilizarReportesPredFacturacion.Location = New System.Drawing.Point(6, 0)
        Me.chkUtilizarReportesPredFacturacion.Name = "chkUtilizarReportesPredFacturacion"
        Me.chkUtilizarReportesPredFacturacion.Size = New System.Drawing.Size(164, 17)
        Me.chkUtilizarReportesPredFacturacion.TabIndex = 81
        Me.chkUtilizarReportesPredFacturacion.Text = "Utilizar reportes predefinidos"
        Me.chkUtilizarReportesPredFacturacion.UseVisualStyleBackColor = True
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Location = New System.Drawing.Point(10, 67)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(52, 13)
        Me.Label86.TabIndex = 80
        Me.Label86.Text = "CRÉDITO"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(10, 40)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(57, 13)
        Me.Label85.TabIndex = 79
        Me.Label85.Text = "CONTADO"
        '
        'chkVisualArticulosCompletos
        '
        Me.chkVisualArticulosCompletos.AutoSize = True
        Me.chkVisualArticulosCompletos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkVisualArticulosCompletos.Location = New System.Drawing.Point(10, 1047)
        Me.chkVisualArticulosCompletos.Name = "chkVisualArticulosCompletos"
        Me.chkVisualArticulosCompletos.Size = New System.Drawing.Size(222, 17)
        Me.chkVisualArticulosCompletos.TabIndex = 96
        Me.chkVisualArticulosCompletos.Text = "Presentar historial de artículos completos"
        Me.chkVisualArticulosCompletos.UseVisualStyleBackColor = True
        '
        'chkSolConfirmacionVendedor
        '
        Me.chkSolConfirmacionVendedor.AutoSize = True
        Me.chkSolConfirmacionVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolConfirmacionVendedor.Location = New System.Drawing.Point(10, 1024)
        Me.chkSolConfirmacionVendedor.Name = "chkSolConfirmacionVendedor"
        Me.chkSolConfirmacionVendedor.Size = New System.Drawing.Size(262, 17)
        Me.chkSolConfirmacionVendedor.TabIndex = 95
        Me.chkSolConfirmacionVendedor.Text = "Solicitar confirmación de vendedor en facturación"
        Me.chkSolConfirmacionVendedor.UseVisualStyleBackColor = True
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.Label82)
        Me.GroupBox26.Controls.Add(Me.Label81)
        Me.GroupBox26.Controls.Add(Me.Panel3)
        Me.GroupBox26.Controls.Add(Me.TrackBarFactura)
        Me.GroupBox26.Controls.Add(Me.Panel2)
        Me.GroupBox26.Controls.Add(Me.TrackBarPrefactura)
        Me.GroupBox26.Location = New System.Drawing.Point(370, 921)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(352, 158)
        Me.GroupBox26.TabIndex = 94
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "Tamaños de imágenes"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(179, 139)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(63, 13)
        Me.Label82.TabIndex = 4
        Me.Label82.Text = "Facturación"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.Location = New System.Drawing.Point(9, 139)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(77, 13)
        Me.Label81.TabIndex = 4
        Me.Label81.Text = "Prefacturación"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.PicFacturacion)
        Me.Panel3.Location = New System.Drawing.Point(178, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(120, 120)
        Me.Panel3.TabIndex = 6
        '
        'PicFacturacion
        '
        Me.PicFacturacion.BackColor = System.Drawing.Color.Gray
        Me.PicFacturacion.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.PicFacturacion.Name = "PicFacturacion"
        Me.PicFacturacion.Size = New System.Drawing.Size(120, 120)
        Me.PicFacturacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicFacturacion.TabIndex = 4
        Me.PicFacturacion.TabStop = False
        '
        'TrackBarFactura
        '
        Me.TrackBarFactura.LargeChange = 15
        Me.TrackBarFactura.Location = New System.Drawing.Point(301, 14)
        Me.TrackBarFactura.Maximum = 120
        Me.TrackBarFactura.Minimum = 15
        Me.TrackBarFactura.Name = "TrackBarFactura"
        Me.TrackBarFactura.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarFactura.Size = New System.Drawing.Size(45, 120)
        Me.TrackBarFactura.TabIndex = 5
        Me.TrackBarFactura.Value = 120
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.PicPrefactura)
        Me.Panel2.Location = New System.Drawing.Point(8, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(120, 120)
        Me.Panel2.TabIndex = 2
        '
        'PicPrefactura
        '
        Me.PicPrefactura.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicPrefactura.Location = New System.Drawing.Point(0, 0)
        Me.PicPrefactura.Name = "PicPrefactura"
        Me.PicPrefactura.Size = New System.Drawing.Size(120, 120)
        Me.PicPrefactura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicPrefactura.TabIndex = 3
        Me.PicPrefactura.TabStop = False
        '
        'TrackBarPrefactura
        '
        Me.TrackBarPrefactura.LargeChange = 15
        Me.TrackBarPrefactura.Location = New System.Drawing.Point(131, 16)
        Me.TrackBarPrefactura.Maximum = 120
        Me.TrackBarPrefactura.Minimum = 15
        Me.TrackBarPrefactura.Name = "TrackBarPrefactura"
        Me.TrackBarPrefactura.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarPrefactura.Size = New System.Drawing.Size(45, 120)
        Me.TrackBarPrefactura.TabIndex = 1
        Me.TrackBarPrefactura.Value = 120
        '
        'chkPermitirDev30
        '
        Me.chkPermitirDev30.AutoSize = True
        Me.chkPermitirDev30.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirDev30.Location = New System.Drawing.Point(10, 1001)
        Me.chkPermitirDev30.Name = "chkPermitirDev30"
        Me.chkPermitirDev30.Size = New System.Drawing.Size(305, 17)
        Me.chkPermitirDev30.TabIndex = 93
        Me.chkPermitirDev30.Text = "Permitir devolución de itbis en facturas con más de 30 días"
        Me.chkPermitirDev30.UseVisualStyleBackColor = True
        '
        'chkRNCInteligente
        '
        Me.chkRNCInteligente.AutoSize = True
        Me.chkRNCInteligente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRNCInteligente.Location = New System.Drawing.Point(10, 978)
        Me.chkRNCInteligente.Name = "chkRNCInteligente"
        Me.chkRNCInteligente.Size = New System.Drawing.Size(188, 17)
        Me.chkRNCInteligente.TabIndex = 92
        Me.chkRNCInteligente.Text = "RNC inteligente en prefacturación"
        Me.chkRNCInteligente.UseVisualStyleBackColor = True
        '
        'chkPermitirFactSinPrefact
        '
        Me.chkPermitirFactSinPrefact.AutoSize = True
        Me.chkPermitirFactSinPrefact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirFactSinPrefact.Location = New System.Drawing.Point(10, 955)
        Me.chkPermitirFactSinPrefact.Name = "chkPermitirFactSinPrefact"
        Me.chkPermitirFactSinPrefact.Size = New System.Drawing.Size(295, 17)
        Me.chkPermitirFactSinPrefact.TabIndex = 91
        Me.chkPermitirFactSinPrefact.Text = "Obligar la realización de prefacturas para emitir facturas"
        Me.chkPermitirFactSinPrefact.UseVisualStyleBackColor = True
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.chkControlarTipoPago)
        Me.GroupBox25.Controls.Add(Me.Label80)
        Me.GroupBox25.Controls.Add(Me.TrackBar1)
        Me.GroupBox25.Location = New System.Drawing.Point(10, 681)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(316, 90)
        Me.GroupBox25.TabIndex = 90
        Me.GroupBox25.TabStop = False
        '
        'chkControlarTipoPago
        '
        Me.chkControlarTipoPago.AutoSize = True
        Me.chkControlarTipoPago.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarTipoPago.Location = New System.Drawing.Point(0, 0)
        Me.chkControlarTipoPago.Name = "chkControlarTipoPago"
        Me.chkControlarTipoPago.Size = New System.Drawing.Size(253, 17)
        Me.chkControlarTipoPago.TabIndex = 78
        Me.chkControlarTipoPago.Text = "Controlar el tipo de pago al realizar prefacturas"
        Me.chkControlarTipoPago.UseVisualStyleBackColor = True
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(11, 21)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(222, 13)
        Me.Label80.TabIndex = 75
        Me.Label80.Text = "Tiempo en espera de respuesta en segundos"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(10, 38)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(300, 45)
        Me.TrackBar1.TabIndex = 87
        '
        'chkHoraCortesCaja
        '
        Me.chkHoraCortesCaja.AutoSize = True
        Me.chkHoraCortesCaja.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkHoraCortesCaja.Location = New System.Drawing.Point(10, 932)
        Me.chkHoraCortesCaja.Name = "chkHoraCortesCaja"
        Me.chkHoraCortesCaja.Size = New System.Drawing.Size(251, 17)
        Me.chkHoraCortesCaja.TabIndex = 89
        Me.chkHoraCortesCaja.Text = "Utilizar hora en las fechas de los cortes de caja"
        Me.chkHoraCortesCaja.UseVisualStyleBackColor = True
        '
        'chkPermitirReimpresion
        '
        Me.chkPermitirReimpresion.AutoSize = True
        Me.chkPermitirReimpresion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirReimpresion.Location = New System.Drawing.Point(10, 909)
        Me.chkPermitirReimpresion.Name = "chkPermitirReimpresion"
        Me.chkPermitirReimpresion.Size = New System.Drawing.Size(183, 17)
        Me.chkPermitirReimpresion.TabIndex = 88
        Me.chkPermitirReimpresion.Text = "Permitir reimpresión de originales"
        Me.chkPermitirReimpresion.UseVisualStyleBackColor = True
        '
        'chkPermitirModPrefactura
        '
        Me.chkPermitirModPrefactura.AutoSize = True
        Me.chkPermitirModPrefactura.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirModPrefactura.Location = New System.Drawing.Point(10, 873)
        Me.chkPermitirModPrefactura.Name = "chkPermitirModPrefactura"
        Me.chkPermitirModPrefactura.Size = New System.Drawing.Size(256, 30)
        Me.chkPermitirModPrefactura.TabIndex = 87
        Me.chkPermitirModPrefactura.Text = "Permitir modificación de artículos en facturación " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "desde prefacturación"
        Me.chkPermitirModPrefactura.UseVisualStyleBackColor = True
        '
        'chkPermitirDuplicidadFacturacion
        '
        Me.chkPermitirDuplicidadFacturacion.AutoSize = True
        Me.chkPermitirDuplicidadFacturacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirDuplicidadFacturacion.Location = New System.Drawing.Point(10, 848)
        Me.chkPermitirDuplicidadFacturacion.Name = "chkPermitirDuplicidadFacturacion"
        Me.chkPermitirDuplicidadFacturacion.Size = New System.Drawing.Size(170, 17)
        Me.chkPermitirDuplicidadFacturacion.TabIndex = 86
        Me.chkPermitirDuplicidadFacturacion.Text = "Permitir duplicidad de artículos"
        Me.chkPermitirDuplicidadFacturacion.UseVisualStyleBackColor = True
        '
        'chkPermitirFiltradoCorte
        '
        Me.chkPermitirFiltradoCorte.AutoSize = True
        Me.chkPermitirFiltradoCorte.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirFiltradoCorte.Location = New System.Drawing.Point(10, 801)
        Me.chkPermitirFiltradoCorte.Name = "chkPermitirFiltradoCorte"
        Me.chkPermitirFiltradoCorte.Size = New System.Drawing.Size(211, 17)
        Me.chkPermitirFiltradoCorte.TabIndex = 85
        Me.chkPermitirFiltradoCorte.Text = "Permitir filtrados durante corte de caja"
        Me.chkPermitirFiltradoCorte.UseVisualStyleBackColor = True
        '
        'chkCalculoCorteCaja
        '
        Me.chkCalculoCorteCaja.AutoSize = True
        Me.chkCalculoCorteCaja.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCalculoCorteCaja.Location = New System.Drawing.Point(10, 826)
        Me.chkCalculoCorteCaja.Name = "chkCalculoCorteCaja"
        Me.chkCalculoCorteCaja.Size = New System.Drawing.Size(311, 17)
        Me.chkCalculoCorteCaja.TabIndex = 84
        Me.chkCalculoCorteCaja.Text = "Visualizar el cálculo de corte de caja para todos los usuarios"
        Me.chkCalculoCorteCaja.UseVisualStyleBackColor = True
        '
        'chkImpresionCopiaMultiple
        '
        Me.chkImpresionCopiaMultiple.AutoSize = True
        Me.chkImpresionCopiaMultiple.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkImpresionCopiaMultiple.Location = New System.Drawing.Point(374, 811)
        Me.chkImpresionCopiaMultiple.Name = "chkImpresionCopiaMultiple"
        Me.chkImpresionCopiaMultiple.Size = New System.Drawing.Size(185, 17)
        Me.chkImpresionCopiaMultiple.TabIndex = 83
        Me.chkImpresionCopiaMultiple.Text = "Impresión de múltiples duplicados"
        Me.chkImpresionCopiaMultiple.UseVisualStyleBackColor = True
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.txtDescripContabilidad)
        Me.GroupBox24.Controls.Add(Me.txtDescripDespacho)
        Me.GroupBox24.Controls.Add(Me.txtDescripDuplicado)
        Me.GroupBox24.Controls.Add(Me.chkCopiaDespacho)
        Me.GroupBox24.Controls.Add(Me.chkCopiaContabilidad)
        Me.GroupBox24.Controls.Add(Me.chkCopiaCliente)
        Me.GroupBox24.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox24.Location = New System.Drawing.Point(370, 808)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(317, 107)
        Me.GroupBox24.TabIndex = 82
        Me.GroupBox24.TabStop = False
        '
        'chkCopiaDespacho
        '
        Me.chkCopiaDespacho.AutoSize = True
        Me.chkCopiaDespacho.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCopiaDespacho.Location = New System.Drawing.Point(15, 51)
        Me.chkCopiaDespacho.Name = "chkCopiaDespacho"
        Me.chkCopiaDespacho.Size = New System.Drawing.Size(73, 17)
        Me.chkCopiaDespacho.TabIndex = 85
        Me.chkCopiaDespacho.Text = "Despacho"
        Me.chkCopiaDespacho.UseVisualStyleBackColor = True
        '
        'chkCopiaContabilidad
        '
        Me.chkCopiaContabilidad.AutoSize = True
        Me.chkCopiaContabilidad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCopiaContabilidad.Location = New System.Drawing.Point(15, 76)
        Me.chkCopiaContabilidad.Name = "chkCopiaContabilidad"
        Me.chkCopiaContabilidad.Size = New System.Drawing.Size(85, 17)
        Me.chkCopiaContabilidad.TabIndex = 84
        Me.chkCopiaContabilidad.Text = "Contabilidad"
        Me.chkCopiaContabilidad.UseVisualStyleBackColor = True
        '
        'chkCopiaCliente
        '
        Me.chkCopiaCliente.AutoSize = True
        Me.chkCopiaCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCopiaCliente.Location = New System.Drawing.Point(15, 26)
        Me.chkCopiaCliente.Name = "chkCopiaCliente"
        Me.chkCopiaCliente.Size = New System.Drawing.Size(64, 17)
        Me.chkCopiaCliente.TabIndex = 0
        Me.chkCopiaCliente.Text = "Clientes"
        Me.chkCopiaCliente.UseVisualStyleBackColor = True
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.chkSolInformacionAdc)
        Me.GroupBox23.Controls.Add(Me.chkSolDireccionCompleta)
        Me.GroupBox23.Controls.Add(Me.chkSolGarante)
        Me.GroupBox23.Controls.Add(Me.chkSolTelefonoPersonal2)
        Me.GroupBox23.Controls.Add(Me.chkSolTelefonoPersonal1)
        Me.GroupBox23.Controls.Add(Me.chkNoIdentObligatoria)
        Me.GroupBox23.Controls.Add(Me.GroupBox16)
        Me.GroupBox23.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox23.Location = New System.Drawing.Point(10, 173)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(341, 198)
        Me.GroupBox23.TabIndex = 81
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "Solicitar información obligatoria en créditos"
        '
        'chkSolInformacionAdc
        '
        Me.chkSolInformacionAdc.AutoSize = True
        Me.chkSolInformacionAdc.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolInformacionAdc.Location = New System.Drawing.Point(6, 170)
        Me.chkSolInformacionAdc.Name = "chkSolInformacionAdc"
        Me.chkSolInformacionAdc.Size = New System.Drawing.Size(127, 17)
        Me.chkSolInformacionAdc.TabIndex = 75
        Me.chkSolInformacionAdc.Text = "Información adicional"
        Me.chkSolInformacionAdc.UseVisualStyleBackColor = True
        '
        'chkSolDireccionCompleta
        '
        Me.chkSolDireccionCompleta.AutoSize = True
        Me.chkSolDireccionCompleta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolDireccionCompleta.Location = New System.Drawing.Point(6, 70)
        Me.chkSolDireccionCompleta.Name = "chkSolDireccionCompleta"
        Me.chkSolDireccionCompleta.Size = New System.Drawing.Size(115, 17)
        Me.chkSolDireccionCompleta.TabIndex = 74
        Me.chkSolDireccionCompleta.Text = "Dirección completa"
        Me.chkSolDireccionCompleta.UseVisualStyleBackColor = True
        '
        'chkSolGarante
        '
        Me.chkSolGarante.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolGarante.Location = New System.Drawing.Point(6, 145)
        Me.chkSolGarante.Name = "chkSolGarante"
        Me.chkSolGarante.Size = New System.Drawing.Size(223, 19)
        Me.chkSolGarante.TabIndex = 73
        Me.chkSolGarante.Text = "Garante (Informaciones relacionadas)"
        Me.chkSolGarante.UseVisualStyleBackColor = True
        '
        'chkSolTelefonoPersonal2
        '
        Me.chkSolTelefonoPersonal2.AutoSize = True
        Me.chkSolTelefonoPersonal2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolTelefonoPersonal2.Location = New System.Drawing.Point(6, 120)
        Me.chkSolTelefonoPersonal2.Name = "chkSolTelefonoPersonal2"
        Me.chkSolTelefonoPersonal2.Size = New System.Drawing.Size(121, 17)
        Me.chkSolTelefonoPersonal2.TabIndex = 71
        Me.chkSolTelefonoPersonal2.Text = "Teléfono Personal 2"
        Me.chkSolTelefonoPersonal2.UseVisualStyleBackColor = True
        '
        'chkSolTelefonoPersonal1
        '
        Me.chkSolTelefonoPersonal1.AutoSize = True
        Me.chkSolTelefonoPersonal1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolTelefonoPersonal1.Location = New System.Drawing.Point(6, 95)
        Me.chkSolTelefonoPersonal1.Name = "chkSolTelefonoPersonal1"
        Me.chkSolTelefonoPersonal1.Size = New System.Drawing.Size(121, 17)
        Me.chkSolTelefonoPersonal1.TabIndex = 70
        Me.chkSolTelefonoPersonal1.Text = "Teléfono Personal 1"
        Me.chkSolTelefonoPersonal1.UseVisualStyleBackColor = True
        '
        'chkNoIdentObligatoria
        '
        Me.chkNoIdentObligatoria.AutoSize = True
        Me.chkNoIdentObligatoria.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkNoIdentObligatoria.Location = New System.Drawing.Point(10, 20)
        Me.chkNoIdentObligatoria.Name = "chkNoIdentObligatoria"
        Me.chkNoIdentObligatoria.Size = New System.Drawing.Size(232, 17)
        Me.chkNoIdentObligatoria.TabIndex = 28
        Me.chkNoIdentObligatoria.Text = "No. de identificación obligatoria en créditos"
        Me.chkNoIdentObligatoria.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.chkIdentificacionFisiscaObligatoria)
        Me.GroupBox16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox16.Location = New System.Drawing.Point(6, 23)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(273, 42)
        Me.GroupBox16.TabIndex = 70
        Me.GroupBox16.TabStop = False
        '
        'chkIdentificacionFisiscaObligatoria
        '
        Me.chkIdentificacionFisiscaObligatoria.AutoSize = True
        Me.chkIdentificacionFisiscaObligatoria.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkIdentificacionFisiscaObligatoria.Location = New System.Drawing.Point(44, 17)
        Me.chkIdentificacionFisiscaObligatoria.Name = "chkIdentificacionFisiscaObligatoria"
        Me.chkIdentificacionFisiscaObligatoria.Size = New System.Drawing.Size(186, 17)
        Me.chkIdentificacionFisiscaObligatoria.TabIndex = 69
        Me.chkIdentificacionFisiscaObligatoria.Text = "Copia de identificación obligatoria"
        Me.chkIdentificacionFisiscaObligatoria.UseVisualStyleBackColor = True
        '
        'ChkPermitirTarjetasFacturacion
        '
        Me.ChkPermitirTarjetasFacturacion.AutoSize = True
        Me.ChkPermitirTarjetasFacturacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkPermitirTarjetasFacturacion.Location = New System.Drawing.Point(10, 776)
        Me.ChkPermitirTarjetasFacturacion.Name = "ChkPermitirTarjetasFacturacion"
        Me.ChkPermitirTarjetasFacturacion.Size = New System.Drawing.Size(259, 17)
        Me.ChkPermitirTarjetasFacturacion.TabIndex = 80
        Me.ChkPermitirTarjetasFacturacion.Text = "No permitir transacciones con tarjetas de crédito"
        Me.ChkPermitirTarjetasFacturacion.UseVisualStyleBackColor = True
        '
        'chkBloqueoFacturacionSimultanea
        '
        Me.chkBloqueoFacturacionSimultanea.AutoSize = True
        Me.chkBloqueoFacturacionSimultanea.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBloqueoFacturacionSimultanea.Location = New System.Drawing.Point(10, 725)
        Me.chkBloqueoFacturacionSimultanea.Name = "chkBloqueoFacturacionSimultanea"
        Me.chkBloqueoFacturacionSimultanea.Size = New System.Drawing.Size(179, 17)
        Me.chkBloqueoFacturacionSimultanea.TabIndex = 79
        Me.chkBloqueoFacturacionSimultanea.Text = "Bloquear facturación simultánea"
        Me.chkBloqueoFacturacionSimultanea.UseVisualStyleBackColor = True
        '
        'chkControlMontoMinimoPagare
        '
        Me.chkControlMontoMinimoPagare.AutoSize = True
        Me.chkControlMontoMinimoPagare.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlMontoMinimoPagare.Location = New System.Drawing.Point(373, 747)
        Me.chkControlMontoMinimoPagare.Name = "chkControlMontoMinimoPagare"
        Me.chkControlMontoMinimoPagare.Size = New System.Drawing.Size(196, 17)
        Me.chkControlMontoMinimoPagare.TabIndex = 74
        Me.chkControlMontoMinimoPagare.Text = "Controlar monto mínimo de pagarés"
        Me.chkControlMontoMinimoPagare.UseVisualStyleBackColor = True
        '
        'chkControlCantidadCreditos
        '
        Me.chkControlCantidadCreditos.AutoSize = True
        Me.chkControlCantidadCreditos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlCantidadCreditos.Location = New System.Drawing.Point(373, 695)
        Me.chkControlCantidadCreditos.Name = "chkControlCantidadCreditos"
        Me.chkControlCantidadCreditos.Size = New System.Drawing.Size(218, 17)
        Me.chkControlCantidadCreditos.TabIndex = 73
        Me.chkControlCantidadCreditos.Text = "Controlar cantidad de facturas a crédito"
        Me.chkControlCantidadCreditos.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label74)
        Me.GroupBox19.Controls.Add(Me.txtMontoMinimoPagare)
        Me.GroupBox19.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox19.Location = New System.Drawing.Point(370, 748)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(317, 54)
        Me.GroupBox19.TabIndex = 77
        Me.GroupBox19.TabStop = False
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(6, 23)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(129, 13)
        Me.Label74.TabIndex = 78
        Me.Label74.Text = "Monto mínimo de pagarés"
        '
        'txtMontoMinimoPagare
        '
        Me.txtMontoMinimoPagare.Location = New System.Drawing.Point(202, 20)
        Me.txtMontoMinimoPagare.Name = "txtMontoMinimoPagare"
        Me.txtMontoMinimoPagare.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoMinimoPagare.TabIndex = 77
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.Label73)
        Me.GroupBox18.Controls.Add(Me.txtCantMaximaFacturasCredito)
        Me.GroupBox18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox18.Location = New System.Drawing.Point(370, 696)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(317, 50)
        Me.GroupBox18.TabIndex = 76
        Me.GroupBox18.TabStop = False
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(5, 22)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(176, 13)
        Me.Label73.TabIndex = 76
        Me.Label73.Text = "Cant. máxima de facturas a crédito"
        '
        'txtCantMaximaFacturasCredito
        '
        Me.txtCantMaximaFacturasCredito.Location = New System.Drawing.Point(201, 19)
        Me.txtCantMaximaFacturasCredito.Name = "txtCantMaximaFacturasCredito"
        Me.txtCantMaximaFacturasCredito.Size = New System.Drawing.Size(100, 20)
        Me.txtCantMaximaFacturasCredito.TabIndex = 75
        '
        'chkControlCantidadPagaresVencidos
        '
        Me.chkControlCantidadPagaresVencidos.AutoSize = True
        Me.chkControlCantidadPagaresVencidos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlCantidadPagaresVencidos.Location = New System.Drawing.Point(373, 635)
        Me.chkControlCantidadPagaresVencidos.Name = "chkControlCantidadPagaresVencidos"
        Me.chkControlCantidadPagaresVencidos.Size = New System.Drawing.Size(217, 17)
        Me.chkControlCantidadPagaresVencidos.TabIndex = 72
        Me.chkControlCantidadPagaresVencidos.Text = "Controlar cantidad de pagares vencidos"
        Me.chkControlCantidadPagaresVencidos.UseVisualStyleBackColor = True
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.Label72)
        Me.GroupBox17.Controls.Add(Me.txtCantMaximaPagaresVencidos)
        Me.GroupBox17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox17.Location = New System.Drawing.Point(370, 634)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(317, 61)
        Me.GroupBox17.TabIndex = 75
        Me.GroupBox17.TabStop = False
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(6, 29)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(175, 13)
        Me.Label72.TabIndex = 74
        Me.Label72.Text = "Cant. máxima de pagarés vencidos"
        '
        'txtCantMaximaPagaresVencidos
        '
        Me.txtCantMaximaPagaresVencidos.Location = New System.Drawing.Point(202, 26)
        Me.txtCantMaximaPagaresVencidos.Name = "txtCantMaximaPagaresVencidos"
        Me.txtCantMaximaPagaresVencidos.Size = New System.Drawing.Size(100, 20)
        Me.txtCantMaximaPagaresVencidos.TabIndex = 73
        '
        'chkObligacionSeriales
        '
        Me.chkObligacionSeriales.AutoSize = True
        Me.chkObligacionSeriales.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkObligacionSeriales.Location = New System.Drawing.Point(10, 652)
        Me.chkObligacionSeriales.Name = "chkObligacionSeriales"
        Me.chkObligacionSeriales.Size = New System.Drawing.Size(186, 17)
        Me.chkObligacionSeriales.TabIndex = 71
        Me.chkObligacionSeriales.Text = "Obligar la introducción de seriales"
        Me.chkObligacionSeriales.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label71)
        Me.GroupBox15.Controls.Add(Me.chkDarExpiracionPrefacturaciion)
        Me.GroupBox15.Controls.Add(Me.cbxVidaUtilPrefacturacion)
        Me.GroupBox15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox15.Location = New System.Drawing.Point(370, 541)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(317, 87)
        Me.GroupBox15.TabIndex = 68
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Validez de prefacturaciones"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(9, 50)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(92, 13)
        Me.Label71.TabIndex = 75
        Me.Label71.Text = "Tiempo de validez"
        '
        'chkDarExpiracionPrefacturaciion
        '
        Me.chkDarExpiracionPrefacturaciion.AutoSize = True
        Me.chkDarExpiracionPrefacturaciion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkDarExpiracionPrefacturaciion.Location = New System.Drawing.Point(8, 22)
        Me.chkDarExpiracionPrefacturaciion.Name = "chkDarExpiracionPrefacturaciion"
        Me.chkDarExpiracionPrefacturaciion.Size = New System.Drawing.Size(227, 17)
        Me.chkDarExpiracionPrefacturaciion.TabIndex = 74
        Me.chkDarExpiracionPrefacturaciion.Text = "Dar tiempo de expiración a prefacturación"
        Me.chkDarExpiracionPrefacturaciion.UseVisualStyleBackColor = True
        '
        'cbxVidaUtilPrefacturacion
        '
        Me.cbxVidaUtilPrefacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVidaUtilPrefacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVidaUtilPrefacturacion.FormattingEnabled = True
        Me.cbxVidaUtilPrefacturacion.Items.AddRange(New Object() {"Siempre", "12 horas ó 1/2 día", "24 horas ó  1 día", "48 horas ó 2 días", "96 horas ó 4 días", "192 horas ó 8 días", "360 horas ó 15 días", "720 horas ó 30 días", "1,440 horas ó 60 días"})
        Me.cbxVidaUtilPrefacturacion.Location = New System.Drawing.Point(118, 47)
        Me.cbxVidaUtilPrefacturacion.Name = "cbxVidaUtilPrefacturacion"
        Me.cbxVidaUtilPrefacturacion.Size = New System.Drawing.Size(121, 21)
        Me.cbxVidaUtilPrefacturacion.TabIndex = 0
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label70)
        Me.GroupBox14.Controls.Add(Me.dtpBlackFridayEnds)
        Me.GroupBox14.Controls.Add(Me.chkBlackFridayLiberarFacturacion)
        Me.GroupBox14.Controls.Add(Me.Label69)
        Me.GroupBox14.Controls.Add(Me.Label68)
        Me.GroupBox14.Controls.Add(Me.dtpBlackFridayStart)
        Me.GroupBox14.Controls.Add(Me.chkActivacionBlackFriday)
        Me.GroupBox14.Controls.Add(Me.SeparatorControl1)
        Me.GroupBox14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox14.Location = New System.Drawing.Point(370, 410)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(400, 125)
        Me.GroupBox14.TabIndex = 67
        Me.GroupBox14.TabStop = False
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label70.Location = New System.Drawing.Point(14, 100)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(35, 13)
        Me.Label70.TabIndex = 73
        Me.Label70.Text = "Hasta"
        '
        'dtpBlackFridayEnds
        '
        Me.dtpBlackFridayEnds.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpBlackFridayEnds.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpBlackFridayEnds.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBlackFridayEnds.Location = New System.Drawing.Point(55, 94)
        Me.dtpBlackFridayEnds.Name = "dtpBlackFridayEnds"
        Me.dtpBlackFridayEnds.Size = New System.Drawing.Size(164, 20)
        Me.dtpBlackFridayEnds.TabIndex = 72
        '
        'chkBlackFridayLiberarFacturacion
        '
        Me.chkBlackFridayLiberarFacturacion.AutoSize = True
        Me.chkBlackFridayLiberarFacturacion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBlackFridayLiberarFacturacion.Location = New System.Drawing.Point(8, 21)
        Me.chkBlackFridayLiberarFacturacion.Name = "chkBlackFridayLiberarFacturacion"
        Me.chkBlackFridayLiberarFacturacion.Size = New System.Drawing.Size(168, 17)
        Me.chkBlackFridayLiberarFacturacion.TabIndex = 71
        Me.chkBlackFridayLiberarFacturacion.Text = "Liberar precios en facturación"
        Me.chkBlackFridayLiberarFacturacion.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label69.Location = New System.Drawing.Point(14, 72)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(22, 13)
        Me.Label69.TabIndex = 69
        Me.Label69.Text = "Del"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label68.Location = New System.Drawing.Point(11, 46)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(94, 13)
        Me.Label68.TabIndex = 68
        Me.Label68.Text = "Validez del evento"
        '
        'dtpBlackFridayStart
        '
        Me.dtpBlackFridayStart.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.dtpBlackFridayStart.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpBlackFridayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBlackFridayStart.Location = New System.Drawing.Point(55, 66)
        Me.dtpBlackFridayStart.Name = "dtpBlackFridayStart"
        Me.dtpBlackFridayStart.Size = New System.Drawing.Size(164, 20)
        Me.dtpBlackFridayStart.TabIndex = 67
        '
        'chkActivacionBlackFriday
        '
        Me.chkActivacionBlackFriday.AutoSize = True
        Me.chkActivacionBlackFriday.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkActivacionBlackFriday.Location = New System.Drawing.Point(8, 0)
        Me.chkActivacionBlackFriday.Name = "chkActivacionBlackFriday"
        Me.chkActivacionBlackFriday.Size = New System.Drawing.Size(83, 17)
        Me.chkActivacionBlackFriday.TabIndex = 66
        Me.chkActivacionBlackFriday.Text = "Black Friday"
        Me.chkActivacionBlackFriday.UseVisualStyleBackColor = True
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(5, 30)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(389, 23)
        Me.SeparatorControl1.TabIndex = 74
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkModificacionArticuloBase)
        Me.GroupBox3.Controls.Add(Me.chkFacturacionSinInvArticuloBase)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(370, 341)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 67)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Modificación en artículo base"
        '
        'chkModificacionArticuloBase
        '
        Me.chkModificacionArticuloBase.AutoSize = True
        Me.chkModificacionArticuloBase.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkModificacionArticuloBase.Location = New System.Drawing.Point(8, 19)
        Me.chkModificacionArticuloBase.Name = "chkModificacionArticuloBase"
        Me.chkModificacionArticuloBase.Size = New System.Drawing.Size(303, 17)
        Me.chkModificacionArticuloBase.TabIndex = 63
        Me.chkModificacionArticuloBase.Text = "Habilitar modificación en facturación de artículo base No.1"
        Me.chkModificacionArticuloBase.UseVisualStyleBackColor = True
        '
        'chkFacturacionSinInvArticuloBase
        '
        Me.chkFacturacionSinInvArticuloBase.AutoSize = True
        Me.chkFacturacionSinInvArticuloBase.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFacturacionSinInvArticuloBase.Location = New System.Drawing.Point(8, 44)
        Me.chkFacturacionSinInvArticuloBase.Name = "chkFacturacionSinInvArticuloBase"
        Me.chkFacturacionSinInvArticuloBase.Size = New System.Drawing.Size(294, 17)
        Me.chkFacturacionSinInvArticuloBase.TabIndex = 64
        Me.chkFacturacionSinInvArticuloBase.Text = "Habilitar facturación sin inventario de artículo base No.1"
        Me.chkFacturacionSinInvArticuloBase.UseVisualStyleBackColor = True
        '
        'chkBloqueoImpresionRapida
        '
        Me.chkBloqueoImpresionRapida.AutoSize = True
        Me.chkBloqueoImpresionRapida.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBloqueoImpresionRapida.Location = New System.Drawing.Point(10, 627)
        Me.chkBloqueoImpresionRapida.Name = "chkBloqueoImpresionRapida"
        Me.chkBloqueoImpresionRapida.Size = New System.Drawing.Size(247, 17)
        Me.chkBloqueoImpresionRapida.TabIndex = 62
        Me.chkBloqueoImpresionRapida.Text = "Bloquear las impresiones rápidas en los cierres"
        Me.chkBloqueoImpresionRapida.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label37)
        Me.GroupBox11.Controls.Add(Me.GroupBox12)
        Me.GroupBox11.Controls.Add(Me.Label6)
        Me.GroupBox11.Controls.Add(Me.chkHabilitarCobroCargos)
        Me.GroupBox11.Controls.Add(Me.Label9)
        Me.GroupBox11.Controls.Add(Me.Label8)
        Me.GroupBox11.Controls.Add(Me.txtMoraDiaria)
        Me.GroupBox11.Controls.Add(Me.txtMoraAnual)
        Me.GroupBox11.Controls.Add(Me.txtMoraMensual)
        Me.GroupBox11.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox11.Location = New System.Drawing.Point(370, 6)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(400, 143)
        Me.GroupBox11.TabIndex = 61
        Me.GroupBox11.TabStop = False
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label37.Location = New System.Drawing.Point(9, 104)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(343, 36)
        Me.Label37.TabIndex = 26
        Me.Label37.Text = "Los cargos generados estarán en un registro único. No se podrán generar NCF por l" &
    "os mismos en los períodos fiscales."
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.chkGenerarNCFCargo)
        Me.GroupBox12.Controls.Add(Me.rdbUnicaMora)
        Me.GroupBox12.Controls.Add(Me.rdbMoraMensual)
        Me.GroupBox12.Location = New System.Drawing.Point(8, 46)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(345, 55)
        Me.GroupBox12.TabIndex = 11
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Tipo de agrupación"
        '
        'chkGenerarNCFCargo
        '
        Me.chkGenerarNCFCargo.Enabled = False
        Me.chkGenerarNCFCargo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkGenerarNCFCargo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.chkGenerarNCFCargo.Location = New System.Drawing.Point(146, 11)
        Me.chkGenerarNCFCargo.Name = "chkGenerarNCFCargo"
        Me.chkGenerarNCFCargo.Size = New System.Drawing.Size(194, 40)
        Me.chkGenerarNCFCargo.TabIndex = 60
        Me.chkGenerarNCFCargo.Text = "Generar comprobantes fiscales mensualmente en cargos"
        Me.chkGenerarNCFCargo.UseVisualStyleBackColor = True
        '
        'rdbUnicaMora
        '
        Me.rdbUnicaMora.AutoSize = True
        Me.rdbUnicaMora.Checked = True
        Me.rdbUnicaMora.Location = New System.Drawing.Point(6, 21)
        Me.rdbUnicaMora.Name = "rdbUnicaMora"
        Me.rdbUnicaMora.Size = New System.Drawing.Size(51, 17)
        Me.rdbUnicaMora.TabIndex = 1
        Me.rdbUnicaMora.TabStop = True
        Me.rdbUnicaMora.Text = "Única"
        Me.rdbUnicaMora.UseVisualStyleBackColor = True
        '
        'rdbMoraMensual
        '
        Me.rdbMoraMensual.AutoSize = True
        Me.rdbMoraMensual.Location = New System.Drawing.Point(67, 21)
        Me.rdbMoraMensual.Name = "rdbMoraMensual"
        Me.rdbMoraMensual.Size = New System.Drawing.Size(64, 17)
        Me.rdbMoraMensual.TabIndex = 0
        Me.rdbMoraMensual.Text = "Mensual"
        Me.rdbMoraMensual.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "% Mora Diaria"
        '
        'chkHabilitarCobroCargos
        '
        Me.chkHabilitarCobroCargos.AutoSize = True
        Me.chkHabilitarCobroCargos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkHabilitarCobroCargos.Location = New System.Drawing.Point(6, -1)
        Me.chkHabilitarCobroCargos.Name = "chkHabilitarCobroCargos"
        Me.chkHabilitarCobroCargos.Size = New System.Drawing.Size(146, 17)
        Me.chkHabilitarCobroCargos.TabIndex = 25
        Me.chkHabilitarCobroCargos.Text = "Habilitar cargos por mora"
        Me.chkHabilitarCobroCargos.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(257, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Anual"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Mensual"
        '
        'txtMoraDiaria
        '
        Me.txtMoraDiaria.Location = New System.Drawing.Point(86, 19)
        Me.txtMoraDiaria.Name = "txtMoraDiaria"
        Me.txtMoraDiaria.Size = New System.Drawing.Size(55, 20)
        Me.txtMoraDiaria.TabIndex = 3
        Me.txtMoraDiaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMoraAnual
        '
        Me.txtMoraAnual.Enabled = False
        Me.txtMoraAnual.Location = New System.Drawing.Point(297, 19)
        Me.txtMoraAnual.Name = "txtMoraAnual"
        Me.txtMoraAnual.ReadOnly = True
        Me.txtMoraAnual.Size = New System.Drawing.Size(56, 20)
        Me.txtMoraAnual.TabIndex = 8
        Me.txtMoraAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMoraMensual
        '
        Me.txtMoraMensual.Enabled = False
        Me.txtMoraMensual.Location = New System.Drawing.Point(202, 19)
        Me.txtMoraMensual.Name = "txtMoraMensual"
        Me.txtMoraMensual.ReadOnly = True
        Me.txtMoraMensual.Size = New System.Drawing.Size(49, 20)
        Me.txtMoraMensual.TabIndex = 7
        Me.txtMoraMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtDiasparaCerrarCredito)
        Me.GroupBox10.Controls.Add(Me.Label67)
        Me.GroupBox10.Controls.Add(Me.chkCerrarCreditoporAntiguedad)
        Me.GroupBox10.Controls.Add(Me.txtCargosMonto)
        Me.GroupBox10.Controls.Add(Me.chkCerrarCreditoconCargo)
        Me.GroupBox10.Controls.Add(Me.Label66)
        Me.GroupBox10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox10.Location = New System.Drawing.Point(370, 150)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(400, 73)
        Me.GroupBox10.TabIndex = 58
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Cierre de créditos"
        '
        'txtDiasparaCerrarCredito
        '
        Me.txtDiasparaCerrarCredito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDiasparaCerrarCredito.Location = New System.Drawing.Point(255, 46)
        Me.txtDiasparaCerrarCredito.Name = "txtDiasparaCerrarCredito"
        Me.txtDiasparaCerrarCredito.Size = New System.Drawing.Size(98, 20)
        Me.txtDiasparaCerrarCredito.TabIndex = 59
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label67.Location = New System.Drawing.Point(121, 49)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(119, 13)
        Me.Label67.TabIndex = 60
        Me.Label67.Text = "Cant. de días sin pagos"
        '
        'chkCerrarCreditoporAntiguedad
        '
        Me.chkCerrarCreditoporAntiguedad.AutoSize = True
        Me.chkCerrarCreditoporAntiguedad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCerrarCreditoporAntiguedad.Location = New System.Drawing.Point(8, 48)
        Me.chkCerrarCreditoporAntiguedad.Name = "chkCerrarCreditoporAntiguedad"
        Me.chkCerrarCreditoporAntiguedad.Size = New System.Drawing.Size(99, 17)
        Me.chkCerrarCreditoporAntiguedad.TabIndex = 58
        Me.chkCerrarCreditoporAntiguedad.Text = "Por antiguedad"
        Me.chkCerrarCreditoporAntiguedad.UseVisualStyleBackColor = True
        '
        'txtCargosMonto
        '
        Me.txtCargosMonto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCargosMonto.Location = New System.Drawing.Point(255, 18)
        Me.txtCargosMonto.Name = "txtCargosMonto"
        Me.txtCargosMonto.Size = New System.Drawing.Size(98, 20)
        Me.txtCargosMonto.TabIndex = 47
        '
        'chkCerrarCreditoconCargo
        '
        Me.chkCerrarCreditoconCargo.AutoSize = True
        Me.chkCerrarCreditoconCargo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCerrarCreditoconCargo.Location = New System.Drawing.Point(8, 22)
        Me.chkCerrarCreditoconCargo.Name = "chkCerrarCreditoconCargo"
        Me.chkCerrarCreditoconCargo.Size = New System.Drawing.Size(80, 17)
        Me.chkCerrarCreditoconCargo.TabIndex = 57
        Me.chkCerrarCreditoconCargo.Text = "Con cargos"
        Me.chkCerrarCreditoconCargo.UseVisualStyleBackColor = True
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label66.Location = New System.Drawing.Point(121, 23)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(95, 13)
        Me.Label66.TabIndex = 48
        Me.Label66.Text = "Por un monto de $"
        '
        'chkControlarventassinInicial
        '
        Me.chkControlarventassinInicial.AutoSize = True
        Me.chkControlarventassinInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarventassinInicial.Location = New System.Drawing.Point(10, 602)
        Me.chkControlarventassinInicial.Name = "chkControlarventassinInicial"
        Me.chkControlarventassinInicial.Size = New System.Drawing.Size(196, 17)
        Me.chkControlarventassinInicial.TabIndex = 56
        Me.chkControlarventassinInicial.Text = "Controlar ventas a crédito sin inicial"
        Me.chkControlarventassinInicial.UseVisualStyleBackColor = True
        '
        'chkHabModContenido
        '
        Me.chkHabModContenido.AutoSize = True
        Me.chkHabModContenido.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkHabModContenido.Location = New System.Drawing.Point(10, 147)
        Me.chkHabModContenido.Name = "chkHabModContenido"
        Me.chkHabModContenido.Size = New System.Drawing.Size(238, 17)
        Me.chkHabModContenido.TabIndex = 55
        Me.chkHabModContenido.Text = "Habilitar modificacion de contenido de precio"
        Me.chkHabModContenido.UseVisualStyleBackColor = True
        '
        'chkImponerRncTel
        '
        Me.chkImponerRncTel.AutoSize = True
        Me.chkImponerRncTel.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkImponerRncTel.Location = New System.Drawing.Point(10, 577)
        Me.chkImponerRncTel.Name = "chkImponerRncTel"
        Me.chkImponerRncTel.Size = New System.Drawing.Size(267, 17)
        Me.chkImponerRncTel.TabIndex = 54
        Me.chkImponerRncTel.Text = "Imponer RNC y teléfono en ventas con valor fiscal"
        Me.chkImponerRncTel.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtLimiteMaximoSolNombre)
        Me.GroupBox8.Controls.Add(Me.Label59)
        Me.GroupBox8.Controls.Add(Me.chkSolicitarNombreLimite)
        Me.GroupBox8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox8.Location = New System.Drawing.Point(370, 225)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(400, 54)
        Me.GroupBox8.TabIndex = 53
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "      Solicitar nombres de clientes al exceder"
        '
        'txtLimiteMaximoSolNombre
        '
        Me.txtLimiteMaximoSolNombre.Location = New System.Drawing.Point(186, 22)
        Me.txtLimiteMaximoSolNombre.Name = "txtLimiteMaximoSolNombre"
        Me.txtLimiteMaximoSolNombre.Size = New System.Drawing.Size(162, 20)
        Me.txtLimiteMaximoSolNombre.TabIndex = 47
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(32, 25)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(136, 13)
        Me.Label59.TabIndex = 48
        Me.Label59.Text = "Facturas por el monto de $"
        '
        'chkSolicitarNombreLimite
        '
        Me.chkSolicitarNombreLimite.AutoSize = True
        Me.chkSolicitarNombreLimite.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSolicitarNombreLimite.Location = New System.Drawing.Point(8, 0)
        Me.chkSolicitarNombreLimite.Name = "chkSolicitarNombreLimite"
        Me.chkSolicitarNombreLimite.Size = New System.Drawing.Size(15, 14)
        Me.chkSolicitarNombreLimite.TabIndex = 46
        Me.chkSolicitarNombreLimite.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label63)
        Me.GroupBox6.Controls.Add(Me.txtRelacionSalario)
        Me.GroupBox6.Controls.Add(Me.chkControlarMontoPagosxSalario)
        Me.GroupBox6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox6.Location = New System.Drawing.Point(370, 285)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(400, 54)
        Me.GroupBox6.TabIndex = 52
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "      Controlar montos de pagos con salarios"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(63, 24)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(106, 13)
        Me.Label63.TabIndex = 53
        Me.Label63.Text = "Relación al salario %"
        '
        'txtRelacionSalario
        '
        Me.txtRelacionSalario.Location = New System.Drawing.Point(186, 21)
        Me.txtRelacionSalario.Name = "txtRelacionSalario"
        Me.txtRelacionSalario.Size = New System.Drawing.Size(162, 20)
        Me.txtRelacionSalario.TabIndex = 53
        '
        'chkControlarMontoPagosxSalario
        '
        Me.chkControlarMontoPagosxSalario.AutoSize = True
        Me.chkControlarMontoPagosxSalario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkControlarMontoPagosxSalario.Location = New System.Drawing.Point(8, 0)
        Me.chkControlarMontoPagosxSalario.Name = "chkControlarMontoPagosxSalario"
        Me.chkControlarMontoPagosxSalario.Size = New System.Drawing.Size(15, 14)
        Me.chkControlarMontoPagosxSalario.TabIndex = 51
        Me.chkControlarMontoPagosxSalario.UseVisualStyleBackColor = True
        '
        'chkControlarFactMenores
        '
        Me.chkControlarFactMenores.AutoSize = True
        Me.chkControlarFactMenores.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarFactMenores.Location = New System.Drawing.Point(10, 552)
        Me.chkControlarFactMenores.Name = "chkControlarFactMenores"
        Me.chkControlarFactMenores.Size = New System.Drawing.Size(223, 17)
        Me.chkControlarFactMenores.TabIndex = 50
        Me.chkControlarFactMenores.Text = "Controlar facturación a menores de edad"
        Me.chkControlarFactMenores.UseVisualStyleBackColor = True
        '
        'chkControlarInfoTarjetas
        '
        Me.chkControlarInfoTarjetas.AutoSize = True
        Me.chkControlarInfoTarjetas.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkControlarInfoTarjetas.Location = New System.Drawing.Point(10, 527)
        Me.chkControlarInfoTarjetas.Name = "chkControlarInfoTarjetas"
        Me.chkControlarInfoTarjetas.Size = New System.Drawing.Size(236, 17)
        Me.chkControlarInfoTarjetas.TabIndex = 49
        Me.chkControlarInfoTarjetas.Text = "Controlar información de tarjetas de crédito"
        Me.chkControlarInfoTarjetas.UseVisualStyleBackColor = True
        '
        'chkGenerarPagares
        '
        Me.chkGenerarPagares.AutoSize = True
        Me.chkGenerarPagares.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkGenerarPagares.Location = New System.Drawing.Point(10, 502)
        Me.chkGenerarPagares.Name = "chkGenerarPagares"
        Me.chkGenerarPagares.Size = New System.Drawing.Size(209, 17)
        Me.chkGenerarPagares.TabIndex = 45
        Me.chkGenerarPagares.Text = "Generar los pagarés automáticamente"
        Me.chkGenerarPagares.UseVisualStyleBackColor = True
        '
        'chkCambiarFechaFact
        '
        Me.chkCambiarFechaFact.AutoSize = True
        Me.chkCambiarFechaFact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCambiarFechaFact.Location = New System.Drawing.Point(10, 477)
        Me.chkCambiarFechaFact.Name = "chkCambiarFechaFact"
        Me.chkCambiarFechaFact.Size = New System.Drawing.Size(166, 17)
        Me.chkCambiarFechaFact.TabIndex = 44
        Me.chkCambiarFechaFact.Text = "Permitir cambiar fecha y hora"
        Me.chkCambiarFechaFact.UseVisualStyleBackColor = True
        '
        'chkPedirAutCredito
        '
        Me.chkPedirAutCredito.AutoSize = True
        Me.chkPedirAutCredito.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPedirAutCredito.Location = New System.Drawing.Point(10, 452)
        Me.chkPedirAutCredito.Name = "chkPedirAutCredito"
        Me.chkPedirAutCredito.Size = New System.Drawing.Size(177, 17)
        Me.chkPedirAutCredito.TabIndex = 43
        Me.chkPedirAutCredito.Text = "Pedir autorización para créditos"
        Me.chkPedirAutCredito.UseVisualStyleBackColor = True
        '
        'chkPermCredSSol
        '
        Me.chkPermCredSSol.AutoSize = True
        Me.chkPermCredSSol.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermCredSSol.Location = New System.Drawing.Point(10, 402)
        Me.chkPermCredSSol.Name = "chkPermCredSSol"
        Me.chkPermCredSSol.Size = New System.Drawing.Size(224, 17)
        Me.chkPermCredSSol.TabIndex = 42
        Me.chkPermCredSSol.Text = "Permitir créditos sin contratos de solicitud"
        Me.chkPermCredSSol.UseVisualStyleBackColor = True
        '
        'chkPerCambioPlazoSol
        '
        Me.chkPerCambioPlazoSol.AutoSize = True
        Me.chkPerCambioPlazoSol.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerCambioPlazoSol.Location = New System.Drawing.Point(10, 427)
        Me.chkPerCambioPlazoSol.Name = "chkPerCambioPlazoSol"
        Me.chkPerCambioPlazoSol.Size = New System.Drawing.Size(275, 17)
        Me.chkPerCambioPlazoSol.TabIndex = 41
        Me.chkPerCambioPlazoSol.Text = "Permitir cambio de plazo de las solicitudes de crédito"
        Me.chkPerCambioPlazoSol.UseVisualStyleBackColor = True
        '
        'chkFacturarSExistencia
        '
        Me.chkFacturarSExistencia.AutoSize = True
        Me.chkFacturarSExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFacturarSExistencia.Location = New System.Drawing.Point(10, 5)
        Me.chkFacturarSExistencia.Name = "chkFacturarSExistencia"
        Me.chkFacturarSExistencia.Size = New System.Drawing.Size(200, 17)
        Me.chkFacturarSExistencia.TabIndex = 23
        Me.chkFacturarSExistencia.Text = "Facturar sin existencia en inventario"
        Me.chkFacturarSExistencia.UseVisualStyleBackColor = True
        '
        'chkMostpreciosFact
        '
        Me.chkMostpreciosFact.AutoSize = True
        Me.chkMostpreciosFact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostpreciosFact.Location = New System.Drawing.Point(10, 122)
        Me.chkMostpreciosFact.Name = "chkMostpreciosFact"
        Me.chkMostpreciosFact.Size = New System.Drawing.Size(230, 17)
        Me.chkMostpreciosFact.TabIndex = 22
        Me.chkMostpreciosFact.Text = "Mostrar precios de artículos en facturación"
        Me.chkMostpreciosFact.UseVisualStyleBackColor = True
        '
        'chkFactDebajoCosto
        '
        Me.chkFactDebajoCosto.AutoSize = True
        Me.chkFactDebajoCosto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFactDebajoCosto.Location = New System.Drawing.Point(10, 30)
        Me.chkFactDebajoCosto.Name = "chkFactDebajoCosto"
        Me.chkFactDebajoCosto.Size = New System.Drawing.Size(168, 17)
        Me.chkFactDebajoCosto.TabIndex = 21
        Me.chkFactDebajoCosto.Text = "Facturar por debajo del costo"
        Me.chkFactDebajoCosto.UseVisualStyleBackColor = True
        '
        'chkFactNCFAgotado
        '
        Me.chkFactNCFAgotado.AutoSize = True
        Me.chkFactNCFAgotado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkFactNCFAgotado.Location = New System.Drawing.Point(10, 76)
        Me.chkFactNCFAgotado.Name = "chkFactNCFAgotado"
        Me.chkFactNCFAgotado.Size = New System.Drawing.Size(222, 17)
        Me.chkFactNCFAgotado.TabIndex = 26
        Me.chkFactNCFAgotado.Text = "Facturar con los comprobantes agotados"
        Me.chkFactNCFAgotado.UseVisualStyleBackColor = True
        '
        'chkPermitirDevoSucursal
        '
        Me.chkPermitirDevoSucursal.AutoSize = True
        Me.chkPermitirDevoSucursal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirDevoSucursal.Location = New System.Drawing.Point(10, 377)
        Me.chkPermitirDevoSucursal.Name = "chkPermitirDevoSucursal"
        Me.chkPermitirDevoSucursal.Size = New System.Drawing.Size(230, 17)
        Me.chkPermitirDevoSucursal.TabIndex = 29
        Me.chkPermitirDevoSucursal.Text = "Permitir devoluciones en cualquier sucursal"
        Me.chkPermitirDevoSucursal.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkCodigoPrimarioClientes)
        Me.TabPage3.Controls.Add(Me.CheckBox1)
        Me.TabPage3.Controls.Add(Me.chkCXCFormatoLargo)
        Me.TabPage3.Controls.Add(Me.chkPermitirCobrosTarjeta)
        Me.TabPage3.Controls.Add(Me.GroupBox13)
        Me.TabPage3.Controls.Add(Me.Label42)
        Me.TabPage3.Controls.Add(Me.txtCantRevisionNombre)
        Me.TabPage3.Controls.Add(Me.chkShowIncompletesInfoClientes)
        Me.TabPage3.Controls.Add(Me.chkCambiarFechaRecibos)
        Me.TabPage3.Controls.Add(Me.txtUltimaActCXC)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.chkEvitDomingos)
        Me.TabPage3.Controls.Add(Me.chkMultiplesCliRec)
        Me.TabPage3.Controls.Add(Me.chkShowPagaresenCobro)
        Me.TabPage3.Controls.Add(Me.chkEvitSabados)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(803, 479)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuentas por Cobrar"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkCodigoPrimarioClientes
        '
        Me.chkCodigoPrimarioClientes.AutoSize = True
        Me.chkCodigoPrimarioClientes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCodigoPrimarioClientes.Location = New System.Drawing.Point(12, 210)
        Me.chkCodigoPrimarioClientes.Name = "chkCodigoPrimarioClientes"
        Me.chkCodigoPrimarioClientes.Size = New System.Drawing.Size(208, 17)
        Me.chkCodigoPrimarioClientes.TabIndex = 58
        Me.chkCodigoPrimarioClientes.Text = "Bloquear el código primario de clientes"
        Me.chkCodigoPrimarioClientes.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(12, 330)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(265, 17)
        Me.CheckBox1.TabIndex = 57
        Me.CheckBox1.Text = "Evitar abreviaciones en mantenimiento de clientes"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkCXCFormatoLargo
        '
        Me.chkCXCFormatoLargo.AutoSize = True
        Me.chkCXCFormatoLargo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCXCFormatoLargo.Location = New System.Drawing.Point(12, 187)
        Me.chkCXCFormatoLargo.Name = "chkCXCFormatoLargo"
        Me.chkCXCFormatoLargo.Size = New System.Drawing.Size(226, 17)
        Me.chkCXCFormatoLargo.TabIndex = 56
        Me.chkCXCFormatoLargo.Text = "Mostrar días de facturas en formato largo"
        Me.chkCXCFormatoLargo.UseVisualStyleBackColor = True
        '
        'chkPermitirCobrosTarjeta
        '
        Me.chkPermitirCobrosTarjeta.AutoSize = True
        Me.chkPermitirCobrosTarjeta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirCobrosTarjeta.Location = New System.Drawing.Point(12, 37)
        Me.chkPermitirCobrosTarjeta.Name = "chkPermitirCobrosTarjeta"
        Me.chkPermitirCobrosTarjeta.Size = New System.Drawing.Size(249, 17)
        Me.chkPermitirCobrosTarjeta.TabIndex = 55
        Me.chkPermitirCobrosTarjeta.Text = "Permitir cobros con tarjetas de crédito / débito"
        Me.chkPermitirCobrosTarjeta.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.chkControlarDescuentos)
        Me.GroupBox13.Controls.Add(Me.txtLimiteDescuentos)
        Me.GroupBox13.Controls.Add(Me.Label61)
        Me.GroupBox13.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox13.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(200, 55)
        Me.GroupBox13.TabIndex = 54
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Controlar descuentos de CXC"
        '
        'chkControlarDescuentos
        '
        Me.chkControlarDescuentos.AutoSize = True
        Me.chkControlarDescuentos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkControlarDescuentos.Location = New System.Drawing.Point(177, 0)
        Me.chkControlarDescuentos.Name = "chkControlarDescuentos"
        Me.chkControlarDescuentos.Size = New System.Drawing.Size(15, 14)
        Me.chkControlarDescuentos.TabIndex = 46
        Me.chkControlarDescuentos.UseVisualStyleBackColor = True
        '
        'txtLimiteDescuentos
        '
        Me.txtLimiteDescuentos.Location = New System.Drawing.Point(101, 22)
        Me.txtLimiteDescuentos.Name = "txtLimiteDescuentos"
        Me.txtLimiteDescuentos.Size = New System.Drawing.Size(91, 20)
        Me.txtLimiteDescuentos.TabIndex = 49
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(9, 25)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(73, 13)
        Me.Label61.TabIndex = 50
        Me.Label61.Text = "Límite máximo"
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label42.Location = New System.Drawing.Point(103, 293)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(166, 34)
        Me.Label42.TabIndex = 53
        Me.Label42.Text = "Cant. de registros para revisar nombres y apellidos"
        '
        'txtCantRevisionNombre
        '
        Me.txtCantRevisionNombre.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantRevisionNombre.Location = New System.Drawing.Point(12, 297)
        Me.txtCantRevisionNombre.Name = "txtCantRevisionNombre"
        Me.txtCantRevisionNombre.Size = New System.Drawing.Size(85, 20)
        Me.txtCantRevisionNombre.TabIndex = 52
        Me.txtCantRevisionNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkShowIncompletesInfoClientes
        '
        Me.chkShowIncompletesInfoClientes.AutoSize = True
        Me.chkShowIncompletesInfoClientes.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkShowIncompletesInfoClientes.Location = New System.Drawing.Point(12, 12)
        Me.chkShowIncompletesInfoClientes.Name = "chkShowIncompletesInfoClientes"
        Me.chkShowIncompletesInfoClientes.Size = New System.Drawing.Size(229, 17)
        Me.chkShowIncompletesInfoClientes.TabIndex = 51
        Me.chkShowIncompletesInfoClientes.Text = "Mostrar información incompleta en clientes"
        Me.chkShowIncompletesInfoClientes.UseVisualStyleBackColor = True
        '
        'chkCambiarFechaRecibos
        '
        Me.chkCambiarFechaRecibos.AutoSize = True
        Me.chkCambiarFechaRecibos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkCambiarFechaRecibos.Location = New System.Drawing.Point(12, 162)
        Me.chkCambiarFechaRecibos.Name = "chkCambiarFechaRecibos"
        Me.chkCambiarFechaRecibos.Size = New System.Drawing.Size(166, 17)
        Me.chkCambiarFechaRecibos.TabIndex = 45
        Me.chkCambiarFechaRecibos.Text = "Permitir cambiar fecha y hora"
        Me.chkCambiarFechaRecibos.UseVisualStyleBackColor = True
        '
        'txtUltimaActCXC
        '
        Me.txtUltimaActCXC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUltimaActCXC.Enabled = False
        Me.txtUltimaActCXC.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUltimaActCXC.Location = New System.Drawing.Point(6912, 4865)
        Me.txtUltimaActCXC.Name = "txtUltimaActCXC"
        Me.txtUltimaActCXC.ReadOnly = True
        Me.txtUltimaActCXC.Size = New System.Drawing.Size(122, 20)
        Me.txtUltimaActCXC.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label18.Location = New System.Drawing.Point(6799, 4868)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Última Actualiz. CXC:"
        '
        'chkEvitDomingos
        '
        Me.chkEvitDomingos.AutoSize = True
        Me.chkEvitDomingos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkEvitDomingos.Location = New System.Drawing.Point(12, 112)
        Me.chkEvitDomingos.Name = "chkEvitDomingos"
        Me.chkEvitDomingos.Size = New System.Drawing.Size(182, 17)
        Me.chkEvitDomingos.TabIndex = 29
        Me.chkEvitDomingos.Text = "Evitar domingos en vencimientos"
        Me.chkEvitDomingos.UseVisualStyleBackColor = True
        '
        'chkMultiplesCliRec
        '
        Me.chkMultiplesCliRec.AutoSize = True
        Me.chkMultiplesCliRec.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMultiplesCliRec.Location = New System.Drawing.Point(12, 137)
        Me.chkMultiplesCliRec.Name = "chkMultiplesCliRec"
        Me.chkMultiplesCliRec.Size = New System.Drawing.Size(203, 17)
        Me.chkMultiplesCliRec.TabIndex = 20
        Me.chkMultiplesCliRec.Text = "Múltiples clientes en recibos de cobro"
        Me.chkMultiplesCliRec.UseVisualStyleBackColor = True
        '
        'chkShowPagaresenCobro
        '
        Me.chkShowPagaresenCobro.AutoSize = True
        Me.chkShowPagaresenCobro.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkShowPagaresenCobro.Location = New System.Drawing.Point(12, 62)
        Me.chkShowPagaresenCobro.Name = "chkShowPagaresenCobro"
        Me.chkShowPagaresenCobro.Size = New System.Drawing.Size(197, 17)
        Me.chkShowPagaresenCobro.TabIndex = 40
        Me.chkShowPagaresenCobro.Text = "Mostrar tabla de pagarés en cobros"
        Me.chkShowPagaresenCobro.UseVisualStyleBackColor = True
        '
        'chkEvitSabados
        '
        Me.chkEvitSabados.AutoSize = True
        Me.chkEvitSabados.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkEvitSabados.Location = New System.Drawing.Point(12, 87)
        Me.chkEvitSabados.Name = "chkEvitSabados"
        Me.chkEvitSabados.Size = New System.Drawing.Size(177, 17)
        Me.chkEvitSabados.TabIndex = 28
        Me.chkEvitSabados.Text = "Evitar sábados en vencimientos"
        Me.chkEvitSabados.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.chkVisualDigitalesCXP)
        Me.TabPage4.Controls.Add(Me.chkAumentarPreciosRelacionCOsto)
        Me.TabPage4.Controls.Add(Me.chkLlenarListadoProductos)
        Me.TabPage4.Controls.Add(Me.cbkActPreciosMedidas)
        Me.TabPage4.Controls.Add(Me.chkRedondearPreciosPiezaje)
        Me.TabPage4.Controls.Add(Me.chkGuardarCalculosPiezaje)
        Me.TabPage4.Controls.Add(Me.chkGuardarAutPietaje)
        Me.TabPage4.Controls.Add(Me.chkLlenarAutVerificacionSub)
        Me.TabPage4.Controls.Add(Me.chkSolConfRecCompra)
        Me.TabPage4.Controls.Add(Me.GroupBox27)
        Me.TabPage4.Controls.Add(Me.chkPermitirDuplicidadCompras)
        Me.TabPage4.Controls.Add(Me.Label79)
        Me.TabPage4.Controls.Add(Me.txtCantDecimales)
        Me.TabPage4.Controls.Add(Me.chkRevalidarTotales)
        Me.TabPage4.Controls.Add(Me.chkAvisarIncosistencia)
        Me.TabPage4.Controls.Add(Me.chkActSupenArt)
        Me.TabPage4.Controls.Add(Me.chkActCostos)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(803, 479)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Compras"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'chkVisualDigitalesCXP
        '
        Me.chkVisualDigitalesCXP.AutoSize = True
        Me.chkVisualDigitalesCXP.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkVisualDigitalesCXP.Location = New System.Drawing.Point(14, 347)
        Me.chkVisualDigitalesCXP.Name = "chkVisualDigitalesCXP"
        Me.chkVisualDigitalesCXP.Size = New System.Drawing.Size(316, 17)
        Me.chkVisualDigitalesCXP.TabIndex = 363
        Me.chkVisualDigitalesCXP.Text = "Visualizar controles para subir digitales de cuentas por pagar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkVisualDigitalesCXP.UseVisualStyleBackColor = True
        '
        'chkAumentarPreciosRelacionCOsto
        '
        Me.chkAumentarPreciosRelacionCOsto.AutoSize = True
        Me.chkAumentarPreciosRelacionCOsto.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkAumentarPreciosRelacionCOsto.Location = New System.Drawing.Point(14, 33)
        Me.chkAumentarPreciosRelacionCOsto.Name = "chkAumentarPreciosRelacionCOsto"
        Me.chkAumentarPreciosRelacionCOsto.Size = New System.Drawing.Size(250, 17)
        Me.chkAumentarPreciosRelacionCOsto.TabIndex = 362
        Me.chkAumentarPreciosRelacionCOsto.Text = "Aumentar precios de venta al aumentar costos"
        Me.chkAumentarPreciosRelacionCOsto.UseVisualStyleBackColor = True
        '
        'chkLlenarListadoProductos
        '
        Me.chkLlenarListadoProductos.AutoSize = True
        Me.chkLlenarListadoProductos.Location = New System.Drawing.Point(14, 324)
        Me.chkLlenarListadoProductos.Name = "chkLlenarListadoProductos"
        Me.chkLlenarListadoProductos.Size = New System.Drawing.Size(312, 17)
        Me.chkLlenarListadoProductos.TabIndex = 361
        Me.chkLlenarListadoProductos.Text = "Llenar automaticamente listado de artículos con grupo único"
        Me.chkLlenarListadoProductos.UseVisualStyleBackColor = True
        '
        'cbkActPreciosMedidas
        '
        Me.cbkActPreciosMedidas.AutoSize = True
        Me.cbkActPreciosMedidas.Location = New System.Drawing.Point(14, 301)
        Me.cbkActPreciosMedidas.Name = "cbkActPreciosMedidas"
        Me.cbkActPreciosMedidas.Size = New System.Drawing.Size(360, 17)
        Me.cbkActPreciosMedidas.TabIndex = 360
        Me.cbkActPreciosMedidas.Text = "Actualizar precios de todas las medidas al aumentar costos de compra"
        Me.cbkActPreciosMedidas.UseVisualStyleBackColor = True
        '
        'chkRedondearPreciosPiezaje
        '
        Me.chkRedondearPreciosPiezaje.AutoSize = True
        Me.chkRedondearPreciosPiezaje.Location = New System.Drawing.Point(14, 232)
        Me.chkRedondearPreciosPiezaje.Name = "chkRedondearPreciosPiezaje"
        Me.chkRedondearPreciosPiezaje.Size = New System.Drawing.Size(328, 17)
        Me.chkRedondearPreciosPiezaje.TabIndex = 359
        Me.chkRedondearPreciosPiezaje.Text = "Redondear durante cálculo de precios y costos durante piezaje"
        Me.chkRedondearPreciosPiezaje.UseVisualStyleBackColor = True
        '
        'chkGuardarCalculosPiezaje
        '
        Me.chkGuardarCalculosPiezaje.AutoSize = True
        Me.chkGuardarCalculosPiezaje.Location = New System.Drawing.Point(14, 278)
        Me.chkGuardarCalculosPiezaje.Name = "chkGuardarCalculosPiezaje"
        Me.chkGuardarCalculosPiezaje.Size = New System.Drawing.Size(359, 17)
        Me.chkGuardarCalculosPiezaje.TabIndex = 358
        Me.chkGuardarCalculosPiezaje.Text = "Guardar automáticamente cálculo de costos y precios durante piezaje"
        Me.chkGuardarCalculosPiezaje.UseVisualStyleBackColor = True
        '
        'chkGuardarAutPietaje
        '
        Me.chkGuardarAutPietaje.AutoSize = True
        Me.chkGuardarAutPietaje.Location = New System.Drawing.Point(14, 255)
        Me.chkGuardarAutPietaje.Name = "chkGuardarAutPietaje"
        Me.chkGuardarAutPietaje.Size = New System.Drawing.Size(373, 17)
        Me.chkGuardarAutPietaje.TabIndex = 357
        Me.chkGuardarAutPietaje.Text = "Guardar automáticamente el piezaje de artículos durante su modificación"
        Me.chkGuardarAutPietaje.UseVisualStyleBackColor = True
        '
        'chkLlenarAutVerificacionSub
        '
        Me.chkLlenarAutVerificacionSub.AutoSize = True
        Me.chkLlenarAutVerificacionSub.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkLlenarAutVerificacionSub.Location = New System.Drawing.Point(14, 209)
        Me.chkLlenarAutVerificacionSub.Name = "chkLlenarAutVerificacionSub"
        Me.chkLlenarAutVerificacionSub.Size = New System.Drawing.Size(318, 17)
        Me.chkLlenarAutVerificacionSub.TabIndex = 97
        Me.chkLlenarAutVerificacionSub.Text = "Llenar automáticamente durante la verificación de subtotales"
        Me.chkLlenarAutVerificacionSub.UseVisualStyleBackColor = True
        '
        'chkSolConfRecCompra
        '
        Me.chkSolConfRecCompra.AutoSize = True
        Me.chkSolConfRecCompra.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSolConfRecCompra.Location = New System.Drawing.Point(14, 186)
        Me.chkSolConfRecCompra.Name = "chkSolConfRecCompra"
        Me.chkSolConfRecCompra.Size = New System.Drawing.Size(248, 17)
        Me.chkSolConfRecCompra.TabIndex = 96
        Me.chkSolConfRecCompra.Text = "Solicitar confirmación de recepción en compras"
        Me.chkSolConfRecCompra.UseVisualStyleBackColor = True
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.Label84)
        Me.GroupBox27.Controls.Add(Me.Panel5)
        Me.GroupBox27.Controls.Add(Me.TrackBarCompras)
        Me.GroupBox27.Location = New System.Drawing.Point(420, 10)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(173, 158)
        Me.GroupBox27.TabIndex = 95
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Tamaños de imágenes"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.Location = New System.Drawing.Point(9, 139)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(49, 13)
        Me.Label84.TabIndex = 4
        Me.Label84.Text = "Compras"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.PicCompras)
        Me.Panel5.Location = New System.Drawing.Point(8, 18)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(120, 120)
        Me.Panel5.TabIndex = 2
        '
        'PicCompras
        '
        Me.PicCompras.Image = Global.Libregco.My.Resources.Resources.No_Image
        Me.PicCompras.Location = New System.Drawing.Point(0, 0)
        Me.PicCompras.Name = "PicCompras"
        Me.PicCompras.Size = New System.Drawing.Size(120, 120)
        Me.PicCompras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicCompras.TabIndex = 3
        Me.PicCompras.TabStop = False
        '
        'TrackBarCompras
        '
        Me.TrackBarCompras.LargeChange = 15
        Me.TrackBarCompras.Location = New System.Drawing.Point(131, 16)
        Me.TrackBarCompras.Maximum = 120
        Me.TrackBarCompras.Minimum = 15
        Me.TrackBarCompras.Name = "TrackBarCompras"
        Me.TrackBarCompras.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarCompras.Size = New System.Drawing.Size(45, 120)
        Me.TrackBarCompras.TabIndex = 1
        Me.TrackBarCompras.Value = 120
        '
        'chkPermitirDuplicidadCompras
        '
        Me.chkPermitirDuplicidadCompras.AutoSize = True
        Me.chkPermitirDuplicidadCompras.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPermitirDuplicidadCompras.Location = New System.Drawing.Point(14, 163)
        Me.chkPermitirDuplicidadCompras.Name = "chkPermitirDuplicidadCompras"
        Me.chkPermitirDuplicidadCompras.Size = New System.Drawing.Size(271, 17)
        Me.chkPermitirDuplicidadCompras.TabIndex = 52
        Me.chkPermitirDuplicidadCompras.Text = "Permitir duplicidad en registro de artículos compras "
        Me.chkPermitirDuplicidadCompras.UseVisualStyleBackColor = True
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label79.Location = New System.Drawing.Point(11, 136)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(149, 13)
        Me.Label79.TabIndex = 51
        Me.Label79.Text = "Cant. de decimales a manejar"
        '
        'txtCantDecimales
        '
        Me.txtCantDecimales.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtCantDecimales.Location = New System.Drawing.Point(166, 134)
        Me.txtCantDecimales.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtCantDecimales.Name = "txtCantDecimales"
        Me.txtCantDecimales.Size = New System.Drawing.Size(61, 20)
        Me.txtCantDecimales.TabIndex = 41
        Me.txtCantDecimales.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'chkRevalidarTotales
        '
        Me.chkRevalidarTotales.AutoSize = True
        Me.chkRevalidarTotales.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkRevalidarTotales.Location = New System.Drawing.Point(14, 108)
        Me.chkRevalidarTotales.Name = "chkRevalidarTotales"
        Me.chkRevalidarTotales.Size = New System.Drawing.Size(165, 17)
        Me.chkRevalidarTotales.TabIndex = 40
        Me.chkRevalidarTotales.Text = "Revalidar totales de compras"
        Me.chkRevalidarTotales.UseVisualStyleBackColor = True
        '
        'chkAvisarIncosistencia
        '
        Me.chkAvisarIncosistencia.AutoSize = True
        Me.chkAvisarIncosistencia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkAvisarIncosistencia.Location = New System.Drawing.Point(14, 83)
        Me.chkAvisarIncosistencia.Name = "chkAvisarIncosistencia"
        Me.chkAvisarIncosistencia.Size = New System.Drawing.Size(207, 17)
        Me.chkAvisarIncosistencia.TabIndex = 39
        Me.chkAvisarIncosistencia.Text = "Dar aviso de incosistencia de compras"
        Me.chkAvisarIncosistencia.UseVisualStyleBackColor = True
        '
        'chkActSupenArt
        '
        Me.chkActSupenArt.AutoSize = True
        Me.chkActSupenArt.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkActSupenArt.Location = New System.Drawing.Point(14, 58)
        Me.chkActSupenArt.Name = "chkActSupenArt"
        Me.chkActSupenArt.Size = New System.Drawing.Size(229, 17)
        Me.chkActSupenArt.TabIndex = 30
        Me.chkActSupenArt.Text = "Actualizar suplidor de artículos en compras"
        Me.chkActSupenArt.UseVisualStyleBackColor = True
        '
        'chkActCostos
        '
        Me.chkActCostos.AutoSize = True
        Me.chkActCostos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkActCostos.Location = New System.Drawing.Point(14, 10)
        Me.chkActCostos.Name = "chkActCostos"
        Me.chkActCostos.Size = New System.Drawing.Size(165, 17)
        Me.chkActCostos.TabIndex = 27
        Me.chkActCostos.Text = "Actualizar costos en compras"
        Me.chkActCostos.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.chkDeshabilitarVerificacionCorreo)
        Me.TabPage5.Controls.Add(Me.chkBloquearUsuarios)
        Me.TabPage5.Controls.Add(Me.chkMultipleUsuarios)
        Me.TabPage5.Controls.Add(Me.chkMostrarBotonAsistenciaInicio)
        Me.TabPage5.Controls.Add(Me.txtDiasGuardarBitacora)
        Me.TabPage5.Controls.Add(Me.Label60)
        Me.TabPage5.Controls.Add(Me.Button1)
        Me.TabPage5.Controls.Add(Me.chkModificarModal)
        Me.TabPage5.Controls.Add(Me.chkPerContraerEncInicio)
        Me.TabPage5.Controls.Add(Me.Label65)
        Me.TabPage5.Controls.Add(Me.Label64)
        Me.TabPage5.Controls.Add(Me.txtDiasUtilesPassword)
        Me.TabPage5.Controls.Add(Me.txtTiempoInactividad)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.chkPerDesactivarAudio)
        Me.TabPage5.Controls.Add(Me.chkPerDeshBloqueoInact)
        Me.TabPage5.Controls.Add(Me.chkPerDeshInicioAutomatico)
        Me.TabPage5.Controls.Add(Me.ChkPerDeshConsejos)
        Me.TabPage5.Controls.Add(Me.chkPerDeshConNotify)
        Me.TabPage5.Controls.Add(Me.chkPerDeshNotificaciones)
        Me.TabPage5.Controls.Add(Me.chkLimPassLife)
        Me.TabPage5.Controls.Add(Me.chkMostrarUsuarios)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(803, 479)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Usuarios"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'chkDeshabilitarVerificacionCorreo
        '
        Me.chkDeshabilitarVerificacionCorreo.AutoSize = True
        Me.chkDeshabilitarVerificacionCorreo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkDeshabilitarVerificacionCorreo.Location = New System.Drawing.Point(11, 394)
        Me.chkDeshabilitarVerificacionCorreo.Name = "chkDeshabilitarVerificacionCorreo"
        Me.chkDeshabilitarVerificacionCorreo.Size = New System.Drawing.Size(254, 17)
        Me.chkDeshabilitarVerificacionCorreo.TabIndex = 62
        Me.chkDeshabilitarVerificacionCorreo.Text = "Deshabilitar la verificación de correo electrónico"
        Me.chkDeshabilitarVerificacionCorreo.UseVisualStyleBackColor = True
        '
        'chkBloquearUsuarios
        '
        Me.chkBloquearUsuarios.AutoSize = True
        Me.chkBloquearUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkBloquearUsuarios.Location = New System.Drawing.Point(11, 450)
        Me.chkBloquearUsuarios.Name = "chkBloquearUsuarios"
        Me.chkBloquearUsuarios.Size = New System.Drawing.Size(191, 17)
        Me.chkBloquearUsuarios.TabIndex = 108
        Me.chkBloquearUsuarios.Text = "Bloquear usuarios al fallar intentos"
        Me.chkBloquearUsuarios.UseVisualStyleBackColor = True
        '
        'chkMultipleUsuarios
        '
        Me.chkMultipleUsuarios.AutoSize = True
        Me.chkMultipleUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMultipleUsuarios.Location = New System.Drawing.Point(11, 371)
        Me.chkMultipleUsuarios.Name = "chkMultipleUsuarios"
        Me.chkMultipleUsuarios.Size = New System.Drawing.Size(195, 17)
        Me.chkMultipleUsuarios.TabIndex = 61
        Me.chkMultipleUsuarios.Text = "Permitir acceso múltiple de usuarios"
        Me.chkMultipleUsuarios.UseVisualStyleBackColor = True
        '
        'chkMostrarBotonAsistenciaInicio
        '
        Me.chkMostrarBotonAsistenciaInicio.AutoSize = True
        Me.chkMostrarBotonAsistenciaInicio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarBotonAsistenciaInicio.Location = New System.Drawing.Point(11, 348)
        Me.chkMostrarBotonAsistenciaInicio.Name = "chkMostrarBotonAsistenciaInicio"
        Me.chkMostrarBotonAsistenciaInicio.Size = New System.Drawing.Size(210, 17)
        Me.chkMostrarBotonAsistenciaInicio.TabIndex = 60
        Me.chkMostrarBotonAsistenciaInicio.Text = "Mostrar entrada de asistencia en inicio"
        Me.chkMostrarBotonAsistenciaInicio.UseVisualStyleBackColor = True
        '
        'txtDiasGuardarBitacora
        '
        Me.txtDiasGuardarBitacora.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDiasGuardarBitacora.Location = New System.Drawing.Point(212, 316)
        Me.txtDiasGuardarBitacora.Name = "txtDiasGuardarBitacora"
        Me.txtDiasGuardarBitacora.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasGuardarBitacora.TabIndex = 58
        Me.txtDiasGuardarBitacora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label60.Location = New System.Drawing.Point(8, 319)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(189, 13)
        Me.Label60.TabIndex = 59
        Me.Label60.Text = "Cant. de días a guardar de la bitácora"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Button1.Location = New System.Drawing.Point(6, 421)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(178, 23)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "Accesos y bitácoras"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkModificarModal
        '
        Me.chkModificarModal.AutoSize = True
        Me.chkModificarModal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkModificarModal.Location = New System.Drawing.Point(11, 288)
        Me.chkModificarModal.Name = "chkModificarModal"
        Me.chkModificarModal.Size = New System.Drawing.Size(214, 17)
        Me.chkModificarModal.TabIndex = 57
        Me.chkModificarModal.Text = "Permitir modificar modal top del sistema"
        Me.chkModificarModal.UseVisualStyleBackColor = True
        '
        'chkPerContraerEncInicio
        '
        Me.chkPerContraerEncInicio.AutoSize = True
        Me.chkPerContraerEncInicio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerContraerEncInicio.Location = New System.Drawing.Point(11, 263)
        Me.chkPerContraerEncInicio.Name = "chkPerContraerEncInicio"
        Me.chkPerContraerEncInicio.Size = New System.Drawing.Size(210, 17)
        Me.chkPerContraerEncInicio.TabIndex = 56
        Me.chkPerContraerEncInicio.Text = "Permitir contraer encabezado del inicio"
        Me.chkPerContraerEncInicio.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label65.Location = New System.Drawing.Point(318, 211)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(44, 13)
        Me.Label65.TabIndex = 55
        Me.Label65.Text = "minutos"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label64.Location = New System.Drawing.Point(8, 211)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(176, 13)
        Me.Label64.TabIndex = 54
        Me.Label64.Text = "Tiempo de inactividad para bloqueo"
        '
        'txtDiasUtilesPassword
        '
        Me.txtDiasUtilesPassword.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtDiasUtilesPassword.Location = New System.Drawing.Point(212, 57)
        Me.txtDiasUtilesPassword.Name = "txtDiasUtilesPassword"
        Me.txtDiasUtilesPassword.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasUtilesPassword.TabIndex = 7
        Me.txtDiasUtilesPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTiempoInactividad
        '
        Me.txtTiempoInactividad.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtTiempoInactividad.Location = New System.Drawing.Point(212, 208)
        Me.txtTiempoInactividad.Name = "txtTiempoInactividad"
        Me.txtTiempoInactividad.Size = New System.Drawing.Size(100, 20)
        Me.txtTiempoInactividad.TabIndex = 53
        Me.txtTiempoInactividad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(8, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Días de vida útil de las contraseñas"
        '
        'chkPerDesactivarAudio
        '
        Me.chkPerDesactivarAudio.AutoSize = True
        Me.chkPerDesactivarAudio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerDesactivarAudio.Location = New System.Drawing.Point(11, 238)
        Me.chkPerDesactivarAudio.Name = "chkPerDesactivarAudio"
        Me.chkPerDesactivarAudio.Size = New System.Drawing.Size(155, 17)
        Me.chkPerDesactivarAudio.TabIndex = 52
        Me.chkPerDesactivarAudio.Text = "Permitir desactivar el audio"
        Me.chkPerDesactivarAudio.UseVisualStyleBackColor = True
        '
        'chkPerDeshBloqueoInact
        '
        Me.chkPerDeshBloqueoInact.AutoSize = True
        Me.chkPerDeshBloqueoInact.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerDeshBloqueoInact.Location = New System.Drawing.Point(11, 183)
        Me.chkPerDeshBloqueoInact.Name = "chkPerDeshBloqueoInact"
        Me.chkPerDeshBloqueoInact.Size = New System.Drawing.Size(245, 17)
        Me.chkPerDeshBloqueoInact.TabIndex = 51
        Me.chkPerDeshBloqueoInact.Text = "Permitir deshabilitar el bloqueo por inactividad"
        Me.chkPerDeshBloqueoInact.UseVisualStyleBackColor = True
        '
        'chkPerDeshInicioAutomatico
        '
        Me.chkPerDeshInicioAutomatico.AutoSize = True
        Me.chkPerDeshInicioAutomatico.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerDeshInicioAutomatico.Location = New System.Drawing.Point(11, 158)
        Me.chkPerDeshInicioAutomatico.Name = "chkPerDeshInicioAutomatico"
        Me.chkPerDeshInicioAutomatico.Size = New System.Drawing.Size(213, 17)
        Me.chkPerDeshInicioAutomatico.TabIndex = 50
        Me.chkPerDeshInicioAutomatico.Text = "Permitir deshabilitar el inicio automático"
        Me.chkPerDeshInicioAutomatico.UseVisualStyleBackColor = True
        '
        'ChkPerDeshConsejos
        '
        Me.ChkPerDeshConsejos.AutoSize = True
        Me.ChkPerDeshConsejos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ChkPerDeshConsejos.Location = New System.Drawing.Point(11, 133)
        Me.ChkPerDeshConsejos.Name = "ChkPerDeshConsejos"
        Me.ChkPerDeshConsejos.Size = New System.Drawing.Size(181, 17)
        Me.ChkPerDeshConsejos.TabIndex = 49
        Me.ChkPerDeshConsejos.Text = "Permitir deshabilitar los consejos"
        Me.ChkPerDeshConsejos.UseVisualStyleBackColor = True
        '
        'chkPerDeshConNotify
        '
        Me.chkPerDeshConNotify.AutoSize = True
        Me.chkPerDeshConNotify.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerDeshConNotify.Location = New System.Drawing.Point(11, 108)
        Me.chkPerDeshConNotify.Name = "chkPerDeshConNotify"
        Me.chkPerDeshConNotify.Size = New System.Drawing.Size(280, 17)
        Me.chkPerDeshConNotify.TabIndex = 48
        Me.chkPerDeshConNotify.Text = "Permitir deshabilitar el contenido de las notificaciones"
        Me.chkPerDeshConNotify.UseVisualStyleBackColor = True
        '
        'chkPerDeshNotificaciones
        '
        Me.chkPerDeshNotificaciones.AutoSize = True
        Me.chkPerDeshNotificaciones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkPerDeshNotificaciones.Location = New System.Drawing.Point(11, 83)
        Me.chkPerDeshNotificaciones.Name = "chkPerDeshNotificaciones"
        Me.chkPerDeshNotificaciones.Size = New System.Drawing.Size(204, 17)
        Me.chkPerDeshNotificaciones.TabIndex = 47
        Me.chkPerDeshNotificaciones.Text = "Permitir deshabilitar las notificaciones"
        Me.chkPerDeshNotificaciones.UseVisualStyleBackColor = True
        '
        'chkLimPassLife
        '
        Me.chkLimPassLife.AutoSize = True
        Me.chkLimPassLife.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkLimPassLife.Location = New System.Drawing.Point(11, 35)
        Me.chkLimPassLife.Name = "chkLimPassLife"
        Me.chkLimPassLife.Size = New System.Drawing.Size(190, 17)
        Me.chkLimPassLife.TabIndex = 10
        Me.chkLimPassLife.Text = "Limitar vida útil de las contraseñas"
        Me.chkLimPassLife.UseVisualStyleBackColor = True
        '
        'chkMostrarUsuarios
        '
        Me.chkMostrarUsuarios.AutoSize = True
        Me.chkMostrarUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkMostrarUsuarios.Location = New System.Drawing.Point(11, 10)
        Me.chkMostrarUsuarios.Name = "chkMostrarUsuarios"
        Me.chkMostrarUsuarios.Size = New System.Drawing.Size(164, 17)
        Me.chkMostrarUsuarios.TabIndex = 24
        Me.chkMostrarUsuarios.Text = "Mostrar usuarios conectados"
        Me.chkMostrarUsuarios.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.chkDesactivarSuperclaves)
        Me.TabPage6.Controls.Add(Me.TabControl3)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(803, 479)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Superclaves"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'chkDesactivarSuperclaves
        '
        Me.chkDesactivarSuperclaves.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkDesactivarSuperclaves.AutoSize = True
        Me.chkDesactivarSuperclaves.Location = New System.Drawing.Point(315, 227)
        Me.chkDesactivarSuperclaves.Name = "chkDesactivarSuperclaves"
        Me.chkDesactivarSuperclaves.Size = New System.Drawing.Size(153, 17)
        Me.chkDesactivarSuperclaves.TabIndex = 1
        Me.chkDesactivarSuperclaves.Text = "Desactivar las superclaves"
        Me.chkDesactivarSuperclaves.UseVisualStyleBackColor = True
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage7)
        Me.TabControl3.Controls.Add(Me.TabPage8)
        Me.TabControl3.Location = New System.Drawing.Point(3, 29)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(797, 447)
        Me.TabControl3.TabIndex = 46
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.DgvSuperClaves)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(789, 421)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Superclaves"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'DgvSuperClaves
        '
        Me.DgvSuperClaves.AllowUserToAddRows = False
        Me.DgvSuperClaves.AllowUserToDeleteRows = False
        Me.DgvSuperClaves.AllowUserToResizeColumns = False
        Me.DgvSuperClaves.AllowUserToResizeRows = False
        Me.DgvSuperClaves.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvSuperClaves.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvSuperClaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSuperClaves.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDSuperClave, Me.Descripcion, Me.Clave})
        Me.DgvSuperClaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSuperClaves.Location = New System.Drawing.Point(3, 3)
        Me.DgvSuperClaves.MultiSelect = False
        Me.DgvSuperClaves.Name = "DgvSuperClaves"
        Me.DgvSuperClaves.RowHeadersVisible = False
        Me.DgvSuperClaves.RowHeadersWidth = 10
        Me.DgvSuperClaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvSuperClaves.Size = New System.Drawing.Size(783, 415)
        Me.DgvSuperClaves.TabIndex = 45
        '
        'IDSuperClave
        '
        Me.IDSuperClave.HeaderText = "ID"
        Me.IDSuperClave.Name = "IDSuperClave"
        Me.IDSuperClave.ReadOnly = True
        Me.IDSuperClave.Width = 120
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 415
        '
        'Clave
        '
        Me.Clave.HeaderText = "Superclave"
        Me.Clave.Name = "Clave"
        Me.Clave.Width = 240
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.DgvAcciones)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(789, 421)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Acciones"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'DgvAcciones
        '
        Me.DgvAcciones.AllowUserToAddRows = False
        Me.DgvAcciones.AllowUserToDeleteRows = False
        Me.DgvAcciones.AllowUserToResizeColumns = False
        Me.DgvAcciones.AllowUserToResizeRows = False
        Me.DgvAcciones.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvAcciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvAcciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAcciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDAccion, Me.Modulo, Me.DescripcionAccion, Me.Activar})
        Me.DgvAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAcciones.Location = New System.Drawing.Point(3, 3)
        Me.DgvAcciones.MultiSelect = False
        Me.DgvAcciones.Name = "DgvAcciones"
        Me.DgvAcciones.RowHeadersVisible = False
        Me.DgvAcciones.RowHeadersWidth = 36
        Me.DgvAcciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvAcciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAcciones.Size = New System.Drawing.Size(783, 415)
        Me.DgvAcciones.TabIndex = 0
        '
        'IDAccion
        '
        Me.IDAccion.HeaderText = "ID"
        Me.IDAccion.Name = "IDAccion"
        Me.IDAccion.ReadOnly = True
        Me.IDAccion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IDAccion.Width = 85
        '
        'Modulo
        '
        Me.Modulo.HeaderText = "Módulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.ReadOnly = True
        Me.Modulo.Width = 155
        '
        'DescripcionAccion
        '
        Me.DescripcionAccion.HeaderText = "Descripción"
        Me.DescripcionAccion.Name = "DescripcionAccion"
        Me.DescripcionAccion.ReadOnly = True
        Me.DescripcionAccion.Width = 475
        '
        'Activar
        '
        Me.Activar.HeaderText = "Activo"
        Me.Activar.Name = "Activar"
        Me.Activar.Width = 70
        '
        'ReportesTab
        '
        Me.ReportesTab.Controls.Add(Me.TabControl4)
        Me.ReportesTab.Location = New System.Drawing.Point(4, 25)
        Me.ReportesTab.Name = "ReportesTab"
        Me.ReportesTab.Padding = New System.Windows.Forms.Padding(3)
        Me.ReportesTab.Size = New System.Drawing.Size(817, 514)
        Me.ReportesTab.TabIndex = 1
        Me.ReportesTab.Text = "Reportes"
        Me.ReportesTab.UseVisualStyleBackColor = True
        '
        'TabControl4
        '
        Me.TabControl4.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl4.Controls.Add(Me.TabPage9)
        Me.TabControl4.Controls.Add(Me.TabPage10)
        Me.TabControl4.Controls.Add(Me.TabPage11)
        Me.TabControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl4.Location = New System.Drawing.Point(3, 3)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(811, 508)
        Me.TabControl4.TabIndex = 11
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.GridControl1)
        Me.TabPage9.Location = New System.Drawing.Point(4, 25)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(803, 479)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Distribución de reportes"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 3)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(797, 473)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsFind.FindNullPrompt = "Escriba el reporte que desea buscar"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'TabPage10
        '
        Me.TabPage10.AutoScroll = True
        Me.TabPage10.Controls.Add(Me.GroupBox20)
        Me.TabPage10.Controls.Add(Me.GroupBox1)
        Me.TabPage10.Controls.Add(Me.GroupBox9)
        Me.TabPage10.Controls.Add(Me.GroupBox2)
        Me.TabPage10.Location = New System.Drawing.Point(4, 25)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage10.Size = New System.Drawing.Size(803, 479)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Encabezados y pie de página"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.Label75)
        Me.GroupBox20.Controls.Add(Me.txtPieDeposito)
        Me.GroupBox20.Controls.Add(Me.txtEncDeposito)
        Me.GroupBox20.Controls.Add(Me.Label76)
        Me.GroupBox20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(6, 342)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(786, 79)
        Me.GroupBox20.TabIndex = 11
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Depósito de facturas"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label75.Location = New System.Drawing.Point(13, 22)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(65, 13)
        Me.Label75.TabIndex = 6
        Me.Label75.Text = "Encabezado"
        '
        'txtPieDeposito
        '
        Me.txtPieDeposito.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPieDeposito.Location = New System.Drawing.Point(84, 45)
        Me.txtPieDeposito.Name = "txtPieDeposito"
        Me.txtPieDeposito.Size = New System.Drawing.Size(690, 21)
        Me.txtPieDeposito.TabIndex = 5
        '
        'txtEncDeposito
        '
        Me.txtEncDeposito.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtEncDeposito.Location = New System.Drawing.Point(84, 19)
        Me.txtEncDeposito.Name = "txtEncDeposito"
        Me.txtEncDeposito.Size = New System.Drawing.Size(690, 21)
        Me.txtEncDeposito.TabIndex = 4
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label76.Location = New System.Drawing.Point(13, 48)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(21, 13)
        Me.Label76.TabIndex = 7
        Me.Label76.Text = "Pie"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox22)
        Me.GroupBox1.Controls.Add(Me.GroupBox21)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 174)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Facturación"
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.txtPieFactCredito)
        Me.GroupBox22.Controls.Add(Me.Label77)
        Me.GroupBox22.Controls.Add(Me.Label78)
        Me.GroupBox22.Controls.Add(Me.txtEncFactCredito)
        Me.GroupBox22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox22.ForeColor = System.Drawing.Color.DimGray
        Me.GroupBox22.Location = New System.Drawing.Point(6, 93)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(774, 72)
        Me.GroupBox22.TabIndex = 9
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Facturas a crédito"
        '
        'txtPieFactCredito
        '
        Me.txtPieFactCredito.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPieFactCredito.ForeColor = System.Drawing.Color.Black
        Me.txtPieFactCredito.Location = New System.Drawing.Point(84, 43)
        Me.txtPieFactCredito.Name = "txtPieFactCredito"
        Me.txtPieFactCredito.Size = New System.Drawing.Size(684, 21)
        Me.txtPieFactCredito.TabIndex = 1
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label77.ForeColor = System.Drawing.Color.Black
        Me.Label77.Location = New System.Drawing.Point(9, 20)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(65, 13)
        Me.Label77.TabIndex = 2
        Me.Label77.Text = "Encabezado"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label78.ForeColor = System.Drawing.Color.Black
        Me.Label78.Location = New System.Drawing.Point(12, 46)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(21, 13)
        Me.Label78.TabIndex = 3
        Me.Label78.Text = "Pie"
        '
        'txtEncFactCredito
        '
        Me.txtEncFactCredito.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtEncFactCredito.ForeColor = System.Drawing.Color.Black
        Me.txtEncFactCredito.Location = New System.Drawing.Point(84, 17)
        Me.txtEncFactCredito.Name = "txtEncFactCredito"
        Me.txtEncFactCredito.Size = New System.Drawing.Size(684, 21)
        Me.txtEncFactCredito.TabIndex = 0
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.txtPieFact)
        Me.GroupBox21.Controls.Add(Me.Label2)
        Me.GroupBox21.Controls.Add(Me.Label3)
        Me.GroupBox21.Controls.Add(Me.txtEncFact)
        Me.GroupBox21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox21.ForeColor = System.Drawing.Color.DimGray
        Me.GroupBox21.Location = New System.Drawing.Point(6, 15)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(774, 72)
        Me.GroupBox21.TabIndex = 8
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Facturas al contado"
        '
        'txtPieFact
        '
        Me.txtPieFact.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPieFact.ForeColor = System.Drawing.Color.Black
        Me.txtPieFact.Location = New System.Drawing.Point(84, 43)
        Me.txtPieFact.Name = "txtPieFact"
        Me.txtPieFact.Size = New System.Drawing.Size(684, 21)
        Me.txtPieFact.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Encabezado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Pie"
        '
        'txtEncFact
        '
        Me.txtEncFact.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtEncFact.ForeColor = System.Drawing.Color.Black
        Me.txtEncFact.Location = New System.Drawing.Point(84, 17)
        Me.txtEncFact.Name = "txtEncFact"
        Me.txtEncFact.Size = New System.Drawing.Size(684, 21)
        Me.txtEncFact.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label29)
        Me.GroupBox9.Controls.Add(Me.txtEncCotizacion)
        Me.GroupBox9.Controls.Add(Me.Label30)
        Me.GroupBox9.Controls.Add(Me.txtPieCotizacion)
        Me.GroupBox9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(6, 262)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(786, 74)
        Me.GroupBox9.TabIndex = 10
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Cotizaciones"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label29.Location = New System.Drawing.Point(6, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 13)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Encabezado"
        '
        'txtEncCotizacion
        '
        Me.txtEncCotizacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtEncCotizacion.Location = New System.Drawing.Point(84, 16)
        Me.txtEncCotizacion.Name = "txtEncCotizacion"
        Me.txtEncCotizacion.Size = New System.Drawing.Size(690, 21)
        Me.txtEncCotizacion.TabIndex = 4
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label30.Location = New System.Drawing.Point(6, 45)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(21, 13)
        Me.Label30.TabIndex = 7
        Me.Label30.Text = "Pie"
        '
        'txtPieCotizacion
        '
        Me.txtPieCotizacion.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPieCotizacion.Location = New System.Drawing.Point(84, 42)
        Me.txtPieCotizacion.Name = "txtPieCotizacion"
        Me.txtPieCotizacion.Size = New System.Drawing.Size(690, 21)
        Me.txtPieCotizacion.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtEncReciboIngreso)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPieReciboIngreso)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 183)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(786, 73)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recibos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Encabezado"
        '
        'txtEncReciboIngreso
        '
        Me.txtEncReciboIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtEncReciboIngreso.Location = New System.Drawing.Point(84, 16)
        Me.txtEncReciboIngreso.Name = "txtEncReciboIngreso"
        Me.txtEncReciboIngreso.Size = New System.Drawing.Size(690, 21)
        Me.txtEncReciboIngreso.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(6, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Pie"
        '
        'txtPieReciboIngreso
        '
        Me.txtPieReciboIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPieReciboIngreso.Location = New System.Drawing.Point(84, 42)
        Me.txtPieReciboIngreso.Name = "txtPieReciboIngreso"
        Me.txtPieReciboIngreso.Size = New System.Drawing.Size(690, 21)
        Me.txtPieReciboIngreso.TabIndex = 5
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.DgvFormatos)
        Me.TabPage11.Location = New System.Drawing.Point(4, 25)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage11.Size = New System.Drawing.Size(803, 479)
        Me.TabPage11.TabIndex = 2
        Me.TabPage11.Text = "Formatos de impresión"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'DgvFormatos
        '
        Me.DgvFormatos.AllowUserToAddRows = False
        Me.DgvFormatos.AllowUserToDeleteRows = False
        Me.DgvFormatos.AllowUserToResizeColumns = False
        Me.DgvFormatos.AllowUserToResizeRows = False
        Me.DgvFormatos.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvFormatos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvFormatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10, Me.PrinterKey})
        Me.DgvFormatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvFormatos.Location = New System.Drawing.Point(3, 3)
        Me.DgvFormatos.MultiSelect = False
        Me.DgvFormatos.Name = "DgvFormatos"
        Me.DgvFormatos.RowHeadersVisible = False
        Me.DgvFormatos.RowHeadersWidth = 10
        Me.DgvFormatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvFormatos.Size = New System.Drawing.Size(797, 473)
        Me.DgvFormatos.TabIndex = 46
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Tipo de formato"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 480
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn10.Width = 60
        '
        'PrinterKey
        '
        Me.PrinterKey.HeaderText = "Printer Key"
        Me.PrinterKey.Name = "PrinterKey"
        Me.PrinterKey.Width = 120
        '
        'NCFs
        '
        Me.NCFs.Controls.Add(Me.GroupBox4)
        Me.NCFs.Location = New System.Drawing.Point(4, 25)
        Me.NCFs.Name = "NCFs"
        Me.NCFs.Size = New System.Drawing.Size(817, 514)
        Me.NCFs.TabIndex = 6
        Me.NCFs.Text = "NCFs"
        Me.NCFs.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkNoGenerarNCFparaDevoluciones)
        Me.GroupBox4.Controls.Add(Me.GboxEstructuraNCF)
        Me.GroupBox4.Controls.Add(Me.Label56)
        Me.GroupBox4.Controls.Add(Me.Label55)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.lblSecuencia)
        Me.GroupBox4.Controls.Add(Me.lblDN)
        Me.GroupBox4.Controls.Add(Me.lblAI)
        Me.GroupBox4.Controls.Add(Me.lblTC)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.lblPE)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(817, 514)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo de Estructuras de NCF del Sistema"
        '
        'chkNoGenerarNCFparaDevoluciones
        '
        Me.chkNoGenerarNCFparaDevoluciones.AutoSize = True
        Me.chkNoGenerarNCFparaDevoluciones.Location = New System.Drawing.Point(13, 417)
        Me.chkNoGenerarNCFparaDevoluciones.Name = "chkNoGenerarNCFparaDevoluciones"
        Me.chkNoGenerarNCFparaDevoluciones.Size = New System.Drawing.Size(288, 17)
        Me.chkNoGenerarNCFparaDevoluciones.TabIndex = 460
        Me.chkNoGenerarNCFparaDevoluciones.Text = "No generar NCF para devoluciones de consumidor final"
        Me.chkNoGenerarNCFparaDevoluciones.UseVisualStyleBackColor = True
        '
        'GboxEstructuraNCF
        '
        Me.GboxEstructuraNCF.Controls.Add(Me.lblExplicacionNCF)
        Me.GboxEstructuraNCF.Controls.Add(Me.rdbMetodo2)
        Me.GboxEstructuraNCF.Controls.Add(Me.rdbMetodo3)
        Me.GboxEstructuraNCF.Controls.Add(Me.rdbMetodo1)
        Me.GboxEstructuraNCF.Location = New System.Drawing.Point(13, 200)
        Me.GboxEstructuraNCF.Name = "GboxEstructuraNCF"
        Me.GboxEstructuraNCF.Size = New System.Drawing.Size(782, 211)
        Me.GboxEstructuraNCF.TabIndex = 459
        Me.GboxEstructuraNCF.TabStop = False
        Me.GboxEstructuraNCF.Text = "Métodos"
        '
        'lblExplicacionNCF
        '
        Me.lblExplicacionNCF.Location = New System.Drawing.Point(277, 56)
        Me.lblExplicacionNCF.Name = "lblExplicacionNCF"
        Me.lblExplicacionNCF.Size = New System.Drawing.Size(499, 133)
        Me.lblExplicacionNCF.TabIndex = 460
        Me.lblExplicacionNCF.Text = "En este método el sistema utiliza una única secuencia para cada tipo de comproban" &
    "te fiscal que no se ve afectada por la división de negocios, el punto de emisión" &
    " y el área de impresión."
        '
        'rdbMetodo2
        '
        Me.rdbMetodo2.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.rdbMetodo2.Location = New System.Drawing.Point(9, 75)
        Me.rdbMetodo2.Name = "rdbMetodo2"
        Me.rdbMetodo2.Size = New System.Drawing.Size(271, 67)
        Me.rdbMetodo2.TabIndex = 459
        Me.rdbMetodo2.Text = "Método 2: Estructuración por Punto de Venta"
        Me.rdbMetodo2.UseVisualStyleBackColor = True
        '
        'rdbMetodo3
        '
        Me.rdbMetodo3.Checked = True
        Me.rdbMetodo3.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.rdbMetodo3.Location = New System.Drawing.Point(9, 138)
        Me.rdbMetodo3.Name = "rdbMetodo3"
        Me.rdbMetodo3.Size = New System.Drawing.Size(252, 67)
        Me.rdbMetodo3.TabIndex = 461
        Me.rdbMetodo3.TabStop = True
        Me.rdbMetodo3.Text = "Método 3: Nueva Normativa 2018"
        Me.rdbMetodo3.UseVisualStyleBackColor = True
        '
        'rdbMetodo1
        '
        Me.rdbMetodo1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.rdbMetodo1.Location = New System.Drawing.Point(9, 13)
        Me.rdbMetodo1.Name = "rdbMetodo1"
        Me.rdbMetodo1.Size = New System.Drawing.Size(271, 67)
        Me.rdbMetodo1.TabIndex = 458
        Me.rdbMetodo1.Text = "Método 1: Estructuración Generalizada"
        Me.rdbMetodo1.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label56.Location = New System.Drawing.Point(9, 139)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(786, 58)
        Me.Label56.TabIndex = 457
        Me.Label56.Text = resources.GetString("Label56.Text")
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(109, 121)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(116, 15)
        Me.Label55.TabIndex = 456
        Me.Label55.Text = "Niveles del sistema:"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(394, 107)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(15, 13)
        Me.Label54.TabIndex = 455
        Me.Label54.Text = "="
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(325, 107)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(15, 13)
        Me.Label53.TabIndex = 454
        Me.Label53.Text = "="
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(248, 107)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(15, 13)
        Me.Label52.TabIndex = 453
        Me.Label52.Text = "="
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(380, 121)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(39, 13)
        Me.Label51.TabIndex = 452
        Me.Label51.Text = "Equipo"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(305, 121)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(47, 13)
        Me.Label50.TabIndex = 451
        Me.Label50.Text = "Almacén"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(231, 121)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(47, 13)
        Me.Label48.TabIndex = 450
        Me.Label48.Text = "Sucursal"
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(526, 76)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(82, 15)
        Me.Label47.TabIndex = 449
        Me.Label47.Text = "Secuencia"
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(447, 76)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(82, 35)
        Me.Label46.TabIndex = 448
        Me.Label46.Text = "Tipo de Comprobante"
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(380, 76)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(67, 35)
        Me.Label45.TabIndex = 447
        Me.Label45.Text = "Área de Impresión"
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(305, 76)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(67, 35)
        Me.Label44.TabIndex = 446
        Me.Label44.Text = "Punto de Emisión"
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(231, 76)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(67, 35)
        Me.Label43.TabIndex = 445
        Me.Label43.Text = "División de Negocios"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(179, 76)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(31, 13)
        Me.Label49.TabIndex = 444
        Me.Label49.Text = "Serie"
        '
        'lblSecuencia
        '
        Me.lblSecuencia.AutoSize = True
        Me.lblSecuencia.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecuencia.Location = New System.Drawing.Point(524, 46)
        Me.lblSecuencia.Name = "lblSecuencia"
        Me.lblSecuencia.Size = New System.Drawing.Size(157, 30)
        Me.lblSecuencia.TabIndex = 437
        Me.lblSecuencia.Text = "000000001"
        '
        'lblDN
        '
        Me.lblDN.AutoSize = True
        Me.lblDN.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDN.Location = New System.Drawing.Point(229, 46)
        Me.lblDN.Name = "lblDN"
        Me.lblDN.Size = New System.Drawing.Size(45, 30)
        Me.lblDN.TabIndex = 435
        Me.lblDN.Text = "01"
        '
        'lblAI
        '
        Me.lblAI.AutoSize = True
        Me.lblAI.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAI.Location = New System.Drawing.Point(378, 46)
        Me.lblAI.Name = "lblAI"
        Me.lblAI.Size = New System.Drawing.Size(61, 30)
        Me.lblAI.TabIndex = 436
        Me.lblAI.Text = "001"
        '
        'lblTC
        '
        Me.lblTC.AutoSize = True
        Me.lblTC.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTC.Location = New System.Drawing.Point(445, 46)
        Me.lblTC.Name = "lblTC"
        Me.lblTC.Size = New System.Drawing.Size(45, 30)
        Me.lblTC.TabIndex = 434
        Me.lblTC.Text = "01"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(182, 46)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(29, 30)
        Me.Label39.TabIndex = 433
        Me.Label39.Text = "A"
        '
        'lblPE
        '
        Me.lblPE.AutoSize = True
        Me.lblPE.Font = New System.Drawing.Font("Courier New", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPE.Location = New System.Drawing.Point(303, 46)
        Me.lblPE.Name = "lblPE"
        Me.lblPE.Size = New System.Drawing.Size(61, 30)
        Me.lblPE.TabIndex = 435
        Me.lblPE.Text = "001"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label36.Location = New System.Drawing.Point(99, 21)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(628, 19)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "Los números de comprobante fiscal (NCF) se compone de derecha a izquierda de la s" &
    "iguiente manera:"
        '
        'AlertasTab
        '
        Me.AlertasTab.Controls.Add(Me.txtDiasAlertasAcuerdos)
        Me.AlertasTab.Controls.Add(Me.Label83)
        Me.AlertasTab.Controls.Add(Me.txtDiasRestAlertPass)
        Me.AlertasTab.Controls.Add(Me.Label35)
        Me.AlertasTab.Controls.Add(Me.Label19)
        Me.AlertasTab.Controls.Add(Me.txtMaxSizeofFiles)
        Me.AlertasTab.Controls.Add(Me.Label10)
        Me.AlertasTab.Controls.Add(Me.txtCantMinimaparaAlertaNCF)
        Me.AlertasTab.Controls.Add(Me.txtDiasVencimientoCheque)
        Me.AlertasTab.Controls.Add(Me.Label14)
        Me.AlertasTab.Controls.Add(Me.Label13)
        Me.AlertasTab.Controls.Add(Me.txtDiasSolicitudClientes)
        Me.AlertasTab.Controls.Add(Me.Label12)
        Me.AlertasTab.Location = New System.Drawing.Point(4, 25)
        Me.AlertasTab.Name = "AlertasTab"
        Me.AlertasTab.Padding = New System.Windows.Forms.Padding(3)
        Me.AlertasTab.Size = New System.Drawing.Size(817, 514)
        Me.AlertasTab.TabIndex = 4
        Me.AlertasTab.Text = "Alertas"
        Me.AlertasTab.UseVisualStyleBackColor = True
        '
        'txtDiasAlertasAcuerdos
        '
        Me.txtDiasAlertasAcuerdos.Location = New System.Drawing.Point(245, 37)
        Me.txtDiasAlertasAcuerdos.Name = "txtDiasAlertasAcuerdos"
        Me.txtDiasAlertasAcuerdos.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasAlertasAcuerdos.TabIndex = 16
        Me.txtDiasAlertasAcuerdos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(8, 40)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(220, 13)
        Me.Label83.TabIndex = 17
        Me.Label83.Text = "Cant. de días para alertar acuerdos de pago"
        '
        'txtDiasRestAlertPass
        '
        Me.txtDiasRestAlertPass.Location = New System.Drawing.Point(245, 115)
        Me.txtDiasRestAlertPass.Name = "txtDiasRestAlertPass"
        Me.txtDiasRestAlertPass.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasRestAlertPass.TabIndex = 14
        Me.txtDiasRestAlertPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(8, 118)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(198, 13)
        Me.Label35.TabIndex = 15
        Me.Label35.Text = "Días restantes para alertar contraseñas"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(302, 145)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "kilobytes"
        '
        'txtMaxSizeofFiles
        '
        Me.txtMaxSizeofFiles.Location = New System.Drawing.Point(245, 141)
        Me.txtMaxSizeofFiles.Name = "txtMaxSizeofFiles"
        Me.txtMaxSizeofFiles.Size = New System.Drawing.Size(54, 20)
        Me.txtMaxSizeofFiles.TabIndex = 11
        Me.txtMaxSizeofFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(187, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Tamaño máximo de archivos adjuntos"
        '
        'txtCantMinimaparaAlertaNCF
        '
        Me.txtCantMinimaparaAlertaNCF.Location = New System.Drawing.Point(245, 89)
        Me.txtCantMinimaparaAlertaNCF.Name = "txtCantMinimaparaAlertaNCF"
        Me.txtCantMinimaparaAlertaNCF.Size = New System.Drawing.Size(54, 20)
        Me.txtCantMinimaparaAlertaNCF.TabIndex = 5
        Me.txtCantMinimaparaAlertaNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDiasVencimientoCheque
        '
        Me.txtDiasVencimientoCheque.Location = New System.Drawing.Point(245, 63)
        Me.txtDiasVencimientoCheque.Name = "txtDiasVencimientoCheque"
        Me.txtDiasVencimientoCheque.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasVencimientoCheque.TabIndex = 7
        Me.txtDiasVencimientoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Cant. mínima de NCF para alertas"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(210, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Días de vencimiento de cheques devueltos"
        '
        'txtDiasSolicitudClientes
        '
        Me.txtDiasSolicitudClientes.Location = New System.Drawing.Point(245, 11)
        Me.txtDiasSolicitudClientes.Name = "txtDiasSolicitudClientes"
        Me.txtDiasSolicitudClientes.Size = New System.Drawing.Size(54, 20)
        Me.txtDiasSolicitudClientes.TabIndex = 5
        Me.txtDiasSolicitudClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(204, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Cant. de días para solicitudes de Clientes"
        '
        'Filtados
        '
        Me.Filtados.Controls.Add(Me.GroupBox5)
        Me.Filtados.Controls.Add(Me.GroupBox7)
        Me.Filtados.Location = New System.Drawing.Point(4, 25)
        Me.Filtados.Name = "Filtados"
        Me.Filtados.Padding = New System.Windows.Forms.Padding(3)
        Me.Filtados.Size = New System.Drawing.Size(817, 514)
        Me.Filtados.TabIndex = 5
        Me.Filtados.Text = "Filtrados"
        Me.Filtados.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label57)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.txtPalabraClaveCosto)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(473, 417)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Palabra clave para costos de artículos"
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(6, 84)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(461, 327)
        Me.Label57.TabIndex = 3
        Me.Label57.Text = resources.GetString("Label57.Text")
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(6, 69)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(86, 13)
        Me.Label41.TabIndex = 2
        Me.Label41.Text = "Funcionamiento:"
        '
        'Label40
        '
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(260, 19)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(45, 47)
        Me.Label40.TabIndex = 1
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPalabraClaveCosto
        '
        Me.txtPalabraClaveCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPalabraClaveCosto.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPalabraClaveCosto.Location = New System.Drawing.Point(6, 19)
        Me.txtPalabraClaveCosto.Name = "txtPalabraClaveCosto"
        Me.txtPalabraClaveCosto.Size = New System.Drawing.Size(255, 47)
        Me.txtPalabraClaveCosto.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ColorFactCredito)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.ColorFactContado)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.ColorAbonos)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.ColorChequesDev)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.ColorDevoluciones)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.ColorNotaCredito)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.ColorNotaDebito)
        Me.GroupBox7.Controls.Add(Me.ColorCargos)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(487, 6)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(190, 221)
        Me.GroupBox7.TabIndex = 38
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Colores en Historial del Cliente"
        '
        'ColorFactCredito
        '
        Me.ColorFactCredito.BackColor = System.Drawing.Color.Black
        Me.ColorFactCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorFactCredito.Location = New System.Drawing.Point(10, 19)
        Me.ColorFactCredito.Name = "ColorFactCredito"
        Me.ColorFactCredito.Size = New System.Drawing.Size(35, 15)
        Me.ColorFactCredito.TabIndex = 23
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label27.Location = New System.Drawing.Point(51, 194)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(131, 15)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "Devoluciones de Ventas"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(51, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 15)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Facturación a Crédito"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(51, 119)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 15)
        Me.Label26.TabIndex = 36
        Me.Label26.Text = "Notas de Débito"
        '
        'ColorFactContado
        '
        Me.ColorFactContado.BackColor = System.Drawing.Color.Black
        Me.ColorFactContado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorFactContado.Location = New System.Drawing.Point(10, 44)
        Me.ColorFactContado.Name = "ColorFactContado"
        Me.ColorFactContado.Size = New System.Drawing.Size(35, 15)
        Me.ColorFactContado.TabIndex = 24
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label25.Location = New System.Drawing.Point(51, 144)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(96, 15)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "Notas de Crédito"
        '
        'ColorAbonos
        '
        Me.ColorAbonos.BackColor = System.Drawing.Color.Black
        Me.ColorAbonos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorAbonos.Location = New System.Drawing.Point(10, 69)
        Me.ColorAbonos.Name = "ColorAbonos"
        Me.ColorAbonos.Size = New System.Drawing.Size(35, 15)
        Me.ColorAbonos.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label24.Location = New System.Drawing.Point(51, 169)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 15)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "Cheques Devueltos"
        '
        'ColorChequesDev
        '
        Me.ColorChequesDev.BackColor = System.Drawing.Color.Black
        Me.ColorChequesDev.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorChequesDev.Location = New System.Drawing.Point(10, 169)
        Me.ColorChequesDev.Name = "ColorChequesDev"
        Me.ColorChequesDev.Size = New System.Drawing.Size(35, 15)
        Me.ColorChequesDev.TabIndex = 26
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(51, 94)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 15)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Cargos"
        '
        'ColorDevoluciones
        '
        Me.ColorDevoluciones.BackColor = System.Drawing.Color.Black
        Me.ColorDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorDevoluciones.Location = New System.Drawing.Point(10, 194)
        Me.ColorDevoluciones.Name = "ColorDevoluciones"
        Me.ColorDevoluciones.Size = New System.Drawing.Size(35, 15)
        Me.ColorDevoluciones.TabIndex = 27
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(51, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 15)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Abonos"
        '
        'ColorNotaCredito
        '
        Me.ColorNotaCredito.BackColor = System.Drawing.Color.Black
        Me.ColorNotaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorNotaCredito.Location = New System.Drawing.Point(10, 144)
        Me.ColorNotaCredito.Name = "ColorNotaCredito"
        Me.ColorNotaCredito.Size = New System.Drawing.Size(35, 15)
        Me.ColorNotaCredito.TabIndex = 28
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(51, 44)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 15)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Facturación a Contado"
        '
        'ColorNotaDebito
        '
        Me.ColorNotaDebito.BackColor = System.Drawing.Color.Black
        Me.ColorNotaDebito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorNotaDebito.Location = New System.Drawing.Point(10, 119)
        Me.ColorNotaDebito.Name = "ColorNotaDebito"
        Me.ColorNotaDebito.Size = New System.Drawing.Size(35, 15)
        Me.ColorNotaDebito.TabIndex = 29
        '
        'ColorCargos
        '
        Me.ColorCargos.BackColor = System.Drawing.Color.Black
        Me.ColorCargos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ColorCargos.Location = New System.Drawing.Point(10, 94)
        Me.ColorCargos.Name = "ColorCargos"
        Me.ColorCargos.Size = New System.Drawing.Size(35, 15)
        Me.ColorCargos.TabIndex = 30
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGuardar.Image = Global.Libregco.My.Resources.Resources.Save_Option_x32
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(701, 549)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(119, 40)
        Me.btnGuardar.TabIndex = 193
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'BarraEstado
        '
        Me.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraEstado.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicLogo, Me.NameSys, Me.ToolSeparator2, Me.lblStatusBar})
        Me.BarraEstado.Location = New System.Drawing.Point(0, 595)
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.BarraEstado.Size = New System.Drawing.Size(828, 25)
        Me.BarraEstado.TabIndex = 270
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 360
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Superclave"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 205
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.Width = 85
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Módulo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 160
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 350
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "No. Orden"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 90
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "MenuString"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'txtDescripDuplicado
        '
        Me.txtDescripDuplicado.Enabled = False
        Me.txtDescripDuplicado.Location = New System.Drawing.Point(112, 24)
        Me.txtDescripDuplicado.Name = "txtDescripDuplicado"
        Me.txtDescripDuplicado.Size = New System.Drawing.Size(198, 20)
        Me.txtDescripDuplicado.TabIndex = 86
        '
        'txtDescripDespacho
        '
        Me.txtDescripDespacho.Enabled = False
        Me.txtDescripDespacho.Location = New System.Drawing.Point(112, 50)
        Me.txtDescripDespacho.Name = "txtDescripDespacho"
        Me.txtDescripDespacho.Size = New System.Drawing.Size(198, 20)
        Me.txtDescripDespacho.TabIndex = 87
        '
        'txtDescripContabilidad
        '
        Me.txtDescripContabilidad.Enabled = False
        Me.txtDescripContabilidad.Location = New System.Drawing.Point(112, 76)
        Me.txtDescripContabilidad.Name = "txtDescripContabilidad"
        Me.txtDescripContabilidad.Size = New System.Drawing.Size(198, 20)
        Me.txtDescripContabilidad.TabIndex = 88
        '
        'frm_ajustes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 620)
        Me.Controls.Add(Me.BarraEstado)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ajustes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajustes de configuración"
        CType(Me.PicBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.EmpresaInfoTab.ResumeLayout(False)
        Me.EmpresaInfoTab.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.cbxMoneda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFlags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox30.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox38.ResumeLayout(False)
        CType(Me.TBSensibilidadDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox37.ResumeLayout(False)
        Me.GroupBox36.ResumeLayout(False)
        Me.GroupBox36.PerformLayout()
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox35.PerformLayout()
        CType(Me.ICBERedondeoHacia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox34.PerformLayout()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox33.PerformLayout()
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        CType(Me.NUSensibilidadRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox31.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PicFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PicPrefactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarPrefactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PicCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        CType(Me.DgvSuperClaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        CType(Me.DgvAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ReportesTab.ResumeLayout(False)
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage11.ResumeLayout(False)
        CType(Me.DgvFormatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NCFs.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GboxEstructuraNCF.ResumeLayout(False)
        Me.AlertasTab.ResumeLayout(False)
        Me.AlertasTab.PerformLayout()
        Me.Filtados.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.BarraEstado.ResumeLayout(False)
        Me.BarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents EmpresaInfoTab As System.Windows.Forms.TabPage
    Friend WithEvents ReportesTab As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LboxInfoEmpresa As System.Windows.Forms.ListBox
    Friend WithEvents btnModificarEmpresa As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPieFact As System.Windows.Forms.TextBox
    Friend WithEvents txtEncFact As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPieReciboIngreso As System.Windows.Forms.TextBox
    Friend WithEvents txtEncReciboIngreso As System.Windows.Forms.TextBox
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMoraDiaria As System.Windows.Forms.TextBox
    Friend WithEvents txtMoraAnual As System.Windows.Forms.TextBox
    Friend WithEvents txtMoraMensual As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItbisGeneral As System.Windows.Forms.TextBox
    Friend WithEvents AlertasTab As System.Windows.Forms.TabPage
    Friend WithEvents chkMostpreciosFact As System.Windows.Forms.CheckBox
    Friend WithEvents chkFactDebajoCosto As System.Windows.Forms.CheckBox
    Friend WithEvents chkMultiplesCliRec As System.Windows.Forms.CheckBox
    Friend WithEvents chkMostrarUsuarios As System.Windows.Forms.CheckBox
    Friend WithEvents chkFacturarSExistencia As System.Windows.Forms.CheckBox
    Friend WithEvents txtCantMinimaparaAlertaNCF As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDiasVencimientoCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDiasSolicitudClientes As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkHabilitarCobroCargos As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNCFPredeterminado As System.Windows.Forms.ComboBox
    Friend WithEvents chkFactNCFAgotado As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCobradorPred As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkActCostos As System.Windows.Forms.CheckBox
    Friend WithEvents txtLimiteConsultas As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtUltimaActCXC As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Filtados As TabPage
    Friend WithEvents Label21 As Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ColorFactCredito As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ColorFactContado As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ColorAbonos As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ColorChequesDev As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ColorDevoluciones As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ColorNotaCredito As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ColorNotaDebito As System.Windows.Forms.Label
    Friend WithEvents ColorCargos As System.Windows.Forms.Label
    Friend WithEvents chkEvitDomingos As System.Windows.Forms.CheckBox
    Friend WithEvents chkEvitSabados As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtDiasCondicion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtEncCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPieCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStrip
    Friend WithEvents PicLogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents NameSys As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusBar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chkNoIdentObligatoria As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CbxOcupacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbxEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbxNacionalidad As System.Windows.Forms.ComboBox
    Friend WithEvents chkPermitirDevoSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents chkActSupenArt As System.Windows.Forms.CheckBox
    Friend WithEvents chkLimPassLife As System.Windows.Forms.CheckBox
    Friend WithEvents txtDiasUtilesPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkAvisarIncosistencia As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMaxSizeofFiles As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDiasRestAlertPass As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkShowPagaresenCobro As System.Windows.Forms.CheckBox
    Friend WithEvents NCFs As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents GboxEstructuraNCF As System.Windows.Forms.GroupBox
    Friend WithEvents rdbMetodo1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblSecuencia As System.Windows.Forms.Label
    Friend WithEvents lblDN As System.Windows.Forms.Label
    Friend WithEvents lblAI As System.Windows.Forms.Label
    Friend WithEvents lblTC As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblPE As System.Windows.Forms.Label
    Friend WithEvents lblExplicacionNCF As System.Windows.Forms.Label
    Friend WithEvents rdbMetodo2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtTasaTSS As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtPalabraClaveCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cbxPlazoContrato As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents chkPermCredSSol As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerCambioPlazoSol As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents chkPedirAutCredito As System.Windows.Forms.CheckBox
    Friend WithEvents chkCambiarFechaFact As System.Windows.Forms.CheckBox
    Friend WithEvents chkCambiarFechaRecibos As System.Windows.Forms.CheckBox
    Friend WithEvents chkGenerarPagares As System.Windows.Forms.CheckBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtLimiteMaximoSolNombre As System.Windows.Forms.TextBox
    Friend WithEvents chkSolicitarNombreLimite As System.Windows.Forms.CheckBox
    Friend WithEvents DgvSuperClaves As System.Windows.Forms.DataGridView
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtLimiteDescuentos As System.Windows.Forms.TextBox
    Friend WithEvents chkControlarDescuentos As System.Windows.Forms.CheckBox
    Friend WithEvents chkControlarInfoTarjetas As System.Windows.Forms.CheckBox
    Friend WithEvents chkControlarFactMenores As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkControlarMontoPagosxSalario As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtRelacionSalario As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtTiempoInactividad As System.Windows.Forms.TextBox
    Friend WithEvents chkPerDesactivarAudio As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerDeshBloqueoInact As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerDeshInicioAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPerDeshConsejos As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerDeshConNotify As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerDeshNotificaciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerContraerEncInicio As System.Windows.Forms.CheckBox
    Friend WithEvents chkModificarModal As System.Windows.Forms.CheckBox
    Friend WithEvents chkImponerRncTel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCargosMonto As System.Windows.Forms.TextBox
    Friend WithEvents chkCerrarCreditoconCargo As System.Windows.Forms.CheckBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents chkControlarventassinInicial As System.Windows.Forms.CheckBox
    Friend WithEvents chkHabModContenido As System.Windows.Forms.CheckBox
    Friend WithEvents rdbMetodo3 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGenerarNCFCargo As System.Windows.Forms.CheckBox
    Friend WithEvents rdbUnicaMora As System.Windows.Forms.RadioButton
    Friend WithEvents rdbMoraMensual As System.Windows.Forms.RadioButton
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents chkShowIncompletesInfoClientes As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtCantRevisionNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasparaCerrarCredito As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents chkCerrarCreditoporAntiguedad As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents DgvAcciones As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents TabControl4 As TabControl
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents chkBloqueoImpresionRapida As CheckBox
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents txtDiasGuardarBitacora As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkModificacionArticuloBase As CheckBox
    Friend WithEvents chkFacturacionSinInvArticuloBase As CheckBox
    Friend WithEvents chkActivacionBlackFriday As CheckBox
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents chkBlackFridayLiberarFacturacion As CheckBox
    Friend WithEvents Label69 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents dtpBlackFridayStart As DateTimePicker
    Friend WithEvents Label70 As Label
    Friend WithEvents dtpBlackFridayEnds As DateTimePicker
    Friend WithEvents chkDesactivarSuperclaves As CheckBox
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents Label71 As Label
    Friend WithEvents chkDarExpiracionPrefacturaciion As CheckBox
    Friend WithEvents cbxVidaUtilPrefacturacion As ComboBox
    Friend WithEvents chkIdentificacionFisiscaObligatoria As CheckBox
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents chkObligacionSeriales As CheckBox
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents Label74 As Label
    Friend WithEvents txtMontoMinimoPagare As TextBox
    Friend WithEvents chkControlMontoMinimoPagare As CheckBox
    Friend WithEvents GroupBox18 As GroupBox
    Friend WithEvents Label73 As Label
    Friend WithEvents txtCantMaximaFacturasCredito As TextBox
    Friend WithEvents chkControlCantidadCreditos As CheckBox
    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents Label72 As Label
    Friend WithEvents txtCantMaximaPagaresVencidos As TextBox
    Friend WithEvents chkControlCantidadPagaresVencidos As CheckBox
    Friend WithEvents chkControlarTipoPago As CheckBox
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents Label75 As Label
    Friend WithEvents txtEncDeposito As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents txtPieDeposito As TextBox
    Friend WithEvents chkBloqueoFacturacionSimultanea As CheckBox
    Friend WithEvents GroupBox22 As GroupBox
    Friend WithEvents txtPieFactCredito As TextBox
    Friend WithEvents Label77 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents txtEncFactCredito As TextBox
    Friend WithEvents GroupBox21 As GroupBox
    Friend WithEvents ChkPermitirTarjetasFacturacion As CheckBox
    Friend WithEvents chkMostrarBotonAsistenciaInicio As CheckBox
    Friend WithEvents chkPermitirCobrosTarjeta As CheckBox
    Friend WithEvents GroupBox23 As GroupBox
    Friend WithEvents chkSolGarante As CheckBox
    Friend WithEvents chkSolTelefonoPersonal2 As CheckBox
    Friend WithEvents chkSolTelefonoPersonal1 As CheckBox
    Friend WithEvents chkSolDireccionCompleta As CheckBox
    Friend WithEvents chkSolInformacionAdc As CheckBox
    Friend WithEvents GroupBox24 As GroupBox
    Friend WithEvents chkCopiaDespacho As CheckBox
    Friend WithEvents chkCopiaContabilidad As CheckBox
    Friend WithEvents chkImpresionCopiaMultiple As CheckBox
    Friend WithEvents chkCopiaCliente As CheckBox
    Friend WithEvents chkRevalidarTotales As CheckBox
    Friend WithEvents chkCXCFormatoLargo As CheckBox
    Friend WithEvents chkCalculoCorteCaja As CheckBox
    Friend WithEvents chkPermitirFiltradoCorte As CheckBox
    Friend WithEvents Label79 As Label
    Friend WithEvents txtCantDecimales As NumericUpDown
    Friend WithEvents chkPermitirDuplicidadCompras As CheckBox
    Friend WithEvents chkPermitirDuplicidadFacturacion As CheckBox
    Friend WithEvents chkPermitirModPrefactura As CheckBox
    Friend WithEvents chkPermitirReimpresion As CheckBox
    Friend WithEvents chkHoraCortesCaja As CheckBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDSuperClave As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Clave As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox25 As GroupBox
    Friend WithEvents Label80 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents DgvFormatos As DataGridView
    Friend WithEvents IDAccion As DataGridViewTextBoxColumn
    Friend WithEvents Modulo As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionAccion As DataGridViewTextBoxColumn
    Friend WithEvents Activar As DataGridViewCheckBoxColumn
    Friend WithEvents chkPermitirFactSinPrefact As CheckBox
    Friend WithEvents chkRNCInteligente As CheckBox
    Friend WithEvents chkPermitirDev30 As CheckBox
    Friend WithEvents GroupBox26 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PicPrefactura As PictureBox
    Friend WithEvents TrackBarPrefactura As TrackBar
    Friend WithEvents Label82 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PicFacturacion As PictureBox
    Friend WithEvents TrackBarFactura As TrackBar
    Friend WithEvents GroupBox27 As GroupBox
    Friend WithEvents Label84 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PicCompras As PictureBox
    Friend WithEvents TrackBarCompras As TrackBar
    Friend WithEvents chkSolConfirmacionVendedor As CheckBox
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents chkSolConfRecCompra As CheckBox
    Friend WithEvents txtDiasAlertasAcuerdos As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents chkLlenarAutVerificacionSub As CheckBox
    Friend WithEvents chkVisualArticulosCompletos As CheckBox
    Friend WithEvents chkRedondearPrecios As CheckBox
    Friend WithEvents chkMultipleUsuarios As CheckBox
    Friend WithEvents GroupBox28 As GroupBox
    Friend WithEvents Label87 As Label
    Friend WithEvents cbxReporteCredito As ComboBox
    Friend WithEvents cbxReporteContado As ComboBox
    Friend WithEvents chkUtilizarReportesPredFacturacion As CheckBox
    Friend WithEvents Label86 As Label
    Friend WithEvents Label85 As Label
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewCheckBoxColumn
    Friend WithEvents PrinterKey As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox29 As GroupBox
    Friend WithEvents rdbDirecto As RadioButton
    Friend WithEvents rdbPredictivo As RadioButton
    Friend WithEvents chkGuardarCalculosPiezaje As CheckBox
    Friend WithEvents chkGuardarAutPietaje As CheckBox
    Friend WithEvents chkRedondearPreciosPiezaje As CheckBox
    Friend WithEvents GroupBox30 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label89 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label88 As Label
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents chkControlarPreciosNiveles As CheckBox
    Friend WithEvents chkPermitirFactLimiteAgotado As CheckBox
    Friend WithEvents chkMostrarNoOrden As CheckBox
    Friend WithEvents chkMostrarRelacionadasPrefac As CheckBox
    Friend WithEvents chkMostrarSimiliaresPrefact As CheckBox
    Friend WithEvents GroupBox32 As GroupBox
    Friend WithEvents chkSoloconExistenciaRelacionados As CheckBox
    Friend WithEvents GroupBox31 As GroupBox
    Friend WithEvents chkSoloconExistSimilares As CheckBox
    Friend WithEvents GroupBox33 As GroupBox
    Friend WithEvents chkControlDespachoPunto As CheckBox
    Friend WithEvents chkControlDespachoMedia As CheckBox
    Friend WithEvents chkControlDespachoPagina As CheckBox
    Friend WithEvents cbxControlDespachoPuntoVenta As ComboBox
    Friend WithEvents cbxControlDespachoMediaPagina As ComboBox
    Friend WithEvents Label93 As Label
    Friend WithEvents cbxControlDespachoPaginaCompleta As ComboBox
    Friend WithEvents chkHabilitarControlDespacho As CheckBox
    Friend WithEvents Label94 As Label
    Friend WithEvents cbxMoneda As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents imgFlags As DevExpress.Utils.ImageCollection
    Friend WithEvents chkDeshabilitarVerificacionCorreo As CheckBox
    Friend WithEvents chkBloqueoPrecioCero As CheckBox
    Friend WithEvents cbkActPreciosMedidas As CheckBox
    Friend WithEvents GroupBox34 As GroupBox
    Friend WithEvents TrackBar2 As TrackBar
    Friend WithEvents chkSensibilidadControlVenta As CheckBox
    Friend WithEvents Label95 As Label
    Friend WithEvents chkBloquearFactArtSNComprasVentas As CheckBox
    Friend WithEvents chkBloquearUsuarios As CheckBox
    Friend WithEvents chkLlenarListadoProductos As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents chkNoGenerarNCFparaDevoluciones As CheckBox
    Friend WithEvents chkAumentarPreciosRelacionCOsto As CheckBox
    Friend WithEvents Label96 As Label
    Friend WithEvents txtDiasNotas As NumericUpDown
    Friend WithEvents chkControlarNotasContado As CheckBox
    Friend WithEvents GroupBox35 As GroupBox
    Friend WithEvents ICBERedondeoHacia As XtraEditors.ImageComboBoxEdit
    Friend WithEvents LabelControl2 As XtraEditors.LabelControl
    Friend WithEvents GroupBox36 As GroupBox
    Friend WithEvents chkHabilitarContraEntrega As CheckBox
    Private WithEvents btnBuscarCliente As Button
    Friend WithEvents txtIDClienteContraEntrega As TextBox
    Friend WithEvents txtNombreContraEntrega As TextBox
    Friend WithEvents chkCodigoPrimarioClientes As CheckBox
    Friend WithEvents ChkFacturarconVencidas As CheckBox
    Friend WithEvents chkControlDigitalFactura As CheckBox
    Friend WithEvents chkVisualDigitalesCXP As CheckBox
    Friend WithEvents chkFraccionesTexto As CheckBox
    Friend WithEvents GroupBox37 As GroupBox
    Friend WithEvents btnFracciones As Button
    Friend WithEvents Label97 As Label
    Friend WithEvents NUSensibilidadRelacionados As NumericUpDown
    Friend WithEvents GroupBox38 As GroupBox
    Friend WithEvents lblSensibilidadDescripcion As Label
    Friend WithEvents TBSensibilidadDescripcion As TrackBar
    Friend WithEvents txtDescripContabilidad As TextBox
    Friend WithEvents txtDescripDespacho As TextBox
    Friend WithEvents txtDescripDuplicado As TextBox
End Class
