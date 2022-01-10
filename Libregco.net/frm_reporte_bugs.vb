Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail
Imports System.Net

Public Class frm_reporte_bugs
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblhora.Text = TimeOfDay()
        lblFecha.Text = Today.ToLongDateString
    End Sub

    Private Sub frm_reporte_bugs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()

        txtDescripcion.Clear()
        txtFormulario.Clear()
        txtMetodo.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        txtFirma.Clear()
        chkRecordar.Checked = False
        txtFirma.Text = frm_inicio.lblNombre.Text

    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtFormulario.ReadOnly = False
            txtFormulario.Focus()
        Else
            txtFormulario.ReadOnly = True
            txtFormulario.Clear()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            txtMetodo.ReadOnly = False
            txtMetodo.Focus()
        Else
            txtMetodo.ReadOnly = True
            txtMetodo.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("La descripción del problema se encuentra vacío." & vbNewLine & vbNewLine & "Por favor especifique el problema.", "Descripción incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        End If

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el reporte de errores?", "Guardar reporte de error", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            sqlQ = "INSERT INTO Errores (Fecha,Formulario,Metodo,Descripcion,MetodoBase,Enlace) VALUES ('" + Today.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:ss") + "','" + txtFormulario.Text + "','" + txtMetodo.Text + "','" + txtDescripcion.Text + "','N/A','')"
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
            MessageBox.Show("El reporte de error fue notificado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If My.Computer.Network.IsAvailable = True Then
                Dim Envios As New SmtpClient
                Dim Correos As New MailMessage

                Correos.To.Clear()
                Correos.Subject = "Reporte de avería / " & frm_inicio.lblRazon.Text
                Correos.IsBodyHtml = True
                Correos.Body = "<p><strong>Reporte de aver&iacute;as</strong></p><hr /> <p>Raz&oacute;n Social: " & frm_inicio.lblRazon.Text & "</p> <p>Usuario: " & frm_inicio.lblNombre.Text & "</p><hr /> <p>Formulario: " & txtFormulario.Text & "</p> <p>M&eacute;todo: " & txtMetodo.Text & "</p> <p>&nbsp;Descripci&oacute;n: " & txtDescripcion.Text & "</p> <p>&nbsp;</p> <p>" + If(chkRecordar.Checked = True, "El cliente desea ser notificado al realizar la corecci&oacute;n de la aver&iacute;a.", "") + "</p> <p>"
                Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
                Correos.Priority = System.Net.Mail.MailPriority.Normal

                Correos.To.Add("luismiguelperez.nc@gmail.com")

                'Envio del correo
                Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
                Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                Envios.Host = "smtp.gmail.com"
                Envios.Port = 587
                Envios.EnableSsl = True
                Envios.Send(Correos)
                Envios.Dispose()
                Correos.Dispose()

                Dim NotificacionMessage As New NotifyIcon
                NotificacionMessage.Icon = SystemIcons.Application
                NotificacionMessage.BalloonTipIcon = ToolTipIcon.Info
                NotificacionMessage.Visible = True

                With NotificacionMessage
                    .Text = "El correo ha sido enviado exitosamente."
                    .BalloonTipTitle = "Correo enviado"
                    .BalloonTipText = "El correo ha sido enviado exitosamente."
                    .ShowBalloonTip(2000)
                End With

                NotificacionMessage.Dispose()
            Else
                MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
            Close()
        End If
    End Sub
End Class