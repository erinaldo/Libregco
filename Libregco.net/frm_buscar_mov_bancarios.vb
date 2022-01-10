Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_mov_bancarios

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_mov_bancarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If Me.Owner.Name = frm_cheques.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,NoCuenta,TipoMovBancario.TipoMovimiento,Abreviatura,NoTransaccion,Total FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN" & SysName.Text & "CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta Where IDTipoMovimientoBanc=1 and IDMovimiento like '%" + txtBuscar.Text + "%'", ConMixta)
                ElseIf rdbMovimiento.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,NoCuenta,TipoMovBancario.TipoMovimiento,Abreviatura,NoTransaccion,Total FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN" & SysName.Text & "CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta Where IDTipoMovimientoBanc=1 and Movimientosbanco.SecondID like '%" + txtBuscar.Text + "%'", ConMixta)
                End If
            ElseIf Me.Owner.Name = frm_movimientos_bancarios.Name Then
                If rdbCodigo.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,NoCuenta,TipoMovBancario.TipoMovimiento,Abreviatura,NoTransaccion,Total FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN" & SysName.Text & "CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta Where IDTipoMovimientoBanc>1 and IDMovimiento like '%" + txtBuscar.Text + "%'", ConMixta)
                ElseIf rdbMovimiento.Checked = True Then
                    cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,NoCuenta,TipoMovBancario.TipoMovimiento,Abreviatura,NoTransaccion,Total FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN" & SysName.Text & "CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta Where IDTipoMovimientoBanc>1 and Movimientosbanco.SecondID like '%" + txtBuscar.Text + "%'", ConMixta)
                End If
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "MovimientosBanco")

            Bs.DataMember = "MovimientosBanco"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvMovimientos.DataSource = Bs

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
        With DgvMovimientos
            .Columns(0).Visible = False
            .Columns(1).Width = 120
            .Columns(1).HeaderText = "No. Movimiento"

            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"

            .Columns(3).Width = 120
            .Columns(3).HeaderText = "No. Cuenta"

            .Columns(4).HeaderText = "Tipo movimiento"
            .Columns(4).Width = 210

            .Columns(5).HeaderText = ""
            .Columns(5).Width = 70

            .Columns(6).HeaderText = "No."
            .Columns(6).Width = 90

            .Columns(7).HeaderText = "Monto"
            .Columns(7).Width = 110
            .Columns(7).DefaultCellStyle.Format = "C"

        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbMovimiento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMovimiento.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvMovimientos.Focus()
    End Sub

    Private Sub DgvMovimientos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvMovimientos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvMovimientos.Focus()
        End If
    End Sub

    Private Sub DgvMovimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvMovimientos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvMovimientos.ColumnCount
                Dim NumRows As Integer = DgvMovimientos.RowCount
                Dim CurCell As DataGridViewCell = DgvMovimientos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvMovimientos.CurrentCell = DgvMovimientos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvMovimientos.CurrentCell = DgvMovimientos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvMovimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMovimientos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDMovimiento, Nulo As New Label
        IDMovimiento.Text = DgvMovimientos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDMovimiento,MovimientosBanco.SecondID,MovimientosBanco.Fecha,MovimientosBanco.Hora,MovimientosBanco.IDCuentaBancaria,CuentasBancarias.NoCuenta,Bancos.Identidad,cuentasbancarias.Titular,CuentasBancarias.Balance,MovimientosBanco.IDTipoMovimientoBanc,TipoMovBancario.TipoMovimiento,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,CuentasBancarias.Balance,MontoLetras,NCF,Concepto,RutaDocumento,MovimientosBanco.Nulo FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.TipoMovBancario ON MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN" & SysName.Text & "CuentasBancarias on MovimientosBanco.IDCuentaBancaria=CuentasBancarias.IDCuenta INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where IDMovimiento= '" + IDMovimiento.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Movimiento")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Movimiento")

        If Me.Owner.Name = frm_cheques.Name Then
            frm_cheques.Hora.Enabled = False
            frm_cheques.txtIDCheque.Text = (Tabla.Rows(0).Item("IDMovimiento"))
            frm_cheques.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_cheques.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cheques.lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuentaBancaria"))
            frm_cheques.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cheques.cbxCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_cheques.SetIDCuenta()
            frm_cheques.txtNoCheque.Text = (Tabla.Rows(0).Item("NoTransaccion"))
            frm_cheques.dtpFechaPago.Text = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
            frm_cheques.dtpFechaPago.Value = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
            frm_cheques.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
            frm_cheques.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_cheques.txtMontoLetras.Text = (Tabla.Rows(0).Item("MontoLetras"))
            frm_cheques.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_cheques.lblRutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))
            frm_cheques.txtBanco.Text = (Tabla.Rows(0).Item("Identidad")) & " --> " & (Tabla.Rows(0).Item("Titular"))
            frm_cheques.txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_cheques.chkNulo.Checked = False
                frm_cheques.lblchknulo.Text = 0
            Else
                frm_cheques.chkNulo.Checked = True
                frm_cheques.lblchknulo.Text = 1
            End If

        ElseIf Me.Owner.Name = frm_movimientos_bancarios.Name Then
            frm_movimientos_bancarios.Hora.Enabled = False
            frm_movimientos_bancarios.txtIDMovimientoBanc.Text = (Tabla.Rows(0).Item("IDMovimiento"))
            frm_movimientos_bancarios.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_movimientos_bancarios.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_movimientos_bancarios.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_movimientos_bancarios.cbxTipoMovimiento.Text = (Tabla.Rows(0).Item("TipoMovimiento"))
            frm_movimientos_bancarios.lblIDTipoMovimiento.Text = (Tabla.Rows(0).Item("IDTipoMovimientoBanc"))
            frm_movimientos_bancarios.SetIDTipoMovimiento()
            frm_movimientos_bancarios.cbxCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_movimientos_bancarios.SetIDCuentaBanc()
            frm_movimientos_bancarios.dtpFecha.Value = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
            frm_movimientos_bancarios.dtpFecha.Text = CDate(Tabla.Rows(0).Item("FechaMovimiento")).ToString("dd/MM/yyyy")
            frm_movimientos_bancarios.txtReferencia.Text = (Tabla.Rows(0).Item("NoTransaccion"))
            frm_movimientos_bancarios.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
            frm_movimientos_bancarios.txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
            frm_movimientos_bancarios.txtCapital.Text = CDbl(Tabla.Rows(0).Item("Capital")).ToString("C")
            frm_movimientos_bancarios.txtInteres.Text = CDbl(Tabla.Rows(0).Item("Interes")).ToString("C")
            frm_movimientos_bancarios.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_movimientos_bancarios.lblRutaDocumento.Text = (Tabla.Rows(0).Item("RutaDocumento"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_movimientos_bancarios.chkNulo.Checked = False
                frm_movimientos_bancarios.lblchkNulo.Text = 0
            Else
                frm_movimientos_bancarios.chkNulo.Checked = True
                frm_movimientos_bancarios.lblchkNulo.Text = 1
            End If
        End If

        Close()
        Exit Sub
    End Sub

End Class