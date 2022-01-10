Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Bitmap
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class frm_prefacturacion_email
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    'Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Private MailRegex As New Regex("^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$", RegexOptions.Compiled)

    Private Sub frm_prefacturacion_email_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCorreos()
    End Sub

    Private Sub FillCorreos()
        Try

            edtTo.Properties.Tokens.Clear()
            edtTo.EditValue = Nothing

            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("Select CorreoElectronico FROM empleados where correoelectronico<>'' and Nulo=0 group by correoelectronico", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Correo")
            Con.Close()

            For Each Fila As DataRow In ds.Tables("Correo").Rows
                edtTo.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken(Fila.Item("CorreoElectronico")))
            Next

            ds.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub edtTo_ValidateToken(sender As Object, e As DevExpress.XtraEditors.TokenEditValidateTokenEventArgs) Handles edtTo.ValidateToken
        e.IsValid = MailRegex.IsMatch(e.Description)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        If My.Computer.Network.IsAvailable = True Then

            'If edtTo.GetTokenList.Count = 0 Then
            '    MessageBox.Show("Escriba al menos una dirección de correo electrónico de destinatario(s) para enviar los datos de este registro.", "No hay destinatarios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
            'Dim Envios As New SmtpClient
            'Dim Correos As New MailMessage
            'Dim ReportPath As String

            'Correos.To.Clear()
            'Correos.Subject = "Prefacturación / Cotización : (" & DirectCast(Me.ActiveMdiChild, frm_prefacturacion_new).txtSecondID.Text & ") " & DTEmpresa.Rows(0).Item("NombreEmpresa")
            'Correos.IsBodyHtml = True
            'Correos.Body = "<ul> <li>Raz&oacute;n Social: " & frm_inicio.lblRazon.Text & "</li> <li>Teminal: " & frm_inicio.Button4.Text & "</li> </ul><p>Notificamos el registro de la factura de compra No. <strong>" + txtNoFact.Text + "&nbsp;</strong>de fecha " + DtpFechaFact.Value.ToString("dd/MM/yyyy") + " del suplidor " + txtNombreSuplidor.Text + ", por un valor de " + txtNeto.Text + ".</p> <p>Este registro se encuentra guardado con el ID # <strong>" + txtSecondID.Text + "</strong>.</p><p>&nbsp;Este correo ha remitido por <strong>" + frm_inicio.lblNombre.Text + "</strong>.</p> <hr /> <p>Este mensaje ha sido enviado desde @<em><strong>Libregco</strong></em>.</p>"
            'Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
            'Correos.Priority = System.Net.Mail.MailPriority.Normal

            'For Each st As String In edtTo.EditValue
            '    Correos.To.Add(Trim(String.Format(st)))
            'Next

            'If chkEnviarCopiaDigital.Checked = True Then
            '    Dim Attach As New System.Net.Mail.Attachment(RutaDocumento.Text)
            '    Correos.Attachments.Add(Attach)
            'End If

            'If chkEnviarReporte.Checked = True Then
            '    Dim crParameterValues As New ParameterValues
            '    Dim crParameterDiscreteValue As New ParameterDiscreteValue
            '    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
            '    Dim crParameterFieldDefinition As ParameterFieldDefinition
            '    Dim crParameterRangeValue As ParameterRangeValue
            '    Dim ObjRpt As New ReportDocument

            '    'Buscar ubicacion del reporte
            '    Dim CompraReportPath As String
            '    Con.Open()
            '    cmd = New MySqlCommand("Select Path FROM" & SysName.Text & "reportes where IDReportes=72", Con)
            '    CompraReportPath = Convert.ToString(cmd.ExecuteScalar())
            '    Con.Close()

            '    'Selecciono el tipo de conexion
            '    If TypeConnection.Text = 1 Then
            '        ObjRpt.Load("\\" & PathServidor.Text & CompraReportPath)
            '    Else
            '        ObjRpt.Load("C:" & CompraReportPath.Replace("\Libregco\Libregco.net", ""))
            '    End If

            '    'Limpio los antiguos parametros
            '    crParameterValues.Clear()

            '    crParameterDiscreteValue.Value = txtIDCompra.Text
            '    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            '    crParameterFieldDefinition = crParameterFiledDefinitions.Item("IDDocumento")
            '    crParameterValues.Add(crParameterDiscreteValue)
            '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '    'Despues de cargados los datos, las opciones del PDF por DEfault
            '    Dim CrExportOptions As ExportOptions
            '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            '    Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

            '    CrDiskFileDestinationOptions.DiskFileName = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
            '    ReportPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
            '    CrExportOptions = ObjRpt.ExportOptions

            '    With CrExportOptions
            '        .ExportDestinationType = ExportDestinationType.DiskFile
            '        .ExportFormatType = ExportFormatType.PortableDocFormat
            '        .ExportDestinationOptions = CrDiskFileDestinationOptions
            '        .ExportFormatOptions = CrFormatTypeOtions
            '    End With

            '    ObjRpt.Export()

            '    Dim Attach As New System.Net.Mail.Attachment(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf")
            '    Correos.Attachments.Add(Attach)
            'End If

            ''Envio del correo
            'Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
            'Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

            'Envios.Host = "smtp.gmail.com"
            'Envios.Port = 587
            'Envios.EnableSsl = True
            'Envios.Send(Correos)


            'Envios.Dispose()
            'Correos.Dispose()

            'If System.IO.File.Exists(ReportPath) = True Then
            '    System.IO.File.Delete(ReportPath)
            'End If

            'Dim NotificacionMessage As New NotifyIcon
            'NotificacionMessage.Icon = SystemIcons.Application
            'NotificacionMessage.BalloonTipIcon = ToolTipIcon.Info
            'NotificacionMessage.Visible = True


            'With NotificacionMessage
            '    .Text = "El correo ha sido enviado exitosamente."
            '    .BalloonTipTitle = "Correo enviado"
            '    .BalloonTipText = "El correo ha sido enviado exitosamente."
            '    .ShowBalloonTip(2000)
            'End With

            'NotificacionMessage.Dispose()


            'MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Else
            MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If

    End Sub
End Class