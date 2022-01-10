Public Class frm_mdi_prefacturacion
    Private Sub frm_mdi_prefacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.Size.Width, My.Computer.Screen.Bounds.Size.Height - 100)
        Me.CenterToScreen()

        If XtraTabbedMdiManager1.Pages.Count = 0 Then
            Dim F As New frm_prefacturacion_new
            F.MdiParent = Me
            F.Text = F.txtNombre.Text & " (" & CDbl(F.AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C") & ")"
            F.Name = Now.ToString
            F.Show()
        End If
    End Sub

    Private Sub frm_mdi_prefacturacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If XtraTabbedMdiManager1.Pages.Count > 0 Then
        '    For Each oChild As Form In Me.MdiChildren
        '        If DirectCast(oChild, frm_prefacturacion_new).txtIDFactura.Text <> "" Then

        '        End If

        '    Next
        'End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New frm_prefacturacion_new
        F.MdiParent = Me
        F.Text = F.txtNombre.Text & " (" & CDbl(F.AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C") & ")"
        F.Name = Now.ToString
        F.Show()
    End Sub

    Private Sub XtraTabbedMdiManager1_PageRemoved(sender As Object, e As XtraTabbedMdi.MdiTabPageEventArgs) Handles XtraTabbedMdiManager1.PageRemoved
        If XtraTabbedMdiManager1.Pages.Count = 0 Then
            Dim F As New frm_prefacturacion_new
            F.MdiParent = Me
            F.Text = F.txtNombre.Text & " (" & CDbl(F.AdvBandedGridView1.Columns("Importe").SummaryItem.SummaryValue).ToString("C") & ")"
            F.Name = Now.ToString
            F.Show()
        End If
    End Sub
End Class