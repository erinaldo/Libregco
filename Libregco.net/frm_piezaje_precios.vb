Public Class frm_piezaje_precios
    Friend lblIDPrecio, GuardarAutoPiezaje, GuardarAutoCalculos, RedondearCalculos As String
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand

    Private Sub frm_piezaje_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        CargarConfiguracion
    End Sub

    Private Sub btnPietaje_Click(sender As Object, e As EventArgs) Handles btnPietaje.Click
        If CDbl(txtPiezaje.EditValue) <> 0 Then
            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If

            ConLibregco.Open()
            cmd = New MySqlCommand("UPDATE precioarticulo SET Piezaje='" + txtPiezaje.EditValue.ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If CDbl(txtPiezaje.EditValue) <> 0 Then
            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
            Con.Close()


            ConLibregco.Open()
            cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(txtCosto.EditValue).ToString + "',PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "',Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "',Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.EditValue)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio + ")", ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

            frm_mant_articulos.RefrescarTablaHistorialPrecios()
        End If

    End Sub

    Private Sub CargarConfiguracion()
        ConMixta.Open()

        cmd = New MySqlCommand("SELECT Value2Int FROM" & SysName.Text & "Configuracion WHERE IDConfiguracion=191", ConMixta)
        chkGuardarAutPietaje.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("SELECT Value2Int FROM" & SysName.Text & "Configuracion WHERE IDConfiguracion=192", ConMixta)
        chkRedondear.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("SELECT Value2Int FROM" & SysName.Text & "Configuracion WHERE IDConfiguracion=193", ConMixta)
        chkGuardarCalculos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        ConMixta.Close()
    End Sub

    Private Sub txtCosto_EditValueChanged(sender As Object, e As EventArgs) Handles txtCosto.EditValueChanged
        If chkGuardarCalculos.Checked Then
            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
            Con.Close()

            ConLibregco.Open()
            cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET CostoFinal='" + CDbl(txtCosto.EditValue).ToString + "',Costo='" + CDbl(txtCosto.EditValue).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.EditValue)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio + ")", ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        End If
    End Sub


    Private Sub txtPrecioA_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecioA.EditValueChanged
        If chkGuardarCalculos.Checked = True Then
            If CDbl(txtPiezaje.EditValue) <> 0 Then
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If

        End If

    End Sub

    Private Sub txtPrecioC_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecioC.EditValueChanged
        If chkGuardarCalculos.Checked = True Then
            If CDbl(txtPiezaje.EditValue) <> 0 Then
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If
        End If
    End Sub

    Private Sub txtPrecioD_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecioD.EditValueChanged
        If chkGuardarCalculos.Checked = True Then
            If CDbl(txtPiezaje.EditValue) <> 0 Then
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If
        End If
    End Sub

    Private Sub chkGuardarAutPietaje_CheckedChanged(sender As Object, e As EventArgs) Handles chkGuardarAutPietaje.CheckedChanged
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGuardarAutPietaje.Checked).ToString + "' Where IDConfiguracion=191", Con)
        cmd.ExecuteNonQuery()
        Con.Close()

        If chkGuardarAutPietaje.Checked = True Then
            If CDbl(txtPiezaje.EditValue) <> 0 Then
                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(txtCosto.EditValue).ToString + "',PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "',Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "',Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.EditValue)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio + ")", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If

        End If
    End Sub

    Private Sub chkRedondear_CheckedChanged(sender As Object, e As EventArgs) Handles chkRedondear.CheckedChanged
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkRedondear.Checked).ToString + "' Where IDConfiguracion=192", Con)
        cmd.ExecuteNonQuery()
        Con.Close()

        If chkRedondear.Checked = True Then
            txtCosto.EditValue = RoundUp(CDbl(CDbl(lblCosto.Tag) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
            txtPrecio.EditValue = RoundUp(CDbl(CDbl(lblPrecio.Tag) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
            txtPrecioA.EditValue = RoundUp(CDbl(CDbl(PA.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
            txtPrecioB.EditValue = RoundUp(CDbl(CDbl(PB.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
            txtPrecioC.EditValue = RoundUp(CDbl(CDbl(PC.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
            txtPrecioD.EditValue = RoundUp(CDbl(CDbl(PD.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))

            lblCosto.Text = "Costo: " & CDbl(lblCosto.Tag).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & lblMedidaPadre.Tag.ToString.ToUpper & "</B></color></u>" & " (" & txtPiezaje.Text & " x " & CDbl(lblCosto.Tag).ToString("C") & ")"
            lblPrecio.Text = "Precio: " & CDbl(lblPrecio.Tag).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & lblMedidaPadre.Tag.ToString.ToUpper & "</B></color></u>" & " (" & txtPiezaje.Text & " x " & CDbl(lblPrecio.Tag).ToString("C") & ")"

            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If

            If CDbl(txtPiezaje.EditValue) <> 0 Then
                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(txtCosto.EditValue).ToString + "',PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "',Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "',Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.EditValue)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio + ")", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If

        End If
    End Sub

    Private Sub chkGuardarCalculos_CheckedChanged(sender As Object, e As EventArgs) Handles chkGuardarCalculos.CheckedChanged
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkGuardarCalculos.Checked).ToString + "' Where IDConfiguracion=193", Con)
        cmd.ExecuteNonQuery()
        Con.Close()
    End Sub

    Private Sub txtPrecioB_EditValueChanged(sender As Object, e As EventArgs) Handles txtPrecioB.EditValueChanged
        If chkGuardarCalculos.Checked = True Then

            If CDbl(txtPiezaje.EditValue) <> 0 Then
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If

                Con.Open()
                CheckedUptadesinPrinces(lblIDPrecio, CDbl(txtCosto.EditValue), CDbl(txtCosto.EditValue), CDbl(txtPrecioA.EditValue), CDbl(txtPrecioB.EditValue), CDbl(txtPrecioC.EditValue), CDbl(txtPrecioD.EditValue))
                Con.Close()

                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If

        End If
    End Sub

    Private Sub frm_piezaje_precios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frm_mant_articulos.RefrescarTablaPrecios()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub txtPiezaje_EditValueChanged(sender As Object, e As EventArgs) Handles txtPiezaje.EditValueChanged
        Try
            If IsNumeric(txtPiezaje.EditValue) Then
                If txtPiezaje.EditValue <> 0 Then
                    txtCosto.EditValue = RoundUp(CDbl(CDbl(lblCosto.Tag) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
                    txtPrecio.EditValue = RoundUp(CDbl(CDbl(lblPrecio.Tag) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
                    txtPrecioA.EditValue = RoundUp(CDbl(CDbl(PA.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
                    txtPrecioB.EditValue = RoundUp(CDbl(CDbl(PB.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
                    txtPrecioC.EditValue = RoundUp(CDbl(CDbl(PC.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))
                    txtPrecioD.EditValue = RoundUp(CDbl(CDbl(PD.Text) * CDbl(txtPiezaje.EditValue)), Convert.ToInt16(chkRedondear.Checked))

                    lblCosto.Text = "Costo: " & CDbl(lblCosto.Tag).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & lblMedidaPadre.Tag.ToString.ToUpper & "</B></color></u>" & " (" & txtPiezaje.Text & " x " & CDbl(lblCosto.Tag).ToString("C") & ")"
                    lblPrecio.Text = "Precio: " & CDbl(lblPrecio.Tag).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & lblMedidaPadre.Tag.ToString.ToUpper & "</B></color></u>" & " (" & txtPiezaje.Text & " x " & CDbl(lblPrecio.Tag).ToString("C") & ")"

                    If chkGuardarAutPietaje.Checked = True Then
                        If CDbl(txtPiezaje.EditValue) <> 0 Then
                            If ConLibregco.State = ConnectionState.Open Then
                                ConLibregco.Close()
                            End If

                            ConLibregco.Open()
                            cmd = New MySqlCommand("UPDATE precioarticulo SET Piezaje='" + txtPiezaje.EditValue.ToString + "' WHERE IDPrecios='" + lblIDPrecio + "'", ConLibregco)
                            cmd.ExecuteNonQuery()
                            ConLibregco.Close()
                        End If

                    End If
                End If
            End If

            If CDbl(txtPiezaje.EditValue) = 0 Then
                lblStatusBar.ForeColor = Color.Red
                  lblStatusBar.Text = "Las informaciones no se guardaran con un valor 0."
            Else
                lblStatusBar.ForeColor = Color.Black
                lblStatusBar.Text = "Listo."
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class