Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_sucursal

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkDesactivar As New Label
    Dim Permisos As New ArrayList
    Dim TypeofMetode As String
    Private Sub frm_mant_sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        SetConfiguracion
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub SetConfiguracion()

        Con.Open()
        'Verificar tipo de NCF
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=75", Con)
        TypeofMetode = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If TypeofMetode = 3 Then
            GroupBox1.Visible = False
        End If
    End Sub
    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CargarLibregco()
   PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblchkDesactivar.Text = 1
            DeshabilitarSucursal()
        Else
            lblchkDesactivar.Text = 0
            HabilitarSucursal()
        End If
    End Sub

    Private Sub HabilitarSucursal()
        txtCodigo.Enabled = True
        txtSucursal.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono0.Enabled = True
        txtTelefono1.Enabled = True
        txtTelefono2.Enabled = True
        txtFax.Enabled = True
        txtEmail.Enabled = True
        txtMunicipio.Enabled = True
        txtProvincia.Enabled = True
    End Sub

    Private Sub DeshabilitarSucursal()
        txtCodigo.Enabled = False
        txtSucursal.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono0.Enabled = False
        txtTelefono1.Enabled = False
        txtTelefono2.Enabled = False
        txtFax.Enabled = False
        txtEmail.Enabled = False
        txtMunicipio.Enabled = False
        txtProvincia.Enabled = False
    End Sub

    Private Sub LimpiarDatos()
        txtCodigo.Clear()
        txtSucursal.Clear()
        txtDireccion.Clear()
        txtTelefono0.Clear()
        txtTelefono1.Clear()
        txtTelefono2.Clear()
        txtFax.Clear()
        txtEmail.Clear()
        lblchkDesactivar.Text = 0
        txtMunicipio.Clear()
        txtProvincia.Clear()
        txtDivisiondeNegocios.Clear()
        chkDesactivar.Checked = False
        txtSucursal.Focus()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
            ConLibregco.Close()
            ConLibregcoMain.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub UltSucursal()
        If txtCodigo.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDSucursal from Sucursal where IDSucursal= (Select Max(IDSucursal) from Sucursal)", Con)
            txtCodigo.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
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

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        HabilitarSucursal()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtSucursal.Text = "" Then
            MessageBox.Show("Escriba la sucursal a procesar.", "Nombre de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSucursal.Focus()
            Exit Sub
        ElseIf txtDireccion.Text = "" Then
            MessageBox.Show("Escriba la dirección de la  sucursal a procesar.", "Dirección de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDireccion.Focus()
            Exit Sub
        ElseIf txtMunicipio.Text = "" Then
            MessageBox.Show("Escriba el municipio de la  sucursal a procesar.", "Municipio de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMunicipio.Focus()
            Exit Sub
        ElseIf txtProvincia.Text = "" Then
            MessageBox.Show("Escriba la provincia de la  sucursal a procesar.", "Provincia de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtProvincia.Focus()
            Exit Sub
        End If

        If txtCodigo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la sucursal " & txtSucursal.Text & " en la base de datos?", "Guardar Nueva Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Sucursal (Sucursal,Direccion,Municipio,Provincia,Telefono,Telefono1,Telefono2,Fax,Email,DivisionNegocio,Nulo) VALUES ('" + txtSucursal.Text + "','" + txtDireccion.Text + "','" + txtMunicipio.Text + "','" + txtProvincia.Text + "','" + txtTelefono0.Text + "','" + txtTelefono1.Text + "','" + txtTelefono2.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtDivisiondeNegocios.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltSucursal()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Sucursal SET Sucursal='" + txtSucursal.Text + "',Direccion='" + txtDireccion.Text + "',Municipio='" + txtMunicipio.Text + "',Provincia='" + txtProvincia.Text + "',Telefono='" + txtTelefono0.Text + "',Telefono1='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Fax='" + txtFax.Text + "',Email='" + txtEmail.Text + "',DivisionNegocio='" + txtDivisiondeNegocios.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDSucursal= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
        DeshabilitarSucursal()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_sucursal.ShowDialog(Me)
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtSucursal.Text = "" Then
            MessageBox.Show("Escriba la sucursal a procesar.", "Nombre de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSucursal.Focus()
            Exit Sub
        ElseIf txtDireccion.Text = "" Then
            MessageBox.Show("Escriba la dirección de la  sucursal a procesar.", "Dirección de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDireccion.Focus()
            Exit Sub
        ElseIf txtMunicipio.Text = "" Then
            MessageBox.Show("Escriba el municipio de la  sucursal a procesar.", "Municipio de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMunicipio.Focus()
            Exit Sub
        ElseIf txtProvincia.Text = "" Then
            MessageBox.Show("Escriba la provincia de la  sucursal a procesar.", "Provincia de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtProvincia.Focus()
            Exit Sub
        End If

        If txtCodigo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la sucursal " & txtSucursal.Text & " en la base de datos?", "Guardar Nueva Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Sucursal (Sucursal,Direccion,Municipio,Provincia,Telefono,Telefono1,Telefono2,Fax,Email,DivisionNegocio,Nulo) VALUES ('" + txtSucursal.Text + "','" + txtDireccion.Text + "','" + txtTelefono0.Text + "','" + txtMunicipio.Text + "','" + txtProvincia.Text + "','" + txtTelefono1.Text + "','" + txtTelefono2.Text + "','" + txtFax.Text + "','" + txtEmail.Text + "','" + txtDivisiondeNegocios.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltSucursal()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Sucursal SET Sucursal='" + txtSucursal.Text + "',Direccion='" + txtDireccion.Text + "',Municipio='" + txtMunicipio.Text + "',Provincia='" + txtProvincia.Text + "',Telefono='" + txtTelefono0.Text + "',Telefono1='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Fax='" + txtFax.Text + "',Email='" + txtEmail.Text + "',DivisionNegocio='" + txtDivisiondeNegocios.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDSucursal= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtSucursal.Text = "" Then
            MessageBox.Show("Escriba la sucursal a procesar.", "Nombre de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSucursal.Focus()
            Exit Sub
        ElseIf txtDireccion.Text = "" Then
            MessageBox.Show("Escriba la dirección de la  sucursal a procesar.", "Dirección de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDireccion.Focus()
            Exit Sub
        ElseIf txtMunicipio.Text = "" Then
            MessageBox.Show("Escriba el municipio de la  sucursal a procesar.", "Municipio de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMunicipio.Focus()
            Exit Sub
        ElseIf txtProvincia.Text = "" Then
            MessageBox.Show("Escriba la provincia de la  sucursal a procesar.", "Provincia de la Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtProvincia.Focus()
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La sucursal " & txtSucursal.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE Sucursal SET Sucursal='" + txtSucursal.Text + "',Direccion='" + txtDireccion.Text + "',Municipio='" + txtMunicipio.Text + "',Provincia='" + txtProvincia.Text + "',Telefono='" + txtTelefono0.Text + "',Telefono1='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Fax='" + txtFax.Text + "',Email='" + txtEmail.Text + "',DivisionNegocio='" + txtDivisiondeNegocios.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDSucursal= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtCodigo.Text = "" Then
            MessageBox.Show("No hay un registro de sucursal abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_sucursal.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de sucursal " & txtSucursal.Text & " del sistema?", "Desactivar Sucursal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE Sucursal SET Sucursal='" + txtSucursal.Text + "',Direccion='" + txtDireccion.Text + "',Municipio='" + txtMunicipio.Text + "',Provincia='" + txtProvincia.Text + "',Telefono='" + txtTelefono0.Text + "',Telefono1='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Fax='" + txtFax.Text + "',Email='" + txtEmail.Text + "',DivisionNegocio='" + txtDivisiondeNegocios.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDSucursal= (" + txtCodigo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub
End Class