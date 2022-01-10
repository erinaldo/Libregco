Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tandas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList
    Dim lblIDTandaDetalle As String
    Private Sub frm_mant_tandas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtDescripcion.Clear()
        txtIDTanda.Clear()
        DgvTandasDetalle.Rows.Clear()

        chkdomingolaborable.Checked = False
        chkdomingolaborable.Tag = 0
        chkluneslaborable.Checked = False
        chkluneslaborable.Tag = 0
        chkmarteslaborable.Checked = False
        chkmarteslaborable.Tag = 0
        chkmiercoleslaborable.Checked = False
        chkmiercoleslaborable.Tag = 0
        chkjueveslaborable.Checked = False
        chkjueveslaborable.Tag = 0
        chkvierneslaborable.Checked = False
        chkvierneslaborable.Tag = 0
        chksabadolaborable.Checked = False
        chksabadolaborable.Tag = 0
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        PictureBox1.Tag = 1
        dtpDomingode.Enabled = False
        dtpdomingohasta.Enabled = False
        dtpDomingode.Value = Today & " 08:00 AM"
        dtpdomingohasta.Value = Today & " 12:00 PM"

        dtplunesde.Enabled = False
        dtpluneshasta.Enabled = False
        dtplunesde.Value = Today & " 08:00 AM"
        dtpluneshasta.Value = Today & " 12:00 PM"

        dtpmartesde.Enabled = False
        dtpmarteshasta.Enabled = False
        dtpmartesde.Value = Today & " 08:00 AM"
        dtpmarteshasta.Value = Today & " 12:00 PM"

        dtpmiercoelsde.Enabled = False
        dtpmiercoleshasta.Enabled = False
        dtpmiercoelsde.Value = Today & " 08:00 AM"
        dtpmiercoleshasta.Value = Today & " 12:00 PM"

        dtpjuevesde.Enabled = False
        dtpjueveshasta.Enabled = False
        dtpjuevesde.Value = Today & " 08:00 AM"
        dtpjueveshasta.Value = Today & " 12:00 PM"

        dtpviernesde.Enabled = False
        dtpvierneshasta.Enabled = False
        dtpviernesde.Value = Today & " 08:00 AM"
        dtpvierneshasta.Value = Today & " 12:00 PM"

        dtpsabadode.Enabled = False
        dtpsabadohasta.Enabled = False
        dtpsabadode.Value = Today & " 08:00 AM"
        dtpsabadohasta.Value = Today & " 12:00 PM"
        Button1.Text = "Insertar horario"
        rdbDia.Checked = True

        chkNulo.Checked = False
        lblNulo.Text = 0
        txtDescripcion.Focus()
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

    Private Sub UltTanda()
        Try

            If txtIDTanda.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTanda from Tandas where IDTanda= (Select Max(IDTanda) from Tandas)", Con)
                txtIDTanda.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltTandas()")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtDescripcion.Enabled = False
        txtDescripcionHorario.Enabled = False
        Button1.Enabled = False
        DgvTandasDetalle.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        txtDescripcionHorario.Enabled = True
        Button1.Enabled = True
        DgvTandasDetalle.Enabled = True
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

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click_1(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción de la tanda a procesar.", "Descripción de tandas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        End If

        If txtIDTanda.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la Tanda Laboral " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Horario Laboral", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Tandas (Descripcion,Nulo) VALUES ('" + txtDescripcion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTanda()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la tanda laboral?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Tandas SET Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTanda= '" + txtIDTanda.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción de la tanda a procesar.", "Descripción de tandas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        End If

        If txtIDTanda.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la Tanda Laboral " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Horario Laboral", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Tandas (Descripcion,Nulo) VALUES ('" + txtDescripcion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTanda()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la tanda laboral?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Tandas SET Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTanda= '" + txtIDTanda.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tandas.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Tanda Código. " & txtIDTanda.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Horario de Trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 69
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                sqlQ = "UPDATE Tandas SET Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTanda= '" + txtIDTanda.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTanda.Text = "" Then
            MessageBox.Show("No hay un registro de horario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la tanda laboral Código. " & txtIDTanda.Text & " / " & txtDescripcion.Text & " del sistema?", "Anular Horario Laboral", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 70
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                sqlQ = "UPDATE Tandas SET Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTanda= '" + txtIDTanda.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub chkdomingolaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkdomingolaborable.CheckedChanged
        dtpDomingode.Enabled = chkdomingolaborable.Checked
        dtpdomingohasta.Enabled = chkdomingolaborable.Checked
        chkdomingolaborable.Tag = Convert.ToInt16(chkdomingolaborable.Checked)
    End Sub

    Private Sub chkluneslaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkluneslaborable.CheckedChanged
        dtplunesde.Enabled = chkluneslaborable.Checked
        dtpluneshasta.Enabled = chkluneslaborable.Checked
        chkluneslaborable.Tag = Convert.ToInt16(chkluneslaborable.Checked)
    End Sub

    Private Sub chkmarteslaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkmarteslaborable.CheckedChanged
        dtpmartesde.Enabled = chkmarteslaborable.Checked
        dtpmarteshasta.Enabled = chkmarteslaborable.Checked
        chkmarteslaborable.Tag = Convert.ToInt16(chkmarteslaborable.Checked)
    End Sub

    Private Sub chkmiercoleslaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkmiercoleslaborable.CheckedChanged
        dtpmiercoelsde.Enabled = chkmiercoleslaborable.Checked
        dtpmiercoleshasta.Enabled = chkmiercoleslaborable.Checked
        chkmiercoleslaborable.Tag = Convert.ToInt16(chkmiercoleslaborable.Checked)
    End Sub

    Private Sub chkjueveslaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkjueveslaborable.CheckedChanged
        dtpjuevesde.Enabled = chkjueveslaborable.Checked
        dtpjueveshasta.Enabled = chkjueveslaborable.Checked
        chkjueveslaborable.Tag = Convert.ToInt16(chkjueveslaborable.Checked)
    End Sub

    Private Sub chkvierneslaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chkvierneslaborable.CheckedChanged
        dtpviernesde.Enabled = chkvierneslaborable.Checked
        dtpvierneshasta.Enabled = chkvierneslaborable.Checked
        chkvierneslaborable.Tag = Convert.ToInt16(chkvierneslaborable.Checked)
    End Sub

    Private Sub chksabadolaborable_CheckedChanged(sender As Object, e As EventArgs) Handles chksabadolaborable.CheckedChanged
        dtpsabadode.Enabled = chksabadolaborable.Checked
        dtpsabadohasta.Enabled = chksabadolaborable.Checked
        chksabadolaborable.Tag = Convert.ToInt16(chksabadolaborable.Checked)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIDTanda.Text = "" Then
            MessageBox.Show("Aún no se ha guardado la tanda para anexar horarios." & vbNewLine & vbNewLine & "Por favor guarde el registro para anexar horarios.", "Proceso tandas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If lblIDTandaDetalle = "" Then
            For Each row As DataGridViewRow In DgvTandasDetalle.Rows
                If row.Cells(24).Value = PictureBox1.Tag.ToString Then
                    MessageBox.Show("Ya existe un horario guardado similar en esta tanda laboral.", "Horario ya existe", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
        End If



        If lblIDTandaDetalle = "" Then
            sqlQ = "INSERT INTO Libregco.TandasDetalle (IDTanda,DescripcionDetalle,ParteDia,Domingo,EntradaDomingo,SalidaDomingo,Lunes,EntradaLunes,SalidaLunes,Martes,EntradaMartes,SalidaMartes,Miercoles,EntradaMiercoles,SalidaMiercoles,Jueves,EntradaJueves,SalidaJueves,Viernes,EntradaViernes,SalidaViernes,Sabado,EntradaSabado,SalidaSabado) VALUES ('" + txtIDTanda.Text + "','" + txtDescripcionHorario.Text + "', '" + PictureBox1.Tag.ToString + "','" + chkdomingolaborable.Tag.ToString + "', '" + If(chkdomingolaborable.Checked = True, dtpDomingode.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkdomingolaborable.Checked = True, dtpdomingohasta.Value.ToString("HH:mm:ss"), "00:00:00") + "', '" + chkluneslaborable.Tag.ToString + "','" + If(chkluneslaborable.Checked = True, dtplunesde.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkluneslaborable.Checked = True, dtpluneshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + chkmarteslaborable.Tag.ToString + "','" + If(chkmarteslaborable.Checked = True, dtpmartesde.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkmarteslaborable.Checked = True, dtpmarteshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + chkmiercoleslaborable.Tag.ToString + "','" + If(chkmiercoleslaborable.Checked = True, dtpmiercoelsde.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkmiercoleslaborable.Checked = True, dtpmiercoleshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + chkjueveslaborable.Tag.ToString + "','" + If(chkjueveslaborable.Checked = True, dtpjuevesde.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkjueveslaborable.Checked = True, dtpjueveshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + chkvierneslaborable.Tag.ToString + "','" + If(chkvierneslaborable.Checked = True, dtpviernesde.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chkvierneslaborable.Checked = True, dtpvierneshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + chksabadolaborable.Tag.ToString + "','" + If(chksabadolaborable.Checked = True, dtpsabadode.Value.ToString("HH:mm:ss"), "00:00:00") + "','" + If(chksabadolaborable.Checked = True, dtpsabadohasta.Value.ToString("HH:mm:ss"), "00:00:00") + "')"

            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            MessageBox.Show("Horario guardado satisfactoriamente.", "Horario guardado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Else
            sqlQ = "UPDATE Libregco.TandasDetalle SET IDTanda='" + txtIDTanda.Text + "',DescripcionDetalle='" + txtDescripcionHorario.Text + "',ParteDia ='" + PictureBox1.Tag.ToString + "',Domingo='" + chkdomingolaborable.Tag.ToString + "',EntradaDomingo='" + If(chkdomingolaborable.Checked = True, dtpDomingode.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaDomingo ='" + If(chkdomingolaborable.Checked = True, dtpdomingohasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Lunes='" + chkluneslaborable.Tag.ToString + "',EntradaLunes ='" + If(chkluneslaborable.Checked = True, dtplunesde.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaLunes='" + If(chkluneslaborable.Checked = True, dtpluneshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Martes ='" + chkmarteslaborable.Tag.ToString + "',EntradaMartes='" + If(chkmarteslaborable.Checked = True, dtpmartesde.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaMartes='" + If(chkmarteslaborable.Checked = True, dtpmarteshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Miercoles='" + chkmiercoleslaborable.Tag.ToString + "',EntradaMiercoles='" + If(chkmiercoleslaborable.Checked = True, dtpmiercoelsde.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaMiercoles='" + If(chkmiercoleslaborable.Checked = True, dtpmiercoleshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Jueves='" + chkjueveslaborable.Tag.ToString + "',EntradaJueves='" + If(chkjueveslaborable.Checked = True, dtpjuevesde.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaJueves= '" + If(chkjueveslaborable.Checked = True, dtpjueveshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Viernes ='" + chkvierneslaborable.Tag.ToString + "',EntradaViernes='" + If(chkvierneslaborable.Checked = True, dtpviernesde.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaViernes='" + If(chkvierneslaborable.Checked = True, dtpvierneshasta.Value.ToString("HH:mm:ss"), "00:00:00") + "',Sabado='" + chksabadolaborable.Tag.ToString + "',EntradaSabado='" + If(chksabadolaborable.Checked = True, dtpsabadode.Value.ToString("HH:mm:ss"), "00:00:00") + "',SalidaSabado= '" + If(chksabadolaborable.Checked = True, dtpsabadohasta.Value.ToString("HH:mm:ss"), "00:00:00") + "' WHERE IDTandasDetalle='" + lblIDTandaDetalle + "'"

            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            MessageBox.Show("Horario modificado satisfactoriamente.", "Horario modificado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        End If

        chkdomingolaborable.Checked = False
        chkdomingolaborable.Tag = 0
        chkluneslaborable.Checked = False
        chkluneslaborable.Tag = 0
        chkmarteslaborable.Checked = False
        chkmarteslaborable.Tag = 0
        chkmiercoleslaborable.Checked = False
        chkmiercoleslaborable.Tag = 0
        chkjueveslaborable.Checked = False
        chkjueveslaborable.Tag = 0
        chkvierneslaborable.Checked = False
        chkvierneslaborable.Tag = 0
        chksabadolaborable.Checked = False
        chksabadolaborable.Tag = 0
        lblIDTandaDetalle = ""
        dtpDomingode.Enabled = False
        dtpdomingohasta.Enabled = False
        dtpDomingode.Value = Today & " 08:00 AM"
        dtpdomingohasta.Value = Today & " 12:00 PM"

        dtplunesde.Enabled = False
        dtpluneshasta.Enabled = False
        dtplunesde.Value = Today & " 08:00 AM"
        dtpluneshasta.Value = Today & " 12:00 PM"

        dtpmartesde.Enabled = False
        dtpmarteshasta.Enabled = False
        dtpmartesde.Value = Today & " 08:00 AM"
        dtpmarteshasta.Value = Today & " 12:00 PM"

        dtpmiercoelsde.Enabled = False
        dtpmiercoleshasta.Enabled = False
        dtpmiercoelsde.Value = Today & " 08:00 AM"
        dtpmiercoleshasta.Value = Today & " 12:00 PM"

        dtpjuevesde.Enabled = False
        dtpjueveshasta.Enabled = False
        dtpjuevesde.Value = Today & " 08:00 AM"
        dtpjueveshasta.Value = Today & " 12:00 PM"

        dtpviernesde.Enabled = False
        dtpvierneshasta.Enabled = False
        dtpviernesde.Value = Today & " 08:00 AM"
        dtpvierneshasta.Value = Today & " 12:00 PM"

        dtpsabadode.Enabled = False
        dtpsabadohasta.Enabled = False
        dtpsabadode.Value = Today & " 08:00 AM"
        dtpsabadohasta.Value = Today & " 12:00 PM"

        rdbDia.Checked = True

        txtDescripcionHorario.Clear()
        Button1.Text = "Insertar horario"
        FillTandasDetalle()
    End Sub

    Sub FillTandasDetalle()
        Dim ImageDay As Image

        DgvTandasDetalle.Rows.Clear()

        Con.Open()
        Dim GarantiaEspecifica As New MySqlCommand("Select idTandasDetalle,ParteDia,DescripcionDetalle,Domingo,EntradaDomingo,SalidaDomingo,Lunes,EntradaLunes,SalidaLunes,Martes,EntradaMartes,SalidaMartes,Miercoles,EntradaMiercoles,SalidaMiercoles,Jueves,EntradaJueves,SalidaJueves,Viernes,EntradaViernes,SalidaViernes,Sabado,EntradaSabado,SalidaSabado,ParteDia from Libregco.TandasDetalle where IDTanda='" + txtIDTanda.Text + "' ORDER BY idTandasDetalle ASC", Con)
        Dim Lector As MySqlDataReader = GarantiaEspecifica.ExecuteReader

        While Lector.Read
            If Lector.GetValue(1) = 1 Then
                ImageDay = My.Resources.Morningx512
            ElseIf Lector.GetValue(1) = 2 Then
                ImageDay = My.Resources.Afternoonx512
            ElseIf Lector.GetValue(1) = 3 Then
                ImageDay = My.Resources.Nightx512
            End If

            DgvTandasDetalle.Rows.Add(Lector.GetValue(0), ImageDay, Lector.GetValue(2), Convert.ToBoolean(Lector.GetValue(3)), If(Lector.GetValue(3) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(4))).ToString("hh:mm:ss tt")), If(Lector.GetValue(3) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(5))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(6)), If(Lector.GetValue(6) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(7))).ToString("hh:mm:ss tt")), If(Lector.GetValue(6) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(8))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(9)), If(Lector.GetValue(9) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(10))).ToString("hh:mm:ss tt")), If(Lector.GetValue(9) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(11))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(12)), If(Lector.GetValue(12) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(13))).ToString("hh:mm:ss tt")), If(Lector.GetValue(12) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(14))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(15)), If(Lector.GetValue(15) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(16))).ToString("hh:mm:ss tt")), If(Lector.GetValue(15) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(17))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(18)), If(Lector.GetValue(18) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(19))).ToString("hh:mm:ss tt")), If(Lector.GetValue(18) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(20))).ToString("hh:mm:ss tt")), Convert.ToBoolean(Lector.GetValue(21)), If(Lector.GetValue(21) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(22))).ToString("hh:mm:ss tt")), If(Lector.GetValue(21) = "0", "N/A", CDate(Today.ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector.GetValue(23))).ToString("hh:mm:ss tt")), Lector.GetValue(24))

        End While

        Lector.Close()
        DgvTandasDetalle.ClearSelection()
        Con.Close()

    End Sub

    Private Sub ChangeDayImage()
        If rdbDia.Checked = True Then
            PictureBox1.Image = My.Resources.Morningx512
            PictureBox1.Tag = 1
            dtpDomingode.Value = Today & " 08:00 AM"
            dtpdomingohasta.Value = Today & " 12:00 PM"

            dtplunesde.Value = Today & " 08:00 AM"
            dtpluneshasta.Value = Today & " 12:00 PM"


            dtpmartesde.Value = Today & " 08:00 AM"
            dtpmarteshasta.Value = Today & " 12:00 PM"


            dtpmiercoelsde.Value = Today & " 08:00 AM"
            dtpmiercoleshasta.Value = Today & " 12:00 PM"


            dtpjuevesde.Value = Today & " 08:00 AM"
            dtpjueveshasta.Value = Today & " 12:00 PM"


            dtpviernesde.Value = Today & " 08:00 AM"
            dtpvierneshasta.Value = Today & " 12:00 PM"


            dtpsabadode.Value = Today & " 08:00 AM"
            dtpsabadohasta.Value = Today & " 12:00 PM"

            txtDescripcionHorario.Text = "Horario matutino"
        ElseIf rdbTarde.Checked = True Then
            PictureBox1.Image = My.Resources.Afternoonx512
            PictureBox1.Tag = 2

            dtpDomingode.Value = Today & " 02:00 PM"
            dtpdomingohasta.Value = Today & " 6:00 PM"

            dtplunesde.Value = Today & " 02:00 PM"
            dtpluneshasta.Value = Today & " 6:00 PM"


            dtpmartesde.Value = Today & " 02:00 PM"
            dtpmarteshasta.Value = Today & " 6:00 PM"


            dtpmiercoelsde.Value = Today & " 02:00 PM"
            dtpmiercoleshasta.Value = Today & " 6:00 PM"


            dtpjuevesde.Value = Today & " 02:00 PM"
            dtpjueveshasta.Value = Today & " 6:00 PM"


            dtpviernesde.Value = Today & " 02:00 PM"
            dtpvierneshasta.Value = Today & " 6:00 PM"


            dtpsabadode.Value = Today & " 02:00 PM"
            dtpsabadohasta.Value = Today & " 6:00 PM"

            txtDescripcionHorario.Text = "Horario vespertino"
        ElseIf rdbNoche.Checked = True Then
            PictureBox1.Image = My.Resources.Nightx512
            PictureBox1.Tag = 3

            dtpDomingode.Value = Today & " 6:00 AM"
            dtpdomingohasta.Value = Today & " 12:00 AM"

            dtplunesde.Value = Today & " 6:00 AM"
            dtpluneshasta.Value = Today & " 12:00 AM"


            dtpmartesde.Value = Today & " 6:00 AM"
            dtpmarteshasta.Value = Today & " 12:00 AM"


            dtpmiercoelsde.Value = Today & " 6:00 AM"
            dtpmiercoleshasta.Value = Today & " 12:00 AM"


            dtpjuevesde.Value = Today & " 6:00 AM"
            dtpjueveshasta.Value = Today & " 12:00 AM"


            dtpviernesde.Value = Today & " 6:00 AM"
            dtpvierneshasta.Value = Today & " 12:00 AM"


            dtpsabadode.Value = Today & " 6:00 AM"
            dtpsabadohasta.Value = Today & " 12:00 AM"
            txtDescripcionHorario.Text = "Horario nocturno"
        End If

    End Sub

    Private Sub rdbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDia.CheckedChanged
        ChangeDayImage()
    End Sub

    Private Sub rdbTarde_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTarde.CheckedChanged
        ChangeDayImage()
    End Sub

    Private Sub rdbNoche_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoche.CheckedChanged
        ChangeDayImage()
    End Sub

    Private Sub DgvTandasDetalle_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvTandasDetalle.RowsAdded
        If DgvTandasDetalle.Rows(e.RowIndex).Cells(3).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(4).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(5).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.White

        End If

        If DgvTandasDetalle.Rows(e.RowIndex).Cells(6).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(6).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(7).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(7).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(8).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(8).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(6).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(7).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(8).Style.BackColor = Color.White

        End If


        If DgvTandasDetalle.Rows(e.RowIndex).Cells(9).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(9).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(10).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(10).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(11).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(11).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(9).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(10).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(11).Style.BackColor = Color.White

        End If

        If DgvTandasDetalle.Rows(e.RowIndex).Cells(12).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(13).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(13).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(14).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(12).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(13).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.White

        End If

        If DgvTandasDetalle.Rows(e.RowIndex).Cells(15).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(16).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(16).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(17).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(17).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(16).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(17).Style.BackColor = Color.White

        End If

        If DgvTandasDetalle.Rows(e.RowIndex).Cells(18).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(18).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(19).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(19).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(20).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(20).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(18).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(19).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(20).Style.BackColor = Color.White

        End If

        If DgvTandasDetalle.Rows(e.RowIndex).Cells(21).Value = False Then
            DgvTandasDetalle.Rows(e.RowIndex).Cells(21).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(22).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(22).Value = "N/A"
            DgvTandasDetalle.Rows(e.RowIndex).Cells(23).Style.BackColor = Color.LightGray
            DgvTandasDetalle.Rows(e.RowIndex).Cells(23).Value = "N/A"
        Else
            DgvTandasDetalle.Rows(e.RowIndex).Cells(21).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(22).Style.BackColor = Color.White
            DgvTandasDetalle.Rows(e.RowIndex).Cells(23).Style.BackColor = Color.White

        End If
    End Sub

    Private Sub DgvTandasDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTandasDetalle.CellDoubleClick
        If e.RowIndex >= 0 Then
            Button1.Text = "Modificar horario"
            lblIDTandaDetalle = DgvTandasDetalle.Rows(e.RowIndex).Cells(0).Value
            PictureBox1.Image = DgvTandasDetalle.Rows(e.RowIndex).Cells(1).Value
            txtDescripcionHorario.Text = DgvTandasDetalle.Rows(e.RowIndex).Cells(2).Value

            chkdomingolaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(3).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(3).Value = True Then
                dtpDomingode.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(4).Value).ToString("hh:mm:ss")
                dtpdomingohasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(5).Value).ToString("hh:mm:ss")
            End If

            chkluneslaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(6).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(6).Value = True Then
                dtplunesde.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(7).Value).ToString("hh:mm:ss")
                dtpluneshasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(8).Value).ToString("hh:mm:ss")
            End If

            chkmarteslaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(9).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(9).Value = True Then
                dtpmartesde.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(10).Value).ToString("hh:mm:ss")
                dtpmarteshasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(11).Value).ToString("hh:mm:ss")
            End If

            chkmiercoleslaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(12).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(12).Value = True Then
                dtpmiercoelsde.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(13).Value).ToString("hh:mm:ss")
                dtpmiercoleshasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(14).Value).ToString("hh:mm:ss")
            End If

            chkjueveslaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(15).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(15).Value = True Then
                dtpjuevesde.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(16).Value).ToString("hh:mm:ss")
                dtpjueveshasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(17).Value).ToString("hh:mm:ss")
            End If

            chkvierneslaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(18).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(18).Value = True Then
                dtpviernesde.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(19).Value).ToString("hh:mm:ss")
                dtpvierneshasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(20).Value).ToString("hh:mm:ss")
            End If

            chksabadolaborable.Checked = DgvTandasDetalle.Rows(e.RowIndex).Cells(21).Value
            If DgvTandasDetalle.Rows(e.RowIndex).Cells(21).Value = True Then
                dtpsabadode.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(22).Value).ToString("hh:mm:ss")
                dtpsabadohasta.Value = Today & " " & CDate(DgvTandasDetalle.Rows(e.RowIndex).Cells(23).Value).ToString("hh:mm:ss")
            End If

            If DgvTandasDetalle.Rows(e.RowIndex).Cells(24).Value = 1 Then
                rdbDia.Checked = True
            ElseIf DgvTandasDetalle.Rows(e.RowIndex).Cells(24).Value = 2 Then
                rdbTarde.Checked = True
            ElseIf DgvTandasDetalle.Rows(e.RowIndex).Cells(24).Value = 3 Then
                rdbNoche.Checked = True
            End If
        End If
    End Sub

    Private Sub DgvTandasDetalle_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvTandasDetalle.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DgvTandasDetalle.Rows(e.RowIndex).Selected = True
                DgvTandasDetalle.CurrentCell = DgvTandasDetalle.Rows(e.RowIndex).Cells(2)
                CMenuPermisos.Show(DgvTandasDetalle, e.Location)
                CMenuPermisos.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub bt_Click(sender As Object, e As EventArgs) Handles bt.Click
        If DgvTandasDetalle.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el horario?", "Eliminar horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from Libregco.TandasDetalle Where IDTandasDetalle=(" + DgvTandasDetalle.CurrentRow.Cells(0).Value.ToString + ")"

                ConLibregco.Open()
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()

                DgvTandasDetalle.Rows.Remove(DgvTandasDetalle.CurrentRow)
            End If
        End If
    End Sub
End Class