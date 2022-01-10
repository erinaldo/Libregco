Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frm_messenger
    Friend IDUser, UserImageFilePath, IDEstatusConversacion, IDUserRole, IDConversacion, IDConversacionUser, IDMessage As String
    Friend IDSelectedUser, IDSelectedUserIDStatus, NameSelectedUser, SelectedUserPicture As String
    Friend NewConversation As Boolean = False
    Friend Con As New MySqlConnection(CnString)
    Friend sqlQ As String
    Friend cmd As MySqlCommand
    Friend Ds, DsConversaciones As New DataSet
    Friend Adaptador As MySqlDataAdapter
    Private mRow As Integer = 0
    Private newpage As Boolean = True
    Dim Arrastre As Boolean
    Dim ex, ey, CountedMessages As Integer

    Private Sub frm_messenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        IDUser = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        btnSend.Enabled = False
        Button5.Visible = False

        If IsNumeric(IDUser) Then
            GetUsersInfo()
            FillUsers()
            FillConversation()
        End If

        If frm_new_message.Visible = True Then
            frm_new_message.Close()
        End If
    End Sub

    Sub SaveDate()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillUsers()
        Try
            DgvUsers.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDEmpleado,ImagenChat,Empleados.Nombre,Empleados.IDChatStatus,EstatusConversacion.Status,ARGB FROM Empleados INNER JOIN EstatusConversacion on Empleados.IDChatStatus=EstatusConversacion.IDEstatusConversacion where Empleados.Nombre like '%" + txtBuscarUsuarios.Text + "%' ORDER BY Nombre ASC", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorDocumentos.GetValue(1))
                If ExistFile = True Then
                    DgvUsers.Rows.Add(LectorDocumentos.GetValue(0), Image.FromFile(LectorDocumentos.GetValue(1)), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3), LectorDocumentos.GetValue(4), LectorDocumentos.GetValue(5), LectorDocumentos.GetValue(1))
                Else
                    DgvUsers.Rows.Add(LectorDocumentos.GetValue(0), My.Resources.no_photo, LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3), LectorDocumentos.GetValue(4), LectorDocumentos.GetValue(5), "")
                End If
            End While
            LectorDocumentos.Close()
            Con.Close()

            'Look at me to mark and change color status in users
            If IsNumeric(IDUser) Then
                For Each row As DataGridViewRow In DgvUsers.Rows
                    If row.Cells(0).Value = IDUser Then
                        row.Cells(2).Value = "(Yo) " & row.Cells(2).Value
                        row.Cells(2).Style.ForeColor = Color.Orange
                    End If
                    row.Cells(4).Style.ForeColor = Color.FromArgb(row.Cells(5).Value)
                Next
            End If

            DgvUsers.ClearSelection()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " FillUsers")
        End Try
    End Sub

    Sub FillConversation()
        Try
            Dim newImage As Image
            Dim PathNewImage As String
            DgvConversations.Rows.Clear()

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Conversaciones.IDConversacion,UsuariosConversacion.IDUsuariosConversacion,UsuariosConversacion.IDEmpleado FROM Libregco.conversaciones INNER JOIN Libregco.UsuariosConversacion on Conversaciones.IDConversacion=UsuariosConversacion.IDConversacion where IDEmpleado='" + IDUser + "' and Individual=1", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Conversaciones")

            Dim Tabla As DataTable = Ds.Tables("Conversaciones")
            Dim TablaUsuarios As DataTable

            For Each row As DataRow In Tabla.Rows
                DsConversaciones.Clear()
                cmd = New MySqlCommand("SELECT usuariosconversacion.IDUsuariosConversacion,usuariosconversacion.IDConversacion,usuariosconversacion.IDEmpleado,Empleados.Nombre,Empleados.ImagenChat,usuariosconversacion.IDRol,RolConversacion.Rol,UsuariosConversacion.IDEstadoChat,EstatusConversacion.Status,EstatusConversacion.ARGB,UsuariosConversacion.Fecha as DateRegistryUser,Descripcion,Conversaciones.Fecha as CreateDate,ImagenConversacion,Individual,IDEmpleadoCreador,CreatedBy.Nombre as NameCreatedBy,CreatedBy.ImagenChat as ImageCreatedBy,(SELECT count(Leido) FROM Mensajes Inner join UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where Leido=0 and UsuariosConversacion.IDEmpleado<>'" + IDUser + "' and UsuariosConversacion.IDConversacion='" + row.Item(0).ToString + "') as CantNoRead FROM libregco.usuariosconversacion INNER JOIN Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion INNER JOIN RolConversacion on UsuariosConversacion.IDRol=RolConversacion.IDRolConversacion INNER JOIN EstatusConversacion on UsuariosConversacion.IDEstadoChat=EstatusConversacion.IDEstatusConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN Empleados as CreatedBy on Conversaciones.IDEmpleadoCreador=CreatedBy.IDEmpleado where UsuariosConversacion.IDConversacion='" + row.Item(0).ToString + "' and UsuariosConversacion.IDEmpleado<>'" + IDUser + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsConversaciones, "Usuarios")

                TablaUsuarios = DsConversaciones.Tables("Usuarios")

                For Each rw As DataRow In TablaUsuarios.Rows
                    'Foto de personas del chat
                    Dim ExistFile As Boolean = System.IO.File.Exists(rw.Item(4))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(rw.Item(4), FileMode.Open, FileAccess.Read)
                        newImage = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                        PathNewImage = rw.Item(4)
                    Else
                        newImage = My.Resources.no_photo
                        PathNewImage = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\no_photo.jpg"
                    End If

                    DgvConversations.Rows.Add(rw.Item(0), ResizeImage(newImage, 70), rw.Item(3), CDate(rw.Item(12)).ToString("dd/MM/yyyy hh:mm:ss tt"), PathNewImage, rw.Item(18), rw.Item(14), rw.Item(1))
                Next
            Next

            Con.Close()

            If DgvConversations.Rows.Count = 0 Then
                DgvConversations.Rows.Add("", Nothing, "No hay conversaciones encontradas en el historial del chat.", Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("hh:mm:ss tt"))
            End If

            DgvConversations.ClearSelection()
            SetFormatConversations()
            Button5.Visible = False
            lblShowing.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " FillConversation")
        End Try

    End Sub


    Private Sub SetFormatConversations()
        Try
            For Each row As DataGridViewRow In DgvConversations.Rows
                If row.Cells(5).Value = 0 Then
                    row.DefaultCellStyle.BackColor = Color.White
                Else
                    row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Friend Sub GetUsersInfo()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,ImagenChat,Nombre,IDChatStatus,EstatusConversacion.Status,ARGB FROM Empleados INNER JOIN EstatusConversacion on Empleados.IDChatStatus=EstatusConversacion.IDEstatusConversacion Where IDEmpleado='" + IDUser + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "User")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("User")
            If Tabla.Rows.Count = 0 Then
                Exit Sub
            Else
                lblName.Text = (Tabla.Rows(0).Item("Nombre"))
                IDEstatusConversacion = (Tabla.Rows(0).Item("IDChatStatus"))
                lblStatus.Text = (Tabla.Rows(0).Item("Status"))
                lblStatus.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ARGB"))

                If Tabla.Rows(0).Item("ImagenChat") = "" Then
                    PicClient.Image = My.Resources.no_photo
                    UserImageFilePath = ""
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("ImagenChat"))
                    If ExistFile = True Then
                        PicClient.Image = Image.FromFile(Tabla.Rows(0).Item("ImagenChat"))
                        UserImageFilePath = (Tabla.Rows(0).Item("ImagenChat"))
                        MakeRoundedImage(PicClient.Image, PicClient)
                    End If
                End If


                FillUsers()
                FillConversation()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " GetUSERSInfo")
        End Try

    End Sub

    Private Sub MakeRoundedImage(ByVal Img As Image, ByVal PicBox As PictureBox)
        Try
            Using bm As New Bitmap(Img.Width, Img.Height)
                Using grx2 As Graphics = Graphics.FromImage(bm)
                    grx2.SmoothingMode = SmoothingMode.AntiAlias
                    Using tb As New TextureBrush(Img)
                        tb.TranslateTransform(0, 0)
                        Using gp As New GraphicsPath
                            gp.AddEllipse(0, 0, Img.Width, Img.Height)
                            grx2.FillPath(tb, gp)
                        End Using
                    End Using
                End Using
                If PicBox.Image IsNot Nothing Then PicBox.Image.Dispose()
                PicBox.Image = New Bitmap(bm)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            DgvMessages.ClearSelection()
            txtmessage.Focus()
        ElseIf TabControl1.SelectedIndex = 1 Then
            DgvConversations.ClearSelection()
            Button5.Visible = False
        ElseIf TabControl1.SelectedIndex = 2 Then
            DgvUsers.ClearSelection()
            txtBuscarUsuarios.Focus()
        End If
    End Sub

    Private Sub DgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvUsers.CellClick
        'Try
        Dim newImage As Image
        Dim PathNewImage As String

        If e.RowIndex >= 0 Then
            If DgvUsers.CurrentRow.Cells(0).Value = IDUser Then
            Else
                DgvConversations.Rows.Clear()
                Button5.Visible = False
                IDSelectedUser = DgvUsers.CurrentRow.Cells(0).Value
                NameSelectedUser = DgvUsers.CurrentRow.Cells(2).Value
                lblShowing.Text = "conversaciones con " & NameSelectedUser
                IDSelectedUserIDStatus = DgvUsers.CurrentRow.Cells(3).Value
                SelectedUserPicture = DgvUsers.CurrentRow.Cells(6).Value

                'Conversaciones en la que estoy
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT Conversaciones.IDConversacion,UsuariosConversacion.IDUsuariosConversacion,UsuariosConversacion.IDEmpleado FROM Libregco.conversaciones INNER JOIN Libregco.UsuariosConversacion on Conversaciones.IDConversacion=UsuariosConversacion.IDConversacion where IDEmpleado='" + IDUser + "' and Individual=1", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Conversaciones")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Conversaciones")
                Dim TablaUsuarios As DataTable


                For Each rw As DataRow In Tabla.Rows
                    DsConversaciones.Clear()
                    cmd = New MySqlCommand("SELECT usuariosconversacion.IDUsuariosConversacion,usuariosconversacion.IDConversacion,usuariosconversacion.IDEmpleado,Empleados.Nombre,Empleados.ImagenChat,usuariosconversacion.IDRol,RolConversacion.Rol,UsuariosConversacion.IDEstadoChat,EstatusConversacion.Status,EstatusConversacion.ARGB,UsuariosConversacion.Fecha as DateRegistryUser,Descripcion,Conversaciones.Fecha as CreateDate,ImagenConversacion,Individual,IDEmpleadoCreador,CreatedBy.Nombre as NameCreatedBy,CreatedBy.ImagenChat as ImageCreatedBy,(SELECT count(Leido) FROM Mensajes Inner join UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where Leido=0 and UsuariosConversacion.IDEmpleado<>'" + IDUser + "' and UsuariosConversacion.IDConversacion='" + rw.Item(0).ToString + "') as CantNoRead FROM libregco.usuariosconversacion INNER JOIN Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion INNER JOIN RolConversacion on UsuariosConversacion.IDRol=RolConversacion.IDRolConversacion INNER JOIN EstatusConversacion on UsuariosConversacion.IDEstadoChat=EstatusConversacion.IDEstatusConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN Empleados as CreatedBy on Conversaciones.IDEmpleadoCreador=CreatedBy.IDEmpleado where UsuariosConversacion.IDConversacion='" + rw.Item(0).ToString + "' and UsuariosConversacion.IDEmpleado='" + IDSelectedUser + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsConversaciones, "ConversacionescElegido")

                    TablaUsuarios = DsConversaciones.Tables("ConversacionescElegido")
                    If TablaUsuarios.Rows.Count = 0 Then
                    Else
                        'Foto de personas del chat
                        Dim ExistFile As Boolean = System.IO.File.Exists(TablaUsuarios.Rows(0).Item(4))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(TablaUsuarios.Rows(0).Item(4), FileMode.Open, FileAccess.Read)
                            newImage = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                            PathNewImage = TablaUsuarios.Rows(0).Item(4)
                        Else
                            newImage = My.Resources.no_photo
                            PathNewImage = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\no_photo.jpg"
                        End If

                        DgvConversations.Rows.Add(TablaUsuarios.Rows(0).Item(0), MakeCircleImagefromDgv(newImage), TablaUsuarios.Rows(0).Item(3), CDate(TablaUsuarios.Rows(0).Item(12)).ToString("dd/MM/yyyy hh:mm:ss tt"), PathNewImage, TablaUsuarios.Rows(0).Item(18), TablaUsuarios.Rows(0).Item(14), TablaUsuarios.Rows(0).Item(1))
                    End If
                Next

                If DgvConversations.Rows.Count = 0 Then
                    DgvConversations.Rows.Clear()
                    DgvConversations.Rows.Add("", Nothing, "No hay conversaciones encontradas en el historial del chat.", Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("hh:mm:ss tt"))
                    DgvMessages.Rows.Clear()
                    IDConversacion = ""
                    lblType.Text = "Charla Individual"
                    lblSubject.Text = NameSelectedUser

                    If SelectedUserPicture = "" Then
                        CurrentConversationPicture.Image = My.Resources.no_photo
                    Else
                        CurrentConversationPicture.Image = Image.FromFile(SelectedUserPicture)
                        MakeRoundedImage(CurrentConversationPicture.Image, CurrentConversationPicture)
                    End If

                    NewConversation = True
                    TabControl1.SelectedIndex = 0
                    txtmessage.Focus()
                Else
                    lblType.Text = "Charla Grupal"
                    TabControl1.SelectedIndex = 1

                End If
            End If
        End If

        SetFormatConversations()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString & "DgvUsers_CellClick")
        'End Try
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        'Try

        If NewConversation = True Then

            If SelectedUserPicture = "" Then
                CurrentConversationPicture.Image = My.Resources.no_photo
                SelectedUserPicture = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\no_photo.jpg"
            End If

            'Creating new conversation
            sqlQ = "INSERT INTO Conversaciones (Descripcion,Objetivos,Fecha,ImagenConversacion,Individual,IDEmpleadoCreador) VALUES ('" + NameSelectedUser + "','', '" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + Replace(SelectedUserPicture, "\", "\\") + "',1,'" + IDUser + "')"
            SaveDate()

            'Getting the last ID Record on conversation
            Con.Open()
            cmd = New MySqlCommand("Select IDConversacion from Conversaciones where IDConversacion= (Select Max(IDConversacion) from Conversaciones)", Con)
            IDConversacion = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            'Setting users into conversation
            'Admin
            sqlQ = "INSERT INTO UsuariosConversacion (IDConversacion,IDEmpleado,IDRol,IDEstadoChat,Fecha,Nulo) VALUES ('" + IDConversacion + "', '" + IDUser + "',1,'" + IDEstatusConversacion + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',0)"
            SaveDate()

            'Get IDConversacionUser of admin
            Con.Open()
            cmd = New MySqlCommand("Select IDUsuariosConversacion from UsuariosConversacion where IDUsuariosConversacion= (Select Max(IDUsuariosConversacion) from UsuariosConversacion)", Con)
            IDConversacionUser = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            'Private
            sqlQ = "INSERT INTO UsuariosConversacion (IDConversacion,IDEmpleado,IDRol,IDEstadoChat,Fecha,Nulo) VALUES ('" + IDConversacion + "', '" + IDSelectedUser + "',2,'" + IDSelectedUserIDStatus + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',0)"
            SaveDate()

            'Saving the message
            sqlQ = "INSERT INTO Mensajes (IDUsuarioConversacion,Mensaje,FechaEnvio,FechaLectura,Leido,Adjunto,Avisado) VALUES ('" + IDConversacionUser + "', '" + txtmessage.Text + "',Now(),'0000-00-00 00:00:00','0','" + Replace(AttachfilesPath.Text, "\", "\\") + "',0)"
            SaveDate()

            'Getting the ID message
            Con.Open()
            cmd = New MySqlCommand("Select IDMensaje from Mensajes where IDMensaje= (Select Max(IDMensaje) from Mensajes)", Con)
            IDMessage = Convert.ToString(cmd.ExecuteReader())
            Con.Close()

            'Setting User info in Messengdaer
            IDUserRole = 1
            lblType.Text = "Charla Individual"
            lblSubject.Text = NameSelectedUser

            MakeRoundedImage(Image.FromFile(SelectedUserPicture), CurrentConversationPicture)
            FillUsers()
            FillConversation()
            'MsgBox(0)
            'FillAlldMesages()

        Else

            'Saving the message
            sqlQ = "INSERT INTO Mensajes (IDUsuarioConversacion,Mensaje,FechaEnvio,FechaLectura,Leido,Adjunto,Avisado) VALUES ('" + IDConversacionUser + "', '" + txtmessage.Text + "',Now(),'0000-00-00 00:00:00','0','" + Replace(AttachfilesPath.Text, "\", "\\") + "',0)"
            SaveDate()

            'Getting the ID message
            Con.Open()
            cmd = New MySqlCommand("Select IDMensaje from Mensajes where IDMensaje= (Select Max(IDMensaje) from Mensajes)", Con)
            IDMessage = Convert.ToString(cmd.ExecuteReader())
            Con.Close()
        End If


        ''''''''''''''''''''''''''

        Dim DsTmp As New DataSet
        Con.Open()
        cmd = New MySqlCommand("SELECT IDMensaje as IDM,Mensajes.IDUsuarioConversacion,UsuariosConversacion.IDConversacion as IDC,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Mensaje,FechaEnvio,IF(FechaLectura='0000-00-00' OR FechaLectura IS NULL,'',FechaLectura) AS DateRead,Leido,Adjunto,ifnull((Select UsuariosConversacion.IDEmpleado from Mensajes Inner join libregco.usuariosconversacion on mensajes.idusuarioconversacion=usuariosconversacion.idusuariosconversacion Where IDMensaje<IDM AND IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),0) as LastMessageIdentify,ifnull((Select FechaEnvio from Mensajes Where Mensajes.IDMensaje<IDM And IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),FechaEnvio) as DateBeforeMessage FROM Mensajes INNER JOIN UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado Where UsuariosConversacion.IDConversacion='" + IDConversacion + "' ORDER BY IDM DESC LIMIT 1", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTmp, "LastChat")
        Con.Close()

        Dim Tabla As DataTable = DsTmp.Tables("LastChat")


        If Today.ToShortDateString <> CDate(Tabla.Rows(0).Item("FechaEnvio")).ToShortDateString Then
            DgvMessages.Rows.Add(0, "", "")
            DgvMessages.Rows.Add(0, "", "", "--------------------------------------------------" & Today.ToString("dd/MM/yyyy") & "--------------------------------------------------")
            DgvMessages.Rows.Add(0, "", "")

        End If

        If Tabla.Rows(0).Item("LastMessageIdentify") = 0 Then
            DgvMessages.Rows.Add(1, IDMessage, IDConversacionUser, lblName.Text & " dice:  ", Now.ToString("hh:mm:ss tt"))
        Else
            If IDUser <> Tabla.Rows(0).Item("LastMessageIdentify") Then
                DgvMessages.Rows.Add(1, IDMessage, IDConversacionUser, lblName.Text & " dice:  ", Now.ToString("hh:mm:ss tt"))
            End If
        End If

        If txtmessage.Text <> "" Then
            DgvMessages.Rows.Add(2, IDMessage, IDConversacionUser, txtmessage.Text & " (" & Now.ToString("hh:mm:ss tt") & ")", "", "", False)
        End If
        If AttachfilesPath.Text <> "" Then
            DgvMessages.Rows.Add(3, IDMessage, IDConversacionUser, AttachfilesPath.Text, "", "", Now.ToString("hh:mm:ss tt"))
        End If


        'Cleaning textbox
        NewConversation = False
        txtmessage.Clear()
        txtmessage.Focus()
        AttachfilesPath.Text = ""
        btnSend.Enabled = False

        If DgvMessages.Rows.Count > 0 Then
            DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
        End If


        DgvMessages.ClearSelection()

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub DgvConversations_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConversations.CellDoubleClick
        'Try
        If e.RowIndex >= 0 Then
            FillPreInfo()
        End If

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try


    End Sub

    Sub FillPreInfo()
        IDConversacion = DgvConversations.CurrentRow.Cells(7).Value

        If IDConversacion = "" Then
            NewConversation = True
        Else
            NewConversation = False
            lblSubject.Text = DgvConversations.CurrentRow.Cells(2).Value

            If DgvConversations.CurrentRow.Cells(6).Value = 1 Then
                lblType.Text = "Charla Individual"
            ElseIf DgvConversations.CurrentRow.Cells(6).Value = 0 Then
                lblType.Text = "Charla Grupal"
            End If

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDUsuariosConversacion,UsuariosConversacion.IDConversacion,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Individual,if(individual=0,Conversaciones.ImagenConversacion,Empleados.ImagenChat) as ImagenConversacion,UsuariosConversacion.IDRol,RolConversacion.Rol,UsuariosConversacion.IDEstadoChat,EstatusConversacion.Status FROM UsuariosConversacion INNER JOIN RolConversacion on UsuariosConversacion.IDRol=RolConversacion.IDRolConversacion INNER JOIN EstatusConversacion on UsuariosConversacion.IDEstadoChat=EstatusConversacion.idEstatusConversacion INNER JOIN Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado Where UsuariosConversacion.IDEmpleado='" + IDUser + "' and UsuariosConversacion.IDConversacion='" + IDConversacion + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Conversation")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Conversation")
            IDUserRole = (Tabla.Rows(0).Item("IDRol"))
            IDConversacionUser = (Tabla.Rows(0).Item("IDUsuariosConversacion"))

            If Tabla.Rows(0).Item("ImagenConversacion") = "" Then
                CurrentConversationPicture.Image = My.Resources.no_photo
                SelectedUserPicture = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\no_photo.jpg"
            Else
                Dim ExistFile As Boolean = System.IO.File.Exists((Tabla.Rows(0).Item("ImagenConversacion")))
                If ExistFile = True Then
                    CurrentConversationPicture.Image = Image.FromFile(DgvConversations.CurrentRow.Cells(4).Value)
                    SelectedUserPicture = DgvConversations.CurrentRow.Cells(4).Value
                Else
                    CurrentConversationPicture.Image = My.Resources.no_photo
                    SelectedUserPicture = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\no_photo.jpg"
                End If
            End If

            MakeRoundedImage(CurrentConversationPicture.Image, CurrentConversationPicture)

            DgvMessages.Rows.Clear()
            FillAlldMesages()

            MessageFormat()
            TabControl1.SelectedIndex = 0

            If DgvMessages.Rows.Count > 0 Then
                DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
            End If

            txtmessage.Focus()
            Application.DoEvents()

            FillConversation()
        End If

    End Sub

    'Sub ChangeColorsToNoReadMessages()
    '    Try
    '        Dim RowValidIndex As Integer
    '        For Each Row As DataGridViewRow In DgvMessages.Rows
    '            'Settings no Read message
    '            If Row.Cells(2).Value <> IDConversacionUser Then
    '                If Row.Cells(0).Value = 2 Then
    '                    RowValidIndex = Row.Index.ToString

    '                    If Row.Cells(6).Value.ToString = False Then
    '                        DgvMessages.Rows(RowValidIndex - 1).DefaultCellStyle.BackColor = Color.LightGray
    '                        DgvMessages.Rows(RowValidIndex + 1).DefaultCellStyle.BackColor = Color.LightGray
    '                        Row.Cells(3).Style.BackColor = Color.LightGray
    '                        Row.Cells(4).Style.BackColor = Color.LightGray
    '                        Row.Cells(5).Style.BackColor = Color.LightGray
    '                    Else
    '                        Row.Cells(3).Style.BackColor = Color.White
    '                        Row.Cells(4).Style.BackColor = Color.White
    '                        Row.Cells(5).Style.BackColor = Color.White
    '                        DgvMessages.Rows(RowValidIndex - 1).DefaultCellStyle.BackColor = Color.White
    '                        DgvMessages.Rows(RowValidIndex + 1).DefaultCellStyle.BackColor = Color.White
    '                    End If
    '                    DgvMessages.Refresh()
    '                End If
    '            End If
    '        Next
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub txtmessage_TextChanged(sender As Object, e As EventArgs) Handles txtmessage.TextChanged
        If lblSubject.Text = "" Then
        Else
            If AttachfilesPath.Text = "" Then
                If txtmessage.Text = "" Then
                    btnSend.Enabled = False
                Else
                    btnSend.Enabled = True
                End If
            Else
                btnSend.Enabled = True
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FillConversation()
        IDSelectedUser = ""
    End Sub


    Sub FillUnReadMesages()
        'Try
        If IDConversacion = "" Then
        Else
           
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDMensaje as IDM,Mensajes.IDUsuarioConversacion,UsuariosConversacion.IDConversacion as IDC,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Mensaje,FechaEnvio,IF(FechaLectura='0000-00-00' OR FechaLectura IS NULL,'',FechaLectura) AS DateRead,Leido,Adjunto,ifnull((Select UsuariosConversacion.IDEmpleado from Mensajes Inner join libregco.usuariosconversacion on mensajes.idusuarioconversacion=usuariosconversacion.idusuariosconversacion Where IDMensaje<IDM AND IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),0) as LastMessageIdentify,ifnull((Select FechaEnvio from Mensajes Where Mensajes.IDMensaje<IDM And IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),FechaEnvio) as DateBeforeMessage FROM Mensajes INNER JOIN UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado Where IDConversacion='" + IDConversacion + "' AND Leido=0 and UsuariosConversacion.IDUsuariosConversacion<>'" + IDConversacionUser + "'ORDER BY FechaEnvio ASC", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read

                ''---
                If CDate(LectorDocumentos.GetValue(6)).ToShortDateString <> CDate(LectorDocumentos.GetValue(11)).ToShortDateString Then
                    DgvMessages.Rows.Add(0, "", "")
                    DgvMessages.Rows.Add(0, "", "", "--------------------------------------------------" & CDate(LectorDocumentos.GetValue(6)).ToString("dd/MM/yyyy") & "--------------------------------------------------")
                    DgvMessages.Rows.Add(0, "", "")

                End If

                If LectorDocumentos.GetValue(10) = 0 Then
                    DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                Else
                    If LectorDocumentos.GetValue(3) <> LectorDocumentos.GetValue(10) Then
                        DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                    End If
                End If

                If LectorDocumentos.GetValue(5) <> "" Then
                    DgvMessages.Rows.Add(2, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(5) & " (" & CDate(LectorDocumentos.GetValue(6)).ToString("hh:mm:ss tt") & ")", "", "", LectorDocumentos.GetValue(8))
                End If
                If LectorDocumentos.GetValue(9) <> "" Then
                    DgvMessages.Rows.Add(3, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(9), "", "", LectorDocumentos.GetValue(8))
                End If

                'DgvMessages.Rows.Add(0, "", "")
            End While


            LectorDocumentos.Close()
            Con.Close()


            CountedMessages = DgvMessages.Rows.Count

            DgvMessages.ClearSelection()
            If DgvMessages.Rows.Count > 0 Then
                DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
            End If

        End If

        FindUltMessage()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString & " from FillMesages")
        'End Try


    End Sub

    Sub FillAlldMesages()
        'Try
        Dim TmpConnection As New MySqlConnection(CnGeneral)

        If IDConversacion = "" Then
        Else
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDMensaje as IDM,Mensajes.IDUsuarioConversacion,UsuariosConversacion.IDConversacion as IDC,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Mensaje,FechaEnvio,IF(FechaLectura='0000-00-00' OR FechaLectura IS NULL,'',FechaLectura) AS DateRead,Leido,Adjunto,ifnull((Select UsuariosConversacion.IDEmpleado from Mensajes Inner join libregco.usuariosconversacion on mensajes.idusuarioconversacion=usuariosconversacion.idusuariosconversacion Where IDMensaje<IDM AND IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),0) as LastMessageIdentify,ifnull((Select FechaEnvio from Mensajes Where Mensajes.IDMensaje<IDM And IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),FechaEnvio) as DateBeforeMessage FROM Mensajes INNER JOIN UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado Where IDConversacion='" + IDConversacion + "' ORDER BY FechaEnvio ASC", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read

                ''---
                If CDate(LectorDocumentos.GetValue(6)).ToShortDateString <> CDate(LectorDocumentos.GetValue(11)).ToShortDateString Then
                    DgvMessages.Rows.Add(0, "", "")
                    DgvMessages.Rows.Add(0, "", "", "--------------------------------------------------" & CDate(LectorDocumentos.GetValue(6)).ToString("dd/MM/yyyy") & "--------------------------------------------------")
                    DgvMessages.Rows.Add(0, "", "")

                End If

                If LectorDocumentos.GetValue(10) = 0 Then
                    DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                Else
                    If LectorDocumentos.GetValue(3) <> LectorDocumentos.GetValue(10) Then
                        DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                    End If
                End If

                If LectorDocumentos.GetValue(5) <> "" Then
                    DgvMessages.Rows.Add(2, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(5) & " (" & CDate(LectorDocumentos.GetValue(6)).ToString("hh:mm:ss tt") & ")", "", "", LectorDocumentos.GetValue(8))
                End If
                If LectorDocumentos.GetValue(9) <> "" Then
                    DgvMessages.Rows.Add(3, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(9), "", "", LectorDocumentos.GetValue(8))
                End If
            End While

            DgvMessages.Rows.Add(0, "", "")
            LectorDocumentos.Close()
            Con.Close()

            TmpConnection.Open()

            sqlQ = "UPDATE" & SysName.Text & "Mensajes INNER JOIN" & SysName.Text & "UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN" & SysName.Text & "Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion SET Leido=1 Where UsuariosConversacion.IDEmpleado <> '" + IDUser + "' and Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosCOnversacion and (SELECT 1 FROM" & SysName.Text & "UsuariosConversacion WHERE Conversaciones.IDConversacion = UsuariosConversacion.IDConversacion AND UsuariosConversacion.IDEmpleado = '" + IDUser + "') AND UsuariosConversacion.IDConversacion='" + IDConversacion + "' AND Leido=0"
            cmd = New MySqlCommand(sqlQ, TmpConnection)
            cmd.ExecuteNonQuery()
            TmpConnection.Close()

            CountedMessages = DgvMessages.Rows.Count

            DgvMessages.ClearSelection()
            If DgvMessages.Rows.Count > 0 Then
                DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
            End If

        End If

       

        FindUltMessage()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString & " from FillMesages")
        'End Try


    End Sub



    Sub FillReadMesages()
        'Try
        If IDConversacion = "" Then
        Else
            DgvMessages.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDMensaje as IDM,Mensajes.IDUsuarioConversacion,UsuariosConversacion.IDConversacion as IDC,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Mensaje,FechaEnvio,IF(FechaLectura='0000-00-00' OR FechaLectura IS NULL,'',FechaLectura) AS DateRead,Leido,Adjunto,ifnull((Select UsuariosConversacion.IDEmpleado from Mensajes Inner join libregco.usuariosconversacion on mensajes.idusuarioconversacion=usuariosconversacion.idusuariosconversacion Where IDMensaje<IDM AND IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),0) as LastMessageIdentify,ifnull((Select FechaEnvio from Mensajes Where Mensajes.IDMensaje<IDM And IDConversacion='" + IDConversacion + "' ORDER BY IDMensaje DESC LIMIT 1),FechaEnvio) as DateBeforeMessage FROM Mensajes INNER JOIN UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado Where IDConversacion='" + IDConversacion + "' AND Leido=1 ORDER BY FechaEnvio ASC", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read

                ''---
                If CDate(LectorDocumentos.GetValue(6)).ToShortDateString <> CDate(LectorDocumentos.GetValue(11)).ToShortDateString Then
                    DgvMessages.Rows.Add(0, "", "")
                    DgvMessages.Rows.Add(0, "", "", "--------------------------------------------------" & CDate(LectorDocumentos.GetValue(6)).ToString("dd/MM/yyyy") & "--------------------------------------------------")
                    DgvMessages.Rows.Add(0, "", "")

                End If

                If LectorDocumentos.GetValue(10) = 0 Then
                    DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                Else
                    If LectorDocumentos.GetValue(3) <> LectorDocumentos.GetValue(10) Then
                        DgvMessages.Rows.Add(1, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(4) & " dice:  ", LectorDocumentos.GetValue(7))
                    End If
                End If

                If LectorDocumentos.GetValue(5) <> "" Then
                    DgvMessages.Rows.Add(2, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(5) & " (" & CDate(LectorDocumentos.GetValue(6)).ToString("hh:mm:ss tt") & ")", "", "", LectorDocumentos.GetValue(8))
                End If
                If LectorDocumentos.GetValue(9) <> "" Then
                    DgvMessages.Rows.Add(3, LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(9), "", "", LectorDocumentos.GetValue(8))
                End If
            End While

            DgvMessages.Rows.Add(0, "", "")
            LectorDocumentos.Close()
            Con.Close()


            CountedMessages = DgvMessages.Rows.Count

            DgvMessages.ClearSelection()
            If DgvMessages.Rows.Count > 0 Then
                DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
            End If

        End If

        FindUltMessage()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString & " from FillMesages")
        'End Try


    End Sub

    Private Sub FindUltMessage()
        Try
            Dim TmpCon As New MySqlConnection(CnGeneral)

            If TmpCon.State = ConnectionState.Open Then
                TmpCon.Close()
            End If

            TmpCon.Open()
            cmd = New MySqlCommand("SELECT FechaEnvio FROM libregco.mensajes INNER JOIN Libregco.UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Libregco.Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado WHERE IDConversacion ='" + IDConversacion + "' And UsuariosConversacion.IDEmpleado <> '" + IDUser + "' ORDER BY IDMensaje DESC LIMIT 1", TmpCon)

            If (Convert.ToString(cmd.ExecuteScalar())) = "" Then
                lblStat.Text = "Último mensaje recibido en fecha: No se ha recibido ningún mensaje."
            Else
                lblStat.Text = "Último mensaje recibido en fecha: " & CDate(CStr(Convert.ToString(cmd.ExecuteScalar()))).ToString("dd/MM/yyyy hh:mm:ss tt")
            End If

            TmpCon.Close()



        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub Updater_Tick(sender As Object, e As EventArgs) Handles Updater.Tick
        Try
            Dim TmpConnection As New MySqlConnection(CnGeneral)

            'Detect no opened Mensajes
            Dim NotReadMessage As String
            TmpConnection.Open()
            cmd = New MySqlCommand("Select COUNT(Leido) from" & SysName.Text & "Mensajes INNER JOIN" & SysName.Text & "UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN" & SysName.Text & "Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where UsuariosConversacion.IDEmpleado <> '" + IDUser + "' and Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosCOnversacion and (SELECT 1 FROM" & SysName.Text & "UsuariosConversacion WHERE Conversaciones.IDConversacion = UsuariosConversacion.IDConversacion AND UsuariosConversacion.IDEmpleado = '" + IDUser + "') and Leido=0", TmpConnection)
            NotReadMessage = Convert.ToString(cmd.ExecuteScalar())


            If NotReadMessage > 0 Then
                Updater.Enabled = False
                FillUnReadMesages()

                sqlQ = "UPDATE" & SysName.Text & "Mensajes INNER JOIN" & SysName.Text & "UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN" & SysName.Text & "Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion SET Leido=1 Where UsuariosConversacion.IDEmpleado <> '" + IDUser + "' and Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosCOnversacion and (SELECT 1 FROM" & SysName.Text & "UsuariosConversacion WHERE Conversaciones.IDConversacion = UsuariosConversacion.IDConversacion AND UsuariosConversacion.IDEmpleado = '" + IDUser + "') AND UsuariosConversacion.IDConversacion='" + IDConversacion + "' AND Leido=0"
                cmd = New MySqlCommand(sqlQ, TmpConnection)
                cmd.ExecuteNonQuery()

                NTimer.Enabled = True

                FillUsers()
                FillConversation()
            End If

            TmpConnection.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frm_grupo_conversacion.ShowDialog(Me)
    End Sub


    Private Sub DgvConversations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConversations.CellClick
        If e.RowIndex >= 0 Then
            If IsNumeric(DgvConversations.CurrentRow.Cells(0).Value) Then
                If DgvConversations.CurrentRow.Cells(6).Value = 0 Then
                    Button5.Visible = True
                Else
                    Button5.Visible = False
                End If
            Else
                Button5.Visible = False
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If frm_grupo_conversacion.Visible = True Then
            frm_grupo_conversacion.Close()
        End If

        frm_grupo_conversacion.IDNewConversation = DgvConversations.CurrentRow.Cells(0).Value

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDConversacion,Descripcion,Objetivos,ImagenConversacion,IDEmpleadoCreador,Individual FROM Conversaciones Where IDConversacion='" + frm_grupo_conversacion.IDNewConversation + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Conversation")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Conversation")

        frm_grupo_conversacion.txtNombreGrupo.Text = (Tabla.Rows(0).Item("Descripcion"))
        frm_grupo_conversacion.txtObjetivos.Text = (Tabla.Rows(0).Item("Objetivos"))
        frm_grupo_conversacion.RefrescarUsuariosInvitados()
        frm_grupo_conversacion.Show(Me)


    End Sub

    Private Sub DgvConversations_SelectionChanged(sender As Object, e As EventArgs) Handles DgvConversations.SelectionChanged
        Try
            If DgvConversations.Columns.Count > 0 And DgvConversations.Rows.Count > 0 Then
                If IsNumeric(DgvConversations.CurrentRow.Cells(0).Value) Then
                    If DgvConversations.CurrentRow.Cells(6).Value = 0 Then
                        Button5.Visible = True
                    Else
                        Button5.Visible = False
                    End If
                Else
                    Button5.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim OfdRutaFoto As New OpenFileDialog

            OfdRutaFoto.RestoreDirectory = True
            OfdRutaFoto.Title = ("Seleccionar archivo a enviar")
            OfdRutaFoto.Multiselect = False
            OfdRutaFoto.Filter = "Documentos(*.bmp;*.jpg;*.gif;*.png;*.txt;*.pdf;*.doc;*.docx;*.xlsx)|*.bmp;*.jpg;*.gif;*.png;*.txt;*.pdf;*.doc;*.docx;*.xlsx"
            OfdRutaFoto.FileName = ""

            If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each itm In OfdRutaFoto.FileNames
                    Dim ExistFile As Boolean = System.IO.File.Exists(itm)
                    If ExistFile = True Then
                        AttachfilesPath.Text = itm
                        If lblSubject.Text = "" Then
                        Else
                            If AttachfilesPath.Text = "" Then
                                If txtmessage.Text = "" Then
                                    btnSend.Enabled = False
                                Else
                                    btnSend.Enabled = True
                                End If
                            Else
                                btnSend.Enabled = True
                            End If
                        End If
                        Button3.Visible = True
                    Else
                        MessageBox.Show("No se ha encontrado una ruta válida.")
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Button 3")
        End Try
    End Sub

    Private Sub DgvMessages_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMessages.CellDoubleClick
        If e.RowIndex >= 0 Then
            If DgvMessages.CurrentRow.Cells(0).Value = 3 Then
                DgvMessages.MultiSelect = False
                System.Diagnostics.Process.Start(DgvMessages.CurrentRow.Cells(3).Value)
                DgvMessages.MultiSelect = True
            End If
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Close()
    End Sub

    Private Sub OnlineToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OnlineToolStripMenuItem2.Click
        IDEstatusConversacion = 1
        SaveChangeofStatus()
        FillUsers()
    End Sub

    Private Sub AwayToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AwayToolStripMenuItem2.Click
        IDEstatusConversacion = 2
        SaveChangeofStatus()
        FillUsers()
    End Sub

    Private Sub mnuBusy_Click(sender As Object, e As EventArgs) Handles mnuBusy.Click
        IDEstatusConversacion = 3
        SaveChangeofStatus()
        FillUsers()
    End Sub

    Private Sub mnuAppearOff_Click(sender As Object, e As EventArgs) Handles mnuAppearOff.Click
        IDEstatusConversacion = 4
        SaveChangeofStatus()
        FillUsers()
    End Sub

    Private Sub SaveChangeofStatus()
        Dim Dstmp As New DataSet

        Dstmp.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT * FROM libregco.estatusconversacion where IDEstatusConversacion='" + IDEstatusConversacion + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstmp, "estatus")
        ConLibregco.Close()

        Dim Tabla As DataTable = Dstmp.Tables("estatus")
        If Tabla.Rows.Count > 0 Then
            lblStatus.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ARGB"))
            lblStatus.Text = Tabla.Rows(0).Item("Status")
        End If

        Con.Open()
        sqlQ = "UPDATE Empleados SET IDChatStatus='" + IDEstatusConversacion + "' WHERE IDEmpleado= '" + IDUser + "'"
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()
    End Sub


    Private Sub SendFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendFileToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'sets it to show '...' for long text
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        Dim y As Int32 = e.MarginBounds.Top
        Dim rc As Rectangle
        Dim x As Int32
        Dim h As Int32 = 0
        Dim row As DataGridViewRow

        ' print the header text for a new page
        '   use a grey bg just like the control
        If newpage Then
            row = DgvMessages.Rows(mRow)
            x = e.MarginBounds.Left
            For Each cell As DataGridViewCell In row.Cells
                ' since we are printing the control's view,
                ' skip invidible columns
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    ' reused in the data pront - should be a function
                    Select Case DgvMessages.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(DgvMessages.Columns(cell.ColumnIndex).HeaderText,
                                               DgvMessages.Font, Brushes.Black, rc, fmt)
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If
            Next
            y += h

        End If
        newpage = False

        ' now print the data for each row
        Dim thisNDX As Int32
        For thisNDX = mRow To DgvMessages.RowCount - 1
            ' no need to try to print the new row
            If DgvMessages.Rows(thisNDX).IsNewRow Then Exit For

            row = DgvMessages.Rows(thisNDX)
            x = e.MarginBounds.Left
            h = 0

            ' reset X for data
            x = e.MarginBounds.Left

            ' print the data
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)

                    ' SAMPLE CODE: How To 
                    ' up a RowPrePaint rule
                    'If Convert.ToDecimal(row.Cells(5).Value) < 9.99 Then
                    '    Using br As New SolidBrush(Color.MistyRose)
                    '        e.Graphics.FillRectangle(br, rc)
                    '    End Using
                    'End If

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    Select Case DgvMessages.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(cell.FormattedValue.ToString(),
                                          DgvMessages.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' next row to print
            mRow = thisNDX + 1

            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                ' mRow -= 1   causes last row to rePrint on next page
                newpage = True
                Return
            End If
        Next

    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        mRow = 0
        newpage = True
        PrintPreviewDialog1.PrintPreviewControl.StartPage = 0
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
    End Sub

    Private Sub SaveConversationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveConversationToolStripMenuItem.Click
        'Resize DataGridView to full height.
        Dim height As Integer = DgvMessages.Height
        DgvMessages.Height = DgvMessages.RowCount * DgvMessages.RowTemplate.Height

        'Create a Bitmap and draw the DataGridView on it.
        Dim bitmap As Bitmap = New Bitmap(Me.DgvMessages.Width, Me.DgvMessages.Height)
        DgvMessages.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DgvMessages.Width, Me.DgvMessages.Height))

        'Resize DataGridView back to original height.
        DgvMessages.Height = height

        'Save the Bitmap to folder.
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .RestoreDirectory = True
            .Title = ("Guardar como archivo de imagen")
            .Filter = "Images (*.png)|*.png"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            bitmap.Save(GetFileName.FileName)
            MessageBox.Show("La imagen se ha guardado satisfactoriamente.", "Imagen guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If


    End Sub

    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        DgvMessages.SelectAll()
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        Dim s As String = ""
        Dim oCurrentCol As DataGridViewColumn    'Get header
        oCurrentCol = DgvMessages.Columns.GetFirstColumn(DataGridViewElementStates.Visible)
        Do
            s &= oCurrentCol.HeaderText & Chr(Keys.Tab)
            oCurrentCol = DgvMessages.Columns.GetNextColumn(oCurrentCol, _
               DataGridViewElementStates.Visible, DataGridViewElementStates.None)
        Loop Until oCurrentCol Is Nothing
        s = s.Substring(0, s.Length - 1)
        s &= Environment.NewLine    'Get rows
        For Each row As DataGridViewRow In DgvMessages.Rows
            oCurrentCol = DgvMessages.Columns.GetFirstColumn(DataGridViewElementStates.Visible)
            Do
                If row.Cells(oCurrentCol.Index).Value IsNot Nothing Then
                    s &= row.Cells(oCurrentCol.Index).Value.ToString
                End If
                s &= Chr(Keys.Tab)
                oCurrentCol = DgvMessages.Columns.GetNextColumn(oCurrentCol, _
                      DataGridViewElementStates.Visible, DataGridViewElementStates.None)
            Loop Until oCurrentCol Is Nothing
            s = s.Substring(0, s.Length - 1)
            s &= Environment.NewLine
        Next    'Put to clipboard
        Dim o As New DataObject
        o.SetText(s)
        Clipboard.SetDataObject(o, True)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub MessageFormat()
        Updater.Enabled = False
        NTimer.Enabled = True
    End Sub

    Private Sub MarkAllRead()
        Try

            If IDConversacionUser <> "" Then

                For Each Row As DataGridViewRow In DgvMessages.Rows

                    If Row.Cells(6).Value = False Then
                        If Row.Cells(0).Value = 2 Or Row.Cells(0).Value = 3 Then
                            If Row.Cells(2).Value <> IDConversacionUser Then
                                Row.Cells(3).Style.BackColor = Color.White
                                Row.Cells(4).Style.BackColor = Color.White
                                Row.Cells(5).Style.BackColor = Color.White
                                Row.Cells(5).Value = Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss")
                                Row.Cells(6).Value = True
                            End If
                        End If
                    End If
                Next

                FillConversation()
                frm_inicio.CargarChat()

                Updater.Enabled = True
                NTimer.Enabled = False
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub NTimer_Tick(sender As Object, e As EventArgs) Handles NTimer.Tick

        MarkAllRead()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AttachfilesPath.Text = ""
        If AttachfilesPath.Text = "" Then
            If txtmessage.Text = "" Then
                btnSend.Enabled = False
            Else
                btnSend.Enabled = True
            End If
        Else
            btnSend.Enabled = True
        End If

        Button3.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtBuscarUsuarios.Text = ""
        txtBuscarUsuarios.Focus()
    End Sub

    Private Sub txtBuscarUsuarios_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarUsuarios.TextChanged
        FillUsers()

        If txtBuscarUsuarios.Text <> "" Then
            Button6.Visible = True
        Else
            Button6.Visible = False
        End If
    End Sub

    Private Sub lblEncabezado_MouseMove(sender As Object, e As MouseEventArgs)
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ex, MousePosition.Y - Me.Location.Y - ey))
        End If

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe
        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))
    End Sub

    Private Sub lblEncabezado_MouseDown(sender As Object, e As MouseEventArgs)
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            ex = e.X
            ey = e.Y
            Arrastre = True
        End If
    End Sub

    Private Sub lblEncabezado_MouseUp(sender As Object, e As MouseEventArgs)
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            Arrastre = False
        End If
    End Sub

    Private Sub DgvMessages_MouseEnter(sender As Object, e As EventArgs) Handles DgvMessages.MouseEnter
        'If DgvMessages.ScrollBars = ScrollBars.None Then
        '    DgvMessages.ScrollBars = ScrollBars.Vertical
        '    'If DgvMessages.Rows.Count > 0 Then
        '    '    DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
        '    'End If
        'End If
    End Sub

    Private Sub DgvMessages_MouseLeave(sender As Object, e As EventArgs) Handles DgvMessages.MouseLeave
        '    If DgvMessages.ScrollBars = ScrollBars.Vertical Then
        '        DgvMessages.ScrollBars = ScrollBars.None

        '        'If CountedMessages <> DgvMessages.Rows.Count Then
        '        '    If DgvMessages.Rows.Count > 0 Then
        '        '        DgvMessages.FirstDisplayedScrollingRowIndex = DgvMessages.RowCount - 1
        '        '    End If
        '        'End If
        '    End If
    End Sub

    Sub DgvConversations_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvConversations.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            FillPreInfo()
        End If
    End Sub

    Private Sub DgvConversations_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvConversations.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvConversations.ColumnCount
                Dim NumRows As Integer = DgvConversations.RowCount
                Dim CurCell As DataGridViewCell = DgvConversations.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvConversations.CurrentCell = DgvConversations.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvConversations.CurrentCell = DgvConversations.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub DgvMessages_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvMessages.RowsAdded
        If DgvMessages.Rows(e.RowIndex).Cells(0).Value = 1 Then
            DgvMessages.Rows(e.RowIndex).Cells(3).Style.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            DgvMessages.Rows(e.RowIndex).Cells(4).Style.Font = New Font("Segoe UI", 8, FontStyle.Regular)


        ElseIf DgvMessages.Rows(e.RowIndex).Cells(0).Value = 2 Then
            If DgvMessages.Rows(e.RowIndex).Cells(2).Value.ToString <> IDConversacionUser Then
                If DgvMessages.Rows(e.RowIndex).Cells(6).Value.ToString = False Then
                    DgvMessages.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    DgvMessages.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    DgvMessages.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.LightGray
                    DgvMessages.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.LightGray
                    DgvMessages.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.LightGray
                Else
                    DgvMessages.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.White
                    DgvMessages.Rows(e.RowIndex).Cells(4).Style.BackColor = Color.White
                    DgvMessages.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.White
                    DgvMessages.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                    DgvMessages.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
            End If
            ElseIf DgvMessages.Rows(e.RowIndex).Cells(0).Value = 3 Then
                DgvMessages.Rows(e.RowIndex).Cells(3).Style.ForeColor = SystemColors.Highlight
                DgvMessages.Rows(e.RowIndex).Cells(3).Style.Font = New Font("Segoe UI", 9, FontStyle.Underline)
            End If

            If DgvMessages.Rows(e.RowIndex).Cells(2).Value.ToString <> "" Then
                If DgvMessages.Rows(e.RowIndex).Cells(2).Value.ToString <> IDConversacionUser Then
                    DgvMessages.Rows(e.RowIndex).Cells(3).Style.ForeColor = Color.FromArgb(255, 64, 64, 64)
                    DgvMessages.Rows(e.RowIndex).Cells(4).Style.ForeColor = Color.FromArgb(255, 64, 64, 64)
                    DgvMessages.Rows(e.RowIndex).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    DgvMessages.Rows(e.RowIndex).Cells(4).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            End If

    End Sub


End Class
