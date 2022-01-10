Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_registro_cuentasbancarias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblCheques As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_registro_cuentasbancarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtSecondID.Clear()
        txtIDCuenta.Clear()
        txtNocuenta.Clear()
        txtTitular.Clear()
        txtSucursal.Clear()
        txtTelefono.Clear()
        txtOficial.Clear()
        txtIDCuentaCont.Clear()
        txtCuentaCont.Clear()
        txtUltimoCheque.Clear()
        txtUltimoMonto.Clear()
        txtUltimoBeneficiario.Clear()
        txtChequeFinal.Clear()
        txtBalance.Clear()
        txtIDBanco.Clear()
        txtBanco.Clear()
        txtIDMoneda.Clear()
        txtMoneda.Clear()
        txtIDCuentaCont.Clear()
        txtLimiteReserva.Clear()
        txtNocuenta.Focus()
        txtDescripcionCta.Clear()
        lblNulo.Text = 0
        lblCheques.Text = 0

    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtFechaCreacion.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        chkCheques.Checked = False
        GroupBox1.Enabled = False
        HabilitarControles()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub UltCuentaBancaria()
        Try

            If txtIDCuenta.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDCuenta from CuentasBancarias where IDCuenta= (Select Max(IDCuenta) from CuentasBancarias)", Con)
                txtIDCuenta.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPago")
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtNocuenta.Enabled = True
        txtTitular.Enabled = True
        txtSucursal.Enabled = True
        txtOficial.Enabled = True
        txtTelefono.Enabled = True
        txtTitular.Enabled = True
        txtSucursal.Enabled = True
        txtOficial.Enabled = True
        txtTelefono.Enabled = True
        txtChequeFinal.Enabled = True
        txtLimiteReserva.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtNocuenta.Enabled = False
        txtTitular.Enabled = False
        txtSucursal.Enabled = False
        txtOficial.Enabled = False
        txtTelefono.Enabled = False
        txtTitular.Enabled = False
        txtSucursal.Enabled = False
        txtOficial.Enabled = False
        txtTelefono.Enabled = False
        txtChequeFinal.Enabled = False
        txtLimiteReserva.Enabled = False
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

    Private Sub btn_BuscarCtaContable_Click(sender As Object, e As EventArgs) Handles btn_BuscarCtaContable.Click
        frm_buscar_cuenta_contable.ShowDialog(Me)
    End Sub

    Private Sub chkCheques_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheques.CheckedChanged
        If chkCheques.Checked = True Then
            lblCheques.Text = 1
            GroupBox1.Enabled = True
        Else
            lblCheques.Text = 0
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDBanco.Text = "" Then
            MessageBox.Show("Selecciona el banco comercial de la cuenta bancaria a guardar.", "Seleccionar banco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarBanco.PerformClick()
            Exit Sub
        ElseIf txtIDMoneda.Text = "" Then
            MessageBox.Show("Seleccione el tipo de moneda correspondiente a la cuenta bancaria.", "Seleccionar tipo de moneda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_buscar_moneda.PerformClick()
            Exit Sub
        ElseIf txtIDCuentaCont.Text = "" Then
            MessageBox.Show("Seleccione la cuenta contable correspondiente a la cuenta bancaria.", "Seleccione cuenta contable", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_BuscarCtaContable.PerformClick()
            Exit Sub
        ElseIf txtLimiteReserva.Text = "" Then
            MessageBox.Show("Especifique el monto de reserva de la cuenta de bancaria.", "Monto de reserva de la cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLimiteReserva.Focus()
            Exit Sub
        End If

        If txtIDCuenta.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva cuenta bancaria No. " & txtNocuenta.Text & " del banco " & txtBanco.Text & ",  en la base de datos?", "Guardar Nueva Cuenta Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO CuentasBancarias (IDTipoDocumento,IDUsuario,Creacion,Fecha,Hora,NoCuenta,IDBanco,Titular,SucursalDirecta,Oficial,Telefono,IDCtaCont,Balance,LimiteReserva,IDTipoMoneda,Cheques,ChequeActual,Nulo) VALUES (44,'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFechaCreacion.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "', '" + txtNocuenta.Text + "','" + txtIDBanco.Text + "','" + txtTitular.Text + "','" + txtSucursal.Text + "','" + txtOficial.Text + "','" + txtTelefono.Text + "','" + txtIDCuentaCont.Text + "',0,'" + txtLimiteReserva.Text + "','" + txtIDMoneda.Text + "','" + lblCheques.Text + "','" + txtChequeFinal.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltCuentaBancaria()
                ConvertString()
                SetSecondID()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE CuentasBancarias SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoCuenta='" + txtNocuenta.Text + "',Titular='" + txtTitular.Text + "',SucursalDirecta='" + txtSucursal.Text + "',Oficial='" + txtOficial.Text + "',Telefono='" + txtTelefono.Text + "',LimiteReserva='" + txtLimiteReserva.Text + "',IDCtaCont='" + txtIDCuentaCont.Text + "',IDTipoMoneda='" + txtIDMoneda.Text + "',Cheques='" + lblCheques.Text + "',Nulo='" + lblNulo.Text + "',ChequeActual='" + txtChequeFinal.Text + "' WHERE IDCuenta= (" + txtIDCuenta.Text + ")"
                GuardarDatos()
                ConvertString()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub ConvertDouble()
        txtLimiteReserva.Text = CDbl(txtLimiteReserva.Text)
    End Sub

    Private Sub ConvertString()
        txtLimiteReserva.Text = CDbl(txtLimiteReserva.Text).ToString("C")
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=44", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE CuentasBancarias SET SecondID='" + lblSecondID.Text + "' WHERE IDCuenta= (" + txtIDCuenta.Text + ")"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=44"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cuenta_bancaria.ShowDialog(Me)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de la cuenta bancaria código No. " & txtSecondID.Text & ", número " & txtNocuenta.Text & " de la entidad comercial " & txtBanco.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Cuenta Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 102
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE CuentasBancarias SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoCuenta='" + txtNocuenta.Text + "',Titular='" + txtTitular.Text + "',SucursalDirecta='" + txtSucursal.Text + "',Oficial='" + txtOficial.Text + "',Telefono='" + txtTelefono.Text + "',LimiteReserva='" + txtLimiteReserva.Text + "',IDCtaCont='" + txtIDCuentaCont.Text + "',IDTipoMoneda='" + txtIDMoneda.Text + "',Cheques='" + lblCheques.Text + "',Nulo='" + lblNulo.Text + "',ChequeActual='" + txtChequeFinal.Text + "' WHERE IDCuenta= (" + txtIDCuenta.Text + ")"
                GuardarDatos()
                ConvertString()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCuenta.Text = "" Then
            MessageBox.Show("No hay un registro de cuenta bancaria abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la cuenta bancaria código no. " & txtSecondID.Text & ", número " & txtNocuenta.Text & " de la entidad comercial " & txtBanco.Text & " del sistema?", "Anular Cuenta Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 103
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE CuentasBancarias SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoCuenta='" + txtNocuenta.Text + "',Titular='" + txtTitular.Text + "',SucursalDirecta='" + txtSucursal.Text + "',Oficial='" + txtOficial.Text + "',Telefono='" + txtTelefono.Text + "',LimiteReserva='" + txtLimiteReserva.Text + "',IDCtaCont='" + txtIDCuentaCont.Text + "',IDTipoMoneda='" + txtIDMoneda.Text + "',Cheques='" + lblCheques.Text + "',Nulo='" + lblNulo.Text + "',ChequeActual='" + txtChequeFinal.Text + "' WHERE IDCuenta= (" + txtIDCuenta.Text + ")"
                ConvertString()
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscarBanco_Click(sender As Object, e As EventArgs) Handles btnBuscarBanco.Click
        frm_buscar_bancos.ShowDialog(Me)
    End Sub

    Private Sub btn_buscar_moneda_Click(sender As Object, e As EventArgs) Handles btn_buscar_moneda.Click
        frm_buscar_tipo_moneda.ShowDialog(Me)
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCuenta.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva cuenta bancaria No. " & txtNocuenta.Text & " del banco " & txtBanco.Text & ",  en la base de datos?", "Guardar Nueva Cuenta Bancaria", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO CuentasBancarias (IDTipoDocumento,IDUsuario,Creacion,Fecha,Hora,NoCuenta,IDBanco,Titular,SucursalDirecta,Oficial,Telefono,IDCtaCont,Balance,LimiteReserva,IDTipoMoneda,Cheques,ChequeActual,Nulo) VALUES (44,'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFechaCreacion.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "', '" + txtNocuenta.Text + "','" + txtIDBanco.Text + "','" + txtTitular.Text + "','" + txtSucursal.Text + "','" + txtOficial.Text + "','" + txtTelefono.Text + "','" + txtIDCuentaCont.Text + "',0,'" + txtLimiteReserva.Text + "','" + txtIDMoneda.Text + "','" + lblCheques.Text + "','" + txtChequeFinal.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltCuentaBancaria()
                SetSecondID()
                ConvertString()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE CuentasBancarias SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoCuenta='" + txtNocuenta.Text + "',Titular='" + txtTitular.Text + "',SucursalDirecta='" + txtSucursal.Text + "',Oficial='" + txtOficial.Text + "',Telefono='" + txtTelefono.Text + "',LimiteReserva='" + txtLimiteReserva.Text + "',IDCtaCont='" + txtIDCuentaCont.Text + "',IDTipoMoneda='" + txtIDMoneda.Text + "',Cheques='" + lblCheques.Text + "',Nulo='" + lblNulo.Text + "',ChequeActual='" + txtChequeFinal.Text + "' WHERE IDCuenta= (" + txtIDCuenta.Text + ")"
                GuardarDatos()
                ConvertString()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub txtChequeFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChequeFinal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            'Case 8, 46
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub txtLimiteReserva_Leave(sender As Object, e As EventArgs) Handles txtLimiteReserva.Leave
        If txtLimiteReserva.Text = "" Then
            txtLimiteReserva.Text = CDbl(0).ToString("C")
        Else
            txtLimiteReserva.Text = CDbl(txtLimiteReserva.Text).ToString("C")
        End If
    End Sub

    Private Sub txtLimiteReserva_Enter(sender As Object, e As EventArgs) Handles txtLimiteReserva.Enter
        If txtLimiteReserva.Text = "" Then
        Else
            txtLimiteReserva.Text = CDbl(txtLimiteReserva.Text)
        End If
    End Sub

    Private Sub txtLimiteReserva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteReserva.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub


End Class