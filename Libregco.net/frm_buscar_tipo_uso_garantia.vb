Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_uso_garantia

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_uso_garantia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM TipoUsoGarantia where IDTipoUsoGarantia like '%" + txtBuscar.Text + "%' ORDER BY IDTipoUsoGarantia DESC", ConLibregco)
            ElseIf rdbProvincia.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoUsoGarantia where TipoUsoGarantia like '%" + txtBuscar.Text + "%' ORDER BY TipoUsoGarantia ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoUsoGarantia")

            Bs.DataMember = "TipoUsoGarantia"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoUso.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbProvincia.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoUso
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(1).HeaderText = "Tipo de Uso"
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbProvincia.CheckedChanged
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

    Private Sub DgvTipoUso_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoUso.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoUso.Focus()
    End Sub

    Private Sub DgvTipoUso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoUso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoUso.Focus()
        End If
    End Sub

    Private Sub DgvTipoUso_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoUso.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoUso.ColumnCount
                Dim NumRows As Integer = DgvTipoUso.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoUso.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoUso.CurrentCell = DgvTipoUso.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoUso.CurrentCell = DgvTipoUso.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_introducir_seriales.Name Then
                frm_introducir_seriales.txtIDTipoUso.Text = DgvTipoUso.CurrentRow.Cells(0).Value
                frm_introducir_seriales.txtTipoUso.Text = DgvTipoUso.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class