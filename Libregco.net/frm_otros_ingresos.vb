Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_otros_ingresos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim BtnArts As New DataGridViewButtonColumn
    Friend lblNulo, lblIDUsuario, lblIDTransaccion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_otros_ingresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
        CargarLibregco()
    End Sub

    Private Sub LimpiarDatos()
        txtIDIngreso.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGeneral.Clear()
        txtCreditoDisponible.Clear()
        txtCalificacion.Clear()
        txtUltimoPago.Clear()
        txtMonto.Clear()
        txtReferencia.Clear()
        txtConcepto.Clear()
        txtSecondID.Clear()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        ControlSuperClave = 1
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        lblNulo.Text = ""
        lblIDTransaccion.Text = ""
        ChkNulo.Checked = False
        lblNulo.Text = 0
        btnBuscarCliente.Focus()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
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
        btnBuscarCliente.Enabled = True
        txtMonto.Enabled = True
        txtReferencia.Enabled = True
        txtConcepto.Enabled = True
        btnBuscarCliente.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        btnBuscarCliente.Enabled = False
        txtMonto.Enabled = False
        txtReferencia.Enabled = False
        txtConcepto.Enabled = False
        btnBuscarCliente.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDIngreso.Text = "" Then
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

    Private Sub UltIngreso()
        Try
            If txtIDIngreso.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDOtrosIngresos from OtrosIngresos where IDOtrosIngresos= (Select Max(IDOtrosIngresos) from OtrosIngresos)", Con)
                txtIDIngreso.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

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
            MessageBox.Show("Seleccione el cliente a cual se le procesará el ingreso.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del ingreso a procesar.", "Defina el Monto del Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del ingreso a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDIngreso.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el ingreso del tipo [Otros Ingresos] del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & ", en la base de datos?", "Guardar Nuevo Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "INSERT INTO OtrosIngresos (IDSucursal,IDAlmacen,IDEquipo,IDTipoDocumento,IDTransaccion,IDUsuario,Fecha,Hora,IDCliente,Monto,Referencia,Concepto,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',16,'" + lblIDTransaccion.Text + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtMonto.Text + "','" + txtReferencia.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltIngreso()
                SetSecondID()
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
                sqlQ = "UPDATE OtrosIngresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDOtrosIngresos= (" + txtIDIngreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_otros_ingresos.ShowDialog(Me)
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=16", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE OtrosIngresos SET SecondID='" + lblSecondID.Text + "' WHERE IDOtrosIngresos='" + txtIDIngreso.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=16"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de [Otros Ingresos] No." & txtIDIngreso.Text & ",del cliente: " & txtIDCliente.Text & " " & txtNombre.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Otros Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 89
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE OtrosIngresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDOtrosIngresos= (" + txtIDIngreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDIngreso.Text = "" Then
            MessageBox.Show("No hay un registro de otros ingresos abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de [Otros Ingresos] No." & txtIDIngreso.Text & ", del cliente: " & txtIDCliente.Text & " " & txtNombre.Text & " del sistema?", "Anular Otros Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 90
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE OtrosIngresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDOtrosIngresos= (" + txtIDIngreso.Text + ")"
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
            MessageBox.Show("Seleccione el cliente a cual se le procesará el ingreso.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del ingreso a procesar.", "Defina el Monto del Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del ingreso a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDIngreso.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el ingreso del tipo [Otros Ingresos] del cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & ", en la base de datos?", "Guardar Nuevo Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "INSERT INTO OtrosIngresos (IDSucursal,IDAlmacen,IDTipoDocumento,IDTransaccion,IDUsuario,Fecha,Hora,IDCliente,Monto,Referencia,Concepto,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',16,'" + lblIDTransaccion.Text + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtMonto.Text + "','" + txtReferencia.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltIngreso()
                SetSecondID()
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
                sqlQ = "UPDATE OtrosIngresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDOtrosIngresos= (" + txtIDIngreso.Text + ")"
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

End Class