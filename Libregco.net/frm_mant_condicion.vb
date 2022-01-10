Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_condicion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDias.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub frm_mant_condicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCondicion.Clear()
        txtCondicion.Clear()
        txtDias.Clear()
        txtOrden.Clear()
        lblchkNulo.Text = 0
        chkNulo.Checked = False
        txtCondicion.Focus()
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
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltCondicion()
        If txtIDCondicion.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCondicion from Condicion where IDCondicion= (Select Max(IDCondicion) from Condicion)", ConLibregco)
            txtIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
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
        txtIDCondicion.Enabled = True
        txtCondicion.Enabled = True
        txtDias.Enabled = True
        txtOrden.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtIDCondicion.Enabled = False
        txtCondicion.Enabled = False
        txtDias.Enabled = False
        txtOrden.Enabled = False
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
        If txtCondicion.Text = "" Then
            MessageBox.Show("Escriba la descripción de la condición de venta", "Escribir condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCondicion.Focus()
            Exit Sub
        ElseIf txtDias.Text = "" Then
            MessageBox.Show("Especifique la cantidad de días de la condición.", "Escribir cantidad de días", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDias.Focus()
            Exit Sub
        ElseIf txtOrden.Text = "" Then
            MessageBox.Show("Escriba el número de orden de la condición.", "Escribir No. de Orden", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtOrden.Focus()
            Exit Sub
        End If

        If txtIDCondicion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la nueva condición: " & txtCondicion.Text & " en la base de datos?", "Guardar Nueva Condición", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Condicion (Condicion,Dias,Orden,Nulo) VALUES ('" + txtCondicion.Text + "','" + txtDias.Text + "','" + txtOrden.Text + "','" + lblchkNulo.Text + "')"
                GuardarDatos1()
                UltCondicion()
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
                sqlQ = "UPDATE Condicion SET Condicion='" + txtCondicion.Text + "',Dias='" + txtDias.Text + "',Orden='" + txtOrden.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDCondicion= (" + txtIDCondicion.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtCondicion.Text = "" Then
            MessageBox.Show("Escriba la descripción de la condición de venta", "Escribir condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCondicion.Focus()
            Exit Sub
        ElseIf txtDias.Text = "" Then
            MessageBox.Show("Especifique la cantidad de días de la condición.", "Escribir cantidad de días", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDias.Focus()
            Exit Sub
        ElseIf txtOrden.Text = "" Then
            MessageBox.Show("Escriba el número de orden de la condición.", "Escribir No. de Orden", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtOrden.Focus()
            Exit Sub
        End If

        If txtIDCondicion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la nueva condición: " & txtCondicion.Text & " en la base de datos?", "Guardar Nueva Condición", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Condicion (Condicion,Dias,Orden,Nulo) VALUES ('" + txtCondicion.Text + "','" + txtDias.Text + "','" + txtOrden.Text + "','" + lblchkNulo.Text + "')"
                GuardarDatos1()
                UltCondicion()
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
                sqlQ = "UPDATE Condicion SET Condicion='" + txtCondicion.Text + "',Dias='" + txtDias.Text + "',Orden='" + txtOrden.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDCondicion= (" + txtIDCondicion.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_condicion.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtCondicion.Text = "" Then
            MessageBox.Show("Escriba la descripción de la condición de venta", "Escribir condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCondicion.Focus()
            Exit Sub
        ElseIf txtDias.Text = "" Then
            MessageBox.Show("Especifique la cantidad de días de la condición.", "Escribir cantidad de días", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDias.Focus()
            Exit Sub
        ElseIf txtOrden.Text = "" Then
            MessageBox.Show("Escriba el número de orden de la condición.", "Escribir No. de Orden", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtOrden.Focus()
            Exit Sub
        End If
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La condición " & txtCondicion.Text & "  ya está desactivada del sistema. Desea volver a activarlo?", "Activar Condición", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE Condicion SET Condicion='" + txtCondicion.Text + "',Dias='" + txtDias.Text + "',Orden='" + txtOrden.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDCondicion= (" + txtIDCondicion.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDCondicion.Text = "" Then
            MessageBox.Show("No hay un registro de condición abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de la condición " & txtCondicion.Text & " del sistema?", "Desactivar Condicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE Condicion SET Condicion='" + txtCondicion.Text + "',Dias='" + txtDias.Text + "',Orden='" + txtOrden.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDCondicion= (" + txtIDCondicion.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class