Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_cargos_emp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_cargos_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        cmd = New MySqlCommand("SELECT IDCargo,Cargo,cargosemp.Nulo,cargosemp.IDDepartamentoEmp,Descripcion FROM cargosemp INNER JOIN departamentoemp on CargosEmp.IDDepartamentoEmp=Departamentoemp.IDDepartamentoEmp ORDER BY Cargo ASC", ConLibregco)
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CargosEmp")

            Bs.DataMember = "CargosEmp"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCargosEmp.DataSource = Bs

            PropiedadColumnsDvg()


        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbCargo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvCargosEmp
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 120
            .Columns(1).HeaderText = "Puesto de Trabajo"
            .Columns(1).Width = 270
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()

        If rdbCodigo.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

        If txtBuscar.Text = "" Then
            cmd = New MySqlCommand("SELECT IDCargo,Cargo,cargosemp.Nulo,cargosemp.IDDepartamentoEmp,Descripcion FROM cargosemp INNER JOIN departamentoemp on CargosEmp.IDDepartamentoEmp=Departamentoemp.IDDepartamentoEmp ORDER BY Cargo ASC", Con)
            RefrescarTabla()
            Exit Sub
        End If

        If rdbCodigo.Checked = True Then
            cmd = New MySqlCommand("SELECT IDCargo,Cargo,cargosemp.Nulo,cargosemp.IDDepartamentoEmp,Descripcion FROM cargosemp INNER JOIN departamentoemp on CargosEmp.IDDepartamentoEmp=Departamentoemp.IDDepartamentoEmp where IDCargo like '%" + txtBuscar.Text + "%' ORDER BY IDCargo DESC", Con)

        ElseIf rdbCargo.Checked = True Then
            cmd = New MySqlCommand("SELECT IDCargo,Cargo,cargosemp.Nulo,cargosemp.IDDepartamentoEmp,Descripcion FROM cargosemp INNER JOIN departamentoemp on CargosEmp.IDDepartamentoEmp=Departamentoemp.IDDepartamentoEmp where Cargo like '%" + txtBuscar.Text + "%' ORDER BY Cargo ASC", Con)

        End If

        RefrescarTabla()
    End Sub

    Private Sub rdbCargo_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()

        If rdbCargo.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub DgvCargosEmp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCargosEmp.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCargosEmp.Focus()
    End Sub

    Private Sub DgvCargosEmp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCargosEmp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCargosEmp.Focus()
        End If
    End Sub

    Private Sub DgvCargosEmp_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCargosEmp.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCargosEmp.ColumnCount
                Dim NumRows As Integer = DgvCargosEmp.RowCount
                Dim CurCell As DataGridViewCell = DgvCargosEmp.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCargosEmp.CurrentCell = DgvCargosEmp.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCargosEmp.CurrentCell = DgvCargosEmp.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_cargos_emp.Name Then
                frm_mant_cargos_emp.txtIDCargo.Text = DgvCargosEmp.CurrentRow.Cells(0).Value
                frm_mant_cargos_emp.txtCargo.Text = DgvCargosEmp.CurrentRow.Cells(1).Value
                frm_mant_cargos_emp.txtIDDepartamento.Text = DgvCargosEmp.CurrentRow.Cells(3).Value
                frm_mant_cargos_emp.txtDepartamento.Text = DgvCargosEmp.CurrentRow.Cells(4).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDDepartamento.Text = DgvCargosEmp.CurrentRow.Cells(0).Value
                frm_mant_empleados.txtDepartamento.Text = DgvCargosEmp.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDCargo.Text = DgvCargosEmp.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtCargo.Text = DgvCargosEmp.CurrentRow.Cells(1).Value

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvCargosEmp.CurrentRow.Cells(2).Value = 0 Then
            frm_mant_cargos_emp.chkNulo.Checked = False
        Else
            frm_mant_cargos_emp.chkNulo.Checked = True
        End If
    End Sub
End Class