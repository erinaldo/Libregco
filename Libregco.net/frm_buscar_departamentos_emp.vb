Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_departamentos_emp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_departamentos_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM DepartamentoEmp where IDDepartamentoEMP like '%" + txtBuscar.Text + "%' ORDER BY IDDepartamentoEmp DESC", Con)
            ElseIf rdbDepartamento.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM DepartamentoEmp where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DepartamentosEmp")

            Bs.DataMember = "DepartamentosEmp"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDepartamentoEmp.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
       
    End Sub

    Sub LimpiartxtBuscar()
        rdbDepartamento.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDepartamentoEmp
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Departamento de Empleados"
            .Columns(1).Width = 305
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


    Private Sub DgvDepartamento_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDepartamentoEmp.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDepartamentoEmp.Focus()
    End Sub

    Private Sub DgvDepartamentoEmp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDepartamentoEmp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDepartamentoEmp.Focus()
        End If
    End Sub

    Private Sub DgvDepartamentoEmp_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDepartamentoEmp.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDepartamentoEmp.ColumnCount
                Dim NumRows As Integer = DgvDepartamentoEmp.RowCount
                Dim CurCell As DataGridViewCell = DgvDepartamentoEmp.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDepartamentoEmp.CurrentCell = DgvDepartamentoEmp.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDepartamentoEmp.CurrentCell = DgvDepartamentoEmp.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_cargos_emp.Name Then
                frm_mant_cargos_emp.txtIDDepartamento.Text = DgvDepartamentoEmp.CurrentRow.Cells(0).Value
                frm_mant_cargos_emp.txtDepartamento.Text = DgvDepartamentoEmp.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_mant_departamentosemp.Name Then
                frm_mant_departamentosemp.txtIDDepartamentoemp.Text = DgvDepartamentoEmp.CurrentRow.Cells(0).Value
                frm_mant_departamentosemp.txtDepartamentoEmp.Text = DgvDepartamentoEmp.CurrentRow.Cells(1).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDDepartamento.Text = DgvDepartamentoEmp.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtDepartamento.Text = DgvDepartamentoEmp.CurrentRow.Cells(1).Value
            End If

            Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If Me.Owner.Name = frm_mant_cargos_emp.Name Then
            If DgvDepartamentoEmp.CurrentRow.Cells(2).Value = 0 Then
                frm_mant_cargos_emp.chkNulo.Checked = False
            Else
                frm_mant_cargos_emp.chkNulo.Checked = True
            End If
        ElseIf Me.Owner.Name = frm_mant_departamentosemp.Name Then
            If DgvDepartamentoEmp.CurrentRow.Cells(2).Value = 0 Then
                frm_mant_departamentosemp.chkNulo.Checked = False
            Else
                frm_mant_departamentosemp.chkNulo.Checked = True
            End If


        End If
    End Sub

    Private Sub rdbDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDepartamento.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub
End Class