Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_facturacion
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter

    Friend LastIDFact, DefaultNcf, DefaultCondicion, MaxFacturasCreditoPermitidas, MaxPagosVencidos, MontoMinimoPagare, IDTipopago, ImponerVentaNCF, Fraccionamiento, NombreMoneda, NivelSensibilidadalCosto As String
    Friend IDArticulo, lblItbisArt, lblIDUsuario, lblIDAlmacenArticulo, lblDiasCondicion, lblIDTransaccion, lblCheckDuplicates, lblIDTipoDocumento, lblExistencia, lblDescuento, lblIDFactArt, lblIDTipoProducto, LiberarControles As New Label
    Friend IDGrupoCXC, EstadoImpresion As String
    Friend ProductImage As Image

    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos, PagaresCreados, Precios As New ArrayList
    Friend IDPrefactura As New ArrayList
    Friend AccionesModulosAutorizadas As New ArrayList

    Friend TablaQuestions As DataTable = GetTablaPreguntas()

    Private Sub frm_facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        GetTablaPreguntas()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        ColumnasDgvArticulos()
        ColumnasDgvPagares()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Function GetTablaPreguntas()
        Dim TablaQuestions As New DataTable
        TablaQuestions.Columns.Add("idArticulos_preguntas", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Titulo", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Abierta", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Opciones", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Respuesta", System.Type.GetType("System.String"))
        Return TablaQuestions
    End Function

    Private Sub ControlRapido()
        Try
            If Me.WindowState = FormWindowState.Normal Then
                If CInt(DTConfiguracion.Rows(102 - 1).Item("Value2Int")) = 1 Then
                    If SearchingFast = False Then
                        If Me.WindowState = FormWindowState.Normal Then
                            If frm_accesos_rapidos_clientes.Visible = True Then
                                If frm_accesos_rapidos_clientes.Owner.Name <> Me.Name Then
                                    frm_accesos_rapidos_clientes.Close()
                                    frm_accesos_rapidos_clientes.Show(Me)
                                End If
                            Else
                                frm_accesos_rapidos_clientes.Show(Me)
                            End If

                            frm_accesos_rapidos_clientes.Location = New Point(Me.Location.X + Me.Size.Width - 12, Me.Location.Y)
                        Else
                            If frm_accesos_rapidos_clientes.Visible = True Then
                                frm_accesos_rapidos_clientes.Close()
                            End If
                        End If
                    End If
                End If
            Else
                If frm_accesos_rapidos_clientes.Visible = True Then
                    frm_accesos_rapidos_clientes.Close()
                End If
            End If


        Catch ex As Exception
            If frm_accesos_rapidos_clientes.Visible = True Then
                frm_accesos_rapidos_clientes.Close()
            End If
        End Try
    End Sub
    Private Sub ColumnasDgvArticulos()
        Dim ImageColumn As New DataGridViewImageColumn

        dgvArticulosFactura.Columns.Clear()
        With dgvArticulosFactura
            .Columns.Add("IDArtFac", "ID ArtFac")   '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("IDPrecios", "ID Precio") '2
            .Columns.Add("IDMedida", "ID Medida")   '3
            .Columns.Add("Cantidad", "Cant.")       '4
            .Columns.Add("Medida", "Medida")        '5
            .Columns.Add("IDArticulo", "Código")    '6
            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("Precio", "Precio") '8
            .Columns.Add("Descuento", "Descuento")  '9
            .Columns.Add("Itbis", "Itbis")  '10
            .Columns.Add("Importe", "Importe")      '11
            .Columns.Add("IDAlmacen", "Alm") '12
            .Columns.Add("NivelPrecio", "Precio") '13
            .Columns.Add("Hijo", "Hijo") '14
            .Columns.Add("Fraccionamiento", "Fraccionamiento") '15
            .Columns.Add(ImageColumn)   '16
        End With

        With ImageColumn
            .Width = 100
            .ImageLayout = DataGridViewImageCellLayout.Normal
            .HeaderText = "Imagen"
            .Visible = True
        End With

        PropiedadesDgvArticulos()
    End Sub

    Sub RefrescarBalances()
        Try
            If txtIDCliente.Text <> "" Then
                Dim ds As New DataSet

                ConMixta.Open()

                cbxMoneda.Properties.Items.Clear()
                ILbcBalances.Items.Clear()

                cmd = New MySqlCommand("SELECT idClientes_Balances,IDTipoMoneda,Texto,Signo,Balance,MonedaImagen,CargosGeneral FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' Order by Balance DESC", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "tipomoneda")

                For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
                    Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                    If CDbl(Fila.Item("CargosGeneral")) = 0 Then
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & "."
                    Else
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & " (+) más cargos acumulados por " & CDbl(Fila.Item("CargosGeneral")).ToString("C") & "."
                    End If

                    nvmoneda.Value = Fila.Item("IDTipoMoneda")

                    If Fila.Item("IDTipoMoneda") = 1 Then
                        nvmoneda.ImageIndex = 0
                    ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                        nvmoneda.ImageIndex = 1
                    ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                        nvmoneda.ImageIndex = 2
                    End If

                    cbxMoneda.Properties.Items.Add(nvmoneda)

                    Dim itm As New DevExpress.XtraEditors.Controls.ImageListBoxItem
                    Dim wFile As System.IO.FileStream

                    itm.Value = Fila.Item("IDTipoMoneda")

                    If CDbl(Fila.Item("CargosGeneral")) = 0 Then
                        itm.Description = Fila.Item("Signo") & " " & CDbl(Fila.Item("Balance")).ToString("C")
                    Else
                        itm.Description = Fila.Item("Signo") & " " & CDbl(CDbl(Fila.Item("Balance")) + CDbl(Fila.Item("CargosGeneral"))).ToString("C")
                    End If

                    If Fila.Item("MonedaImagen") <> "" Then
                        If System.IO.File.Exists(Fila.Item("MonedaImagen")) Then
                            wFile = New FileStream(Fila.Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                            itm.ImageOptions.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), 18)
                        Else
                            itm.ImageOptions.Image = ResizeImage(My.Resources.No_Image, 18)
                        End If
                    Else
                        itm.ImageOptions.Image = ResizeImage(My.Resources.No_Image, 18)
                    End If

                    ILbcBalances.Items.Add(itm)
                Next

                ds.Dispose()
                ConMixta.Close()
            End If

            cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))

            'Seleccionando el balance correspondiente al cargar
            ''''''''''''''''''''''''''''''''''''''
            Dim dstemp As New DataSet
            ConTemporal.Open()
            cmd = New MySqlCommand("SELECT Clientes_Balances.IDMoneda,idClientes_Balances,TipoMoneda.TasaCompra,Balance,CargosGeneral,Moneda,(Clientes_Balances.LimiteCredito-Clientes_Balances.Balance) as CreditoDisponible FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", ConTemporal)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "tipomoneda")
            ConTemporal.Close()

            If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
                txtBalanceGeneral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
                NombreMoneda = dstemp.Tables("tipomoneda").Rows(0).Item("Moneda")
                txtCreditoDisponible.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CreditoDisponible")).ToString("C")
                lblTasa.Text = dstemp.Tables("tipomoneda").Rows(0).Item("TasaCompra")

                If dstemp.Tables("tipomoneda").Rows(0).Item("IDMoneda") = 1 Then
                    lblTasa.Visible = False
                    Label3.Visible = False
                Else
                    lblTasa.Visible = True
                    Label3.Visible = True
                End If
            End If

            dstemp.Dispose()

        Catch ex As Exception
        MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            If dgvArticulosFactura.Columns.Count > 0 Then
                Dim Condicion As Boolean = False

                If chkPreviewImages.Checked = True Then
                    Dim DatagridWidth As Double = (dgvArticulosFactura.Width - 100 - dgvArticulosFactura.RowHeadersWidth) / 100

                    With dgvArticulosFactura
                        .Columns("IDArtFac").Visible = Condicion
                        .Columns("IDFactura").Visible = Condicion
                        .Columns("IDMedida").Visible = Condicion
                        .Columns("IDPrecios").Visible = Condicion
                        .Columns("Medida").Width = DatagridWidth * 8
                        .Columns("Cantidad").HeaderText = "Cant."
                        .Columns("Cantidad").Width = DatagridWidth * 8
                        .Columns("IDArticulo").Width = DatagridWidth * 8
                        .Columns("IDArticulo").HeaderText = "Código"
                        .Columns("Descripcion").Width = DatagridWidth * 36
                        .Columns("Descripcion").HeaderText = "Descripción"
                        .Columns("Descripcion").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .Columns("Precio").DefaultCellStyle.Format = ("C4")
                        .Columns("Precio").HeaderText = "Precio"
                        .Columns("Precio").Width = DatagridWidth * 12
                        .Columns("Descuento").Visible = False
                        .Columns("Itbis").Width = DatagridWidth * 10
                        .Columns("Importe").DefaultCellStyle.Format = ("C4")
                        .Columns("Importe").Width = DatagridWidth * 12
                        .Columns("IDAlmacen").Width = DatagridWidth * 6
                        .Columns("NivelPrecio").Width = Condicion
                        .Columns("Hijo").Visible = Condicion
                        .Columns("Fraccionamiento").Visible = Condicion
                        .Columns(16).Visible = True
                        .Columns(16).DisplayIndex = 0
                        .RowTemplate.Height = 28
                        .ScrollBars = ScrollBars.Vertical
                    End With

                Else
                    Dim DatagridWidth As Double = (dgvArticulosFactura.Width - dgvArticulosFactura.RowHeadersWidth) / 100

                    With dgvArticulosFactura
                        .Columns("IDArtFac").Visible = Condicion
                        .Columns("IDFactura").Visible = Condicion
                        .Columns("IDMedida").Visible = Condicion
                        .Columns("IDPrecios").Visible = Condicion
                        .Columns("Medida").Width = DatagridWidth * 8
                        .Columns("Cantidad").HeaderText = "Cant."
                        .Columns("Cantidad").Width = DatagridWidth * 5
                        .Columns("IDArticulo").Width = DatagridWidth * 8
                        .Columns("IDArticulo").HeaderText = "Código"
                        .Columns("Descripcion").Width = DatagridWidth * 27
                        .Columns("Descripcion").HeaderText = "Descripción"
                        .Columns("Descripcion").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .Columns("Precio").DefaultCellStyle.Format = ("C4")
                        .Columns("Precio").HeaderText = "Precio"
                        .Columns("Precio").Width = DatagridWidth * 10
                        .Columns("Descuento").Visible = True
                        .Columns("Descuento").DefaultCellStyle.Format = ("C4")
                        .Columns("Descuento").Width = DatagridWidth * 10
                        .Columns("Itbis").Visible = True
                        .Columns("Itbis").DefaultCellStyle.Format = ("C4")
                        .Columns("Itbis").Width = DatagridWidth * 10
                        .Columns("Importe").DefaultCellStyle.Format = ("C4")
                        .Columns("Importe").Width = DatagridWidth * 12
                        .Columns("IDAlmacen").Width = DatagridWidth * 5
                        .Columns("NivelPrecio").Width = DatagridWidth * 5
                        .Columns("Hijo").Visible = Condicion
                        .Columns("Fraccionamiento").Visible = Condicion
                        .Columns(16).Visible = Condicion
                        .RowTemplate.Height = 22
                        .ScrollBars = ScrollBars.Vertical
                    End With
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            lblUsuario.Text = frm_inicio.lblNombre.Text

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetConfiguracion()
        Try
            'Mostrar el panel de informacion de los articulos
            Con.Open()
            ConLibregco.Open()

            'ShowInfoArticle = CInt(DTConfiguracion.Rows(15 - 1).Item("Value2Int"))

            'Permitir facturar debajo del costo
            'FactDebajoCosto = CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int"))

            'Comprobante Fiscal Predeterminado
            cmd = New MySqlCommand("SELECT TipoComprobante FROM Comprobantefiscal Where IDComprobanteFiscal='" + CInt(DTConfiguracion.Rows(13 - 1).Item("Value2Int")).ToString + "'", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

            'Condicion Predeterminada
            cmd = New MySqlCommand("Select Condicion from Condicion Where IDCondicion='" + CInt(DTConfiguracion.Rows(59 - 1).Item("Value2Int")).ToString + "'", ConLibregco)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Facturar sin Existencia
            'FacturarSinExist = CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")).ToString

            'Evitar Sabados en pagares
            'EvitSabado = CInt(DTConfiguracion.Rows(50 - 1).Item("Value2Int")).ToString

            'Evitar Domingos en pagares
            'EvitDomingo = CInt(DTConfiguracion.Rows(51 - 1).Item("Value2Int")).ToString

            'Dias en condicion de pagares
            'DefaultDiasCondicion = CInt(DTConfiguracion.Rows(52 - 1).Item("Value2Int"))

            'Obligación de cédulas en créditos
            'IdentObligCred = CInt(DTConfiguracion.Rows(55 - 1).Item("Value2Int")).ToString

            'Permitir créditos sin contrato
            'PerVentasSContrato = CInt(DTConfiguracion.Rows(79 - 1).Item("Value2Int"))

            'Solicitar autorizacion para créditos
            'SolicitarAutCredito = CInt(DTConfiguracion.Rows(82 - 1).Item("Value2Int"))

            'Permiso general de cambio de fechas
            'CambiarFecha = CInt(DTConfiguracion.Rows(95 - 1).Item("Value2Int"))
            txtFecha.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(95 - 1).Item("Value2Int")))
            txtHora.Enabled = Convert.ToBoolean(CInt(DTConfiguracion.Rows(95 - 1).Item("Value2Int")))


            'Controlar montos de pagos con relación al sueldo
            'lblControlarMontos = CInt(DTConfiguracion.Rows(103 - 1).Item("Value2Int"))

            'Generar pagares automaticamente
            'GenerarPagares = CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int"))

            'Solicitar nombre de cliente cuando excede el limite del monto
            'SolicitarNombreCliente = CInt(DTConfiguracion.Rows(97 - 1).Item("Value2Int"))

            'Límite de total neto para solicitar nombre de clientes en facturación
            'LimiteSolNombre = CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))

            'Imponer RNC y telefonos en ventas con valor fiscal
            'ImponerInfoenNCF = CInt(DTConfiguracion.Rows(114 - 1).Item("Value2Int"))

            'Moneda predeterminada
            'DefaultCurrency = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))

            'Cobrador Predeterminado
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados where IDEmpleado='" + DTConfiguracion.Rows(25 - 1).Item("Value2Int").ToString + "'", Con)
            txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())

            'Controlar ventas sin inicial
            'ControlarVentasSinInicial = CInt(DTConfiguracion.Rows(116 - 1).Item("Value2Int"))

            'Habilitar modificación en facturación del artículo base No.01
            'ModificacionArticuloBase = CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int"))

            'Permitir facturación sin inventario de artículo base No.01
            'FacturacionSinInventarioArticuloBase = CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int"))

            'Cantidad maxima de pagos vencidos
            If CInt(DTConfiguracion.Rows(140 - 1).Item("Value2Int")) = 0 Then
                MaxPagosVencidos = 999
            Else
                MaxPagosVencidos = CInt(DTConfiguracion.Rows(141 - 1).Item("Value2Int"))
            End If

            'Cantidad maxima de facturas pendientes
            If CInt(DTConfiguracion.Rows(142 - 1).Item("Value2Int")) = 0 Then
                MaxFacturasCreditoPermitidas = 999
            Else
                MaxFacturasCreditoPermitidas = CInt(DTConfiguracion.Rows(143 - 1).Item("Value2Int"))
            End If

            'Monto minimo de pagare
            If CInt(DTConfiguracion.Rows(144 - 1).Item("Value2Int")) = 0 Then
                MontoMinimoPagare = 0
            Else
                MontoMinimoPagare = CInt(DTConfiguracion.Rows(145 - 1).Item("Value2Int"))
            End If

            'Control de tipo de pago
            'ControlTipoPago = CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int"))

            'Bloqueo tarjetas de credito
            'BloqueoTarjeta = CInt(DTConfiguracion.Rows(150 - 1).Item("Value2Int"))

            'ModoDuplicado
            'ModoDuplicidadHabilitado = CInt(DTConfiguracion.Rows(160 - 1).Item("Value2Int"))

            'Duplicado de copia del cliente
            'DuplicadoCliente = Convert.ToBoolean(CInt(DTConfiguracion.Rows(161 - 1).Item("Value2Int")))

            'Duplicado de despacho
            'DuplicadoDespacho = Convert.ToBoolean(CInt(DTConfiguracion.Rows(162 - 1).Item("Value2Int")))

            'Duplicado de contabilidad
            'DuplicadoContabilidad = Convert.ToBoolean(CInt(DTConfiguracion.Rows(163 - 1).Item("Value2Int")))

            'Permitir duplicado de articulos
            'PermitirDuplicado = CInt(DTConfiguracion.Rows(170 - 1).Item("Value2Int"))

            'Modificacion desde prefacturacion
            'PermModificacionPrefac = CInt(DTConfiguracion.Rows(171 - 1).Item("Value2Int"))

            'Permitir reeimpresion de originales
            'PermitirReimpresion = CInt(DTConfiguracion.Rows(172 - 1).Item("Value2Int"))

            'Permitir facturas sin prefacturacion
            'ObligarPrefacturaparaFacturar = CInt(DTConfiguracion.Rows(175 - 1).Item("Value2Int"))

            'Altura de las imágenes de facturación
            'PictureHeight = CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))

            'Solicitar confirmacion de vendedor en facturacion
            'SolicitarVendedor = CInt(DTConfiguracion.Rows(181 - 1).Item("Value2Int"))

            'Facturación con límite de crédito agotado
            'ControlarNivelesPrecios = CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int"))

            'Permitir facturación con límite de crédito agotado
            'PermitirFacturacionCreditoAgotado = CInt(DTConfiguracion.Rows(196 - 1).Item("Value2Int"))

            'Bloquear toda facturación de artículo con precio CERO RD$ 0
            'BloqueoPrecioCero = CInt(DTConfiguracion.Rows(211 - 1).Item("Value2Int"))

            'Activar sensibilidad sobre el costo cubierto
            'SensibilidadalCosto = CInt(DTConfiguracion.Rows(213 - 1).Item("Value2Int"))

            'Porcentaje del costo cubierto para exonerar controles de ventas
            NivelSensibilidadalCosto = CInt(DTConfiguracion.Rows(214 - 1).Item("Value3Double")) / 100

            Con.Close()
            ConLibregco.Close()

            Dim PermisosA As New ArrayList
            PermisosA = PasarPermisos(3)

            If PermisosA(0) = 0 Then
                IrAArtículosToolStripMenuItem.Enabled = False
            Else
                IrAArtículosToolStripMenuItem.Enabled = True
            End If

            Dim PermisosConsultaCotizacion As New ArrayList
            PermisosConsultaCotizacion = PasarPermisos(81)

            If PermisosConsultaCotizacion(0) = 0 Then
                ConsultacotizacionToolStripMenuItem.Enabled = False
            Else
                ConsultacotizacionToolStripMenuItem.Enabled = True
            End If

            chkPreviewImages.Checked = frm_inicio.chkPreviewMode.CheckState

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarTodo()
        TabInfoFactura.SelectedIndex = 0
        lblDiasCondicion.Text = 0
        lblItbisArt.Text = 0
        EstadoImpresion = 0
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        lblIDTransaccion.Text = ""
        lblIDAlmacenArticulo.Text = ""
        ControlSuperClave = 1
        LiberarControles.Text = 0
        lblCheckDuplicates.Text = 0
        IDTipopago = 3
        IDGrupoCXC = 1
        txtDiasCondicion.Text = CInt(DTConfiguracion.Rows(52 - 1).Item("Value2Int")).ToString 
        ControlRapido()
        CambiarBalance()
        GbClientes.Text = " Información general"
        PicImagen.Image = My.Resources.no_photo
        TbSelectProductos.Enabled = True
        txtFlete.Text = CDbl(0).ToString("C")
        txtCantidadPagos.Text = CDbl(0).ToString("C")
        txtMontoPagos.Text = CDbl(0).ToString("C")
        txtBalance.Text = CDbl(0).ToString("C")
        cbxCondicion.Text = DefaultCondicion
        txtCondicionContado.Enabled = False
        txtDescripcionArticulo.ReadOnly = True
        txtDescripcionArticulo.Enabled = False
        lblMensajeCalificacion.Visible = False
        cbxMoneda.Properties.Items.Clear()
        ILbcBalances.Items.Clear()
        cbxMoneda.Enabled = True
        GbClientes.Size = New Size(GbClientes.Size.Width, 90)
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        txtFechaVencimiento.Text = Today.ToString("dd/MM/yyyy")
        lblStatusBar.Text = "Listo"
        lblCalificacionColor.BackColor = SystemColors.ButtonShadow
        GPExistencia.Visible = False
        SetIDTipoDocumento()
        FillComprobante()
        FillChofer()
        FillAlmacen()
        FillVehiculo()
        FillCondicion()
        HabilitarControles()
        chkEntregarporConduce.Checked = False
        btnVisualizarPagares.Visible = False
        txtAdicional.ReadOnly = True
        btnModificar.Enabled = True
        chkItbis.Checked = False
        NewNCFValue.Text = ""
        Hora.Enabled = True
        cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))

        If CInt(IDGrupoCXC) <> 4 Then
            Precios = GetRangePrices()
        Else
            Precios.Add("F")
        End If


        For Each item As String In Precios
            cbxPrecio.Items.Add(item)
        Next

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.SelectedIndex = 0
        End If

    End Sub

    Private Sub FillCondicion()
        Try
            Dim Ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillComprobante()
        Try
            Dim Ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            CbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxTipoComprobante.Text = DefaultNcf
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetIDComprobanteFiscal()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        CbxTipoComprobante.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT ImposicionVenta FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        ImponerVentaNCF = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillChofer()
        Try
            Dim Ds As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados WHERE Nulo=0 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            CbxChofer.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")
            For Each Fila As DataRow In Tabla.Rows
                CbxChofer.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxChofer.SelectedIndex = 0
            Else
                MessageBox.Show("No se pudo cargar un chofer para definirla en la factura ya que no se encontraron resultados de empleados bajo esa condición." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDChofer()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + CbxChofer.SelectedItem + "'", Con)
        CbxChofer.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillAlmacen()
        Try
            Dim Ds As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen ORDER BY Almacen.Almacen ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Almacen")
            cbxAlmacen.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Almacen")

            For Each Fila As DataRow In Tabla.Rows
                cbxAlmacen.Items.Add(Fila.Item("Almacen"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxAlmacen.SelectedIndex = 0
            Else
                MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Tabla.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        cbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillVehiculo()
        Dim Ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT DatoVehiculo FROM Vehiculo ORDER BY Marca ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Vehiculo")
        cbxVehiculo.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Vehiculo")
        For Each Fila As DataRow In Tabla.Rows
            cbxVehiculo.Items.Add(Fila.Item("DatoVehiculo"))
        Next
        If Tabla.Rows.Count > 0 Then
            cbxVehiculo.SelectedIndex = 0
        Else
            MessageBox.Show("No se pudo cargar un vehículo para definirlo en la factura ya que no se encontraron resultados de vehículos activos. Por favor cree un registros de vehículos." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
        Tabla.Dispose()
    End Sub

    Private Sub SetIDVehiculo()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDVehiculo FROM Vehiculo WHERE DatoVehiculo= '" + cbxVehiculo.SelectedItem + "'", ConLibregco)
        cbxVehiculo.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        SetIDComprobanteFiscal()
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        SetIDAlmacen()
    End Sub

    Private Sub CbxChofer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxChofer.SelectedIndexChanged
        SetIDChofer()
    End Sub

    Private Sub cbxVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVehiculo.SelectedIndexChanged
        SetIDVehiculo()
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        SumarTotalArticulo()
        If Len(txtPrecio.Text) = 0 Then
            txtPrecio.Text = 0
            txtPrecio.SelectAll()
        End If
    End Sub

    Private Sub txtCantidadArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadArticulo.TextChanged
        SumarTotalArticulo()
    End Sub

    Sub SumarTotalArticulo()
        Try
            txtTotalArt.Text = (CDbl(txtCantidadArticulo.Text) * (CDbl(txtPrecio.Text))).ToString("C")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCantidadArticulo_Leave(sender As Object, e As EventArgs) Handles txtCantidadArticulo.Leave
        Try
            If IsNumeric(txtCodigoArticulo.Text) Then
                If txtCantidadArticulo.Text = "" Then
                    txtCantidadArticulo.Text = 1
                ElseIf txtCantidadArticulo.Text = 0 Then
                    txtCantidadArticulo.Text = 1
                End If

            Else
                txtCantidadArticulo.Text = 1
            End If

        Catch ex As Exception
            txtCantidadArticulo.Text = 1
        End Try
    End Sub

    Sub SetInformacionArticulo()
        Try
            Dim Ds As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE IDArticulo='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count = 0 Then
                ConLibregco.Open()
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE Referencia='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Articulos")
                ConLibregco.Close()

                Tabla = Ds.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    ConLibregco.Open()
                    Ds.Clear()
                    cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,Articulos.RutaFoto,IDTipoProducto,VecesVendido,VecesComprado,ServicioPersonalizable FROM Articulos WHERE CodigoBarra='" + txtCodigoArticulo.Text + "' and Articulos.Desactivar=0", ConLibregco)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Articulos")
                    ConLibregco.Close()

                    Tabla = Ds.Tables("Articulos")

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtCodigoArticulo.Focus()
                        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                    Else

                        If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                            If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                                MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        End If

                        txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                        lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                        txtCantidadArticulo.Text = 1
                        lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")
                        lblDescuento.Text = 0

                        If TypeConnection.Text = 1 Then
                            If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                                ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                            Else
                                If chkPreviewImages.Checked Then
                                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                                    If ExistFile = True Then
                                        Dim wFile As System.IO.FileStream
                                        wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                        ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                        wFile.Close()
                                    Else
                                        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                    End If
                                End If
                            End If
                        Else
                            ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                        End If

                        FillMedida()
                        CargarExistenciasTreeView()

                    End If
                Else

                    If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                        If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                            MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                    lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                    txtCantidadArticulo.Text = 1
                    lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")
                    lblDescuento.Text = 0

                    If TypeConnection.Text = 1 Then
                        If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                            ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                        Else
                            If chkPreviewImages.Checked Then
                                Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                                If ExistFile = True Then
                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                    ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                    wFile.Close()
                                Else
                                    ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                End If
                            End If
                        End If
                    Else
                        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                    End If

                    FillMedida()
                    CargarExistenciasTreeView()
                End If

            Else

                If CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1 Then
                    If CDbl(Tabla.Rows(0).Item("VecesVendido")) = 0 And CDbl(Tabla.Rows(0).Item("VecesComprado")) = 0 Then
                        MessageBox.Show("La facturación de artículos sin transacciones de ventas o compras está bloqueada del sistema. Para arreglar esta opción por favor visite el apartado de Ajustes de Empresa en el encabezado de facturación.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblExistencia.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
                txtCantidadArticulo.Text = 1
                lblIDTipoProducto.Text = Tabla.Rows(0).Item("IDTipoProducto")
                lblDescuento.Text = 0

                If TypeConnection.Text = 1 Then
                    If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                    Else
                        If chkPreviewImages.Checked Then
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                wFile.Close()
                            Else
                                ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                            End If
                        End If
                    End If
                Else
                    ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                End If

                FillMedida()
                CargarExistenciasTreeView()



            End If

            If txtCodigoArticulo.Text = "1" Then
                If CInt(DTConfiguracion.Rows(128 - 1).Item("Value2Int")) = 1 Then
                    txtDescripcionArticulo.ReadOnly = False
                    txtDescripcionArticulo.Enabled = True
                    txtDescripcionArticulo.Focus()
                Else
                    txtDescripcionArticulo.ReadOnly = True
                    txtDescripcionArticulo.Enabled = False
                End If
            Else
                If Tabla.Rows(0).Item("ServicioPersonalizable") = "1" Then
                    txtDescripcionArticulo.ReadOnly = False
                    txtDescripcionArticulo.Enabled = True
                    txtDescripcionArticulo.Focus()
                Else
                    txtDescripcionArticulo.ReadOnly = True
                    txtDescripcionArticulo.Enabled = False
                End If
            End If

            If txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZABLE") Or txtDescripcionArticulo.Text.Contains("Tola Personalizable") Or txtDescripcionArticulo.Text.Contains("TOLA PERSONALIZADA") Or txtDescripcionArticulo.Text.Contains("Tola Personalizada") Then
                frm_calculo_tolas.ShowDialog(Me)
            End If


            Tabla.Dispose()
            Ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub CargarExistenciasTreeView()
        Try
            Dim ds0, ds1, ds2 As New DataSet
            Dim MyNode() As TreeNode

            TreeViewExistencia.Nodes.Clear()

            'Primero cargo todos los sucursales
            ds0.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & "Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtCodigoArticulo.Text + "' AND Sucursal.Nulo=0 GROUP BY Sucursal.IDSucursal", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds0, "Sucursal")
            ConMixta.Close()

            Dim TablaSucursales As DataTable = ds0.Tables("Sucursal")
            Dim IDSucursal, IDAlmacen, Medida As New Label

            For Each FilaSucursal As DataRow In TablaSucursales.Rows
                IDSucursal.Text = FilaSucursal.Item("IDSucursal")
                If CDbl(FilaSucursal.Item("Existencia")) = 0 Then
                    Medida.Text = ": [No hay unidades en stock]"
                ElseIf CDbl(FilaSucursal.Item("Existencia")) = 1 Then
                    Medida.Text = ": Sólo " & FilaSucursal.Item("Existencia") & " unidad encontrada."
                Else
                    Medida.Text = ": " & FilaSucursal.Item("Existencia") & " unidades encontradas."
                End If

                TreeViewExistencia.Nodes.Add(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), "Sucursal: " & FilaSucursal.Item("Sucursal") & Medida.Text)

                ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & " Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & " Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtCodigoArticulo.Text + "' AND Sucursal.IDSucursal='" + IDSucursal.Text + "' AND Almacen.Desactivar=0 GROUP BY Almacen.IDAlmacen", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds1, "Almacenes")
                ConMixta.Close()

                Dim TablaAlmacenes As DataTable = ds1.Tables("Almacenes")

                For Each FilaAlmacen As DataRow In TablaAlmacenes.Rows
                    IDAlmacen.Text = FilaAlmacen.Item("IDAlmacen")
                    If CDbl(FilaAlmacen.Item("Existencia")) = 0 Then
                        Medida.Text = ": [No hay unidades]"
                    ElseIf CDbl(FilaAlmacen.Item("Existencia")) = 1 Then
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidad"
                    Else
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidades"
                    End If

                    MyNode = TreeViewExistencia.Nodes.Find(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), True)
                    MyNode(0).Nodes.Add(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), "[" & FilaAlmacen.Item("IDAlmacen") & "] " & FilaAlmacen.Item("Almacen") & Medida.Text)

                    ds2.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT Existencia.IDAlmacen,Medida.IDMedida,Medida.Medida,Existencia FROM Libregco.existencia INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDArticulo='" + txtCodigoArticulo.Text + "' and IDAlmacen='" + IDAlmacen.Text + "' and PrecioArticulo.Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(ds2, "Medidas")
                    ConMixta.Close()

                    Dim TablaMedidas As DataTable = ds2.Tables("Medidas")

                    For Each FilaMedida As DataRow In TablaMedidas.Rows
                        MyNode = TreeViewExistencia.Nodes.Find(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), True)
                        MyNode(0).Nodes.Add(FilaMedida.Item("IDMedida") & FilaMedida.Item("Medida"), FilaMedida.Item("Existencia") & " " & (FilaMedida.Item("Medida").ToString.ToLower))
                    Next
                Next
            Next

            TreeViewExistencia.ExpandAll()

            GPExistencia.Visible = True

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub txtCodigoArticulo_Leave(sender As Object, e As EventArgs) Handles txtCodigoArticulo.Leave
        Try
            If txtCodigoArticulo.Text = "" Then
                LimpiarDatosArticulo2()
            Else
                lblIDAlmacenArticulo.Text = cbxAlmacen.Tag.ToString
                SetInformacionArticulo()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub txtCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtCodigoArticulo.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Try
            If Fraccionamiento = 1 Then
                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select

                If (txtCantidadArticulo.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
                    e.Handled = True
                End If
            Else

                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    'Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiarDatosArticulos()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        lblDescuento.Text = 0
        txtPrecio.Clear()
        txtTotalArt.Clear()
        txtCantidadArticulo.Clear()
        CbxMedida.Tag = ""
        cbxPrecio.Tag = ""
        lblExistencia.Text = ""
        lblIDAlmacenArticulo.Text = ""
        IDArticulo.Text = ""
        lblIDFactArt.Text = ""
        GPExistencia.Visible = False
        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
        txtCodigoArticulo.Focus()
    End Sub

    Sub LimpiarDatosArticulo2() 'Para limpiar si crear error al salir del txtIDCodigoArticulo en el evento Leave
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        lblDescuento.Text = 0
        txtPrecio.Clear()
        txtTotalArt.Clear()
        CbxMedida.Tag = ""
        cbxPrecio.Tag = ""
        lblExistencia.Text = ""
        IDArticulo.Text = ""
        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
    End Sub

    Private Sub FillMedida()
        Dim Ds As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0 order by contenido desc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")
        CbxMedida.Items.Clear()
        ConLibregco.Close()
        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")
        For Each Fila As DataRow In Tabla.Rows
            CbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron registros de medidas del artículo consultado.", "No hay registros de precios para el artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ElseIf Tabla.Rows.Count > 0 Then
            CbxMedida.SelectedIndex = 0
        End If

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.Text = txtNivelPrecio.Text
        End If

    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        CbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Fraccionamiento = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + CbxMedida.Tag.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
        cbxPrecio.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue)).ToString("C")
    End Sub

    Sub ChangeItebis()
        Dim IDItebis As Double

        ConLibregco.Open()

        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            If chkItbis.Checked = True Then
                Row.Cells(10).Value = CDbl(0).ToString("C4")
                Row.Cells(11).Value = (CDbl(Row.Cells(8).Value) * CDbl(Row.Cells(4).Value)).ToString("C4")
            Else
                cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + Row.Cells(6).Value.ToString + "'", ConLibregco)
                IDItebis = Convert.ToDouble(cmd.ExecuteScalar())

                Row.Cells(10).Value = (CDbl(Row.Cells(8).Value) * CDbl(IDItebis)).ToString("C4")
                Row.Cells(11).Value = ((CDbl(Row.Cells(8).Value) + CDbl(Row.Cells(10).Value)) * CDbl(Row.Cells(4).Value)).ToString("C4")
            End If

        Next

        ConLibregco.Close()

        SumTotales()
    End Sub
    Private Sub BuscarItebis()
        If chkItbis.Checked = True Then
            lblItbisArt.Text = 0
        Else
            ConLibregco.Open()
            cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
            lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If

    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If x = dgvArticulosFactura.Rows.Count Or dgvArticulosFactura.Rows.Count = 0 Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If dgvArticulosFactura.Rows(x).Cells(2).Value = cbxPrecio.Tag.ToString Then
            MessageBox.Show("Este artículo ya se encuentra en la factura con la misma medida." & vbNewLine & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCodigoArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub btnInsertarArticulo_Click(sender As Object, e As EventArgs) Handles btnInsertarArticulo.Click
        Try

            If txtCodigoArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCodigoArticulo.Focus()

            Else
                If lblIDTipoProducto.Text <> 2 Then
                    If CInt(DTConfiguracion.Rows(21 - 1).Item("Value2Int")).ToString = 0 Then
                        If txtCodigoArticulo.Text = 1 Then
                            If CInt(DTConfiguracion.Rows(129 - 1).Item("Value2Int")) = 0 Then
                                If txtIDFactura.Text = "" Then
                                    If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                        MessageBox.Show("No se puede facturar el artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & ", ya que no tiene existencias en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        Exit Sub
                                    End If
                                End If
                            End If

                        Else
                            If txtIDFactura.Text = "" Then
                                If CDbl(lblExistencia.Text) < CDbl(txtCantidadArticulo.Text) Then
                                    MessageBox.Show("No se puede facturar el artículo [" & txtCodigoArticulo.Text & "] " & txtDescripcionArticulo.Text & ", ya que no tiene existencias en el sistema." & vbNewLine & vbNewLine & "Para más información puede referirse a su supervisor o ir a la sección Ayuda [F2] en el apartado [Facturación].", "No se encuentran existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    Exit Sub
                                End If
                            End If

                        End If
                    End If
                End If


                If CInt(DTConfiguracion.Rows(211 - 1).Item("Value2Int")) = 1 Then
                    If CDbl(txtPrecio.Text) = 0 Then
                        MessageBox.Show("En estos momentos todo precio 0 está bloqueado a nivel de facturación.", "Precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                If CInt(DTConfiguracion.Rows(170 - 1).Item("Value2Int")) = 0 Then
                    VerificarDuplicados()
                    If lblCheckDuplicates.Text = 1 Then
                        Exit Sub
                    End If
                End If

                BuscarItebis()

                With dgvArticulosFactura
                    .Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, cbxPrecio.Tag.ToString, CbxMedida.Tag.ToString, txtCantidadArticulo.Text, CbxMedida.Text, IDArticulo.Text, txtDescripcionArticulo.Text, (CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C4"), CDbl(lblDescuento.Text).ToString("C4"), ((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArt.Text))) * CDbl(lblItbisArt.Text)).ToString("C4"), CDbl(txtPrecio.Text) * CDbl(txtCantidadArticulo.Text), lblIDAlmacenArticulo.Text, cbxPrecio.Text, 0, Fraccionamiento, ResizeImage(ProductImage, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))))
                End With

                SumTotales()
                CreatePagares()
                BuscarHijos()
                BuscarPreguntas
                LimpiarDatosArticulos()
                HabilitarEscCredito()
                btnModificar.Enabled = True
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
                If dgvArticulosFactura.Rows.Count > 0 Then
                    cbxMoneda.Enabled = False
                End If

                dgvArticulosFactura.FirstDisplayedScrollingRowIndex = dgvArticulosFactura.Rows.Count - 1
                txtCodigoArticulo.Focus()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarPreguntas()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idArticulos_preguntas,IDArticulo,Titulo,Descripcion,Abierta,Opciones FROM libregco.articulos_preguntas Where articulos_preguntas.IDArticulo ='" + txtCodigoArticulo.Text + "' and articulos_preguntas.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "articulos_preguntas")
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("articulos_preguntas")

        If Tabla.Rows.Count > 0 Then
            For Each dt As DataRow In Tabla.Rows
                Dim foundRow() As DataRow = TablaQuestions.Select("idArticulos_preguntas='" & dt.Item("idArticulos_preguntas").ToString & "'")

                If foundRow.Length > 0 Then
                Else
                    If frm_questions_facturacion.Visible = True Then
                        frm_questions_facturacion.Close()
                    End If

                    frm_questions_facturacion.IDQuestion = dt.Item("idArticulos_preguntas")
                    frm_questions_facturacion.IDArticulo = dt.Item("IDArticulo")
                    frm_questions_facturacion.GCTitulo.Text = dt.Item("Titulo")
                    frm_questions_facturacion.Descripcion.Text = dt.Item("Descripcion")
                    frm_questions_facturacion.Abierta = dt.Item("Abierta")
                    frm_questions_facturacion.Opciones = dt.Item("Opciones")

                    If dt.Item("Opciones") = "" Then
                        If dt.Item("Abierta") = 1 Then
                            frm_questions_facturacion.NavTipos.ActiveGroup = frm_questions_facturacion.NavTipos.Groups(0)
                            frm_questions_facturacion.NavTipos.Groups(0).Visible = True
                            frm_questions_facturacion.NavTipos.Groups(1).Visible = False
                            frm_questions_facturacion.NavTipos.Groups(2).Visible = False
                            frm_questions_facturacion.txtRepuestaAbierta.Focus()

                        ElseIf dt.Item("Abierta") = 0 Then
                            frm_questions_facturacion.NavTipos.ActiveGroup = frm_questions_facturacion.NavTipos.Groups(1)

                            frm_questions_facturacion.NavTipos.Groups(0).Visible = False
                            frm_questions_facturacion.NavTipos.Groups(1).Visible = True
                            frm_questions_facturacion.NavTipos.Groups(2).Visible = False
                            frm_questions_facturacion.btnSi.Focus()
                        End If
                    Else
                        frm_questions_facturacion.NavTipos.ActiveGroup = frm_questions_facturacion.NavTipos.Groups(2)
                        frm_questions_facturacion.NavTipos.Groups(0).Visible = False
                        frm_questions_facturacion.NavTipos.Groups(1).Visible = False
                        frm_questions_facturacion.NavTipos.Groups(2).Visible = True

                    End If



                    frm_questions_facturacion.ShowDialog(Me)

                End If



            Next
        End If

    End Sub

    Private Sub BuscarHijos()
        Try
            Dim dsTemp As New DataSet

            If txtIDFactura.Text = "" Then

                dsTemp.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo,ArticulosHijo.Descripcion,ArticulosHijo.Referencia,CantidadEnOferta,IDPrecioHijo,MedidaHijo.Medida,LimitarHastaFecha,HastaFecha,ValorIncluidoPrecio,Nivel,Precio,Articulos_hijos.Nulo,ArticulosHijo.RutaFoto FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo ='" + txtCodigoArticulo.Text + "' and articulos_hijos.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dsTemp, "Articulos")
                ConLibregco.Close()

                Dim Tabla As DataTable = dsTemp.Tables("Articulos")

                If Tabla.Rows.Count > 0 Then

                    For Each row As DataRow In Tabla.Rows
                        'Si la fecha es valida
                        If row.Item(10) = 1 Or CDate(row.Item(11)) >= Today Then

                            'Si la cantidad aplica
                            If CDbl(txtCantidadArticulo.Text) >= row.Item(2) Then

                                'Busco en los articulos de la factura
                                If cbxPrecio.Tag.ToString = row.Item(1) Then

                                    Dim CantidadOfertaGenerada As Integer = CInt(txtCantidadArticulo.Text) * CInt(row.Item(7))

                                    txtCodigoArticulo.Text = row.Item(4)
                                    SetInformacionArticulo()

                                    If chkItbis.Checked = True Then
                                        lblItbisArt.Text = 0
                                    Else
                                        ConLibregco.Open()
                                        cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtCodigoArticulo.Text + "'", ConLibregco)
                                        lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
                                        ConLibregco.Close()
                                    End If

                                    Dim ExistFile As Boolean = System.IO.File.Exists(row.Item(16))
                                    If ExistFile = True Then
                                        Dim wFile As System.IO.FileStream
                                        wFile = New FileStream(row.Item(16), FileMode.Open, FileAccess.Read)
                                        ProductImage = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                        wFile.Close()
                                    Else
                                        ProductImage = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                    End If

                                    If row.Item(12) = 1 Then
                                        dgvArticulosFactura.Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, cbxPrecio.Tag.ToString, CbxMedida.Tag.ToString, CantidadOfertaGenerada, CbxMedida.Text, IDArticulo.Text, "+ " & txtDescripcionArticulo.Text, (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), (0).ToString("C"), (0).ToString("C"), lblIDAlmacenArticulo.Text, cbxPrecio.Text, 1, 0, ResizeImage(ProductImage, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))))
                                    Else
                                        dgvArticulosFactura.Rows.Add(lblIDFactArt.Text, txtIDFactura.Text, cbxPrecio.Tag.ToString, CbxMedida.Tag.ToString, CantidadOfertaGenerada, CbxMedida.Text, IDArticulo.Text, txtDescripcionArticulo.Text, (CDbl(txtPrecio.Text) / (1 + CDbl(lblItbisArt.Text))), CDbl(lblDescuento.Text).ToString("C"), ((CDbl(txtPrecio.Text) / (CantidadOfertaGenerada + CDbl(lblItbisArt.Text))) * CDbl(lblItbisArt.Text)).ToString("C"), CDbl(txtPrecio.Text) * CantidadOfertaGenerada, lblIDAlmacenArticulo.Text, cbxPrecio.Text, 1, 0, ResizeImage(ProductImage, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int"))))
                                    End If
                                End If

                            End If

                        End If


                    Next

                    SumTotales()
                End If

                dgvArticulosFactura.ClearSelection()
                Tabla.Dispose()
                dsTemp.Dispose()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub dgvArticulosFactura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar este artículo de la factura", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = MsgBoxResult.Yes Then
                dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                SumTotales()
                CreatePagares()
                HabilitarEscCredito()
            End If
        End If
    End Sub

    Sub SetIDTipoDocumento()
        If lblDiasCondicion.Text = 0 Then
            lblIDTipoDocumento.Text = 1
        Else
            lblIDTipoDocumento.Text = 2
        End If
    End Sub

    Sub SumTotales()
        Try
            Dim SubTotal As Double = 0
            Dim Descuentos As Double = 0
            Dim Itbis As Double = 0
            Dim Importe As Double = 0

            For Each Rows As DataGridViewRow In dgvArticulosFactura.Rows
                SubTotal = SubTotal + (CDbl(Rows.Cells(8).Value) * (CDbl(Rows.Cells(4).Value)))
                Descuentos = Descuentos + ((CDbl(Rows.Cells(9).Value)) * (CDbl(Rows.Cells(4).Value)))
                Itbis = Itbis + ((CDbl(Rows.Cells(10).Value)) * (CDbl(Rows.Cells(4).Value)))
                Importe = Importe + (CDbl(Rows.Cells(11).Value))
            Next

            txtSubTotal.Text = SubTotal.ToString("C")
            TxtDescuentoSuma.Text = Descuentos.ToString("C")
            txtITBIS.Text = Itbis.ToString("C")
            txtNeto.Text = (CDbl(txtFlete.Text) + Importe).ToString("C")

            CalcularMontoPago()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtFlete_Leave(sender As Object, e As EventArgs) Handles txtFlete.Leave
        If txtFlete.Text = "" Then
            txtFlete.Text = CDbl(0).ToString("C")
        Else
            txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
        End If
        SumTotales()
        CalcularMontoPago()
        CreatePagares()
    End Sub

    Private Sub txtFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlete.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub dgvArticulosFactura_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvArticulosFactura.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < dgvArticulosFactura.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If dgvArticulosFactura.RowHeadersWidth < CInt(size.Width + 20) Then
                dgvArticulosFactura.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub AjCondContado()
        TabPagCondicion.Visible = False
        txtInicial.Text = CDbl(0)
        txtBalance.Text = 0
        txtCantidadPagos.Text = 0
        txtMontoPagos.Text = 0
        txtAdicional.Text = 0
        txtFechaAdicional.Text = ""
        txtCondicionContado.Text = ""
        chkFichaDatos.Checked = False
        chkHabilitarNota.Checked = False
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtITBIS.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        TxtDescuentoSuma.Text = CDbl(0).ToString("C")
        txtFechaVencimiento.Text = Today.ToString("dd/MM/yyyy")
    End Sub

    Private Sub AjCondCredito()
        TabPagCondicion.Visible = True
        TabPagCondicion.SelectedIndex = 0
        txtInicial.Text = CDbl(0.0).ToString("C")
        txtBalance.Text = CDbl(0.0).ToString("C")
        txtCantidadPagos.Text = 1
        txtMontoPagos.Text = txtBalance.Text
        txtAdicional.Text = CDbl(0).ToString("C")
        txtCondicionContado.Text = ""
    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        If txtInicial.Text = "" Then
            txtInicial.Text = (0).ToString("C")
            txtBalance.Text = txtNeto.Text
        Else
            If IsNumeric(txtInicial.Text) Then
                If CDbl(txtInicial.Text) > 0 And CDbl(txtInicial.Text) >= CDbl(txtNeto.Text) Then
                    MessageBox.Show("El inicial es igual al monto neto de la factura." & vbNewLine & vbNewLine & "Por favor cambie la condición de la factura a {CONTADO}.", "Error en Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtInicial.Text = CDbl(0).ToString("C")
                    Exit Sub
                Else
                    txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
                End If
            Else
                txtInicial.Text = (0).ToString("C")
            End If

        End If

        ValidacionEnInicial()
        CreatePagares()
    End Sub

    Private Sub txtInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInicial.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadPagos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtAdicional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdicional.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Friend Sub HabilitarEscCredito()
        If txtIDFactura.Text = "" Then
            If dgvArticulosFactura.Rows.Count = 0 Then
                TabPagCondicion.Enabled = False
                txtInicial.Text = CDbl(0).ToString("C")
                txtBalance.Text = CDbl(0).ToString("C")
                txtCantidadPagos.Text = 1
                txtAdicional.Text = CDbl(0).ToString("C")
                SumTotales()
            Else
                TabPagCondicion.Enabled = True
            End If
        End If

    End Sub

    Private Sub txtCantidadPagos_Leave(sender As Object, e As EventArgs) Handles txtCantidadPagos.Leave
        If txtCantidadPagos.Text = "" Then
            txtCantidadPagos.Text = 1
        End If

        If txtCantidadPagos.Text = 0 Then
            txtCantidadPagos.Text = 1
        ElseIf txtCantidadPagos.Text = 1 Then
            txtAdicional.ReadOnly = True
            txtAdicional.Text = CDbl(0).ToString("C")
            txtFechaAdicional.Text = ""
            txtFechaAdicional.Mask = ""
            txtFechaAdicional.Enabled = False
        ElseIf txtCantidadPagos.Text > 1 Then
            txtAdicional.ReadOnly = False
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
    End Sub

    Friend Sub CalcularMontoPago()
        Try
            If CDbl(txtNeto.Text) > 0 Then
                If lblDiasCondicion.Text > 0 Then
                    txtBalance.Text = (CDbl(txtNeto.Text) - CDbl(txtInicial.Text)).ToString("C")

                    If CDbl(txtAdicional.Text) = 0 Then
                        txtMontoPagos.Text = (CDbl(txtBalance.Text) / CInt(txtCantidadPagos.Text)).ToString("C")

                    Else
                        txtMontoPagos.Text = ((CDbl(txtBalance.Text) - CDbl(txtAdicional.Text)) / (CInt(txtCantidadPagos.Text) - 1)).ToString("C")
                    End If
                    'ASD
                Else
                    txtBalance.Text = CDbl(0).ToString("C")
                End If
            End If

            If txtCantidadPagos.Text = "" Or txtCantidadPagos.Text = 0 Then
                txtCantidadPagos.Text = 1
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " CalcularMontoPago")
        End Try
    End Sub

    Private Sub txtCantidadPagos_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadPagos.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub txtAdicional_Leave(sender As Object, e As EventArgs) Handles txtAdicional.Leave
        If txtAdicional.Text = "" Then
            txtAdicional.Text = CDbl(0).ToString("C")
            txtFechaAdicional.Clear()

        Else
            If IsNumeric(txtAdicional.Text) Then
                txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
            Else
                txtAdicional.Text = CDbl(0).ToString("C")
                txtFechaAdicional.Clear()
            End If

        End If
        ValidacionEnAdicional()
    End Sub

    Private Sub txtAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtAdicional.TextChanged
        If txtAdicional.Text = "" Then
            txtAdicional.Text = 0
            txtAdicional.SelectAll()
        Else
            If IsNumeric(txtAdicional.Text) Then

                CalcularMontoPago()
                If Len(txtAdicional.Text) = 0 Then
                    txtAdicional.Text = 0
                    txtAdicional.SelectAll()
                End If
            End If
        End If

    End Sub

    Private Sub ValidacionEnInicial()
        Dim Neto, Inicial As Double
        Neto = txtNeto.Text
        Inicial = txtInicial.Text

        If Inicial > Neto Then
            MessageBox.Show("El inicial introducido en la factura es mayor al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el inicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtInicial.Text = CDbl(0).ToString("C")
            txtInicial.Focus()
        End If

        CalcularMontoPago()

    End Sub

    Private Sub ValidacionEnAdicional()
        Dim Balance, Adicional As Double
        Balance = txtBalance.Text
        Adicional = txtAdicional.Text

        If Adicional >= Balance Then
            MessageBox.Show("El adicional introducido en la factura es mayor o igual al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtAdicional.Text = CDbl(0).ToString("C")
            'txtAdicional.Focus()
            Exit Sub
        End If

        If CDbl(txtAdicional.Text) > 0 Then
            txtFechaAdicional.Enabled = True
            txtFechaAdicional.Focus()
        Else
            txtFechaAdicional.Enabled = False
        End If
    End Sub

    Private Sub txtInicial_TextChanged(sender As Object, e As EventArgs) Handles txtInicial.TextChanged
        CalcularMontoPago()
        If Len(txtInicial.Text) = 0 Then
            txtInicial.Text = 0
            txtInicial.SelectAll()
        End If
    End Sub

    Private Sub txtFechaAdicional_Leave(sender As Object, e As EventArgs) Handles txtFechaAdicional.Leave
        ValidarFechaAdicional()

        If IsDate(txtFechaAdicional.Text) Then
            CreatePagares()
            CalcVencientoFactura()
        Else
            CreatePagares()
            txtFechaAdicional.Clear()
            txtFechaAdicional.Mask = ""
            txtFechaAdicional.Enabled = False
            txtAdicional.Text = CDbl(0).ToString("C")
            CalcVencientoFactura()
        End If

    End Sub

    Private Sub ValidarFechaAdicional()
        Try
            If CDbl(txtAdicional.Text) > 0 Then
                If IsDate(txtFechaAdicional.Text) Then
                    If CDate(txtFechaAdicional.Text) < CDate(txtFecha.Value) Then
                        MessageBox.Show("La fecha del adicional introducida en la factura es menor a la fecha de la factura." & vbNewLine & vbNewLine & "Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtFechaAdicional.Clear()
                        txtFechaAdicional.Focus()
                    ElseIf CDate(txtFechaAdicional.Text) > Today.AddYears(1) Then
                        MessageBox.Show("La fecha del adicional no puede ser mayor a un año." & vbNewLine & vbNewLine & "Por favor vuelva a calcular utilizando una distribución de pagos diferente.", "Fecha de adicional no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFechaAdicional.Clear()
                        txtFechaAdicional.Focus()
                    End If

                    MessageBox.Show("Recuerde que el pagaré adicional está incluído en la cantidad de pagarés." & vbNewLine & vbNewLine & "Está por generar " & txtCantidadPagos.Text & " pagarés en la factura.", "Cantidad de pagarés", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("La fecha suministrada no es una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFechaAdicional.Clear()
                    txtFechaAdicional.Mask = ""
                    txtFechaAdicional.Enabled = False
                    txtAdicional.Text = CDbl(0).ToString("C")
                    txtAdicional.Focus()
                End If
            Else
                txtFechaAdicional.Clear()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkHabilitarNota_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarNota.CheckedChanged
        If chkHabilitarNota.Checked = True Then
            frm_int_notacontado.ShowDialog(Me)
        Else
            txtCondicionContado.Clear()
        End If
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub LimpiarDatos()
        dgvArticulosFactura.Rows.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefonos.Clear()
        txtBalanceGeneral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtIDFactura.Clear()
        txtSecondID.Clear()
        txtNIF.Clear()
        txtObservacion.Clear()
        txtNivelPrecio.Clear()
        LimpiarDatosArticulos()
        AjCondContado()
        txtFlete.Text = CDbl(0).ToString("C")
        CbxTipoComprobante.Items.Clear()
        txtVendedor.Tag = ""
        txtVendedor.Text = ""
        lblTasa.Text = ""
        cbxAlmacen.Items.Clear()
        txtOrden.Clear()
        CbxChofer.Items.Clear()
        cbxVehiculo.Items.Clear()
        cbxCondicion.Items.Clear()
        cbxAlmacen.Items.Clear()
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtITBIS.Text = CDbl(0).ToString("C")
        TxtDescuentoSuma.Text = CDbl(0).ToString("C")
        txtFlete.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        GbClientes.Text = " Información general"
        chkDesactivar.Checked = False
        txtCobrador.Text = ""
        txtCobrador.Tag = ""
        LastIDFact = ""
        PagaresCreados.Clear()
        TablaQuestions.Rows.Clear()
        txtRNC.Clear()
        txtCreditoDisponible.Clear()
        cbxPrecio.Items.Clear()
        DgvPagares.Rows.Clear()
        AccionesModulosAutorizadas.Clear 
        btnBuscarCliente.Focus()
    End Sub

    Private Sub CalcVencientoFactura()
        Try
            Dim MayorDate As Date

            If CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int")) = 1 Then

                MayorDate = Today

                For Each Row As DataGridViewRow In DgvPagares.Rows
                    If CDate(Row.Cells(4).Value) > MayorDate Then
                        MayorDate = CDate(Row.Cells(4).Value)
                    End If
                Next

                txtFechaVencimiento.Text = MayorDate.ToString("dd/MM/yyyy")

            Else
                txtFechaVencimiento.Text = CDate(txtFecha.Value.AddDays(lblDiasCondicion.Text)).ToString("dd/MM/yyyy")
            End If



        Catch ex As Exception
            txtCantidadPagos.Text = 1
            txtFechaVencimiento.Text = CDate(txtFecha.Value.AddDays(lblDiasCondicion.Text)).ToString("dd/MM/yyyy")
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub HabilitarControles()
        TabInfoFactura.Enabled = True
        cbxCondicion.Enabled = True
        txtVendedor.Enabled = True
        txtCobrador.Enabled = True
        cbxAlmacen.Enabled = True
        CbxChofer.Enabled = True
        cbxVehiculo.Enabled = True
        txtCodigoArticulo.Enabled = True
        btnBuscarArticulo.Enabled = True
        txtCantidadArticulo.Enabled = True
        txtDescripcionArticulo.Enabled = True
        dgvArticulosFactura.Enabled = True
        TabPagCondicion.Enabled = True
        txtFlete.Enabled = True
        CbxMedida.Enabled = True
        btnInsertarArticulo.Enabled = True
        btnBuscarCliente.Enabled = True
        txtPrecio.Enabled = True
        Hora.Enabled = True
        txtDireccion.Enabled = True
        txtTelefonos.Enabled = True
        btnAnular.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        TabInfoFactura.Enabled = False
        cbxCondicion.Enabled = False
        txtVendedor.Enabled = False
        txtCobrador.Enabled = False
        cbxAlmacen.Enabled = False
        CbxChofer.Enabled = False
        cbxVehiculo.Enabled = False
        txtCodigoArticulo.Enabled = False
        btnBuscarArticulo.Enabled = False
        txtCantidadArticulo.Enabled = False
        txtDescripcionArticulo.Enabled = False
        dgvArticulosFactura.Enabled = False
        TabPagCondicion.Enabled = False
        txtFlete.Enabled = False
        CbxMedida.Enabled = False
        btnInsertarArticulo.Enabled = False
        btnBuscarCliente.Enabled = False
        txtPrecio.Enabled = False
        Hora.Enabled = False
        txtDireccion.Enabled = False
        txtTelefonos.Enabled = False
        btnAnular.Enabled = False
    End Sub

    'Sub ConvertDouble()
    '    txtInicial.Text = CDbl(txtInicial.Text)
    '    txtAdicional.Text = CDbl(txtAdicional.Text)
    '    txtSubTotal.Text = CDbl(txtSubTotal.Text)
    '    txtITBIS.Text = CDbl(txtITBIS.Text)
    '    TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text)
    '    txtFlete.Text = CDbl(txtFlete.Text)
    '    txtNeto.Text = CDbl(txtNeto.Text)
    '    txtBalance.Text = CDbl(txtBalance.Text)
    '    txtMontoPagos.Text = CDbl(txtMontoPagos.Text)
    'End Sub

    'Sub ConvertCurrent()
    '    txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
    '    txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
    '    txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
    '    txtITBIS.Text = CDbl(txtITBIS.Text).ToString("C")
    '    TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text).ToString("C")
    '    txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
    '    txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
    '    txtBalance.Text = CDbl(txtBalance.Text).ToString("C")
    '    txtMontoPagos.Text = CDbl(txtMontoPagos.Text).ToString("C")
    'End Sub

    Private Sub BuscarSeriales()
        Dim IDArticulo, SerialValue, Control As New Label
        Control.Text = 0

        ConLibregco.Open()

        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            IDArticulo.Text = Row.Cells(6).Value

            cmd = New MySqlCommand("Select Serial from Articulos Where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
            SerialValue.Text = Convert.ToDouble(cmd.ExecuteScalar())

            If SerialValue.Text = 1 Then
                Control.Text = 1
                Exit For
            End If
        Next

        ConLibregco.Close()

        If Control.Text = 1 Then
            frm_introducir_seriales.ShowDialog(Me)
        End If

    End Sub

    Private Sub VerificarInicialenCondicion()
        If CInt(DTConfiguracion.Rows(116 - 1).Item("Value2Int")) = 1 Then
            If Not AccionesModulosAutorizadas.Contains("110") Then
                If CDbl(txtInicial.Text) = 0 Then
                    MessageBox.Show("Las ventas sin inicial está siendo actualmente controladas y se ha detectado que está procesando una factura con esta condición." & vbNewLine & vbNewLine & "Por favor suministre los credenciales requeridos para continuar.", "Venta sin inicial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    frm_superclave.IDAccion.Text = 110
                    frm_superclave.ShowDialog(Me)
                End If
            Else
                ControlSuperClave = 0
            End If
        Else
            ControlSuperClave = 0
        End If

    End Sub

    Private Sub BuscarFactVencidas()
        If DTConfiguracion.Rows(86 - 1).Item("Value2Int") = 0 Then
            If Not AccionesModulosAutorizadas.Contains("49") Then
                If lblDiasCondicion.Text > 0 Then
                    Dim Ds As New DataSet
                    Con.Open()
                    cmd = New MySqlCommand("Select FechaVencimiento from FacturaDatos INNER JOIN libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + txtIDCliente.Text + "' and Balance>0 and FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "' and Condicion.Dias>0 and FacturaDatos.Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "FacturaDatos")
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

                    If Tabla.Rows.Count > 0 Then
                        If frm_reporte_movimientos_clientes.Visible = True Then
                            If frm_reporte_movimientos_clientes.WindowState = FormWindowState.Minimized Then
                                frm_reporte_movimientos_clientes.WindowState = FormWindowState.Normal
                            Else
                                frm_reporte_movimientos_clientes.Activate()
                            End If
                        Else
                            frm_reporte_movimientos_clientes.Show(Me)
                        End If

                        frm_reporte_movimientos_clientes.txtIDCliente.Text = txtIDCliente.Text
                        frm_reporte_movimientos_clientes.txtCliente.Text = txtNombre.Text
                        frm_reporte_movimientos_clientes.FillEstadoCuenta()

                        Dim Result As MsgBoxResult = MessageBox.Show("El cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & " tiene factura(s) vencida(s)." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Existen facturas vencidas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 49
                            frm_superclave.ShowDialog(Me)

                        Else
                            ControlSuperClave = 1
                        End If
                    End If

                    Tabla.Dispose()
                End If

            Else

                ControlSuperClave = 0

            End If
        Else
            ControlSuperClave = 0
        End If
    End Sub

    Private Sub BuscarLimiteCredito()
        Try
            Dim LimiteCredito, SumBceFacts As New Label

            If lblDiasCondicion.Text > 0 Then

                ConLibregco.Open()
                ConMixta.Open()

                cmd = New MySqlCommand("Select LimiteCredito from Libregco.clientes_balances where IDCliente='" + txtIDCliente.Text + "' and IDMoneda= '" + cbxMoneda.EditValue.ToString + "'", ConLibregco)
                LimiteCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select Coalesce(Sum(FacturaDatos.Balance),0) From" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where IDCliente= '" + txtIDCliente.Text + "' and Transaccion.IDMoneda='" + cbxMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0", ConMixta)
                SumBceFacts.Text = Convert.ToDouble(cmd.ExecuteScalar())

                ConLibregco.Close()
                ConMixta.Close()

                If CDbl(SumBceFacts.Text) + CDbl(txtBalance.Text) > CDbl(LimiteCredito.Text) Then
                    If CInt(DTConfiguracion.Rows(196 - 1).Item("Value2Int")) = 0 Then
                        MessageBox.Show("La factura excede el límite de crédito [" & CDbl(LimiteCredito.Text).ToString("C") & "] aprobado al cliente. La factura no se generará.", "Excede crédito otorgado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlSuperClave = 1
                    Else
                        If Not AccionesModulosAutorizadas.Contains("134") Then
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 134
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If

                    End If

                Else
                    ControlSuperClave = 0
                End If
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ArticulosBloqueados()
        Try
            ConLibregco.Open()
            ControlSuperClave = 0

            For Each row As DataGridViewRow In dgvArticulosFactura.Rows
                cmd = New MySqlCommand("Select BloqueoCredito from Articulos where IDArticulo='" + row.Cells(6).Value.ToString + "'", ConLibregco)
                If Convert.ToDouble(cmd.ExecuteScalar()) = 1 Then
                    ConLibregco.Close()
                    MessageBox.Show("El artículo [" & row.Cells(6).Value & "] " & row.Cells(7).Value & " está bloqueado para ventas a crédito.", "Artículo bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                    frm_superclave.IDAccion.Text = 108
                    frm_superclave.ShowDialog(Me)
                    Exit Sub
                Else
                    ControlSuperClave = 0
                End If
            Next

            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub StatusCliente()
        Try
            Dim IDCalificacion, CuentaIncobrable, CreditoCerrado As New Label

            Dim Ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCalificacion,CuentaIncobrable,CerrarCredito from Libregco.Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")
            CuentaIncobrable.Text = Tabla.Rows(0).Item("CuentaIncobrable")
            CreditoCerrado.Text = Tabla.Rows(0).Item("CerrarCredito")
            IDCalificacion.Text = Tabla.Rows(0).Item("IDCalificacion")

            If IDCalificacion.Text > 6 Then
                frm_degraded_client.IDCliente.Text = txtIDCliente.Text
                frm_degraded_client.ShowDialog(Me)

                frm_superclave.IDAccion.Text = 117
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                Else
                    ControlSuperClave = 0
                End If
            End If

            If CreditoCerrado.Text = 1 And lblDiasCondicion.Text > 0 Then
                MessageBox.Show("El cliente tiene el crédito cerrado." & vbNewLine & "Por favor verifique su historial para verificar su status crediticio.", "CREDITO CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
                Exit Sub
            Else
                ControlSuperClave = 0
            End If

            If CuentaIncobrable.Text = 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] " & "posee cuentas incobrables." & vbNewLine & "Es recomendable consultar el status con " & txtCobrador.Text & ", cobrador asignado actualmente." & vbNewLine & vbNewLine & "Está seguro que desea continuar con la factura?", "Posee cuentas incobrables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    ControlSuperClave = 1
                    Exit Sub
                End If
            End If


            Tabla.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CalcInventario()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub CalcExistencia()
        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            FunctCalcInventarioGral(Row.Cells(6).Value.ToString)
        Next
    End Sub

    Private Sub CalcExistenciaAlm()
        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            FunctCalcInvAlmacenes(Row.Cells(6).Value.ToString, Row.Cells(2).Value.ToString)
        Next
    End Sub

    Private Sub ImprimirDocumento()
        Try
            Dim ObjRpt As New ReportDocument
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim DsSP As New DataSet

            If txtIDFactura.Text = "" Then
                MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else

                If Permisos(3) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If Me.Owner.Name = frm_cierre_facturas.Name Then

                    If frm_cierre_facturas.chkImpresionDirecta.Checked = False Then

                        If frm_impresiones_directas.Visible = True Then
                            frm_impresiones_directas.Close()
                        End If

                        frm_impresiones_directas.ShowDialog(Me)
                        Me.Close()

                    Else

                        ChangetoTruePrintSecureEmployee()


                        lblStatusBar.Text = "Realizando impresión directa desde el cierre de prefacturación"

                        If TypeConnection.Text = 1 Then
                            ObjRpt.Load("\\" & PathServidor.Text & frm_cierre_facturas.LUEReportes.GetColumnValue("Path"))
                        Else
                            ObjRpt.Load("C:" & frm_cierre_facturas.LUEReportes.GetColumnValue("Path").Replace("\Libregco\Libregco.net", ""))
                        End If

                        Me.Cursor = Cursors.WaitCursor

                        Dim cmdSP As New MySqlCommand
                        Dim AdaptadorSP As MySqlDataAdapter

                        'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        AdaptadorSP = New MySqlDataAdapter("call" & SysName.Text & "facturadatosview(" + txtIDFactura.Text + ");", Con)
                        AdaptadorSP.Fill(DsSP, "FacturaDatosView")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        'Llenado EmpresaView
                        AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                        AdaptadorSP.Fill(DsSP, "EmpresaView")

                        'Para facturas a credito
                        'Lleando pagaresView
                        AdaptadorSP = New MySqlDataAdapter("SELECT IDPagare,Pagares.IDFactura,NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento as VencimientoPagares,Pagares.DiasVencidos as DiasVencidosPagares,Concepto,Pagares.Monto,Pagares.Balance as BalancePagares,Pagares.Nulo,GROUP_CONCAT(FacturaArticulos.Descripcion,'') AS DescripcionArticulos FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura Where Pagares.IDFactura='" + txtIDFactura.Text + "' GROUP BY Pagares.IDPagare", Con)
                        AdaptadorSP.Fill(DsSP, "ListadoPagaresView")

                        'Lleando balances_clientes_view
                        AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + txtIDCliente.Text + ");", Con)
                        AdaptadorSP.Fill(DsSP, "balances_clientes")

                        'Lleando garantaias
                        'Esta consulta busca terminos para todos los articulos introducidos
                        AdaptadorSP = New MySqlDataAdapter("Select * from (SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.idarticulo=articulos_garantia.idarticulo Where FacturaArticulos.IDFactura='" + txtIDFactura.Text + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDSubcategoria=articulos_garantia.IDSubCategoria Where FacturaArticulos.IDFactura='" + txtIDFactura.Text + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDCategoria=articulos_garantia.IDCategoria Where FacturaArticulos.IDFactura='" + txtIDFactura.Text + "') AS Resultados  Group by Resultados.idArticulos_garantia ORDER BY Resultados.Orden", ConMixta)
                        AdaptadorSP.Fill(DsSP, "GarantiaArticulosView")

                        For Each crReportObject In ObjRpt.Subreports
                            If CType(crReportObject, ReportDocument).Name = "subreport_preguntas" Then
                                'Lleando garantaias
                                AdaptadorSP = New MySqlDataAdapter("SELECT idFactura_Preguntas,factura_preguntas.IDArticulo_Pregunta,factura_preguntas.IDFactura,factura_preguntas.IDArticulo,Titulo,Descripcion,Respuesta FROM" & SysName.Text & "factura_preguntas inner join Libregco.articulos_preguntas on factura_preguntas.IDArticulo_Pregunta=articulos_preguntas.idArticulos_preguntas Where IDFactura='" + txtIDFactura.Text + "'", ConMixta)
                                AdaptadorSP.Fill(DsSP, "FacturaPreguntas_DATA")

                                ObjRpt.Subreports("subreport_preguntas").SetDataSource(DsSP.Tables("FacturaPreguntas_DATA"))
                            End If
                        Next


                        cmdSP.Dispose()
                        AdaptadorSP.Dispose()

                        ObjRpt.Database.Tables("facturadatosview1").SetDataSource(DsSP.Tables("FacturaDatosView"))
                        ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
                        ObjRpt.Subreports("subinforme_pagares_en_factura.rpt").SetDataSource(DsSP.Tables("ListadoPagaresView"))
                        ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))
                        ObjRpt.Subreports("subreport_garantias.rpt").SetDataSource(DsSP.Tables("GarantiaArticulosView"))

                        'Si la impresión es en media página
                        If frm_cierre_facturas.LUEReportes.GetColumnValue("Descripcion").ToUpper.Contains("MEDIA") Then
                            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
                            doctoprint.PrinterSettings.PrinterName = frm_cierre_facturas.CbxInstalledPrinters.Text
                            For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                                Dim rawKind As Integer
                                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "MediaPagina" Then
                                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                                    ObjRpt.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                                    ObjRpt.PrintOptions.PaperSize = rawKind
                                    Exit For
                                End If
                            Next
                        End If

                        Dim PrinterSettings1 As New Printing.PrinterSettings
                        Dim PageSettings1 As New Printing.PageSettings
                        PrinterSettings1.PrinterName = frm_cierre_facturas.CbxInstalledPrinters.Text
                        ObjRpt.SummaryInfo.ReportTitle = frm_cierre_facturas.LUEReportes.GetColumnValue("Descripcion") & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                        ObjRpt.PrintOptions.PrinterName = frm_cierre_facturas.CbxInstalledPrinters.Text


                        If frm_cierre_facturas.LUEReportes.GetColumnValue("ModoDuplicado") = 1 Then
                            If CInt(DTConfiguracion.Rows(160 - 1).Item("Value2Int")) = 1 Then

                                If CInt(DTConfiguracion.Rows(172 - 1).Item("Value2Int")) = 0 Then
                                    If EstadoImpresion = 0 Then
                                        'Imprimiendo original cuando nunca se ha impreso
                                        ObjRpt.SetParameterValue("Duplicidad", "ORIGINAL")
                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If

                                Else
                                    'IMprimiendo original cuando ya se ha impreso pero el sistema permite reimprimirlo
                                    ObjRpt.SetParameterValue("Duplicidad", "ORIGINAL")
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                                'Imprimiendo copia  del cliente
                                If Convert.ToBoolean(CInt(DTConfiguracion.Rows(161 - 1).Item("Value2Int"))) = True Then
                                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(92 - 1).Item("Value1Var").ToString)
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                                'Imprimiendo copia  del despacho
                                If Convert.ToBoolean(CInt(DTConfiguracion.Rows(162 - 1).Item("Value2Int"))) = True Then
                                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(93 - 1).Item("Value1Var").ToString)
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                                'Imprimiendo copia  del contabilidad
                                If Convert.ToBoolean(CInt(DTConfiguracion.Rows(163 - 1).Item("Value2Int"))) = True Then
                                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(94 - 1).Item("Value1Var").ToString)
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                            Else

                                'Imprimiendo sólo el original cuando el modo de duplicido no esta activado
                                ObjRpt.SetParameterValue("Duplicidad", "ORIGINAL")
                                ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                            End If

                        Else

                            'Impresion de reportes que no utilizan el metodo de duplicado
                            ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

                        End If

                        'Control de despacho desde facturacion
                        If CInt(DTConfiguracion.Rows(202 - 1).Item("Value2Int")) = 1 Then
                            Con.Open()

                            If frm_cierre_facturas.LUEReportes.GetColumnValue("idPaperSize") = 1 Then
                                'Habilitar control en reportes de página completa
                                If CInt(DTConfiguracion.Rows(203 - 1).Item("Value2Int")) = 1 Then
                                    cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=206)", Con)
                                    ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                    crParameterValues.Clear()
                                    crParameterDiscreteValue.Value = txtIDFactura.Text
                                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                    crParameterValues.Add(crParameterDiscreteValue)
                                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If


                            ElseIf frm_cierre_facturas.LUEReportes.GetColumnValue("idPaperSize") = 2 Then
                                'Habilitar control en reportes de media
                                If CInt(DTConfiguracion.Rows(204 - 1).Item("Value2Int")) = 1 Then
                                    cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=207)", Con)
                                    ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                    crParameterValues.Clear()
                                    crParameterDiscreteValue.Value = txtIDFactura.Text
                                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                    crParameterValues.Add(crParameterDiscreteValue)
                                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If


                            ElseIf frm_cierre_facturas.LUEReportes.GetColumnValue("idPaperSize") = 3 Then
                                'Habilitar control en reportes de punto
                                If CInt(DTConfiguracion.Rows(205 - 1).Item("Value2Int")) = 1 Then
                                    cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=208)", Con)
                                    ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                    crParameterValues.Clear()
                                    crParameterDiscreteValue.Value = txtIDFactura.Text
                                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                    crParameterValues.Add(crParameterDiscreteValue)
                                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                            End If

                            Con.Close()
                        End If

                        ChangetoFalsePrintSecureEmployee()

                        Me.Cursor = Cursors.Default

                        If DgvPagares.Rows.Count = 0 Then
                            Me.Close()
                            frm_cierre_facturas.Activate()
                            frm_cierre_facturas.GridView1.Focus()
                        End If

                        ObjRpt.Close()
                        ObjRpt.Dispose()

                    End If


                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        CalcularBalances()

                        If frm_impresiones_directas.Visible = True Then
                            frm_impresiones_directas.Close()
                        End If

                        frm_impresiones_directas.ShowDialog(Me)
                    Else
                        If Me.Owner.Name = frm_cierre_facturas.Name Then
                            frm_cierre_facturas.Activate()
                            Me.Close()
                        End If
                    End If

                End If

            End If

            If txtIDFactura.Text <> "" Then
                If DgvPagares.Rows.Count > 0 And lblDiasCondicion.Text <> "0" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir los pagarés de la factura?", "Impresión de pagarés", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        If frm_pagares.Visible = True Then
                            If frm_pagares.WindowState = FormWindowState.Minimized Then
                                frm_pagares.WindowState = FormWindowState.Normal
                            Else
                                frm_pagares.Activate()
                            End If
                            frm_pagares.lblIDFactura.Text = txtIDFactura.Text
                            frm_pagares.txtFactura.Text = txtSecondID.Text
                            frm_pagares.rdbPresentacion.Checked = True
                            frm_pagares.btnBuscar.PerformClick()
                        Else
                            If frm_pagares.Visible = False Then
                                frm_pagares.Show(Me)
                            End If
                            frm_pagares.lblIDFactura.Text = txtIDFactura.Text
                            frm_pagares.txtFactura.Text = txtSecondID.Text
                            frm_pagares.rdbPresentacion.Checked = True
                            frm_pagares.btnBuscar.PerformClick()

                        End If
                    Else
                        If Me.Owner.Name = frm_cierre_facturas.Name Then
                            frm_cierre_facturas.Activate()
                            Me.Close()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltFactura()
        Try

            If txtIDFactura.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos=(Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                txtIDFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from FacturaDatos where IDFacturaDatos=(Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If LastIDFact = txtIDFactura.Text Then
                    If Con.State = ConnectionState.Open Then
                        Con.Close()
                    End If
                    If ConMixta.State = ConnectionState.Open Then
                        ConMixta.Close()
                    End If
                    If ConLibregco.State = ConnectionState.Open Then
                        ConLibregco.Close()
                    End If

                    lblStatusBar.ForeColor = Color.Red
                    lblStatusBar.Text = "Reintentando guardar la factura..."

                    Con.Open()

                    Dim CheckADC As New Label

                    lblStatusBar.Text = "Verificando formatos de las condiciones de ventas."
                    If IsDate(txtFechaAdicional.Text) Then
                        CheckADC.Text = CDate(txtFechaAdicional.Text).ToString("yyyy-MM-dd")
                    Else
                        CheckADC.Text = ""
                    End If

                    cmd = New MySqlCommand("INSERT INTO Facturadatos (SecondID,IDTipoDocumento,IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTransaccion,NCF,NCFModificado,NIF,IDCondicion,DiasCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,FechaRetencion,ItbisRetenido,ItbisPercibido,RetencionRenta,ISRPercibido,ISC,OtrosImpuestos,PropinaLegal,Flete,TotalNeto,NetoLetra,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Observacion,EntregarPorConduce,Cierre,Impreso,IDTipoIngreso,Nulo) VALUES ('" + GetSecondID(lblIDTipoDocumento.Text).ToString + "','" + lblIDTipoDocumento.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text.ToUpper + "','" + txtTelefonos.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','','" + txtNIF.Text + "','" + cbxCondicion.Tag.ToString + "','" + txtDiasCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + CbxTipoComprobante.Tag.ToString + "','" + CbxChofer.Tag.ToString + "','" + cbxVehiculo.Tag.ToString + "','" + txtVendedor.Tag.ToString + "','" + lblIDUsuario.Text + "',DATE(NOW()),TIME(NOW()),'" + CDbl(txtInicial.Text).ToString + "','" + txtCantidadPagos.Text + "','" + CDbl(txtMontoPagos.Text).ToString + "','" + CDbl(txtAdicional.Text).ToString + "','" + CheckADC.Text + "','" + CDbl(txtBalance.Text).ToString + "','" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(chkHabilitarNota.CheckState).ToString + "','" + txtCondicionContado.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(TxtDescuentoSuma.Text).ToString + "','" + CDbl(txtITBIS.Text).ToString + "','',0,0,0,0,0,0,0,'" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',0,'" + CDbl(txtBalance.Text).ToString + "','" + Convert.ToInt16(chkFichaDatos.CheckState).ToString + "',0,'ACTIVA','" + txtObservacion.Text + "','" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',0,0,1,'" + Convert.ToInt16(chkDesactivar.Checked).ToString + "')", Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                    txtIDFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select SecondID from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                    txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

                    Con.Close()

                    If txtIDFactura.Text = LastIDFact Then
                        MessageBox.Show("No se ha podido guardar la factura. Verifique la comunicación con el servidor para poder guardar la factura.")
                        Application.Exit()
                    End If
                End If


                If IDPrefactura.Count > 0 Then
                    Con.Open()

                    For Each itm As String In IDPrefactura
                        cmd = New MySqlCommand("SELECT coalesce(IDCotizacion,'') as IDCotizacion FROM prefactura where IDPrefactura='" + itm + "'", Con)
                        Dim IDCotizacion As String = Convert.ToString(cmd.ExecuteScalar())

                        If IsNumeric(IDCotizacion) Then
                            'Si vino de una cotizacion actualizo el estado de la cotización
                            sqlQ = "UPDATE" & SysName.Text & "Cotizacion SET EstadoCotizacion=2 WHERE IDCotizacion=(" + IDCotizacion + ")"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    Con.Close()
                End If


            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub CambiarBalance()
        If lblDiasCondicion.Text = 0 Then
            txtCantidadPagos.Text = CDbl(0)
            txtMontoPagos.Text = CDbl(0)
            txtBalance.Text = CDbl(0)
        End If
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Value = DateTime.Today
        txtHora.Value = DateTime.Now
    End Sub

    Private Function GetCostoImporte(ByVal IDPrecio As String, ByVal Cantidad As Double) As String
        cmd = New MySqlCommand("SELECT Costo FROM libregco.precioarticulo where IDPrecios='" + IDPrecio.ToString + "'", Con)
        Return CDbl(CDbl(Convert.ToDouble(cmd.ExecuteScalar())) * CDbl(Cantidad))
    End Function

    Private Sub InsertArticulos()
        Con.Open()

        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            If CStr(Row.Cells(0).Value.ToString) = "" Then
                sqlQ = "INSERT INTO FacturaArticulos (IDFactura,IDPrecio,IDArticulo,IDMedida,Medida,Cantidad,Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo,Orden,CostoImporte) VALUES ('" + txtIDFactura.Text + "', '" + Row.Cells(2).Value.ToString + "','" + Row.Cells(6).Value.ToString + "','" + Row.Cells(3).Value.ToString + "','" + Row.Cells(5).Value.ToString + "','" + Row.Cells(4).Value.ToString + "','" + Row.Cells(7).Value.ToString + "','" + CDbl(Row.Cells(8).Value).ToString + "','" + CDbl(Row.Cells(9).Value).ToString + "','" + CDbl(Row.Cells(10).Value).ToString + "','" + CDbl(Row.Cells(11).Value).ToString + "','" + Row.Cells(12).Value.ToString + "','" + Row.Cells(13).Value.ToString + "','" + Row.Index.ToString + "','" + GetCostoImporte(Row.Cells(2).Value.ToString, CDbl(Row.Cells(4).Value.ToString)) + "')"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDFactArt from FacturaArticulos where IDFactArt=(Select Max(IDFactArt) from FacturaArticulos)", Con)
                Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                Row.Cells(1).Value = txtIDFactura.Text


            Else
                sqlQ = "UPDATE FacturaArticulos SET IDFactura='" + txtIDFactura.Text + "',IDPrecio='" + Row.Cells(2).Value.ToString + "',IDArticulo='" + Row.Cells(6).Value.ToString + "',IDMedida='" + Row.Cells(3).Value.ToString + "',Medida='" + Row.Cells(5).Value.ToString + "',Cantidad='" + Row.Cells(4).Value.ToString + "',Descripcion='" + Row.Cells(7).Value.ToString + "',PrecioUnitario='" + CDbl(Row.Cells(8).Value).ToString + "',Descuento='" + CDbl(Row.Cells(9).Value).ToString + "',Itbis='" + CDbl(Row.Cells(10).Value).ToString + "',Importe='" + CDbl(Row.Cells(11).Value).ToString + "',IDAlmacen='" + Row.Cells(12).Value.ToString + "',NivelPrecioArticulo='" + Row.Cells(13).Value.ToString + "',Orden='" + Row.Index.ToString + "' Where IDFactArt='" + Row.Cells(0).Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If
        Next

        Con.Close()
        'RefrescarTablaConsulta()
    End Sub

    Sub RefrescarTablaConsulta()
        Try
            Dim ImgFile As Image

            dgvArticulosFactura.Rows.Clear()
            ConMixta.Open()
            Dim Consulta As New MySqlCommand("Select IDFactArt,IDFactura,IDPrecio,FacturaArticulos.IDMedida,Cantidad,FacturaArticulos.Medida,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo,0,Medida.Fraccionamiento,RutaFoto from" & SysName.Text & "Facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE IDFactura='" + txtIDFactura.Text + "' Order by Orden ASC", ConMixta)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read

                If TypeConnection.Text = 1 Then
                    If (LectorArticulos.GetValue(16)) = "" Then
                        ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(LectorArticulos.GetValue(16))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(LectorArticulos.GetValue(16), FileMode.Open, FileAccess.Read)
                            ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                            wFile.Close()
                        Else
                            ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                        End If
                    End If
                Else
                    ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                End If

                dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14), LectorArticulos.GetValue(15), ImgFile)

            End While

            LectorArticulos.Close()
            ConMixta.Close()

            PropiedadesDgvArticulos()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub RefrescarTablaPagares()
        Try
            DgvPagares.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,Concepto,Monto,Balance,IDTipoPagare from Pagares where IDFactura='" + txtIDFactura.Text + "'", Con)
            Dim LectorPagares As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagares.Read
                DgvPagares.Rows.Add(LectorPagares.GetValue(0), LectorPagares.GetValue(1), LectorPagares.GetValue(2), LectorPagares.GetValue(3), LectorPagares.GetValue(4), LectorPagares.GetValue(5), LectorPagares.GetValue(6), LectorPagares.GetValue(7), LectorPagares.GetValue(8))
            End While
            LectorPagares.Close()
            Con.Close()
            PropiedadesDgvPagares()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LiberarDgvArticulos()
        Try
            If dgvArticulosFactura.Columns.Count = 0 Then
                dgvArticulosFactura.DataSource = Nothing
                dgvArticulosFactura.Rows.Clear()
                ColumnasDgvArticulos()
                PropiedadesDgvArticulos()
            Else
                dgvArticulosFactura.DataSource = Nothing
                dgvArticulosFactura.Rows.Clear()
                dgvArticulosFactura.Columns.Clear()
                ColumnasDgvArticulos()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LiberarDgvPagares()
        Try
            Dim Counter As Integer
            Counter = DgvPagares.Columns.Count

            If Counter = 0 Then
                DgvPagares.DataSource = Nothing
                DgvPagares.Rows.Clear()
                ColumnasDgvPagares()
            Else
                DgvPagares.DataSource = Nothing
                DgvPagares.Rows.Clear()
                DgvPagares.Columns.Clear()
                ColumnasDgvPagares()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ColumnasDgvPagares()
        DgvPagares.Columns.Clear()
        With DgvPagares
            .Columns.Add("IDPagare", "IDPagare") '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("NoPagare", "No Pagaré.") '2
            .Columns.Add("Cantidad", "Cant.") '3
            .Columns.Add("FechaVencimiento", "Vencimiento") '4
            .Columns.Add("Concepto", "Concepto") '5
            .Columns.Add("Monto", "Monto") '6
            .Columns.Add("Balance", "Balance") '7
            .Columns.Add("TipoPagare", "TipoPagare") '8
        End With
        PropiedadesDgvPagares()

    End Sub

    Private Sub PropiedadesDgvPagares()
        Try
            Dim Condicion As String = False
            Dim DatagridWidth As Double = (DgvPagares.Width - DgvPagares.RowHeadersWidth) / 100
            With DgvPagares
                .Columns("IDPagare").Visible = Condicion
                .Columns("IDFactura").Visible = Condicion
                .Columns("FechaVencimiento").Width = DatagridWidth * 12
                .Columns("NoPagare").Width = DatagridWidth * 10
                .Columns("Cantidad").Visible = Condicion
                .Columns("Concepto").Width = DatagridWidth * 58
                .Columns("Monto").Width = DatagridWidth * 16
                .Columns("Monto").DefaultCellStyle.Format = ("C")
                .Columns("Balance").DefaultCellStyle.Format = ("C")
                .Columns("Balance").Visible = Condicion
                .Columns("TipoPagare").Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub

    Friend Sub CreatePagares()
        Try
            Dim DiadelPagare As Date = CDate(txtFecha.Value)
            Dim CantidadPagos As Integer = CInt(txtCantidadPagos.Text)

            If txtCantidadPagos.Text = "" Then
                txtCantidadPagos.Text = 1
            End If

            If CInt(lblDiasCondicion.Text) > 0 Then
                If CantidadPagos > 0 Then
                    If CDbl(txtBalance.Text) > 0 Then
                        If CDbl(txtAdicional.Text) > 0 Then
                            CantidadPagos = CantidadPagos - 1
                        End If

                        If IsModifiable(txtIDFactura.Text) Then
                            If CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int")) = 1 Then
                                If lblDiasCondicion.Text > 0 Then
                                    DgvPagares.Rows.Clear()

                                    For i As Integer = 1 To CantidadPagos
                                        DiadelPagare = DiadelPagare.AddDays(txtDiasCondicion.Text)

                                        If CInt(DTConfiguracion.Rows(50 - 1).Item("Value2Int")) = 1 Then
                                            If DiadelPagare.DayOfWeek = DayOfWeek.Saturday Then
                                                DiadelPagare = DiadelPagare.AddDays(1)
                                            End If
                                        End If
                                        If CInt(DTConfiguracion.Rows(51 - 1).Item("Value2Int")) = 1 Then
                                            If DiadelPagare.DayOfWeek = DayOfWeek.Sunday Then
                                                DiadelPagare = DiadelPagare.AddDays(1)
                                            End If
                                        End If

                                        DgvPagares.Rows.Add("", "", "", txtCantidadPagos.Text, DiadelPagare.ToString("yyyy-MM-dd"), "BUENO Y VÁLIDO POR " & ConvertNumbertoString(CDbl(txtMontoPagos.Text), NombreMoneda), txtMontoPagos.Text, txtMontoPagos.Text, 1)
                                    Next

                                    If txtFechaAdicional.Text <> "" Then
                                        If IsDate(txtFechaAdicional.Text) Then
                                            If CDbl(txtAdicional.Text) > 0 Then
                                                DgvPagares.Rows.Add("", "", "", txtCantidadPagos.Text, CDate(txtFechaAdicional.Text).ToString("yyyy-MM-dd"), "BUENO Y VÁLIDO POR " & ConvertNumbertoString(CDbl(txtAdicional.Text), NombreMoneda), txtAdicional.Text, txtAdicional.Text, 1)
                                            End If
                                        End If
                                    End If


                                    DgvPagares.Sort(DgvPagares.Columns(4), System.ComponentModel.ListSortDirection.Ascending)

                                    For Each row As DataGridViewRow In DgvPagares.Rows
                                        row.Cells(2).Value = CInt(row.Index) + 1
                                    Next

                                End If
                            End If

                            CalcVencientoFactura()
                        End If

                    End If
                End If

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub InsertPagares()
        If CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int")) = 1 Then
            If CInt(lblDiasCondicion.Text) > 0 Then
                If IsModifiable(txtIDFactura.Text) Then
                    Con.Open()

                    sqlQ = "Delete from" & SysName.Text & "Pagares Where IDFactura=(" + txtIDFactura.Text + ")"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    For Each rw As DataGridViewRow In DgvPagares.Rows
                        If CStr(rw.Cells(0).Value) = "" Then
                            sqlQ = "INSERT INTO" & SysName.Text & "Pagares (IDTipoPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,DiasVencidos,Concepto,Monto,Balance,BalanceCerrado,IDEmpleado,IDStatusPagare,Nota,Cargado,Nulo) VALUES ('" + rw.Cells(8).Value.ToString + "','" + txtIDFactura.Text + "','" + rw.Cells(2).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(4).Value.ToString + "','0','" + rw.Cells(5).Value.ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + DTConfiguracion.Rows(25 - 1).Item("Value2Int").ToString + "',1,'',0,0)"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()

                            cmd = New MySqlCommand("Select IDPagare from pagares where IDPagare=(Select Max(IDPagare) from pagares)", Con)
                            rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                        End If
                    Next

                    Con.Close()
                End If
            End If
        End If

    End Sub

    Private Sub CalcularBalances()
        If CDbl(txtIDCliente.Text) <> 1 Then
            FunctCalcBcesFact(txtIDCliente.Text)
            FunctCalcBceGral(txtIDCliente.Text)
        End If
    End Sub

    Private Sub txtInicial_Enter(sender As Object, e As EventArgs) Handles txtInicial.Enter
        If txtInicial.Text = "" Then
        Else
            txtInicial.Text = CDbl(txtInicial.Text)
        End If
    End Sub

    Private Sub txtAdicional_Enter(sender As Object, e As EventArgs) Handles txtAdicional.Enter
        If txtAdicional.Text = "" Then
        Else
            txtAdicional.Text = CDbl(txtAdicional.Text)
        End If
    End Sub

    Private Sub txtFlete_Enter(sender As Object, e As EventArgs) Handles txtFlete.Enter
        If txtFlete.Text = "" Then
        Else
            txtFlete.Text = CDbl(txtFlete.Text)
        End If
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDFactura.Text = "" Then
            If txtNombre.Text <> "" Or txtDireccion.Text <> "" Or txtTelefonos.Text <> "" Or dgvArticulosFactura.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de facturación?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                    If Me.Owner.Name = frm_cierre_facturas.Name Then
                        Me.Close()
                    End If
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
                If Me.Owner.Name = frm_cierre_facturas.Name Then
                    Me.Close()
                End If
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
            If Me.Owner.Name = frm_cierre_facturas.Name Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        If txtPrecio.Text = "" Then
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text)
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        Try
            Dim DsPrecios As New DataSet
            Dim CostoFinal, VenderCosto, PrecioMinimoA, PrecioMinimoB As New Label

            If txtCodigoArticulo.Text <> "" And CbxMedida.Tag.ToString <> "" Then
                PrecioMinimoA.Text = GetMinimoPrecio("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString)
                PrecioMinimoB.Text = GetMinimoPrecio("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString)

                If IsNumeric(txtPrecio.Text) Then
                    If CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 1 Then         'Si puedo facturar por debajo del costo 
                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                        If cbxPrecio.Text = "A" Then
                            If CDbl(txtPrecio.Text) > CDbl(GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString)).ToString("C") Then
                                lblDescuento.Text = CDbl(0).ToString("C")
                            Else
                                lblDescuento.Text = (CDbl(GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString)) - CDbl(txtPrecio.Text)).ToString("C")
                            End If
                        ElseIf cbxPrecio.Text = "B" Then
                            If CDbl(txtPrecio.Text) > CDbl(GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString)).ToString("C") Then
                                lblDescuento.Text = CDbl(0).ToString("C")
                            Else
                                lblDescuento.Text = (GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                            End If
                        End If
                    Else
                        'Verifico si el articulo se puede vender al costo
                        ConLibregco.Open()
                        cmd = New MySqlCommand("SELECT VenderCosto FROM Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", ConLibregco)
                        VenderCosto.Text = Convert.ToDouble(cmd.ExecuteScalar())
                        ConLibregco.Close()

                        If VenderCosto.Text = 1 Then    'Si se puede vender al costo
                            If CDbl(txtPrecio.Text) >= GetPrices("E", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                            Else
                                MessageBox.Show("El precio establecido excede el costo del producto." & vbNewLine & vbNewLine & "El artículo está autorizado y disponible para venderse al costo, por un monto de: " & GetPrices("F", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C") & ".", "Exceso del precio introducido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                txtPrecio.Text = GetPrices("E", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                If cbxPrecio.Text = "A" Then
                                    If CDbl(txtPrecio.Text) > GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                        lblDescuento.Text = 0
                                    Else
                                        lblDescuento.Text = (GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                                    End If

                                ElseIf cbxPrecio.Text = "B" Then
                                    If CDbl(txtPrecio.Text) > GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                        lblDescuento.Text = 0
                                    Else
                                        lblDescuento.Text = (GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                                    End If
                                End If
                            End If

                        Else
                            If CInt(DTConfiguracion.Rows(195 - 1).Item("Value2Int")) = 1 Then
                                'Si el precio se puede vender al costo no hago nada, aún cuando no se puede facturar al costo.
                                If cbxPrecio.Text = "A" Then
                                    If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoA.Text) Then
                                        MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        txtPrecio.Text = GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        txtPrecio.Focus()
                                    Else
                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        If txtPrecio.Text < GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            lblDescuento.Text = (GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                                        Else
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        End If

                                    End If
                                ElseIf cbxPrecio.Text = "B" Then
                                    If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoB.Text) Then
                                        MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        txtPrecio.Text = GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        txtPrecio.Focus()
                                    Else
                                        txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        If txtPrecio.Text < GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            lblDescuento.Text = (GetPrices("B", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) - CDbl(txtPrecio.Text)).ToString("C")
                                        Else
                                            lblDescuento.Text = CDbl(0).ToString("C")
                                        End If
                                    End If
                                Else
                                    If cbxPrecio.Text = "C" Then
                                        If CDbl(txtPrecio.Text) < GetPrices("C", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = GetPrices("C", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        Else
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        End If
                                        lblDescuento.Text = CDbl(0).ToString("C")
                                    ElseIf cbxPrecio.Text = "D" Then
                                        If CDbl(txtPrecio.Text) < GetPrices("D", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = GetPrices("D", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        Else
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        End If
                                        lblDescuento.Text = CDbl(0).ToString("C")
                                    ElseIf cbxPrecio.Text = "E" Then
                                        If CDbl(txtPrecio.Text) < GetPrices("E", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = GetPrices("E", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        Else
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        End If
                                        lblDescuento.Text = CDbl(0).ToString("C")
                                    ElseIf cbxPrecio.Text = "F" Then
                                        If CDbl(txtPrecio.Text) < GetPrices("F", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = GetPrices("F", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        Else
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        End If
                                        lblDescuento.Text = CDbl(0).ToString("C")

                                    ElseIf cbxPrecio.Text = "BlackFriday" Then
                                        If CDbl(txtPrecio.Text) < GetPrices("BlackFriday", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                            MessageBox.Show("No es posible establecer precios por debajo de este nivel.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            txtPrecio.Text = GetPrices("BlackFriday", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                        Else
                                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                        End If
                                        lblDescuento.Text = CDbl(0).ToString("C")
                                    End If
                                End If

                            Else

                                If CDbl(txtPrecio.Text) < GetPrices("E", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString) Then
                                    MessageBox.Show("No es posible hacer establecer el precio ya que excede el costo del producto.", "Ha excedido el costo del producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    txtPrecio.Text = GetPrices("A", txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue.ToString).ToString("C")
                                Else
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                End If
                            End If

                        End If
                    End If
                End If
            End If

            lblDescuento.Text = CDbl(lblDescuento.Text).ToString("C")
            SumarTotalArticulo()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarArtículosToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarArtículoToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarArtículoToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPrecio.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDFactura.Text = "" And dgvArticulosFactura.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    dgvArticulosFactura.Rows.Clear()
                    SumTotales()
                    txtCodigoArticulo.Focus()
                    Exit Sub
                End If
            End If

            If txtIDFactura.Text = "" Then
            Else
                If dgvArticulosFactura.Rows.Count > 0 Then
                    MessageBox.Show("No se pueden eliminar todos los artículos ya procesados en una factura.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            If txtIDFactura.Text = "" Then
                If dgvArticulosFactura.Rows.Count > 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & dgvArticulosFactura.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        RemoveHijos()
                        dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                        SumTotales()
                    End If
                End If
            End If

            If txtIDFactura.Text <> "" Then
                If dgvArticulosFactura.Rows.Count = 1 Then
                    MessageBox.Show("No es posible eliminar el artículo ya que es único en la factura. Para realizar esta operación primero agregue el artículo que desea a la factura y posteriormente proceda a eliminar el artículo correspondiente.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo?", "Eliminar artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    If IsModifiable(txtIDFactura.Text) Then
                        Dim IDFacturaArticulos, HaveSerials As New Label
                        Dim IDArticulo As String

                        IDFacturaArticulos.Text = dgvArticulosFactura.CurrentRow.Cells(0).Value

                        Con.Open()
                        cmd = New MySqlCommand("SELECT count(IDSerial) FROM libregco.serialarticulo where IDFactArt='" + IDFacturaArticulos.Text + "'", Con)
                        HaveSerials.Text = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()

                        If CDbl(HaveSerials.Text) = 0 Then
                            Con.Open()
                            sqlQ = "Delete from FacturaArticulos Where IDFactArt= '" + IDFacturaArticulos.Text + "'"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                            Con.Close()

                            'Recalculando inventario de articulo removido
                            FunctCalcInventarioGral(dgvArticulosFactura.CurrentRow.Cells(6).Value.ToString)
                            FunctCalcInvAlmacenes(dgvArticulosFactura.CurrentRow.Cells(6).Value.ToString, dgvArticulosFactura.CurrentRow.Cells(2).Value.ToString)

                            RemoveHijos()
                            dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                            SumTotales()
                            CambiarBalance()

                            Con.Open()
                            sqlQ = "UPDATE FacturaDatos SET IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text.ToUpper + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',IDChofer='" + CbxChofer.Tag.ToString + "',IDVehiculo='" + cbxVehiculo.Tag.ToString + "',IDVendedor='" + txtVendedor.Tag.ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',PagoAdicional='" + CDbl(txtAdicional.Text).ToString + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + CDbl(txtBalance.Text).ToString + "',FechaVencimiento='" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "',NotaContado='" + Convert.ToInt16(chkHabilitarNota.CheckState).ToString + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuentoSuma.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',EntregarPorConduce='" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',HabilitarFicha='" + Convert.ToInt16(chkFichaDatos.Checked).ToString + "',Observacion='" + txtObservacion.Text + "',Nulo='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                            Con.Close()

                            Con.Open()
                            If lblDiasCondicion.Text = 0 Then
                                sqlQ = "UPDATE Transaccion SET Efectivo='" + CDbl(txtNeto.Text).ToString + "',DevueltaEfectivo=0,Cheque='0',Deposito='0',Informacion='',Credito='0',IDCredito='',ClaseTarjeta='',Tarjeta='0',TipoTarjeta='',NoTarjeta='',TipoTarjeta='',Mes='',Año='',Banco='',NoAprobacion='',Recibido='" + CDbl(txtNeto.Text).ToString + "',MontoCobrar='" + CDbl(txtNeto.Text).ToString + "',Devuelta='0' WHERE IDTransaccion= (" + lblIDTransaccion.Text + ")"
                                cmd = New MySqlCommand(sqlQ, Con)
                                cmd.ExecuteNonQuery()
                            Else
                                sqlQ = "UPDATE Transaccion SET Efectivo='" + CDbl(txtInicial.Text).ToString + "',DevueltaEfectivo=0,Cheque='0',Deposito='0',Informacion='',Credito='0',IDCredito='',ClaseTarjeta='',Tarjeta='0',TipoTarjeta='',NoTarjeta='',TipoTarjeta='',Mes='',Año='',Banco='',NoAprobacion='',Recibido='" + CDbl(txtInicial.Text).ToString + "',MontoCobrar='" + CDbl(txtInicial.Text).ToString + "',Devuelta='0' WHERE IDTransaccion= (" + lblIDTransaccion.Text + ")"
                                cmd = New MySqlCommand(sqlQ, Con)
                                cmd.ExecuteNonQuery()
                            End If

                            Con.Close()


                            InsertArticulos()
                            InsertPagares()
                            CalcInventario()
                            CalcularBalances()

                            MessageBox.Show("El artículo ha sido eliminado satisfactoriamente.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("No es posible eliminar el artículo ya que hay registro(s) de seriales en la base de datos.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    Else
                        MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If


            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try

            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If dgvArticulosFactura.Rows.Count > 0 Then
                lblIDFactArt.Text = dgvArticulosFactura.CurrentRow.Cells(0).Value
                txtCodigoArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
                IDArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
                FillMedida()
                txtDescripcionArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(7).Value
                CbxMedida.Text = dgvArticulosFactura.CurrentRow.Cells(5).Value
                CbxMedida.Tag = dgvArticulosFactura.CurrentRow.Cells(3).Value
                cbxPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(13).Value
                txtCantidadArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(4).Value
                BuscarItebis()
                cbxPrecio.Tag = dgvArticulosFactura.CurrentRow.Cells(2).Value
                cbxPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(13).Value
                txtPrecio.Text = (CDbl(dgvArticulosFactura.CurrentRow.Cells(8).Value) * (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C")
                txtTotalArt.Text = CDbl(dgvArticulosFactura.CurrentRow.Cells(11).Value).ToString("C")
                lblDescuento.Text = CDbl(dgvArticulosFactura.CurrentRow.Cells(9).Value).ToString("C")
                lblIDAlmacenArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(12).Value
                ProductImage = dgvArticulosFactura.CurrentRow.Cells(16).Value

                Con.Open()
                cmd = New MySqlCommand("Select ExistenciaTotal from Libregco.Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", Con)
                lblExistencia.Text = Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select IDTipoProducto from Libregco.Articulos Where IDArticulo='" + txtCodigoArticulo.Text + "'", Con)
                lblIDTipoProducto.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                RemoveHijos()
                dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                SumTotales()
                btnModificar.Enabled = False
                'btnGuardar.Enabled = False
                'btnGuardarC.Enabled = False
                Exit Sub
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RemoveHijos()
        Dim dsTemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo, ArticulosHijo.Descripcion, ArticulosHijo.Referencia, CantidadEnOferta, IDPrecioHijo, MedidaHijo.Medida, LimitarHastaFecha, HastaFecha, ValorIncluidoPrecio, Nivel, Precio, Articulos_hijos.Nulo FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo ='" + dgvArticulosFactura.CurrentRow.Cells(6).Value.ToString + "' and articulos_hijos.Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dsTemp, "Articulos")
        Con.Close()

        Dim Tabla As DataTable = dsTemp.Tables("Articulos")


        For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
            If rw.Cells(14).Value = 1 Then


                For Each dt As DataRow In Tabla.Rows

                    If dt.Item("IDPrecioHijo") = rw.Cells(2).Value Then
                        dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.Rows(rw.Index))
                    End If
                Next
            End If
        Next

        Tabla.Dispose()
    End Sub

    Private Sub BuscarHistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultacotizacionToolStripMenuItem.Click
        If frm_consulta_cotizacion.Visible = True Then
            frm_consulta_cotizacion.Close()
        End If

        frm_consulta_cotizacion.ShowDialog(Me)
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub HistorialDelClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDelClienteToolStripMenuItem.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para poder acceder a su historial.", "No hay cliente activo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_clientes.ShowDialog(Me)

            If txtIDCliente.Text <> "" Then
                frm_historialpagos.ShowDialog(Me)
            End If
        Else
            frm_historialpagos.ShowDialog(Me)
        End If

    End Sub

    Private Sub txtDescripcionArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcionArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtCantidadArticulo.Focus()
            txtCantidadArticulo.SelectAll()
        End If
    End Sub

    Private Sub chkItbis_Click(sender As Object, e As EventArgs) Handles chkItbis.Click
        DeterminarCambiadoItbis
    End Sub

    Sub DeterminarCambiadoItbis()
        If txtIDCliente.Text = "" Then
        Else
            If chkItbis.Checked = False Then
                If CbxTipoComprobante.Tag.ToString <> 8 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el itbis de la factura para un comprobante fiscal diferente a" & vbNewLine & vbNewLine & "Comprobante de Tributación Especial?", "Eliminación de Itbis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                    If Result = MsgBoxResult.Yes Then
                        frm_superclave.IDAccion.Text = 115
                        frm_superclave.ShowDialog(Me)

                        If ControlSuperClave = 1 Then
                            Exit Sub
                        Else
                            chkItbis.Checked = True
                        End If

                    Else
                        chkItbis.Checked = False
                    End If
                Else

                    If txtIDCliente.Text = 1 Then
                        chkItbis.Checked = True
                    Else
                        ConMixta.Open()
                        cmd = New MySqlCommand("Select count(idClientes_Carnet_Tributacion) FROM libregco.clientes_carnet_tributacion where Vencimiento>=CURDATE() And IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                        Dim Validos As Int16 = Convert.ToInt16(cmd.ExecuteScalar())
                        ConMixta.Close()

                        If Validos > 0 Then
                            chkItbis.Checked = True
                        Else
                            Dim Result1 As MsgBoxResult = MessageBox.Show("El cliente no posee carnets de exención fiscal válidos registrado en el sistema. " & vbNewLine & vbNewLine & "Está seguro que desea eliminar el itbis de la factura sin una identificación válida?", "Eliminación de Itbis", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                            If Result1 = MsgBoxResult.Yes Then
                                frm_superclave.IDAccion.Text = 115
                                frm_superclave.ShowDialog(Me)

                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                Else
                                    chkItbis.Checked = True
                                End If
                            End If

                        End If

                        btnBuscarCliente.Enabled = False
                    End If
                End If
            Else
                chkItbis.Checked = False
            End If
        End If
    End Sub
    Private Sub txtIDVendedor_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFlete_TextChanged(sender As Object, e As EventArgs) Handles txtFlete.TextChanged
        If Len(txtFlete.Text) = 0 Then
            txtFlete.Text = 0
            txtFlete.SelectAll()
        End If
    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDFactura_TextChanged(sender As Object, e As EventArgs) Handles txtIDFactura.TextChanged
        If txtIDFactura.Text = "" Then
            cbxMoneda.Enabled = True
        Else
            cbxMoneda.Enabled = False
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        GbClientes.Text = "Información general <b>" & (txtNombre.Text).ToString.ToUpper & "</b> <color=red> (" & (txtIDCliente.Text) & ") </color>"
    End Sub

    Private Sub dgvArticulosFactura_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvArticulosFactura.RowsRemoved
        If dgvArticulosFactura.Rows.Count > 0 Then
            cbxMoneda.Enabled = False
        Else
            cbxMoneda.Enabled = True
        End If
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        Try
            If CbxMedida.Text <> "" Then
                txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue)).ToString("C")
            End If

            Dim dstemp As New DataSet
            ConTemporal.Open()
            cmd = New MySqlCommand("SELECT Clientes_Balances.IDMoneda,idClientes_Balances,TasaCompra,Balance,CargosGeneral,Moneda,(Clientes_Balances.LimiteCredito-Clientes_Balances.Balance) as CreditoDisponible FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", ConTemporal)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "tipomoneda")
            ConTemporal.Close()

            If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
                txtBalanceGeneral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
                NombreMoneda = dstemp.Tables("tipomoneda").Rows(0).Item("Moneda")
                txtCreditoDisponible.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CreditoDisponible")).ToString("C")
                lblTasa.Text = dstemp.Tables("tipomoneda").Rows(0).Item("TasaCompra")

                If dstemp.Tables("tipomoneda").Rows(0).Item("IDMoneda") = 1 Then
                    lblTasa.Visible = False
                    Label3.Visible = False
                Else
                    lblTasa.Visible = True
                    Label3.Visible = True
                End If

            End If

            dstemp.Dispose()

            ILbcBalances.SelectedValue = CInt(cbxMoneda.EditValue)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtDiasCondicion_TextChanged(sender As Object, e As EventArgs) Handles txtDiasCondicion.TextChanged
        If Len(txtDiasCondicion.Text) = 0 Then
            txtDiasCondicion.Text = 30
            txtDiasCondicion.SelectAll()
        End If
    End Sub

    Private Sub chkItbis_CheckedChanged(sender As Object, e As EventArgs) Handles chkItbis.CheckedChanged
        ChangeItebis()
    End Sub

    Private Sub txtVendedor_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtVendedor.ButtonClick
        frm_contraseña_empleado.txtUsuario.Tag = lblIDUsuario.Text
        frm_contraseña_empleado.Show(Me)
    End Sub

    Private Sub txtCobrador_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCobrador.ButtonClick
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub IrAArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
        frm_mant_articulos.txtIDProducto.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
        frm_mant_articulos.FillAllDatafromID()

        If txtIDCliente.Text <> "" Then
            If txtIDCliente.Text <> 1 Then
                frm_mant_articulos.SplitContainer1.Panel1Collapsed = False
                frm_mant_articulos.lblHistorialCliente.Text = txtNombre.Text.ToUpper
            End If
        End If
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = dgvArticulosFactura.CurrentCell.ColumnIndex


        If Columna = 4 Then

            If dgvArticulosFactura.CurrentRow.Cells(15).Value = 1 Then
                Dim Caracter As Char = e.KeyChar
                Dim Txt As TextBox = CType(sender, TextBox)

                If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            Else

                Dim Caracter As Char = e.KeyChar
                Dim Txt As TextBox = CType(sender, TextBox)

                If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If

            End If

        ElseIf Columna = 8 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub dgvArticulosFactura_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvArticulosFactura.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub chkPreviewImages_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreviewImages.CheckedChanged
        PropiedadesDgvArticulos()
    End Sub

    Private Sub dgvArticulosFactura_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArticulosFactura.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgvArticulosFactura.Rows(e.RowIndex).Selected = True

                dgvArticulosFactura.CurrentCell = dgvArticulosFactura.Rows(e.RowIndex).Cells(6)

                CMenuProducts.Show(dgvArticulosFactura, e.Location)
                CMenuProducts.Show(Cursor.Position)

            End If
        End If

    End Sub

    Private Sub BuscarCedulaenCredito()
        If CInt(DTConfiguracion.Rows(55 - 1).Item("Value2Int")) = 1 Then
            If lblDiasCondicion.Text > 0 Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select Clientes.Identificacion from Clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                Dim IdentInserted As String = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If IdentInserted.Length > 0 Then
                    IdentInserted = Replace(IdentInserted, "_", "")
                    IdentInserted = Replace(IdentInserted, "-", "")
                End If

                If IdentInserted.Trim = "" Then
                    MessageBox.Show("El cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " no tiene un número de identificación/cédula válido para procesar facturas a crédito." & vbNewLine & vbNewLine & "Por favor inserte el número de identificación del cliente para procesar la factura.", "No tiene No. de Identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                Else
                    ControlSuperClave = 0
                End If
            End If
        Else
            ControlSuperClave = 0
        End If
    End Sub

    Private Sub frm_facturacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        GC.Collect()
    End Sub

    Private Sub VerificarFechaSistema()
        Dim CurrentDate As New Date
        Con.Open()
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())
        Con.Close()

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()
        End If

    End Sub

    Private Sub ControlRelacionSueldo()
        Try
            If lblDiasCondicion.Text > 0 Then
                If CInt(DTConfiguracion.Rows(103 - 1).Item("Value2Int")) = 1 Then
                    Dim Sueldo, Relacion, Mensualidad As Double

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT Sueldo FROM libregco.clientes where IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                    Sueldo = Convert.ToDouble(cmd.ExecuteScalar())

                    Relacion = CDbl(DTConfiguracion.Rows(104 - 1).Item("Value3Double"))

                    cmd = New MySqlCommand("SELECT Coalesce(sum(IF(MontoPagos<Balance, MontoPagos,Balance)),0) AS MontoValido FROM" & SysName.Text & "facturadatos inner join libregco.Condicion on facturadatos.IDCondicion=Condicion.IDCondicion where Condicion.Dias>0 and FacturaDatos.Balance>0 and IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                    Mensualidad = CDbl(Convert.ToString(cmd.ExecuteScalar())) + CDbl(txtMontoPagos.Text)
                    ConMixta.Close()

                    If Mensualidad > (Sueldo * Relacion) Then
                        If Not AccionesModulosAutorizadas.Contains("107") Then
                            MessageBox.Show("Los montos de pagos que tiene el cliente (" & Mensualidad.ToString("C") & ")" & vbNewLine & vbNewLine & "Exceden su capacidad en base al salario específicado según fue establecido en la relación de la capacidad de pagos (" & Relacion.ToString("P2") & ") establecida en el sistema.", "Exceso de capacidad de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 107
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub GetTriedModifiedIDFactArt()
        Try
            If lblIDFactArt.Text <> "" Then
                Dim ImgFile As Image

                ConMixta.Open()
                Dim Consulta As New MySqlCommand("Select IDFactArt,IDFactura,IDPrecio,FacturaArticulos.IDMedida,Cantidad,FacturaArticulos.Medida,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,PrecioUnitario,Descuento,Itbis,Importe,IDAlmacen,NivelPrecioArticulo,0,Medida.Fraccionamiento,RutaFoto from" & SysName.Text & "Facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE IDFactArt='" + lblIDFactArt.Text + "'", ConMixta)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    If TypeConnection.Text = 1 Then
                        If (LectorArticulos.GetValue(16)) = "" Then
                            ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(LectorArticulos.GetValue(16))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(LectorArticulos.GetValue(16), FileMode.Open, FileAccess.Read)
                                ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                                wFile.Close()
                            Else
                                ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                            End If
                        End If
                    Else
                        ImgFile = ResizeImage(My.Resources.No_Image, CInt(DTConfiguracion.Rows(178 - 1).Item("Value2Int")))
                    End If

                    dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14), LectorArticulos.GetValue(15), ImgFile)

                End While

                LectorArticulos.Close()
                ConMixta.Close()

                SumTotales()
                CreatePagares()
                LimpiarDatosArticulos()
                btnModificar.Enabled = True
                txtDescripcionArticulo.ReadOnly = True
                txtDescripcionArticulo.Enabled = False
                dgvArticulosFactura.FirstDisplayedScrollingRowIndex = dgvArticulosFactura.Rows.Count - 1
                txtCodigoArticulo.Focus()

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try



    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        'Try
        Dim CheckADC As New Label
        VerificarFechaSistema()

        CreatePagares()

        If CInt(DTConfiguracion.Rows(175 - 1).Item("Value2Int")) = 1 Then
            If IDPrefactura.Count = 0 Then
                MessageBox.Show("Se ha específicado que es necesaria la realización de una prefactura para la emisión posterior de una factura." & vbNewLine & vbNewLine & "Verifique la configuración del método de venta y/o los permisos y ajustes del sistema.", "Facturación sin prefactura ha sido bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        If txtIDCliente.Text = "" Or ILbcBalances.Items.Count = 0 Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "Seleccione el cliente para procesar la factura. No se ha específicado el cliente"
            btnBuscarCliente.PerformClick()
            Exit Sub

        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "Escriba el nombre del cliente de la factura a procesar"
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub

        ElseIf Len(txtNombre.Text) < 3 Then
            MessageBox.Show("Escriba un nombre válido para generar la prefactura.", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombre.Focus()
            txtNombre.SelectAll()
            Exit Sub

        ElseIf CDbl(lblDiasCondicion.Text) > 0 And txtIDCliente.Text = 1 Then
            MessageBox.Show("No existe la posibilidad de realizar facturas a crédito con el código de contado." & vbNewLine & vbNewLine & "Verifique el código del cliente que esta utilizando en este proceso.", "Código de cliente no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub

        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "No se encuentran artículos en la factura"
            btnBuscarArticulo.Focus()
            Exit Sub

        ElseIf lblDiasCondicion.Text > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
            lblStatusBar.Text = "La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente"
            Exit Sub

        ElseIf txtVendedor.Tag.ToString = "" Then
            MessageBox.Show("Escriba el código del vendedor para registrar la venta.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_contraseña_empleado.txtUsuario.Tag = lblIDUsuario.Text
            frm_contraseña_empleado.ShowDialog(Me)
            Exit Sub

        ElseIf txtCobrador.Tag.ToString = "" Then
            MessageBox.Show("Escriba el código del cobrador para registrar la venta.", "Código del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub

        ElseIf DTEmpleado.Rows(0).Item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "No se detectó el código de la sucursal para procesar la factura."
            Exit Sub

        ElseIf CInt(DTConfiguracion.Rows(79 - 1).Item("Value2Int")) = 0 And lblDiasCondicion.Text > 0 Then
            If LiberarControles.Text = 0 Then
                'BuscarCantidad de contratos a nombre del cliente
                Con.Open()
                cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today.ToString("yyyy-MM-dd") + "'", Con)
                Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If CantContratos = 0 Then
                    MessageBox.Show("No se han encontrado contratos de solicitud de crédito válidos para procesar el crédito." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    lblStatusBar.Text = "No se han encontrado contratos de solicitud de crédito válidos para procesar el crédito."
                    Exit Sub
                End If
            End If


        ElseIf CInt(DTConfiguracion.Rows(114 - 1).Item("Value2Int")) = 1 And ImponerVentaNCF = 1 Then

            If txtNombre.Text.Contains("CONTADO") Then
                MessageBox.Show("Por favor escriba el nombre de la persona o negocio a la que desea facturar.", "Escriba la denominación social", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba el nombre de la persona o negocio a la que desea facturar."
                txtNombre.Enabled = True
                txtNombre.ReadOnly = False
                txtNombre.Focus()
                Exit Sub

            ElseIf txtRNC.Text.Trim = "" Then
                MessageBox.Show("Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar.", "Escriba el RNC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar."

                If GbClientes.Size.Height = 90 Then
                    GbClientes.Size = New Size(GbClientes.Size.Width, 187)
                    txtRNC.Focus()
                    txtRNC.SelectAll()
                End If
                Exit Sub

            ElseIf txtTelefonos.Text.Replace("-", "").Trim = "" Then
                MessageBox.Show("Por favor escriba al menos un número teléfonico del cliente.", "Escriba un número teléfonico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba al menos un número teléfonico del cliente."

                If GbClientes.Size.Height = 90 Then
                    GbClientes.Size = New Size(GbClientes.Size.Width, 187)
                    txtTelefonos.Focus()
                    txtTelefonos.SelectAll()
                End If
                Exit Sub
            End If


        ElseIf CInt(DTConfiguracion.Rows(97 - 1).Item("Value2Int")) = 1 Then
            If txtNombre.Text.Contains("CONTADO") Then
                If CDbl(txtNeto.Text) > CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))) Then
                    MessageBox.Show("El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))).ToString("C") & ") para facturas sin el respectivo nombre del cliente." & vbNewLine & vbNewLine & "Por favor escriba el nombre del cliente para continuar con la factura.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    lblStatusBar.Text = "El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))).ToString("C") & ") para facturas sin el respectivo nombre del cliente"
                    lblModificar_LinkClicked(lblModificar, Nothing)
                    txtNombre.Focus()
                    txtNombre.SelectAll()
                    Exit Sub
                End If
            End If

        End If

        If CInt(DTConfiguracion.Rows(83 - 1).Item("Value2Int")) = 1 Then
            If DTConfiguracion.Rows(84 - 1).Item("Value2Int") = txtIDCliente.Text Then
                Dim TelString As String = txtTelefonos.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("_", "")

                If ContarPalabras(txtNombre.Text) < 2 Or txtNombre.Text.Contains("CONTADO") = True Or txtNombre.Text.Contains("CONTRA ENTREGA") = True Or txtNombre.Text.Contains("CONTRAENTREGA") = True Then
                    MessageBox.Show("Por escriba un nombre válido para generar la factura en el código de contraentrega.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    GbClientes.Size = New Size(GbClientes.Size.Width, 187)
                    txtNombre.Focus()
                    txtNombre.SelectAll()
                    Exit Sub

                ElseIf TelString.Length < 10 Then
                    MessageBox.Show("Por escriba al menos un número teléfonico válido para generar la factura en el código de contraentrega.", "Escriba un número teléfonico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    GbClientes.Size = New Size(GbClientes.Size.Width, 187)
                    txtTelefonos.Focus()
                    txtTelefonos.SelectAll()
                    Exit Sub
                End If
            End If

        End If




        If cbxCondicion.Tag.ToString <> 1 Then
            If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
                Exit Sub
            End If
        End If


        'Verificacion de condiciones
        If lblDiasCondicion.Text = 0 Then
        Else
            If CDbl(txtAdicional.Text) > 0 Then
                If IsDate(txtFechaAdicional.Text) Then
                    If CDate(txtFechaAdicional.Text) < CDate(txtFecha.Value) Then
                        MessageBox.Show("La fecha del adicional introducida en la factura es menor a la fecha de la factura." & vbNewLine & vbNewLine & "Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtFechaAdicional.Clear()
                        txtFechaAdicional.Focus()
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("El dato introducido no es una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFechaAdicional.Clear()
                    txtFechaAdicional.Focus()
                    Exit Sub
                End If
            Else
                txtFechaAdicional.Clear()
            End If


            Dim MayorDate As Date
            If CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int")) = 1 Then
                MayorDate = Today

                For Each Row As DataGridViewRow In DgvPagares.Rows
                    If CDate(Row.Cells(4).Value) > MayorDate Then
                        MayorDate = CDate(Row.Cells(4).Value)
                    End If
                Next
                txtFechaVencimiento.Text = MayorDate.ToString("dd/MM/yyyy")
            Else
                txtFechaVencimiento.Text = CDate(txtFecha.Value.AddDays(txtDiasCondicion.Text * txtCantidadPagos.Text)).ToString("dd/MM/yyyy")
            End If
            CreatePagares()
        End If

        If txtIDFactura.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            SumTotales()

            'Verificacion de ultima factura generada
            lblStatusBar.Text = "Estableciendo precontroles de facturación."
            Con.Open()
            cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
            LastIDFact = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If IsIntegratedBalance(txtIDCliente.Text, CDbl(txtBalanceGeneral.Text), cbxMoneda.EditValue.ToString) = False Then
                Exit Sub
            End If

            ControlSuperClave = 0
            lblStatusBar.Text = "Verificando disponibilidad de NCF."
            GetIfBlockedNCFS(CbxTipoComprobante.Tag.ToString)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            'Buscar similitudes
            lblStatusBar.Text = "Verificando si existen duplicados de la misma."
            If txtIDCliente.Text <> 1 Then
                If CInt(lblDiasCondicion.Text) = 0 Then
                    FindSimilarities(1, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                Else
                    FindSimilarities(2, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If
            End If

            If lblDiasCondicion.Text > 0 Then
                If CheckDoubleBilling(txtIDCliente.Text) = True Then
                    frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
                    Exit Sub
                End If


                'Verificar adicional
                lblStatusBar.Text = "Verificando formatos de las condiciones de ventas."
                If IsDate(txtFechaAdicional.Text) Then
                    CheckADC.Text = CDate(txtFechaAdicional.Text).ToString("yyyy-MM-dd")
                Else
                    CheckADC.Text = ""
                End If

                lblStatusBar.Text = "Verificando artículos bloqueados."
                ArticulosBloqueados()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If LiberarControles.Text = 0 Then
                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando estatus crediticio del cliente."
                        StatusCliente()
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If
                End If

                If LiberarControles.Text = 0 Then
                    lblStatusBar.Text = "Verificando límites de crédito."
                    BuscarLimiteCredito()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                If LiberarControles.Text = 0 Then
                    If CInt(IDGrupoCXC) < 3 Then
                        If lblDiasCondicion.Text > 0 Then
                            If CDbl(txtInicial.Text) > 0 Then
                                If CInt(DTConfiguracion.Rows(213 - 1).Item("Value2Int")) = 1 Then
                                    lblStatusBar.Text = "Verificando sensibilidad al costo de venta."
                                    Dim CostoTotal As Double = 0

                                    ConMixta.Open()
                                    For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
                                        cmd = New MySqlCommand("SELECT Costo FROM libregco.precioarticulo where IDPrecios='" + rw.Cells("IDPrecios").Value.ToString + "'", ConMixta)
                                        CostoTotal += Convert.ToDouble(cmd.ExecuteScalar()) * CDbl(rw.Cells("Cantidad").Value)
                                    Next
                                    ConMixta.Close()

                                    Dim RelacionSensalCosto As Double = Math.Round(CDbl(txtInicial.Text) / CostoTotal, 2)

                                    If RelacionSensalCosto >= NivelSensibilidadalCosto Then
                                        GoTo RegistroFormaPago
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                If LiberarControles.Text = 0 Then

                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando registro de documento de identidad."
                        BuscarCedulaenCredito()
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If

                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando condiciones de la venta"
                        VerificarInicialenCondicion()
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If

                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando existencia de facturas vencidas."
                        BuscarFactVencidas()
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        Else
                            If frm_reporte_movimientos_clientes.Visible = True Then
                                frm_reporte_movimientos_clientes.Close()
                            End If
                        End If
                    End If

                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando cantidad de cuentas pendientes"
                        ConMixta.Open()
                        cmd = New MySqlCommand("Select count(IDFacturaDatos) FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Condicion On FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + txtIDCliente.Text + "' And FacturaDatos.FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "' and Condicion.Dias>0 And FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                        Dim CantFacturasPendientes As String = Convert.ToString(cmd.ExecuteScalar())
                        ConMixta.Close()
                        If CInt(CantFacturasPendientes) >= CInt(MaxFacturasCreditoPermitidas) Then
                            If Not AccionesModulosAutorizadas.Contains("118") Then
                                ControlSuperClave = 1
                                frm_superclave.IDAccion.Text = 118
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                        End If
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If

                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando cantidad de pagos pendientes"
                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT count(IDPagare) FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.Balance>0 and Pagares.FechaVencimiento<Now() and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                        Dim CantPagaresVencidos As String = Convert.ToString(cmd.ExecuteScalar())
                        ConMixta.Close()
                        If CInt(CantPagaresVencidos) >= CInt(MaxPagosVencidos) Then
                            If Not AccionesModulosAutorizadas.Contains("119") Then
                                ControlSuperClave = 1
                                frm_superclave.IDAccion.Text = 119
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                        End If
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If


                    If CInt(IDGrupoCXC) < 3 Then
                        lblStatusBar.Text = "Verificando montos de los pagarés"
                        If CDbl(txtMontoPagos.Text) < CDbl(MontoMinimoPagare) Then
                            If Not AccionesModulosAutorizadas.Contains("120") Then
                                ControlSuperClave = 1
                                frm_superclave.IDAccion.Text = 120
                                frm_superclave.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If

                        Else
                            If CDbl(txtAdicional.Text) > 0 Then
                                If CDbl(txtAdicional.Text) < CDbl(MontoMinimoPagare) Then
                                    If Not AccionesModulosAutorizadas.Contains("120") Then
                                        ControlSuperClave = 1
                                        frm_superclave.IDAccion.Text = 120
                                        frm_superclave.ShowDialog(Me)
                                    Else
                                        ControlSuperClave = 0
                                    End If

                                End If
                            End If
                        End If
                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If


                    If CInt(IDGrupoCXC) < 3 Then
                        'Si el cliente es personal verifico si puede pagarlo con respecto a la formula de salario
                        ConLibregco.Open()
                        cmd = New MySqlCommand("SELECT IDTipoCredito FROM clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                        If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                            lblStatusBar.Text = "Calculado relación de pagos con respecto al sueldo."
                            ControlRelacionSueldo()
                            If ControlSuperClave = 1 Then
                                ConLibregco.Close()
                                Exit Sub
                            End If
                        End If
                        ConLibregco.Close()
                    End If

                End If

                If CInt(IDGrupoCXC) < 3 Then
                    lblStatusBar.Text = "Verificando control de autorizaciones para ventas."
                    If CInt(DTConfiguracion.Rows(82 - 1).Item("Value2Int")) = 1 Then
                        If lblDiasCondicion.Text > 0 Then

                            If Not AccionesModulosAutorizadas.Contains("17") Then
                                frm_usuarios_recepcion_solicitud.ShowDialog(Me)

                                If frm_autorizacion_acciones.IDEmpleadoAvisa.Text = "" Then
                                    frm_autorizacion_acciones.IDEmpleadoAvisa.Text = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
                                End If

                                frm_autorizacion_acciones.IDAccion.Text = 17
                                frm_autorizacion_acciones.lblAccion.Text = "Control de ventas a crédito (Autorización de ventas)"
                                frm_autorizacion_acciones.ShowDialog(Me)
                            Else
                                ControlSuperClave = 0
                            End If


                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If

                        End If
                    End If
                End If

            End If

RegistroFormaPago:
            lblStatusBar.Text = "Registrando método de pago."

            ControlSuperClave = 1
            frm_formadepago.txtEfectivo.Focus()
            frm_formadepago.txtEfectivo.SelectAll()
            frm_formadepago.ShowDialog(Me)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            lblStatusBar.Text = "Adquiriendo secuencia de NCF."
            GetNCFsNumbers(CbxTipoComprobante.Tag.ToString)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            lblStatusBar.Text = "Guardando registro a la base de datos."
            CambiarBalance()

            sqlQ = "INSERT INTO Facturadatos (SecondID,IDTipoDocumento,IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTransaccion,NCF,NCFModificado,NIF,IDCondicion,DiasCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,FechaRetencion,ItbisRetenido,ItbisPercibido,RetencionRenta,ISRPercibido,ISC,OtrosImpuestos,PropinaLegal,Flete,TotalNeto,NetoLetra,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Observacion,NoOrden,EntregarPorConduce,Cierre,Impreso,IDTipoIngreso,IDMoneda,Tasa,Nulo) VALUES ('" + GetSecondID(lblIDTipoDocumento.Text).ToString + "','" + lblIDTipoDocumento.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text.ToUpper + "','" + txtTelefonos.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','','" + txtNIF.Text + "','" + cbxCondicion.Tag.ToString + "','" + txtDiasCondicion.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + CbxTipoComprobante.Tag.ToString + "','" + CbxChofer.Tag.ToString + "','" + cbxVehiculo.Tag.ToString + "','" + txtVendedor.Tag.ToString + "','" + lblIDUsuario.Text + "',DATE(NOW()),TIME(NOW()),'" + CDbl(txtInicial.Text).ToString + "','" + txtCantidadPagos.Text + "','" + CDbl(txtMontoPagos.Text).ToString + "','" + CDbl(txtAdicional.Text).ToString + "','" + CheckADC.Text + "','" + CDbl(txtBalance.Text).ToString + "','" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(chkHabilitarNota.CheckState).ToString + "','" + txtCondicionContado.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(TxtDescuentoSuma.Text).ToString + "','" + CDbl(txtITBIS.Text).ToString + "','',0,0,0,0,0,0,0,'" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',0,'" + CDbl(txtBalance.Text).ToString + "','" + Convert.ToInt16(chkFichaDatos.CheckState).ToString + "',0,'ACTIVA','" + txtObservacion.Text + "','" + txtOrden.Text + "','" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',0,0,1,'" + cbxMoneda.EditValue.ToString + "','" + CDbl(lblTasa.Text).ToString + "','" + Convert.ToInt16(chkDesactivar.Checked).ToString + "')"
            lblStatusBar.Text = "Guardando registro a la base de datos (Insertando registro)."
            GuardarDatos()

            lblStatusBar.Text = "Guardando registro a la base de datos (Obteniendo número de factura)."
            UltFactura()

            lblStatusBar.Text = "Guardando registro a la base de datos (Insertando artículos)."
            InsertArticulos()

            lblStatusBar.Text = "Guardando registro a la base de datos (Insertando pagarés)."
            InsertPagares()

            lblStatusBar.Text = "Actualizando existencias."
            CalcInventario()

            lblStatusBar.Text = "Identificando seriales."
            BuscarSeriales()

            lblStatusBar.Text = "Calculando balances."
            CalcularBalances()

            lblStatusBar.Text = "Verificando prefacturaciones."

            CheckPrefacturas()

            CheckQuestions()

            lblStatusBar.ForeColor = Color.Green
            lblStatusBar.Text = "El registro fue guardado satisfactoriamente."

            ToastNotificationsManager1.Notifications(0).Body = "La factura " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

            'Verificando eventos especiales
            If CheckEventosBoleteriaActuales(1) = True Then
                lblStatusBar.ForeColor = Color.Purple
                lblStatusBar.Text = "Se han encontrado eventos especiales aplicables en facturación."

                If lblDiasCondicion.Text = 0 Then
                    GenerateBoletosEventos(1, lblIDTransaccion.Text, CDbl(txtNeto.Text), txtNombre.Text, txtRNC.Text, txtDireccion.Text.ToUpper, txtTelefonos.Text)
                Else
                    GenerateBoletosEventos(1, lblIDTransaccion.Text, CDbl(txtInicial.Text), txtNombre.Text, txtRNC.Text, txtDireccion.Text.ToUpper, txtTelefonos.Text)
                End If
            End If

            DeshabilitarControles()
            Hora.Enabled = False
            lblStatusBar.ForeColor = Color.Black
            lblStatusBar.Text = "Listo."
            ImprimirDocumento()

            'End If
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If IsModifiable(txtIDFactura.Text) Then
            Else
                MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            SumTotales()

            GetTriedModifiedIDFactArt()
            lblStatusBar.Text = "Buscando registros modificados no guardados."

            lblStatusBar.Text = "Modificando registro de método de pago."
            frm_formadepago.ShowDialog(Me)
            If ControlSuperClave = 1 Then
                Exit Sub
            End If

            lblStatusBar.Text = "Modificando registro de la base de datos."
            CambiarBalance()
            sqlQ = "UPDATE FacturaDatos SET IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text.ToUpper + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',IDChofer='" + CbxChofer.Tag.ToString + "',IDVehiculo='" + cbxVehiculo.Tag.ToString + "',IDVendedor='" + txtVendedor.Tag.ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',PagoAdicional='" + CDbl(txtAdicional.Text).ToString + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + CDbl(txtBalance.Text).ToString + "',Balance='" + CDbl(txtBalance.Text).ToString + "',FechaVencimiento='" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "',NotaContado='" + Convert.ToInt16(chkHabilitarNota.Checked).ToString + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuentoSuma.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',EntregarPorConduce='" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',HabilitarFicha='" + Convert.ToInt16(chkFichaDatos.Checked).ToString + "',Observacion='" + txtObservacion.Text + "',NoOrden='" + txtOrden.Text + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Tasa='" + CDbl(lblTasa.Text).ToString + "',Nulo='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
            GuardarDatos()
            InsertArticulos()
            InsertPagares()
            CalcInventario()
            CalcularBalances()
            CheckPrefacturas()

            ToastNotificationsManager1.Notifications(1).Body = "La factura " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

            lblStatusBar.ForeColor = Color.Green
            lblStatusBar.Text = "El registro fue modificado satisfactoriamente."
            DeshabilitarControles()
            Hora.Enabled = False
            lblStatusBar.ForeColor = Color.Black
            lblStatusBar.Text = "Listo."
            ImprimirDocumento()
            'End If
        End If
        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    '    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
    '        Try
    '            Dim CheckADC As New Label
    '            VerificarFechaSistema()
    '            CreatePagares()

    '            If CInt(DTConfiguracion.Rows(175 - 1).Item("Value2Int")) = 1 Then
    '                If IDPrefactura.Count = 0 Then
    '                    MessageBox.Show("Se ha específicado que es necesaria la realización de una prefactura para la emisión posterior de una factura." & vbNewLine & vbNewLine & "Verifique la configuración del método de venta y/o los permisos y ajustes del sistema.", "Facturación sin prefactura ha sido bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If

    '            End If
    '            If txtIDCliente.Text = "" Then
    '                MessageBox.Show("Seleccione el cliente para procesar la factura.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                lblStatusBar.Text = "Seleccione el cliente para procesar la factura. No se ha específicado el cliente"
    '                btnBuscarCliente.PerformClick()
    '                Exit Sub

    '            ElseIf txtNombre.Text = "" Then
    '                MessageBox.Show("Escriba el nombre del cliente de la factura a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                lblStatusBar.Text = "Escriba el nombre del cliente de la factura a procesar"
    '                txtNombre.Enabled = True
    '                txtNombre.Focus()
    '                Exit Sub

    '            ElseIf Len(txtNombre.Text) < 3 Then
    '                MessageBox.Show("Escriba un nombre válido para generar la prefactura.", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                txtNombre.Focus()
    '                txtNombre.SelectAll()
    '                Exit Sub

    '            ElseIf CDbl(lblDiasCondicion.Text) > 0 And txtIDCliente.Text = 1 Then
    '                MessageBox.Show("No existe la posibilidad de realizar facturas a crédito con el código de contado." & vbNewLine & vbNewLine & "Verifique el código del cliente que esta utilizando en este proceso.", "Código de cliente no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                Exit Sub

    '            ElseIf dgvArticulosFactura.Rows.Count = 0 Then
    '                MessageBox.Show("No se encuentran artículos en la factura.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                lblStatusBar.Text = "No se encuentran artículos en la factura"
    '                btnBuscarArticulo.Focus()
    '                Exit Sub

    '            ElseIf lblDiasCondicion.Text > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
    '                MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                txtCantidadPagos.Text = 1
    '                lblStatusBar.Text = "La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente"
    '                Exit Sub

    '            ElseIf txtVendedor.Tag.ToString = "" Then
    '                MessageBox.Show("Escriba el código del vendedor para registrar la venta.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                frm_contraseña_empleado.txtUsuario.Tag = lblIDUsuario.Text
    '                frm_contraseña_empleado.ShowDialog(Me)
    '                Exit Sub

    '            ElseIf txtCobrador.Tag.ToString = "" Then
    '                MessageBox.Show("Escriba el código del cobrador para registrar la venta.", "Código del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                Exit Sub

    '            ElseIf DtEmpleado.Rows(0).item("IDSucursal").ToString() = "" Then
    '                MessageBox.Show("No se detectó el código de la sucursal para procesar la factura.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                lblStatusBar.Text = "No se detectó el código de la sucursal para procesar la factura."
    '                Exit Sub

    '            ElseIf CInt(DTConfiguracion.Rows(79 - 1).Item("Value2Int")) = 0 And lblDiasCondicion.Text > 0 Then
    '                'BuscarCantidad de contratos a nombre del cliente
    '                Con.Open()
    '                cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today.ToString("yyyy-MM-dd") + "'", Con)
    '                Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())
    '                Con.Close()

    '                If CantContratos = 0 Then
    '                    MessageBox.Show("No se han encontrado contratos de solicitud de crédito válidos para procesar el crédito." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                    lblStatusBar.Text = "No se han encontrado contratos de solicitud de crédito válidos para procesar el crédito."
    '                    Exit Sub
    '                End If

    '            ElseIf CInt(DTConfiguracion.Rows(114 - 1).Item("Value2Int")) = 1 And ImponerVentaNCF = 1 Then

    '                If txtNombre.Text.Contains("CONTADO") Then
    '                    MessageBox.Show("Por favor escriba el nombre de la persona o negocio a la que desea facturar.", "Escriba la denominación social", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                    lblStatusBar.Text = "Por favor escriba el nombre de la persona o negocio a la que desea facturar."
    '                    txtNombre.Enabled = True
    '                    txtNombre.ReadOnly = False
    '                    txtNombre.Focus()
    '                    Exit Sub

    '                ElseIf txtRNC.Text.Trim = "" Then
    '                    MessageBox.Show("Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar.", "Escriba el RNC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                    lblStatusBar.Text = "Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar."

    '                    If GbClientes.Size.Height = 90 Then
    '                        GbClientes.Size = New Size(GbClientes.Size.Width, 187)
    '                        txtRNC.Focus()
    '                        txtRNC.SelectAll()
    '                    End If

    '                    Exit Sub

    '                ElseIf txtTelefonos.Text.Replace("-", "").Trim = "" Then
    '                    MessageBox.Show("Por favor escriba al menos un número teléfonico del cliente.", "Escriba un número teléfonico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                    lblStatusBar.Text = "Por favor escriba al menos un número teléfonico del cliente."

    '                    If GbClientes.Size.Height = 90 Then
    '                        GbClientes.Size = New Size(GbClientes.Size.Width, 187)
    '                        txtTelefonos.Focus()
    '                        txtTelefonos.SelectAll()
    '                    End If

    '                    Exit Sub
    '                End If


    '            ElseIf CInt(DTConfiguracion.Rows(97 - 1).Item("Value2Int")) = 1 Then
    '                If txtNombre.Text.Contains("CONTADO") Then
    '                    If CDbl(txtNeto.Text) > CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))) Then
    '                        MessageBox.Show("El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))).ToString("C") & ") para facturas sin el respectivo nombre del cliente." & vbNewLine & vbNewLine & "Por favor escriba el nombre del cliente para continuar con la factura.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                        lblStatusBar.Text = "El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(CDbl(DTConfiguracion.Rows(98 - 1).Item("Value3Double"))).ToString("C") & ") para facturas sin el respectivo nombre del cliente"
    '                        lblModificar_LinkClicked(lblModificar, Nothing)
    '                        txtNombre.Focus()
    '                        txtNombre.SelectAll()
    '                        Exit Sub
    '                    End If
    '                End If

    '            End If

    '            If cbxCondicion.Tag.ToString <> 1 Then
    '                If CheckRequiredFieldsofCustomers(txtIDCliente.Text) = False Then
    '                    Exit Sub
    '                End If
    '            End If

    '            'Verificacion de condiciones
    '            If lblDiasCondicion.Text = 0 Then
    '            Else
    '                If CDbl(txtAdicional.Text) > 0 Then
    '                    If IsDate(txtFechaAdicional.Text) Then
    '                        If CDate(txtFechaAdicional.Text) < CDate(txtFecha.Value) Then
    '                            MessageBox.Show("La fecha del adicional introducida en la factura es menor a la fecha de la factura." & vbNewLine & vbNewLine & "Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                            txtFechaAdicional.Clear()
    '                            txtFechaAdicional.Focus()
    '                            Exit Sub
    '                        End If
    '                    Else
    '                        MessageBox.Show("El dato introducido no es una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                        txtFechaAdicional.Clear()
    '                        txtFechaAdicional.Focus()
    '                        Exit Sub
    '                    End If
    '                Else
    '                    txtFechaAdicional.Clear()
    '                End If


    '                Dim MayorDate As Date
    '                If CInt(DTConfiguracion.Rows(96 - 1).Item("Value2Int")) = 1 Then
    '                    MayorDate = Today

    '                    For Each Row As DataGridViewRow In DgvPagares.Rows
    '                        If CDate(Row.Cells(4).Value) > MayorDate Then
    '                            MayorDate = CDate(Row.Cells(4).Value)
    '                        End If
    '                    Next
    '                    txtFechaVencimiento.Text = MayorDate.ToString("dd/MM/yyyy")
    '                Else
    '                    txtFechaVencimiento.Text = CDate(txtFecha.Value.AddDays(txtDiasCondicion.Text * txtCantidadPagos.Text)).ToString("dd/MM/yyyy")
    '                End If
    '                CreatePagares()
    '            End If

    '            If txtIDFactura.Text = "" Then 'Si no hay factura
    '                If Permisos(1) = 0 Then
    '                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Exit Sub
    '                End If
    '                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '                If Result = MsgBoxResult.Yes Then
    '                    SumTotales()

    '                    'Verificacion de ultima factura generada
    '                    lblStatusBar.Text = "Estableciendo precontroles de facturación."
    '                    Con.Open()
    '                    cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
    '                    LastIDFact = Convert.ToString(cmd.ExecuteScalar())
    '                    Con.Close()

    '                    If IsIntegratedBalance(txtIDCliente.Text, CDbl(txtBalanceGeneral.Text), cbxMoneda.EditValue.ToString) = False Then
    '                        Exit Sub
    '                    End If

    '                    ControlSuperClave = 0
    '                    lblStatusBar.Text = "Verificando disponibilidad de NCF."
    '                    GetIfBlockedNCFS(CbxTipoComprobante.Tag.ToString)
    '                    If ControlSuperClave = 1 Then
    '                        Exit Sub
    '                    End If

    '                    'Buscar similitudes
    '                    lblStatusBar.Text = "Verificando si existen duplicados de la misma."
    '                    If txtIDCliente.Text <> 1 Then
    '                        If CInt(lblDiasCondicion.Text) = 0 Then
    '                            FindSimilarities(1, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        Else
    '                            FindSimilarities(2, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If
    '                    End If

    '                    If lblDiasCondicion.Text > 0 Then
    '                        If CheckDoubleBilling(txtIDCliente.Text) = True Then
    '                            frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
    '                            Exit Sub
    '                        End If


    '                        'Verificar adicional
    '                        lblStatusBar.Text = "Verificando formatos de las condiciones de ventas."
    '                        If IsDate(txtFechaAdicional.Text) Then
    '                            CheckADC.Text = CDate(txtFechaAdicional.Text).ToString("yyyy-MM-dd")
    '                        Else
    '                            CheckADC.Text = ""
    '                        End If

    '                        lblStatusBar.Text = "Verificando artículos bloqueados."
    '                        ArticulosBloqueados()
    '                        If ControlSuperClave = 1 Then
    '                            Exit Sub
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando estatus crediticio del cliente."
    '                            StatusCliente()
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If

    '                        lblStatusBar.Text = "Verificando límites de crédito."
    '                        BuscarLimiteCredito()
    '                        If ControlSuperClave = 1 Then
    '                            Exit Sub
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            If lblDiasCondicion.Text > 0 Then
    '                                If CDbl(txtInicial.Text) > 0 Then
    '                                    If CInt(DTConfiguracion.Rows(213 - 1).Item("Value2Int")) = 1 Then
    '                                        lblStatusBar.Text = "Verificando sensibilidad al costo de venta."
    '                                        Dim CostoTotal As Double = 0

    '                                        ConMixta.Open()
    '                                        For Each rw As DataGridViewRow In dgvArticulosFactura.Rows
    '                                            cmd = New MySqlCommand("SELECT Costo FROM libregco.precioarticulo where IDPrecios='" + rw.Cells("IDPrecios").Value.ToString + "'", ConMixta)
    '                                            CostoTotal += Convert.ToDouble(cmd.ExecuteScalar()) * CDbl(rw.Cells("Cantidad").Value)
    '                                        Next
    '                                        ConMixta.Close()

    '                                        Dim RelacionSensalCosto As Double = Math.Round(CDbl(txtInicial.Text) / CostoTotal, 2)

    '                                        If RelacionSensalCosto >= NivelSensibilidadalCosto Then
    '                                            GoTo RegistroFormaPago
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando registro de documento de identidad."
    '                            BuscarCedulaenCredito()
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando condiciones de la venta"
    '                            VerificarInicialenCondicion()
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando existencia de facturas vencidas."
    '                            BuscarFactVencidas()
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            Else
    '                                If frm_reporte_movimientos_clientes.Visible = True Then
    '                                    frm_reporte_movimientos_clientes.Close()
    '                                End If
    '                            End If
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando cantidad de cuentas pendientes"
    '                            ConMixta.Open()
    '                            cmd = New MySqlCommand("Select count(IDFacturaDatos) FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Condicion On FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + txtIDCliente.Text + "' And FacturaDatos.FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "' and Condicion.Dias>0 And FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
    '                            Dim CantFacturasPendientes As String = Convert.ToString(cmd.ExecuteScalar())
    '                            ConMixta.Close()
    '                            If CInt(CantFacturasPendientes) >= CInt(MaxFacturasCreditoPermitidas) Then
    '                                If Not AccionesModulosAutorizadas.Contains("118") Then
    '                                    ControlSuperClave = 1
    '                                    frm_superclave.IDAccion.Text = 118
    '                                    frm_superclave.ShowDialog(Me)
    '                                Else
    '                                    ControlSuperClave = 0
    '                                End If

    '                            End If
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If

    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando cantidad de pagos pendientes"
    '                            ConMixta.Open()
    '                            cmd = New MySqlCommand("SELECT count(IDPagare) FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.Balance>0 and Pagares.FechaVencimiento<Now() and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
    '                            Dim CantPagaresVencidos As String = Convert.ToString(cmd.ExecuteScalar())
    '                            ConMixta.Close()
    '                            If CInt(CantPagaresVencidos) >= CInt(MaxPagosVencidos) Then
    '                                If Not AccionesModulosAutorizadas.Contains("119") Then
    '                                    ControlSuperClave = 1
    '                                    frm_superclave.IDAccion.Text = 119
    '                                    frm_superclave.ShowDialog(Me)
    '                                Else
    '                                    ControlSuperClave = 0
    '                                End If

    '                            End If
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If


    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando montos de los pagarés"
    '                            If CDbl(txtMontoPagos.Text) < CDbl(MontoMinimoPagare) Then
    '                                If Not AccionesModulosAutorizadas.Contains("120") Then
    '                                    ControlSuperClave = 1
    '                                    frm_superclave.IDAccion.Text = 120
    '                                    frm_superclave.ShowDialog(Me)
    '                                Else
    '                                    ControlSuperClave = 0
    '                                End If

    '                            Else
    '                                If CDbl(txtAdicional.Text) > 0 Then
    '                                    If CDbl(txtAdicional.Text) < CDbl(MontoMinimoPagare) Then
    '                                        If Not AccionesModulosAutorizadas.Contains("120") Then
    '                                            ControlSuperClave = 1
    '                                            frm_superclave.IDAccion.Text = 120
    '                                            frm_superclave.ShowDialog(Me)
    '                                        Else
    '                                            ControlSuperClave = 0
    '                                        End If

    '                                    End If
    '                                End If
    '                            End If
    '                            If ControlSuperClave = 1 Then
    '                                Exit Sub
    '                            End If
    '                        End If


    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            'Si el cliente es personal verifico si puede pagarlo con respecto a la formula de salario
    '                            ConLibregco.Open()
    '                            cmd = New MySqlCommand("SELECT IDTipoCredito FROM clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
    '                            If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
    '                                lblStatusBar.Text = "Calculado relación de pagos con respecto al sueldo."
    '                                ControlRelacionSueldo()
    '                                If ControlSuperClave = 1 Then
    '                                    ConLibregco.Close()
    '                                    Exit Sub
    '                                End If
    '                            End If
    '                            ConLibregco.Close()
    '                        End If


    '                        If CInt(IDGrupoCXC) < 3 Then
    '                            lblStatusBar.Text = "Verificando control de autorizaciones para ventas."
    '                            If CInt(DTConfiguracion.Rows(82 - 1).Item("Value2Int")) = 1 Then
    '                                If lblDiasCondicion.Text > 0 Then

    '                                    If Not AccionesModulosAutorizadas.Contains("17") Then
    '                                        frm_usuarios_recepcion_solicitud.ShowDialog(Me)

    '                                        If frm_autorizacion_acciones.IDEmpleadoAvisa.Text = "" Then
    '                                            frm_autorizacion_acciones.IDEmpleadoAvisa.Text = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
    '                                        End If

    '                                        frm_autorizacion_acciones.IDAccion.Text = 17
    '                                        frm_autorizacion_acciones.lblAccion.Text = "Control de ventas a crédito (Autorización de ventas)"
    '                                        frm_autorizacion_acciones.ShowDialog(Me)
    '                                    Else
    '                                        ControlSuperClave = 0
    '                                    End If


    '                                    If ControlSuperClave = 1 Then
    '                                        Exit Sub
    '                                    End If

    '                                End If
    '                            End If
    '                        End If

    '                    End If

    'RegistroFormaPago:
    '                    lblStatusBar.Text = "Registrando método de pago."

    '                    ControlSuperClave = 1
    '                    frm_formadepago.txtEfectivo.Focus()
    '                    frm_formadepago.txtEfectivo.SelectAll()
    '                    frm_formadepago.ShowDialog(Me)
    '                    If ControlSuperClave = 1 Then
    '                        Exit Sub
    '                    End If

    '                    lblStatusBar.Text = "Adquiriendo secuencia de NCF."
    '                    GetNCFsNumbers(CbxTipoComprobante.Tag.ToString)
    '                    If ControlSuperClave = 1 Then
    '                        Exit Sub
    '                    End If

    '                    lblStatusBar.Text = "Guardando registro a la base de datos."
    '                    CambiarBalance()

    '                    sqlQ = "INSERT INTO Facturadatos (SecondID,IDTipoDocumento,IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTransaccion,NCF,NCFModificado,NIF,IDCondicion,DiasCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,FechaRetencion,ItbisRetenido,ItbisPercibido,RetencionRenta,ISRPercibido,ISC,OtrosImpuestos,PropinaLegal,Flete,TotalNeto,NetoLetra,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Observacion,NoOrden,EntregarPorConduce,Cierre,Impreso,IDTipoIngreso,IDMoneda,Tasa,Nulo) VALUES ('" + GetSecondID(lblIDTipoDocumento.Text).ToString + "','" + lblIDTipoDocumento.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text.ToUpper + "','" + txtTelefonos.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','','" + txtNIF.Text + "','" + cbxCondicion.Tag.ToString + "','" + txtDiasCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + CbxTipoComprobante.Tag.ToString + "','" + CbxChofer.Tag.ToString + "','" + cbxVehiculo.Tag.ToString + "','" + txtVendedor.Tag.ToString + "','" + lblIDUsuario.Text + "',DATE(NOW()),TIME(NOW()),'" + CDbl(txtInicial.Text).ToString + "','" + txtCantidadPagos.Text + "','" + CDbl(txtMontoPagos.Text).ToString + "','" + CDbl(txtAdicional.Text).ToString + "','" + CheckADC.Text + "','" + CDbl(txtBalance.Text).ToString + "','" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToInt16(chkHabilitarNota.CheckState).ToString + "','" + txtCondicionContado.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(TxtDescuentoSuma.Text).ToString + "','" + CDbl(txtITBIS.Text).ToString + "','',0,0,0,0,0,0,0,'" + CDbl(txtFlete.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',0,'" + CDbl(txtBalance.Text).ToString + "','" + Convert.ToInt16(chkFichaDatos.CheckState).ToString + "',0,'ACTIVA','" + txtObservacion.Text + "','" + txtOrden.Text + "','" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',0,0,1,'" + cbxMoneda.EditValue.ToString + "','" + CDbl(lblTasa.Text).ToString + "','" + Convert.ToInt16(chkDesactivar.Checked).ToString + "')"
    '                    lblStatusBar.Text = "Guardando registro a la base de datos (Insertando registro)."
    '                    GuardarDatos()
    '                    lblStatusBar.Text = "Guardando registro a la base de datos (Obteniendo número de factura)."
    '                    UltFactura()
    '                    lblStatusBar.Text = "Guardando registro a la base de datos (Insertando artículos)."
    '                    InsertArticulos()
    '                    lblStatusBar.Text = "Guardando registro a la base de datos (Insertando pagarés)."
    '                    InsertPagares()
    '                    lblStatusBar.Text = "Actualizando existencias."
    '                    CalcInventario()
    '                    lblStatusBar.Text = "Identificando seriales."
    '                    BuscarSeriales()
    '                    lblStatusBar.Text = "Calculando balances."
    '                    CalcularBalances()
    '                    lblStatusBar.Text = "Verificando prefacturaciones."
    '                    CheckPrefacturas()
    '                    CheckQuestions
    '                    lblStatusBar.ForeColor = Color.Green
    '                    lblStatusBar.Text = "El registro fue guardado satisfactoriamente."

    '                    ToastNotificationsManager1.Notifications(0).Body = "La factura " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
    '                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

    '                    'Verificando eventos especiales
    '                    If CheckEventosBoleteriaActuales(1) = True Then
    '                        lblStatusBar.ForeColor = Color.Purple
    '                        lblStatusBar.Text = "Se han encontrado eventos especiales aplicables en facturación."

    '                        If lblDiasCondicion.Text = 0 Then
    '                            GenerateBoletosEventos(1, lblIDTransaccion.Text, CDbl(txtNeto.Text), txtNombre.Text, txtRNC.Text, txtDireccion.Text.ToUpper, txtTelefonos.Text)
    '                        Else
    '                            GenerateBoletosEventos(1, lblIDTransaccion.Text, CDbl(txtInicial.Text), txtNombre.Text, txtRNC.Text, txtDireccion.Text.ToUpper, txtTelefonos.Text)
    '                        End If
    '                    End If

    '                    DeshabilitarControles()
    '                    Hora.Enabled = False
    '                    lblStatusBar.ForeColor = Color.Black
    '                    lblStatusBar.Text = "Listo."
    '                    ImprimirDocumento()
    '                    LimpiarDatos()
    '                    ActualizarTodo()
    '                End If
    '            Else

    '                If Permisos(2) = 0 Then
    '                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    Exit Sub
    '                End If

    '                If IsModifiable(txtIDFactura.Text) Then
    '                Else
    '                    MessageBox.Show("Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad.", "La factura no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                    Exit Sub
    '                End If

    '                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '                If Result = MsgBoxResult.Yes Then
    '                    SumTotales()

    '                    GetTriedModifiedIDFactArt()
    '                    lblStatusBar.Text = "Buscando registros modificados no guardados."

    '                    lblStatusBar.Text = "Modificando registro de método de pago."
    '                    frm_formadepago.ShowDialog(Me)
    '                    If ControlSuperClave = 1 Then
    '                        Exit Sub
    '                    End If

    '                    lblStatusBar.Text = "Modificando registro de la base de datos."
    '                    CambiarBalance()
    '                    sqlQ = "UPDATE FacturaDatos SET IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text.ToUpper + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',IDChofer='" + CbxChofer.Tag.ToString + "',IDVehiculo='" + cbxVehiculo.Tag.ToString + "',IDVendedor='" + txtVendedor.Tag.ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',PagoAdicional='" + CDbl(txtAdicional.Text).ToString + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + CDbl(txtBalance.Text).ToString + "',Balance='" + CDbl(txtBalance.Text).ToString + "',FechaVencimiento='" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "',NotaContado='" + Convert.ToInt16(chkHabilitarNota.Checked).ToString + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuentoSuma.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',EntregarPorConduce='" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',HabilitarFicha='" + Convert.ToInt16(chkFichaDatos.Checked).ToString + "',Observacion='" + txtObservacion.Text + "',NoOrden='" + txtOrden.Text + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Tasa='" + CDbl(lblTasa.Text).ToString + "',Nulo='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
    '                    GuardarDatos()
    '                    InsertArticulos()
    '                    InsertPagares()
    '                    CalcInventario()
    '                    CalcularBalances()
    '                    CheckPrefacturas()

    '                    ToastNotificationsManager1.Notifications(1).Body = "La factura " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
    '                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

    '                    lblStatusBar.ForeColor = Color.Green
    '                    lblStatusBar.Text = "El registro fue modificado satisfactoriamente."
    '                    DeshabilitarControles()
    '                    Hora.Enabled = False
    '                    lblStatusBar.ForeColor = Color.Black
    '                    lblStatusBar.Text = "Listo."
    '                    ImprimirDocumento()
    '                    LimpiarDatos()
    '                    ActualizarTodo()
    '                End If
    '            End If
    '        Catch ex As Exception
    '            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
    '        End Try
    '    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cliente_factura.ShowDialog(Me)
    End Sub

    Private Sub CheckQuestions()
        If TablaQuestions.Rows.Count > 0 Then
            Con.Open()

            For Each dt As DataRow In TablaQuestions.Rows
                cmd = New MySqlCommand("INSERT INTO" & SysName.Text & "Factura_Preguntas (IDArticulo_Pregunta,IDFactura,IDArticulo,Respuesta) VALUES  ('" + dt.Item("idArticulos_preguntas").ToString + "','" + txtIDFactura.Text + "','" + dt.Item("IDArticulo").ToString + "','" + dt.Item("Respuesta").ToString + "')", Con)
                cmd.ExecuteNonQuery()
            Next

            Con.Close()
        End If
    End Sub
    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Dim CheckADC As New Label

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Verificar adicional
        If IsDate(txtFechaAdicional.Text) Then
            CheckADC.Text = CDate(txtFechaAdicional.Text).ToString("yyyy-MM-dd")
        Else
            CheckADC.Text = ""
        End If


        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La factura No. " & txtIDFactura.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 45
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkDesactivar.Checked = False
                sqlQ = "UPDATE FacturaDatos SET IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text.ToUpper + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',IDChofer='" + CbxChofer.Tag.ToString + "',IDVehiculo='" + cbxVehiculo.Tag.ToString + "',IDVendedor='" + txtVendedor.Tag.ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',PagoAdicional='" + CDbl(txtAdicional.Text).ToString + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + CDbl(txtBalance.Text).ToString + "',Balance='" + CDbl(txtBalance.Text).ToString + "',FechaVencimiento='" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "',NotaContado='" + Convert.ToInt16(chkHabilitarNota.Checked).ToString + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuentoSuma.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',EntregarPorConduce='" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',HabilitarFicha='" + Convert.ToInt16(chkFichaDatos.Checked).ToString + "',Observacion='" + txtObservacion.Text + "',Nulo='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "',ClasificacionAnulacion=NULL,MotivoAnulacion=NULL,IDUsuarioAnulador=NULL,FechaAnulacion=NULL WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalances()
                CalcInventario()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDFactura.Text = "" Then
            MessageBox.Show("No hay un registro de factura abierto para anular.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la factura No. " & txtIDFactura.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_facturacion_anulacion.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkDesactivar.Checked = True
                sqlQ = "UPDATE FacturaDatos SET IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text.ToUpper + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',IDChofer='" + CbxChofer.Tag.ToString + "',IDVehiculo='" + cbxVehiculo.Tag.ToString + "',IDVendedor='" + txtVendedor.Tag.ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',PagoAdicional='" + CDbl(txtAdicional.Text).ToString + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + CDbl(txtBalance.Text).ToString + "',Balance='" + CDbl(txtBalance.Text).ToString + "',FechaVencimiento='" + CDate(txtFechaVencimiento.Text).ToString("yyyy-MM-dd") + "',NotaContado='" + Convert.ToInt16(chkHabilitarNota.Checked).ToString + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + CDbl(txtSubTotal.Text).ToString + "',Descuento='" + CDbl(TxtDescuentoSuma.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',Flete='" + CDbl(txtFlete.Text).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text), NombreMoneda).ToString + "',EntregarPorConduce='" + Convert.ToInt16(chkEntregarporConduce.Checked).ToString + "',HabilitarFicha='" + Convert.ToInt16(chkFichaDatos.Checked).ToString + "',Observacion='" + txtObservacion.Text + "',Nulo='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "',ClasificacionAnulacion='" + frm_facturacion_anulacion.cbxClasificacion.Tag.ToString + "',MotivoAnulacion='" + frm_facturacion_anulacion.txtMotivos.Text + "',IDUsuarioAnulador='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',FechaAnulacion='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalances()
                CalcInventario()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub frm_facturacion_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub TabPagCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabPagCondicion.SelectedIndexChanged
        If TabPagCondicion.SelectedIndex = 1 Then
            btnVisualizarPagares.Visible = True
        Else
            btnVisualizarPagares.Visible = False
        End If
    End Sub

    Private Sub btnVisualizarPagares_Click(sender As Object, e As EventArgs) Handles btnVisualizarPagares.Click
        frm_visualizar_detalle_pagares.ShowDialog(Me)
    End Sub

    Private Sub txtDiasCondicion_Leave(sender As Object, e As EventArgs) Handles txtDiasCondicion.Leave
        If txtDiasCondicion.Text = "" Then
            txtDiasCondicion.Text = CInt(DTConfiguracion.Rows(52 - 1).Item("Value2Int"))
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
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

    Private Sub txtFechaAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtFechaAdicional.TextChanged
        If txtFechaAdicional.Text = "" Then
        Else
            txtFechaAdicional.Mask = "00/00/0000"
            txtFechaAdicional.SelectionStart = 1
        End If
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        If CDbl(lblDiasCondicion.Text) < 30 Then
            txtDiasCondicion.Text = lblDiasCondicion.Text
        Else
            txtDiasCondicion.Text = 30
        End If

        ConLibregco.Close()

        If lblDiasCondicion.Text = 0 Then
            SetIDTipoDocumento()
            AjCondContado()
        Else
            SetIDTipoDocumento()
            AjCondCredito()
            HabilitarEscCredito()
            CalcVencientoFactura()
        End If

        SumTotales()
    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        If GbClientes.Size.Height = 90 Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 187)
            txtNombre.Focus()
            txtNombre.SelectAll()
        Else
            GbClientes.Size = New Size(GbClientes.Size.Width, 90)
        End If
    End Sub

    Private Sub GbClientes_Leave(sender As Object, e As EventArgs) Handles GbClientes.Leave
        If GbClientes.Size.Height = 155 Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 90)
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvArticulosFactura.CellFormatting
        Try

            If e.ColumnIndex = Me.dgvArticulosFactura.Columns(12).Index AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvArticulosFactura.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    Dim IDAlmacen As String = dgvArticulosFactura.CurrentRow.Cells(12).Value

                    'If Con.State = ConnectionState.Open Then
                    '    Con.Close()
                    'End If

                    Con.Open()
                    cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                    Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    .ToolTipText = Almacen
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvArticulosFactura_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArticulosFactura.CellMouseMove
        If e.ColumnIndex = 12 Then
            If dgvArticulosFactura.Rows.Count = 0 Then
            Else
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 12 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = dgvArticulosFactura.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        If txtCodigoArticulo.Focused = False Then
            txtCodigoArticulo.Focus()
        Else
            txtCodigoArticulo.Focus()
            frm_buscar_mant_articulos.ShowDialog(Me)
        End If

    End Sub

    Private Sub ModificarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarClienteToolStripMenuItem.Click
        lblModificar_LinkClicked(lblModificar, Nothing)
    End Sub

    Private Sub lblModificar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblModificar.LinkClicked
        If GbClientes.Size.Height = 90 Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 187)
            txtNombre.Focus()
            txtNombre.SelectAll()
        Else
            GbClientes.Size = New Size(GbClientes.Size.Width, 90)
        End If
    End Sub

    Private Sub txtRNC_Leave(sender As Object, e As EventArgs) Handles txtRNC.Leave
        Dim Cedula As New Label
        Cedula.Text = Replace(txtRNC.Text, "-", "")

        If Cedula.Text = "" Then
        Else
            Dim Ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCliente,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,EntregarPorConduce,BalanceGeneral,Desactivar,ifnull((Select Fecha from Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM clientes INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal WHERE REPLACE(Identificacion,'-','')='" + txtRNC.Text.Replace("-", "") + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")
            If Tabla.Rows.Count = 0 Then
                Ds.Clear()
                ConUtilitarios.Open()
                cmd = New MySqlCommand("SELECT * FROM Libregco_Utilitarios.RncDgii WHERE RNC= '" + Cedula.Text + "'", ConUtilitarios)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "RncDgii")
                ConUtilitarios.Close()

                Dim TablaRNC As DataTable = Ds.Tables("RncDgii")

                If TablaRNC.Rows.Count = 0 Then
                    Dim ValueReplace As String
                    ValueReplace = Replace(txtRNC.Text, "_", "")
                    ValueReplace = Replace(ValueReplace, "-", "")

                    If ValueReplace.Trim <> "" Then
                        MessageBox.Show("El registro de cédula no se encuentra en la base de datos de la DGII.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    txtIDCliente.Text = 1
                    txtNombre.Text = (TablaRNC.Rows(0).Item("Nombre"))
                End If

                TablaRNC.Dispose()

            Else
                MessageBox.Show("La cédula introducida ya existe en la base de datos." & vbNewLine & vbNewLine & "Pertenece al cliente código No. [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & ".", "Existe en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                txtDireccion.Text = ((Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia")) & ".").ToString.ToUpper
                txtRNC.Text = Tabla.Rows(0).Item("Identificacion")
                txtTelefonos.Text = Tabla.Rows(0).Item("TelefonoPersonal")
                txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("LimiteCredito")).ToString("C")
                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                End If

                If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                    chkEntregarporConduce.Checked = True
                Else
                    chkEntregarporConduce.Checked = False
                End If
            End If

            Tabla.Dispose()
            Cedula.Dispose()
        End If


        Dim Masked As New MaskedTextBox
        Dim ValueFilt As String = txtRNC.Text.Replace("-", "")

        If Len(ValueFilt) = 9 Then
            Masked.Mask = "000-00000-0"
            Masked.Text = txtRNC.Text
            txtRNC.Text = Masked.Text
        ElseIf Len(ValueFilt) = 11 Then
            Masked.Mask = "000-0000000-0"
            Masked.Text = txtRNC.Text
            txtRNC.Text = Masked.Text
        Else
            txtRNC.Clear()
        End If

        Masked.Dispose()

    End Sub

    Private Sub ImpresiónDePagarésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónDePagarésToolStripMenuItem.Click
        If CInt(lblDiasCondicion.Text) > 0 Then
            If frm_pagares.Visible = True Then
                If frm_pagares.WindowState = FormWindowState.Minimized Then
                    frm_pagares.WindowState = FormWindowState.Normal
                Else
                    frm_pagares.Activate()
                End If
            Else
                frm_pagares.Show(Me)

                If txtIDFactura.Text <> "" Then
                    frm_pagares.lblIDFactura.Text = txtIDFactura.Text
                    frm_pagares.txtFactura.Text = txtSecondID.Text
                    frm_pagares.rdbPresentacion.Checked = True
                    frm_pagares.btnBuscar.PerformClick()
                End If

            End If
        End If

    End Sub

    Private Sub cbxPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio.SelectedIndexChanged
        Try
            If CbxMedida.Text <> "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtCodigoArticulo.Text + "' AND PrecioArticulo.IDMedida='" + CbxMedida.Tag.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
                cbxPrecio.Tag = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtCodigoArticulo.Text, CbxMedida.Tag.ToString, cbxMoneda.EditValue)).ToString("C")
            End If

            SumarTotalArticulo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_facturacion_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ControlRapido()
    End Sub

    Private Sub CheckPrefacturas()
        Try
            Con.Open()
            If IDPrefactura.Count > 0 Then
                For Each itm As String In IDPrefactura
                    'Actualizo el numero de factura generado en la tabla de prefacturacion
                    cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET Cierre=1,IDFacturaDatos='" + txtIDFactura.Text + "' WHERE IDPrefactura= (" + itm + ")", Con)
                    cmd.ExecuteNonQuery()

                    'Verifico si esa prefactura posee una cotizacion de fondo
                    cmd = New MySqlCommand("SELECT coalesce(IDCotizacion,'') as IDCotizacion FROM prefactura where IDPrefactura='" + itm + "'", Con)
                    Dim IDCotizacion As String = Convert.ToString(cmd.ExecuteScalar())

                    If IsNumeric(IDCotizacion) Then
                        'Si vino de una cotizacion actualizo el estado de la cotización
                        cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET IDCotizacion='" + IDCotizacion + "' WHERE IDPrefactura= (" + itm + ")", Con)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            Con.Close()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_facturacion_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If frm_accesos_rapidos_clientes.Visible = True Then
            If frm_accesos_rapidos_clientes.Owner.Name = Me.Name Then
                ControlRapido()
            End If
        End If

    End Sub

    Private Sub txtCodigoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCodigoArticulo.Text <> "" Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCodigoArticulo.Text <> "" Then
                If txtCodigoArticulo.SelectionStart = txtCodigoArticulo.TextLength Then
                    e.Handled = True
                    CbxMedida.Focus()
                    CbxMedida.DroppedDown = True
                End If
            End If
        End If
    End Sub

    Private Sub CbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtCodigoArticulo.Focus()
            txtCodigoArticulo.SelectAll()

        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtCantidadArticulo.SelectionStart = 0 Then
                CbxMedida.Focus()
                CbxMedida.DroppedDown = True
            End If

        ElseIf e.KeyCode = Keys.Right Then

            If txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength Then
                If txtDescripcionArticulo.ReadOnly = True Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                Else
                    e.Handled = True
                    txtDescripcionArticulo.Focus()
                    txtDescripcionArticulo.SelectAll()

                End If

            End If
        End If

    End Sub

    Private Sub cbxPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtDescripcionArticulo.ReadOnly = True Then
                e.Handled = True
                txtCantidadArticulo.Focus()
                txtCantidadArticulo.SelectAll()
            Else
                e.Handled = True
                txtDescripcionArticulo.Focus()
                txtDescripcionArticulo.SelectAll()
            End If


        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecio.SelectionStart = 0 Then
                cbxPrecio.Focus()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecio.SelectionStart = txtPrecio.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub frm_facturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            e.Handled = True
            btnGuardarC.PerformClick()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRNC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRNC.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789-"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frm_facturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.Owner.Name = frm_cierre_facturas.Name Then
            If frm_cierre_facturas.Visible = True Then
                If IDPrefactura.Count > 0 Then
                    Dim TmpConn As New MySqlConnection(CnGeneral)
                    TmpConn.Open()
                    For Each itm As String In IDPrefactura
                        cmd = New MySqlCommand("UPDATE" & SysName.Text & "PreFactura SET Usando=0 WHERE IDPrefactura=(" + itm + ")", TmpConn)
                        cmd.ExecuteNonQuery()
                    Next
                    TmpConn.Close()

                    TmpConn.Dispose()
                    frm_cierre_facturas.Activate()
                    frm_cierre_facturas.RefrescarTabla()
                    frm_cierre_facturas.ContarCheckeds()
                    IDPrefactura.Clear()
                End If

            End If



        ElseIf Me.Owner.Name = frm_inicio.Name Then
            If txtIDFactura.Text = "" Then
                If dgvArticulosFactura.Rows.Count > 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario de facturación?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result = MsgBoxResult.Yes Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If
            End If

        End If

        If Me.Owner.Name = frm_cierre_facturas.Name Then
            frm_cierre_facturas.Activate()
        End If
    End Sub

    Private Sub txtTelefonos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonos.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-0123456789 "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvArticulosFactura.RowsAdded
        If dgvArticulosFactura.Rows(e.RowIndex).Cells(14).Value = 1 Then
            dgvArticulosFactura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            dgvArticulosFactura.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkSalmon
            dgvArticulosFactura.Rows(e.RowIndex).Cells(7).Style.Font = New Font("Segoe UI", 7, FontStyle.Regular)
        End If

        If dgvArticulosFactura.Rows.Count > 0 Then
            cbxMoneda.Enabled = False
        Else
            cbxMoneda.Enabled = True
        End If
    End Sub

    Sub BloquearModificacionPrefactura()
        If CInt(DTConfiguracion.Rows(171 - 1).Item("Value2Int")) = 0 Then
            TbSelectProductos.Enabled = False
        Else
            TbSelectProductos.Enabled = True
        End If
    End Sub
End Class
