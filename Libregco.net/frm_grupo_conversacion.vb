Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Public Class frm_grupo_conversacion
    Friend NewConversation As Boolean = False
    Friend Con As New MySqlConnection(CnString)
    Friend sqlQ As String
    Friend cmd As MySqlCommand
    Friend Ds As New DataSet
    Friend Adaptador As MySqlDataAdapter
    Friend lblPathFile, IDNewConversation As String

    Private Sub frm_grupo_conversacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        FillUsers()
    End Sub

    Private Sub btnGuardarConversacion_Click(sender As Object, e As EventArgs) Handles btnGuardarConversacion.Click
        'Try
        Dim IDInvitado, IDConversationInvitado As String
        If txtNombreGrupo.Text = "" Then
            MessageBox.Show("Escriba el nombre del grupo para guardarlo.", "Definir nombre del grupo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNombreGrupo.Focus()
            Exit Sub

        ElseIf DgvInvitados.Rows.Count < 2 Then
            MessageBox.Show("La conversación grupal no cuenta la cantidad mínima de invitados para procesar.", "Hay " & DgvInvitados.Rows.Count & " invitados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        'Check is ImagePathFile Exist
        If lblPathFile = "" Then
            lblPathFile = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\Group_Image.png"
        Else
            Dim ExistFile As Boolean = System.IO.File.Exists(lblPathFile)
            If ExistFile = True Then
            Else
                lblPathFile = "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\Elementos\Group_Image.png"
            End If
        End If
        '---------------------------------------------------------------

        If IDNewConversation = "" Then
            sqlQ = "INSERT INTO Conversaciones (Descripcion,Objetivos,Fecha,ImagenConversacion,Individual,IDEmpleadoCreador) VALUES ('" + txtNombreGrupo.Text + "','" + txtObjetivos.Text + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + Replace(lblPathFile, "\", "\\") + "',0,'" + frm_messenger.IDUser + "')"
            SavingQuery()

            'Getting the last ID Record on conversation
            Con.Open()
            cmd = New MySqlCommand("Select IDConversacion from Conversaciones where IDConversacion= (Select Max(IDConversacion) from Conversaciones)", Con)
            IDNewConversation = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            'Setting users into conversation
            For Each row As DataGridViewRow In DgvInvitados.Rows
                IDInvitado = row.Cells(0).Value
                IDConversationInvitado = row.Cells(4).Value

                If IDConversationInvitado = "" Then
                    sqlQ = "INSERT INTO UsuariosConversacion (IDConversacion,IDEmpleado,IDRol,IDEstadoChat,Fecha,Nulo) VALUES ('" + IDNewConversation + "','" + IDInvitado + "',2,1,'" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',0)"
                    SavingQuery()

                End If
            Next

            ToolStripStatusLabel1.Text = "El grupo de conversación ha sido guardado exitosamente."
        Else
            sqlQ = "UPDATE Conversacion SET Descripcion='" + txtNombreGrupo.Text + "', Objetivos='" + txtObjetivos.Text + "',ImagenConversacion='" + Replace(lblPathFile, "\", "\\") + "' WHERE IDConversacion='" + IDNewConversation + "'"
            SavingQuery()

            'Setting users into conversation
            For Each row As DataGridViewRow In DgvInvitados.Rows
                IDInvitado = row.Cells(0).Value
                IDConversationInvitado = row.Cells(4).Value

                If IDConversationInvitado = "" Then
                    sqlQ = "INSERT INTO UsuariosConversacion (IDConversacion,IDEmpleado,IDRol,IDEstadoChat,Fecha,Nulo) VALUES ('" + IDNewConversation + "','" + IDInvitado + "',2,1,'" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',0)"
                    SavingQuery()

                End If
            Next
            ToolStripStatusLabel1.Text = "Se han modificado los datos del grupo exitosamente."
        End If


        RefrescarUsuariosInvitados()


        frm_messenger.FillConversation()

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub RefrescarUsuariosInvitados()
        Try
            DgvInvitados.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT UsuariosConversacion.IDEmpleado,Empleados.ImagenChat,Empleados.Nombre,IDUsuariosConversacion,UsuariosConversacion.Nulo FROM UsuariosConversacion INNER JOIN Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado where UsuariosConversacion.IDConversacion='" + IDNewConversation + "' and UsuariosConversacion.Nulo=0", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorDocumentos.GetValue(1))
                If ExistFile = True Then
                    DgvInvitados.Rows.Add(LectorDocumentos.GetValue(0), Image.FromFile(LectorDocumentos.GetValue(1)), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(3))
                Else
                    DgvInvitados.Rows.Add(LectorDocumentos.GetValue(0), My.Resources.no_photo, LectorDocumentos.GetValue(2), "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\no_photo.jpg", LectorDocumentos.GetValue(3))

                End If
            End While
            LectorDocumentos.Close()
            Con.Close()

            'Look at me to mark and change color status in users
            If IsNumeric(frm_messenger.IDUser) Then
                For Each row As DataGridViewRow In DgvInvitados.Rows
                    If row.Cells(0).Value = frm_messenger.IDUser Then
                        row.Cells(2).Value = "(Me) " & row.Cells(2).Value
                        row.Cells(2).Style.ForeColor = Color.Orange
                    End If
                Next
            End If

            DgvUsers.ClearSelection()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillUsers()
        Try
            DgvUsers.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDEmpleado,ImagenChat,Nombre,Empleados.IDChatStatus,EstatusConversacion.Status,ARGB FROM Empleados INNER JOIN EstatusConversacion on Empleados.IDChatStatus=EstatusConversacion.IDEstatusConversacion", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorDocumentos.GetValue(1))
                If ExistFile = True Then
                    DgvUsers.Rows.Add(LectorDocumentos.GetValue(0), Image.FromFile(LectorDocumentos.GetValue(1)), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(1))
                Else
                    DgvUsers.Rows.Add(LectorDocumentos.GetValue(0), My.Resources.no_photo, LectorDocumentos.GetValue(2), "\\" & PathServidor.Text & "\Libregco\Libregco.net\Resources\no_photo.jpg")

                End If
            End While
            LectorDocumentos.Close()
            Con.Close()

            'Look at me to mark and change color status in users
            If IsNumeric(frm_messenger.IDUser) Then
                For Each row As DataGridViewRow In DgvUsers.Rows
                    If row.Cells(0).Value = frm_messenger.IDUser Then
                        row.Cells(2).Value = "(Me) " & row.Cells(2).Value
                    End If
                Next
            End If

            DgvUsers.ClearSelection()


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PicClient_Click(sender As Object, e As EventArgs) Handles PicClient.Click
        Try
            Dim OfdRutaFoto As New OpenFileDialog

            OfdRutaFoto.RestoreDirectory = True
            OfdRutaFoto.Title = ("Seleccionar Imagen")
            OfdRutaFoto.Multiselect = False
            OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
            OfdRutaFoto.FileName = ""

            If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then

                For Each itm In OfdRutaFoto.FileNames
                    Dim ExistFile As Boolean = System.IO.File.Exists(itm)
                    If ExistFile = True Then
                        PicClient.Image = Image.FromFile(itm)
                        lblPathFile = itm
                    Else
                        MessageBox.Show("No valid path found.")
                    End If

                Next

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvUsers.CellClick
        Try
            If e.RowIndex >= 0 Then

                For Each row As DataGridViewRow In DgvInvitados.Rows
                    If DgvUsers.CurrentRow.Cells(0).Value = row.Cells(0).Value Then
                        lblUserStatus.Text = ("El usuario ya está agregado a la conversación.")
                        lblUserStatus.ForeColor = Color.Blue
                        Exit Sub
                    End If
                Next
                DgvInvitados.Rows.Add(DgvUsers.CurrentRow.Cells(0).Value, DgvUsers.CurrentRow.Cells(1).Value, DgvUsers.CurrentRow.Cells(2).Value, DgvUsers.CurrentRow.Cells(3).Value, "", 0)
                lblUserStatus.Text = ""
                DgvUsers.ClearSelection()
                DgvInvitados.ClearSelection()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If DgvInvitados.Rows.Count = 0 Then
            Else
                Dim IDInvitadoAgregado As String
                IDInvitadoAgregado = DgvInvitados.CurrentRow.Cells(4).Value

                If IDInvitadoAgregado = "" Then
                    DgvInvitados.Rows.Remove(DgvInvitados.CurrentRow)
                Else
                    sqlQ = "UPDATE UsuariosConversacion SET Nulo=1 WHERE IDUsuariosConversacion='" + IDInvitadoAgregado + "'"
                    SavingQuery()
                End If

                RefrescarUsuariosInvitados()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SavingQuery()
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

  
    Private Sub SendFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendFileToolStripMenuItem.Click
        IDNewConversation = ""
        FillUsers()
        DgvInvitados.Rows.Clear()
        txtNombreGrupo.Clear()
        txtObjetivos.Clear()
        lblUserStatus.Text = ""
    End Sub

    Private Sub SaveConversationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveConversationToolStripMenuItem.Click
        btnGuardarConversacion.PerformClick()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Close()
    End Sub

    Private Sub frm_grupo_conversacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DgvInvitados.Rows.Clear()
        txtNombreGrupo.Clear()
        txtObjetivos.Clear()
    End Sub
End Class