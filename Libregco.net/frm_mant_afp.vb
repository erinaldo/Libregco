Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_afp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_afp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDAFP.Clear()
        txtAFP.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtAFP.Focus()
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

    Private Sub UltAFP()
        Try
            If txtIDAFP.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAFP from AFP where IDAFP= (Select Max(IDAFP) from AFP)", Con)
                txtIDAFP.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtAFP.Enabled = False
        txtDireccion.Enabled = False
        txtTelefono.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtAFP.Enabled = True
        txtDireccion.Enabled = True
        txtTelefono.Enabled = True
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtAFP.Text = "" Then
            MessageBox.Show("Escriba el nombre de la aseguradora de riesgos laborales (AFP) para procesar el registro.", "Escriba Nombre de AFP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAFP.Focus()
            Exit Sub
        End If
        If txtIDAfp.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la AFP " & txtAFP.Text & " en la base de datos?", "Guardar Nueva AFP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO AFP (Descripcion,Direccion,Telefono,Nulo) VALUES ('" + txtAFP.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltAFP()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la AFP?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE AFP SET Descripcion='" + txtAFP.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAFP= (" + txtIDAfp.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtAFP.Text = "" Then
            MessageBox.Show("Escriba el nombre de la aseguradora de riesgos laborales (AFP) para procesar el registro.", "Escriba Nombre de AFP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAFP.Focus()
            Exit Sub
        End If
        If txtIDAfp.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la AFP " & txtAFP.Text & " en la base de datos?", "Guardar Nueva AFP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO AFP (Descripcion,Direccion,Telefono,Nulo) VALUES ('" + txtAFP.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltAFP()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la AFP?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE AFP SET Descripcion='" + txtAFP.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAFP= (" + txtIDAfp.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_afp.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtAFP.Text = "" Then
            MessageBox.Show("Escriba el nombre de la aseguradora de riesgos laborales (AFP) para procesar el registro.", "Escriba Nombre de AFP", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAFP.Focus()
            Exit Sub
        End If
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La AFP Código. " & txtIDAfp.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar AFP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE AFP SET Descripcion='" + txtAFP.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAFP= (" + txtIDAfp.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDAfp.Text = "" Then
            MessageBox.Show("No hay un registro de AFP abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la AFP Código. " & txtIDAfp.Text & " / " & txtAFP.Text & " del sistema?", "Anular AFP", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE AFP SET Descripcion='" + txtAFP.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAFP= (" + txtIDAfp.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub
End Class