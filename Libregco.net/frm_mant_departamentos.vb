Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes

Public Class frm_mant_departamentos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkDesactivar As New Label
    Dim Permisos As New ArrayList
    Friend lblRutaFoto As New Label

    Private Sub frm_mant_departamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        LimpiarDatosDepartamento()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub FillTreeView()
        Dim DsDepartamentos, DsCategorias, DsSubCategorias As New DataSet
        Dim MyNode() As TreeNode

        TreeView1.Nodes.Clear()
        ConLibregco.Open()

        cmd = New MySqlCommand("SELECT IDDepartamento,Departamento FROM libregco.departamentos where Desactivar=0 order by Departamento ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsDepartamentos, "Departamentos")

        Dim TablaDepartamentos As DataTable = DsDepartamentos.Tables("Departamentos")

        For Each DtDepartamentos As DataRow In TablaDepartamentos.Rows
            TreeView1.Nodes.Add("D" & DtDepartamentos.Item("IDDepartamento"), DtDepartamentos.Item("Departamento"))

            MyNode = TreeView1.Nodes.Find("D" & DtDepartamentos.Item("IDDepartamento"), True)

            'Buscando las categorias
            DsCategorias.Clear()
            cmd = New MySqlCommand("SELECT IDCategoria,Categoria FROM libregco.categoria where IDDepartamento='" + DtDepartamentos.Item("IDDepartamento").ToString + "' order by Categoria ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsCategorias, "Categoria")

            Dim TablaCategoria As DataTable = DsCategorias.Tables("Categoria")

            For Each DtCategoria As DataRow In TablaCategoria.Rows
                MyNode = TreeView1.Nodes.Find("D" & DtDepartamentos.Item("IDDepartamento"), True)
                MyNode(0).Nodes.Add("C" & DtCategoria.Item("IDCategoria"), DtCategoria.Item("Categoria"))

                MyNode = TreeView1.Nodes.Find("C" & DtCategoria.Item("IDCategoria"), True)


                'Buscando las SUBcategorias
                DsSubCategorias.Clear()
                cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria FROM libregco.subcategoria where IDCategoria='" + DtCategoria.Item("IDCategoria").ToString + "' order by SubCategoria ASC", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsSubCategorias, "SubCategoria")

                Dim TablaSubCategoria As DataTable = DsSubCategorias.Tables("SubCategoria")

                For Each DtSubCategoria As DataRow In TablaSubCategoria.Rows
                    MyNode(0).Nodes.Add("S" & DtSubCategoria.Item("IDSubCategoria"), DtSubCategoria.Item("SubCategoria"))
                Next


            Next
        Next



        ConLibregco.Close()

        TreeView1.ExpandAll()
    End Sub

    Private Sub LimpiarDatosDepartamento()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        lblchkDesactivar.Text = 0
        chkDesactivar.Checked = False
        lblRutaFoto.Text = ""
        PicImagen.Image = My.Resources.No_Image
        FillTreeView()
        HabilitarDepartamento()
        txtDepartamento.Focus()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
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

    Private Sub UltDepartamento()
        If txtIDDepartamento.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDDepartamento from Departamentos where IDDepartamento= (Select Max(IDDepartamento) from Departamentos)", ConLibregco)
            txtIDDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblchkDesactivar.Text = 1
            DeshabilitarDepartamento()
        Else
            lblchkDesactivar.Text = 0
            HabilitarDepartamento()

        End If
    End Sub

    Private Sub HabilitarDepartamento()
        txtDepartamento.Enabled = True
    End Sub

    Private Sub DeshabilitarDepartamento()
        txtDepartamento.Enabled = False
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
        LimpiarDatosDepartamento()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDDepartamento.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el departamento de " & txtDepartamento.Text & " en la base de datos?", "Guardar Nuevo Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                'Agrego un nuevo registro
                sqlQ = "INSERT INTO Departamentos (Departamento,DepartamentoFilePath,Desactivar) VALUES ('" + txtDepartamento.Text + "','','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltDepartamento()
                SetDepartmentImage(txtIDDepartamento.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Departamentos SET Departamento='" + txtDepartamento.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDDepartamento= (" + txtIDDepartamento.Text + ")"
                GuardarDatos()
                SetDepartmentImage(txtIDDepartamento.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub
    Public Function SetDepartmentImage(ByVal IDDepartment As String)
        Try
            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Departamentos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Departamentos")
            End If

            If lblRutaFoto.Text <> "" Then
                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\Departamentos\" & txtIDDepartamento.Text & ".png"

                If lblRutaFoto.Text <> RutaDestino Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(lblRutaFoto.Text)
                    If ExistFile = True Then
                        My.Computer.FileSystem.MoveFile(lblRutaFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        sqlQ = "UPDATE Libregco.Departamentos SET DepartamentoFilePath='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDDepartamento= (" + txtIDDepartamento.Text + ")"
                        GuardarDatos()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Function

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDDepartamento.Text = "" Then 'Si no hay un referente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el departamento de " & txtDepartamento.Text & " en la base de datos?", "Guardar Nuevo Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                'Agrego un nuevo registro
                sqlQ = "INSERT INTO Departamentos (Departamento,Desactivar) VALUES ('" + txtDepartamento.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltDepartamento()
                SetDepartmentImage(txtIDDepartamento.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosDepartamento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Departamentos SET IDDepartamento='" + txtIDDepartamento.Text + "',Departamento='" + txtDepartamento.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDDepartamento= (" + txtIDDepartamento.Text + ")"
                GuardarDatos()
                SetDepartmentImage(txtIDDepartamento.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatosDepartamento()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El departamento " & txtDepartamento.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                chkDesactivar.Checked = False
                sqlQ = "UPDATE Departamentos SET IDDepartamento='" + txtIDDepartamento.Text + "',Departamento='" + txtDepartamento.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDDepartamento= (" + txtIDDepartamento.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDDepartamento.Text = "" Then
            MessageBox.Show("No hay un registro de departamento abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_departamentos.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro del departamento " & txtDepartamento.Text & " del sistema?", "Desactivar departamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE Departamentos SET IDDepartamento='" + txtIDDepartamento.Text + "',Departamento='" + txtDepartamento.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDDepartamento= (" + txtIDDepartamento.Text + ")"
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
                OfdRutaFoto.Multiselect = False

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
                    PicImagen.Image = My.Resources.No_Image
                End If
            End If
        End If
    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        If lblRutaFoto.Text = "" Then
            btnCargarFoto.PerformClick()
        End If
    End Sub


End Class