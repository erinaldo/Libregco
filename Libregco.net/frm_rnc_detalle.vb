Public Class frm_rnc_detalle

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub frm_rnc_detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        If Me.Owner.Name = frm_consulta_rnc.Name Then
            txtRNC.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(0).Value
            txtRepresentante.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(1).Value
            txtEstablecimiento.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(2).Value
            txtRazon.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(3).Value
            txtDireccion.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(4).Value
            txtNumero.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(5).Value
            txtSector.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(6).Value
            txtTelefono.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(7).Value
            txtFecha.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(8).Value
            txtEstado.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(9).Value
            txtTipo.Text = frm_consulta_rnc.DgvResultados.CurrentRow.Cells(10).Value
        End If
    End Sub
End Class