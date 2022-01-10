Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_factura_sd

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_factura_sd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,Nombre,Balance FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where FacturaDatos.SecondID like '%" + txtBuscar.Text + "%' and FacturaDatos.IDTipoDocumento=12 or FacturaDatos.IDTipoDocumento=54 and FacturaDatos.Nulo=0", ConMixta)
            ElseIf rdbNombre.CheckAlign = True Then
                cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,Nombre,Balance FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Nombre like '%" + txtBuscar.Text + "%' and FacturaDatos.IDTipoDocumento=12 or FacturaDatos.IDTipoDocumento=54 and FacturaDatos.Nulo=0", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "facturadatos")

            Bs.DataMember = "facturadatos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvFacturas.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvFacturas
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 280
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(4).Width = 150
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvFacturas.Focus()
    End Sub

    Private Sub DgvFacturas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvFacturas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvFacturas.Focus()
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

    Private Sub DgvFacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDFactura, Nulo As New Label
        IDFactura.Text = DgvFacturas.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.DiasCondicion,FacturaDatos.IDCliente,FacturaDatos.NombreFactura,FacturaDatos.IdentificacionFactura,FacturaDatos.DireccionFactura,FacturaDatos.TelefonosFactura,IDFacturaDatos,Clientes.BalanceGeneral,FacturaDatos.SecondID,IDTipoDocumento,IDTransaccion,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,FacturaDatos.EntregarPorConduce,FacturaDatos.Nulo from FacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos='" + IDFactura.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "FacturaDatos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")

        If Me.Owner.Name = frm_registro_factura_sd.Name Then
            frm_registro_factura_sd.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
            frm_registro_factura_sd.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_registro_factura_sd.txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
            frm_registro_factura_sd.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
            frm_registro_factura_sd.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonosFactura"))
            frm_registro_factura_sd.txtRNC.Text = (Tabla.Rows(0).Item("IdentificacionFactura"))
            frm_registro_factura_sd.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_registro_factura_sd.txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
            frm_registro_factura_sd.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_registro_factura_sd.txtFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_registro_factura_sd.txtHoraFactura.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_registro_factura_sd.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
            frm_registro_factura_sd.txtDiasCondicion.Text = (Tabla.Rows(0).Item("DiasCondicion"))
            frm_registro_factura_sd.txtInicial.Text = CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C")
            frm_registro_factura_sd.txtBalance.Text = CDbl(Tabla.Rows(0).Item("NetoFactura")).ToString("C")
            frm_registro_factura_sd.txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
            frm_registro_factura_sd.txtAdicional.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")
            frm_registro_factura_sd.txtFechaAdicional.Text = (Tabla.Rows(0).Item("FechaAdicional"))
            frm_registro_factura_sd.txtMontoPagos.Text = CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")
            frm_registro_factura_sd.txtFechaVencimiento.Text = CDate(Tabla.Rows(0).Item("FechaVencimiento")).ToString("yyyy-MM-dd")
            frm_registro_factura_sd.txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
            frm_registro_factura_sd.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            frm_registro_factura_sd.TxtDescuentoSuma.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
            frm_registro_factura_sd.txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            frm_registro_factura_sd.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
            frm_registro_factura_sd.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
            frm_registro_factura_sd.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
            frm_registro_factura_sd.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_registro_factura_sd.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            frm_registro_factura_sd.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_registro_factura_sd.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            frm_registro_factura_sd.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
            frm_registro_factura_sd.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
            frm_registro_factura_sd.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
            frm_registro_factura_sd.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_registro_factura_sd.ChkNulo.Checked = False
            Else
                frm_registro_factura_sd.ChkNulo.Checked = True
            End If

            If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                frm_registro_factura_sd.chkEntregarporConduce.Checked = True
            Else
                frm_registro_factura_sd.chkEntregarporConduce.Checked = False
            End If

            frm_registro_factura_sd.RefrescarTablaPagares()
            frm_registro_factura_sd.ConvertCurrent()
            frm_registro_factura_sd.HabilitarControles()
        End If

        Close()
        Exit Sub
    End Sub

    
End Class