Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_vehiculos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblchkDesactivar, lblIDTipoVehiculo, lblIDColor As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_vehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        FillTipoVehiculo()
        FillColor()
        ResetPicMatricula()
        NupAño.Text = ""
        lblchkDesactivar.Text = 0
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

        Catch ex As Exception
            ConLibregco.Close()

        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDVehiculo.Clear()
        txtMarca.Clear()
        cbxTipoVehiculo.Items.Clear()
        cbxColor.Items.Clear()
        txtPlaca.Clear()
        txtMatricula.Clear()
        txtRuta.Clear()
        txtModelo.Clear()
        lblDatoVehiculo.Text = ""
        lblchkDesactivar.Text = 0
        chkDesactivar.Checked = False
        ResetPicMatricula()
        ActualizarTodo()
        txtMarca.Focus()
    End Sub

    Private Sub ResetPicMatricula()
        PicMatricula.Width = 543
        PicMatricula.Height = 191
        PicMatricula.Image = Nothing
    End Sub

    Private Sub FillColor()
        Ds.clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Color FROM Color ORDER BY Color", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Color")
        cbxColor.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Color")

        For Each Fila As DataRow In Tabla.Rows
            cbxColor.Items.Add(Fila.Item("Color"))
        Next
    End Sub

    Private Sub FillTipoVehiculo()
        Ds.clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TipoVehiculo FROM TipoVehiculo ORDER BY TipoVehiculo", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoVehiculo")
        cbxTipoVehiculo.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoVehiculo")

        For Each Fila As DataRow In Tabla.Rows
            cbxTipoVehiculo.Items.Add(Fila.Item("TipoVehiculo"))
        Next
    End Sub

    Private Sub SetIDColor()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDColor FROM Color WHERE Color= '" + cbxColor.SelectedItem + "' Order By Color ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Color")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Color")
        lblIDColor.Text = (Tabla.Rows(0).Item("IDColor"))
    End Sub

    Private Sub SetIDTipoVehiculo()

        Ds.clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoVehiculo FROM TipoVehiculo WHERE TipoVehiculo= '" + cbxTipoVehiculo.SelectedItem + "' Order By TipoVehiculo ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoVehiculo")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoVehiculo")
        lblIDTipoVehiculo.Text = (Tabla.Rows(0).Item("IDTipoVehiculo"))

    End Sub

    Private Sub cbxColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxColor.SelectedIndexChanged
        SetIDColor()
        ActualizarDatoVehiculo()
    End Sub

    Private Sub cbxTipoVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoVehiculo.SelectedIndexChanged
        SetIDTipoVehiculo()
        ActualizarDatoVehiculo()
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblchkDesactivar.Text = 1
            InhabilitarVehiculo()
        Else
            lblchkDesactivar.Text = 0
            HabilitarVehiculo()
        End If
    End Sub

    Private Sub InhabilitarVehiculo()
        txtIDVehiculo.Enabled = False
        txtMarca.Enabled = False
        cbxTipoVehiculo.Enabled = False
        cbxColor.Enabled = False
        txtPlaca.Enabled = False
        txtRuta.Enabled = False
        txtMatricula.Enabled = False
    End Sub

    Private Sub HabilitarVehiculo()
        txtIDVehiculo.Enabled = True
        txtMarca.Enabled = True
        cbxTipoVehiculo.Enabled = True
        cbxColor.Enabled = True
        txtPlaca.Enabled = True
        txtRuta.Enabled = True
        txtMatricula.Enabled = True
    End Sub

    Private Sub UltVehiculo()
        If txtIDVehiculo.Text = "" Then
            Ds.clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDVehiculo from Vehiculo where IDVehiculo= (Select Max(IDVehiculo) from Vehiculo)", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Vehiculo")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Vehiculo")
            txtIDVehiculo.Text = (Tabla.Rows(0).Item("IDVehiculo"))
        End If
    End Sub

    Private Sub txtPlaca_TextChanged(sender As Object, e As EventArgs) Handles txtPlaca.TextChanged
        ActualizarDatoVehiculo()
    End Sub

    Private Sub txtMarca_TextChanged(sender As Object, e As EventArgs) Handles txtMarca.TextChanged
        ActualizarDatoVehiculo()
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

    Private Sub ActualizarDatoVehiculo()
        lblDatoVehiculo.Text = UCase(cbxTipoVehiculo.Text & " " & txtMarca.Text & " " & txtModelo.Text & " " & "C/" & cbxColor.Text & " Año " & NupAño.Text)
    End Sub

    Private Sub CreateFolder()
        Try
            Dim Exists As Boolean
            Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Activos\Vehiculos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Activos\Vehiculos")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MoverFichero()
        Try

            CreateFolder()   'Verificamos si existe el folder del suplidor

            If txtRuta.Text = "" Then
            Else

                Dim Exists As Boolean = System.IO.File.Exists(txtRuta.Text)
                If Exists = True Then

                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Activos\Vehiculos\" & "VEH-ID" & txtIDVehiculo.Text & ".png"

                    If RutaDestino <> txtRuta.Text Then

                        'Liberar uso del recurso
                        PicMatricula.Image.Dispose()
                        PicMatricula.Image = Nothing

                        My.Computer.FileSystem.MoveFile(txtRuta.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)


                        sqlQ = "UPDATE Vehiculo SET RutaMatricula='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDVehiculo= (" + txtIDVehiculo.Text + ")"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        PicMatricula.Image = System.Drawing.Image.FromStream(wFile)
                        txtRuta.Text = RutaDestino
                        wFile.Close()
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarDoc_Click(sender As Object, e As EventArgs) Handles btnBuscarDoc.Click
        Try
            Dim OfdRutaDocumento As New OpenFileDialog
            Dim wFile As System.IO.FileStream

            OfdRutaDocumento.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            OfdRutaDocumento.Title = ("Seleccionar Matrícula")
            OfdRutaDocumento.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
            OfdRutaDocumento.FileName = ""

            If OfdRutaDocumento.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtRuta.Text = OfdRutaDocumento.FileName
                wFile = New FileStream(OfdRutaDocumento.FileName, FileMode.Open, FileAccess.Read)
                PicMatricula.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
                lblStatusBar.Text = "Imagen Cargada"
            Else
                lblStatusBar.Text = "Listo"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " btnCargarMatricula_Click")
        End Try
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If txtRuta.Text = "" Then
            MessageBox.Show("No hay documento anexo para poder abrirla.", "Falta Anexar Cédula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la documentación vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(txtRuta.Text)
            End If
        End If
    End Sub

    Private Sub EscanearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscanearToolStripMenuItem.Click
        btnEscanear.PerformClick()
    End Sub

    Private Sub BuscarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDocumentoToolStripMenuItem.Click
        btnBuscarDoc.PerformClick()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        btnAbrir.PerformClick()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If txtRuta.Text = "" Then
            MessageBox.Show("No existe documentación anexa al registro.", "No existe identificación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la documentación anexa al registro?", "Eliminar Documentación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                txtRuta.Clear()
                PicMatricula.Image = Nothing
                lblStatusBar.Text = "Listo"
            End If
        End If
    End Sub

    Private Sub NupAño_Leave(sender As Object, e As EventArgs) Handles NupAño.Leave
        ActualizarDatoVehiculo()
    End Sub

    Private Sub txtModelo_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged
        ActualizarDatoVehiculo()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtMatricula.Text = "" Then
            MessageBox.Show("Especifique el No. de matrícula del vehículo.", "No. de Matrícula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMatricula.Focus()
            Exit Sub
        ElseIf cbxColor.Text = "" Then
            MessageBox.Show("Seleccione el color del vehículo.", "Seleccionar Color", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxColor.Focus()
            cbxColor.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoVehiculo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de vehículo.", "Seleccionar Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxColor.Focus()
            cbxColor.DroppedDown = True
            Exit Sub
        ElseIf txtMarca.Text = "" Then
            MessageBox.Show("Escriba la marca del vehículo.", "Escriba la marca", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMarca.Focus()
            Exit Sub
        ElseIf NupAño.Value = 0 Then
            MessageBox.Show("Escriba el año del vehículo.", "Escriba el año vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            NupAño.Focus()
            Exit Sub
        End If

        If txtIDVehiculo.Text = "" Then 'Si no hay un cliente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Vehiculo (IDColor,Marca,IDTipoVehiculo,Modelo,Placa,Matricula,RutaMatricula,DatoVehiculo,Desactivar) VALUES ('" + lblIDColor.Text + "','" + txtMarca.Text + "','" + lblIDTipoVehiculo.Text + "','" + txtModelo.Text + "','" + txtPlaca.Text + "','" + txtMatricula.Text + "','" + (Replace(txtRuta.Text, "\", "\\")) + "','" + lblDatoVehiculo.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltVehiculo()
                MoverFichero()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Vehiculo SET IDColor='" + lblIDColor.Text + "',Marca='" + txtMarca.Text + "',IDTipoVehiculo='" + lblIDTipoVehiculo.Text + "',Modelo='" + txtModelo.Text + "',Placa='" + txtPlaca.Text + "',Matricula='" + txtMatricula.Text + "',RutaMatricula='" + (Replace(txtRuta.Text, "\", "\\")) + "',DatoVehiculo='" + lblDatoVehiculo.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDVehiculo= (" + txtIDVehiculo.Text + ")"
                GuardarDatos()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtMatricula.Text = "" Then
            MessageBox.Show("Especifique el No. de matrícula del vehículo.", "No. de Matrícula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMatricula.Focus()
            Exit Sub
        ElseIf cbxColor.Text = "" Then
            MessageBox.Show("Seleccione el color del vehículo.", "Seleccionar Color", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxColor.Focus()
            cbxColor.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoVehiculo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de vehículo.", "Seleccionar Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxColor.Focus()
            cbxColor.DroppedDown = True
            Exit Sub
        ElseIf txtMarca.Text = "" Then
            MessageBox.Show("Escriba la marca del vehículo.", "Escriba la marca", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMarca.Focus()
            Exit Sub
        ElseIf NupAño.Value = 0 Then
            MessageBox.Show("Escriba el año del vehículo.", "Escriba el año vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            NupAño.Focus()
            Exit Sub
        End If

        If txtIDVehiculo.Text = "" Then 'Si no hay un cliente seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Vehiculo (IDColor,Marca,IDTipoVehiculo,Modelo,Placa,Matricula,RutaMatricula,DatoVehiculo,Desactivar) VALUES ('" + lblIDColor.Text + "','" + txtMarca.Text + "','" + lblIDTipoVehiculo.Text + "','" + txtModelo.Text + "','" + txtPlaca.Text + "','" + txtMatricula.Text + "','" + (Replace(txtRuta.Text, "\", "\\")) + "','" + lblDatoVehiculo.Text + "','" + lblchkDesactivar.Text + "')"
                GuardarDatos()
                UltVehiculo()
                MoverFichero()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Vehiculo SET IDColor='" + lblIDColor.Text + "',Marca='" + txtMarca.Text + "',IDTipoVehiculo='" + lblIDTipoVehiculo.Text + "',Modelo='" + txtModelo.Text + "',Placa='" + txtPlaca.Text + "',Matricula='" + txtMatricula.Text + "',RutaMatricula='" + (Replace(txtRuta.Text, "\", "\\")) + "',DatoVehiculo='" + lblDatoVehiculo.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDVehiculo= (" + txtIDVehiculo.Text + ")"
                GuardarDatos()
                MoverFichero()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        frm_buscar_vehiculo.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkDesactivar.Checked = True Then
            Dim Result As MsgBoxResult = MessageBox.Show("El vehículo " & cbxTipoVehiculo.Text & " " & txtMarca.Text & " " & cbxColor.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                chkDesactivar.Checked = False
                sqlQ = "UPDATE Vehiculo SET IDColor='" + lblIDColor.Text + "',Marca='" + txtMarca.Text + "',IDTipoVehiculo='" + lblIDTipoVehiculo.Text + "',Modelo='" + txtModelo.Text + "',Placa='" + txtPlaca.Text + "',Matricula='" + txtMatricula.Text + "',RutaMatricula='" + (Replace(txtRuta.Text, "\", "\\")) + "',DatoVehiculo='" + lblDatoVehiculo.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDVehiculo= (" + txtIDVehiculo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDVehiculo.Text = "" Then
            MessageBox.Show("No hay un registro de vehículo abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del vehículo " & cbxTipoVehiculo.Text & " " & txtMarca.Text & " " & cbxColor.Text & " del sistema?", "Desactivar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                chkDesactivar.Checked = True
                sqlQ = "UPDATE Vehiculo SET IDColor='" + lblIDColor.Text + "',Marca='" + txtMarca.Text + "',IDTipoVehiculo='" + lblIDTipoVehiculo.Text + "',Modelo='" + txtModelo.Text + "',Placa='" + txtPlaca.Text + "',Matricula='" + txtMatricula.Text + "',RutaMatricula='" + (Replace(txtRuta.Text, "\", "\\")) + "',DatoVehiculo='" + lblDatoVehiculo.Text + "',Desactivar='" + lblchkDesactivar.Text + "' WHERE IDVehiculo= (" + txtIDVehiculo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub
End Class