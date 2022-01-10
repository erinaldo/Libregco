Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_credito

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
          'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDTipoCredito,Descripcion,Nulo FROM TipoCredito where IDTipoCredito like '%" + txtBuscar.Text + "%' ORDER BY IDTipoCredito DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDTipoCredito,Descripcion,Nulo FROM TipoCredito where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoCredito")

            Bs.DataMember = "TipoCredito"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoCredito.DataSource = Bs

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
        With DgvTipoCredito
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Descripción"
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

    Private Sub DgvTipoCredito_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoCredito.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoCredito.Focus()
    End Sub

    Private Sub DgvTipoCredito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoCredito.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoCredito.Focus()
        End If
    End Sub

    Private Sub DgvTipoCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoCredito.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoCredito.ColumnCount
                Dim NumRows As Integer = DgvTipoCredito.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoCredito.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoCredito.CurrentCell = DgvTipoCredito.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoCredito.CurrentCell = DgvTipoCredito.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_tipo_credito.Name Then
                frm_mant_tipo_credito.txtIDTipoCredito.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_mant_tipo_credito.txtDescripcion.Text = DgvTipoCredito.CurrentRow.Cells(1).Value
                If DgvTipoCredito.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_tipo_credito.chkNulo.Checked = False
                Else
                    frm_mant_tipo_credito.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_mant_clientes.Name Then
                frm_mant_clientes.txtIDTipoCredito.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_mant_clientes.txtTipoCredito.Text = DgvTipoCredito.CurrentRow.Cells(1).Value
               
            ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
                frm_reporte_cotizacion.txtIDTipoCredito.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_cotizacion.txtTipoCredito.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_nota_debito_credito_cxc.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_cobros_facturas.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_cobrar.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                frm_reporte_cheques_devueltos.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_cheques_devueltos.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                frm_reporte_cheques_futuros.txtIDTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(0).Value
                frm_reporte_cheques_futuros.txtTipoCliente.Text = DgvTipoCredito.CurrentRow.Cells(1).Value


            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class