Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_impresiones_directas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand = New MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim ObjRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, TipoReporte, ModoDuplicidadHabilitado, ModoDuplicado, TipoPapel As New Label
    Dim DuplicadoCliente, DuplicadoDespacho, DuplicadoContabilidad As Boolean
    Private Sub frm_impresiones_directas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        Me.CenterToParent()
            VerificarTipoReporte()
            CargarLibregco()
            FillReportes()
            ChangetoTruePrintSecureEmployee()

            'If frm_inicio.WindowState = FormWindowState.Normal Then
        'Else
        '    'Me.WindowState = CheckWindowState()
        '    'End If
        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    'Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
    '    ObjRpt.Dispose()
    'End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='" + TipoReporte.Text + "' and Reportes.Activo=1 and PaperSize.Activo=1 and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub VerificarTipoReporte()
        If Me.Owner.Name = frm_facturacion.Name Then
            TipoReporte.Text = "Facturación"
        ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
            TipoReporte.Text = "Facturación"
        ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
            TipoReporte.Text = "ReciboAbono"
        ElseIf Me.Owner.Name = frm_contratos_clientes.Name Then
            TipoReporte.Text = "RegistroContrato"
        ElseIf Me.Owner.Name = frm_cotizacion.Name Then
            TipoReporte.Text = "Cotización"
        ElseIf Me.Owner.Name = frm_devolucion_fact.Name Then
            TipoReporte.Text = "Devolución Venta"
        ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
            TipoReporte.Text = "AjustesInv"
        ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
            TipoReporte.Text = "AjustesInv"
        ElseIf Me.Owner.Name = frm_conduce.Name Then
            TipoReporte.Text = "Conduce"
        ElseIf Me.Owner.Name = frm_transferencia_arts.Name Then
            TipoReporte.Text = "TransferenciasInv"
        ElseIf Me.Owner.Name = frm_orden_compras.Name Then
            TipoReporte.Text = "Orden Compra"
        ElseIf Me.Owner.Name = frm_pedidos.Name Then
            TipoReporte.Text = "Pedido"
        ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
            TipoReporte.Text = "ConducedeReparacion"
        ElseIf Me.Owner.Name = frm_registro_compras.Name Then
            TipoReporte.Text = "Compra"
        ElseIf Me.Owner.Name = frm_devolucion_compras.Name Then
            TipoReporte.Text = "DevCompra"
        ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
            TipoReporte.Text = "ConducedeReparacion"
        ElseIf Me.Owner.Name = frm_prefacturacion.Name Then
            TipoReporte.Text = "PickingList"
        ElseIf Me.Owner.Name = frm_mdi_prefacturacion.Name Then
            TipoReporte.Text = "PickingList"
        ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
            TipoReporte.Text = "Registros Facturas"
        ElseIf Me.Owner.Name = frm_notas_debito_credito.Name Then
            TipoReporte.Text = "NotaDebitoCreditocxc"
        ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
            TipoReporte.Text = "CobrosAdelantados"
        ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
            TipoReporte.Text = "OtrosIngresos"
        ElseIf Me.Owner.Name = frm_conduce_reparacion_entrada.Name Then
            TipoReporte.Text = "EntregasConduces"
        ElseIf Me.Owner.Name = frm_acuerdos_pago.Name Then
            TipoReporte.Text = "AcuerdodePago"
        ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
            TipoReporte.Text = "Cheques Devueltos"
        ElseIf Me.Owner.Name = frm_cheques_futuristas.Name Then
            TipoReporte.Text = "Cheques Futuros"
        ElseIf Me.Owner.Name = frm_mant_memos_cliente.Name Then
            TipoReporte.Text = "Solicitud"
        ElseIf Me.Owner.Name = frm_progreso_solicitudes.Name Then
            TipoReporte.Text = "Solicitud"
        ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
            TipoReporte.Text = "RegistroFacturaCXP"
        ElseIf Me.Owner.Name = frm_nota_debito_credito_cxp.Name Then
            TipoReporte.Text = "NotaDebitoCreditoCXP"
        ElseIf Me.Owner.Name = frm_recibos_egresos.Name Then
            TipoReporte.Text = "RecibosEgresosCXP"
        ElseIf Me.Owner.Name = frm_pago_compras.Name Then
            TipoReporte.Text = "ReciboPagoCompra"
        ElseIf Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
            TipoReporte.Text = "DeduccionesEmp"
        ElseIf Me.Owner.Name = frm_mant_prestamos_emp.Name Then
            TipoReporte.Text = "Prestamos"
        ElseIf Me.Owner.Name = frm_descontar_prestamos.Name Then
            TipoReporte.Text = "AbonoPrestamo"
        ElseIf Me.Owner.Name = frm_proceso_nomina.Name Then
            TipoReporte.Text = "Nomina"
        ElseIf Me.Owner.Name = frm_solicitud_cheques.Name Then
            TipoReporte.Text = "SolicitudCheques"
        ElseIf Me.Owner.Name = frm_cheques.Name Then
            TipoReporte.Text = "ChequesImpresion"
        ElseIf Me.Owner.Name = frm_movimientos_bancarios.Name Then
            TipoReporte.Text = "MovimientosBancarios"
        ElseIf Me.Owner.Name = frm_historial_recibos_cliente.Name Then
            TipoReporte.Text = "RecibosCobroDetalle"
        ElseIf Me.Owner.Name = frm_generacion_nuevos_recibos.Name Then
            TipoReporte.Text = "RecibosCobro"
        ElseIf Me.Owner.Name = frm_entrega_cobro.Name Then
            TipoReporte.Text = "EntregaCobros"
        ElseIf Me.Owner.Name = frm_cargo_pagareses.Name Then
            TipoReporte.Text = "Titulaciones"
        ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then
            TipoReporte.Text = "Titulaciones"
        ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then
            TipoReporte.Text = "Titulaciones"
        ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
            TipoReporte.Text = "Titulaciones"
        ElseIf Me.Owner.Name = frm_grupo_cierre_recibos.Name Then
            TipoReporte.Text = "RecibosCierre"
        ElseIf Me.Owner.Name = frm_consulta_numero_recibo.Name Then
            TipoReporte.Text = "RecibosCierre"
        ElseIf Me.Owner.Name = frm_historial_recibos_cliente.Name Then
            TipoReporte.Text = "DetalleCobros"
        ElseIf Me.Owner.Name = frm_talonarios_cobro.Name Then
            TipoReporte.Text = "TalonarioRecibos"
        ElseIf Me.Owner.Name = frm_listado_articulos.Name Then
            TipoReporte.Text = "ListaArticulos"
        ElseIf Me.Owner.Name = frm_deposito_factura.Name Then
            TipoReporte.Text = "DepositoFactura"
        ElseIf Me.Owner.Name = frm_financiamiento.Name Then
            If frm_financiamiento.TipodeImpresion = 1 Then
                TipoReporte.Text = "Financiamientos"
            ElseIf frm_financiamiento.TipodeImpresion = 2 Then
                TipoReporte.Text = "ImpresionCuotasFinanciamientos"
            End If
        ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
            TipoReporte.Text = "PagosFinanciamientos"
        ElseIf Me.Owner.Name = frm_corte_caja.Name Then
            TipoReporte.Text = "CortedeCaja"
        End If
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")
            IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
            NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
            PathReport.Text = (Tabla.Rows(0).Item("Path"))
            ModoDuplicado.Text = Tabla.Rows(0).Item("ModoDuplicado")
            TipoPapel.Text = (Tabla.Rows(0).Item("IDPaperName"))

            If ModoDuplicado.Text = 1 Then
                'Con.Open()
                'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=160", Con)
                ModoDuplicidadHabilitado.Text = DTConfiguracion.Rows(160 - 1).Item("Value2Int")
                'Con.Close()

                VisorDocumento.ShowPrintButton = False

                If ModoDuplicidadHabilitado.Text = 1 Then
                    PanelDuplicidad.Visible = True
                    lblStatusBar.Text = "El reporte seleccionado tiene activado el modo de duplicidad."

                    'Con.Open()
                    'Habilitar impresion de clientes
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=161", Con)
                    DuplicadoCliente = Convert.ToBoolean(CInt(DTConfiguracion.Rows(161 - 1).Item("Value2Int")))

                    If DuplicadoCliente = True Then
                        chkDuplicado.Enabled = True
                        chkDuplicado.Checked = True
                    Else
                        chkDuplicado.Enabled = False
                        chkDuplicado.Checked = False
                    End If

                    'Habilitar impresion de despacho
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=162", Con)
                    DuplicadoDespacho = Convert.ToBoolean(CInt(DTConfiguracion.Rows(162 - 1).Item("Value2Int")))

                    If DuplicadoDespacho = True Then
                        chkDespacho.Enabled = True
                        chkDespacho.Checked = True
                    Else
                        chkDespacho.Enabled = False
                        chkDespacho.Checked = False
                    End If

                    'Habilitar impresion de contabilidad
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=163", Con)
                    DuplicadoContabilidad = Convert.ToBoolean(CInt(DTConfiguracion.Rows(163 - 1).Item("Value2Int")))

                    If DuplicadoContabilidad = True Then
                        chkContabilidad.Enabled = True
                        chkContabilidad.Checked = True
                    Else
                        chkContabilidad.Enabled = False
                        chkContabilidad.Checked = False
                    End If


                    Con.Close()

                    If Me.Owner.Name = frm_facturacion.Name Then

                        If CInt(DTConfiguracion.Rows(172 - 1).Item("Value2Int")) = 0 Then

                            If frm_facturacion.EstadoImpresion = 1 Then
                                chkOriginal.Checked = False
                                chkOriginal.Enabled = False
                            Else
                                chkOriginal.Checked = True
                                chkOriginal.Enabled = True
                            End If

                        Else
                            chkOriginal.Checked = True
                            chkOriginal.Enabled = True
                        End If

                        If frm_facturacion.lblDiasCondicion.Text = 0 Then
                            chkDuplicado.Checked = False
                        Else
                            chkDuplicado.Checked = True
                        End If
                    End If

                Else
                    lblStatusBar.Text = "El modo de impresión en duplicidad está deshabilitado del sistema."
                    PanelDuplicidad.Visible = False
                End If

            Else
                lblStatusBar.Text = "Listo."
                PanelDuplicidad.Visible = False

                VisorDocumento.ShowPrintButton = True
            End If

            VisualizarReporte()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

    Private Sub LoadAnimation()

        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If

    End Sub

    Private Sub VisualizarReporte()
        'Try
        Dim DsSP As New DataSet
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            VisorDocumento.Cursor = Cursors.AppStarting

            'Disposing crystal elements
            VisorDocumento.ReportSource = Nothing


            'Loading File Path
            If TypeConnection.Text = 1 Then
                ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

        'Passing Paramteres 'Hide Selection'
        If Me.Owner.Name = frm_facturacion.Name Then
            'crParameterDiscreteValue.Value = frm_facturacion.txtIDFactura.Text
            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("call" & SysName.Text & "facturadatosview(" + frm_facturacion.txtIDFactura.Text + ");", Con)
            AdaptadorSP.Fill(DsSP, "FacturaDatosView")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            'Para facturas a credito
            'Lleando pagaresView
            AdaptadorSP = New MySqlDataAdapter("SELECT IDPagare,Pagares.IDFactura,NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento as VencimientoPagares,Pagares.DiasVencidos as DiasVencidosPagares,Concepto,Pagares.Monto,Pagares.Balance as BalancePagares,Pagares.Nulo,GROUP_CONCAT(FacturaArticulos.Descripcion,'') AS DescripcionArticulos FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura Where Pagares.IDFactura='" + frm_facturacion.txtIDFactura.Text + "' GROUP BY Pagares.IDPagare", Con)
            AdaptadorSP.Fill(DsSP, "ListadoPagaresView")

            'Lleando balances_clientes_view
            AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + frm_facturacion.txtIDCliente.Text + ");", Con)
            AdaptadorSP.Fill(DsSP, "balances_clientes")

            'Lleando garantaias
            'Esta consulta busca terminos para todos los articulos introducidos
            AdaptadorSP = New MySqlDataAdapter("Select * from (SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.idarticulo=articulos_garantia.idarticulo Where FacturaArticulos.IDFactura='" + frm_facturacion.txtIDFactura.Text + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDSubcategoria=articulos_garantia.IDSubCategoria Where FacturaArticulos.IDFactura='" + frm_facturacion.txtIDFactura.Text + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDCategoria=articulos_garantia.IDCategoria Where FacturaArticulos.IDFactura='" + frm_facturacion.txtIDFactura.Text + "') AS Resultados  Group by Resultados.idArticulos_garantia ORDER BY Resultados.Orden", ConMixta)
            AdaptadorSP.Fill(DsSP, "GarantiaArticulosView")

            For Each crReportObject In ObjRpt.Subreports
                If CType(crReportObject, ReportDocument).Name = "subreport_preguntas" Then
                    'Lleando garantaias
                    AdaptadorSP = New MySqlDataAdapter("SELECT idFactura_Preguntas,factura_preguntas.IDArticulo_Pregunta,factura_preguntas.IDFactura,factura_preguntas.IDArticulo,Titulo,Descripcion,Respuesta FROM" & SysName.Text & "factura_preguntas inner join Libregco.articulos_preguntas on factura_preguntas.IDArticulo_Pregunta=articulos_preguntas.idArticulos_preguntas Where IDFactura='" + frm_facturacion.txtIDFactura.Text + "'", ConMixta)
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

        ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
            crParameterDiscreteValue.Value = frm_punto_venta_lite.lblIDFactura.Text
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos del abono   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT Abonos.IDAbono,Abonos.IDSucursal,Sucursal.Sucursal,Sucursal.Direccion as DireccionSucursal,Sucursal.Provincia,Sucursal.Municipio,Sucursal.Telefono,Sucursal.Telefono1,Sucursal.Telefono2,Sucursal.Fax,Sucursal.Email,Abonos.IDAlmacen,Almacen.Almacen,Abonos.SecondID as SecondIDAbono,Abonos.IDTipoDocumento,TipoDocumento.Documento,Abonos.IDCliente,Clientes.Nombre,Clientes.Direccion,Clientes.Identificacion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Abonos.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Texto,TipoMoneda.MonedaImagen,Transaccion.Efectivo,Transaccion.Cheque,Transaccion.Deposito,Transaccion.Informacion,IDCredito,Transaccion.Credito,ClaseTarjeta,Transaccion.Tarjeta,TipoTarjeta,NoAprobacion,Recibido,MontoCobrar,Devuelta,Abonos.IDEmpleado,Usuarios.Nombre as NombreUsuario,Usuarios.Login,Abonos.Fecha,Abonos.Hora,Abonos.BalanceAnterior as BalanceAnteriorGeneral,DetalleAbonos.CargosAnterior,Abonos.Concepto,Abonos.Debito,Abonos.Descuento,Abonos.Total as TotalAbono,SumaLetra,Abonos.Impreso,Abonos.Nulo,IDDetalleAbono,IDFactura,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.Fecha as FechaFactura,FacturaDatos.Hora as HoraFactura,FacturaDatos.Balance,DetalleAbonos.BalanceAnterior as BalanceAnteriorFactura,DetalleAbonos.DiasVencidos as DiasVencidosenPago,DetalleAbonos.Debito as DebitoDetalle,DetalleAbonos.Cargos as CargosDetalle,DetalleAbonos.CargosExcento,DetalleAbonos.Descuento as DescuentoDetalle,DetalleAbonos.Total as TotalDetalleAbono,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,(Select Value1Var from Configuracion Where IDConfiguracion=6) as EncabezadodeCobro,(Select Value1Var from Configuracion Where IDConfiguracion=7) as PiedeCobro FROM" & SysName.Text & "Abonos INNER JOIN" & SysName.Text & "Sucursal on Abonos.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on Abonos.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Transaccion on Abonos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Empleados as Usuarios on Abonos.IDEmpleado=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Detalleabonos on Abonos.IDAbono=DetalleAbonos.IDAbono INNER JOIN" & SysName.Text & "FacturaDatos on DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where Abonos.IDAbono='" + frm_recibo_pagos.txtIDPago.Text + "'", Con)
            AdaptadorSP.Fill(DsSP, "AbonosView")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            'Lleando balances_clientes_view
            AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + frm_recibo_pagos.txtIDCliente.Text + ");", Con)
            AdaptadorSP.Fill(DsSP, "balances_clientes")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("abonosview1").SetDataSource(DsSP.Tables("AbonosView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
            ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))

            'crParameterDiscreteValue.Value = frm_recibo_pagos.txtIDPago.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_contratos_clientes.Name Then

            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            'Llenado ContratosView
            AdaptadorSP = New MySqlDataAdapter("SELECT contratos.IDContrato,contratos.IDUsuario,Usuarios.Nombre as NombreUsuario,contratos.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,contratos.IDTipoDocumento,TipoDocumento.Documento,contratos.SecondID,contratos.NoContrato,contratos.IDCliente,contratos.Folio,contratos.Fecha as FechaContrato,contratos.IDPlazoVencimiento,PlazoContrato.Plazo,PlazoContrato.Meses,contratos.FechaVencimiento,contratos.Observaciones FROM libregco.contratos INNER JOIN" & SysName.Text & "Empleados as Usuarios on Contratos.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on Contratos.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "TipoDocumento on Contratos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Clientes on Contratos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.PlazoContrato on Contratos.IDPlazoVencimiento=PlazoContrato.IDPlazoContrato Where Contratos.IDContrato='" + frm_contratos_clientes.txtIDContrato.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "ContratosView")

            'Llenado ContratosView
            AdaptadorSP = New MySqlDataAdapter("SELECT IDCliente,Clientes.IDTratamiento,Tratamiento.Tratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Nacionalidad.Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.CorreoElectronico,Clientes.Sueldo,Vivienda,NumeroTiempoAlquilado,TiempoAlquilado,TipoVivienda,Vehiculo,TrabajoActivo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,SeguroMedico,CuentasBancaria,EntidadBancariaCuenta,Tarjeta,EntidadBancariaTarjeta,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,DedicacionAutoEmpleado,OrigenPagos,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,CalificacionAutonoma,xCore,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Empleados.TelefonoPersonal as TelefonoPersonalEmpleado,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobrador,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Clientes.IDCondicionCliente,Condicion.Condicion,InformacionAdc,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,BalanceGeneral,BalanceGeneralLetras,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,Clientes.IDRegistrador,Registrador.Nombre as NombreRegistrador,Clientes.IDUsuarioModificador,Modificador.Nombre as NombreModificador FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Registrador on Clientes.IDRegistrador=Registrador.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Modificador on Clientes.IDUsuarioModificador=Modificador.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento INNER JOIN Libregco.Condicion on Clientes.IDCondicionCliente=Condicion.IDCondicion Where Clientes.IDCliente='" + frm_contratos_clientes.txtIDCliente.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "ListadoClientesView")

            'Llenado listado de referencias
            AdaptadorSP = New MySqlDataAdapter("SELECT IDReferencias,Referencias.IDCliente,Clientes.Nombre as NombreCliente,IDRelacion,RelacionFamiliar.Relacion,Referencias.Nombre,Referencias.Direccion,Referencias.Telefono FROM libregco.referencias INNER JOIN Libregco.RelacionFamiliar on Referencias.IDRelacion=RelacionFamiliar.IDRelacionFamiliar INNER JOIN Libregco.Clientes on Referencias.IDCliente=Clientes.IDCliente Where Clientes.IDCliente='" + frm_contratos_clientes.txtIDCliente.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "ListadoReferenciasView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()


            ObjRpt.Database.Tables("contratosview1").SetDataSource(DsSP.Tables("ContratosView"))
            ObjRpt.Database.Tables("listadoclientesview1").SetDataSource(DsSP.Tables("ListadoClientesView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
            ObjRpt.Subreports("sub_reporte_referencias.rpt").SetDataSource(DsSP.Tables("ListadoReferenciasView"))

            'crParameterDiscreteValue.Value = frm_contratos_clientes.txtIDContrato.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_cotizacion.Name Then
            'crParameterDiscreteValue.Value = frm_cotizacion.txtIDCotizacion.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la cotizacion   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT Cotizacion.IDCotizacion,Cotizacion.SecondID,Cotizacion.IDTipoDocumento,TipoDocumento.Documento,Cotizacion.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.IDMunicipio,Municipios.Municipio,Clientes.IDProvincia,Provincias.Provincia,NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,Clientes.BalanceGeneral,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,Clientes.IDCalificacion,Calificacion,Fecha,Hora,Cotizacion.IDCondicion,Condicion.Condicion,Cotizacion.IDUsuario,Usuarios.Nombre as NombreUsuario,IDVendedor,Vendedor.Nombre as NombreVendedor,Comentario,SubTotal,Cotizacion.Descuento AS DescuentoCotizacion,Cotizacion.Itbis as ItbisCotizacion,Flete,TotalNeto,Cotizacion.Impreso,Cotizacion.Nulo,CotizacionDetalle.Cantidad,CotizacionDetalle.IDMedida,Medida.Medida,Medida.Abreviatura,CotizacionDetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia,CotizacionDetalle.PrecioUnitario,CotizacionDetalle.Descuento as DescuentoArticulo,CotizacionDetalle.Itbis as ItbisArticulo,CotizacionDetalle.Importe,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Cotizacion.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(Select Value1Var from" & SysName.Text & "Configuracion Where IDConfiguracion=53) as EncabezadodeCotizacion,(Select Value1Var from" & SysName.Text & "Configuracion Where IDConfiguracion=54) as PiedeCotizacion FROM" & SysName.Text & "Cotizacion INNER JOIN" & SysName.Text & "TipoDocumento on Cotizacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Provincias ON Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios ON Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Cotizacion.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on Cotizacion.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.Condicion on Cotizacion.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "CotizacionDetalle on Cotizacion.IDCotizacion=CotizacionDetalle.IDCotizacion INNER JOIN Libregco.Medida on CotizacionDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos on CotizacionDetalle.IDArticulo=Articulos.IDArticulo WHERE Cotizacion.IDCotizacion='" + frm_cotizacion.txtIDCotizacion.Text + "'", Con)
            AdaptadorSP.Fill(DsSP, "CotizacionView")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("cotizacionview1").SetDataSource(DsSP.Tables("CotizacionView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

        ElseIf Me.Owner.Name = frm_devolucion_fact.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la cotizacion   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.IDTipoDocumento,Documento,DevolucionVenta.SecondID as SecondIDDevolucion,DevolucionVenta.IDUsuario,Usuarios.Nombre as NombreUsuario,DevolucionVenta.Fecha,DevolucionVenta.Hora,DevolucionVenta.IDSucursal,DevolucionVenta.IDAlmacen,Almacen.Almacen,DevolucionVenta.NCF,DevolucionVenta.IDFactura,FacturaDatos.SecondID AS SecondIDFact,FacturaDatos.Fecha as FechaFactura,FacturaDatos.NCF AS NCFFactura,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDCliente,Clientes.Nombre as NombreCliente,FacturaDatos.NombreFactura,Clientes.Identificacion,IdentificacionFactura,Clientes.Direccion,DireccionFactura,Provincias.Provincia,Municipios.Municipio,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,FacturaDatos.TelefonosFactura,Clientes.BalanceGeneral,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,DiasTransaccion,DevolucionVenta.IDTipoDevolucion,TipoDevolucion.Tipo,DevolucionVenta.IDMotivoDevolucion,MotivoDevolucion.Descripcion as MotivoDevolucion,DevolverItbis,DevolucionVenta.Subtotal,DevolucionVenta.Itbis,DevolucionVenta.Neto,Devolver,DevolucionVenta.Impreso,DevolucionVenta.Nulo,Devolucionventadetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Devolucionventadetalle.IDMedida,Medida.Medida,CantDevuelta,PrecioDevuelto,DevolucionVentaDetalle.Itbis as ItbisArt,DevolucionVentaDetalle.IDAlmacen as IDAlmacenArticulo,AlmacenArticulo.Almacen as AlmacenArticulo FROM" & SysName.Text & "devolucionventa INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "DevolucionVentaDetalle on DevolucionVenta.IDDevolucionVenta=DevolucionVentaDetalle.IDDevolucionVenta INNER JOIN Libregco.Articulos on DevolucionVentaDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on DevolucionVentaDetalle.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "Empleados as Usuarios on DevolucionVenta.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionVenta.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.MotivoDevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN Libregco.TipoDevolucion on DevolucionVenta.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "Almacen as AlmacenArticulo on DevolucionVentaDetalle.IDAlmacen=AlmacenArticulo.IDAlmacen INNER JOIN" & SysName.Text & "Almacen on DevolucionVenta.IDAlmacen=Almacen.IDAlmacen WHERE DevolucionVenta.IDDevolucionVenta='" + frm_devolucion_fact.txtIDDevolucion.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "DevolucionVentaView")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            For Each crReportObject In ObjRpt.Subreports
                If CType(crReportObject, ReportDocument).Name = "balances_clientes_formato.rpt" Then
                    'Lleando balances_clientes_view
                    AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + frm_devolucion_fact.txtIDCliente.Text + ");", Con)
                    AdaptadorSP.Fill(DsSP, "balances_clientes")

                    ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))
                End If

            Next

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("devolucionventaview1").SetDataSource(DsSP.Tables("DevolucionVentaView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


        ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
            crParameterDiscreteValue.Value = frm_ajuste_inventario.txtIDAjuste.Text

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
            crParameterDiscreteValue.Value = frm_inv_inicial.txtIDAjuste.Text

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_conduce.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la cotizacion   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("Select Conduce.IDConduce,Conduce.IDTipoDocumento,TipoDocumento.Documento,Conduce.SecondID,Conduce.IDUsuario,Usuarios.Nombre as NombreUsuario,Conduce.IDFacturaDatos,FacturaDatos.SecondID AS SecondIDFact,FacturaDatos.Fecha as FechaFact,FacturaDatos.Hora as HoraFact,FacturaDatos.IDAlmacen,Almacen.Almacen,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,Conduce.Fecha,Conduce.Hora,FacturaDatos.IDCliente,FacturaDatos.NombreFactura AS Nombre,FacturaDatos.IdentificacionFactura as Identificacion,FacturaDatos.DireccionFactura as Direccion,NombreFactura,DireccionFactura,TelefonosFactura,IdentificacionFactura,Conduce.Entregado,Conduce.Observacion,Conduce.SubTotal,Conduce.Itbis,Conduce.Neto,Conduce.Nulo,Conduce.Impreso,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,Articulos.Referencia,FacturaArticulos.IDPrecio as IDPrecioVendida,PrecioArticuloVendido.Contenido as ContenidoVendido,FacturaArticulos.Cantidad as CantidadVendida,FacturaArticulos.IDMedida,MedidaComprada.Medida as MedidaVendida,ConduceDetalle.IDPrecio as IDPrecioEntregado,PrecioArticuloEntregada.IDMedida as IDMedidaEntregada,PrecioArticuloEntregada.Contenido as ContenidoEntregado,ConduceDetalle.Entregar as CantidadEntregada,MedidaEntregada.Medida as MedidaEntregada,ConduceDetalle.Precio as PrecioArticulo,ConduceDetalle.Itbis as ItbisArticulo,ConduceDetalle.Importe as ImporteArticulo,FacturaArticulos.Itbis as ItbisArt,FacturaArticulos.Importe,MostrarPrecios,round(((Cantidad*PrecioArticuloVendido.contenido)-(select coalesce(Sum(Entregar*PrecioArticuloConduce.Contenido),0) from" & SysName.Text & "ConduceDetalle inner join Libregco.PrecioArticulo as PrecioArticuloConduce on ConduceDetalle.IDPrecio=PrecioArticuloConduce.IDPrecios Where FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt))/PrecioArticulo.Contenido,4) as Disponible from" & SysName.Text & "FacturaArticulos INNER JOIN" & SysName.Text & "FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "ConduceDetalle on FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt INNER JOIN" & SysName.Text & "Conduce on ConduceDetalle.IDConduce=Conduce.IDConduce INNER JOIN" & SysName.Text & "TipoDocumento on Conduce.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on Conduce.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloVendido on FacturaArticulos.IDPrecio=PrecioArticuloVendido.IDPrecios INNER JOIN Libregco.Medida as MedidaComprada on FacturaArticulos.IDMedida=MedidaComprada.IDMedida INNER JOIN Libregco.PrecioArticulo as PrecioArticuloEntregada on ConduceDetalle.IDPrecio=PrecioArticuloEntregada.IDPrecios INNER JOIN Libregco.Medida as MedidaEntregada on PrecioArticuloEntregada.IDMedida=MedidaEntregada.IDMedida WHERE Conduce.IDConduce='" + frm_conduce.txtIDConduce.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "ConducesView")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("conducesview1").SetDataSource(DsSP.Tables("ConducesView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

            'crParameterDiscreteValue.Value = frm_conduce.txtIDConduce.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_transferencia_arts.Name Then
            crParameterDiscreteValue.Value = frm_transferencia_arts.txtIDTransferenciaArt.Text

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_orden_compras.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la orden de compra   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT OrdenCompra.IDOrdenCompra,OrdenCompra.IDTipoDocumento,TipoDocumento.Documento,SecondID,Fecha,Hora,IDUsuario,Usuarios.Nombre as NombreUsuario,OrdenCompra.IDSuplidor,Suplidor.Suplidor,Suplidor.Rnc,Suplidor.Direccion,Suplidor.Telefono,Suplidor.TelefonoRepresentante,Suplidor.Representante,IDTipoOrden,OrdenCompra.Referencia as ReferenciaOrden,OrdenCompra.Comentario,(if(TipoItbis=1,'Itbis incluído','No incluído')) as TipoItbis,OrdenCompra.SubtotalOrden,OrdenCompra.ItbisOrden,OrdenCompra.Total,OrdenCompra.Impreso,OrdenCompra.Nulo,OrdenCompraDetalle.IDArticulo,OrdenCompraDetalle.IDMedida,Medida.Medida,Cantidad,Articulos.Descripcion,Articulos.Referencia as ReferenciaArt,OrdenCompraDetalle.SubtotalDetalle,OrdenCompraDetalle.ItbisDetalle,OrdenCompraDetalle.Precio,OrdenCompraDetalle.Importe FROM" & SysName.Text & "ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "OrdenCompraDetalle on OrdenCompra.IDOrdenCompra=OrdenCompraDetalle.IDOrdenCompra INNER JOIN Libregco.Articulos on OrdenCompraDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on OrdenCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "Empleados as Usuarios on OrdenCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on OrdenCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where OrdenCompra.IDOrdenCompra='" + frm_orden_compras.txtIDOrdenCompra.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "OrdenCompraView")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("ordencompraview1").SetDataSource(DsSP.Tables("OrdenCompraView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


            'crParameterDiscreteValue.Value = frm_orden_compras.txtIDOrdenCompra.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_pedidos.Name Then
            crParameterDiscreteValue.Value = frm_pedidos.txtIDPedido.Text

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
            crParameterDiscreteValue.Value = frm_conduce_reparaciones.txtIDReparacion.Text

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_registro_compras.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la compra   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT Compras.IDCompra,Compras.IDTipoDocumento,TipoDocumento.Documento,Compras.SecondID,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.Rnc,Suplidor.Direccion,Suplidor.Telefono,Suplidor.Fax,Suplidor.Representante,Suplidor.TelefonoRepresentante,Compras.IDUsuario,Usuario.Nombre as NombreUsuario,Compras.Fecha,Compras.Hora,Compras.IDCondicion,Condicion.Condicion,Compras.FechaFactura,Compras.FechaVencimiento,Compras.NoFactura,Compras.Referencia,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.TipoItbis,Compras.IDAlmacen,Almacen.Almacen,Compras.SubTotal,Compras.Descuento,Compras.Descuento2,Compras.Itbis,Compras.Flete,Compras.TotalNeto,Compras.IDEmpleadoRec,EmpleadosRecepcion.Nombre as NombreRecepcion,Compras.DiaRecepcion,Compras.Balance,Compras.RutaDocumento,Compras.Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,Compras.Impreso,Compras.Nulo,DetalleCompra.IDArticulo,Articulos.Descripcion,Articulos.Referencia as ReferenciaArt,Articulos.RutaFoto as RutaArticulo,DetalleCompra.IDMedida,Medida.Medida,DetalleCompra.Cantidad,DetalleCompra.PrecioUnitario,DetalleCompra.Descuento as DescuentoArt,DetalleCompra.Descuento2 as Descuento2Art,DetalleCompra.Itbis as ItbisArt,DetalleCompra.Importe,DetalleCompra.CostoFinal,(Select DetalleCompra.CostoFinal from" & SysName.Text & "DetalleCompra Where DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios and DetalleCompra.IDCompra<Compras.IDCompra ORDER BY IDCompra DESC LIMIT 1) as CostoFinalAntesdeCompra,PrecioArticulo.Contenido,PrecioArticulo.Costo as CostoPrecioArticulo,PrecioArticulo.CostoFinal as CostoFinalArticulo,PrecioArticulo.DescuentoMaximo,PrecioArticulo.PrecioContado,PrecioArticulo.PrecioCredito,PrecioArticulo.Precio3,PrecioArticulo.Precio4,DetalleCompra.IDAlmacen as IDAlmacenArticulo,AlmacenArticulo.Almacen as AlmacenArticulo,DetalleCompra.Orden FROM" & SysName.Text & "compras  INNER JOIN" & SysName.Text & "TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Empleados as Usuario on Compras.IDUsuario=Usuario.IDEmpleado INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Empleados as EmpleadosRecepcion on Compras.IDEmpleadoRec=EmpleadosRecepcion.IDEmpleado INNER JOIN" & SysName.Text & "DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra INNER JOIN" & SysName.Text & "Almacen as AlmacenArticulo on DetalleCompra.IDAlmacen=AlmacenArticulo.IDAlmacen INNER JOIN Libregco.Articulos on DetalleCompra.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida INNER JOIN Libregco.PrecioArticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios where Compras.IDCompra='" + frm_registro_compras.txtIDCompra.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "ComprasView")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("comprasView1").SetDataSource(DsSP.Tables("ComprasView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


            'crParameterDiscreteValue.Value = frm_registro_compras.txtIDCompra.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_devolucion_compras.Name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la devolucion compra   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT devolucioncompra.IDDevolucionCompra,devolucioncompra.IDTipoDocumento,TipoDocumento.Documento,devolucioncompra.SecondID AS SecondIDDevCompra,devolucioncompra.IDUsuario,Usuarios.Nombre as NombreUsuario,Devolucioncompra.Fecha,Devolucioncompra.Hora,DevolucionCompra.IDSucursal,DevolucionCompra.IDAlmacen,Almacen.Almacen,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Suplidor.Direccion,Suplidor.Telefono,Suplidor.Fax,Suplidor.Representante,Suplidor.TelefonoRepresentante,devolucioncompra.IDFactura,Compras.SecondID AS SecondIDFact,Compras.FechaFactura,Compras.NoFactura,Compras.IDComprobanteFiscal as IDNCFCompra,Compras.NCF as NCFFact,DevolucionCompra.NCF AS NCFDevolucionCompra,DevolucionCompra.IDMotivoDevolucion,MotivoDevolucion.Descripcion as MotivoDevolucion,DevolucionCompra.DevolverItbis,DevolucionCompra.Devolver,DevolucionCompra.Itbis,DevolucionCompra.Neto,DevolucionCompra.DiasTransaccion,DevolucionCompra.Impreso,DevolucionCompra.Nulo,devolucioncompradetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia as ReferenciaArt,devolucioncompradetalle.IDMedida,Medida.Medida,CantDevuelta,PrecioDevuelto,DevolucionCompraDetalle.IDAlmacen as IDAlmacenArticulo,AlmacenArticulo.Almacen as AlmacenArticulo FROM" & SysName.Text & "devolucioncompra INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN" & SysName.Text & "Empleados as Usuarios on DevolucionCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.MotivoDevolucion on DevolucionCompra.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "DevolucionCompraDetalle on DevolucionCompra.IDDevolucionCompra=DevolucionCompraDetalle.IDDevolucionCompra INNER JOIN Libregco.Articulos on DevolucionCompraDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on DevolucionCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Almacen on DevolucionCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenArticulo on DevolucionCompraDetalle.IDAlmacen=AlmacenArticulo.IDAlmacen Where devolucioncompra.IDDevolucionCompra='" + frm_devolucion_compras.txtIDDevolucion.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "DevolucionCompraView")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Llenado EmpresaView
            AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
            AdaptadorSP.Fill(DsSP, "EmpresaView")

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("devolucioncompraview1").SetDataSource(DsSP.Tables("DevolucionCompraView"))
            ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


            'crParameterDiscreteValue.Value = frm_registro_compras.txtIDCompra.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'crParameterDiscreteValue.Value = frm_devolucion_compras.txtIDDevolucion.Text

            'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
            'crParameterValues.Add(crParameterDiscreteValue)
            'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        ElseIf Me.Owner.Name = frm_prefacturacion.name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la prefactura  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT Prefactura.IDPreFactura,SecondID,Fecha,Hora,TotalNeto,PrefacturaArticulos.IDArticulo,IDMedida,Medida,Cantidad,PrefacturaArticulos.Descripcion,Articulos.Referencia,PrecioUnitario,Descuento,Itbis,Importe,NoOrden,Nulo FROM" & SysName.Text & "prefactura INNER JOIN" & SysName.Text & "prefacturaarticulos on Prefactura.IDPrefactura=PrefacturaArticulos.IDPrefactura INNER JOIN Libregco.Articulos on PrefacturaArticulos.IDArticulo=Articulos.IDArticulo Where Prefactura.IDPrefactura='" + frm_prefacturacion.txtIDFactura.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "PrefacturaView")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("Prefactura_DATA").SetDataSource(DsSP.Tables("PrefacturaView"))

        ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
            Dim cmdSP As New MySqlCommand
            Dim AdaptadorSP As MySqlDataAdapter

            'Consulta de los datos de la prefactura  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            AdaptadorSP = New MySqlDataAdapter("SELECT Prefactura.IDPreFactura,SecondID,Fecha,Hora,TotalNeto,PrefacturaArticulos.IDArticulo,IDMedida,Medida,Cantidad,PrefacturaArticulos.Descripcion,Articulos.Referencia,PrecioUnitario,Descuento,Itbis,Importe,NoOrden,Nulo FROM" & SysName.Text & "prefactura INNER JOIN" & SysName.Text & "prefacturaarticulos on Prefactura.IDPrefactura=PrefacturaArticulos.IDPrefactura INNER JOIN Libregco.Articulos on PrefacturaArticulos.IDArticulo=Articulos.IDArticulo Where Prefactura.IDPrefactura='" + DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).txtIDFactura.Text + "'", ConMixta)
            AdaptadorSP.Fill(DsSP, "PrefacturaView")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            cmdSP.Dispose()
            AdaptadorSP.Dispose()

            ObjRpt.Database.Tables("Prefactura_DATA").SetDataSource(DsSP.Tables("PrefacturaView"))

        ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
                crParameterDiscreteValue.Value = frm_conduce_reparaciones.txtIDReparacion.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                crParameterDiscreteValue.Value = frm_registro_factura_sd.txtIDFactura.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
                crParameterDiscreteValue.Value = frm_cuotas_financiamientos.txtIDPagoFinanciamiento.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_notas_debito_credito.Name Then
                crParameterDiscreteValue.Value = frm_notas_debito_credito.txtIDNota.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
                crParameterDiscreteValue.Value = frm_cobros_adelantados.txtIDCobro.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                crParameterDiscreteValue.Value = frm_otros_ingresos.txtIDIngreso.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_conduce_reparacion_entrada.Name Then
                crParameterDiscreteValue.Value = frm_conduce_reparacion_entrada.txtIDEntrada.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_acuerdos_pago.Name Then
                crParameterDiscreteValue.Value = frm_acuerdos_pago.txtIDAcuerdo.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_financiamiento.Name Then
                crParameterDiscreteValue.Value = frm_financiamiento.txtIDFinanciamiento.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
                crParameterDiscreteValue.Value = frm_cheques_devueltos.txtIDCheque.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cheques_futuristas.Name Then
                crParameterDiscreteValue.Value = frm_cheques_futuristas.txtIDCheque.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_mant_memos_cliente.Name Then
                crParameterDiscreteValue.Value = frm_mant_memos_cliente.txtIDMemoC.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_progreso_solicitudes.Name Then
                crParameterDiscreteValue.Value = frm_progreso_solicitudes.lblIDSolicitud.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                crParameterDiscreteValue.Value = frm_factura_cxp.txtIDCompra.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_nota_debito_credito_cxp.Name Then
                crParameterDiscreteValue.Value = frm_nota_debito_credito_cxp.txtIDNota.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_recibos_egresos.Name Then
                crParameterDiscreteValue.Value = frm_recibos_egresos.txtIDEgreso.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_pago_compras.Name Then
                Dim cmdSP As New MySqlCommand
                Dim AdaptadorSP As MySqlDataAdapter

                'Consulta de los PAGOS DE COMPRAS''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                AdaptadorSP = New MySqlDataAdapter("SELECT PagoCompra.IDPagoCompra,PagoCompra.SecondID as SecondIDPago,PagoCompra.IDTipoDocumento,TipoDocumento.Documento,PagoCompra.Fecha,PagoCompra.Hora,PagoCompra.IDSucursal,Sucursal.Sucursal,Sucursal.Direccion as DireccionSucursal,Sucursal.Municipio as MunicipioSucursal,Sucursal.Provincia AS ProvinciaSucursal,Sucursal.Telefono as TelefonoSucursal,Sucursal.Telefono1 as Telefono1Sucursal,Sucursal.Telefono2 as SucursalTelefono2,Sucursal.Fax as FaxSucursal,Sucursal.Email as EmailSucursal,PagoCompra.IDAlmacen,Almacen.Almacen,PagoCompra.IDUsuario,Usuarios.Nombre as NombreUsuario,PagoCompra.IDSuplidor,Suplidor.Suplidor,Suplidor.IDTipoIdentificacion,TipoIdentificacion.Descripcion as TipoRNC,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.Rnc,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Suplidor.Direccion,Suplidor.Telefono,Suplidor.FAx,Suplidor.TelefonoRepresentante,PagoCompra.BceAnterior as BceAnteriorSup,PagoCompra.MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,PagoCompra.Nulo,IDPagoComprasDetalle,PagoComprasDetalle.IDCompra,Compras.NoFactura,Compras.SecondID as SecondIDCompra,Compras.NCF,Compras.FechaFactura,Compras.FechaVencimiento,PagoComprasDetalle.BceAnterior as BceAnteriorFactura,PagoComprasDetalle.RetISR AS RetISRDetalle,PagoComprasDetalle.RetITBIS AS RetITBISDetalle,PagoCOmprasDetalle.Descuento as DescuentoDetalle,PagoComprasDetalle.Aplicado as AplicadoDetalle FROM" & SysName.Text & "Pagocompra INNER JOIN" & SysName.Text & "TipoDocumento on PagoCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagoCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Sucursal on PagoCompra.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on PagoCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoIdentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN" & SysName.Text & "PagoComprasDetalle on PagoCompra.IDPagoCompra=PagoComprasDetalle.IDPagoCompra INNER JOIN" & SysName.Text & "Compras on PagoComprasDetalle.IDCompra=Compras.IDCompra Where PagoCompra.IDPagoCompra='" + frm_pago_compras.txtIDPago.Text + "'", ConMixta)
                AdaptadorSP.Fill(DsSP, "PagoComprasView")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Llenado EmpresaView
                AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                AdaptadorSP.Fill(DsSP, "EmpresaView")

                cmdSP.Dispose()
                AdaptadorSP.Dispose()

                ObjRpt.Database.Tables("pagocomprasview1").SetDataSource(DsSP.Tables("PagoComprasView"))
                ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))



                'crParameterDiscreteValue.Value = frm_pago_compras.txtIDPago.Text

                'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
                crParameterDiscreteValue.Value = frm_registro_ingresos_deducciones.txtIDDeduccionProc.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_mant_prestamos_emp.Name Then
                crParameterDiscreteValue.Value = frm_mant_prestamos_emp.txtIDPrestamo.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_descontar_prestamos.Name Then
                crParameterDiscreteValue.Value = frm_descontar_prestamos.txtIDAbonoPrestamo.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_proceso_nomina.Name Then
                '@Fecha
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue
                crParameterRangeValue.StartValue = frm_proceso_nomina.DtpFechaInicial.MinDate
                crParameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive
                crParameterRangeValue.EndValue = frm_proceso_nomina.DtpFechaFinal.MaxDate
                crParameterRangeValue.LowerBoundType = RangeBoundType.BoundInclusive
                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDNomina
                crParameterDiscreteValue.Value = frm_proceso_nomina.txtIDNomina.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDNomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoNomina
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoNomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDEmpleado
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDAlmacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DTEmpleado.Rows(0).Item("Login").ToString & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "]")
                ObjRpt.SetParameterValue("@Resumir", 0)

            ElseIf Me.Owner.Name = frm_solicitud_cheques.Name Then
                crParameterDiscreteValue.Value = frm_solicitud_cheques.txtIDSolicitud.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cheques.Name Then
                crParameterDiscreteValue.Value = frm_cheques.txtIDCheque.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_movimientos_bancarios.Name Then
                crParameterDiscreteValue.Value = frm_movimientos_bancarios.txtIDMovimientoBanc.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_generacion_nuevos_recibos.Name Then
                crParameterDiscreteValue.Value = frm_generacion_nuevos_recibos.txtIDGRecibo.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_entrega_cobro.Name Then
                crParameterDiscreteValue.Value = frm_entrega_cobro.txtIDEntrega.Text
                If frm_entrega_cobro.chkResumir.Checked = False Then
                    ObjRpt.SetParameterValue("@Resumir", 0)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 1)
                End If

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cargo_pagareses.Name Then
                crParameterDiscreteValue.Value = frm_cargo_pagareses.txtIDListaPagare.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_cargar_pagare_individual.Name Then
                crParameterDiscreteValue.Value = frm_cargar_pagare_individual.txtIDListaPagare.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_traspasar_pagare.Name Then
                crParameterDiscreteValue.Value = frm_traspasar_pagare.txtIDListaPagare.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_restablecer_pagare.Name Then
                crParameterDiscreteValue.Value = frm_restablecer_pagare.txtIDListaPagare.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_grupo_cierre_recibos.Name Then
                crParameterDiscreteValue.Value = frm_grupo_cierre_recibos.txtIDGrupo.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_consulta_numero_recibo.Name Then
                crParameterDiscreteValue.Value = frm_consulta_numero_recibo.txtIDGrupo.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_historial_recibos_cliente.Name Then
                crParameterDiscreteValue.Value = frm_historial_recibos_cliente.lblIDFactura.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DTEmpleado.Rows(0).Item("Login").ToString & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "]")

                If frm_historial_recibos_cliente.chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If

            ElseIf Me.Owner.Name = frm_talonarios_cobro.Name Then
                crParameterDiscreteValue.Value = frm_talonarios_cobro.txtIDTalonario.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_listado_articulos.Name Then
                crParameterDiscreteValue.Value = frm_listado_articulos.txtIDListado.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_deposito_factura.Name Then
                crParameterDiscreteValue.Value = frm_deposito_factura.txtIDDeposito.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ElseIf Me.Owner.Name = frm_corte_caja.Name Then
                crParameterDiscreteValue.Value = frm_corte_caja.txtIDCorte.Text

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                If frm_corte_caja.Privilegios = 1 Then
                    ObjRpt.SetParameterValue("@Resumir", 0)
                ElseIf frm_corte_caja.Privilegios = 2 Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                ElseIf frm_corte_caja.Privilegios = 3 Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                ElseIf frm_corte_caja.Privilegios = 4 Then
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If


            End If

            If ModoDuplicado.Text = 1 Then
                If chkOriginal.Enabled = True Then
                    ObjRpt.SetParameterValue("Duplicidad", "ORIGINAL")
                Else
                If chkDuplicado.Checked = True Then
                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(92 - 1).Item("Value1Var").ToString)
                ElseIf chkDespacho.Checked = True Then
                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(93 - 1).Item("Value1Var").ToString)
                ElseIf chkContabilidad.Checked = True Then
                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(94 - 1).Item("Value1Var").ToString)
                End If

                End If
            End If

            VisorDocumento.Cursor = Cursors.Default

            'Formatting and showing suspect
            lblStatusBar.Text = "Cargando recursos del reporte..."
            Me.VisorDocumento.ReportSource = Nothing
            Me.VisorDocumento.ReportSource = ObjRpt

            lblStatusBar.Text = "Establecimiendo existencia de impresora predefinida..."
            Me.VisorDocumento.Tag = ObjRpt.PrintOptions.PrinterName.ToString

            lblStatusBar.Text = "Actualizando controles de visualización..."
            Me.VisorDocumento.Refresh()

            lblStatusBar.Text = "Ajustando vista..."
            Me.VisorDocumento.Zoom(100)
            lblStatusBar.Text = "Listo..."

            DsSP.Dispose()


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            LoadAnimation()

            If rdbImpresora.Checked = True Then
                Me.Cursor = Cursors.AppStarting
                lblStatusBar.Text = "Reporte en impresión..."

                If frm_inicio.cbxPrintMode.Tag = 0 Then
                    If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                        With PrintDialog
                            .AllowSelection = True
                            .AllowSomePages = True
                            .AllowPrintToFile = True
                        End With

                        Dim PrinterSettings1 As New Printing.PrinterSettings
                        Dim PageSettings1 As New Printing.PageSettings

                        PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                        PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                        PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                        PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                        PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                        PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                        Me.VisorDocumento.ReportSource.SummaryInfo.ReportTitle = CbxFormato.Text & " " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.VisorDocumento.ReportSource.SummaryInfo.ReportAuthor = DTEmpleado.Rows(0).Item("Nombre").ToString & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "]"
                        Me.VisorDocumento.ReportSource.PrintOptions.PrinterName = PrinterSettings1.PrintFileName

                        'Si la impresión es en media página
                        If CbxFormato.Text.ToUpper.Contains("MEDIA") Then
                            Dim doctoprint As New System.Drawing.Printing.PrintDocument()
                            doctoprint.PrinterSettings.PrinterName = PrintDialog.PrinterSettings.PrinterName
                            For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                                Dim rawKind As Integer
                                If doctoprint.PrinterSettings.PaperSizes(i).PaperName = "MediaPagina" Then
                                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                                    Me.VisorDocumento.ReportSource.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                                    Me.VisorDocumento.ReportSource.PrintOptions.PaperSize = rawKind
                                    Exit For
                                End If
                            Next
                        End If

                        If ModoDuplicado.Text = 0 Then
                            'Comando de impresion
                            Me.VisorDocumento.ReportSource.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                        Else

                            If ModoDuplicidadHabilitado.Text = 1 Then
                                If chkOriginal.Checked Then
                                    'Imprimiendo original
                                    ObjRpt.SetParameterValue("Duplicidad", "ORIGINAL")

                                    Me.VisorDocumento.ReportSource = ObjRpt
                                    'Me.VisorDocumento.ReportSource.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    chkOriginal.Checked = False
                                End If

                                ''''''''''''''''''''''''''''''''''''''
                                If TipoPapel.Text = 1 Then
                                    If chkDuplicado.Checked Then
                                        ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(92 - 1).Item("Value1Var").ToString)

                                        Me.VisorDocumento.ReportSource = ObjRpt
                                        'Me.VisorDocumento.ReportSource.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If
                                Else
                                    ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(92 - 1).Item("Value1Var").ToString)

                                    Me.VisorDocumento.ReportSource = ObjRpt
                                    'Me.VisorDocumento.ReportSource.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                                    ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                End If

                                ''''''''''''''''''''''''''''''''''''
                                If TipoPapel.Text = 1 Then
                                    If chkDespacho.Checked Then
                                        ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(93 - 1).Item("Value1Var").ToString)

                                        Me.VisorDocumento.ReportSource = ObjRpt
                                        'Me.VisorDocumento.ReportSource.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If
                                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                                    If chkContabilidad.Checked Then
                                        ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(94 - 1).Item("Value1Var").ToString)

                                        Me.VisorDocumento.ReportSource = ObjRpt
                                        'Me.VisorDocumento.ReportSource.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If
                                End If

                            End If
                        End If

                        'Control de despacho desde facturacion
                        If Me.Owner.Name = frm_facturacion.Name Then
                            If CInt(DTConfiguracion.Rows(202 - 1).Item("Value2Int")) = 1 Then
                                Con.Open()
                                If TipoPapel.Text = 1 Then
                                    'Habilitar control en reportes de página completa
                                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=203", Con)
                                    If CInt(DTConfiguracion.Rows(203 - 1).Item("Value2Int")) = 1 Then
                                        Dim crParameterValues As New ParameterValues
                                        Dim crParameterDiscreteValue As New ParameterDiscreteValue
                                        Dim ObjRpt As New ReportDocument

                                        cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=206)", Con)
                                        ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                        crParameterDiscreteValue.Value = frm_facturacion.txtIDFactura.Text
                                        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                        crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                        crParameterValues.Add(crParameterDiscreteValue)
                                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If


                                ElseIf TipoPapel.Text = 2 Then
                                    'Habilitar control en reportes de media
                                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=204", Con)
                                    If CInt(DTConfiguracion.Rows(204 - 1).Item("Value2Int")) = 1 Then
                                        Dim crParameterValues As New ParameterValues
                                        Dim crParameterDiscreteValue As New ParameterDiscreteValue
                                        Dim ObjRpt As New ReportDocument

                                        cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=207)", Con)
                                        ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                        crParameterDiscreteValue.Value = frm_facturacion.txtIDFactura.Text
                                        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                        crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                        crParameterValues.Add(crParameterDiscreteValue)
                                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If


                                ElseIf TipoPapel.Text = 3 Then
                                    'Habilitar control en reportes de punto
                                    'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=205", Con)
                                    If CInt(DTConfiguracion.Rows(205 - 1).Item("Value2Int")) = 1 Then
                                        Dim crParameterValues As New ParameterValues
                                        Dim crParameterDiscreteValue As New ParameterDiscreteValue
                                        Dim ObjRpt As New ReportDocument

                                        cmd = New MySqlCommand("SELECT Path FROM libregco.reportes where IDReportes=(Select Value2Int from Configuracion Where IDConfiguracion=208)", Con)
                                        ObjRpt.Load("\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar()))

                                        crParameterDiscreteValue.Value = frm_facturacion.txtIDFactura.Text
                                        crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                                        crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
                                        crParameterValues.Add(crParameterDiscreteValue)
                                        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                                        ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)
                                    End If

                                End If

                                Con.Close()
                            End If
                        End If

                        chkOriginal.Checked = False
                        chkOriginal.Enabled = False
                    End If

                ElseIf frm_inicio.cbxPrintMode.Tag = 1 Then
                    VisorDocumento.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintToPrinter
                    VisorDocumento.PrintReport()


                ElseIf frm_inicio.cbxPrintMode.Tag = 2 Then
                    VisorDocumento.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintOutputController
                    VisorDocumento.PrintReport()

                End If

                Me.Cursor = Cursors.Default

            ElseIf rdbPDF.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en PDF..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                With GetFileName
                    .RestoreDirectory = True
                    .Title = ("Especifique Ubicación")
                    .Filter = "Portable Documento Format (*.pdf)|*.pdf"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = Me.VisorDocumento.ReportSource.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With

                    Me.VisorDocumento.ReportSource.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)

                    chkOriginal.Checked = False
                    chkOriginal.Enabled = False
                End If

            ElseIf rdbExcel.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en archivo de Excel..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New ExcelFormatOptions

                With GetFileName
                    .RestoreDirectory = True
                    .Title = ("Especifique Ubicación")
                    .Filter = "Excel (*.xls)|*.xls"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = Me.VisorDocumento.ReportSource.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    Me.VisorDocumento.ReportSource.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)

                    chkOriginal.Checked = False
                    chkOriginal.Enabled = False
                End If
            End If
            LoadAnimation()

            lblStatusBar.Text = "Listo"


            If Me.Owner.Name = frm_facturacion.Name Then
                If frm_facturacion.Owner.Name = frm_cierre_facturas.Name Then
                    If frm_facturacion.DgvPagares.Rows.Count = 0 Then
                        Me.Close()
                    End If
                End If
            End If


        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub frm_impresiones_directas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If frm_LoginSistema.Visible = True Then
                Exit Sub
            End If

            Dim PrintStatus As New Label

            'Disposing on closing form
            'If Me.ObjRpt IsNot Nothing Then
            '    Me.ObjRpt.Close()
            '    Me.ObjRpt.Dispose()
            'End If

            'Changing state of print on record
            ChangetoFalsePrintSecureEmployee()


            If Me.Owner.Name = frm_facturacion.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "FacturaDatos Where IDFacturaDatos='" + frm_facturacion.txtIDFactura.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "FacturaDatos SET Impreso=1 WHERE IDFacturaDatos='" + frm_facturacion.txtIDFactura.Text + "'"
                    GuardarDatos()
                    frm_facturacion.EstadoImpresion = 1
                End If

            ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Abonos Where IDAbono='" + frm_recibo_pagos.txtIDPago.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Abonos SET Impreso=1 WHERE IDAbono='" + frm_recibo_pagos.txtIDPago.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "pagosfinanciamientos Where idPagosFinanciamientos='" + frm_cuotas_financiamientos.txtIDPagoFinanciamiento.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "pagosfinanciamientos SET Impreso=1 WHERE idPagosFinanciamientos='" + frm_cuotas_financiamientos.txtIDPagoFinanciamiento.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "FacturaDatos Where IDFacturaDatos='" + frm_punto_venta_lite.lblIDFactura.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "FacturaDatos SET Impreso=1 WHERE IDFacturaDatos='" + frm_punto_venta_lite.lblIDFactura.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Cotizacion Where IDCotizacion='" + frm_cotizacion.txtIDCotizacion.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Cotizacion SET Impreso=1 WHERE IDCotizacion='" + frm_cotizacion.txtIDCotizacion.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_devolucion_fact.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "DevolucionVenta Where IDDevolucionVenta='" + frm_devolucion_fact.txtIDDevolucion.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "DevolucionVenta SET Impreso=1 WHERE IDDevolucionVenta='" + frm_devolucion_fact.txtIDDevolucion.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "MovimientoInventario Where IDAjusteInventario='" + frm_ajuste_inventario.txtIDAjuste.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "MovimientoInventario SET Impreso=1 WHERE IDAjusteInventario='" + frm_ajuste_inventario.txtIDAjuste.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "MovimientoInventario Where IDAjusteInventario='" + frm_inv_inicial.txtIDAjuste.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "MovimientoInventario SET Impreso=1 WHERE IDAjusteInventario='" + frm_inv_inicial.txtIDAjuste.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_conduce.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Conduce Where IDConduce='" + frm_conduce.txtIDConduce.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Conduce SET Impreso=1 WHERE IDConduce='" + frm_conduce.txtIDConduce.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_transferencia_arts.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "TransfenciaArticulos Where IDTransferenciaArt='" + frm_transferencia_arts.txtIDTransferenciaArt.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "TransfenciaArticulos SET Impreso=1 WHERE IDTransferenciaArt='" + frm_transferencia_arts.txtIDTransferenciaArt.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_orden_compras.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "OrdenCompra Where IDOrdenCompra='" + frm_orden_compras.txtIDOrdenCompra.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "OrdenCompra SET Impreso=1 WHERE IDOrdenCompra='" + frm_orden_compras.txtIDOrdenCompra.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_pedidos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Pedidos Where IDPedido='" + frm_pedidos.txtIDPedido.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Pedidos SET Impreso=1 WHERE IDPedido='" + frm_pedidos.txtIDPedido.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Reparacion Where IDReparacion='" + frm_conduce_reparaciones.txtIDReparacion.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Reparacion SET Impreso=1 WHERE IDReparacion='" + frm_conduce_reparaciones.txtIDReparacion.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_financiamiento.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Financiamientos Where IDFinanciamientos='" + frm_financiamiento.txtIDFinanciamiento.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Financiamientos SET Impreso=1 WHERE IDFinanciamientos='" + frm_financiamiento.txtIDFinanciamiento.Text + "'"
                    GuardarDatos()
                End If


            ElseIf Me.Owner.Name = frm_devolucion_compras.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "DevolucionCompra Where IDDevolucionCompra='" + frm_devolucion_compras.txtIDDevolucion.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "DevolucionCompra SET Impreso=1 WHERE IDDevolucionCompra='" + frm_devolucion_compras.txtIDDevolucion.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Reparacion Where IDReparacion='" + frm_conduce_reparaciones.txtIDReparacion.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Reparacion SET Impreso=1 WHERE IDReparacion='" + frm_conduce_reparaciones.txtIDReparacion.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "FacturaDatos Where IDFacturaDatos='" + frm_registro_factura_sd.txtIDFactura.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "FacturaDatos SET Impreso=1 WHERE IDFacturaDatos='" + frm_registro_factura_sd.txtIDFactura.Text + "'"
                    GuardarDatos()
                End If
            ElseIf Me.Owner.Name = frm_notas_debito_credito.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "NotaDebitoCredito Where IDNotaDebCred='" + frm_notas_debito_credito.txtIDNota.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "NotaDebitoCredito SET Impreso=1 WHERE IDNotaDebCred='" + frm_notas_debito_credito.txtIDNota.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "CobrosAdelantados Where IDCobrosAdelantados='" + frm_cobros_adelantados.txtIDCobro.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "CobrosAdelantados SET Impreso=1 WHERE IDCobrosAdelantados='" + frm_cobros_adelantados.txtIDCobro.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "OtrosIngresos Where IDOtrosIngresos='" + frm_otros_ingresos.txtIDIngreso.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "OtrosIngresos SET Impreso=1 WHERE IDOtrosIngresos='" + frm_otros_ingresos.txtIDIngreso.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_conduce_reparacion_entrada.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "EntradaReparacion Where IDEntradaReparacion='" + frm_conduce_reparacion_entrada.txtIDEntrada.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "EntradaReparacion SET Impreso=1 WHERE IDEntradaReparacion='" + frm_conduce_reparacion_entrada.txtIDEntrada.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_acuerdos_pago.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "AcuerdosPago Where IDAcuerdoPago='" + frm_acuerdos_pago.txtIDAcuerdo.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "AcuerdosPago SET Impreso=1 WHERE IDAcuerdoPago='" + frm_acuerdos_pago.txtIDAcuerdo.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "ChequesDevueltos Where IDChequesDevueltos='" + frm_cheques_devueltos.txtIDCheque.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "ChequesDevueltos SET Impreso=1 WHERE IDChequesDevueltos='" + frm_cheques_devueltos.txtIDCheque.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_cheques_futuristas.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "ChequesFuturos Where IDChequesFuturos='" + frm_cheques_futuristas.txtIDCheque.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "ChequesFuturos SET Impreso=1 WHERE IDChequesFuturos='" + frm_cheques_futuristas.txtIDCheque.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_mant_memos_cliente.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "MemosClientes Where IDMemoC='" + frm_mant_memos_cliente.txtIDMemoC.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "MemosClientes SET Impreso=1 WHERE IDMemoC='" + frm_mant_memos_cliente.txtIDMemoC.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_progreso_solicitudes.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "ProgresoSolicitud Where IDProgreso='" + frm_progreso_solicitudes.txtIDProgreso.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "ProgresoSolicitud SET Impreso=1 WHERE IDProgreso='" + frm_progreso_solicitudes.txtIDProgreso.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_registro_compras.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Compras Where IDCompra='" + frm_registro_compras.txtIDCompra.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Compras SET Impreso=1 WHERE IDCompra='" + frm_registro_compras.txtIDCompra.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Compras Where IDCompra='" + frm_factura_cxp.txtIDCompra.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Compras SET Impreso=1 WHERE IDCompra='" + frm_factura_cxp.txtIDCompra.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_recibos_egresos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Egresos Where IDEgresos='" + frm_recibos_egresos.txtIDEgreso.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Egresos SET Impreso=1 WHERE IDEgresos='" + frm_recibos_egresos.txtIDEgreso.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "DeduccionesProcesadas Where IDeduccionesProcesadas='" + frm_registro_ingresos_deducciones.txtIDDeduccionProc.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "DeduccionesProcesadas SET Impreso=1 WHERE IDeduccionesProcesadas='" + frm_registro_ingresos_deducciones.txtIDDeduccionProc.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_mant_prestamos_emp.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "PrestamosEmp Where IDPrestamosEmp='" + frm_mant_prestamos_emp.txtIDPrestamo.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "PrestamosEmp SET Impreso=1 WHERE IDPrestamosEmp='" + frm_mant_prestamos_emp.txtIDPrestamo.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_descontar_prestamos.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "abprestemp Where IDAbonoPrestamosEmp='" + frm_descontar_prestamos.txtIDAbonoPrestamo.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "abprestemp SET Impreso=1 WHERE IDAbonoPrestamosEmp='" + frm_descontar_prestamos.txtIDAbonoPrestamo.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_proceso_nomina.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "Nomina Where IDNomina='" + frm_proceso_nomina.txtIDNomina.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "Nomina SET Impreso=1 WHERE IDNomina='" + frm_proceso_nomina.txtIDNomina.Text + "'"
                    GuardarDatos()
                End If

            ElseIf Me.Owner.Name = frm_deposito_factura.Name Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select Impreso from" & SysName.Text & "DepositoFacturas Where IDDepositoFacturas='" + frm_deposito_factura.txtIDDeposito.Text + "'", ConMixta)
                PrintStatus.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If PrintStatus.Text = 0 Then
                    sqlQ = "UPDATE" & SysName.Text & "DepositoFacturas SET Impreso=1 WHERE IDDepositoFacturas='" + frm_deposito_factura.txtIDDeposito.Text + "'"
                    GuardarDatos()
                End If

            End If

            If frm_show_montodevuelta.Visible = True Then
                frm_show_montodevuelta.Close()
            End If


        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub frm_impresiones_directas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.P Then
                e.Handled = True
                btnPresentar.PerformClick()
            End If

        ElseIf e.KeyCode = Keys.F10 Then
            e.Handled = True
            btnPresentar.PerformClick()

        ElseIf e.KeyCode = Keys.Add Then
            e.Handled = True
            btnPresentar.PerformClick()

        ElseIf e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

End Class