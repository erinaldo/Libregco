Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_plazos_contratos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_plazos_contratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDPlazoContrato,Plazo,Meses,Nulo FROM plazocontrato where IDPlazoContrato like '%" + txtBuscar.Text + "%' ORDER BY Meses ASC", ConLibregco)
            ElseIf rdbNoContrato.Checked = True Then
                cmd = New MySqlCommand("SELECT IDPlazoContrato,Plazo,Meses,Nulo FROM plazocontrato where Plazo like '%" + txtBuscar.Text + "%' ORDER BY Meses ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PlazoContratos")

            Bs.DataMember = "PlazoContratos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvContratos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarEmpresa()
  PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbNoContrato.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvContratos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 160
            .Columns(1).Width = 460
            .Columns(2).Visible = False
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbNacionalidad_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoContrato.CheckedChanged
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

    Private Sub DgvContratos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvContratos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvContratos.Focus()
    End Sub

    Private Sub DgvContratos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvContratos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvContratos.Focus()
        End If
    End Sub

    Private Sub DgvContratos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvContratos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvContratos.ColumnCount
                Dim NumRows As Integer = DgvContratos.RowCount
                Dim CurCell As DataGridViewCell = DgvContratos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvContratos.CurrentCell = DgvContratos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvContratos.CurrentCell = DgvContratos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_plazo_contratos.Name Then
                frm_mant_plazo_contratos.txtIDPlazo.Text = DgvContratos.CurrentRow.Cells(0).Value
                frm_mant_plazo_contratos.txtPlazo.Text = DgvContratos.CurrentRow.Cells(1).Value
                frm_mant_plazo_contratos.txtMeses.Text = DgvContratos.CurrentRow.Cells(2).Value

                If DgvContratos.CurrentRow.Cells(3).Value = 0 Then
                    frm_mant_plazo_contratos.chkNulo.Checked = False
                Else
                    frm_mant_plazo_contratos.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_contratos_clientes.Name Then
                frm_contratos_clientes.txtIDPlazo.Text = DgvContratos.CurrentRow.Cells(0).Value
                frm_contratos_clientes.txtPlazo.Text = DgvContratos.CurrentRow.Cells(1).Value
                frm_contratos_clientes.dtpVencimiento.Value = CDate(frm_contratos_clientes.txtFecha.Text).AddMonths(DgvContratos.CurrentRow.Cells(2).Value)
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class