Imports System.Drawing

Public Class Slider
    Dim asd As Boolean
    Dim xs As Integer
    Dim dsa As Integer
    Public Sety As Boolean
    Public SetyInteger As Integer


    Private Sub Button1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        asd = True
        Dim MousePosition As Point
        MousePosition = Windows.Forms.Cursor.Position
        xs = MousePosition.X
    End Sub

    Private Sub Button1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        If asd = True Then
            Dim MousePosition As Point
            MousePosition = Windows.Forms.Cursor.Position
            dsa = MousePosition.X
            Dim movem As Integer

            If dsa < xs Then
                movem = (xs - dsa)
                If Button1.Left <= PictureBox1.Left Then
                    Button1.Left = PictureBox1.Left
                Else
                    Button1.Left = Button1.Left - movem
                End If

            ElseIf dsa > xs Then
                movem = (dsa - xs)
                If (Button1.Left + Button1.Width) >= (PictureBox1.Left + PictureBox1.Width) Then
                    Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
                Else
                    Button1.Left = Button1.Left + movem
                End If
            End If
            xs = MousePosition.X
        End If

        CheckSetyColor()
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        asd = False
        Dim midimage As Integer
        Dim midbutt As Integer
        midbutt = (Button1.Width / 2)
        midimage = (PictureBox1.Width / 2)
        midbutt = Button1.Left + midbutt
        midimage = PictureBox1.Left + midimage

        If midbutt <= midimage Then
            Button1.Left = PictureBox1.Left
            Sety = False
            SetyInteger = 0
        End If

        If midbutt > midimage Then
            Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
            Sety = True
            SetyInteger = 1
        End If

        CheckSetyColor()
    End Sub

    Public Sub Onme()
        Button1.Left = (PictureBox1.Left + PictureBox1.Width) - Button1.Width
        Sety = True
        SetyInteger = 1
        CheckSetyColor()
    End Sub

    Public Sub Offme()
        Button1.Left = PictureBox1.Left
        Sety = False
        SetyInteger = 0
        CheckSetyColor()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Button1.Left = PictureBox1.Left Then
            Sety = True
            SetyInteger = 1
            Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)

        Else
            Sety = False
            SetyInteger = 0
            Button1.Left = PictureBox1.Left
        End If
        CheckSetyColor()
    End Sub

    Private Sub PictureBox_Click(Sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If Button1.Left = PictureBox1.Left Then
            Sety = True
            SetyInteger = 1
            Button1.Left = ((PictureBox1.Left + PictureBox1.Width) - Button1.Width)
        Else
            Sety = False
            SetyInteger = 0
            Button1.Left = PictureBox1.Left
        End If
        CheckSetyColor()
    End Sub

    Private Sub CheckSetyColor()
        If Sety = False Then
            PictureBox1.BackColor = SystemColors.ActiveBorder
        Else
            PictureBox1.BackColor = Color.LimeGreen
        End If
    End Sub

End Class
