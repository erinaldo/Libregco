Public Class frm_alerta_tipocomprobante
    Dim Counter As Integer = 0
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If Me.Owner.Name = frm_prefacturacion_detalles.Name Then
            frm_prefacturacion_detalles.txtIDNcf.Text = lblComprobanteRecomendado.Tag
            frm_prefacturacion_detalles.txtTipoNcf.Text = lblComprobanteRecomendado.Text

        ElseIf Me.Owner.Name = frm_cierre_facturas.name Then
            frm_facturacion.CbxTipoComprobante.Text = lblComprobanteRecomendado.Text
            frm_facturacion.CbxTipoComprobante.Tag = lblComprobanteRecomendado.Tag
        End If

        Me.Close()

    End Sub

    Private Sub frm_alerta_tipocomprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False
        Me.CenterToParent()
        Me.Focus()
        Counter = 0
        Timer1.Enabled = True
        Label1.ForeColor = Color.Black
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Counter += 1

        Label1.Text = "El tiempo de espera es de " & 5 - Counter & " segundo(s)..."

        If Counter > 4 Then
            SimpleButton1.Enabled = True
            SimpleButton2.Enabled = True
            Timer1.Enabled = False
            Counter = 0
            Label1.Text = "Haga la elección del comprobante fiscal correcto para la transacción"
            Label1.ForeColor = SystemColors.Highlight
        End If
    End Sub
End Class