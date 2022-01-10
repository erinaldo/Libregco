Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_referencias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1, Ds2 As New DataSet
    
    Private Sub frm_buscar_referencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDReferencias,Nombre FROM Referencias where IDReferencias like '%" + txtBuscar.Text + "%'", ConLibregco)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT IDReferencias,Nombre FROM Referencias where Nombre like '%" + txtBuscar.Text + "%'", ConLibregco)
            ElseIf rdbCodCliente.Checked = True Then
                cmd = New MySqlCommand("SELECT IDReferencias,Nombre FROM Referencias where IDCliente like '%" + txtBuscar.Text + "%'", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Referencias")

            Bs.DataMember = "Referencias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvReferencias.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        DgvReferencias.Columns(0).HeaderText = "Código"
        DgvReferencias.Columns(0).Width = 100
        DgvReferencias.Columns(1).HeaderText = "Referencia"
        DgvReferencias.Columns(1).Width = 410
    End Sub

    Sub LimpiartxtBuscar()

        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodCliente.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvReferencias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvReferencias.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDReferencia As New Label
            IDReferencia.Text = DgvReferencias.CurrentRow.Cells(0).Value

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDReferencias,Referencias.IDCliente,Clientes.Nombre as NombreCliente,Clientes.Identificacion,Referencias.Nombre as NombreReferencia,Referencias.Direccion as DireccionReferencia,Referencias.Telefono as TelefonoReferencia,Referencias.IDRelacion,RelacionFamiliar.Relacion FROM Referencias INNER JOIN RelacionFamiliar on Referencias.IDRelacion=RelacionFamiliar.IDRelacionFamiliar INNER JOIN Clientes on Referencias.IDCliente=Clientes.IDCliente Where IDReferencias='" + IDReferencia.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Referencia")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Referencia")

            If Me.Owner.Name = frm_mant_referencias.Name Then
                frm_mant_referencias.txtIDReferencia.Text = (Tabla.Rows(0).Item("IDReferencias"))
                frm_mant_referencias.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                frm_mant_referencias.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
                frm_mant_referencias.txtCedula.Text = (Tabla.Rows(0).Item("Identificacion"))
                frm_mant_referencias.txtReferencia.Text = (Tabla.Rows(0).Item("NombreReferencia"))
                frm_mant_referencias.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionReferencia"))
                frm_mant_referencias.txtTelefono.Text = (Tabla.Rows(0).Item("TelefonoReferencia"))
                frm_mant_referencias.cbxRelacion.Text = (Tabla.Rows(0).Item("Relacion"))

            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvReferencias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvReferencias.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim NumCols As Integer = DgvReferencias.ColumnCount
            Dim NumRows As Integer = DgvReferencias.RowCount
            Dim CurCell As DataGridViewCell = DgvReferencias.CurrentCell
            If CurCell.ColumnIndex = NumCols - 1 Then
                If CurCell.RowIndex < NumRows - 1 Then
                    DgvReferencias.CurrentCell = DgvReferencias.Item(0, CurCell.RowIndex + 1)
                End If
            Else
                DgvReferencias.CurrentCell = DgvReferencias.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
            End If
            e.Handled = True
        End If

    End Sub

    Private Sub DgvReferencias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvReferencias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
         RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvReferencias.Focus()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvReferencias.Focus()
    End Sub
End Class