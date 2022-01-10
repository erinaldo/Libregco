Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_tarjeta

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_tarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM TarjetaTipo where IDTarjetaTipo like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY IDTarjetaTipo ASC", ConLibregco)
            ElseIf rdbTarjeta.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TarjetaTipo where Descripcion like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TarjetaTipo")

            Bs.DataMember = "TarjetaTipo"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoTarjetas.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbTarjeta.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoTarjetas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Tipo de Tarjeta"
            .Columns(1).Width = 300
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

    Private Sub DgvTipoPrestamo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoTarjetas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoTarjetas.Focus()
    End Sub

    Private Sub DgvTipoTarjetas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoTarjetas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoTarjetas.Focus()
        End If
    End Sub

    Private Sub DgvTipoTarjetas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoTarjetas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoTarjetas.ColumnCount
                Dim NumRows As Integer = DgvTipoTarjetas.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoTarjetas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoTarjetas.CurrentCell = DgvTipoTarjetas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoTarjetas.CurrentCell = DgvTipoTarjetas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            While frm_mant_tipo_tarjeta.Visible = True
                frm_mant_tipo_tarjeta.txtIDTipoTarjeta.Text = DgvTipoTarjetas.CurrentRow.Cells(0).Value
                frm_mant_tipo_tarjeta.txtTipoTarjeta.Text = DgvTipoTarjetas.CurrentRow.Cells(1).Value
                Close()
                Exit Sub
            End While

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If frm_mant_tipo_tarjeta.Visible = True Then
            If DgvTipoTarjetas.CurrentRow.Cells(2).Value = 0 Then
                frm_mant_tipo_tarjeta.chkNulo.Checked = False
            Else
                frm_mant_tipo_tarjeta.chkNulo.Checked = True
            End If
        End If
    End Sub

    Private Sub rdbTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTarjeta.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub
End Class