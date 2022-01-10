Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_suplidor

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_sup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDSuplidor,Suplidor,RNC,Telefono FROM Suplidor where IDSuplidor like '%" + txtBuscar.Text + "%' ORDER BY IDSuplidor ASC LIMIT 50", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDSuplidor,Suplidor,RNC,Telefono FROM Suplidor where Suplidor like '%" + txtBuscar.Text + "%' ORDER BY Suplidor ASC LIMIT 50", ConLibregco)
            ElseIf rdbCedula.Checked = True Then
                cmd = New MySqlCommand("SELECT IDSuplidor,Suplidor,RNC,Telefono FROM Suplidor where rnc like '%" + txtBuscar.Text + "%'  ORDER BY RNC ASC LIMIT 50", ConLibregco)
            ElseIf rdbTelefono.Checked = True Then
                cmd = New MySqlCommand("SELECT IDSuplidor,Suplidor,RNC,Telefono FROM Suplidor where Suplidor like '%" + txtBuscar.Text + "%' ORDER BY Suplidor ASC LIMIT 50", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Suplidor")

            Bs.DataMember = "Suplidor"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvSuplidor.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        DgvSuplidor.Columns(0).HeaderText = "Código"
        DgvSuplidor.Columns(0).Width = 80
        DgvSuplidor.Columns(1).Width = 330
        DgvSuplidor.Columns(2).Width = 110
        DgvSuplidor.Columns(3).HeaderText = "Teléfono"
        DgvSuplidor.Columns(3).Width = 110
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCedula_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCedula.CheckedChanged
         RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbTelefono_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTelefono.CheckedChanged
          RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
          RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvSuplidor.Focus()
    End Sub

    Private Sub DgvSuplidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvSuplidor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DgvSuplidor.Rows.Count > 0 Then
                LlenarFormularios()
            Else
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvSuplidor.Focus()
        End If
    End Sub

    Private Sub DgvSuplidor_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSuplidor.KeyDown
        Try
            If DgvSuplidor.Rows.Count > 0 Then
                If e.KeyCode = Keys.Enter Then
                    Dim NumCols As Integer = DgvSuplidor.ColumnCount
                    Dim NumRows As Integer = DgvSuplidor.RowCount
                    Dim CurCell As DataGridViewCell = DgvSuplidor.CurrentCell
                    If CurCell.ColumnIndex = NumCols - 1 Then
                        If CurCell.RowIndex < NumRows - 1 Then
                            DgvSuplidor.CurrentCell = DgvSuplidor.Item(0, CurCell.RowIndex + 1)
                        End If
                    Else
                        DgvSuplidor.CurrentCell = DgvSuplidor.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                    End If
                    e.Handled = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim DsLlenarFormulario As New DataSet
            Dim IDSuplidor As New Label
            IDSuplidor.Text = DgvSuplidor.CurrentRow.Cells(0).Value

            DsLlenarFormulario.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDSuplidor,Suplidor,TipoIdentificacion.Descripcion,TipoIdentificacion.IDTipoIdentificacion,RNC,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero from Libregco.Suplidor INNER JOIN Libregco.tipoidentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Condicion on Suplidor.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto Where IDSuplidor= '" + IDSuplidor.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsLlenarFormulario, "Suplidor")
            ConMixta.Close()

            Dim Tabla As DataTable = DsLlenarFormulario.Tables("Suplidor")

            If Me.Owner.Name = frm_mant_suplidor.Name Then
                frm_mant_suplidor.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_mant_suplidor.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_mant_suplidor.lblTipoIdentificacion.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
                frm_mant_suplidor.cbxTipoIdentificacion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_mant_suplidor.txtRnc.Text = (Tabla.Rows(0).Item("RNC"))
                frm_mant_suplidor.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
                frm_mant_suplidor.lblIDProvincia.Text = (Tabla.Rows(0).Item("IDProvincia"))
                frm_mant_suplidor.cbxProvincia.Text = (Tabla.Rows(0).Item("Provincia"))
                frm_mant_suplidor.lblIDMunicipio.Text = (Tabla.Rows(0).Item("IDMunicipio"))
                frm_mant_suplidor.cbxMunicipio.Text = (Tabla.Rows(0).Item("Municipio"))
                frm_mant_suplidor.txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                frm_mant_suplidor.txtTelefono.Text = (Tabla.Rows(0).Item("Telefono"))
                frm_mant_suplidor.txtFax.Text = (Tabla.Rows(0).Item("Fax"))
                frm_mant_suplidor.txtRepresentante.Text = (Tabla.Rows(0).Item("Representante"))
                frm_mant_suplidor.txtTelRep.Text = (Tabla.Rows(0).Item("TelefonoRepresentante"))
                frm_mant_suplidor.txtCorreo.Text = (Tabla.Rows(0).Item("Email"))
                frm_mant_suplidor.txtWeb.Text = (Tabla.Rows(0).Item("Web"))
                frm_mant_suplidor.txtIDTipoSuplidor.Text = (Tabla.Rows(0).Item("IDTipoSuplidor"))
                frm_mant_suplidor.txtTipoSuplidor.Text = (Tabla.Rows(0).Item("TipoSuplidor"))
                frm_mant_suplidor.txtIDCondicion.Text = (Tabla.Rows(0).Item("IDCondicion"))
                frm_mant_suplidor.txtCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_mant_suplidor.txtIDNcf.Text = (Tabla.Rows(0).Item("IDNCF"))
                frm_mant_suplidor.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_mant_suplidor.txtIDTipoGasto.Text = (Tabla.Rows(0).Item("IDGasto"))
                frm_mant_suplidor.txtTipoGasto.Text = (Tabla.Rows(0).Item("TipoGasto"))
                frm_mant_suplidor.txtLimite.Text = CDbl((Tabla.Rows(0).Item("LimiteCredito"))).ToString("C")
                frm_mant_suplidor.txtBalance.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_mant_suplidor.txtFechaRegistro.Text = CDate(Tabla.Rows(0).Item("FechaIngreso")).ToString("yyyy-MM-dd")

                If (Tabla.Rows(0).Item("Desactivar")) = 1 Then
                    frm_mant_suplidor.ChkDesactivar.Checked = True
                Else
                    frm_mant_suplidor.ChkDesactivar.Checked = False
                End If

            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_mant_articulos.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_registro_compras.Name Then
                frm_registro_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_registro_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_registro_compras.lblRNC.Tag = (Tabla.Rows(0).Item("RNC"))
                frm_registro_compras.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_registro_compras.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_registro_compras.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_registro_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_compras.LUEGasto.EditValue = (Tabla.Rows(0).Item("IDGasto"))

                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_registro_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_registro_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If

            ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                frm_factura_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_factura_cxp.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_factura_cxp.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")

                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    frm_factura_cxp.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    frm_factura_cxp.txtUltimoPago.Text = "No hay pagos"
                End If

                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_factura_cxp.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_factura_cxp.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If

                frm_factura_cxp.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_factura_cxp.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))

            ElseIf Me.Owner.Name = frm_pago_compras.Name Then
                frm_pago_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_pago_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_pago_compras.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_pago_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_pago_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_pago_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If
                frm_pago_compras.RefrescarComprasPendientes()

            ElseIf Me.Owner.Name = frm_consulta_facturas_cxp.Name Then
                frm_consulta_facturas_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_facturas_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_nota_debito_credito_cxp.Name Then
                frm_nota_debito_credito_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_nota_debito_credito_cxp.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_nota_debito_credito_cxp.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_nota_debito_credito_cxp.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_nota_debito_credito_cxp.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If
                frm_nota_debito_credito_cxp.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_nota_debito_credito_cxp.RefrescarTablaFacturas()

            ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
                frm_conduce_reparaciones.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_conduce_reparaciones.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_conduce_reparaciones.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_conduce_reparaciones.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_conduce_reparaciones.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_conduce_reparaciones.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If

            ElseIf Me.Owner.Name = frm_recibos_egresos.Name Then
                frm_recibos_egresos.txtBeneficiario.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                frm_reporte_ventas.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_ventas.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_detalle_ventas.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
                frm_reporte_conduce_reparacion.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_conduce_reparacion.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_consulta_stocks.Name Then
                frm_consulta_stocks.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_stocks.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
            ElseIf Me.Owner.Name = frm_consulta_devolucion_compra.Name Then
                frm_consulta_devolucion_compra.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_devolucion_compra.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_orden_compras.Name Then
                frm_orden_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_orden_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_orden_compras.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_orden_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_orden_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_orden_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If

            ElseIf Me.Owner.Name = frm_consulta_conduce_reparacion.Name Then
                frm_consulta_conduce_reparacion.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_conduce_reparacion.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_consulta_pedidos.Name Then
                frm_consulta_pedidos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_pedidos.txtCliente.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_consulta_compras.Name Then
                frm_consulta_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_consulta_orden_compra.Name Then
                frm_consulta_orden_compra.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_orden_compra.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_consulta_orden_compra.VerificarCondicionSuplidor()

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_productos.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_devolucion_ventas.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_compras.Name Then
                frm_reporte_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_detalle_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_devolucion_compras.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_orden_compra.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_series_garantias.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
                frm_reporte_entradas_reparacion.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_entradas_reparacion.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_registro_facturas_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_cuentas_por_pagar.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_pagos_facturas.Name Then
                frm_reporte_pagos_facturas.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_pagos_facturas.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_notas_debito_credito_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_reporte_estado_cuenta_cxp.Name Then
                frm_reporte_estado_cuenta_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_reporte_estado_cuenta_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

                If frm_reporte_estado_cuenta_cxp.txtSuplidor.Text = "" Then
                    frm_reporte_estado_cuenta_cxp.txtIDSuplidor.Clear()
                Else
                    frm_reporte_estado_cuenta_cxp.FillEstadoCuenta()
                End If

            ElseIf Me.Owner.Name = frm_historial_suplidor.Name Then
                frm_historial_suplidor.IDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_historial_suplidor.lblNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_historial_suplidor.IDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()


            ElseIf Me.Owner.Name = frm_consulta_pagos_cxp.Name Then
                frm_consulta_pagos_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_pagos_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_consulta_nota_debito_credito_cxp.Name Then
                frm_consulta_nota_debito_credito_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_consulta_nota_debito_credito_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_antiguedad_saldos_cxp.Name Then
                frm_antiguedad_saldos_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_antiguedad_saldos_cxp.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_solicitud_cheques.Name Then
                frm_solicitud_cheques.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_solicitud_cheques.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_solicitud_cheques.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_solicitud_cheques.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_solicitud_cheques.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_solicitud_cheques.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If
                frm_solicitud_cheques.RefrescarComprasPendientes()

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_actualizar_precios_costos.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                frm_actualizar_propiedades_articulos.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_actualizar_propiedades_articulos.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                frm_ajuste_inventario.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_ajuste_inventario.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))


            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.name Then
                frm_buscar_mant_articulos.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_buscar_mant_articulos.txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_buscar_mant_articulos.RefrescarTablaArticulos()

            ElseIf Me.Owner.Name = frm_subtotales_compras.name Then
                frm_registro_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_registro_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_registro_compras.txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("Balance"))).ToString("C")
                frm_registro_compras.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_registro_compras.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_registro_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_compras.LUEGasto.EditValue = (Tabla.Rows(0).Item("IDGasto"))

                frm_subtotales_compras.lblRazon.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_subtotales_compras.lblRNC.Text = (Tabla.Rows(0).Item("RNC"))
            End If


            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvSuplidor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSuplidor.CellDoubleClick
        Try

            If e.RowIndex >= 0 Then
                LlenarFormularios()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_buscar_suplidor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

    Private Sub frm_buscar_suplidor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.F2 Then
            e.Handled = True
            txtBuscar.Focus()
        End If
    End Sub
End Class