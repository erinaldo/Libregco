Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_comision_cobros

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_comision_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        Permisos = PasarPermisos(Me.Tag)
        CargarLibregco()
        CargarEmpresa()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDComision.Clear()
        txtDescripcion.Clear()
        txtComision.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtDescripcion.Focus()
    End Sub

    Private Sub CargarEmpresa()
PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub txtComision_Enter(sender As Object, e As EventArgs) Handles txtComision.Enter
        Try
            If txtComision.Text = "" Then
            Else
                txtComision.Text = Replace(txtComision.Text, "%", "")
                txtComision.SelectAll()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtComision_Leave(sender As Object, e As EventArgs) Handles txtComision.Leave
        If txtComision.Text = "" Then
            txtComision.Text = CDbl(0).ToString("P")
        Else
            txtComision.Text = (CDbl(txtComision.Text) / 100).ToString("P")
        End If
    End Sub

    Private Sub txtComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComision.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        txtComision.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        txtDescripcion.Enabled = False
        txtComision.Enabled = False
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

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub UltComision()
        Try

            If txtIDComision.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDComisionCobro from ComisionCobro where IDComisionCobro= (Select Max(IDComisionCobro) from ComisionCobro)", Con)
                txtIDComision.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltComision()")
        End Try
    End Sub

    Private Sub ConvertCdblPorcentaje()
        txtComision.Text = Replace(txtComision.Text, "%", "")
        txtComision.Text = CDbl(txtComision.Text) / 100
    End Sub

    Private Sub ConverStringPorcentaje()
        txtComision.Text = CDbl(txtComision.Text).ToString("P")
    End Sub
    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
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
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Describa el tipo de comisión de cobros del registro.", "Descripción del tipo de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf txtComision.Text = "" Then
            MessageBox.Show("Especifique el porciento de pago al cobrador por concepto de este tipo de comisión.", "Especifique Porcentaje de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComision.Focus()
            Exit Sub
        End If

        If txtIDComision.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de comisión: " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Tipo de Comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "INSERT INTO ComisionCobro (Descripcion,Comision,Nulo) VALUES ('" + txtDescripcion.Text + "','" + Replace(txtComision.Text, "%", "") + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltComision()
                ConverStringPorcentaje()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DesHabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de comisión de cobros?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE ComisionCobro SET Descripcion='" + txtDescripcion.Text + "',Comision='" + Replace(txtComision.Text, "%", "") + "',Nulo='" + lblNulo.Text + "' WHERE IDComisionCobro= '" + txtIDComision.Text + "'"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Describa el tipo de comisión de cobros del registro.", "Descripción del tipo de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf txtComision.Text = "" Then
            MessageBox.Show("Especifique el porciento de pago al cobrador por concepto de este tipo de comisión.", "Especifique Porcentaje de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComision.Focus()
            Exit Sub
        End If

        If txtIDComision.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de comisión: " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Tipo de Comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "INSERT INTO ComisionCobro (Descripcion,Comision,Nulo) VALUES ('" + txtDescripcion.Text + "','" + Replace(txtComision.Text, "%", "") + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltComision()
                ConverStringPorcentaje()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de comisión de cobros?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE ComisionCobro SET Descripcion='" + txtDescripcion.Text + "',Comision='" + Replace(txtComision.Text, "%", "") + "',Nulo='" + lblNulo.Text + "' WHERE IDComisionCobro= '" + txtIDComision.Text + "'"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_comision_cobro.ShowDialog(Me)
    End Sub

    Private Sub btnNulo_Click(sender As Object, e As EventArgs) Handles btnNulo.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Describa el tipo de comisión de cobros del registro.", "Descripción del tipo de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf txtComision.Text = "" Then
            MessageBox.Show("Especifique el porciento de pago al cobrador por concepto de este tipo de comisión.", "Especifique Porcentaje de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtComision.Focus()
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de comisión de cobros código [ " & txtIDComision.Text & "] ya está anulado en el sistema. Desea activarla?", "Recuperar tipo de comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE ComisionCobro SET Descripcion='" + txtDescripcion.Text + "',Comision='" + txtComision.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDComisionCobro= '" + txtIDComision.Text + "'"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDComision.Text = "" Then
            MessageBox.Show("No hay un registro de comisión de cobros abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de comisión de cobros código [" & txtIDComision.Text & "] " & txtDescripcion.Text & " del sistema?", "Anular tipo de comisión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                ConvertCdblPorcentaje()
                sqlQ = "UPDATE ComisionCobro SET Descripcion='" + txtDescripcion.Text + "',Comision='" + Replace(txtComision.Text, "%", "") + "',Nulo='" + lblNulo.Text + "' WHERE IDComisionCobro= '" + txtIDComision.Text + "'"
                GuardarDatos()
                ConverStringPorcentaje()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class

