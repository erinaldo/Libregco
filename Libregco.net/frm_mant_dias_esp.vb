Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_dias_esp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList

    Private Sub frm_dia_nolaboral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDDia.Clear()
        dtpDia.Value = Today
        txtCelebracion.Clear()
        TSLaborable.IsOn = False
        TSLaborable.Tag = 0
        rdbPatrio.Checked = True
        SelectMotivo()
        txtEstado.Clear()
        chkNulo.Checked = False
        chkNulo.Tag = 0
        dtpDia.Focus()
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

    Private Sub UltIDDia()
        If txtIDDia.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDDia from DiasEspeciales where IDDia= (Select Max(IDDia) from DiasEspeciales)", ConLibregco)
            txtIDDia.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            chkNulo.Tag = 1
            DeshabilitarControles()
        Else
            chkNulo.Tag = 0
            HabilitarControles()

        End If
    End Sub

    Private Sub HabilitarControles()
        dtpDia.Enabled = True
        txtCelebracion.Enabled = True
        TSLaborable.Enabled = True
        rdbPatrio.Enabled = True
        txtEstado.Enabled = True
        chkNulo.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        dtpDia.Enabled = False
        txtCelebracion.Enabled = False
        TSLaborable.Enabled = False
        rdbPatrio.Enabled = False
        txtEstado.Enabled = False
        chkNulo.Enabled = False
    End Sub


    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
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

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtCelebracion.Text = "" Then
            MessageBox.Show("Especifique la celebración correspondiente al día " & dtpDia.Value & ".", "Especifique la celebración", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCelebracion.Focus()
            Exit Sub
        End If

        If txtIDDia.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el registro de día especial " & dtpDia.Value & " en la base de datos?", "Guardar Día", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO DiasEspeciales (Dia,Celebracion,Laborable,IDMotivo,Estado,Nulo) VALUES ('" + dtpDia.Value.ToString("yyyy-MM-dd") + "','" + txtCelebracion.Text + "','" + TSLaborable.Tag.ToString + "','" + GroupBox2.Tag.ToString + "','" + txtEstado.Text + "','" + chkNulo.Tag.ToString + "')"
                GuardarDatos1()
                UltIDDia()
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
                sqlQ = "UPDATE DiasEspeciales SET Dia='" + dtpDia.Value.ToString("yyyy-MM-dd") + "',Celebracion='" + txtCelebracion.Text + "',Laborable='" + TSLaborable.Tag.ToString + "',IDMotivo='" + GroupBox2.Tag.ToString + "',Estado='" + txtEstado.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDia=(" + txtIDDia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub TSLaborable_Toggled(sender As Object, e As EventArgs) Handles TSLaborable.Toggled
        If TSLaborable.IsOn = True Then
            TSLaborable.Tag = 1
        Else
            TSLaborable.Tag = 0
        End If
    End Sub

    Private Sub rdbPatrio_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPatrio.CheckedChanged
        SelectMotivo()
    End Sub

    Private Sub rdbReligioso_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReligioso.CheckedChanged
        SelectMotivo()
    End Sub

    Private Sub rdbCultural_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCultural.CheckedChanged
        SelectMotivo()
    End Sub

    Private Sub SelectMotivo()
        If rdbPatrio.Checked = True Then
            GroupBox2.Tag = 1
        ElseIf rdbReligioso.Checked = True Then
            GroupBox2.Tag = 2
        ElseIf rdbCultural.Checked = True Then
            GroupBox2.Tag = 3
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El día " & dtpDia.Value & "  ya está desactivada del sistema. Desea volver a activarlo?", "Activar día", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE DiasEspeciales SET Dia='" + dtpDia.Value.ToString("yyyy-MM-dd") + "',Celebracion='" + txtCelebracion.Text + "',Laborable='" + TSLaborable.Tag.ToString + "',IDMotivo='" + GroupBox2.Tag.ToString + "',Estado='" + txtEstado.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDia=(" + txtIDDia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDDia.Text = "" Then
            MessageBox.Show("No hay un registro de día abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro del día " & dtpDia.Value & " del sistema?", "Desactivar día especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE DiasEspeciales SET Dia='" + dtpDia.Value.ToString("yyyy-MM-dd") + "',Celebracion='" + txtCelebracion.Text + "',Laborable='" + TSLaborable.Tag.ToString + "',IDMotivo='" + GroupBox2.Tag.ToString + "',Estado='" + txtEstado.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDia=(" + txtIDDia.Text + ")"
                GuardarDatos1()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_Dia.ShowDialog(Me)
    End Sub
End Class