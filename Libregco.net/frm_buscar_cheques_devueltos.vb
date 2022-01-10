Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cheques_devueltos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_cheques_devueltos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
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
                cmd = New MySqlCommand("SELECT IDChequesDevueltos,Fecha,ChequesDevueltos.IDCliente,Nombre,NoCheque,Total FROM chequesdevueltos INNER JOIN Clientes on ChequesDevueltos.IDCliente=Clientes.IDCliente Where IDChequesDevueltos like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY IDChequesDevueltos DESC", Con)
            ElseIf rdbNoCheque.Checked = True Then
                cmd = New MySqlCommand("SELECT IDChequesDevueltos,Fecha,ChequesDevueltos.IDCliente,Nombre,NoCheque,Total FROM chequesdevueltos INNER JOIN Clientes on ChequesDevueltos.IDCliente=Clientes.IDCliente Where NoCheque like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY NoCheque ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Cheques")

            Bs.DataMember = "Cheques"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCheques.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvCheques
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).Width = 70
            .Columns(2).Width = 50
            .Columns(2).HeaderText = "ID"
            .Columns(3).Width = 180
            .Columns(4).Width = 110
            .Columns(4).HeaderText = "No. Cheque"
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 110
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbComentario_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoCheque.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCheques.Focus()
    End Sub

    Private Sub DgvCheques_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCheques.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvCheques.Focus()
        End If
    End Sub

    Private Sub DgvCheques_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCheques.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCheques.ColumnCount
                Dim NumRows As Integer = DgvCheques.RowCount
                Dim CurCell As DataGridViewCell = DgvCheques.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCheques.CurrentCell = DgvCheques.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCheques.CurrentCell = DgvCheques.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCheques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCheques.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDCheque, Nulo As New Label
        IDCheque.Text = DgvCheques.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDChequesDevueltos,ChequesDevueltos.SecondID AS SecondIDChequeDevuelto,IDFacturaDatos,IDMovimientoBancario,ChequesDevueltos.Fecha,ChequesDevueltos.Hora,ChequesDevueltos.IDCliente,Nombre,Clientes.Direccion,Clientes.Identificacion,Clientes.TelefonoPersonal,BalanceGeneral,Clientes.IDCalificacion,Calificacion,ifnull((Select Fecha from Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,IDCuentaBancaria,NoCuenta,BancosCuenta.Identidad as IdentidadBanco,CuentasBancarias.Balance,NoCheque,ChequesDevueltos.IDBanco,BancosCheque.Identidad as IdentidadCheque,Monto,Cargo,Total,BancosCheque.Identidad as IdentidadCuenta,Concepto,ChequesDevueltos.Nulo FROM chequesdevueltos INNER JOIN Clientes on ChequesDevueltos.IDCliente=Clientes.IDCliente INNER JOIN cuentasbancarias on chequesdevueltos.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN Bancos as BancosCuenta on CuentasBancarias.IDBanco=BancosCuenta.IDBanco INNER JOIN Bancos as BancosCheque on ChequesDevueltos.IDBanco=BancosCheque.IDBanco INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDChequesDevueltos='" + IDCheque.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Cheques")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Cheques")

        If Me.Owner.Name = frm_cheques_devueltos.Name Then
            frm_cheques_devueltos.txtIDCheque.Text = (Tabla.Rows(0).Item("IDChequesDevueltos"))
            frm_cheques_devueltos.lblIDFact.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
            frm_cheques_devueltos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDChequeDevuelto"))
            frm_cheques_devueltos.lblIDMovBanc.Text = (Tabla.Rows(0).Item("IDMovimientoBancario"))
            frm_cheques_devueltos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_cheques_devueltos.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_cheques_devueltos.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_cheques_devueltos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_cheques_devueltos.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuentaBancaria"))
            frm_cheques_devueltos.txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_cheques_devueltos.txtBancoCuenta.Text = (Tabla.Rows(0).Item("IdentidadBanco"))
            frm_cheques_devueltos.txtNoCheque.Text = (Tabla.Rows(0).Item("NoCheque"))
            frm_cheques_devueltos.txtIDBancoDevuelve.Text = (Tabla.Rows(0).Item("IDBanco"))
            frm_cheques_devueltos.txtBancoDevuelve.Text = (Tabla.Rows(0).Item("IdentidadCheque"))
            frm_cheques_devueltos.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_cheques_devueltos.txtCargo.Text = CDbl(Tabla.Rows(0).Item("Cargo")).ToString("C")
            frm_cheques_devueltos.txtTotal.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            frm_cheques_devueltos.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_cheques_devueltos.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            frm_cheques_devueltos.lblIdentificacion.Text = (Tabla.Rows(0).Item("Identificacion"))
            frm_cheques_devueltos.lblDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
            frm_cheques_devueltos.lblTelefono.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
            frm_cheques_devueltos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

            If (Tabla.Rows(0).Item("Nulo")) = True Then
                frm_cheques_devueltos.chkNulo.Checked = True
            Else
                frm_cheques_devueltos.chkNulo.Checked = False
            End If
        End If

        Close()
        Exit Sub

    End Sub

End Class