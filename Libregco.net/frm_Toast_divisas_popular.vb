Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing

Public Class frm_toast_divisas_popular
    Dim ex, ey As Integer
    Dim Arrastre As Boolean
    Dim TimerClosed As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim OpenedToast As Integer = 0
        For Each frm As Form In My.Application.OpenForms
            If frm.Name.Contains("Toast") Then
                OpenedToast = OpenedToast + 1
            End If
        Next

        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        WebBrowserUpdater.FixBrowserVersion()

        If My.Computer.Network.IsAvailable = True Then
            PicDivisaLoading.Visible = True
            WebBrowser1.Navigate("https://www.popularenlinea.com/personas/Paginas/Home.aspx")
        Else
            Label42.Visible = True
            LinkLabel3.Visible = True
        End If

    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs)
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs)

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ex, MousePosition.Y - Me.Location.Y - ey))

    End Sub

    Private Sub PictureBox2_MouseUp(sender As Object, e As MouseEventArgs)
        Arrastre = False
    End Sub

    Private Sub frm_toast_divisas_popular_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim HeightLocation As Integer = Screen.PrimaryScreen.WorkingArea.Height
        For Each frm As Form In My.Application.OpenForms
            If frm.Name.Contains("Toast") Then
                HeightLocation = HeightLocation - frm.Height - 2
                frm.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, HeightLocation)
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimerClosed = TimerClosed + 1

        If CInt(TimerClosed) >= 8 Then
            Me.Close()
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Try
            lblCompraUSD.Text = WebBrowser1.Document.GetElementById("mobileBuyUsd").InnerText
            lblVentaUSD.Text = WebBrowser1.Document.GetElementById("mobileSellUsd").InnerText
            lblCompraEU.Text = WebBrowser1.Document.GetElementById("mobileBuyEur").InnerText
            lblVentaEU.Text = WebBrowser1.Document.GetElementById("mobileSellEur").InnerText

            Label12.Text = Today.ToLongDateString & " " & Now.ToString("hh:mm:ss tt")
            PicDivisaLoading.Visible = False
            Label42.Visible = False
            LinkLabel3.Visible = False
            btnClose.Visible = False

            TimerClosed = 1
            Timer1.Enabled = True

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
