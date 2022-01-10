Public Class frm_int_notacontado
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Private Sub DtpFecha_CloseUp(sender As Object, e As EventArgs) Handles DtpFecha.CloseUp
        txtMonto.Focus()
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        End If
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
            Exit Sub
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Insert.Click
        If frm_facturacion.Visible = True Then

            If CDbl(txtMonto.Text) >= CDbl(frm_facturacion.txtNeto.Text) Then
                MessageBox.Show("La nota de contado excede el total neto a pagar en la factura, verifique el monto introducido.", "Nota mayor que factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            End If

            frm_facturacion.txtCondicionContado.Text = "Antes del " & DtpFecha.Text & " sólo por " & txtMonto.Text
        End If

        If frm_punto_venta_lite.Visible = True Then
            If CDbl(txtMonto.Text) >= CDbl(frm_punto_venta_lite.lblTotalNeto.Text) Then
                MessageBox.Show("La nota de contado excede el total neto a pagar en la factura, verifique el monto introducido.", "Nota mayor que factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            End If

            frm_punto_venta_lite.txtCondicionContado.Text = "Antes del " & DtpFecha.Text & " sólo por " & txtMonto.Text

        End If

        If frm_registro_factura_sd.Visible = True Then
            If CDbl(txtMonto.Text) >= CDbl(frm_registro_factura_sd.txtNeto.Text) Then
                MessageBox.Show("La nota de contado excede el total neto a pagar en la factura, verifique el monto introducido.", "Nota mayor que factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            End If

            frm_registro_factura_sd.txtCondicionContado.Text = "Antes del " & DtpFecha.Text & " sólo por " & txtMonto.Text

        End If

        Close()

    End Sub

    Private Sub frm_int_notacontado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con.Open()

        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=219", Con)
        If Convert.ToInt16(cmd.ExecuteScalar()) = 1 Then
            'Controlar dias de notas de contado
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=220", Con)
            DtpFecha.MaxDate = Today.AddDays(Convert.ToInt16(cmd.ExecuteScalar()))
        End If
        Con.Close()

        btn_Insert.Enabled = False
        DtpFecha.Value = Today
        txtMonto.Clear()
        DtpFecha.Focus()
    End Sub

    Private Sub HabilitarInsert()
        If txtMonto.Text = "" Then
            btn_Insert.Enabled = False
        Else
            btn_Insert.Enabled = True
        End If
    End Sub

    Private Sub frm_int_notacontado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If frm_facturacion.Visible = True Then
            If frm_facturacion.txtCondicionContado.Text = "" Then frm_facturacion.chkHabilitarNota.Checked = False
        ElseIf frm_punto_venta_lite.Visible = True Then
            If frm_punto_venta_lite.txtCondicionContado.Text = "" Then frm_punto_venta_lite.chkHabilitarNota.Checked = False
        ElseIf frm_registro_factura_sd.Visible = True Then
            If frm_registro_factura_sd.txtCondicionContado.Text = "" Then frm_registro_factura_sd.chkHabilitarNota.Checked = False
        End If
    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged
        HabilitarInsert()
    End Sub
End Class