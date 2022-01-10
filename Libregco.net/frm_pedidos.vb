Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_pedidos

    Dim sqlQ, DefaultCondicion As String
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblIDUsuario, lblIDPrecio, lblIDAlmacen, lblDiasCondicion, lblIDMedida, lblItbisArticulo, lblNulo, lblIDCondicion, PrecioLista, lblCheckDuplicates, FactDebajoCosto, FacturarSinExist, DefaultCurrency As New Label
    Friend ChangedCodeEmployee As Boolean
    Dim Permisos As New ArrayList
    Dim Precios As New ArrayList

    Private Sub frm_pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SetConfiguracion()
        ColumnasDgvArticulos()
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetConfiguracion()
        Try
            Con.Open()
            ConMixta.Open()

            'Permitir facturar debajo del costo
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=16", Con)
            FactDebajoCosto.Text = Convert.ToString(cmd.ExecuteScalar())

            'Facturar sin Existencia
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=21", Con)
            FacturarSinExist.Text = Convert.ToString(cmd.ExecuteScalar())

            'Condicion Predeterminada
            cmd = New MySqlCommand("Select Condicion from" & SysName.Text & "Configuracion INNER JOIN Libregco.Condicion on Configuracion.Value2Int=Condicion.IDCondicion Where IDConfiguracion=59", ConMixta)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            Ds.Clear()
            cbxMoneda.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipomoneda")
            Dim Tabla As DataTable = Ds.Tables("tipomoneda")

            For Each Fila As DataRow In Tabla.Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                nvmoneda.Description = Fila.Item("Texto")
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                cbxMoneda.Properties.Items.Add(nvmoneda)
            Next
            Tabla.Dispose()

            'Moneda predeterminada
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
            DefaultCurrency.Text = CInt(Convert.ToString(cmd.ExecuteScalar()))

            Con.Close()
            ConMixta.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDPedidoDetalle", "IDPedidoDetalle")  '0
            .Columns.Add("IDPedido", "IDPedido")    '1
            .Columns.Add("IDPrecio", "IDPrecio")    '2
            .Columns.Add("IDMedida", "IDMedida")    '3
            .Columns.Add("Cantidad", "Cant.")   '4
            .Columns.Add("Medida", "Medida")        '5
            .Columns.Add("IDArticulo", "Código")    '6
            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("Precio", "Precio") '8
            .Columns.Add("Descuento", "Descuento")  '9
            .Columns.Add("Itbis", "Itbis")  '10
            .Columns.Add("Importe", "Importe")  '11
            PropiedadesDgvArticulos()
        End With
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim Condicion As String = False
            Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100
            With DgvArticulos
                .Columns("IDPedidoDetalle").Visible = Condicion
                .Columns("IDPedido").Visible = Condicion
                .Columns("IDPrecio").Visible = Condicion
                .Columns("IDArticulo").Width = DatagridWith * 10
                .Columns("Descripcion").Width = DatagridWith * 30
                .Columns("IDMedida").Visible = Condicion
                .Columns("Medida").Width = DatagridWith * 8
                .Columns("Cantidad").Width = DatagridWith * 8
                .Columns("Precio").Width = DatagridWith * 10
                .Columns("Precio").DefaultCellStyle.Format = ("C")
                .Columns("Descuento").Width = DatagridWith * 10
                .Columns("Descuento").DefaultCellStyle.Format = ("C")
                .Columns("Itbis").Width = DatagridWith * 10
                .Columns("Itbis").DefaultCellStyle.Format = ("C")
                .Columns("Importe").Width = DatagridWith * 14
                .Columns("Importe").DefaultCellStyle.Format = ("C")
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub txtIDArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDArticulo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        If txtIDArticulo.Text = "" Then
            LimpiarDatosArticulos()
        Else
            SetInformacionArticulo()
        End If
    End Sub

    Sub SetInformacionArticulo()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "' or Articulos.Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Articulos")

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
        Else
            IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
            txtCantidadArticulo.Text = 1
            txtDescuento.Text = 0
            FillMedida()


        End If

    End Sub

    Private Sub FillMedida()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
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

    Sub LimpiarDatosArticulos()
        IDArticulo.Text = ""
        txtIDArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtCantidadArticulo.Clear()
        txtPrecio.Clear()
        txtCantidadArticulo.Clear()
        CbxMedida.Items.Clear()
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())


        cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtIDArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")

    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DesHabilitarControles()
            lblNulo.Text = 1
        Else
            HabilitarControles()
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub DesHabilitarControles()
        GbClientes.Enabled = False
        GbArticulos.Enabled = False
        txtReferencia.Enabled = False
        txtIDVendedor.Enabled = False
        cbxAlmacen.Enabled = False
        cbxCondicion.Enabled = False
        txtComentario.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbClientes.Enabled = True
        GbArticulos.Enabled = True
        txtReferencia.Enabled = True
        txtComentario.Enabled = True
        txtIDVendedor.Enabled = True
        btnModificar.Enabled = True
        cbxAlmacen.Enabled = True
        cbxCondicion.Enabled = True
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If DgvArticulos.Rows.Count = 0 Or x = DgvArticulos.Rows.Count Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(DgvArticulos.Rows(x).Cells(2).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra introducido en la orden de compras." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub BuscarItebis()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDArticulo,Articulos.IDItbis,TipoItbis.Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Articulos")

        lblItbisArticulo.Text = CDbl(Tabla.Rows(0).Item("Itbis"))
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try

            If txtIDArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtIDArticulo.Focus()

            Else

                If cbxPrecio.Text = "" Then
                    MessageBox.Show("Seleccione un nivel de precio del producto para insertar a la cotización.", "Seleccione un nivel de precio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    cbxPrecio.Focus()
                    cbxPrecio.DroppedDown = True
                    Exit Sub
                End If
                If CbxMedida.Items.Count = 0 Then
                    MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    CbxMedida.Focus()
                    Exit Sub
                End If

                VerificarDuplicados()
                If lblCheckDuplicates.Text = 1 Then
                    Exit Sub
                End If

                BuscarItebis()

                With DgvArticulos
                    .Rows.Add("", "", lblIDPrecio.Text, lblIDMedida.Text, txtCantidadArticulo.Text, CbxMedida.Text, IDArticulo.Text, txtDescripcionArticulo.Text, (CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))).ToString("C"), (((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))) * (CDbl(Replace(txtDescuento.Text, "%", "") / 100))) * CDbl(txtCantidadArticulo.Text)).ToString("C"), ((((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))) - ((CDbl(txtPrecio.Text) / (CDbl(1) + CDbl(lblItbisArticulo.Text))) * (CDbl(Replace(txtDescuento.Text, "%", "") / 100)))) * CDbl(lblItbisArticulo.Text)) * CDbl(txtCantidadArticulo.Text)).ToString("C"), ((CDbl(txtPrecio.Text) - (CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuento.Text, "%", "") / 100))) * CDbl(txtCantidadArticulo.Text)).ToString("C"))
                End With

                SumTotales()
                btnModificar.Enabled = True
                LimpiarTextInsert()
                txtIDArticulo.Focus()

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarTextInsert()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtPrecio.Clear()
        txtDescuentoAplicado.Clear()
        txtIDArticulo.Clear()
        lblIDMedida.Text =
        lblIDPrecio.Text = ""
        IDArticulo.Text = ""
        txtIDArticulo.Focus()
    End Sub

    Private Sub DgvArticulos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvArticulos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvArticulos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvArticulos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvArticulos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
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
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub EliminarArticulo()
        Dim IDPedidoDetalle As New Label
        IDPedidoDetalle.Text = DgvArticulos.CurrentRow.Cells(0).Value

        If IDPedidoDetalle.Text = "" Or txtIDPedido.Text = "" Then
            Exit Sub
        Else
            sqlQ = "Delete from PedidoDetalle Where IDPedidoDetalle = (" + IDPedidoDetalle.Text + ")"
            GuardarDatos()

            MessageBox.Show("Artículo eliminado satisfactoriamente de la nota de pedido.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtSubTotal.Text = CDbl(0.0).ToString("C")
        txtNeto.Text = CDbl(0.0).ToString("C")
        txtDescuento.Text = CDbl(0.0).ToString("C")
        txtItbis.Text = CDbl(0.0).ToString("C")
        lblNulo.Text = 0
        PrecioLista.Text = ""
        ChkNulo.Checked = False
        ChangedCodeEmployee = False
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        ControlSuperClave = 1
        lblCheckDuplicates.Text = 1
        FillAlmacen()
        FillCondicion()
        cbxMoneda.EditValue = CInt(DefaultCurrency.Text)
        Precios = GetRangePrices()

        For Each item As String In Precios
            cbxPrecio.Items.Add(item)
        Next

        If cbxPrecio.Items.Count > 0 Then
            cbxPrecio.SelectedIndex = 0
        End If


        btnBuscarCliente.Focus()
    End Sub


    Private Sub FillAlmacen()

        Ds.clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
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
    End Sub

    Private Sub FillCondicion()
        Try
            Ds.Clear()
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

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LiberarDgvArticulos()
        Try

            If DgvArticulos.Columns.Count = 0 Then
                DgvArticulos.DataSource = Nothing
                DgvArticulos.Rows.Clear()
                ColumnasDgvArticulos()
                PropiedadesDgvArticulos()
            Else
                DgvArticulos.DataSource = Nothing
                DgvArticulos.Rows.Clear()
                DgvArticulos.Columns.Clear()
                ColumnasDgvArticulos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "Desde LiberarDgvArticulos")
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtSecondID.Clear()
        txtIDVendedor.Clear()
        txtVendedor.Clear()
        txtIDPedido.Clear()
        CbxMedida.Items.Clear()
        txtReferencia.Clear()
        txtComentario.Clear()
        LimpiarTextInsert()
    End Sub

    Private Sub ConvertDouble()
        txtSubTotal.Text = CDbl(txtSubTotal.Text)
        txtItbis.Text = CDbl(txtItbis.Text)
        txtDescuento.Text = CDbl(txtDescuento.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub


    Private Sub ConvertCurrent()
        txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
        txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
        txtDescuento.Text = CDbl(txtDescuento.Text).ToString("C")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
    End Sub

    Private Sub UltPedido()
        Try
            If txtIDPedido.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDPedido from Pedidos where IDPedido= (Select Max(IDPedido) from Pedidos)", Con)
                txtIDPedido.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDPedido.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la nota de pedido?", "Imprimir Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub InsertArticulos()
        Dim IDPedidoDetalle, IDPedido, IDArticulo, IDPrecio, IDMedida, Medida, Cantidad, Descripcion, Precio, Descuento, Itbis, Importe As New Label
        Dim x As Integer = 0

Inicio:
        If x = DgvArticulos.RowCount Then
            GoTo Fin
        End If
        IDPedidoDetalle.Text = DgvArticulos.Rows(x).Cells(0).Value
        IDPedido.Text = DgvArticulos.Rows(x).Cells(1).Value
        IDPrecio.Text = DgvArticulos.Rows(x).Cells(2).Value
        IDMedida.Text = DgvArticulos.Rows(x).Cells(3).Value
        Cantidad.Text = DgvArticulos.Rows(x).Cells(4).Value
        Medida.Text = DgvArticulos.Rows(x).Cells(5).Value
        IDArticulo.Text = DgvArticulos.Rows(x).Cells(6).Value
        Descripcion.Text = DgvArticulos.Rows(x).Cells(7).Value
        Precio.Text = CDbl(DgvArticulos.Rows(x).Cells(8).Value)
        Descuento.Text = CDbl(DgvArticulos.Rows(x).Cells(9).Value)
        Itbis.Text = CDbl(DgvArticulos.Rows(x).Cells(10).Value)
        Importe.Text = CDbl(DgvArticulos.Rows(x).Cells(11).Value)

        If IDPedidoDetalle.Text = "" Then
            sqlQ = "INSERT INTO PedidoDetalle (IDPedido,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,Cantidad,Precio,Descuento,Itbis,Importe) VALUES ('" + txtIDPedido.Text + "','" + IDPrecio.Text + "','" + IDArticulo.Text + "','" + Descripcion.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + Cantidad.Text + "','" + Precio.Text + "','" + Descuento.Text + "','" + Itbis.Text + "','" + Importe.Text + "')"
            GuardarDatos()
            x = x + 1
            GoTo Inicio
        Else
            x = x + 1
            GoTo Inicio
        End If

Fin:
        RefrescarTablaArticulos()
    End Sub

    Sub SumTotales()
        SumSubTotal()
        SumDescuentos()
        SumItbis()
        SumImporte()
    End Sub

    Private Sub SumImporte()
        Dim x As Integer = 0
        Dim Importe As Double = 0

Inicio:
        If x = DgvArticulos.Rows.Count Then
            GoTo Final
        Else
            Importe = (Importe + CDbl(DgvArticulos.Rows(x).Cells(11).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtNeto.Text = (Importe).ToString("C")

    End Sub

    Private Sub SumItbis()
        Dim x As Integer = 0
        Dim Itbis As Double = 0

Inicio:
        If x = DgvArticulos.Rows.Count Then
            GoTo Final
        Else
            Itbis = Itbis + (CDbl(DgvArticulos.Rows(x).Cells(10).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtItbis.Text = Itbis.ToString("C")


    End Sub

    Private Sub SumDescuentos()
        Dim x As Integer = 0
        Dim Descuentos As Double = 0

Inicio:
        If x = DgvArticulos.Rows.Count Then
            GoTo Final
        Else
            Descuentos = (Descuentos + CDbl(DgvArticulos.Rows(x).Cells(9).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtDescuento.Text = Descuentos.ToString("C")
    End Sub

    Private Sub SumSubTotal()
        Dim Counter = DgvArticulos.Rows.Count
        Dim x As Integer = 0
        Dim Precios As Double = 0

Inicio:
        If x = Counter Then
            GoTo Final
        Else
            Precios = (Precios + (CDbl(DgvArticulos.Rows(x).Cells(8).Value) * CDbl(DgvArticulos.Rows(x).Cells(4).Value)))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtSubTotal.Text = Precios.ToString("C")

    End Sub

    Sub RefrescarTablaArticulos()

        Try
            If txtIDPedido.Text = "" Then
            Else
                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDPedidoDetalle,IDPedido,IDPrecio,IDMedida,Cantidad,Medida,IDArticulo,Descripcion,Precio,Descuento,Itbis,Importe FROM PedidoDetalle Where IDPedido='" + txtIDPedido.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11))
                End While
                PropiedadesDgvArticulos()
                LectorArticulos.Close()
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        If txtPrecio.Text = "" Then
            txtPrecio.Text = CDbl(0).ToString("C")
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text)
        End If

    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        If txtPrecio.Text = "" Then
            txtPrecio.Text = CDbl(0).ToString("C")
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub CerrarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarPedidoToolStripMenuItem.Click
        Dim Cierre As New Label
        If txtIDPedido.Text = "" Then
            MessageBox.Show("No hay un registro de nota de pedido abierto para cerrar.", "Registro en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Con.Open()
            cmd = New MySqlCommand("SELECT Cierre FROM pedidos Where IDPedido='" + txtIDPedido.Text + "'", Con)
            Cierre.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If Cierre.Text = CInt(0) Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la nota de pedido No. " & txtIDPedido.Text & " está abierta en el sistema." & vbNewLine & "Está seguro que desea cerrarla?", "Cerrar Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    sqlQ = "UPDATE Pedidos SET Cierre=1 WHERE IDPedido= (" + txtIDPedido.Text + ")"
                    GuardarDatos()
                    MessageBox.Show("Nota de pedido cerrada satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la nota de pedido No. " & txtIDPedido.Text & " ya está cerrada en el sistema." & vbNewLine & "Está seguro que desea abrirla?", "Abrir Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    sqlQ = "UPDATE Pedidos SET Cierre=0 WHERE IDPedido= (" + txtIDPedido.Text + ")"
                    GuardarDatos()
                    MessageBox.Show("Nota de pedido abierta satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDPedido.Text = "" And DgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    DgvArticulos.Rows.Clear()
                    SumImporte()
                    Exit Sub
                End If
            End If

            If txtIDPedido.Text > 0 And DgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya insertados a través de esta función." & vbNewLine & "Para proceder a la eliminación de artículos utilice la función F2-Quitar Artículos.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If DgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & DgvArticulos.CurrentRow.Cells(3).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    EliminarArticulo()
                    DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                    SumImporte()
                End If
            Else
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim Counter As Integer = DgvArticulos.Rows.Count

            If Counter > 0 Then
                txtIDArticulo.Text = DgvArticulos.CurrentRow.Cells(6).Value
                IDArticulo.Text = DgvArticulos.CurrentRow.Cells(6).Value
                FillMedida()
                txtDescripcionArticulo.Text = DgvArticulos.CurrentRow.Cells(7).Value
                CbxMedida.Text = DgvArticulos.CurrentRow.Cells(5).Value
                lblIDMedida.Text = DgvArticulos.CurrentRow.Cells(3).Value
                txtCantidadArticulo.Text = DgvArticulos.CurrentRow.Cells(4).Value

                BuscarItebis()
                lblIDPrecio.Text = DgvArticulos.CurrentRow.Cells(2).Value
                txtPrecio.Text = (CDbl(DgvArticulos.CurrentRow.Cells(8).Value) * (CDbl(1) + CDbl(lblItbisArticulo.Text))).ToString("C")
                txtDescuento.Text = ((CDbl(DgvArticulos.CurrentRow.Cells(9).Value) / CDbl((DgvArticulos.CurrentRow.Cells(4).Value))) / CDbl(DgvArticulos.CurrentRow.Cells(8).Value)).ToString("P")
                txtPrecio.Focus()

                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                SumImporte()
                btnModificar.Enabled = False
            Else
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtDescuentoAplicado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoAplicado.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDescuentoAplicado_Leave(sender As Object, e As EventArgs) Handles txtDescuentoAplicado.Leave
        Try
            If txtDescuentoAplicado.Text = "" Then
                txtDescuentoAplicado.Text = CDbl(0.0).ToString("P")
            Else
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT VenderCosto FROM Articulos Where IDArticulo='" + txtIDArticulo.Text + "'", ConLibregco)
                Dim VenderCosto As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If VenderCosto = 1 Then
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT Costo FROM PrecioArticulo Where IDPrecios='" + lblIDPrecio.Text + "'", ConLibregco)
                    Dim Costo As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    If CDbl(txtPrecio.Text) = Costo Then
                        txtDescuentoAplicado.Text = CDbl(0).ToString("P")
                        Exit Sub
                    End If
                End If

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT DescuentoMaximo FROM PrecioArticulo Where IDPrecios='" + lblIDPrecio.Text + "'", ConLibregco)
                Dim DescMax As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                Dim ValueDesglozado As Double = CDbl((txtDescuentoAplicado.Text) / 100)

                If ValueDesglozado > DescMax Then
                    MessageBox.Show("El descuento aplicado es mayor al permitido.", "Descuento muy alto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    txtDescuentoAplicado.Text = DescMax.ToString("P")
                    txtDescuentoAplicado.Focus()
                Else
                    txtDescuentoAplicado.Text = CDbl((txtDescuentoAplicado.Text) / 100).ToString("P")
                End If

                If FactDebajoCosto.Text = 0 Then
                    Dim DescMaxAutorizado, PrecioMinimo As Double
                    DescMaxAutorizado = CDbl(PrecioLista.Text) * CDbl(DescMax)
                    PrecioMinimo = CDbl(PrecioLista.Text) - DescMaxAutorizado

                    If (CDbl(txtPrecio.Text) - (CDbl(txtPrecio.Text) * ((CDbl(Replace(txtDescuentoAplicado.Text, "%", ""))) / 100))) < PrecioMinimo Then
                        MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido." & vbNewLine & vbNewLine & "Precio de Lista: " & CDbl(PrecioLista.Text).ToString("C") & vbNewLine & "Precio a Insertar: " & CDbl(txtPrecio.Text).ToString("C") & " (Rebaja sobre el precio: " & ((CDbl(PrecioLista.Text) - CDbl(txtPrecio.Text))).ToString("C") & ") " & vbNewLine & "Descuento Aplicado: " & (txtDescuentoAplicado.Text) & " (" & (CDbl(CDbl(txtPrecio.Text) * CDbl(Replace(txtDescuentoAplicado.Text, "%", ""))) / 100).ToString("C") & ")" & vbNewLine & "Descuento Máximo: " & DescMaxAutorizado.ToString("C"), "El precio ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtPrecio.Text = PrecioLista.Text
                        txtPrecio.Focus()
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescuentoAplicado_Enter(sender As Object, e As EventArgs) Handles txtDescuentoAplicado.Enter
        Try
            If txtDescuentoAplicado.Text = "" Then
            Else
                txtDescuentoAplicado.Text = CDbl(Replace(txtDescuentoAplicado.Text, "%", ""))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
        LiberarDgvArticulos()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=9", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Pedidos SET SecondID='" + lblSecondID.Text + "' WHERE IDPedido='" + txtIDPedido.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=9"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el pedido.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtReferencia.Text = "" Then
            MessageBox.Show("Escriba una breve referencia sobre la nota de pedido a procesar.", "Referencia de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf txtIDVendedor.Text = "" Then
            MessageBox.Show("Seleccione el vendedor correspondiente a la nota de pedido.", "Seleccionar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar la nota de pedido.", "Insertar artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDPedido.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar la guardar la nueva nota de pedidos en la base de datos?", "Guardar Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Pedidos (IDTipoDocumento,IDSucursal,IDAlmacen,IDCondicion,IDVendedor,Fecha,Hora,IDUsuario,IDCliente,NombrePedido,DireccionPedido,TelefonoPedido,Referencia,Comentario,SubTotal,Descuento,Itbis,Total,Nulo,Impreso,Cierre) VALUES (9,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDCondicion.Text + "','" + txtIDVendedor.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDUsuario.Text + "','" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtDireccion.Text + "','" + txtTelefonos.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + txtSubTotal.Text + "','" + txtDescuento.Text + "','" + txtItbis.Text + "','" + txtNeto.Text + "','" + lblNulo.Text + "',0,0)"
                GuardarDatos()
                ConvertCurrent()
                UltPedido()
                SetSecondID()
                InsertArticulos()
                DesHabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota de pedido?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Pedidos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',NombrePedido='" + txtNombre.Text + "',DireccionPedido='" + txtDireccion.Text + "',TelefonoPedido='" + txtTelefonos.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',Itbis='" + txtItbis.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPedido= (" + txtIDPedido.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el pedido.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtReferencia.Text = "" Then
            MessageBox.Show("Escriba una breve referencia sobre la nota de pedido a procesar.", "Referencia de Nota de Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf txtIDVendedor.Text = "" Then
            MessageBox.Show("Seleccione el vendedor correspondiente a la nota de pedido.", "Seleccionar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar la nota de pedido.", "Insertar artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDPedido.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar la guardar la nueva nota de pedidos en la base de datos?", "Guardar Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Pedidos (IDTipoDocumento,IDSucursal,IDAlmacen,IDCondicion,IDVendedor,Fecha,Hora,IDUsuario,IDCliente,NombrePedido,DireccionPedido,TelefonoPedido,Referencia,Comentario,SubTotal,Descuento,Itbis,Total,Nulo,Impreso,Cierre) VALUES (9,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDCondicion.Text + "','" + txtIDVendedor.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDUsuario.Text + "','" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtDireccion.Text + "','" + txtTelefonos.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + txtSubTotal.Text + "','" + txtDescuento.Text + "','" + txtItbis.Text + "','" + txtNeto.Text + "','" + lblNulo.Text + "',0,0)"
                GuardarDatos()
                ConvertCurrent()
                UltPedido()
                SetSecondID()
                InsertArticulos()
                DesHabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota de pedido?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Pedidos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',NombrePedido='" + txtNombre.Text + "',DireccionPedido='" + txtDireccion.Text + "',TelefonoPedido='" + txtTelefonos.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',Itbis='" + txtItbis.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPedido= (" + txtIDPedido.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_pedidos.Show(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la nota de pedido No. " & txtIDPedido.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Pedidos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',NombrePedido='" + txtNombre.Text + "',DireccionPedido='" + txtDireccion.Text + "',TelefonoPedido='" + txtTelefonos.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',Itbis='" + txtItbis.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPedido= (" + txtIDPedido.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDPedido.Text = "" Then
            MessageBox.Show("No hay un registro de nota de pedido abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de la nota de pedido No. " & txtIDPedido.Text & " del sistema?", "Anular Nota de Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Pedidos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDCondicion='" + lblIDCondicion.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',NombrePedido='" + txtNombre.Text + "',DireccionPedido='" + txtDireccion.Text + "',TelefonoPedido='" + txtTelefonos.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',Itbis='" + txtItbis.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPedido= (" + txtIDPedido.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub


    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "' ORDER BY Orden ASC", ConLibregco)
        lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        If ChangedCodeEmployee = True And txtIDVendedor.Text <> "" Then
            frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
            frm_contraseña_empleado.ShowDialog(Me)
        Else
            If txtIDVendedor.Text <> "" Then
                If txtVendedor.Text = "" Then
                    frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
                    frm_contraseña_empleado.ShowDialog(Me)
                End If
            Else
                txtIDVendedor.Clear()
                txtVendedor.Clear()
            End If
        End If
    End Sub

    Private Sub lblModificar_Click(sender As Object, e As EventArgs) Handles lblModificar.Click
        If txtDireccion.Visible = False Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height + 78)
            txtNombre.Enabled = True
            txtNombre.ReadOnly = False
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
            txtNombre.Focus()
        Else
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            txtNombre.Enabled = False
            txtNombre.ReadOnly = True
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        End If
    End Sub

    Private Sub lblAjustarGbClientes_Click(sender As Object, e As EventArgs) Handles lblAjustarGbClientes.Click
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        Else
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
        End If
    End Sub

    Private Sub GbClientes_Leave(sender As Object, e As EventArgs) Handles GbClientes.Leave
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
        End If
    End Sub
  
    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub frm_pedidos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        ChangedCodeEmployee = True
    End Sub

    Private Sub cbxPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio.SelectedIndexChanged
        Try
            If CbxMedida.Text <> "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                lblIDPrecio.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                txtPrecio.Text = CDbl(GetPrices(cbxPrecio.Text, txtIDArticulo.Text, lblIDMedida.Text, cbxMoneda.EditValue)).ToString("C")
            End If


        Catch ex As Exception

        End Try
    End Sub

  
End Class