Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_cuenta_contable

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_buscar_cuenta_contable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDCtaCont,NoCuenta,NombreCuenta FROM CtaContable where IDCtaCont like '%" + txtBuscar.Text + "%' ORDER BY IDCtaCont DESC", Con)
            ElseIf rdbNoCuenta.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCtaCont,NoCuenta,NombreCuenta FROM CtaContable where NoCuenta like '%" + txtBuscar.Text + "%' ORDER BY NoCuenta ASC", Con)
            ElseIf rdbdescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCtaCont,NoCuenta,NombreCuenta FROM CtaContable where NombreCuenta like '%" + txtBuscar.Text + "%' ORDER BY NombreCuenta ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CtaContable")

            Bs.DataMember = "CtaContable"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCuentas.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvCuentas.Columns(0).HeaderText = "Código"
        DgvCuentas.Columns(0).Width = 100
        DgvCuentas.Columns(1).Width = 160
        DgvCuentas.Columns(1).HeaderText = "No. Cuenta"
        DgvCuentas.Columns(2).Width = 318
        DgvCuentas.Columns(2).HeaderText = "Descripción"
    End Sub


    Private Sub rdbNoCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoCuenta.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbdescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbdescripcion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCuentas.Focus()
    End Sub

    Private Sub DgvCuentas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCuentas.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCuentas.ColumnCount
                Dim NumRows As Integer = DgvCuentas.RowCount
                Dim CurCell As DataGridViewCell = DgvCuentas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCuentas.CurrentCell = DgvCuentas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCuentas.CurrentCell = DgvCuentas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCuentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCuentas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim lblIDCtaCont As New Label
        lblIDCtaCont.Text = DgvCuentas.CurrentRow.Cells(0).Value

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select * from CtaContable where IDCtaCont='" + lblIDCtaCont.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "CtaContable")
        Con.Close()

        Dim Tabla As DataTable= Ds.Tables("CtaContable")

        If Me.Owner.Name = frm_registro_cuentasbancarias.Name Then
            frm_registro_cuentasbancarias.txtIDCuentaCont.Text = (Tabla.Rows(0).Item("IDCtaCont"))
            frm_registro_cuentasbancarias.txtCuentaCont.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_registro_cuentasbancarias.txtDescripcionCta.Text = (Tabla.Rows(0).Item("NombreCuenta"))

        ElseIf Me.Owner.Name = frm_mant_tipo_mov_bancario.Name Then
            frm_mant_tipo_mov_bancario.txtIDCtaContable.Text = (Tabla.Rows(0).Item("IDCtaCont"))
            frm_mant_tipo_mov_bancario.txtCtaContable.Text = (Tabla.Rows(0).Item("NombreCuenta"))
        End If
       
        Close()
        Exit Sub
       
    End Sub
End Class