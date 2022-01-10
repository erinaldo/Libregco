Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_genero

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_genero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Genero where IDGenero like '%" + txtBuscar.Text + "%' ORDER BY IDGenero ASC", ConLibregco)
            ElseIf rdbGenero.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Genero where Genero like '%" + txtBuscar.Text + "%' ORDER BY Genero DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Genero")

            Bs.DataMember = "Genero"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGeneros.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()
        rdbGenero.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvGeneros
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 348
            .Columns(1).HeaderText = "Género"
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbGenero_CheckedChanged(sender As Object, e As EventArgs) Handles rdbGenero.CheckedChanged
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

    Private Sub DgvGenero_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGeneros.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGeneros.Focus()
    End Sub

    Private Sub DgvGeneros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGeneros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvGeneros.Focus()
        End If
    End Sub

    Private Sub DgvGeneros_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGeneros.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGeneros.ColumnCount
                Dim NumRows As Integer = DgvGeneros.RowCount
                Dim CurCell As DataGridViewCell = DgvGeneros.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGeneros.CurrentCell = DgvGeneros.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGeneros.CurrentCell = DgvGeneros.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_genero.Name Then
                frm_mant_genero.txtIDGenero.Text = DgvGeneros.CurrentRow.Cells(0).Value
                frm_mant_genero.txtGenero.Text = DgvGeneros.CurrentRow.Cells(1).Value

                If DgvGeneros.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_genero.chkNulo.Checked = False
                Else
                    frm_mant_genero.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDGenero.Text = DgvGeneros.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtGenero.Text = DgvGeneros.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDGenero.Text = DgvGeneros.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtGenero.Text = DgvGeneros.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

   

End Class