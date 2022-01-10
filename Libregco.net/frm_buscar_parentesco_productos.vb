Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_parentesco_productos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_parentesco_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM ParentescoProducto where IDParentesco like '%" + txtBuscar.Text + "%' ORDER BY IDParentesco DESC", ConLibregco)
            ElseIf rdbParentesco.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM ParentescoProducto where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ParentescoProducto")

            Bs.DataMember = "ParentescoProducto"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvParentesco.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbParentesco.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvParentesco
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbParentesco.CheckedChanged
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

    Private Sub DgvProvincias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvParentesco.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvParentesco.Focus()
    End Sub

    Private Sub DgvProvincias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvParentesco.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvParentesco.Focus()
        End If
    End Sub

    Private Sub DgvProvincias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvParentesco.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvParentesco.ColumnCount
                Dim NumRows As Integer = DgvParentesco.RowCount
                Dim CurCell As DataGridViewCell = DgvParentesco.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvParentesco.CurrentCell = DgvParentesco.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvParentesco.CurrentCell = DgvParentesco.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_articulos.Name Then
                frm_mant_articulos.txtIDParentesco.Text = DgvParentesco.CurrentRow.Cells(0).Value
                frm_mant_articulos.txtParentesco.Text = DgvParentesco.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                frm_reporte_productos.txtIDParental.Text = DgvParentesco.CurrentRow.Cells(0).Value
                frm_reporte_productos.txtParentezco.Text = DgvParentesco.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.name Then
                frm_actualizar_precios_costos.txtIDParental.Text = DgvParentesco.CurrentRow.Cells(0).Value
                frm_actualizar_precios_costos.txtParentezco.Text = DgvParentesco.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.name Then
                frm_actualizar_propiedades_articulos.txtIDParental.Text = DgvParentesco.CurrentRow.Cells(0).Value
                frm_actualizar_propiedades_articulos.txtParentezco.Text = DgvParentesco.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_ajuste_inventario.name Then
                frm_ajuste_inventario.txtIDParental.Text = DgvParentesco.CurrentRow.Cells(0).Value
                frm_ajuste_inventario.txtParentezco.Text = DgvParentesco.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class