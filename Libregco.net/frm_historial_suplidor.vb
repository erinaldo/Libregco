Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_historial_suplidor

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds2 As New DataSet      'Usual sin interrupcion
    Friend IDSuplidor, IDUsuario, Privilegio As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_historial_suplidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ObtenerIDs()
        RefrescarDgvs()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub RefrescarDgvs()
        If IDSuplidor.Text = "" Then
            Me.Close()
        Else
            RefrescarCompras()
            RefrescarArticulosCompra()
            RefrescarCxP()
            RefrescarPagos()
            RefrescarOrdenes()
        End If
    End Sub

    Private Sub LimpiarDatos()
        IDSuplidor.Text = ""
        lblNombreSuplidor.Text = ""
        txtBalance.Clear()
        txtTotal.Clear()
        txtTotalPagos.Clear()
    End Sub

    Private Sub ObtenerIDs()
        If Me.Owner.Name = frm_registro_compras.Name Then
            IDSuplidor.Text = frm_registro_compras.txtIDSuplidor.Text
            lblNombreSuplidor.Text = frm_registro_compras.txtNombreSuplidor.Text
            IDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        ElseIf Me.Owner.Name = frm_pago_compras.Name Then
            IDSuplidor.Text = frm_pago_compras.txtIDSuplidor.Text
            lblNombreSuplidor.Text = frm_pago_compras.txtSuplidor.Text
            IDUsuario.Text = frm_pago_compras.lblIDUsuario.Text
        ElseIf Me.Owner.Name = frm_inicio.Name Then
            frm_buscar_suplidor.ShowDialog(Me)
        End If


    End Sub

    Sub RefrescarCompras()
        Try
            Dim Dstemp, DsTemp1 As New DataSet

            Dstemp.Clear()
            If Me.Owner.Name = frm_registro_compras.Name Then
                cmd = New MySqlCommand("SELECT IDCompra,SecondID,FechaFactura,FechaVencimiento,NoFactura,Referencia,NCF,Itbis,TotalNeto FROM Compras Where IDSuplidor='" + IDSuplidor.Text + "' and Compras.Nulo=0 and IDTipoDocumento=6 ORDER BY IDCompra DESC", Con)
            ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                cmd = New MySqlCommand("SELECT IDCompra,SecondID,FechaFactura,FechaVencimiento,NoFactura,Referencia,NCF,Itbis,TotalNeto FROM Compras Where IDSuplidor='" + IDSuplidor.Text + "' and Compras.Nulo=0 and IDTipoDocumento=19 ORDER BY IDCompra DESC", Con)
            ElseIf Me.Owner.Name = frm_pago_compras.Name Then
                cmd = New MySqlCommand("SELECT IDCompra,SecondID,FechaFactura,FechaVencimiento,NoFactura,Referencia,NCF,Itbis,TotalNeto FROM Compras Where IDSuplidor='" + IDSuplidor.Text + "' and Compras.Nulo=0 and IDTipoDocumento=6 ORDER BY IDCompra DESC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Compras")
            DgvCompras.DataSource = Dstemp
            DgvCompras.DataMember = "Compras"
            PropiedadDgvCompras()
            SumarTotalCompras()


            Dim IDCompra As New Label
            IDCompra.Text = DgvCompras.Rows(0).Cells(0).Value

            DsTemp1.Clear()
            cmd = New MySqlCommand("SELECT IDDetalleCompra,IDCompra,IDArticulo,Cantidad,Medida,Descripcion,Importe/Cantidad as PrecioUnitario,Importe from DetalleCompra Where IDCompra='" + IDCompra.Text + "' ORDER BY IDDetalleCompra DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp1, "DetalleCompra")
            DgvArticulosComprados.DataSource = DsTemp1
            DgvArticulosComprados.DataMember = "DetalleCompra"
            PropiedadDgvArticulosComprados()

            lblCantCompras.Text = "Cantidad de compras: " & DgvCompras.Rows.Count
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarArticulosCompra()
        Try
            Dim DsTemp As New DataSet

            Dim IDCompra As New Label
            IDCompra.Text = DgvCompras.CurrentRow.Cells(0).Value

            If IDCompra.Text <> "" Then
                DsTemp.Clear()
                cmd = New MySqlCommand("SELECT IDDetalleCompra,IDCompra,IDArticulo,Cantidad,Medida,Descripcion,PrecioUnitario,Importe from DetalleCompra Where IDCompra='" + IDCompra.Text + "' ORDER BY IDDetalleCompra DESC", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "DetalleCompra")
                DgvArticulosComprados.DataSource = DsTemp
                DgvArticulosComprados.DataMember = "DetalleCompra"
                PropiedadDgvArticulosComprados()
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PropiedadDgvArticulosComprados()
        With DgvArticulosComprados
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Código"
            .Columns(3).Width = 80
            .Columns(3).HeaderText = "Cant."
            .Columns(4).Width = 80
            .Columns(4).HeaderText = "Medida"
            .Columns(5).Width = 300
            .Columns(5).HeaderText = "Descripción"
            .Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Columns(6).Width = 110
            .Columns(6).HeaderText = "Precio"
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 110
            .Columns(7).HeaderText = "Importe"
            .Columns(7).DefaultCellStyle.Format = ("C")
        End With

    End Sub

    Sub RefrescarPagos()
        Try
            Dim DsTemp As New DataSet

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDPagoCompra,SecondID,IDSuplidor,Fecha,Importe,Retencion,Neto,Concepto from PagoCompra Where IDSuplidor='" + IDSuplidor.Text + "' AND PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "PagoCompra")
            DgvPagos.DataSource = DsTemp
            DgvPagos.DataMember = "PagoCompra"
            PropiedadDgvPagos()
            SumarPagos()

            lblCantPagos.Text = "Cantidad de pagos: " & DgvPagos.Rows.Count
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub RefrescarOrdenes()
        Try
            Dim DsOrdenes As New DataSet

            DsOrdenes.Clear()
            cmd = New MySqlCommand("SELECT IDOrdenCOmpra,SecondID,Fecha,Referencia,Comentario,IDTipoOrden,TipoOrdenCompra.Descripcion,Total FROM libregco.ordencompra INNER JOIN Libregco.TipoOrdenCompra on OrdenCompra.IDTipoOrden=TipoOrdenCompra.IDTipoOrdenCompra where IDSuplidor='" + IDSuplidor.Text + "' AND OrdenCompra.Nulo=0 ORDER BY IDOrdenCompra DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsOrdenes, "OrdenCompra")
            DgvOrdenes.DataSource = DsOrdenes
            DgvOrdenes.DataMember = "OrdenCompra"
            PropiedadDgvOrdenes()

            lblCantNotas.Text = "Cantidad de ordenes: " & DgvOrdenes.Rows.Count
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub PropiedadDgvOrdenes()
        With DgvOrdenes
            .Columns(0).Visible = False
            .Columns(1).Width = 110
            .Columns(1).HeaderText = "Código"

            .Columns(2).Width = 100

            .Columns(3).Width = 100

            .Columns(4).Width = 140
           
            .Columns(5).Width = 80
            .Columns(5).HeaderText = "Status"

            .Columns(6).Width = 140
            .Columns(6).HeaderText = "Estado"

            .Columns(7).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 100
        End With
    End Sub

    Private Sub PropiedadDgvPagos()
        With DgvPagos
            .Columns(0).Visible = False
            .Columns(1).Width = 110
            .Columns(1).HeaderText = "Código Pago"
            .Columns(2).Visible = False
            .Columns(3).Width = 110
            .Columns(3).HeaderText = "Fecha"
            .Columns(4).Width = 110
            .Columns(4).HeaderText = "Importe"
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 110
            .Columns(5).HeaderText = "Retenido"
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 120
            .Columns(6).HeaderText = "Total Neto"
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 200
        End With
    End Sub

    Sub RefrescarCxP()
        Try
            Dim DsTemp As New DataSet

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDCompra,SecondID,NoFactura,FechaFactura,Referencia,NCF,FechaVencimiento,TotalNeto,Balance FROM Compras Where IDSuplidor='" + IDSuplidor.Text + "' AND Balance>0 AND Compras.Nulo=0 ORDER BY IDCompra DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "CxP")
            DgvCxP.DataSource = DsTemp
            DgvCxP.DataMember = "CxP"
            PropiedadDgvCxP()
            SumarCxP()

            lblCantCXP.Text = "Cantidad de cuentas por pagar: " & DgvCxP.Rows.Count

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PropiedadDgvCxP()
        Dim DatagridWith As Double = (DgvCxP.Width - DgvCxP.RowHeadersWidth) / 100

        With DgvCxP
            .Columns(0).Visible = False

            .Columns(1).Width = DatagridWith * 14
            .Columns(1).HeaderText = "Código"

            .Columns(2).Width = DatagridWith * 12
            .Columns(2).HeaderText = "Factura"

            .Columns(3).Width = DatagridWith * 10
            .Columns(3).HeaderText = "Fecha"

            .Columns(4).Visible = False

            .Columns(5).Width = DatagridWith * 20
            .Columns(5).HeaderText = "NCF"

            .Columns(6).Width = DatagridWith * 12
            .Columns(6).HeaderText = "Vence"

            .Columns(7).Width = DatagridWith * 16
            .Columns(7).HeaderText = "Monto"
            .Columns(7).DefaultCellStyle.Format = ("C")

            .Columns(8).Width = DatagridWith * 16
            .Columns(8).HeaderText = "Balance"
            .Columns(8).DefaultCellStyle.Format = ("C")
        End With

    End Sub

    Private Sub SumarPagos()
        Dim x As Integer = 0
        Dim Pagos As Double = 0

