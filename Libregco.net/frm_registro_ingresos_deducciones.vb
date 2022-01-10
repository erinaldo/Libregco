Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_registro_ingresos_deducciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDDeduccion, lblIDDedProc, TypeFunction, lblNulo As New Label
    Dim Permisos As New ArrayList


    Private Sub frm_registro_ingresos_deducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        txtFechaPago.Text = Today.ToString("yyyy-MM-dd")
        dtpFecha.Value = Today
        txtMonto.Text = CDbl(0).ToString("C")
        lblIDDeduccion.Text = ""
        TypeFunction.Text = ""
        lblIDDedProc.Text = ""
        lblNulo.Text = 0
        chkNulo.Checked = False
        btnEliminar.Visible = False
        btnConsultarDeducciones.Visible = False
    End Sub

    Private Sub LimpiarTodo()
        txtIDEmpleado.Clear()
        txtEmpleado.Clear()
        cbxDeducciones.Items.Clear()
        txtDescripcion.Clear()
        DgvDeducciones.Rows.Clear()
        txtIDDeduccionProc.Clear()
        txtSecondID.Clear()
        txtFechaPago.Clear()
        txtHora.Clear()
    End Sub

    Private Sub txtIDEmpleado_Leave(sender As Object, e As EventArgs) Handles txtIDEmpleado.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDEmpleado.Text + "'", Con)
        txtEmpleado.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If txtEmpleado.Text = "" Then
            txtIDEmpleado.Clear()
        Else
            FillDeducciones()
        End If
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub FillDeducciones()
        Try
            If cbxDeducciones.Items.Count = 0 Then
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT Descripcion FROM deduccionesempleados INNER JOIN Deducciones on DeduccionesEmpleados.IDDeduccion=Deducciones.IDDeduccion Where DeduccionesEmpleados.IDEmpleado='" + txtIDEmpleado.Text + "' and Activado=1 ORDER BY Descripcion ASC", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Deducciones")
                cbxDeducciones.Items.Clear()
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Deducciones")
                For Each Fila As DataRow In Tabla.Rows
                    cbxDeducciones.Items.Add(Fila.Item("Descripcion"))
                Next

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron deducciones o ingresos hábiles para este empleado en la base de datos." & vbNewLine & vbNewLine & "Por favor active deducciones e ingresos en Nómina/Archivos/Empleados [Mant. de Empleados].", "No se encontraron deducciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                ElseIf Tabla.Rows.Count = 1 Then
                    cbxDeducciones.SelectedIndex = 0
                    cbxDeducciones.Focus()
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub btnAnexar_Click(sender As Object, e As EventArgs) Handles btnAnexar.Click
        Try
            If txtIDEmpleado.Text = "" Then
                MessageBox.Show("Seleccione un empleado para la búsqueda de deducciones o ingresos para procesos de nómina.", "Seleccione el empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnEmpleado.PerformClick()
                Exit Sub
            ElseIf cbxDeducciones.Text = "" Then
                MessageBox.Show("Seleccione una deducción o ingreso para el proceso de registro.", "Seleccione el tipo de ingreso o deducción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cbxDeducciones.Focus()
                cbxDeducciones.DroppedDown = True
                Exit Sub
            ElseIf txtMonto.Text = 0 Or txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
                If TypeFunction.Text = "+" Then
                    MessageBox.Show("Escriba el monto a procesar del ingreso del tipo [" & cbxDeducciones.Text & "].", "Escribir monto del ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtMonto.Focus()
                    Exit Sub
                ElseIf TypeFunction.Text = "-" Then
                    MessageBox.Show("Escriba el monto a procesar de la deducción del tipo [" & cbxDeducciones.Text & "].", "Escribir monto de la deducción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtMonto.Focus()
                    Exit Sub
                End If
            End If

            DgvDeducciones.Rows.Add(lblIDDedProc.Text, txtIDEmpleado.Text, txtEmpleado.Text, dtpFecha.Text, lblIDDeduccion.Text, cbxDeducciones.Text, txtDescripcion.Text, CDbl(txtMonto.Text).ToString("C"), TypeFunction.Text)

            dtpFecha.Value = Today
            txtMonto.Text = CDbl(0).ToString("C")
            lblIDDeduccion.Text = ""
            TypeFunction.Text = ""
            lblIDDedProc.Text = ""
            txtIDEmpleado.Clear()
            txtEmpleado.Clear()
            cbxDeducciones.Items.Clear()
            txtDescripcion.Clear()
            SetGridColors()
            DgvDeducciones.ClearSelection()
            txtIDEmpleado.Focus()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridColors()
        For Each row As DataGridViewRow In DgvDeducciones.Rows
            If row.Cells(8).Value = "+" Then
                row.DefaultCellStyle.ForeColor = Color.Blue
            ElseIf row.Cells(8).Value = "-" Then
                row.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub cbxDeducciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDeducciones.SelectedIndexChanged
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("Select IDDeduccion from Deducciones Where Descripcion= '" + cbxDeducciones.Text + "'", Con)
        lblIDDeduccion.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Funcion FROM Deducciones INNER JOIN tipofuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where IDDeduccion= '" + lblIDDeduccion.Text + "'", Con)
        TypeFunction.Text = Convert.ToString(cmd.ExecuteScalar())

        If lblIDDeduccion.Text = 3 Then
            btnConsultarDeducciones.Visible = True
            btnConsultarDeducciones.Text = "Consultar " & cbxDeducciones.Text.ToLower
        Else
            btnConsultarDeducciones.Visible = False
            btnConsultarDeducciones.Text = ""
        End If

        Con.Close()
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        If txtMonto.Text = "" Then
            txtMonto.Text = (0).ToString("C")
        Else
            txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
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

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Private Sub DgvDeducciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDeducciones.CellDoubleClick
        Try
            ModificarRowDgv()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModificarRowDgv()
        If DgvDeducciones.Rows.Count = 0 Then
            MessageBox.Show("No hay ingresos y/o deducciones anexadas en el registro para modificar.", "No hay filas para modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            lblIDDedProc.Text = DgvDeducciones.CurrentRow.Cells(0).Value
            txtIDEmpleado.Text = DgvDeducciones.CurrentRow.Cells(1).Value
            txtEmpleado.Text = DgvDeducciones.CurrentRow.Cells(2).Value

            FillDeducciones()

            cbxDeducciones.Text = DgvDeducciones.CurrentRow.Cells(5).Value
            lblIDDeduccion.Text = DgvDeducciones.CurrentRow.Cells(4).Value
            dtpFecha.Value = DgvDeducciones.CurrentRow.Cells(3).Value
            txtMonto.Text = DgvDeducciones.CurrentRow.Cells(7).Value
            txtDescripcion.Text = DgvDeducciones.CurrentRow.Cells(6).Value
            TypeFunction.Text = DgvDeducciones.CurrentRow.Cells(8).Value

            If cbxDeducciones.Text = "" Then
                cbxDeducciones.Items.Add(DgvDeducciones.CurrentRow.Cells(5).Value)
                cbxDeducciones.Text = DgvDeducciones.CurrentRow.Cells(5).Value
            End If

            If lblIDDedProc.Text = "" Then
                btnEliminar.Visible = False
            Else
                btnEliminar.Visible = True
            End If

            DgvDeducciones.Rows.Remove(DgvDeducciones.CurrentRow)


        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ModificarRowDgv()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If DgvDeducciones.Rows.Count = 0 Then
                MessageBox.Show("Anexe al menos una deducción o ingreso para guardar el proceso.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDDeduccionProc.Text = "" Then 'Si no hay un cliente seleccionado
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el registro de deducciones e ingresos procesadas?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "INSERT INTO DeduccionesProcesadas (IDUsuario,IDTipoDocumento,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',43,'" + txtFechaPago.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',0,0)"
                    GuardarDatos()
                    UltDeduccionProcesada()
                    SetSecondID()
                    GuardarDeducciones()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "UPDATE DeduccionesProcesadas SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Fecha='" + txtFechaPago.Text + "',Hora='" + txtHora.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDeduccionesProcesadas= '" + txtIDDeduccionProc.Text + "'"
                    GuardarDatos()
                    GuardarDeducciones()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " btnGuardar_Click")
        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=43", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE DeduccionesProcesadas SET SecondID='" + txtSecondID.Text + "' WHERE IDeduccionesProcesadas= '" + txtIDDeduccionProc.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=43"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarDeducciones()
        Try
            Dim lblIDDedProcDetalle, lblIDEmpleadoDetalle, lblIDDeduccionDetalle, lblFechaDetalle, lblDescripcionDetalle, lblMontoDetalle As New Label

            For Each row As DataGridViewRow In DgvDeducciones.Rows
                lblIDDedProcDetalle.Text = row.Cells(0).Value
                lblIDEmpleadoDetalle.Text = row.Cells(1).Value
                lblFechaDetalle.Text = CDate(row.Cells(3).Value).ToString("yyyy-MM-dd")
                lblIDDeduccionDetalle.Text = row.Cells(4).Value
                lblDescripcionDetalle.Text = row.Cells(6).Value
                lblMontoDetalle.Text = CDbl(row.Cells(7).Value)

                If lblIDDedProcDetalle.Text = "" Then
                    sqlQ = "INSERT INTO deduccionesprocdetalle (IDDeduccionProcesada,IDEmpleado,IDDeduccion,Fecha,Descripcion,Monto) VALUES ('" + txtIDDeduccionProc.Text + "','" + lblIDEmpleadoDetalle.Text + "','" + lblIDDeduccionDetalle.Text + "','" + lblFechaDetalle.Text + "','" + lblDescripcionDetalle.Text + "','" + lblMontoDetalle.Text + "')"
                    GuardarDatos()
                Else
                    sqlQ = "UPDATE  deduccionesprocdetalle Set IDDeduccionProcesada='" + txtIDDeduccionProc.Text + "',IDEmpleado='" + lblIDEmpleadoDetalle.Text + "',IDDeduccion='" + lblIDDeduccionDetalle.Text + "',Fecha='" + lblFechaDetalle.Text + "',Descripcion='" + lblDescripcionDetalle.Text + "',Monto='" + lblMontoDetalle.Text + "' where IDDeduccionesProcDetalle='" + lblIDDedProcDetalle.Text + "'"
                    GuardarDatos()
                End If
            Next

            RefrescarDeducciones()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarDeducciones()
        Try
            DgvDeducciones.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDDeduccionesProcDetalle,deduccionesprocdetalle.IDEmpleado,Empleados.Nombre,deduccionesprocdetalle.Fecha,deduccionesprocdetalle.IDDeduccion,Deducciones.Descripcion as Deduccion,deduccionesprocdetalle.Descripcion,deduccionesprocdetalle.Monto,tipofuncion.Funcion FROM deduccionesprocdetalle INNER JOIN Empleados on DeduccionesProcDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion WHERE IDDeduccionProcesada='" + txtIDDeduccionProc.Text + "'", Con)
            Dim LectorDeduccion As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorDeduccion.Read
                DgvDeducciones.Rows.Add(LectorDeduccion.GetValue(0), LectorDeduccion.GetValue(1), LectorDeduccion.GetValue(2), CDate(LectorDeduccion.GetValue(3)).ToString("dd/MM/yyyy"), LectorDeduccion.GetValue(4), LectorDeduccion.GetValue(5), LectorDeduccion.GetValue(6), CDbl(LectorDeduccion.GetValue(7)).ToString("C"), LectorDeduccion.GetValue(8))
            End While
            LectorDeduccion.Close()
            Con.Close()

            SetGridColors()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " RefrescarTablaFacturas")
        End Try

    End Sub

    Private Sub UltDeduccionProcesada()
        Try
            If txtIDDeduccionProc.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDeduccionesProcesadas from DeduccionesProcesadas where IDeduccionesProcesadas= (Select Max(IDeduccionesProcesadas) from DeduccionesProcesadas)", Con)
                txtIDDeduccionProc.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltEmpleado")
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " GuardarDatos")
        End Try

    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If chkNulo.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El grupo de deducciones e ingresos No. " & txtSecondID.Text & "  ya está desactivado del sistema. Desea volver a activarlo.", "Activar Grupo de deducciones e ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    chkNulo.Checked = False
                    sqlQ = "UPDATE DeduccionesProcesadas SET Fecha='" + txtFechaPago.Text + "',Hora='" + txtHora.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDeduccionesProcesadas= '" + txtIDDeduccionProc.Text + "'"
                    GuardarDatos()
                    GuardarDeducciones()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            ElseIf txtIDDeduccionProc.Text = "" Then
                MessageBox.Show("No hay un registro de grupo de deducciones e ingresos abierto para desactivar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el grupo de deducciones e ingresos No. " & txtSecondID.Text & " del sistema?", "Desactivar grupo de deducciones e ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkNulo.Checked = True
                    sqlQ = "UPDATE DeduccionesProcesadas SET Fecha='" + txtFechaPago.Text + "',Hora='" + txtHora.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDeduccionesProcesadas= '" + txtIDDeduccionProc.Text + "'"
                    GuardarDatos()
                    GuardarDeducciones()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " btnEliminar_Click")
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub DeshabilitarControles()
        GroupBox1.Enabled = False
        btnAnexar.Enabled = False
        btnModificar.Enabled = False
        DgvDeducciones.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GroupBox1.Enabled = True
        btnAnexar.Enabled = True
        btnModificar.Enabled = True
        DgvDeducciones.Enabled = True
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDDeduccionProc.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el grupo de ingresos y deducciones?", "Imprimir Ingresos y deducciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        Try
            If DgvDeducciones.Rows.Count = 0 Then
                MessageBox.Show("Anexe al menos una deducción o ingreso para guardar el proceso.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDDeduccionProc.Text = "" Then 'Si no hay un cliente seleccionado
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el registro de deducciones e ingresos procesadas?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "INSERT INTO DeduccionesProcesadas (IDUsuario,IDTipoDocumento,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,Impreso,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',43,'" + txtFechaPago.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',0,0)"
                    GuardarDatos()
                    UltDeduccionProcesada()
                    SetSecondID()
                    GuardarDeducciones()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    LimpiarTodo()
                    ActualizarTodo()
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "UPDATE DeduccionesProcesadas SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Fecha='" + txtFechaPago.Text + "',Hora='" + txtHora.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDeduccionesProcesadas= '" + txtIDDeduccionProc.Text + "'"
                    GuardarDatos()
                    GuardarDeducciones()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    LimpiarTodo()
                    ActualizarTodo()
                End If
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " btnGuardar_Click")
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_grupo_ingreso_deducciones.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub AnexarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnexarToolStripMenuItem.Click
        btnAnexar.PerformClick()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        btnModificar.PerformClick()
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
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro de deducción/ingreso?", "Eliminar deducción/ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            sqlQ = "Delete from deduccionesprocdetalle WHERE IDDeduccionesProcDetalle='" + lblIDDedProc.Text + "'"
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

            MessageBox.Show("El registro ha sido eliminado satisfactoriamente.", "Registro eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnConsultarDeducciones_Click(sender As Object, e As EventArgs) Handles btnConsultarDeducciones.Click
        If lblIDDeduccion.Text = 3 Then
            If frm_consulta_entrega_cobros.Visible = True Then
                frm_consulta_entrega_cobros.Close()
            End If

            frm_consulta_entrega_cobros.Show(Me)
            frm_consulta_entrega_cobros.txtIDCobrador.Text = txtIDEmpleado.Text
            frm_consulta_entrega_cobros.txtCobrador.Text = txtEmpleado.Text
            frm_consulta_entrega_cobros.DgvEntregas.MultiSelect = True

        End If
    End Sub
End Class