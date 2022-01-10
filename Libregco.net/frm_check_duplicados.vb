Public Class frm_check_duplicados
    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub frm_check_duplicados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlSuperClave = 1
        btnCancelar.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ControlSuperClave = 0
        Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ControlSuperClave = 1
        Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ControlSuperClave = 1
        Close()
    End Sub

    Private Sub lblEncabezado_MouseDown(sender As Object, e As MouseEventArgs) Handles lblEncabezado.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub lblEncabezado_MouseUp(sender As Object, e As MouseEventArgs) Handles lblEncabezado.MouseUp
        Arrastre = False
    End Sub

    Private Sub lblEncabezado_MouseMove(sender As Object, e As MouseEventArgs) Handles lblEncabezado.MouseMove
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ex, MousePosition.Y - Me.Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))

    End Sub
End Class