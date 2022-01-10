Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_ars
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_ars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDArs,Descripcion,Direccion,Telefono,Nulo from ARS Where IDArs like '%" + txtBuscar.Text + "%' ORDER BY IDArs DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDArs,Descripcion,Direccion,Telefono,Nulo from ARS Where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Ars")

            Bs.DataMember = "Ars"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvArs.DataSource = Bs

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
        With DgvArs
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 340
            .Columns(2).Visible = False
            .Columns(3).HeaderText = "Teléfono"
            .Columns(3).Width = 100
            .Columns(4).Visible = False
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

    Private Sub DgvArs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArs.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvArs.Focus()
    End Sub

    Private Sub DgvArs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvArs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvArs.Focus()
        End If
    End Sub

    Private Sub DgvArs_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvArs.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvArs.ColumnCount
                Dim NumRows As Integer = DgvArs.RowCount
                Dim CurCell As DataGridViewCell = DgvArs.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvArs.CurrentCell = DgvArs.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvArs.CurrentCell = DgvArs.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_ARS.Name Then
                frm_mant_ARS.txtIDArs.Text = DgvArs.CurrentRow.Cells(0).Value
                frm_mant_ARS.txtArs.Text = DgvArs.CurrentRow.Cells(1).Value
                frm_mant_ARS.txtDireccion.Text = DgvArs.CurrentRow.Cells(2).Value
                frm_mant_ARS.txtTelefono.Text = DgvArs.CurrentRow.Cells(3).Value
                FillChkBox()
                
            ElseIf Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDArs.Text = DgvArs.CurrentRow.Cells(0).Value
                frm_mant_empleados.txtArs.Text = DgvArs.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDARS.Text = DgvArs.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtARS.Text = DgvArs.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvArs.CurrentRow.Cells(4).Value = 0 Then
            frm_mant_ARS.chkNulo.Checked = False
        Else
            frm_mant_ARS.chkNulo.Checked = True
        End If
    End Sub

End Class