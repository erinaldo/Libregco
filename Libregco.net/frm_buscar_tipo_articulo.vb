Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_articulo

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_articulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM TipoArticulo where IDTipoArticulo like '%" + txtBuscar.Text + "%' ORDER BY IDTipoArticulo ASC", ConLibregco)
            ElseIf rdbTipo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoArticulo where TipoArticulo like '%" + txtBuscar.Text + "%' ORDER BY TipoArticulo DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoArticulo")

            Bs.DataMember = "TipoArticulo"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoArticulo.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbTipo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoArticulo
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Tipo de Artículo"
            .Columns(1).Width = 324
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbTipo_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvTipoArticulo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoArticulo.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoArticulo.Focus()
    End Sub

    Private Sub DgvTipoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoArticulo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoArticulo.Focus()
        End If
    End Sub

    Private Sub DgvTipoArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoArticulo.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoArticulo.ColumnCount
                Dim NumRows As Integer = DgvTipoArticulo.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoArticulo.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoArticulo.CurrentCell = DgvTipoArticulo.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoArticulo.CurrentCell = DgvTipoArticulo.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_tipo_productos.Name Then
                frm_mant_tipo_productos.txtIDTipo.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_mant_tipo_productos.txtTipoArticulo.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

                If DgvTipoArticulo.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_tipo_productos.chkNulo.Checked = False
                Else
                    frm_mant_tipo_productos.chkNulo.Checked = True
                End If
            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDTipoArticulo.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtTipoArticulo.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_detalle_compras.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_orden_compra.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_inventario_fecha.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_inventario.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                frm_actualizar_propiedades_articulos.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value


            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.name Then
                frm_buscar_mant_articulos.txtIDTipo.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_buscar_mant_articulos.txtTipo.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value
                frm_buscar_mant_articulos.RefrescarTablaArticulos()


            ElseIf Me.Owner.Name = frm_ajuste_inventario.name Then
                frm_ajuste_inventario.txtIDTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtTipoProducto.Text = DgvTipoArticulo.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_buscar_tipo_articulo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class