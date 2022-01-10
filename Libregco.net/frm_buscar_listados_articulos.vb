Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_listados_articulos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_listados_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDListaArticulos,SecondID,Fecha,Descripcion,Total FROM listasarticulos where IDListaArticulos like '%" + txtBuscar.Text + "%' AND Nulo=0 ORDER BY IDListaArticulos DESC", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDListaArticulos,SecondID,Fecha,Descripcion,Total FROM listasarticulos where Descripcion like '%" + txtBuscar.Text + "%'  AND Nulo=0 ORDER BY Descripcion ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ListadoArticulos")

            Bs.DataMember = "ListadoArticulos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvListados.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvListados
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 90
            .Columns(3).Width = 297
            .Columns(3).HeaderText = "Descripción"
            .Columns(4).Width = 130
            .Columns(4).DefaultCellStyle.Format = ("C")
        End With
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
        DgvListados.Focus()
    End Sub

    Private Sub DgvListados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvListados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvListados.Focus()
        End If
    End Sub

    Private Sub DgvListados_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvListados.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvListados.ColumnCount
                Dim NumRows As Integer = DgvListados.RowCount
                Dim CurCell As DataGridViewCell = DgvListados.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvListados.CurrentCell = DgvListados.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvListados.CurrentCell = DgvListados.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvListados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListados.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDListado, Nulo As New Label
        IDListado.Text = DgvListados.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select * from Listasarticulos Where IDListaArticulos= '" + IDListado.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Listasarticulos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Listasarticulos")

        If Me.Owner.Name = frm_listado_articulos.Name Then
            frm_listado_articulos.Hora.Enabled = False
            frm_listado_articulos.txtIDListado.Text = (Tabla.Rows(0).Item("IDListaArticulos"))
            frm_listado_articulos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_listado_articulos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_listado_articulos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_listado_articulos.lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
            frm_listado_articulos.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_listado_articulos.txtTotal.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            frm_listado_articulos.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_listado_articulos.ChkNulo.Checked = False
            Else
                frm_listado_articulos.ChkNulo.Checked = True
            End If

            frm_listado_articulos.RefrescarTablaArticulos()

        End If

        Close()
    End Sub
End Class