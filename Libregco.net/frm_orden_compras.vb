Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_orden_compras

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblCheckDuplicates, Fraccionamiento, lblIDOrdenDetalle, lblIDPrecio, lblTipoItbis As New Label
    Dim Permisos As New ArrayList
    Dim PermitirDuplicados As String

    Private Sub frm_orden_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        CargarConfiguracion
        Permisos = PasarPermisos(Me.Tag)
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarConfiguracion()
        ConMixta.Open()

        'Permitir duplicados
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=169", ConMixta)
        PermitirDuplicados = Convert.ToString(cmd.ExecuteScalar())

        ConMixta.Close()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try
            GbxUserInfo.Text = "User Info --> " & frm_inicio.Button3.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDOrdenCompraDetalle", "IDOrdenCompraDetalle")  '0
            .Columns.Add("IDOrdenCompra", "IDOrdenCompra")    '1
            .Columns.Add("IDArticulo", "Código")    '2
            .Columns.Add("IDPrecio", "IDPrecio")    '3
            .Columns.Add("IDMedida", "IDMedida")    '4
            .Columns.Add("Medida", "Medida")    '5
            .Columns.Add("Cantidad", "Cant.")   '6
            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("Subtotal", "Subtotal")  '8
            .Columns.Add("Itbis", "Itbis")  '9
            .Columns.Add("Precio", "Precio") '10
            .Columns.Add("Importe", "Importe")   '11
        End With
        PropiedadesDgvArticulos()
    End Sub

    Private Function VScrollBarVisible() As Boolean
        Dim ctrl As New Control
        For Each ctrl In DgvArticulos.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing
    End Function

    Sub PropiedadesDgvArticulos()
        Try
            If DgvArticulos.Columns.Count > 0 Then
                Dim VScrollBarWidht As Integer = 0

                If VScrollBarVisible() = True Then
                    VScrollBarWidht = 17
                Else
                    VScrollBarWidht = 0
                End If

                Dim DatagridWidth As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth - VScrollBarWidht) / 100
                Dim Condicion As String = False

                With DgvArticulos
                    .Columns(0).Visible = Condicion
                    .Columns(1).Visible = Condicion
                    .Columns(2).Width = DatagridWidth * 8
                    .Columns(3).Visible = Condicion
                    .Columns(4).Visible = Condicion
                    .Columns(5).Width = DatagridWidth * 10
                    .Columns(6).Width = DatagridWidth * 6
                    .Columns(7).Width = DatagridWidth * 36
                    .Columns(8).DefaultCellStyle.Format = ("C")
                    .Columns(8).Width = DatagridWidth * 10
                    .Columns(9).DefaultCellStyle.Format = ("C")
                    .Columns(9).Width = DatagridWidth * 10
                    .Columns(10).Width = DatagridWidth * 10
                    .Columns(10).DefaultCellStyle.Format = ("C")
                    .Columns(11).Width = DatagridWidth * 10
                    .Columns(11).DefaultCellStyle.Format = ("C")
                End With
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("hh:mm:ss")
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub


    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Try
            If Fraccionamiento.Text = 1 Then
                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select

                If (txtCantidadArticulo.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
                    e.Handled = True
                End If
            Else

                Dim Car% = Asc(e.KeyChar)
                Select Case Car
                    Case 8
                    'Case 46
                    Case 48 To 57
                    Case Else
                        e.KeyChar = Nothing
                End Select
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        Try
            If txtIDArticulo.Text = "" Then
                LimpiarDatosArticulos()
            Else
                If txtIDArticulo.Text.Substring(0, 1) = "-" Then
                    Dim Index As Integer = txtIDArticulo.Text.Remove(0, 1)
                    If Index > 0 Then
                        If DgvArticulos.Rows.Count >= Index - 1 Then
                            DgvArticulos.Rows.Remove(DgvArticulos.Rows(Index - 1))
                            LimpiarDatosArticulos()
                            SumTotales()
                        Else
                            LimpiarDatosArticulos()
                        End If
                    Else
                        LimpiarDatosArticulos()
                    End If

                ElseIf txtIDArticulo.Text.Substring(0, 1) = "*" Then
                    Dim Index As Integer = txtIDArticulo.Text.Remove(0, 1)
                    If Index > 0 Then
                        If DgvArticulos.Rows.Count >= Index - 1 Then
                            LimpiarDatosArticulos()
                            DgvArticulos.Focus()
                            DgvArticulos.Rows(Index - 1).Selected = True
                            DgvArticulos.FirstDisplayedScrollingRowIndex = Index - 1
                            DgvArticulos.CurrentCell = Me.DgvArticulos.Rows(Index - 1).Cells(0)
                        Else
                            LimpiarDatosArticulos()
                        End If
                        LimpiarDatosArticulos()
                    Else
                        LimpiarDatosArticulos()
                    End If

                    LimpiarDatosArticulos()

                Else
                    SetInformacionArticulo()
                End If


                If txtIDArticulo.Text = 1 Then
                    txtDescripcionArticulo.Enabled = True
                    txtDescripcionArticulo.ReadOnly = False
                Else
                    txtDescripcionArticulo.Enabled = False
                    txtDescripcionArticulo.ReadOnly = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub SetDescripcionArt()
        Try
            Ds.clear()
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
            End If

        Catch ex As Exception
            LimpiarDatosArticulos()
            txtIDArticulo.Focus()
        End Try
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

    Sub SetInformacionArticulo()
        Try
            SetDescripcionArt()
            txtCantidadArticulo.Text = 1
            FillMedida()
        Catch ex As Exception
            LimpiarDatosArticulos()
        End Try
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

        If Tabla.Rows.Count > 0 Then
            CbxMedida.SelectedIndex = 0
        End If
    End Sub

    Sub LimpiarDatosArticulos()
        txtIDArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtCantidadArticulo.Clear()
        txtPrecio.Clear()
        txtCantidadArticulo.Clear()
        CbxMedida.Items.Clear()
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        SetPrecio()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        CbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Fraccionamiento FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Fraccionamiento.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()
    End Sub

    Sub SetPrecio()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Costo FROM PrecioArticulo WHERE IDArticulo= '" + txtIDArticulo.Text + "' AND IDMedida='" + CbxMedida.Tag.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PrecioArticulo")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")
            txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Costo")).ToString("C")
            lblIDPrecio.Text = (Tabla.Rows(0).Item("IDPrecios"))

        Catch ex As Exception
            LimpiarDatosArticulos()
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DesHabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub DesHabilitarControles()
        GbSuplidor.Enabled = False
        GbArticulos.Enabled = False
        txtReferencia.Enabled = False
        txtComentario.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbSuplidor.Enabled = True
        GbArticulos.Enabled = True
        txtReferencia.Enabled = True
        txtComentario.Enabled = True
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If DgvArticulos.Rows.Count = 0 Or x = DgvArticulos.Rows.Count Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(DgvArticulos.Rows(x).Cells(3).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra introducido en la orden de compras." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try

            If txtIDArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtIDArticulo.Focus()

            Else

                If CbxMedida.Items.Count = 0 Then
                    MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    CbxMedida.Focus()
                    Exit Sub
                End If

                If PermitirDuplicados = 0 Then
                    VerificarDuplicados()
                    If lblCheckDuplicates.Text = 1 Then
                        Exit Sub
                    End If
                End If

                With DgvArticulos

                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
                    Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    If rdbIncluido.Checked = True Then
                        Dim PrecioUnitarioSinItbis As Double = (CDbl(txtPrecio.Text) / (CDbl(1) + ItbisC))
                        Dim ItbisCalculado As Double = (PrecioUnitarioSinItbis * ItbisC)

                        .Rows.Add(lblIDOrdenDetalle.Text, txtIDOrdenCompra.Text, IDArticulo.Text, lblIDPrecio.Text, CbxMedida.Tag.ToString, CbxMedida.Text, txtCantidadArticulo.Text, txtDescripcionArticulo.Text, PrecioUnitarioSinItbis, ItbisCalculado, (PrecioUnitarioSinItbis + ItbisCalculado), ((PrecioUnitarioSinItbis + ItbisCalculado) * txtCantidadArticulo.Text))

                    ElseIf rdbNoIncluido.Checked = True Then
                        Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                        Dim ItbisCalculado As Double = (PrecioUnitarioSinItbis) * (1 + ItbisC)

                        .Rows.Add(lblIDOrdenDetalle.Text, txtIDOrdenCompra.Text, IDArticulo.Text, lblIDPrecio.Text, CbxMedida.Tag.ToString, CbxMedida.Text, txtCantidadArticulo.Text, txtDescripcionArticulo.Text, PrecioUnitarioSinItbis, ItbisCalculado, (PrecioUnitarioSinItbis + ItbisCalculado), ((PrecioUnitarioSinItbis + ItbisCalculado) * txtCantidadArticulo.Text))

                    ElseIf rdbNoItbis.Checked = True Then
                        Dim PrecioUnitarioSinItbis As Double = CDbl(txtPrecio.Text)
                        Dim ItbisCalculado As Double = 0

                        .Rows.Add(lblIDOrdenDetalle.Text, txtIDOrdenCompra.Text, IDArticulo.Text, lblIDPrecio.Text, CbxMedida.Tag.ToString, IDArticulo.Text, CbxMedida.Text, txtCantidadArticulo.Text, txtDescripcionArticulo.Text, PrecioUnitarioSinItbis, ItbisCalculado, (PrecioUnitarioSinItbis + ItbisCalculado), ((PrecioUnitarioSinItbis + ItbisCalculado) * txtCantidadArticulo.Text))
                    End If
                End With

                SumTotales()
                LimpiarTextInsert()
                DgvArticulos.ClearSelection()
                DgvArticulos.FirstDisplayedScrollingRowIndex = DgvArticulos.Rows.Count - 1
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
        txtIDArticulo.Clear()
        CbxMedida.Tag = ""
        lblIDPrecio.Text = ""
        IDArticulo.Text = ""
        txtIDArticulo.Focus()
    End Sub

    Sub SumTotales()
        Dim SubTotal As Double = 0
        Dim SumItbis As Double = 0
        Dim Importe As Double = 0
        Dim IDArt, ItbisCalc As New Label

        ConLibregco.Open()

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            IDArt.Text = Rows.Cells(2).Value
            cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + IDArt.Text + "'", ConLibregco)
            ItbisCalc.Text = Convert.ToDouble(cmd.ExecuteScalar())

            SubTotal = SubTotal + (CDbl(Rows.Cells(8).Value) * (CDbl(Rows.Cells(6).Value)))

            If rdbIncluido.Checked = True Then
                Rows.Cells(9).Value = CDbl(Rows.Cells(8).Value) * CDbl(ItbisCalc.Text)
            ElseIf rdbNoIncluido.Checked = True Then
                Rows.Cells(9).Value = CDbl(Rows.Cells(8).Value) * CDbl(ItbisCalc.Text)
            ElseIf rdbNoItbis.Checked = True Then
                Rows.Cells(9).Value = CDbl(0)
            End If

            SumItbis = SumItbis + (CDbl(Rows.Cells(9).Value) * CDbl(Rows.Cells(6).Value))

            Rows.Cells(10).Value = CDbl(Rows.Cells(8).Value) + CDbl(Rows.Cells(9).Value)
            Rows.Cells(11).Value = (CDbl(Rows.Cells(8).Value) + CDbl(Rows.Cells(9).Value)) * CDbl(Rows.Cells(6).Value)
        Next

        txtSubTotal.Text = SubTotal.ToString("C")
        txtItbis.Text = SumItbis.ToString("C")
        txtNeto.Text = CDbl(SubTotal + SumItbis).ToString("C")

        ConLibregco.Close()
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
        Dim IDDetalleCompra As New Label
        IDDetalleCompra.Text = DgvArticulos.CurrentRow.Cells(0).Value

        If IDDetalleCompra.Text = "" Then
            DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
        Else
            sqlQ = "Delete from OrdenCompraDetalle Where IDOrdenCompraDetalle = (" + IDDetalleCompra.Text + ")"
            GuardarDatos()
            DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)

            MessageBox.Show("Artículo eliminado satisfactoriamente de la factura.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub


    Private Sub EliminacionPorModificacion()
        Dim IDOrdenCompraDetalle As String = DgvArticulos.CurrentRow.Cells(0).Value

        If IDOrdenCompraDetalle = "" Then
            DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)

        Else

            sqlQ = "Delete from OrdenCompraDetalle Where IDOrdenCompraDetalle = (" + IDOrdenCompraDetalle + ")"
            GuardarDatos()
            DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
            MessageBox.Show("Artículo eliminado satisfactoriamente de la factura.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        End If

    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("dd/MM/yyyy")
        txtNeto.Text = CDbl(0.0).ToString("C")
        txtSubTotal.Text = CDbl(0.0).ToString("C")
        txtItbis.Text = CDbl(0.0).ToString("C")
        FillStatusOrden()
        ChkNulo.Checked = False
        FillAlmacen()
        lblCheckDuplicates.Text = 1
        ControlSuperClave = 1
        rdbIncluido.Checked = True
        rdbNoItbis.Visible = True
        txtDescripcionArticulo.Enabled = False
        txtDescripcionArticulo.ReadOnly = True
        btnBuscarSup.Focus()
    End Sub

    Sub FillStatusOrden()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoOrdenCompra ORDER BY Descripcion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoOrdenCompra")
        cbxStatusOrder.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoOrdenCompra")
        For Each Fila As DataRow In Tabla.Rows
            cbxStatusOrder.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count > 0 Then
            cbxStatusOrder.Text = "Sin procesar"
        Else
            MessageBox.Show("No se encontraron nacionalidades hábiles en la base de datos. Inserte nacionalidades para procesar los registros de los clientes.", "No se encontraron nacionalidades", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub LiberarDgvArticulos()
        Try
            Dim Counter As Integer
            Counter = DgvArticulos.Columns.Count

            If Counter = 0 Then
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

        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtSecondID.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoPago.Clear()
        txtUltimoMonto.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtIDOrdenCompra.Clear()
        CbxMedida.Items.Clear()
        cbxStatusOrder.Items.Clear()
        txtReferencia.Clear()
        txtComentario.Clear()
        lblIDOrdenDetalle.Text = ""
        txtSubTotal.Clear()
        txtItbis.Clear()
        txtNeto.Clear()
        LimpiarTextInsert()
    End Sub

    Private Sub UltOrdendeCompra()
        Try
            If txtIDOrdenCompra.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDOrdenCompra from OrdenCompra where IDOrdenCompra= (Select Max(IDOrdenCompra) from OrdenCompra)", Con)
                txtIDOrdenCompra.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPrecio.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDOrdenCompra.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la orden de compras?", "Imprimir Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub InsertArticulos()

        Con.Open()

        For Each rw As DataGridViewRow In DgvArticulos.Rows
            If CStr(rw.Cells(0).Value) = "" Then
                cmd = New MySqlCommand("INSERT INTO OrdenCompraDetalle (IDOrdenCompra,IDArticulo,IDPrecio,IDMedida,Medida,Cantidad,Descripcion,SubtotalDetalle,ItbisDetalle,Precio,Importe) VALUES ('" + txtIDOrdenCompra.Text + "','" + rw.Cells(2).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(4).Value.ToString + "','" + rw.Cells(5).Value.ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + rw.Cells(7).Value.ToString + "','" + CDbl(rw.Cells(8).Value).ToString + "','" + CDbl(rw.Cells(9).Value).ToString + "','" + CDbl(rw.Cells(10).Value).ToString + "','" + CDbl(rw.Cells(11).Value).ToString + "')", Con)
                cmd.ExecuteNonQuery()
                CheckProductListStatus(rw.Cells("IDArticulo").Value.ToString, 2)
            End If
        Next

        Con.Close()

        RefrescarTablaArticulos()
    End Sub

    Sub RefrescarTablaArticulos()

        Try
            If txtIDOrdenCompra.Text = "" Then
            Else
                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select * FROM OrdenCompraDetalle Where IDOrdenCompra='" + txtIDOrdenCompra.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11))
                End While
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

    Private Sub btnBlanquearListado_Click(sender As Object, e As EventArgs) Handles btnBlanquearListado.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDOrdenCompra.Text = "" And DgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    DgvArticulos.Rows.Clear()
                    SumTotales()
                    Exit Sub
                End If
            End If

            If txtIDOrdenCompra.Text > 0 And DgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya insertados a través de esta función." & vbNewLine & "Para proceder a la eliminación de artículos utilice la función F2-Quitar Artículos.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If DgvArticulos.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & DgvArticulos.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    EliminarArticulo()
                    SumTotales()
                    ActualizarCambios()

                    Con.Open()
                    CheckProductListStatus(DgvArticulos.CurrentRow.Cells(7).Value.ToString, 0)
                    Con.Close()
                End If
            Else
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ActualizarCambios()
        If txtIDOrdenCompra.Text = "" Then
        Else
            sqlQ = "UPDATE OrdenCompra SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSuplidor='" + txtIDSuplidor.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + txtNeto.Text + "',IDTipoOrden='" + cbxStatusOrder.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDOrdenCompra= (" + txtIDOrdenCompra.Text + ")"
            GuardarDatos()
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try

            If DgvArticulos.Rows.Count > 0 Then
                txtIDArticulo.Text = DgvArticulos.CurrentRow.Cells(2).Value
                IDArticulo.Text = DgvArticulos.CurrentRow.Cells(2).Value
                FillMedida()
                CbxMedida.Text = DgvArticulos.CurrentRow.Cells(5).Value
                CbxMedida.Tag = DgvArticulos.CurrentRow.Cells(4).Value
                txtCantidadArticulo.Text = DgvArticulos.CurrentRow.Cells(6).Value
                txtDescripcionArticulo.Text = DgvArticulos.CurrentRow.Cells(7).Value
                txtPrecio.Text = CDbl(DgvArticulos.CurrentRow.Cells(8).Value).ToString("C")
                txtPrecio.Focus()

                EliminacionPorModificacion()
                SumTotales()
                ActualizarCambios()
            Else
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDOrdenCompra.Text = "" Then
            If DgvArticulos.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de registro de ordenes de compras?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                    LiberarDgvArticulos()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
                LiberarDgvArticulos()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
            LiberarDgvArticulos()
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=5", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE OrdenCompra SET SecondID='" + lblSecondID.Text + "' WHERE IDOrdenCompra='" + txtIDOrdenCompra.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=5"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetTipoItbis()
        If rdbIncluido.Checked = True Then
            lblTipoItbis.Text = 1
        ElseIf rdbNoIncluido.Checked = True Then
            lblTipoItbis.Text = 2
        ElseIf rdbNoItbis.Checked = True Then
            lblTipoItbis.Text = 3
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar la orden de compra.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtComentario.Text = "" Then
            MessageBox.Show("Escriba una breve nota sobre la orden de compras.", "Escriba Notas de descripción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComentario.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos en la orden de compras. Se necesita al menos un artículo para procesar la orden de compras.", "Inserte artículo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDOrdenCompra.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar la guardar la orden de compras en la base de datos?", "Guardar Orden de Compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                SetTipoItbis()
                sqlQ = "INSERT INTO OrdenCompra (IDTipoDocumento,IDSucursal,IDAlmacen,Fecha,Hora,IDUsuario,IDSuplidor,Referencia,Comentario,TipoItbis,SubtotalOrden,ItbisOrden,Total,IDTipoOrden,Nulo,Impreso) VALUES (5,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + CbxAlmacen.Tag.ToString + "',CURDATE(),CURTIME(),'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtIDSuplidor.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + lblTipoItbis.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(txtItbis.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + cbxStatusOrder.Tag.ToString + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0)"
                GuardarDatos()
                UltOrdendeCompra()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la orden de compras?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                SetTipoItbis()
                sqlQ = "UPDATE OrdenCompra SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSuplidor='" + txtIDSuplidor.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',TipoItbis='" + lblTipoItbis.Text + "',SubtotalOrden='" + CDbl(txtSubTotal.Text).ToString + "',ItbisOrden='" + CDbl(txtItbis.Text).ToString + "',Total='" + CDbl(txtNeto.Text).ToString + "',IDTipoOrden='" + cbxStatusOrder.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDOrdenCompra= (" + txtIDOrdenCompra.Text + ")"
                GuardarDatos()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub cbxStatusOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatusOrder.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoOrdenCompra FROM TipoOrdenCompra WHERE Descripcion= '" + cbxStatusOrder.SelectedItem + "'", ConLibregco)
        cbxStatusOrder.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar la orden de compra.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtComentario.Text = "" Then
            MessageBox.Show("Escriba una breve nota sobre la orden de compras.", "Escriba Notas de descripción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComentario.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos en la orden de compras. Se necesita al menos un artículo para procesar la orden de compras.", "Inserte artículo(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDOrdenCompra.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar la guardar la orden de compras en la base de datos?", "Guardar Orden de Compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                SetTipoItbis()
                sqlQ = "INSERT INTO OrdenCompra (IDTipoDocumento,IDSucursal,IDAlmacen,Fecha,Hora,IDUsuario,IDSuplidor,Referencia,Comentario,TipoItbis,SubtotalOrden,ItbisOrden,Total,IDTipoOrden,Nulo,Impreso) VALUES (5,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + CbxAlmacen.Tag.ToString + "',CURDATE(),CURTIME(),'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtIDSuplidor.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + lblTipoItbis.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(txtItbis.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + cbxStatusOrder.Tag.ToString + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0)"
                GuardarDatos()
                UltOrdendeCompra()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la orden de compras?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                SetTipoItbis()
                sqlQ = "UPDATE OrdenCompra SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSuplidor='" + txtIDSuplidor.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',TipoItbis='" + lblTipoItbis.Text + "',SubtotalOrden='" + CDbl(txtSubTotal.Text).ToString + "',ItbisOrden='" + CDbl(txtItbis.Text).ToString + "',Total='" + CDbl(txtNeto.Text).ToString + "',IDTipoOrden='" + cbxStatusOrder.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDOrdenCompra= (" + txtIDOrdenCompra.Text + ")"
                GuardarDatos()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_orden_compra.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la orden de compras No. " & txtIDOrdenCompra.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Registro de Orden de Compras", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 87
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = False
                sqlQ = "UPDATE OrdenCompra SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSuplidor='" + txtIDSuplidor.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + CDbl(txtNeto.Text).ToString + "',IDTipoOrden='" + cbxStatusOrder.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDOrdenCompra= (" + txtIDOrdenCompra.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDOrdenCompra.Text = "" Then
            MessageBox.Show("No hay un registro de orden de compras abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de orden de compras No. " & txtIDOrdenCompra.Text & " del sistema?", "Anular Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 88
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = True
                sqlQ = "UPDATE OrdenCompra SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSuplidor='" + txtIDSuplidor.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + CDbl(txtNeto.Text).ToString + "',IDTipoOrden='" + cbxStatusOrder.Tag.ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDOrdenCompra= (" + txtIDOrdenCompra.Text + ")"
                GuardarDatos()
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

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        btnBuscarArticulo.PerformClick()
    End Sub

    Private Sub frm_orden_compras_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub CbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + CbxAlmacen.SelectedItem + "'", Con)
        CbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub rdbIncluido_CheckedChanged(sender As Object, e As EventArgs) Handles rdbIncluido.CheckedChanged
        If rdbIncluido.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub

    Private Sub rdbNoIncluido_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoIncluido.CheckedChanged
        If rdbNoIncluido.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub

    Private Sub rdbNoItbis_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoItbis.CheckedChanged
        If rdbNoItbis.Checked Then
            ChangeTypeofPrice()
        End If
    End Sub


    Private Sub ChangeTypeofPrice()

        For Each rw As DataGridViewRow In DgvArticulos.Rows
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Itbis FROM Libregco.articulos INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + rw.Cells(2).Value.ToString + "'", ConLibregco)
            Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()

            If rdbIncluido.Checked Then
                rw.Cells(8).Value = (CDbl(rw.Cells(8).Value) / (1 + ItbisC))
                rw.Cells(9).Value = (CDbl(rw.Cells(8).Value) / (1 + ItbisC)) * ItbisC
                rw.Cells(10).Value = CDbl(rw.Cells(8).Value) + CDbl(rw.Cells(9).Value)
                rw.Cells(11).Value = CDbl(rw.Cells(10).Value) * CDbl(rw.Cells(6).Value)

                rdbNoItbis.Visible = False

            ElseIf rdbNoIncluido.Checked Then

                rw.Cells(8).Value = (CDbl(rw.Cells(8).Value) + CDbl(rw.Cells(9).Value))
                rw.Cells(9).Value = CDbl(rw.Cells(8).Value) * ItbisC
                rw.Cells(10).Value = CDbl(rw.Cells(8).Value) + CDbl(rw.Cells(9).Value)
                rw.Cells(11).Value = CDbl(rw.Cells(10).Value) * CDbl(rw.Cells(6).Value)

                rdbNoItbis.Visible = False

            ElseIf rdbNoItbis.Checked Then
                rw.Cells(8).Value = CDbl(rw.Cells(8).Value)
                rw.Cells(9).Value = 0
                rw.Cells(10).Value = CDbl(rw.Cells(8).Value) + CDbl(rw.Cells(9).Value)
                rw.Cells(11).Value = CDbl(rw.Cells(10).Value) * CDbl(rw.Cells(6).Value)
            End If
        Next

        SumTotales()
    End Sub

    Private Sub txtIDArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDArticulo.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-*0123456789abcdefghijklmnñopqrstuvwxyz/"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtIDArticulo.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIDArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIDArticulo.Text <> "" Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtIDArticulo.Text <> "" Then
                If txtIDArticulo.SelectionStart = txtIDArticulo.TextLength Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtCantidadArticulo.SelectionStart = 0 Then
                CbxMedida.Focus()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength Then
                If txtDescripcionArticulo.Enabled = True Then
                    txtDescripcionArticulo.Focus()
                    txtDescripcionArticulo.SelectAll()
                Else
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If

            End If

        ElseIf e.KeyCode = Keys.Up Then
            txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) + 1
            txtCantidadArticulo.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            If CDbl(txtCantidadArticulo.Text) > 1 Then
                txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) - 1
                txtCantidadArticulo.SelectAll()
            End If

        End If
    End Sub

    Private Sub CbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtIDArticulo.Focus()
            txtIDArticulo.SelectAll()

        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecio.SelectionStart = 0 Then
                If txtDescripcionArticulo.Enabled = True Then
                    txtDescripcionArticulo.Focus()
                Else
                    txtCantidadArticulo.Focus()
                    txtCantidadArticulo.SelectAll()
                End If
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecio.SelectionStart = txtPrecio.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
End Class