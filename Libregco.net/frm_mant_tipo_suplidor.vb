Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_suplidor

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_suplidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoSuplidor.Clear()
        txtTipoSuplidor.Clear()
    End Sub

    Private Sub ActualizarTodo()
        lblNulo.Text = 0
        chkNulo.Checked = False
        txtTipoSuplidor.Focus()
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

    Private Sub UltTipoSuplidor()
        Try

            If txtIDTipoSuplidor.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTipoSuplidor from TipoSuplidor where IDTipoSuplidor= (Select Max(IDTipoSuplidor) from TipoSuplidor)", Con)
                txtIDTipoSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltSuplidor")
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtTipoSuplidor.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtTipoSuplidor.Enabled = False
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtTipoSuplidor.Text = "" Then
            MessageBox.Show("Escriba el tipo de suplidor a procesar.", "Tipo de Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoSuplidor.Focus()
            Exit Sub
        End If

        If txtIDTipoSuplidor.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de suplidor: " & txtTipoSuplidor.Text & " en la base de datos?", "Guardar Nuevo Tipo de Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoSuplidor (Descripcion,Nulo) VALUES ('" + txtTipoSuplidor.Text + "', '" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoSuplidor()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de suplidor?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoSuplidor SET Descripcion='" + txtTipoSuplidor.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoSuplidor= (" + txtIDTipoSuplidor.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtTipoSuplidor.Text = "" Then
            MessageBox.Show("Escriba el tipo de suplidor a procesar.", "Tipo de Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoSuplidor.Focus()
            Exit Sub
        End If

        If txtIDTipoSuplidor.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de suplidor: " & txtTipoSuplidor.Text & " en la base de datos?", "Guardar Nuevo Tipo de Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoSuplidor (Descripcion,Nulo) VALUES ('" + txtTipoSuplidor.Text + "', '" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoSuplidor()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de suplidor?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoSuplidor SET Descripcion='" + txtTipoSuplidor.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoSuplidor= (" + txtIDTipoSuplidor.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtTipoSuplidor.Text = "" Then
            MessageBox.Show("Escriba el tipo de suplidor a procesar.", "Tipo de Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoSuplidor.Focus()
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El tipo de suplidor código No. " & txtIDTipoSuplidor.Text & ", " & txtTipoSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Tipo de Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE TipoSuplidor SET Descripcion='" + txtTipoSuplidor.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoSuplidor= (" + txtIDTipoSuplidor.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTipoSuplidor.Text = "" Then
            MessageBox.Show("No hay un registro de banco abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro del tipo de suplidor " & txtTipoSuplidor.Text & " del sistema?", "Anular Tipo de Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE TipoSuplidor SET Descripcion='" + txtTipoSuplidor.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoSuplidor= (" + txtIDTipoSuplidor.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_suplidor.ShowDialog(Me)
    End Sub
End Class