Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_historial_recibos_cliente

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblIDFactura As New Label
    Dim ChkRevisado As New DataGridViewCheckBoxColumn
    Dim Permisos As New ArrayList

    Private Sub frm_historial_recibos_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        ColumnasHistorial()
        LimpiarTodo()
        ActualizarTodo()
        CheckForms()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CheckForms()
        Try
            If Me.Owner.Name = frm_registro_recibos_cobro.Name Then
                txtIDCliente.Text = frm_registro_recibos_cobro.txtIDCliente.Text
                txtNombre.Text = frm_registro_recibos_cobro.txtNombre.Text
                txtCalificacion.Text = frm_registro_recibos_cobro.txtCalificacion.Text
                txtUltimoPago.Text = frm_registro_recibos_cobro.txtUltimoPago.Text
                txtBalanceGral.Text = frm_registro_recibos_cobro.txtBalanceGral.Text
                FillCbxFacturas()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarListBox()
        Try
            With LtboxDetalle
                .Items.Clear()
                .Items.Add("Código : ")
                .Items.Add("Tipo de Documento: ")
                .Items.Add("Condición: ")
                .Items.Add("Código de Transacción: ")
                .Items.Add("Fecha: ")
                .Items.Add("Fecha Vencimiento: ")
                .Items.Add("Almacén: ")
                .Items.Add("Tipo de Comprobante: ")
                .Items.Add("Vendedor: ")
                .Items.Add("Total Neto: ")
                .Items.Add("Inicial: ")
                .Items.Add("A Pagar: ")
                .Items.Add("Cantidad de Pagos: ")
                .Items.Add("Pago Adicional: ")
                .Items.Add("Nota de Contado: ")
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
   PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasHistorial()
        DgvHistorial.Columns.Clear()
        With DgvHistorial
            .Columns.Add("NoEntrega", "No. Entrega") '0
            .Columns.Add("NoRecibo", "No. Recibo") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("Debito", "Débito") '3
            .Columns.Add("Descuento", "Descuento") '4
            .Columns.Add("Aplicado", "Aplicado") '5
            .Columns.Add("Descripcion", "Tipo Recibo") '6
            .Columns.Add(ChkRevisado) '7
        End With
        PropiedadDgvHistorial()
    End Sub

    Private Sub PropiedadDgvHistorial()
        With DgvHistorial
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 95
            .Columns(3).Width = 130
            .Columns(3).DefaultCellStyle.Format = ("C")
            .Columns(4).Width = 130
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 130
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 142
        End With

        With ChkRevisado
            .HeaderText = "Revisado"
            .Name = "ChkRevisado"
            .Width = 85
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .FlatStyle = FlatStyle.Standard
        End With

        For Each Column As DataGridViewColumn In DgvHistorial.Columns
            Column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub LimpiarTodo()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtCobrador.Clear()
        txtLimiteCredito.Clear()
        cbxFactura.Items.Clear()
        DgvHistorial.Rows.Clear()
        DgvArticulos.Rows.Clear()
    End Sub

    Private Sub ActualizarTodo()
        CargarListBox()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub BuscarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarClienteToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub RefrescarTabla()
        Try
            DgvHistorial.Rows.Clear()

            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,Pagares.IDPagare,Pagares.NoPagare,Pagares.Cantidad,EntregaCobro.IDEntregaCobro,NoEntrega,GrupoRecibos.IDNaturaleza,NaturalezaRecibo.Descripcion as Naturaleza,naturalezarecibo.Abreviacion,NoRecibo,RecibosCobro.Fecha,RecibosDetalle.Debito,RecibosDetalle.Descuento,RecibosDetalle.Debito+RecibosDetalle.Descuento AS Total,RecibosCobro.IDTipoRecibo,TipoRecibos.Descripcion as TipoRecibo,reciboscobro.Cierre FROM recibosdetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro INNER JOIN EntregaCobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo INNER JOIN GrupoRecibos on RecibosCobro.IDGrupoRecibo=gruporecibos.IDGrupoRecibos INNER JOIN NaturalezaRecibo on GrupoRecibos.IDNaturaleza=NaturalezaRecibo.IDNaturaleza INNER JOIN Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos Where Pagares.IDFactura='" + lblIDFactura.Text + "' AND RecibosCobro.Nulo=0 AND RecibosCobro.IDTipoRecibo<>3", Con)
            Dim LectorPagos As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagos.Read
                DgvHistorial.Rows.Add(LectorPagos.GetValue(6), LectorPagos.GetValue(9) & " " & LectorPagos.GetValue(10), CDate(LectorPagos.GetValue(11)).ToString("dd/MM/yyyy"), CDbl(LectorPagos.GetValue(12)).ToString("C"), CDbl(LectorPagos.GetValue(13)).ToString("C"), (CDbl(LectorPagos.GetValue(12)) + CDbl(LectorPagos.GetValue(13))).ToString("C"), "[" & LectorPagos.GetValue(15) & "] " & LectorPagos.GetValue(16), CBool(LectorPagos.GetValue(17)))
            End While

            LectorPagos.Close()
            Con.Close()
            DgvHistorial.ClearSelection()

            Dim AplicadoTotal As Double = 0
            For Each row As DataGridViewRow In DgvHistorial.Rows
                AplicadoTotal = AplicadoTotal + CDbl(row.Cells(5).Value)
            Next
            DgvHistorial.Rows.Add("", "", "", "", "Total aplicado:", AplicadoTotal.ToString("C"))
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FillCbxFacturas()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM FacturaDatos INNER JOIN Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias>0 and FacturaDatos.Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "FacturaDatos")
        CbxFactura.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("FacturaDatos")
        For Each Fila As DataRow In Tabla.Rows
            cbxFactura.Items.Add(Fila.Item("SecondID"))
        Next

        If Tabla.Rows.Count = 1 Then
            cbxFactura.SelectedIndex = 0
        End If
    End Sub

    Private Sub SetIDFactura()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDFacturaDatos FROM FacturaDatos WHERE SecondID='" + cbxFactura.Text + "'", Con)
        lblIDFactura.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub cbxFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFactura.SelectedIndexChanged
        SetIDFactura()
        RefrescarTabla()
        RefrescarDetalles()
        RefrescarArticulos()
    End Sub

    Private Sub RefrescarArticulos()
        Try
            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT Cantidad,Medida,Descripcion FROM facturaarticulos Where IDFactura='" + lblIDFactura.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2))
            End While

            LectorArticulos.Close()
            Con.Close()
            DgvArticulos.ClearSelection()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub RefrescarDetalles()
        Try
            LtboxDetalle.Items.Clear()
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDFacturaDatos,Documento,IDTransaccion,Fecha,Hora,Condicion,FacturaDatos.IDAlmacen,Almacen,TipoComprobante,NCF,FacturaDatos.IDVendedor,Empleados.Nombre as Vendedor,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,FacturaDatos.Balance FROM facturadatos INNER JOIN TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado Where IDFacturaDatos='" + lblIDFactura.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")
            With LtboxDetalle
                .Items.Add("Código : " & Tabla.Rows(0).Item("IDFacturaDatos"))
                .Items.Add("Tipo de Documento: " & Tabla.Rows(0).Item("Documento"))
                .Items.Add("Condición: " & Tabla.Rows(0).Item("Condicion"))
                .Items.Add("Código de Transacción: " & Tabla.Rows(0).Item("IDTransaccion"))
                .Items.Add("Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & " " & CDate(Convert.ToString(Tabla.Rows(0).Item("Hora"))).ToString("hh:mm:ss"))
                .Items.Add("Fecha Vencimiento: " & Tabla.Rows(0).Item("FechaVencimiento"))
                .Items.Add("Almacén: [" & Tabla.Rows(0).Item("IDAlmacen") & "] " & Tabla.Rows(0).Item("Almacen"))
                .Items.Add("Tipo de Comprobante: " & Tabla.Rows(0).Item("TipoComprobante") & " " & Tabla.Rows(0).Item("NCF"))
                .Items.Add("Vendedor: [" & Tabla.Rows(0).Item("IDVendedor") & "] " & Tabla.Rows(0).Item("Vendedor"))
                .Items.Add("Total Neto: " & CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C"))
                .Items.Add("Inicial: " & CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C"))
                .Items.Add("A Pagar: " & CDbl(Tabla.Rows(0).Item("NetoFactura")).ToString("C"))
                .Items.Add("Cantidad de Pagos: " & Tabla.Rows(0).Item("CantidadPagos") & " | " & CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C"))
                .Items.Add("Pago Adicional: " & CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C") & " | " & "Fecha de Adicional: " & Tabla.Rows(0).Item("FechaAdicional"))
                .Items.Add("Nota de Contado: " & Tabla.Rows(0).Item("CondicionContado"))
            End With

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub DgvHistorial_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvHistorial.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvHistorial.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvHistorial.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvHistorial.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
       
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

            If DgvHistorial.Rows.Count = 1 Then
                MessageBox.Show("No se han encontrado detalle de pagos en la factura " & cbxFactura.Text & ".", "No hay recibos de cobro en la factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf txtIDCliente.Text = "" Then
                MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        frm_impresiones_directas.ShowDialog(Me)

    End Sub
End Class