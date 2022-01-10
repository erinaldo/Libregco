Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cliente_factura

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Friend lblIDUsuario As New Label

    Private Sub frm_buscar_cliente_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal FROM Clientes where IDCliente like '%" + txtBuscar.Text + "%' ORDER BY IDCliente DESC LIMIT 50", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal FROM Clientes where Nombre like '%" + txtBuscar.Text + "%' ORDER BY Nombre ASC LIMIT 50", ConLibregco)
            ElseIf rdbCedula.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal FROM Clientes where Identificacion like '%" + txtBuscar.Text + "%' ORDER BY Identificacion DESC LIMIT 50", ConLibregco)
            ElseIf rdbTelefono.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,TelefonoPersonal FROM Clientes where TelefonoPersonal like '%" + txtBuscar.Text + "%' ORDER BY TelefonoPersonasl DESC LIMIT 50", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")

            Bs.DataMember = "Clientes"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvClientes.DataSource = Bs

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
        With DgvClientes
            DgvClientes.Columns(0).HeaderText = "Código"
            DgvClientes.Columns(0).Width = 80
            DgvClientes.Columns(1).Width = 330
            DgvClientes.Columns(2).HeaderText = "Documento"
            DgvClientes.Columns(2).Width = 120
            DgvClientes.Columns(3).HeaderText = "Teléfono"
            DgvClientes.Columns(3).Width = 110
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCedula_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCedula.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbTelefono_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTelefono.CheckedChanged
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

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvClientes.Focus()
    End Sub

    Private Sub LlenarFormularios()
        Try
            With frm_consulta_factura_cliente
                .txtIDCliente.Text = DgvClientes.CurrentRow.Cells(0).Value
                .txtNombre.Text = DgvClientes.CurrentRow.Cells(1).Value
                .lblIDUsuario.Text = lblIDUsuario.Text
                Close()
            End With
          
            frm_consulta_factura_cliente.ShowDialog(Me)

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvClientes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvClientes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvClientes.Focus()
        End If
    End Sub

    Private Sub DgvClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvClientes.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvClientes.ColumnCount
                Dim NumRows As Integer = DgvClientes.RowCount
                Dim CurCell As DataGridViewCell = DgvClientes.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvClientes.CurrentCell = DgvClientes.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvClientes.CurrentCell = DgvClientes.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvClientes.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub
End Class