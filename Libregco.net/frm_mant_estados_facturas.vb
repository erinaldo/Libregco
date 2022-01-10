Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_estados_facturas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_estados_facturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDEstado.Clear()
        txtEstado.Clear()
        txtDescripcion.Clear()
        lblColor.Text = ""
        lblColor.BackColor = SystemColors.Control
        lblchkNulo.Text = 0
        chkNulo.Checked = False
        txtEstado.Clear()
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltEstado()
        If txtIDEstado.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDEstadoFactura from EstadoFactura where IDEstadoFactura= (Select Max(IDEstadoFactura) from EstadoFactura)", ConLibregco)
            txtIDEstado.Text = Convert.ToDouble(cmd.ExecuteScalar)
            ConLibregco.Close()
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
        txtEstado.Enabled = True
        txtDescripcion.Enabled = True
        lblColor.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtEstado.Enabled = False
        txtDescripcion.Enabled = False
        lblColor.Enabled = False
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        HabilitarControles()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtEstado.Text = "" Then
            MessageBox.Show("Escriba el estado que resume la descripción del status de la factura.", "Escribir estatus", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtEstado.Focus()
            Exit Sub
        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve definición de estado de la factura.", "Escribir descripción de estado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf lblColor.BackColor = SystemColors.Control Then
            MessageBox.Show("Específique un color para el estado de facturas.", "Elegir color", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtIDEstado.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el nuevo status de factura [" & txtIDEstado.Text & "] " & txtEstado.Text & "?", "Guardar nuevo estatus de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO EstadoFactura (EstadoFactura,DescripcionEstado,Color,Nulo) VALUES ('" + txtEstado.Text + "','" + txtDescripcion.Text + "','" + lblColor.BackColor.ToArgb.ToString + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                UltEstado()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE EstadoFactura SET EstadoFactura='" + txtEstado.Text + "',DescripcionEstado='" + txtDescripcion.Text + "',Color='" + lblColor.BackColor.ToArgb.ToString + "',Nulo='" + lblchkNulo.Text + "' WHERE IDEstadoFactura= (" + txtIDEstado.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_estado_factura.ShowDialog(Me)
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtEstado.Text = "" Then
            MessageBox.Show("Escriba el estado que resume la descripción del status de la factura.", "Escribir estatus", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtEstado.Focus()
            Exit Sub
        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve definición de estado de la factura.", "Escribir descripción de estado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf lblColor.BackColor = SystemColors.Control Then
            MessageBox.Show("Específique un color para el estado de facturas.", "Elegir color", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtIDEstado.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el nuevo status de factura [" & txtIDEstado.Text & "] " & txtEstado.Text & "?", "Guardar nuevo estatus de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO EstadoFactura (EstadoFactura,DescripcionEstado,Color,Nulo) VALUES ('" + txtEstado.Text + "','" + txtDescripcion.Text + "','" + lblColor.BackColor.ToArgb.ToString + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                UltEstado()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE EstadoFactura SET EstadoFactura='" + txtEstado.Text + "',DescripcionEstado='" + txtDescripcion.Text + "',Color='" + lblColor.BackColor.ToArgb.ToString + "',Nulo='" + lblchkNulo.Text + "' WHERE IDEstadoFactura= (" + txtIDEstado.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtEstado.Text = "" Then
            MessageBox.Show("Escriba el estado que resume la descripción del status de la factura.", "Escribir estatus", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtEstado.Focus()
            Exit Sub
        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve definición de estado de la factura.", "Escribir descripción de estado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf lblColor.BackColor = SystemColors.Control Then
            MessageBox.Show("Específique un color para el estado de facturas.", "Elegir color", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El estado de factura " & txtEstado.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar estado de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE EstadoFactura SET EstadoFactura='" + txtEstado.Text + "',DescripcionEstado='" + txtDescripcion.Text + "',Color='" + lblColor.BackColor.ToArgb.ToString + "',Nulo='" + lblchkNulo.Text + "' WHERE IDEstadoFactura= (" + txtIDEstado.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDEstado.Text = "" Then
            MessageBox.Show("No hay un registro de estado de factura abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de estado de factura " & txtEstado.Text & " del sistema?", "Desactivar estado de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE EstadoFactura SET EstadoFactura='" + txtEstado.Text + "',DescripcionEstado='" + txtDescripcion.Text + "',Color='" + lblColor.BackColor.ToArgb.ToString + "',Nulo='" + lblchkNulo.Text + "' WHERE IDEstadoFactura= (" + txtIDEstado.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub lblColor_Click(sender As Object, e As EventArgs) Handles lblColor.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            lblColor.BackColor = CDialog.Color
        End If
    End Sub
End Class