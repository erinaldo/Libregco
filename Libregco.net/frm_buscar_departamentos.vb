Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_departamentos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_departamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM Departamentos where IDDepartamento like '%" + txtBuscar.Text + "%' ORDER BY IDDepartamento DESC", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Departamentos where Departamento like '%" + txtBuscar.Text + "%' ORDER BY Departamento ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Departamentos")

            Bs.DataMember = "Departamentos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDepartamentos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDepartamentos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).Width = 324
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With

    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
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

    Private Sub DgvDepartamentos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDepartamentos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDepartamentos.Focus()
    End Sub

    Private Sub DgvDepartamentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDepartamentos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDepartamentos.Focus()
        End If
    End Sub

    Private Sub DgvDepartamentos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDepartamentos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDepartamentos.ColumnCount
                Dim NumRows As Integer = DgvDepartamentos.RowCount
                Dim CurCell As DataGridViewCell = DgvDepartamentos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDepartamentos.CurrentCell = DgvDepartamentos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDepartamentos.CurrentCell = DgvDepartamentos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_departamentos.Name Then
                frm_mant_departamentos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_mant_departamentos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value
                frm_mant_departamentos.lblRutaFoto.Text = DgvDepartamentos.CurrentRow.Cells(2).Value

                If DgvDepartamentos.CurrentRow.Cells(2).Value <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvDepartamentos.CurrentRow.Cells(2).Value)
                    If ExistFile = True Then
                        frm_mant_departamentos.lblRutaFoto.Text = DgvDepartamentos.CurrentRow.Cells(2).Value

                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(DgvDepartamentos.CurrentRow.Cells(2).Value, FileMode.Open, FileAccess.Read)
                        frm_mant_departamentos.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_departamentos.PicImagen.Image = My.Resources.No_Image
                    End If

                Else
                    frm_mant_departamentos.lblRutaFoto.Text = ""
                    frm_mant_departamentos.PicImagen.Image = My.Resources.No_Image
                End If

                If DgvDepartamentos.CurrentRow.Cells(3).Value = 0 Then
                    frm_mant_departamentos.chkDesactivar.Checked = False
                Else
                    frm_mant_departamentos.chkDesactivar.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_categorias.Name Then
                frm_mant_categorias.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_mant_categorias.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_consulta_stocks.Name Then
                frm_consulta_stocks.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_consulta_stocks.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_detalle_ventas.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_detalle_compras.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_orden_compra.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_inventario_fecha.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_inventario.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                frm_actualizar_propiedades_articulos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                frm_ajuste_inventario.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value


            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.Name Then
                frm_buscar_mant_articulos.txtIDDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(0).Value
                frm_buscar_mant_articulos.txtDepartamento.Text = DgvDepartamentos.CurrentRow.Cells(1).Value
                frm_buscar_mant_articulos.RefrescarTablaArticulos()
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub



    Private Sub frm_buscar_departamentos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class