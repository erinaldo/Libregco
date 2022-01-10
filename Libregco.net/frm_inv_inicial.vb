Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_inv_inicial

    Dim sqlQ As String = "" = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblIDUsuario, lblIDAlmacen, lblIDAlmacenArticulo, lblIDPrecio, lblIDMedida, lblNulo, lblCheckDuplicates As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_inv_inicial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtNeto.Text = CDbl(0.0).ToString("C")
        lblNulo.Text = 0
        ControlSuperClave = 0
        ChkNulo.Checked = False
        FillAlmacen()
    End Sub


    Private Sub FillAlmacen()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
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
        Else
            MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

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

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDMovimientoDetalle", "IDMovimientoDetalle")  '0
            .Columns.Add("IDMovimiento", "IDMovimiento")    '1
            .Columns.Add("IDPrecio", "IDPrecio")    '2
            .Columns.Add("IDArticulo", "Código")    '3
            .Columns.Add("Descripcion", "Descripción")  '4
            .Columns.Add("IDMedida", "IDMedida")    '5
            .Columns.Add("Medida", "Medida")        '6
            .Columns.Add("Cantidad", "Cant.")   '7
            .Columns.Add("Precio", "Precio") '8
            .Columns.Add("Importe", "Importe")   '9
            .Columns.Add("IDAlmacen", "Almacén") '10
        End With

        PropiedadesDgvArticulosa()
    End Sub

    Sub PropiedadesDgvArticulosa()
        Try
            If DgvArticulos.Columns.Count > 0 Then
                Dim Condicion As String = False
                Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100

                With DgvArticulos
                    .Columns("IDMovimientoDetalle").Visible = Condicion
                    .Columns("IDMovimiento").Visible = Condicion
                    .Columns("IDPrecio").Visible = Condicion
                    .Columns("IDArticulo").Width = DatagridWith * 10
                    .Columns("Descripcion").Width = DatagridWith * 33
                    .Columns("IDMedida").Visible = Condicion
                    .Columns("Medida").Width = DatagridWith * 10
                    .Columns("Cantidad").Width = DatagridWith * 10
                    .Columns("Precio").Width = DatagridWith * 13
                    .Columns("Precio").DefaultCellStyle.Format = ("C")
                    .Columns("Importe").Width = DatagridWith * 14
                    .Columns("Importe").DefaultCellStyle.Format = ("C")
                    .Columns("IDAlmacen").Width = DatagridWith * 10
                End With
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub CbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxAlmacen.SelectedIndexChanged
        SetIDAlmacen()
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + CbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
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
        Try
            If txtIDArticulo.Text = "" Then
                LimpiarDatosArticulos()
            Else
                SetInformacionArticulo()
                lblIDAlmacenArticulo.Text = lblIDAlmacen.Text
            End If
        Catch ex As Exception
        End Try
    End Sub


    Sub SetDescripcionArt()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtIDArticulo.Text + "' or CodigoBarra='" + txtIDArticulo.Text + "' or Articulos.Referencia='" + txtIDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")
            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Else
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
            End If

        Catch ex As Exception
            LimpiarDatosArticulos()
            txtIDArticulo.Focus()
        End Try
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
        IDArticulo.Text = ""
        CbxMedida.Items.Clear()
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        SetCosto()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Sub SetCosto()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Costo FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + IDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
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
            lblNulo.Text = 1
        Else
            HabilitarControles()
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub HabilitarControles()
        CbxAlmacen.Enabled = True
        txtReferencia.Enabled = True
        GbArticulos.Enabled = True
        txtComentario.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        CbxAlmacen.Enabled = False
        txtReferencia.Enabled = False
        GbArticulos.Enabled = False
        txtComentario.Enabled = False
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0
        Dim Counter As Integer = DgvArticulos.Rows.Count

