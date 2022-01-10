Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_nacionalidad

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_nacionalidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM Nacionalidad where IDNacionalidad like '%" + txtBuscar.Text + "%' ORDER BY IDNacionalidad ASC", ConLibregco)
            ElseIf rdbNacionalidad.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Nacionalidad where Nacionalidad like '%" + txtBuscar.Text + "%' ORDER BY Nacionalidad ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nacionalidad")

            Bs.DataMember = "Nacionalidad"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvNacionalidad.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbNacionalidad.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvNacionalidad
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbNacionalidad_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNacionalidad.CheckedChanged
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

    Private Sub DgvNacionalidad_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNacionalidad.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvNacionalidad.Focus()
    End Sub

    Private Sub DgvNacionalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNacionalidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvNacionalidad.Focus()
        End If
    End Sub

    Private Sub DgvNacionalidad_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNacionalidad.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNacionalidad.ColumnCount
                Dim NumRows As Integer = DgvNacionalidad.RowCount
                Dim CurCell As DataGridViewCell = DgvNacionalidad.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNacionalidad.CurrentCell = DgvNacionalidad.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNacionalidad.CurrentCell = DgvNacionalidad.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_nacionalidades.Name Then
                frm_mant_nacionalidades.txtIDNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(0).Value
                frm_mant_nacionalidades.txtNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(1).Value
                frm_mant_nacionalidades.txtGentilicio.Text = DgvNacionalidad.CurrentRow.Cells(3).Value

                If DgvNacionalidad.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_nacionalidades.chkNulo.Checked = False
                Else
                    frm_mant_nacionalidades.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtNacionalidad.Text = DgvNacionalidad.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class