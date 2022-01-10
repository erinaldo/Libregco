Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_previsualizacion_compra

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend RutaDocumento As New Label

    Private Sub frm_previsualizacion_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
        LlenarFormularios()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCompra.Clear()
        txtSecondID.Clear()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        txtNoFact.Clear()
        txtReferencia.Clear()
        txtIDRecepcion.Clear()
        txtRecepcion.Clear()
        txtNCF.Clear()
        txtNotaCompra.Clear()
        cbxCondicion.Items.Clear()
        CbxTipoComprobante.Items.Clear()
        CbxAlmacen.Items.Clear()
        RutaDocumento.Text = ""
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        ControlSuperClave = 0
        chkpreciosdiferidos.Checked = False
        chkcreditospendientes.Checked = False
        chkArtfuerapedido.Checked = False
        chkrenegociarflete.Checked = False
        chkAveriados.Checked = False
        txtSubTotal.Text = CDbl(0.0).ToString("C4")
        txtFlete.Text = CDbl(0.0).ToString("C4")
        txtNeto.Text = CDbl(0.0).ToString("C4")
        txtDescuento.Text = CDbl(0.0).ToString("C4")
        txtPorDescuento2.Text = CDbl(0).ToString("P")
        txtDescuento2.Text = CDbl(0.0).ToString("C4")
        txtItbis.Text = CDbl(0.0).ToString("C4")
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        DtpFechaFact.Value = Today
        DtpVencimiento.Value = Today
        DtpDiaRecibido.Value = Today
        DtpDiaRecibido.Value = Today
        FillComprobanteFiscal()
        FillAlmacen()
        FillCondicion()
    End Sub

    Private Sub FillAlmacen()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "' and Desactivar=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Almacen")
            CbxAlmacen.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Almacen")
            For Each Fila As DataRow In Tabla.Rows
                CbxAlmacen.Items.Add(Fila.Item("Almacen"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxAlmacen.SelectedIndex = 0
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillComprobanteFiscal()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM comprobantefiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            CbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillCondicion()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Libregco.Condicion Where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next
            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub


    Private Sub ColumnasDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDDetalleCompra", "IDDetalleCompra")  '0
            .Columns.Add("IDCompra", "IDCompra")    '1
            .Columns.Add("IDPrecio", "IDPrecio")    '2
            .Columns.Add("IDArticulo", "Código")    '3
            .Columns.Add("Descripcion", "Descripción")  '4
            .Columns.Add("IDMedida", "IDMedida")    '5
            .Columns.Add("Medida", "Medida")        '6
            .Columns.Add("Cantidad", "Cant.")   '7
            .Columns.Add("PrecioUnitario", "Precio Unit.") '8
            .Columns.Add("Descuento", "Descuento")  '9
            .Columns.Add("Descuento2", "Descuento2") '10
            .Columns.Add("Itbis", "Itbis")  '11
            .Columns.Add("Importe", "Importe Unit.")  '12
            .Columns.Add("IDAlmacen", "Almacén") '13
            .Columns.Add("CostoFinalUnitario", "Costo final") '14
            .Columns.Add("ImporteTotal", "Importe") '15

        End With
        PropiedadesDgvArticulos()
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            If DgvArticulos.Columns.Count > 0 Then
                Dim Condicion As String = False
                Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100

                With DgvArticulos
                    .Columns("IDDetalleCompra").Visible = Condicion '0
                    .Columns("IDDetalleCompra").ReadOnly = True

                    .Columns("IDCompra").Visible = Condicion '1
                    .Columns("IDCompra").ReadOnly = True

                    .Columns("IDPrecio").Visible = Condicion '2
                    .Columns("IDPrecio").ReadOnly = True

                    .Columns("IDArticulo").Width = DatagridWith * 12 '3
                    .Columns("IDArticulo").ReadOnly = True

                    .Columns("Descripcion").Width = DatagridWith * 30   '4
                    .Columns("Descripcion").ReadOnly = True
                    .Columns("Descripcion").DefaultCellStyle.WrapMode = DataGridViewTriState.True

                    .Columns("IDMedida").Visible = Condicion    '5
                    .Columns("IDMedida").ReadOnly = True

                    .Columns("Medida").Width = DatagridWith * 6 '6
                    .Columns("Medida").ReadOnly = True

                    .Columns("Cantidad").Width = DatagridWith * 6   '7
                    .Columns("Cantidad").HeaderText = "Cant."
                    .Columns("Cantidad").ReadOnly = True

                    .Columns("PrecioUnitario").Visible = Condicion
                    .Columns("PrecioUnitario").ReadOnly = True

                    .Columns("Descuento").Visible = Condicion
                    .Columns("Descuento").ReadOnly = True

                    .Columns("Descuento2").Visible = Condicion   '10
                    .Columns("Descuento2").ReadOnly = True

                    .Columns("Itbis").Visible = Condicion
                    .Columns("Itbis").ReadOnly = True

                    .Columns("Importe").DefaultCellStyle.Format = ("C4")    '12
                    .Columns("Importe").HeaderText = "Importe Unit."
                    .Columns("Importe").Width = DatagridWith * 12
                    .Columns("Importe").ReadOnly = True

                    .Columns("IDAlmacen").Width = DatagridWith * 8  '13
                    .Columns("IDAlmacen").DisplayIndex = 15
                    .Columns("IDAlmacen").ReadOnly = True
                    .Columns("IDAlmacen").DefaultCellStyle.BackColor = Color.LightGray

                    .Columns("CostoFinalUnitario").DisplayIndex = 13           '15
                    .Columns("CostoFinalUnitario").DefaultCellStyle.BackColor = Color.LightGray
                    .Columns("CostoFinalUnitario").DefaultCellStyle.Format = ("C4")
                    .Columns("CostoFinalUnitario").Width = DatagridWith * 12

                    .Columns("ImporteTotal").Width = DatagridWith * 14 '14
                    .Columns("ImporteTotal").DefaultCellStyle.BackColor = Color.Gray
                    .Columns("ImporteTotal").DefaultCellStyle.ForeColor = Color.White
                    .Columns("ImporteTotal").DefaultCellStyle.Format = ("C4")
                    .Columns("ImporteTotal").HeaderText = "Importe Total"
                    .Columns("ImporteTotal").ReadOnly = True
                End With

            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub LlenarFormularios()
        Try
            Dim DsTemp As New DataSet
            Dim IDCompra As New Label
            IDCompra.Text = frm_pago_compras.DgvCompras.CurrentRow.Cells(2).Value

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDCompra,IDTipoDocumento,SecondID,Compras.IDSuplidor,Suplidor.Suplidor,IDUsuario,Fecha,Hora,Compras.IDCondicion,Condicion.Condicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,NCF,TipoItbis,Compras.IDAlmacen,Almacen.Almacen,SubTotal,Descuento,Descuento2,Itbis,Flete,TotalNeto,IDEmpleadoRec,Recepcion.Nombre as NombreRecepcion,DiaRecepcion,Compras.Balance,RutaDocumento,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,Compras.Nulo,Suplidor.Balance as BceGeneral,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero FROM" & SysName.Text & "Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN " & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN " & SysName.Text & "Empleados as Recepcion on Compras.IDEmpleadoRec=Recepcion.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on Compras.IDAlmacen=Almacen.IDAlmacen Where Compras.IDCompra='" + IDCompra.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Compras")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Compras")

            txtIDCompra.Text = IDCompra.Text
            txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
            txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
            txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
            DtpFechaFact.Value = (Tabla.Rows(0).Item("FechaFactura"))
            DtpVencimiento.Value = (Tabla.Rows(0).Item("FechaVencimiento"))
            txtNoFact.Text = (Tabla.Rows(0).Item("NoFactura"))
            txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
            CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
            txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            txtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
            txtDescuento2.Text = CDbl(Tabla.Rows(0).Item("Descuento2")).ToString("C")
            txtItbis.Text = CDbl(Tabla.Rows(0).Item("ITBIS")).ToString("C")
            txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
            txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
            txtIDRecepcion.Text = (Tabla.Rows(0).Item("IDEmpleadoRec"))
            txtRecepcion.Text = (Tabla.Rows(0).Item("NombreRecepcion"))
            DtpDiaRecibido.Value = (Tabla.Rows(0).Item("DiaRecepcion"))
            txtNotaCompra.Text = (Tabla.Rows(0).Item("Nota"))
            RutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))
            txtBalanceSup.Text = CDbl((Tabla.Rows(0).Item("BceGeneral"))).ToString("C")
            txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

            If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
            Else
                txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
            End If

            If (Tabla.Rows(0).Item("PrecioDiferido")) = 0 Then
                chkpreciosdiferidos.Checked = False
            Else
                chkpreciosdiferidos.Checked = True
            End If

            If (Tabla.Rows(0).Item("CreditoPendiente")) = 0 Then
                chkcreditospendientes.Checked = False
            Else
                chkcreditospendientes.Checked = True
            End If

            If (Tabla.Rows(0).Item("ArticuloFuera")) = 0 Then
                chkArtfuerapedido.Checked = False
            Else
                chkArtfuerapedido.Checked = True
            End If

            If (Tabla.Rows(0).Item("NegociarFlete")) = 0 Then
                chkrenegociarflete.Checked = False
            Else
                chkrenegociarflete.Checked = True
            End If

            If (Tabla.Rows(0).Item("Averiados")) = 0 Then
                chkAveriados.Checked = False
            Else
                chkAveriados.Checked = True
            End If

            RefrescarTablaArticulos()
            DgvArticulos.ClearSelection()
           
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaArticulos()
        Try
            If txtIDCompra.Text = "" Then
            Else
                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDDetalleCompra,IDCompra,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,Cantidad,PrecioUnitario,Descuento,Descuento2,Itbis,Importe,IDAlmacen,CostoFinal FROM DetalleCompra Where IDCompra='" + txtIDCompra.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14), CDbl(LectorArticulos.GetValue(7)) * CDbl(LectorArticulos.GetValue(12)))
                End While

                LectorArticulos.Close()
                Con.Close()

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnSubirFactura_Click(sender As Object, e As EventArgs) Handles btnSubirFactura.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = RutaDocumento.Text

            If RutaDocumento.Text <> "" Then
                If System.IO.File.Exists(RutaDocumento.Text) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDocumento.Text, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If
        End If
    End Sub
End Class