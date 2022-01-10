Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_estado_civil

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_estado_civil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM EstadoCivil where IDCivil like '%" + txtBuscar.Text + "%' ORDER BY IDCivil ASC", ConLibregco)
            ElseIf rdbEstadoCivil.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM EstadoCivil where EstadoCivil like '%" + txtBuscar.Text + "%' ORDER BY EstadoCivil DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EstadoCivil")

            Bs.DataMember = "EstadoCivil"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvEstadoCivil.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()
        rdbEstadoCivil.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvEstadoCivil
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 348
            .Columns(1).HeaderText = "Estado Civil"
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbEstadoCivil_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEstadoCivil.CheckedChanged
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

    Private Sub DgvEstadoCivil_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEstadoCivil.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEstadoCivil.Focus()
    End Sub

    Private Sub DgvEstadoCivil_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEstadoCivil.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEstadoCivil.Focus()
        End If
    End Sub

    Private Sub DgvEstadoCivil_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEstadoCivil.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEstadoCivil.ColumnCount
                Dim NumRows As Integer = DgvEstadoCivil.RowCount
                Dim CurCell As DataGridViewCell = DgvEstadoCivil.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEstadoCivil.CurrentCell = DgvEstadoCivil.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEstadoCivil.CurrentCell = DgvEstadoCivil.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_estado_civil.Name Then
                frm_mant_estado_civil.txtIDEstadoCivil.Text = DgvEstadoCivil.CurrentRow.Cells(0).Value
                frm_mant_estado_civil.txtEstadoCivil.Text = DgvEstadoCivil.CurrentRow.Cells(1).Value

                If DgvEstadoCivil.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_estado_civil.chkNulo.Checked = False
                Else
                    frm_mant_estado_civil.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDEstadoCivil.Text = DgvEstadoCivil.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtEstadoCivil.Text = DgvEstadoCivil.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class