Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cambiar_precio_lite
    Dim CnString As String = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=libregco")

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds = New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDPrecio, lblPrecioLista, lblIDMedida, lblItbisArt, lblDescuento As New Label


    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        If txtPrecio.Text = "" Then
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text)
        End If
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub btnInsertarPrecio_Click(sender As Object, e As EventArgs) Handles btnInsertarPrecio.Click
        Dim NuevoPrecio As Double = (CDbl(txtPrecio.Text)).ToString("C")
     
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Itbis from Articulos INNER JOIN TipoItbis ON Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
        lblItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()

        'frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(8).Value = (NuevoPrecio / (CDbl(1) + CDbl(lblItbisArt.Text))).ToString("C")

        If NuevoPrecio < CDbl(txtPrecioActual.Text) Then
            frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(9).Value = ((CDbl(frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(8).Value) - (NuevoPrecio / (CDbl(1) + CDbl(lblItbisArt.Text)))) * (CDbl(frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(6).Value))).ToString("C")
        Else
            frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
        End If

        frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(10).Value = ((NuevoPrecio - (NuevoPrecio / (CDbl(1) + CDbl(lblItbisArt.Text)))) * CDbl(frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(6).Value)).ToString("C")
        frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(11).Value = (NuevoPrecio * CDbl(frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(6).Value)).ToString("C")
        frm_punto_venta_lite.SumTotales()

        Close()
    End Sub


    Private Sub frm_cambiar_precio_lite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
    End Sub

    Private Sub CargarLibregco()
          PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        Dim DsPrecios As New DataSet
        Dim CostoFinal, VenderCosto, DescuentoMaximo, PrecioMinimoA, PrecioMinimoB As New Label

        If txtIDArticulo.Text <> "" And lblIDMedida.Text <> "" Then
            ConLibregco.Open()                      'Busco los precios predeterminados
            cmd = New MySqlCommand("SELECT Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4 FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo= '" + txtIDArticulo.Text + "' AND PrecioArticulo.IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsPrecios, "Precios")
            ConLibregco.Close()

            Dim Tabla As DataTable = DsPrecios.Tables("Precios")

            DescuentoMaximo.Text = Tabla.Rows(0).Item("DescuentoMaximo")
            PrecioMinimoA.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")) - (CDbl(Tabla.Rows(0).Item("PrecioCredito")) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo")))
            PrecioMinimoB.Text = CDbl(Tabla.Rows(0).Item("PrecioContado")) - (CDbl(Tabla.Rows(0).Item("PrecioContado")) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo")))

            If IsNumeric(txtPrecio.Text) Then
                If frm_punto_venta_lite.FactDebajoCosto = 1 Then         'Si puedo facturar por debajo del costo 
                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                    If txtNivelPrecio.Text = "A" Then
                        lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                    ElseIf txtNivelPrecio.Text = "B" Then
                        lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                    End If
                Else
                    'Verifico si el articulo se puede vender al costo
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT VenderCosto FROM Articulos Where IDArticulo='" + txtIDArticulo.Text + "'", ConLibregco)
                    VenderCosto.Text = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    If VenderCosto.Text = 1 Then    'Si se puede vender al costo
                        If CDbl(txtPrecio.Text) >= CDbl(Tabla.Rows(0).Item("CostoFinal")) Then
                            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                        Else
                            MessageBox.Show("El precio establecido excede el costo del producto." & vbNewLine & vbNewLine & "El artículo está autorizado y disponible para venderse al costo, por un monto de: " & CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C") & ".", "Exceso del precio introducido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            txtPrecio.Text = CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C")
                            If txtNivelPrecio.Text = "A" Then
                                lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                            ElseIf txtNivelPrecio.Text = "B" Then
                                lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                            End If
                        End If

                    Else
                        'Si el precio se puede vender al costo no hago nada, aún cuando no se puede facturar al costo.
                        If txtNivelPrecio.Text = "A" Then
                            If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoA.Text) Then
                                MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioCredito")).ToString("C")
                                txtPrecio.Focus()
                            Else
                                txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                If txtPrecio.Text < (Tabla.Rows(0).Item("PrecioCredito")) Then
                                    lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioCredito")) - CDbl(txtPrecio.Text)).ToString("C")
                                Else
                                    lblDescuento.Text = CDbl(0).ToString("C")
                                End If

                            End If
                        ElseIf txtNivelPrecio.Text = "B" Then
                            If CDbl(txtPrecio.Text) < CDbl(PrecioMinimoB.Text) Then
                                MessageBox.Show("El precio aplicado está por debajo del descuento máximo permitido.", "El precio dado ha excedido el descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                txtPrecio.Text = CDbl(Tabla.Rows(0).Item("PrecioContado")).ToString("C")
                                txtPrecio.Focus()
                            Else
                                txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                If txtPrecio.Text < (Tabla.Rows(0).Item("PrecioCredito")) Then
                                    lblDescuento.Text = (CDbl(Tabla.Rows(0).Item("PrecioContado")) - CDbl(txtPrecio.Text)).ToString("C")
                                Else
                                    lblDescuento.Text = CDbl(0).ToString("C")
                                End If
                            End If
                        Else
                            If txtNivelPrecio.Text = "C" Then
                                If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Precio3")) Then
                                    MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Precio3")).ToString("C")
                                Else
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                End If
                                lblDescuento.Text = CDbl(0).ToString("C")
                            ElseIf txtNivelPrecio.Text = "D" Then
                                If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Precio4")) Then
                                    MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Precio4")).ToString("C")
                                Else
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                End If
                                lblDescuento.Text = CDbl(0).ToString("C")
                            ElseIf txtNivelPrecio.Text = "E" Then
                                If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("Costo")) Then
                                    MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Costo")).ToString("C")
                                Else
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                End If
                                lblDescuento.Text = CDbl(0).ToString("C")
                            ElseIf txtNivelPrecio.Text = "F" Then
                                If CDbl(txtPrecio.Text) < CDbl(Tabla.Rows(0).Item("CostoFinal")) Then
                                    MessageBox.Show("No es posible hacer descuentos extras en los precios C,D,E y F.", "Los niveles de precios han sido excedidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    txtPrecio.Text = CDbl(Tabla.Rows(0).Item("CostoFinal")).ToString("C")
                                Else
                                    txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
                                End If
                                lblDescuento.Text = CDbl(0).ToString("C")
                            End If
                        End If
                    End If
                End If

            End If

        Else
            txtPrecio.Text = CDbl(0).ToString("C")
        End If

        lblDescuento.Text = CDbl(lblDescuento.Text).ToString("C")
    End Sub
End Class