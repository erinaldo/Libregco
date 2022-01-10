Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cheques_devueltos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblNulo, lblIDFact, lblIDMovBanc, lblIdentificacion, lblDireccion, lblTelefono As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cheques_devueltos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        SelectUsuario()
        ActualizarTodo()
        Me.CenterToParent()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtFecha.Clear()
        txtHora.Clear()
        txtIDCheque.Clear()
        txtSecondID.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtNoCheque.Clear()
        txtMonto.Clear()
        txtCargo.Clear()
        txtTotal.Clear()
        txtConcepto.Clear()
        txtBancoCuenta.Clear()
        txtIDBancoDevuelve.Clear()
        txtBancoDevuelve.Clear()
        txtIDCuenta.Clear()
        txtCuentaBancaria.Clear()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        lblNulo.Text = 0
        lblIDFact.Text = ""
        lblIDMovBanc.Text = ""
        lblStatusBar.Text = "Listo"
    End Sub

    Private Sub HabilitarControles()
        GbDetalle.Enabled = True
        GbCliente.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GbDetalle.Enabled = False
        GbCliente.Enabled = False
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub


    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Private Sub txtCargo_Enter(sender As Object, e As EventArgs) Handles txtCargo.Enter
        If txtCargo.Text = "" Then
        Else
            txtCargo.Text = CDbl(txtCargo.Text)
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        If txtMonto.Text = "" Then
            txtMonto.Text = CDbl(0).ToString("C")
        Else
            txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        End If
        SumTotal()
    End Sub

    Private Sub txtCargo_Leave(sender As Object, e As EventArgs) Handles txtCargo.Leave
        If txtCargo.Text = "" Then
            txtCargo.Text = CDbl(0).ToString("C")
        Else
            txtCargo.Text = CDbl(txtCargo.Text).ToString("C")
        End If
        SumTotal()
    End Sub

    Private Sub SumTotal()
        If txtMonto.Text = "" Then
            Exit Sub
        ElseIf txtCargo.Text = "" Then
            Exit Sub
        Else
            txtTotal.Text = (CDbl(txtMonto.Text) + CDbl(txtCargo.Text)).ToString("C")
        End If
    End Sub

    Private Sub ConceptoCheque()
        If txtIDCliente.Text = "" Then
            txtConcepto.Text = "CHEQUE DEVUELTO "
        Else
            txtConcepto.Text = "CHEQUE DEVUELTO DE: " & txtNombre.Text.ToUpper & " [" & txtIDCliente.Text & "] "
        End If
        If txtNoCheque.Text = "" Then
        Else
            txtConcepto.Text = "CHEQUE DEVUELTO #" & txtNoCheque.Text & "-->" & txtNombre.Text.ToUpper & " [" & txtIDCliente.Text & "] "
        End If

    End Sub

    Private Sub txtNoCheque_Leave(sender As Object, e As EventArgs) Handles txtNoCheque.Leave
        ConceptoCheque()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
        ConceptoCheque()
    End Sub

    Private Sub txtNoCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoCheque.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCheque.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo del cheque devuelto?", "Imprimir devolución de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
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

    Private Sub txtCargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCargo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
        txtCargo.Text = CDbl(txtCargo.Text)
        txtTotal.Text = CDbl(txtTotal.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        txtCargo.Text = CDbl(txtCargo.Text).ToString("C")
        txtTotal.Text = CDbl(txtTotal.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub UltCheque()
        Try

            If txtIDCheque.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDChequesDevueltos from ChequesDevueltos where IDChequesDevueltos= (Select Max(IDChequesDevueltos) from ChequesDevueltos)", Con)
                txtIDCheque.Text = Convert.ToDouble(cmd.ExecuteScalar)

                cmd = New MySqlCommand("Select SecondID from ChequesDevueltos where IDChequesDevueltos= (Select Max(IDChequesDevueltos) from ChequesDevueltos)", Con)
                txtSecondID.Text = Convert.ToDouble(cmd.ExecuteScalar)

                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub InsertASFact()
        Try
            Dim DiasVencCheque As Integer
            Con.Open()
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=17", Con)
            DiasVencCheque = Convert.ToInt16(cmd.ExecuteScalar)
            Con.Close()

            If txtIDCheque.Text = "" Then
                sqlQ = "INSERT INTO Facturadatos (IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDSucursal,IDAlmacen,IDTipoDocumento,IDCondicion,NCF,NIF,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,DiasCondicion,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Cierre,Observacion,Impreso,Nulo) VALUES ('" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + lblIdentificacion.Text + "','" + lblDireccion.Text + "','" + lblTelefono.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',17,2,'','',1,1,1,1,30,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "',0,1,'" + txtTotal.Text + "',0,'','" + txtTotal.Text + "','" + CDate(Today.AddDays(DiasVencCheque)).ToString("yyyy-MM-dd") + "',0,'','" + txtTotal.Text + "',0,0,0,'" + txtTotal.Text + "',0,'" + txtTotal.Text + "',0,0,'ACTIVA',0,'',0,0)"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                lblIDFact.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()

                sqlQ = "INSERT INTO Transaccion (Fecha,IDTipoDocumento,Efectivo,Cheque,Deposito,Informacion,Credito,IDCredito,ClaseTarjeta,Tarjeta,NoTarjeta,TipoTarjeta,Mes,Año,Banco,NoAprobacion,Recibido,MontoCobrar,Devuelta) Values ('" + Today.ToString("yyyy-MM-dd") + "','17','0','0','0','','0','','','0','','','','','','','0','0','0')"
                GuardarDatos()

                Dim IDTransaccion As New Label
                Con.Open()
                cmd = New MySqlCommand("Select IDTransaccion from Transaccion where IDTransaccion= (Select Max(IDTransaccion) from Transaccion)", Con)
                IDTransaccion.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()


                Dim DsTemp As New DataSet
                Con.Open()
                DsTemp.Clear()
                cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=17", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "TipoDocumento")
                Con.Close()

                Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
                Dim lblSecondID, UltSecuencia As New Label

                lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
                UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

                sqlQ = "UPDATE FacturaDatos SET IDTransaccion='" + IDTransaccion.Text + "',SecondID='" + lblSecondID.Text + "' WHERE IDFacturaDatos='" + lblIDFact.Text + "'"
                GuardarDatos()

                sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=17"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select SecondID from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            Else
                sqlQ = "UPDATE FacturaDatos SET Nulo='" + lblNulo.Text + "' WHERE IDFacturaDatos= (" + lblIDFact.Text + ")"
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CalcularBceCuentaBancaria()
        Try
            Dim Ingresos, Egresos, Total As New Label

            Con.Open()
            cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM movimientosbanco INNER JOIN tipomovbancario on MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN tipofuncion on tipomovbancario.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where TipoMovBancario.IDTipoFuncion=1 and IDCuentaBancaria='" + txtIDCuenta.Text + "' and MovimientosBanco.Nulo=0", Con)
            Ingresos.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM movimientosbanco INNER JOIN tipomovbancario on MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN tipofuncion on tipomovbancario.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where TipoMovBancario.IDTipoFuncion=2 and IDCuentaBancaria='" + txtIDCuenta.Text + "' and MovimientosBanco.Nulo=0", Con)
            Egresos.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            Total.Text = CDbl(Ingresos.Text) - CDbl(Egresos.Text)

            sqlQ = "UPDATE CuentasBancarias SET Balance='" + Total.Text + "' WHERE IDCuenta= '" + txtIDCuenta.Text + "'"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub InsertMovBancario()
        Try
            If txtIDCheque.Text = "" Then
                sqlQ = "INSERT INTO MovimientosBanco (IDCuentaBancaria,IDTipoMovimientoBanc,IDUsuario,Fecha,Hora,FechaMovimiento,Monto,Capital,Interes,Total,Concepto,RutaDocumento,Nulo) VALUES ('" + txtIDCuenta.Text + "',6,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtFecha.Text + "','" + txtTotal.Text + "',0,0,'" + txtMonto.Text + "','" + txtConcepto.Text + "','','" + lblNulo.Text + "')"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select IDMovimiento from MovimientosBanco where IDMovimiento= (Select Max(IDMovimiento) from MovimientosBanco)", Con)
                lblIDMovBanc.Text = Convert.ToInt16(cmd.ExecuteScalar())
                Con.Close()
            Else
                sqlQ = "UPDATE MovimientosBanco Set Monto='" + txtMonto.Text + "',Capital='" + txtMonto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDMovimiento='" + lblIDMovBanc.Text + "'"
                GuardarDatos()
            End If

            CalcularBceCuentaBancaria()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CalcBces()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
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

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("No ha seleccionado el cliente para procesar la devolución del cheque.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtIDCuenta.Text = "" Then
            MessageBox.Show("Seleccione el la cuenta bancaria a la que se depositó el cheque.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDCuenta.Focus()
            Exit Sub
        ElseIf txtNoCheque.Text = "" Then
            MessageBox.Show("Escriba el No. del cheque emitido.", "No. de cheque vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoCheque.Focus()
        ElseIf txtIDBancoDevuelve.Text = "" Then
            MessageBox.Show("Seleccione el banco emisor del cheque.", "Seleccionar Banco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDBancoDevuelve.Focus()
            Exit Sub
        ElseIf txtTotal.Text = "" Or txtTotal.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no ha especificado el monto total de la devolución del cheque.", "No ha aplicado los detalles de la devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea procesar la devolución del cheque No. " & txtNoCheque.Text & " a nombre del cliente: " & txtNombre.Text & " [" & txtIDCliente.Text & "]  en la base de datos?", "Procesar devolución del cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                InsertASFact()
                InsertMovBancario()
                sqlQ = "INSERT INTO ChequesDevueltos (SecondID,IDTipoDocumento,IDSucursal,IDAlmacen,IDFacturaDatos,IDMovimientoBancario,IDUsuario,Fecha,Hora,IDCliente,IDCuentaBancaria,NoCheque,IDBanco,Monto,Cargo,Total,Concepto,Impreso,Nulo) VALUES ('" + GetSecondID(17).ToString + "',17,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDFact.Text + "','" + lblIDMovBanc.Text + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtIDCuenta.Text + "','" + txtNoCheque.Text + "','" + txtIDBancoDevuelve.Text + "','" + txtMonto.Text + "','" + txtCargo.Text + "','" + txtTotal.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCheque()
                CalcBces()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la devolución del cheque?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Chequesdevueltos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDFacturaDatos='" + lblIDFact.Text + "',IDMovimientoBancario='" + lblIDMovBanc.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDCuentaBancaria='" + txtIDCuenta.Text + "',NoCheque='" + txtNoCheque.Text + "',IDBanco='" + txtIDBancoDevuelve.Text + "',Monto='" + txtMonto.Text + "',Cargo='" + txtCargo.Text + "',Total='" + txtTotal.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesDevueltos= (" + txtIDCheque.Text + ")"
                InsertASFact()
                GuardarDatos()
                ConvertCurrent()
                CalcBces()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("No ha seleccionado el cliente para procesar la devolución del cheque.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtIDCuenta.Text = "" Then
            MessageBox.Show("Seleccione el la cuenta bancaria a la que se depositó el cheque.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDCuenta.Focus()
            Exit Sub
        ElseIf txtNoCheque.Text = "" Then
            MessageBox.Show("Escriba el No. del cheque emitido.", "No. de cheque vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoCheque.Focus()
        ElseIf txtIDBancoDevuelve.Text = "" Then
            MessageBox.Show("Seleccione el banco emisor del cheque.", "Seleccionar Banco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDBancoDevuelve.Focus()
            Exit Sub
        ElseIf txtTotal.Text = "" Or txtTotal.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no ha especificado el monto total de la devolución del cheque.", "No ha aplicado los detalles de la devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea procesar la devolución del cheque No. " & txtNoCheque.Text & " a nombre del cliente: " & txtNombre.Text & " [" & txtIDCliente.Text & "]  en la base de datos?", "Procesar devolución del cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                InsertASFact()
                InsertMovBancario()
                sqlQ = "INSERT INTO ChequesDevueltos (SecondID,IDTipoDocumento,IDSucursal,IDAlmacen,IDFacturaDatos,IDMovimientoBancario,IDUsuario,Fecha,Hora,IDCliente,IDCuentaBancaria,NoCheque,IDBanco,Monto,Cargo,Total,Concepto,Impreso,Nulo) VALUES ('" + GetSecondID(17).ToString + "',17,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDFact.Text + "','" + lblIDMovBanc.Text + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtIDCuenta.Text + "','" + txtNoCheque.Text + "','" + txtIDBancoDevuelve.Text + "','" + txtMonto.Text + "','" + txtCargo.Text + "','" + txtTotal.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCheque()
                CalcBces()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la devolución del cheque?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Chequesdevueltos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDFacturaDatos='" + lblIDFact.Text + "',IDMovimientoBancario='" + lblIDMovBanc.Text + "',IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDCuentaBancaria='" + txtIDCuenta.Text + "',NoCheque='" + txtNoCheque.Text + "',IDBanco='" + txtIDBancoDevuelve.Text + "',Monto='" + txtMonto.Text + "',Cargo='" + txtCargo.Text + "',Total='" + txtTotal.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesDevueltos= (" + txtIDCheque.Text + ")"
                InsertASFact()
                GuardarDatos()
                ConvertCurrent()
                CalcBces()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cheques_devueltos.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La devolución del cheque código. " & txtIDCheque.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Registro de devolución del cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Chequesdevueltos SET IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDCuentaBancaria='" + txtIDCuenta.Text + "',NoCheque='" + txtNoCheque.Text + "',IDBanco='" + txtIDBancoDevuelve.Text + "',Monto='" + txtMonto.Text + "',Cargo='" + txtCargo.Text + "',Total='" + txtTotal.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesDevueltos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                sqlQ = "UPDATE FacturaDatos SET Nulo='" + lblNulo.Text + "' WHERE IDFacturaDatos= '" + lblIDFact.Text + "'"
                GuardarDatos()
                sqlQ = "UPDATE MovimientosBanco SET Nulo='" + lblNulo.Text + "' WHERE IDMovimiento= '" + lblIDMovBanc.Text + "'"
                GuardarDatos()
                CalcBces()
                CalcularBceCuentaBancaria()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDCheque.Text = "" Then
            MessageBox.Show("No hay un registro de devolución de cheque abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la devolución del cheque código. " & txtIDCheque.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Devolución de Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Chequesdevueltos SET IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',IDCuentaBancaria='" + txtIDCuenta.Text + "',NoCheque='" + txtNoCheque.Text + "',IDBanco='" + txtIDBancoDevuelve.Text + "',Monto='" + txtMonto.Text + "',Cargo='" + txtCargo.Text + "',Total='" + txtTotal.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesDevueltos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                sqlQ = "UPDATE FacturaDatos SET Nulo='" + lblNulo.Text + "' WHERE IDFacturaDatos= (" + lblIDFact.Text + ")"
                GuardarDatos()
                sqlQ = "UPDATE MovimientosBanco SET Nulo='" + lblNulo.Text + "' WHERE IDMovimiento= '" + lblIDMovBanc.Text + "'"
                GuardarDatos()
                CalcBces()
                CalcularBceCuentaBancaria()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnBuscarCuenta_Click(sender As Object, e As EventArgs) Handles btnBuscarCuenta.Click
        frm_buscar_cuenta_bancaria.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarBanco_Click(sender As Object, e As EventArgs) Handles btnBuscarBanco.Click
        frm_buscar_bancos.ShowDialog(Me)
    End Sub

    Private Sub BuscarCuentaBancariaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCuentaBancariaToolStripMenuItem.Click
        btnBuscarCuenta.PerformClick()
    End Sub

    Private Sub BuscarBancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarBancoToolStripMenuItem.Click
        btnBuscarBanco.PerformClick()
    End Sub
End Class