Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoRecibo.Clear()
        txtTipoRecibo.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtTipoRecibo.Focus()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltTipoRecibo()
        Try
            If txtIDTipoRecibo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTipoRecibo from TipoRecibos where IDTipoRecibo= (Select Max(IDTipoRecibo) from TipoRecibos)", Con)
                txtIDTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltTipoRecibo)")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtTipoRecibo.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtTipoRecibo.Enabled = True
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
        btnNulo.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtTipoRecibo.Text = "" Then
            MessageBox.Show("Describa el tipo de tipo de recibos a generar.", "Nombre del tipo de recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoRecibo.Focus()
            Exit Sub
        End If

        If txtIDTipoRecibo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el tipo de recibos " & txtTipoRecibo.Text & " en la base de datos?", "Guardar Nuevo Tipo de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoRecibos (Descripcion,Nulo) VALUES ('" + txtTipoRecibo.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoRecibo()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de recibos?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoRecibos SET Descripcion='" + txtTipoRecibo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoRecibo= (" + txtIDTipoRecibo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtTipoRecibo.Text = "" Then
            MessageBox.Show("Describa el tipo de tipo de recibos a generar.", "Nombre del tipo de recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoRecibo.Focus()
            Exit Sub
        End If

        If txtIDTipoRecibo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el tipo de recibos " & txtTipoRecibo.Text & " en la base de datos?", "Guardar Nuevo Tipo de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoRecibos (Descripcion,Nulo) VALUES ('" + txtTipoRecibo.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoRecibo()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de recibos?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoRecibos SET Descripcion='" + txtTipoRecibo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoRecibo= (" + txtIDTipoRecibo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_recibos.ShowDialog(Me)
    End Sub

    Private Sub btnNulo_Click(sender As Object, e As EventArgs) Handles btnNulo.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El tipo de recibos código [" & txtIDTipoRecibo.Text & "] ya está anulada en el sistema. Desea activarla?", "Recuperar tipo de recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE TipoRecibos SET Descripcion='" + txtTipoRecibo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoRecibo= (" + txtIDTipoRecibo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTipoRecibo.Text = "" Then
            MessageBox.Show("No hay un registro de tipo de recibo abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el tipo de recibo código [" & txtIDTipoRecibo.Text & "] " & txtTipoRecibo.Text & " del sistema?", "Anular tipo de recibo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE TipoRecibos SET Descripcion='" + txtTipoRecibo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoRecibo= (" + txtIDTipoRecibo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub
End Class