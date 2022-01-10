Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports IWshRuntimeLibrary
Imports Microsoft.VisualBasic.FileIO

Public Class frm_copiar_actualizacion_sys

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend var_originfilepath As String
    Friend var_copypath As String = "C:"
    Friend var_filepathexecutable As String

    Private Sub frm_copiar_actualizacion_sys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarPathServidor()
        CargarLibregco()
        BuscarActualizaciones()
    End Sub

    Private Sub CargarPathServidor()
        Try
            ConUtilitarios.Open()
            cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=1", ConUtilitarios)
            PathServidor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConUtilitarios.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
        Label4.Visible = False
        Label15.Visible = False
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Dim fi As New System.IO.FileInfo(var_filepathexecutable)

        btnCopy.Enabled = False
        Label4.Visible = True
        Label15.Visible = True
        Label15.Text = "El sistema se está actualizando. Por favor espere..."

        My.Computer.FileSystem.CopyDirectory(var_originfilepath, var_copypath & "/" & fi.Directory.Name, UIOption.OnlyErrorDialogs, UICancelOption.DoNothing)

        'Eliminar acceso directo viejo
        Dim DeleteShortcut As String
        DeleteShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Libregco.exe"
        If System.IO.File.Exists(DeleteShortcut) = True Then
            System.IO.File.Delete(DeleteShortcut)
        End If

        'Copiar nuevo acceso directo
        Dim NewShortCut As String = lblHasta.Text & "libregco_" & Replace(lblUltimaVersion.Text, ".", "_") & "\" & "libregco.exe"
        Dim WSHShell As Object = CreateObject("WScript.Shell")
        Dim DesktopDir As String = CType(WSHShell.SpecialFolders.Item("Desktop"), String)
        Dim Shortcut As Object = WSHShell.CreateShortcut(DesktopDir & "\Libregco.lnk")
        Shortcut.IconLocation = lblHasta.Text & "libregco_" & Replace(lblUltimaVersion.Text, ".", "_") & "\" & "libregco.ico"
        Shortcut.TargetPath = NewShortCut
        Shortcut.WindowStyle = 1
        Shortcut.Description = "Sistema de gestión empresarial"
        Shortcut.Save()

        Dim DsTmp As New DataSet
        ConUtilitarios.Open()
        cmd = New MySqlCommand("SELECT concat('C:/libregco_',VersionMayor,'_',VersionMenor,'_',VersionCompilacion,'_',VersionVersion) as File FROM libregco_utilitarios.version_sys WHERE IDBuild< (SELECT MAX(IDBuild) FROM libregco_utilitarios.version_sys)-1 ORDER BY IDBuild DESC", ConUtilitarios)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTmp, "version_sys")
        ConUtilitarios.Close()

        Dim Tabla As DataTable = DsTmp.Tables("version_sys")

        For Each dt As DataRow In Tabla.Rows
            Dim ExistsFile As Boolean = System.IO.Directory.Exists(dt.Item("File"))
            If ExistsFile Then
                My.Computer.FileSystem.DeleteDirectory(dt.Item("File"), FileIO.DeleteDirectoryOption.DeleteAllContents)
            Else
                Exit For
            End If
        Next

        Tabla.Dispose()
        DsTmp.Dispose()

        If Me.Owner.Name = frm_LoginSistema.Name Then
            Application.Exit()
        ElseIf Me.Owner.Name = frm_inicio.Name Then
            frm_inicio.CerrarSistemaToolStripMenuItem.Tag = 4
            frm_inicio.Close()
        End If
    End Sub


    Private Sub BuscarActualizaciones()
        Try
            'Conseguir la versión del ejecutable

            lblVersionActual.Text = Replace(My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath.Substring(0, My.Application.Info.DirectoryPath.IndexOf("libregco_")).Trim, "").Replace("_", ".").Replace("libregco.", "")

            ConUtilitarios.Open()
            cmd = New MySqlCommand("SELECT IDBuild FROM libregco_utilitarios.version_sys where concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion)='" + lblVersionActual.Text + "'", ConUtilitarios)
            lblBuildActual.Text = Convert.ToString(cmd.ExecuteScalar())
            ConUtilitarios.Close()

            If lblBuildActual.Text <> "" Then
                Dim DsTmp As New DataSet
                DsTmp.Clear()
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTmp, "version_sys")
                ConUtilitarios.Close()

                Dim Tabla As DataTable = DsTmp.Tables("version_sys")

                If Tabla.Rows.Count > 0 Then
                    lblUltimoBuild.Text = Tabla.Rows(0).Item("IDBuild")
                    lblUltimaVersion.Text = Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion")
                    lblDesde.Text = "\\" & PathServidor.Text & (Tabla.Rows(0).Item("LocacionDirectorio"))
                    lblHasta.Text = "C:\"

                    If CInt(lblUltimoBuild.Text) > CInt(lblBuildActual.Text) Then

                        Dim PathInfo As New System.IO.FileInfo("\\" & PathServidor.Text & Tabla.Rows(0).Item("Locacion"))

                        If System.IO.Directory.Exists("C:\" & PathInfo.Directory.Name) Then
                            Exit Sub
                        Else

                            Con.Open()
                            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=119", Con)
                            Dim ActOblig As String = Convert.ToString(cmd.ExecuteScalar())
                            Con.Close()

                            If ActOblig = 1 Then
                                MessageBox.Show("Se ha encontrado una actualización del sistema. ", "Nueva versión " & Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                btnCopy.Enabled = True
                                btnCopy.PerformClick()
                            Else

                                Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado una actualización del sistema. " & vbNewLine & vbNewLine & "Tenga en cuenta que las actualizaciones sirven para arreglar y reparar cualquier tipo de procedimientos que realiza el sistema." & vbNewLine & vbNewLine & "Desea empezar la actualización del sistema?", "Nueva versión " & Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If Result = MsgBoxResult.Yes Then
                                    btnCopy.Enabled = True
                                Else
                                    Close()
                                End If
                            End If

                        End If



                    Else
                        btnCopy.Enabled = False
                        Label15.Text = "Ya tienes instalada la última versión del sistema.!"
                        Label15.ForeColor = Color.Green
                    End If
                Else
                    lblUltimoBuild.Text = ""
                    lblUltimaVersion.Text = ""
                End If


            Else
                Dim DsTmp As New DataSet
                DsTmp.Clear()
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTmp, "version_sys")
                ConUtilitarios.Close()

                Dim Tabla As DataTable = DsTmp.Tables("version_sys")

                If Tabla.Rows.Count > 0 Then
                    lblUltimoBuild.Text = Tabla.Rows(0).Item("IDBuild")
                    lblUltimaVersion.Text = Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion")
                    lblDesde.Text = "\\" & PathServidor.Text & (Tabla.Rows(0).Item("LocacionDirectorio"))
                    lblHasta.Text = "C:\"

                    If CInt(lblUltimoBuild.Text) > CInt(lblBuildActual.Text) Then

                        Con.Open()
                        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=119", Con)
                        Dim ActOblig As String = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()

                        If ActOblig = 1 Then
                            MessageBox.Show("Se ha encontrado una actualización del sistema. ", "Nueva versión " & Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            btnCopy.Enabled = True
                            btnCopy.PerformClick()
                        Else
                            Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado una actualización del sistema. " & vbNewLine & vbNewLine & "Tenga en cuenta que las actualizaciones sirven para arreglar y reparar cualquier tipo de procedimientos que realiza el sistema." & vbNewLine & vbNewLine & "Desea empezar la actualización del sistema?", "Nueva versión " & Tabla.Rows(0).Item("VersionMayor") & "." & Tabla.Rows(0).Item("VersionMenor") & "." & Tabla.Rows(0).Item("VersionCompilacion") & "." & Tabla.Rows(0).Item("VersionVersion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If Result = MsgBoxResult.Yes Then
                                btnCopy.Enabled = True
                            Else
                                Close()
                            End If
                        End If

                    Else
                        btnCopy.Enabled = False
                        Label15.Text = "Ya tienes instalada la última versión del sistema.!"
                        Label15.ForeColor = Color.Green
                    End If
                Else
                    lblUltimoBuild.Text = ""
                    lblUltimaVersion.Text = ""
                End If

            End If


        Catch ex As Exception

        End Try

    End Sub
End Class