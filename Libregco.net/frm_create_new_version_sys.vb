Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.CodeDom.Compiler

Public Class frm_create_new_version_sys

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Server As New Label

    Private Sub frm_create_new_version_sys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        GetServer()
        CargarLibregco()
        GetLastBuild()
    End Sub


    Private Sub GetServer()
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=1", ConUtilitarios)
        Server.Text = Convert.ToString(cmd.ExecuteScalar())
        ConUtilitarios.Close()

    End Sub

    Private Sub GetLastBuild()
        Dim wFile As System.IO.FileStream

        Ds.Clear()
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "version_sys")
        ConUtilitarios.Close()

        Dim Tabla As DataTable = Ds.Tables("version_sys")

        If Tabla.Rows.Count > 0 Then
            txtIDBuild.Text = (Tabla.Rows(0).Item("IDBuild"))
            txtMayor.Text = (Tabla.Rows(0).Item("VersionMayor"))
            txtMenor.Text = (Tabla.Rows(0).Item("VersionMenor"))
            txtCompilacion.Text = (Tabla.Rows(0).Item("VersionCompilacion"))
            txtVersion.Text = (Tabla.Rows(0).Item("VersionVersion"))
            dtpLaunched.Value = CDate(Tabla.Rows(0).Item("FechaLanzamiento"))
            txtLocation.Text = "\\" & Server.Text & (Tabla.Rows(0).Item("Locacion"))
            txtSizeExe.Text = (Tabla.Rows(0).Item("Tamano"))
            txtDirectory.Text = "\\" & Server.Text & (Tabla.Rows(0).Item("LocacionDirectorio"))
            txtSizeDirectory.Text = (Tabla.Rows(0).Item("SizeDirectorio"))
            txtRutaLogo.Text = "\\" & Server.Text & (Tabla.Rows(0).Item("LocacionLogo"))

            Dim ExistFile As Boolean = System.IO.File.Exists("\\" & Server.Text & Tabla.Rows(0).Item("LocacionLogo"))

            If ExistFile = True Then
                wFile = New FileStream("\\" & Server.Text & (Tabla.Rows(0).Item("LocacionLogo")), FileMode.Open, FileAccess.Read)
                PicImagenLogo.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            Else
                PicImagenLogo.Image = My.Resources.No_Image
            End If

            RefrescarDgvNotificaciones()
        End If

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LastIDBuild()
        If txtIDBuild.Text = "" Then
            ConUtilitarios.Open()
            cmd = New MySqlCommand("Select IDBuild from Libregco_Utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
            txtIDBuild.Text = Convert.ToString(cmd.ExecuteScalar())
            ConUtilitarios.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ''Try
        If txtMayor.Text = "" Then
                MessageBox.Show("Escriba el número mayor de la versión.", "Numeración mayor de versión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtMayor.Focus()
                Exit Sub
            ElseIf txtMenor.Text = "" Then
                MessageBox.Show("Escriba el número menor de la versión.", "Numeración menor de versión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtMenor.Focus()
                Exit Sub
            ElseIf txtCompilacion.Text = "" Then
                MessageBox.Show("Escriba el número de la compilación de la versión.", "Numeración de la compilación de la versión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtCompilacion.Focus()
                Exit Sub
            ElseIf txtVersion.Text = "" Then
                MessageBox.Show("Escriba el número de la sub-versión.", "Numeración de la sub-versión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtCompilacion.Focus()
                Exit Sub
            ElseIf txtLocation.Text = "" Then
                MessageBox.Show("Seleccione la ubicación de la actualización del sistema", "Ubicación del release", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnLocation.PerformClick()
                If txtLocation.Text = "" Then
                    Exit Sub
                End If
            ElseIf DgvNotas.Rows.Count = 0 Then
                txtEspecificacion.Focus()
                MessageBox.Show("Escriba al menos una nota de la versión.", "No se encuentran notas de la versión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDBuild.Text = "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                'MessageBox.Show("INSERT INTO Libregco_Utilitarios.Version_sys (VersionMayor, VersionMenor, VersionCompilacion, VersionVersion, FechaLanzamiento, Tamano, Locacion, LocacionDirectorio, SizeDirectorio, LocacionLogo) VALUES ('" + txtMayor.Text + "','" + txtMenor.Text + "','" + txtCompilacion.Text + "','" + txtVersion.Text + "','" + dtpLaunched.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtSizeExe.Text + "','" + Replace(txtLocation.Text, "\\" & Server.Text, "").Replace("\", "\\") + "'")
                'Exit Sub
                MoveLogo()
                sqlQ = "INSERT INTO Libregco_Utilitarios.Version_sys (VersionMayor,VersionMenor,VersionCompilacion,VersionVersion,FechaLanzamiento,Tamano,Locacion,LocacionDirectorio,SizeDirectorio,LocacionLogo) VALUES ('" + txtMayor.Text + "','" + txtMenor.Text + "','" + txtCompilacion.Text + "','" + txtVersion.Text + "','" + dtpLaunched.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtSizeExe.Text + "','" + Replace(txtLocation.Text, "\\" & Server.Text, "").Replace("\", "\\") + "','" + Replace(txtDirectory.Text, "\\" & Server.Text, "").Replace("\", "\\") + "','" + txtSizeDirectory.Text + "','" + Replace(txtRutaLogo.Text, "\\" & Server.Text, "").Replace("\", "\\") + "')"
                GuardarDatos()
                LastIDBuild()
                Notificaciones()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    MoveLogo()
                    sqlQ = "UPDATE Libregco_Utilitarios.Version_sys SET VersionMayor='" + txtMayor.Text + "',VersionMenor='" + txtMenor.Text + "',VersionCompilacion='" + txtCompilacion.Text + "',VersionVersion='" + txtVersion.Text + "',FechaLanzamiento='" + dtpLaunched.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',Tamano='" + txtSizeExe.Text + "',Locacion='" + Replace(txtLocation.Text, "\\" & Server.Text, "").Replace("\", "\\") + "',LocacionDirectorio='" + Replace(txtDirectory.Text, "\\" & Server.Text, "").Replace("\", "\\") + "',SizeDirectorio='" + txtSizeDirectory.Text + "',LocacionLogo='" + Replace(txtRutaLogo.Text, "\\" & Server.Text, "").Replace("\", "\\") + "' WHERE IDBuild= (" + txtIDBuild.Text + ")"
                    GuardarDatos()

                    Notificaciones()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

            SetLastUpdate()
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        ''End Try
    End Sub

    Private Sub MoveLogo()
        Try

            Dim Exists As Boolean
            Dim RutaDestino As String

            If txtRutaLogo.Text = "" Then
            Else

                Exists = System.IO.File.Exists(txtRutaLogo.Text)

                If Exists = True Then

                    RutaDestino = txtDirectory.Text & "\" & Path.GetFileName(txtRutaLogo.Text)

                    If RutaDestino <> txtRutaLogo.Text Then
                        My.Computer.FileSystem.CopyFile(txtRutaLogo.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        txtRutaLogo.Text = RutaDestino

                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetLastUpdate()
        Try
            Ds.Clear()

            ConUtilitarios.Open()
            ConLibregco.Open()
            ConLibregcoMain.Open()

            cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "version_sys")

            Dim Tabla As DataTable = Ds.Tables("version_sys")


            'Version del Sistema
            sqlQ = "UPDATE Configuracion SET Value1Var='" + CStr(Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion")).ToString + "' WHERE IDConfiguracion=19"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()

            'Año del Sistema
            sqlQ = "UPDATE Configuracion SET Value1Var='" + CDate(Tabla.Rows(0).Item("FechaLanzamiento")).Year.ToString + "' WHERE IDConfiguracion=20"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()

            ConUtilitarios.Close()
            ConLibregco.Close()
            ConLibregcoMain.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            ConUtilitarios.Open()
            cmd = New MySqlCommand(sqlQ, ConUtilitarios)
            cmd.ExecuteNonQuery()
            ConUtilitarios.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Notificaciones()
        Dim IDNotificacion, FilePath As New Label

        ConUtilitarios.Open()

        For Each row As DataGridViewRow In DgvNotas.Rows
            IDNotificacion.Text = CStr(row.Cells(0).Value)
            FilePath.Text = CStr(row.Cells(4).Value)

            If IDNotificacion.Text = "" Then
                cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco_Utilitarios' AND table_name='Update_Sys'", ConUtilitarios)
                IDNotificacion.Text = Convert.ToDouble(cmd.ExecuteScalar())
            End If

            'Create Folder
            If TypeConnection.Text = 1 Then
                If System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Improvements") = False Then
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Improvements")
                End If

                If FilePath.Text <> "" Then
                    'Verifico si existe el archivo de por anexar
                    If System.IO.File.Exists(FilePath.Text) = True Then
                        Dim RutaDestino As String = "\Libregco\Files\Improvements\" & IDNotificacion.Text & ".png"

                        If RutaDestino <> row.Cells(4).Value Then
                            My.Computer.FileSystem.MoveFile(FilePath.Text, "\\" & PathServidor.Text & RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            FilePath.Text = Replace(RutaDestino, "\", "\\")
                            row.Cells(4).Value = FilePath.Text
                        End If
                    End If
                Else
                    FilePath.Text = ""
                End If
            End If


            If CStr(row.Cells(0).Value) = "" Then
                sqlQ = "INSERT INTO Libregco_Utilitarios.Update_Sys (IDBuild,Rate,Notes,Picture) VALUES ('" + txtIDBuild.Text + "','" + row.Cells(3).Value.ToString + "','" + row.Cells(2).Value.ToString + "','" + FilePath.Text + "')"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()

            Else
                sqlQ = "UPDATE Libregco_Utilitarios.Update_Sys SET IDBuild='" + txtIDBuild.Text + "',Rate='" + row.Cells(3).Value.ToString + "',Notes='" + row.Cells(2).Value.ToString + "',Picture='" + FilePath.Text + "' WHERE IDUpdate_sys= (" + IDNotificacion.Text + ")"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()
            End If
        Next

        ConUtilitarios.Close()

        RefrescarDgvNotificaciones()

    End Sub

    Private Sub RefrescarDgvNotificaciones()

        DgvNotas.Rows.Clear()
        ConUtilitarios.Open()
        Dim SQLPrecios As New MySqlCommand("SELECT idUpdate_sys,Notes,Rate,Picture FROM libregco_utilitarios.update_sys where IDBuild='" + txtIDBuild.Text + "' ORDER BY Rate ASC", ConUtilitarios)
        Dim LectorNotas As MySqlDataReader = SQLPrecios.ExecuteReader

        While LectorNotas.Read
            If System.IO.File.Exists("\\" & PathServidor.Text & LectorNotas.GetValue(3)) = True Then
                Dim wFile As System.IO.FileStream
                wFile = New FileStream("\\" & PathServidor.Text & LectorNotas.GetValue(3), FileMode.Open, FileAccess.Read)
                DgvNotas.Rows.Add(LectorNotas.GetValue(0), System.Drawing.Image.FromStream(wFile), LectorNotas.GetValue(1), LectorNotas.GetValue(2), LectorNotas.GetValue(3))
                wFile.Close()

            Else
                DgvNotas.Rows.Add(LectorNotas.GetValue(0), My.Resources.No_Image, LectorNotas.GetValue(1), LectorNotas.GetValue(2), "")
            End If
        End While

        LectorNotas.Close()
        ConUtilitarios.Close()

    End Sub

    Private Sub btnLocation_Click(sender As Object, e As EventArgs) Handles btnLocation.Click
        Dim OdfLocation As New OpenFileDialog
        Dim infoReader As System.IO.FileInfo

        OdfLocation.InitialDirectory = "\\" & Server.Text & "\Libregco\Release\Application Files"
        OdfLocation.Title = ("Seleccionar Libregco")
        OdfLocation.Filter = "Ejecutable(*.exe)|*.exe"
        OdfLocation.FileName = "Libregco.exe"

        If OdfLocation.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLocation.Text = OdfLocation.FileName
            txtSizeExe.Text = GetFileSizes(OdfLocation.FileName)
            infoReader = My.Computer.FileSystem.GetFileInfo(OdfLocation.FileName)
            txtSizeExe.Text = (Math.Round((infoReader.Length / (1024 * 1024)), 2))
        End If

        If txtLocation.Text = "" Then
        Else
            txtDirectory.Text = Path.GetDirectoryName(txtLocation.Text)
        End If

        Dim TotalSize As Long = 0
        If txtLocation.Text <> "" Then
            For Each s As String In Directory.GetFiles(txtDirectory.Text, "*.*", SearchOption.AllDirectories)
                TotalSize += New FileInfo(s).Length
            Next
            txtSizeDirectory.Text = Math.Round(TotalSize / (1024 * 1024), 2)
        End If
    End Sub

    Private Sub btnAdjuntarEspecificacion_Click(sender As Object, e As EventArgs) Handles btnAdjuntarEspecificacion.Click
        If txtEspecificacion.Text = "" Then
        Else
            DgvNotas.Rows.Add(lblIDNotificacion.Text, PictureBox1.Image, txtEspecificacion.Text, NUPRatio.Value, PictureBox1.Tag)

            lblIDNotificacion.Text = ""
            NUPRatio.Value = 10
            txtEspecificacion.Clear()
            txtEspecificacion.Focus()
            PictureBox1.Image = My.Resources.No_Image
            PictureBox1.Tag = ""
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        GetLastBuild()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Mensaje, Titulo, DefaultValue As String
        Dim MyValue As Object

        Mensaje = "Escriba el ID de la versión que desea consultar."
        Titulo = "ID Build"
        DefaultValue = txtIDBuild.Text

        MyValue = InputBox(Mensaje, Titulo, DefaultValue)

        If MyValue Is "" Then
            MyValue = DefaultValue
        Else

            Ds.Clear()
            ConUtilitarios.Open()
            cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild='" + MyValue + "'", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "version_sys")
            ConUtilitarios.Close()

            Dim Tabla As DataTable = Ds.Tables("version_sys")

            If Tabla.Rows.Count > 0 Then
                txtIDBuild.Text = (Tabla.Rows(0).Item("IDBuild"))
                txtMayor.Text = (Tabla.Rows(0).Item("VersionMayor"))
                txtMenor.Text = (Tabla.Rows(0).Item("VersionMenor"))
                txtCompilacion.Text = (Tabla.Rows(0).Item("VersionCompilacion"))
                txtVersion.Text = (Tabla.Rows(0).Item("VersionVersion"))
                dtpLaunched.Value = CDate(Tabla.Rows(0).Item("FechaLanzamiento"))
                txtLocation.Text = (Tabla.Rows(0).Item("Locacion"))
                txtSizeExe.Text = (Tabla.Rows(0).Item("Tamano"))
                txtDirectory.Text = (Tabla.Rows(0).Item("LocacionDirectorio"))
                txtSizeDirectory.Text = (Tabla.Rows(0).Item("SizeDirectorio"))

                RefrescarDgvNotificaciones()
            Else
                MessageBox.Show("No se ha encontrado un release con el ID Build especificado.")
            End If

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtIDBuild.Clear()
        txtMayor.Clear()
        txtMenor.Clear()
        txtCompilacion.Clear()
        txtVersion.Clear()
        dtpLaunched.Value = Today
        txtLocation.Clear()
        txtSizeExe.Clear()
        txtDirectory.Clear()
        txtSizeDirectory.Clear()
        NUPRatio.Value = 10
        txtEspecificacion.Clear()
        DgvNotas.Rows.Clear()
        lblIDNotificacion.Text = ""
        ResetPicLogo()
        txtMayor.Focus()
    End Sub

    Private Sub btnCargarLogo_Click(sender As Object, e As EventArgs) Handles btnCargarLogo.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.InitialDirectory = "\\" & Server.Text & "\Libregco"
        OfdRutaFoto.Title = ("Seleccionar imagen para el logo")
        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
        OfdRutaFoto.FileName = ""

        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtRutaLogo.Text = OfdRutaFoto.FileName
            wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
            PicImagenLogo.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If txtRutaLogo.Text = "" Then
            MessageBox.Show("No se ha encontrado una imagen anexa para poder abrirla.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(txtRutaLogo.Text)
            End If
        End If
    End Sub

    Private Sub btnEliminarLogo_Click(sender As Object, e As EventArgs) Handles btnEliminarLogo.Click
        Try
            If txtIDBuild.Text = "" Then
                ResetPicLogo()
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la imagen anexa al registro?", "Eliminar imagen anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ResetPicLogo()
                    sqlQ = "UPDATE Libregco_Utilitarios.Version_sys SET VersionMayor='" + txtMayor.Text + "',VersionMenor='" + txtMenor.Text + "',VersionCompilacion='" + txtCompilacion.Text + "',VersionVersion='" + txtVersion.Text + "',FechaLanzamiento='" + dtpLaunched.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',Tamano='" + txtSizeExe.Text + "',Locacion='" + Replace(txtLocation.Text, "\", "\\") + "',LocacionDirectorio='" + Replace(txtDirectory.Text, "\", "\\") + "',SizeDirectorio='" + txtSizeDirectory.Text + "' WHERE IDBuild= (" + txtIDBuild.Text + ")"
                    GuardarDatos()
                    MessageBox.Show("La imagen ha sido eliminada satisfactoriamente.", "Imagen eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub ResetPicLogo()
        txtRutaLogo.Text = ""
        PicImagenLogo.Width = 312
        PicImagenLogo.Height = 307
        PicImagenLogo.Image = My.Resources.No_Image
    End Sub

    Private Sub DgvNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotas.CellDoubleClick
        If lblIDNotificacion.Text = "" Then
            lblIDNotificacion.Text = DgvNotas.CurrentRow.Cells(0).Value
            NUPRatio.Value = DgvNotas.CurrentRow.Cells(3).Value
            txtEspecificacion.Text = DgvNotas.CurrentRow.Cells(2).Value

            DgvNotas.Rows.Remove(DgvNotas.CurrentRow)
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.Title = ("Seleccionar imagen")
        OfdRutaFoto.Multiselect = False
        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaFoto.FileName = ""
        OfdRutaFoto.RestoreDirectory = True

        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
            wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
            PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
            PictureBox1.Tag = OfdRutaFoto.FileName
            wFile.Close()
        End If

    End Sub

    Private Sub DgvNotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotas.CellContentClick
        Dim wFile As System.IO.FileStream


        If e.ColumnIndex = 1 Then
            Dim OfdRutaFoto As New OpenFileDialog

            OfdRutaFoto.Title = ("Seleccionar imagen")
            OfdRutaFoto.Multiselect = False
            OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
            OfdRutaFoto.FileName = ""
            OfdRutaFoto.RestoreDirectory = True

            If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
                wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
                DgvNotas.CurrentRow.Cells(1).Value = System.Drawing.Image.FromStream(wFile)
                DgvNotas.CurrentRow.Cells(4).Value = OfdRutaFoto.FileName
                wFile.Close()
            End If

        ElseIf e.ColumnIndex = 5 Then
            If lblIDNotificacion.Text = "" Then
                lblIDNotificacion.Text = DgvNotas.CurrentRow.Cells(0).Value
                NUPRatio.Value = DgvNotas.CurrentRow.Cells(3).Value
                txtEspecificacion.Text = DgvNotas.CurrentRow.Cells(2).Value
                PictureBox1.Tag = DgvNotas.CurrentRow.Cells(4).Value
                If PictureBox1.Tag <> "" Then

                    If System.IO.File.Exists(PictureBox1.Tag) = True Then
                        wFile = New FileStream(PictureBox1.Tag, FileMode.Open, FileAccess.Read)
                        PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        If System.IO.File.Exists("\\" & PathServidor.Text & PictureBox1.Tag) = True Then
                            wFile = New FileStream("\\" & PathServidor.Text, FileMode.Open, FileAccess.Read)
                            PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        End If
                    End If
                End If

                DgvNotas.Rows.Remove(DgvNotas.CurrentRow)
            End If

        ElseIf e.ColumnIndex = 6 Then

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la nota de versión " & DgvNotas.CurrentRow.Cells(2).Value & "?", "Eliminar nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from libregco_utilitarios.update_sys Where idUpdate_sys = (" + DgvNotas.CurrentRow.Cells(0).Value.ToString + ")"
                ConUtilitarios.Open()
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()
                ConUtilitarios.Close()
                DgvNotas.Rows.Remove(DgvNotas.CurrentRow)
            End If
        End If
    End Sub
End Class