Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cambiar_nuevo_password

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim IDEmpleado, lblNivelSeguridad, lblNivel, DF1, DF2, DF3, DF4, DF5, lblTexto, lblErrorConf As New Label

    Private Sub frm_cambiar_nuevo_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
        CargarLibregco()
        CargarConfiguracion()
        ActualizarTodo()
    End Sub

    Private Sub CargarConfiguracion()
        Con.Open()

        'Version del sistema
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion) from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        lblVersion.Text = Convert.ToString(cmd.ExecuteScalar()) & "v"
        ConUtilitarios.Close()

        'Cargar color primario
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=64", Con)
        Panel1.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))
        btn_Iniciar.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))
        btn_Iniciar.FlatAppearance.BorderColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))
        btn_Iniciar.FlatAppearance.MouseDownBackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))
        btn_Iniciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        'Cargar color secundario
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=65", Con)
        Panel3.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        Con.Close()
    End Sub

    Private Sub CargarLibregco()
        LogoLibregco.Image = ConseguirLogoSistema()
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

    Private Sub ActualizarTodo()
        txtPassword.Clear()
        txtConfirmarPassword.Clear()
        IDEmpleado.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        If txtPassword.Text = "" Then
            Me.PanelMenu.Controls.Add(lblNivelSeguridad)
            lblNivelSeguridad.Location = New System.Drawing.Point(19, 98)
            lblNivelSeguridad.AutoSize = True
            lblNivelSeguridad.Font = New System.Drawing.Font("Segoe UI", 9.0!, FontStyle.Bold)
            lblNivelSeguridad.Text = "Seguridad de contraseña:"
            Me.PanelMenu.Controls.Add(lblNivel)
            lblNivel.Location = New System.Drawing.Point(19, 113)
            lblNivel.AutoSize = True
            lblNivel.Font = New System.Drawing.Font("Segoe UI", 9.0!, FontStyle.Regular)
            lblNivel.Text = "Demasiada Corta"
            Me.PanelMenu.Controls.Add(DF1)
            DF1.Location = New System.Drawing.Point(20, 132)
            DF1.Size = New System.Drawing.Size(36, 5)
            DF1.AutoSize = False
            DF1.BackColor = Color.DarkRed
            Me.PanelMenu.Controls.Add(DF2)
            DF2.Location = New System.Drawing.Point(55, 132)
            DF2.Size = New System.Drawing.Size(36, 5)
            DF2.AutoSize = False
            DF2.BackColor = Color.White
            Me.PanelMenu.Controls.Add(DF3)
            DF3.Location = New System.Drawing.Point(90, 132)
            DF3.Size = New System.Drawing.Size(36, 5)
            DF3.AutoSize = False
            DF3.BackColor = Color.White
            Me.PanelMenu.Controls.Add(DF4)
            DF4.Location = New System.Drawing.Point(125, 132)
            DF4.Size = New System.Drawing.Size(36, 5)
            DF4.AutoSize = False
            DF4.BackColor = Color.White
            Me.PanelMenu.Controls.Add(DF5)
            DF5.Location = New System.Drawing.Point(160, 132)
            DF5.Size = New System.Drawing.Size(36, 5)
            DF5.AutoSize = False
            DF5.BackColor = Color.White
            Me.PanelMenu.Controls.Add(lblTexto)
            lblTexto.Location = New System.Drawing.Point(19, 140)
            lblTexto.AutoSize = False
            lblTexto.Size = New System.Drawing.Size(246, 49)
            lblTexto.Font = New System.Drawing.Font("Segoe UI", 9.0!, FontStyle.Regular)
            lblTexto.Text = "Usa al menos seis caracteres. No uses la contraseña de otro sitio ni una demasiada obvia, como el nombre de tu mascota."
            lblConfirmacionPassword.Location = New Point(19, 190)
            txtConfirmarPassword.Location = New Point(22, 210)
            lblLenConfPassword.Location = New Point(264, 210)
            lblErrorConf.Text = ""
            btn_Iniciar.Location = New Point(232, 244)
        Else
            If Len(txtPassword.Text) > 0 And Len(txtPassword.Text) < 4 Then
                lblNivel.Text = "Demasiada Corta"
                DF1.BackColor = Color.DarkRed
                DF2.BackColor = Color.White
                DF3.BackColor = Color.White
                DF4.BackColor = Color.White
                DF5.BackColor = Color.White
            ElseIf Len(txtPassword.Text) > 4 And Len(txtPassword.Text) < 6 Then
                lblNivel.Text = "Corta"
                DF1.BackColor = Color.DarkSlateBlue
                DF2.BackColor = Color.DarkSlateBlue
                DF3.BackColor = Color.White
                DF4.BackColor = Color.White
                DF5.BackColor = Color.White
            ElseIf Len(txtPassword.Text) > 6 And Len(txtPassword.Text) < 8 Then
                lblNivel.Text = "Aceptable"
                DF1.BackColor = Color.Blue
                DF2.BackColor = Color.Blue
                DF3.BackColor = Color.Blue
                DF4.BackColor = Color.White
                DF5.BackColor = Color.White
            ElseIf Len(txtPassword.Text) > 8 And Len(txtPassword.Text) < 10 Then
                lblNivel.Text = "Óptima"
                DF1.BackColor = Color.LawnGreen
                DF2.BackColor = Color.LawnGreen
                DF3.BackColor = Color.LawnGreen
                DF4.BackColor = Color.LawnGreen
                DF5.BackColor = Color.White
            ElseIf Len(txtPassword.Text) > 10 Then
                lblNivel.Text = "Hermetica"
                DF1.BackColor = Color.Green
                DF2.BackColor = Color.Green
                DF3.BackColor = Color.Green
                DF4.BackColor = Color.Green
                DF5.BackColor = Color.Green
            End If
            lblLenPassword.Text = Len(txtPassword.Text)
        End If


    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If Len(txtPassword.Text) >= 0 And Len(txtPassword.Text) < 4 Then
            lblNivel.Text = "Demasiada Corta"
            DF1.BackColor = Color.DarkRed
            DF2.BackColor = Color.White
            DF3.BackColor = Color.White
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) > 4 And Len(txtPassword.Text) < 6 Then
            lblNivel.Text = "Corta"
            DF1.BackColor = Color.DarkSlateBlue
            DF2.BackColor = Color.DarkSlateBlue
            DF3.BackColor = Color.White
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) > 6 And Len(txtPassword.Text) < 8 Then
            lblNivel.Text = "Aceptable"
            DF1.BackColor = Color.Blue
            DF2.BackColor = Color.Blue
            DF3.BackColor = Color.Blue
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) > 8 And Len(txtPassword.Text) < 10 Then
            lblNivel.Text = "Óptima"
            DF1.BackColor = Color.LawnGreen
            DF2.BackColor = Color.LawnGreen
            DF3.BackColor = Color.LawnGreen
            DF4.BackColor = Color.LawnGreen
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) > 10 Then
            lblNivel.Text = "Hermetica"
            DF1.BackColor = Color.Green
            DF2.BackColor = Color.Green
            DF3.BackColor = Color.Green
            DF4.BackColor = Color.Green
            DF5.BackColor = Color.Green
        End If
        lblLenPassword.Text = Len(txtPassword.Text)
    End Sub

    Private Sub txtConfirmarPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmarPassword.TextChanged
        lblLenConfPassword.Text = Len(txtConfirmarPassword.Text)
    End Sub

    Private Sub txtConfirmarPassword_Leave(sender As Object, e As EventArgs) Handles txtConfirmarPassword.Leave
        If txtPassword.Text <> "" Then
            Me.PanelMenu.Controls.Add(lblErrorConf)
            If txtPassword.Text <> txtConfirmarPassword.Text And txtConfirmarPassword.Text <> "" Then
                Dim g As Graphics = Me.PanelMenu.CreateGraphics
                Dim pen As New Pen(Color.Red, 2.0)
                lblErrorConf.Location = New System.Drawing.Point(16, 235)
                lblErrorConf.AutoSize = True
                lblErrorConf.Font = New System.Drawing.Font("Segoe UI", 9.0!, FontStyle.Regular)
                lblErrorConf.Text = "Las contraseñas no coinciden. ¿Quieres volver a intentarlo?"
                lblErrorConf.ForeColor = Color.Red
                btn_Iniciar.Location = New Point(232, 257)
                lblErrorConf.Visible = True
                g.DrawRectangle(pen, New Rectangle(txtConfirmarPassword.Location, txtConfirmarPassword.Size))
                g.DrawRectangle(pen, New Rectangle(lblLenConfPassword.Location, lblLenConfPassword.Size))
                pen.Dispose()
            Else
                lblErrorConf.Visible = False
                btn_Iniciar.Location = New Point(232, 244)
            End If
        End If


    End Sub

    Private Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        Dim g As Graphics = Me.PanelMenu.CreateGraphics
        Dim pen As New Pen(Color.Red, 2.0)
        If Validar_Password(txtPassword.Text) = False Then
            MessageBox.Show("La contraseña no cumple con los estándares establecidos." & vbNewLine & vbNewLine & "La contraseña debe tener de 6 a 15 caracteres." & vbNewLine & "Deben tener al menos una letra minúscula" & vbNewLine & "Deben tener al menos una letra mayúscula.", "Requisitos para contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPassword.Focus()
            txtPassword.SelectAll()
            Exit Sub
        ElseIf txtPassword.Text <> txtConfirmarPassword.Text Then
            lblErrorConf.Location = New System.Drawing.Point(16, 235)
            lblErrorConf.AutoSize = True
            lblErrorConf.Font = New System.Drawing.Font("Segoe UI", 9.0!, FontStyle.Regular)
            lblErrorConf.Text = "Las contraseñas no coinciden. ¿Quieres volver a intentarlo?"
            lblErrorConf.ForeColor = Color.Red
            lblErrorConf.Visible = True
            g.DrawRectangle(pen, New Rectangle(txtConfirmarPassword.Location, txtConfirmarPassword.Size))
            g.DrawRectangle(pen, New Rectangle(lblLenConfPassword.Location, lblLenConfPassword.Size))
            btn_Iniciar.Location = New Point(232, 257)
            Exit Sub
        Else
            pen.Dispose()
        End If

        sqlQ = "UPDATE Empleados SET Password='" + txtPassword.Text + "',FechaPassword='" + Today.ToString("dd/MM/yyyy") + "',Status=0 WHERE IDEmpleado='" + IDEmpleado.Text + "'"
        GuardarDatos()

        MessageBox.Show("Enhorabuena.!" & vbNewLine & vbNewLine & "La contraseña se ha restablecido satisfactoriamente.", "Operación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Close()
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If Len(txtPassword.Text) >= 0 And Len(txtPassword.Text) < 4 Then
            lblNivel.Text = "Demasiada Corta"
            DF1.BackColor = Color.DarkRed
            DF2.BackColor = Color.White
            DF3.BackColor = Color.White
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) >= 4 And Len(txtPassword.Text) < 6 Then
            lblNivel.Text = "Corta"
            DF1.BackColor = Color.DarkSlateBlue
            DF2.BackColor = Color.DarkSlateBlue
            DF3.BackColor = Color.White
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) >= 6 And Len(txtPassword.Text) < 8 Then
            lblNivel.Text = "Aceptable"
            DF1.BackColor = Color.Blue
            DF2.BackColor = Color.Blue
            DF3.BackColor = Color.Blue
            DF4.BackColor = Color.White
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) >= 8 And Len(txtPassword.Text) < 10 Then
            lblNivel.Text = "Óptima"
            DF1.BackColor = Color.LawnGreen
            DF2.BackColor = Color.LawnGreen
            DF3.BackColor = Color.LawnGreen
            DF4.BackColor = Color.LawnGreen
            DF5.BackColor = Color.White
        ElseIf Len(txtPassword.Text) >= 10 Then
            lblNivel.Text = "Hermetica"
            DF1.BackColor = Color.Green
            DF2.BackColor = Color.Green
            DF3.BackColor = Color.Green
            DF4.BackColor = Color.Green
            DF5.BackColor = Color.Green
        End If
        lblLenPassword.Text = Len(txtPassword.Text)

        Con.Open()
        cmd = New MySqlCommand("Select Password from Empleados where IDEmpleado='" + IDEmpleado.Text + "'", Con)
        Dim OldPassword As String = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If txtPassword.Text = OldPassword Then
            MessageBox.Show("No puedes usar tu actual contraseña como nueva contraseña." & vbNewLine & "Introduce una nueva contraseña para continuar el proceso.", "Se han encontrado coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
End Class