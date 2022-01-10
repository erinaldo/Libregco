Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_cuenta_bancaria

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_buscar_cuenta_bancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
        Me.CenterToParent()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub PropiedadColumnsDgv()
        DgvCuentasBancarias.Columns(0).Visible = False

        DgvCuentasBancarias.Columns(1).HeaderText = "Código"
        DgvCuentasBancarias.Columns(1).Width = 100

        DgvCuentasBancarias.Columns(2).Width = 100
        DgvCuentasBancarias.Columns(2).HeaderText = "No. Cuenta"

        DgvCuentasBancarias.Columns(3).Width = 210
        DgvCuentasBancarias.Columns(3).HeaderText = "Banco"

        DgvCuentasBancarias.Columns(4).Width = 170
        DgvCuentasBancarias.Columns(4).HeaderText = "Tipo de Moneda"

    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("Select IDCuenta,CuentasBancarias.SecondID,NoCuenta,Identidad,Texto from" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on cuentasbancarias.IDBanco=Bancos.IDBanco INNER JOIN Libregco.tipomoneda on cuentasbancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda where IDCuenta like '%" + txtBuscar.Text + "%' ORDER BY IDCUENTA DESC", ConMixta)

            ElseIf rdbNoCuenta.Checked = True Then
                cmd = New MySqlCommand("Select IDCuenta,CuentasBancarias.SecondID,NoCuenta,Identidad,Texto from" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on cuentasbancarias.IDBanco=Bancos.IDBanco INNER JOIN Libregco.tipomoneda on cuentasbancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda where NoCuenta like '%" + txtBuscar.Text + "%' ORDER BY NoCuenta ASC", ConMixta)

            ElseIf rdbBanco.Checked = True Then
                cmd = New MySqlCommand("Select IDCuenta,CuentasBancarias.SecondID,NoCuenta,Identidad,Texto from" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on cuentasbancarias.IDBanco=Bancos.IDBanco INNER JOIN Libregco.tipomoneda on cuentasbancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda where Identidad like '%" + txtBuscar.Text + "%' ORDER BY Identidad ASC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CuentasBancarias")

            Bs.DataMember = "CuentasBancarias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCuentasBancarias.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNoCuenta_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoCuenta.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles rdbBanco.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCuentasBancarias.Focus()
    End Sub

    Private Sub DgvCuentasBancarias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCuentasBancarias.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCuentasBancarias.ColumnCount
                Dim NumRows As Integer = DgvCuentasBancarias.RowCount
                Dim CurCell As DataGridViewCell = DgvCuentasBancarias.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCuentasBancarias.CurrentCell = DgvCuentasBancarias.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCuentasBancarias.CurrentCell = DgvCuentasBancarias.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCuentasBancarias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCuentasBancarias.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim DsTemp As New DataSet
        Dim lblIDCuenta As New Label
        lblIDCuenta.Text = DgvCuentasBancarias.CurrentRow.Cells(0).Value


        DsTemp.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("Select IDCuenta,SecondID,CuentasBancarias.IDTipoDocumento,TipoDocumento.Documento,CuentasBancarias.IDUsuario,Usuarios.Nombre as NombreEmpleado,Creacion,CuentasBancarias.Fecha,CuentasBancarias.Hora,CuentasBancarias.NoCuenta,CuentasBancarias.LimiteReserva,CuentasBancarias.IDBanco,Bancos.Identidad,Titular,SucursalDirecta,Oficial,Telefono,CuentasBancarias.IDCtaCont,CtaContable.NoCuenta as NoCtaContable,CtaContable.NombreCuenta,CuentasBancarias.Balance,CuentasBancarias.IDTipoMoneda,Moneda,Cheques,ChequeActual,CuentasBancarias.Nulo,ifnull((Select Beneficiario from" & SysName.Text & "MovimientosBanco where IDCuentaBancaria='" + lblIDCuenta.Text + "' and IDTipoMovimientoBanc=1 and Nulo=0 ORDER BY IDMovimiento DESC LIMIT 1),'') AS UltimoBeneficiario,ifnull((Select Total from" & SysName.Text & "MovimientosBanco where IDCuentaBancaria='" + lblIDCuenta.Text + "' and IDTipoMovimientoBanc=1 and Nulo=0 ORDER BY IDMovimiento DESC LIMIT 1),'') AS UltimoMonto,ifnull((Select NoTransaccion from" & SysName.Text & "MovimientosBanco where IDCuentaBancaria='" + lblIDCuenta.Text + "' and IDTipoMovimientoBanc=1 and Nulo=0 ORDER BY IDMovimiento DESC LIMIT 1),'') AS UltimoCheque from" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on cuentasbancarias.IDBanco=Bancos.IDBanco INNER JOIN" & SysName.Text & "Empleados as Usuarios on CuentasBancarias.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "CtaContable on CuentasBancarias.IDCtaCont=CtaContable.IDCtaCont INNER JOIN Libregco.TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda INNER JOIN" & SysName.Text & "TipoDocumento on CuentasBancarias.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where CuentasBancarias.IDCuenta='" + lblIDCuenta.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "CuentasBancarias")
        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("CuentasBancarias")

        If Me.Owner.Name = frm_registro_cuentasbancarias.Name Then
            frm_registro_cuentasbancarias.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_registro_cuentasbancarias.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_registro_cuentasbancarias.txtNocuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_registro_cuentasbancarias.txtTitular.Text = (Tabla.Rows(0).Item("Titular"))
            frm_registro_cuentasbancarias.txtSucursal.Text = (Tabla.Rows(0).Item("SucursalDirecta"))
            frm_registro_cuentasbancarias.txtOficial.Text = (Tabla.Rows(0).Item("Oficial"))
            frm_registro_cuentasbancarias.txtTelefono.Text = (Tabla.Rows(0).Item("Telefono"))
            frm_registro_cuentasbancarias.txtFechaCreacion.Text = (Tabla.Rows(0).Item("Creacion"))
            frm_registro_cuentasbancarias.txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            frm_registro_cuentasbancarias.txtIDCuentaCont.Text = (Tabla.Rows(0).Item("IDCtaCont"))
            frm_registro_cuentasbancarias.txtIDBanco.Text = (Tabla.Rows(0).Item("IDBanco"))
            frm_registro_cuentasbancarias.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
            frm_registro_cuentasbancarias.txtIDMoneda.Text = (Tabla.Rows(0).Item("IDTipoMoneda"))
            frm_registro_cuentasbancarias.txtMoneda.Text = (Tabla.Rows(0).Item("Moneda"))

            frm_registro_cuentasbancarias.lblCheques.Text = (Tabla.Rows(0).Item("Cheques"))
            frm_registro_cuentasbancarias.txtIDCuentaCont.Text = (Tabla.Rows(0).Item("IDCtaCont"))
            frm_registro_cuentasbancarias.txtDescripcionCta.Text = (Tabla.Rows(0).Item("NombreCuenta"))
            frm_registro_cuentasbancarias.txtCuentaCont.Text = (Tabla.Rows(0).Item("NoCtaContable"))
            frm_registro_cuentasbancarias.txtLimiteReserva.Text = CDbl(Tabla.Rows(0).Item("LimiteReserva")).ToString("C")
            frm_registro_cuentasbancarias.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))

            frm_registro_cuentasbancarias.txtChequeFinal.Text = (Tabla.Rows(0).Item("ChequeActual"))
            frm_registro_cuentasbancarias.txtUltimoBeneficiario.Text = (Tabla.Rows(0).Item("UltimoBeneficiario"))
            frm_registro_cuentasbancarias.txtUltimoCheque.Text = (Tabla.Rows(0).Item("UltimoCheque"))

            If IsNumeric((Tabla.Rows(0).Item("UltimoMonto"))) Then
                frm_registro_cuentasbancarias.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
            End If

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_registro_cuentasbancarias.chkNulo.Checked = True
            Else
                frm_registro_cuentasbancarias.chkNulo.Checked = False
            End If

            If (Tabla.Rows(0).Item("Cheques")) = 1 Then
                frm_registro_cuentasbancarias.chkCheques.Checked = True
            Else
                frm_registro_cuentasbancarias.chkCheques.Checked = False
            End If

        ElseIf Me.Owner.Name = frm_cheques_devueltos.Name Then
            frm_cheques_devueltos.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_cheques_devueltos.txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))
            frm_cheques_devueltos.txtBancoCuenta.Text = (Tabla.Rows(0).Item("Identidad"))

        ElseIf Me.Owner.Name = frm_reporte_cheques_devueltos.Name Then
            frm_reporte_cheques_devueltos.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_reporte_cheques_devueltos.txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))

        ElseIf Me.Owner.Name = frm_reporte_movimientos_bancarios.Name Then
            frm_reporte_movimientos_bancarios.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_reporte_movimientos_bancarios.txtCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))

        ElseIf Me.Owner.Name = frm_reporte_cheques.Name Then
            frm_reporte_cheques.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_reporte_cheques.txtCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))

        ElseIf Me.Owner.Name = frm_consulta_solicitud_cheques.Name Then
            frm_consulta_solicitud_cheques.txtIDCuentaBancaria.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_consulta_solicitud_cheques.txtCuentaBancaria.Text = (Tabla.Rows(0).Item("NoCuenta"))

        ElseIf Me.Owner.Name = frm_reporte_solicitud_cheques.Name Then
            frm_reporte_solicitud_cheques.txtIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            frm_reporte_solicitud_cheques.txtCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))

        End If

        Close()
        Exit Sub

    End Sub
End Class