Public Class frm_articulos_noaplicatarjeta
    Private Sub frm_articulos_noaplicatarjeta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DgvArticulos.Rows.Clear()
    End Sub

    Private Sub frm_articulos_noaplicatarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        DgvArticulos.ClearSelection()
    End Sub
End Class