Inicio:
        If DgvArticulos.Rows.Count = 0 Or x = Counter Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(DgvArticulos.Rows(x).Cells(2).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra introducido en la compra." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub btnAplicarMonto_Click(sender As Object, e As EventArgs) Handles btnAplicarMonto.Click
        Try
            If txtIDArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtIDArticulo.Focus()
            Else
                VerificarDuplicados()
                If lblCheckDuplicates.Text = 1 Then
                    Exit Sub
                End If

                With DgvArticulos
                    .Rows.Add("", "", lblIDPrecio.Text, IDArticulo.Text, txtDescripcionArticulo.Text, lblIDMedida.Text, CbxMedida.Text, txtCantidadArticulo.Text, CDbl(txtPrecio.Text).ToString("C"), CDbl((txtPrecio.Text) * CDbl(txtCantidadArticulo.Text)).ToString("C"), lblIDAlmacenArticulo.Text)
                End With

                SumImporte()
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
        txtIDArticulo.Clear()
        lblIDMedida.Text = ""
        IDArticulo.Text = ""
        txtIDArticulo.Focus()
    End Sub

    Private Sub SumImporte()
        Dim x As Integer = 0
        Dim Importe As Double = 0

Inicio:
        If x = DgvArticulos.Rows.Count Then
            GoTo Final
        Else
            Importe = (Importe + CDbl(DgvArticulos.Rows(x).Cells(9).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtNeto.Text = Importe.ToString("C")

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
        Dim IDMovimientoDetalle As New Label
        IDMovimientoDetalle.Text = DgvArticulos.CurrentRow.Cells(0).Value

        If IDMovimientoDetalle.Text = "" Or txtIDAjuste.Text = "" Then
            Exit Sub
        Else

            sqlQ = "Delete from MovimientoInvDetalle Where IDMovimientoDetalle = (" + IDMovimientoDetalle.Text + ")"
            GuardarDatos()
            CalcExistencia()
            CalcExistenciaAlm()
            MessageBox.Show("Artículo eliminado satisfactoriamente de la transacción de ajuste de inventario.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub EliminacionPorModificacion()
        Dim IDMovimientoDetalle As New Label
        IDMovimientoDetalle.Text = DgvArticulos.CurrentRow.Cells(0).Value

        If IDMovimientoDetalle.Text = "" Or txtIDAjuste.Text = "" Then
            Exit Sub
        Else

            sqlQ = "Delete from MovimientoInvDetalle Where IDMovimientoDetalle = (" + IDMovimientoDetalle.Text + ")"
            GuardarDatos()
        End If

    End Sub

    Private Sub LimpiarDatos()
        txtFecha.Clear()
        txtHora.Clear()
        txtIDAjuste.Clear()
        txtSecondID.Clear()
        CbxAlmacen.Items.Clear()
        CbxMedida.Items.Clear()
        txtReferencia.Clear()
        txtComentario.Clear()
        DgvArticulos.Rows.Clear()
        LimpiarTextInsert()
    End Sub

    Private Sub ConvertDouble()
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
    End Sub

    Private Sub UltAjuste()
        Try
            If txtIDAjuste.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAjusteInventario from MovimientoInventario where IDAjusteInventario= (Select Max(IDAjusteInventario) from MovimientoInventario)", Con)
                txtIDAjuste.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDAjuste.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el inventario inicial procesado?", "Imprimir Reporte de Inv. Inicial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub CalcExistencia()
        Dim IDArticulo As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(3).Value
            FunctCalcInventarioGral(IDArticulo)
        Next

    End Sub

    Private Sub CalcExistenciaAlm()
        Dim IDArticulo, IDPrecio As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(3).Value
            IDPrecio = Row.Cells(2).Value
            FunctCalcInvAlmacenes(IDArticulo, IDPrecio)
        Next

    End Sub

    Private Sub InsertArticulos()
        Dim IDMovimientoDetalle, IDMovimientoInventario, IDPrecio, IDArticulo, Descripcion, IDMedida, Medida, Cantidad, Precio, Importe, IDAlmacen As New Label
        Dim x As Integer = 0
        Dim Counter As Integer = DgvArticulos.RowCount

Inicio:
        If x = Counter Then
            GoTo Fin
        End If

        IDMovimientoDetalle.Text = DgvArticulos.Rows(x).Cells(0).Value
        IDMovimientoInventario.Text = DgvArticulos.Rows(x).Cells(1).Value
        IDPrecio.Text = DgvArticulos.Rows(x).Cells(2).Value
        IDArticulo.Text = DgvArticulos.Rows(x).Cells(3).Value
        Descripcion.Text = DgvArticulos.Rows(x).Cells(4).Value
        IDMedida.Text = DgvArticulos.Rows(x).Cells(5).Value
        Medida.Text = DgvArticulos.Rows(x).Cells(6).Value
        Cantidad.Text = DgvArticulos.Rows(x).Cells(7).Value
        Precio.Text = CDbl(DgvArticulos.Rows(x).Cells(8).Value)
        Importe.Text = CDbl(DgvArticulos.Rows(x).Cells(9).Value)
        IDAlmacen.Text = CDbl(DgvArticulos.Rows(x).Cells(10).Value)

        If IDMovimientoDetalle.Text = "" Then
            sqlQ = "INSERT INTO Movimientoinvdetalle (IDMovimientoInventario,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,Cantidad,Precio,Importe,IDAlmacen) VALUES ('" + txtIDAjuste.Text + "','" + IDPrecio.Text + "','" + IDArticulo.Text + "','" + Descripcion.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + Cantidad.Text + "','" + Precio.Text + "','" + Importe.Text + "','" + IDAlmacen.Text + "')"
        Else
            sqlQ = "UPDATE Movimientoinvdetalle SET IDMovimientoInventario='" + IDMovimientoInventario.Text + "',IDPrecio='" + IDPrecio.Text + "',IDArticulo='" + IDArticulo.Text + "',Descripcion='" + Descripcion.Text + "',IDMedida='" + IDMedida.Text + "',Medida='" + Medida.Text + "',Cantidad='" + Cantidad.Text + "',Precio='" + Precio.Text + "',Importe='" + Importe.Text + "',IDAlmacen='" + IDAlmacen.Text + "' Where IDMovimientoDetalle='" + IDMovimientoDetalle.Text + "'"
        End If

        GuardarDatos()
        x = x + 1
        GoTo Inicio

Fin:
        RefrescarTablaArticulos()
    End Sub

    Sub RefrescarTablaArticulos()
        Try
            If txtIDAjuste.Text = "" Then
            Else
                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDMovimientoDetalle,IDMovimientoInventario,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,Cantidad,Precio,Importe,IDAlmacen FROM Movimientoinvdetalle Where IDMovimientoInventario='" + txtIDAjuste.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10))
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

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub BuscarAjusteInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarAjusteInventarioToolStripMenuItem.Click
        btnBuscar.PerformClick()
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

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDAjuste.Text = "" And DgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    DgvArticulos.Rows.Clear()
                    SumImporte()
                    Exit Sub
                End If
            End If

            If txtIDAjuste.Text > 0 And DgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya insertados a través de esta función." & vbNewLine & "Para proceder a la eliminación de artículos utilice la función F2-Quitar Artículos.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If DgvArticulos.Rows.Count > 0 Then
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
            If DgvArticulos.Rows.Count > 0 Then
                txtIDArticulo.Text = DgvArticulos.CurrentRow.Cells(3).Value
                IDArticulo.Text = DgvArticulos.CurrentRow.Cells(3).Value
                FillMedida()
                CbxMedida.Text = DgvArticulos.CurrentRow.Cells(5).Value
                lblIDMedida.Text = DgvArticulos.CurrentRow.Cells(4).Value

                ConLibregco.Open()
                cmd = New MySqlCommand("Select Abreviatura from Medida where IDMedida='" + lblIDMedida.Text + "'", ConLibregco)
                CbxMedida.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                txtCantidadArticulo.Text = DgvArticulos.CurrentRow.Cells(6).Value
                txtDescripcionArticulo.Text = DgvArticulos.CurrentRow.Cells(4).Value
                lblIDAlmacenArticulo.Text = DgvArticulos.CurrentRow.Cells(10).Value
                txtPrecio.Text = CDbl(DgvArticulos.CurrentRow.Cells(8).Value).ToString("C")
                txtPrecio.Focus()

                EliminacionPorModificacion()
                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                SumImporte()
            Else
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

        End Try
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub


    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=10", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE MovimientoInventario SET IDTipoDocumento=10,SecondID='" + lblSecondID.Text + "' WHERE IDAjusteInventario='" + txtIDAjuste.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=10"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtReferencia.Text = "" Then
            MessageBox.Show("Escriba una breve referencia sobre el ajuste de inventario a través de inventario inicial.", "Referencia del ajuste", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han insertado artículos para proceasr el ajuste del inventario.", "No se detectaron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDAjuste.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la guardar el registro de inventario inicial en la base de datos?", "Guardar Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO MovimientoInventario (Fecha,Hora,IDTipodeAjuste,IDUsuario,IDSucursal,IDAlmacen,Referencia,Comentario,Total,Impreso,Nulo) VALUES ('" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDTipoAjuste.Text + "','" + lblIDUsuario.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + txtNeto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltAjuste()
                SetSecondID()
                InsertArticulos()
                CalcExistencia()
                CalcExistenciaAlm()
                DesHabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DesHabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el registro de inventario inicial?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE MovimientoInventario SET IDTipodeAjuste='" + txtIDTipoAjuste.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                CalcExistencia()
                CalcExistenciaAlm()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DesHabilitarControles()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtReferencia.Text = "" Then
            MessageBox.Show("Escriba una breve referencia sobre el ajuste de inventario a través de inventario inicial.", "Referencia del ajuste", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han insertado artículos para proceasr el ajuste del inventario.", "No se detectaron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDAjuste.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la guardar el registro de inventario inicial en la base de datos?", "Guardar Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO MovimientoInventario (Fecha,Hora,IDTipodeAjuste,IDUsuario,IDSucursal,IDAlmacen,Referencia,Comentario,Total,Impreso,Nulo) VALUES ('" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDTipoAjuste.Text + "','" + lblIDUsuario.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + txtNeto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltAjuste()
                SetSecondID()
                InsertArticulos()
                CalcExistencia()
                CalcExistenciaAlm()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el registro de inventario inicial?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE MovimientoInventario SET IDTipodeAjuste='" + txtIDTipoAjuste.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                CalcExistencia()
                CalcExistenciaAlm()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_ajustes_inventario.Show(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de ajuste de inventario No. " & txtIDAjuste.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Registro de Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE MovimientoInventario SET IDUsuario='" + lblIDUsuario.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',Referencia='" + txtReferencia.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                CalcExistencia()
                CalcExistenciaAlm()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDAjuste.Text = "" Then
            MessageBox.Show("No hay un registro de ajuste de inventario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de ajuste de inventario No. " & txtIDAjuste.Text & " del sistema?", "Anular Ajuste de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE MovimientoInventario SET IDUsuario='" + lblIDUsuario.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',Referencia='" + txtReferencia.Text + "',Total='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                CalcExistencia()
                CalcExistenciaAlm()
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

    Private Sub frm_inv_inicial_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulosa()
    End Sub

    Private Sub dgvArticulos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvArticulos.CellFormatting
        If e.ColumnIndex = Me.DgvArticulos.Columns(10).Index AndAlso (e.Value IsNot Nothing) Then

            With Me.DgvArticulos.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim IDAlmacen As String = DgvArticulos.CurrentRow.Cells(10).Value
                Con.Open()
                cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                .ToolTipText = Almacen
            End With
        End If
    End Sub

    Private Sub DgvArticulos_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulos.CellMouseMove
        If e.ColumnIndex = 10 Then
            If DgvArticulos.Rows.Count = 0 Then
            Else
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub DgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 10 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = DgvArticulos.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.Show(Me)
            End If
        End If
    End Sub
End Class