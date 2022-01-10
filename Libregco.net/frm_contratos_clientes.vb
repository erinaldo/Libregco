Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_contratos_clientes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_contratos_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Sub CodeNumContraro()
        If txtIDContrato.Text = "" Then
            If txtIDCliente.Text <> "" Then
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT count(Fecha) FROM" & SysName.Text & "contratos where date(Fecha)='" + Today.ToString("yyyy-MM-dd") + "'", ConMixta)
                txtNoContrato.Text = (CInt(Convert.ToInt16(cmd.ExecuteScalar())) + 1) & "-" & Today.ToString("yyyyMMdd") + "-" & txtIDCliente.Text
                ConMixta.Close()
            End If
        End If

    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtUsuario.Clear()
        txtNoContrato.Clear()
        txtFolio.Clear()
        txtPlazo.Clear()
        txtIDPlazo.Clear()
        txtObservacion.Clear()
        txtFecha.Clear()
        txtIDContrato.Clear()
        txtSecondID.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("HH:mm:ss")
        dtpVencimiento.Value = Today
        ChkNulo.Checked = False
        txtUsuario.Text = "[" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] " & frm_inicio.lblNombre.Text
        lblNulo.Text = 0
        Hora.Enabled = True
        btn_buscar_plazo.Enabled = True
        HabilitarControles()
    End Sub

    Private Sub HabilitarControles()
        txtNoContrato.Enabled = True
        txtFolio.Enabled = True
        txtObservacion.Enabled = True
        btnBuscarCliente.Enabled = True
        btn_buscar_plazo.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtNoContrato.Enabled = False
        txtFolio.Enabled = False
        txtObservacion.Enabled = False
        btnBuscarCliente.Enabled = False
        btn_buscar_plazo.Enabled = False
    End Sub

    Private Sub SelectUsuario()
        Try
            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub UltContrato()
        Try
            If txtIDContrato.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("SELECT IDContrato FROM contratos where IDContrato= (Select Max(IDContrato) from contratos)", Con)
                txtIDContrato.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltContrato")
        End Try
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

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDContrato.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el contrato de solicitud de crédito?", "Imprimir Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para realizar el contrato de solicitud de crédito.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtNoContrato.Text = "" Then
            MessageBox.Show("Escriba el No. de contrato.", "No. de Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoContrato.Focus()
            Exit Sub
        ElseIf txtIDPlazo.Text = "" Then
            MessageBox.Show("Seleccione el plazo o tiempo de validez del contrato crédito.", "Seleccione el plazo del contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_buscar_plazo.PerformClick()
            Exit Sub

        ElseIf VerificarContratosValidos(txtIDCliente.Text) = True Then
            Dim Result As MsgBoxResult = MessageBox.Show("Ya se el cliente posee actualmente un contrato de solicitud de crédito activo." & vbNewLine & vbNewLine & "Está seguro que desea generar un nuevo contrato de solicitud de crédito?", "Ya existe un contrato hábil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If txtIDContrato.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo contrato de solicitud de crédito en favor del cliente cód. [" & txtIDCliente.Text & "] " & " " & txtCliente.Text & " en la base de datos?", "Guardar Nuevo Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Contratos (IDUsuario,IDAlmacen,IDTipoDocumento,NoContrato,IDCliente,Folio,Fecha,IDPlazoVencimiento,FechaVencimiento,Observaciones,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',46,'" + txtNoContrato.Text + "','" + txtIDCliente.Text + "','" + txtFolio.Text + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + txtIDPlazo.Text + "','" + CDate(dtpVencimiento.Value).ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + txtObservacion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltContrato()
                SetSecondID()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()

            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el contrato de solicitud de crédito?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Contratos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',NoContrato='" + txtNoContrato.Text + "',IDCliente='" + txtIDCliente.Text + "',Folio='" + txtFolio.Text + "',IDPlazoVencimiento='" + txtIDPlazo.Text + "',FechaVencimiento='" + dtpVencimiento.Value.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',Observaciones='" + txtObservacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDContrato= ('" + txtIDContrato.Text + "')"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Function VerificarContratosValidos(ByVal IDCliente As Integer) As Boolean
        Con.Open()
        cmd = New MySqlCommand("SELECT count(idcontrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>curdate() and Contratos.Nulo=0", Con)
        Dim CantContratos As Integer = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If CantContratos > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=46", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Contratos SET SecondID='" + lblSecondID.Text + "' WHERE IDContrato='" + txtIDContrato.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=46"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para realizar el contrato de solicitud de crédito.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtNoContrato.Text = "" Then
            MessageBox.Show("Escriba el No. de contrato.", "No. de Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoContrato.Focus()
            Exit Sub
        ElseIf txtIDPlazo.Text = "" Then
            MessageBox.Show("Seleccione el plazo o tiempo de validez del contrato crédito.", "Seleccione el plazo del contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_buscar_plazo.PerformClick()
            Exit Sub

        ElseIf VerificarContratosValidos(txtIDCliente.Text) = True Then
            Dim Result As MsgBoxResult = MessageBox.Show("Ya se el cliente posee actualmente un contrato de solicitud de crédito activo." & vbNewLine & vbNewLine & "Está seguro que desea generar un nuevo contrato de solicitud de crédito?", "Ya existe un contrato hábil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If txtIDContrato.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo contrato de solicitud de crédito en favor del cliente cód. [" & txtIDCliente.Text & "] " & " " & txtCliente.Text & " en la base de datos?", "Guardar Nuevo Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Contratos (IDUsuario,IDAlmacen,IDTipoDocumento,NoContrato,IDCliente,Folio,Fecha,IDPlazoVencimiento,FechaVencimiento,Observaciones,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',46,'" + txtNoContrato.Text + "','" + txtIDCliente.Text + "','" + txtFolio.Text + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + txtIDPlazo.Text + "','" + CDate(dtpVencimiento.Value).ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + txtObservacion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltContrato()
                SetSecondID()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el contrato de solicitud de crédito?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Contratos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',NoContrato='" + txtNoContrato.Text + "',IDCliente='" + txtIDCliente.Text + "',Folio='" + txtFolio.Text + "',IDPlazoVencimiento='" + txtIDPlazo.Text + "',FechaVencimiento='" + dtpVencimiento.Value.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',Observaciones='" + txtObservacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDContrato= ('" + txtIDContrato.Text + "')"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para realizar el contrato de solicitud de crédito.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf txtNoContrato.Text = "" Then
            MessageBox.Show("Escriba el No. de contrato.", "No. de Contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoContrato.Focus()
            Exit Sub
        ElseIf txtIDPlazo.Text = "" Then
            MessageBox.Show("Seleccione el plazo o tiempo de validez del contrato crédito.", "Seleccione el plazo del contrato", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_buscar_plazo.PerformClick()
            Exit Sub
        End If
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El contrato de solicitud de crédito No. " & txtIDContrato.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Contrato de crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                ChkNulo.Checked = False
                sqlQ = "UPDATE Contratos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',NoContrato='" + txtNoContrato.Text + "',IDCliente='" + txtIDCliente.Text + "',Folio='" + txtFolio.Text + "',IDPlazoVencimiento='" + txtIDPlazo.Text + "',FechaVencimiento='" + dtpVencimiento.Value.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',Observaciones='" + txtObservacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDContrato= ('" + txtIDContrato.Text + "')"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDContrato.Text = "" Then
            MessageBox.Show("No hay un registro de contrato abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de contrato de solicitud de crédito No. " & txtSecondID.Text & " del sistema?", "Desactivar Contrato", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                sqlQ = "UPDATE Contratos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',NoContrato='" + txtNoContrato.Text + "',IDCliente='" + txtIDCliente.Text + "',Folio='" + txtFolio.Text + "',IDPlazoVencimiento='" + txtIDPlazo.Text + "',FechaVencimiento='" + dtpVencimiento.Value.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',Observaciones='" + txtObservacion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDContrato= ('" + txtIDContrato.Text + "')"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btn_buscar_plazo_Click(sender As Object, e As EventArgs) Handles btn_buscar_plazo.Click
        frm_buscar_plazos_contratos.ShowDialog(Me)
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
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_contratos_clientes.ShowDialog(Me)
    End Sub
End Class