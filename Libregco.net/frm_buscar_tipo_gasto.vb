Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_gasto

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_gasto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT * from TipoGasto Where IDGasto like '%" + txtBuscar.Text + "%' ORDER BY IDGasto DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * from TipoGasto Where TipoGasto like '%" + txtBuscar.Text + "%' ORDER BY TipoGasto ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoGasto")

            Bs.DataMember = "TipoGasto"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGasto.DataSource = Bs

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
        With DgvGasto
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).HeaderText = "Tipo de Gasto"
            .Columns(1).Width = 350
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbCategoria_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub DgvGasto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGasto.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGasto.Focus()
    End Sub

    Private Sub DgvGasto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGasto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvGasto.Focus()
        End If
    End Sub

    Private Sub DgvGasto_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGasto.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGasto.ColumnCount
                Dim NumRows As Integer = DgvGasto.RowCount
                Dim CurCell As DataGridViewCell = DgvGasto.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGasto.CurrentCell = DgvGasto.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGasto.CurrentCell = DgvGasto.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_tipo_gasto.Name Then
                frm_mant_tipo_gasto.txtIDTipoGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_mant_tipo_gasto.txtGasto.Text = DgvGasto.CurrentRow.Cells(1).Value

                If DgvGasto.CurrentRow.Cells(2).Value = 1 Then
                    frm_mant_tipo_gasto.chkNulo.Checked = True
                Else
                    frm_mant_tipo_gasto.chkNulo.Checked = False
                End If

            ElseIf Me.Owner.Name = frm_mant_suplidor.Name Then
                frm_mant_suplidor.txtIDTipoGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_mant_suplidor.txtTipoGasto.Text = DgvGasto.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_compras.Name Then
                frm_reporte_compras.txtIDGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_reporte_compras.txtGasto.Text = DgvGasto.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_reporte_suplidor.txtGasto.Text = DgvGasto.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas_cxp.txtGasto.Text = DgvGasto.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDGasto.Text = DgvGasto.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_pagar.txtGasto.Text = DgvGasto.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class