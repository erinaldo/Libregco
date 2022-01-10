Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_prestamos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_prestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoPrestamo.Clear()
        txtTipoPrestamo.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtTipoPrestamo.Focus()
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
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltTipoPrestamo()
        Try

            If txtIDTipoPrestamo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTipoPrestamoEmp from TipoPrestamoEmp where IDTipoPrestamoEmp= (Select Max(IDTipoPrestamoEmp) from TipoPrestamoEmp)", Con)
                txtIDTipoPrestamo.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " DepartamentoEmp()")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtTipoPrestamo.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtTipoPrestamo.Enabled = True
    End Sub


    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtTipoPrestamo.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoPrestamo.Focus()
            Exit Sub
        End If
        If txtIDTipoPrestamo.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el tipo de préstamo " & txtTipoPrestamo.Text & " en la base de datos?", "Guardar Nuevo Tipo de Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoPrestamoEmp (Descripcion,Nulo) VALUES ('" + txtTipoPrestamo.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoPrestamo()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de préstamo?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "UPDATE TipoPrestamoEmp SET Descripcion='" + txtTipoPrestamo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoPrestamoEmp= (" + txtIDTipoPrestamo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtTipoPrestamo.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoPrestamo.Focus()
            Exit Sub
        End If
        If txtIDTipoPrestamo.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el tipo de préstamo " & txtTipoPrestamo.Text & " en la base de datos?", "Guardar Nuevo Tipo de Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoPrestamoEmp (Descripcion,Nulo) VALUES ('" + txtTipoPrestamo.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoPrestamo()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de préstamo?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "UPDATE TipoPrestamoEmp SET Descripcion='" + txtTipoPrestamo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoPrestamoEmp= (" + txtIDTipoPrestamo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_prestamos_emp.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtTipoPrestamo.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de préstamo a procesar.", "Tipo de préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoPrestamo.Focus()
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El tipo de préstamo Código. " & txtIDTipoPrestamo.Text & " ya está anulado en el sistema. Desea activarla?", "Recuperar Tipo de Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 77
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                sqlQ = "UPDATE TipoPrestamoEmp SET Descripcion='" + txtTipoPrestamo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoPrestamoEmp= (" + txtIDTipoPrestamo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTipoPrestamo.Text = "" Then
            MessageBox.Show("No hay un registro de tipos de préstamos abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el tipo de préstamos Código. " & txtIDTipoPrestamo.Text & " / " & txtTipoPrestamo.Text & " del sistema?", "Anular Tipo de Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 78
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                sqlQ = "UPDATE TipoPrestamoEmp SET Descripcion='" + txtTipoPrestamo.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoPrestamoEmp= (" + txtIDTipoPrestamo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub
End Class