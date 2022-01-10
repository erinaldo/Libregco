Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_ajustes_inventario
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_ajustes_inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarCmd()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarCmd()
        If Me.Owner.Name = frm_ajuste_inventario.Name Then
            cmd = New MySqlCommand("Select MovimientoInventario.IDAjusteInventario,MovimientoInventario.SecondID,Fecha,Almacen,Referencia from" & SysName.Text & "movimientoinventario INNER JOIN" & SysName.Text & "almacen on movimientoinventario.IDAlmacen=Almacen.IDAlmacen WHERE MovimientoInventario.Nulo=0 ORDER BY IDAjusteInventario ASC", ConMixta)
        ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
            cmd = New MySqlCommand("Select MovimientoInventario.IDAjusteInventario,MovimientoInventario.SecondID,Fecha,Almacen,Referencia from" & SysName.Text & "movimientoinventario INNER JOIN" & SysName.Text & "almacen on movimientoinventario.IDAlmacen=Almacen.IDAlmacen WHERE MovimientoInventario.Nulo=0 ORDER BY IDAjusteInventario ASC", ConMixta)
        End If
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If Me.Owner.Name = frm_ajuste_inventario.Name Then
                cmd = New MySqlCommand("Select MovimientoInventario.IDAjusteInventario,MovimientoInventario.SecondID,Fecha,Almacen,Referencia,Total from" & SysName.Text & "movimientoinventario INNER JOIN" & SysName.Text & "almacen on movimientoinventario.IDAlmacen=Almacen.IDAlmacen where MovimientoInventario.IDAjusteInventario like '%" + txtBuscar.Text + "%' and MovimientoInventario.Nulo=0 ORDER BY IDAjusteInventario DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "AjustesInventario")
            Bs.DataMember = "AjustesInventario"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvAjustesInventario.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvAjustesInventario
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(3).Width = 100
            .Columns(3).HeaderText = "Almacén"
            .Columns(4).Width = 240
            .Columns(4).HeaderText = "Referencia"
            .Columns(5).HeaderText = "Total"
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Format = "C"
        End With
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvAjustesInventario.Focus()
    End Sub

    Private Sub DgvAjustesInventario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvAjustesInventario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvAjustesInventario.Focus()
        End If
    End Sub

    Private Sub DgvAjustesInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvAjustesInventario.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvAjustesInventario.ColumnCount
                Dim NumRows As Integer = DgvAjustesInventario.RowCount
                Dim CurCell As DataGridViewCell = DgvAjustesInventario.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvAjustesInventario.CurrentCell = DgvAjustesInventario.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvAjustesInventario.CurrentCell = DgvAjustesInventario.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvAjustesInventario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAjustesInventario.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDAjusteInventario, Nulo As New Label
        IDAjusteInventario.Text = DgvAjustesInventario.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("Select MovimientoInventario.IDAjusteInventario,SecondID,Fecha,Hora,MovimientoInventario.IDAlmacen,Almacen.Almacen,Referencia,Comentario,Total,MovimientoInventario.Nulo from" & SysName.Text & "MovimientoInventario INNER JOIN" & SysName.Text & "Almacen on MovimientoInventario.IDAlmacen=Almacen.IDAlmacen Where MovimientoInventario.IDAjusteInventario='" + IDAjusteInventario.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "MovimientoInventario")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("MovimientoInventario")

        If Me.Owner.Name = frm_inv_inicial.Name Then
            frm_inv_inicial.txtIDAjuste.Text = (Tabla.Rows(0).Item("IDAjusteInventario"))
            frm_inv_inicial.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_inv_inicial.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_inv_inicial.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_inv_inicial.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            frm_inv_inicial.lblIDAlmacen.Text = (Tabla.Rows(0).Item("IDAlmacen"))
            frm_inv_inicial.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_ajuste_inventario.ChkNulo.Checked = False
            Else
                frm_ajuste_inventario.ChkNulo.Checked = True
            End If
            frm_inv_inicial.RefrescarTablaArticulos()

        ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
            frm_ajuste_inventario.txtIDAjuste.Text = (Tabla.Rows(0).Item("IDAjusteInventario"))
            frm_ajuste_inventario.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_ajuste_inventario.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_ajuste_inventario.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_ajuste_inventario.CbxAlmacen.Tag = (Tabla.Rows(0).Item("IDAlmacen"))
            frm_ajuste_inventario.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_ajuste_inventario.ChkNulo.Checked = False
            Else
                frm_ajuste_inventario.ChkNulo.Checked = True
            End If

            frm_ajuste_inventario.ShowSavedRows()
        End If

        Close()
        Exit Sub
    End Sub

  
End Class