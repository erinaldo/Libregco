Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_tarjeta

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_tarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoTarjeta.Clear()
        txtTipoTarjeta.Clear()
        lblchkNulo.Text = 0
        chkNulo.Checked = False
        txtTipoTarjeta.Focus()
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

    Private Sub UltTipoTarjeta()

        If txtIDTipoTarjeta.Text = "" Then

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDTarjetaTipo from TarjetaTipo where IDTarjetaTipo= (Select Max(IDTarjetaTipo) from TarjetaTipo)", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TarjetaTipo")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TarjetaTipo")
            txtIDTipoTarjeta.Text = (Tabla.Rows(0).Item("IDTarjetaTipo"))

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
        txtIDTipoTarjeta.Enabled = True
        txtTipoTarjeta.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtIDTipoTarjeta.Enabled = False
        txtTipoTarjeta.Enabled = False
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
        btnAnular.PerformClick()
    End Sub

    Private Sub HabilitarGuadar()
        If txtTipoTarjeta.Text = "" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub txtTipoTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTipoTarjeta.TextChanged
        HabilitarGuadar()
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDTipoTarjeta.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el nuevo tipo de tarjeta: " & txtTipoTarjeta.Text & " en la base de datos?", "Guardar Nuevo Tipo Tarjeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                'Agrego un nuevo registro
                sqlQ = "INSERT INTO TarjetaTipo (Descripcion,Nulo) VALUES ('" + txtTipoTarjeta.Text + "','" + lblchkNulo.Text + "')"
                GuardarDatos1()
                UltTipoTarjeta()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TarjetaTipo SET Descripcion='" + txtTipoTarjeta.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDTarjetaTipo= (" + txtIDTipoTarjeta.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDTipoTarjeta.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el nuevo tipo de tarjeta: " & txtTipoTarjeta.Text & " en la base de datos?", "Guardar Nuevo Tipo Tarjeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                'Agrego un nuevo registro
                sqlQ = "INSERT INTO TarjetaTipo (Descripcion,Nulo) VALUES ('" + txtTipoTarjeta.Text + "','" + lblchkNulo.Text + "')"
                GuardarDatos1()
                UltTipoTarjeta()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TarjetaTipo SET Descripcion='" + txtTipoTarjeta.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDTarjetaTipo= (" + txtIDTipoTarjeta.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_tarjeta.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnAnular.Click, btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El Tipo de Tarjeta " & txtTipoTarjeta.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Tipo Tarjeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                chkNulo.Checked = False
                sqlQ = "UPDATE TarjetaTipo SET Descripcion='" + txtTipoTarjeta.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDTarjetaTipo= (" + txtIDTipoTarjeta.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTipoTarjeta.Text = "" Then
            MessageBox.Show("No hay un registro de tipo de tarjeta abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de tipo de tarjeta " & txtTipoTarjeta.Text & " del sistema?", "Desactivar Tipo De Tarjeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                chkNulo.Checked = True
                sqlQ = "UPDATE TarjetaTipo SET Descripcion='" + txtTipoTarjeta.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDTarjetaTipo= (" + txtIDTipoTarjeta.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub
End Class