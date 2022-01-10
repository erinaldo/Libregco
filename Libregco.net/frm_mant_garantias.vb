Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_mant_garantias
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkDesactivar As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_garantias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
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
            InhabilitarGarantia()
        Else
            lblchkDesactivar.Text = 0
            HabilitarGarantia()
        End If
    End Sub

    Private Sub HabilitarGarantia()
        txtIDGarantia.Enabled = True
        txtGarantia.Enabled = True
        txtDias.Enabled = True
    End Sub

    Private Sub InhabilitarGarantia()
        txtIDGarantia.Enabled = False
        txtGarantia.Enabled = False
        txtDias.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDGarantia.Clear()
        txtGarantia.Clear()
        txtDias.Clear()
        lblchkDesactivar.Text = 0
        chkDesactivar.Checked = False
        txtGarantia.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtGarantia.Text = "" Then
            MessageBox.Show("Escriba una descripción para la garantía a procesar.", "Descripción de garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtGarantia.Focus()
            Exit Sub
        ElseIf txtDias.Text = "" Then
            MessageBox.Show("Escriba la cantidad de días hábiles que posee la garantía que desea procesar.", "Días de garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtGarantia.Focus()
            Exit Sub
        End If

        If txtIDGarantia.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la garantía " & txtGarantia.Text & " en la base de datos?", "Guardar Nueva Garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO GarantiaArticulos (TiempoGarantia,Dias,Nulo) VALUES ('" + txtGarantia.Text + "','" + txtDias.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltGarantia()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkDesactivar.Checked = False
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE GarantiaArticulos SET TiempoGarantia='" + txtGarantia.Text + "',Dias='" + txtDias.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDGarantiaArticulos= (" + txtIDGarantia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkDesactivar.Checked = True
            End If
        End If
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltGarantia()
        If txtIDGarantia.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDGarantiaArticulos from GarantiaArticulos where IDGarantiaArticulos= (Select Max(IDGarantiaArticulos) from GarantiaArticulos)", ConLibregco)
            txtIDGarantia.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_garantia.ShowDialog(Me)
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

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtGarantia.Text = "" Then
            MessageBox.Show("Escriba una descripción para la garantía a procesar.", "Descripción de garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtGarantia.Focus()
            Exit Sub
        ElseIf txtDias.Text = "" Then
            MessageBox.Show("Escriba la cantidad de días hábiles que posee la garantía que desea procesar.", "Días de garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtGarantia.Focus()
            Exit Sub
        End If

        If txtIDGarantia.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la garantía " & txtGarantia.Text & " en la base de datos?", "Guardar Nueva Garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO GarantiaArticulos (TiempoGarantia,Dias,Nulo) VALUES ('" + txtGarantia.Text + "','" + txtDias.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltGarantia()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                HabilitarGarantia()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE GarantiaArticulos SET TiempoGarantia='" + txtGarantia.Text + "',Dias='" + txtDias.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDGarantiaArticulos= (" + txtIDGarantia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                HabilitarGarantia()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El tipo de garantía " & txtGarantia.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Tipo de garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE GarantiaArticulos SET TiempoGarantia='" + txtGarantia.Text + "',Dias='" + txtDias.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDGarantiaArticulos= (" + txtIDGarantia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDGarantia.Text = "" Then
            MessageBox.Show("No hay un registro de tipo de garantía abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_tipo_garantia.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro de tipo de garantía " & txtGarantia.Text & " del sistema?", "Desactivar Garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE GarantiaArticulos SET TiempoGarantia='" + txtGarantia.Text + "',Dias='" + txtDias.Text + "',Nulo='" + lblchkDesactivar.Text + "' WHERE IDGarantiaArticulos= (" + txtIDGarantia.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If
    End Sub

End Class