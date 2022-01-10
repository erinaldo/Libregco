Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_subcategorias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_subcategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If Me.Owner.Name = frm_mant_articulos.Name Then
                If frm_mant_articulos.txtIDCategoria.Text = "" Then
                    If frm_mant_articulos.txtIDDepartamento.Text = "" Then
                        If rdbCodigo.Checked = True Then
                            cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria.IDSubCategoria like '%" + txtBuscar.Text + "%' ORDER BY SubCategoria ASC", ConLibregco)
                        ElseIf rdbSubCategoria.Checked = True Then
                            cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria like '%" + txtBuscar.Text + "%' ORDER BY SubCategoria ASC", ConLibregco)
                        End If
                    Else
                        If rdbCodigo.Checked = True Then
                            cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria.IDSubCategoria like '%" + txtBuscar.Text + "%' And Departamentos.IDDepartamento='" + frm_mant_articulos.txtIDDepartamento.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                        ElseIf rdbSubCategoria.Checked = True Then
                            cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria like '%" + txtBuscar.Text + "%' And Departamentos.IDDepartamento='" + frm_mant_articulos.txtIDDepartamento.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                        End If
                    End If
                Else
                    If rdbCodigo.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDSubCategoria like '%" + txtBuscar.Text + "%' and SubCategoria.IDCategoria='" + frm_mant_articulos.txtIDCategoria.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                    ElseIf rdbSubCategoria.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria like '%" + txtBuscar.Text + "%' and SubCategoria.IDCategoria='" + frm_mant_articulos.txtIDCategoria.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                    End If
                End If


            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDSubCategoria like '%" + txtBuscar.Text + "%' and SubCategoria.IDCategoria='" + frm_buscar_mant_articulos.txtIDCategoria.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                ElseIf rdbSubCategoria.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria like '%" + txtBuscar.Text + "%' and SubCategoria.IDCategoria='" + frm_buscar_mant_articulos.txtIDCategoria.Text + "' ORDER BY SubCategoria ASC", ConLibregco)
                End If

            Else
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDSubCategoria like '%" + txtBuscar.Text + "%' ORDER BY SubCategoria ASC", ConLibregco)
                ElseIf rdbSubCategoria.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria.subcategoria,SubCategoria.IDCategoria,Categoria.Categoria,Departamentos.IDDepartamento,Departamentos.Departamento,SubCategoria.Nulo,SubCategoriaFilePath FROM subcategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where SubCategoria like '%" + txtBuscar.Text + "%' ORDER BY SubCategoria ASC", ConLibregco)
                End If
            End If


            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SubCategorias")

            Bs.DataMember = "SubCategorias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvSubCategoria.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbSubCategoria.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvSubCategoria
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Sub-Categoría"
            .Columns(1).Width = 360
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_subcategorias.Name Then
                frm_mant_subcategorias.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_mant_subcategorias.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value
                frm_mant_subcategorias.txtIDCategoria.Text = DgvSubCategoria.CurrentRow.Cells(2).Value
                frm_mant_subcategorias.txtCategoria.Text = DgvSubCategoria.CurrentRow.Cells(3).Value

                If DgvSubCategoria.CurrentRow.Cells(6).Value = 0 Then
                    frm_mant_subcategorias.chkNulo.Checked = False
                Else
                    frm_mant_subcategorias.chkNulo.Checked = True
                End If

                If DgvSubCategoria.CurrentRow.Cells(7).Value <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvSubCategoria.CurrentRow.Cells(7).Value)
                    If ExistFile = True Then
                        frm_mant_subcategorias.lblRutaFoto.Text = DgvSubCategoria.CurrentRow.Cells(7).Value

                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(DgvSubCategoria.CurrentRow.Cells(7).Value, FileMode.Open, FileAccess.Read)
                        frm_mant_subcategorias.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_subcategorias.PicImagen.Image = My.Resources.No_Image
                    End If

                Else
                    frm_mant_subcategorias.lblRutaFoto.Text = ""
                    frm_mant_subcategorias.PicImagen.Image = My.Resources.No_Image
                End If


                frm_mant_subcategorias.btnMultipleRegistro.Visible = False
                frm_mant_subcategorias.PanelHibrido.Size = New Size(453, 31)
                frm_mant_subcategorias.PanelHibrido.Location = New Point(0, 440)
                frm_mant_subcategorias.btnMultipleRegistro.Text = "Modo de múltiples registros"
                frm_mant_subcategorias.btnMultipleRegistro.Visible = True
                frm_mant_subcategorias.Size = New Size(469, 535)

            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value
                frm_mant_articulos.txtIDCategoria.Text = DgvSubCategoria.CurrentRow.Cells(2).Value
                frm_mant_articulos.txtCategoria.Text = DgvSubCategoria.CurrentRow.Cells(3).Value
                frm_mant_articulos.txtIDDepartamento.Text = DgvSubCategoria.CurrentRow.Cells(4).Value
                frm_mant_articulos.txtDepartamento.Text = DgvSubCategoria.CurrentRow.Cells(5).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_detalle_ventas.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_detalle_compras.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_orden_compra.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_inventario_fecha.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_inventario.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                frm_actualizar_propiedades_articulos.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                frm_ajuste_inventario.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.name Then
                frm_buscar_mant_articulos.txtIDSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(0).Value
                frm_buscar_mant_articulos.txtSubcategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value
                frm_buscar_mant_articulos.RefrescarTablaArticulos()
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbCategoria_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub DgvSubCategoria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSubCategoria.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvSubCategoria.Focus()
    End Sub


    Private Sub DgvSubCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvSubCategoria.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvSubCategoria.Focus()
        End If
    End Sub

    Private Sub DgvSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSubCategoria.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
            'If e.KeyCode = Keys.Enter Then
            '    Dim NumCols As Integer = DgvSubCategoria.ColumnCount
            '    Dim NumRows As Integer = DgvSubCategoria.RowCount
            '    Dim CurCell As DataGridViewCell = DgvSubCategoria.CurrentCell
            '    If CurCell.ColumnIndex = NumCols - 1 Then
            '        If CurCell.RowIndex < NumRows - 1 Then
            '            DgvSubCategoria.CurrentCell = DgvSubCategoria.Item(0, CurCell.RowIndex + 1)
            '        End If
            '    Else
            '        DgvSubCategoria.CurrentCell = DgvSubCategoria.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
            '    End If
            '    e.Handled = True
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_buscar_subcategorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class