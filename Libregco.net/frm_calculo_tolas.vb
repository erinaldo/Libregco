Public Class frm_calculo_tolas
    Dim TablaTolas As DataTable = New DataTable("Tolas")
    Private Sub frm_calculo_tolas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillTablaTolas()

        cbxMedida.SelectedIndex = 0
        txtDescripcion.EditValue = ""
        txtAncho.EditValue = 0
        txtLargo.EditValue = 0
        txtPrecio.EditValue = 0
        txtValor.EditValue = 0
        txtImporte.EditValue = 0
        txtCantidadLibras.EditValue = 0
        txtCantidad.EditValue = 1



        txtAncho.Focus()

    End Sub

    Private Sub FillTablaTolas()
        TablaTolas.Clear()
        TablaTolas.Columns.Clear()

        TablaTolas.Columns.Add("ID", System.Type.GetType("System.Double"))
        TablaTolas.Columns.Add("Pulgadas", System.Type.GetType("System.String"))
        TablaTolas.Columns.Add("Pies", System.Type.GetType("System.String"))
        TablaTolas.Columns.Add("Grosor", System.Type.GetType("System.String"))
        TablaTolas.Columns.Add("LibrasxPie2", System.Type.GetType("System.String"))

        TablaTolas.Rows.Add("1", "24", "2", "1/16", "2.5")
        TablaTolas.Rows.Add("2", "36", "3", "3/32", "3.53")
        TablaTolas.Rows.Add("3", "48", "4", "1/8", "5.1")
        TablaTolas.Rows.Add("4", "60", "5", "3/16", "7.53")
        TablaTolas.Rows.Add("5", "72", "6", "1/4", "10.2")
        TablaTolas.Rows.Add("6", "96", "8", "3/8", "15.3")
        TablaTolas.Rows.Add("7", "120", "10", "1/2", "20.4")
        TablaTolas.Rows.Add("8", "144", "12", "5/8", "25.5")
        TablaTolas.Rows.Add("9", "168", "14", "3/4", "30.6")
        TablaTolas.Rows.Add("10", "216", "18", "1", "40.8")
        'GridControl1.DataSource = TablaTolas

        LUEGrosor.Properties.DataSource = TablaTolas
        LUEGrosor.Properties.ValueMember = "ID"
        LUEGrosor.Properties.DisplayMember = "Grosor"

        LUEGrosor.Properties.PopulateColumns()
        LUEGrosor.Properties.Columns(LUEGrosor.Properties.ValueMember).Visible = False


        If TablaTolas.Rows.Count > 0 Then
            LUEGrosor.ItemIndex = 0
        End If

    End Sub

    Private Sub CalcularPrecio()
        If CDbl(txtLargo.EditValue) = 0 Then
            Exit Sub
        ElseIf CDbl(txtAncho.EditValue) = 0 Then
            Exit Sub
        ElseIf CDbl(txtPrecio.EditValue) = 0 Then
            Exit Sub
        End If

        If cbxMedida.Text = "Pulgadas" Then
            txtDescripcion.EditValue = "TOLA " & txtAncho.EditValue & Chr(34) & " X " & txtLargo.EditValue & Chr(34) & " - " & LUEGrosor.GetColumnValue("Grosor").ToString

            If CheckEdit1.CheckState = CheckState.Checked Then
                txtValor.EditValue = Math.Round(CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue)) / 144) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2"))) * CDbl(txtPrecio.EditValue), 0)
            Else
                txtValor.EditValue = CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue)) / 144) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2"))) * CDbl(txtPrecio.EditValue)
            End If

            txtCantidadLibras.EditValue = CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue)) / 144) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2")))

        ElseIf cbxMedida.Text = "Pies" Then
            txtDescripcion.EditValue = "TOLA " & txtAncho.EditValue & " PIE" & " X " & txtLargo.EditValue & " PIE" & " - " & LUEGrosor.GetColumnValue("Grosor").ToString


            If CheckEdit1.CheckState = CheckState.Checked Then
                txtValor.EditValue = Math.Round(CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue))) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2"))) * CDbl(txtPrecio.EditValue), 0)
            Else
                txtValor.EditValue = CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue))) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2"))) * CDbl(txtPrecio.EditValue)
            End If

            txtCantidadLibras.EditValue = CDbl(CDbl((CDbl(txtAncho.EditValue) * CDbl(txtLargo.EditValue))) * CDbl(LUEGrosor.GetColumnValue("LibrasxPie2")))
        End If

        txtImporte.EditValue = CDbl(txtCantidad.EditValue) * CDbl(txtValor.EditValue)

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles txtAncho.EditValueChanged
        CalcularPrecio()
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles txtLargo.EditValueChanged
        CalcularPrecio()
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecio.EditValueChanged
        CalcularPrecio()
    End Sub

    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles LUEGrosor.EditValueChanged
        CalcularPrecio()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            If CDbl(txtAncho.EditValue) = 0 Then
                txtAncho.Focus()
                txtAncho.SelectAll()
                Exit Sub
            ElseIf CDbl(txtLargo.EditValue) = 0 Then
                txtLargo.Focus()
                txtLargo.SelectAll()
                Exit Sub
            ElseIf CDbl(txtPrecio.EditValue) = 0 Then
                txtPrecio.Focus()
                txtPrecio.SelectAll()
                Exit Sub
            End If

            If Me.Owner.Name = frm_prefacturacion.Name Then
                frm_prefacturacion.txtCantidadArticulo.Text = txtCantidad.EditValue
                frm_prefacturacion.txtDescripcionArticulo.Text = txtDescripcion.EditValue
                frm_prefacturacion.txtPrecio.Text = CDbl(txtValor.EditValue).ToString("c2")
                frm_prefacturacion.SumarTotalArticulo()

            ElseIf Me.Owner.Name = frm_facturacion.Name Then
                frm_facturacion.txtCantidadArticulo.Text = txtCantidad.EditValue
                frm_facturacion.txtDescripcionArticulo.Text = txtDescripcion.EditValue
                frm_facturacion.txtPrecio.Text = CDbl(txtValor.EditValue).ToString("c2")
                frm_facturacion.SumarTotalArticulo()

            ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                frm_cotizacion.txtCantidadArticulo.Text = txtCantidad.EditValue
                frm_cotizacion.txtDescripcionArticulo.Text = txtDescripcion.EditValue
                frm_cotizacion.txtPrecio.Text = CDbl(txtValor.EditValue).ToString("c2")
                frm_cotizacion.SumarTotalArticulo()

            ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Focus()
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Cantidad", txtCantidad.EditValue)
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Descripcion", txtDescripcion.Text)
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Precio", CDbl(txtValor.EditValue))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Importe", CDbl(CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Cantidad")))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("PrecioSinItbis", CDbl(CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - CDbl(CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc"))) / (1 + CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetFocusedRowCellValue("Itbis", (CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) - ((CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) - (CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("Precio")) * CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("DescuentoPorc")))) / (1 + CDbl(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.GetFocusedRowCellValue("PorcItbis")))))





            End If

            txtAncho.Focus()

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frm_calculo_tolas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtLargo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLargo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAncho_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAncho.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAncho_Enter(sender As Object, e As EventArgs) Handles txtAncho.Enter
        txtAncho.SelectAll()

    End Sub

    Private Sub txtLargo_Enter(sender As Object, e As EventArgs) Handles txtLargo.Enter
        txtLargo.SelectAll()
    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        txtPrecio.SelectAll()
    End Sub

    Private Sub txtCantidad_EditValueChanged(sender As Object, e As EventArgs) Handles txtCantidad.EditValueChanged
        If txtCantidad.EditValue <= 0 Then
            txtCantidad.EditValue = 1
        End If

        CalcularPrecio()
    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
        txtCantidad.SelectAll()
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LUEGrosor_KeyDown(sender As Object, e As KeyEventArgs) Handles LUEGrosor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LUEGrosor_Enter(sender As Object, e As EventArgs) Handles LUEGrosor.Enter
        LUEGrosor.ShowPopup()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        CalcularPrecio()
    End Sub

    Private Sub cbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedida.SelectedIndexChanged
        CalcularPrecio()
    End Sub
End Class