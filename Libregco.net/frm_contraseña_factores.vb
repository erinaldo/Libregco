Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frm_contraseña_factores
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtPasswordFactor.Text = "" Then
            MessageBox.Show("Por favor escriba la contraseña de 4 factores.", "Contraseña vacía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPasswordFactor.Focus()
            Exit Sub
        ElseIf txtPasswordFactor.Text <> txtPasswordFactorRep.Text Then
            MessageBox.Show("La contraseña de 4 factores no coincide. Por favor vuelva a escribir la contraseña e intente volver a guardar el registro.", "Contraseña no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPasswordFactor.Focus()
            Exit Sub
        End If

        sqlQ = "UPDATE Empleados SET FactorNumerico='" + txtPasswordFactor.Text + "' WHERE IDEmpleado= '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString + "'"
        GuardarDatos()
        MessageBox.Show("Se ha establecido la contraseña correctamente.", "Contraseña guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        ControlSuperClave = 1
        Close()

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub frm_contraseña_factores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibregco()
        lblNombre.Text = DTEmpleado.Rows(0).Item("Nombre")

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

        txtPasswordFactor.Focus()
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

    Private Sub frm_contraseña_factores_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.F4 Then
            e.Handled = True
            MessageBox.Show("No es posible cerrar esta ventana de manera forzosa.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub txtPasswordFactor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPasswordFactor.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPasswordFactorRep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPasswordFactorRep.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPasswordFactorRep_Leave(sender As Object, e As EventArgs) Handles txtPasswordFactorRep.Leave
        If txtPasswordFactor.Text <> "" Then
            If txtPasswordFactor.Text <> txtPasswordFactorRep.Text Then
                lblMensajeFactores.ForeColor = Color.Red
                lblMensajeFactores.Text = "La contraseña de factor no coincide."
                txtPasswordFactor.Text = ""
                txtPasswordFactorRep.Text = ""
                txtPasswordFactor.Focus()
            Else
                lblMensajeFactores.Text = ""
                lblMensajeFactores.ForeColor = Color.Black
            End If
        End If

    End Sub

    Private Sub txtPasswordFactor_Leave(sender As Object, e As EventArgs) Handles txtPasswordFactor.Leave
        If txtPasswordFactor.Text <> "" Then
            If txtPasswordFactor.Text.Length < 4 Then
                MessageBox.Show("Por favor escriba una contraseña de 4 dígitos.", "Faltan " & 4 - CInt(txtPasswordFactor.Text.Length) & " dígito(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPasswordFactor.Focus()
                txtPasswordFactor.SelectAll()
                Exit Sub
            Else
                lblMensajeFactores.Text = "Vuelva a repetir la misma contraseña"
                lblMensajeFactores.ForeColor = SystemColors.Highlight
            End If
        End If

    End Sub

    Private Sub frm_contraseña_factores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ControlSuperClave = 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que no desea continuar con el acceso al sistema?", "Cerrar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ControlSuperClave = 0
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class