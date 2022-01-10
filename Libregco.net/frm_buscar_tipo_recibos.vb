Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM tiporecibos where IDTipoRecibo like '%" + txtBuscar.Text + "%' ORDER BY IDTipoRecibo ASC", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM tiporecibos where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tiporecibos")

            Bs.DataMember = "tiporecibos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoRecibos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoRecibos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Descripción"
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

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvTipoRecibos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoRecibos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoRecibos.Focus()
    End Sub

    Private Sub DgvTipoRecibos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoRecibos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoRecibos.Focus()
        End If
    End Sub

    Private Sub DgvTipoRecibos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoRecibos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoRecibos.ColumnCount
                Dim NumRows As Integer = DgvTipoRecibos.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoRecibos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoRecibos.CurrentCell = DgvTipoRecibos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoRecibos.CurrentCell = DgvTipoRecibos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_tipo_recibos.Name Then
                frm_mant_tipo_recibos.txtIDTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(0).Value
                frm_mant_tipo_recibos.txtTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(1).Value
                If DgvTipoRecibos.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_tipo_recibos.chkNulo.Checked = False
                Else
                    frm_mant_tipo_recibos.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
                frm_reporte_recibos_cobros.txtIDTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(0).Value
                frm_reporte_recibos_cobros.txtTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_consulta_recibos_cobros.Name Then
                frm_consulta_recibos_cobros.txtIDTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(0).Value
                frm_consulta_recibos_cobros.txtTipoRecibo.Text = DgvTipoRecibos.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class