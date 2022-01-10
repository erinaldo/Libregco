Public Class frm_cierre_equipos
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(5)


    Private Sub frm_cierre_equipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TargetDT = DateTime.Now.Add(CountDownFrom)
        tmrCountdown.Start()
    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        If ts.TotalMilliseconds > 0 Then
            Label2.Text = ts.ToString("mm\:ss") & " segundos"
        Else
            Label2.Text = "00:00" & " segundos"
            tmrCountdown.Stop()
            Close()
        End If
    End Sub
End Class