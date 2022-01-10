Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_mant_ing_dec

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDFuncion, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_ing_dec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDDeduccion.Clear()
        txtDescripcion.Clear()
        CbxFuncion.Items.Clear()
        txtPorcentaje.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        FillFuncion()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtDescripcion.Focus()
    End Sub

    Private Sub FillFuncion()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoFuncion ORDER BY Descripcion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoFuncion")
        CbxFuncion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoFuncion")
        For Each Fila As DataRow In Tabla.Rows
            CbxFuncion.Items.Add(Fila.Item("Descripcion"))
        Next

    End Sub

    Private Sub SetIDFuncion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoFuncion FROM TipoFuncion WHERE Descripcion= '" + CbxFuncion.SelectedItem + "'", ConLibregco)
        lblIDFuncion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        CbxFuncion.Enabled = True
        txtPorcentaje.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtDescripcion.Enabled = False
        CbxFuncion.Enabled = False
        txtPorcentaje.Enabled = False
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

            ConLibregcoMain.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltDeduccion()
        Try
            If txtIDDeduccion.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDDeduccion from Deducciones where IDDeduccion= (Select Max(IDDeduccion) from Deducciones)", Con)
                txtIDDeduccion.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltDeduccion()")
        End Try
    End Sub

    Private Sub CbxFuncion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFuncion.SelectedIndexChanged
        SetIDFuncion()
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

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtPorcentaje_Enter(sender As Object, e As EventArgs) Handles txtPorcentaje.Enter
        Try
            If txtPorcentaje.Text = "" Then
            Else
                txtPorcentaje.Text = CDbl(Replace(txtPorcentaje.Text, "%", "")) / 100
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPorcentaje_Leave(sender As Object, e As EventArgs) Handles txtPorcentaje.Leave
        Try
            If txtPorcentaje.Text = "" Then
            Else
                txtPorcentaje.Text = CDbl(txtPorcentaje.Text).ToString("P2")
            End If
        Catch ex As Exception
            txtPorcentaje.Text = ""
        End Try
    End Sub

    Private Sub ConvertDouble()
        txtPorcentaje.Text = CDbl(Replace(txtPorcentaje.Text, "%", "")) / 100
    End Sub

    Private Sub ConvertCurrent()
        txtPorcentaje.Text = CDbl(txtPorcentaje.Text).ToString("P2")
    End Sub

  
    Private Sub btnNuevo_Click_1(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción del ingreso o deducción.", "Descripción ingreso/deducción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf CbxFuncion.Text = "" Then
            MessageBox.Show("Seleccione la función del tipo de ingreso/deducción.", "Función de registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFuncion.Focus()
            CbxFuncion.DroppedDown = True
        ElseIf txtPorcentaje.Text = "" Then
            MessageBox.Show("Escriba el porcentaje que afecta este tipo de ingreso/deducción", "Porcentaje de afección", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPorcentaje.Focus()
            Exit Sub
        End If

        If txtIDDeduccion.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la deducción " & txtDescripcion.Text & " en la base de datos?", "Guardar Nueva Deduccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Deducciones (IDTipoFuncion,Descripcion,Porciento,Nulo) VALUES ('" + lblIDFuncion.Text + "','" + txtDescripcion.Text + "','" + txtPorcentaje.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltDeduccion()
                ConvertCurrent()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la deducción", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Deducciones SET Descripcion='" + txtDescripcion.Text + "',Porciento='" + txtPorcentaje.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDeduccion= (" + txtIDDeduccion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_deducciones.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción del ingreso o deducción.", "Descripción ingreso/deducción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf CbxFuncion.Text = "" Then
            MessageBox.Show("Seleccione la función del tipo de ingreso/deducción.", "Función de registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFuncion.Focus()
            CbxFuncion.DroppedDown = True
        ElseIf txtPorcentaje.Text = "" Then
            MessageBox.Show("Escriba el porcentaje que afecta este tipo de ingreso/deducción", "Porcentaje de afección", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPorcentaje.Focus()
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La deducción código. " & txtIDDeduccion.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Deducción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 61
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Deducciones SET Descripcion='" + txtDescripcion.Text + "',Porciento='" + txtPorcentaje.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDeduccion= (" + txtIDDeduccion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDDeduccion.Text = "" Then
            MessageBox.Show("No hay un registro de marca abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la deducción Código. " & txtIDDeduccion.Text & " / " & txtDescripcion.Text & " del sistema?", "Anular Deducción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 60
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Deducciones SET Descripcion='" + txtDescripcion.Text + "',Porciento='" + txtPorcentaje.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDeduccion= (" + txtIDDeduccion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción del ingreso o deducción.", "Descripción ingreso/deducción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf CbxFuncion.Text = "" Then
            MessageBox.Show("Seleccione la función del tipo de ingreso/deducción.", "Función de registro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFuncion.Focus()
            CbxFuncion.DroppedDown = True
        ElseIf txtPorcentaje.Text = "" Then
            MessageBox.Show("Escriba el porcentaje que afecta este tipo de ingreso/deducción", "Porcentaje de afección", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPorcentaje.Focus()
            Exit Sub
        End If

        If txtIDDeduccion.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la deducción " & txtDescripcion.Text & " en la base de datos?", "Guardar Nueva Deduccion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Deducciones (IDTipoFuncion,Descripcion,Porciento,Nulo) VALUES ('" + lblIDFuncion.Text + "','" + txtDescripcion.Text + "','" + txtPorcentaje.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltDeduccion()
                ConvertCurrent()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la deducción", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Deducciones SET Descripcion='" + txtDescripcion.Text + "',Porciento='" + txtPorcentaje.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDeduccion= (" + txtIDDeduccion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub
End Class