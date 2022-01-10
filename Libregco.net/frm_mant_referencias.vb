Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_referencias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblRelacion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_referencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatosCliente()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
          PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        FillCbxRelacion()
    End Sub

    Private Sub FillCbxRelacion()
        Ds.clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT relacion FROM Relacionfamiliar ORDER BY Relacion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "relacionfamiliar")
        cbxRelacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("relacionfamiliar")

        For Each Fila As DataRow In Tabla.Rows
            cbxRelacion.Items.Add(Fila.Item("relacion"))
        Next
        cbxRelacion.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub SetIDCbxRelacion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDRelacionFamiliar FROM relacionFamiliar WHERE relacion= '" + cbxRelacion.SelectedItem + "' Order By Relacion ASC", ConLibregco)
        lblRelacion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnAnular.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MessageBox.Show(lblRelacion.Text)
    End Sub

    Private Sub cbxRelacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRelacion.SelectedIndexChanged
        SetIDCbxRelacion()
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        If txtTelefono.Text = "" Then
        Else
            txtTelefono.Mask = "000-000-0000"
            txtTelefono.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefono_Leave(sender As Object, e As EventArgs) Handles txtTelefono.Leave
        If Len(txtTelefono.Text) = 8 Then
            txtTelefono.Mask = ""
        End If
        If Len(txtTelefono.Text) = 12 Then
            txtTelefono.Mask = "000-000-0000"
        End If
    End Sub

    Sub LimpiarDatosCliente()

        If Me.Owner.Name = frm_mant_clientes.Name Then
            HabilitarCampos()
            txtReferencia.Clear()
            lblRelacion.Text = ""
            cbxRelacion.Items.Clear()
            cbxRelacion.Text = ""
            txtDireccion.Clear()
            txtTelefono.Text = ""
            ActualizarReferencias()
            txtIDReferencia.Clear()
            txtReferencia.Focus()
        Else
            HabilitarCampos()
            txtIDCliente.Clear()
            txtCedula.Clear()
            txtNombre.Clear()
            txtReferencia.Clear()
            lblRelacion.Text = ""
            cbxRelacion.Items.Clear()
            cbxRelacion.Text = ""
            txtDireccion.Clear()
            txtTelefono.Text = ""
            ActualizarReferencias()
            txtIDReferencia.Clear()
        End If

       
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarReferencias()
        FillCbxRelacion()
        txtTelefono.Mask = "000-000-0000"
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub frm_mant_referencias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiarDatosCliente()
        txtReferencia.Focus()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtCedula.Clear()
    End Sub

    Private Sub UltReferencia()
        If txtIDReferencia.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDReferencias from Referencias where IDreferencias= (Select Max(IDReferencias) from referencias)", ConLibregco)
            txtIDReferencia.Text = Convert.ToDouble(cmd.ExecuteScalar)
            ConLibregco.Close()
        End If
    End Sub

    Private Sub InhabilitarCampos()
        txtIDReferencia.Enabled = False
        txtReferencia.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
        cbxRelacion.Enabled = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub HabilitarCampos()
        txtIDReferencia.Enabled = True
        txtReferencia.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
        cbxRelacion.Enabled = True
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatosCliente()
        ActualizarReferencias()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtReferencia.Text = "" Then
            MessageBox.Show("Escriba el nombre de la referencia.", "Nombre Referencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf cbxRelacion.Text = "" Then
            MessageBox.Show("Especifique el tipo de relación con el cliente.", "Relación con Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxRelacion.Focus()
            cbxRelacion.DroppedDown = True
            Exit Sub
        ElseIf txtIDCliente.Text = "" Then
            MessageBox.Show("No se ha específicado el cliente a relacionar.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        End If
        If txtIDReferencia.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea insertar la nueva referencia al registro de " & txtNombre.Text & " en la base de datos?", "Guardar Nuevo Referente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Referencias (IDCliente,IDRelacion,Nombre,Direccion,Telefono) VALUES ('" + txtIDCliente.Text + "','" + lblRelacion.Text + "', '" + txtReferencia.Text + "','" + txtDireccion.Text + "', '" + txtTelefono.Text + "')"
                GuardarDatos()
                UltReferencia()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Referencias SET IDCliente='" + txtIDCliente.Text + "',IDRelacion='" + lblRelacion.Text + "',Nombre='" + txtReferencia.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "'WHERE IDReferencias= (" + txtIDReferencia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
        If frm_mant_clientes.Visible = True Then
            frm_mant_clientes.RefrescarTablaReferencias()
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtReferencia.Text = "" Then
            MessageBox.Show("Escriba el nombre de la referencia.", "Nombre Referencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf cbxRelacion.Text = "" Then
            MessageBox.Show("Especifique el tipo de relación con el cliente.", "Relación con Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxRelacion.Focus()
            cbxRelacion.DroppedDown = True
            Exit Sub
        ElseIf txtIDCliente.Text = "" Then
            MessageBox.Show("No se ha específicado el cliente a relacionar.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        End If
        If txtIDReferencia.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea insertar la nueva referencia al registro de " & txtNombre.Text & " en la base de datos?", "Guardar Nuevo Referente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Referencias (IDCliente,IDRelacion,Nombre,Direccion,Telefono) VALUES ('" + txtIDCliente.Text + "','" + lblRelacion.Text + "', '" + txtReferencia.Text + "','" + txtDireccion.Text + "', '" + txtTelefono.Text + "')"
                GuardarDatos()
                UltReferencia()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosCliente()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Referencias SET IDCliente='" + txtIDCliente.Text + "',IDRelacion='" + lblRelacion.Text + "',Nombre='" + txtReferencia.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "'WHERE IDReferencias= (" + txtIDReferencia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosCliente()
                ActualizarTodo()
            End If
        End If

        If frm_mant_clientes.Visible = True Then
            frm_mant_clientes.RefrescarTablaReferencias()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_referencias.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDReferencia.Text = "" Then 'Si no hay un referente seleccionado
            MessageBox.Show("No hay registro seleccionado para eliminar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro de la base de datos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from Referencias Where IDReferencias= (" + txtIDReferencia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Registro eliminado satisfactoriamente.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_mant_clientes.RefrescarTablaReferencias()
                InhabilitarCampos()
            Else
                MessageBox.Show("Se ha cancelado la eliminación del registro.", "Eliminado Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub BuscarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarClienteToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub
End Class