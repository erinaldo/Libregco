Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_subcategorias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList
    Friend lblRutaFoto As New Label

    Private Sub frm_mant_subcategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtIDSubCategoria.Clear()
        txtSubCategoria.Clear()
        DgvSubCategoria.Rows.Clear()
        lblRutaFoto.Text = ""
        PicImagen.Image = My.Resources.No_Image
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        PanelHibrido.Size = New Size(453, 31)
        PanelHibrido.Location = New Point(0, 440)
        btnMultipleRegistro.Text = "Modo de múltiples registros"
        btnMultipleRegistro.Visible = True
        btnGuardarMultiple.Visible = False
        Me.Size = New Size(469, 535)
        txtCategoria.Focus()
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

    Private Sub btn_BuscarCategoria_Click(sender As Object, e As EventArgs) Handles btn_BuscarCategoria.Click
        frm_buscar_categorias.ShowDialog(Me)
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            ConLibregco.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltSubCategoria()
        Try

            If txtIDSubCategoria.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDSubCategoria from SubCategoria where IDSubCategoria= (Select Max(IDSubCategoria) from SubCategoria)", ConLibregco)
                txtIDSubCategoria.Text = Convert.ToDouble(cmd.ExecuteScalar)
                ConLibregco.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " SubCategoria()")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtSubCategoria.Enabled = False
        btnMultipleRegistro.Visible = False
    End Sub

    Private Sub HabilitarControles()
        txtSubCategoria.Enabled = True
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btn_BuscarCategoria.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub


    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría de la sub categoría que desea guardar.", "Seleccionar la categoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_BuscarCategoria.PerformClick()
            Exit Sub
        ElseIf txtSubCategoria.Text = "" Then
            MessageBox.Show("Escriba o defina la nueva sub categoría a procesar.", "Definir sub categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSubCategoria.Focus()
            Exit Sub
        End If

        If txtIDSubCategoria.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la Sub-Categoría " & txtSubCategoria.Text & " en la base de datos?", "Guardar Nueva Sub-Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO SubCategoria (IDCategoria,SubCategoria,SubCategoriaFilePath,Nulo) VALUES ('" + txtIDCategoria.Text + "','" + txtSubCategoria.Text + "','','" + lblNulo.Text + "')"
                GuardarDatos()
                UltSubCategoria()
                SetSubCategoryImage(txtIDSubCategoria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la categoría?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "UPDATE SubCategoria SET IDCategoria='" + txtIDCategoria.Text + "',SubCategoria='" + txtSubCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDSubCategoria= (" + txtIDSubCategoria.Text + ")"
                GuardarDatos()
                SetSubCategoryImage(txtIDSubCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría de la sub categoría que desea guardar.", "Seleccionar la categoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_BuscarCategoria.PerformClick()
            Exit Sub
        ElseIf txtSubCategoria.Text = "" Then
            MessageBox.Show("Escriba o defina la nueva sub categoría a procesar.", "Definir sub categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSubCategoria.Focus()
            Exit Sub
        End If
        If txtIDSubCategoria.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la Sub-Categoría " & txtSubCategoria.Text & " en la base de datos?", "Guardar Nueva Sub-Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "INSERT INTO SubCategoria (IDCategoria,SubCategoria,SubCategoriaFilePath,Nulo) VALUES ('" + txtIDCategoria.Text + "','" + txtSubCategoria.Text + "','','" + lblNulo.Text + "')"
                GuardarDatos()
                UltSubCategoria()
                SetSubCategoryImage(txtIDSubCategoria.Text)
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la categoría?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "UPDATE SubCategoria SET IDCategoria='" + txtIDCategoria.Text + "',SubCategoria='" + txtSubCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDSubCategoria= (" + txtIDSubCategoria.Text + ")"
                GuardarDatos()
                SetSubCategoryImage(txtIDSubCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_subcategorias.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Sub-Categoría Código. " & txtIDSubCategoria.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Sub-Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 67
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                sqlQ = "UPDATE SubCategoria SET IDCategoria='" + txtIDCategoria.Text + "',SubCategoria='" + txtSubCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDSubCategoria= '" + txtIDSubCategoria.Text + "'"
                GuardarDatos()
                SetSubCategoryImage(txtIDSubCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCategoria.Text = "" Then
            MessageBox.Show("No hay un registro de Sub-Categoría abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la Sub-Categoría Código. " & txtIDSubCategoria.Text & " / " & txtSubCategoria.Text & " del sistema?", "Anular Sub-Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 68
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                sqlQ = "UPDATE SubCategoria SET IDCategoria='" + txtIDCategoria.Text + "',SubCategoria='" + txtSubCategoria.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDSubCategoria= '" + txtIDSubCategoria.Text + "'"
                GuardarDatos()
                SetSubCategoryImage(txtIDSubCategoria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnMultipleRegistro_Click(sender As Object, e As EventArgs) Handles btnMultipleRegistro.Click
        If PanelHibrido.Height = 31 Then
            PanelHibrido.Size = New Size(453, 193)
            PanelHibrido.Location = New Point(0, 437)
            btnMultipleRegistro.Text = "Agregar subcategoría"
            Me.Size = New Size(469, 694)
            btnGuardarMultiple.Location = New Point(280, 167)
            btnGuardarMultiple.Visible = True
            Me.CenterToParent()
            txtSubCategoria.Focus()
        Else

            If txtIDCategoria.Text = "" Then
                MessageBox.Show("Seleccione la categoría de la sub categoría que desea guardar.", "Seleccionar la categoría", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btn_BuscarCategoria.PerformClick()
                Exit Sub
            ElseIf txtSubCategoria.Text = "" Then
                MessageBox.Show("Escriba o defina la nueva sub categoría a procesar.", "Definir sub categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtSubCategoria.Focus()
                Exit Sub
            End If

            DgvSubCategoria.Rows.Add(txtIDCategoria.Text, txtCategoria.Text, txtIDSubCategoria.Text, txtSubCategoria.Text)

            txtIDSubCategoria.Clear()
            txtSubCategoria.Clear()
            txtSubCategoria.Focus()
        End If
    End Sub

    Private Sub btnGuardarMultiple_Click(sender As Object, e As EventArgs) Handles btnGuardarMultiple.Click
        If DgvSubCategoria.Rows.Count > 0 Then
            btnGuardar.Enabled = False

            ConLibregco.Open()

            For Each Row As DataGridViewRow In DgvSubCategoria.Rows
                If Convert.ToString(CStr(Row.Cells(2).Value)) = "" Then
                    sqlQ = "INSERT INTO SubCategoria (IDCategoria,SubCategoria,SubCategoriaFilePath,Nulo) VALUES ('" + Row.Cells(0).Value.ToString + "','" + Row.Cells(3).Value.ToString + "','',0)"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDSubCategoria from SubCategoria where IDSubCategoria= (Select Max(IDSubCategoria) from SubCategoria)", ConLibregco)
                    Row.Cells(2).Value = Convert.ToDouble(cmd.ExecuteScalar)
                End If
            Next

            ConLibregco.Close()

            btnGuardar.Enabled = True

            MessageBox.Show("Se han guardado satisfactoriamente los registros.")
        End If

    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        If lblRutaFoto.Text = "" Then
            btnCargarFoto.PerformClick()
        End If
    End Sub


    Private Sub btnCargarFoto_Click(sender As Object, e As EventArgs) Handles btnCargarFoto.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaFoto As New OpenFileDialog

                OfdRutaFoto.RestoreDirectory = True
                OfdRutaFoto.Title = ("Selección de foto para subcategoría")
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
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la foto anexa al registro?", "Eliminar foto de subcategoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblRutaFoto.Text = ""
                    PicImagen.Image = My.Resources.no_photo
                End If
            End If
        End If
    End Sub

    Public Function SetSubCategoryImage(ByVal IDSubCategoria As String)
        Try
            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\SubCategorías")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\SubCategorías")
            End If

            If lblRutaFoto.Text <> "" Then
                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\SubCategorías\" & txtIDSubCategoria.Text & ".png"

                If lblRutaFoto.Text <> RutaDestino Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(lblRutaFoto.Text)
                    If ExistFile = True Then
                        My.Computer.FileSystem.MoveFile(lblRutaFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE Libregco.SubCategoria SET SubcategoriaFilePath='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDSubCategoria= (" + txtIDSubCategoria.Text + ")"
                        GuardarDatos()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Function
End Class