Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Public Class frm_connection_hosts

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim Host, DNS, User, Port As String
    Dim HostAproved As Boolean = False
    Private Sub frm_connection_hosts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(frm_LoginSistema.lblIcoConnection.Location.X + frm_LoginSistema.lblIcoConnection.Size.Width, 5)
        If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then

            Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))
            Dim ReadedLine As String = readNthLine(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), CInt(lines(0).Substring(lines(0).IndexOf("=") + 1)) + 1)
            Dim SelectedHost As String = Before(Between(ReadedLine, "HostName=", ";"), ";")

            CbxHosts.Items.Clear()
            For Each Line As String In File.ReadLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))
                If Line.Contains("HostName=") = True Then
                    CbxHosts.Items.Add(Before(Between(Line, "HostName=", ";"), ";"))
                End If
            Next
            CbxHosts.Text = SelectedHost

        Else

            Dim thePath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs")
            'Creo la carpeta
            IO.Directory.CreateDirectory(thePath)

            'Creo el path del servidor
            My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), "#Current=1" & vbNewLine & "----------------------------------------------" & vbNewLine & "HostName=localhost;DDNS=localhost;User=root;Port=3306", True)

        End If



        'Catch ex As Exception

        'End Try

    End Sub
    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        If Me.Owner.Name = frm_LoginSistema.Name Then
            If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then
                Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))

                lines(0) = "#Current=" & CInt(CbxHosts.SelectedIndex) + 1
                System.IO.File.WriteAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), lines)


                frm_LoginSistema.CheckConnectionMySQL()
                frm_LoginSistema.CargarPathServidor()
                frm_LoginSistema.UseDoubleBuffer()
                frm_LoginSistema.ActualizarDatos()
                frm_LoginSistema.CargarEquipo()
                frm_LoginSistema.CargarconfiguracionLibregco()
                frm_LoginSistema.CheckNewBussiness()
                frm_LoginSistema.CheckSecurePrinting()

                Close()
            End If

        ElseIf Me.Owner.name = frm_mensaje_desconexion.name Then
            If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then
                Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))

                lines(0) = "#Current=" & CInt(CbxHosts.SelectedIndex) + 1
                System.IO.File.WriteAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), lines)

                frm_LoginSistema.Show()
                frm_LoginSistema.CheckConnectionMySQL()
                frm_LoginSistema.CargarPathServidor()
                frm_LoginSistema.UseDoubleBuffer()
                frm_LoginSistema.ActualizarDatos()
                frm_LoginSistema.CargarconfiguracionLibregco()
                frm_LoginSistema.CheckNewBussiness()
                frm_LoginSistema.CheckSecurePrinting()

                Me.Close()
            End If
        End If

    End Sub

    Private Sub CbxHosts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxHosts.SelectedIndexChanged
        FillHost()
    End Sub

    Private Sub FillHost()
        Try
            lblMessage.Text = ""
            lblMessage.ForeColor = Color.Black
            CheckedImage.Visible = True
            btnContinuar.Visible = False
            CheckedImage.Image = My.Resources.TriangleLoading

            If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then
                Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))

                Dim ReadedLine As String = readNthLine(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), CbxHosts.SelectedIndex + 2)

                Host = Before(Between(ReadedLine, "HostName=", ";"), ";")
                DNS = Before(Between(ReadedLine, "DDNS=", ";"), ";")
                User = Between(ReadedLine, "User=", ";")
                Port = After(ReadedLine, "Port=")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Intentos de conexión
                Dim CLocal As String = "database=Libregco" & ";server=" & Host & ";port=" & Port & ";user id=" & User & ";password=iLM14PC1191;sslmode=None"
                Dim CnOnline As String = "database=Libregco;server=" & DNS & ";port=" & Port & ";user id=" & User & ";password=iLM14PC1191;sslmode=None"

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Dta As String
                Dim ConOnline As New MySqlConnection(CnOnline) 'Conexión de Online
                Dim ConLocal As New MySqlConnection(CLocal)

                'Intentando conexión local
                Try
                    lblMessage.ForeColor = Color.Black
                    lblMessage.Text = "Intentando conexión local..."

                    ConLocal.Open()
                    cmd = New MySqlCommand("Select Now()", ConLocal)
                    Dta = Convert.ToString(cmd.ExecuteScalar())
                    ConLocal.Close()

                    If IsDate(Dta) Then
                        CheckedImage.Visible = True
                        btnContinuar.Visible = True
                        CheckedImage.Size = New Size(160, 160)
                        CheckedImage.Location = New Point(52, 113)
                        CheckedImage.Image = My.Resources.Check_Gif
                        lblMessage.ForeColor = SystemColors.Highlight
                        lblMessage.Text = "La conexión ha sido verificada satisfactoriamente."
                        HostAproved = True
                        TypeConnection.Text = 1
                    End If

                Catch ex As Exception
                    CheckedImage.Visible = True
                    btnContinuar.Visible = False
                    CheckedImage.Size = New Size(120, 120)
                    CheckedImage.Location = New Point(72, 148)
                    CheckedImage.Image = My.Resources.Closed_GIF
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "No se ha encontrado el host."
                    HostAproved = False
                    Me.Refresh()
                    System.Threading.Thread.Sleep(250)

                    ConLocal.Close()
                    GoTo IntentoOnline
                End Try




                'Intentando conexión online
                If HostAproved = False Then
IntentoOnline:
                    Try
                        CheckedImage.Image = My.Resources.TriangleLoading
                        lblMessage.ForeColor = Color.Black
                        lblMessage.Text = "Intentando conexión por internet..."

                        ConOnline.Open()
                        cmd = New MySqlCommand("Select Now()", ConOnline)
                        Dta = Convert.ToString(cmd.ExecuteScalar())
                        ConOnline.Close()

                        If IsDate(Dta) Then
                            CheckedImage.Visible = True
                            btnContinuar.Visible = True
                            CheckedImage.Size = New Size(160, 160)
                            CheckedImage.Location = New Point(52, 113)
                            CheckedImage.Image = My.Resources.Check_Gif
                            lblMessage.ForeColor = SystemColors.Highlight
                            lblMessage.Text = "La conexión por internet ha sido verificada satisfactoriamente."
                            HostAproved = True
                            TypeConnection.Text = 0
                        End If

                    Catch ex As Exception
                        CheckedImage.Visible = True
                        btnContinuar.Visible = False
                        CheckedImage.Size = New Size(120, 120)
                        CheckedImage.Location = New Point(72, 148)
                        CheckedImage.Image = My.Resources.Closed_GIF
                        lblMessage.ForeColor = Color.Red
                        lblMessage.Text = "No se ha encontrado el host por internet."
                        HostAproved = False

                        ConOnline.Close()
                        GoTo HostNoFounded
                    End Try

                End If

                System.Threading.Thread.Sleep(100)

                If HostAproved = False Then
HostNoFounded:
                    CheckedImage.Visible = True
                    CheckedImage.Size = New Size(120, 120)
                    CheckedImage.Location = New Point(72, 148)
                    CheckedImage.Image = My.Resources.Closed_GIF
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "No se ha encontrado el host"
                    btnContinuar.Visible = False
                End If

            End If

        Catch ex As Exception

        End Try


    End Sub
End Class