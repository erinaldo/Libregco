Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_tipo_prestamos_emp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_tipo_prestamos_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT * FROM TipoPrestamoEmp where IDTipoPrestamoEmp like '%" + txtBuscar.Text + "%' ORDER BY IDTipoPrestamoEmp ASC", ConLibregco)
            ElseIf rdbTipoPrestamo.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoPrestamoEmp where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoPrestamosEmp")

            Bs.DataMember = "TipoPrestamosEmp"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoPrestamo.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbTipoPrestamo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoPrestamo
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Tipo de Préstamo"
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

    Private Sub rdbTipoPrestamo_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvTipoPrestamo_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoPrestamo.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoPrestamo.Focus()
    End Sub

    Private Sub DgvTipoPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoPrestamo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoPrestamo.Focus()
        End If
    End Sub

    Private Sub DgvTipoPrestamo_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoPrestamo.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoPrestamo.ColumnCount
                Dim NumRows As Integer = DgvTipoPrestamo.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoPrestamo.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoPrestamo.CurrentCell = DgvTipoPrestamo.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoPrestamo.CurrentCell = DgvTipoPrestamo.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_prestamos_emp.Name Then
                frm_mant_prestamos_emp.txtIDTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(0).Value
                frm_mant_prestamos_emp.txtTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_mant_tipo_prestamos.Name Then
                frm_mant_tipo_prestamos.txtIDTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(0).Value
                frm_mant_tipo_prestamos.txtTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(1).Value

                If DgvTipoPrestamo.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_tipo_prestamos.chkNulo.Checked = False
                Else
                    frm_mant_tipo_prestamos.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_consulta_prestamos_emp.Name Then
                frm_consulta_prestamos_emp.txtIDTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(0).Value
                frm_consulta_prestamos_emp.txtTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_prestamos_empleados.Name Then
                frm_reporte_prestamos_empleados.txtIDTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(0).Value
                frm_reporte_prestamos_empleados.txtTipoPrestamo.Text = DgvTipoPrestamo.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class