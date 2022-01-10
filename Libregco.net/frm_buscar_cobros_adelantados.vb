Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cobros_adelantados

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_cobros_adelantados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDCobrosAdelantados,CobrosAdelantados.SecondID,Fecha,CobrosAdelantados.IDCliente,Nombre,Monto,CobrosAdelantados.Nulo FROM" & SysName.Text & "cobrosadelantados INNER JOIN Libregco.Clientes on CobrosAdelantados.IDCliente=Clientes.IDCliente where IDCobrosAdelantados like '%" + txtBuscar.Text + "%' AND CobrosAdelantados.Nulo=0 ORDER By IDCobrosAdelantados DESC LIMIT 50", ConMixta)
            ElseIf rdbConcepto.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCobrosAdelantados,CobrosAdelantados.SecondID,Fecha,CobrosAdelantados.IDCliente,Nombre,Monto,CobrosAdelantados.Nulo FROM" & SysName.Text & "cobrosadelantados INNER JOIN Libregco.Clientes on CobrosAdelantados.IDCliente=Clientes.IDCliente where Concepto like '%" + txtBuscar.Text + "%' AND CobrosAdelantados.Nulo=0 ORDER By Concepto ASC LIMIT 50", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CobrosAdelantados")

            Bs.DataMember = "CobrosAdelantados"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCobrosAdelantados.DataSource = Bs

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
        With DgvCobrosAdelantados
            .Columns(1).HeaderText = "No. Cobro"
            .Columns(0).Visible = False
            .Columns(1).Width = 110
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "ID"
            .Columns(3).Width = 80
            .Columns(4).Width = 230
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 120
            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbConcepto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConcepto.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCobrosAdelantados.Focus()
    End Sub

    Private Sub DgvCobrosAdelantados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCobrosAdelantados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvCobrosAdelantados.Focus()
        End If
    End Sub

    Private Sub DgvCobrosAdelantados_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCobrosAdelantados.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCobrosAdelantados.ColumnCount
                Dim NumRows As Integer = DgvCobrosAdelantados.RowCount
                Dim CurCell As DataGridViewCell = DgvCobrosAdelantados.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCobrosAdelantados.CurrentCell = DgvCobrosAdelantados.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCobrosAdelantados.CurrentCell = DgvCobrosAdelantados.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCobrosAdelantados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCobrosAdelantados.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDCobro As New Label
        IDCobro.Text = DgvCobrosAdelantados.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCobrosAdelantados,CobrosAdelantados.SecondID,Fecha,Hora,CobrosAdelantados.IDTransaccion,CobrosAdelantados.IDCliente,Clientes.Nombre as NombreCliente,Monto,Letra,Concepto,CobrosAdelantados.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=CobrosAdelantados.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,Clientes.BalanceGeneral,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM" & SysName.Text & "CobrosAdelantados INNER JOIN Libregco.Clientes on CobrosAdelantados.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDCobrosAdelantados='" + IDCobro.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "CobrosAdelantados")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("CobrosAdelantados")

        If Me.Owner.Name = frm_cobros_adelantados.Name Then
            frm_cobros_adelantados.txtIDCobro.Text = (Tabla.Rows(0).Item("IDCobrosAdelantados"))
            frm_cobros_adelantados.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
            frm_cobros_adelantados.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cobros_adelantados.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_cobros_adelantados.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cobros_adelantados.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_cobros_adelantados.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
            frm_cobros_adelantados.txtLetra.Text = (Tabla.Rows(0).Item("Letra"))
            frm_cobros_adelantados.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_cobros_adelantados.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_cobros_adelantados.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_cobros_adelantados.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_cobros_adelantados.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
            frm_cobros_adelantados.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_cobros_adelantados.ChkNulo.Checked = False
            Else
                frm_cobros_adelantados.ChkNulo.Checked = True
            End If
        End If

        Close()
        Exit Sub

    End Sub



End Class