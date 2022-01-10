Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_marcas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
        LimpiartxtBuscar()
        RefrescarTabla()
        CheckSupposedBrand()
    End Sub

    Private Sub CheckSupposedBrand()
        If frm_mant_articulos.txtIDMarca.Text = "" Then

            If Me.Owner.Name = frm_mant_articulos.Name Then
                Con.Open()

                For Each word As String In frm_mant_articulos.txtDescrip.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                    If Len(word) > 1 Then
                        cmd = New MySqlCommand("SELECT count(Marca) FROM libregco.marca where Marca like '%" + word + "%'", Con)

                        If Convert.ToDouble(cmd.ExecuteScalar()) = 1 Then
                            Dim DsTemp As New DataSet
                            cmd = New MySqlCommand("SELECT IDMarca,Marca FROM libregco.marca where Marca like '%" + word + "%'", Con)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(DsTemp, "Marca")

                            Dim Tabla As DataTable = DsTemp.Tables("Marca")

                            lblIDSupMarca.Text = Tabla.Rows(0).Item(0)
                            lblSupMarca.Text = Tabla.Rows(0).Item(1)

                            lblSupuestaMarca.Visible = True
                            lblSupMarca.Visible = True

                            Tabla.Dispose()
                            Con.Close()

                            Exit Sub
                        End If
                    End If
                Next

                Con.Close()
            End If


        End If
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Marca where IDMarca like '%" + txtBuscar.Text + "%' ORDER BY IDMarca DESC", ConLibregco)
            ElseIf rdbMarca.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Marca where Marca like '%" + txtBuscar.Text + "%' ORDER BY Marca ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Marcas")

            Bs.DataMember = "Marcas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMarcas.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbMarca.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
        lblSupMarca.Visible = False
        lblSupuestaMarca.Visible = False

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvMarcas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Marca"
            .Columns(1).Width = 324
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbMarca_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvMarcas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMarcas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvMarcas.Focus()
    End Sub

    Private Sub DgvMarcas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvMarcas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvMarcas.Focus()
        End If
    End Sub

    Private Sub DgvMarcas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMarcas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMarcas.ColumnCount
                Dim NumRows As Integer = DgvMarcas.RowCount
                Dim CurCell As DataGridViewCell = DgvMarcas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMarcas.CurrentCell = DgvMarcas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMarcas.CurrentCell = DgvMarcas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_marcas.Name Then
                frm_mant_marcas.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_mant_marcas.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

                If DgvMarcas.CurrentRow.Cells(2).Value <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvMarcas.CurrentRow.Cells(2).Value)
                    If ExistFile = True Then
                        frm_mant_marcas.PicImagen.Tag = DgvMarcas.CurrentRow.Cells(2).Value

                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(DgvMarcas.CurrentRow.Cells(2).Value, FileMode.Open, FileAccess.Read)
                        frm_mant_marcas.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        frm_mant_marcas.PicImagen.Image = My.Resources.No_Image
                    End If

                Else
                    frm_mant_marcas.PicImagen.Tag = ""
                    frm_mant_marcas.PicImagen.Image = My.Resources.No_Image
                End If

                If DgvMarcas.CurrentRow.Cells(3).Value = 0 Then
                    frm_mant_marcas.chkNulo.Checked = False
                Else
                    frm_mant_marcas.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_ventas.Name Then
                frm_reporte_ventas.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_ventas.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_detalle_ventas.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_devolucion_ventas.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_detalle_compras.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_devolucion_compras.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_inventario_fecha.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_movimientos_inventario.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_reporte_series_garantias.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then
                frm_actualizar_propiedades_articulos.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                frm_ajuste_inventario.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value


            ElseIf Me.Owner.Name = frm_buscar_mant_articulos.name Then
                frm_buscar_mant_articulos.txtIDMarca.Text = DgvMarcas.CurrentRow.Cells(0).Value
                frm_buscar_mant_articulos.txtMarca.Text = DgvMarcas.CurrentRow.Cells(1).Value
                frm_buscar_mant_articulos.RefrescarTablaArticulos()
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub frm_buscar_marcas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

    Private Sub lblSupMarca_MouseEnter(sender As Object, e As EventArgs) Handles lblSupMarca.MouseEnter
        Cursor = Cursors.Hand
    End Sub

    Private Sub lblSupMarca_MouseLeave(sender As Object, e As EventArgs) Handles lblSupMarca.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub lblSupMarca_Click(sender As Object, e As EventArgs) Handles lblSupMarca.Click
        If Me.Owner.Name = frm_mant_articulos.Name Then
            frm_mant_articulos.txtIDMarca.Text = lblIDSupMarca.Text
            frm_mant_articulos.txtMarca.Text = lblSupMarca.Text
            Cursor = Cursors.Default
            Me.Close()
        End If


    End Sub
End Class