Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail
Imports System.Net
Public Class frm_recuperar_cuenta

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Private Correos As New MailMessage
    Private Envios As New SmtpClient
    Dim GroupOtrosMot As New GroupBox
    Dim Option1, Option2, Option3 As New RadioButton
    Dim NewPassword As New Label
    Friend UserInfo As New ArrayList
    '1 Users ID
    '2 Users Name
    '3 Email
    '4 Login Name
    '5 Password
    '6 Verifiec
    '7 PicFilePath1
    '8 PicFilePath2

    Private Sub frm_recuperar_cuenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        GetColors()
        CargarEmpresa()
        CargarLibregco()
        ActualizarTodo()
        VerificarCondicionRDB()
    End Sub

    Private Sub GetColors()
        PanelInferior.BackColor = frm_LoginSistema.PanelIzquierdo.BackColor
        PanelSuperior.BackColor = frm_LoginSistema.PanelInferior.BackColor
        btn_Iniciar.BackColor = frm_LoginSistema.btn_Iniciar.BackColor
        btn_Iniciar.FlatAppearance.MouseDownBackColor = frm_LoginSistema.btn_Iniciar.FlatAppearance.MouseDownBackColor
        btn_Iniciar.FlatAppearance.MouseOverBackColor = frm_LoginSistema.btn_Iniciar.FlatAppearance.MouseOverBackColor
    End Sub

    Private Sub VerificarCondicionRDB()
        MessageWatermark.Text = ""
        If rdbNoPassword.Checked = True Then
            lblMessage.Visible = True
            MessageWatermark.Visible = True
            Me.PanelMenu.Controls.Remove(GroupOtrosMot)
            rdbNoPassword.Location = New Point(19, 49)
            lblMessage.Location = New Point(19, 75)
            lblMessage.Text = "Si deseas restablecer la contraseña, ingresa la dirección de correo electrónico que utilizas. No importa el tipo de dirección asociada a tu cuenta."
            MessageWatermark.Location = New Point(16, 126)
            MessageWatermark.WatermarkText = "Dirección de correo electrónico"
            rdbNoUserName.Location = New Point(19, 155)
            rdbOtroMotivo.Location = New Point(19, 184)
            rdbPCAutorizado.Location = New Point(19, 213)
            lblMessage.Size = New Point(325, 47)
            Me.Size = New Point(646, 474)
            btn_Iniciar.Location = New Point(232, 244)
        ElseIf rdbNoUserName.Checked = True Then
            lblMessage.Visible = True
            MessageWatermark.Visible = True
            Me.Size = New Point(646, 420)
            Me.PanelMenu.Controls.Remove(GroupOtrosMot)
            rdbNoUserName.Location = New Point(19, 78)
            btn_Iniciar.Location = New Point(232, 215)
            lblMessage.Location = New Point(19, 104)
            lblMessage.Size = New Point(325, 32)
            lblMessage.Text = "Ingresa tu dirección de correo electrónico. No importa el tipo de dirección asociada a tu cuenta."
            MessageWatermark.Location = New Point(19, 139)
            MessageWatermark.WatermarkText = "Dirección de correo electrónico"
            rdbOtroMotivo.Location = New Point(19, 168)
            rdbPCAutorizado.Location = New Point(19, 197)
        ElseIf rdbOtroMotivo.Checked = True Then
            lblMessage.Visible = True
            MessageWatermark.Visible = True
            Me.Size = New Point(646, 560)
            rdbOtroMotivo.Location = New Point(19, 107)
            rdbNoUserName.Location = New Point(19, 78)
            rdbPCAutorizado.Location = New Point(19, 309)
            lblMessage.Location = New Point(19, 133)
            lblMessage.Size = New Point(325, 47)
            lblMessage.Text = "Escribe el nombre de usuario que usas para iniciar sesión en  Puede ser la dirección de correo electronico que hayas asociado a tu cuenta."

            PanelMenu.Controls.Add(GroupOtrosMot)
            GroupOtrosMot.Location = New System.Drawing.Point(19, 184)
            GroupOtrosMot.Size = New System.Drawing.Size(265, 89)
            GroupOtrosMot.Text = "Específique el motivo"

            GroupOtrosMot.Controls.Add(Option1)
            Option1.Location = New System.Drawing.Point(32, 19)
            Option1.AutoSize = True
            Option1.Text = "El usuario está conectado."
            Option1.TabStop = True

            GroupOtrosMot.Controls.Add(Option2)
            Option2.Location = New System.Drawing.Point(32, 42)
            Option2.AutoSize = True
            Option2.Text = "El usuario está bloqueado."
            Option2.TabStop = True

            GroupOtrosMot.Controls.Add(Option3)
            Option3.Location = New System.Drawing.Point(32, 65)
            Option3.AutoSize = True
            Option3.Text = "El usuario está desactivado."
            Option3.TabStop = True

            MessageWatermark.Location = New Point(19, 280)
            MessageWatermark.WatermarkText = "Nombre de Usuario o Correo electrónico"

        ElseIf rdbPCAutorizado.Checked = True Then
            Me.PanelMenu.Controls.Remove(GroupOtrosMot)
            rdbNoPassword.Location = New Point(19, 49)
            lblMessage.Visible = False
            MessageWatermark.Visible = False
            rdbNoUserName.Location = New Point(19, 78)
            rdbOtroMotivo.Location = New Point(19, 107)
            rdbPCAutorizado.Location = New Point(19, 136)
            btn_Iniciar.Location = New Point(232, 170)
            Me.Size = New Size(646, 420)
        End If
    End Sub

    Private Sub CargarLibregco()
        Try
            LogoLibregco.Image = ConseguirLogoSistema()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        rdbNoPassword.Checked = True
        MessageWatermark.Text = ""
        MessageWatermark.Focus()
        rdbNoUserName.Checked = False
        rdbOtroMotivo.Checked = False
    End Sub

    Private Sub rdbNoPassword_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoPassword.CheckedChanged
        VerificarCondicionRDB()
    End Sub

    Private Sub rdbOtroMotivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbOtroMotivo.CheckedChanged
        VerificarCondicionRDB()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        UserInfo.Clear()

        If rdbNoPassword.Checked = True Or rdbNoUserName.Checked = True Then
            If MessageWatermark.Text = "" Then
                MessageBox.Show("No se ha específicado la dirección de correo electrónico para recuperar la cuenta de acceso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                MessageWatermark.Focus()
                Exit Sub
            ElseIf MessageWatermark.Text.Length < 4 Then
                MessageBox.Show("La dirección de correo electrónico es muy corta o está incompleta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                MessageWatermark.Focus()
                Exit Sub
            End If
        ElseIf rdbOtroMotivo.Checked = True Then
            If Option1.Checked = False And Option2.Checked = False And Option3.Checked = False Then
                MessageBox.Show("Específique el motivo por el que no puede acceder al sistema.")
                Option1.Checked = True
                Exit Sub
            ElseIf MessageWatermark.Text = "" Then
                MessageBox.Show("No se ha específicado la dirección de correo electrónico o el nombre de usuario para recuperar la cuenta de acceso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                MessageWatermark.Focus()
                Exit Sub
            End If
        End If

        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("Select IDEmpleado,Nombre,CorreoElectronico,Login,Password,CorreoVerificado,RutaFoto,ImagenChat from Empleados Where CorreoElectronico='" + MessageWatermark.Text + "' UNION ALL " & "Select IDEmpleado,Nombre,CorreoElectronico,Login,Password,CorreoVerificado,RutaFoto,ImagenChat from Empleados Where Login='" + MessageWatermark.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")

        If Tabla.Rows.Count > 0 Then
            UserInfo.Add(Tabla.Rows(0).Item(0))
            UserInfo.Add(Tabla.Rows(0).Item(1))
            UserInfo.Add(Tabla.Rows(0).Item(2))
            UserInfo.Add(Tabla.Rows(0).Item(3))
            UserInfo.Add(Tabla.Rows(0).Item(4))
            UserInfo.Add(Tabla.Rows(0).Item(5))
            UserInfo.Add(Tabla.Rows(0).Item(6))
            UserInfo.Add(Tabla.Rows(0).Item(7))
        End If

        If rdbPCAutorizado.Checked = False Then
            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("El correo electrónico o usuario " & MessageWatermark.Text & " no se ha encontrado en la base de datos. Por favor revise si el correo o usuario está bien escrito.", "No se encontró el correo electrónico y/o usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        If rdbNoPassword.Checked = True Then
            If Validar_Mail(UserInfo(2).ToString) = True Then
                If UserInfo(5).ToString = "1" Then
                    If My.Computer.Network.IsAvailable = True Then

EnvioCorreo:
                        btn_Iniciar.BackColor = Color.Gray
                        NewPassword.Text = GenerarCadena(16)

                        sqlQ = "UPDATE Empleados SET Password='" + NewPassword.Text + "',Status=1 WHERE IDEmpleado='" + UserInfo(0).ToString + "'"
                        GuardarDatos()

                        Correos.To.Clear()
                        Correos.Subject = "Recuperación de contraseña de acceso"
                        Correos.IsBodyHtml = True
                        Correos.Body = "<p><em><strong>Recuperaci&oacute;n de clave de acceso</strong></em></p> <p><em>Querido(a) " & UserInfo(1) & ",</em></p> <p>La contrase&ntilde;a de tu acceso a <em><strong>Libregco</strong></em> ha sido reseteada satisfactoriamente.</p> <p style='text-align: left;'>Tu nueva contrase&ntilde;a temporal es:&nbsp;<strong>" & NewPassword.Text & "</strong></p> <p>Si crees que has recibido este correo por error o que una persona no autorizada ha accedido a su cuenta, vaya al apartado de Seguridad de Empleados para actualizar su configuraci&oacute;n.</p> <p>Si tienes m&aacute;s preguntas puedes consultarnos en la pesta&ntilde;a de Servicio T&eacute;cnico.</p> <ul> <li>Fecha de solicitud: " & Today.ToString("dd/MM/yyyy") & " " & Now.ToString("hh:mm:ss tt") & "</li> <li>Raz&oacute;n Social: " & frm_LoginSistema.lblEmpresa.Text & "</li> <li>Teminal: " & frm_LoginSistema.lblEquipo.Text & "</li> </ul> <p>Muchas gracias</p> <p><em><font size='2'>Servicio al cliente <strong>Libregco</strong></font></em></p> <hr /> <p>&nbsp;</p>"
                        Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
                        Correos.Priority = System.Net.Mail.MailPriority.Normal
                        Correos.To.Add(Trim(UserInfo(2)))

                        Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
                        Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                        Envios.Host = "smtp.gmail.com"
                        Envios.Port = 587
                        Envios.EnableSsl = True
                        Envios.Send(Correos)

                        MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        Close()
                    Else
                        MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                Else
                    If My.Computer.Network.IsAvailable = True Then
                        Dim Result As MsgBoxResult = MessageBox.Show("La dirección de correo electrónico especificado en tu cuenta aún no ha sido verificada." & vbNewLine & vbNewLine & "Desea verificar la cuenta del correo electronico?", "Verificación de correo electrónico", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            frm_verificacion_correo.ShowDialog(Me)

                            If UserInfo(5).ToString = "1" Then
                                GoTo EnvioCorreo
                            ElseIf UserInfo(5).ToString = "0" Then
                                MessageBox.Show("Es necesario verificar la cuenta de correo electrónico asociada a tu cuenta para restablecer la contraseña de tu cuenta.", "Verificación necesaria para reestablecer contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Es necesario verificar la cuenta de correo electrónico asociada a tu cuenta para restablecer la contraseña de tu cuenta.", "Verificación necesaria para reestablecer contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                End If
            End If

        ElseIf rdbNoUserName.Checked = True Then
            If My.Computer.Network.IsAvailable = True Then
            Else
                MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        ElseIf rdbOtroMotivo.Checked = True Then
            Dim AcStatus As New Label
            Con.Open()
            cmd = New MySqlCommand("Select Status from Empleados where CorreoElectronico='" + MessageWatermark.Text + "' or Login='" + MessageWatermark.Text + "'", Con)
            AcStatus.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If Option1.Checked = True Then
                Dim AcConetado As New Label
                Con.Open()
                cmd = New MySqlCommand("Select Conectado from Empleados where CorreoElectronico='" + MessageWatermark.Text + "' or Login='" + MessageWatermark.Text + "'", Con)
                AcConetado.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If AcConetado.Text = 1 Then
                    sqlQ = "UPDATE Empleados SET Conectado=0 WHERE IDEmpleado='" + UserInfo(0).ToString + "'"
                    GuardarDatos()
                    MessageBox.Show("Enhorabuena!" & vbNewLine & vbNewLine & "El usuario ha sido restaurado satisfactoriamente.", "Restablecimiento completado.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                Else
                    MessageBox.Show("No se ha encontrado esta condición en el usuario asociado a la cuenta específicada.", "El usuario no tiene este problema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If
            If Option2.Checked = True Then
                If My.Computer.Network.IsAvailable = True Then
                    If AcStatus.Text = 3 Then
                        Dim NewPassword As New Label
                        NewPassword.Text = GenerarCadena(16)

                        sqlQ = "UPDATE Empleados SET Password='" + NewPassword.Text + "',Status=1 WHERE IDEmpleado='" + UserInfo(0).ToString + "'"
                        GuardarDatos()

                        Correos.To.Clear()
                        Correos.Subject = "Recuperación de contraseña de acceso"
                        Correos.IsBodyHtml = True
                        Correos.Body = "<p><em><strong>Recuperaci&oacute;n de clave de acceso</strong></em></p> <p><em>Querido(a) " & UserInfo(1) & ",</em></p> <p>La contrase&ntilde;a de tu acceso a <em><strong>Libregco</strong></em> ha sido reestablecida satisfactoriamente.</p> <p style='text-align: left;'>Tu nueva contrase&ntilde;a temporal es:&nbsp;<strong>" & NewPassword.Text & "</strong></p> <p>Si crees que has recibido este correo por error o que una persona no autorizada ha accedido a su cuenta, vaya al apartado de Seguridad de Empleados para actualizar su configuraci&oacute;n.</p> <p>Si tienes m&aacute;s preguntas puedes consultarnos en la pesta&ntilde;a de Servicio T&eacute;cnico.</p> <ul> <li>Fecha de solicitud: " & Today.ToString("dd/MM/yyyy") & " " & Now.ToString("hh:mm:ss tt") & "</li> <li>Raz&oacute;n Social: " & frm_LoginSistema.lblEmpresa.Text & "</li> <li>Teminal: " & frm_LoginSistema.lblEquipo.Text & "</li> </ul> <p>Muchas gracias</p> <p><em><font size='2'>Servicio al cliente <strong>Libregco</strong></font></em></p> <hr /> <p>&nbsp;</p>"
                        Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
                        Correos.Priority = System.Net.Mail.MailPriority.Normal
                        Correos.To.Add(Trim(UserInfo(2)))

                        Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
                        Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                        Envios.Host = "smtp.gmail.com"
                        Envios.Port = 587
                        Envios.EnableSsl = True
                        Envios.Send(Correos)

                        MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        Close()
                    Else
                        MessageBox.Show("No se ha encontrado esta condición en el usuario asociado a la cuenta específicada.", "El usuario no tiene este problema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

            End If
            If Option3.Checked = True Then
                If My.Computer.Network.IsAvailable = True Then
                    Dim AcDesactivado As New Label
                    Con.Open()
                    cmd = New MySqlCommand("Select Nulo from Empleados where CorreoElectronico='" + MessageWatermark.Text + "' or Login='" + MessageWatermark.Text + "'", Con)
                    AcDesactivado.Text = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If AcDesactivado.Text = 1 Then
                        btn_Iniciar.BackColor = Color.Gray

                        Correos.To.Clear()
                        Correos.Subject = "Acceso bloqueado o suspendido"
                        Correos.IsBodyHtml = True
                        Correos.Body = "<p><em><strong>Acceso Inhabilitado</strong></em></p> <p><em>Querido(a) " & UserInfo(1) & ",</em></p> <p>Su acceso a la base de datos est&aacute; temporalmente deshabilitado o suspendida.</p> <p>Por favor contacte a su supervisor o superior para verificar las razones o motivos del bloqueo. De igual manera, si crees que has recibido este correo por error o que una persona no autorizada est&aacute; intentando ingresar a su cuenta por favor comun&iacute;quese con el departamento administrativo.</p> <p>Muchas gracias</p> <p><em><span style=font-size: small;>Servicio al cliente <strong>Libregco</strong></span></em></p><hr /> <p>&nbsp;</p>"
                        Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
                        Correos.Priority = System.Net.Mail.MailPriority.Normal
                        Correos.To.Add(Trim(UserInfo(2)))

                        Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
                        Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                        Envios.Host = "smtp.gmail.com"
                        Envios.Port = 587
                        Envios.EnableSsl = True
                        Envios.Send(Correos)

                        MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        Close()
                    Else
                        MessageBox.Show("No se ha encontrado esta condición en el usuario asociado a la cuenta específicada.", "El usuario no tiene este problema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


            'Status de los Empleados
            'Status=0 Empleado en condición normal
            'Status=1 Empleado en condición de cambio de contraseña
            'Status=2 Empleado con primera alerta de intentos fallidos en contraseña
            'Status3=Empleado bloqueado

        ElseIf rdbPCAutorizado.Checked = True Then
            frm_autorizacion_equipos.ShowDialog(Me)
            Me.Close()

        End If
    End Sub

    Private Sub rdbNoUserName_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoUserName.CheckedChanged
        VerificarCondicionRDB()
    End Sub

    Private Sub MessageWatermark_Leave(sender As Object, e As EventArgs) Handles MessageWatermark.Leave
        If rdbNoPassword.Checked = True Or rdbNoUserName.Checked = True Then
            If MessageWatermark.Text <> "" Then
                If Validar_Mail(LCase(MessageWatermark.Text)) = False Then
                    MessageBox.Show("La dirección de correo electrónico no es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    MessageWatermark.Focus()
                    MessageWatermark.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub rdbPCAutorizado_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPCAutorizado.CheckedChanged
        VerificarCondicionRDB()
    End Sub
End Class