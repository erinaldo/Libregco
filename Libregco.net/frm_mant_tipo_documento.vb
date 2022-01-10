Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_documento

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatos()
        txtTipoDocumento.Clear()
        txtIDTipoDocumento.Clear()
        txtLetra.Clear()
        txtCaracterRelleno.Clear()
        txtRepeticiones.Clear()
        txtUltimaSecuencia.Clear()
        txtMuestra.Clear()
    End Sub

    Private Sub ActualizarTodo()
        lblNulo.Text = 0
        chkNulo.Checked = False
        txtTipoDocumento.Focus()
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

    Private Sub UltBanco()
        Try

            If txtIDTipoDocumento.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTipoDocumento from TipoDocumento where IDTipoDocumento=(Select Max(IDTipoDocumento) from TipoDocumento)", Con)
                txtIDTipoDocumento.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltBanco")
        End Try
    End Sub

    Sub HabilitarControles()
        txtTipoDocumento.Enabled = True
        txtLetra.Enabled = True
        txtUltimaSecuencia.Enabled = True
        txtRepeticiones.Enabled = True
        txtCaracterRelleno.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        txtTipoDocumento.Enabled = False
        txtLetra.Enabled = False
        txtUltimaSecuencia.Enabled = False
        txtRepeticiones.Enabled = False
        txtCaracterRelleno.Enabled = False
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
        If txtTipoDocumento.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de concepto a guardar.", "Escriba la descripción del concepto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoDocumento.Focus()
            Exit Sub
        ElseIf txtLetra.Text = "" Then
            MessageBox.Show("Escriba la letra del documento para fines de impresión.", "Escriba la letra del tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLetra.Focus()
            Exit Sub
        ElseIf txtCaracterRelleno.Text = "" Then
            MessageBox.Show("Escriba el caracter que se repetirá para completar los tipos de documentos.", "Caracter de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCaracterRelleno.Focus()
            Exit Sub
        ElseIf txtRepeticiones.Text = "" Then
            MessageBox.Show("Defina la cantidad de repeticiones del caractér de relleno", "Repetición de relleno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRepeticiones.Focus()
            Exit Sub
        ElseIf txtUltimaSecuencia.Text = "" Then
            MessageBox.Show("Escriba el punto de partida del tipo de documento.", "Ultima secuencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtUltimaSecuencia.Focus()
            Exit Sub
        End If

        If txtIDTipoDocumento.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de documento: " & txtIDTipoDocumento.Text & " en la base de datos?", "Guardar Nuevo Concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoDocumento (Documento,Nulo,Letra,UltimaSecuencia,CantCharacter,Filler,Nulo) VALUES ('" + txtTipoDocumento.Text + "', '" + txtLetra.Text + "','" + txtUltimaSecuencia.Text + "','" + txtRepeticiones.Text + "','" + txtCaracterRelleno.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltBanco()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el concepto?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoDocumento SET Documento='" + txtTipoDocumento.Text + "',Letra='" + txtLetra.Text + "',UltimaSecuencia='" + txtUltimaSecuencia.Text + "',CantCharacter='" + txtRepeticiones.Text + "',Filler='" + txtCaracterRelleno.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoDocumento= (" + txtIDTipoDocumento.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtTipoDocumento.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de concepto a guardar.", "Escriba la descripción del concepto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoDocumento.Focus()
            Exit Sub
        ElseIf txtLetra.Text = "" Then
            MessageBox.Show("Escriba la letra del documento para fines de impresión.", "Escriba la letra del tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLetra.Focus()
            Exit Sub
        ElseIf txtCaracterRelleno.Text = "" Then
            MessageBox.Show("Escriba el caracter que se repetirá para completar los tipos de documentos.", "Caracter de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCaracterRelleno.Focus()
            Exit Sub
        ElseIf txtRepeticiones.Text = "" Then
            MessageBox.Show("Defina la cantidad de repeticiones del caractér de relleno", "Repetición de relleno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRepeticiones.Focus()
            Exit Sub
        ElseIf txtUltimaSecuencia.Text = "" Then
            MessageBox.Show("Escriba el punto de partida del tipo de documento.", "Ultima secuencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtUltimaSecuencia.Focus()
            Exit Sub
        End If

        If txtIDTipoDocumento.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de documento: " & txtIDTipoDocumento.Text & " en la base de datos?", "Guardar Nuevo Concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoDocumento (Documento,Nulo,Letra,UltimaSecuencia,CantCharacter,Filler,Nulo) VALUES ('" + txtTipoDocumento.Text + "', '" + txtLetra.Text + "','" + txtUltimaSecuencia.Text + "','" + txtRepeticiones.Text + "','" + txtCaracterRelleno.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltBanco()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnNuevo.PerformClick()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el concepto?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoDocumento SET Documento='" + txtTipoDocumento.Text + "',Letra='" + txtLetra.Text + "',UltimaSecuencia='" + txtUltimaSecuencia.Text + "',CantCharacter='" + txtRepeticiones.Text + "',Filler='" + txtCaracterRelleno.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoDocumento= (" + txtIDTipoDocumento.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnNuevo.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_documento.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtTipoDocumento.Text = "" Then
            MessageBox.Show("Escriba o defina el tipo de concepto a guardar.", "Escriba la descripción del concepto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtTipoDocumento.Focus()
            Exit Sub
        ElseIf txtLetra.Text = "" Then
            MessageBox.Show("Escriba la letra del documento para fines de impresión.", "Escriba la letra del tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLetra.Focus()
            Exit Sub
        ElseIf txtCaracterRelleno.Text = "" Then
            MessageBox.Show("Escriba el caracter que se repetirá para completar los tipos de documentos.", "Caracter de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCaracterRelleno.Focus()
            Exit Sub
        ElseIf txtRepeticiones.Text = "" Then
            MessageBox.Show("Defina la cantidad de repeticiones del caractér de relleno", "Repetición de relleno", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRepeticiones.Focus()
            Exit Sub
        ElseIf txtUltimaSecuencia.Text = "" Then
            MessageBox.Show("Escriba el punto de partida del tipo de documento.", "Ultima secuencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtUltimaSecuencia.Focus()
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El Concepto código No. " & txtIDTipoDocumento.Text & ", " & txtTipoDocumento.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 71
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                sqlQ = "UPDATE TipoDocumento SET Documento='" + txtTipoDocumento.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoDocumento= (" + txtIDTipoDocumento.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDTipoDocumento.Text = "" Then
            MessageBox.Show("No hay un registro de concepto abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro del concepto " & txtTipoDocumento.Text & " del sistema?", "Anular Concepto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 72
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                sqlQ = "UPDATE TipoDocumento SET Documento='" + txtTipoDocumento.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoDocumento= (" + txtIDTipoDocumento.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtUltimaSecuencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUltimaSecuencia.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtRepeticiones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRepeticiones.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Sub HacerMuestra()
        Dim Ultimo As String

        Ultimo = txtUltimaSecuencia.Text

        If txtLetra.Text <> "" And txtCaracterRelleno.Text <> "" And txtRepeticiones.Text <> "" And txtUltimaSecuencia.Text <> "" Then
            txtMuestra.Text = txtLetra.Text & (Ultimo.PadLeft(CInt(txtRepeticiones.Text), txtCaracterRelleno.Text))
        End If
    End Sub

    Private Sub txtLetra_TextChanged(sender As Object, e As EventArgs) Handles txtLetra.TextChanged
        HacerMuestra()
    End Sub

    Private Sub txtUltimaSecuencia_TextChanged(sender As Object, e As EventArgs) Handles txtUltimaSecuencia.TextChanged
        HacerMuestra()
    End Sub

    Private Sub txtCaracterRelleno_TextChanged(sender As Object, e As EventArgs) Handles txtCaracterRelleno.TextChanged
        HacerMuestra()
    End Sub

    Private Sub txtRepeticiones_TextChanged(sender As Object, e As EventArgs) Handles txtRepeticiones.TextChanged
        HacerMuestra()
    End Sub
End Class