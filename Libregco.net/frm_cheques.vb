Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cheques
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblchknulo, lblIDCuenta, lblRutaDocumento As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        CheckForm()
    End Sub

    Private Sub CheckForm()
        Try
            If Me.Owner.Name = frm_pago_compras.Name Then
                Dim DsLlenarFormulario As New DataSet
                Dim IDSuplidor As New Label
                IDSuplidor.Text = frm_pago_compras.txtIDSuplidor.Text

                DsLlenarFormulario.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDSuplidor,Suplidor,TipoIdentificacion.Descripcion,TipoIdentificacion.IDTipoIdentificacion,RNC,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero from Libregco.Suplidor INNER JOIN Libregco.tipoidentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Condicion on Suplidor.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto Where IDSuplidor= '" + IDSuplidor.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsLlenarFormulario, "Suplidor")
                ConMixta.Close()

                Dim Tabla As DataTable = DsLlenarFormulario.Tables("Suplidor")

                txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
                txtMonto.Enabled = False
                txtBeneficiario.Enabled = False
                txtMonto.Text = CDbl(frm_pago_compras.txtCheque.Text).ToString("C")
                WriteNumberToText()
                txtConcepto.Text = frm_pago_compras.txtConcepto.Text

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
        FillCuenta()
        lblchknulo.Text = 0
        lblRutaDocumento.Text = ""
        chkNulo.Checked = False
        Hora.Enabled = True
        dtpFechaPago.Value = Today
        HabilitarControles()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub FillCuenta()
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias WHERE Cheques=1 and Nulo=0 ORDER BY IDCuenta ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "CuentasBancarias")
        cbxCuenta.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")

        For Each Fila As DataRow In Tabla.Rows
            cbxCuenta.Items.Add(Fila.Item("NoCuenta"))
        Next

        If Tabla.Rows.Count = 1 Then
            cbxCuenta.SelectedIndex = 0
        End If

    End Sub

    Sub SetIDCuenta()
        If txtIDCheque.Text = "" Then
            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDCuenta,Titular,Balance,Bancos.Identidad,ChequeActual,TipoMoneda.Texto FROM" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco inner join libregco.TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda WHERE CuentasBancarias.Cheques=1 and CuentasBancarias.Nulo=0 and NoCuenta='" + cbxCuenta.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "CuentasBancarias")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")

            lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
            txtBanco.Text = (Tabla.Rows(0).Item("Identidad")) & " --> " & (Tabla.Rows(0).Item("Titular"))
            txtNoCheque.Text = CDbl(Tabla.Rows(0).Item("ChequeActual")) + 1
            txtTipoMoneda.Text = Tabla.Rows(0).Item("Texto")


            If IsNumeric(Tabla.Rows(0).Item("Balance")) Then
                txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            End If

        End If

    End Sub

    Private Sub LimpiarDatos()
        txtIDCheque.Clear()
        txtSecondID.Clear()
        txtBanco.Clear()
        txtBeneficiario.Clear()
        txtBeneficiario.Clear()
        txtBalance.Clear()
        cbxCuenta.Items.Clear()
        txtMonto.Clear()
        txtMontoLetras.Clear()
        txtBeneficiario.Clear()
        txtConcepto.Clear()
        txtNoCheque.Clear()
        txtTipoMoneda.Clear()
    End Sub

    Private Sub cbxCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuenta.SelectedIndexChanged
        SetIDCuenta()
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Friend Sub WriteNumberToText()
        If CDbl(txtMonto.Text) > 0 And IsNumeric(txtMonto.Text) Then
            txtMontoLetras.Text = ConvertNumbertoStringinBank(txtMonto.Text)
        End If
    End Sub
    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try
            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

            WriteNumberToText()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress

        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub HabilitarControles()
        cbxCuenta.Enabled = True
        txtBeneficiario.Enabled = True
        txtMonto.Enabled = True
        txtMontoLetras.Enabled = True
        txtConcepto.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        cbxCuenta.Enabled = False
        txtBeneficiario.Enabled = False
        txtMonto.Enabled = False
        txtMontoLetras.Enabled = False
        txtConcepto.Enabled = False
    End Sub

    Friend Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=45", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE movimientosbanco SET SecondID='" + lblSecondID.Text + "' WHERE IDMovimiento= (" + txtIDCheque.Text + ")"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=45"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de cheque?", "Imprimir Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Friend Sub UltPagoCheque()
        Try

            If txtIDCheque.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDMovimiento from Movimientosbanco where IDMovimiento= (Select Max(IDMovimiento) from Movimientosbanco)", Con)
                txtIDCheque.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Friend Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)

    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblchknulo.Text = 1
            DesHabilitarControles()
        Else
            lblchknulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Friend Sub UpdateLastCheque()

        sqlQ = "UPDATE CuentasBancarias SET ChequeActual='" + txtNoCheque.Text + "' WHERE IDCuenta='" + lblIDCuenta.Text + "'"
        GuardarDatos()

    End Sub

    Private Sub MoverFichero()
        Try
            If TypeConnection.Text = 1 Then
                CreateFolder()   'Verificamos si existe el folder del suplidor

                If lblRutaDocumento.Text = "" Then
                Else
                    'Verifico si existe la carpeta del suplidor
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & cbxCuenta.Text)

                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & cbxCuenta.Text)
                    End If


                    'Verifico si existe el archivo de por anexar
                    Dim ExistsFile As Boolean = System.IO.File.Exists(lblRutaDocumento.Text)

                    If ExistsFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & cbxCuenta.Text & "\" & txtNoCheque.Text & "-" & Today.ToString("yyyyMMdd") & Now.ToString("HHmmss") & ".png"

                        If RutaDestino <> lblRutaDocumento.Text Then
                            My.Computer.FileSystem.MoveFile(lblRutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                        sqlQ = "UPDATE Movimientosbanco SET RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDMovimiento= '" + txtIDCheque.Text + "'"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                        lblRutaDocumento.Text = RutaDestino
                        wFile.Close()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CreateFolder()
        Try
            If TypeConnection.Text = 1 Then
                Dim Exists As Boolean
                Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & cbxCuenta.Text)

                If Exists = True Then
                Else
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & cbxCuenta.Text)

                End If

            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cbxCuenta.Text = "" Then
            MessageBox.Show("Seleccione una cuenta bancaria para procesar el cheque.", "Seleccione la cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuenta.Focus()
            cbxCuenta.DroppedDown = True
            Exit Sub
        ElseIf txtBeneficiario.Text = "" Then
            MessageBox.Show("El beneficiario a procesar se encuentra vacío. Indique el beneficiario para procesar el cheque.", "Especifique el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtBeneficiario.Focus()
            Exit Sub
        ElseIf txtMonto.Text = "" Then
            MessageBox.Show("El monto total del cheque no es válido.", "Especifique el monto del cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar el cheque No. " & txtNoCheque.Text & " al beneficiario " & txtBeneficiario.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + txtNoCheque.Text + "','" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + txtBeneficiario.Text + "','" + txtMonto.Text + "',0,0,'" + txtMonto.Text + "','" + txtMontoLetras.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchknulo.Text + "')"
                GuardarDatos()
                UpdateLastCheque()
                UltPagoCheque()
                SetSecondID()
                MoverFichero()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuenta.Text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DesHabilitarControles()
                ControlSuperClave = 1
                If Me.Owner.Name = frm_pago_compras.Name Then
                    frm_pago_compras.lblChequeNumero.Text = txtNoCheque.Text
                    frm_pago_compras.lblChequeFecha.Text = dtpFechaPago.Value
                    frm_pago_compras.lblChequeBanco.Text = txtBanco.Text
                    frm_pago_compras.lblChequeCuenta.Text = cbxCuenta.Text
                    Me.Close()
                End If
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Movimientosbanco SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuentaBancaria='" + lblIDCuenta.Text + "',NoTransaccion='" + txtNoCheque.Text + "',FechaMovimiento='" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Total='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + Replace(lblRutaDocumento.Text, "\", "\\") + "',Nulo='" + lblchknulo.Text + "' WHERE IDMovimiento= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                MoverFichero()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuenta.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If cbxCuenta.Text = "" Then
            MessageBox.Show("Seleccione una cuenta bancaria para procesar el cheque.", "Seleccione la cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuenta.Focus()
            cbxCuenta.DroppedDown = True
            Exit Sub
        ElseIf txtBeneficiario.Text = "" Then
            MessageBox.Show("El beneficiario a procesar se encuentra vacío. Indique el beneficiario para procesar el cheque.", "Especifique el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtBeneficiario.Focus()
            Exit Sub
        ElseIf txtMonto.Text = "" Then
            MessageBox.Show("El monto total del cheque no es válido.", "Especifique el monto del cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar el cheque No. " & txtNoCheque.Text & " al beneficiario " & txtBeneficiario.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + txtNoCheque.Text + "','" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + txtBeneficiario.Text + "','" + txtMonto.Text + "',0,0,'" + txtMonto.Text + "','" + txtMontoLetras.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchknulo.Text + "')"
                GuardarDatos()
                UltPagoCheque()
                SetSecondID()
                MoverFichero()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuenta.Text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
                ControlSuperClave = 1
                If Me.Owner.Name = frm_pago_compras.Name Then
                    frm_pago_compras.lblChequeNumero.Text = txtNoCheque.Text
                    frm_pago_compras.lblChequeFecha.Text = dtpFechaPago.Value
                    frm_pago_compras.lblChequeBanco.Text = txtBanco.Text
                    frm_pago_compras.lblChequeCuenta.Text = cbxCuenta.Text
                    Me.Close()
                End If
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Movimientosbanco SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuentaBancaria='" + lblIDCuenta.Text + "',NoTransaccion='" + txtNoCheque.Text + "',FechaMovimiento='" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Total='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + Replace(lblRutaDocumento.Text, "\", "\\") + "',Nulo='" + lblchknulo.Text + "' WHERE IDMovimiento= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                MoverFichero()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuenta.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
                ControlSuperClave = 1
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de cheques " & txtSecondID.Text & " de la cuenta bancaria No. " & cbxCuenta.Text & " / " & txtBanco.Text & " con el número de cheque #" & txtNoCheque.Text & " correspondiente al beneficiario " & txtBeneficiario.Text & ", ya está anulada en el sistema. Desea reactivarlo?", "Recuperar Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 7
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Movimientosbanco SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuentaBancaria='" + lblIDCuenta.Text + "',NoTransaccion='" + txtNoCheque.Text + "',FechaMovimiento='" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Total='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + Replace(lblRutaDocumento.Text, "/", "//") + "',Nulo='" + lblchknulo.Text + "' WHERE IDMovimiento= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                MoverFichero()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCheque.Text = "" Then
            MessageBox.Show("No hay un registro cheque para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de cheques no. " & txtSecondID.Text & " correspondiente al cheque # " & txtNoCheque.Text & " del beneficiario " & txtBeneficiario.Text & " del sistema?", "Anular registro de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 8
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Movimientosbanco SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuentaBancaria='" + lblIDCuenta.Text + "',NoTransaccion='" + txtNoCheque.Text + "',FechaMovimiento='" + dtpFechaPago.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Total='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + Replace(lblRutaDocumento.Text, "/", "//") + "',Nulo='" + lblchknulo.Text + "' WHERE IDMovimiento= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                MoverFichero()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub AdjuntarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdjuntarDocumentoToolStripMenuItem.Click
        btnAdjuntarCheque.PerformClick()
    End Sub

    Private Sub btnAdjuntarCheque_Click(sender As Object, e As EventArgs)
        With frm_subir_documento
            .PicDocumento.Width = 459
            .PicDocumento.Height = 530
            .PicDocumento.Location = New Point(0, 0)
        End With

        frm_subir_documento.Show(Me)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_mov_bancarios.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAdjuntarCheque.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = lblRutaDocumento.Text

            If lblRutaDocumento.Text <> "" Then
                If System.IO.File.Exists(lblRutaDocumento.Text) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(lblRutaDocumento.Text, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If
        End If
    End Sub


End Class