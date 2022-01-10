Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_prestamos_emp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_prestamos_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDPrestamosEmp,SecondID,Fecha,Nombre,Concepto,prestamosemp.Nulo FROM" & SysName.Text & "prestamosemp INNER JOIN" & SysName.Text & "Empleados on prestamosemp.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.tipoprestamoemp on PrestamosEmp.IDTipoPrestamo=TipoPrestamoemp.IDTipoPrestamoEmp where IDPrestamosEmp like '%" + txtBuscar.Text + "%' ORDER BY IDPrestamosEmp Desc", ConMixta)
            ElseIf rdbConcepto.Checked = True Then
                cmd = New MySqlCommand("SELECT IDPrestamosEmp,SecondID,Fecha,Nombre,Concepto,prestamosemp.Nulo FROM" & SysName.Text & "prestamosemp INNER JOIN" & SysName.Text & " Empleados on prestamosemp.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.tipoprestamoemp on PrestamosEmp.IDTipoPrestamo=TipoPrestamoemp.IDTipoPrestamoEmp where Concepto like '%" + txtBuscar.Text + "%' ORDER BY Descripcion Desc", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Clipboard.SetText(cmd.CommandText)
            Adaptador.Fill(Ds, "Prestamos")

            Bs.DataMember = "Prestamos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPrestamos.DataSource = Bs

            PropiedadColumnsDvg()
        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbConcepto.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvPrestamos
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 80
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "Empleado"
            .Columns(3).Width = 170
            .Columns(4).HeaderText = "Descripción"
            .Columns(4).Width = 200
            .Columns(5).Visible = False
        End With
    End Sub

    Private Sub rdbConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConcepto.CheckedChanged
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

    Private Sub DgvPrestamos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrestamos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPrestamos.Focus()
    End Sub

    Private Sub DgvPrestamos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPrestamos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvPrestamos.Focus()
        End If
    End Sub

    Private Sub DgvPrestamos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPrestamos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPrestamos.ColumnCount
                Dim NumRows As Integer = DgvPrestamos.RowCount
                Dim CurCell As DataGridViewCell = DgvPrestamos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPrestamos.CurrentCell = DgvPrestamos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPrestamos.CurrentCell = DgvPrestamos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDPrestamo As New Label
            lblIDPrestamo.Text = DgvPrestamos.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDPrestamosEmp,prestamosemp.Fecha,SecondID,prestamosemp.IDEmpleado,Nombre,Cedula,IDTipoPrestamo,Descripcion,Monto,Cuota,Concepto,Empleados.Balance,prestamosemp.Nulo from" & SysName.Text & "prestamosemp INNER JOIN" & SysName.Text & "Empleados on PrestamosEmp.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.tipoprestamoemp on PrestamosEMp.IDTipoPrestamo=tipoprestamoemp.IDTipoPrestamoEmp where IDPrestamosEmp='" + lblIDPrestamo.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "prestamosemp")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("prestamosemp")

            If Me.Owner.Name = frm_mant_prestamos_emp.Name = True Then
                frm_mant_prestamos_emp.txtIDPrestamo.Text = (Tabla.Rows(0).Item("IDPrestamosEmp"))
                frm_mant_prestamos_emp.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_mant_prestamos_emp.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_mant_prestamos_emp.txtIDEmpleado.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                frm_mant_prestamos_emp.txtIDTipoPrestamo.Text = (Tabla.Rows(0).Item("IDTipoPrestamo"))
                frm_mant_prestamos_emp.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_mant_prestamos_emp.txtCuota.Text = CDbl(Tabla.Rows(0).Item("Cuota")).ToString("C")
                frm_mant_prestamos_emp.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
                frm_mant_prestamos_emp.txtEmpleado.Text = (Tabla.Rows(0).Item("Nombre"))
                frm_mant_prestamos_emp.txtCedula.Text = (Tabla.Rows(0).Item("Cedula"))
                frm_mant_prestamos_emp.txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_mant_prestamos_emp.txtTipoPrestamo.Text = (Tabla.Rows(0).Item("Descripcion"))

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_prestamos_emp.chkNulo.Checked = False
                Else
                    frm_mant_prestamos_emp.chkNulo.Checked = True
                End If
            End If

            Close()

            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class