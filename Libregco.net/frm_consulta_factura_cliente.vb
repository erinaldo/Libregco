Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_consulta_factura_cliente

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Friend lblIDUsuario As New Label

    Private Sub frm_consultas_factura_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,NombreFactura,TotalNeto,Balance FROM FacturaDatos where IDCliente = '" + txtIDCliente.Text + "' and IDTipoDocumento<3 ORDER BY IDFacturaDatos ASC", Con)
        RefrescarTabla()
        ContarFacturas()
    End Sub

    Private Sub ContarFacturas()
        lblFactEncontradas.Text = "Facturas Encontradas: " & DgvFacturas.Rows.Count
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Ds.Clear()
        Con.Open()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "FacturaDatos")
        DgvFacturas.DataSource = Ds
        DgvFacturas.DataMember = "FacturaDatos"
        PropiedadColumnsDvg()
        Con.Close()
    End Sub

    Private Sub PropiedadColumnsDvg()
        Dim DatagridWith As Double = (DgvFacturas.Width - DgvFacturas.RowHeadersWidth) / 100

        With DgvFacturas
            .Columns(0).Visible = False

            .Columns(1).Width = DatagridWith * 15
            .Columns(1).HeaderText = "No.Factura"
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(2).Width = DatagridWith * 15
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(3).HeaderText = "Nombre"
            .Columns(3).Width = DatagridWith * 35

            .Columns(4).Width = DatagridWith * 17
            .Columns(4).HeaderText = "Total Neto"
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(5).Width = DatagridWith * 18
            .Columns(5).HeaderText = "Balance"
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    Private Sub DgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDFactura As New Label
        IDFactura.Text = DgvFacturas.CurrentRow.Cells(0).Value

        Try
            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,IdentificacionFactura,Clientes.Nombre,FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,FacturaDatos.IDTransaccion,FacturaDatos.Fecha,FacturaDatos.Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Transaccion.IDMoneda,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,Calificacion.ColorCalificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.Nulo,FacturaDatos.Impreso,Clientes.Precio,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.BloqueoCobrador,Clientes.LiberarControles from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where IDFacturaDatos='" + IDFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")

            If frm_buscar_cliente_factura.Owner.Name = frm_facturacion.Name Then

                frm_superclave.IDAccion.Text = 32
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                frm_facturacion.Hora.Enabled = False
                frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
                frm_facturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_facturacion.txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                frm_facturacion.txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
                frm_facturacion.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
                frm_facturacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonosFactura"))
                frm_facturacion.txtRNC.Text = (Tabla.Rows(0).Item("IdentificacionFactura"))
                frm_facturacion.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_facturacion.lblIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                frm_facturacion.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                frm_facturacion.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_facturacion.cbxCondicion.Tag = (Tabla.Rows(0).Item("IDCondicion"))
                frm_facturacion.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                frm_facturacion.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
                frm_facturacion.txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
                frm_facturacion.txtMontoPagos.Text = (Tabla.Rows(0).Item("MontoPagos"))

                frm_facturacion.txtAdicional.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")

                If IsDate(Tabla.Rows(0).Item("FechaAdicional")) Then
                    frm_facturacion.txtFechaAdicional.Text = CDate(Tabla.Rows(0).Item("FechaAdicional")).ToString("dd/MM/yyyy")
                Else
                    frm_facturacion.txtFechaAdicional.Text = ""
                End If
                frm_facturacion.txtBalance.Text = (Tabla.Rows(0).Item("Balance"))
                frm_facturacion.txtFechaVencimiento.Text = (Tabla.Rows(0).Item("FechaVencimiento"))
                frm_facturacion.txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
                frm_facturacion.txtSubTotal.Text = (Tabla.Rows(0).Item("SubTotal"))
                frm_facturacion.TxtDescuentoSuma.Text = (Tabla.Rows(0).Item("Descuento"))
                frm_facturacion.txtITBIS.Text = (Tabla.Rows(0).Item("Itbis"))
                frm_facturacion.txtFlete.Text = (Tabla.Rows(0).Item("Flete"))
                frm_facturacion.txtNeto.Text = (Tabla.Rows(0).Item("TotalNeto"))
                frm_facturacion.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
                frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                frm_facturacion.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                frm_facturacion.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_facturacion.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
                frm_facturacion.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_facturacion.cbxVehiculo.Text = (Tabla.Rows(0).Item("Datovehiculo"))
                frm_facturacion.txtVendedor.Tag = (Tabla.Rows(0).Item("IDVendedor"))
                frm_facturacion.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
                frm_facturacion.CbxChofer.Text = (Tabla.Rows(0).Item("Chofer"))
                frm_facturacion.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
                frm_facturacion.EstadoImpresion = Tabla.Rows(0).Item("Impreso")
                frm_facturacion.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")
                frm_facturacion.RefrescarBalances()
                frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                If (Tabla.Rows(0).Item("HabilitarFicha")) = 0 Then
                    frm_facturacion.chkFichaDatos.Checked = False
                Else
                    frm_facturacion.chkFichaDatos.Checked = True
                End If
                If (Tabla.Rows(0).Item("NotaContado")) = 0 Then
                    frm_facturacion.chkHabilitarNota.Checked = False
                Else
                    frm_facturacion.chkHabilitarNota.Checked = True
                    frm_int_notacontado.DtpFecha.Value = CDate(Between(Tabla.Rows(0).Item("CondicionContado"), "del ", " sólo")).ToString("dd/MM/yyyy")
                    frm_int_notacontado.txtMonto.Text = CDbl(After(Tabla.Rows(0).Item("CondicionContado"), "$")).ToString("C")
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_facturacion.chkDesactivar.Checked = False
                Else
                    frm_facturacion.chkDesactivar.Checked = True
                End If

                If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                    frm_facturacion.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                    frm_facturacion.lblMensajeCalificacion.Visible = True
                Else
                    frm_facturacion.lblMensajeCalificacion.Visible = False
                End If


                If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                    frm_facturacion.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                Else
                    frm_facturacion.txtUltimoMonto.Text = Tabla.Rows(0).Item("UltimoMontoPago")
                End If

                Dim Founded As Boolean = False
                For Each itm As String In frm_facturacion.cbxPrecio.Items
                    If itm = (Tabla.Rows(0).Item("Precio")) Then
                        frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                        Founded = True
                        Exit For
                    End If
                Next
                If Founded = False Then
                    frm_facturacion.cbxPrecio.Items.Add(Tabla.Rows(0).Item("Precio"))
                    frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                Else
                    frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                End If

                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                End If

                If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                    frm_facturacion.chkEntregarporConduce.Checked = True
                Else
                    frm_facturacion.chkEntregarporConduce.Checked = False
                End If

                'Liberando controles
                If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                    If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                        frm_facturacion.LiberarControles.Text = 1
                    End If
                End If


                If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                    MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                    MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    frm_facturacion.DeshabilitarControles()
                End If

                If TypeConnection.Text = 1 Then
                    If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                        frm_facturacion.PicImagen.Image = My.Resources.no_photo
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                            frm_facturacion.PicImagen.Image = Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

                frm_facturacion.Hora.Enabled = False
                frm_facturacion.btnAnular.Enabled = True
                frm_facturacion.RefrescarTablaConsulta()
                frm_facturacion.RefrescarTablaPagares()
                frm_facturacion.CalcularMontoPago()
                frm_facturacion.SumTotales()

                If frm_facturacion.dgvArticulosFactura.Rows.Count > 0 Then
                    frm_facturacion.cbxMoneda.Enabled = False
                End If

                If IsModifiable(Tabla.Rows(0).Item("IDFacturaDatos")) = 0 Then
                    frm_facturacion.lblStatusBar.Text = "Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad."
                Else
                    frm_facturacion.lblStatusBar.Text = "Listo"
                End If

            ElseIf frm_buscar_cliente_factura.Owner.Name = frm_punto_venta_lite.Name Then
                frm_superclave.IDAccion.Text = 18
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                frm_punto_venta_lite.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_punto_venta_lite.txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
                frm_punto_venta_lite.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
                frm_punto_venta_lite.txtTelefono.Text = (Tabla.Rows(0).Item("TelefonosFactura"))
                frm_punto_venta_lite.lblIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                frm_punto_venta_lite.lblSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_punto_venta_lite.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_punto_venta_lite.txtDiasCondicion.Text = (Tabla.Rows(0).Item("DiasCondicion"))
                frm_punto_venta_lite.lblIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                frm_punto_venta_lite.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                frm_punto_venta_lite.lblFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_punto_venta_lite.lblHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_punto_venta_lite.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
                frm_punto_venta_lite.txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
                frm_punto_venta_lite.txtMontoPagos.Text = (Tabla.Rows(0).Item("MontoPagos"))
                frm_punto_venta_lite.txtAdicional.Text = (Tabla.Rows(0).Item("PagoAdicional"))
                frm_punto_venta_lite.txtFechaAdicional.Text = (Tabla.Rows(0).Item("FechaAdicional"))
                frm_punto_venta_lite.txtBalance.Text = (Tabla.Rows(0).Item("NetoFactura"))
                frm_punto_venta_lite.txtFechaVencimiento.Text = CDate(Tabla.Rows(0).Item("FechaVencimiento")).ToString("dd/MM/yyyy")
                frm_punto_venta_lite.txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
                frm_punto_venta_lite.lblSubTotal.Text = (Tabla.Rows(0).Item("SubTotal"))
                frm_punto_venta_lite.lblDescuento.Text = (Tabla.Rows(0).Item("Descuento"))
                frm_punto_venta_lite.lblItbis.Text = (Tabla.Rows(0).Item("Itbis"))
                frm_punto_venta_lite.lblFlete.Text = (Tabla.Rows(0).Item("Flete"))
                frm_punto_venta_lite.lblTotalNeto.Text = (Tabla.Rows(0).Item("TotalNeto"))
                frm_punto_venta_lite.lblTotalNeto2.Text = (Tabla.Rows(0).Item("TotalNeto"))
                frm_punto_venta_lite.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
                frm_punto_venta_lite.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_punto_venta_lite.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                frm_punto_venta_lite.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_punto_venta_lite.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                frm_punto_venta_lite.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_punto_venta_lite.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
                frm_punto_venta_lite.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_punto_venta_lite.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
                frm_punto_venta_lite.cbxVehiculo.Text = (Tabla.Rows(0).Item("Datovehiculo"))
                frm_punto_venta_lite.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
                frm_punto_venta_lite.CbxChofer.Text = (Tabla.Rows(0).Item("Chofer"))
                frm_punto_venta_lite.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

                If (Tabla.Rows(0).Item("HabilitarFicha")) = 0 Then
                    frm_punto_venta_lite.chkFichaDatos.Checked = False
                Else
                    frm_punto_venta_lite.chkFichaDatos.Checked = True
                End If
                If (Tabla.Rows(0).Item("NotaContado")) = 0 Then
                    frm_punto_venta_lite.chkHabilitarNota.Checked = False
                Else
                    frm_punto_venta_lite.chkHabilitarNota.Checked = True
                End If
                If (Tabla.Rows(0).Item("EntregarPorConduce")) = 0 Then
                    frm_punto_venta_lite.chkEntregarporConduce.Checked = False
                Else
                    frm_punto_venta_lite.chkEntregarporConduce.Checked = True
                End If
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_punto_venta_lite.chkDesactivar.Checked = False
                Else
                    frm_punto_venta_lite.chkDesactivar.Checked = True
                End If

                frm_punto_venta_lite.RefrescarTablaConsulta()
                frm_punto_venta_lite.RefrescarTablaPagares()
                frm_punto_venta_lite.SumTotales()
                frm_punto_venta_lite.ConvertCurrent()
                frm_punto_venta_lite.DeshabilitarControles()

                If IsModifiable(Tabla.Rows(0).Item("IDFacturaDatos")) = 0 Then
                    frm_punto_venta_lite.lblStatusBar.Text = "Esta factura no es modificable ya que se han hecho transacciones que afectan su integridad."
                Else
                    frm_punto_venta_lite.lblStatusBar.Text = "Listo"
                End If

            ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
                frm_reporte_entrega_cobros.txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                frm_reporte_entrega_cobros.txtFactura.Text = (Tabla.Rows(0).Item("SecondID"))
            End If

            Close()
            Exit Sub
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvFacturas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvFacturas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub DgvFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvFacturas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvFacturas.ColumnCount
                Dim NumRows As Integer = DgvFacturas.RowCount
                Dim CurCell As DataGridViewCell = DgvFacturas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvFacturas.CurrentCell = DgvFacturas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvFacturas.CurrentCell = DgvFacturas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class