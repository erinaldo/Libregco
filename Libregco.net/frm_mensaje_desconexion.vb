Public Class frm_mensaje_desconexion
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then
            System.IO.Directory.Delete(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs"), True)
        End If

        Application.Exit()
    End Sub

    Private Sub frm_mensaje_desconexion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DTAreaImpresion.Rows.Count = 0 Then
            Application.Exit()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub lblIcoConnection_Click(sender As Object, e As EventArgs) Handles lblIcoConnection.Click
        Dim MousePosition As Point = Cursor.Position

        frm_connection_hosts.Show(Me)
        frm_connection_hosts.Location = New Point(MousePosition.X, MousePosition.Y - 150)
    End Sub

    Private Sub lblConnection_Click(sender As Object, e As EventArgs) Handles lblConnection.Click
        Dim MousePosition As Point = Cursor.Position

        frm_connection_hosts.Show(Me)
        frm_connection_hosts.Location = New Point(MousePosition.X, MousePosition.Y - 150)
    End Sub

    Private Sub frm_mensaje_desconexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class