Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_orden_compra

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_orden_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDOrdenCompra,SecondID,Fecha,Suplidor,OrdenCompra.Referencia,Total FROM" & SysName.Text & "ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor where IDOrdenCompra like '%" + txtBuscar.Text + "%' AND OrdenCompra.Nulo=0 ORDER BY IDOrdenCompra DESC", ConMixta)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDOrdenCompra,SecondID,Fecha,Suplidor,OrdenCompra.Referencia,Total FROM" & SysName.Text & " ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor where OrdenCompra.Referencia like '%" + txtBuscar.Text + "%' AND OrdenCompra.Nulo=0 ORDER BY OrdenCompra.Referencia DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OrdenCompra")

            Bs.DataMember = "OrdenCompra"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvOrdenCompra.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvOrdenCompra
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(3).Width = 190
            .Columns(4).Width = 160
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReferencia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvOrdenCompra.Focus()
    End Sub

    Private Sub DgvOrdenCompra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvOrdenCompra.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvOrdenCompra.Focus()
        End If
    End Sub

    Private Sub DgvOrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvOrdenCompra.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvOrdenCompra.ColumnCount
                Dim NumRows As Integer = DgvOrdenCompra.RowCount
                Dim CurCell As DataGridViewCell = DgvOrdenCompra.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvOrdenCompra.CurrentCell = DgvOrdenCompra.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvOrdenCompra.CurrentCell = DgvOrdenCompra.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvOrdenCompra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOrdenCompra.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDOrdenCompra, Nulo As New Label
        IDOrdenCompra.Text = DgvOrdenCompra.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("Select IDOrdenCompra,OrdenCompra.SecondID,Fecha,Hora,IDUsuario,OrdenCompra.IDSuplidor,Suplidor,OrdenCompra.Referencia,Comentario,Total,OrdenCompra.Nulo,Suplidor.Balance,OrdenCompra.IDTipoOrden,Descripcion,OrdenCompra.IDAlmacen,Almacen.Almacen,TipoItbis,SubtotalOrden,ItbisOrden from" & SysName.Text & "OrdenCompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoOrdenCompra on OrdenCompra.IDTipoOrden=TipoOrdenCompra.IDTipoOrdenCompra INNER JOIN" & SysName.Text & "Almacen on OrdenCompra.IDAlmacen=Almacen.IDAlmacen Where IDOrdenCompra='" + IDOrdenCompra.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "OrdenCompra")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("OrdenCompra")

        If Tabla.Rows.Count > 0 Then
            If Me.Owner.Name = frm_orden_compras.Name Then
                frm_orden_compras.txtIDOrdenCompra.Text = (Tabla.Rows(0).Item("IDOrdenCompra"))
                frm_orden_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_orden_compras.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_orden_compras.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_orden_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_orden_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_orden_compras.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_orden_compras.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_orden_compras.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubtotalOrden")).ToString("C")
                frm_orden_compras.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisOrden")).ToString("C")
                frm_orden_compras.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
                frm_orden_compras.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
                frm_orden_compras.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_orden_compras.cbxStatusOrder.Tag = (Tabla.Rows(0).Item("IDTipoOrden"))
                frm_orden_compras.cbxStatusOrder.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_orden_compras.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

                If (Tabla.Rows(0).Item("TipoItbis")) = 1 Then
                    frm_orden_compras.rdbIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 2 Then
                    frm_orden_compras.rdbNoIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 3 Then
                    frm_orden_compras.rdbNoItbis.Checked = True
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_orden_compras.ChkNulo.Checked = False
                Else
                    frm_orden_compras.ChkNulo.Checked = True
                End If

                frm_orden_compras.RefrescarTablaArticulos()
            End If

            Close()
            Exit Sub
        End If

    End Sub
End Class