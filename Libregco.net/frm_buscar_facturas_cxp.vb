Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_facturas_cxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim Privilegio As New Label

    Private Sub frm_buscar_facturas_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCompra,SecondID,Fecha,Compras.IDSuplidor,Suplidor,NoFactura,TotalNeto FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where IDCompra like '%" + txtBuscar.Text + "%' and IDTipoDocumento=19 ORDER BY IDCompra ASC", ConMixta)
            ElseIf rdbNoFactura.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCompra,SecondID,Fecha,Compras.IDSuplidor,Suplidor,NoFactura,TotalNeto FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NoFactura like '%" + txtBuscar.Text + "%' and IDTipoDocumento=19 ORDER BY NoFactura ASC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")

            Bs.DataMember = "Compras"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCompras.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbNoFactura.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvCompras
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 80
            .Columns(2).Width = 75
            .Columns(3).HeaderText = "ID Sup."
            .Columns(3).Width = 70
            .Columns(4).Width = 160
            .Columns(5).HeaderText = "No. Fact."
            .Columns(5).Width = 80
            .Columns(6).Width = 130
            .Columns(6).DefaultCellStyle.Format = "C"
        End With
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoFactura.CheckedChanged
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

    Private Sub DgvCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCompras.Focus()
    End Sub

    Private Sub DgvCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCompras.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCompras.Focus()
        End If
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

    Private Sub VerificarPrivilegios()
        Try
            Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,IDPrivilegios FROM" & SysName.Text & "Empleados Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", ConMixta)
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


    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_factura_cxp.Name Then
                Dim IDCompra As New Label
                Dim DsTemp As New DataSet

                IDCompra.Text = DgvCompras.CurrentRow.Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCompra,IDTipoDocumento,SecondID,Compras.IDSuplidor,Suplidor.Suplidor,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero,IDUsuario,Compras.Fecha,Compras.Hora,Compras.IDCondicion,Condicion.Condicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,NCF,TipoItbis,Compras.IDAlmacen,Almacen.Almacen,SubTotal,Descuento,Descuento2,Itbis,Flete,TotalNeto,IDEmpleadoRec,Recepcion.Nombre as NombreRecepcion,DiaRecepcion,Compras.Balance,RutaDocumento,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoalPago,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDMoneda,TipoMoneda.Moneda,Compras.Tasa,Compras.Nulo,Compras.SubtotalLlenado FROM" & SysName.Text & "Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN " & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN " & SysName.Text & "Empleados as Recepcion on Compras.IDEmpleadoRec=Recepcion.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto Where Compras.IDCompra='" + IDCompra.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Compras")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Compras")

                VerificarPrivilegios()
                If Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                    Exit Sub
                End If
                frm_superclave.IDAccion.Text = 15
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                frm_factura_cxp.txtIDCompra.Text = IDCompra.Text
                frm_factura_cxp.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_factura_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_factura_cxp.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_factura_cxp.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_factura_cxp.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_factura_cxp.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_factura_cxp.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))

                frm_factura_cxp.cbxCondicion.Tag = (Tabla.Rows(0).Item("IDCondicion"))
                frm_factura_cxp.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                frm_factura_cxp.DtpFechaFact.Value = (Tabla.Rows(0).Item("FechaFactura"))
                frm_factura_cxp.DtpVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))
                frm_factura_cxp.txtNoFact.Text = (Tabla.Rows(0).Item("NoFactura"))
                frm_factura_cxp.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_factura_cxp.CbxTipoComprobante.Tag = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_factura_cxp.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_factura_cxp.txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_factura_cxp.CbxAlmacen.Tag = (Tabla.Rows(0).Item("IDAlmacen"))
                frm_factura_cxp.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
                frm_factura_cxp.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
                frm_factura_cxp.txtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
                frm_factura_cxp.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ITBIS")).ToString("C")
                frm_factura_cxp.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
                frm_factura_cxp.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_factura_cxp.CbxEmpleadoRec.Text = (Tabla.Rows(0).Item("NombreRecepcion"))
                frm_factura_cxp.CbxEmpleadoRec.Tag = (Tabla.Rows(0).Item("IDEmpleadoRec"))
                frm_factura_cxp.DtpDiaRecibido.Value = (Tabla.Rows(0).Item("DiaRecepcion"))
                frm_factura_cxp.txtNotaCompra.Text = (Tabla.Rows(0).Item("Nota"))
                frm_factura_cxp.RutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))
                frm_factura_cxp.cbxGasto.Text = (Tabla.Rows(0).Item("TipoGasto"))
                frm_factura_cxp.cbxMoneda.Text = (Tabla.Rows(0).Item("Moneda"))
                frm_factura_cxp.txtTasa.Text = (Tabla.Rows(0).Item("Tasa"))
                frm_factura_cxp.chkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                If Tabla.Rows(0).Item("SubtotalLlenado") = 0 Then
                    frm_factura_cxp.lblStatusBar.ForeColor = SystemColors.Highlight
                    frm_factura_cxp.lblStatusBar.Text = "La factura no ha sido verificada en el control de subtotales."
                End If

                frm_factura_cxp.HabilitarEnvioDatos()
                frm_factura_cxp.MostrarControlSubTotales()

                Tabla.Dispose()
                DsTemp.Dispose()
            End If

            Me.Close()

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class