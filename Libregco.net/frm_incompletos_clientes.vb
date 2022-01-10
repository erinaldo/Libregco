Public Class frm_incompletos_clientes

    Private Sub frm_incompletos_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        'Me.WindowState = CheckWindowState()
        DgvIncompletos.ClearSelection()
    End Sub

    Private Sub frm_incompletos_clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DgvIncompletos.Rows.Count = 0 Then
            ControlSuperClave = 0
        Else
            ControlSuperClave = 1
        End If
    End Sub

    Private Sub DgvIncompletos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvIncompletos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 3 Then
                DgvIncompletos.Rows.Remove(DgvIncompletos.Rows(e.RowIndex))

            ElseIf e.ColumnIndex = 4 Then
                If DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 1 Then
                    frm_mant_clientes.Panel8.BackColor = SystemColors.ActiveBorder
                    frm_mant_clientes.tbcClientes.SelectedIndex = 0

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 2 Then
                    frm_mant_clientes.Panel2.BackColor = SystemColors.ActiveBorder
                    frm_mant_clientes.tbcClientes.SelectedIndex = 2

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 3 Then
                    frm_mant_clientes.Panel1.BackColor = SystemColors.ActiveBorder
                    frm_mant_clientes.tbcClientes.SelectedIndex = 2

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 4 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 2
                    frm_mant_clientes.txtLugarTrabajo.Focus()

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 5 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 2
                    frm_mant_clientes.txtOcupacionAutoEmpleado.Focus()

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 6 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 2
                    frm_mant_clientes.txtOrigenPagos.Focus()

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 7 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 4
                    frm_mant_clientes.txtReferenciaComercial1.Focus()

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 8 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 4
                    frm_mant_clientes.txtNombreGarante.Focus()

                ElseIf DgvIncompletos.Rows(e.RowIndex).Cells(0).Value = 9 Then
                    frm_mant_clientes.tbcClientes.SelectedIndex = 4
                    frm_mant_clientes.OpenMantRef_btn.Focus()
                End If

                ControlSuperClave = 0
                Close()

            End If
        End If

    End Sub

    Private Sub DgvIncompletos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgvIncompletos.RowsRemoved
        If DgvIncompletos.Rows.Count = 0 Then
            ControlSuperClave = 0
            Close()
        End If
    End Sub
End Class