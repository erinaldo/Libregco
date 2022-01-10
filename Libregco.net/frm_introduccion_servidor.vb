Public Class frm_introduccion_servidor

    Private Sub frm_introduccion_servidor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.Activate()
    End Sub


    Private Sub frm_introduccion_servidor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.F4 Then
            e.Handled = True
            txtNombreServidor.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNombreServidor.Text = "" Then
            MessageBox.Show("Escriba el nombre del servidor para continuar.")
            txtNombreServidor.Focus()
            Exit Sub
        End If
        If txtDDNS.Text = "" Then
            txtDDNS.Text = txtNombreServidor.Text
        End If
        If txtUsuario.Text = "" Then
            txtUsuario.Text = "root"
        End If

        If txtPuerto.Text = "" Then
            txtPuerto.Text = 3306
        End If

        Dim thePath As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs")

        'Creo la carpeta
        IO.Directory.CreateDirectory(thePath)

        'Creo el path del servidor
        'My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), "#HostName=" & Watermark1.Text & vbNewLine & "#DDNS=" & txtDDNS.Text & vbNewLine & "#User=root" & vbNewLine & "#root=" & txtPuerto.Text, True)
        My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), "#Current=1" & vbNewLine & "----------------------------------------------" & vbNewLine & "HostName=" & txtNombreServidor.Text & ";DDNS=" & txtDDNS.Text & ";User=" & txtUsuario.Text & ";Port=" & txtPuerto.Text, True)

        Close()
    End Sub

    Private Sub txtNombreServidor_Enter(sender As Object, e As EventArgs) Handles txtNombreServidor.Enter
        txtNombreServidor.SelectAll()
    End Sub

    Private Sub txtDDNS_Enter(sender As Object, e As EventArgs) Handles txtDDNS.Enter
        txtDDNS.SelectAll()
    End Sub

    Private Sub txtUsuario_Enter(sender As Object, e As EventArgs) Handles txtUsuario.Enter
        txtUsuario.SelectAll()
    End Sub

    Private Sub txtPuerto_Enter(sender As Object, e As EventArgs) Handles txtPuerto.Enter
        txtPuerto.SelectAll()
    End Sub

    Private Sub txtNombreServidor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombreServidor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDDNS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDDNS.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPuerto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPuerto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class