Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_ajustes_inventario

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds = New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDFuncion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_ajustes_inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        LimpiarDatos()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
  PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoAjuste.Clear()
        txtDescripcion.Clear()
    End Sub

    Private Sub ActualizarTodo()
        FillFuncion()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        lblStatusBar.Text = "Listo"
        txtDescripcion.Focus()
    End Sub

    Private Sub FillFuncion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoFuncion ORDER BY IDTipoFuncion ASC", ConLibregco)
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

    Private Sub UltIDAjuste()
        Try
            If txtIDTipoAjuste.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDAjusteInventario from TipodeAjuste where IDAjusteInventario= (Select Max(IDAjusteInventario) from TipodeAjuste)", ConLibregco)
                txtIDTipoAjuste.Text = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtDescripcion.Enabled = False
        CbxFuncion.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        CbxFuncion.Enabled = True
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

    Private Sub CbxFuncion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFuncion.SelectedIndexChanged
        SetIDFuncion()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba y/o defina la descripción de ajuste de inventario.", "Escriba descripción de ajuste de inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf CbxFuncion.Text = "" Then
            MessageBox.Show("Seleccione el tipo de función del tipo de ajuste a registrar.", "Seleccionar tipo de función", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFuncion.Focus()
            CbxFuncion.DroppedDown = True
            Exit Sub
        End If

        If txtIDTipoAjuste.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de ajuste de inventario " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Tipo de Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipodeAjuste (TipodeAjuste,IDTipoFuncion,Nulo) VALUES ('" + txtDescripcion.Text + "','" + lblIDFuncion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltIDAjuste()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de ajuste?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                sqlQ = "UPDATE TipodeAjuste SET TipodeAjuste='" + txtDescripcion.Text + "',IDTipoFuncion='" + lblIDFuncion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDTipoAjuste.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba y/o defina la descripción de ajuste de inventario.", "Escriba descripción de ajuste de inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf CbxFuncion.Text = "" Then
            MessageBox.Show("Seleccione el tipo de función del tipo de ajuste a registrar.", "Seleccionar tipo de función", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFuncion.Focus()
            CbxFuncion.DroppedDown = True
            Exit Sub
        End If

        If txtIDTipoAjuste.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de ajuste de inventario " & txtDescripcion.Text & " en la base de datos?", "Guardar Nuevo Tipo de Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "INSERT INTO TipodeAjuste (TipodeAjuste,IDTipoFuncion,Nulo) VALUES ('" + txtDescripcion.Text + "','" + lblIDFuncion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltIDAjuste()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el tipo de ajuste?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                sqlQ = "UPDATE TipodeAjuste SET TipodeAjuste='" + txtDescripcion.Text + "',IDTipoFuncion='" + lblIDFuncion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDTipoAjuste.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La tipo de ajuste código. " & txtIDTipoAjuste.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Tipo de Ajuste", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 50
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                sqlQ = "UPDATE TipodeAjuste SET TipodeAjuste='" + txtDescripcion.Text + "',IDTipoFuncion='" + lblIDFuncion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDTipoAjuste.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTipoAjuste.Text = "" Then
            MessageBox.Show("No hay un registro de tipo de ajuste de inventario  abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el ajuste de inventario Código. " & txtIDTipoAjuste.Text & " / " & txtDescripcion.Text & " del sistema?", "Anular Tipo de Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 48
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                sqlQ = "UPDATE TipodeAjuste SET TipodeAjuste='" + txtDescripcion.Text + "',IDTipoFuncion='" + lblIDFuncion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAjusteInventario= (" + txtIDTipoAjuste.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_ajuste_inventario.ShowDialog(Me)
    End Sub
End Class