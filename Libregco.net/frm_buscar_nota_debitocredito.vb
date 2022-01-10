Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_nota_debitocredito

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_nota_debitocredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDNotaDebCred,Fecha,NotaDebitoCredito.IDCliente,Nombre,TipoNotaFactura.Descripcion,Neto From" & SysName.Text & "notadebitocredito INNER Join Libregco.Clientes On notadebitocredito.IDCliente=Clientes.IDCliente INNER Join Libregco.TipoNotaFactura On notadebitocredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura Where IDNotaDebCred Like '%" + txtBuscar.Text + "%' AND NotaDebitoCredito.Nulo=0 ORDER By IDNotaDebCred DESC LIMIT 50", ConMixta)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDNotaDebCred,Fecha,NotaDebitoCredito.IDCliente,Nombre,TipoNotaFactura.Descripcion,Neto FROM" & SysName.Text & "notadebitocredito INNER JOIN Libregco.Clientes on NotaDebitoCredito.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoNotaFactura on NotaDebitoCredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura where Concepto like '%" + txtBuscar.Text + "%' AND NotaDebitoCredito.Nulo=0 ORDER By IDNotaDebCred DESC LIMIT 50", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nota")

            Bs.DataMember = "Nota"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvNotas.DataSource = Bs

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
        With DgvNotas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).Width = 70
            .Columns(2).Width = 45
            .Columns(2).HeaderText = "Cód"
            .Columns(3).Width = 220
            .Columns(4).Width = 100
            .Columns(5).Width = 115
            .Columns(5).DefaultCellStyle.Format = ("C")
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
        DgvNotas.Focus()
    End Sub

    Private Sub DgvNotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNotas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvNotas.Focus()
        End If
    End Sub

    Private Sub DgvNotas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNotas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNotas.ColumnCount
                Dim NumRows As Integer = DgvNotas.RowCount
                Dim CurCell As DataGridViewCell = DgvNotas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNotas.CurrentCell = DgvNotas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNotas.CurrentCell = DgvNotas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDNota, Nulo As New Label
        IDNota.Text = DgvNotas.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDNotaDebCred,NotaDebitoCredito.SecondID,Fecha,Hora,NotaDebitoCredito.IDCliente,Nombre,IDTipoNota,Descripcion,Concepto,GenerarNCF,NCF,SubTotal,Itbis,Neto,NotaDebitoCredito.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=NotaDebitoCredito.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.BalanceGeneral FROM" & SysName.Text & "notadebitocredito INNER JOIN Libregco.Clientes on NotaDebitoCredito.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoNotaFactura on NotaDebitoCredito.IDTipoNota=TipoNotaFactura.IDTipoNotaFactura INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDNotaDebCred= '" + IDNota.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Nota")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Nota")

        If Me.Owner.Name = frm_notas_debito_credito.Name Then
            frm_notas_debito_credito.txtIDNota.Text = (Tabla.Rows(0).Item("IDNotaDebCred"))
            frm_notas_debito_credito.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_notas_debito_credito.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_notas_debito_credito.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_notas_debito_credito.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_notas_debito_credito.txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
            frm_notas_debito_credito.TipoNota.Text = (Tabla.Rows(0).Item("Descripcion"))
            frm_notas_debito_credito.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_notas_debito_credito.lblNoNCF.Text = (Tabla.Rows(0).Item("NCF"))
            RefrescarTablaFact()
            frm_notas_debito_credito.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            frm_notas_debito_credito.txtItbis.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            frm_notas_debito_credito.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
            frm_notas_debito_credito.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
            frm_notas_debito_credito.lblCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_notas_debito_credito.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_notas_debito_credito.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

            If (Tabla.Rows(0).Item("IDTipoNota")) = "2" Then
                frm_notas_debito_credito.rdbNotaCredito.Checked = True
            ElseIf (Tabla.Rows(0).Item("IDTipoNota")) = "1" Then
                frm_notas_debito_credito.rdbNotaDebito.Checked = True
            End If
            If (Tabla.Rows(0).Item("GenerarNCF")) = 1 Then
                frm_notas_debito_credito.ChkGenerarNCF.Checked = True
            Else
                frm_notas_debito_credito.ChkGenerarNCF.Checked = False
            End If
            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_notas_debito_credito.ChkNulo.Checked = False
            Else
                frm_notas_debito_credito.ChkNulo.Checked = True
            End If
        End If


        Close()
        Exit Sub
    End Sub

    Sub RefrescarTablaFact()
        Try
            Dim IDDetalleAbono, IDFactura, BalanceAnterior, DiasVencidos, Debito, Descuento, lblIDCliente As New Label
            lblIDCliente.Text = frm_notas_debito_credito.txtIDCliente.Text
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim RowIndex As Integer = 0

            With frm_notas_debito_credito

                .DgvFacturas.Rows.Clear()
                Con.Open()
                Dim CmdFacts As New MySqlCommand("SELECT IDFacturaDatos,NCF,Fecha,FechaVencimiento,DiasVencidos,TotalNeto,BceAnterior,IDNotaDetalle,FacturaDatos.SecondID FROM NotaDebitoCreditoDetalle INNER JOIN FacturaDatos on notadebitocreditodetalle.IDFactura=FacturaDatos.IDFacturaDatos WHERE IDNotaDebitoCredito='" + frm_notas_debito_credito.txtIDNota.Text + "' AND Nulo=0", Con)
                Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

                While LectorFacturas.Read
                    .DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), False, CDbl(0).ToString("C"), CDbl(0).ToString("C"), LectorFacturas.GetValue(7), LectorFacturas.GetValue(8))
                End While
                LectorFacturas.Close()
                Con.Close()

                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDNotaDebitoCredito,IDFactura,BceAnterior,Aplicado,Itbis FROM NotaDebitoCreditoDetalle Where IDNotaDebitoCredito='" + .txtIDNota.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Notas")
                Con.Close()
                Dim Tabla As DataTable = Ds.Tables("Notas")
Inicio:
                If x = Tabla.Rows.Count Then
                    Exit Sub
                End If

                IDFactura.Text = Tabla.Rows(x).Item("IDFactura")
Buscar:
                If y = .DgvFacturas.Rows.Count Then
                    x = x + 1
                    y = 0
                    GoTo Inicio
                End If

                If CDbl(.DgvFacturas.Rows(y).Cells(0).Value) = IDFactura.Text Then
                    .DgvFacturas.Rows(y).Cells(6).Value = Tabla.Rows(x).Item("BceAnterior")
                    .DgvFacturas.Rows(y).Cells(8).Value = Tabla.Rows(x).Item("Aplicado")
                    .DgvFacturas.Rows(y).Cells(9).Value = Tabla.Rows(x).Item("Itbis")
                Else
                    If y = .DgvFacturas.Rows.Count Then
                        .DgvFacturas.Rows.Add(Tabla.Rows(x).Item("IDFactura"), "", "", "", "", Tabla.Rows(x).Item("BceAnterior"), False, "", Tabla.Rows(x).Item("Aplicado"), Tabla.Rows(x).Item("Itbis"))
                    End If
                End If

                y = y + 1
                GoTo Buscar

            End With

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class