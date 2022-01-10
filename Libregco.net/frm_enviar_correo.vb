Imports System.Net
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.Drawing.Font

Public Class frm_enviar_correo
    Private Correos As New MailMessage
    Private Envios As New SmtpClient

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNombre, EmailCompleto, Foto As New Label
    Dim RutaAdjunto As New ArrayList

    Private Sub frm_enviar_correo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        LimpiarTodo()
        ActualizarTodo()
        SelectUsuario()
        ChangeBtnEnviarColor()
    End Sub

    Private Sub LimpiarTodo()
        txtDestino.Clear()
        txtAsunto.Clear()
        'RutaAdjunto.Text = ""
        RtMensaje.Clear()
        lblNombre.Text = ""
        txtEmail.Clear()
        txtPassword.Clear()
        LbAdjuntos.Items.Clear()
    End Sub

    Private Sub ActualizarTodo()
        StatusLabel.Text = "Listo"
        StatusLabel.ForeColor = Color.Black
    End Sub

    Private Sub SelectUsuario()
        Try
            Dim Correo As String
            Dim Array() As String

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select IDEmpleado,Nombre,Login,RutaFoto,CorreoElectronico from Empleados Where IDEmpleado=  '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            Con.Close()

            Dim Tabla As DataTable= Ds.Tables("Empleados")

            lblNombre.Text = LCase(Tabla.Rows(0).Item("Nombre"))
            lblNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lblNombre.Text)

            Correo = (Tabla.Rows(0).Item("CorreoElectronico"))
            Array = Split(Correo, "@")

            txtEmail.Text = Array(0)
            cboExtension.Text = "@" & Array(1)

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub VerPasswordbtn_MouseClick(sender As Object, e As MouseEventArgs) Handles VerPasswordbtn.MouseClick
        txtPassword.PasswordChar = "*"
        txtPassword.Focus()
    End Sub

    Private Sub VerPasswordbtn_MouseDown(sender As Object, e As MouseEventArgs) Handles VerPasswordbtn.MouseDown
        txtPassword.PasswordChar = ""
    End Sub


    Private Sub VerPasswordbtn_MouseEnter(sender As Object, e As EventArgs) Handles VerPasswordbtn.MouseEnter
        VerPasswordbtn.Text = "Ver"
    End Sub

    Private Sub VerPasswordbtn_MouseLeave(sender As Object, e As EventArgs) Handles VerPasswordbtn.MouseLeave
        VerPasswordbtn.Text = ""
    End Sub

    Private Function FileExists(ByVal FileFullPath As String) _
     As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function


    Sub EnviarCorreo(ByVal Emisor As String, ByVal Password As String, ByVal Mensaje As String, ByVal Asunto As String, ByVal Destinatario As String, Optional ByVal AttachmentFiles As ArrayList = Nothing)
        Dim i, iCnt As Integer
        Try
            Correos.To.Clear()
            Correos.Body = ""
            Correos.Subject = ""
            Correos.Body = Mensaje
            Correos.Subject = Asunto
            Correos.From = New System.Net.Mail.MailAddress(EmailCompleto.Text, lblNombre.Text, System.Text.Encoding.UTF8)
            Correos.Priority = System.Net.Mail.MailPriority.Normal
            Correos.IsBodyHtml = True
            Correos.To.Add(Trim(Destinatario))

            If Not AttachmentFiles Is Nothing Then
                iCnt = AttachmentFiles.Count - 1
                For i = 0 To iCnt
                    If FileExists(AttachmentFiles(i)) Then
                        Correos.Attachments.Add(AttachmentFiles(i))
                    End If
                Next
            End If

            'If Ruta <> "" Then
            '    Dim Archivo As Net.Mail.Attachment = New Net.Mail.Attachment(Ruta)
            '    Correos.Attachments.Add(Archivo)
            'End If

            Correos.From = New MailAddress(Emisor)
            Envios.Credentials = New NetworkCredential(Emisor, Password)

            If cboExtension.Text = "@gmail.com" Then
                Envios.Host = "smtp.gmail.com"
                Envios.Port = 587
                Envios.EnableSsl = True

            ElseIf cboExtension.Text = "@hotmail.com" Or cboExtension.Text = "@hotmail.es" Then
                Envios.Host = "smtp.live.com"
                Envios.Port = 25
                Envios.EnableSsl = True

            ElseIf cboExtension.Text = "@yahoo.com" Then
                Envios.Host = "smtp.mail.yahoo.com"
                Envios.Port = 465
                Envios.EnableSsl = True
            Else
                'Si la extensión del correo no está especificado usare la de Gmail de Google.
                Envios.Host = "smtp.gmail.com"
                Envios.Port = 587
                Envios.EnableSsl = True
            End If

            Envios.Send(Correos)
            MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            StatusLabel.Text = "Es necesario tener habilitada la opción POP y IMAP para permitir el envío de correos de su cuenta por esta vía. "
            StatusLabel.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        Try
            Dim OfDialog As New OpenFileDialog


            OfDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            OfDialog.Title = ("Seleccionar Adjunto")
            OfDialog.Multiselect = True

            If OfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each itm In OfDialog.FileNames
                    If (IO.Path.GetExtension(itm) = ".exe") Then
                        MessageBox.Show(" El archivo a adjuntar no puede ser un ejecutable.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    LbAdjuntos.Items.Add(itm)
                Next
                'BucAdjunto()
            End If

        Catch ex As Exception

        End Try
    End Sub

    '    Private Sub BucAdjunto()

    '        Dim Counter As Integer = LbAdjuntos.Items.Count
    '        Dim x As Integer = 0
    '        Dim LbAdValue, PutSign As String

    '        RutaAdjunto.Text = ""
    'Inicio:

    '        If x = Counter Then
    '            GoTo Fin
    '        End If

    '        LbAdValue = LbAdjuntos.Items(x)
    '        If x = 0 Or x = Counter Then
    '            PutSign = ""
    '            RutaAdjunto.Text = RutaAdjunto.Text & PutSign & LbAdValue

    '        ElseIf x < Counter Then
    '            PutSign = ", "
    '            RutaAdjunto.Text = RutaAdjunto.Text & PutSign & LbAdValue
    '        End If

    '        x = x + 1
    '        GoTo Inicio
    'Fin:

    '        MessageBox.Show(RutaAdjunto.Text)
    '    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        If txtEmail.Text.Trim.Length > 5 Then
            cboExtension.Enabled = True
        Else
            cboExtension.Enabled = False
            cboExtension.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboExtension_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExtension.SelectedIndexChanged
        If cboExtension.SelectedIndex = 0 Then
            txtPassword.Clear()
            txtPassword.Enabled = False
            VerPasswordbtn.Enabled = False
        Else
            txtPassword.Clear()
            txtPassword.Enabled = True
            VerPasswordbtn.Enabled = True
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text.Trim.Length > 4 Then
            btnIngresar.Enabled = True
        Else
            btnIngresar.Enabled = False
        End If
    End Sub


    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        GbValidacion.Enabled = False
        GbMensaje.Enabled = True
        ChangeBtnEnviarColor()
        btnCerrarSesion.Enabled = True
        EmailCompleto.Text = txtEmail.Text & cboExtension.Text
        txtDestino.Focus()
    End Sub

    Private Sub ChangeBtnEnviarColor()
        If GbMensaje.Enabled = False Then
            btnSendEmail.BackColor = Color.LightGray
        Else
            btnSendEmail.BackColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        LimpiarTodo()
        ActualizarTodo()
        GbValidacion.Enabled = True
        GbMensaje.Enabled = False
        btnCerrarSesion.Enabled = False
        ChangeBtnEnviarColor()
        txtEmail.Focus()
    End Sub

    Private Sub txtDestino_Enter(sender As Object, e As EventArgs) Handles txtDestino.Enter
        StatusLabel.Text = "Para envíar correos a múltiples personas divida los emails por comas y sin espacios. "
    End Sub

    Private Sub txtDestino_Leave(sender As Object, e As EventArgs) Handles txtDestino.Leave
        If txtDestino.Text <> "" Then
            If Validar_Mail(LCase(txtDestino.Text)) = False Then
                MessageBox.Show("La dirección de correo electronico  es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDestino.Focus()
                txtDestino.SelectAll()
            Else
                StatusLabel.Text = "Listo"
            End If
        End If
    End Sub

    Private Sub LbAdjuntos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LbAdjuntos.MouseDoubleClick
        If LbAdjuntos.Items.Count > 0 Then

            Dim RutaDestino As String = (LbAdjuntos.SelectedItem.ToString)
            Dim Exists As Boolean

            Cursor.Current = Cursors.WaitCursor

            Exists = System.IO.File.Exists(RutaDestino)

            If Exists = False Then
                MessageBox.Show("El archivo específicado en la ruta " & RutaDestino & " se ha modificado o eliminado.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                System.Diagnostics.Process.Start(RutaDestino)
            End If

            Cursor.Current = Cursors.Default

        End If

    End Sub

    Private Sub LimpiarMensaje()
        txtDestino.Clear()
        txtAsunto.Clear()
        LbAdjuntos.Items.Clear()
        RtMensaje.Clear()
    End Sub


    Private Sub btnEliminarEnlace_Click(sender As Object, e As EventArgs) Handles btnEliminarEnlace.Click
        LbAdjuntos.Items.Remove(LbAdjuntos.SelectedItem)
        'BucAdjunto()
    End Sub

    Private Sub TsbLimpiar_Click(sender As Object, e As EventArgs) Handles TsbLimpiar.Click
        If txtAsunto.Text <> "" Or txtDestino.Text <> "" Or RtMensaje.Text <> "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea borrar el mensaje?", "Borrar Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                LimpiarMensaje()
                ActualizarTodo()
                txtDestino.Focus()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        RtMensaje.Undo()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        RtMensaje.Redo()
    End Sub

    Private Sub TsBBold_Click(sender As Object, e As EventArgs) Handles TsBBold.Click
        Try

            Dim Style As FontStyle

            If RtMensaje.SelectionFont.Bold Then
                Style = RtMensaje.SelectionFont.Style And Not FontStyle.Bold
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

            Else
                Style = RtMensaje.SelectionFont.Style Or FontStyle.Bold
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

                RtMensaje.Focus()
            End If

            If TsBBold.BackColor = Color.SteelBlue Then
                TsBBold.BackColor = System.Drawing.SystemColors.Control
            Else
                TsBBold.BackColor = Color.SteelBlue
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsBItalic_Click(sender As Object, e As EventArgs) Handles TsBItalic.Click
        Try

            Dim Style As FontStyle

            If RtMensaje.SelectionFont.Italic Then
                Style = RtMensaje.SelectionFont.Style And Not FontStyle.Italic
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

            Else
                Style = RtMensaje.SelectionFont.Style Or FontStyle.Italic
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

                RtMensaje.Focus()
            End If

            If TsBItalic.BackColor = Color.SteelBlue Then
                TsBItalic.BackColor = System.Drawing.SystemColors.Control
            Else
                TsBItalic.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsBUnderLine_Click(sender As Object, e As EventArgs) Handles TsBUnderLine.Click
        Try

            Dim Style As FontStyle

            If RtMensaje.SelectionFont.Underline Then
                Style = RtMensaje.SelectionFont.Style And Not FontStyle.Underline
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

            Else
                Style = RtMensaje.SelectionFont.Style Or FontStyle.Underline
                RtMensaje.SelectionFont = New Font(RtMensaje.SelectionFont, Style)

                RtMensaje.Focus()
            End If

            If TsBUnderLine.BackColor = Color.SteelBlue Then
                TsBUnderLine.BackColor = System.Drawing.SystemColors.Control
            Else
                TsBUnderLine.BackColor = Color.SteelBlue
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsBForeColor_Click(sender As Object, e As EventArgs) Handles TsBForeColor.Click
        Dim Cdialog As ColorDialog = New ColorDialog
        Cdialog.AnyColor = True

        If (Cdialog.ShowDialog = DialogResult.OK) Then
            TsLTextoColor.ForeColor = Cdialog.Color
            RtMensaje.SelectionColor = TsLTextoColor.ForeColor
        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim Fdialog As FontDialog = New FontDialog

        If (Fdialog.ShowDialog = DialogResult.OK) Then
            RtMensaje.SelectionFont = Fdialog.Font
        End If

    End Sub

    Private Sub TsbAlinearIzquierda_Click(sender As Object, e As EventArgs) Handles TsbAlinearIzquierda.Click
        RtMensaje.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub TsbAlinearCentrar_Click(sender As Object, e As EventArgs) Handles TsbAlinearCentrar.Click
        RtMensaje.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub TsbAlinearDerecha_Click(sender As Object, e As EventArgs) Handles TsbAlinearDerecha.Click
        RtMensaje.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub btnSendEmail_Click(sender As Object, e As EventArgs) Handles btnSendEmail.Click
        If txtEmail.Text = "" Then
            MessageBox.Show("El correo electrónico está vacío.", "Escriba su dirección de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtEmail.Focus()
            Exit Sub
        End If

        If cboExtension.SelectedIndex = 0 Then
            MessageBox.Show("La extensión del correo " & " no ha sido elegida.", "Seleccione la extensión del email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cboExtension.Focus()
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            MessageBox.Show("La contraseña está en blanco.", "Escriba su contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cboExtension.Focus()
            Exit Sub
        End If

        If txtDestino.Text = "" Then
            MessageBox.Show("El destino del email está en blanco.", "Escriba el destino de su mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtDestino.Focus()
            Exit Sub
        End If

        If txtAsunto.Text = "" Then
            MessageBox.Show("El asunto de su mensaje está en blanco.", "Escriba el objetivo de su mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtAsunto.Focus()
            Exit Sub
        End If

        If RtMensaje.Text = "" Then
            MessageBox.Show("El mensaje del correo está en blanco.", "Escriba un mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            RtMensaje.Focus()
            Exit Sub
        End If

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea envíar el correo?", "Envíar Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            EnviarCorreo(EmailCompleto.Text, txtPassword.Text, RtMensaje.Text, txtAsunto.Text, txtDestino.Text, RutaAdjunto)
        End If

    End Sub


End Class