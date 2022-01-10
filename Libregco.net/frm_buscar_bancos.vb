Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_bancos
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDBanco,Identidad FROM Bancos where IDBanco like '%" + txtBuscar.Text + "%' ORDER BY IDBanco DESC", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDBanco,Identidad FROM Bancos where Identidad like '%" + txtBuscar.Text + "%' ORDER BY Identidad ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Bancos")

            Bs.DataMember = "Bancos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvBancos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvBancos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 115
            .Columns(1).Width = 350
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvBancos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvBancos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvBancos.Focus()
    End Sub

    Private Sub DgvBancos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvBancos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvBancos.Focus()
        End If
    End Sub

    Private Sub DgvBancos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvBancos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvBancos.ColumnCount
                Dim NumRows As Integer = DgvBancos.RowCount
                Dim CurCell As DataGridViewCell = DgvBancos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvBancos.CurrentCell = DgvBancos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvBancos.CurrentCell = DgvBancos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDBanco As New Label
            lblIDBanco.Text = DgvBancos.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select * from Bancos where IDBanco='" + lblIDBanco.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Bancos")
            ConLibregco.Close()

            Dim Tabla As DataTable= Ds1.Tables("Bancos")

            If Me.Owner.Name = frm_mant_bancos.Name Then
                frm_mant_bancos.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_mant_bancos.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_bancos.chkNulo.Checked = False
                Else
                    frm_mant_bancos.chkNulo.Checked = True
                End If

            ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
                frm_cheques_devueltos.txtIDBancoDevuelve.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_cheques_devueltos.txtBancoDevuelve.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
                frm_reporte_cheques_devueltos.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_reporte_cheques_devueltos.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_reporte_cheques_futuros.Name Then
                frm_reporte_cheques_futuros.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_reporte_cheques_futuros.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_consulta_cheques_futuros.Name Then
                frm_consulta_cheques_futuros.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_consulta_cheques_futuros.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_consulta_cheques_devueltos.Name Then
                frm_consulta_cheques_devueltos.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_consulta_cheques_devueltos.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_registro_cuentasbancarias.Name Then
                frm_registro_cuentasbancarias.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_registro_cuentasbancarias.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

            ElseIf Me.Owner.Name = frm_consulta_solicitud_cheques.Name Then
                frm_consulta_solicitud_cheques.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
                frm_consulta_solicitud_cheques.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
            End If

            Close()
            Exit Sub

        Catch ex As Exception

        End Try

    End Sub

   
End Class