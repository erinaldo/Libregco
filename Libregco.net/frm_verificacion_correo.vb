Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Net.Mail

Public Class frm_verificacion_correo
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim NumberConfirmation As String
    Private Correos As New MailMessage
    Private Envios As New SmtpClient

    Private Sub frm_verificacion_correo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Panel2.Location = New Point(0, 419)
        txtCorreo.Text = ""
        txtCorreo.ReadOnly = True
        txtCodigo.Text = ""
        Panel1.Visible = False
        Panel2.Enabled = False
        btnVolverAEnviar.Visible = False

        CargarLibregco()
        SetConfiguracion()

        If Me.Owner.Name = frm_LoginSistema.Name Then
            lblNombre.Text = DTEmpleado.Rows(0).Item("Nombre")
            txtCorreo.Text = DTEmpleado.Rows(0).Item("CorreoElectronico")

            If TypeConnection.Text = 1 Then
                Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("RutaFoto"))
                Dim ExistFile1 As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("ImagenChat"))

                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(DTEmpleado.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                    MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                    wFile.Close()

                ElseIf ExistFile1 = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(DTEmpleado.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                    MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                    wFile.Close()

                Else
                    PicEmpleado.Image = My.Resources.no_photo
                End If
            Else
                PicEmpleado.Image = My.Resources.no_photo
            End If
        ElseIf Me.Owner.Name = frm_recuperar_cuenta.name Then
            '0 Users ID
            '1 Users Name
            '2 Email
            '3 Login Name
            '4 Password
            '5 Verifiec
            '6 PicFilePath1
            '7 PicFilePath2
            lblNombre.Text = frm_recuperar_cuenta.UserInfo(1).ToString
            txtCorreo.Text = frm_recuperar_cuenta.UserInfo(2).ToString

            If TypeConnection.Text = 1 Then
                Dim ExistFile As Boolean = System.IO.File.Exists(frm_recuperar_cuenta.UserInfo(6).ToString)
                Dim ExistFile1 As Boolean = System.IO.File.Exists(frm_recuperar_cuenta.UserInfo(7).ToString)

                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(frm_recuperar_cuenta.UserInfo(6).ToString, FileMode.Open, FileAccess.Read)
                    MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                    wFile.Close()

                ElseIf ExistFile1 = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(frm_recuperar_cuenta.UserInfo(7).ToString, FileMode.Open, FileAccess.Read)
                    MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                    wFile.Close()

                Else
                    PicEmpleado.Image = My.Resources.no_photo
                End If
            Else
                PicEmpleado.Image = My.Resources.no_photo
            End If
        End If


        If txtCorreo.Text = "" Then
            btnModificarCorreo.Visible = True
            btnRevisar.Visible = False
            Panel2.Enabled = False
        Else
            If Validar_Mail(LCase(txtCorreo.Text)) = True Then
                btnModificarCorreo.Visible = True
                btnModificarCorreo.Enabled = True
                btnModificarCorreo.BackColor = SystemColors.Highlight
                btnRevisar.Visible = True
                btnRevisar.Enabled = True
                Panel2.Enabled = True
                btnEnviarCodigo.Enabled = True
                btnEnviarCodigo.BackColor = SystemColors.Highlight
                btnRevisar.Visible = False
            Else
                Panel2.Enabled = False
                btnModificarCorreo.Visible = True
                btnModificarCorreo.BackColor = SystemColors.Highlight
                btnRevisar.Visible = False
                btnRevisar.BackColor = SystemColors.Highlight
            End If
        End If

    End Sub

    Private Sub SetConfiguracion()
        Try

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub btnModificarCorreo_Click(sender As Object, e As EventArgs) Handles btnModificarCorreo.Click
        txtCorreo.Enabled = True
        txtCorreo.ReadOnly = False
        Panel2.Enabled = False
        btnEnviarCodigo.BackColor = Color.Gray
        btnEnviarCodigo.Enabled = False
        btnRevisar.Visible = True
        btnModificarCorreo.Visible = False
        txtCorreo.Focus()
    End Sub

    Private Sub txtCorreo_Leave(sender As Object, e As EventArgs) Handles txtCorreo.Leave
        If Validar_Mail(LCase(txtCorreo.Text)) = False Then
            MessageBox.Show("La dirección de correo electrónico no es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCorreo.SelectAll()
            Panel2.Enabled = False
        Else
            Panel2.Enabled = True
        End If
    End Sub

    Private Sub btnVolverAEnviar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnVolverAEnviar.LinkClicked
        If My.Computer.Network.IsAvailable = True Then
            Label7.Text = ""
            NumberConfirmation = GetRandomnumber(3)

            sqlQ = "UPDATE Empleados SET ClaveVerificacion='" + NumberConfirmation + "' WHERE IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
            GuardarDatos()

            Correos.To.Clear()
            Correos.Subject = "Verifica la dirección de correo electrónico de tu cuenta de Libregco"
            Correos.IsBodyHtml = True
            Correos.Body = "<h3>Verificar <span style='text-decoration: underline;'>" & txtCorreo.Text & "</span>&nbsp;como tu direcci&oacute;n de correo electr&oacute;nico de contacto.</h3> <p><em>Hola, " & lblNombre.Text & "</em></p> <p>Confirma que quieres usar <span style='text-decoration underline;'>" & txtCorreo.Text & "</span><em>&nbsp;como direcci&oacute;n de correo electr&oacute;nico para tu cuenta de Libregco.</em></p> <p><em>Libregco usar&aacute; este correo electr&oacute;nico para enviarte notificaciones importantes sobre tu cuenta y tu seguridad.</em></p> <p><em>Tu n&uacute;mero de confirmaci&oacute;n de cuenta es:&nbsp;</em><strong><em>" & NumberConfirmation & "</em></strong></p>  <p>No reconoces este actividad?</p> <p>Si no has a&ntilde;adido <span style='text-decoration underline;'>" & txtCorreo.Text & "</span>&nbsp;a tu cuenta de Libregco, ignora este correo electr&oacute;nico y esa direcci&oacute;n no se a&ntilde;adira a tu cuenta de Libregco. Es posible que alguien haya escrito mal su propia direcci&oacute;n de correo electr&oacute;nico.</p> <p><em>Servicio al cliente <strong>Libregco</strong></em>&nbsp;</p> <hr /> <blockquote> <p><span style=color #999999;'>Este&nbsp;correo&nbsp;electr&oacute;nico no puede recibir respuestas. Para obtener m&aacute;s informaci&oacute;n, visita el apartado de seguridad de Libregco.</span></p> </blockquote> <hr /> <p>&nbsp;</p>"
            Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
            Correos.Priority = System.Net.Mail.MailPriority.Normal
            Correos.To.Add(Trim(txtCorreo.Text))

            Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
            Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

            Envios.Host = "smtp.gmail.com"
            Envios.Port = 587
            Envios.EnableSsl = True
            Envios.Send(Correos)

            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
        Else
            MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.Close()
        End If
    End Sub

    Private Sub btnComprobar_Click(sender As Object, e As EventArgs) Handles btnComprobar.Click
        'Try

        If NumberConfirmation = txtCodigo.Text Then

            sqlQ = "UPDATE Empleados SET CorreoVerificado=1 WHERE IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
            GuardarDatos()

            Label7.ForeColor = SystemColors.Highlight
            Label7.Text = "El correo ha sido verificado satisfactoriamente."

            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

            If Me.Owner.Name = frm_recuperar_cuenta.Name Then
                frm_recuperar_cuenta.UserInfo(5) = 1
            End If

            Close()
        Else

            If Me.Owner.Name = frm_recuperar_cuenta.Name Then
                frm_recuperar_cuenta.UserInfo(5) = 0
            End If

            Label7.ForeColor = Color.Red
            Label7.Text = "El número de confirmación no es el correcto. Por favor intente de nuevo"
        End If


        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRevisar.Click

        If Validar_Mail(LCase(txtCorreo.Text)) = False Then
            MessageBox.Show("La dirección de correo electrónico no es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCorreo.Focus()
            txtCorreo.SelectAll()
            Panel2.Enabled = False
        Else
            Panel2.Enabled = True

            txtCorreo.Enabled = False
            txtCorreo.ReadOnly = True

            sqlQ = "UPDATE Empleados SET CorreoElectronico='" + txtCorreo.Text + "' WHERE IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
            GuardarDatos()

            btnEnviarCodigo.BackColor = SystemColors.Highlight
            btnEnviarCodigo.Enabled = True
            btnModificarCorreo.Visible = True
            btnRevisar.Visible = False
        End If

    End Sub

    Private Sub btnEnviarCodigo_Click(sender As Object, e As EventArgs) Handles btnEnviarCodigo.Click
        Try
            If Panel2.Location = New Point(0, 419) Then
                Panel2.Location = New Point(0, 362)
                Panel1.Visible = True
                btnEnviarCodigo.Enabled = False
                btnVolverAEnviar.Visible = True
                btnEnviarCodigo.BackColor = Color.Gray
                btnModificarCorreo.Enabled = False
                btnModificarCorreo.BackColor = Color.Gray

                If My.Computer.Network.IsAvailable = True Then
                    NumberConfirmation = GetRandomnumber(3)

                    sqlQ = "UPDATE Empleados SET ClaveVerificacion='" + NumberConfirmation + "' WHERE IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                    GuardarDatos()

                    Correos.To.Clear()
                    Correos.Subject = "Verifica la dirección de correo electrónico de tu cuenta de Libregco"
                    Correos.IsBodyHtml = True
                    Correos.Body = "<h3>Verificar <span style='text-decoration: underline;'>" & txtCorreo.Text & "</span>&nbsp;como tu direcci&oacute;n de correo electr&oacute;nico de contacto.</h3> <p><em>Hola, " & lblNombre.Text & "</em></p> <p>Confirma que quieres usar <span style='text-decoration underline;'>" & txtCorreo.Text & "</span><em>&nbsp;como direcci&oacute;n de correo electr&oacute;nico para tu cuenta de Libregco.</em></p> <p><em>Libregco usar&aacute; este correo electr&oacute;nico para enviarte notificaciones importantes sobre tu cuenta y tu seguridad.</em></p> <p><em>Tu n&uacute;mero de confirmaci&oacute;n de cuenta es:&nbsp;</em><strong><em>" & NumberConfirmation & "</em></strong></p>  <p>No reconoces este actividad?</p> <p>Si no has a&ntilde;adido <span style='text-decoration underline;'>" & txtCorreo.Text & "</span>&nbsp;a tu cuenta de Libregco, ignora este correo electr&oacute;nico y esa direcci&oacute;n no se a&ntilde;adira a tu cuenta de Libregco. Es posible que alguien haya escrito mal su propia direcci&oacute;n de correo electr&oacute;nico.</p> <p><em>Servicio al cliente <strong>Libregco</strong></em>&nbsp;</p> <hr /> <blockquote> <p><span style=color #999999;'>Este&nbsp;correo&nbsp;electr&oacute;nico no puede recibir respuestas. Para obtener m&aacute;s informaci&oacute;n, visita el apartado de seguridad de Libregco.</span></p> </blockquote> <hr /> <p>&nbsp;</p>"
                    Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
                    Correos.Priority = System.Net.Mail.MailPriority.Normal
                    Correos.To.Add(Trim(txtCorreo.Text))

                    Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
                    Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                    Envios.Host = "smtp.gmail.com"
                    Envios.Port = 587
                    Envios.EnableSsl = True
                    Envios.Send(Correos)

                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                Else
                    MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class