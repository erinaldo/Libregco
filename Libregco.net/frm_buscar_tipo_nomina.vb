Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_nomina

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_nomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * from TipoNomina Where IDTipoNomina like '%" + txtBuscar.Text + "%' ORDER BY IDTipoNomina ASC", ConLibregco)
            ElseIf rdbNomina.Checked = True Then
                cmd = New MySqlCommand("SELECT * from TipoNomina Where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoNomina")

            Bs.DataMember = "TipoNomina"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvNominas.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub
    Sub LimpiartxtBuscar()

        rdbNomina.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvNominas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 110
            .Columns(1).HeaderText = "Nóminas"
            .Columns(1).Width = 420
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

    Private Sub rdbNomina_CheckedChanged(sender As Object, e As EventArgs)
       RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvNominas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNominas.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvNominas.Focus()
    End Sub

    Private Sub DgvNominas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNominas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvNominas.Focus()
        End If
    End Sub

    Private Sub DgvNominas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNominas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNominas.ColumnCount
                Dim NumRows As Integer = DgvNominas.RowCount
                Dim CurCell As DataGridViewCell = DgvNominas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNominas.CurrentCell = DgvNominas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNominas.CurrentCell = DgvNominas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_mant_empleados.txtTipoNomina.Text = DgvNominas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_tipo_nomina.Name Then
                frm_mant_tipo_nomina.txtIDTipoNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_mant_tipo_nomina.txtTipoNomina.Text = DgvNominas.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_proceso_nomina.Name Then
                frm_proceso_nomina.txtIDTipoNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_proceso_nomina.txtTipoNomina.Text = DgvNominas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtNomina.Text = DgvNominas.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_nomina.Name Then
                frm_reporte_nomina.txtIDTipoNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_reporte_nomina.txtTipoNomina.Text = DgvNominas.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvNominas.CurrentRow.Cells(2).Value = 0 Then
            frm_mant_tipo_nomina.chkNulo.Checked = False
        Else
            frm_mant_tipo_nomina.chkNulo.Checked = True
        End If
    End Sub
End Class