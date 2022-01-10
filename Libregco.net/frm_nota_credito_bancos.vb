Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_nota_credito_bancos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblchkNulo, lblIDTipoMovimiento, lblIDCuentaBancaria, lblRutaDocumento As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_nota_credito_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtNCFAfectado.Clear()
        txtFechaNCF.Clear()
        txtMontoNCF.Clear()
        cbxCuentaBancaria.Items.Clear()
        txtBanco.Clear()
        dtpFecha.Value = Today
        txtMonto.Clear()
        txtConcepto.Clear()
        txtIDMovimientoBanc.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        lblRutaDocumento.Text = ""
        txtReferencia.Clear()
    End Sub

    Private Sub ActualizarTodo()
        Try
            txtNCF.Visible = False
            lblNCF.Visible = False
            ControlSuperClave = 1
            lblchkNulo.Text = 0
            txtFecha.Text = Today.ToString("yyyy-MM-dd")
            txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
            chkNulo.Checked = False
            HabilitarControles()
            FillCuentaBanc()
            Hora.Enabled = True
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub SetIDCuentaBanc()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT CuentasBancarias.IDCuenta,CuentasBancarias.IDBanco,Bancos.Identidad,SucursalDirecta,Oficial,Titular,TipoMoneda.Texto,CuentasBancarias.Balance,CuentasBancarias.LimiteReserva FROM cuentasbancarias INNER JOIN TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where NoCuenta= '" + cbxCuentaBancaria.SelectedItem + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "cuentasbancarias")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("cuentasbancarias")

        lblIDCuentaBancaria.Text = (Tabla.Rows(0).Item("IDCuenta"))
        txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))

    End Sub

    Private Sub FillCuentaBanc()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT NoCuenta FROM cuentasbancarias Where Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Cuentasbancarias")
        cbxCuentaBancaria.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Cuentasbancarias")

        For Each Fila As DataRow In Tabla.Rows
            cbxCuentaBancaria.Items.Add(Fila.Item("NoCuenta"))
        Next

    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub cbxCuentaBancaria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuentaBancaria.SelectedIndexChanged
        SetIDCuentaBanc()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
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

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try

            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

           
            lblSumaLetra.Text = "LA SUMA DE " & ConvertNumbertoString(txtMonto.Text)


        Catch ex As Exception
            txtMonto.Text = CDbl(0).ToString("C")
            lblSumaLetra.Text = ""
        End Try
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub


    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblchkNulo.Text = 0
            HabilitarControles()
        Else
            lblchkNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub DeshabilitarControles()
        GbMovimiento.Enabled = False
        txtNCF.Enabled = False
        dtpFecha.Enabled = False
        txtMonto.Enabled = False
        txtConcepto.Enabled = False
        chkNulo.Enabled = False
        txtReferencia.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbMovimiento.Enabled = True

        txtNCF.Enabled = True
        dtpFecha.Enabled = True
        txtMonto.Enabled = True
        txtConcepto.Enabled = True
        chkNulo.Enabled = True
        txtReferencia.Enabled = True
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDMovimientoBanc.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir el boucher del movimiento bancario?", "Imprimir Movimiento Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltMovimientoBanc()
        Try

            If txtIDMovimientoBanc.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDMovimiento from MovimientosBanco where IDMovimiento= (Select Max(IDMovimiento) from MovimientosBanco)", Con)
                txtIDMovimientoBanc.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltMovimientoBanc()")
        End Try
    End Sub

    Private Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub


    Private Sub SetSecondID()
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

            sqlQ = "UPDATE movimientosbanco SET SecondID='" + lblSecondID.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=45"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cbxCuentaBancaria.Text = "" Then
            MessageBox.Show("Seleccione el No. de Cuenta de la transacción bancaria.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuentaBancaria.Focus()
            cbxCuentaBancaria.DroppedDown = True
            Exit Sub
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de la transacción bancaria.", "Escribir Monto de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDMovimientoBanc.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nota de crédito  en la cuenta No. " & cbxCuentaBancaria.Text & " en la base de datos?", "Guardar Nuevo Movimiento en Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuentaBancaria.Text + "','" + lblIDTipoMovimiento.Text + "','" + txtReferencia.Text + "','" + dtpFecha.Value.ToString("yyyy-MM-dd") + "','','" + txtMonto.Text + "','0','0','" + txtMonto.Text + "','" + lblSumaLetra.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltMovimientoBanc()
                SetSecondID()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='0',Interes='0',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If cbxCuentaBancaria.Text = "" Then
            MessageBox.Show("Seleccione el No. de Cuenta de la transacción bancaria.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuentaBancaria.Focus()
            cbxCuentaBancaria.DroppedDown = True
            Exit Sub
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de la transacción bancaria.", "Escribir Monto de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDMovimientoBanc.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nota de crédito de la cuenta No. " & cbxCuentaBancaria.Text & " en la base de datos?", "Guardar Nuevo Movimiento en Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuentaBancaria.Text + "','" + lblIDTipoMovimiento.Text + "','" + txtReferencia.Text + "','" + dtpFecha.Value.ToString("yyyy-MM-dd") + "','','" + txtMonto.Text + "','0','0','0','" + lblSumaLetra.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltMovimientoBanc()
                SetSecondID()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='0',Interes='0',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La nota de crédito No. " & txtSecondID.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Mov. Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 81
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='0',Interes='0',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDMovimientoBanc.Text = "" Then
            MessageBox.Show("No hay un registro de movimiento bancario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la nota de crédito No. " & txtSecondID.Text & " del sistema?", "Anular nota de crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 82
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='0',Interes='0',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_mov_bancarios.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click_1(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub
End Class