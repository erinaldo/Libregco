Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_categorias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList
    Friend lblRutaFoto As New Label
    Private Sub frm_mant_categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        LimpiarDatos()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        txtCategoria.Focus()
        lblRutaFoto.Text = ""
        PicImagen.Image = My.Resources.No_Image
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
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltCategoria()
        Try
            If txtIDCategoria.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDCategoria from Categoria where IDCategoria= (Select Max(IDCategoria) from Categoria)", ConLibregco)
                txtIDCategoria.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtCategoria.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtCategoria.Enabled = True
    End Sub

    Private Sub btn_BuscarDepartamento_Click(sender As Object, e As EventArgs) Handles btn_BuscarDepartamento.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btn_BuscarDepartamento.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub HabilitarGuardar()
        If txtCategoria.Text = "" Or txtDepartamento.Text = "" Then
            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub txtDepartamento_TextChanged(sender As Object, e As EventArgs) Handles txtDepartamento.TextChanged
        HabilitarGuardar()
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        HabilitarGuardar()
    End Sub

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCategoria.Text = "" Then 'Si no hay categoria
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If txtIDDepartamento.Text = "" Then
                MessageBox.Show("Seleccione un departamento de artículos válido para generar las categorías de artículos.", "Departamento no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf txtCategoria.Text = "" Then
                MessageBox.Show("Haga una breve descripción de  la categoría de artículos que desea generar.", "Descripción de categoría vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la categoría " & txtCategoria.Text & " en la base de datos?", "Guardar Nueva Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Categoria (IDDepartamento,Categoria,CategoriaFilePath,Nulo) VALUES ('" + txtIDDepartamento.Text + "','" + txtCategoria.Text + "','','" + lblNulo.Text + "')"
                GuardarDatos()
                UltCategoria()
                SetCategoryImage(txtIDCategoria.text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la categoría?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Categoria SET IDDepartamento='" + txtIDDepartamento.Text + "',Categoria='" + txtCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCategoria= (" + txtIDCategoria.Text + ")"
                GuardarDatos()
                SetCategoryImage(txtIDCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCategoria.Text = "" Then 'Si no hay categoria
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If txtIDDepartamento.Text = "" Then
                MessageBox.Show("Seleccione un departamento de artículos válido para generar las categorías de artículos.", "Departamento no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf txtCategoria.Text = "" Then
                MessageBox.Show("Haga una breve descripción de  la categoría de artículos que desea generar.", "Descripción de categoría vacía", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la categoría " & txtCategoria.Text & " en la base de datos?", "Guardar Nueva Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Categoria (IDDepartamento,Categoria,CategoriaFilePath,Nulo) VALUES ('" + txtIDDepartamento.Text + "','" + txtCategoria.Text + "','','" + lblNulo.Text + "')"
                GuardarDatos()
                UltCategoria()
                SetCategoryImage(txtIDCategoria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la categoría?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Categoria SET IDDepartamento='" + txtIDDepartamento.Text + "',Categoria='" + txtCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCategoria= (" + txtIDCategoria.Text + ")"
                GuardarDatos()
                SetCategoryImage(txtIDCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_categorias.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Categoría Código. " & txtIDCategoria.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 54
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                sqlQ = "UPDATE Categoria SET IDDepartamento='" + txtIDDepartamento.Text + "',Categoria='" + txtCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCategoria= (" + txtIDCategoria.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCategoria.Text = "" Then
            MessageBox.Show("No hay un registro de categoría abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la categoría Código. " & txtIDCategoria.Text & " / " & txtCategoria.Text & " del sistema?", "Anular Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 53
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                sqlQ = "UPDATE Categoria SET IDDepartamento='" + txtIDDepartamento.Text + "',Categoria='" + txtCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDCategoria= (" + txtIDCategoria.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnCargarFoto_Click(sender As Object, e As EventArgs) Handles btnCargarFoto.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaFoto As New OpenFileDialog

                OfdRutaFoto.RestoreDirectory = True
                OfdRutaFoto.Title = ("Selección de foto para categoría")
                OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaFoto.FileName = ""

                If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lblRutaFoto.Text = OfdRutaFoto.FileName
                    wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
                    PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                    lblRutaFoto.Text = OfdRutaFoto.FileName
                    wFile.Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub btnAbrirFoto_Click(sender As Object, e As EventArgs) Handles btnAbrirFoto.Click
        If TypeConnection.Text = 1 Then
            If lblRutaFoto.Text = "" Then
                MessageBox.Show("No se ha encontrado la foto anexa para poder abrirla.", "Falta Anexar Foto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(lblRutaFoto.Text)
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminarFoto_Click(sender As Object, e As EventArgs) Handles btnEliminarFoto.Click
        If TypeConnection.Text = 1 Then
            If lblRutaFoto.Text = "" Then
                MessageBox.Show("No existe foto anexa al registro.", "No existe foto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la foto anexa al registro?", "Eliminar foto de categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblRutaFoto.Text = ""
                    PicImagen.Image = My.Resources.no_photo
                End If
            End If
        End If
    End Sub

    Public Function SetCategoryImage(ByVal IDDepartment As String)
        Try
            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Categorías")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Categorías")
            End If

            If lblRutaFoto.Text <> "" Then
                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\Categorías\" & txtIDCategoria.Text & ".png"

                If lblRutaFoto.Text <> RutaDestino Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(lblRutaFoto.Text)
                    If ExistFile = True Then
                        My.Computer.FileSystem.MoveFile(lblRutaFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE Libregco.Categoria SET CategoriaFilePath='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDCategoria= (" + txtIDCategoria.Text + ")"
                        GuardarDatos()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Function

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        If lblRutaFoto.Text = "" Then
            btnCargarFoto.PerformClick()
        End If
    End Sub
End Class