Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_formadepago

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim txtIDBanco, ControlStatus As New Label
    Friend RutaDocumento As String
    Dim txtIDTipoDocumento As New TextBox
    Dim Billetes() As Double
    Dim ClosingWithButton As Boolean = False
    Dim TablaCobrosAdelantadados As DataTable = New DataTable("CobrosAdelantadados")

    Private Sub frm_formadepago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        Me.CenterToParent()
        Timer1.Enabled = True
        'Me.WindowState = CheckWindowState()
        CargarConfiguracion()
        CargarLibregco()
        LimpiarForm()
        WhileForms()
        LlenarIDs()
        GetBilletes()
        GetPosibilidades()

        NavBarControl1.Focus()
        NavBarGroupControlContainer1.Focus()
        txtEfectivo.Focus()
        txtEfectivo.SelectAll()
        txtTarjeta.Enabled = True

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub GetBilletes()
        If cbxMoneda.EditValue = 1 Then
            Billetes = {"2000", "1000", "500", "200", "100", "50", "25", "10", "5", "1"}
        ElseIf cbxMoneda.EditValue = 2 Then
            Billetes = {"100", "50", "20", "10", "5", "1", "0.50", "0.10", "0.01"}
        End If
    End Sub
    Private Function GetPosibilites(ByVal MontoaCobrar As Double) As ArrayList
        Dim Possibilites As New ArrayList

        For Each bill As Double In Billetes
            'If bill < MontoaCobrar Then
            Dim Resultado As Double = 0

            If ObtenerParteEntera(MontoaCobrar / bill) > 0 Then
                Resultado = ObtenerParteEntera(MontoaCobrar / bill)
            End If

            If ObtenerParteDecimal(MontoaCobrar / bill) > 0 Then
                Resultado += 1
            End If

            If Not Possibilites.Contains(CDbl(bill * Resultado)) Then
                Possibilites.Add(CDbl(bill * Resultado))
            End If
            'End If
        Next

        Possibilites.Sort()
        Possibilites.Reverse()

        Return Possibilites
    End Function

    Private Function ObtenerParteEntera(ByVal value As Double) As Double
        Dim MontoDecimal As Decimal = value
        Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
        Dim Monto As Integer = MontoDecimal - DecimalResult

        Return Monto
    End Function

    Private Function ObtenerParteDecimal(ByVal Value As Double) As Decimal
        Dim MontoDecimal As Decimal = Value
        Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)

        Return DecimalResult
    End Function

    Private Sub GetPosibilidades()
        Dim Arrr As New ArrayList
        Arrr = GetPosibilites(CDbl(txtMontoCobrar.EditValue))

        FlowBotones.Controls.Clear()

        For Each itm As String In Arrr
            Dim btn As New DevExpress.XtraEditors.SimpleButton

            btn.Text = CDbl(itm).ToString("C")
            btn.Size = New Size(120, 44)
            btn.Cursor = Cursors.Hand
            btn.TabStop = False

            AddHandler btn.Click, AddressOf ShowValue
            FlowBotones.Controls.Add(btn)
        Next

        txtEfectivo.Focus()
        txtEfectivo.SelectAll()

        FormatoNavBarEfectivo()
    End Sub

    Private Sub ShowValue(Sendr As Object, e As EventArgs)
        Dim btn As New DevExpress.XtraEditors.SimpleButton
        btn = CType(Sendr, DevExpress.XtraEditors.SimpleButton)

        txtTarjeta.EditValue = 0
        txtCheque.EditValue = 0
        txtDeposito.EditValue = 0
        txtBonos.EditValue = 0
        txtPermuta.EditValue = 0
        txtCobrosAdelantados.EditValue = 0
        txtMontoCredito.EditValue = 0
        txtEfectivo.EditValue = CDbl(btn.Text)
        txtDevuelta.Text = (CDbl(txtEfectivoCobrar.Text) - CDbl(txtMontoCobrar.Text)).ToString("C")
        'txtDevolucionEfectivo.Text = CDbl(txtEfectivo.Text) - CDbl(txtMontoCobrar.Text)
        'txtDevuelta.Text = CDbl(txtEfectivo.Text) - CDbl(txtMontoCobrar.Text)

        'Calculo de devolucion de efectivo
        If CDbl(txtEfectivo.EditValue) = 0 Then
            txtDevolucionEfectivo.EditValue = 0
        Else

            If CDbl(txtEfectivo.Text) <= CDbl(txtMontoCobrar.Text) Then
                txtDevolucionEfectivo.EditValue = 0
            Else
                txtDevolucionEfectivo.Text = (CDbl(txtEfectivo.EditValue) - CDbl(txtMontoCobrar.EditValue)).ToString("C")
            End If
        End If

        btnContinuar.PerformClick()
    End Sub

    Private Sub CargarConfiguracion()
        If CInt(DTConfiguracion.Rows(57 - 1).Item("Value2Int")) = 1 Then
            lblClaseTarjeta.Visible = True
            Label33.Visible = True
            rdbTipoTarjeta.Visible = True
            PictureBox2.Visible = True
            Label15.Visible = True
            txtNoTarjeta.Visible = True
            PictureBox1.Visible = True
            Label14.Visible = True
            Label12.Visible = True
            Label13.Visible = True
            cbxMes.Visible = True
            cbxAño.Visible = True
            PictureBox3.Visible = True
            Label9.Visible = True
            cbxBancoTarjeta.Visible = True
            gcAprobacion.Location = New Point(341, 39)
            gcAprobacion.Enabled = True

            If txtNoTarjeta.Visible = True Then
                NavBarGroupControlContainer4.Height = 150
            Else
                NavBarGroupControlContainer4.Height = 68
            End If
        Else
            lblClaseTarjeta.Visible = False
            Label33.Visible = False
            rdbTipoTarjeta.Visible = False
            PictureBox2.Visible = False
            Label15.Visible = False
            txtNoTarjeta.Visible = False
            PictureBox1.Visible = False
            Label14.Visible = False
            Label12.Visible = False
            Label13.Visible = False
            cbxMes.Visible = False
            cbxAño.Visible = False
            PictureBox3.Visible = False
            Label9.Visible = False
            cbxBancoTarjeta.Visible = False
            gcAprobacion.Location = New Point(341, 0)
            gcAprobacion.Enabled = True
            If txtNoTarjeta.Visible = True Then
                NavBarGroupControlContainer4.Height = 150
            Else
                NavBarGroupControlContainer4.Height = 68
            End If
        End If

        FillTipoMoneda()
        FillCobrosAdelantadosTable()

    End Sub

    Private Sub FillCobrosAdelantadosTable()
        TablaCobrosAdelantadados = New DataTable("CobrosAdelantadados")
        'TablaCobrosAdelantadados.Columns.Clear()

        TablaCobrosAdelantadados.Columns.Add("IDCobrosAdelantados_hijo", System.Type.GetType("System.String"))
        TablaCobrosAdelantadados.Columns.Add("IDCobrosAdelantados", System.Type.GetType("System.String"))
        TablaCobrosAdelantadados.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaCobrosAdelantadados.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaCobrosAdelantadados.Columns.Add("Disponible", System.Type.GetType("System.Double"))
        TablaCobrosAdelantadados.Columns.Add("Utilizar", System.Type.GetType("System.Double"))
        TablaCobrosAdelantadados.Columns.Add("Eliminar", System.Type.GetType("System.Object"))

        GridControl1.DataSource = TablaCobrosAdelantadados
    End Sub


    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LlenarCbx()
        LlenarClaseTarjeta()
        LlenarCbxMeses()
        LlenarCbxAños()
    End Sub

    Private Sub LlenarClaseTarjeta()
        lblClaseTarjeta.Properties.Items.Clear()
        lblClaseTarjeta.Properties.Items.Add("CRÉDITO")
        lblClaseTarjeta.Properties.Items.Add("DÉBITO")
    End Sub

    Private Function GetTipodeTarjeta() As String
        If CDbl(txtTarjeta.EditValue) > 0 Then
            For Each rd As RadioButton In rdbTipoTarjeta.Controls
                If rd.Checked = True Then
                    Return rd.Tag.ToString
                    Exit For
                End If
            Next
        Else
            Return ""
        End If

    End Function

    Private Sub FillTipoMoneda()
        ConLibregco.Open()
        Ds.Clear()
        cbxMoneda.Properties.Items.Clear()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "tipomoneda")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("tipomoneda")

        For Each Fila As DataRow In Tabla.Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem

            nvmoneda.Description = Fila.Item("Texto")
            nvmoneda.Value = Fila.Item("IDTipoMoneda")

            If Fila.Item("IDTipoMoneda") = 1 Then
                nvmoneda.ImageIndex = 0
            ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                nvmoneda.ImageIndex = 1
            ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                nvmoneda.ImageIndex = 2
            End If

            cbxMoneda.Properties.Items.Add(nvmoneda)
        Next

        cbxMoneda.SelectedIndex = 0
    End Sub

    '    'Private Sub LlenarCbxTipoTarjetas()
    '    '    ConLibregco.Open()
    '    '    Ds.Clear()
    '    '    cmd = New MySqlCommand("d where Nulo=0 ORDER BY Descripcion ASC", ConLibregco)
    '    '    Adaptador = New MySqlDataAdapter(cmd)
    '    '    Adaptador.Fill(Ds, "TarjetaTipo")
    '    '    CbxTipoTarjeta.Items.Clear()
    '    '    ConLibregco.Close()

    '    '    Dim Tabla As DataTable = Ds.Tables("TarjetaTipo")
    '    '    For Each Fila As DataRow In Tabla.Rows
    '    '        CbxTipoTarjeta.Items.Add(Fila.Item("Descripcion"))
    '    '    Next
    '    'End Sub
    '    'Private Sub LlenarBancos()
    '    '    ConLibregco.Open()
    '    '    Ds.clear()
    '    '    CbxBanco.Items.Clear()
    '    '    cmd = New MySqlCommand("SELECT Identidad FROM Bancos ORDER BY Identidad ASC", ConLibregco)
    '    '    Adaptador = New MySqlDataAdapter(cmd)
    '    '    Adaptador.Fill(Ds, "Bancos")
    '    '    CbxBanco.Items.Clear()
    '    '    ConLibregco.Close()

    '    '    Dim Tabla As DataTable = Ds.Tables("Bancos")
    '    '    For Each Fila As DataRow In Tabla.Rows
    '    '        CbxBanco.Items.Add(Fila.Item("Identidad"))
    '    '    Next

    '    'End Sub
    Private Sub WhileForms()
        Try
            Dim DsTmp As New DataSet

            If Me.Owner.Name = frm_facturacion.Name Then
                txtIDTipoDocumento.Text = frm_facturacion.lblIDTipoDocumento.Text
                cbxMoneda.EditValue = frm_facturacion.cbxMoneda.EditValue

                If frm_facturacion.lblDiasCondicion.Text = 0 Then
                    txtMontoCobrar.Text = frm_facturacion.txtNeto.Text
                Else
                    txtMontoCobrar.Text = frm_facturacion.txtInicial.Text
                End If

                If frm_facturacion.lblIDTransaccion.Text = "" Then

                    If frm_facturacion.lblDiasCondicion.Text = 0 Then

                        If CInt(DTConfiguracion.Rows(146 - 1).Item("Value2Int")) = 1 Then
                            If frm_facturacion.IDTipopago = 1 Then

                                txtEfectivo.ReadOnly = False
                                txtEfectivo.Text = frm_facturacion.txtNeto.Text

                                txtTarjeta.ReadOnly = True
                                txtCheque.ReadOnly = True
                                txtDeposito.ReadOnly = True
                                txtBonos.ReadOnly = True
                                txtPermuta.ReadOnly = True
                                txtCobrosAdelantados.ReadOnly = True

                                NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
                                NavBarEfectivo.Tag = 0
                                NavBarEfectivo.Expanded = True
                                NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarTarjeta.Tag = 1
                                NavBarTarjeta.Expanded = False
                                NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarCheque.Tag = 1
                                NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarDeposito.Tag = 1
                                NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y otras <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarBonos.Tag = 1


                                frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Clear()
                                ConLibregco.Open()
                                For Each Rw As DataGridViewRow In frm_facturacion.dgvArticulosFactura.Rows
                                    cmd = New MySqlCommand("Select NoPagoTarjeta from Articulos where IDArticulo='" + Rw.Cells(6).Value.ToString + "'", ConLibregco)
                                    If Convert.ToString(cmd.ExecuteScalar) = 1 Then
                                        frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Add(Rw.Cells(7).Value, "No aplica")
                                    End If
                                Next
                                ConLibregco.Close()

                            ElseIf frm_facturacion.IDTipopago = 2 Then
                                txtEfectivo.ReadOnly = False
                                txtTarjeta.ReadOnly = False
                                txtCheque.ReadOnly = True
                                txtDeposito.ReadOnly = True
                                txtBonos.ReadOnly = True
                                txtPermuta.ReadOnly = True
                                txtCobrosAdelantados.ReadOnly = True

                                NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
                                NavBarEfectivo.Tag = 0
                                NavBarEfectivo.Expanded = False
                                NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito "
                                NavBarTarjeta.Tag = 0
                                NavBarTarjeta.Expanded = True
                                NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarCheque.Tag = 1
                                NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarDeposito.Tag = 1
                                NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y otras <u><color=red><B>DESHABILITADO</B></color></u>"
                                NavBarBonos.Tag = 1

                                frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Clear()
                                ConLibregco.Open()
                                For Each Rw As DataGridViewRow In frm_facturacion.dgvArticulosFactura.Rows

                                    cmd = New MySqlCommand("Select NoPagoTarjeta from Articulos where IDArticulo='" + Rw.Cells(6).Value.ToString + "'", ConLibregco)
                                    If Convert.ToString(cmd.ExecuteScalar) = 1 Then
                                        frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Add(Rw.Cells(7).Value, "No aplica")
                                    End If

                                Next

                                ConLibregco.Close()


                                txtTarjeta.ReadOnly = False
                                txtTarjeta.Text = frm_facturacion.txtNeto.Text
                                txtTarjeta.Focus()
                                txtTarjeta.SelectAll()

                            ElseIf frm_facturacion.IDTipopago = 3 Then
                                txtEfectivo.ReadOnly = False
                                txtEfectivo.Text = frm_facturacion.txtNeto.Text
                                txtCheque.ReadOnly = False
                                txtDeposito.ReadOnly = False
                                txtTarjeta.ReadOnly = False


                                NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
                                NavBarEfectivo.Tag = 0
                                NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito "
                                NavBarTarjeta.Tag = 0
                                NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques "
                                NavBarCheque.Tag = 0
                                NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos "
                                NavBarDeposito.Tag = 0
                                NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y otras "
                                NavBarBonos.Tag = 0
                                NavBarCreditos.Caption = "<u><color=30,144,255><B>[F6]</B></color></u>  Créditos y devoluciones "
                                NavBarCreditos.Tag = 0
                            End If
                        Else
                            NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
                            NavBarEfectivo.Tag = 0
                            NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito "
                            NavBarTarjeta.Tag = 0
                            NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques "
                            NavBarCheque.Tag = 0
                            NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos "
                            NavBarDeposito.Tag = 0
                            NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y otras "
                            NavBarBonos.Tag = 0
                            NavBarCreditos.Caption = "<u><color=30,144,255><B>[F6]</B></color></u>  Créditos y devoluciones "
                            NavBarCreditos.Tag = 0
                        End If

                        'txtMontoCobrar.Text = frm_facturacion.txtNeto.Text
                        SumarEfectivos()
                    Else

                        If frm_facturacion.lblDiasCondicion.Text = 0 Then
                            txtMontoCobrar.Text = frm_facturacion.txtNeto.Text
                        Else
                            txtMontoCobrar.Text = frm_facturacion.txtInicial.Text
                        End If

                        If frm_facturacion.IDTipopago = 1 Then
                            txtEfectivo.ReadOnly = False
                            txtEfectivo.Text = frm_facturacion.txtInicial.Text
                            txtCheque.ReadOnly = True
                            txtDeposito.ReadOnly = True
                            txtTarjeta.ReadOnly = True
                        ElseIf frm_facturacion.IDTipopago = 2 Then
                            txtEfectivo.ReadOnly = False
                            txtCheque.ReadOnly = True
                            txtDeposito.ReadOnly = True
                            txtTarjeta.ReadOnly = False
                            txtTarjeta.Text = frm_facturacion.txtInicial.Text
                        ElseIf frm_facturacion.IDTipopago = 3 Then
                            txtEfectivo.ReadOnly = False
                            txtEfectivo.Text = frm_facturacion.txtInicial.Text
                            txtCheque.ReadOnly = False
                            txtDeposito.ReadOnly = False
                            txtTarjeta.ReadOnly = False
                        End If
                    End If

                    SumarEfectivos()

                Else
                    IDTransaccion.Text = frm_facturacion.lblIDTransaccion.Text


                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")

                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    'txtIDTipoDocumento.Text = frm_facturacion.lblIDTipoDocumento.Text
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))

                    If frm_facturacion.lblDiasCondicion.Text = 0 Then
                        txtMontoCobrar.Text = frm_facturacion.txtNeto.Text
                    Else
                        txtMontoCobrar.Text = frm_facturacion.txtInicial.Text
                    End If

                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If

            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                If frm_punto_venta_lite.lblIDTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = frm_punto_venta_lite.lblIDTipoDocumento.Text
                    If frm_punto_venta_lite.lblDiasCondicion.Text = 0 Then
                        txtEfectivo.Text = frm_punto_venta_lite.lblTotalNeto.Text
                        txtMontoCobrar.Text = frm_punto_venta_lite.lblTotalNeto.Text
                        SumarEfectivos()
                    Else
                        txtEfectivo.Text = frm_punto_venta_lite.txtInicial.Text
                        txtMontoCobrar.Text = frm_punto_venta_lite.txtInicial.Text
                        SumarEfectivos()
                    End If
                Else
                    IDTransaccion.Text = frm_punto_venta_lite.lblIDTransaccion.Text

                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")

                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))

                    If frm_punto_venta_lite.lblDiasCondicion.Text = 0 Then
                        txtMontoCobrar.EditValue = CDbl(frm_punto_venta_lite.lblTotalNeto.Text)
                    Else
                        txtMontoCobrar.EditValue = CDbl(frm_punto_venta_lite.txtInicial.Text)
                    End If

                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If

            ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then

                If DTConfiguracion.Rows(154 - 1).Item("Value2Int") = 1 Then
                    txtTarjeta.Enabled = True
                Else
                    txtTarjeta.Enabled = False
                End If

                cbxMoneda.EditValue = CInt(frm_recibo_pagos.cbxMoneda.EditValue)

                If frm_recibo_pagos.lblTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = 3
                    txtMontoCobrar.EditValue = CDbl(frm_recibo_pagos.txtMontoAplicar.Text)
                    txtEfectivo.EditValue = CDbl(frm_recibo_pagos.txtMontoAplicar.Text)
                    SumarEfectivos()
                Else
                    IDTransaccion.Text = frm_recibo_pagos.lblTransaccion.Text
                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))
                    txtMontoCobrar.Text = frm_recibo_pagos.txtMontoAplicar.Text
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")

                    txtEfectivo.Focus()
                End If

                If DTConfiguracion.Rows(154 - 1).Item("Value2Int") = 1 Then
                    txtTarjeta.Enabled = True
                Else
                    txtTarjeta.Enabled = False
                End If

            ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then

                If frm_cuotas_financiamientos.PermitirPagosTarjeta = 1 Then
                    txtTarjeta.Enabled = True
                Else
                    txtTarjeta.Enabled = False
                End If

                If frm_cuotas_financiamientos.lblIDTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = 58
                    txtMontoCobrar.Text = frm_cuotas_financiamientos.txtMontoAplicar.Text
                    txtEfectivo.Text = frm_cuotas_financiamientos.txtMontoAplicar.Text
                    SumarEfectivos()
                Else
                    IDTransaccion.Text = frm_cuotas_financiamientos.lblIDTransaccion.Text
                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")

                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))
                    txtMontoCobrar.EditValue = CDbl(Tabla.Rows(0).Item("MontoCobrar"))
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                    txtEfectivo.Focus()
                End If

                If frm_cuotas_financiamientos.PermitirPagosTarjeta = 1 Then
                    txtTarjeta.Enabled = True
                Else
                    txtTarjeta.Enabled = False
                End If

            ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                If frm_otros_ingresos.lblIDTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = 16
                    txtEfectivo.Text = frm_otros_ingresos.txtMonto.Text
                    txtMontoCobrar.Text = frm_otros_ingresos.txtMonto.Text
                    SumarEfectivos()
                Else
                    IDTransaccion.Text = frm_otros_ingresos.lblIDTransaccion.Text

                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")
                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))
                    txtMontoCobrar.EditValue = CDbl(Tabla.Rows(0).Item("MontoCobrar"))
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If

            ElseIf Me.Owner.Name = frm_financiamiento.Name Then
                txtIDTipoDocumento.Text = 57
                If CDbl(frm_financiamiento.txtInicial.Text) = 0 Then
                    txtMontoCobrar.Text = 0
                Else
                    txtMontoCobrar.Text = frm_financiamiento.txtInicial.Text
                End If

                If frm_financiamiento.lblIDTransaccion.Text = "" Then

                    SumarEfectivos()

                Else
                    IDTransaccion.Text = frm_financiamiento.lblIDTransaccion.Text

                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")

                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))

                    txtMontoCobrar.EditValue = CDbl(Tabla.Rows(0).Item("MontoCobrar"))
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If

            ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
                If frm_cobros_adelantados.lblIDTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = 35
                    txtEfectivo.Text = frm_cobros_adelantados.txtMonto.Text
                    txtMontoCobrar.Text = frm_cobros_adelantados.txtMonto.Text
                    SumarEfectivos()
                Else
                    IDTransaccion.Text = frm_cobros_adelantados.lblIDTransaccion.Text

                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")
                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.EditValue = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))
                    txtMontoCobrar.EditValue = CDbl(Tabla.Rows(0).Item("MontoCobrar"))
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If

            ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                If frm_registro_factura_sd.lblIDTransaccion.Text = "" Then
                    txtIDTipoDocumento.Text = frm_registro_factura_sd.lblIDTipoDocumento.Text
                    If frm_registro_factura_sd.lblDiasCondicion.Text = 0 Then
                        txtEfectivo.Text = frm_registro_factura_sd.txtNeto.Text
                        txtMontoCobrar.Text = frm_registro_factura_sd.txtNeto.Text
                        SumarEfectivos()
                    Else
                        txtEfectivo.Text = frm_registro_factura_sd.txtInicial.Text
                        txtMontoCobrar.Text = frm_registro_factura_sd.txtInicial.Text
                        SumarEfectivos()
                    End If
                Else
                    IDTransaccion.Text = frm_registro_factura_sd.lblIDTransaccion.Text

                    DsTmp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT * FROM transaccion Where IDTransaccion='" + IDTransaccion.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Transaccion")
                    Con.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("Transaccion")
                    IDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    cbxMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
                    txtEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("Efectivo"))
                    txtDevolucionEfectivo.EditValue = CDbl(Tabla.Rows(0).Item("DevueltaEfectivo"))
                    txtCheque.EditValue = CDbl(Tabla.Rows(0).Item("Cheque"))
                    cbxBancoCheque.Text = Tabla.Rows(0).Item("ChequeBanco")
                    txtNoCheque.Text = Tabla.Rows(0).Item("NoCheque")
                    txtDeposito.EditValue = CDbl(Tabla.Rows(0).Item("Deposito"))
                    txtInformacionDeposito.Text = (Tabla.Rows(0).Item("Informacion"))
                    txtIDCredito.Text = (Tabla.Rows(0).Item("IDCredito"))
                    txtMontoCredito.EditValue = CDbl(Tabla.Rows(0).Item("Credito"))
                    txtTarjeta.Text = CDbl(Tabla.Rows(0).Item("Tarjeta"))
                    HabilitarPagoTarjeta()
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("ClaseTarjeta"))
                    lblClaseTarjeta.Text = (Tabla.Rows(0).Item("TipoTarjeta"))
                    txtNoTarjeta.Text = (Tabla.Rows(0).Item("NoTarjeta"))
                    cbxMes.Text = (Tabla.Rows(0).Item("Mes"))
                    'cbxAño.Text = (Tabla.Rows(0).Item("Año"))
                    cbxBancoTarjeta.Text = (Tabla.Rows(0).Item("Banco"))
                    txtNoAprobacion.Text = (Tabla.Rows(0).Item("NoAprobacion"))
                    If (Tabla.Rows(0).Item("TipoTarjeta")) = "Visa" Then
                        rdbVisa.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "MasterCard" Then
                        rdbMasterCard.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "American Express" Then
                        rdbAmericanExpress.Checked = True
                    ElseIf (Tabla.Rows(0).Item("TipoTarjeta")) = "Otra" Then
                        rdbOtra.Checked = True
                    End If
                    txtEfectivoCobrar.Text = CDbl(Tabla.Rows(0).Item("Recibido")).ToString("C")
                    RutaDocumento = Tabla.Rows(0).Item("RutaBoucher")
                    txtBonos.EditValue = CDbl(Tabla.Rows(0).Item("Bonos"))
                    txtPermuta.EditValue = CDbl(Tabla.Rows(0).Item("Permuta"))
                    txtCobrosAdelantados.EditValue = CDbl(Tabla.Rows(0).Item("Otras"))
                    txtMontoCobrar.EditValue = CDbl(Tabla.Rows(0).Item("MontoCobrar"))
                    txtDevuelta.Text = CDbl(Tabla.Rows(0).Item("Devuelta")).ToString("C")
                End If
            End If

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

            ConseguirCobrosAdelantados

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ConseguirCobrosAdelantados()
        If IDTransaccion.Text <> "" Then
            TablaCobrosAdelantadados.Rows.Clear()

            TablaCobrosAdelantadados.Clear()

            Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                Using myCommand As MySqlCommand = New MySqlCommand("SELECT IDCobrosAdelantados_hijo,cobrosadelantados_hijos.IDCobrosAdelantados,cobrosadelantados.SecondID,TIMESTAMP(cobrosadelantados.Fecha,CobrosAdelantados.Hora) as Fecha,(cobrosadelantados.Monto-(SELECT SUM(Monto) from" & SysName.Text & "CobrosAdelantados_hijos Where CobrosAdelantados_hijos.IDCobrosAdelantados=CobrosAdelantados.IDCobrosAdelantados)) as Disponible,cobrosadelantados_hijos.Monto as Utilizar FROM" & SysName.Text & "cobrosadelantados_hijos INNER JOIN" & SysName.Text & "CobrosAdelantados on cobrosadelantados_hijos.IDCobrosAdelantados=CobrosAdelantados.IDCobrosAdelantados where cobrosadelantados_hijos.IDTransaccion='" + IDTransaccion.Text + "'", ConMixta)
                    ConMixta.Open()

                    Using myReader As MySqlDataReader = myCommand.ExecuteReader

                        TablaCobrosAdelantadados.Load(myReader, LoadOption.Upsert)

                        ConMixta.Close()

                    End Using
                End Using
            End Using

            TablaCobrosAdelantadados.EndLoadData()
        End If
    End Sub

    Private Sub LlenarCbxMeses()
        Dim x As Integer

        cbxMes.Properties.Items.Clear()

        For x = 1 To 12
            cbxMes.Properties.Items.Add(x)
        Next
    End Sub

    Private Sub LlenarCbxAños()
        Dim x As Integer = Year(Now)

        cbxAño.Properties.Items.Clear()

        For x = x To x + 10
            cbxAño.Properties.Items.Add(x)

        Next
    End Sub

    Private Sub HabilitarPagoTarjeta()
        Try
            If CDbl(txtTarjeta.Text) > 0 Then
                If txtNoTarjeta.Visible = True Then
                    NavBarGroupControlContainer4.Height = 112
                Else
                    NavBarGroupControlContainer4.Height = 68
                End If

                lblClaseTarjeta.Enabled = True
                txtNoTarjeta.Enabled = True
                cbxMes.Enabled = True
                cbxAño.Enabled = True
                cbxBancoTarjeta.Enabled = True
                rdbTipoTarjeta.Enabled = True
                gcAprobacion.Enabled = True
                LlenarCbx()
            Else
                If txtNoTarjeta.Visible = True Then
                    NavBarGroupControlContainer4.Height = 112
                Else
                    NavBarGroupControlContainer4.Height = 68
                End If

                lblClaseTarjeta.Properties.Items.Clear()
                lblClaseTarjeta.Enabled = False
                txtNoTarjeta.Enabled = False
                cbxMes.Enabled = False
                cbxAño.Enabled = False
                cbxBancoTarjeta.Enabled = False
                rdbTipoTarjeta.Enabled = False
                gcAprobacion.Enabled = False
                txtNoTarjeta.Text = ""
                cbxMes.Properties.Items.Clear()
                cbxAño.Properties.Items.Clear()
                cbxBancoTarjeta.Text = "N/A"
                txtNoAprobacion.Text = ""
                RutaDocumento = ""
            End If

        Catch ex As Exception
            NavBarGroupControlContainer4.Height = 68
        End Try


    End Sub

    Private Sub SumarEfectivos()
        Try
            txtEfectivoCobrar.Text = (CDbl(txtEfectivo.EditValue) + CDbl(txtCheque.EditValue) + CDbl(txtDeposito.EditValue) + CDbl(txtTarjeta.EditValue) + CDbl(txtMontoCredito.EditValue) + CDbl(txtBonos.EditValue) + CDbl(txtPermuta.EditValue) + CDbl(txtCobrosAdelantados.EditValue)).ToString("C")
            txtDevuelta.Text = (CDbl(txtEfectivoCobrar.Text) - CDbl(txtMontoCobrar.Text)).ToString("C")
            ColoresTransaccion()
            VerificarTiposCompletos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarForm()
        ControlStatus.Text = 0
        txtTipoDocumento.Text = ""
        IDTransaccion.Text = ""
        txtIDCredito.Text = ""
        txtIDCredito.Tag = ""
        txtNoCheque.Text = ""
        txtBalanceCredito.Text = CDbl(0).ToString("C")
        txtBalanceUtilizado.Text = CDbl(0).ToString("C")
        txtBalanceGenerado.Text = CDbl(0).ToString("C")
        txtMontoCredito.EditValue = CDbl(0)
        txtEfectivo.EditValue = CDbl(0)
        txtCheque.EditValue = CDbl(0)
        txtDeposito.EditValue = CDbl(0)
        txtInformacionDeposito.Text = ""
        txtTarjeta.EditValue = CDbl(0)
        txtBonos.EditValue = CDbl(0)
        txtPermuta.EditValue = CDbl(0)
        txtCobrosAdelantados.EditValue = CDbl(0)
        lblClaseTarjeta.Properties.Items.Clear()
        txtNoTarjeta.Text = ""
        lblClaseTarjeta.Text = ""
        cbxMes.Properties.Items.Clear()
        cbxAño.Properties.Items.Clear()
        TablaCobrosAdelantadados.Rows.Clear()
        cbxBancoTarjeta.Text = "N/A"
        txtNoAprobacion.Clear()
        txtEfectivoCobrar.Text = CDbl(0).ToString("C")
        txtMontoCobrar.EditValue = CDbl(0)
        txtDevuelta.Text = CDbl(0).ToString("C")
        HabilitarPagoTarjeta()
        Panel1.Visible = False
        txtEfectivo.ReadOnly = False
        txtCheque.ReadOnly = False
        txtDeposito.ReadOnly = False
        txtTarjeta.ReadOnly = False
        cbxBancoCheque.SelectedIndex = 0
        cbxBancoDeposito.SelectedIndex = 0
        cbxBancoTarjeta.SelectedIndex = 0
        Label27.Text = ""
        txtIDCredito.Enabled = True
        btnBuscarCreditos.Enabled = True
        txtMontoCredito.Enabled = False
        txtIDCredito.ReadOnly = False
        btnBuscarCreditos.Visible = True
        Label27.Text = ""
        NavBarEfectivo.Caption = "<u><color=30,144,255><B>[F1]</B></color></u>  Efectivo"
        NavBarEfectivo.Tag = 0
        NavBarTarjeta.Caption = "<u><color=30,144,255><B>[F2]</B></color></u>  Tarjetas de crédito y débito "
        NavBarTarjeta.Tag = 0
        NavBarCheque.Caption = "<u><color=30,144,255><B>[F3]</B></color></u>  Cheques "
        NavBarCheque.Tag = 0
        NavBarDeposito.Caption = "<u><color=30,144,255><B>[F4]</B></color></u>  Depósitos "
        NavBarDeposito.Tag = 0
        NavBarBonos.Caption = "<u><color=30,144,255><B>[F5]</B></color></u>  Bonos, Permutas y otras "
        NavBarBonos.Tag = 0
        NavBarCreditos.Caption = "<u><color=30,144,255><B>[F6]</B></color></u>  Créditos y devoluciones "
        NavBarCreditos.Tag = 0
    End Sub

    Private Sub MoverFichero()
        'Try
        If CDbl(txtTarjeta.EditValue) > 0 Then
            If RutaDocumento <> "" Then

                frm_facturacion.lblStatusBar.Text = "Verificando si existen ficheros"

                If TypeConnection.Text = 1 Then
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                    End If

                    'Verifico si existe el archivo de por anexar
                    Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento)

                    If ExistsFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Verifone\" & txtNoAprobacion.Text & ".png"

                        If RutaDestino <> RutaDocumento Then
                            My.Computer.FileSystem.MoveFile(RutaDocumento, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                        sqlQ = "UPDATE Transaccion SET RutaBoucher='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDTransaccion= '" + IDTransaccion.Text + "'"
                        GuardarDatos()

                        'Devolver Nueva Ruta al los controles
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                        frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                        RutaDocumento = RutaDestino
                        wFile.Close()
                    End If

                End If
            End If
        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub UltTransaccion()
        If IDTransaccion.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDTransaccion from" & SysName.Text & "Transaccion where IDTransaccion= (Select Max(IDTransaccion) from" & SysName.Text & "Transaccion)", Con)
            IDTransaccion.Text = Convert.ToString(cmd.ExecuteScalar)
            Con.Close()
        End If

    End Sub

    Private Sub VerificarDeposito()
        If CDbl(txtDeposito.EditValue) > 0 Then
            frm_facturacion.lblStatusBar.Text = "Verificando pagos con cheques"
            If cbxBancoDeposito.Text = "" Then
                MessageBox.Show("Por favor seleccione el banco correspondiente del depósito que desea procesar.", "No ha elegido un banco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                ControlStatus.Text = 1
                Exit Sub
            ElseIf txtInformacionDeposito.Text = "" Then
                MessageBox.Show("Por favor escriba en número de referencia del depósito que desea procesar.", "# Número de depósito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ControlStatus.Text = 1
                Exit Sub
            End If
        Else
            ControlStatus.Text = 0
        End If
    End Sub
    Private Sub VerificarPosCheque()
        Dim lblIDCliente, NoRecibirCheques As New Label
        'Try
        If CDbl(txtCheque.EditValue) > 0 Then
            frm_facturacion.lblStatusBar.Text = "Verificando pagos con cheques"
            If cbxBancoCheque.Text = "" Then
                MessageBox.Show("Por favor seleccione el banco correspondiente del cheque que desea procesar.", "No ha elegido un banco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                cbxBancoCheque.Focus()
                ControlSuperClave = 1
                Exit Sub
            ElseIf txtNoCheque.Text = "" Then
                MessageBox.Show("Por favor escriba en número del cheque que desea procesar.", "# Número de cheque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtNoCheque.Focus()
                ControlSuperClave = 1
                Exit Sub
            End If

            If Me.Owner.Name = frm_facturacion.Name Then
                lblIDCliente.Text = frm_facturacion.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                lblIDCliente.Text = frm_punto_venta_lite.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
                lblIDCliente.Text = frm_recibo_pagos.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                lblIDCliente.Text = frm_otros_ingresos.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
                lblIDCliente.Text = frm_cobros_adelantados.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                lblIDCliente.Text = frm_registro_factura_sd.txtIDCliente.Text
            ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
                lblIDCliente.Text = frm_cuotas_financiamientos.txtIDCliente.Text
            End If

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCliente,NoRecibirCheques from Clientes where IDCliente= '" + lblIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")

            NoRecibirCheques.Text = (Tabla.Rows(0).Item("NoRecibirCheques"))

            If CDbl(txtCheque.Text) > 0 And NoRecibirCheques.Text = 1 Then
                MessageBox.Show("Se tiene desautorizada y/o prohíbida, la recepción de pagos a través de cheques de este cliente." & vbNewLine & "Elija otra forma de pago para continuar.", "No recibir cheques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCheque.Focus()
                ControlStatus.Text = 1
            Else
                ControlStatus.Text = 0
            End If
        Else
            ControlStatus.Text = 0
        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub UpdateTransaccion()
        'Try
        If Me.Owner.Name = frm_facturacion.Name Then
            frm_facturacion.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
            frm_punto_venta_lite.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
            frm_recibo_pagos.lblTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
            frm_otros_ingresos.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_cobros_adelantados.Name Then
            frm_cobros_adelantados.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
            frm_registro_factura_sd.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_financiamiento.Name Then
            frm_financiamiento.lblIDTransaccion.Text = IDTransaccion.Text

        ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
            frm_cuotas_financiamientos.lblIDTransaccion.Text = IDTransaccion.Text

        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub GuardarDatos()
        'Try
        Con.Open()
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '    Con.Close()
        'End Try
    End Sub

    Private Sub VerificarTarjeta()
        Try
            If CDbl(txtTarjeta.EditValue) > 0 Then
                frm_facturacion.lblStatusBar.Text = "Verificando pagos con tarjeta"
                If CInt(DTConfiguracion.Rows(57 - 1).Item("Value2Int")) = 1 Then
                    If lblClaseTarjeta.Text = "" Then
                        MessageBox.Show("Seleccione el tipo de tarjeta para continuar con el pago", "Seleccione la marca de la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        lblClaseTarjeta.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If
                    If txtNoTarjeta.DoValidate = False Then
                        MessageBox.Show("Complete el número de la tarjeta de crédito/débito para continuar con el pago.", "Complete el número de la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        txtNoTarjeta.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If
                    If cbxMes.Text = "" Then
                        MessageBox.Show("Seleccione el mes de vencimiento de la tarjeta para continuar con el pago.", "Introduzca el mes de la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        cbxMes.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If
                    If cbxAño.Text = "" Then
                        MessageBox.Show("Seleccione el año de vencimiento de la tarjeta para continuar con el pago.", "Introduzca el mes de la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        cbxAño.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If

                    Dim ConstructDate As String = "01/" & cbxMes.Text & "/" & cbxAño.Text
                    If IsDate(ConstructDate) Then
                        If CDate(ConstructDate) < Today Then
                            MessageBox.Show("La tarjeta de crédito/débito para procesar el pago está vencida.", "Tarjeta Vencida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ControlStatus.Text = 1
                            Exit Sub
                        End If
                        ControlStatus.Text = 0
                    Else
                        ControlStatus.Text = 1
                        Exit Sub
                    End If

                    If cbxBancoTarjeta.Text = "N/A" Then
                        MessageBox.Show("Seleccione la entidad financiera emisora de la tarjeta de crédito o débito para continuar con el pago.", "Selecciona Banco emisor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        cbxBancoTarjeta.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If
                    If txtNoAprobacion.Text = "" Then
                        MessageBox.Show("Introduzca el No. de Aprobación de la transacción para continuar.", "Selecciona Banco emisor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        txtNoAprobacion.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If

                ElseIf CInt(DTConfiguracion.Rows(57 - 1).Item("Value2Int")) = 0 Then

                    'If lblClaseTarjeta.Text = "" Then
                    '    MessageBox.Show("Seleccione la marca de la tarjeta para continuar con el pago", "Seleccione la marca de la tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '    ControlStatus.Text = 1
                    '    lblClaseTarjeta.Focus()
                    '    Exit Sub
                    'Else
                    '    ControlStatus.Text = 0
                    'End If

                    'If cbxBancoTarjeta.Text = "N/A" Then
                    '    MessageBox.Show("Seleccione la entidad financiera emisora de la tarjeta de crédito o débito para continuar con el pago.", "Selecciona Banco emisor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '    ControlStatus.Text = 1
                    '    cbxBancoTarjeta.Focus()
                    '    Exit Sub
                    'Else
                    '    ControlStatus.Text = 0
                    'End If

                    If txtNoAprobacion.Text = "" Then
                        MessageBox.Show("Introduzca el No. de Aprobación de la transacción para continuar.", "Selecciona Banco emisor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        ControlStatus.Text = 1
                        txtNoAprobacion.Focus()
                        Exit Sub
                    Else
                        ControlStatus.Text = 0
                    End If


                End If

            Else
                ControlStatus.Text = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub LlenarIDs()
        'Try

        Con.Open()
        cmd = New MySqlCommand("Select Documento from TipoDocumento where IDTipoDocumento='" + txtIDTipoDocumento.Text + "'", Con)
        txtTipoDocumento.Text = Convert.ToString(cmd.ExecuteScalar)
        Con.Close()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub ColoresTransaccion()
        If CDbl(txtEfectivoCobrar.Text) = CDbl(txtMontoCobrar.Text) Then
            txtDevuelta.ForeColor = Color.Green
        ElseIf CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
            txtDevuelta.ForeColor = Color.Red
        ElseIf CDbl(txtEfectivoCobrar.Text) > CDbl(txtMontoCobrar.Text) Then
            txtDevuelta.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub lblClaseTarjeta_Click(sender As Object, e As EventArgs)
        If lblClaseTarjeta.Text = "CRÉDITO" Then
            lblClaseTarjeta.Text = "DÉBITO"
        ElseIf lblClaseTarjeta.Text = "DÉBITO" Then
            lblClaseTarjeta.Text = "CRÉDITO"
        End If
    End Sub

    '    'Private Sub FillBancos()
    '    '    Try
    '    '        Ds.Clear()
    '    '        ConLibregco.Open()
    '    '        cmd = New MySqlCommand("SELECT Identidad FROM Bancos Where Bancos.Nulo=0 ORDER BY Identidad ASC", ConLibregco)
    '    '        Adaptador = New MySqlDataAdapter(cmd)
    '    '        Adaptador.Fill(Ds, "Bancos")
    '    '        cbxBanco.Items.Clear()
    '    '        ConLibregco.Close()

    '    '        Dim Tabla As DataTable = Ds.Tables("Bancos")

    '    '        For Each Fila As DataRow In Tabla.Rows
    '    '            cbxBanco.Items.Add(Fila.Item("Identidad"))
    '    '        Next

    '    '    Catch ex As Exception
    '    '        InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
    '    '    End Try
    '    'End Sub

    '    'Private Sub cbxBanco_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    '    ConLibregco.Open()
    '    '    cmd = New MySqlCommand("SELECT Bancos.IDBanco from Bancos WHERE Bancos.Identidad='" + CbxBanco.Text + "'", ConLibregco)
    '    '    txtIDBanco.Text = Convert.ToString(cmd.ExecuteScalar())
    '    '    ConLibregco.Close()

    '    'End Sub

    '    'Private Sub btnShowCheques_Click(sender As Object, e As EventArgs) Handles btnShowCheques.Click
    '    '    GbDetalleCheques.Visible = True
    '    'End Sub

    '    'Private Sub btnInsertarCheque_Click(sender As Object, e As EventArgs) Handles btnInsertarCheque.Click
    '    '    If txtNoCheque.Text = "" Then
    '    '        MessageBox.Show("Escriba el No. de Cheque.", "No. de cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    '        txtNoCheque.Focus()
    '    '        Exit Sub
    '    '    ElseIf cbxBanco.Text = "" Then
    '    '        MessageBox.Show("Seleccione el banco correspondiente al cheque.", "Seleccionar el banco emisor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    '        cbxBanco.Focus()
    '    '        cbxBanco.DroppedDown = True
    '    '        Exit Sub
    '    '    ElseIf txtMontoCheque.Text = "" Or txtMontoCheque.Text = 0 Or txtMontoCheque.Text = CDbl(0).ToString("C") Then
    '    '        MessageBox.Show("Escriba el monto del cheque.", "Monto de cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    '        txtMontoCheque.Focus()
    '    '        Exit Sub
    '    '    End If

    '    '    DgvDetalleCheques.Rows.Add("", txtNoCheque.Text, txtIDBanco.Text, cbxBanco.Text, txtMontoCheque.Text)

    '    '    txtNoCheque.Clear()
    '    '    txtIDBanco.Clear()
    '    '    FillBancos()
    '    '    txtMontoCheque.Clear()

    '    '    Dim MontoCheque As Double = 0
    '    '    For Each Row As DataGridViewRow In DgvDetalleCheques.Rows
    '    '        MontoCheque = CDbl(Row.Cells(4).Value) + MontoCheque
    '    '    Next

    '    '    lblSumaCheque.Text = MontoCheque.ToString("C")
    '    '    txtCheque.Text = MontoCheque.ToString("C")

    '    '    txtNoCheque.Focus()
    '    'End Sub

    '    'Private Sub DgvDetalleCheques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleCheques.CellDoubleClick
    '    '    If DgvDetalleCheques.Rows.Count = 0 Then
    '    '        MessageBox.Show("No hay cheques para eliminar.", "No se encontró cheque", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    '    Else
    '    '        Dim IDCheque As String = DgvDetalleCheques.CurrentRow.Cells(0).Value

    '    '        If IDCheque = "" Then
    '    '            DgvDetalleCheques.Rows.Remove(DgvDetalleCheques.CurrentRow)
    '    '        Else
    '    '            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el cheque " & DgvDetalleCheques.CurrentRow.Cells(1).Value & " como cheque anexo al registro?", "Eliminar Cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '    '            If Result = MsgBoxResult.Yes Then
    '    '                'sqlQ = "Delete from documentosclientes Where IDDocumentosClientes = (" + IDDocumento + ")"
    '    '                GuardarDatos()
    '    '                DgvDetalleCheques.Rows.Remove(DgvDetalleCheques.CurrentRow)
    '    '            End If
    '    '        End If
    '    '    End If

    '    '    Dim MontoCheque As Double = 0
    '    '    For Each Row As DataGridViewRow In DgvDetalleCheques.Rows
    '    '        MontoCheque = CDbl(Row.Cells(4).Value) + MontoCheque
    '    '    Next

    '    '    lblSumaCheque.Text = MontoCheque.ToString("C")
    '    '    txtCheque.Text = MontoCheque.ToString("C")

    '    'End Sub

    '    'Private Sub GbDetalleCheques_Leave(sender As Object, e As EventArgs) Handles GbDetalleCheques.Leave
    '    '    GbDetalleCheques.Visible = False
    '    'End Sub

    Private Sub frm_formadepago_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar.PerformClick()

        ElseIf e.KeyCode = Keys.F1 Then
            e.Handled = True

            If NavBarTarjeta.Tag.ToString = 0 Then
                If txtTarjeta.EditValue = 0 Then
                    NavBarTarjeta.Expanded = False
                Else
                    NavBarTarjeta.Expanded = True
                End If
            End If

            If NavBarCheque.Tag.ToString = 0 Then
                If txtCheque.EditValue = 0 Then
                    NavBarCheque.Expanded = False
                Else
                    NavBarCheque.Expanded = True
                End If
            End If

            If NavBarDeposito.Tag.ToString = 0 Then
                If txtDeposito.EditValue = 0 Then
                    NavBarDeposito.Expanded = False
                Else
                    NavBarDeposito.Expanded = True
                End If
            End If

            If NavBarBonos.Tag.ToString = 0 Then
                If txtBonos.EditValue = 0 And txtPermuta.EditValue = 0 And txtCobrosAdelantados.EditValue = 0 Then
                    NavBarBonos.Expanded = False
                Else
                    NavBarBonos.Expanded = True
                End If
            End If

            If NavBarCreditos.Tag.ToString = 0 Then
                If txtMontoCredito.EditValue = 0 Then
                    NavBarCreditos.Expanded = False
                Else
                    NavBarCreditos.Expanded = True
                End If
            End If


            NavBarEfectivo.Expanded = True
            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

        ElseIf e.KeyCode = Keys.F2 Then
            e.Handled = True


            If txtEfectivo.EditValue = 0 Then
                NavBarEfectivo.Expanded = False
            Else
                NavBarEfectivo.Expanded = True
            End If

            If txtCheque.EditValue = 0 Then
                NavBarCheque.Expanded = False
            Else
                NavBarCheque.Expanded = True
            End If

            If txtDeposito.EditValue = 0 Then
                NavBarDeposito.Expanded = False
            Else
                NavBarDeposito.Expanded = True
            End If


            If txtBonos.EditValue = 0 And txtPermuta.EditValue = 0 And txtCobrosAdelantados.EditValue = 0 Then
                NavBarBonos.Expanded = False
            Else
                NavBarBonos.Expanded = True
            End If

            If txtMontoCredito.EditValue = 0 Then
                NavBarCreditos.Expanded = False
            Else
                NavBarCreditos.Expanded = True
            End If

            NavBarTarjeta.Expanded = True
            txtTarjeta.Focus()
            txtTarjeta.SelectAll()

        ElseIf e.KeyCode = Keys.F3 Then
            e.Handled = True

            If NavBarEfectivo.Tag.ToString = 0 Then
                If txtEfectivo.EditValue = 0 Then
                    NavBarEfectivo.Expanded = False
                Else
                    NavBarEfectivo.Expanded = True
                End If
            End If

            If NavBarTarjeta.Tag.ToString = 0 Then
                If txtTarjeta.EditValue = 0 Then
                    NavBarTarjeta.Expanded = False
                Else
                    NavBarTarjeta.Expanded = True
                End If
            End If

            If NavBarDeposito.Tag.ToString = 0 Then
                If txtDeposito.EditValue = 0 Then
                    NavBarDeposito.Expanded = False
                Else
                    NavBarDeposito.Expanded = True
                End If
            End If


            If NavBarBonos.Tag.ToString = 0 Then
                If txtBonos.EditValue = 0 And txtPermuta.EditValue = 0 And txtCobrosAdelantados.EditValue = 0 Then
                    NavBarBonos.Expanded = False
                Else
                    NavBarBonos.Expanded = True
                End If
            End If

            If NavBarCreditos.Tag.ToString = 0 Then
                If txtMontoCredito.EditValue = 0 Then
                    NavBarCreditos.Expanded = False
                Else
                    NavBarCreditos.Expanded = True
                End If
            End If


            NavBarCheque.Expanded = True
            txtCheque.Focus()
            txtCheque.SelectAll()

        ElseIf e.KeyCode = Keys.F4 Then
            e.Handled = True


            If NavBarEfectivo.Tag.ToString = 0 Then
                If txtEfectivo.EditValue = 0 Then
                    NavBarEfectivo.Expanded = False
                Else
                    NavBarEfectivo.Expanded = True
                End If
            End If

            If NavBarTarjeta.Tag.ToString = 0 Then
                If txtTarjeta.EditValue = 0 Then
                    NavBarTarjeta.Expanded = False
                Else
                    NavBarTarjeta.Expanded = True
                End If
            End If

            If NavBarCheque.Tag.ToString = 0 Then
                If txtCheque.EditValue = 0 Then
                    NavBarCheque.Expanded = False
                Else
                    NavBarCheque.Expanded = True
                End If
            End If


            If NavBarBonos.Tag.ToString = 0 Then
                If txtBonos.EditValue = 0 And txtPermuta.EditValue = 0 And txtCobrosAdelantados.EditValue = 0 Then
                    NavBarBonos.Expanded = False
                Else
                    NavBarBonos.Expanded = True
                End If
            End If

            If NavBarCreditos.Tag.ToString = 0 Then
                If txtMontoCredito.EditValue = 0 Then
                    NavBarCreditos.Expanded = False
                Else
                    NavBarCreditos.Expanded = True
                End If
            End If

            NavBarDeposito.Expanded = True
            txtDeposito.Focus()
            txtDeposito.SelectAll()

        ElseIf e.KeyCode = Keys.F5 Then
            e.Handled = True
            If NavBarEfectivo.Tag.ToString = 0 Then
                If txtEfectivo.EditValue = 0 Then
                    NavBarEfectivo.Expanded = False
                Else
                    NavBarEfectivo.Expanded = True
                End If
            End If

            If NavBarTarjeta.Tag.ToString = 0 Then
                If txtTarjeta.EditValue = 0 Then
                    NavBarTarjeta.Expanded = False
                Else
                    NavBarTarjeta.Expanded = True
                End If
            End If

            If NavBarCheque.Tag.ToString = 0 Then
                If txtCheque.EditValue = 0 Then
                    NavBarCheque.Expanded = False
                Else
                    NavBarCheque.Expanded = True
                End If
            End If

            If NavBarDeposito.Tag.ToString = 0 Then
                If txtDeposito.EditValue = 0 Then
                    NavBarDeposito.Expanded = False
                Else
                    NavBarDeposito.Expanded = True
                End If
            End If


            If NavBarCreditos.Tag.ToString = 0 Then
                If txtMontoCredito.EditValue = 0 Then
                    NavBarCreditos.Expanded = False
                Else
                    NavBarCreditos.Expanded = True
                End If
            End If

            NavBarBonos.Expanded = True
            txtBonos.Focus()
            txtBonos.SelectAll()

        ElseIf e.KeyCode = Keys.F6 Then
            e.Handled = True

            If NavBarEfectivo.Tag.ToString = 0 Then
                If txtEfectivo.EditValue = 0 Then
                    NavBarEfectivo.Expanded = False
                Else
                    NavBarEfectivo.Expanded = True
                End If
            End If

            If NavBarTarjeta.Tag.ToString = 0 Then
                If txtTarjeta.EditValue = 0 Then
                    NavBarTarjeta.Expanded = False
                Else
                    NavBarTarjeta.Expanded = True
                End If
            End If

            If NavBarCheque.Tag.ToString = 0 Then
                If txtCheque.EditValue = 0 Then
                    NavBarCheque.Expanded = False
                Else
                    NavBarCheque.Expanded = True
                End If
            End If

            If NavBarDeposito.Tag.ToString = 0 Then
                If txtDeposito.EditValue = 0 Then
                    NavBarDeposito.Expanded = False
                Else
                    NavBarDeposito.Expanded = True
                End If
            End If


            If NavBarBonos.Tag.ToString = 0 Then
                If txtBonos.EditValue = 0 And txtPermuta.EditValue = 0 And txtCobrosAdelantados.EditValue = 0 Then
                    NavBarBonos.Expanded = False
                Else
                    NavBarBonos.Expanded = True
                End If
            End If


            NavBarCreditos.Expanded = True
            txtIDCredito.Focus()
            txtIDCredito.SelectAll()

        ElseIf e.KeyCode = Keys.F10 Or e.KeyCode = Keys.End Then

            e.Handled = True

            btnContinuar.Focus()
            btnContinuar.PerformClick()


        End If

    End Sub


    Private Sub txtCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheque.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If CDbl(txtCheque.Text) > 0 Then
                cbxBancoCheque.Focus()
            Else
                If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                    If CDbl(txtCheque.EditValue) = 0 Then
                        NavBarCheque.Expanded = False
                    End If

                    NavBarDeposito.Expanded = True
                    txtDeposito.Focus()
                    txtDeposito.SelectAll()
                End If
            End If


        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If CDbl(txtCheque.Text) > 0 Then
                cbxBancoCheque.Focus()
            Else
                If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                    If CDbl(txtCheque.EditValue) = 0 Then
                        NavBarCheque.Expanded = False
                    End If

                    NavBarDeposito.Expanded = True
                    txtDeposito.Focus()
                    txtDeposito.SelectAll()
                End If
            End If


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            cbxBancoCheque.Focus()
            cbxBancoCheque.ShowPopup()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            NavBarCheque.Expanded = False
            NavBarTarjeta.Expanded = True
            txtTarjeta.Focus()
            txtTarjeta.SelectAll()

        End If
    End Sub

    Private Sub txtNoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoCheque.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
                NavBarDeposito.Expanded = True
                txtDeposito.Focus()
                txtDeposito.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True

            txtCheque.Focus()
            txtCheque.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            txtDeposito.Focus()
            txtDeposito.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtTarjeta.Focus()
            txtTarjeta.SelectAll()

        End If
    End Sub

    Private Sub txtDeposito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDeposito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                If CDbl(txtDeposito.EditValue) = 0 Then
                    NavBarDeposito.Expanded = False
                End If

                NavBarBonos.Expanded = True
                txtBonos.Focus()
                txtBonos.SelectAll()
            Else
                cbxBancoDeposito.Focus()
            End If


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True

            cbxBancoDeposito.Focus()
            cbxBancoDeposito.ShowPopup()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                If CDbl(txtDeposito.EditValue) = 0 Then
                    NavBarDeposito.Expanded = False
                End If

                NavBarBonos.Expanded = True
                txtBonos.Focus()
                txtBonos.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            NavBarDeposito.Expanded = False
            NavBarCheque.Expanded = True
            txtCheque.Focus()
            txtCheque.SelectAll()

        End If
    End Sub

    Private Sub txtInformacionDeposito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInformacionDeposito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True

            cbxBancoDeposito.Focus()
            cbxBancoDeposito.ShowPopup()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If txtBonos.Enabled = True Then
                NavBarBonos.Expanded = True
                txtBonos.Focus()
                txtBonos.SelectAll()
            Else
                If NavBarCreditos.Expanded = False Then
                    NavBarCreditos.Expanded = True
                    txtIDCredito.Focus()
                    txtIDCredito.SelectAll()
                End If
            End If


        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtCheque.Focus()
            txtCheque.SelectAll()
        End If
    End Sub

    Private Sub txtIDCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDCredito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If txtIDCredito.Text = "" Then
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            Else

                btnBuscarCreditos.Focus()
            End If


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True

            btnBuscarCreditos.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True


            If txtIDCredito.Text = "" Then
                btnContinuar.Focus()
            Else

                btnBuscarCreditos.Focus()
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            NavBarCreditos.Expanded = False
            NavBarBonos.Expanded = True

            txtCobrosAdelantados.Focus()
            txtCobrosAdelantados.SelectAll()


        End If
    End Sub

    Private Sub txtBalanceCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBalanceCredito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMontoCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMontoCredito.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            txtTarjeta.Focus()
            txtTarjeta.SelectAll()


        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtIDCredito.Focus()
            txtIDCredito.SelectAll()

        End If
    End Sub

    Private Sub txtTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjeta.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then
                If CDbl(txtTarjeta.EditValue) = 0 Then
                    NavBarTarjeta.Expanded = False
                    NavBarCheque.Expanded = True
                    txtCheque.Focus()
                    txtCheque.SelectAll()
                Else
                    lblClaseTarjeta.Focus()
                End If


            Else
                SendKeys.Send("{TAB}")
            End If


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            lblClaseTarjeta.Focus()
            lblClaseTarjeta.ShowPopup()


        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then
                If CDbl(txtTarjeta.EditValue) = 0 Then
                    NavBarTarjeta.Expanded = False
                End If

                NavBarCheque.Expanded = True
                txtCheque.Focus()
                txtCheque.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If


        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                If CDbl(txtTarjeta.EditValue) = 0 Then
                    NavBarTarjeta.Expanded = False
                End If

                NavBarEfectivo.Expanded = True
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtNoTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoTarjeta.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()


        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            cbxMes.Focus()
            cbxMes.ShowPopup()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtTarjeta.Focus()
            txtTarjeta.SelectAll()

        End If
    End Sub

    Private Sub cbxMes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMes.KeyDown
        If cbxMes.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                cbxAño.Focus()
                cbxAño.ShowPopup()


                'ElseIf e.KeyCode = Keys.Down Then
                '    e.Handled = True
                '    cbxBancoTarjeta.Focus()
                '    cbxBancoTarjeta.ShowPopup()

                'ElseIf e.KeyCode = Keys.Up Then
                '    e.Handled = True

                '    txtNoTarjeta.Focus()
                '    txtNoTarjeta.SelectAll()

            End If
        End If
    End Sub

    Private Sub cbxAño_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAño.KeyDown
        If cbxAño.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                txtNoAprobacion.Focus()
                txtNoAprobacion.SelectAll()


            ElseIf e.KeyCode = Keys.Down Then
                e.Handled = True
                cbxBancoTarjeta.Focus()
                cbxBancoTarjeta.ShowPopup()

            ElseIf e.KeyCode = Keys.Up Then
                e.Handled = True

                txtNoTarjeta.Focus()
                txtNoTarjeta.SelectAll()

            End If
        End If
    End Sub

    Private Sub CbxBanco_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBancoTarjeta.KeyDown
        If cbxBancoTarjeta.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                txtNoAprobacion.Focus()
                txtNoAprobacion.SelectAll()


            ElseIf e.KeyCode = Keys.Down Then
                e.Handled = True

                If txtCheque.Enabled = True Then
                    NavBarCheque.Expanded = True
                    txtCheque.Focus()
                    txtCheque.SelectAll()
                Else
                    btnContinuar.Focus()
                End If

            ElseIf e.KeyCode = Keys.Up Then
                e.Handled = True

                cbxAño.Focus()
                cbxAño.ShowPopup()

            End If
        End If
    End Sub

    Private Sub txtNoAprobacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoAprobacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            If CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
                NavBarCheque.Expanded = True
                NavBarTarjeta.Expanded = False
                txtCheque.Focus()
                txtCheque.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            rdbTipoTarjeta.Focus()

        End If
    End Sub

    Private Sub txtEfectivoCobrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivoCobrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtMontoCobrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMontoCobrar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub btnContinuar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnContinuar.KeyDown
        If e.KeyCode = Keys.Down Then
            e.Handled = True

            btnCancelar.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

        End If
    End Sub

    Private Sub btnCancelar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCancelar.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True

            btnContinuar.Focus()
        End If
    End Sub


    Private Sub txtTarjeta_EditValueChanged(sender As Object, e As EventArgs) Handles txtTarjeta.EditValueChanged
        If CDbl(txtTarjeta.EditValue) = 0 Then
            lblClaseTarjeta.Properties.Items.Clear()
            lblClaseTarjeta.Enabled = False
            lblClaseTarjeta.Text = ""
            txtNoTarjeta.Enabled = False
            cbxMes.Enabled = False
            cbxAño.Enabled = False
            cbxBancoTarjeta.Enabled = False
            rdbTipoTarjeta.Enabled = False
            gcAprobacion.Enabled = False
            txtNoTarjeta.Text = ""
            cbxMes.Properties.Items.Clear()
            cbxMes.Text = ""
            cbxAño.Properties.Items.Clear()
            cbxAño.Text = ""
            cbxBancoTarjeta.Text = "N/A"
            txtNoAprobacion.Text = ""
            RutaDocumento = ""
            txtTarjeta.SelectAll()
        Else
            HabilitarPagoTarjeta()
        End If


        If txtTarjeta.Focused Then
            If CDbl(txtTarjeta.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
                If txtTarjeta.Focused = True Then
                    txtTarjeta.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue))
                End If

            Else
                txtEfectivo.Enabled = True
                txtCheque.Enabled = True
                txtDeposito.Enabled = True
                txtPermuta.Enabled = True
                txtBonos.Enabled = True
                txtCobrosAdelantados.Enabled = True
                txtIDCredito.Enabled = True
                btnBuscarCreditos.Enabled = True
            End If
        Else
            txtEfectivo.Enabled = True
            txtCheque.Enabled = True
            txtDeposito.Enabled = True
            txtPermuta.Enabled = True
            txtBonos.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If


        SumarEfectivos()

    End Sub

    Private Sub txtDevuelta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDevuelta.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormatoNavBarEfectivo()
        If FlowBotones.Controls.Count <= 5 Then
            FlowBotones.Height = 50
            SeparatorControl4.Location = New Point(-8, 43)

            Label10.Location = New Point(0, 62)
            txtEfectivo.Location = New Point(96, 59)
            SeparatorControl3.Location = New Point(-12, 76)
            Label11.Location = New Point(42, 96)
            txtDevolucionEfectivo.Location = New Point(96, 93)
            ListadeDevolucion.Location = New Point(224, 56)
            NavBarGroupControlContainer1.Height = 118 + ((ListadeDevolucion.Items.Count) * 15)
        Else
            FlowBotones.Height = 100
            SeparatorControl4.Location = New Point(-8, 97)
            Label10.Location = New Point(0, 121)
            txtEfectivo.Location = New Point(96, 118)
            SeparatorControl3.Location = New Point(-12, 135)
            Label11.Location = New Point(42, 155)
            txtDevolucionEfectivo.Location = New Point(96, 152)
            ListadeDevolucion.Location = New Point(224, 115)
            NavBarGroupControlContainer1.Height = 176 + ((ListadeDevolucion.Items.Count + 1) * 15)

        End If
    End Sub

    Private Sub txtEfectivo_EditValueChanged(sender As Object, e As EventArgs) Handles txtEfectivo.EditValueChanged
        If CDbl(txtEfectivo.EditValue) = 0 Then
            txtEfectivo.SelectAll()
        End If

        'Calculo de devolucion de efectivo
        If CDbl(txtEfectivo.EditValue) = 0 Then
            txtDevolucionEfectivo.EditValue = 0
        Else

            If CDbl(txtEfectivo.Text) <= CDbl(txtMontoCobrar.Text) Then
                txtDevolucionEfectivo.EditValue = 0
            Else
                txtDevolucionEfectivo.Text = (CDbl(txtEfectivo.EditValue) - CDbl(txtMontoCobrar.EditValue)).ToString("C")
            End If
        End If

        'Calculo de tamaños de flow panel y lista de devoluciones
        FormatoNavBarEfectivo()

        If txtEfectivo.Focused Then
            If CDbl(txtEfectivo.EditValue) >= CDbl(txtMontoCobrar.EditValue) Then
                txtTarjeta.EditValue = 0
                txtTarjeta.Enabled = False

                txtCheque.EditValue = 0
                txtCheque.Enabled = False

                txtDeposito.EditValue = 0
                txtDeposito.Enabled = False

                txtPermuta.EditValue = 0
                txtPermuta.Enabled = False
                txtBonos.Enabled = False
                txtBonos.EditValue = 0
                txtCobrosAdelantados.Enabled = False
                txtCobrosAdelantados.EditValue = 0
                txtIDCredito.Enabled = False
                btnBuscarCreditos.Enabled = False
                txtMontoCredito.EditValue = 0
                txtIDCredito.Text = ""
                txtIDCredito.Tag = ""
                txtBalanceUtilizado.Text = CDbl(0).ToString("C")
                txtBalanceGenerado.Text = CDbl(0).ToString("C")
                txtBalanceCredito.Text = CDbl(0).ToString("C")
            Else
                txtTarjeta.Enabled = True
                txtCheque.Enabled = True
                txtDeposito.Enabled = True
                txtPermuta.Enabled = True
                txtBonos.Enabled = True
                txtCobrosAdelantados.Enabled = True
                txtIDCredito.Enabled = True
                btnBuscarCreditos.Enabled = True
            End If
        Else
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtDeposito.Enabled = True
            txtPermuta.Enabled = True
            txtBonos.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If


        SumarEfectivos()

    End Sub

    Private Sub txtDevolucionEfectivo_EditValueChanged(sender As Object, e As EventArgs) Handles txtDevolucionEfectivo.EditValueChanged
        Try
            If txtDevolucionEfectivo.EditValue >= 0 Then
                txtDevolucionEfectivo.ForeColor = Color.White
                txtDevolucionEfectivo.BackColor = Color.Gray

                ListadeDevolucion.Items.Clear()

                NavBarTarjeta.Expanded = False
                NavBarCheque.Expanded = False
                NavBarDeposito.Expanded = False
                NavBarBonos.Expanded = False
                NavBarCreditos.Expanded = False

                CalcularMejorDevolucion(txtDevolucionEfectivo.Text)
            Else
                txtDevolucionEfectivo.ForeColor = Color.Red
                txtDevolucionEfectivo.BackColor = Color.White
                ListadeDevolucion.Items.Clear()
                NavBarGroupControlContainer1.Height = 118

                NavBarTarjeta.Expanded = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try

            If Me.Owner.Name = frm_facturacion.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar la factura?", "Detener Proceso de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago de factura.", "La Factura no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If

            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar la factura?", "Detener Proceso de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago de factura.", "La Factura no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If


            ElseIf Me.Owner.Name = frm_financiamiento.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar la factura del financiamiento?", "Detener Proceso de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago de factura.", "La Factura no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If

            ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar la factura?", "Detener Proceso de Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago de factura.", "La Factura no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                End If
                Close()
            ElseIf Me.Owner.Name = frm_recibo_pagos.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar el abono?", "Detener Proceso de Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result1 = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago.", "El abono no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If


            ElseIf Me.Owner.Name = frm_cuotas_financiamientos.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar el abono?", "Detener Proceso de Abono", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result1 = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro al pago.", "El abono no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If


            ElseIf Me.Owner.Name = frm_otros_ingresos.Name Then
                If IDTransaccion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar el ingreso?", "Detener Otros Ingresos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        ClosingWithButton = True
                        ControlSuperClave = 1
                        MessageBox.Show("Se canceló el registro de otros ingresos.", "El recibo no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                    Else
                        Exit Sub
                    End If
                Else
                    ControlSuperClave = 1
                    ClosingWithButton = True
                    Close()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageEdit1_Click(sender As Object, e As EventArgs) Handles ImageEdit1.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = RutaDocumento

            If RutaDocumento <> "" Then
                If System.IO.File.Exists(RutaDocumento) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDocumento, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If
        End If
    End Sub

    Private Sub btnBuscarCreditos_Click_1(sender As Object, e As EventArgs) Handles btnBuscarCreditos.Click
        'Try

        Dim DsTemp As New DataSet
        DsTemp.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDDevolucionVenta,Fecha,Devolver FROM" & SysName.Text & "devolucionventa Where SecondID='" + txtIDCredito.Text + "' and IDTipoDevolucion=1", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "devolucionventa")
        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("devolucionventa")

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se ha encontrado ninguna devolución y/o crédito con el número específicado." & vbNewLine & vbNewLine & "Por favor revise el número y vuelta a intentarlo.", "Crédito no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Else
            Panel1.Visible = True

            ConMixta.Open()
            cmd = New MySqlCommand("Select coalesce(sum(Credito), 0) FROM" & SysName.Text & "transaccion where IDCredito='" + Tabla.Rows(0).Item("IDDevolucionVenta").ToString + "'", ConMixta)
            Dim MontoDisponible As Double = CDbl(Tabla.Rows(0).Item("Devolver").ToString) - Convert.ToDouble(cmd.ExecuteScalar())
            ConMixta.Close()

            If MontoDisponible = 0 Then
                MessageBox.Show("El crédito No. " & txtIDCredito.Text & " ha sido agotado en su totalidad por lo que se pueden realizar transacciones.", "Crédito agotado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Else
                Dim VencimientoCredito As Date = CDate(Tabla.Rows(0).Item("Fecha")).AddDays(30)

                If VencimientoCredito >= Today Then
                    Label27.ForeColor = Color.Green
                    Label27.Text = "Este boucher de crédito vencerá en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).AddDays(30).ToString("dd/MM/yyyy") & ". Tiene " & DateDiff(DateInterval.Day, Today, CDate(Tabla.Rows(0).Item("Fecha")).AddDays(30)) & " para usar el crédito."
                    txtIDCredito.ReadOnly = True
                    btnBuscarCreditos.Visible = False

                    txtIDCredito.Tag = Tabla.Rows(0).Item("IDDevolucionVenta").ToString
                    txtBalanceCredito.Text = MontoDisponible.ToString("C")
                    txtBalanceGenerado.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                    txtBalanceUtilizado.Text = (CDbl(Tabla.Rows(0).Item("Devolver")) - MontoDisponible).ToString("C")
                    txtEfectivo.EditValue = CDbl(0)
                    If MontoDisponible > CDbl(txtMontoCobrar.Text) Then
                        txtMontoCredito.EditValue = CDbl(txtMontoCobrar.Text)
                    Else
                        txtMontoCredito.EditValue = MontoDisponible
                    End If
                    txtMontoCredito.Enabled = True

                    txtMontoCredito.Focus()
                    txtMontoCredito.SelectAll()
                Else
                    Label27.ForeColor = Color.Red
                    Label27.Text = "Este boucher de crédito venció en fecha " & CDate(Tabla.Rows(0).Item("Fecha")).AddDays(30).ToString("dd/MM/yyyy") & " No se puede utilizar para procesar transacciones."
                    txtIDCredito.Tag = Tabla.Rows(0).Item("IDDevolucionVenta").ToString
                    txtBalanceCredito.Text = MontoDisponible.ToString("C")
                    txtBalanceGenerado.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                    txtBalanceUtilizado.Text = (CDbl(Tabla.Rows(0).Item("Devolver")) - MontoDisponible).ToString("C")
                    txtEfectivo.EditValue = CDbl(0)
                    txtMontoCredito.Enabled = False
                    txtMontoCredito.Text = CDbl(0)
                End If



            End If

        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub txtTarjeta_Leave(sender As Object, e As EventArgs) Handles txtTarjeta.Leave
        Try
            If txtTarjeta.Text = "" Then
                txtTarjeta.EditValue = CDbl(0)

                If CDbl(txtTarjeta.EditValue) = 0 Then
                    lblClaseTarjeta.Properties.Items.Clear()
                    lblClaseTarjeta.Enabled = False
                    txtNoTarjeta.Enabled = False
                    cbxMes.Enabled = False
                    cbxAño.Enabled = False
                    cbxBancoTarjeta.Enabled = False
                    rdbTipoTarjeta.Enabled = False
                    gcAprobacion.Enabled = False
                    txtNoTarjeta.Text = ""
                    cbxMes.Properties.Items.Clear()
                    cbxAño.Properties.Items.Clear()
                    cbxBancoTarjeta.Text = "N/A"
                    txtNoAprobacion.Text = ""
                    RutaDocumento = ""
                    txtTarjeta.SelectAll()
                End If


            Else

                If Me.Owner.Name = frm_facturacion.Name Then

                    If CDbl(txtTarjeta.Text) > 0 Then
                        Dim TotalArticulosBloqueados As Double = 0
                        Dim ArticulosListados As String
                        frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Clear()

                        ConLibregco.Open()
                        For Each Rw As DataGridViewRow In frm_facturacion.dgvArticulosFactura.Rows
                            cmd = New MySqlCommand("Select NoPagoTarjeta from Articulos where IDArticulo='" + Rw.Cells(6).Value.ToString + "'", ConLibregco)
                            If Convert.ToString(cmd.ExecuteScalar) = 1 Then
                                ArticulosListados = ArticulosListados & vbNewLine & Rw.Cells(7).Value
                                TotalArticulosBloqueados += CDbl(Rw.Cells(11).Value)
                                frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Add(Rw.Cells(7).Value, "No aplica")
                            End If
                        Next
                        ConLibregco.Close()



                        If TotalArticulosBloqueados > 0 Then
                            If CDbl(txtTarjeta.Text) > (CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados) Then
                                MessageBox.Show("Existen algunos artículos que se encuentran bloqueados para el pago con tarjeta de crédito y/o débito" & vbNewLine & ArticulosListados & vbNewLine & vbNewLine & "Para realizar esta operación el monto a pagar vía tarjeta de crédito o débito no puede ser mayor a " & CDbl(CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados).ToString("C"), "Ha excedido el monto de pago con tarjeta permitido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                                If (CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados) > 0 Then
                                    txtTarjeta.EditValue = (CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados)
                                Else
                                    txtTarjeta.EditValue = CDbl(0)
                                End If

                                frm_articulos_noaplicatarjeta.Show(Me)
                                Exit Sub

                            End If
                        End If



                    End If


                End If


                txtTarjeta.EditValue = CDbl(txtTarjeta.Text)
            End If

        Catch ex As Exception
            txtTarjeta.Text = CDbl(0).ToString("C")
        End Try


    End Sub

    Private Sub txtEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True


            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then
                NavBarTarjeta.Expanded = True
                txtTarjeta.Focus()
                txtTarjeta.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            '    cbxMoneda.Focus()
            '    cbxMoneda.ShowPopup()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            If txtEfectivo.EditValue = 0 Then
                NavBarTarjeta.Expanded = True
                txtTarjeta.Focus()
                txtTarjeta.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        End If
    End Sub

    Private Sub txtCheque_EditValueChanged(sender As Object, e As EventArgs) Handles txtCheque.EditValueChanged

        If txtCheque.EditValue = 0 Then
            txtCheque.SelectAll()
            cbxBancoCheque.Enabled = False
            cbxBancoCheque.Text = "N/A"
            txtNoCheque.Enabled = False
            txtNoCheque.Text = ""
        Else
            cbxBancoCheque.Enabled = True
            txtNoCheque.Enabled = True
        End If

        If CDbl(txtCheque.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
            If txtCheque.Focused = True Then
                txtCheque.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtDeposito.Enabled = True
            txtPermuta.Enabled = True
            txtBonos.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If

        SumarEfectivos()

    End Sub

    Private Sub txtDeposito_EditValueChanged(sender As Object, e As EventArgs) Handles txtDeposito.EditValueChanged
        If txtDeposito.EditValue = 0 Then
            txtDeposito.SelectAll()
            cbxBancoDeposito.Enabled = False
            cbxBancoCheque.Text = "N/A"
            txtInformacionDeposito.Enabled = False
            txtInformacionDeposito.Text = ""
        Else
            cbxBancoDeposito.Enabled = True
            txtInformacionDeposito.Enabled = True
        End If

        If CDbl(txtDeposito.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
            If txtDeposito.Focused = True Then
                txtDeposito.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtPermuta.Enabled = True
            txtBonos.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If

        SumarEfectivos()
    End Sub

    Private Sub txtBonos_EditValueChanged(sender As Object, e As EventArgs) Handles txtBonos.EditValueChanged
        If txtBonos.EditValue = 0 Then
            txtBonos.SelectAll()
        End If

        If CDbl(txtBonos.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
            If txtBonos.Focused = True Then
                txtBonos.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtPermuta.Enabled = True
            txtDeposito.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If

        SumarEfectivos()
    End Sub

    Private Sub TextEdit12_EditValueChanged(sender As Object, e As EventArgs) Handles txtPermuta.EditValueChanged
        If txtPermuta.EditValue = 0 Then
            txtPermuta.SelectAll()
        End If

        If CDbl(txtPermuta.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
            If txtPermuta.Focused = True Then
                txtPermuta.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtBonos.Enabled = True
            txtDeposito.Enabled = True
            txtCobrosAdelantados.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If

        SumarEfectivos()
    End Sub

    Private Sub txtOtros_EditValueChanged(sender As Object, e As EventArgs) Handles txtCobrosAdelantados.EditValueChanged
        If txtCobrosAdelantados.EditValue = 0 Then
            txtCobrosAdelantados.SelectAll()
            GridControl1.Enabled = False
            TablaCobrosAdelantadados.Rows.Clear()
        Else
            GridControl1.Enabled = True
        End If

        If CDbl(txtCobrosAdelantados.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtMontoCredito.EditValue)) Then
            If txtCobrosAdelantados.Focused = True Then
                txtCobrosAdelantados.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtMontoCredito.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtBonos.Enabled = True
            txtDeposito.Enabled = True
            txtPermuta.Enabled = True
            txtIDCredito.Enabled = True
            btnBuscarCreditos.Enabled = True
        End If

        SumarEfectivos()

    End Sub

    Private Sub txtMontoCredito_EditValueChanged(sender As Object, e As EventArgs) Handles txtMontoCredito.EditValueChanged
        If txtMontoCredito.EditValue = 0 Then
            txtMontoCredito.SelectAll()
        End If


        If CDbl(txtMontoCredito.EditValue) >= CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue)) Then
            If txtMontoCredito.Focused = True Then
                txtMontoCredito.EditValue = CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue))
            End If
        Else
            txtEfectivo.Enabled = True
            txtTarjeta.Enabled = True
            txtCheque.Enabled = True
            txtBonos.Enabled = True
            txtDeposito.Enabled = True
            txtPermuta.Enabled = True
            txtCobrosAdelantados.Enabled = True
        End If

        SumarEfectivos()
    End Sub

    Private Sub txtEfectivoCobrar_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivoCobrar.TextChanged
        If CDbl(CDbl(txtTarjeta.EditValue) + CDbl(txtCheque.EditValue) + CDbl(txtDeposito.EditValue) + CDbl(txtPermuta.EditValue) + CDbl(txtBonos.EditValue) + CDbl(txtCobrosAdelantados.EditValue) + CDbl(txtMontoCredito.EditValue)) >= CDbl(txtMontoCobrar.EditValue) Then
            txtDevolucionEfectivo.Visible = False
            ListadeDevolucion.Visible = False
            SeparatorControl3.Visible = False
            Label11.Visible = False
        Else
            txtDevolucionEfectivo.Visible = True
            ListadeDevolucion.Visible = True
            SeparatorControl3.Visible = True
            Label11.Visible = True
        End If
    End Sub


    Private Sub VerificarTiposCompletos()
        If CDbl(CDbl(txtEfectivo.EditValue) - CDbl(txtDevolucionEfectivo.EditValue) + CDbl(txtTarjeta.EditValue) + CDbl(txtCheque.EditValue) + CDbl(txtDeposito.EditValue) + CDbl(txtBonos.EditValue) + CDbl(txtPermuta.EditValue) + CDbl(txtCobrosAdelantados.EditValue) + CDbl(txtMontoCredito.EditValue)) >= CDbl(txtMontoCobrar.EditValue) Then
            If txtEfectivo.EditValue = 0 Then
                txtEfectivo.Enabled = False
            Else
                txtEfectivo.Enabled = True
            End If
            If txtTarjeta.EditValue = 0 Then
                txtTarjeta.Enabled = False
            Else
                txtTarjeta.Enabled = True
            End If
            If txtCheque.EditValue = 0 Then
                txtCheque.Enabled = False
            Else
                txtCheque.Enabled = True
            End If
            If txtDeposito.EditValue = 0 Then
                txtDeposito.Enabled = False
            Else
                txtDeposito.Enabled = True
            End If
            If txtBonos.EditValue = 0 Then
                txtBonos.Enabled = False
            Else
                txtBonos.Enabled = True
            End If
            If txtPermuta.EditValue = 0 Then
                txtPermuta.Enabled = False
            Else
                txtPermuta.Enabled = True
            End If
            If txtCobrosAdelantados.EditValue = 0 Then
                txtCobrosAdelantados.Enabled = False
            Else
                txtCobrosAdelantados.Enabled = True
            End If
            If txtMontoCredito.EditValue = 0 Then
                txtMontoCredito.Enabled = False
            Else
                txtMontoCredito.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtBonos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBonos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True

            txtPermuta.Focus()
            txtPermuta.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            txtPermuta.Focus()
            txtPermuta.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            NavBarBonos.Expanded = False
            NavBarDeposito.Expanded = True
            txtDeposito.Focus()
            txtDeposito.SelectAll()

        End If
    End Sub

    Private Sub txtPermuta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPermuta.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True

            txtCobrosAdelantados.Focus()
            txtCobrosAdelantados.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            txtCobrosAdelantados.Focus()
            txtCobrosAdelantados.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtBonos.Focus()
            txtBonos.SelectAll()

        End If
    End Sub

    Private Sub txtOtros_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCobrosAdelantados.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                If CDbl(txtBonos.EditValue) + CDbl(txtPermuta.EditValue) + CDbl(txtCobrosAdelantados.EditValue) = 0 Then
                    NavBarBonos.Expanded = False
                End If

                NavBarCreditos.Expanded = True
                txtIDCredito.Focus()
                txtIDCredito.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True

            txtIDCredito.Focus()
            txtIDCredito.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If CDbl(CDbl(txtMontoCobrar.EditValue) - CDbl(txtEfectivo.EditValue) + CDbl(txtDevolucionEfectivo.EditValue) - CDbl(txtTarjeta.EditValue) - CDbl(txtCheque.EditValue) - CDbl(txtDeposito.EditValue) - CDbl(txtBonos.EditValue) - CDbl(txtPermuta.EditValue) - CDbl(txtCobrosAdelantados.EditValue) - CDbl(txtMontoCredito.EditValue)) > 0 Then

                If CDbl(txtBonos.EditValue) + CDbl(txtPermuta.EditValue) + CDbl(txtCobrosAdelantados.EditValue) = 0 Then
                    NavBarBonos.Expanded = False
                End If

                NavBarCreditos.Expanded = True
                txtIDCredito.Focus()
                txtIDCredito.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtPermuta.Focus()
            txtPermuta.SelectAll()

        End If
    End Sub

    Private Sub VerificarEditValues()
        If txtEfectivo.EditValue < 0 Then
            txtEfectivo.EditValue = 0
        End If
        If txtTarjeta.EditValue < 0 Then
            txtTarjeta.EditValue = 0
        End If
        If txtCheque.EditValue < 0 Then
            txtCheque.EditValue = 0
        End If
        If txtDeposito.EditValue < 0 Then
            txtDeposito.EditValue = 0
        End If
        If txtBonos.EditValue < 0 Then
            txtBonos.EditValue = 0
        End If
        If txtPermuta.EditValue < 0 Then
            txtPermuta.EditValue = 0
        End If
        If txtCobrosAdelantados.EditValue < 0 Then
            txtCobrosAdelantados.EditValue = 0
        End If
        If txtMontoCredito.EditValue < 0 Then
            txtMontoCredito.EditValue = 0
        End If
    End Sub
    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        'Try
        frm_facturacion.lblStatusBar.Text = "Verificando valores de los campos."
        VerificarEditValues()

        If Me.Owner.Name = frm_facturacion.Name Then
            If frm_facturacion.lblDiasCondicion.Text = 0 Then
                frm_facturacion.lblStatusBar.Text = "Verificando montos a cobrar."
                If CDbl(txtMontoCobrar.Text) <= 0 Then
                    MessageBox.Show("El monto a cobrar es igual a 0.")
                    Exit Sub
                End If
            Else
                If CDbl(CDbl(txtEfectivo.EditValue) - CDbl(txtDevolucionEfectivo.EditValue) + CDbl(txtTarjeta.EditValue) + CDbl(txtCheque.EditValue) + CDbl(txtDeposito.EditValue)) <> CDbl(txtMontoCobrar.Text) Then
                    MessageBox.Show("No es posible continuar ya que el monto aplicado como forma de pago es diferente al monto del inicial específicado en la factura.", "Diferencias entre montos a aplicar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf CDbl(txtMontoCobrar.EditValue) <> CDbl(frm_facturacion.txtInicial.Text) Then
                    MessageBox.Show("No es posible continuar ya que el monto aplicado como forma de pago es diferente al monto del inicial específicado en la factura.", "Diferencias entre montos a aplicar", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If


        End If

        If CDbl(txtDevuelta.Text) >= 2000 Then
            frm_facturacion.lblStatusBar.Text = "Verificando montos de devolución."
            ControlSuperClave = 1
            frm_superclave.IDAccion.Text = 116
            frm_superclave.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            End If
        End If

        frm_facturacion.lblStatusBar.Text = "Verificando montos a recibir."
        If CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
            MessageBox.Show("El monto a recibir debe ser igual o mayor al total a pagar. Verifique los datos suministrados para continuar.", "Error en el cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            txtEfectivo.Focus()
            Exit Sub
        End If

        VerificarTarjeta()
        If ControlStatus.Text = 1 Then
            Exit Sub
        End If

        VerificarPosCheque()
        If ControlStatus.Text = 1 Then
            Exit Sub
        End If

        VerificarDeposito()
        If ControlStatus.Text = 1 Then
            Exit Sub
        End If

        'Verificando cobros adelantados
        If CDbl(txtCobrosAdelantados.EditValue) > 0 Then
            If CDbl(txtCobrosAdelantados.EditValue) <> CDbl(AdvBandedGridView1.Columns("Utilizar").SummaryItem.SummaryValue) Then
                MessageBox.Show("Los montos de cobros adelantados no cuadran con el específicado para utilizar como pago.", "Error en el cálculo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtCobrosAdelantados.Focus()
                Exit Sub
            End If
        End If

        'Verificacion de bloqueos de pagos con tarjeta sobre articulos
        If Me.Owner.Name = frm_facturacion.Name Then
            If CDbl(txtTarjeta.EditValue) > 0 Then

                frm_facturacion.lblStatusBar.Text = "Verificando pagos con tarjeta en artículos"

                If CInt(DTConfiguracion.Rows(150 - 1).Item("Value2Int")) = 1 Then
                    frm_creditcard_notallowed.ShowDialog(Me)
                    Exit Sub
                End If

                frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Clear()
                Dim TotalArticulosBloqueados As Double = 0
                Dim ArticulosListados As String

                ConLibregco.Open()
                For Each Rw As DataGridViewRow In frm_facturacion.dgvArticulosFactura.Rows
                    cmd = New MySqlCommand("Select NoPagoTarjeta from Articulos where IDArticulo='" + Rw.Cells(6).Value.ToString + "'", ConLibregco)
                    If Convert.ToString(cmd.ExecuteScalar) = 1 Then
                        ArticulosListados = ArticulosListados & vbNewLine & Rw.Cells(7).Value
                        TotalArticulosBloqueados += CDbl(Rw.Cells(11).Value)
                        frm_articulos_noaplicatarjeta.DgvArticulos.Rows.Add(Rw.Cells(7).Value, "No aplica")
                    End If
                Next
                ConLibregco.Close()

                If CDbl(txtTarjeta.EditValue) > (CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados) Then
                    MessageBox.Show("Existen algunos artículos que se encuentran bloqueados para el pago con tarjeta de crédito y/o débito" & vbNewLine & vbNewLine & ArticulosListados & vbNewLine & vbNewLine & "Para realizar esta operación el monto a pagar vía tarjeta de crédito o débito no puede ser mayor a " & CDbl(CDbl(frm_facturacion.txtNeto.Text) - TotalArticulosBloqueados).ToString("C"), "Ha excedido el monto de pago con tarjeta permitido", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    frm_articulos_noaplicatarjeta.ShowDialog(Me)
                    Exit Sub
                End If
            End If
        End If

        If IDTransaccion.Text = "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Este es el último paso para procesar la transacción." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Procesar Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_facturacion.lblStatusBar.Text = "Iniciando proceso de transacción..."
                ClosingWithButton = True
                frm_facturacion.lblStatusBar.Text = "Insertando forma de pago a la base de datos"
                sqlQ = "INSERT INTO" & SysName.Text & "Transaccion (Fecha,IDTipoDocumento,IDMoneda,Efectivo,DevueltaEfectivo,Cheque,ChequeBanco,NoCheque,Deposito,DepositoBanco,Informacion,Credito,IDCredito,MontoUtilizado,MontoDisponible,ClaseTarjeta,Tarjeta,NoTarjeta,TipoTarjeta,Mes,Año,Banco,NoAprobacion,Recibido,MontoCobrar,Devuelta,RutaBoucher,Bonos,Permuta,Otras) Values (curdate(),'" + txtIDTipoDocumento.Text + "','" + cbxMoneda.EditValue.ToString + "','" + CDbl(txtEfectivo.EditValue).ToString + "','" + CDbl(txtDevolucionEfectivo.EditValue).ToString + "','" + CDbl(txtCheque.EditValue).ToString + "','" + cbxBancoCheque.Text.ToString + "','" + txtNoCheque.Text + "','" + CDbl(txtDeposito.EditValue).ToString + "','" + cbxBancoDeposito.Text.ToString + "','" + txtInformacionDeposito.Text + "','" + CDbl(txtMontoCredito.EditValue).ToString + "','" + txtIDCredito.Tag.ToString + "','" + CDbl(txtBalanceUtilizado.Text).ToString + "','" + CDbl(txtBalanceCredito.Text).ToString + "','" + lblClaseTarjeta.Text + "','" + CDbl(txtTarjeta.EditValue).ToString + "','" + txtNoTarjeta.Text + "','" + GetTipodeTarjeta().ToString + "','" + cbxMes.Text + "','" + cbxAño.Text + "','" + cbxBancoTarjeta.Text + "','" + txtNoAprobacion.Text + "','" + CDbl(txtEfectivoCobrar.Text).ToString + "','" + CDbl(txtMontoCobrar.Text).ToString + "','" + CDbl(txtDevuelta.Text).ToString + "','" + RutaDocumento + "','" + CDbl(txtBonos.EditValue).ToString + "','" + CDbl(txtPermuta.EditValue).ToString + "','" + CDbl(txtCobrosAdelantados.EditValue).ToString + "')"
                GuardarDatos()

                frm_facturacion.lblStatusBar.Text = "Consiguiendo # de transacción"
                UltTransaccion()
                frm_facturacion.lblStatusBar.Text = "Devolviendo valor de la transacción al proceso"
                UpdateTransaccion()
                CobrosAdelantadosChilds
                MoverFichero()
                ControlSuperClave = 0
            Else
                Exit Sub
            End If
        Else
            frm_facturacion.lblStatusBar.Text = "Modificando proceso de transacción..."
            sqlQ = "UPDATE Transaccion SET IDMoneda='" + cbxMoneda.EditValue.ToString + "',Efectivo='" + CDbl(txtEfectivo.EditValue).ToString + "',DevueltaEfectivo='" + CDbl(txtDevolucionEfectivo.Text).ToString + "',Cheque='" + CDbl(txtCheque.EditValue).ToString + "',ChequeBanco='" + cbxBancoCheque.Text + "',NoCheque='" + txtNoCheque.Text + "',Deposito='" + CDbl(txtDeposito.EditValue).ToString + "',DepositoBanco='" + cbxBancoDeposito.Text + "',Informacion='" + txtInformacionDeposito.Text + "',Credito='" + CDbl(txtMontoCredito.EditValue).ToString + "',IDCredito='" + txtIDCredito.Tag.ToString + "',MontoUtilizado='" + CDbl(txtBalanceUtilizado.Text).ToString + "',MontoDisponible='" + CDbl(txtBalanceCredito.Text).ToString + "',ClaseTarjeta='" + lblClaseTarjeta.Text + "',Tarjeta='" + CDbl(txtTarjeta.Text).ToString + "',TipoTarjeta='" + lblClaseTarjeta.Text + "',NoTarjeta='" + txtNoTarjeta.Text + "',TipoTarjeta='" + lblClaseTarjeta.Text + "',Mes='" + cbxMes.Text + "',Año='" + cbxAño.Text + "',Banco='" + cbxBancoTarjeta.Text + "',NoAprobacion='" + txtNoAprobacion.Text + "',Recibido='" + CDbl(txtEfectivoCobrar.Text).ToString + "',MontoCobrar='" + CDbl(txtMontoCobrar.Text).ToString + "',Devuelta='" + CDbl(txtDevuelta.Text).ToString + "',RutaBoucher='" + RutaDocumento + "',Bonos='" + CDbl(txtBonos.EditValue).ToString + "',Permuta='" + CDbl(txtPermuta.EditValue).ToString + "',Otras='" + CDbl(txtCobrosAdelantados.EditValue).ToString + "' WHERE IDTransaccion= (" + IDTransaccion.Text + ")"
            ClosingWithButton = True
            GuardarDatos()
            CobrosAdelantadosChilds
            MoverFichero()
            ControlSuperClave = 0
        End If

        txtEfectivo.Focus()
        txtEfectivo.SelectAll()


        If CDbl(txtDevuelta.Text) > 0 Then
            frm_facturacion.lblStatusBar.Text = "Mostrando montos detallados de devolución"
            If frm_show_montodevuelta.Visible = True Then
                frm_show_montodevuelta.Close()
            End If

            frm_show_montodevuelta.Show()
        End If


        Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub CobrosAdelantadosChilds()
        For i As Integer = 0 To AdvBandedGridView1.DataRowCount - 1
            If CStr(AdvBandedGridView1.GetRowCellValue(i, "IDCobrosAdelantados_hijo")) = "" Then
                If CDbl(AdvBandedGridView1.GetRowCellValue(i, "Utilizar")) > 0 Then
                    sqlQ = "Insert into Cobrosadelantados_hijos (IDCobrosAdelantados,IDTransaccion,Monto) Values ('" + AdvBandedGridView1.GetRowCellValue(i, "IDCobrosAdelantados").ToString + "','" + IDTransaccion.Text + "','" + AdvBandedGridView1.GetRowCellValue(i, "Utilizar").ToString + "')"
                    GuardarDatos()

                    If Con.State = ConnectionState.Open Then
                        Con.Close()
                    End If

                    Con.Open()
                    cmd = New MySqlCommand("Select IDCobrosAdelantados_hijo from Cobrosadelantados_hijos where IDCobrosAdelantados_hijo= (Select Max(IDCobrosAdelantados_hijo) from Cobrosadelantados_hijos)", Con)
                    AdvBandedGridView1.SetRowCellValue(i, "IDCobrosAdelantados_hijo", Convert.ToString(cmd.ExecuteScalar()))
                    Con.Close()
                End If
            End If
        Next
    End Sub
    Private Sub txtEfectivo_Enter(sender As Object, e As EventArgs) Handles txtEfectivo.Enter
        txtEfectivo.SelectAll()
    End Sub

    Private Sub txtTarjeta_Enter(sender As Object, e As EventArgs) Handles txtTarjeta.Enter
        txtTarjeta.SelectAll()
    End Sub

    Private Sub txtCheque_Enter(sender As Object, e As EventArgs) Handles txtCheque.Enter
        txtCheque.SelectAll()
    End Sub

    Private Sub txtDeposito_Enter(sender As Object, e As EventArgs) Handles txtDeposito.Enter
        txtDeposito.SelectAll()
    End Sub

    Private Sub txtBonos_Enter(sender As Object, e As EventArgs) Handles txtBonos.Enter
        txtBonos.SelectAll()
    End Sub

    Private Sub txtPermuta_Enter(sender As Object, e As EventArgs) Handles txtPermuta.Enter
        txtPermuta.SelectAll()
    End Sub

    Private Sub txtOtros_Enter(sender As Object, e As EventArgs) Handles txtCobrosAdelantados.Enter
        txtCobrosAdelantados.SelectAll()
    End Sub

    Private Sub txtMontoCredito_Enter(sender As Object, e As EventArgs) Handles txtMontoCredito.Enter
        txtMontoCredito.SelectAll()
    End Sub

    Private Sub cbxMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMoneda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True

            If cbxMoneda.IsPopupOpen = False Then
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            End If


        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True

            If cbxMoneda.IsPopupOpen = False Then
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            End If


        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If cbxMoneda.IsPopupOpen = False Then
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            End If


        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            If cbxMoneda.IsPopupOpen = False Then
                txtEfectivo.Focus()
                txtEfectivo.SelectAll()
            End If

        End If
    End Sub

    Private Sub lblClaseTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles lblClaseTarjeta.KeyDown
        If lblClaseTarjeta.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Left Then
                e.Handled = True
                txtTarjeta.Focus()
                txtTarjeta.SelectAll()


            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                txtNoAprobacion.Focus()
                txtNoAprobacion.SelectAll()


                'ElseIf e.KeyCode = Keys.Down Then
                '    e.Handled = True
                '    txtNoTarjeta.Focus()
                '    txtTarjeta.SelectAll()

                'ElseIf e.KeyCode = Keys.Up Then
                '    e.Handled = True

                '    txtEfectivo.Focus()
                '    txtEfectivo.SelectAll()

            End If
        End If
    End Sub

    Private Sub rdbVisa_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbVisa.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            lblClaseTarjeta.Focus()
            lblClaseTarjeta.ShowPopup()

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            rdbMasterCard.Focus()
            rdbMasterCard.Checked = True

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

        End If
    End Sub

    Private Sub rdbMasterCard_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbMasterCard.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            rdbVisa.Focus()
            rdbVisa.Checked = True

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            rdbAmericanExpress.Focus()
            rdbAmericanExpress.Checked = True

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

        End If
    End Sub

    Private Sub rdbAmericanExpress_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbAmericanExpress.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            rdbMasterCard.Focus()
            rdbMasterCard.Checked = True

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            rdbOtra.Focus()
            rdbOtra.Checked = True

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

        End If
    End Sub

    Private Sub rdbOtra_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbOtra.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            rdbAmericanExpress.Focus()
            rdbAmericanExpress.Checked = True

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtNoAprobacion.Focus()
            txtNoAprobacion.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            txtEfectivo.Focus()
            txtEfectivo.SelectAll()

        End If
    End Sub

    Private Sub frm_formadepago_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If ClosingWithButton = False Then
            e.Cancel = True
        Else
            e.Cancel = False

            CType(Me.Owner, Form).Activate()
        End If
    End Sub

    Private Sub ImageEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles ImageEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True


            If CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
                NavBarCheque.Expanded = True
                If CDbl(txtTarjeta.EditValue) = 0 Then
                    NavBarTarjeta.Expanded = False
                End If

                txtCheque.Focus()
                txtCheque.SelectAll()
            Else
                SendKeys.Send("{TAB}")
            End If


        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True

            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True

            If CDbl(txtEfectivoCobrar.Text) < CDbl(txtMontoCobrar.Text) Then
                NavBarCheque.Expanded = True
                NavBarTarjeta.Expanded = False
                txtCheque.Focus()
                txtCheque.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True

            rdbTipoTarjeta.Focus()
        End If
    End Sub

    Private Sub NavBarControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles NavBarControl1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub cbxBancoCheque_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBancoCheque.KeyDown
        If cbxBancoCheque.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                txtNoCheque.Focus()
                txtNoCheque.SelectAll()


                'ElseIf e.KeyCode = Keys.Down Then
                '    e.Handled = True

                '    If txtDeposito.Enabled = True Then
                '        NavBarDeposito.Expanded = True
                '        txtDeposito.Focus()
                '        txtDeposito.SelectAll()
                '    Else
                '        btnContinuar.Focus()
                '    End If

                'ElseIf e.KeyCode = Keys.Up Then
                '    e.Handled = True

                '    If NavBarTarjeta.Expanded = True Then
                '        cbxBancoTarjeta.Focus()
                '        cbxBancoTarjeta.ShowPopup()
                '    Else
                '        txtEfectivo.Focus()
                '        txtEfectivo.SelectAll()
                '    End If


            End If
        End If
    End Sub

    Private Sub cbxBancoDeposito_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBancoDeposito.KeyDown
        If cbxBancoDeposito.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                SendKeys.Send("{TAB}")

            ElseIf e.KeyCode = Keys.Right Then
                e.Handled = True
                txtInformacionDeposito.Focus()
                txtInformacionDeposito.SelectAll()


                'ElseIf e.KeyCode = Keys.Down Then
                '    e.Handled = True

                '    If txtBonos.Enabled = True Then
                '        NavBarBonos.Expanded = True
                '        txtBonos.Focus()
                '        txtBonos.SelectAll()
                '    Else
                '        btnContinuar.Focus()
                '    End If

                'ElseIf e.KeyCode = Keys.Up Then
                '    e.Handled = True

                '    If NavBarCheque.Expanded = True Then
                '        txtNoCheque.Focus()
                '        txtNoCheque.SelectAll()
                '    ElseIf NavBarTarjeta.Expanded = True Then
                '        cbxBancoTarjeta.Focus()
                '        cbxBancoTarjeta.ShowPopup()
                '    ElseIf NavBarEfectivo.Expanded = True Then
                '        txtEfectivo.Focus()
                '        txtEfectivo.SelectAll()
                '    End If


            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If FlowBotones.Controls.Count <= 5 Then
            FlowBotones.Height = 50
            SeparatorControl4.Location = New Point(-8, 43)

            Label10.Location = New Point(0, 62)
            txtEfectivo.Location = New Point(96, 59)
            SeparatorControl3.Location = New Point(-12, 76)
            Label11.Location = New Point(42, 96)
            txtDevolucionEfectivo.Location = New Point(96, 93)
            ListadeDevolucion.Location = New Point(224, 56)
            NavBarGroupControlContainer1.Height = 118 + ((ListadeDevolucion.Items.Count) * 15)
        Else
            FlowBotones.Height = 100
            SeparatorControl4.Location = New Point(-8, 97)
            Label10.Location = New Point(0, 121)
            txtEfectivo.Location = New Point(96, 118)
            SeparatorControl3.Location = New Point(-12, 135)
            Label11.Location = New Point(42, 155)
            txtDevolucionEfectivo.Location = New Point(96, 152)
            ListadeDevolucion.Location = New Point(224, 115)
            NavBarGroupControlContainer1.Height = 176 + ((ListadeDevolucion.Items.Count) * 15)

        End If

        txtEfectivo.Focus()
        txtEfectivo.SelectAll()
        Timer1.Enabled = False
    End Sub

    Private Sub frm_formadepago_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtEfectivo.Focus()
        txtEfectivo.SelectAll()
    End Sub

    Private Sub CalcularMejorDevolucion(ByVal Devuelta As Double)
        Dim RealValue, RemainingValue As Decimal
        Dim EntereValue, RemainingMoney, ResidualValue As Double
        Dim Sobrante As Double = CDbl(txtDevolucionEfectivo.EditValue)
        Dim lt As New ArrayList

        ListadeDevolucion.Items.Clear()

        For Each Billete As String In Billetes

            Sobrante = (Math.Round(CDbl(Sobrante), 3))
            ResidualValue = 0

            If Sobrante >= CDbl(Billete) Then
                RealValue = CDbl(Sobrante) / CDbl(Billete)
                RemainingValue = RealValue - Int(RealValue)
                EntereValue = RealValue - RemainingValue
                RemainingMoney = CDbl(CDbl(Billete) * EntereValue)
                ResidualValue = Sobrante - RemainingMoney
                Sobrante = ResidualValue

                Dim itm As New DevExpress.XtraEditors.Controls.ImageListBoxItem

                itm.Description = EntereValue & " [" & Num2Text(EntereValue).ToLower & "] " & "de " & CDbl(Billete).ToString("C")

                If cbxMoneda.EditValue = 1 Then
                    If Billete = 2000 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._2000, 24)
                    ElseIf Billete = 1000 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._1000, 24)
                    ElseIf Billete = 500 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._500, 24)
                    ElseIf Billete = 200 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._200, 24)
                    ElseIf Billete = 100 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._100, 24)
                    ElseIf Billete = 50 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._50, 24)
                    ElseIf Billete = 25 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._25, 24)
                    ElseIf Billete = 20 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._20, 24)
                    ElseIf Billete = 10 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._10, 24)
                    ElseIf Billete = 5 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._5, 24)
                    ElseIf Billete = 1 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources._1, 24)
                    Else
                        itm.ImageOptions.Image = Nothing
                    End If

                ElseIf cbxMoneda.EditValue = 2 Then
                    If Billete = 100 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx100, 24)
                    ElseIf Billete = 50 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.doolarx50, 24)
                    ElseIf Billete = 20 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx20, 24)
                    ElseIf Billete = 10 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx10, 24)
                    ElseIf Billete = 5 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx5, 24)
                    ElseIf Billete = 1 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx1, 24)
                    ElseIf Billete = 0.5 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx0_5, 24)
                    ElseIf Billete = 0.1 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx0_1, 24)
                    ElseIf Billete = 0.01 Then
                        itm.ImageOptions.Image = ResizeImage(My.Resources.dolarx0_01, 24)
                    Else
                        itm.ImageOptions.Image = Nothing
                    End If

                End If

                ListadeDevolucion.Items.Add(itm)

            End If

        Next

        FormatoNavBarEfectivo()
    End Sub


    Private Function IsInTableTransaccionID(ByVal IDTransaccionToFind As String) As Boolean
        Dim status As Boolean = False
        For Each RW As DataRow In TablaCobrosAdelantadados.Rows
            If RW.Item("IDCobrosAdelantados") = IDTransaccionToFind Then
                status = True
                If status = True Then
                    Exit For
                End If
            End If
        Next

        Return status
    End Function
    Private Sub AdvBandedGridView1_ShownEditor(sender As Object, e As EventArgs) Handles AdvBandedGridView1.ShownEditor
        'If AdvBandedGridView1.FocusedColumn.FieldName = "IDCobrosAdelantados" Then
        If AdvBandedGridView1.FocusedRowHandle >= 0 Then
            If IsNumeric(AdvBandedGridView1.GetFocusedRowCellValue("IDCobrosAdelantados")) Then
                AdvBandedGridView1.HideEditor()
            Else
                AdvBandedGridView1.ShowEditor()
            End If
        End If

        'End If
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanging(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanging
        If e.Column.FieldName = "Utilizar" Then
            If IsNumeric(e.Value) Then
                If CDbl(e.Value) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Disponible")) Then
                    AdvBandedGridView1.SetFocusedRowCellValue("Utilizar", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Disponible")))
                End If
            End If

        End If
    End Sub

    Private Sub AdvBandedGridView1_ValidateRow(sender As Object, e As XtraGrid.Views.Base.ValidateRowEventArgs) Handles AdvBandedGridView1.ValidateRow
        If AdvBandedGridView1.IsNewItemRow(e.RowHandle) Then
            Dim obj As DataRowView = AdvBandedGridView1.GetRow(e.RowHandle)
            If IsDBNull(obj.Item("IDCobrosAdelantados")) Then
                e.ErrorText = "No se ha encontrado una transacción válida para anexar al registro."
                e.Valid = False
            Else
                If IsNumeric(obj.Item("Utilizar")) Then
                    If CDbl(obj.Item("Utilizar")) > 0 Then

                        e.Valid = True

                    Else
                        e.ErrorText = "No se ha específicado un monto válido para anexar el registro."
                        e.Valid = False
                    End If
                Else
                    e.ErrorText = "No se ha específicado un monto válido para anexar el registro."
                    e.Valid = False
                End If
            End If
        End If
    End Sub

    Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
        'Try
        If e.Column.FieldName = "Eliminar" Then

                If AdvBandedGridView1.GetFocusedRowCellValue("IDCobrosAdelantados_hijo").ToString = "" Then
                    AdvBandedGridView1.DeleteRow(e.RowHandle)
                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro de cobros adelantados de la transacción." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Eliminar cobros adelantados", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                    sqlQ = "Delete from cobrosadelantados_hijos Where IDCobrosAdelantados_hijo=(" + AdvBandedGridView1.GetFocusedRowCellValue("IDCobrosAdelantados_hijo").ToString + ")"
                    GuardarDatos()

                        AdvBandedGridView1.DeleteRow(e.RowHandle)
                    End If

                End If


            End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub AdvBandedGridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles AdvBandedGridView1.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("IDCobrosAdelantados_hijo"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("IDCobrosAdelantados"), "")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Fecha"), Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        view.SetRowCellValue(e.RowHandle, view.Columns("Disponible"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("Utilizar"), 0)
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
        If e.Column.FieldName = "SecondID" Then
            If e.Value = "" Then
            Else
                Dim ds As New DataSet

                Con.Open()
                cmd = New MySqlCommand("Select IDCobrosAdelantados,SecondID,timestamp(Fecha, Hora) As Fecha,Monto FROM cobrosadelantados where SecondID='" + e.Value.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "cobrosadelantados")
                Con.Close()

                Dim Tabla As DataTable = ds.Tables("cobrosadelantados")

                If Tabla.Rows.Count > 0 Then
                    Con.Open()
                    cmd = New MySqlCommand("SELECT coalesce(sum(cobrosadelantados_hijos.Monto),0) FROM cobrosadelantados_hijos INNER JOIN Libregco.CobrosAdelantados on Cobrosadelantados_hijos.IDCobrosAdelantados=CobrosAdelantados.IDCobrosAdelantados where CobrosAdelantados.SecondID='" + e.Value.ToString + "'", Con)
                    Dim MontoDisponible As Double = CDbl(Tabla.Rows(0).Item("Monto")) - Convert.ToDouble(cmd.ExecuteScalar)
                    Con.Close()

                    If MontoDisponible > 0 Then
                        If IsInTableTransaccionID(Tabla.Rows(0).Item("IDCobrosAdelantados")) = False Then
                            AdvBandedGridView1.SetFocusedRowCellValue("IDCobrosAdelantados", Tabla.Rows(0).Item("IDCobrosAdelantados"))
                            AdvBandedGridView1.SetFocusedRowCellValue("Fecha", CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt"))
                            AdvBandedGridView1.SetFocusedRowCellValue("Disponible", MontoDisponible)

                            If MontoDisponible > CDbl(txtMontoCobrar.Text) Then
                                AdvBandedGridView1.SetFocusedRowCellValue("Utilizar", CDbl(txtMontoCobrar.Text))
                            Else
                                AdvBandedGridView1.SetFocusedRowCellValue("Utilizar", MontoDisponible)
                            End If

                        Else
                            MessageBox.Show("La transacción de cobros adelantados ya se encuentra ingresada al registro.")
                            AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                        End If
                    Else
                        MessageBox.Show("La transacción de cobros adelantados no posee balance disponible..")
                        AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    End If


                Else
                    MessageBox.Show("No se ha encontrado ninguna transacción de cobros adelantados con el código ingresado." & vbNewLine & vbNewLine & "Por favor intente nuevamente.")
                    AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                End If
            End If


        End If
    End Sub

    Private Sub AdvBandedGridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AdvBandedGridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("IDCobrosAdelantados")) = "" Then
            Else
                e.Appearance.BackColor = SystemColors.Control
                e.Appearance.BackColor2 = SystemColors.Control
                e.Appearance.ForeColor = SystemColors.ControlDarkDark
            End If
        End If
    End Sub
End Class