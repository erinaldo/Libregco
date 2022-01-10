Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_transferencia_art

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_transferencia_art_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDTransferenciaArt,Fecha,IDAlmacenSalida,AlmacenSalida.Almacen as AlmacenSalida,IDAlmacenEntrada,AlmacenEntrada.Almacen as AlmacenEntrada,Total FROM transfenciaarticulos INNER JOIN Almacen as AlmacenSalida on transfenciaarticulos.IDAlmacenSalida=AlmacenSalida.IDAlmacen INNER JOIN Almacen as AlmacenEntrada on transfenciaarticulos.IDAlmacenEntrada=AlmacenEntrada.IDAlmacen where IDTransferenciaArt like '%" + txtBuscar.Text + "%' and transfenciaarticulos.Nulo=0 ORDER BY IDTransferenciaArt ASC", Con)
            ElseIf rdbSalida.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTransferenciaArt,Fecha,IDAlmacenSalida,AlmacenSalida.Almacen as AlmacenSalida,IDAlmacenEntrada,AlmacenEntrada.Almacen as AlmacenEntrada,Total FROM transfenciaarticulos INNER JOIN Almacen as AlmacenSalida on transfenciaarticulos.IDAlmacenSalida=AlmacenSalida.IDAlmacen INNER JOIN Almacen as AlmacenEntrada on transfenciaarticulos.IDAlmacenEntrada=AlmacenEntrada.IDAlmacen where AlmacenSalida.Almacen like '%" + txtBuscar.Text + "%' and transfenciaarticulos.Nulo=0 ORDER BY IDTransferenciaArt ASC", Con)
            ElseIf rdbEntrada.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTransferenciaArt,Fecha,IDAlmacenSalida,AlmacenSalida.Almacen as AlmacenSalida,IDAlmacenEntrada,AlmacenEntrada.Almacen as AlmacenEntrada,Total FROM transfenciaarticulos INNER JOIN Almacen as AlmacenSalida on transfenciaarticulos.IDAlmacenSalida=AlmacenSalida.IDAlmacen INNER JOIN Almacen as AlmacenEntrada on transfenciaarticulos.IDAlmacenEntrada=AlmacenEntrada.IDAlmacen where AlmacenEntrada.Almacen like '%" + txtBuscar.Text + "%' and transfenciaarticulos.Nulo=0 ORDER BY IDTransferenciaArt ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TransferenciaArt")

            Bs.DataMember = "TransferenciaArt"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTransferenciaInventario.DataSource = Bs

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
        With DgvTransferenciaInventario
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).Width = 80
            .Columns(2).Visible = False
            .Columns(3).Width = 150
            .Columns(3).HeaderText = "Salida"
            .Columns(4).Visible = False
            .Columns(5).Width = 150
            .Columns(5).HeaderText = "Entrada"
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 150
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEntrada.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbSalida_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSalida.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTransferenciaInventario.Focus()
    End Sub

    Private Sub DgvTransferenciaInventario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTransferenciaInventario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvTransferenciaInventario.Focus()
        End If
    End Sub

    Private Sub dgvTransferenciaInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTransferenciaInventario.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTransferenciaInventario.ColumnCount
                Dim NumRows As Integer = DgvTransferenciaInventario.RowCount
                Dim CurCell As DataGridViewCell = DgvTransferenciaInventario.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTransferenciaInventario.CurrentCell = DgvTransferenciaInventario.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTransferenciaInventario.CurrentCell = DgvTransferenciaInventario.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTransferenciaInventario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTransferenciaInventario.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDTransferenciaArt, Nulo As New Label
        IDTransferenciaArt.Text = DgvTransferenciaInventario.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select IDTransferenciaArt,IDTipoDocumento,TransfenciaArticulos.IDSucursal,Sucursal.Sucursal,TransfenciaArticulos.IDAlmacen,Almacen.Almacen as AlmacenRealizado,IDAlmacenEntrada,AlmacenEntrada.Almacen as AlmacenEntrada,IDAlmacenSalida,AlmacenSalida.Almacen as AlmacenSalida,SecondID,Fecha,Hora,IDUsuario,Referencia,Comentario,Total,Impreso,TransfenciaArticulos.Nulo from transfenciaarticulos INNER JOIN Sucursal on TransfenciaArticulos.IDSucursal=Sucursal.IDSucursal INNER JOIN Almacen on TransfenciaArticulos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Almacen as AlmacenEntrada on TransfenciaArticulos.IDAlmacenEntrada=AlmacenEntrada.IDAlmacen INNER JOIN Almacen as AlmacenSalida on TransfenciaArticulos.IDAlmacenSalida=AlmacenSalida.IDAlmacen Where IDTransferenciaArt='" + IDTransferenciaArt.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "transfenciaarticulos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("transfenciaarticulos")

        If Me.Owner.Name = frm_transferencia_arts.Name Then
            frm_transferencia_arts.txtIDTransferenciaArt.Text = (Tabla.Rows(0).Item("IDTransferenciaArt"))
            frm_transferencia_arts.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_transferencia_arts.cbxAlmacen.Text = (Tabla.Rows(0).Item("AlmacenRealizado"))
            frm_transferencia_arts.cbxAlmacenEntrada.Text = (Tabla.Rows(0).Item("AlmacenEntrada"))
            frm_transferencia_arts.CbxAlmacenSalida.Text = (Tabla.Rows(0).Item("AlmacenSalida"))
            frm_transferencia_arts.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_transferencia_arts.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_transferencia_arts.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            frm_transferencia_arts.RefrescarTablaArticulos()
        End If
        Close()
        Exit Sub
    End Sub
End Class