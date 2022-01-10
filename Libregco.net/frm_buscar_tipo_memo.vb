Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_memo

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_buscar_tipo_memo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
   PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvTipoMemo.Columns(0).HeaderText = "Código"
        DgvTipoMemo.Columns(0).Width = 120

        DgvTipoMemo.Columns(1).Width = 395
        DgvTipoMemo.Columns(1).HeaderText = "Clase de Memo"

    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("Select * from TiposMemos where IDTiposMemos like '%" + txtBuscar.Text + "%' ORDER BY IDTiposMemos DESC", Con)
            ElseIf rdbClase.Checked = True Then
                cmd = New MySqlCommand("Select * from TiposMemos where Clase like '%" + txtBuscar.Text + "%' ORDER BY Clase ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TiposMemos")

            Bs.DataMember = "TiposMemos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoMemo.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbClase.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
     RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbClase_CheckedChanged(sender As Object, e As EventArgs) Handles rdbClase.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoMemo.Focus()
    End Sub

    Private Sub DgvTipoMemo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoMemo.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoMemo.ColumnCount
                Dim NumRows As Integer = DgvTipoMemo.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoMemo.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoMemo.CurrentCell = DgvTipoMemo.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoMemo.CurrentCell = DgvTipoMemo.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTipoMemo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoMemo.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim lblIDTipoMemo As New Label
        lblIDTipoMemo.Text = DgvTipoMemo.CurrentRow.Cells(0).Value

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select * from TiposMemos where IDTiposMemos='" + lblIDTipoMemo.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TiposMemos")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("TiposMemos")

        If Me.Owner.Name = frm_mant_memos_cliente.Name Then
            frm_mant_memos_cliente.txtIDTipoMemo.Text = (Tabla.Rows(0).Item("IDTiposMemos"))
            frm_mant_memos_cliente.txtTipoMemo.Text = (Tabla.Rows(0).Item("Clase"))

        ElseIf Me.Owner.Name = frm_consulta_memosclientes.Name Then
            frm_consulta_memosclientes.txtIDClasificacion.Text = (Tabla.Rows(0).Item("IDTiposMemos"))
            frm_consulta_memosclientes.txtClasificacion.Text = (Tabla.Rows(0).Item("Clase"))
        End If

        Close()
        Exit Sub
    End Sub
End Class