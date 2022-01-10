Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_marcas
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtIDMarca.Clear()
        txtMarca.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        lblNulo.Text = 0
        PicImagen.Image = My.Resources.No_Image
        PicImagen.Tag = ""
        txtMarca.Focus()
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
            ConLibregco.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub


    Private Sub btnCargarFoto_Click(sender As Object, e As EventArgs) Handles btnCargarFoto.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaFoto As New OpenFileDialog

                OfdRutaFoto.RestoreDirectory = True
                OfdRutaFoto.Title = ("Selección de foto para marcas")
                OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaFoto.FileName = ""
                OfdRutaFoto.Multiselect = False

                If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
                    PicImagen.Tag = OfdRutaFoto.FileName
                    wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
                    PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Public Function SetMarcaImage(ByVal IDMarca As String)
        Try
            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Marcas")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Marcas")
            End If

            If PicImagen.Tag <> "" Then
                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\Marcas\" & txtIDMarca.Text & ".png"

                If PicImagen.Tag.ToString <> RutaDestino Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(PicImagen.Tag.ToString)
                    If ExistFile = True Then
                        My.Computer.FileSystem.MoveFile(PicImagen.Tag.ToString, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE Libregco.Marca SET MarcaFilePath='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDMarca= (" + txtIDMarca.Text + ")"
                        GuardarDatos()
                    End If

                End If
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Function

    Private Sub btnAbrirFoto_Click(sender As Object, e As EventArgs) Handles btnAbrirFoto.Click
        If TypeConnection.Text = 1 Then
            If PicImagen.Tag = "" Then
                MessageBox.Show("No se ha encontrado la foto anexa para poder abrirla.", "Falta Anexar Foto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir logo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(PicImagen.Tag.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminarFoto_Click(sender As Object, e As EventArgs) Handles btnEliminarFoto.Click
        If TypeConnection.Text = 1 Then
            If PicImagen.Tag = "" Then
                MessageBox.Show("No existe foto anexa al registro.", "No existe foto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la foto anexa al registro?", "Eliminar logo de marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    PicImagen.Tag = ""
                    PicImagen.Image = My.Resources.No_Image
                End If
            End If
        End If
    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        If PicImagen.Tag = "" Then
            btnCargarFoto.PerformClick()
        End If
    End Sub

    Private Sub UltMarca()
        Try
            If txtIDMarca.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDMarca from Marca where IDMarca= (Select Max(IDMarca) from Marca)", ConLibregco)
                txtIDMarca.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Marca()")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtMarca.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtMarca.Enabled = True
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
        ActualizarTodo()
    End Sub




    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Marca Código. " & txtIDMarca.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE Marca SET Marca='" + txtMarca.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDMarca= (" + txtIDMarca.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDMarca.Text = "" Then
            MessageBox.Show("No hay un registro de marca abierta para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la marca Código. " & txtIDMarca.Text & " / " & txtMarca.Text & " del sistema?", "Anular Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE Marca SET Marca='" + txtMarca.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDMarca= (" + txtIDMarca.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtMarca.Text = "" Then
            MessageBox.Show("Escriba o defina la nueva marca a guadar en la base de datos.", "Definir marca", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMarca.Focus()
            Exit Sub

        End If
        If txtIDMarca.Text = "" Then 'Si no hay marca
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la marca " & txtMarca.Text & " en la base de datos?", "Guardar Nueva Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Marca (Marca,Nulo) VALUES ('" + txtMarca.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltMarca()
                SetMarcaImage(txtIDMarca.Text)
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la marca?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Marca SET Marca='" + txtMarca.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDMarca= (" + txtIDMarca.Text + ")"
                GuardarDatos()
                SetMarcaImage(txtIDMarca.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class