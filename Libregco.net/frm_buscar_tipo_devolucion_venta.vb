Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_devolucion_venta

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Private Sub frm_buscar_tipo_devolucion_venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvTipoDevolucion.Columns(0).HeaderText = "Código"
        DgvTipoDevolucion.Columns(0).Width = 120
        DgvTipoDevolucion.Columns(1).Width = 395
        DgvTipoDevolucion.Columns(1).HeaderText = "Descripción"

    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM tipodevolucion where IDTipoDevolucion like '%" + txtBuscar.Text + "%' ORDER BY IDTipoDevolucion DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM tipodevolucion where Tipo like '%" + txtBuscar.Text + "%' ORDER BY Tipo ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoDevolucion")

            Bs.DataMember = "TipoDevolucion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoDevolucion.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoDevolucion.Focus()
    End Sub

    Private Sub DgvTipoDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoDevolucion.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoDevolucion.ColumnCount
                Dim NumRows As Integer = DgvTipoDevolucion.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoDevolucion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoDevolucion.CurrentCell = DgvTipoDevolucion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoDevolucion.CurrentCell = DgvTipoDevolucion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTipoDevolucion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoDevolucion.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim lblIDTipoDevolucion As New Label
        lblIDTipoDevolucion.Text = DgvTipoDevolucion.CurrentRow.Cells(0).Value

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM tipodevolucion where IDTipoDevolucion='" + lblIDTipoDevolucion.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TiposDevolucion")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("TiposDevolucion")

        If Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
            frm_reporte_devolucion_ventas.txtIDTipoDevolucion.Text = (Tabla.Rows(0).Item("IDTipoDevolucion"))
            frm_reporte_devolucion_ventas.txtTipoDevolucion.Text = (Tabla.Rows(0).Item("Tipo"))

        ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
            frm_reporte_nota_debito_credito_cxc.txtIDTipoNota.Text = (Tabla.Rows(0).Item("IDTipoDevolucion"))
            frm_reporte_nota_debito_credito_cxc.txtTipoNota.Text = (Tabla.Rows(0).Item("Tipo"))
        End If

        Close()
        Exit Sub
    End Sub
End Class