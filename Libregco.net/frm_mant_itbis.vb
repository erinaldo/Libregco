Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_itbis

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds = New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkDesactivar As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_itbis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        lblchkDesactivar.Text = 0
        txtPorcentaje.Focus()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatosItbis()
        txtIDItbis.Clear()
        txtPorcentaje.Clear()
        txtTipoItbis.Clear()
        txtSigno.Clear()
        chkDesactivar.Checked = False
    End Sub

    Private Sub ConvertCdblPorcentaje()
        txtPorcentaje.Text = Replace(txtPorcentaje.Text, "%", "")
        txtPorcentaje.Text = CDbl(txtPorcentaje.Text) / 100
    End Sub

    Private Sub ConverStringPorcentaje()
        txtPorcentaje.Text = CDbl(txtPorcentaje.Text).ToString("P")
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

    Private Sub UltItbis()
        If txtIDItbis.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDTipoItbis from TipoItbis where IDTipoItbis= (Select Max(IDTipoItbis) from TipoItbis)", ConLibregco)
            txtIDItbis.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblchkDesactivar.Text = 1
            InhabilitarItbis()
        Else
            lblchkDesactivar.Text = 0
            HabilitarItbis()

        End If
    End Sub

    Private Sub InhabilitarItbis()
        txtPorcentaje.Enabled = False
        txtTipoItbis.Enabled = False
    End Sub

    Private Sub HabilitarItbis()
        txtPorcentaje.Enabled = True
        txtTipoItbis.Enabled = True
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

    Private Sub frm_mant_departamentos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiarDatosItbis()
    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPorcentaje_Leave(sender As Object, e As EventArgs) Handles txtPorcentaje.Leave
        If txtPorcentaje.Text = "" Then
            txtPorcentaje.Text = CDbl(0).ToString("P")
        Else
            If txtPorcentaje.Text > 100 Then
                txtPorcentaje.Clear()
            End If

            txtPorcentaje.Text = (CDbl(txtPorcentaje.Text) / 100).ToString("P")
        End If
    End Sub

    Private Sub txtPorcentaje_Enter(sender As Object, e As EventArgs) Handles txtPorcentaje.Enter
        Try
            If txtPorcentaje.Text = "" Then
            Else
                txtPorcentaje.Text = Replace(txtPorcentaje.Text, "%", "")
                txtPorcentaje.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatosItbis()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtTipoItbis.Text = "" Then
            MessageBox.Show("Escriba una breve descripción del tipo de itbis a procesar.", "Escribir descripción del ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTipoItbis.Focus()
            Exit Sub
        ElseIf txtPorcentaje.Text = "" Then
            MessageBox.Show("Específique el porcentaje equivalente al itbis a procesar.", "Especificar ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPorcentaje.Focus()
            Exit Sub
        End If

        If txtIDItbis.Text = "" Then 'Si no hay un itbis seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el impuesto ITBIS de " & txtTipoItbis.Text & " en la base de datos?", "Guardar Nuevo Impuesto de ITBIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "INSERT INTO TipoItbis (Itbis,Tipo,Signo,Desactivar) VALUES ('" + txtPorcentaje.Text + "','" + txtTipoItbis.Text + "','" + txtSigno.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                UltItbis()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE TipoItbis SET Itbis='" + txtPorcentaje.Text + "',Tipo='" + txtTipoItbis.Text + "',Signo='" + txtSigno.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDTipoItbis= (" + txtIDItbis.Text + ")"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtTipoItbis.Text = "" Then
            MessageBox.Show("Escriba una breve descripción del tipo de itbis a procesar.", "Escribir descripción del ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTipoItbis.Focus()
            Exit Sub
        ElseIf txtPorcentaje.Text = "" Then
            MessageBox.Show("Específique el porcentaje equivalente al itbis a procesar.", "Especificar ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPorcentaje.Focus()
            Exit Sub
        End If

        If txtIDItbis.Text = "" Then 'Si no hay un itbis seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el impuesto ITBIS de " & txtTipoItbis.Text & " en la base de datos?", "Guardar Nuevo Impuesto de ITBIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "INSERT INTO TipoItbis (Itbis,Tipo,Signo,Desactivar) VALUES ('" + txtPorcentaje.Text + "','" + txtTipoItbis.Text + "','" + txtSigno.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltItbis()
                ConverStringPorcentaje()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosItbis()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE TipoItbis SET Itbis='" + txtPorcentaje.Text + "',Tipo='" + txtTipoItbis.Text + "',Signo='" + txtSigno.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDTipoItbis= (" + txtIDItbis.Text + ")"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosItbis()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_itbis.ShowDialog(Me)
    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El impuesto " & txtTipoItbis.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE TipoItbis SET Itbis='" + txtPorcentaje.Text + "',Tipo='" + txtTipoItbis.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDTipoItbis= (" + txtIDItbis.Text + ")"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDItbis.Text = "" Then
            MessageBox.Show("No hay un registro de ITBIS abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del impuesto " & txtTipoItbis.Text & " del sistema?", "Desactivar Tipo de ITBIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                chkDesactivar.Checked = True
                sqlQ = "UPDATE TipoItbis SET Itbis='" + txtPorcentaje.Text + "',Tipo='" + txtTipoItbis.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDTipoItbis= (" + txtIDItbis.Text + ")"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

  
End Class
