Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_forma_pago_cxp
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_cambiar_ncf_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        If Me.Owner.Name = frm_pago_compras.Name Then
            FillCuenta()
            txtEfectivo.Text = frm_pago_compras.txtEfectivo.Text
            txtCheque.Text = frm_pago_compras.txtCheque.Text
            txtTransferencia.Text = frm_pago_compras.txtTransferencia.Text
            lblNombreSuplidor.Text = frm_pago_compras.txtSuplidor.Text.ToUpper

            If CDbl(txtCheque.Text) > 0 Then
                Dim DsLlenarFormulario As New DataSet

                DsLlenarFormulario.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDSuplidor,Suplidor,TipoIdentificacion.Descripcion,TipoIdentificacion.IDTipoIdentificacion,RNC,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero from Libregco.Suplidor INNER JOIN Libregco.tipoidentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Condicion on Suplidor.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto Where IDSuplidor= '" + frm_pago_compras.txtIDSuplidor.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsLlenarFormulario, "Suplidor")
                ConMixta.Close()

                Dim Tabla As DataTable = DsLlenarFormulario.Tables("Suplidor")

                txtBeneficiario.Text = Tabla.Rows(0).Item("Beneficiario")
            End If
        End If
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        If CDbl(txtCheque.Text) > 0 Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Seleccione la cuenta bancaria que desea utilizar para realizar el cheque.", "Seleccionar cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuenta.Focus()
                cbxCuenta.DroppedDown = True
                Exit Sub

            ElseIf txtNoCheque.Text = "" Then
                MessageBox.Show("No se ha especificado el número de cheque.", "Escriba el No. de Cheque", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNoCheque.Focus()
                Exit Sub

            ElseIf txtBeneficiario.Text = "" Then
                MessageBox.Show("Escriba el nombre del beneficiario al que desea generar el cheque.", "Nombre del beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBeneficiario.Focus()
                Exit Sub

            End If
        End If

        If CDbl(txtTransferencia.Text) > 0 Then
            If cbxCuenta.Text = "" Then
                MessageBox.Show("Seleccione la cuenta bancaria que desea utilizar para realizar el cheque.", "Seleccionar cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information)
                cbxCuentaTransferencia.Focus()
                cbxCuentaTransferencia.DroppedDown = True
                Exit Sub
            End If
        End If

        ConMixta.Open()

        ConvertDouble()

        sqlQ = "INSERT INTO" & SysName.Text & "Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + Today.ToString("yyyy-MM-dd") + "','" + Now.ToString("HH:mm:ss") + "','" + cbxCuenta.Tag.ToString + "','1','" + txtNoCheque.Text + "','" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + txtBeneficiario.Text + "','" + txtCheque.Text + "',0,0,'" + txtCheque.Text + "','" + ConvertNumbertoStringinBank(txtCheque.Text).ToString + "','','" + frm_pago_compras.txtConcepto.Text + "','',0)"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        cmd = New MySqlCommand("Select IDMovimiento from" & SysName.Text & "Movimientosbanco where IDMovimiento= (Select Max(IDMovimiento) from" & SysName.Text & "Movimientosbanco)", ConMixta)
        Dim IDMovimiento As String = Convert.ToString(cmd.ExecuteScalar())

        Dim DsTemp As New DataSet
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "TipoDocumento WHERE IDTipoDocumento=45", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "TipoDocumento")

        Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
        Dim lblSecondID, UltSecuencia As New Label

        lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
        UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

        sqlQ = "UPDATE" & SysName.Text & "movimientosbanco SET SecondID='" + lblSecondID.Text + "' WHERE IDMovimiento= (" + IDMovimiento + ")"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        sqlQ = "UPDATE" & SysName.Text & "TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=45"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        'Insertando transferencia
        sqlQ = "INSERT INTO" & SysName.Text & "Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + Today.ToString("yyyy-MM-dd") + "','" + Now.ToString("HH:mm:ss") + "','" + cbxCuentaTransferencia.Tag.ToString + "','8','" + txtReferenciaTransferencia.Text + "','" + Today.ToString("yyyy-MM-dd") + "','','" + txtTransferencia.Text + "','0','0','" + txtTransferencia.Text + "','" + ConvertNumbertoStringinBank(txtTransferencia.Text).ToString + "','','" + frm_pago_compras.txtConcepto.Text + "','','0')"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        cmd = New MySqlCommand("Select IDMovimiento from" & SysName.Text & "Movimientosbanco where IDMovimiento= (Select Max(IDMovimiento) from" & SysName.Text & "Movimientosbanco)", ConMixta)
        IDMovimiento = Convert.ToString(cmd.ExecuteScalar())

        Dim DsP As New DataSet
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "TipoDocumento WHERE IDTipoDocumento=45", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsP, "TipoDocumento")
        Tabla.Rows.Clear()

        Tabla = DsP.Tables("TipoDocumento")
        lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
        UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

        sqlQ = "UPDATE" & SysName.Text & "movimientosbanco SET SecondID='" + lblSecondID.Text + "' WHERE IDMovimiento= (" + IDMovimiento + ")"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        sqlQ = "UPDATE" & SysName.Text & "TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=45"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()

        ConMixta.Close()

        CalcularBceCuentaBancaria(cbxCuenta.Tag)

        frm_pago_compras.lblTransferenciaBanco.Text = lblBancoTransferencia.Text
        frm_pago_compras.lblTransferenciaCuenta.Text = cbxCuentaTransferencia.Text
        frm_pago_compras.lblTransferenciaReferencia.Text = txtReferenciaTransferencia.Text
        frm_pago_compras.lblChequeNumero.Text = txtNoCheque.Text
        frm_pago_compras.lblChequeFecha.Text = dtpFechaPago.Value
        frm_pago_compras.lblChequeBanco.Text = lblBancoCheque.Text
        frm_pago_compras.lblChequeCuenta.Text = cbxCuenta.Text

        ConvertCurrent()

        MessageBox.Show("Se han realizado satisfactoriamente las operaciones.", "La operación ha finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ControlSuperClave = 1

        Close()
    End Sub

    Private Sub ConvertDouble()
        txtCheque.Text = CDbl(txtCheque.Text)
        txtEfectivo.Text = CDbl(txtEfectivo.Text)
        txtTransferencia.Text = CDbl(txtTransferencia.Text)

    End Sub

    Private Sub ConvertCurrent()
        txtCheque.Text = CDbl(txtCheque.Text).ToString("C")
        txtEfectivo.Text = CDbl(txtEfectivo.Text).ToString("C")
        txtTransferencia.Text = CDbl(txtTransferencia.Text).ToString("C")

    End Sub
    Private Sub FillCuenta()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias WHERE Cheques=1 and Nulo=0 ORDER BY IDCuenta ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "CuentasBancarias")
        cbxCuenta.Items.Clear()
        cbxCuentaTransferencia.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("CuentasBancarias")

        For Each Fila As DataRow In Tabla.Rows
            cbxCuenta.Items.Add(Fila.Item("NoCuenta"))
            cbxCuentaTransferencia.Items.Add(Fila.Item("NoCuenta"))
        Next

        If Tabla.Rows.Count = 1 Then
            cbxCuenta.SelectedIndex = 0
            cbxCuentaTransferencia.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub cbxCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuenta.SelectedIndexChanged
        SetIDCuenta()
    End Sub

    Sub SetIDCuenta()
        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCuenta,Titular,Balance,Bancos.Identidad,ChequeActual,TipoMoneda.Texto FROM" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco inner join libregco.TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda WHERE CuentasBancarias.Cheques=1 and CuentasBancarias.Nulo=0 and NoCuenta='" + cbxCuenta.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "CuentasBancarias")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")
       
        cbxCuenta.Tag = (Tabla.Rows(0).Item("IDCuenta"))
        txtNoCheque.Text = CDbl(Tabla.Rows(0).Item("ChequeActual")) + 1
        lblBancoCheque.Text = Tabla.Rows(0).Item("Identidad").ToString.ToUpper
    End Sub

    Private Sub cbxCuentaTransferencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuentaTransferencia.SelectedIndexChanged
        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCuenta,Titular,Balance,Bancos.Identidad,ChequeActual,TipoMoneda.Texto FROM" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco inner join libregco.TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda WHERE CuentasBancarias.Cheques=1 and CuentasBancarias.Nulo=0 and NoCuenta='" + cbxCuentaTransferencia.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "CuentasBancarias")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")

        cbxCuentaTransferencia.Tag = (Tabla.Rows(0).Item("IDCuenta"))
        lblBancoTransferencia.Text = Tabla.Rows(0).Item("Identidad").ToString.ToUpper

    End Sub

  
End Class