Inicio:
        If x = DgvPagos.Rows.Count Then
            GoTo Final
        Else
            Pagos = (Pagos + CDbl(DgvPagos.Rows(x).Cells(6).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtTotalPagos.Text = Pagos.ToString("C")
    End Sub

    Private Sub SumarTotalCompras()
        Dim x As Integer = 0
        Dim Neto As Double = 0

Inicio:
        If x = DgvCompras.Rows.Count Then
            GoTo Final
        Else
            Neto = (Neto + CDbl(DgvCompras.Rows(x).Cells(8).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtTotal.Text = Neto.ToString("C")
    End Sub

    Private Sub SumarCxP()
        Dim x As Integer = 0
        Dim Balance As Double = 0

Inicio:
        If x = DgvCxP.Rows.Count Then
            GoTo Final
        Else
            Balance = (Balance + CDbl(DgvCxP.Rows(x).Cells(7).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtBalance.Text = Balance.ToString("C")
    End Sub

    Private Sub PropiedadDgvCompras()
        Dim DatagridWith As Double = (DgvCompras.Width - DgvCompras.RowHeadersWidth) / 100
        With DgvCompras
            .Columns(0).Visible = False

            .Columns(1).Width = DatagridWith * 12
            .Columns(1).HeaderText = "Código"

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = DatagridWith * 10

            .Columns(3).Width = DatagridWith * 10
            .Columns(3).HeaderText = "Venc."

            .Columns(4).Width = DatagridWith * 15
            .Columns(4).HeaderText = "Factura"

            .Columns(5).Width = DatagridWith * 7
            .Columns(5).HeaderText = "Ref."

            .Columns(6).HeaderText = "NCF"
            .Columns(6).Width = DatagridWith * 18

            .Columns(7).Width = DatagridWith * 14
            .Columns(7).HeaderText = "ITBIS"
            .Columns(7).DefaultCellStyle.Format = ("C")

            .Columns(8).Width = DatagridWith * 14
            .Columns(8).HeaderText = "Total Neto"
            .Columns(8).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_registro_compras.Name Then
                Dim IDCompra As New Label

                IDCompra.Text = DgvCompras.CurrentRow.Cells(0).Value

                Ds.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCompra,IDTipoDocumento,SecondID,Compras.IDSuplidor,Suplidor.Suplidor,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero,IDUsuario,Compras.Fecha,Compras.Hora,Compras.IDCondicion,Condicion.Condicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,NCF,TipoItbis,Compras.IDAlmacen,Almacen.Almacen,SubTotal,Descuento,Descuento2,Itbis,Flete,TotalNeto,IDEmpleadoRec,Recepcion.Nombre as NombreRecepcion,DiaRecepcion,Compras.Balance,RutaDocumento,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoalPago,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDMoneda,TipoMoneda.Moneda,Compras.Tasa,Compras.Nulo,Compras.SubtotalLlenado FROM" & SysName.Text & "Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN " & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN " & SysName.Text & "Empleados as Recepcion on Compras.IDEmpleadoRec=Recepcion.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto Where Compras.IDCompra='" + IDCompra.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Compras")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds.Tables("Compras")

                VerificarPrivilegios()
                If Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                    Exit Sub
                End If
                frm_superclave.IDAccion.Text = 15
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                frm_registro_compras.txtIDCompra.Text = IDCompra.Text
                frm_registro_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_registro_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_registro_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_registro_compras.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_registro_compras.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_registro_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))

                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_registro_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                End If

                frm_registro_compras.cbxCondicion.Tag = (Tabla.Rows(0).Item("IDCondicion"))
                frm_registro_compras.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_registro_compras.DtpFechaFact.Value = (Tabla.Rows(0).Item("FechaFactura"))
                frm_registro_compras.DtpVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))
                frm_registro_compras.txtNoFact.Text = (Tabla.Rows(0).Item("NoFactura"))
                frm_registro_compras.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_registro_compras.CbxTipoComprobante.Tag = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_registro_compras.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_registro_compras.txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_registro_compras.lblTipoItbis.Text = (Tabla.Rows(0).Item("TipoItbis"))
                frm_registro_compras.LUEAlmacen.EditValue = (Tabla.Rows(0).Item("IDAlmacen"))
                frm_registro_compras.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
                frm_registro_compras.txtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
                frm_registro_compras.txtDescuento2.Text = CDbl(Tabla.Rows(0).Item("Descuento2")).ToString("C")
                frm_registro_compras.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ITBIS")).ToString("C")
                frm_registro_compras.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
                frm_registro_compras.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_registro_compras.txtRecepcion.Tag = (Tabla.Rows(0).Item("IDEmpleadoRec"))
                frm_registro_compras.txtRecepcion.Text = (Tabla.Rows(0).Item("NombreRecepcion"))
                frm_registro_compras.DtpDiaRecibido.Value = (Tabla.Rows(0).Item("DiaRecepcion"))
                frm_registro_compras.txtNotaCompra.Text = (Tabla.Rows(0).Item("Nota"))
                frm_registro_compras.RutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))
                frm_registro_compras.LUEGasto.EditValue = (Tabla.Rows(0).Item("IDTipoGasto"))
                frm_registro_compras.LueMoneda.EditValue = (Tabla.Rows(0).Item("IDMoneda"))
                frm_registro_compras.txtTasa.Text = (Tabla.Rows(0).Item("Tasa"))
                frm_registro_compras.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                If (Tabla.Rows(0).Item("PrecioDiferido")) = 0 Then
                    frm_registro_compras.chkpreciosdiferidos.Checked = False
                Else
                    frm_registro_compras.chkpreciosdiferidos.Checked = True
                End If

                If (Tabla.Rows(0).Item("CreditoPendiente")) = 0 Then
                    frm_registro_compras.chkcreditospendientes.Checked = False
                Else
                    frm_registro_compras.chkcreditospendientes.Checked = True
                End If

                If (Tabla.Rows(0).Item("ArticuloFuera")) = 0 Then
                    frm_registro_compras.chkArtfuerapedido.Checked = False
                Else
                    frm_registro_compras.chkArtfuerapedido.Checked = True
                End If

                If (Tabla.Rows(0).Item("NegociarFlete")) = 0 Then
                    frm_registro_compras.chkrenegociarflete.Checked = False
                Else
                    frm_registro_compras.chkrenegociarflete.Checked = True
                End If

                If (Tabla.Rows(0).Item("Averiados")) = 0 Then
                    frm_registro_compras.chkAveriados.Checked = False
                Else
                    frm_registro_compras.chkAveriados.Checked = True
                End If

                If (Tabla.Rows(0).Item("DescuentoalPago")) = 0 Then
                    frm_registro_compras.chkDescuentoPago.Checked = False
                Else
                    frm_registro_compras.chkDescuentoPago.Checked = True
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_compras.ChkNulo.Checked = False
                Else
                    frm_registro_compras.ChkNulo.Checked = True
                End If
                If (Tabla.Rows(0).Item("TipoItbis")) = 1 Then
                    frm_registro_compras.rdbIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 2 Then
                    frm_registro_compras.rdbNoIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 3 Then
                    frm_registro_compras.rdbNoItbis.Checked = True
                End If

                If Tabla.Rows(0).Item("SubtotalLlenado") = 0 Then
                    frm_registro_compras.lblStatusBar.ForeColor = SystemColors.Highlight
                    frm_registro_compras.lblStatusBar.Text = "La factura no ha sido verificada en el control de subtotales."
                End If

                frm_registro_compras.RefrescarTablaArticulos()
                frm_registro_compras.HabilitarPanelItibis()
                frm_registro_compras.HabilitarEnvioDatos()
                frm_registro_compras.MostrarControlSubTotales()
                frm_registro_compras.PreciosDinámicosToolStripMenuItem.Visible = True
                Tabla.Dispose()

                Me.Close()
            End If


        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub VerificarPrivilegios()
        Try
            Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,IDPrivilegios FROM" & SysName.Text & "Empleados Where IDEmpleado='" + IDUsuario.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Empleados")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Empleados")

            Privilegio.Text = (Tabla.Rows(0).Item("IDPrivilegios"))

            If Privilegio.Text = 1 Or Privilegio.Text = 4 Then
                Exit Sub
            End If
            If Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                MessageBox.Show("No posee los permisos necesarios para poder accesar y modificar los recibos ya procesados en el sistema.", "No se encontraron los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvCompras_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvCompras.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvCompras.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvCompras.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvCompras.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvCompras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub DgvCompras_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCompras.SelectionChanged
        RefrescarArticulosCompra()
    End Sub

    Private Sub DgvCxP_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvCxP.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvCxP.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvCxP.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvCxP.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCompras.KeyPress
        If DgvCompras.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                LlenarFormularios()
            End If
        End If
    End Sub

    Private Sub DgvPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPagos.KeyPress
        If DgvPagos.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                LlenarPagos()
            End If
        End If
    End Sub

    Private Sub DgvArticulosComprados_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvArticulosComprados.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvArticulosComprados.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvArticulosComprados.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvArticulosComprados.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPagos.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPagos.ColumnCount
                Dim NumRows As Integer = DgvPagos.RowCount
                Dim CurCell As DataGridViewCell = DgvPagos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPagos.CurrentCell = DgvPagos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPagos.CurrentCell = DgvPagos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCompras.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCompras.ColumnCount
                Dim NumRows As Integer = DgvCompras.RowCount
                Dim CurCell As DataGridViewCell = DgvCompras.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCompras.CurrentCell = DgvCompras.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCompras.CurrentCell = DgvCompras.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvCxP_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCxP.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub


    Private Sub frm_historial_suplidor_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            PropiedadDgvCompras()
            PropiedadDgvArticulosComprados()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LlenarPagos()
        Dim IDPago As New Label
        Dim DsTemp As New DataSet
        Try

            IDPago.Text = DgvPagos.CurrentRow.Cells(0).Value

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPagoCompra,SecondID,Fecha,Hora,PagoCompra.IDSucursal,Sucursal.Sucursal,PagoCompra.IDAlmacen,Almacen.Almacen,PagoCompra.IDUsuario,Usuarios.Nombre as NombreUsuario,PagoCompra.IDSuplidor,Suplidor.Suplidor,BceAnterior,MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,PagoCompra.Nulo FROM" & SysName.Text & "pagocompra INNER JOIN" & SysName.Text & "Sucursal on PagoCompra.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on PagoCompra.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagoCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.Suplidor on PagoCompra.IDSuplidor=Suplidor.IDSuplidor Where IDPagoCompra='" + IDPago.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Pagocompras")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Pagocompras")

            If Me.Owner.Name = frm_pago_compras.Name Then
                frm_pago_compras.txtIDPago.Text = (Tabla.Rows(0).Item("IDPagoCompra"))
                frm_pago_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_pago_compras.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_pago_compras.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_pago_compras.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("MontoAplicado")).ToString("C")
                frm_pago_compras.txtCheque.Text = CDbl(Tabla.Rows(0).Item("Cheque")).ToString("C")
                frm_pago_compras.txtEfectivo.Text = CDbl(Tabla.Rows(0).Item("Efectivo")).ToString("C")
                frm_pago_compras.txtTransferencia.Text = CDbl(Tabla.Rows(0).Item("Transferencia")).ToString("C")
                frm_pago_compras.txtImporte.Text = CDbl(Tabla.Rows(0).Item("Importe")).ToString("C")
                frm_pago_compras.txtDescRet.Text = CDbl(Tabla.Rows(0).Item("Retencion")).ToString("C")
                frm_pago_compras.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_pago_compras.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_pago_compras.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_pago_compras.lblTransferenciaReferencia.Text = (Tabla.Rows(0).Item("TransferenciaReferencia"))
                frm_pago_compras.lblTransferenciaCuenta.Text = (Tabla.Rows(0).Item("TransferenciaCuenta"))
                frm_pago_compras.lblTransferenciaBanco.Text = (Tabla.Rows(0).Item("TransferenciaBanco"))
                frm_pago_compras.lblChequeNumero.Text = (Tabla.Rows(0).Item("ChequeNumero"))
                frm_pago_compras.lblChequeFecha.Text = (Tabla.Rows(0).Item("ChequeFecha"))
                frm_pago_compras.lblChequeBanco.Text = (Tabla.Rows(0).Item("ChequeBanco"))
                frm_pago_compras.lblChequeCuenta.Text = (Tabla.Rows(0).Item("ChequeCuenta"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_compras.ChkNulo.Checked = False
                Else
                    frm_registro_compras.ChkNulo.Checked = True
                End If

                Con.Open()
                frm_pago_compras.DgvCompras.Rows.Clear()
                Dim Da As New MySqlCommand("SELECT IDPagoComprasDetalle,IDPagoCompra,PagoComprasDetalle.IDCompra,Compras.NoFactura,Compras.FechaFactura,Compras.FechaVencimiento,Compras.TotalNeto,PagoComprasDetalle.BceAnterior,RetISR,RetItbis,PagoComprasDetalle.Descuento,Aplicado,NCF,Compras.SecondID,if(Compras.FechaFactura<Now(),DATEDIFF(now(),Compras.FechaFactura),0) as DiasVencidos FROM pagocomprasdetalle INNER JOIN Compras on PagoComprasDetalle.IDCompra=Compras.IDCompra where IDPagoCompra='" + IDPago.Text + "'", Con)
                Dim LectorPago As MySqlDataReader = Da.ExecuteReader

                While LectorPago.Read
                    frm_pago_compras.DgvCompras.Rows.Add(LectorPago.GetValue(0), LectorPago.GetValue(1), LectorPago.GetValue(2), LectorPago.GetValue(3), CDate(LectorPago.GetValue(4)).ToString("dd/MM/yyyy"), CDate(LectorPago.GetValue(5)).ToString("dd/MM/yyyy"), LectorPago.GetValue(6), LectorPago.GetValue(7), LectorPago.GetValue(8), LectorPago.GetValue(9), LectorPago.GetValue(10), LectorPago.GetValue(11), False, CDbl(CDbl(LectorPago.GetValue(7)) - CDbl(LectorPago.GetValue(11))).ToString("C"), LectorPago.GetValue(12), LectorPago.GetValue(13), LectorPago.GetValue(14))
                End While

                LectorPago.Close()
                Con.Close()

                frm_pago_compras.BuscarAfecciones()
            End If

            Close()

            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagos.CellDoubleClick
        LlenarPagos
    End Sub
End Class