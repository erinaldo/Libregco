Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cobros_adelantados

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim BtnArts As New DataGridViewButtonColumn
    Friend lblNulo, lblIDUsuario, lblIDTransaccion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cobros_adelantados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGeneral.Clear()
        txtCalificacion.Clear()
        txtUltimoPago.Clear()
        txtCreditoDisponible.Clear()
        txtIDCobro.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtMonto.Clear()
        txtLetra.Clear()
        txtConcepto.Clear()
        txtSecondID.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        ControlSuperClave = 1
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        lblNulo.Text = 0
        ChkNulo.Checked = False
        lblIDTransaccion.Text = ""
        btnBuscarCliente.Focus()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub UltCobroAdelantado()
        Try
            If txtIDCobro.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDCobrosAdelantados from CobrosAdelantados where IDCobrosAdelantados= (Select Max(IDCobrosAdelantados) from CobrosAdelantados)", Con)
                txtIDCobro.Text = Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from CobrosAdelantados where IDCobrosAdelantados= (Select Max(IDCobrosAdelantados) from CobrosAdelantados)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtConcepto.Enabled = True
        txtMonto.Enabled = True
        btnBuscarCliente.Enabled = True
        txtConcepto.Enabled = True
        btnBuscarCliente.Enabled = True
    End Sub


    Private Sub DeshabilitarControles()
        txtConcepto.Enabled = False
        txtMonto.Enabled = False
        btnBuscarCliente.Enabled = False
        txtConcepto.Enabled = False
        btnBuscarCliente.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCobro.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el comprobante de otros ingresos?", "Imprimir Comprobante de Otros Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try
            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
                txtLetra.Clear()
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

        Catch ex As Exception
            txtMonto.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
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

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos1")
            Con.Close()
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
            lblNulo.Text = 1
        Else
            HabilitarControles()
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el nombre del cliente para procesar el cobro adelantado.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del ingreso a procesar.", "Defina el Monto del Cobro Adelantado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del cobro adelantado a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Cobro Adelantado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDCobro.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el cobro adelantado del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " en la base de datos?", "Guardar Cobro Adelantado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO CobrosAdelantados (SecondID,IDTipoDocumento,IDTransaccion,IDSucursal,IDAlmacen,IDEquipo,IDUsuario,Fecha,Hora,IDCliente,Monto,Letra,Concepto,Impreso,Nulo) VALUES ('" + GetSecondID(35).ToString + "',35,'" + lblIDTransaccion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtMonto.Text + "','" + txtLetra.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCobroAdelantado()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la egreso?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE CobrosAdelantados SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Letra='" + txtLetra.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCobrosAdelantados= (" + txtIDCobro.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cobros_adelantados.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de cobros adelantados No." & txtIDCobro.Text & ",del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Cobro Adelantado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 9
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE CobrosAdelantados SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Letra='" + txtLetra.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCobrosAdelantados= (" + txtIDCobro.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDCobro.Text = "" Then
            MessageBox.Show("No hay un registro de cobros adelantados abiertos para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de cobros adelantados No." & txtIDCobro.Text & ", del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " del sistema?", "Anular Otros Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 48
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE CobrosAdelantados SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Letra='" + txtLetra.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCobrosAdelantados= (" + txtIDCobro.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el nombre del cliente para procesar el cobro adelantado.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del ingreso a procesar.", "Defina el Monto del Cobro Adelantado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del cobro adelantado a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Cobro Adelantado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDCobro.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el cobro adelantado del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " en la base de datos?", "Guardar Cobro Adelantado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO CobrosAdelantados (SecondID,IDTipoDocumento,IDTransaccion,IDSucursal,IDAlmacen,IDEquipo,IDUsuario,Fecha,Hora,IDCliente,Monto,Letra,Concepto,Impreso,Nulo) VALUES ('" + GetSecondID(35).ToString + "',35,'" + lblIDTransaccion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtMonto.Text + "','" + txtLetra.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCobroAdelantado()
                DeshabilitarControles()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la egreso?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE CobrosAdelantados SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Letra='" + txtLetra.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCobrosAdelantados= (" + txtIDCobro.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged
        txtLetra.Text = ConvertNumbertoString(txtMonto.Text)
    End Sub
End Class