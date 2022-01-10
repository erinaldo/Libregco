Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_periodopago
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Private Sub frm_busca_periodopago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDPeriodoPago,Descripcion FROM libregco.periodopago where IDPeriodoPago like '%" + txtBuscar.Text + "%' ORDER BY IDPeriodoPago ASC", ConLibregco)
            ElseIf rdbGenero.Checked = True Then
                cmd = New MySqlCommand("SELECT IDPeriodoPago,Descripcion FROM libregco.periodopago where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipofinanciamiento")

            Bs.DataMember = "tipofinanciamiento"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPeriodoPago.DataSource = Bs

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
        With DgvPeriodoPago
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 110
            .Columns(1).Width = 348
            .Columns(1).HeaderText = "Períodos"
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

    Private Sub DgvGenero_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPeriodoPago.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPeriodoPago.Focus()
    End Sub

    Private Sub DgvPeriodoPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPeriodoPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvPeriodoPago.Focus()
        End If
    End Sub

    Private Sub DgvPeriodoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPeriodoPago.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPeriodoPago.ColumnCount
                Dim NumRows As Integer = DgvPeriodoPago.RowCount
                Dim CurCell As DataGridViewCell = DgvPeriodoPago.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPeriodoPago.CurrentCell = DgvPeriodoPago.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPeriodoPago.CurrentCell = DgvPeriodoPago.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_reporte_financiamientos.Name Then
                frm_reporte_financiamientos.txtIDFormaPago.Text = DgvPeriodoPago.CurrentRow.Cells(0).Value
                frm_reporte_financiamientos.txtFormaPago.Text = DgvPeriodoPago.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuotas_financiamientos.Name Then
                frm_reporte_cuotas_financiamientos.txtIDFormaPago.Text = DgvPeriodoPago.CurrentRow.Cells(0).Value
                frm_reporte_cuotas_financiamientos.txtFormaPago.Text = DgvPeriodoPago.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class