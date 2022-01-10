Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_ocupacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_ocupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM Ocupacion where IDOcupacion like '%" + txtBuscar.Text + "%' ORDER BY IDOcupacion ASC", ConLibregco)
            ElseIf rdbOcupacion.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM Ocupacion where Ocupacion like '%" + txtBuscar.Text + "%' ORDER BY Ocupacion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Ocupacion")

            Bs.DataMember = "Ocupacion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvOcupacion.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbOcupacion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvOcupacion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 117
            .Columns(1).Width = 370
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbOcupacion.CheckedChanged
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

    Private Sub DgvOcupaciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOcupacion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvOcupacion.Focus()
    End Sub

    Private Sub DgvOcupaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvOcupacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvOcupacion.Focus()
        End If
    End Sub

    Private Sub DgvOcupaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvOcupacion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvOcupacion.ColumnCount
                Dim NumRows As Integer = DgvOcupacion.RowCount
                Dim CurCell As DataGridViewCell = DgvOcupacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvOcupacion.CurrentCell = DgvOcupacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvOcupacion.CurrentCell = DgvOcupacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_ocupaciones.Name Then
                frm_mant_ocupaciones.txtIDOcupacion.Text = DgvOcupacion.CurrentRow.Cells(0).Value
                frm_mant_ocupaciones.txtOcupacion.Text = DgvOcupacion.CurrentRow.Cells(1).Value

                If DgvOcupacion.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_ocupaciones.chkNulo.Checked = False
                Else
                    frm_mant_ocupaciones.chkNulo.Checked = True
                End If
            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDOcupacion.Text = DgvOcupacion.CurrentRow.Cells(0).Value
                frm_reporte_clientes.txtOcupacion.Text = DgvOcupacion.CurrentRow.Cells(1).Value
                
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

   

End Class