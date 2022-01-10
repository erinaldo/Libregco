Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tandas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tandas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * from Tandas Where IDTanda like '%" + txtBuscar.Text + "%' ORDER BY IDTanda ASC", ConLibregco)

            ElseIf rdbTanda.Checked = True Then
                cmd = New MySqlCommand("SELECT * from Tandas Where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)

            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Tandas")

            Bs.DataMember = "Tandas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTandas.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try

    End Sub

    Sub LimpiartxtBuscar()
        rdbTanda.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTandas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 110
            .Columns(1).HeaderText = "Tandas"
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

    Private Sub rdbTanda_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()

        If rdbTanda.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub DgvTandas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTandas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTandas.Focus()
    End Sub

    Private Sub DgvTandas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTandas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTandas.Focus()
        End If
    End Sub

    Private Sub DgvTandas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTandas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTandas.ColumnCount
                Dim NumRows As Integer = DgvTandas.RowCount
                Dim CurCell As DataGridViewCell = DgvTandas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTandas.CurrentCell = DgvTandas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTandas.CurrentCell = DgvTandas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDTanda.Text = DgvTandas.CurrentRow.Cells(0).Value
                frm_mant_empleados.txtTanda.Text = DgvTandas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_tandas.Name Then

                frm_mant_tandas.txtIDTanda.Text = DgvTandas.CurrentRow.Cells(0).Value
                frm_mant_tandas.txtDescripcion.Text = DgvTandas.CurrentRow.Cells(1).Value
                frm_mant_tandas.FillTandasDetalle()
                FillChkBox()

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDTanda.Text = DgvTandas.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtTanda.Text = DgvTandas.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvTandas.CurrentRow.Cells(2).Value = 0 Then
            frm_mant_tandas.chkNulo.Checked = False
        Else
            frm_mant_tandas.chkNulo.Checked = True
        End If
    End Sub

    Private Sub rdbTanda_CheckedChanged_1(sender As Object, e As EventArgs) Handles rdbTanda.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub
End Class