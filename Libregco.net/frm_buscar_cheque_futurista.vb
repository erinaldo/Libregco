Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cheque_futurista

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_cheque_futurista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDChequesFuturos,SecondID,Fecha,ChequesFuturos.IDCliente,Nombre,ChequesFuturos.Referencia,NoCheque,MontoCheque FROM chequesfuturos INNER JOIN Clientes on ChequesFuturos.IDCliente=Clientes.IDCliente where IDChequesFuturos like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY IDChequesFuturos DESC", Con)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDChequesFuturos,SecondID,Fecha,ChequesFuturos.IDCliente,Nombre,ChequesFuturos.Referencia,NoCheque,MontoCheque FROM chequesfuturos INNER JOIN Clientes on ChequesFuturos.IDCliente=Clientes.IDCliente where IDReferencia like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY Referencia ASC", Con)
            ElseIf rdbNoCheque.Checked = True Then
                cmd = New MySqlCommand("SELECT IDChequesFuturos,SecondID,Fecha,ChequesFuturos.IDCliente,Nombre,ChequesFuturos.Referencia,NoCheque,MontoCheque FROM chequesfuturos INNER JOIN Clientes on ChequesFuturos.IDCliente=Clientes.IDCliente where NoCheque like '%" + txtBuscar.Text + "%' and Nulo=0 ORDER BY NoCheque ASC", Con)
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
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvCheques
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 90
            .Columns(2).Width = 75
            .Columns(2).HeaderText = "Fecha"
            .Columns(3).Width = 50
            .Columns(3).HeaderText = "ID"
            .Columns(4).Width = 180
            .Columns(4).HeaderText = "Cliente"
            .Columns(5).HeaderText = "Ref."
            .Columns(5).Width = 70
            .Columns(6).HeaderText = "No. Cheque"
            .Columns(6).Width = 100
            .Columns(7).HeaderText = "Monto"
            .Columns(7).Width = 115
            .Columns(7).DefaultCellStyle.Format = "C"
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReferencia.CheckedChanged
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
        Dim IDChequeFuturo, Nulo As New Label
        IDChequeFuturo.Text = DgvCheques.CurrentRow.Cells(0).Value

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDChequesFuturos,SecondID,IDUsuario,Fecha,Hora,ChequesFuturos.IDCliente,Nombre,ChequesFuturos.Referencia,ChequesFuturos.IDBanco,Identidad,FechaDeposito,NoCheque,MontoCheque,Procesado,ChequesFuturos.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from Abonos where IDCliente=ChequesFuturos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.BalanceGeneral FROM chequesfuturos INNER JOIN Clientes on ChequesFuturos.IDCliente=Clientes.IDCliente INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Bancos on ChequesFuturos.IDBanco=Bancos.IDBanco Where IDChequesFuturos= '" + IDChequeFuturo.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "chequesfuturos")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("chequesfuturos")

        If Me.Owner.Name = frm_cheques_futuristas.Name Then
            frm_cheques_futuristas.txtIDCheque.Text = (Tabla.Rows(0).Item("IDChequesFuturos"))
            frm_cheques_futuristas.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cheques_futuristas.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_cheques_futuristas.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cheques_futuristas.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_cheques_futuristas.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_cheques_futuristas.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_cheques_futuristas.DtpFechaDeposito.Value = (Tabla.Rows(0).Item("FechaDeposito"))
            frm_cheques_futuristas.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_cheques_futuristas.lblIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
            frm_cheques_futuristas.cbxBanco.Text = (Tabla.Rows(0).Item("Identidad"))
            frm_cheques_futuristas.txtNoCheque.Text = (Tabla.Rows(0).Item("NoCheque"))
            frm_cheques_futuristas.txtMonto.Text = CDbl(Tabla.Rows(0).Item("MontoCheque")).ToString("C")
            frm_cheques_futuristas.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            frm_cheques_futuristas.lblProcesado.Text = (Tabla.Rows(0).Item("Procesado"))
            frm_cheques_futuristas.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_cheques_futuristas.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_cheques_futuristas.ChkNulo.Checked = True
            Else
                frm_cheques_futuristas.ChkNulo.Checked = False
            End If

            If (Tabla.Rows(0).Item("Procesado")) = 1 Then
                frm_cheques_futuristas.chkProcesar.Checked = True
                frm_cheques_futuristas.lblStatusBar.Text = "Este cheque futurista ya ha sido procesado."
            Else
                frm_cheques_futuristas.chkProcesar.Checked = False
            End If

            frm_cheques_futuristas.RefrescarTablaFacturasGuardadas()
        End If

        Close()
        Exit Sub
    End Sub

    Private Sub rdbNoCheque_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoCheque.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub
End Class