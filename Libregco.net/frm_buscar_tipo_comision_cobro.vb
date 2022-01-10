Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_tipo_comision_cobro

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_comision_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM comisioncobro Where IDComisionCobro like '%" + txtBuscar.Text + "%' ORDER BY IDComisionCobro DESC", Con)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM comisioncobro Where Comision like '%" + txtBuscar.Text + "%' ORDER BY Comision ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Comision")

            Bs.DataMember = "Comision"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvComision.DataSource = Bs

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
        With DgvComision
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 300
            .Columns(2).HeaderText = "Porcentaje"
            .Columns(2).DefaultCellStyle.Format = "P"
            .Columns(2).Width = 100
            .Columns(3).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvComision_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvComision.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvComision.Focus()
    End Sub

    Private Sub DgvComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvComision.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvComision.Focus()
        End If
    End Sub

    Private Sub DgvComision_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvComision.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvComision.ColumnCount
                Dim NumRows As Integer = DgvComision.RowCount
                Dim CurCell As DataGridViewCell = DgvComision.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvComision.CurrentCell = DgvComision.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvComision.CurrentCell = DgvComision.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_comision_cobros.Name Then
                frm_mant_comision_cobros.txtIDComision.Text = DgvComision.CurrentRow.Cells(0).Value
                frm_mant_comision_cobros.txtDescripcion.Text = DgvComision.CurrentRow.Cells(1).Value
                frm_mant_comision_cobros.txtComision.Text = CDbl(DgvComision.CurrentRow.Cells(2).Value).ToString("P")
                If DgvComision.CurrentRow.Cells(3).Value = 0 Then
                    frm_mant_comision_cobros.chkNulo.Checked = False
                Else
                    frm_mant_comision_cobros.chkNulo.Checked = True
                End If

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        
    End Sub
End Class