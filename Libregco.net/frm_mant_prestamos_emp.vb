Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_prestamos_emp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_prestamos_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
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

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub LimpiarDatos()
        txtIDEmpleado.Clear()
        txtSecondID.Clear()
        txtEmpleado.Clear()
        txtCedula.Clear()
        txtBalance.Clear()
        txtIDPrestamo.Clear()
        txtIDTipoPrestamo.Clear()
        txtTipoPrestamo.Clear()
        txtMonto.Clear()
        txtCuota.Clear()
        txtConcepto.clear()
        lblNulo.Text = 0
        txtHora.Clear()

    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        HabilitarControles()
        btnBuscarEmpleado.Focus()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub HabilitarControles()
        btnBuscarEmpleado.Enabled = True
        btnBuscarTipoPrestamo.Enabled = True
        txtMonto.Enabled = True
        txtCuota.Enabled = True
        txtConcepto.Enabled = True
        chkNulo.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        btnBuscarEmpleado.Enabled = False
        btnBuscarTipoPrestamo.Enabled = False
        txtMonto.Enabled = False
        txtCuota.Enabled = False
        txtConcepto.Enabled = False
        chkNulo.Enabled = False
    End Sub

    Private Sub UltPrestamo()
        Try

            If txtIDPrestamo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDPrestamosEmp from prestamosemp where IDPrestamosEmp= (Select Max(IDPrestamosEmp) from prestamosemp)", Con)
                txtIDPrestamo.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPrestamo")
        End Try
    End Sub

    Private Sub ConvertDoubles()
        txtMonto.Text = CDbl(txtMonto.Text)
        txtCuota.Text = CDbl(txtCuota.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        txtCuota.Text = CDbl(txtCuota.Text).ToString("C")
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDPrestamo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el préstamo?", "Imprimir Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Sub FillChk()
        If lblNulo.Text = 0 Then
            chkNulo.Checked = False
        Else
            chkNulo.Checked = True
        End If
    End Sub

    Private Sub btnBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoPrestamo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoPrestamo.Click
        frm_buscar_tipo_prestamos_emp.ShowDialog(Me)
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Private Sub txtCuota_Enter(sender As Object, e As EventArgs) Handles txtCuota.Enter
        If txtCuota.Text = "" Then
        Else
            txtCuota.Text = CDbl(txtCuota.Text)
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        If txtMonto.Text = "" Then
            txtMonto.Text = CDbl(0).ToString("C")
        Else
            txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCuota_Leave(sender As Object, e As EventArgs) Handles txtCuota.Leave
        If txtCuota.Text = "" Then
            txtCuota.Text = CDbl(0).ToString("C")
        Else
            txtCuota.Text = CDbl(txtCuota.Text).ToString("C")
        End If

        If CDbl(txtCuota.Text) > CDbl(txtMonto.Text) Then
            MessageBox.Show("La cuota debe ser menor o igual al monto del préstamo. Por favor revise los datos introducidos.", "Cuota no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCuota.Text = txtMonto.Text
        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarEmpleado.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        btnBuscarTipoPrestamo.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_prestamos_emp.ShowDialog(Me)
    End Sub

    Private Sub BuscarPréstamoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarPréstamoToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=24", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE PrestamosEmp SET SecondID='" + lblSecondID.Text + "' WHERE IDPrestamosEmp='" + txtIDPrestamo.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=24"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDEmpleado.Text = "" Then
            MessageBox.Show("Seleccione el empleado correspondiente al préstamo.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarEmpleado.PerformClick()
            Exit Sub
        ElseIf txtIDTipoPrestamo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarTipoPrestamo.PerformClick()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Or txtMonto.Text = "" Then
            MessageBox.Show("Escriba el monto del préstamo a procesar.", "Monto del préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtCuota.Text = "" Or txtCuota.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de las cuota(s) para descontar el préstamo al empleado.", "Monto de las cuota(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCuota.Focus()
            Exit Sub
        End If

        If txtIDPrestamo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar el nuevo prestamo a nombre de :" & txtEmpleado.Text & "  en la base de datos?", "Guardar Nuevo Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDoubles()
                sqlQ = "INSERT INTO PrestamosEmp (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDEmpleado,IDTipoPrestamo,Monto,Cuota,Concepto,Impreso,Nulo) VALUES (24,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "', '" + txtIDEmpleado.Text + "','" + txtIDTipoPrestamo.Text + "','" + txtMonto.Text + "','" + txtCuota.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltPrestamo()
                SetSecondID()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                CalcMontoCuota()
                ConvertCurrent()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DesHabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el préstamo?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDoubles()
                sqlQ = "UPDATE PrestamosEmp SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDEmpleado='" + txtIDEmpleado.Text + "',IDTipoPrestamo='" + txtIDTipoPrestamo.Text + "',Monto='" + txtMonto.Text + "',Cuota='" + txtCuota.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPrestamosEmp= '" + txtIDPrestamo.Text + "'"
                GuardarDatos()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                ConvertCurrent()
                CalcMontoCuota()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DesHabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub CalcMontoCuota()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT sum(if(prestamosemp.Cuota<=PrestamosEmp.Balance,prestamosemp.Cuota,PrestamosEmp.Balance)) as Cuota FROM prestamosemp where Balance>0 and IDEmpleado='" + txtIDEmpleado.Text + "'", Con)
            Dim Cuota As New Label
            Cuota.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            sqlQ = "UPDATE Empleados SET CuotaPrestamo='" + Cuota.Text + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
            GuardarDatos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDEmpleado.Text = "" Then
            MessageBox.Show("Seleccione el empleado correspondiente al préstamo.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarEmpleado.PerformClick()
            Exit Sub
        ElseIf txtIDTipoPrestamo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarTipoPrestamo.PerformClick()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Or txtMonto.Text = "" Then
            MessageBox.Show("Escriba el monto del préstamo a procesar.", "Monto del préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtCuota.Text = "" Or txtCuota.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de las cuota(s) para descontar el préstamo al empleado.", "Monto de las cuota(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCuota.Focus()
            Exit Sub
        End If
        If txtIDPrestamo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar el nuevo prestamo a nombre de :" & txtEmpleado.Text & "  en la base de datos?", "Guardar Nuevo Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDoubles()
                sqlQ = "INSERT INTO PrestamosEmp (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDEmpleado,IDTipoPrestamo,Monto,Cuota,Concepto,Impreso,Nulo) VALUES (24,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "', '" + txtIDEmpleado.Text + "','" + txtIDTipoPrestamo.Text + "','" + txtMonto.Text + "','" + txtCuota.Text + "','" + txtConcepto.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltPrestamo()
                SetSecondID()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                CalcMontoCuota()
                ConvertCurrent()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el préstamo?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDoubles()
                sqlQ = "UPDATE PrestamosEmp SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDEmpleado='" + txtIDEmpleado.Text + "',IDTipoPrestamo='" + txtIDTipoPrestamo.Text + "',Monto='" + txtMonto.Text + "',Cuota='" + txtCuota.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPrestamosEmp= '" + txtIDPrestamo.Text + "'"
                GuardarDatos()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                ConvertCurrent()
                CalcMontoCuota()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DesHabilitarControles()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If txtIDEmpleado.Text = "" Then
            MessageBox.Show("Seleccione el empleado correspondiente al préstamo.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarEmpleado.PerformClick()
            Exit Sub
        ElseIf txtIDTipoPrestamo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarTipoPrestamo.PerformClick()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Or txtMonto.Text = "" Then
            MessageBox.Show("Escriba el monto del préstamo a procesar.", "Monto del préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtCuota.Text = 0 Or txtCuota.Text = "" Then
            MessageBox.Show("Escriba la cantidad de cuota(s) para descontar el préstamo al empleado.", "Cantidad de cuota(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCuota.Focus()
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro del préstamo código No. " & txtIDPrestamo.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 65
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                ConvertDoubles()
                sqlQ = "UPDATE PrestamosEmp SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',IDTipoPrestamo='" + txtIDTipoPrestamo.Text + "',Monto='" + txtMonto.Text + "',Cuota='" + txtCuota.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPrestamosEmp= '" + txtIDPrestamo.Text + "'"
                GuardarDatos()
                ConvertCurrent()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDPrestamo.Text = "" Then
            MessageBox.Show("No hay un registro de préstamo abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el préstamo código no. " & txtIDPrestamo.Text & " del sistema?", "Anular Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 66
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDoubles()
                sqlQ = "UPDATE PrestamosEmp SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',IDTipoPrestamo='" + txtIDTipoPrestamo.Text + "',Monto='" + txtMonto.Text + "',Cuota='" + txtCuota.Text + "',Concepto='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPrestamosEmp= '" + txtIDPrestamo.Text + "'"
                GuardarDatos()
                ConvertCurrent()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

End Class