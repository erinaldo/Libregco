Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_grupo_cxc

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_grupo_cxc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDGrupoCxc,Descripcion,Nulo FROM Grupocxc where IDGrupocxc like '%" + txtBuscar.Text + "%' ORDER BY IDGrupocxc DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDGrupocxc,Descripcion,Nulo FROM Grupocxc where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Grupocxc")

            Bs.DataMember = "Grupocxc"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvGrupocxc.DataSource = Bs

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
        With DgvGrupocxc
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

    Private Sub DgvGrupocxc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGrupocxc.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvGrupocxc.Focus()
    End Sub

    Private Sub DgvGrupocxc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvGrupocxc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvGrupocxc.Focus()
        End If
    End Sub

    Private Sub DgvGrupocxc_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvGrupocxc.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvGrupocxc.ColumnCount
                Dim NumRows As Integer = DgvGrupocxc.RowCount
                Dim CurCell As DataGridViewCell = DgvGrupocxc.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvGrupocxc.CurrentCell = DgvGrupocxc.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvGrupocxc.CurrentCell = DgvGrupocxc.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_grupos_cxc.Name Then

                If DgvGrupocxc.CurrentRow.Cells(0).Value = 3 Then
                    frm_superclave.IDAccion.Text = 121
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                frm_mant_grupos_cxc.txtIDGrupoCxc.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_mant_grupos_cxc.txtDescripcion.Text = DgvGrupocxc.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_mant_clientes.Name Then

                If DgvGrupocxc.CurrentRow.Cells(0).Value = 3 Or DgvGrupocxc.CurrentRow.Cells(0).Value = 4 Then
                    frm_superclave.IDAccion.Text = 121
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                frm_mant_clientes.txtIDGrupoCxc.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_mant_clientes.txtGrupoCxc.Text = DgvGrupocxc.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_reporte_cotizacion.Name Then
                frm_reporte_cotizacion.txtIDGrupocxc.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_cotizacion.txtGrupocxc.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_registro_facturas.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nota_debito_credito_cxc.Name Then
                frm_reporte_nota_debito_credito_cxc.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_nota_debito_credito_cxc.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_cobros_facturas.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_cuentas_por_cobrar.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                frm_reporte_cheques_devueltos.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_cheques_devueltos.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                frm_reporte_cheques_futuros.txtIDGrupo.Text = DgvGrupocxc.CurrentRow.Cells(0).Value
                frm_reporte_cheques_futuros.txtGrupo.Text = DgvGrupocxc.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvGrupocxc.CurrentRow.Cells(2).Value = 0 Then
            frm_mant_grupos_cxc.chkNulo.Checked = False
        Else
            frm_mant_grupos_cxc.chkNulo.Checked = True
        End If
    End Sub
End Class