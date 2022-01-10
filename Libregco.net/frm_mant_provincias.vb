Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_provincias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_provincias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDProvincia.Clear()
        txtProvincia.Clear()
        lblchkNulo.Text = 0
        chkNulo.Checked = False
        txtProvincia.Focus()
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub GuardarDatos1()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            ConLibregco.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltProvincia()
        If txtIDProvincia.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDProvincia from Provincias where IDProvincia= (Select Max(IDProvincia) from Provincias)", ConLibregco)
            txtIDProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblchkNulo.Text = 1
            DeshabilitarControles()
        Else
            lblchkNulo.Text = 0
            HabilitarControles()

        End If
    End Sub

    Private Sub HabilitarControles()
        txtIDProvincia.Enabled = True
        txtProvincia.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtIDProvincia.Enabled = False
        txtProvincia.Enabled = False
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        HabilitarControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtProvincia.Text = "" Then
            MessageBox.Show("Escriba el nombre de la nueva provincia a procesar.", "Escribir Nueva Provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtProvincia.Focus()
            Exit Sub
        End If

        If txtIDProvincia.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la nueva provincia: " & txtProvincia.Text & " en la base de datos?", "Guardar Nueva Provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Provincias (Provincia,Nulo) VALUES ('" + txtProvincia.Text + "','" + chkNulo.CheckState + "')"
                GuardarDatos1()
                UltProvincia()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Provincias SET Provincia='" + txtProvincia.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDProvincia= (" + txtIDProvincia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtProvincia.Text = "" Then
            MessageBox.Show("Escriba el nombre de la nueva provincia a procesar.", "Escribir Nueva Provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtProvincia.Focus()
            Exit Sub
        End If

        If txtIDProvincia.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la nueva provincia: " & txtProvincia.Text & " en la base de datos?", "Guardar Nueva Provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Provincias (Provincia,Nulo) VALUES ('" + txtProvincia.Text + "','" + chkNulo.CheckState + "')"
                GuardarDatos1()
                UltProvincia()
                DeshabilitarControles()
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
                sqlQ = "UPDATE Provincias SET Provincia='" + txtProvincia.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDProvincia= (" + txtIDProvincia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_provincias.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La provincia " & txtProvincia.Text & "  ya está desactivada del sistema. Desea volver a activarlo?", "Activar Provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE Provincias SET Provincia='" + txtProvincia.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDProvincia= (" + txtIDProvincia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDProvincia.Text = "" Then
            MessageBox.Show("No hay un registro de provincias abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de la Provincia " & txtProvincia.Text & " del sistema?", "Desactivar Provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE Provincias SET Provincia='" + txtProvincia.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDProvincia= (" + txtIDProvincia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class