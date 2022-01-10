Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_categorias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                If frm_mant_articulos.txtIDDepartamento.Text = "" Then
                    If rdbCodigo.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDCategoria like '%" + txtBuscar.Text + "%' ORDER BY IDCategoria DESC", ConLibregco)
                    ElseIf rdbCategoria.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where Categoria like '%" + txtBuscar.Text + "%' ORDER BY Categoria ASC", ConLibregco)
                    End If

                Else
                    If rdbCodigo.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDCategoria like '%" + txtBuscar.Text + "%' and Categoria.IDDepartamento='" + frm_mant_articulos.txtIDDepartamento.Text + "' ORDER BY IDCategoria DESC", ConLibregco)
                    ElseIf rdbCategoria.Checked = True Then
                        cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where Categoria like '%" + txtBuscar.Text + "%' and Categoria.IDDepartamento='" + frm_mant_articulos.txtIDDepartamento.Text + "' ORDER BY Categoria ASC", ConLibregco)
                    End If

                End If

            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDCategoria like '%" + txtBuscar.Text + "%' and Categoria.IDDepartamento='" + frm_buscar_mant_articulos.txtIDDepartamento.Text + "' ORDER BY IDCategoria DESC", ConLibregco)
                ElseIf rdbCategoria.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where Categoria like '%" + txtBuscar.Text + "%' and Categoria.IDDepartamento='" + frm_buscar_mant_articulos.txtIDDepartamento.Text + "' ORDER BY Categoria ASC", ConLibregco)
                End If
            Else
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where IDCategoria like '%" + txtBuscar.Text + "%' ORDER BY IDCategoria DESC", ConLibregco)
                ElseIf rdbCategoria.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDCategoria,Categoria.IDDepartamento,Departamento,Categoria,Nulo,CategoriaFilePath FROM Categoria INNER JOIN departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento where Categoria like '%" + txtBuscar.Text + "%' ORDER BY Categoria ASC", ConLibregco)
                End If
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Categorias")

            Bs.DataMember = "Categorias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCategorias.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCategoria.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvCategorias
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).Visible = False
            '.Columns(2).HeaderText = "Departamento"
            '.Columns(2).Width = 140
            .Columns(2).Visible = False
            .Columns(3).HeaderText = "Categoría"
            .Columns(3).Width = 320
            .Columns(4).Visible = False
            .Columns(5).Visible = False
        End With
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

    Private Sub DgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCategorias.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCategorias.Focus()
    End Sub


    Private Sub DgvCategorias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCategorias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCategorias.Focus()
        End If
    End Sub

    Private Sub DgvCategorias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCategorias.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If DgvCategorias.Rows.Count > 0 Then
                If Me.Owner.Name = frm_mant_categorias.Name Then
                    frm_mant_categorias.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_mant_categorias.txtIDDepartamento.Text = DgvCategorias.CurrentRow.Cells(1).Value
                    frm_mant_categorias.txtDepartamento.Text = DgvCategorias.CurrentRow.Cells(2).Value
                    frm_mant_categorias.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                    If DgvCategorias.CurrentRow.Cells(4).Value = 0 Then
                        frm_mant_categorias.chkNulo.Checked = False
                    Else
                        frm_mant_categorias.chkNulo.Checked = True
                    End If

                    If DgvCategorias.CurrentRow.Cells(5).Value <> "" Then
                        Dim ExistFile As Boolean = System.IO.File.Exists(DgvCategorias.CurrentRow.Cells(5).Value)
                        If ExistFile = True Then
                            frm_mant_categorias.lblRutaFoto.Text = DgvCategorias.CurrentRow.Cells(5).Value

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(DgvCategorias.CurrentRow.Cells(5).Value, FileMode.Open, FileAccess.Read)
                            frm_mant_categorias.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            frm_mant_categorias.PicImagen.Image = My.Resources.No_Image
                        End If

                    Else
                        frm_mant_categorias.lblRutaFoto.Text = ""
                        frm_mant_categorias.PicImagen.Image = My.Resources.No_Image
                    End If


                ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                    frm_mant_articulos.txtIDDepartamento.Text = DgvCategorias.CurrentRow.Cells(1).Value
                    frm_mant_articulos.txtDepartamento.Text = DgvCategorias.CurrentRow.Cells(2).Value
                    frm_mant_articulos.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_mant_articulos.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_mant_subcategorias.Name Then
                    frm_mant_subcategorias.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_mant_subcategorias.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                    frm_reporte_productos.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_productos.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                    frm_reporte_detalle_ventas.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_detalle_ventas.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                    frm_reporte_detalle_compras.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_detalle_compras.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                    frm_reporte_orden_compra.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_orden_compra.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                    frm_reporte_inventario_fecha.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_inventario_fecha.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                    frm_reporte_movimientos_inventario.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_movimientos_inventario.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                    frm_reporte_series_garantias.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_reporte_series_garantias.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                    frm_actualizar_precios_costos.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_actualizar_precios_costos.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                    frm_ajuste_inventario.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_ajuste_inventario.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value


                ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                    frm_actualizar_propiedades_articulos.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_actualizar_propiedades_articulos.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value

                ElseIf Me.Owner.Name = frm_buscar_mant_articulos.Name Then
                    frm_buscar_mant_articulos.txtIDCategoria.Text = DgvCategorias.CurrentRow.Cells(0).Value
                    frm_buscar_mant_articulos.txtCategoria.Text = DgvCategorias.CurrentRow.Cells(3).Value
                    frm_buscar_mant_articulos.RefrescarTablaArticulos()
                End If

                Close()
                Exit Sub
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

  
    Private Sub frm_buscar_categorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class