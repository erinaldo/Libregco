Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_ajustes
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim GridColor As Color

    Private dt As DataTable
    Dim LuePaperSize As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()


    Private Sub frm_Ajustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        CargarConfiguracion()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarConfiguracion()
        Try
            Ds.Clear()
            Con.Open()
            ConLibregco.Open()

            TabControl1.SelectedIndex = 0

            'Tasa de Mora Diaria
            cmd = New MySqlCommand("Select Value3Double from Configuracion Where IDConfiguracion=3", Con)
            txtMoraDiaria.Text = Convert.ToDouble(cmd.ExecuteScalar()).ToString("P2")

            'Tasa de TSS
            cmd = New MySqlCommand("Select Value3Double from Configuracion Where IDConfiguracion=77", Con)
            txtTasaTSS.Text = Convert.ToDouble(cmd.ExecuteScalar()).ToString("P2")

            'Avisar inconsistencia en compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=9", Con)
            chkAvisarIncosistencia.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Itbis General
            cmd = New MySqlCommand("Select Value3Double from Configuracion Where IDConfiguracion=11", Con)
            txtItbisGeneral.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("P")

            'Dias en condicion de pagares por default
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=52", Con)
            txtDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

            'Comprobante Fiscal Predeterminado
            Ds.Clear()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            cbxNCFPredeterminado.Items.Clear()
            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                cbxNCFPredeterminado.Items.Add(Fila.Item("TipoComprobante"))
            Next
            cmd = New MySqlCommand("Select TipoComprobante from Configuracion INNER JOIN ComprobanteFiscal on Configuracion.Value2Int=ComprobanteFiscal.IDComprobanteFiscal Where IDConfiguracion=13", Con)
            cbxNCFPredeterminado.Text = Convert.ToString(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=13", Con)
            cbxNCFPredeterminado.Tag = Convert.ToString(cmd.ExecuteScalar())

            'Cobrador Predeterminado
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where Nulo=0 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Cobrador")
            cbxCobradorPred.Items.Clear()
            Dim TablaCobrador As DataTable = Ds.Tables("Cobrador")
            For Each Fila As DataRow In TablaCobrador.Rows
                cbxCobradorPred.Items.Add(Fila.Item("Nombre"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
            cbxCobradorPred.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Nombre FROM Empleados where IDEmpleado='" + cbxCobradorPred.Tag.ToString + "'", Con)
            cbxCobradorPred.Text = Convert.ToString(cmd.ExecuteScalar())


            'Condiciones Predeterminadas
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()

            Dim TablaCondicion As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In TablaCondicion.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=59", Con)
            cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where IDCondicion='" + cbxCondicion.Tag.ToString + "'", ConLibregco)
            cbxCondicion.Text = Convert.ToString(cmd.ExecuteScalar())


            'Ocupacion Predeterminada
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Ocupacion FROM Ocupacion Where Nulo=0 ORDER BY Ocupacion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Ocupacion")
            CbxOcupacion.Items.Clear()
            Dim TablaOcupacion As DataTable = Ds.Tables("Ocupacion")
            For Each Fila As DataRow In TablaOcupacion.Rows
                CbxOcupacion.Items.Add(Fila.Item("Ocupacion"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=61", Con)
            CbxOcupacion.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Ocupacion FROM Ocupacion where IDOcupacion='" + CbxOcupacion.Tag.ToString + "'", ConLibregco)
            CbxOcupacion.Text = Convert.ToString(cmd.ExecuteScalar())

            'Estado Civil Predeterminado
            Ds.Clear()
            cmd = New MySqlCommand("SELECT EstadoCivil FROM EstadoCivil Where Nulo=0 ORDER BY EstadoCivil ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EstadoCivil")
            cbxEstadoCivil.Items.Clear()
            Dim TablaEstadoCivil As DataTable = Ds.Tables("EstadoCivil")
            For Each Fila As DataRow In TablaEstadoCivil.Rows
                cbxEstadoCivil.Items.Add(Fila.Item("EstadoCivil"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=60", Con)
            cbxEstadoCivil.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT EstadoCivil FROM EstadoCivil where IDCivil='" + cbxEstadoCivil.Tag.ToString + "'", ConLibregco)
            cbxEstadoCivil.Text = Convert.ToString(cmd.ExecuteScalar())

            'Nacionalidad Predeterminado
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Nacionalidad FROM Nacionalidad Where Nulo=0 ORDER BY Nacionalidad ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nacionalidad")
            cbxNacionalidad.Items.Clear()
            Dim TablaNacionalidad As DataTable = Ds.Tables("Nacionalidad")
            For Each Fila As DataRow In TablaNacionalidad.Rows
                cbxNacionalidad.Items.Add(Fila.Item("Nacionalidad"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=62", Con)
            cbxNacionalidad.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Nacionalidad FROM Nacionalidad where IDNacionalidad='" + cbxNacionalidad.Tag.ToString + "'", ConLibregco)
            cbxNacionalidad.Text = Convert.ToString(cmd.ExecuteScalar())

            'Plazo Predeterminado
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Plazo FROM PlazoContrato Where Nulo=0 ORDER BY Meses ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PlazoContrato")
            cbxPlazoContrato.Items.Clear()
            Dim TablaPlazoContrato As DataTable = Ds.Tables("PlazoContrato")
            For Each Fila As DataRow In TablaPlazoContrato.Rows
                cbxPlazoContrato.Items.Add(Fila.Item("Plazo"))
            Next
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=80", Con)
            cbxPlazoContrato.Tag = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Plazo FROM plazocontrato where IDPlazoContrato='" + cbxPlazoContrato.Tag.ToString + "'", ConLibregco)
            cbxPlazoContrato.Text = Convert.ToString(cmd.ExecuteScalar())

            'Cargar monedas habiles
            Ds.Clear()
            cbxMoneda.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipomoneda")

            Dim Tabla1 As DataTable = Ds.Tables("tipomoneda")

            For Each Fila As DataRow In Tabla1.Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem

                nvmoneda.Description = Fila.Item("Texto")
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                cbxMoneda.Properties.Items.Add(nvmoneda)
            Next

            'Moneda predeterminada
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
            cbxMoneda.EditValue = CInt(Convert.ToString(cmd.ExecuteScalar()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'CheckBoxes
            'Facturar Sin Existencias
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=21", Con)
            chkFacturarSExistencia.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar Cargos Por Mora
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=23", Con)
            chkHabilitarCobroCargos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Facturar por Debajo del Costo
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=16", Con)
            chkFactDebajoCosto.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir devoluciones en cualquier sucursal
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=47", Con)
            chkPermitirDevoSucursal.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar Precios de Articulos en Facturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=15", Con)
            chkMostpreciosFact.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar Usuarios Conectados
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=22", Con)
            chkMostrarUsuarios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Multiples Clientes en un solo Recibo de Cobro
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=14", Con)
            chkMultiplesCliRec.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Facturar con comprobantes fiscales agotados
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
            chkFactNCFAgotado.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Actualizar Costos en Compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=27", Con)
            chkActCostos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Actualizar Suplidor de artículos en compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=26", Con)
            chkActSupenArt.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Evitar Sábados en pagares
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=50", Con)
            chkEvitSabados.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Evitar Domingos en pagares
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=51", Con)
            chkEvitDomingos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'No. de Identificacion obligatoria para créditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=55", Con)
            chkNoIdentObligatoria.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar pagares en cobros
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=73", Con)
            chkShowPagaresenCobro.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir creditos sin contratos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=79", Con)
            chkPermCredSSol.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir cambio de plazo de las solicitudes de crédito
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=81", Con)
            chkPerCambioPlazoSol.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Encabezado de Factura
            '--------------------------------------------------------
            'Encabezado de facturas al contado
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=4", Con)
            txtEncFact.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pie de Factura
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=5", Con)
            txtPieFact.Text = Convert.ToString(cmd.ExecuteScalar())

            '---------------------------------------------------------
            'Encabezado de facturas a credito
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=151", Con)
            txtEncFactCredito.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pie de Factura
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=152", Con)
            txtPieFactCredito.Text = Convert.ToString(cmd.ExecuteScalar())

            'Encabezado de Recibo de Cobro
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=6", Con)
            txtEncReciboIngreso.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pie de Recibo de Cobro
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=7", Con)
            txtPieReciboIngreso.Text = Convert.ToString(cmd.ExecuteScalar())

            'Encabezado de Cotización
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=53", Con)
            txtEncCotizacion.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pie de Recibo de Cotización
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=54", Con)
            txtPieCotizacion.Text = Convert.ToString(cmd.ExecuteScalar())

            'Encabezado de deposito
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=147", Con)
            txtEncDeposito.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pie de deposito
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=148", Con)
            txtPieDeposito.Text = Convert.ToString(cmd.ExecuteScalar())

            'Dias para alertas de solicitudes de clientes
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=10", Con)
            txtDiasSolicitudClientes.Text = Convert.ToString(cmd.ExecuteScalar())

            'Dias para vencimiento de cheques devueltos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=17", Con)
            txtDiasVencimientoCheque.Text = Convert.ToString(cmd.ExecuteScalar())

            'Mínimo de comprobantes para lanzar alertas
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
            txtCantMinimaparaAlertaNCF.Text = Convert.ToString(cmd.ExecuteScalar())

            'Limite de Consultas
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=28", Con)
            txtLimiteConsultas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Ultima actualizacion de modulos
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=18", Con)
            txtUltimaActCXC.Text = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=39", Con)
            ColorFactCredito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=40", Con)
            ColorFactContado.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=41", Con)
            ColorAbonos.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=42", Con)
            ColorChequesDev.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=43", Con)
            ColorDevoluciones.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=44", Con)
            ColorNotaCredito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=45", Con)
            ColorNotaDebito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=46", Con)
            ColorCargos.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

            'Limitar vida útil de las contraseñas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=68", Con)
            chkLimPassLife.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Días de vida útil de las contraseñas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=69", Con)
            txtDiasUtilesPassword.Text = Convert.ToString(cmd.ExecuteScalar())

            'Días restantes para alertar vida útil de las contraseñas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=71", Con)
            txtDiasRestAlertPass.Text = Convert.ToString(cmd.ExecuteScalar())

            'Tamaño máximo de archivos adjuntos
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=70", Con)
            txtMaxSizeofFiles.Text = Convert.ToString(cmd.ExecuteScalar())

            'Seleccionar tipo de metodo de NCFs
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=75", Con)
            Dim TypeofMetode As String = Convert.ToString(cmd.ExecuteScalar())

            If TypeofMetode = 1 Then
                rdbMetodo1.Checked = True
            ElseIf TypeofMetode = 2 Then
                rdbMetodo2.Checked = True
            ElseIf TypeofMetode = 3 Then
                rdbMetodo3.Checked = True
            End If

            'Permitir cambiar estructura NCF
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=76", Con)
            GboxEstructuraNCF.Enabled = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Palabra clave de costos
            cmd = New MySqlCommand("SELECT Value1Var FROM Configuracion WHERE IDConfiguracion=78", Con)
            txtPalabraClaveCosto.Text = Convert.ToString(cmd.ExecuteScalar())

            'Pedir autorizacion para creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=82", Con)
            chkPedirAutCredito.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar código de cliente para facturas de contado a contraentrega
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=83", Con)
            chkHabilitarContraEntrega.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Código del cliente para facturas de contado a contraentrega
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=84", Con)
            If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
            Else
                txtIDClienteContraEntrega.Text = Convert.ToInt16(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select Nombre from Libregco.Clientes where IDCliente='" + txtIDClienteContraEntrega.Text + "'", ConLibregco)
                txtNombreContraEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
            End If

            'Bloquear codigo primario de clientes
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=85", Con)
            chkCodigoPrimarioClientes.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir facturas con balances vendidos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=86", Con)
            ChkFacturarconVencidas.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Visualizar controles para subir digitales de facturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=88", Con)
            chkControlDigitalFactura.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Visualizar controles para subir digitales de recibos de pagos de cuentass por pagar
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=89", Con)
            chkVisualDigitalesCXP.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Convertir fracciones en caracteres especiales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=90", Con)
            chkFraccionesTexto.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Sensibilidad de artículos relacionados
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=91", Con)
            NUSensibilidadRelacionados.Value = Convert.ToInt16(cmd.ExecuteScalar())

            'Descripción de duplicado de clientes de factura
            cmd = New MySqlCommand("Select Value1Var from Configuracion where IDConfiguracion=92", Con)
            txtDescripDuplicado.Text = Convert.ToString(cmd.ExecuteScalar())
            If txtDescripDuplicado.Text = "" Then
                txtDescripDuplicado.Text = "DUPLICADO"
            End If

            'Descripción de duplicado de despacho de factura
            cmd = New MySqlCommand("Select Value1Var from Configuracion where IDConfiguracion=93", Con)
            txtDescripDespacho.Text = Convert.ToString(cmd.ExecuteScalar())
            If txtDescripDespacho.Text = "" Then
                txtDescripDespacho.Text = "DESPACHO"
            End If

            'Descripción de duplicado de contabilidad de factura
            cmd = New MySqlCommand("Select Value1Var from Configuracion where IDConfiguracion=94", Con)
            txtDescripContabilidad.Text = Convert.ToString(cmd.ExecuteScalar())
            If txtDescripContabilidad.Text = "" Then
                txtDescripContabilidad.Text = "CONTABILIDAD"
            End If

            'Permitir cambiar fecha recibo
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=63", Con)
            chkCambiarFechaRecibos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir cambiar fecha factura
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=95", Con)
            chkCambiarFechaFact.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Generar Pagares automaticamente
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=96", Con)
            chkGenerarPagares.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar nombre de clientes al exceder limite
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=97", Con)
            chkSolicitarNombreLimite.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar montos de pagos con salarios
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=103", Con)
            chkControlarMontoPagosxSalario.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkControlarMontoPagosxSalario.Checked = False Then
                txtRelacionSalario.Enabled = False
            Else
                txtRelacionSalario.Enabled = True
            End If

            'Relación de control de montos de pagos con salarios
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=104", Con)
            txtRelacionSalario.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("P")

            'Limitar descuentos de recibos de ingresos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=8", Con)
            chkControlarDescuentos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkControlarDescuentos.Checked = False Then
                txtLimiteDescuentos.Enabled = False
            Else
                txtLimiteDescuentos.Enabled = True
            End If

            'Limite maximo descuentos de recibos de ingresos
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=56", Con)
            txtLimiteDescuentos.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Controlar informacion de tarjetas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=57", Con)
            chkControlarInfoTarjetas.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar informacion de edad de menores
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=58", Con)
            chkControlarFactMenores.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Limite maximo para solicitar nombres
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=98", Con)
            txtLimiteMaximoSolNombre.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Permitir deshabilitar las notificaciones
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=105", Con)
            chkPerDeshNotificaciones.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir deshabilitar el contenido de las notificaciones
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=106", Con)
            chkPerDeshConNotify.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir deshabilitar los consejos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=107", Con)
            ChkPerDeshConsejos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir deshabilitar el inicio automatico
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=108", Con)
            chkPerDeshInicioAutomatico.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir deshabilitar el bloqueo por inactividad
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=109", Con)
            chkPerDeshBloqueoInact.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Tiempo de bloqueo de inactividad en minutos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=110", Con)
            txtTiempoInactividad.Text = CInt(Convert.ToString(cmd.ExecuteScalar())) / 60

            'Permitir deshabilitar el audio
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=111", Con)
            chkPerDesactivarAudio.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir contraer el encabezado del inicio
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=112", Con)
            chkPerContraerEncInicio.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir modificar modal
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=113", Con)
            chkModificarModal.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Imponer NCF y telefonos en ventas con valor fiscal
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=114", Con)
            chkImponerRncTel.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar modificacion de contenido en precios
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=115", Con)
            chkHabModContenido.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar ventas a crédito sin inicial
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=116", Con)
            chkControlarventassinInicial.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Cerrar crédito autómaticamente al exceder cargos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=117", Con)
            chkCerrarCreditoconCargo.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkCerrarCreditoconCargo.Checked = True Then
                txtCargosMonto.Enabled = True
            Else
                txtCargosMonto.Enabled = False
            End If

            'Monto de cargos para cerrar crédito
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=118", Con)
            txtCargosMonto.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Tipo de agrupación de cargos
            '0 mensual  '1 unica
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=120", Con)
            If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                rdbMoraMensual.Checked = True
            Else
                rdbUnicaMora.Checked = True
            End If

            'Generar NCF en cargos mensuales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=121", Con)
            chkGenerarNCFCargo.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar info incompleta de clientes
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=122", Con)
            chkShowIncompletesInfoClientes.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Cantidad de registros para revisar nombre
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=123", Con)
            txtCantRevisionNombre.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Cerrar creditos por antiguedad
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=124", Con)
            chkCerrarCreditoporAntiguedad.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Cantidad de dias para cerrar credito
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=125", Con)
            txtDiasparaCerrarCredito.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Bloqueo de impresion rapida
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=126", Con)
            chkBloqueoImpresionRapida.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Cantidad de dias a guardar en bitacora
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=127", Con)
            txtDiasGuardarBitacora.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Habilitar modificacion en facturacion de articulo base No.1
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=128", Con)
            chkModificacionArticuloBase.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir facturación sin inventario de artículo base No.01
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=129", Con)
            chkFacturacionSinInvArticuloBase.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Activar Black Friday
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=131", Con)
            chkActivacionBlackFriday.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Liberar facturacion de Black Friday
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=132", Con)
            chkBlackFridayLiberarFacturacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Inicio de BlackFriday
            cmd = New MySqlCommand("Select Value4Datetime from Configuracion where IDConfiguracion=133", Con)
            dtpBlackFridayStart.Value = Convert.ToDateTime(cmd.ExecuteScalar())

            'Final de BlackFriday
            cmd = New MySqlCommand("Select Value4Datetime from Configuracion where IDConfiguracion=134", Con)
            dtpBlackFridayEnds.Value = Convert.ToDateTime(cmd.ExecuteScalar())

            'Desactivar las superclaves
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=135", Con)
            chkDesactivarSuperclaves.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Dar vida util a la prefacturaciones
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=136", Con)
            chkDarExpiracionPrefacturaciion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkDarExpiracionPrefacturaciion.Checked = False Then
                cbxVidaUtilPrefacturacion.Enabled = False
            Else
                cbxVidaUtilPrefacturacion.Enabled = True
            End If

            'Vida util a la prefacturaciones
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=137", Con)
            cbxVidaUtilPrefacturacion.SelectedIndex = Convert.ToInt16(cmd.ExecuteScalar())

            'Obligacion de copia de cedula
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=138", Con)
            chkIdentificacionFisiscaObligatoria.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Obligacion de seriales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=139", Con)
            chkObligacionSeriales.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar cantidad de pgares vencidos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=140", Con)
            chkControlCantidadPagaresVencidos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkControlCantidadPagaresVencidos.Checked = False Then
                GroupBox17.Enabled = False
            Else
                GroupBox17.Enabled = True
            End If

            'Cantidad de pgares vencidos permitidos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=141", Con)
            txtCantMaximaPagaresVencidos.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Controlar cantidad de facturas a credito pendiente
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=142", Con)
            chkControlCantidadCreditos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkControlCantidadCreditos.Checked = False Then
                GroupBox18.Enabled = False
            Else
                GroupBox18.Enabled = True
            End If

            'Cantidad de facturas a credito
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=143", Con)
            txtCantMaximaFacturasCredito.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Controlar monto minimo de pagares
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=144", Con)
            chkControlMontoMinimoPagare.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
            If chkControlMontoMinimoPagare.Checked = False Then
                GroupBox19.Enabled = False
            Else
                GroupBox19.Enabled = True
            End If

            'Monto minimo de pagares
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=145", Con)
            txtMontoMinimoPagare.Text = Convert.ToDouble(cmd.ExecuteScalar()).ToString("C")

            'Controlar tipo de pago en prefacturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=146", Con)
            chkControlarTipoPago.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar facturacion simultanea
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=149", Con)
            chkBloqueoFacturacionSimultanea.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir transacciones con tarjetas de credito
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=150", Con)
            ChkPermitirTarjetasFacturacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar boton de asistencia en inicio
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=153", Con)
            chkMostrarBotonAsistenciaInicio.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir cobros con tarjetas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=154", Con)
            chkPermitirCobrosTarjeta.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar direccion completa en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=155", Con)
            chkSolDireccionCompleta.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar telefono personal 1 en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=156", Con)
            chkSolTelefonoPersonal1.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar telefono personal 2 en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=157", Con)
            chkSolTelefonoPersonal2.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar garante en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=158", Con)
            chkSolGarante.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Solicitar informacion adicional
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=159", Con)
            chkSolInformacionAdc.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar impresion de duplicados
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=160", Con)
            chkImpresionCopiaMultiple.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar impresion de clientes
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=161", Con)
            chkCopiaCliente.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar impresion de despacho
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=162", Con)
            chkCopiaDespacho.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar impresion de contabilidad
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=163", Con)
            chkCopiaContabilidad.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Revalidar totales de compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=164", Con)
            chkRevalidarTotales.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Usar formato días de factura en formato largo
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=165", Con)
            chkCXCFormatoLargo.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir visualizar cálculos de corte de caja a todos los usuarios
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=166", Con)
            chkCalculoCorteCaja.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir filtrado de corte de caja
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=167", Con)
            chkPermitirFiltradoCorte.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Cantidad de decimales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=168", Con)
            txtCantDecimales.Value = Convert.ToInt16(cmd.ExecuteScalar())

            'Permitir duplicados en compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=169", Con)
            chkPermitirDuplicidadCompras.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir duplicados en facturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=170", Con)
            chkPermitirDuplicidadFacturacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir modificacion de articulos desde prefacturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=171", Con)
            chkPermitirModPrefactura.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir reeimpresion de originales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=172", Con)
            chkPermitirReimpresion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Utilizar hora en cortes de caja
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=173", Con)
            chkHoraCortesCaja.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Tiempo de espera de confirmación de tipo de pago
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=174", Con)
            TrackBar1.Value = Convert.ToInt16(Convert.ToInt16(cmd.ExecuteScalar()))
            Label80.Text = "Tiempo en espera de respuesta en segundos: " & TrackBar1.Value & " seg(s)"

            'Permitir facturas sin prefacturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=175", Con)
            chkPermitirFactSinPrefact.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'RNC Inteligente
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=176", Con)
            chkRNCInteligente.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir devolucion facturas con mas de 30 dias
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=177", Con)
            chkPermitirDev30.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Altura de las imágenes de facturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=178", Con)
            TrackBarFactura.Value = Convert.ToInt16(cmd.ExecuteScalar())
            PicFacturacion.Height = TrackBarFactura.Value

            'Altura de las imágenes de facturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=179", Con)
            TrackBarPrefactura.Value = Convert.ToInt16(cmd.ExecuteScalar())
            PicPrefactura.Height = TrackBarPrefactura.Value

            'Altura de las imágenes de compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=180", Con)
            TrackBarCompras.Value = Convert.ToInt16(cmd.ExecuteScalar())
            PicCompras.Height = TrackBarPrefactura.Value

            'Solicitar confirmacion de vendedor en facturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=181", Con)
            chkSolConfirmacionVendedor.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Dias para Alerta de acuerdos de pagos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=182", Con)
            txtDiasAlertasAcuerdos.Text = Convert.ToInt16(cmd.ExecuteScalar())

            'Solicitar confirmación para recepción en compras
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=183", Con)
            chkSolConfRecCompra.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Rellenar totales básicos en la verificación de subtotales
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=184", Con)
            chkLlenarAutVerificacionSub.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Visualizar historial de artículos completos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=185", Con)
            chkVisualArticulosCompletos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Redondear al entero mas cercano
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=186", Con)
            chkRedondearPrecios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=221", Con)
            ICBERedondeoHacia.EditValue = CStr(Convert.ToInt16(cmd.ExecuteScalar()))

            'Sensibilidad de descripcion de articulos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=222", Con)
            TBSensibilidadDescripcion.Value = Convert.ToInt16(cmd.ExecuteScalar())


            'Permitir múltiples accesos de usuarios
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=187", Con)
            chkMultipleUsuarios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir múltiples accesos de usuarios
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=188", Con)
            chkUtilizarReportesPredFacturacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))


            'Reporte de facturación para facturas al contado
            Dim Dstemp As New DataSet
            cmd = New MySqlCommand("SELECT IDReportes,Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Facturación' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Reportes")
            cbxReporteContado.DisplayMember = "Descripcion"
            cbxReporteContado.ValueMember = "IDReportes"
            cbxReporteContado.DataSource = Dstemp.Tables("Reportes")

            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=189", Con)
            cbxReporteContado.SelectedValue = Convert.ToInt16(cmd.ExecuteScalar())

            'Reporte de facturación para facturas al credito
            Dim Dstemp1 As New DataSet
            cmd = New MySqlCommand("SELECT IDReportes,Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Facturación' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp1, "Reportes")
            cbxReporteCredito.DisplayMember = "Descripcion"
            cbxReporteCredito.ValueMember = "IDReportes"
            cbxReporteCredito.DataSource = Dstemp1.Tables("Reportes")

            'Reportes de control de despacho
            Dim Dstemp2 As New DataSet
            cmd = New MySqlCommand("SELECT IDReportes,Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ControlDespacho' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp2, "Reportes")
            cbxControlDespachoPuntoVenta.DisplayMember = "Descripcion"
            cbxControlDespachoPuntoVenta.ValueMember = "IDReportes"
            cbxControlDespachoPuntoVenta.DataSource = Dstemp2.Tables("Reportes")

            cbxControlDespachoMediaPagina.DisplayMember = "Descripcion"
            cbxControlDespachoMediaPagina.ValueMember = "IDReportes"
            cbxControlDespachoMediaPagina.DataSource = Dstemp2.Tables("Reportes")

            cbxControlDespachoPaginaCompleta.DisplayMember = "Descripcion"
            cbxControlDespachoPaginaCompleta.ValueMember = "IDReportes"
            cbxControlDespachoPaginaCompleta.DataSource = Dstemp2.Tables("Reportes")

            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=190", Con)
            cbxReporteCredito.SelectedValue = Convert.ToInt16(cmd.ExecuteScalar())

            'Guardar automáticamente piezaje durante establecimiento de la cantidad
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=191", Con)
            chkGuardarAutPietaje.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Redondear cálculos de costos y precios al realizar piezaje
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=192", Con)
            chkRedondearPreciosPiezaje.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Guardar automáticamente el cálculo de costos y precios durante el piezaje
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=193", Con)
            chkGuardarCalculosPiezaje.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Tipo de consulta en el formulario de búsqueda de artículos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=194", Con)
            If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                rdbDirecto.Checked = True
            Else
                rdbPredictivo.Checked = True
            End If

            'Controlar precios de venta por niveles 
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=195", Con)
            chkControlarPreciosNiveles.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Permitir facturación con límite de crédito agotado
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=196", Con)
            chkPermitirFactLimiteAgotado.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar número de orden en el formulario de prefactura
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=197", Con)
            chkMostrarNoOrden.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar artículos similares durante la prefacturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=198", Con)
            chkMostrarSimiliaresPrefact.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar artículos relacionados durante la prefacturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=199", Con)
            chkMostrarRelacionadasPrefac.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar sólo artículos con existencia al mostrar los similares durante prefacturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=200", Con)
            chkSoloconExistSimilares.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Mostrar artículos relacionados durante la prefacturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=201", Con)
            chkSoloconExistenciaRelacionados.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Control de despacho en facturación
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=202", Con)
            chkHabilitarControlDespacho.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar control en reportes de página completa
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=203", Con)
            chkControlDespachoPagina.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar control en reportes de media pagina
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=204", Con)
            chkControlDespachoMedia.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Habilitar control en reportes de punto de venta
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=205", Con)
            chkControlDespachoPunto.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Reporte de control de despacho para página completa
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=206", Con)
            cbxControlDespachoPaginaCompleta.SelectedValue = Convert.ToInt16(cmd.ExecuteScalar())

            'Reporte de control de despacho para media pagina
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=207", Con)
            cbxControlDespachoMediaPagina.SelectedValue = Convert.ToInt16(cmd.ExecuteScalar())

            'Reporte de control de despacho para punto de venta
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=208", Con)
            cbxControlDespachoPuntoVenta.SelectedValue = Convert.ToInt16(cmd.ExecuteScalar())

            'Deshabilitar verificacion de correo electronico
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=210", Con)
            chkDeshabilitarVerificacionCorreo.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Bloquear toda facturación de artículo con precio CERO RD$ 0
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=211", Con)
            chkBloqueoPrecioCero.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Activar sensibilidad sobre el costo cubierto
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=213", Con)
            chkSensibilidadControlVenta.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            If chkSensibilidadControlVenta.Checked Then
                TrackBar2.Enabled = True
            Else
                TrackBar2.Enabled = False
            End If

            'Porcentaje del costo cubierto para exonerar controles de ventas
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=214", Con)
            TrackBar2.Value = Convert.ToInt16(cmd.ExecuteScalar())
            chkSensibilidadControlVenta.Text = "Activar sensibilidad de venta sobre el costo de venta al " & TrackBar2.Value & "%"

            If chkHabilitarControlDespacho.Checked = True Then
                GroupBox33.Enabled = True
            Else
                GroupBox33.Enabled = False
            End If

            If chkControlDespachoPagina.Checked Then
                cbxControlDespachoPaginaCompleta.Enabled = True
            Else
                cbxControlDespachoPaginaCompleta.Enabled = False
            End If

            If chkControlDespachoMedia.Checked Then
                cbxControlDespachoMediaPagina.Enabled = True
            Else
                cbxControlDespachoMediaPagina.Enabled = False
            End If

            If chkControlDespachoPunto.Checked Then
                cbxControlDespachoPuntoVenta.Enabled = True
            Else
                cbxControlDespachoPuntoVenta.Enabled = False
            End If

            'Abrir último listado de artículos automáticamente
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=215", Con)
            chkLlenarListadoProductos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Bloquear acceso a sistema con accesos fallidos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=216", Con)
            chkBloquearUsuarios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Bloquear facturación de artículos sin compras ni ventas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=217", Con)
            chkBloquearFactArtSNComprasVentas.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'No generar NCF para ventas de consumidor final
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=218", Con)
            chkNoGenerarNCFparaDevoluciones.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Controlar dias de notas de contado
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=219", Con)
            chkControlarNotasContado.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

            'Días máximo de las notas de contado
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=220", Con)
            txtDiasNotas.Value = Convert.ToInt16(cmd.ExecuteScalar())

            'Cargar superclaves
            DgvSuperClaves.Rows.Clear()
            Dim CmdSuperClaves As New MySqlCommand("Select IDModulo,Modulo,Clave FROM modulos", Con)
            Dim LectorSuperClaves As MySqlDataReader = CmdSuperClaves.ExecuteReader

            While LectorSuperClaves.Read
                DgvSuperClaves.Rows.Add(LectorSuperClaves.GetValue(0), LectorSuperClaves.GetValue(1), LectorSuperClaves.GetValue(2))
            End While
            LectorSuperClaves.Close()

            'Cargar Acciones SuperClaves
            DgvAcciones.Rows.Clear()
            cmd = New MySqlCommand("Select idAccionesSuperClave, Modulos.Modulo,AccionesModulos.Descripcion,AccionesModulos.Activo FROM" & SysName.Text & "accionesmodulos inner join" & SysName.Text & "Modulos On AccionesModulos.IDModulo=Modulos.IDModulo ORDER BY AccionesModulos.IDModulo ASC", Con)
            Dim LectorAcciones As MySqlDataReader = cmd.ExecuteReader

            While LectorAcciones.Read
                DgvAcciones.Rows.Add(LectorAcciones.GetValue(0), LectorAcciones.GetValue(1), LectorAcciones.GetValue(2), Convert.ToBoolean(LectorAcciones.GetValue(3)))
            End While
            LectorAcciones.Close()

            'Cargar formatos de impresion
            DgvFormatos.Rows.Clear()
            cmd = New MySqlCommand("Select IDPaperSize,SizeName,Activo,PrinterKey FROM libregco.papersize", Con)
            Dim LectorFormatos As MySqlDataReader = cmd.ExecuteReader

            While LectorFormatos.Read
                DgvFormatos.Rows.Add(LectorFormatos.GetValue(0), LectorFormatos.GetValue(1), Convert.ToBoolean(LectorFormatos.GetValue(2)), LectorFormatos.GetValue(3))
            End While
            LectorFormatos.Close()


            Con.Close()
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & " " & cmd.CommandText.ToString & " " & sqlQ, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select * from razonsocial where IDRazon=(Select Max(IDRazon) from razonsocial)", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "razonsocial")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("razonsocial")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No existen datos sobre empresa alguna. Por favor registre la empresa y sus datos correspondientes.", "No existe empresa en base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_razon_social.ShowDialog(Me)
                Exit Sub
            Else
                LboxInfoEmpresa.Items.Clear()
                With LboxInfoEmpresa
                    .Items.Add("Nombre de la Empresa:")
                    .Items.Add(Tabla.Rows(0).Item("NombreEmpresa"))
                    .Items.Add("")
                    .Items.Add("Eslogan:")
                    .Items.Add(Tabla.Rows(0).Item("Eslogan"))
                    .Items.Add("")
                    .Items.Add("Registro Nacional del Contribuyente:")
                    .Items.Add(Tabla.Rows(0).Item("RNC"))
                    .Items.Add("")
                    .Items.Add("Dirección:")
                    .Items.Add(Tabla.Rows(0).Item("Direccion"))
                    .Items.Add("")
                    .Items.Add("Teléfonos:")
                    .Items.Add((Tabla.Rows(0).Item("Telefono")) & "   " & (Tabla.Rows(0).Item("Telefono1")) & "   " & (Tabla.Rows(0).Item("Telefono2")))
                    .Items.Add("")
                    .Items.Add("Ruta de Logo Corporativo:")
                    .Items.Add(Tabla.Rows(0).Item("RutaLogo"))
                    .Items.Add("Proporción del Logo:")
                    .Items.Add("Alto: " & Tabla.Rows(0).Item("Alto") & " x " & "Ancho: " & Tabla.Rows(0).Item("Ancho"))
                End With

                PicBoxLogo.Image = ConseguirLogoEmpresa()

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub btnModificarEmpresa_Click(sender As Object, e As EventArgs) Handles btnModificarEmpresa.Click
        frm_superclave.IDAccion.Text = 3
        frm_superclave.ShowDialog(Me)
        If ControlSuperClave = 0 Then
            frm_razon_social.ShowDialog(Me)
        End If

    End Sub

    Private Sub txtMoraDiaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMoraDiaria.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub CalcularMora()
        Try
            Dim Mora As Double = CDbl(Replace(txtMoraDiaria.Text, "%", "")) / 100
            txtMoraMensual.Text = (Mora * 30).ToString("P2")
            txtMoraAnual.Text = (Mora * 30 * 12).ToString("P2")

        Catch ex As Exception
            txtMoraDiaria.Undo()
        End Try

    End Sub

    Private Sub txtMoraDiaria_Leave(sender As Object, e As EventArgs) Handles txtMoraDiaria.Leave
        Try
            If txtMoraDiaria.Text = "" Then
                txtMoraDiaria.Text = CDbl(0).ToString("P2")
            Else
                txtMoraDiaria.Text = CDbl(txtMoraDiaria.Text).ToString("P2")
            End If

        Catch ex As Exception
            txtMoraDiaria.Text = CDbl(0).ToString("P2")
        End Try
    End Sub

    Private Sub txtMoraDiaria_Enter(sender As Object, e As EventArgs) Handles txtMoraDiaria.Enter
        Try
            If txtMoraDiaria.Text = "" Then
            Else
                txtMoraDiaria.Text = CDbl(Replace(txtMoraDiaria.Text, "%", "")) / 100
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtMoraDiaria_TextChanged(sender As Object, e As EventArgs) Handles txtMoraDiaria.TextChanged
        CalcularMora()
    End Sub

    Private Sub ConvertDouble()
        txtMoraDiaria.Text = CDbl(Replace(txtMoraDiaria.Text, "%", "")) / 100
        txtRelacionSalario.Text = CDbl(Replace(txtRelacionSalario.Text, "%", "")) / 100
        txtTasaTSS.Text = CDbl(Replace(txtTasaTSS.Text, "%", "")) / 100
        txtItbisGeneral.Text = CDbl(Replace(txtItbisGeneral.Text, "%", "")) / 100
        txtLimiteMaximoSolNombre.Text = CDbl(txtLimiteMaximoSolNombre.Text)
        txtLimiteDescuentos.Text = CDbl(txtLimiteDescuentos.Text)
        txtCargosMonto.Text = CDbl(txtCargosMonto.Text)
        txtMontoMinimoPagare.Text = CDbl(txtMontoMinimoPagare.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMoraDiaria.Text = CDbl(txtMoraDiaria.Text).ToString("P2")
        txtRelacionSalario.Text = CDbl(txtRelacionSalario.Text).ToString("P2")
        txtItbisGeneral.Text = CDbl(txtItbisGeneral.Text).ToString("P2")
        txtTasaTSS.Text = CDbl(txtTasaTSS.Text).ToString("P2")
        txtLimiteMaximoSolNombre.Text = CDbl(txtLimiteMaximoSolNombre.Text).ToString("C")
        txtLimiteDescuentos.Text = CDbl(txtLimiteDescuentos.Text).ToString("C")
        txtCargosMonto.Text = CDbl(txtCargosMonto.Text).ToString("C")
        txtMontoMinimoPagare.Text = CDbl(txtMontoMinimoPagare.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try

            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Con.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en los ajustes?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                If cbxReporteContado.Text = "" Then
                    MessageBox.Show("Seleccione el reporte predeterminado para facturas al contado.")
                    Exit Sub
                ElseIf cbxReporteCredito.Text = "" Then
                    MessageBox.Show("Seleccione el reporte predeterminado para facturas a crédito.")
                    Exit Sub
                ElseIf cbxControlDespachoPaginaCompleta.Text = "" Then
                    MessageBox.Show("Seleccione el reporte de control de despacho para impresiones de página completa.")
                    Exit Sub
                ElseIf cbxControlDespachoMediaPagina.Text = "" Then
                    MessageBox.Show("Seleccione el reporte de control de despacho para impresiones de media página.")
                    Exit Sub
                ElseIf cbxControlDespachoPuntoVenta.Text = "" Then
                    MessageBox.Show("Seleccione el reporte de control de despacho para impresiones de puntos de ventaa.")
                    Exit Sub
                End If

                Cursor = Cursors.AppStarting
                ConvertDouble()
                Con.Open()
                ConLibregco.Open()

                'Tasa de Mora
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtMoraDiaria.Text + "' WHERE IDConfiguracion=3"
                GuardarDatos()

                'Aviso de inconsistencia
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkAvisarIncosistencia.CheckState).ToString + "' WHERE IDConfiguracion=9"
                GuardarDatos()

                'Itbis General
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtItbisGeneral.Text + "' WHERE IDConfiguracion=11"
                GuardarDatos()

                'Dias en condicion de pagares
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasCondicion.Text + "' WHERE IDConfiguracion=52"
                GuardarDatos()

                'Tasa de TSS
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtTasaTSS.Text + "' WHERE IDConfiguracion=77"
                GuardarDatos()

                'NCF Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxNCFPredeterminado.Tag.ToString + "' WHERE IDConfiguracion=13"
                GuardarDatos()

                'Cobrador Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxCobradorPred.Tag.ToString + "' WHERE IDConfiguracion=25"
                GuardarDatos()

                'Permitir Devoluciones en cualquier sucursal
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirDevoSucursal.CheckState).ToString + "' WHERE IDConfiguracion=47"
                GuardarDatos()

                'Condicion Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxCondicion.Tag.ToString + "' WHERE IDConfiguracion=59"
                GuardarDatos()

                'Facturar Sin Existencia
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkFacturarSExistencia.CheckState).ToString + "' WHERE IDConfiguracion=21"
                GuardarDatos()

                'Habilitar Cargo por Mora
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHabilitarCobroCargos.CheckState).ToString + "' WHERE IDConfiguracion=23"
                GuardarDatos()

                'Facturar por Debajo de Costo
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkFactDebajoCosto.CheckState).ToString + "' WHERE IDConfiguracion=16"
                GuardarDatos()

                'Mostrar Precios en Facturacion
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostpreciosFact.CheckState).ToString + "' WHERE IDConfiguracion=15"
                GuardarDatos()

                'Mostrar Usuarios Conectados
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarUsuarios.CheckState).ToString + "' WHERE IDConfiguracion=22"
                GuardarDatos()

                'Multiples Clientes en Recibo de Cobro
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMultiplesCliRec.CheckState).ToString + "' WHERE IDConfiguracion=14"
                GuardarDatos()

                'Facturar con Comprobantes Agotados
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkFactNCFAgotado.CheckState).ToString + "' WHERE IDConfiguracion=24"
                GuardarDatos()

                'Actualizar Automaticamente Costos en Compras
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkActCostos.CheckState).ToString + "' WHERE IDConfiguracion=27"
                GuardarDatos()

                'Actualizar Automaticamente Suplidor de artículos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkActSupenArt.CheckState).ToString + "' WHERE IDConfiguracion=26"
                GuardarDatos()

                'Evitar Sabados en pagares
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkEvitSabados.CheckState).ToString + "' WHERE IDConfiguracion=50"
                GuardarDatos()

                'Evitar Domingos en pagares
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkEvitDomingos.CheckState).ToString + "' WHERE IDConfiguracion=51"
                GuardarDatos()

                'Fact Encabezado contado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtEncFact.Text + "' WHERE IDConfiguracion=4"
                GuardarDatos()

                'Fact Pie contado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPieFact.Text + "' WHERE IDConfiguracion=5"
                GuardarDatos()

                'Fact Encabezado  Credito
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtEncFactCredito.Text + "' WHERE IDConfiguracion=151"
                GuardarDatos()

                'Fact Pie  Credito
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPieFactCredito.Text + "' WHERE IDConfiguracion=152"
                GuardarDatos()

                'Cobro Encabezado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtEncReciboIngreso.Text + "' WHERE IDConfiguracion=6"
                GuardarDatos()

                'Cobro Pie
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPieReciboIngreso.Text + "' WHERE IDConfiguracion=7"
                GuardarDatos()

                'Cotización Encabezado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtEncCotizacion.Text + "' WHERE IDConfiguracion=53"
                GuardarDatos()

                'Cotización Pie
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPieCotizacion.Text + "' WHERE IDConfiguracion=54"
                GuardarDatos()

                'Deposito Encabezado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtEncDeposito.Text + "' WHERE IDConfiguracion=147"
                GuardarDatos()

                'Deposito Pie
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPieDeposito.Text + "' WHERE IDConfiguracion=148"
                GuardarDatos()

                'Dias para Alertas de Solicitudes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasSolicitudClientes.Text + "' WHERE IDConfiguracion=10"
                GuardarDatos()

                'Dias para Vencimiento de Cheques Devueltos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasVencimientoCheque.Text + "' WHERE IDConfiguracion=17"
                GuardarDatos()

                'Cantidad Restante para Alertas en Comprobantes Fiscales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantMinimaparaAlertaNCF.Text + "' WHERE IDConfiguracion=12"
                GuardarDatos()

                'Limite de Busqueda en Consultas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtLimiteConsultas.Text + "' WHERE IDConfiguracion=28"
                GuardarDatos()

                'Guardar color de facturas crédito
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorFactCredito.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=39"
                GuardarDatos()

                'Guardar color de facturas contado
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorFactContado.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=40"
                GuardarDatos()

                'Guardar color abonos
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorAbonos.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=41"
                GuardarDatos()

                'Guardar color cheques devueltos
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorChequesDev.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=42"
                GuardarDatos()

                'Guardar color devoluciones
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorDevoluciones.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=43"
                GuardarDatos()

                'Guardar color notas de credito
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorNotaCredito.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=44"
                GuardarDatos()

                'Guardar color notas de debito
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorNotaDebito.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=45"
                GuardarDatos()

                'Guardar color cargos
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorCargos.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=46"
                GuardarDatos()

                'Identificacion obligatoria en créditos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkNoIdentObligatoria.CheckState).ToString + "' WHERE IDConfiguracion=55"
                GuardarDatos()

                'Estado Civil Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxEstadoCivil.Tag.ToString + "' WHERE IDConfiguracion=60"
                GuardarDatos()

                'Estado Civil Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + CbxOcupacion.Tag.ToString + "' WHERE IDConfiguracion=61"
                GuardarDatos()

                'Nacionalidad Predeterminado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxNacionalidad.Tag.ToString + "' WHERE IDConfiguracion=62"
                GuardarDatos()

                'Limitar vida útil de las contraseñas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkLimPassLife.CheckState).ToString + "' WHERE IDConfiguracion=68"
                GuardarDatos()

                'Dias de vida útil de las contraseñas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasUtilesPassword.Text + "' WHERE IDConfiguracion=69"
                GuardarDatos()

                'Dias restantes para alertar vida util de contraseñas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasRestAlertPass.Text + "' WHERE IDConfiguracion=71"
                GuardarDatos()

                'Tamaño máximo de archivos anexos
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtMaxSizeofFiles.Text + "' WHERE IDConfiguracion=70"
                GuardarDatos()

                'Palabra clave costos
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPalabraClaveCosto.Text + "' WHERE IDConfiguracion=78"
                DTConfiguracion.Rows(78 - 1).Item("Value1Var") = txtPalabraClaveCosto.Text
                GuardarDatos()

                'Mostrar pagares en cobros
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkShowPagaresenCobro.CheckState).ToString + "' WHERE IDConfiguracion=73"
                GuardarDatos()

                'Permitir créditos sin contratos de solicitud
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermCredSSol.CheckState).ToString + "' WHERE IDConfiguracion=79"
                GuardarDatos()

                'Código de plazo pre-establecido para solicitudes de crédito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxPlazoContrato.Tag.ToString + "' WHERE IDConfiguracion=80"
                GuardarDatos()

                'Permitir cambio de plazo de las solicitudes de crédito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerCambioPlazoSol.CheckState).ToString + "' WHERE IDConfiguracion=81"
                GuardarDatos()

                'Pedir autorizacion para créditos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPedirAutCredito.CheckState).ToString + "' WHERE IDConfiguracion=82"
                GuardarDatos()

                'Habilitar código de cliente para facturas de contado a contraentrega
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHabilitarContraEntrega.CheckState).ToString + "' WHERE IDConfiguracion=83"
                GuardarDatos()

                'Código del cliente para facturas de contado a contraentrega
                If txtIDClienteContraEntrega.Text <> "" Then
                    sqlQ = "UPDATE Configuracion SET Value2Int='" + txtIDClienteContraEntrega.Text + "' WHERE IDConfiguracion=84"
                    GuardarDatos()
                End If

                'Bloquear codig primario de clientes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCodigoPrimarioClientes.CheckState).ToString + "' WHERE IDConfiguracion=85"
                GuardarDatos()

                'Permitir facturas con balances vendidos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(ChkFacturarconVencidas.CheckState).ToString + "' WHERE IDConfiguracion=86"
                GuardarDatos()

                'Visualizar controles para subir digitales de facturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlDigitalFactura.CheckState).ToString + "' WHERE IDConfiguracion=88"
                GuardarDatos()

                'Visualizar controles para subir digitales de recibos de pagos de cuentass por pagar
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkVisualDigitalesCXP.CheckState).ToString + "' WHERE IDConfiguracion=89"
                GuardarDatos()

                'Convertir fracciones en caracteres especiales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkFraccionesTexto.CheckState).ToString + "' WHERE IDConfiguracion=90"
                GuardarDatos()

                'Convertir fracciones en caracteres especiales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(NUSensibilidadRelacionados.Value).ToString + "' WHERE IDConfiguracion=91"
                GuardarDatos()

                'Descripción de duplicado de clientes de factura
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtDescripDuplicado.Text + "' WHERE IDConfiguracion=92"
                GuardarDatos()

                'Descripción de despacho de factura
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtDescripDespacho.Text + "' WHERE IDConfiguracion=93"
                GuardarDatos()

                'Descripción de contabilidad  de factura
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtDescripContabilidad.Text + "' WHERE IDConfiguracion=94"
                GuardarDatos()

                'Guardar metodo para tipo de estructura NCF
                Dim TypeMetodo As New Label
                If rdbMetodo1.Checked = True Then
                    TypeMetodo.Text = 1
                    'sqlQ = "UPDATE ComprobanteFiscal SET Serie='A'"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Crédito Fiscal' WHERE IDComprobanteFiscal=1"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Consumidor Final' WHERE IDComprobanteFiscal=2"
                    'GuardarDatos()
                ElseIf rdbMetodo2.Checked = True Then
                    TypeMetodo.Text = 2
                    'sqlQ = "UPDATE ComprobanteFiscal SET Serie='A'"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Crédito Fiscal' WHERE IDComprobanteFiscal=1"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Consumidor Final' WHERE IDComprobanteFiscal=2"
                    'GuardarDatos()
                ElseIf rdbMetodo3.Checked = True Then
                    TypeMetodo.Text = 3
                    'sqlQ = "UPDATE ComprobanteFiscal SET Serie='B'"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Factura de Crédito (Fiscal)' WHERE IDComprobanteFiscal=1"
                    'GuardarDatos()
                    'sqlQ = "UPDATE ComprobanteFiscal SET TipoComprobante='Factura de Consumo' WHERE IDComprobanteFiscal=2"
                    'GuardarDatos()
                End If
                sqlQ = "UPDATE Configuracion SET Value2Int='" + TypeMetodo.Text + "' WHERE IDConfiguracion=75"
                GuardarDatos()

                'Cambiar fecha de ingreso
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCambiarFechaRecibos.CheckState).ToString + "' WHERE IDConfiguracion=63"
                GuardarDatos()

                'Cambiar fecha de factura
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCambiarFechaFact.CheckState).ToString + "' WHERE IDConfiguracion=95"
                GuardarDatos()

                'Generar pagares automaticamente
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGenerarPagares.CheckState).ToString + "' WHERE IDConfiguracion=96"
                GuardarDatos()

                'Solicitar nombre de clientes al exceder limite
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolicitarNombreLimite.CheckState).ToString + "' WHERE IDConfiguracion=97"
                GuardarDatos()

                'Generar pagares automaticamente
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtLimiteMaximoSolNombre.Text + "' WHERE IDConfiguracion=98"
                GuardarDatos()

                'Limitar descuentos de recibos de ingresos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarDescuentos.CheckState).ToString + "' WHERE IDConfiguracion=8"
                GuardarDatos()

                'Generar pagares automaticamente
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtLimiteDescuentos.Text + "' WHERE IDConfiguracion=56"
                GuardarDatos()

                'Controlar informacion de tarjetas de credito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarInfoTarjetas.CheckState).ToString + "' WHERE IDConfiguracion=57"
                GuardarDatos()

                'Controlar informacion de edad de clientes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarFactMenores.CheckState).ToString + "' WHERE IDConfiguracion=58"
                GuardarDatos()

                'Controlar montos de pagos con salarios
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarMontoPagosxSalario.CheckState).ToString + "' WHERE IDConfiguracion=103"
                GuardarDatos()

                'Relación de control de montos de pagos con salarios
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtRelacionSalario.Text + "' WHERE IDConfiguracion=104"
                GuardarDatos()

                'Permitir deshabilitar las notificaciones
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerDeshNotificaciones.CheckState).ToString + "' WHERE IDConfiguracion=105"
                GuardarDatos()

                'Permitir deshabilitar el contenido de las notificaciones
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerDeshConNotify.CheckState).ToString + "' WHERE IDConfiguracion=106"
                GuardarDatos()

                'Permitir deshabilitar los consejos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(ChkPerDeshConsejos.CheckState).ToString + "' WHERE IDConfiguracion=107"
                GuardarDatos()

                'Permitir deshabilitar el inicio automatico
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerDeshInicioAutomatico.CheckState).ToString + "' WHERE IDConfiguracion=108"
                GuardarDatos()

                'Permitir deshabilitar el bloqueo por inactividad
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerDeshBloqueoInact.CheckState).ToString + "' WHERE IDConfiguracion=109"
                GuardarDatos()

                'Tiempo de bloqueo de inactividad en minutos
                Dim SecondsInac As Integer = CInt(txtTiempoInactividad.Text) * 60
                sqlQ = "UPDATE Configuracion SET Value2Int='" + SecondsInac.ToString + "' WHERE IDConfiguracion=110"
                GuardarDatos()

                'Permitir deshabilitar el audio
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerDesactivarAudio.CheckState).ToString + "' WHERE IDConfiguracion=111"
                GuardarDatos()

                'Permitir contraer el encabezado del inicio
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPerContraerEncInicio.CheckState).ToString + "' WHERE IDConfiguracion=112"
                GuardarDatos()

                'Permitir modificar modal
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkModificarModal.CheckState).ToString + "' WHERE IDConfiguracion=113"
                GuardarDatos()

                'Imponer RNC y telefonos en ventas con valor fiscal
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkImponerRncTel.CheckState).ToString + "' WHERE IDConfiguracion=114"
                GuardarDatos()

                'Habilitar modificacion de contenido en precios
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHabModContenido.CheckState).ToString + "' WHERE IDConfiguracion=115"
                GuardarDatos()

                'Controlar ventas a crédito sin inicial
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarventassinInicial.CheckState).ToString + "' WHERE IDConfiguracion=116"
                GuardarDatos()

                'Cerrar crédito autómaticamente al exceder cargos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCerrarCreditoconCargo.CheckState).ToString + "' WHERE IDConfiguracion=117"
                GuardarDatos()

                'Monto de cargos para cerrar crédito
                sqlQ = "UPDATE Configuracion SET Value3Double='" + txtCargosMonto.Text + "' WHERE IDConfiguracion=118"
                GuardarDatos()

                'Tipo de agrupación de cargos
                '0 mensual  '1 unica
                If rdbUnicaMora.Checked = True Then
                    sqlQ = "UPDATE Configuracion SET Value2Int=1 WHERE IDConfiguracion=120"
                    GuardarDatos()
                Else
                    sqlQ = "UPDATE Configuracion SET Value2Int=0 WHERE IDConfiguracion=120"
                    GuardarDatos()
                End If

                'Generar NCF en cargos mensuales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGenerarNCFCargo.CheckState).ToString + "' WHERE IDConfiguracion=121"
                GuardarDatos()

                'Mostrar info incompleta de clientes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkShowIncompletesInfoClientes.CheckState).ToString + "' WHERE IDConfiguracion=122"
                GuardarDatos()

                'Cantidad de registros para verificar nombres
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantRevisionNombre.Text + "' WHERE IDConfiguracion=123"
                GuardarDatos()

                'Cerrar creditos por antiguedad
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCerrarCreditoporAntiguedad.CheckState).ToString + "' WHERE IDConfiguracion=124"
                GuardarDatos()

                'Cantidad de dias para cerrar creito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasparaCerrarCredito.Text + "' WHERE IDConfiguracion=125"
                GuardarDatos()

                'Bloqueo de impresion rapida
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBloqueoImpresionRapida.CheckState).ToString + "' WHERE IDConfiguracion=126"
                GuardarDatos()

                'Cantidad de dias a guardar en bitacora
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasGuardarBitacora.Text + "' WHERE IDConfiguracion=127"
                GuardarDatos()

                'Habilitar modificación en facturación del artículo base No.01
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkModificacionArticuloBase.CheckState).ToString + "' WHERE IDConfiguracion=128"
                GuardarDatos()

                'Permitir facturación sin inventario de artículo base No.01
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkFacturacionSinInvArticuloBase.CheckState).ToString + "' WHERE IDConfiguracion=129"
                GuardarDatos()

                'Activar Black Friday
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkActivacionBlackFriday.CheckState).ToString + "' WHERE IDConfiguracion=131"
                GuardarDatos()

                'Liberar precios de black friday
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBlackFridayLiberarFacturacion.CheckState).ToString + "' WHERE IDConfiguracion=132"
                GuardarDatos()

                'Inicio de Black Friday
                sqlQ = "UPDATE Configuracion SET Value4Datetime='" + dtpBlackFridayStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE IDConfiguracion=133"
                GuardarDatos()

                'Final de Black Friday
                sqlQ = "UPDATE Configuracion SET Value4Datetime='" + dtpBlackFridayEnds.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE IDConfiguracion=134"
                GuardarDatos()

                'Desactivar las superclaves
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkDesactivarSuperclaves.CheckState).ToString + "' WHERE IDConfiguracion=135"
                GuardarDatos()

                'Dar vida util a las prefacturaciones
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkDarExpiracionPrefacturaciion.CheckState).ToString + "' WHERE IDConfiguracion=136"
                GuardarDatos()

                'Tiempo de vida util a las prefacturaciones
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxVidaUtilPrefacturacion.SelectedIndex.ToString + "' WHERE IDConfiguracion=137"
                GuardarDatos()

                'Obligacion de cedulas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkIdentificacionFisiscaObligatoria.CheckState).ToString + "' WHERE IDConfiguracion=138"
                GuardarDatos()

                'Obligacion de seriales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkObligacionSeriales.CheckState).ToString + "' WHERE IDConfiguracion=139"
                GuardarDatos()

                'Controlar cantidad de pagares vencidos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlCantidadPagaresVencidos.CheckState).ToString + "' WHERE IDConfiguracion=140"
                GuardarDatos()

                'Cantidad de pagares vencidos permitidos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantMaximaPagaresVencidos.Text + "' WHERE IDConfiguracion=141"
                GuardarDatos()

                'Controlar cantidad de facturas pendientes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlCantidadCreditos.CheckState).ToString + "' WHERE IDConfiguracion=142"
                GuardarDatos()

                'Cantidad de facturas pendientes permitidas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantMaximaFacturasCredito.Text + "' WHERE IDConfiguracion=143"
                GuardarDatos()

                'Controlar monto de pagares
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlMontoMinimoPagare.CheckState).ToString + "' WHERE IDConfiguracion=144"
                GuardarDatos()

                'Monto minimo de pagares
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtMontoMinimoPagare.Text + "' WHERE IDConfiguracion=145"
                GuardarDatos()

                'Controlar tipo de pago en prefacturacion
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarTipoPago.CheckState).ToString + "' WHERE IDConfiguracion=146"
                GuardarDatos()

                'Bloquear facturacion simultanea
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBloqueoFacturacionSimultanea.CheckState).ToString + "' WHERE IDConfiguracion=149"
                GuardarDatos()

                'Permitir transacciones con tarjetas de credito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(ChkPermitirTarjetasFacturacion.CheckState).ToString + "' WHERE IDConfiguracion=150"
                GuardarDatos()

                'Mostrar boton de assistencia en inicio
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarBotonAsistenciaInicio.CheckState).ToString + "' WHERE IDConfiguracion=153"
                GuardarDatos()

                'Permitir cobros con tarjetas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirCobrosTarjeta.CheckState).ToString + "' WHERE IDConfiguracion=154"
                GuardarDatos()

                'Solicitar direccion para creditos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolDireccionCompleta.CheckState).ToString + "' WHERE IDConfiguracion=155"
                GuardarDatos()

                'Solicitar Telefono Personal 1
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolTelefonoPersonal1.CheckState).ToString + "' WHERE IDConfiguracion=156"
                GuardarDatos()

                'Solicitar telefono Personal 2
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolTelefonoPersonal2.CheckState).ToString + "' WHERE IDConfiguracion=157"
                GuardarDatos()

                'Solicitar garante
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolGarante.CheckState).ToString + "' WHERE IDConfiguracion=158"
                GuardarDatos()

                'Solicitar informacion adicional
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolInformacionAdc.CheckState).ToString + "' WHERE IDConfiguracion=159"
                GuardarDatos()

                'Habilitar impresion de duplicados
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkImpresionCopiaMultiple.CheckState).ToString + "' WHERE IDConfiguracion=160"
                GuardarDatos()

                'Habilitar impresion de clientes
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCopiaCliente.CheckState).ToString + "' WHERE IDConfiguracion=161"
                GuardarDatos()

                'Habilitar impresion de duplicados
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCopiaDespacho.CheckState).ToString + "' WHERE IDConfiguracion=162"
                GuardarDatos()

                'Habilitar impresion de duplicados
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCopiaContabilidad.CheckState).ToString + "' WHERE IDConfiguracion=163"
                GuardarDatos()

                'Revalidad totales de compras                                                                                       
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkRevalidarTotales.CheckState).ToString + "' WHERE IDConfiguracion=164"
                GuardarDatos()

                'Usar formato días de factura en formato largo
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCXCFormatoLargo.CheckState).ToString + "' WHERE IDConfiguracion=165"
                GuardarDatos()

                'Permitir visualizar cálculos de corte de caja a todos los usuarios
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkCalculoCorteCaja.CheckState).ToString + "' WHERE IDConfiguracion=166"
                GuardarDatos()

                'Permitir filtrado de corte de caja
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirFiltradoCorte.CheckState).ToString + "' WHERE IDConfiguracion=167"
                GuardarDatos()

                'Cantidad de deciamles
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantDecimales.Value.ToString + "' WHERE IDConfiguracion=168"
                GuardarDatos()

                'Permitir filtrado de corte de caja
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirDuplicidadCompras.CheckState).ToString + "' WHERE IDConfiguracion=169"
                GuardarDatos()

                'Permitir filtrado de corte de caja
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirDuplicidadFacturacion.CheckState).ToString + "' WHERE IDConfiguracion=170"
                GuardarDatos()

                'Permitir modificacion de prefacturaciones 
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirModPrefactura.CheckState).ToString + "' WHERE IDConfiguracion=171"
                GuardarDatos()

                'Permitir reimpresion de originales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirReimpresion.CheckState).ToString + "' WHERE IDConfiguracion=172"
                GuardarDatos()

                'Permitir reimpresion de originales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHoraCortesCaja.CheckState).ToString + "' WHERE IDConfiguracion=173"
                GuardarDatos()

                'Tiempo de espera de confirmación de tipo de pago
                sqlQ = "UPDATE Configuracion SET Value2Int='" + TrackBar1.Value.ToString + "' WHERE IDConfiguracion=174"
                GuardarDatos()

                'Permitir facturación sin realización de prefacturas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirFactSinPrefact.CheckState).ToString + "' WHERE IDConfiguracion=175"
                GuardarDatos()

                'Permitir facturación sin realización de prefacturas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkRNCInteligente.CheckState).ToString + "' WHERE IDConfiguracion=176"
                GuardarDatos()

                'Permitir devolucion de facturas con mas de 30 dias
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirDev30.CheckState).ToString + "' WHERE IDConfiguracion=177"
                GuardarDatos()

                'Altura de las imágenes de facturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(TrackBarFactura.Value).ToString + "' WHERE IDConfiguracion=178"
                GuardarDatos()

                'Altura de las imágenes de prefacturacion
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(TrackBarPrefactura.Value).ToString + "' WHERE IDConfiguracion=179"
                GuardarDatos()

                'Altura de las imágenes de compras
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(TrackBarCompras.Value).ToString + "' WHERE IDConfiguracion=180"
                GuardarDatos()

                'Solicitar confirmación de vendedor en facturacion
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolConfirmacionVendedor.CheckState).ToString + "' WHERE IDConfiguracion=181"
                GuardarDatos()

                'Dias para Alerta de acuerdos de pagos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasAlertasAcuerdos.Text + "' WHERE IDConfiguracion=182"
                GuardarDatos()

                'Solicitar confirmación para recepción en compras
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSolConfRecCompra.CheckState).ToString + "' WHERE IDConfiguracion=183"
                GuardarDatos()

                'Rellenar totales básicos en la verificación de subtotales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkLlenarAutVerificacionSub.CheckState).ToString + "' WHERE IDConfiguracion=184"
                GuardarDatos()

                'Visualizar historial de artículos completos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkVisualArticulosCompletos.CheckState).ToString + "' WHERE IDConfiguracion=185"
                GuardarDatos()

                'Redondear al entero mas cercano
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkRedondearPrecios.CheckState).ToString + "' WHERE IDConfiguracion=186"
                GuardarDatos()

                'Permitir múltiples accesos de usuarios
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMultipleUsuarios.CheckState).ToString + "' WHERE IDConfiguracion=187"
                GuardarDatos()

                'Utilizar reportes predefinidos en facturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkUtilizarReportesPredFacturacion.CheckState).ToString + "' WHERE IDConfiguracion=188"
                GuardarDatos()

                'Reporte de facturación para facturas al contado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxReporteContado.SelectedValue.ToString + "' WHERE IDConfiguracion=189"
                GuardarDatos()

                'Reporte de facturación para facturas a credito
                sqlQ = "UPDATE Configuracion SET Value2Int='" + cbxReporteCredito.SelectedValue.ToString + "' WHERE IDConfiguracion=190"
                GuardarDatos()

                'Guardar automáticamente piezaje durante establecimiento de la cantidad
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGuardarAutPietaje.CheckState).ToString + "' WHERE IDConfiguracion=191"
                GuardarDatos()

                'Redondear cálculos de costos y precios al realizar piezaje
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkRedondearPreciosPiezaje.CheckState).ToString + "' WHERE IDConfiguracion=192"
                GuardarDatos()

                'Guardar automáticamente el cálculo de costos y precios durante el piezaje
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGuardarCalculosPiezaje.CheckState).ToString + "' WHERE IDConfiguracion=193"
                GuardarDatos()

                'Tipo de consulta en el formulario de búsqueda de artículos
                sqlQ = "UPDATE Configuracion SET Value2Int='" + If(rdbDirecto.Checked = True, 0, 1).ToString + "' WHERE IDConfiguracion=194"
                GuardarDatos()

                'Controlar precios de venta por niveles 
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarPreciosNiveles.CheckState).ToString + "' WHERE IDConfiguracion=195"
                GuardarDatos()

                'Permitir facturación con límite de crédito agotado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkPermitirFactLimiteAgotado.CheckState).ToString + "' WHERE IDConfiguracion=196"
                GuardarDatos()

                'Mostrar número de orden en el formulario de prefactura
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarNoOrden.CheckState).ToString + "' WHERE IDConfiguracion=197"
                GuardarDatos()

                'Mostrar artículos similares durante la prefacturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarSimiliaresPrefact.CheckState).ToString + "' WHERE IDConfiguracion=198"
                GuardarDatos()

                'Mostrar artículos relacionados durante la prefacturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarRelacionadasPrefac.CheckState).ToString + "' WHERE IDConfiguracion=199"
                GuardarDatos()

                'Mostrar sólo artículos con existencia al mostrar los similares durante prefacturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSoloconExistSimilares.CheckState).ToString + "' WHERE IDConfiguracion=200"
                GuardarDatos()

                'Mostrar sólo artículos con existencia al mostrar los relacionados durante prefacturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSoloconExistenciaRelacionados.CheckState).ToString + "' WHERE IDConfiguracion=201"
                GuardarDatos()

                'Control de despacho en facturación
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHabilitarControlDespacho.CheckState).ToString + "' WHERE IDConfiguracion=202"
                GuardarDatos()

                'Habilitar control en reportes de página completa
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlDespachoPagina.CheckState).ToString + "' WHERE IDConfiguracion=203"
                GuardarDatos()

                'Habilitar control en reportes de media pagina
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlDespachoMedia.CheckState).ToString + "' WHERE IDConfiguracion=204"
                GuardarDatos()

                'Habilitar control en reportes de punto de venta
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlDespachoPunto.CheckState).ToString + "' WHERE IDConfiguracion=205"
                GuardarDatos()

                'Reporte de control de despacho para página completa
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(cbxControlDespachoPaginaCompleta.SelectedValue).ToString + "' WHERE IDConfiguracion=206"
                GuardarDatos()

                'Reporte de control de despacho para media pagina
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(cbxControlDespachoMediaPagina.SelectedValue).ToString + "' WHERE IDConfiguracion=207"
                GuardarDatos()

                'Reporte de control de despacho para punto de venta
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(cbxControlDespachoPuntoVenta.SelectedValue).ToString + "' WHERE IDConfiguracion=208"
                GuardarDatos()

                'Moneda predeterminada
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(cbxMoneda.EditValue).ToString + "' WHERE IDConfiguracion=209"
                GuardarDatos()

                'Deshabilitar verificacion de correo electronico
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkDeshabilitarVerificacionCorreo.CheckState).ToString + "' WHERE IDConfiguracion=210"
                GuardarDatos()

                'Bloquear toda facturación de artículo con precio CERO RD$ 0
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBloqueoPrecioCero.CheckState).ToString + "' WHERE IDConfiguracion=211"
                GuardarDatos()

                'Activar sensibilidad sobre el costo cubierto
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkSensibilidadControlVenta.CheckState).ToString + "' WHERE IDConfiguracion=213"
                GuardarDatos()

                'Porcentaje del costo cubierto para exonerar controles de ventas
                sqlQ = "UPDATE Configuracion SET Value3Double='" + Convert.ToInt16(TrackBar2.Value).ToString + "' WHERE IDConfiguracion=214"
                GuardarDatos()

                'Abrir último listado de artículos automáticamente
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkLlenarListadoProductos.CheckState).ToString + "' WHERE IDConfiguracion=215"
                GuardarDatos()

                'Utilizar
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBloquearUsuarios.CheckState).ToString + "' WHERE IDConfiguracion=216"
                GuardarDatos()

                'No permitir facturación de artículos sin compras ni ventas
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkBloquearFactArtSNComprasVentas.CheckState).ToString + "' WHERE IDConfiguracion=217"
                GuardarDatos()

                'No generar NCF para ventas de consumidor final
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkNoGenerarNCFparaDevoluciones.CheckState).ToString + "' WHERE IDConfiguracion=218"
                GuardarDatos()

                'Controlar dias de notas de contado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkControlarNotasContado.CheckState).ToString + "' WHERE IDConfiguracion=219"
                GuardarDatos()

                'Días máximo de las notas de contado
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(txtDiasNotas.Value).ToString + "' WHERE IDConfiguracion=220"
                GuardarDatos()

                'Distancia del redondeo
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(ICBERedondeoHacia.EditValue).ToString + "' WHERE IDConfiguracion=221"
                GuardarDatos()

                'Convertir fracciones en caracteres especiales
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(TBSensibilidadDescripcion.Value).ToString + "' WHERE IDConfiguracion=222"
                GuardarDatos()

                'Guardar superclaves
                Dim IDSuperclave, SuperClave As New Label
                For Each row As DataGridViewRow In DgvSuperClaves.Rows
                    IDSuperclave.Text = row.Cells(0).Value
                    SuperClave.Text = row.Cells(2).Value

                    sqlQ = "UPDATE Modulos SET Clave='" + SuperClave.Text + "' WHERE IDModulo='" + IDSuperclave.Text + "'"
                    GuardarDatos()
                Next

                'Acciones de superclaves
                For Each Row As DataGridViewRow In DgvAcciones.Rows
                    sqlQ = "UPDATE AccionesModulos SET Activo='" + Convert.ToInt16(Row.Cells(3).Value).ToString + "' WHERE idAccionesSuperClave='" + Row.Cells(0).Value.ToString() + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Next


                'Acciones de superclaves
                For Each Row As DataGridViewRow In DgvFormatos.Rows
                    cmd = New MySqlCommand("UPDATE papersize SET Activo='" + Convert.ToInt16(Row.Cells(2).Value).ToString + "',PrinterKey='" + If(Row.Cells(3).Value Is Nothing, "", Row.Cells(3).Value).ToString + "' WHERE idPaperSize='" + Row.Cells(0).Value.ToString() + "'", Con)
                    cmd.ExecuteNonQuery()
                Next

                Con.Close()
                ConLibregco.Close()

                ConvertCurrent()
                Cursor = Cursors.Default

                'Cargando configuracion del sistema
                DTConfiguracion.Dispose()

                Dim dstemp As New DataSet
                cmd = New MySqlCommand("Select * from Configuracion", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "Configuracion")

                DTConfiguracion = dstemp.Tables("Configuracion")

                DTModulos.Dispose()
                cmd = New MySqlCommand("Select * from Modulos", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "Modulos")

                DTModulos = dstemp.Tables("Modulos")

                dstemp.Dispose()


                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub txtTasaDolar_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtItbisGeneral_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisGeneral.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtItbisGeneral_Enter(sender As Object, e As EventArgs) Handles txtItbisGeneral.Enter
        Try
            If txtItbisGeneral.Text = "" Then
            Else
                txtItbisGeneral.Text = CDbl(Replace(txtItbisGeneral.Text, "%", "")) / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtItbisGeneral_Leave(sender As Object, e As EventArgs) Handles txtItbisGeneral.Leave
        If txtItbisGeneral.Text = "" Then
            txtItbisGeneral.Text = CDbl(0).ToString("P")
        Else
            txtItbisGeneral.Text = CDbl(txtItbisGeneral.Text).ToString("P")
        End If
    End Sub

    Private Sub btnBuscarNCF_Click(sender As Object, e As EventArgs)
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub

    Private Sub cbxNCFPredeterminado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNCFPredeterminado.SelectedIndexChanged
        If Con.State = ConnectionState.Closed Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + cbxNCFPredeterminado.SelectedItem + "'", Con)
            cbxNCFPredeterminado.Tag = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        Else
            cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + cbxNCFPredeterminado.SelectedItem + "'", Con)
            cbxNCFPredeterminado.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If

    End Sub

    Private Sub cbxCobradorPred_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCobradorPred.SelectedIndexChanged
        If Con.State = 0 Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado FROM empleados Where Nombre= '" + cbxCobradorPred.SelectedItem + "'", Con)
            cbxCobradorPred.Tag = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        Else
            cmd = New MySqlCommand("SELECT IDEmpleado FROM empleados Where Nombre= '" + cbxCobradorPred.SelectedItem + "'", Con)
            cbxCobradorPred.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub ColorCargos_Click(sender As Object, e As EventArgs) Handles ColorCargos.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorCargos.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorNotaDebito_Click(sender As Object, e As EventArgs) Handles ColorNotaDebito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorNotaDebito.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorNotaCredito_Click(sender As Object, e As EventArgs) Handles ColorNotaCredito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorNotaCredito.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorDevoluciones_Click(sender As Object, e As EventArgs) Handles ColorDevoluciones.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorDevoluciones.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorChequesDev_Click(sender As Object, e As EventArgs) Handles ColorChequesDev.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorChequesDev.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorAbonos_Click(sender As Object, e As EventArgs) Handles ColorAbonos.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorAbonos.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorFactContado_Click(sender As Object, e As EventArgs) Handles ColorFactContado.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True

        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorFactContado.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorFactCredito_Click(sender As Object, e As EventArgs) Handles ColorFactCredito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorFactCredito.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub txtDiasCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasCondicion.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub chkNoIdentObligatoria_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoIdentObligatoria.CheckedChanged
        chkIdentificacionFisiscaObligatoria.Enabled = chkNoIdentObligatoria.CheckState
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If ConLibregco.State = 0 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub cbxEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstadoCivil.SelectedIndexChanged
        If ConLibregco.State = 0 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCivil FROM EstadoCivil WHERE EstadoCivil= '" + cbxEstadoCivil.SelectedItem + "'", ConLibregco)
            cbxEstadoCivil.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cmd = New MySqlCommand("SELECT IDCivil FROM EstadoCivil WHERE EstadoCivil= '" + cbxEstadoCivil.SelectedItem + "'", ConLibregco)
            cbxEstadoCivil.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub CbxOcupacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOcupacion.SelectedIndexChanged
        If ConLibregco.State = 0 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDOcupacion FROM Ocupacion WHERE Ocupacion= '" + CbxOcupacion.SelectedItem + "'", ConLibregco)
            CbxOcupacion.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cmd = New MySqlCommand("SELECT IDOcupacion FROM Ocupacion WHERE Ocupacion= '" + CbxOcupacion.SelectedItem + "'", ConLibregco)
            CbxOcupacion.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub cbxNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNacionalidad.SelectedIndexChanged
        If ConLibregco.State = 0 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDNacionalidad FROM Nacionalidad WHERE Nacionalidad= '" + cbxNacionalidad.SelectedItem + "'", ConLibregco)
            cbxNacionalidad.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cmd = New MySqlCommand("SELECT IDNacionalidad FROM Nacionalidad WHERE Nacionalidad= '" + cbxNacionalidad.SelectedItem + "'", ConLibregco)
            cbxNacionalidad.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub txtDiasUtilesPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasUtilesPassword.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtLimiteConsultas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteConsultas.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub


    Private Sub txtMaxSizeofFiles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxSizeofFiles.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub rdbMetodo1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMetodo1.CheckedChanged
        If rdbMetodo1.Checked = True Then
            lblExplicacionNCF.Text = "En este método el sistema utiliza una única secuencia para cada tipo de comprobante fiscal que no se ve afectada por la división de negocios, el punto de emisión y el área de impresión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo2.Checked = True Then
            lblExplicacionNCF.Text = "Este método utiliza los valores asignados a cada sucursal (División de Negocios), a cada almacén (Punto de Emisión) y a cada equipo autorizado (Área de Impresión) para crear una estructura combinada y personalizada para cada equipo autorizado en el sistema. Este método requiere de más controles internos y externos."
            lblDN.ForeColor = Color.Black
            lblPE.ForeColor = Color.Black
            lblAI.ForeColor = Color.Black
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo3.Checked = True Then
            lblExplicacionNCF.Text = "Este nuevo método válido desde el 01 de Mayo del 2018, utiliza una única secuencia de ochos digitos para cada tipo de comprobante fiscal que es generalizada para todos puntos de emisión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "00000001"
            Label39.Text = "B"
        End If
    End Sub

    Private Sub txtTasaTss_Leave(sender As Object, e As EventArgs) Handles txtTasaTSS.Leave
        Try
            If txtTasaTSS.Text = "" Then
                txtTasaTSS.Text = CDbl(0).ToString("P2")
            Else
                txtTasaTSS.Text = CDbl(txtTasaTSS.Text).ToString("P2")
            End If

        Catch ex As Exception
            txtTasaTSS.Text = CDbl(0).ToString("P2")
        End Try
    End Sub

    Private Sub txtTasaTSS_Enter(sender As Object, e As EventArgs) Handles txtTasaTSS.Enter
        Try
            If txtTasaTSS.Text = "" Then
            Else
                txtTasaTSS.Text = CDbl(Replace(txtTasaTSS.Text, "%", "")) / 100
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTasaTSS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaTSS.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub


    Private Sub txtPalabraClaveCosto_TextChanged(sender As Object, e As EventArgs) Handles txtPalabraClaveCosto.TextChanged
        Label40.Text = txtPalabraClaveCosto.TextLength
    End Sub

    Private Sub cbxPlazoContrato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlazoContrato.SelectedIndexChanged
        If ConLibregco.State = 0 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPlazoContrato FROM PlazoContrato WHERE Plazo= '" + cbxPlazoContrato.SelectedItem + "'", ConLibregco)
            cbxPlazoContrato.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        Else
            cmd = New MySqlCommand("SELECT IDPlazoContrato FROM PlazoContrato WHERE Plazo= '" + cbxPlazoContrato.SelectedItem + "'", ConLibregco)
            cbxPlazoContrato.Tag = Convert.ToString(cmd.ExecuteScalar())
        End If
    End Sub

    Private Sub txtLimiteMaximoSolNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteMaximoSolNombre.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub chkSolicitarNombreLimite_CheckedChanged(sender As Object, e As EventArgs) Handles chkSolicitarNombreLimite.CheckedChanged
        txtLimiteMaximoSolNombre.Enabled = chkSolicitarNombreLimite.CheckState
    End Sub

    Private Sub txtLimiteMaximoSolNombre_Leave(sender As Object, e As EventArgs) Handles txtLimiteMaximoSolNombre.Leave
        If txtLimiteMaximoSolNombre.Text = "" Then
            txtLimiteMaximoSolNombre.Text = CDbl(0).ToString("P")
        Else
            txtLimiteMaximoSolNombre.Text = CDbl(txtLimiteMaximoSolNombre.Text).ToString("C")
        End If
    End Sub

    Private Sub txtLimiteMaximoSolNombre_Enter(sender As Object, e As EventArgs) Handles txtLimiteMaximoSolNombre.Enter
        If txtLimiteMaximoSolNombre.Text = "" Then
        Else
            txtLimiteMaximoSolNombre.Text = CDbl(txtLimiteMaximoSolNombre.Text)
        End If
    End Sub

    Private Sub txtDiasRestAlertPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasRestAlertPass.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantMinimaparaAlertaNCF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantMinimaparaAlertaNCF.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDiasVencimientoCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasVencimientoCheque.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDiasSolicitudClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasSolicitudClientes.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub


    Private Sub DgvSuperClaves_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSuperClaves.CellEndEdit
        DgvSuperClaves.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvSuperClaves_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSuperClaves.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 2 Then
                DgvSuperClaves.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvSuperClaves_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvSuperClaves.CurrentCellDirtyStateChanged
        If DgvSuperClaves.IsCurrentCellDirty Then
            DgvSuperClaves.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtLimiteDescuentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteDescuentos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtLimiteDescuentos_Enter(sender As Object, e As EventArgs) Handles txtLimiteDescuentos.Enter
        If txtLimiteDescuentos.Text = "" Then
        Else
            txtLimiteDescuentos.Text = CDbl(txtLimiteDescuentos.Text)
        End If
    End Sub

    Private Sub txtLimiteDescuentos_Leave(sender As Object, e As EventArgs) Handles txtLimiteDescuentos.Leave
        If txtLimiteDescuentos.Text = "" Then
            txtLimiteDescuentos.Text = CDbl(0).ToString("P")
        Else
            txtLimiteDescuentos.Text = CDbl(txtLimiteDescuentos.Text).ToString("C")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_bitacora_usuarios.ShowDialog(Me)
    End Sub

    Private Sub chkControlarMontoPagosxSalario_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlarMontoPagosxSalario.CheckedChanged
        txtRelacionSalario.Enabled = chkControlarMontoPagosxSalario.CheckState
    End Sub

    Private Sub txtRelacionSalario_Enter(sender As Object, e As EventArgs) Handles txtRelacionSalario.Enter
        Try
            If txtRelacionSalario.Text = "" Then
            Else
                txtRelacionSalario.Text = CDbl(Replace(txtRelacionSalario.Text, "%", "")) / 100
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtRelacionSalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRelacionSalario.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtRelacionSalario_Leave(sender As Object, e As EventArgs) Handles txtRelacionSalario.Leave
        Try
            If txtRelacionSalario.Text = "" Then
                txtRelacionSalario.Text = CDbl(0).ToString("P2")
            Else
                txtRelacionSalario.Text = CDbl(txtRelacionSalario.Text).ToString("P2")
            End If

        Catch ex As Exception
            txtRelacionSalario.Text = CDbl(0).ToString("P2")
        End Try
    End Sub

    Private Sub txtTiempoInactividad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTiempoInactividad.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtTiempoInactividad_Leave(sender As Object, e As EventArgs) Handles txtTiempoInactividad.Leave
        If txtTiempoInactividad.Text = "" Then
            txtTiempoInactividad.Text = 15
        Else
            'If CDbl(txtTiempoInactividad.Text) < 15 Then
            '    txtTiempoInactividad.Text = 15
            'End If
        End If
    End Sub

    Private Sub txtCargosMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCargosMonto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub


    Private Sub chkCerrarCreditoconCargo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrarCreditoconCargo.CheckedChanged
        txtCargosMonto.Enabled = chkCerrarCreditoconCargo.CheckState
    End Sub

    Private Sub txtCargosMonto_Leave(sender As Object, e As EventArgs) Handles txtCargosMonto.Leave
        If txtCargosMonto.Text = "" Then
            txtCargosMonto.Text = CDbl(0).ToString("P")
        Else
            txtCargosMonto.Text = CDbl(txtCargosMonto.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCargosMonto_Enter(sender As Object, e As EventArgs) Handles txtCargosMonto.Enter
        If txtCargosMonto.Text = "" Then
        Else
            txtCargosMonto.Text = CDbl(txtCargosMonto.Text)
        End If
    End Sub

    Private Sub rdbMetodo2_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMetodo2.CheckedChanged
        If rdbMetodo1.Checked = True Then
            lblExplicacionNCF.Text = "En este método el sistema utiliza una única secuencia para cada tipo de comprobante fiscal que no se ve afectada por la división de negocios, el punto de emisión y el área de impresión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo2.Checked = True Then
            lblExplicacionNCF.Text = "Este método utiliza los valores asignados a cada sucursal (División de Negocios), a cada almacén (Punto de Emisión) y a cada equipo autorizado (Área de Impresión) para crear una estructura combinada y personalizada para cada equipo autorizado en el sistema. Este método requiere de más controles internos y externos."
            lblDN.ForeColor = Color.Black
            lblPE.ForeColor = Color.Black
            lblAI.ForeColor = Color.Black
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo3.Checked = True Then
            lblExplicacionNCF.Text = "Este nuevo método válido desde el 01 de Mayo del 2018, utiliza una única secuencia de ochos digitos para cada tipo de comprobante fiscal que es generalizada para todos puntos de emisión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "00000001"
            Label39.Text = "B"
        End If
    End Sub

    Private Sub rdbMetodo3_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMetodo3.CheckedChanged
        If rdbMetodo1.Checked = True Then
            lblExplicacionNCF.Text = "En este método el sistema utiliza una única secuencia para cada tipo de comprobante fiscal que no se ve afectada por la división de negocios, el punto de emisión y el área de impresión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo2.Checked = True Then
            lblExplicacionNCF.Text = "Este método utiliza los valores asignados a cada sucursal (División de Negocios), a cada almacén (Punto de Emisión) y a cada equipo autorizado (Área de Impresión) para crear una estructura combinada y personalizada para cada equipo autorizado en el sistema. Este método requiere de más controles internos y externos."
            lblDN.ForeColor = Color.Black
            lblPE.ForeColor = Color.Black
            lblAI.ForeColor = Color.Black
            lblSecuencia.Text = "000000001"
            Label39.Text = "A"
        ElseIf rdbMetodo3.Checked = True Then
            lblExplicacionNCF.Text = "Este nuevo método válido desde el 01 de Mayo del 2018, utiliza una única secuencia de ochos digitos para cada tipo de comprobante fiscal que es generalizada para todos puntos de emisión."
            lblDN.ForeColor = Color.Red
            lblPE.ForeColor = Color.Red
            lblAI.ForeColor = Color.Red
            lblSecuencia.Text = "00000001"
            Label39.Text = "B"
        End If
    End Sub

    Private Sub rdbUnicaMora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbUnicaMora.CheckedChanged
        If rdbUnicaMora.Checked = True Then
            chkGenerarNCFCargo.Enabled = False
            chkGenerarNCFCargo.Checked = False
            Label37.Text = "Los cargos generados estarán en un registro único. No se podrán generar NCF por los mismos en los períodos fiscales."
        Else
            chkGenerarNCFCargo.Enabled = True
            Label37.Text = "Los cargos generados se agruparan mensualmente y se podrá generar NCF en los mismos durante los períodos fiscales."
        End If
    End Sub

    Private Sub txtCantRevisionNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantRevisionNombre.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            'Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub chkCerrarCreditoporAntiguedad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrarCreditoporAntiguedad.CheckedChanged
        txtDiasparaCerrarCredito.Enabled = chkCerrarCreditoporAntiguedad.CheckState
    End Sub

    Private Sub txtDiasparaCerrarCredito_Leave(sender As Object, e As EventArgs) Handles txtDiasparaCerrarCredito.Leave
        If txtDiasparaCerrarCredito.Text = "" Then
            txtDiasparaCerrarCredito.Text = 0
        End If
    End Sub

    Private Sub txtDiasparaCerrarCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasparaCerrarCredito.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDiasGuardarBitacora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasGuardarBitacora.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDiasUtilesPassword_Leave(sender As Object, e As EventArgs) Handles txtDiasUtilesPassword.Leave
        If txtDiasUtilesPassword.Text = "" Then
            txtDiasUtilesPassword.Text = 0
        End If
    End Sub

    Private Sub txtDiasGuardarBitacora_Leave(sender As Object, e As EventArgs) Handles txtDiasGuardarBitacora.Leave
        If txtDiasGuardarBitacora.Text = "" Then
            txtDiasGuardarBitacora.Text = 0
        End If
    End Sub

    Private Sub chkDarExpiracionPrefacturaciion_CheckedChanged(sender As Object, e As EventArgs) Handles chkDarExpiracionPrefacturaciion.CheckedChanged
        cbxVidaUtilPrefacturacion.Enabled = chkDarExpiracionPrefacturaciion.CheckState
    End Sub

    Private Sub txtCantMaximaPagaresVencidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantMaximaPagaresVencidos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantMaximaFacturasCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantMaximaFacturasCredito.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtMontoMinimoPagare_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoMinimoPagare.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantMaximaPagaresVencidos_Leave(sender As Object, e As EventArgs) Handles txtCantMaximaPagaresVencidos.Leave
        If txtCantMaximaPagaresVencidos.Text = "" Then
            txtCantMaximaPagaresVencidos.Text = 1
        End If
    End Sub

    Private Sub txtCantMaximaFacturasCredito_Leave(sender As Object, e As EventArgs) Handles txtCantMaximaFacturasCredito.Leave
        If txtCantMaximaFacturasCredito.Text = "" Then
            txtCantMaximaFacturasCredito.Text = 1
        End If
    End Sub

    Private Sub txtMontoMinimoPagare_Leave(sender As Object, e As EventArgs) Handles txtMontoMinimoPagare.Leave
        If txtMontoMinimoPagare.Text = "" Then
            txtMontoMinimoPagare.Text = CDbl(1000).ToString("C")
        Else
            txtMontoMinimoPagare.Text = CDbl(txtMontoMinimoPagare.Text).ToString("C")
        End If
    End Sub

    Private Sub chkControlCantidadPagaresVencidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlCantidadPagaresVencidos.CheckedChanged
        GroupBox17.Enabled = chkControlCantidadPagaresVencidos.CheckState
    End Sub

    Private Sub chkControlCantidadCreditos_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlCantidadCreditos.CheckedChanged
        GroupBox18.Enabled = chkControlCantidadCreditos.CheckState
    End Sub

    Private Sub chkControlMontoMinimoPagare_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlMontoMinimoPagare.CheckedChanged
        GroupBox19.Enabled = chkControlMontoMinimoPagare.CheckState
    End Sub

    Private Sub chkControlarTipoPago_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlarTipoPago.CheckedChanged
        TrackBar1.Enabled = chkControlarTipoPago.CheckState
    End Sub

    Private Sub chkImpresionCopiaMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpresionCopiaMultiple.CheckedChanged
        GroupBox24.Enabled = chkImpresionCopiaMultiple.Checked
    End Sub

    Private Sub CreateDatatable()
        dt = New DataTable
        dt.Columns.Add("ID")    '0
        dt.Columns.Add("Menu")     '1
        dt.Columns.Add("Descripcion") '2
        dt.Columns.Add("Ubicacion")   '3
        dt.Columns.Add("Resumir")    '4
        dt.Columns.Add("Orden")       '5
        dt.Columns.Add("Activo")       '6
        dt.Columns.Add("Duplicidad")       '7
        dt.Columns.Add("PaperSize")       '8
        dt.Columns.Add("Verificado")       '9
        'dt.Columns.Add("Visual")       '10
        GridControl1.DataSource = dt

        'Convertir columnas
        Dim chkColumnResumir As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = ""}
        GridView1.Columns(4).ColumnEdit = chkColumnResumir

        Dim SpinColumnOrder As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "0", .MaxValue = "100"}
        SpinColumnOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        SpinColumnOrder.Properties.Mask.MaskType = XtraEditors.Mask.MaskType.Numeric
        'SpinColumnOrder.Properties.Mask.EditMask = "0"
        GridView1.Columns(5).ColumnEdit = SpinColumnOrder

        Dim chkColumnActivo As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = ""}
        GridView1.Columns(6).ColumnEdit = chkColumnActivo

        Dim chkColumnDuplicidad As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = ""}
        GridView1.Columns(7).ColumnEdit = chkColumnDuplicidad

        GridView1.Columns(8).ColumnEdit = LuePaperSize

        Dim chkColummnVerificado As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = "", .Caption = "Verified", .ReadOnly = True}
        GridView1.Columns(9).ColumnEdit = chkColummnVerificado
    End Sub

    Private Sub FillPaperSizes()
        Dim ds As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDPaperSize, Concat(SizeName,' (',Width,' x ',Height,')') as Size FROM libregco.papersize", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "papersize")
        ConLibregco.Close()

        LuePaperSize.DataSource = ds.Tables("papersize")
        LuePaperSize.ValueMember = "IDPaperSize"
        LuePaperSize.DisplayMember = "Size"
        LuePaperSize.PopulateColumns()
        LuePaperSize.Columns(0).Caption = "ID"
        LuePaperSize.Columns(1).Caption = "Tamaño"

    End Sub

    Private Sub LlenarGridControl()
        Dim ds As New DataSet
        Dim isVerified As Integer

        Con.Open()
        cmd = New MySqlCommand("SELECT IDReportes,MenuString as Menu,Descripcion,Path,HabilitadoResumen as Resumen,NoOrden as Orden,Activo as Estado,ModoDuplicado,IDPaperName FROM reportes ORDER BY MenuString ASC,NoOrden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "reportes")
        Con.Close()

        Dim TablaPaper As DataTable = ds.Tables("reportes")

        For Each itm As DataRow In TablaPaper.Rows
            If System.IO.File.Exists("\\" & PathServidor.Text & itm.Item("Path").ToString) Then
                isVerified = 1
            Else
                isVerified = 0
            End If

            dt.Rows.Add(itm.Item("IDReportes").ToString, itm.Item("Menu").ToString, itm.Item("Descripcion").ToString, itm.Item("Path").ToString, itm.Item("Resumen").ToString, itm.Item("Orden").ToString, itm.Item("Estado").ToString, itm.Item("ModoDuplicado").ToString, itm.Item("IDPaperName").ToString, isVerified)
        Next


        GridControl1.DataSource = dt
        GridView1.Columns(0).OptionsColumn.ReadOnly = True
        GridView1.Columns(0).OptionsColumn.AllowEdit = False
        GridView1.Columns(1).GroupIndex = 0
        GridView1.BestFitColumns()
        GridView1.ExpandAllGroups()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            CreateDatatable()
            FillPaperSizes()
            LlenarGridControl()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Con.Open()
        sqlQ = "UPDATE Reportes SET Descripcion='" + (GridView1.GetDataRow(e.RowHandle)(2)).ToString + "',Path='" + Replace((GridView1.GetDataRow(e.RowHandle)(3)), "\", "\\").ToString + "',HabilitadoResumen='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(4)).ToString + "',NoOrden='" + (GridView1.GetDataRow(e.RowHandle)(5)).ToString + "',Activo='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(6)).ToString + "',ModoDuplicado='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(7)).ToString + "',IDPaperName='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(8)).ToString + "' WHERE IDReportes='" + (GridView1.GetDataRow(e.RowHandle)(0)).ToString + "'"
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()
        GridView1.BestFitColumns()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label80.Text = "Tiempo en espera de respuesta en segundos: " & TrackBar1.Value & " seg(s)"
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBarPrefactura.Scroll
        PicPrefactura.Height = TrackBarPrefactura.Value
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBarFactura.Scroll
        PicFacturacion.Height = TrackBarFactura.Value
    End Sub

    Private Sub TrackBarCompras_Scroll(sender As Object, e As EventArgs) Handles TrackBarCompras.Scroll
        PicCompras.Height = TrackBarCompras.Value
    End Sub

    Private Sub chkUtilizarReportesPredFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkUtilizarReportesPredFacturacion.CheckedChanged
        cbxReporteContado.Enabled = chkUtilizarReportesPredFacturacion.CheckState
        cbxReporteCredito.Enabled = chkUtilizarReportesPredFacturacion.CheckState
    End Sub

    Private Sub chkMostrarRelacionadasPrefac_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarRelacionadasPrefac.CheckedChanged
        chkSoloconExistenciaRelacionados.Enabled = chkMostrarRelacionadasPrefac.CheckState
    End Sub

    Private Sub chkMostrarSimiliaresPrefact_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarSimiliaresPrefact.CheckedChanged
        chkSoloconExistSimilares.Enabled = chkMostrarSimiliaresPrefact.CheckState
    End Sub

    Private Sub chkHabilitarControlDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarControlDespacho.CheckedChanged
        GroupBox33.Enabled = chkHabilitarControlDespacho.CheckState
    End Sub

    Private Sub chkControlDespachoPagina_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlDespachoPagina.CheckedChanged
        cbxControlDespachoPaginaCompleta.Enabled = chkControlDespachoPagina.CheckState
    End Sub

    Private Sub chkControlDespachoMedia_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlDespachoMedia.CheckedChanged
        cbxControlDespachoMediaPagina.Enabled = chkControlDespachoMedia.CheckState
    End Sub

    Private Sub chkControlDespachoPunto_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlDespachoPunto.CheckedChanged
        cbxControlDespachoPuntoVenta.Enabled = chkControlDespachoPunto.CheckState

    End Sub

    Private Sub TrackBar2_Scroll_1(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        chkSensibilidadControlVenta.Text = "Activar sensibilidad de venta sobre el costo de venta al " & TrackBar2.Value & "%"
    End Sub

    Private Sub chkSensibilidadControlVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chkSensibilidadControlVenta.CheckedChanged
        TrackBar2.Enabled = chkSensibilidadControlVenta.CheckState
    End Sub


    Private Sub chkControlarNotasContado_CheckedChanged(sender As Object, e As EventArgs) Handles chkControlarNotasContado.CheckedChanged
        txtDiasNotas.Enabled = chkControlarNotasContado.Checked
    End Sub

    Private Sub chkRedondearPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chkRedondearPrecios.CheckedChanged
        GroupBox35.Enabled = chkRedondearPrecios.Checked
        LabelControl2.Enabled = chkRedondearPrecios.Checked
        ICBERedondeoHacia.Enabled = chkRedondearPrecios.Checked
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub chkHabilitarContraEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarContraEntrega.CheckedChanged
        btnBuscarCliente.Enabled = chkHabilitarContraEntrega.Checked
    End Sub

    Private Sub chkFraccionesTexto_CheckedChanged(sender As Object, e As EventArgs) Handles chkFraccionesTexto.CheckedChanged
        If chkFraccionesTexto.Checked Then
            btnFracciones.Text = "Convertir a especiales (⅜)"
        Else
            btnFracciones.Text = "Convertir a fracciones (3/8)"
        End If
    End Sub

    Private Sub btnFracciones_Click(sender As Object, e As EventArgs) Handles btnFracciones.Click
        'Try
        Dim ds As New DataSet
        ConLibregco.Open()

        If chkFraccionesTexto.Checked = False Then
            'Cambiando ¼ a 1/4
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%¼%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("¼", "1/4").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ½ a 1/2
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%½%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("½", "1/2").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ¾ a 3/4
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%¾%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("¾", "3/4").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ⅜ a 3/8
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%⅜%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("⅜", "3/8").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ⅝ a 5/8
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%⅝%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("⅝", "5/8").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ⅞ a 7/8
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%⅞%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("⅞", "7/8").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando ⅛ a 1/8
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%⅛%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + dt.Item("Descripcion").ToString.Replace("⅛", "1/8").ToString() + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

        Else

            'Cambiando de 1/4 a ¼
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%1/4%' or descripcion like '%1 / 4%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Libregco.Articulos Set Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("1/4"), dt.Item("Descripcion").ToString.Replace("1/4", "¼").ToString(), dt.Item("Descripcion").ToString.Replace("1 / 4", "¼").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 1/2 a ½
            ds.Clear()
            cmd = New MySqlCommand("Select IDArticulo, Descripcion FROM libregco.articulos where descripcion Like '%1/2%' or descripcion like '%1 / 2%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("1/2"), dt.Item("Descripcion").ToString.Replace("1/2", "½").ToString(), dt.Item("Descripcion").ToString.Replace("1 / 2", "½").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 3/4 a ¾
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%3/4%' or descripcion like '%3 / 4%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("3/4"), dt.Item("Descripcion").ToString.Replace("3/4", "¾").ToString(), dt.Item("Descripcion").ToString.Replace("3 / 4", "¾").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 3/8 a ⅜
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%3/8%' or descripcion like '%3 / 8%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("3/8"), dt.Item("Descripcion").ToString.Replace("3/8", "⅜").ToString(), dt.Item("Descripcion").ToString.Replace("3 / 8", "⅜").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 5/8 a ⅝
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%5/8%' or descripcion like '%5 / 8%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("5/8"), dt.Item("Descripcion").ToString.Replace("5/8", "⅝").ToString(), dt.Item("Descripcion").ToString.Replace("5 / 8", "⅝").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 7/8 a ⅞
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%7/8%' or descripcion like '%7 / 8%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("7/8"), dt.Item("Descripcion").ToString.Replace("7/8", "⅞").ToString(), dt.Item("Descripcion").ToString.Replace("7 / 8", "⅞").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            'Cambiando de 1/8 a ⅛
            ds.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.articulos where descripcion like '%1/8%' or descripcion like '%1 / 8%'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "articulos")

            For Each dt As DataRow In ds.Tables("articulos").Rows
                Dim SQLQ As String = "UPDATE Articulos SET Descripcion='" + If(dt.Item("Descripcion").ToString.Contains("1/8"), dt.Item("Descripcion").ToString.Replace("1/8", "⅛").ToString(), dt.Item("Descripcion").ToString.Replace("1 / 8", "⅛").ToString()).ToString + "' WHERE IDArticulo='" + dt.Item("IDArticulo").ToString + "'"
                cmd = New MySqlCommand(SQLQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

        End If


        ConLibregco.Close()

        MessageBox.Show("Finalizado.")


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub TBSensibilidadDescripcion_Scroll(sender As Object, e As EventArgs) Handles TBSensibilidadDescripcion.Scroll
        If TBSensibilidadDescripcion.Value = 1 Then
            lblSensibilidadDescripcion.Text = "NINGUNO"
        ElseIf TBSensibilidadDescripcion.Value = 2 Then
            lblSensibilidadDescripcion.Text = "MEDIO"
        ElseIf TBSensibilidadDescripcion.Value = 3 Then
            lblSensibilidadDescripcion.Text = "MODERADO"
        End If
    End Sub

    Private Sub chkCopiaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkCopiaCliente.CheckedChanged
        txtDescripDuplicado.Enabled = chkCopiaCliente.Checked
    End Sub

    Private Sub chkCopiaDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles chkCopiaDespacho.CheckedChanged
        txtDescripDespacho.Enabled = chkCopiaDespacho.Checked
    End Sub

    Private Sub chkCopiaContabilidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCopiaContabilidad.CheckedChanged
        txtDescripContabilidad.Enabled = chkCopiaContabilidad.Checked
    End Sub
End Class