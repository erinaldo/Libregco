Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_calificacion
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_calificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM Calificacion where IDCalificacion like '%" + txtBuscar.Text + "%' ORDER BY IDCalificacion DESC", ConLibregco)
            ElseIf rdbCalificacion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Calificacion where Calificacion like '%" + txtBuscar.Text + "%' ORDER BY Calificacion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Calificacion")

            Bs.DataMember = "Calificacion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCalificacion.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbCalificacion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvCalificacion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbCalificacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCalificacion.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvCalificacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCalificacion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCalificacion.Focus()
    End Sub

    Private Sub DgvCalificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCalificacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCalificacion.Focus()
        End If
    End Sub

    Private Sub DgvCalificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCalificacion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCalificacion.ColumnCount
                Dim NumRows As Integer = DgvCalificacion.RowCount
                Dim CurCell As DataGridViewCell = DgvCalificacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCalificacion.CurrentCell = DgvCalificacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCalificacion.CurrentCell = DgvCalificacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_calificacion.Name Then
                frm_mant_calificacion.txtIDCalificacion.Text = DgvCalificacion.CurrentRow.Cells(0).Value
                frm_mant_calificacion.txtCalificacion.Text = DgvCalificacion.CurrentRow.Cells(1).Value
                frm_mant_calificacion.ColorCalificacion.BackColor = Color.FromArgb(DgvCalificacion.CurrentRow.Cells(2).Value)

                If DgvCalificacion.CurrentRow.Cells(3).Value = 0 Then
                    frm_mant_calificacion.chkNulo.Checked = False
                Else
                    frm_mant_calificacion.chkNulo.Checked = True
                End If
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class