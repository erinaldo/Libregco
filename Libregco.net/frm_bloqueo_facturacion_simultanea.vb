Public Class frm_bloqueo_facturacion_simultanea
    Private Sub frm_bloqueo_facturacion_simultanea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Owner.Name = frm_facturacion.Name Then
            Label1.Text = "Se ha detectado que el cliente posee facturaciones simultáneas." & vbNewLine & vbNewLine & "Por favor reviste la integridad del historial del cliente para continuar con el procedimiento actual."
            Label2.Visible = True
            Label3.Visible = True
        Else
            Label1.Text = "Se ha detectado que el cliente posee facturaciones simultáneas." & vbNewLine & vbNewLine & "Verifique el sistema para realizar los pagos apropiadamente a la antiguedad de las cuentas por cobrar."
            Label2.Visible = False
            Label3.Visible = False
        End If
    End Sub
End Class