Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_relacion_familiar

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_relacion_familiar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT * FROM RelacionFamiliar where IDRelacionFamiliar like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY IDRelacionFamiliar ASC", ConLibregco)
            ElseIf rdbRelacion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM RelacionFamiliar where Relacion like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY Relacion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Relaciones")

            Bs.DataMember = "Relaciones"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvRelacion.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbRelacion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvRelacion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Relación"
            .Columns(1).Width = 288
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbRelacion_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()

        If rdbRelacion.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub DgvRelacion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRelacion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvRelacion.Focus()
    End Sub

    Private Sub DgvRelacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvRelacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvRelacion.Focus()
        End If
    End Sub

    Private Sub DgvRelacion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvRelacion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvRelacion.ColumnCount
                Dim NumRows As Integer = DgvRelacion.RowCount
                Dim CurCell As DataGridViewCell = DgvRelacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvRelacion.CurrentCell = DgvRelacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvRelacion.CurrentCell = DgvRelacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_relacion_familiar.Name Then

                frm_mant_relacion_familiar.txtIDRelacion.Text = DgvRelacion.CurrentRow.Cells(0).Value
                frm_mant_relacion_familiar.txtRelacion.Text = DgvRelacion.CurrentRow.Cells(1).Value
                If DgvRelacion.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_relacion_familiar.chkNulo.Checked = False
                Else
                    frm_mant_relacion_familiar.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_clientes_referecias.name Then
                frm_reporte_clientes_referecias.txtIDRelacion.Text = DgvRelacion.CurrentRow.Cells(0).Value
                frm_reporte_clientes_referecias.txtRelacion.Text = DgvRelacion.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub rdbRelacion_CheckedChanged_1(sender As Object, e As EventArgs) Handles rdbRelacion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub
End Class