Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_previsualizacion_facturas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_previsualizacion_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        ActualizarTodo()
        LlenarFormularios()
        VerificarIntegridad()
    End Sub

    Private Sub VerificarIntegridad()
        Dim Importes As Double = 0
        For Each row As DataGridViewRow In dgvArticulosFactura.Rows
            Importes = Importes + CDbl(row.Cells(11).Value)
        Next

        If Importes <> CDbl(txtNeto.Text) Then
            MessageBox.Show("Se han detectado diferencias en la integridad referencial del artículo y la factura seleccionada." & vbNewLine & vbNewLine & "Este error se produce ya que la transferencia de la información a incluído un registro no exacto dada la antiguedad y la plataforma anterior del sistema." & vbNewLine & vbNewLine & "Este formulario va a cerrarse.", "Error de integridad", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            'Me.Close()
        End If
    End Sub
    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub
    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGeneral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtCreditoDisponible.Clear()
        txtIDFactura.Clear()
        txtSecondID.Clear()
        txtHoraFactura.Clear()
        txtFechaFactura.Clear()
        txtTipoComprobante.Clear()
        txtNCF.Clear()
        txtNIF.Clear()
        txtVendedor.Clear()
        txtCobrador.Clear()
        txtAlmacen.Clear()
        txtVehiculo.Clear()
        txtChofer.Clear()
        txtBalance.Clear()
        txtCargos.Clear()
        txtDiasVencidos.Clear()
        txtStatus.Clear()
        txtInicial.Clear()
        txtTotalPagar.Clear()
        txtCantidadPagos.Clear()
        txtMontoPagos.Clear()
        txtAdicional.Clear()
        txtFechaAdicional.Clear()
        txtObservacion.Clear()
        chkFichaDatos.Checked = False
        chkHabilitarNota.Checked = False
        txtCondicionContado.Clear()
        txtFechaVencimiento.Clear()
        txtSubTotal.Clear()
        TxtDescuentoSuma.Clear()
        txtITBIS.Clear()
        txtFlete.Clear()
        txtNeto.Clear()
    End Sub

    Private Sub ActualizarTodo()
        ColumnasDgvArticulos()
        ColumnasDgvPagares()
    End Sub

    Private Sub LlenarFormularios()
        Dim IDFactura As New Label
        IDFactura.Text = frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos")

        Try
            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDCliente,Clientes.Nombre as NombreCliente,IDCondicion,FacturaDatos.IDAlmacen,Almacen,FacturaDatos.IDComprobanteFiscal,TipoComprobante,NCF,NIF,IDChofer,Chofer.Nombre as NombreChofer,FacturaDatos.IDVehiculo,DatoVehiculo,IDVendedor,Vendedor.Nombre as NombreVendedor,IDUsuario,Usuario.Nombre as NombreUsuario,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,FacturaDatos.Balance,Cargos,HabilitarFicha,DiasVencidos,FacturaDatos.Status,Observacion,Cierre,FacturaDatos.Nulo,Clientes.IDCalificacion,Calificacion,Identificacion,Clientes.TelefonoPersonal,Clientes.IDEmpleado,Cobrador.Nombre as NombreCobrador,LimiteCredito,BalanceGeneral from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN Libregco.Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuario on FacturaDatos.IDUsuario=Usuario.IDEmpleado INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado Where IDFacturaDatos='" + IDFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")

            GbxUserInfo.Text = "User Info-> " & (Tabla.Rows(0).Item("NombreUsuario")) & " [" & (Tabla.Rows(0).Item("IDUsuario")) & "]"
            txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
            txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            txtCreditoDisponible.Text = (CDbl(Tabla.Rows(0).Item("LimiteCredito")) - CDbl(Tabla.Rows(0).Item("BalanceGeneral"))).ToString("C")
            txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
            txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            txtFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha"))
            txtHoraFactura.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            txtTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
            txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
            txtNIF.Text = (Tabla.Rows(0).Item("NIF"))
            txtVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
            txtCobrador.Text = (Tabla.Rows(0).Item("NombreCobrador"))
            txtAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
            txtVehiculo.Text = (Tabla.Rows(0).Item("DatoVehiculo"))
            txtChofer.Text = (Tabla.Rows(0).Item("NombreChofer"))
            txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            txtCargos.Text = CDbl(Tabla.Rows(0).Item("Cargos")).ToString("C")
            txtDiasVencidos.Text = (Tabla.Rows(0).Item("Diasvencidos"))
            txtStatus.Text = (Tabla.Rows(0).Item("Status"))
            txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
            txtInicial.Text = CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C")
            txtTotalPagar.Text = CDbl(Tabla.Rows(0).Item("NetoFactura")).ToString("C")
            txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
            txtMontoPagos.Text = CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")
            txtAdicional.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")
            txtFechaAdicional.Text = (Tabla.Rows(0).Item("FechaAdicional"))
            txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            txtFechaVencimiento.Text = (Tabla.Rows(0).Item("FechaVencimiento"))
            txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
            txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            TxtDescuentoSuma.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
            txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
            txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")

            FillChkBox()
            UltimoPago()

            RefrescarTablaConsulta()
            RefrescarTablaPagares()

            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Sub RefrescarTablaConsulta()
        Try

            dgvArticulosFactura.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDFactArt,IDFactura,IDPrecio,IDMedida,Cantidad,Medida,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,PrecioUnitario,Descuento,Itbis,Importe from facturaarticulos WHERE IDFactura='" + txtIDFactura.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11))
            End While

            LectorArticulos.Close()
            Con.Close()
            PropiedadesDgvArticulos()
            dgvArticulosFactura.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ColumnasDgvArticulos()
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
            .Columns.Add("PrecioUnitario", "Precio Unitario")   '8
            .Columns.Add("Descuento", "Descuento")  '9
            .Columns.Add("Itbis", "Itbis")  '10
            .Columns.Add("Importe", "Importe")      '11
            PropiedadesDgvArticulos()
        End With

    End Sub

    Private Sub ColumnasDgvPagares()
        DgvPagares.Columns.Clear()
        With DgvPagares
            .Columns.Add("IDPagare", "IDPagare") '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("NoPagare", "No.") '2
            .Columns.Add("Cantidad", "Cant.") '3
            .Columns.Add("FechaVencimiento", "Vencimiento") '4
            .Columns.Add("Concepto", "Concepto") '5
            .Columns.Add("Monto", "Monto") '6
            .Columns.Add("Balance", "Balance") '7
            PropiedadesDgvPagares()
        End With
    End Sub

    Private Sub PropiedadesDgvPagares()
        Dim Condicion As String = False
        With DgvPagares
            .Columns("IDPagare").Visible = Condicion
            .Columns("IDFactura").Visible = Condicion
            .Columns("FechaVencimiento").Width = 100
            .Columns("NoPagare").Width = 70
            .Columns("Cantidad").Visible = Condicion
            .Columns("Concepto").Width = 380
            .Columns("Monto").Width = 140
            .Columns("Monto").DefaultCellStyle.Format = ("C")
            .Columns("Balance").DefaultCellStyle.Format = ("C")
            .Columns("Balance").Visible = Condicion
        End With
    End Sub

    Sub PropiedadesDgvArticulos()
        Dim Condicion As String = False
        With dgvArticulosFactura
            .Columns("IDArtFac").Visible = Condicion
            .Columns("IDFactura").Visible = Condicion
            .Columns("IDMedida").Visible = Condicion
            .Columns("IDPrecios").Visible = Condicion
            .Columns("Medida").Width = 80
            .Columns("Cantidad").HeaderText = "Cant."
            .Columns("Cantidad").Width = 50
            .Columns("IDArticulo").Width = 68
            .Columns("IDArticulo").HeaderText = "Código"
            .Columns("Descripcion").Width = 290
            .Columns("Descripcion").HeaderText = "Descripción"
            .Columns("PrecioUnitario").DefaultCellStyle.Format = ("C")
            .Columns("PrecioUnitario").HeaderText = "Precio"
            .Columns("PrecioUnitario").Width = 110
            .Columns("Descuento").DefaultCellStyle.Format = ("C")
            .Columns("Descuento").Width = 110
            .Columns("Itbis").DefaultCellStyle.Format = ("C")
            .Columns("Itbis").Width = 110
            .Columns("Importe").DefaultCellStyle.Format = ("C")
            .Columns("Importe").Width = 110
        End With
    End Sub

    Sub RefrescarTablaPagares()
        Try
            DgvPagares.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,Concepto,Monto,Balance from Pagares where IDFactura='" + txtIDFactura.Text + "'", Con)
            Dim LectorPagares As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagares.Read
                DgvPagares.Rows.Add(LectorPagares.GetValue(0), LectorPagares.GetValue(1), LectorPagares.GetValue(2), LectorPagares.GetValue(3), LectorPagares.GetValue(4), LectorPagares.GetValue(5), LectorPagares.GetValue(6), LectorPagares.GetValue(7))
            End While
            LectorPagares.Close()
            Con.Close()
            PropiedadesDgvPagares()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub UltimoPago()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select IDAbono,Fecha from Abonos where IDCliente='" + txtIDCliente.Text + "' and Nulo=0 ORDER BY IDAbono DESC LIMIT 1", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Abonos")
            Con.Close()

            Dim Tabla1 As DataTable = Ds1.Tables("Abonos")

            If Tabla1.Rows.Count = CInt(0) Then
                txtUltimoPago.Text = "NINGUNO"
            Else
                txtUltimoPago.Text = (Tabla1.Rows(0).Item("Fecha"))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltimoPago")
        End Try

    End Sub


    Private Sub FillChkBox()
        Dim Nota, Ficha, Desactivar As New Label

        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select HabilitarFicha,NotaContado from FacturaDatos Where IDFacturaDatos='" + txtIDFactura.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "FacturaDatos")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("FacturaDatos")
            Ficha.Text = (Tabla.Rows(0).Item("HabilitarFicha"))
            Nota.Text = (Tabla.Rows(0).Item("NotaContado"))

            If Ficha.Text = 0 Then
                chkFichaDatos.Checked = False
            Else
                chkFichaDatos.Checked = True
            End If
            If Nota.Text = 0 Then
                chkHabilitarNota.Checked = False
            Else
                chkHabilitarNota.Checked = True
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

 
End Class