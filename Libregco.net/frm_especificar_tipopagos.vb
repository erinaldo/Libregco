Public Class frm_especificar_tipopagos
    Dim CantidadSegundos As Integer = 0
    Dim Counter As Integer = 0
    Dim cmd As MySqlCommand

    Private Sub frm_especificar_tipopagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarConfiguracion()

        If CantidadSegundos = 0 Then
            Button1.Enabled = True
        Else
            Counter = 0
            Button1.Enabled = False
            Timer1.Enabled = True
        End If

        Me.Activate()
        rdbMixto.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Owner.Name = frm_prefacturacion.Name Then
            If rdbEfectivo.Checked = True Then
                frm_prefacturacion.btnControlTipoPago.Tag = 1
                frm_prefacturacion.btnControlTipoPago.Image = My.Resources.dollar_iconx90
                frm_prefacturacion.btnControlTipoPago.Text = "Pago Efectivo"

            ElseIf rdbTarjeta.Checked = True Then
                If CInt(DTConfiguracion.Rows(150 - 1).Item("Value2Int")) = 1 Then
                    frm_creditcard_notallowed.ShowDialog(Me)
                    Exit Sub
                End If

                frm_prefacturacion.btnControlTipoPago.Tag = 2
                frm_prefacturacion.btnControlTipoPago.Image = My.Resources.creditcardx90
                frm_prefacturacion.btnControlTipoPago.Text = "Pago Tarjeta"

            ElseIf rdbMixto.Checked = True Then
                frm_prefacturacion.btnControlTipoPago.Tag = 3
                frm_prefacturacion.btnControlTipoPago.Image = My.Resources.Facturacion_x90
                frm_prefacturacion.btnControlTipoPago.Text = "Pago Mixto / Otros"
            End If

            frm_prefacturacion.TipoPagoMostrado = True
            frm_prefacturacion.txtCodigoArticulo.Focus()
            Me.Close()

        ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
            If rdbEfectivo.Checked = True Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 1
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.dollar_iconx90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Efectivo"

            ElseIf rdbTarjeta.Checked = True Then
                If CInt(DTConfiguracion.Rows(150 - 1).Item("Value2Int")) = 1 Then
                    frm_creditcard_notallowed.ShowDialog(Me)
                    Exit Sub
                End If

                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 2
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.creditcardx90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Tarjeta"

            ElseIf rdbMixto.Checked = True Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Tag = 3
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.ImageOptions.LargeImage = My.Resources.Facturacion_x90
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).btnControlTipoPago.Caption = "Pago Mixto / Otros"
            End If

            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).TipoPagoMostrado = True
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Focus()
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.FocusedColumn = DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Columns("Busqueda")
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.ShowEditor()
            DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).FillPrecios()

            Me.Close()



            'If rdbEfectivo.Checked = True Then
            '    frm_prefacturacion_new.btnControlTipoPago.Tag = 1
            '    frm_prefacturacion_new.btnControlTipoPago.Image = My.Resources.dollar_iconx90
            '    frm_prefacturacion_new.btnControlTipoPago.Text = "Pago Efectivo"

            'ElseIf rdbTarjeta.Checked = True Then
            '    If CInt(DTConfiguracion.Rows(150 - 1).Item("Value2Int")) = 1 Then
            '        frm_creditcard_notallowed.ShowDialog(Me)
            '        Exit Sub
            '    End If

            '    frm_prefacturacion_new.btnControlTipoPago.Tag = 2
            '    frm_prefacturacion_new.btnControlTipoPago.Image = My.Resources.creditcardx90
            '    frm_prefacturacion_new.btnControlTipoPago.Text = "Pago Tarjeta"

            'ElseIf rdbMixto.Checked = True Then
            '    frm_prefacturacion_new.btnControlTipoPago.Tag = 3
            '    frm_prefacturacion_new.btnControlTipoPago.Image = My.Resources.Facturacion_x90
            '    frm_prefacturacion_new.btnControlTipoPago.Text = "Pago Mixto / Otros"
            'End If

            'frm_prefacturacion_new.TipoPagoMostrado = True
            'frm_prefacturacion_new.AdvBandedGridView1.Focus()
            'frm_prefacturacion_new.AdvBandedGridView1.FocusedColumn = frm_prefacturacion_new.AdvBandedGridView1.Columns("Busqueda")
            'frm_prefacturacion_new.AdvBandedGridView1.ShowEditor()
            'Me.Close()
        End If

    End Sub

    Private Sub frm_especificar_tipopagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If rdbEfectivo.Checked = True Then

            '    frm_prefacturacion.btnControlTipoPago.Tag = 1
            '    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.dollar_iconx90
            '    frm_prefacturacion.btnControlTipoPago.Text = "Pago Efectivo"

            'ElseIf rdbTarjeta.Checked = True Then
            '    If frm_prefacturacion.BloqueoTarjeta = 1 Then
            '        frm_creditcard_notallowed.ShowDialog(Me)
            '        Exit Sub
            '    End If
            '    frm_prefacturacion.btnControlTipoPago.Tag = 2
            '    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.creditcardx90
            '    frm_prefacturacion.btnControlTipoPago.Text = "Pago Tarjeta"

            'ElseIf rdbMixto.Checked = True Then
            '    frm_prefacturacion.btnControlTipoPago.Tag = 3
            '    frm_prefacturacion.btnControlTipoPago.Image = My.Resources.Facturacion_x90
            '    frm_prefacturacion.btnControlTipoPago.Text = "Pago Mixto/Otros"
            'End If

            'frm_prefacturacion.TipoPagoMostrado = True
            'Me.Close()

            Button1.PerformClick()

        End If
    End Sub



    Private Sub CargarConfiguracion()
        Con.Open()
        'Tiempo de espera de confirmación de tipo de pago
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=174", Con)
        CantidadSegundos = Convert.ToInt16(Convert.ToInt16(cmd.ExecuteScalar()))
        Con.Close()
    End Sub

    Private Sub frm_especificar_tipopagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frm_prefacturacion.txtCodigoArticulo.Focus()
        frm_prefacturacion.txtCodigoArticulo.SelectAll()
    End Sub

    Private Sub rdbMixto_MouseHover(sender As Object, e As EventArgs) Handles rdbMixto.MouseHover
        rdbMixto.Image = My.Resources.Facturacion_x90
        rdbMixto.ForeColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub rdbMixto_MouseLeave(sender As Object, e As EventArgs) Handles rdbMixto.MouseLeave
        If rdbMixto.Checked = False Then
            rdbMixto.Image = My.Resources.Facturacion_x90gray
            rdbMixto.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub rdbEfectivo_MouseHover(sender As Object, e As EventArgs) Handles rdbEfectivo.MouseHover
        rdbEfectivo.Image = My.Resources.dollar_iconx90
        rdbEfectivo.ForeColor = Color.DarkGoldenrod
    End Sub

    Private Sub rdbEfectivo_MouseLeave(sender As Object, e As EventArgs) Handles rdbEfectivo.MouseLeave
        If rdbEfectivo.Checked = False Then
            rdbEfectivo.Image = My.Resources.dollar_iconx90gray
            rdbEfectivo.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub rdbTarjeta_MouseHover(sender As Object, e As EventArgs) Handles rdbTarjeta.MouseHover
        rdbTarjeta.Image = My.Resources.creditcardx90
        rdbTarjeta.ForeColor = Color.Goldenrod
    End Sub

    Private Sub rdbTarjeta_MouseLeave(sender As Object, e As EventArgs) Handles rdbTarjeta.MouseLeave
        If rdbTarjeta.Checked = False Then
            rdbTarjeta.Image = My.Resources.creditcardx90gray
            rdbTarjeta.ForeColor = Color.Gray
        End If

    End Sub

    Private Sub rdbMixto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMixto.CheckedChanged
        If rdbMixto.Checked = True Then
            rdbMixto.Image = My.Resources.Facturacion_x90
            rdbMixto.ForeColor = Color.FromArgb(255, 128, 128)
        Else
            rdbMixto.Image = My.Resources.Facturacion_x90gray
            rdbMixto.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub rdbEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEfectivo.CheckedChanged
        If rdbEfectivo.Checked = True Then
            rdbEfectivo.Image = My.Resources.dollar_iconx90
            rdbEfectivo.ForeColor = Color.DarkGoldenrod
        Else
            rdbEfectivo.Image = My.Resources.dollar_iconx90gray
            rdbEfectivo.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub rdbTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTarjeta.CheckedChanged
        If rdbTarjeta.Checked = True Then
            rdbTarjeta.Image = My.Resources.creditcardx90
            rdbTarjeta.ForeColor = Color.Goldenrod
        Else
            rdbTarjeta.Image = My.Resources.creditcardx90gray
            rdbTarjeta.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label3.ForeColor = Color.Red Then
            Label3.ForeColor = Color.Black
        Else
            Label3.ForeColor = Color.Red
        End If

        Counter += 1

        If Counter >= (CantidadSegundos * 2) Then
            Button1.Enabled = True
        End If
    End Sub
End Class